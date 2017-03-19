using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleHmi.PlcService
{
    public class DummyPlcService : IPlcService
    {
        public ConnectionStates ConnectionState { get; private set; }

        public bool HighLimit { get; private set; }

        public int InletPumpSpeed { get; private set; }

        public bool LowLimit { get; private set; }

        public int OutletPumpSpeed { get; private set; }

        public bool PumpState { get; private set; }

        public TimeSpan ScanTime { get; private set; }

        public int TankLevel { get; private set; }

        public event EventHandler ValuesRefreshed;

        private System.Timers.Timer _timer;
        private DateTime _lastScanTime;

        public DummyPlcService()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 100;
            InletPumpSpeed = 3;
            OutletPumpSpeed = 2;
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Stop();


            TankLevel -= OutletPumpSpeed;
            TankLevel = Math.Max(TankLevel, 0);


            if (PumpState)
            {
                TankLevel += InletPumpSpeed;
                TankLevel = Math.Min(TankLevel, 100);
            }
            LowLimit = TankLevel < 10;
            HighLimit = TankLevel > 90;
            ScanTime = DateTime.Now - _lastScanTime;
            OnValuesRefreshed();
            _timer.Start();
            _lastScanTime = DateTime.Now;
        }

        public void Connect(string ipAddress, int rack, int slot)
        {
            ConnectionState = ConnectionStates.Connecting;
            OnValuesRefreshed();
            ConnectionState = ConnectionStates.Online;
            _timer.Start();
        }

        public void Disconnect()
        {
            ConnectionState = ConnectionStates.Offline;
            OnValuesRefreshed();
            _timer.Stop();
        }

        public Task WriteSpeedInletPump(short speed)
        {
            return Task.Run(() => { InletPumpSpeed = speed; });
        }

        public Task WriteSpeedOutletPump(short speed)
        {
            return Task.Run(() => { OutletPumpSpeed = speed; });
        }

        public Task WriteStart()
        {
            return Task.Run(() => {
                PumpState = true;
            });
        }

        public Task WriteStop()
        {
            return Task.Run(() => {
                PumpState = false;
            });
        }

        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }
    }
}
