using System;

namespace Gh.Tk
{
	public class ActivityFindObject<T> : PollActivity
	{
		private Func<T> _findCallback;

		private int _maxRetries;

		private Func<PlayerAlertData> _notFoundAlert;

		public T Result { get; set; }

		public ActivityFindObject(string name, float retryIntervalInSeconds, Func<T> find, Func<PlayerAlertData> notFoundAlert, int maxRetries = 3)
			: base(0f)
		{
		}

		protected override void Poll()
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
