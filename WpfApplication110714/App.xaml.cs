using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication110714.ViewModel;

namespace WpfApplication110714
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // here we override the startup event
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //this is where we will actuall inject the viewmodel. We will create an instance of the viewmodel
            //(which we haven't done yet) and then set the DataContext of our window from there. 
            MainWindow window = new MainWindow();
            var viewModel = new MainWindowViewModel();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
