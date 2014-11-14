using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using WpfApplication110714.DataAccess;
using WpfApplication110714.Model;

namespace WpfApplication110714.ViewModel
{
    class EmployeeListViewModel : ViewModelBase
    {   /*Overall this class has a field that is not a collection but
         also has a property which handles a collection. Then in the
         constructor we instantiate our field, retrieve data from the
         model (repository) and set that in our public property. Also notice that
         we have specified readonly and don't have a field for AllEmployees. I 
         think this again adheres better to the purpose of the viewmodel. The 
         viewmodel is a model for viewing the data in a way that the view can use.
         So I create it to hold data a certain way but not replicate the model.*/

        readonly EmployeeRepository _employeeRepository;

        //this field is only instantiated if we hit a button "Check for Invasion" which 
        //uses our InvasionCommand Property.
        RelayCommand _invasionCommand;

        /*So as part of our viewmodel structure we add a public property
         * here that the view will be able to use. We don't add it directly
         into the EmployeeRepository class because it would violate the 
         * separation we want between the ViewModel and the Model because now
         we would have a property used by the view within our model. Also there
         * is no specific collection field for this collection property. It 
         is set by a method in the constructor.*/
        public ObservableCollection<Model.Employee> AllEmployees
        {
            get;
            private set;
        }

        public EmployeeListViewModel(EmployeeRepository employeeRepository)
        /*So when another class instantiates this class into an object this 
         constructor sets the _employeeRepository to the argument provided.*/
        {
            if (employeeRepository == null)
            {
                throw new ArgumentNullException("employeeRepository");

            }
            _employeeRepository = employeeRepository;
            /*Here we retrieve the concrete employees that will be displayed. The
             GetEmployees method returns a list of employees and ObservableCollection
             can accept a list.*/
            this.AllEmployees =
                new ObservableCollection<Model.Employee>(_employeeRepository.GetEmployees());
        }

        protected override void OnDispose()
        {
            this.AllEmployees.Clear();
        }

        private Brush _bgBrush;
        public Brush BackgroundBrush
        {
            get
            {
                return _bgBrush;
            }
            set
            {
                _bgBrush = value;
                OnPropertyChanged("BackgroundBrush");
            }
        }

        /*This property instantiates a new _invasionCommand only if...  It initates the get only (in this example)
         when we press a certain button in our view. We could have specified any UI object to do this. So important
         here is the property get process initiates everything.*/
        public ICommand InvasionCommand
        {
            get {
                if (_invasionCommand == null)
                {//we instantaniate a new RelayCommand with these arguments which are lambda expressions for brevity.
                    //We can pass the these two method calls because they fit the signature of Action and Predicate
                    //we don't have to provide the type because C#'s compliler will use its type inference feature 
                    //we could have used anonymous expression but that would have required us to state the return type
                    _invasionCommand = new RelayCommand(param => this.InvasionCommandExecute(), param => this.InvasionCommandCanExecute);
                }
                /*And so what we get is a RelayCommand object with InvasionCommandExecute as the Action and InvasionCommandCanExecute
                 as the predicate. Those methods are executed and so forth.*/
                return _invasionCommand;
                }
        }

        void InvasionCommandExecute() {
            bool isinvasion = true;
            foreach(Model.Employee emp in this.AllEmployees)
            {
                if(emp.LastName.Trim().ToLower() != "smith")
                {
                    isinvasion = false;
                }

            }
            if(isinvasion)
            {
                BackgroundBrush = new SolidColorBrush(Colors.Green);
            }
            else
            {
                BackgroundBrush = new SolidColorBrush(Colors.White);
            }
        }

        bool InvasionCommandCanExecute
        {
            get
            {
                if (this.AllEmployees.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
