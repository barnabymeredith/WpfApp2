using System.Collections.Generic;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.Services;
using WpfApp2.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp2.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Player> _PlayersList;
        public DatabaseAccess _DatabaseAccess;

        public PlayerViewModel(DatabaseAccess databaseAccess)
        {
            _DatabaseAccess = databaseAccess;
            _PlayersList = databaseAccess.ReadPlayers();
        }

        public void Refresh()
        {
            _PlayersList = _DatabaseAccess.ReadPlayers();
        }

        public ObservableCollection<Player> Players
        {
            get { return _PlayersList; }
            set 
            { 
                _PlayersList = value;
                OnPropertyChanged("Players");
            }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater(this);
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private ICommand mCreator;
        public ICommand CreateCommand
        {
            get
            {
                if (mCreator == null)
                    mCreator = new Create(this);
                return mCreator;
            }
            set
            {
                mCreator = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
