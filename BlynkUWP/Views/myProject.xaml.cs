using BlynkLibrary.DataManager;
using BlynkLibrary.Models;
using BlynkUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
        public Dictionary<string, string> pinData { get; set; }
        //public Dictionary<string, string> pinsStorage { get; set; }
        public List<KeyValuePair<string, string>> pinsStorage { get; set; }

        ObservableCollection<SwitchData> ToggleItems = new ObservableCollection<SwitchData>();
        public myProject()
        {
            this.InitializeComponent();
            //pinsStorage = k.ToDictionary(a => a.Key, a => a.Value);
            refresh();            
        }

        public async void refresh()
        {
            DataManager.StatusCode status = await DataManager.RefreshAsync();
            if (!(await BlynkLibrary.NetworkService.BlynkService.IsInternet()))
            {
                StatusText.Text = "Offline";
            }
            else if (status != DataManager.StatusCode.Success)
            {
                StatusText.Text = "Offline";
            }
            else
            {
                StatusText.Text = "Online";
            }
            currentDevice = DataManager.navDevice;
            string id = currentDevice.Id.ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            string myPages = "";
            foreach (PageStackEntry page in rootFrame.BackStack)
            {
                myPages += page.SourcePageType.ToString() + "\n";
            }
            //stackCount.Text = myPages;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }
    }
}
