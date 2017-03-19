using Prism.Mvvm;
using SimpleHmi.PlcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHmi.ViewModels
{
    class HmiStatusBarViewModel : BindableBase
    {
        public ConnectionStates ConnectionState
        {
            get { return _connectionState; }
            set { SetProperty(ref _connectionState, value); }
        }
        private ConnectionStates _connectionState;

        public TimeSpan ScanTime
        {
            get { return _scanTime; }
            set { SetProperty(ref _scanTime, value); }
        }
        private TimeSpan _scanTime;

        private readonly IPlcService _plcService;

        public HmiStatusBarViewModel(IPlcService plcService)
        {
            _plcService = plcService;
            _plcService.ValuesRefreshed += OnPlcServiceValuesRefreshed;
            OnPlcServiceValuesRefreshed(null, EventArgs.Empty);
        }

        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            ConnectionState = _plcService.ConnectionState;
            ScanTime = _plcService.ScanTime;
        }
    }
}
