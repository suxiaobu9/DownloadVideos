
namespace PowerShellDownloadVideos
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.UrlsList = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirPath = new System.Windows.Forms.TextBox();
            this.btnSelectDirPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.videosGrid = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "URLs";
            // 
            // UrlsList
            // 
            this.UrlsList.Location = new System.Drawing.Point(12, 36);
            this.UrlsList.Name = "UrlsList";
            this.UrlsList.Size = new System.Drawing.Size(776, 80);
            this.UrlsList.TabIndex = 1;
            this.UrlsList.Text = "";
            this.UrlsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlsList_KeyDown);
            this.UrlsList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.UrlsList_KeyUp);
            // 
            // txtDirPath
            // 
            this.txtDirPath.Font = new System.Drawing.Font("微軟正黑體", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDirPath.Location = new System.Drawing.Point(48, 122);
            this.txtDirPath.Name = "txtDirPath";
            this.txtDirPath.ReadOnly = true;
            this.txtDirPath.Size = new System.Drawing.Size(328, 30);
            this.txtDirPath.TabIndex = 4;
            // 
            // btnSelectDirPath
            // 
            this.btnSelectDirPath.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSelectDirPath.Location = new System.Drawing.Point(382, 122);
            this.btnSelectDirPath.Name = "btnSelectDirPath";
            this.btnSelectDirPath.Size = new System.Drawing.Size(50, 30);
            this.btnSelectDirPath.TabIndex = 5;
            this.btnSelectDirPath.Text = "...";
            this.btnSelectDirPath.UseVisualStyleBackColor = true;
            this.btnSelectDirPath.Click += new System.EventHandler(this.btnSelectDirPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Download list";
            // 
            // videosGrid
            // 
            this.videosGrid.AllowUserToAddRows = false;
            this.videosGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.videosGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.videosGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.videosGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.videosGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.videosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.videosGrid.GridColor = System.Drawing.SystemColors.ControlLight;
            this.videosGrid.Location = new System.Drawing.Point(12, 191);
            this.videosGrid.Name = "videosGrid";
            this.videosGrid.ReadOnly = true;
            this.videosGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.videosGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.videosGrid.RowTemplate.Height = 24;
            this.videosGrid.ShowCellToolTips = false;
            this.videosGrid.ShowEditingIcon = false;
            this.videosGrid.Size = new System.Drawing.Size(776, 150);
            this.videosGrid.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAdd.Location = new System.Drawing.Point(701, 122);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Image = global::PowerShellDownloadVideos.Properties.Resources.cloud_download_32px;
            this.btnDownload.Location = new System.Drawing.Point(738, 388);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(50, 50);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PowerShellDownloadVideos.Properties.Resources.folder_32px;
            this.pictureBox1.Location = new System.Drawing.Point(12, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.videosGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectDirPath);
            this.Controls.Add(this.txtDirPath);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UrlsList);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox UrlsList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtDirPath;
        private System.Windows.Forms.Button btnSelectDirPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView videosGrid;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDownload;
    }
}

