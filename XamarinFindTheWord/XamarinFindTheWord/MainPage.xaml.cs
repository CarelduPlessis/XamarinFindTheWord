using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFindTheWord
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();

            Button startBTN = new Button
            {
                Text = "Start Game"
            };
            startBTN.Clicked += StartGame;

            /*
            Button optionsBTN = new Button
            {
                Text = "Settings"
            };*/

            Button ExitAppBTN = new Button
            {
                Text = "Exit App"
            };
            ExitAppBTN.Clicked += ExitApp;

            stackLayout.Children.Add(startBTN);
            stackLayout.Children.Add(ExitAppBTN);

            Content = stackLayout;
        }
        public void StartGame(object sender, EventArgs e)
        {
            var enterPlayerNamePage = new EnterPlayerNamePage();
            Navigation.PushAsync(enterPlayerNamePage);
        }

        public void ExitApp(object sender, EventArgs e)
        {
            /*
             Website: stackoverflow
             Title: How to terminate a Xamarin application?
             url: https://stackoverflow.com/questions/29257929/how-to-terminate-a-xamarin-application
             */
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        
    }
}
