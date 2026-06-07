namespace Gh.Tk
{
	public class ActivityLookAt : Activity
	{
		private Actor _target;

		private float _durationPer45Degrees;

		private bool _ignoreTurningAngle;

		private bool _doNotTurn;

		public ActivityLookAt(Actor target, float durationPer45Degrees = 0.5f, bool ignoreTurningAngle = false, bool doNotTurn = false)
		{
		}

		public override void Init()
		{
		}

		public override void Finish()
		{
		}

		public override string GetLogInfo()
		{
			return null;
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		private float GetTurningAngle(Actor actor, Actor target)
		{
			return 0f;
		}

		private float GetCurrentAngle(Actor actor)
		{
			return 0f;
		}

		private static float GetDesiredTurningAngle(Actor source, Actor target)
		{
			return 0f;
		}
	}
}
