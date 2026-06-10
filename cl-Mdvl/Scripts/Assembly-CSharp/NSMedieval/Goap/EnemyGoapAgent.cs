using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class EnemyGoapAgent : Agent
	{
		private HumanoidInstance humanoid;

		public EnemyGoapAgent(HumanoidInstance humanoid)
			: base(humanoid, new NPCGoalExecutionManager(humanoid))
		{
			this.humanoid = humanoid;
			base.GoalScheduler.AddToPool(new FaintGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyWithdrawalGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyStepAsideGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowDigOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowConstructBuildingGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemySelfDefenseGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowMoveOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowAttackOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowOperateSiegeWeaponOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowDeliverSiegeWeaponAmmoOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowCutPlantOrderGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyCombatIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new AttackGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new OperateTrebuchetGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new IdleOnFireGoal(this), enableGoal: true);
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}

		internal override void OnGoalEnded(Goal goal, GoalCondition condition)
		{
			base.OnGoalEnded(goal, condition);
			if (goal != null && goal.Id.Equals("AttackGoal"))
			{
				DelayNextTick(0.85f);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			humanoid = null;
		}
	}
}
