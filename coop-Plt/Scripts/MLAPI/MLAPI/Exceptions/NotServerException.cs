using System;

namespace MLAPI.Exceptions
{
	public class NotServerException : Exception
	{
		public NotServerException()
		{
		}

		public NotServerException(string message)
			: base(message)
		{
		}

		public NotServerException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
