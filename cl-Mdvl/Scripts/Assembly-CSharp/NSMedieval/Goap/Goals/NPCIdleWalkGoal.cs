using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class NPCIdleWalkGoal : Goal
	{
		private float walkSpeed;

		private System.Random random;

		private HumanoidInstance HumanoidInstance => base.AgentOwner as HumanoidInstance;

		public NPCIdleWalkGoal(Agent selfAgent)
			: base("NPCIdleWalkGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<StockpileManager>.IsInstantiated() || !MonoSingleton<AnimationController>.IsInstantiated() || !MonoSingleton<NPCController>.IsInstantiated())
			{
				return false;
			}
			if (HumanoidInstance == null || HumanoidInstance.HasDisposed)
			{
				return false;
			}
			return !HumanoidInstance.IsOnFire;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(walkSpeed);
			GoapAction goapAction = GeneralActions.Instant("Trader-Idle-Wait");
			goapAction.OnInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(base.AgentOwner);
			};
			yield return goapAction;
			yield return GeneralActions.Instant().TriggerAnimation("Bored", ActionAnimationMode.WaitForCompletion);
			yield return GeneralActions.Wait(UnityEngine.Random.value * 2f + 0.75f);
		}

		private bool PrepareData()
		{
			if (!MonoSingleton<NPCController>.IsInstantiated() || base.AgentOwner == null || base.AgentOwner.HasDisposed)
			{
				return false;
			}
			if (random == null)
			{
				random = new System.Random();
			}
			walkSpeed = (float)random.NextDouble() * 0.05f + 0.575f;
			Vec3Int reachablePosition = Vec3Int.zero;
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (reachablePosition.Equals(Vec3Int.zero))
			{
				MapNode idlePointForTrader = creatureBase.Map.IdlePoints.GetIdlePointForTrader(creatureBase);
				if (idlePointForTrader == null)
				{
					return false;
				}
				reachablePosition = idlePointForTrader.Position;
			}
			SetTarget(TargetIndex.A, new TargetObject(reachablePosition));
			return true;
		}
	}
}
