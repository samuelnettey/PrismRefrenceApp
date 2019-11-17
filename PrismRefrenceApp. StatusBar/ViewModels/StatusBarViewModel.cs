using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismRefrenceApp.Infrastructure;
using PrismRefrenceApp.StatusBar.Views;

namespace PrismRefrenceApp.StatusBar.ViewModels
{
    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        IEventAggregator _eventAggregator;


        public StatusBarViewModel(IStatusBarView view, IEventAggregator eventAggregator)
            : base(view)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Subscribe(PersonUpdated);
        }

        private string _message = "Ready";
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        private void PersonUpdated(string obj)
        {
            Message = String.Format("{0} was updated.", obj);
        }
    }

   
}
