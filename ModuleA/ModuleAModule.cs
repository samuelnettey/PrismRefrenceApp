using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using PrismRefrenceApp.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;


        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<ToolbarView>();
            _container.RegisterType<IContentView,ContentView>();
            _container.RegisterType<IContentViewViewModel, ContentViewViewModel>();

            _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof (ToolbarView));
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof (ContentView));


            //============View Injection === gives more controll on when and how view are displayed

            //var vm = _container.Resolve<IContentAViewViewModel>();
            //vm.Message = "First View";

            //IRegion region = _manager.Regions[RegionNames.ContentRegion];
            //region.Add(vm.View);

            //var vm2 = _container.Resolve<IContentAViewViewModel>();
            //vm2.Message = "Second View";

            //region.Deactivate(vm.View);
            //region.Add(vm2.View);

        }
    }
}
