using System;

namespace FluentAssertions.Common
{
	public static class DateTimeExtensions
	{
		public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
		{
			return dateTime.ToDateTimeOffset(TimeSpan.Zero);
		}

		public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, TimeSpan offset)
		{
			return new DateTimeOffset(DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified), offset);
		}
	}
}
