using System;

namespace TH20
{
	public class CorruptSaveUnstableGameException : SaveException
	{
		public CorruptSaveUnstableGameException()
		{
		}

		public CorruptSaveUnstableGameException(string message)
			: base(message)
		{
		}

		public CorruptSaveUnstableGameException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
