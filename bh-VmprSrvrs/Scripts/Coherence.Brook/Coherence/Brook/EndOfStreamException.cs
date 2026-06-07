using System;

namespace Coherence.Brook
{
	public class EndOfStreamException : Exception
	{
		public EndOfStreamException()
		{
		}

		public EndOfStreamException(int requestedRead, int remainingBits)
		{
		}

		public EndOfStreamException(string message)
		{
		}

		public EndOfStreamException(string message, Exception inner)
		{
		}
	}
}
