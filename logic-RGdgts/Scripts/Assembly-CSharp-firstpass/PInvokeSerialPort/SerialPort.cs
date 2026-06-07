using System;
using System.Runtime.CompilerServices;
using System.Threading;
using PInvokeSerialPort.Win32PInvoke;

namespace PInvokeSerialPort
{
	public class SerialPort : IDisposable
	{
		private IntPtr _hPort;

		private OVERLAPPED wo;

		private IntPtr _ptrUwo;

		private Thread _rxThread;

		private bool _online;

		private bool _auto;

		private bool _checkSends;

		private Exception _rxException;

		private bool _rxExceptionReported;

		private int _writeCount;

		private int _stateRts;

		private int _stateDtr;

		private int _stateBrk;

		public Action<Exception> OnRxException;

		public int BaudRate;

		public Parity Parity;

		public int DataBits;

		public StopBits StopBits;

		public bool TxFlowCts;

		public bool TxFlowDsr;

		public bool TxFlowX;

		public bool TxWhenRxXoff;

		public bool RxGateDsr;

		public bool RxFlowX;

		public HsOutput UseRts;

		public HsOutput UseDtr;

		public ASCII XonChar;

		public ASCII XoffChar;

		public int RxHighWater;

		public int RxLowWater;

		public int SendTimeoutMultiplier;

		public int SendTimeoutConstant;

		public int RxQueue;

		public int TxQueue;

		public bool AutoReopen;

		public bool CheckAllSends;

		private Handshake _handShake;

		public bool Online => false;

		protected bool RtSavailable => false;

		protected bool Rts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected bool DtrAvailable => false;

		protected bool Dtr
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected bool Break
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string PortName { get; set; }

		public Handshake Handshake
		{
			get
			{
				return default(Handshake);
			}
			set
			{
			}
		}

		public event Action<byte> DataReceived
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SerialPort(string portName)
		{
		}

		public SerialPort(string portName, int baudRate)
		{
		}

		public bool Open()
		{
			return false;
		}

		public void Close()
		{
		}

		private void InternalClose()
		{
		}

		public void Dispose()
		{
		}

		~SerialPort()
		{
		}

		public void Flush()
		{
		}

		protected void ThrowException(string reason)
		{
		}

		public void Write(byte[] toSend)
		{
		}

		public void Write(string toSend)
		{
		}

		public void Write(byte toSend)
		{
		}

		public void Write(char toSend)
		{
		}

		public void WriteLine(string toSend)
		{
		}

		private void CheckResult()
		{
		}

		public void SendImmediate(byte tosend)
		{
		}

		protected void Sleep(int milliseconds)
		{
		}

		protected ModemStatus GetModemStatus()
		{
			return default(ModemStatus);
		}

		protected QueueStatus GetQueueStatus()
		{
			return default(QueueStatus);
		}

		protected virtual bool AfterOpen()
		{
			return false;
		}

		protected virtual void BeforeClose(bool error)
		{
		}

		protected void OnRxChar(byte ch)
		{
		}

		protected virtual void OnTxDone()
		{
		}

		protected virtual void OnBreak()
		{
		}

		protected virtual void OnRing()
		{
		}

		protected virtual void OnStatusChange(ModemStatus mask, ModemStatus state)
		{
		}

		private void ReceiveThread()
		{
		}

		private bool CheckOnline()
		{
			return false;
		}
	}
}
