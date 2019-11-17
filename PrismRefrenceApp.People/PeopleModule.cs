using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismRefrenceApp.Infrastructure;
using PrismRefrenceApp.People.ViewModels;
using PrismRefrenceApp.People.Views;

namespace PrismRefrenceApp.People
{
    public class PeopleModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public PeopleModule(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;
        }

        public void Initialize()
        {
            RegisterViewsAndServices();

            IRegion region = _regionManager.Regions[RegionNames.ContentRegion];

            var vm = _container.Resolve<IPersonViewModel>();
            vm.CreatePerson("Bob", "Smith");

            region.Add(vm.View);
            region.Activate(vm.View);

            var vm2 = _container.Resolve<IPersonViewModel>();
            vm2.CreatePerson("Karl", "Sums");
            region.Add(vm2.View);

            var vm3 = _container.Resolve<IPersonViewModel>();
            vm3.CreatePerson("Jeff", "Lock");
            region.Add(vm3.View);
        }

        protected void RegisterViewsAndServices()
        {
            _container.RegisterType<IPersonViewModel, PersonViewModel>();
            _container.RegisterType<IPersonView, PersonView>();
        }
    }
}
