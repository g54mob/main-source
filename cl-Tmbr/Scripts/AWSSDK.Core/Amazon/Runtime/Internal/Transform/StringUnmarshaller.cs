using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class StringUnmarshaller : IXmlUnmarshaller<string, XmlUnmarshallerContext>, IJsonUnmarshaller<string, JsonUnmarshallerContext>
	{
		private static StringUnmarshaller _instance = new StringUnmarshaller();

		public static StringUnmarshaller Instance => _instance;

		private StringUnmarshaller()
		{
		}

		public static StringUnmarshaller GetInstance()
		{
			return Instance;
		}

		public string Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<string>.Unmarshall(context);
		}

		public string Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<string>.Unmarshall(context, ref reader);
		}
	}
}
