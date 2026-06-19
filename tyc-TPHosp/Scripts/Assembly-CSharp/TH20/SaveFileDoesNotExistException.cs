using System;

namespace TH20
{
	public class SaveFileDoesNotExistException : SaveException
	{
		public SaveFileDoesNotExistException()
		{
		}

		public SaveFileDoesNotExistException(string message)
			: base(message)
		{
		}

		public SaveFileDoesNotExistException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
