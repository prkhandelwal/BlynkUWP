using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkLibrary.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BoardType { get; set; }
        public string Vendor { get; set; }
        public string ConnectionType { get; set; }
        public bool IsUserIcon { get; set; }
    }
}
