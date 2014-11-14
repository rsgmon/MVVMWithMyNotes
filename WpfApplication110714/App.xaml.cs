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

            //this is where we will actually inject the viewmodel. We will create an instance of the viewmodel
            //(which we haven't done yet) and then set the DataContext of our window from there. 
            MainWindow window = new MainWindow();
            //Notice that we create an instance of MainWindowViewModel
            //This is where the control of what UI will be shown on the screen starts!
            var viewModel = new MainWindowViewModel();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
