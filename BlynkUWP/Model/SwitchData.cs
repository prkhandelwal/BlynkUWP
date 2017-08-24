using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlynkUWP.Model
{
    class SwitchData
    {
        public SwitchData(string switchName, bool switchValue)
        {
            SwitchName = switchName;
            SwitchValue = switchValue;
        }

        public string SwitchName { get; set; }
        public bool SwitchValue { get; set; }
    }
}
