using System;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class DateTimeEpochLongMillisecondsUnmarshaller : IXmlUnmarshaller<DateTime, XmlUnmarshallerContext>, IJsonUnmarshaller<DateTime, JsonUnmarshallerContext>
	{
		private static DateTimeEpochLongMillisecondsUnmarshaller _instance = new DateTimeEpochLongMillisecondsUnmarshaller();

		public static DateTimeEpochLongMillisecondsUnmarshaller Instance => _instance;

		private DateTimeEpochLongMillisecondsUnmarshaller()
		{
		}

		public static DateTimeEpochLongMillisecondsUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<DateTime>.Unmarshall(context);
		}

		public DateTime Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			long num = LongUnmarshaller.Instance.Unmarshall(context, ref reader);
			DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
			return ePOCH_START.AddMilliseconds(num);
		}
	}
}
