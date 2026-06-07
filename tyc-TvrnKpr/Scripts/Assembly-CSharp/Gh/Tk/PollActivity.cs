using System;

namespace Gh.Tk
{
	public class PollActivity : Activity
	{
		protected float _seconds;

		public Action pollAction;

		protected PollActivity(float seconds, bool executePollOnFirstTick = false)
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

		protected virtual void Poll()
		{
		}
	}
}
