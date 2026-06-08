using System;
using System.Diagnostics;

namespace Amazon.Runtime.Internal.Util
{
	public static class Extensions
	{
		private static readonly long TicksPerSecond = TimeSpan.FromSeconds(1.0).Ticks;

		private static readonly double TickFrequency = (double)TicksPerSecond / (double)Stopwatch.Frequency;

		public static long GetElapsedDateTimeTicks(this Stopwatch self)
		{
			return (long)((double)self.ElapsedTicks * TickFrequency);
		}

		public static bool HasRequestData(this IRequest request)
		{
			if (request == null)
			{
				return false;
			}
			if (request.ContentStream != null || request.Content != null)
			{
				return true;
			}
			return request.Parameters.Count > 0;
		}
	}
}
