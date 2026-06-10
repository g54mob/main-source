using System.Collections.Generic;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class WorkerRangedDraftAiPlanGoal : CombatAiPlanningGoal
	{
		private HumanoidInstance humanoid;

		public WorkerRangedDraftAiPlanGoal(Agent selfAgent)
			: base("WorkerRangedDraftAiPlanGoal", selfAgent)
		{
			humanoid = (HumanoidInstance)base.CombatAgent;
			AddInitStep(new ThreadSequenceStep(FindTargets));
		}

		public override bool CanStart(bool isForced = false)
		{
			PathfinderAgentDriver pathDriver = ((IPathfindingAgent)base.AgentOwner).PathDriver;
			if (pathDriver == null || pathDriver.IsMoving || pathDriver.IsProcessing)
			{
				return false;
			}
			if (CombatUtils.GetAttackType(base.CombatAgent) != AttackType.Melee && !base.CombatAi.IsStateSet(CombatAiState.Fainted))
			{
				return !base.CombatAi.IsStateSet(CombatAiState.PreferedTarget);
			}
			return false;
		}

		private bool FindTargets()
		{
			HashSet<IDamageDealAgent> hashSet = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			if (hashSet == null || hashSet.Count == 0)
			{
				return false;
			}
			foreach (IDamageDealAgent item in hashSet)
			{
				if (!CombatUtils.IsNullOrDisposed(item))
				{
					IDamageTakingAgent damageTakingAgent = item as IDamageTakingAgent;
					CombatAiAgent combatAi = item.CombatAi;
					if ((combatAi == null || !combatAi.IsStateSet(CombatAiState.Fainted)) && CombatAttackerPositioningManager.IsInAttackPosition(base.CombatAgent, damageTakingAgent) && (combatAi == null || combatAi.IsStateSet(CombatAiState.IsAggressive)) && CombatUtils.IsAttackPossible(base.CombatAgent, damageTakingAgent))
					{
						base.CombatAi.SetState(CombatAiState.IsDraftAutoTargetSet, true);
						base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
						return true;
					}
				}
			}
			return false;
		}
	}
}
