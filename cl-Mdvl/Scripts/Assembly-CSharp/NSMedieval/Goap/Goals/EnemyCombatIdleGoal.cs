using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class EnemyCombatIdleGoal : Goal
	{
		private const float EnemyWaitTimeMin = 10f;

		private const float EnemyWaitTimeMax = 15f;

		private readonly System.Random rnd;

		private ActiveRaidInfo raidInfo;

		public EnemyCombatIdleGoal(Agent selfAgent)
			: base("EnemyCombatIdleGoal", selfAgent)
		{
			rnd = new System.Random();
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || !MonoSingleton<CombatTargetManager>.IsInstantiated())
			{
				return false;
			}
			EnemyBehaviour enemyBehaviour = ((HumanoidInstance)base.AgentOwner).EnemyBehaviour;
			if (enemyBehaviour != null && raidInfo == null && enemyBehaviour.RaidId != 0)
			{
				raidInfo = ActiveRaidInfo.GetById(enemyBehaviour.RaidId);
			}
			if (raidInfo == null || raidInfo.TrebuchetsCount == 0)
			{
				return false;
			}
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			CombatAiAgent combatAi = humanoidInstance.CombatAi;
			if (combatAi == null || combatAi.IsStateSet(CombatAiState.NeverIdle))
			{
				return false;
			}
			if (MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(humanoidInstance) != null)
			{
				return false;
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GeneralActions.Wait(UnityEngine.Random.Range(10f, 15f));
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			if (raidInfo != null && !raidInfo.HasEngaged)
			{
				return true;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			MapNode idlePointForEnemy = creatureBase.Map.IdlePoints.GetIdlePointForEnemy(creatureBase);
			if (idlePointForEnemy == null)
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(idlePointForEnemy.Position));
			return true;
		}
	}
}
