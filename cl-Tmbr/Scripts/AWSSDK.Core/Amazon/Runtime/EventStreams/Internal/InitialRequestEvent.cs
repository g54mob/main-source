using System.IO;

namespace Amazon.Runtime.EventStreams.Internal
{
	public class InitialRequestEvent
	{
		public MemoryStream Payload { get; set; }

		public InitialRequestEvent(IEventStreamMessage message)
		{
			Payload = new MemoryStream(message.Payload);
		}
	}
}
