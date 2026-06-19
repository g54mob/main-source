using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblTitleHistory
	{
		public bool HasUserPlayed { get; }

		public DateTime LastTimeUserPlayed { get; }

		internal XblTitleHistory(XGamingRuntime.Interop.XblTitleHistory interopTitleHistory)
		{
			HasUserPlayed = interopTitleHistory.hasUserPlayed;
			LastTimeUserPlayed = interopTitleHistory.lastTimeUserPlayed.DateTime;
		}
	}
}
