using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.CombatAi
{
	public class NPCCombatAiAgent : CombatAiAgent
	{
		private HumanoidInstance humanoid;

		public NPCCombatAiAgent(IGoapAgentOwner owner, string blueprintId)
			: base(owner, blueprintId, new CombatAiTargetSwitcherEnemy())
		{
			humanoid = (HumanoidInstance)owner;
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}

		public override void Dispose()
		{
			base.Dispose();
			humanoid = null;
		}
	}
}
