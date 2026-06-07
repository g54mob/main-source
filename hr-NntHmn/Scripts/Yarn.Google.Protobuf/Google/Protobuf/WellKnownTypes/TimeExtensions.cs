using System;

namespace Google.Protobuf.WellKnownTypes
{
	public static class TimeExtensions
	{
		public static Timestamp ToTimestamp(this DateTime dateTime)
		{
			return null;
		}

		public static Timestamp ToTimestamp(this DateTimeOffset dateTimeOffset)
		{
			return null;
		}

		public static Duration ToDuration(this TimeSpan timeSpan)
		{
			return null;
		}
	}
}
