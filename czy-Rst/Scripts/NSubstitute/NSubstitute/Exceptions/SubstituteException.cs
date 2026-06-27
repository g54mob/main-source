using System;

namespace NSubstitute.Exceptions
{
	public class SubstituteException : Exception
	{
		public SubstituteException(string message, Exception? innerException)
			: base(message, innerException)
		{
		}

		public SubstituteException()
			: this("")
		{
		}

		public SubstituteException(string message)
			: this(message, null)
		{
		}
	}
}
