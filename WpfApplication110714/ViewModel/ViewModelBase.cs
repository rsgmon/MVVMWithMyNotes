using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication110714.ViewModel
{
    public abstract class ViewModelBase: INotifyPropertyChanged, IDisposable
    {   /*This base class is just here to complete the interfaces we have inherited. 
         This way we can create more concrete classes that look complicated and focus
         on what their for.*/
        protected ViewModelBase()
        {
        }
        /* this is fulfilling the Inotifypropertychanged contract*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /*Completes the IDisposable. Notice the actual OnDispose method is virtual.*/
        public void Dispose()
        {
            this.OnDispose();
        }
        protected virtual void OnDispose()
        {
        }
        
    }
}
