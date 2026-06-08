using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableDoubleUnmarshaller : IXmlUnmarshaller<double?, XmlUnmarshallerContext>, IJsonUnmarshaller<double?, JsonUnmarshallerContext>
	{
		private static NullableDoubleUnmarshaller _instance = new NullableDoubleUnmarshaller();

		public static NullableDoubleUnmarshaller Instance => _instance;

		private NullableDoubleUnmarshaller()
		{
		}

		public double? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return double.Parse(text, CultureInfo.InvariantCulture);
		}

		public double? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			return double.Parse(text, CultureInfo.InvariantCulture);
		}
	}
}
