using System;

namespace Lachee.IO.Exceptions
{
	public class NamedPipeWriteException : Exception
	{
		public int ErrorCode { get; private set; }

		internal NamedPipeWriteException(int err)
		{
		}
	}
}
