using System;

namespace TH20
{
	public abstract class SaveException : Exception
	{
		protected SaveException()
		{
		}

		protected SaveException(string message)
			: base(message)
		{
		}

		protected SaveException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
