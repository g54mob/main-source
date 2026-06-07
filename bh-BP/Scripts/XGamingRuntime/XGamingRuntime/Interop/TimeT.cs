using System;

namespace XGamingRuntime.Interop
{
	public struct TimeT
	{
		private readonly long SecondsSinceUnixEpoch;

		public DateTime DateTime => default(DateTime);

		public TimeT(DateTime time)
		{
			SecondsSinceUnixEpoch = 0L;
		}

		public TimeT(long secondSinceUnixEpoch)
		{
			SecondsSinceUnixEpoch = 0L;
		}
	}
}
