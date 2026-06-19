using System;

namespace TH20
{
	public class SaveDeserialisationException : SaveException
	{
		public SaveDeserialisationException()
		{
		}

		public SaveDeserialisationException(string message)
			: base(message)
		{
		}

		public SaveDeserialisationException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
