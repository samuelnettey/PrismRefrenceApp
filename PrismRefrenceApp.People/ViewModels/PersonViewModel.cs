using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.PubSubEvents;
using PrismRefrenceApp.Business;
using PrismRefrenceApp.Infrastructure;
using PrismRefrenceApp.People.Views;
using System;

namespace PrismRefrenceApp.People.ViewModels
{

    public class PersonViewModel : ViewModelBase, IPersonViewModel
    {

        IEventAggregator _eventAggregator;

        public string ViewName
        {
            get { return string.Format("{0}, {1}", Person.LastName, Person.FirstName); }
        }

        public DelegateCommand SaveCommand { get; set; }

        public PersonViewModel(IPersonView view, IEventAggregator eventaggregator)
            : base(view)
        {
            _eventAggregator = eventaggregator;
            SaveCommand = new DelegateCommand(Save, CanSave);

            GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
        }

        private void Save()
        {
            Person.LastUpdated = DateTime.Now;
            _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish(String.Format("{0}, {1}", Person.LastName, Person.FirstName));
        }

        private bool CanSave()
        {
            return Person != null && Person.Error == null;
        }

        private Person _person;

        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                _person.PropertyChanged += Person_PropertyChanged;
                OnPropertyChanged("Person");
            }
        }

        private void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public void CreatePerson(string firstName, string lastName)
        {
            Person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 0
            };
        }

    }
}
