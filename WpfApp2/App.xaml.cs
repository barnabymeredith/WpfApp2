using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.View;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WpfApp2.View.MainPage window = new MainPage();
            PlayerViewModel VM = new PlayerViewModel(new Services.DatabaseAccess());
            window.DataContext = VM;
            window.Show();
        }
    }
}
