using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableDecimalUnmarshaller : IXmlUnmarshaller<decimal?, XmlUnmarshallerContext>, IJsonUnmarshaller<decimal?, JsonUnmarshallerContext>
	{
		private static NullableDecimalUnmarshaller _instance = new NullableDecimalUnmarshaller();

		public static NullableDecimalUnmarshaller Instance => _instance;

		private NullableDecimalUnmarshaller()
		{
		}

		public decimal? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return decimal.Parse(text, CultureInfo.InvariantCulture);
		}

		public decimal? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			return decimal.Parse(text, CultureInfo.InvariantCulture);
		}
	}
}
