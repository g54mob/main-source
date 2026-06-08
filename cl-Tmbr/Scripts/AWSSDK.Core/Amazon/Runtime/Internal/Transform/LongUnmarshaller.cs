using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class LongUnmarshaller : IXmlUnmarshaller<long, XmlUnmarshallerContext>, IJsonUnmarshaller<long, JsonUnmarshallerContext>
	{
		private static LongUnmarshaller _instance = new LongUnmarshaller();

		public static LongUnmarshaller Instance => _instance;

		private LongUnmarshaller()
		{
		}

		public static LongUnmarshaller GetInstance()
		{
			return Instance;
		}

		public long Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<long>.Unmarshall(context);
		}

		public long Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<long>.Unmarshall(context, ref reader);
		}
	}
}
