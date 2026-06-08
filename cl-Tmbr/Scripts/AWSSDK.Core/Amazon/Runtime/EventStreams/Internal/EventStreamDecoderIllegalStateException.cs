using System;

namespace Amazon.Runtime.EventStreams.Internal
{
	public class EventStreamDecoderIllegalStateException : Exception
	{
		public EventStreamDecoderIllegalStateException(string message)
			: base(message)
		{
		}
	}
}
