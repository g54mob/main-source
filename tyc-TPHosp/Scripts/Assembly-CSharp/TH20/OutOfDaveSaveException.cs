using System;

namespace TH20
{
	public class OutOfDaveSaveException : SaveException
	{
		public OutOfDaveSaveException()
		{
		}

		public OutOfDaveSaveException(string message)
			: base(message)
		{
		}

		public OutOfDaveSaveException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
