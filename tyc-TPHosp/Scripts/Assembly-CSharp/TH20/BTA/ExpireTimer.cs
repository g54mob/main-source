using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	public class ExpireTimer : LevelAction
	{
		public string TimerName;

		public bool Immediately;

		public override TaskStatus OnUpdate()
		{
			if (base.Owner.Level.TimerManager.HasTimerExpired(TimerName))
			{
				return TaskStatus.Success;
			}
			base.Owner.Level.TimerManager.ExpireTimer(TimerName, Immediately);
			return TaskStatus.Success;
		}
	}
}
