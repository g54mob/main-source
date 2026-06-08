using System;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableDateTimeUnmarshaller : IXmlUnmarshaller<DateTime?, XmlUnmarshallerContext>, IJsonUnmarshaller<DateTime?, JsonUnmarshallerContext>
	{
		private static NullableDateTimeUnmarshaller _instance = new NullableDateTimeUnmarshaller();

		public static NullableDateTimeUnmarshaller Instance => _instance;

		private NullableDateTimeUnmarshaller()
		{
		}

		public static NullableDateTimeUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime? Unmarshall(XmlUnmarshallerContext context)
		{
			return DateTimeUnmarshaller.UnmarshallInternal(context.ReadText(), treatAsNullable: true);
		}

		public DateTime? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			return DateTimeUnmarshaller.UnmarshallInternal(context.ReadText(ref reader), treatAsNullable: true);
		}
	}
}
