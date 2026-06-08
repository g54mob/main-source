using System.IO;
using Amazon.Runtime.EventStreams;

namespace Amazon.S3.Model
{
	public class RecordsEvent : IS3Event, IEventStreamEvent
	{
		public Stream Payload { get; set; }

		public RecordsEvent()
		{
		}

		public RecordsEvent(IEventStreamMessage message)
		{
			Payload = new MemoryStream(message.Payload);
		}
	}
}
