using System;

namespace R3.Internal
{
	internal static class TimeSpanExtensions
	{
		public static TimeSpan Normalize(this TimeSpan timeSpan)
		{
			if (!(timeSpan >= TimeSpan.Zero))
			{
				return TimeSpan.Zero;
			}
			return timeSpan;
		}
	}
}
