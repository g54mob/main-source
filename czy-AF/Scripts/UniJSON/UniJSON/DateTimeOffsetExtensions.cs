using System;

namespace UniJSON
{
	public static class DateTimeOffsetExtensions
	{
		public const long TicksPerSecond = 10000000L;

		public static readonly DateTimeOffset EpochTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, TimeSpan.Zero);

		[Obsolete("Use EpochTime")]
		public static readonly DateTimeOffset EpocTime = EpochTime;
	}
}
