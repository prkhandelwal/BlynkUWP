using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkLibrary.Models
{
    public class Widget
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int Color { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TabId { get; set; }
        public bool IsDefaultColor { get; set; }
        public int DeviceId { get; set; }
        public string PinType { get; set; }
        public int Pin { get; set; }
        public bool PwmMode { get; set; }
        public bool RangeMappingOn { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Value { get; set; }
        public bool PushMode { get; set; }
        public string FontSize { get; set; }
    }
}
