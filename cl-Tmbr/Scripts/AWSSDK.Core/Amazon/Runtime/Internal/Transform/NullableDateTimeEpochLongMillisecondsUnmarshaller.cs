using System;
using System.Globalization;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class NullableDateTimeEpochLongMillisecondsUnmarshaller : IXmlUnmarshaller<DateTime?, XmlUnmarshallerContext>, IJsonUnmarshaller<DateTime?, JsonUnmarshallerContext>
	{
		private static NullableDateTimeEpochLongMillisecondsUnmarshaller _instance = new NullableDateTimeEpochLongMillisecondsUnmarshaller();

		public static NullableDateTimeEpochLongMillisecondsUnmarshaller Instance => _instance;

		private NullableDateTimeEpochLongMillisecondsUnmarshaller()
		{
		}

		public DateTime? Unmarshall(XmlUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			long num = long.Parse(text, CultureInfo.InvariantCulture);
			DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
			return ePOCH_START.AddMilliseconds(num);
		}

		public DateTime? Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			string text = context.ReadText(ref reader);
			if (text == null)
			{
				return null;
			}
			long num = long.Parse(text, CultureInfo.InvariantCulture);
			DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
			return ePOCH_START.AddMilliseconds(num);
		}
	}
}
