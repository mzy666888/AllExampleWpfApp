using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace FilterDataGridModule
{
    public class FilterDataGridModule : IModule
    {
        private readonly IRegionManager regionManager;

        public FilterDataGridModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //throw new NotImplementedException();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
    }
}
