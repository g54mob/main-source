using System;

namespace QRCoder.Exceptions
{
	public class DataTooLongException : Exception
	{
		public DataTooLongException(string eccLevel, string encodingMode, int maxSizeByte)
		{
		}

		public DataTooLongException(string eccLevel, string encodingMode, int version, int maxSizeByte)
		{
		}
	}
}
