using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Goap.Goals;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class TraderBodyguardGoapAgent : Agent
	{
		private HumanoidInstance humanoid;

		public TraderBodyguardGoapAgent(HumanoidInstance humanoid)
			: base(humanoid, new NPCGoalExecutionManager(humanoid))
		{
			this.humanoid = humanoid;
			base.GoalScheduler.AddToPool(new FaintGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FeastEventGoal(this));
			base.GoalScheduler.AddToPool(new SermonEventGoal(this));
			base.GoalScheduler.AddToPool(new RitualEventGoal(this));
			base.GoalScheduler.AddToPool(new HangingEventGoal(this));
			base.GoalScheduler.AddToPool(new EnemyWithdrawalGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyCombatIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FollowGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new TraderIdleGoal(this), enableGoal: true);
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

		public override void Tick(float deltaTime)
		{
			if (humanoid != null)
			{
				if (humanoid.CombatAi != null)
				{
					FollowTrader();
				}
				base.Tick(deltaTime);
			}
		}

		private void FollowTrader()
		{
			HumanoidInstance state = humanoid.CombatAi.GetState<HumanoidInstance>(CombatAiState.FollowTarget);
			if (state != null && state.IsTrader())
			{
				return;
			}
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				if (item.Faction == humanoid.Faction && item.IsTrader())
				{
					humanoid.CombatAi.SetState(CombatAiState.FollowTarget, item);
				}
			}
		}
	}
}
