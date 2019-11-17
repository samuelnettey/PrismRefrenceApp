using System.ComponentModel;

namespace PrismRefrenceApp.Infrastructure
{
    public class ViewModelBase : IViewModel, INotifyPropertyChanged
    {
        public IView View { get; set; }

        public ViewModelBase(IView view)
        {
            View = view;
            View.ViewModel = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
