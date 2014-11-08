using System.Collections.ObjectModel;
using WpfApplication110714.DataAccess;

namespace WpfApplication110714.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        readonly EmployeeRepository _employeeRepository;
        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            EmployeeListViewModel viewModel = new EmployeeListViewModel(_employeeRepository);
            this.ViewModels.Add(viewModel);
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }
    }
}
