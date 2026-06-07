using System;

namespace Gh.Tk
{
	public class SimpleActivity : Activity
	{
		private Action _action;

		public SimpleActivity(Action action)
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}
	}
}
