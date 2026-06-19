using System;

namespace TH20
{
	public class CorruptSaveException : SaveException
	{
		public CorruptSaveException()
		{
		}

		public CorruptSaveException(string message)
			: base(message)
		{
		}

		public CorruptSaveException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
