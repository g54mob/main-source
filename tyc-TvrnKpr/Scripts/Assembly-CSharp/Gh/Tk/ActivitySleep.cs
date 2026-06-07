namespace Gh.Tk
{
	public class ActivitySleep : Activity
	{
		private bool _inBed;

		private float _patronWakeUpTime;

		private Prop _bed;

		public ActivitySleep(bool inBed)
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
