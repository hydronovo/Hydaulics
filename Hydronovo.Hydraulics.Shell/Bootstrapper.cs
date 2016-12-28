using System.Windows;
using Hydronovo.Hydraulics.PT.RiverNetwork;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace Hydronovo.Hydraulics.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(RiverNetworkModule));
        }
    }
}
