using System;
using Coherence.Brook;

namespace Coherence.Tend.Client
{
	public class UnorderedPacketException : Exception
	{
		public UnorderedPacketException()
		{
		}

		public UnorderedPacketException(string message, SequenceId last, SequenceId received)
		{
		}

		public UnorderedPacketException(string message, Exception inner)
		{
		}
	}
}
