using Prism.Commands;
using Prism.Regions;
using SimpleHmi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleHmi.ViewModels
{
    class LeftMenuViewModel
    {
        public ICommand NavigateToMainPageCommand { get; private set; }

        public ICommand NavigateToSettingsPageCommand { get; private set; }

        private readonly IRegionManager _regionManager;

        public LeftMenuViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateToMainPageCommand = new DelegateCommand(() => NavigateTo("MainPage"));
            NavigateToSettingsPageCommand = new DelegateCommand(() => NavigateTo("SettingsPage"));
        }

        private void NavigateTo(string url)
        {
            _regionManager.RequestNavigate(Regions.ContentRegion, url);
        }
    }
}
