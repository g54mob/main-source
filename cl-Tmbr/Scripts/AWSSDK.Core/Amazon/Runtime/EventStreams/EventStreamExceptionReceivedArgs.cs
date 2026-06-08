using System;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.Runtime.EventStreams
{
	public class EventStreamExceptionReceivedArgs<T> : EventArgs where T : EventStreamException
	{
		public T EventStreamException { get; }

		public EventStreamExceptionReceivedArgs(T eventStreamException)
		{
			EventStreamException = eventStreamException;
		}
	}
}
