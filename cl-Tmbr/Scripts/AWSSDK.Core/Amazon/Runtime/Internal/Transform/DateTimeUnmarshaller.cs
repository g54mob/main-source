using System;
using System.Globalization;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class DateTimeUnmarshaller : IXmlUnmarshaller<DateTime, XmlUnmarshallerContext>, IJsonUnmarshaller<DateTime, JsonUnmarshallerContext>
	{
		private static DateTimeUnmarshaller _instance = new DateTimeUnmarshaller();

		public static DateTimeUnmarshaller Instance => _instance;

		private DateTimeUnmarshaller()
		{
		}

		public static DateTimeUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime Unmarshall(XmlUnmarshallerContext context)
		{
			return UnmarshallInternal(context.ReadText(), treatAsNullable: false).Value;
		}

		public DateTime Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			return UnmarshallInternal(context.ReadText(ref reader), treatAsNullable: false).Value;
		}

		internal static DateTime? UnmarshallInternal(string text, bool treatAsNullable)
		{
			if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
				return ePOCH_START.AddSeconds(result);
			}
			if (text == null)
			{
				if (treatAsNullable)
				{
					return null;
				}
				return DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			}
			return DateTime.Parse(text, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
		}
	}
}
