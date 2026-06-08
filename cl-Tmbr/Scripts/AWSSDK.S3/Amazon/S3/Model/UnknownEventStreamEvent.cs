using Amazon.Runtime.EventStreams;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.S3.Model
{
	public class UnknownEventStreamEvent : Amazon.Runtime.EventStreams.Internal.UnknownEventStreamEvent, IS3Event, IEventStreamEvent
	{
		public UnknownEventStreamEvent()
		{
		}

		public UnknownEventStreamEvent(IEventStreamMessage receivedMessage)
			: this(receivedMessage, receivedMessage.Headers[":event-type"].AsString())
		{
		}

		public UnknownEventStreamEvent(IEventStreamMessage receivedMessage, string eventType)
			: base(receivedMessage, eventType)
		{
		}
	}
}
