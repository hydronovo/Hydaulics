using Hydronovo.Hydraulics.PT.RiverNetwork.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Hydronovo.Hydraulics.PT.RiverNetwork
{
    public class RiverNetworkModule : IModule
    {
        private readonly IRegionManager regionManager;

        public RiverNetworkModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainRegion", typeof(RiverNetworkView));
        }
    }
}
