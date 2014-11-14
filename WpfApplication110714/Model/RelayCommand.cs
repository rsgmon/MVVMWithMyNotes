using System;
using System.Diagnostics;
using System.Windows.Input;

namespace WpfApplication110714.Model
{
    class RelayCommand : ICommand
    {/*So overall this class handles the interaction between the view and the viewmodel. 
      One challenge in implementing an MVVM is how to deal with interaction. If we had 
      used a code behind we would have implemented events or commands. Now commands are
      just a feature of XAML and the use of commands in MVVM is not the purpose of commands
      but it provides solution to creating the separation. Essentially programming into 
      the language and using commands for another purpose.*/
        readonly Action<object> _execute; //simplified delegate with void return
        readonly Predicate<object> _canExecute;  //predicates test the returned value of a method

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action<object> execute, Predicate<object> canExectue)
        {//all the constructor does is check for a null and assign our fields to the argument of the constuctor.
        //    the arguments passed are in fact objects. You must pass an Action and a Predicate or basically a
            //method that fits the signature of an Action and Predicate. 
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExectue;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
    
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
