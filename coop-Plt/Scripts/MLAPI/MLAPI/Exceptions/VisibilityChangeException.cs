using System;

namespace MLAPI.Exceptions
{
	public class VisibilityChangeException : Exception
	{
		public VisibilityChangeException()
		{
		}

		public VisibilityChangeException(string message)
			: base(message)
		{
		}

		public VisibilityChangeException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
