using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class FriendlyVisitorGoapAgent : Agent
	{
		private HumanoidInstance humanoid;

		public FriendlyVisitorGoapAgent(HumanoidInstance humanoid)
			: base(humanoid, new NPCGoalExecutionManager(humanoid))
		{
			this.humanoid = humanoid;
			base.GoalScheduler.AddToPool(new FaintGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyWithdrawalGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyCombatIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new NPCIdleWalkGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new IdleOnFireGoal(this), enableGoal: true);
		}

		public override void Dispose()
		{
			base.Dispose();
			humanoid = null;
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}
	}
}
