using NSMedieval.Goap.Goals;
using NSMedieval.State;

namespace NSMedieval.Goap
{
	public class NPCGoalExecutionManager : GoalExecutionManager
	{
		private readonly HumanoidInstance humanoid;

		public NPCGoalExecutionManager(HumanoidInstance humanoid)
			: base(humanoid)
		{
			this.humanoid = humanoid;
		}

		internal override Goal GetNextToStart()
		{
			if (humanoid.HasFainted)
			{
				return GetFromPool("FaintGoal");
			}
			return base.GetNextToStart();
		}

		private Goal GetFromPool(string goalId)
		{
			Goal goal = base.GoalScheduler.GetFromPool(goalId);
			if (goal == null)
			{
				goal = new BanishGoal(humanoid.GetGoapAgent());
				base.GoalScheduler.AddToPool(goal);
			}
			return goal;
		}
	}
}
