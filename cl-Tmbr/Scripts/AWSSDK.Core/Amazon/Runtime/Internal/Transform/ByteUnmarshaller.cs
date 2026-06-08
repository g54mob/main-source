using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class ByteUnmarshaller : IXmlUnmarshaller<byte, XmlUnmarshallerContext>, IJsonUnmarshaller<byte, JsonUnmarshallerContext>
	{
		private static ByteUnmarshaller _instance = new ByteUnmarshaller();

		public static ByteUnmarshaller Instance => _instance;

		private ByteUnmarshaller()
		{
		}

		public static ByteUnmarshaller GetInstance()
		{
			return Instance;
		}

		public byte Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<byte>.Unmarshall(context);
		}

		public byte Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<byte>.Unmarshall(context, ref reader);
		}
	}
}
