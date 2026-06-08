using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class IntUnmarshaller : IXmlUnmarshaller<int, XmlUnmarshallerContext>, IJsonUnmarshaller<int, JsonUnmarshallerContext>
	{
		private static IntUnmarshaller _instance = new IntUnmarshaller();

		public static IntUnmarshaller Instance => _instance;

		private IntUnmarshaller()
		{
		}

		public static IntUnmarshaller GetInstance()
		{
			return Instance;
		}

		public int Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<int>.Unmarshall(context);
		}

		public int Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<int>.Unmarshall(context, ref reader);
		}
	}
}
