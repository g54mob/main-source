using System;

namespace PInvokeSerialPort
{
	public class CommPortException : ApplicationException
	{
		public CommPortException(string desc)
		{
		}

		public CommPortException(Exception e)
		{
		}
	}
}
