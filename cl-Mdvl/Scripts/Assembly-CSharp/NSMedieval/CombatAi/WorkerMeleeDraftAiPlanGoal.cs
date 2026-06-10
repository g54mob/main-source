using System.Collections.Generic;
using System.Linq;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class WorkerMeleeDraftAiPlanGoal : CombatAiPlanningGoal
	{
		private readonly HumanoidInstance humanoid;

		private readonly List<IDamageTakingAgent> possibleTargets = new List<IDamageTakingAgent>();

		public WorkerMeleeDraftAiPlanGoal(Agent selfAgent)
			: base("WorkerMeleeDraftAiPlanGoal", selfAgent)
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
			if (CombatUtils.GetAttackType(base.CombatAgent) == AttackType.Melee && !base.CombatAi.IsStateSet(CombatAiState.Fainted) && !base.CombatAi.IsStateSet(CombatAiState.PreferedTarget))
			{
				return !base.CombatAi.IsStateSet(CombatAiState.NextTargetValidated);
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
			possibleTargets.Clear();
			Vector3 position = humanoid.GetPosition();
			foreach (IDamageDealAgent item in hashSet)
			{
				if (possibleTargets.Count >= 3)
				{
					break;
				}
				IDamageTakingAgent damageTakingAgent = item as IDamageTakingAgent;
				if (CombatUtils.IsNullOrDisposed(damageTakingAgent))
				{
					continue;
				}
				CombatAiAgent combatAi = item.CombatAi;
				Vector3 position2 = damageTakingAgent.GetPosition();
				if (Mathf.Abs(position.y - position2.y) > 1.2f || Vector3.Distance(position, position2) > 7f || (combatAi != null && combatAi.IsStateSet(CombatAiState.Fainted)) || (combatAi != null && !combatAi.IsStateSet(CombatAiState.IsAggressive)))
				{
					continue;
				}
				if (CombatAttackerPositioningManager.IsInAttackPosition(base.CombatAgent, damageTakingAgent))
				{
					FocusTarget(damageTakingAgent);
					return true;
				}
				if (!PathfinderUtil.IsPathPossible((IPathfindingAgent)base.CombatAgent, damageTakingAgent.GetNode()))
				{
					continue;
				}
				if (possibleTargets.Count == 0)
				{
					possibleTargets.Add(damageTakingAgent);
					continue;
				}
				for (int i = 0; i < possibleTargets.Count; i++)
				{
					IDamageTakingAgent damageTakingAgent2 = possibleTargets[i];
					IDamageTakingAgent damageTakingAgent3 = CombatAiUtils.PickBestTarget(base.CombatAgent, damageTakingAgent2, damageTakingAgent);
					if (damageTakingAgent3 != damageTakingAgent2)
					{
						possibleTargets.Insert(i, damageTakingAgent3);
						break;
					}
				}
				possibleTargets.Add(damageTakingAgent);
			}
			if (possibleTargets.Count == 0)
			{
				return false;
			}
			FocusTarget(possibleTargets.First());
			return true;
		}

		private void FocusTarget(IDamageTakingAgent target)
		{
			base.CombatAi.SetState(CombatAiState.IsDraftAutoTargetSet, true);
			base.CombatAi.SetState(CombatAiState.NextTargetValidated, target);
		}
	}
}
