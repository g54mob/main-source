using System;

namespace BestHTTP.Extensions
{
	public readonly struct TimerData
	{
		public readonly DateTime Created;

		public readonly TimeSpan Interval;

		public readonly object Context;

		public readonly Func<DateTime, object, bool> OnTimer;

		public bool IsOnTime(DateTime now)
		{
			return false;
		}

		public TimerData(TimeSpan interval, object context, Func<DateTime, object, bool> onTimer)
		{
			Created = default(DateTime);
			Interval = default(TimeSpan);
			Context = null;
			OnTimer = null;
		}

		public TimerData CreateNew()
		{
			return default(TimerData);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
