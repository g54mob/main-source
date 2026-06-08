using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableFloatUnmarshaller : IXmlUnmarshaller<float?, XmlUnmarshallerContext>, IJsonUnmarshaller<float?, JsonUnmarshallerContext>
	{
		private static NullableFloatUnmarshaller _instance = new NullableFloatUnmarshaller();

		public static NullableFloatUnmarshaller Instance => _instance;

		private NullableFloatUnmarshaller()
		{
		}

		public float? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return float.Parse(text, CultureInfo.InvariantCulture);
		}

		public float? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			return float.Parse(text, CultureInfo.InvariantCulture);
		}
	}
}
