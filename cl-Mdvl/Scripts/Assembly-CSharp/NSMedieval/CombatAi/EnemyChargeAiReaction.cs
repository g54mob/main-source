using System.Linq;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class EnemyChargeAiReaction : CombatAiReaction
	{
		private const string EffectorName = "InitialChargeMovementSpeed";

		private readonly ActiveRaidInfo raidInfo;

		private float startDistance;

		public EnemyChargeAiReaction(CombatAiAgent agent)
			: base(agent)
		{
			EnemyBehaviour enemyBehaviour = ((HumanoidInstance)base.CombatAgent).EnemyBehaviour;
			raidInfo = ActiveRaidInfo.GetById(enemyBehaviour.RaidId);
		}

		internal override void Refresh()
		{
			base.Refresh();
			ActiveRaidInfo activeRaidInfo = raidInfo;
			if (activeRaidInfo != null && activeRaidInfo.HasEngaged && !base.CombatAi.IsStateSet(CombatAiState.NeverIdle))
			{
				base.CombatAi.SetState(CombatAiState.NeverIdle, true);
			}
			IDamageTakingAgent state = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (state != null && Vector3.Distance(base.CombatAgent.GetPosition(), state.GetPosition()) <= startDistance / 2f)
			{
				CompleteReaction();
			}
		}

		internal override void OnAgentStateChanges(CombatAiState state, object oldObject, object newObject)
		{
			if (raidInfo == null || raidInfo.HasCharged)
			{
				CompleteReaction();
			}
			else if ((state == CombatAiState.PreferedTarget || state == CombatAiState.LastMissFrom) && raidInfo.HasEngaged && !(startDistance > 0f) && CombatUtils.IsAlive(base.CombatAgent))
			{
				Vector3 vector = ((IDamageTakingAgent)newObject)?.GetPosition() ?? MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.First()?.GetPosition() ?? Vector3.zero;
				if (!(vector == Vector3.zero))
				{
					startDistance = Vector3.Distance(base.CombatAgent.GetPosition(), vector);
					FireEffector();
				}
			}
		}

		private void FireEffector()
		{
			base.CombatAgent.Stats.StartEffector("InitialChargeMovementSpeed");
		}

		private void EndEffector()
		{
			base.CombatAgent.Stats?.EndEffector("InitialChargeMovementSpeed");
		}

		private void CompleteReaction()
		{
			EndEffector();
			base.CombatAi.RemoveReaction(this);
		}
	}
}
