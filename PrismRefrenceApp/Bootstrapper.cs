using System;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System.Windows;
using ModuleA;
using PrismRefrenceApp.Infrastructure;
using PrismRefrenceApp.People;
using PrismRefrenceApp.StatusBar;
using PrismRefrenceApp.Toolbar;


namespace PrismRefrenceApp
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }
        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }
        //protected override void ConfigureModuleCatalog()
        //{
        //    Type moduleAType = typeof(ModuleAModule);
        //    ModuleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleAType.Name,
        //        ModuleType = moduleAType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.WhenAvailable,
        //    });
        //}

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();
            catalog.AddModule(typeof(ToolbarModule));
            catalog.AddModule(typeof(PeopleModule));
            catalog.AddModule(typeof(StatusBarModule));

            return catalog;
        }
    }
}
