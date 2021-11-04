using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace ChromeTabsModule
{
    public class ChromeTabsModule : IModule
    {
        private readonly IRegionManager regionManager;

        public ChromeTabsModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}
