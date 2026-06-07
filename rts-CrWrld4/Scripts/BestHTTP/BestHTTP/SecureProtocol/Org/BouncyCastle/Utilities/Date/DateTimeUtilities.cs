using System;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities.Date
{
	public class DateTimeUtilities
	{
		public static readonly DateTime UnixEpoch;

		private DateTimeUtilities()
		{
		}

		public static long DateTimeToUnixMs(DateTime dateTime)
		{
			return 0L;
		}

		public static DateTime UnixMsToDateTime(long unixMs)
		{
			return default(DateTime);
		}

		public static long CurrentUnixMs()
		{
			return 0L;
		}
	}
}
