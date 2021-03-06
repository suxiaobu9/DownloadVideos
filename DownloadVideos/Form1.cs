﻿using Newtonsoft.Json;
using DownloadVideos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadVideos
{
    public partial class Form1 : Form
    {
        private string GetGridCellData(DataGridViewRow row, int cell)
        {
            return row.Cells[cell].Value.ToString();
        }

        private List<DownloadList> GridDownLists
        {
            get
            {
                var list = new List<DownloadList>();
                for (var i = 0; i < videosGrid.RowCount; i++)
                {
                    var row = videosGrid.Rows[i];
                    list.Add(new DownloadList
                    {
                        Title = GetGridCellData(row, 0),
                        Size = GetGridCellData(row, 1),
                        Percent = GetGridCellData(row, 2),
                        Speed = GetGridCellData(row, 3),
                        Status = GetGridCellData(row, 4),
                        ETA = GetGridCellData(row, 5),
                    });
                }
                return list;
            }
        }

        private DataTable gridDataTable { get; set; }


        public Form1()
        {
            InitializeComponent();
            this.txtDirPath.Text = Properties.Settings.Default.txtDirPath;
        }

        private void btnSelectDirPath_Click(object sender, EventArgs e)
        {
            using (var browserDialog = new FolderBrowserDialog())
            {
                var result = browserDialog.ShowDialog();
                if (result != DialogResult.OK || string.IsNullOrWhiteSpace(browserDialog.SelectedPath))
                    return;

                this.txtDirPath.Text = browserDialog.SelectedPath;

                ConfigHelper.SetConfigValue(x => x.txtDirPath, browserDialog.SelectedPath);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtDirPath.Text = ConfigHelper.DefaultConfig[txtDirPath.Name].ToString();

            var props = TypeDescriptor.GetProperties(typeof(DownloadList));
            gridDataTable = new DataTable();

            foreach (PropertyDescriptor p in props)
                gridDataTable.Columns.Add(p.Name, p.PropertyType);

            videosGrid.DataSource = gridDataTable;
            //videosGrid.Columns[0].Width = 100;
            videosGrid.Columns[1].Width = 50;
            videosGrid.Columns[2].Width = 50;
            videosGrid.Columns[3].Width = 50;
            videosGrid.Columns[4].Width = 50;
            videosGrid.Columns[5].Width = 150;



            this.videosGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UrlsList.Text))
                return;

            var urls = UrlsList.Text.Split('\n')
                            .Distinct()
                            .Where(x => !string.IsNullOrEmpty(x) && !GridDownLists.Any(y => y.Title == x));

            foreach(var url in urls)
            {
                var newRow = gridDataTable.NewRow();

                newRow["Title"] = url;
                newRow["Status"] = "Queue";

                gridDataTable.Rows.Add(newRow);
            }

            UrlsList.Text = "";
        }

        private bool isPaste = false;

        private void UrlsList_KeyDown(object sender, KeyEventArgs e)
        {
            isPaste = e.KeyCode == Keys.V && e.Control;
        }

        private void UrlsList_KeyUp(object sender, KeyEventArgs e)
        {
            if (!isPaste)
                return;
            isPaste = false;
            this.UrlsList.Text += "\n";
            UrlsList.Select(UrlsList.Text.Length, 0);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(DownLoadVideos);
            t1.Start();
        }

        private void DownLoadVideos()
        {
            var regx = @"\[download\]\s+\d+.\d+%\sof\s\d+.\d+\w+\sat\s+\d+.\d+\w+\/s\sETA\s\d+:\d+";
            var queueData = GridDownLists;
            for (var i = 0; i < queueData.Count; i++)
            {
                var item = queueData[i];
                if (string.IsNullOrEmpty(item.Title))
                    continue;
                var processInfo = new ProcessStartInfo
                    ("youtube-dl.exe", $"-o \"{txtDirPath.Text}\\%(title)s-%(id)s.%(ext)s\" {item.Title}")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                var process = Process.Start(processInfo);

                gridDataTable.Rows[i]["Status"] = "Process";
                
                process.OutputDataReceived += (object outputSender, DataReceivedEventArgs outputevent) =>
                {
                    if (string.IsNullOrEmpty(outputevent.Data) || !Regex.IsMatch(outputevent.Data, regx))
                        return;

                    var tmp = outputevent.Data.Split(' ')
                                .Where(x => !string.IsNullOrEmpty(x.Trim()))
                                .Select(x => x.Trim())
                                .ToList();
                    gridDataTable.Rows[i]["Percent"] = tmp[1];
                    gridDataTable.Rows[i]["Size"] = tmp[3];
                    gridDataTable.Rows[i]["Speed"] = tmp[5];
                    gridDataTable.Rows[i]["ETA"] = tmp[7];
                    Thread.Sleep(200);
                };
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object errorSender, DataReceivedEventArgs errorEvent) =>
                {
                    if (string.IsNullOrEmpty(errorEvent.Data) || errorEvent.Data.ToLower().Contains("error"))
                        return;
                    gridDataTable.Rows[i]["Status"] = errorEvent.Data;
                };

                process.BeginErrorReadLine();

                process.WaitForExit();

                process.Close();
            }

            gridDataTable.Rows.Clear();
        }
    }
}
