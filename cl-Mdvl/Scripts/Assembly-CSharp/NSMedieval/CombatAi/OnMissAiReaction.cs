using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class OnMissAiReaction : CombatAiReaction
	{
		public OnMissAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		public override void OnHitMissed(IDamageDealAgent deal, IDamageTakingAgent take, CombatMissType missType)
		{
			if (deal == base.CombatAgent || take != base.CombatAgent)
			{
				return;
			}
			IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (state == null)
			{
				state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NextTarget);
			}
			if (state != deal && ShouldReact(deal, state))
			{
				IDamageTakingAgent damageTakingAgent = CombatAiUtils.PickBestTarget(base.CombatAgent, (IDamageTakingAgent)deal, state);
				if (damageTakingAgent != state)
				{
					base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
				}
			}
		}

		private bool ShouldReact(IDamageDealAgent newAttacker, IDamageTakingAgent currentTarget)
		{
			if (currentTarget == null)
			{
				return true;
			}
			if (base.CombatAgent is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && base.CombatAgent.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackOrderTarget) == currentTarget)
			{
				return false;
			}
			if (!base.CombatAi.IsStateSet(CombatAiState.IsInCombat))
			{
				return true;
			}
			if (CombatUtils.GetAttackType(newAttacker) == AttackType.Melee && !CombatUtils.IsInAttackRange(base.CombatAgent, currentTarget))
			{
				float num = Vector3.Distance(base.CombatAgent.GetPosition(), currentTarget.GetPosition());
				float num2 = Vector3.Distance(base.CombatAgent.GetPosition(), newAttacker.GetPosition());
				if (num < num2)
				{
					return false;
				}
				return true;
			}
			return Random.value >= 0.5f;
		}
	}
}
