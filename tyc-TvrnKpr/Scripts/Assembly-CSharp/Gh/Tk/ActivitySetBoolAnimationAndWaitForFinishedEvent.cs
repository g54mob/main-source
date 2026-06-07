using System;

namespace Gh.Tk
{
	public class ActivitySetBoolAnimationAndWaitForFinishedEvent : Activity
	{
		private string _animation;

		private bool _value;

		private GameObjectX _target;

		public ActivitySetBoolAnimationAndWaitForFinishedEvent(string animation, bool value, GameObjectX target = null, Action initAction = null, Action finishAction = null)
		{
		}

		public override void Init()
		{
		}

		private void Initialize()
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

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}
	}
}
