using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkLibrary.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool IsPreview { get; set; }
        public string Name { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public List<Widget> Widgets { get; set; }
        public List<Device> Devices { get; set; }
        public string Theme { get; set; }
        public bool KeepScreenOn { get; set; }
        public bool IsAppConnectedOn { get; set; }
        public bool IsShared { get; set; }
        public bool IsActive { get; set; }
        public bool widgetBackgroundOn { get; set; }
        public int color { get; set; }
        public bool isDefaultColor { get; set; }
    }

}
