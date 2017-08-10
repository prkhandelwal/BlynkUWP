using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkLibrary.Models
{
    public class Device
    {
        public int id { get; set; }
        public string name { get; set; }
        public string boardType { get; set; }
        public string token { get; set; }
        public string connectionType { get; set; }
        public string status { get; set; }
        public int disconnectTime { get; set; }
    }
}
