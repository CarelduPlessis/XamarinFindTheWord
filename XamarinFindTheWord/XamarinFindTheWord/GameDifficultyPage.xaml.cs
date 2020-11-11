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
    public partial class GameDifficultyPage : ContentPage
    {
        public GameDifficultyPage()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();

            Button easyBTN = new Button() 
            { 
                Text = "Easy"
            };
            easyBTN.Clicked += Difficulty;

            Button normalBTN = new Button()
            {
                Text = "Normal"
            };
            normalBTN.Clicked += Difficulty;

            Button hardBTN = new Button()
            {
                Text = "Hard"
            };
            hardBTN.Clicked += Difficulty;

            stackLayout.Children.Add(easyBTN);
            stackLayout.Children.Add(normalBTN);
            stackLayout.Children.Add(hardBTN);

            Content = stackLayout;

        }
        public void Difficulty(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            var vm = BindingContext as HangmanModel;

            var hangmanModel = new HangmanModel
            {
                NameOfPlayer = vm.NameOfPlayer,
                Difficulty = btn.Text
            };

            var HangmanPage = new HangmanPage();
            HangmanPage.BindingContext = hangmanModel;
            Navigation.PushAsync(HangmanPage);
        }
    }
}