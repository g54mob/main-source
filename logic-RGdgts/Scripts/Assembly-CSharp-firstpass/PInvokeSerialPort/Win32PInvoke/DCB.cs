namespace PInvokeSerialPort.Win32PInvoke
{
	internal struct DCB
	{
		internal int DCBlength;

		internal int BaudRate;

		internal int PackedValues;

		internal short wReserved;

		internal short XonLim;

		internal short XoffLim;

		internal byte ByteSize;

		internal byte Parity;

		internal byte StopBits;

		internal byte XonChar;

		internal byte XoffChar;

		internal byte ErrorChar;

		internal byte EofChar;

		internal byte EvtChar;

		internal short wReserved1;

		internal void Init(bool parity, bool outCts, bool outDsr, int dtr, bool inDsr, bool txc, bool xOut, bool xIn, int rts)
		{
		}
	}
}
