using System;
using System.Collections.Generic;
using TwitchLib.Api.Core.Interfaces;

namespace TwitchLib.Api.Core.RateLimiter
{
	public class PersistentCountByIntervalAwaitableConstraint : CountByIntervalAwaitableConstraint
	{
		private readonly Action<DateTime> _saveStateAction;

		public PersistentCountByIntervalAwaitableConstraint(int count, TimeSpan timeSpan, Action<DateTime> saveStateAction, IEnumerable<DateTime> initialTimeStamps, ITime time = null)
			: base(count, timeSpan, time)
		{
			_saveStateAction = saveStateAction;
			if (initialTimeStamps == null)
			{
				return;
			}
			foreach (DateTime initialTimeStamp in initialTimeStamps)
			{
				base._timeStamps.Push(initialTimeStamp);
			}
		}

		protected override void OnEnded(DateTime now)
		{
			_saveStateAction(now);
		}
	}
}
