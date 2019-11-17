using PrismRefrenceApp.Infrastructure;

namespace PrismRefrenceApp.People.ViewModels
{
    public interface IPersonViewModel : IViewModel
    {
        void CreatePerson(string firstName, string lastName);
    }
}
