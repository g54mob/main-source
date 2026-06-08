using System;

namespace Amazon.Runtime.EventStreams.Internal
{
	public abstract class EventStreamException : Exception
	{
		protected EventStreamException()
		{
		}

		protected EventStreamException(string message)
			: base(message)
		{
		}

		protected EventStreamException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
