using System;

namespace Ludiq
{
	public class InvalidImplementationException : Exception
	{
		public InvalidImplementationException()
		{
		}

		public InvalidImplementationException(string message)
			: base(message)
		{
		}
	}
}
