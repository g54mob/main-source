namespace TH20
{
	public class OnlineChallengeState
	{
		public Level Level;

		public OnlineChallengeObjective Owner;

		protected bool _connectionEstablished;

		public virtual void Enter()
		{
		}

		public virtual void Update(float timeDelta)
		{
		}

		public virtual void ConnectionEstablished()
		{
		}

		public virtual void Exit()
		{
		}

		public virtual void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
		}

		public virtual void OnTimelineUpdated(int day)
		{
		}
	}
}
