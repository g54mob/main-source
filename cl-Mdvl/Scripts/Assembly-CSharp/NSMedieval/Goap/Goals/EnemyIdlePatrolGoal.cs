using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class EnemyIdlePatrolGoal : Goal
	{
		private const float EnemyWaitTimeMin = 10f;

		private const float EnemyWaitTimeMax = 60f;

		private readonly System.Random rnd;

		private ActiveRaidInfo raidInfo;

		public EnemyIdlePatrolGoal(Agent selfAgent)
			: base("EnemyIdlePatrolGoal", selfAgent)
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
			HumanoidInstance humanoidInstance = (HumanoidInstance)base.AgentOwner;
			if (MonoSingleton<CombatTargetManager>.Instance.GetPreferredTarget(humanoidInstance) != null)
			{
				return false;
			}
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GeneralActions.Wait(UnityEngine.Random.Range(10f, 60f));
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.2f);
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			MapNode mapNode = ((CreatureBase)base.AgentOwner).GetNode().Region.Nodes.PickRandom((MapNode node) => node.IsVoxelFloor());
			if (mapNode == null)
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(mapNode.Position));
			return true;
		}
	}
}
