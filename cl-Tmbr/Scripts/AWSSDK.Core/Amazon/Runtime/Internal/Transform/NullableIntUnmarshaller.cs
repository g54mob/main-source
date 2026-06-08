using System.Globalization;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableIntUnmarshaller : IXmlUnmarshaller<int?, XmlUnmarshallerContext>, IJsonUnmarshaller<int?, JsonUnmarshallerContext>
	{
		private static NullableIntUnmarshaller _instance = new NullableIntUnmarshaller();

		public static NullableIntUnmarshaller Instance => _instance;

		private NullableIntUnmarshaller()
		{
		}

		public static NullableIntUnmarshaller GetInstance()
		{
			return Instance;
		}

		public int? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return int.Parse(text, CultureInfo.InvariantCulture);
		}

		public int? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			return int.Parse(text, CultureInfo.InvariantCulture);
		}
	}
}
