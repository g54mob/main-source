namespace PInvokeSerialPort.Win32PInvoke
{
	internal struct COMMTIMEOUTS
	{
		internal int ReadIntervalTimeout;

		internal int ReadTotalTimeoutMultiplier;

		internal int ReadTotalTimeoutConstant;

		internal int WriteTotalTimeoutMultiplier;

		internal int WriteTotalTimeoutConstant;
	}
}
