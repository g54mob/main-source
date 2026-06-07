namespace Gh.Tk
{
	public class ActivityUse : Activity
	{
		private GameObjectX _target;

		private string _usageKey;

		private bool _animationDone;

		private const string AnimationDoneKey = "_animationDone";

		private bool _initialized;

		public ActivityUse(GameObjectX target, string usageKey)
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
