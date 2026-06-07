namespace Gh.Tk
{
	public class ActivityUseForDuration : ActivityWait
	{
		private string _usage;

		private GameObjectX _target;

		private bool _paused;

		public ActivityUseForDuration(string usage, GameObjectX target, double seconds, bool showProgress = false, bool canAbort = false)
			: base(0.0)
		{
		}

		public override void Init()
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		private void MaintenanceNecessaryChanged(object sender, EventArgs<Prop> e)
		{
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
