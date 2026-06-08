using System;

namespace Amazon.Runtime.EventStreams
{
	public class EventStreamParseException : Exception
	{
		public EventStreamParseException(string message)
			: base(message)
		{
		}
	}
}
