namespace Amazon.Runtime.EventStreams.Internal
{
	public class UnknownEventStreamEvent : IEventStreamEvent
	{
		public IEventStreamMessage ReceivedMessage { get; set; }

		public string EventType { get; set; }

		public UnknownEventStreamEvent()
		{
		}

		public UnknownEventStreamEvent(IEventStreamMessage receivedMessage, string eventType)
		{
			ReceivedMessage = receivedMessage;
			EventType = eventType;
		}
	}
}
