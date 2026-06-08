using System;

namespace Amazon.Runtime.EventStreams.Internal
{
	public class EventStreamMessageReceivedEventArgs : EventArgs
	{
		public EventStreamMessage Message { get; private set; }

		public object Context { get; private set; }

		public EventStreamMessageReceivedEventArgs(EventStreamMessage message)
		{
			Message = message;
		}

		public EventStreamMessageReceivedEventArgs(EventStreamMessage message, object context)
		{
			Message = message;
			Context = context;
		}
	}
}
