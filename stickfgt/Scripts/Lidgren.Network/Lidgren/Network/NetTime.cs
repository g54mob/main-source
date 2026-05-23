using System;

namespace Lidgren.Network
{
	public static class NetTime
	{
		private static readonly long s_timeInitialized = Environment.TickCount;

		public static double Now
		{
			get
			{
				return (double)((uint)Environment.TickCount - s_timeInitialized) / 1000.0;
			}
		}

		public static string ToReadable(double seconds)
		{
			if (seconds > 60.0)
			{
				return TimeSpan.FromSeconds(seconds).ToString();
			}
			return (seconds * 1000.0).ToString("N2") + " ms";
		}
	}
}
