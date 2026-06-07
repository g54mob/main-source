using System;

namespace Gh.Tk
{
	public class ActivityWait : Activity
	{
		private double _totalSeconds;

		protected double _seconds;

		private bool _showProgress;

		private bool _canAbort;

		private int _progress;

		private bool _firstTick;

		private Action<int> _progressCallback;

		private Func<bool> _finishEarlyCondition;

		private Action _tickCallback;

		public ActivityWait(double seconds, bool showProgress = false, bool canAbort = false, Action<int> progressCallback = null, Func<bool> finishEarlyCondition = null, Action tickCallback = null)
		{
		}

		protected void OverrideDuration(float duration)
		{
		}

		protected virtual void ChangeSeconds(float delta)
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
