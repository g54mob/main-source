using NSEipix.Repository;
using NSMedieval.Goap.Goals;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;

namespace NSMedieval.Goap
{
	public class WorkerGoalExecutionManager : GoalExecutionManager
	{
		private readonly HumanoidInstance humanoid;

		public WorkerGoalExecutionManager(HumanoidInstance humanoid)
			: base(humanoid)
		{
			this.humanoid = humanoid;
		}

		internal override Goal GetNextToStart()
		{
			if (humanoid.WorkerBehaviour.IsBanished)
			{
				return GetFromPool("BanishGoal");
			}
			if (humanoid.WorkerBehaviour.IsDrafting || humanoid.IsBeingCarried)
			{
				return null;
			}
			if (humanoid.HasFainted)
			{
				return GetFromPool("FaintGoal");
			}
			Goal exclusiveGoal = ((WorkerGoapAgent)humanoid.GetGoapAgent()).ExclusiveGoal;
			if (exclusiveGoal != null)
			{
				return exclusiveGoal;
			}
			return base.GetNextToStart();
		}

		protected override bool CanBeInterrupted(Goal goalToInterrupt, Goal goalToInterruptWith)
		{
			if (((WorkerGoapAgent)humanoid.GetGoapAgent()).ExclusiveGoal != null)
			{
				return false;
			}
			if (goalToInterrupt == goalToInterruptWith)
			{
				return false;
			}
			if (Repository<JobRepository, Job>.Instance.IsJobGoal(goalToInterrupt.Id) && Repository<JobRepository, Job>.Instance.IsJobGoal(goalToInterruptWith.Id))
			{
				if (!goalToInterrupt.Id.Equals("RestGoal"))
				{
					return goalToInterrupt.Id.Equals("PatientGoal");
				}
				return true;
			}
			return base.CanBeInterrupted(goalToInterrupt, goalToInterruptWith);
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
