using System.Collections.Generic;
using NSEipix;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class PetAttackAiReaction : CombatAiReaction
	{
		public PetAttackAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (!(base.CombatAgent is AnimalInstance animalInstance) || animalInstance.Blueprint == null || animalInstance.AnimalType == AnimalType.Wild || animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.DomesticNpc || (animalInstance.AnimalType == AnimalType.Pet && (!animalInstance.Blueprint.CanAttackAsPet || !animalInstance.PetBattleEnabled)) || base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || base.CombatAi.IsStateSet(CombatAiState.NextTarget))
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
				if (!CombatUtils.IsNullOrDisposed(item) && !(item is HumanoidInstance { WorkerBehaviour: not null }) && item?.CombatAi != null && !item.CombatAi.IsStateSet(CombatAiState.Fainted) && item.CombatAi.IsStateSet(CombatAiState.IsAggressive))
				{
					IDamageTakingAgent damageTakingAgent = item as IDamageTakingAgent;
					if (CombatUtils.IsAttackPossible(base.CombatAgent, damageTakingAgent) && PathfinderUtil.IsPathPossible(animalInstance, item.GetNode()))
					{
						base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
						break;
					}
				}
			}
		}
	}
}
