using System;

namespace Gh.Tk
{
	public class ActivityWaitFor : Activity
	{
		private readonly Func<bool> _endCondition;

		private readonly bool _ignoreAborting;

		protected float _seconds;

		public ActivityWaitFor(Func<bool> endCondition, bool ignoreAborting = false, float maxDuration = -1f)
		{
		}

		public override void Init()
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
