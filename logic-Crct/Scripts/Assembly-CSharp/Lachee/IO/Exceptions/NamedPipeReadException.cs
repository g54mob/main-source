using System;

namespace Lachee.IO.Exceptions
{
	public class NamedPipeReadException : Exception
	{
		public int ErrorCode { get; private set; }

		internal NamedPipeReadException(int err)
		{
		}
	}
}
