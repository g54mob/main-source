using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class IdleOnFireGoal : Goal
	{
		private bool isTargetWater;

		public IdleOnFireGoal(Agent selfAgent)
			: base("IdleOnFireGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.AgentOwner is CreatureBase creatureBase)
			{
				return creatureBase.IsOnFire;
			}
			return false;
		}

		private float GetMoveSpeedMultiplier()
		{
			return Random.Range(1.75f, 2.45f);
		}

		private float GetDelayAfterRun()
		{
			if (isTargetWater)
			{
				return Random.Range(2f, 3f);
			}
			return Random.Range(0.1f, 0.4f);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(GetMoveSpeedMultiplier());
			yield return GeneralActions.Wait(GetDelayAfterRun());
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			MapNode idlePointForAgentOnFire = creatureBase.Map.IdlePoints.GetIdlePointForAgentOnFire(creatureBase);
			isTargetWater = idlePointForAgentOnFire.IsWater;
			SetTarget(TargetIndex.A, new TargetObject(idlePointForAgentOnFire.Position));
			return true;
		}
	}
}
