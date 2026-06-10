using System.Collections.Generic;
using NSEipix;
using NSMedieval.Goap;
using NSMedieval.Manager;

namespace NSMedieval.CombatAi
{
	public class AttackFirstTargetInPerceptionAiReaction : CombatAiReaction
	{
		public AttackFirstTargetInPerceptionAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || base.CombatAi.IsStateSet(CombatAiState.NextTarget))
			{
				return;
			}
			HashSet<IDamageDealAgent> state = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			if (state == null || state.Count == 0)
			{
				return;
			}
			if (state.Count > 2)
			{
				state.Shuffle();
			}
			foreach (IDamageDealAgent item in state)
			{
				if (item?.CombatAi != null && !item.CombatAi.IsStateSet(CombatAiState.Fainted))
				{
					IDamageTakingAgent damageTakingAgent = item as IDamageTakingAgent;
					if (CombatUtils.IsAttackPossible(base.CombatAgent, damageTakingAgent))
					{
						base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
						break;
					}
				}
			}
		}
	}
}
