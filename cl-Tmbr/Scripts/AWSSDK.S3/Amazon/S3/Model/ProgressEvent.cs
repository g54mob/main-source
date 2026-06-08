using Amazon.Runtime.EventStreams;

namespace Amazon.S3.Model
{
	public class ProgressEvent : IS3Event, IEventStreamEvent
	{
		public Progress Details { get; set; }

		public ProgressEvent()
		{
		}

		public ProgressEvent(IEventStreamMessage message)
		{
			Details = Progress.Unmarshall(message.Payload);
		}
	}
}
