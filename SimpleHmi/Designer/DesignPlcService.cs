using SimpleHmi.PlcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHmi.Designer
{
    class DesignPlcService : IPlcService
    {
        public ConnectionStates ConnectionState
        {
            get
            {
                return ConnectionStates.Online;
            }
        }

        public bool HighLimit
        {
            get { return false; }
        }

        public int InletPumpSpeed
        {
            get { return 1; }
        }

        public bool LowLimit
        {
            get { return true; }
        }

        public int OutletPumpSpeed
        {
            get { return 2; }
        }

        public bool PumpState
        {
            get { return true; }
        }

        public TimeSpan ScanTime
        {
            get
            {
                return TimeSpan.FromMilliseconds(2550);
            }
        }

        public int TankLevel
        {
            get { return 21; }
        }             

        public event EventHandler ValuesRefreshed { add { } remove { } } // avoid warning CS0067

        public void Connect(string ipAddress, int rack, int slot)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task WriteSpeedInletPump(short speed)
        {
            throw new NotImplementedException();
        }

        public Task WriteSpeedOutletPump(short speed)
        {
            throw new NotImplementedException();
        }

        public Task WriteStart()
        {
            throw new NotImplementedException();
        }

        public Task WriteStop()
        {
            throw new NotImplementedException();
        }
    }
}
