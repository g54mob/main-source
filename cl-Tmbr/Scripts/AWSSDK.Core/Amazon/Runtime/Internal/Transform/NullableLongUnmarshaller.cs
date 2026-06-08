using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableLongUnmarshaller : IXmlUnmarshaller<long?, XmlUnmarshallerContext>, IJsonUnmarshaller<long?, JsonUnmarshallerContext>
	{
		private static NullableLongUnmarshaller _instance = new NullableLongUnmarshaller();

		public static NullableLongUnmarshaller Instance => _instance;

		private NullableLongUnmarshaller()
		{
		}

		public long? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return long.Parse(text, CultureInfo.InvariantCulture);
		}

		public long? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			return long.Parse(text, CultureInfo.InvariantCulture);
		}
	}
}
