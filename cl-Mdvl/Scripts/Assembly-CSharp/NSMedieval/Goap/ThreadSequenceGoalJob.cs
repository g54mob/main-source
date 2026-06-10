namespace NSMedieval.Goap
{
	public class ThreadSequenceGoalJob : ThreadSequenceJob
	{
		private Goal goal;

		public Goal Goal => goal;

		public ThreadSequenceGoalJob(Goal goal)
		{
			this.goal = goal;
		}
	}
}
