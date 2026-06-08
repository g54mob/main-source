using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class BoolUnmarshaller : IXmlUnmarshaller<bool, XmlUnmarshallerContext>, IJsonUnmarshaller<bool, JsonUnmarshallerContext>
	{
		private static BoolUnmarshaller _instance = new BoolUnmarshaller();

		public static BoolUnmarshaller Instance => _instance;

		private BoolUnmarshaller()
		{
		}

		public static BoolUnmarshaller GetInstance()
		{
			return Instance;
		}

		public bool Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<bool>.Unmarshall(context);
		}

		public bool Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<bool>.Unmarshall(context, ref reader);
		}
	}
}
