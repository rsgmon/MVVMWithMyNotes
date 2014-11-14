using System.Collections.ObjectModel;
using WpfApplication110714.DataAccess;

namespace WpfApplication110714.ViewModel
{
             /*So MainWindowViewModel is a collection of
             * concrete viewmodels we will use. Notice we use viewmodel base as
             * the type so we can polymorphically add any type inherited from 
             * viewmodelbase */
    public class MainWindowViewModel : ViewModelBase
    {
        readonly EmployeeRepository _employeeRepository;
        /*this observable collection will hold all our different viewmodels*/
        ObservableCollection<ViewModelBase> _viewModels;

        public MainWindowViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            /*The two lines below create an instance of a viewmodel and adds 
             * it to our collection. Each time we add a ViewModel to our collection
             * you get another entire viewmodel. So if that viewmodel returns all 
             employees, if you added two of them it would display those employees
             twice. You might or might not instantiate more than one of the same
             viewmodel.*/
            EmployeeListViewModel viewModel = new EmployeeListViewModel(_employeeRepository);
            /*EmployeeListView model is constructed with an _employeeRepository. The
             EmployeeListViewModel constructor */
            this.ViewModels.Add(viewModel);
            
        }

        public ObservableCollection<ViewModelBase> ViewModels
        {   /*this property will allow the view to access our view model*/
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
