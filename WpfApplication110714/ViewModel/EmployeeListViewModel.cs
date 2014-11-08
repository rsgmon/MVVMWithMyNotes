using System;
using System.Collections.ObjectModel;
using WpfApplication110714.DataAccess;

namespace WpfApplication110714.ViewModel
{
    class EmployeeListViewModel : ViewModelBase
    {
        readonly EmployeeRepository _employeeRepository;

        public ObservableCollection<Model.Employee> AllEmployees
        {
            get;
            private set;
        }

        public EmployeeListViewModel(EmployeeRepository employeeRepository)
        {
            if(employeeRepository == null)
            {
                throw new ArgumentNullException("employeeRepository");

            }
            _employeeRepository = employeeRepository;
            this.AllEmployees = new ObservableCollection<Model.Employee>(_employeeRepository.GetEmployees());
        }
        protected override void OnDispose()
        {
            this.AllEmployees.Clear();
        }
    }
}
