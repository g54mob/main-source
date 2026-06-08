using System.IO;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.Runtime.EventStreams.Utils
{
	public static class EventStreamUtils
	{
		public static XmlUnmarshallerContext ConvertMessageToXmlContext(IEventStreamMessage message)
		{
			return new XmlUnmarshallerContext(new MemoryStream(message.Payload), maintainResponseBody: false, null);
		}

		public static JsonUnmarshallerContext ConvertMessageToJsonContext(IEventStreamMessage message)
		{
			return new JsonUnmarshallerContext(new MemoryStream(message.Payload), maintainResponseBody: false, null);
		}
	}
}
