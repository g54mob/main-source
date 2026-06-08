using System.Collections.Generic;

namespace Amazon.Runtime.EventStreams
{
	public interface IEventStreamMessage
	{
		Dictionary<string, IEventStreamHeader> Headers { get; set; }

		byte[] Payload { get; set; }

		byte[] ToByteArray();
	}
}
