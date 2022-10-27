using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.ViewModel;

namespace WpfApp2.Commands
{
    public class Updater : ICommand
    {
        private readonly PlayerViewModel _playerViewModel;

        public Updater(PlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }

        #region ICommand Members  

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            Player player = (Player)parameter;
            _playerViewModel._DatabaseAccess.UpdatePlayer(player.PlayerId, player.FirstName, player.LastName, player.Club, player.Nationality, player.Position);
        }

        #endregion
    }
}
