using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableBoolUnmarshaller : IXmlUnmarshaller<bool?, XmlUnmarshallerContext>, IJsonUnmarshaller<bool?, JsonUnmarshallerContext>
	{
		private static NullableBoolUnmarshaller _instance = new NullableBoolUnmarshaller();

		public static NullableBoolUnmarshaller Instance => _instance;

		private NullableBoolUnmarshaller()
		{
		}

		public bool? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string value = context.ReadText();
			if (string.IsNullOrEmpty(value))
			{
				return null;
			}
			return bool.Parse(value);
		}

		public bool? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string value = context.ReadText(ref reader);
			if (string.IsNullOrEmpty(value))
			{
				return null;
			}
			return bool.Parse(value);
		}
	}
}
