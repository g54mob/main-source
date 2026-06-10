using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.Goap
{
	public class NPCNegotiatorGoapAgent : Agent
	{
		private HumanoidInstance npc;

		public NPCNegotiatorGoapAgent(HumanoidInstance npc)
			: base(npc, new NPCGoalExecutionManager(npc))
		{
			this.npc = npc;
			base.GoalScheduler.AddToPool(new EnemyWithdrawalGoal(this), enableGoal: true);
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
