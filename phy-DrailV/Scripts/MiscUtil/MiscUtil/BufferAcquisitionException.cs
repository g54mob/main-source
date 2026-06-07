using System;

namespace MiscUtil
{
	public class BufferAcquisitionException : Exception
	{
		public BufferAcquisitionException(string message)
			: base(message)
		{
		}
	}
}
