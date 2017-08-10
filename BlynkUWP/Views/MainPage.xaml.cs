using BlynkUWP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BlynkLibrary.NetworkService;
using BlynkLibrary.DataManager;
using System.Windows.Input;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BlynkUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static DataManager.StatusCode status { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (AuthKey.Text == "")
            {
                MessageDialog msg = new MessageDialog("Please Enter the Authorization Token");
                await msg.ShowAsync();
                return;
            }
            status = await DataManager.LoginAsync(AuthKey.Text);
            if (status == DataManager.StatusCode.Success)
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values["authToken"] = AuthKey.Text;
                
                this.Frame.Navigate(typeof(Home));
            }
            else
            {
                MessageDialog dialog = new MessageDialog(DataManager.proj.name);
                await dialog.ShowAsync();
            }
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if(rootFrame.CanGoBack)
            {
                this.Frame.BackStack.Clear();
            }
        }

    }

    //protected override void OnNavigatedTo(NavigationEventArgs e)
    //{
    //    Frame rootFrame = Window.Current.Content as Frame;

    //    string myPages = "";
    //    foreach (PageStackEntry page in rootFrame.BackStack)
    //    {
    //        myPages += page.SourcePageType.ToString() + "\n";
    //    }
    //    //stackCount.Text = myPages;

    //    if (rootFrame.CanGoBack)
    //    {
    //        // Show UI in title bar if opted-in and in-app backstack is not empty.
    //        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
    //            AppViewBackButtonVisibility.Visible;
    //    }
    //    else
    //    {
    //        // Remove the UI from the title bar if in-app back stack is empty.
    //        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
    //            AppViewBackButtonVisibility.Collapsed;
    //    }
    //}
}
