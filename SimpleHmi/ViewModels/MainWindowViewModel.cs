using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimpleHmi.Infrastructure;
using SimpleHmi.PlcService;
using SimpleHmi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleHmi.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(MainPage));
            _regionManager.RegisterViewWithRegion(Regions.StatusBarRegion, typeof(HmiStatusBar));
            _regionManager.RegisterViewWithRegion(Regions.LeftMenuRegion, typeof(LeftMenu));
        }
    }
}
