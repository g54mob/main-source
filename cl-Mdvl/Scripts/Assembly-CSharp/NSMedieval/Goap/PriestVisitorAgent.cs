using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class PriestVisitorAgent : Agent
	{
		private HumanoidInstance npc;

		public PriestVisitorAgent(HumanoidInstance npc)
			: base(npc, new NPCGoalExecutionManager(npc))
		{
			this.npc = npc;
			base.GoalScheduler.AddToPool(new FaintGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyWithdrawalGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new EnemyCombatIdleGoal(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new SermonEventGoalPriest(this), enableGoal: true);
			base.GoalScheduler.AddToPool(new FeastEventGoal(this));
			base.GoalScheduler.AddToPool(new SermonEventGoal(this));
			base.GoalScheduler.AddToPool(new RitualEventGoal(this));
			base.GoalScheduler.AddToPool(new HangingEventGoal(this));
			base.GoalScheduler.AddToPool(new PriestVisitorGoal(this), enableGoal: true);
		}

		public override AnimatedAgentView GetView()
		{
			return npc.GetAgentView<AnimatedAgentView>();
		}

		public override void Dispose()
		{
			base.Dispose();
			npc = null;
		}
	}
}
