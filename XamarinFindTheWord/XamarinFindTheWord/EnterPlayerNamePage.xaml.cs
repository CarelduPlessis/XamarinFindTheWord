using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFindTheWord
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPlayerNamePage : ContentPage
    {
        Entry MyEntry;
        public EnterPlayerNamePage()
        {
            InitializeComponent();

            StackLayout MainstackLayout = new StackLayout();

            MyEntry = new Entry
            {
                Text = "Enter in player name"
            };

            Button subBTN = new Button
            {
                Text = "Next"
            };
            subBTN.Clicked += getPlayerName;

            MainstackLayout.Children.Add(MyEntry);

            MainstackLayout.Children.Add(subBTN);

            Content = MainstackLayout;
        }

        public void getPlayerName(object sender, EventArgs e)
        {
            var hangmanModel = new HangmanModel
            {
                NameOfPlayer = MyEntry.Text
            };
            var gameDifficultyPage = new GameDifficultyPage();
            gameDifficultyPage.BindingContext = hangmanModel;
            Navigation.PushAsync(gameDifficultyPage);
        }
    }
}