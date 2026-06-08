using Amazon.Runtime.EventStreams;
using Amazon.Runtime.EventStreams.Internal;

namespace Amazon.S3.Model
{
	public class EndEvent : IS3Event, IEventStreamEvent, IEventStreamTerminalEvent
	{
		public EndEvent()
		{
		}

		public EndEvent(IEventStreamMessage message)
		{
		}
	}
}
