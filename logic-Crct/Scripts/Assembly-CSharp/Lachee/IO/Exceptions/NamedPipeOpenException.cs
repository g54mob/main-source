using System;

namespace Lachee.IO.Exceptions
{
	public class NamedPipeOpenException : Exception
	{
		public int ErrorCode { get; private set; }

		internal NamedPipeOpenException(int err)
		{
		}
	}
}
