using System.IO.Ports;

namespace BatteryTestDevice.ExternalDevice
{
    public class ComPort : IPort
    {
        private SerialPort m_serialPort;

        private object m_locker;

        public object Locker
        {
            get { return m_locker; }
        }

        public ComPort(string com)
        {
            this.m_serialPort = new SerialPort(com);
            this.m_serialPort.BaudRate = 9600;
            this.m_serialPort.RtsEnable = true;
            this.m_serialPort.DtrEnable = true;
            this.m_serialPort.Parity = Parity.None;
            this.m_serialPort.StopBits = StopBits.One;

            this.m_serialPort.WriteTimeout = 1000;
            this.m_serialPort.ReadTimeout = 1000; 

            m_locker = new object();
        }

        public void Open()
        {
            this.m_serialPort.Open();
        }

        public bool IsOpen
        {
            get { return this.m_serialPort.IsOpen; }
        }

        public void Close()
        {
            this.m_serialPort.Close();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            this.m_serialPort.Write(buffer, offset, count);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return this.m_serialPort.Read(buffer, offset, count);
        }

        public override string ToString()
        {
            return this.m_serialPort.PortName;
        }
    }
}
