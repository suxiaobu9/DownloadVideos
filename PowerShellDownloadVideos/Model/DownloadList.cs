using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellDownloadVideos.Model
{
    public class DownloadList
    {
        public string Title { get; set; }

        public string Size { get; set; }

        public string Percent { get; set; }

        public string Speed { get; set; }

        public string Status { get; set; }

        public string ETA { get; set; }

        public string Error { get; set; }
    }
}
