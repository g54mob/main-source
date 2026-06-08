using System.IO;

namespace Amazon.Runtime.EventStreams.Internal
{
	public class InitialResponseEvent : IEventStreamEvent
	{
		public MemoryStream Payload { get; set; }

		public InitialResponseEvent(IEventStreamMessage message)
		{
			Payload = new MemoryStream(message.Payload);
		}
	}
}
