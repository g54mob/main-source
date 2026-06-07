namespace Gh.Tk
{
	public class ActivitySit : Activity
	{
		private bool _animationFinished;

		private readonly bool _sitDown;

		public ActivitySit(bool sitDown)
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

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
