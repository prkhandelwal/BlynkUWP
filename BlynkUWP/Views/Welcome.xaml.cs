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
    public sealed partial class Welcome : Page
    {

        ObservableCollection<InstructionItem> InstructionItems = new ObservableCollection<InstructionItem>();
        public Welcome()
        {

            this.InitializeComponent();
            start();
            //  this.DataContextChanged += (s, e) => Bindings.Update();
        }
        public void start()
        {
            flipView.ItemsSource = InstructionItems;
            flipView.SelectionChanged += flipView_SelectionChanged;

            InitializeInstructionItems();

        }

        private void InitializeInstructionItems()
        {


            string text = "It's Simple ! Tap on Remember Me  Button to regsiter the background services for automating the login process.Tap on Forget Me Button to unregsiter the background services.";
            string welcomeText = "This app is specifically made for  the students of VIT University .To ease the process of  having acces to  Intenet when  connected  to Vit's Wifi Network";
            text = text.Replace("!", " !" + System.Environment.NewLine);
            text = text.Replace(".", System.Environment.NewLine);
            welcomeText = welcomeText.Replace(".", System.Environment.NewLine);
            string loginText = "Say Hey Cortana Wifi Login to Login";
            string logoutText = "Say Hey Cortana Wifi Logout to Lgout";
            string dataText = "Say Hey Cortana Wifi usage or Wifi Check My data or Wifi data consumed  to check your Monthly Data Usage";
            string alertText = "Get alert when you reach your data plan Limit";
            string tileText = "Automatically updates and  check your usage every 15 minutes.Don't Forget to pin the app's tile on Start!";
            string lockText = "Now Say No ,to Browser Login ";
            string planText = "Don't know your renewal date.Don't worry we  got you covered !";

            InstructionItems.Add(new InstructionItem("Welcome",
            welcomeText,
            new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Register", text,
            new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Like Jarvis !",
            loginText,
            new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Like Jarvis !",
            logoutText,
            new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Like Jarvis !",
            dataText,
            new Uri("ms-appx:///Assets/blynk.png")));

            planText = planText.Replace(".", System.Environment.NewLine);
            InstructionItems.Add(new InstructionItem("Stay Informed !",
           planText,
           new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Stay Alerted !",
           alertText,
           new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Lockscreen Login !",
          lockText,
          new Uri("ms-appx:///Assets/blynk.png")));

            tileText = tileText.Replace(".", System.Environment.NewLine);
            InstructionItems.Add(new InstructionItem("Stay Updated !",
           tileText,
           new Uri("ms-appx:///Assets/blynk.png")));

            InstructionItems.Add(new InstructionItem("Ready?",
                 "Everything is easy when you are crazy about it ,right?",
                   null, "MainPage")
               );


        }

        private void flipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var service = this.Frame.GetNavigationService();
            //NavigationService.NavigateAsync(typeof(Views.HelpPage));
            //var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            this.Frame.Navigate(typeof(MainPage));
            //await service.NavigateAsync(typeof(Views.MainPage), new SuppressNavigationTransitionInfo());
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
