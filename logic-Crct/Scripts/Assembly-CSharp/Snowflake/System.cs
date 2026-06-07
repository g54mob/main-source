using System;

namespace Snowflake
{
	public static class System
	{
		public static Func<long> currentTimeFunc;

		private static readonly DateTime Jan1st1970;

		public static long CurrentTimeMillis()
		{
			return 0L;
		}

		public static IDisposable StubCurrentTime(Func<long> func)
		{
			return null;
		}

		public static IDisposable StubCurrentTime(long millis)
		{
			return null;
		}

		private static long InternalCurrentTimeMillis()
		{
			return 0L;
		}
	}
}
