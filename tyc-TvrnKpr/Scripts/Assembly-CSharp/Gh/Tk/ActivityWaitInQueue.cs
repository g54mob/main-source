namespace Gh.Tk
{
	public class ActivityWaitInQueue : Activity
	{
		private Actor _owner;

		private bool _isAnimationPlaying;

		private string _animation;

		private float _seconds;

		private bool _ignoreQueue;

		public ActivityWaitInQueue(bool ignoreQueue)
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

		private void ForceAllQueueAnimsToStop()
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
