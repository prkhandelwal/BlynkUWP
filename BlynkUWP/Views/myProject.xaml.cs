using BlynkLibrary.DataManager;
using BlynkLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BlynkUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class myProject : Page
    {
        public Device currentDevice { get; set; }
        public Dictionary<string,string> pinData { get; set; }
        public Dictionary<string, string> reqPins { get; set; }
        public myProject()
        {
            this.InitializeComponent();
            currentDevice = DataManager.navDevice;
            pinData = DataManager.proj.pinsStorage;
            string id = currentDevice.id.ToString();
            IEnumerable<KeyValuePair<string,string>> k = pinData.Where(a => a.Key.Contains(id + "-"));
            reqPins = k.ToDictionary(a => a.Key, a => a.Value);

        }
    }
}
