using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace XamarinFindTheWord
{
    public class HangmanModel : INotifyPropertyChanged
    {
        public HangmanModel()
        {
        }

        public int Id { get; set; }
        public string NameOfPlayer { get; set; }
        public string Difficulty { get; set; }
        public string StateOfGame { get; set; }
        public int Score { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
