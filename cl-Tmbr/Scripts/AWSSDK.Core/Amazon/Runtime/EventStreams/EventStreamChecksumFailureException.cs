using System;

namespace Amazon.Runtime.EventStreams
{
	public class EventStreamChecksumFailureException : Exception
	{
		public EventStreamChecksumFailureException(string message)
			: base(message)
		{
		}
	}
}
