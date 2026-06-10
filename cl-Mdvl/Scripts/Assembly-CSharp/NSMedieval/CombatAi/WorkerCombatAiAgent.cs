using System;
using NSMedieval.Goap;
using NSMedieval.State;
using NSMedieval.View;

namespace NSMedieval.CombatAi
{
	public class WorkerCombatAiAgent : CombatAiAgent
	{
		[NonSerialized]
		private HumanoidInstance humanoid;

		public WorkerCombatAiAgent(IGoapAgentOwner owner, string blueprintId)
			: base(owner, blueprintId)
		{
			humanoid = (HumanoidInstance)owner;
		}

		public override AnimatedAgentView GetView()
		{
			return humanoid.GetAgentView<AnimatedAgentView>();
		}

		public override void Enable()
		{
			base.Enable();
			SetState(CombatAiState.IsDraftAutoTargetSet, false);
		}

		public override void Disable()
		{
			base.Disable();
			SetState(CombatAiState.IsDraftAutoTargetSet, false);
		}

		protected override void PreferredTargetUpdated(IDamageDealAgent deal, IDamageTakingAgent newTarget, IDamageTakingAgent oldTarget)
		{
			base.PreferredTargetUpdated(deal, newTarget, oldTarget);
			if (deal == base.AgentOwner && newTarget == null)
			{
				SetState(CombatAiState.IsDraftAutoTargetSet, false);
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			humanoid = null;
		}
	}
}
