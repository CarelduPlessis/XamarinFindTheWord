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
    public partial class HangmanPage : ContentPage
    {
        Label label;
        Grid gridTopChildTop;
        Grid gridTopChildBottom;
        string[] words = { "world", "skateboard", "hello", "adaptation", "fish", "volleyball", "car" };
        public string Word;
        public int imgIndex = 0;
        public int points = 100;
        public HangmanPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            Grid Maingrid = new Grid();

            Maingrid.RowDefinitions.Add(new RowDefinition { });
            Grid gridTop = new Grid { };
            var gridBottom = new Grid { };

            Grid.SetRow(gridBottom, 1);

            Maingrid.Children.Add(gridTop);
            Maingrid.Children.Add(gridBottom);

            gridTopChildTop = new Grid { VerticalOptions = LayoutOptions.StartAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
            gridTopChildTop.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridTopChildTop.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
           
            gridTopChildBottom = new Grid { };

            Grid.SetRow(gridTopChildBottom, 1);

            gridTop.Children.Add(gridTopChildTop);
            gridTop.Children.Add(gridTopChildBottom);

            Random indexArray = new Random();
            int index = indexArray.Next(0, words.Length);
            Word = words[index];

            var image = new Image
            {
                Source = "Hangman0.png",
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = Application.Current.MainPage.Width * 0.5
            };

            gridTopChildTop.Children.Add(image, 0, 0);

            CreateLabel(Word);
            CreateKeyBoard(gridBottom);

            Content = Maingrid;
        }
        public void AddText(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.IsEnabled = false;
            CheckGuess(btn.Text);
        }

        public void CreateKeyBoard(Grid gridBottom)
        {
            int count = 97;
            int maxcount = 123;
            char myChar = 'a';

            for (int myrow = 0; myrow < 9; myrow++)
            {
                for (int mycolumn = 0; mycolumn < 3; mycolumn++)
                {
                    myChar = Convert.ToChar(count);

                    if (maxcount > count)
                    {
                        Button button = new Button
                        {
                            Text = myChar.ToString(),
                            FontSize = 25,
                            Padding = -5,
                            Margin = -5,
                        };
                        button.Clicked += AddText;
                        gridBottom.Children.Add(button, mycolumn, myrow);
                    }
                    count++;
                }
            }
        }

        public void CheckGuess(string letter)
        {
            /*
             * website: tack overflow
             * Title: How can I get the text value of a label that is a child of a stacklayout which is a child of a Frame inside a listview item
             *  Url: https://stackoverflow.com/questions/39955719/how-can-i-get-the-text-value-of-a-label-that-is-a-child-of-a-stacklayout-which-i
             * 

            */

            /*
           var labelList = gridTop.Children;
           var reqLabel = labelList[1];
           var theLabel = reqLabel.GetType();
            if (theLabel == typeof(Label)) {
                Label randomLabel = (Label)reqLabel;
                randomLabel.Text = letter;
            }
          */
            char[] charArr = Word.ToCharArray(0, Word.Length);
            int index = 0;
            bool IsletterInWord = false;
            foreach (char l in charArr)
            {
                if (l == Convert.ToChar(letter))
                {
                    var labelList = gridTopChildBottom.Children;
                    var reqLabel = labelList[index];
                    var theLabel = reqLabel.GetType();
                    if (theLabel == typeof(Label))
                    {
                        Label randomLabel = (Label)reqLabel;
                        randomLabel.Text = letter;
                        IsletterInWord = true;
                        IsGameOver(imgIndex);
                    }
                }
                index++;
            }

            if (IsletterInWord == false)
            {
                imgIndex++;
                var image = new Image
                {
                    Source = "Hangman" + imgIndex + ".png",
                    Aspect = Aspect.AspectFill,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HeightRequest = Application.Current.MainPage.Width * 0.5
                };
                gridTopChildTop.Children.Add(image, 0, 0);
                points -= 20;
                IsGameOver(imgIndex);
            }
        }

        public void IsGameOver(int countGuess)
        {
            // Website: Youtube
            // Title: Behavior & BindableProperty in Xamarin.Forms by Houssem Dellai
            //URL: https://www.youtube.com/watch?v=dzviFuEU09Y
            var vm = BindingContext as HangmanModel;

            if (countGuess == 6)
            {
                // Player lost the game
                var hangmanModel = new HangmanModel
                {
                    StateOfGame = "You Have Lost the Game",
                    NameOfPlayer = vm.NameOfPlayer,
                    Score = points,
                    Difficulty = vm.Difficulty
                };
                var gameOverPage = new GameOverPage();
                gameOverPage.BindingContext = hangmanModel;
                Navigation.PushAsync(gameOverPage);
            }

            int countCorrentGuess = 0;
            for (int i = 0; i < Word.Length; i++)
            {
                var labelList = gridTopChildBottom.Children;
                var reqLabel = labelList[i];
                var theLabel = reqLabel.GetType();
                if (theLabel == typeof(Label))
                {
                    Label randomLabel = (Label)reqLabel;
                    if (!randomLabel.Text.Contains('_'))
                    {
                        countCorrentGuess++;
                    }
                }
            }

            if (countCorrentGuess == Word.Length && countGuess != 6)
            {
                // Player Won the game
                var hangmanModel = new HangmanModel
                {
                    StateOfGame = "You Have Won the Game",
                    NameOfPlayer = vm.NameOfPlayer,
                    Score = points,
                    Difficulty = vm.Difficulty
                };

                var gameOverPage = new GameOverPage();
                gameOverPage.BindingContext = hangmanModel;
                Navigation.PushAsync(gameOverPage);
            }
        }

        public void CreateLabel(string word)
        {
            int myrow = 2;
            int mycolumn = 0;
            int nextrow = 5;
            for (int i = 0; i < word.Length; i++)
            {
                if (mycolumn > nextrow)
                {
                    myrow++;
                    mycolumn = 0;
                    nextrow += 10;
                }
                label = new Label();
                label.HorizontalTextAlignment = TextAlignment.Center;
                label.Text = "_";
                label.FontSize = 25;
                gridTopChildBottom.Children.Add(label, mycolumn, myrow);
                mycolumn++;
            }
        }
    }
}