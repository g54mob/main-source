namespace Gh.Tk
{
	public class TimeoutActivity : PollActivity
	{
		protected TimeoutActivity(int seconds)
			: base(0f)
		{
		}

		protected override void Poll()
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
