namespace PInvokeSerialPort
{
	public struct ModemStatus
	{
		private readonly uint _status;

		public bool Cts => false;

		public bool Dsr => false;

		public bool Rlsd => false;

		public bool Ring => false;

		internal ModemStatus(uint val)
		{
			_status = 0u;
		}
	}
}
