using System;

namespace NVorbis
{
	public class InvalidDataException : Exception
	{
		public InvalidDataException(string message)
			: base(message)
		{
		}

		public InvalidDataException()
		{
		}
	}
}
