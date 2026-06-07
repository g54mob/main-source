namespace Gh.Tk
{
	public class ActivityWaitForNextFrame : Activity
	{
		private readonly int _frameCreated;

		private bool IsSameFrame()
		{
			return false;
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
