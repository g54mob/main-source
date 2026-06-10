using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class AnimalFleeingIdleGoal : Goal
	{
		private readonly System.Random rnd;

		private bool isRunning;

		private Vec3Int currentIdlePointGridPosition;

		public AnimalFleeingIdleGoal(Agent selfAgent)
			: base("AnimalFleeingIdleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			rnd = new System.Random();
			AddInitStep(new ThreadSequenceStep(PrePrepareData, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		private float Random(float a, float b)
		{
			return Mathf.Min(a, b) + Mathf.Abs(b - a) * (float)rnd.NextDouble();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			float speedMultiplier = (isRunning ? Random(1f, 1.5f) : Random(0.35f, 0.5f));
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(speedMultiplier);
			float time = (float)rnd.NextDouble() * 4.5f + 1.5f;
			MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(base.AgentOwner);
			yield return GeneralActions.Wait(time).TriggerAnimation("Bored", ActionAnimationMode.WaitForCompletion);
		}

		private bool PrePrepareData()
		{
			return true;
		}

		private bool PrepareData()
		{
			if (LoadingController.IsSceneTransition || !MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			Vec3Int lhs = currentIdlePointGridPosition;
			IdlePointManager.AnimalIdlePoint idlePoint;
			MapNode idlePointForAnimal = creatureBase.Map.IdlePoints.GetIdlePointForAnimal(creatureBase, out idlePoint);
			bool flag = rnd != null && rnd.NextDouble() > 0.8999999761581421;
			if (idlePoint == null)
			{
				currentIdlePointGridPosition = idlePointForAnimal.Position;
				isRunning = flag;
			}
			else
			{
				currentIdlePointGridPosition = idlePoint.GridPosition;
				isRunning = flag || lhs != currentIdlePointGridPosition;
			}
			SetTarget(TargetIndex.A, new TargetObject(idlePointForAnimal.Position));
			return true;
		}
	}
}
