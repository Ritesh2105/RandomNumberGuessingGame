using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace Random_Number_Guessing_Game
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region properties
        
        private string randomNumber;
        public string RandomNumber
        {
            get { return randomNumber; }
            set { randomNumber = value; changed(); }
        }

        private string userguess;
        public string UserGuess
        {
            get { return userguess; }
            set { userguess = value; changed(); }
        }

        private string submit;
        public string Submit
        {
            get { return submit; }
            set { submit = value; changed(); }
        }

        private string visibility = "Hidden";
        public string Visibility
        {
            get { return visibility; }
            set { visibility = value; changed(); }
        }

        private string textRead;

        public string TextRead
        {
            get { return textRead; }
            set { textRead = value; changed(); }
        }


        #endregion

        #region PropertyChange
        public event PropertyChangedEventHandler PropertyChanged;
        private void changed([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
