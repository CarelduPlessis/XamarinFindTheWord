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
    public partial class GameOverPage : ContentPage
    {

        public GameOverPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);

            StackLayout MainstackLayout = new StackLayout();

            Label label = new Label();
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.SetBinding(Label.TextProperty, "StateOfGame");
            label.FontSize = 25;

            Label label1 = new Label();
            label1.HorizontalTextAlignment = TextAlignment.Center;
            label1.SetBinding(Label.TextProperty, "NameOfPlayer", BindingMode.Default, null, "Name Of Player: {0}");
            label1.FontSize = 25;

            Label label2 = new Label();
            label2.HorizontalTextAlignment = TextAlignment.Center;
            label2.SetBinding(Label.TextProperty, "Score", BindingMode.Default, null, "Score: {0}");
            label2.FontSize = 25;

            Label label3 = new Label();
            label3.HorizontalTextAlignment = TextAlignment.Center;
            label3.SetBinding(Label.TextProperty, "Difficulty", BindingMode.Default, null, "Difficulty: {0}");
            label3.FontSize = 25;

            MainstackLayout.Children.Add(label);
            MainstackLayout.Children.Add(label1);
            MainstackLayout.Children.Add(label2);
            MainstackLayout.Children.Add(label3);

            Content = MainstackLayout;
        }
    }
}