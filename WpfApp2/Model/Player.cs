using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp2.Model
{
    public class Player : INotifyPropertyChanged
    {
        private int playerId;
        private string firstName;
        private string lastName;
        private string club;
        private string nationality;
        private string position;

        public int PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
                OnPropertyChanged("PlayerId");
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Club
        {
            get
            {
                return club;
            }
            set
            {
                club = value;
                OnPropertyChanged("Club");
            }
        }
        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                nationality = value;
                OnPropertyChanged("Nationality");
            }
        }
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
