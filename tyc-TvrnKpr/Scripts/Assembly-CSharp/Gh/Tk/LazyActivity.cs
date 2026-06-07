using System;

namespace Gh.Tk
{
	public class LazyActivity : Activity
	{
		private Func<Activity> _createActivity;

		private Activity activity;

		public LazyActivity(Func<Activity> createActivity)
		{
		}

		public override void Init()
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		public override void Finish()
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
