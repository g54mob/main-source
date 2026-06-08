using Amazon.Runtime.EventStreams;

namespace Amazon.S3.Model
{
	public class ContinuationEvent : IS3Event, IEventStreamEvent
	{
		public ContinuationEvent()
		{
		}

		public ContinuationEvent(IEventStreamMessage message)
		{
		}
	}
}
