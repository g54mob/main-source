using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class FloatUnmarshaller : IXmlUnmarshaller<float, XmlUnmarshallerContext>, IJsonUnmarshaller<float, JsonUnmarshallerContext>
	{
		private static FloatUnmarshaller _instance = new FloatUnmarshaller();

		public static FloatUnmarshaller Instance => _instance;

		private FloatUnmarshaller()
		{
		}

		public static FloatUnmarshaller GetInstance()
		{
			return Instance;
		}

		public float Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<float>.Unmarshall(context);
		}

		public float Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			return SimpleTypeUnmarshaller<float>.Unmarshall(context, ref reader);
		}
	}
}
