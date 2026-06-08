using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.Runtime.EventStreams
{
	public abstract class EventStreamPublisher : IEventStreamPublisher
	{
		private class EventStreamRequest : AmazonWebServiceRequest
		{
		}

		private const string HeaderContentType = ":content-type";

		private const string HeaderEventType = ":event-type";

		private const string HeaderMessageType = ":message-type";

		private const string HeaderMessageTypeEvent = "event";

		public abstract Task<IEventStreamMessage> NextEventAsync();

		protected static IEventStreamMessage CreateEventStreamMessage(string eventType, string contentType, IList<EventStreamHeader> marshalledEventHeaders, byte[] eventPayload)
		{
			List<IEventStreamHeader> list = new List<IEventStreamHeader>();
			EventStreamHeader eventStreamHeader = new EventStreamHeader(":content-type")
			{
				HeaderType = EventStreamHeaderType.String
			};
			eventStreamHeader.SetString(contentType);
			list.Add(eventStreamHeader);
			EventStreamHeader eventStreamHeader2 = new EventStreamHeader(":event-type")
			{
				HeaderType = EventStreamHeaderType.String
			};
			eventStreamHeader2.SetString(eventType);
			list.Add(eventStreamHeader2);
			EventStreamHeader eventStreamHeader3 = new EventStreamHeader(":message-type")
			{
				HeaderType = EventStreamHeaderType.String
			};
			eventStreamHeader3.SetString("event");
			list.Add(eventStreamHeader3);
			if (marshalledEventHeaders != null)
			{
				list.AddRange(marshalledEventHeaders);
			}
			return new EventStreamMessage(list, eventPayload);
		}

		protected static JsonMarshallerContext CreateJsonMarshallerContext(Stream stream)
		{
			DefaultRequest request = new DefaultRequest(new EventStreamRequest(), "eventstream");
			Utf8JsonWriter writer = new Utf8JsonWriter(stream);
			return new JsonMarshallerContext(request, writer);
		}
	}
}
