using System;
using System.Collections.Generic;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class AnimalRaidIdleGoal : Goal
	{
		private const float WalkRadius = 12f;

		private readonly System.Random random;

		public AnimalRaidIdleGoal(Agent selfAgent)
			: base("AnimalRaidIdleGoal", selfAgent)
		{
			random = new System.Random();
			AddInitStep(new ThreadSequenceStep(PrePrepareData, PrepareData));
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			float speedMultiplier = 0.4f + 0.5f * (float)random.NextDouble();
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(speedMultiplier);
			yield return GeneralActions.Instant().TriggerAnimation("Bored", ActionAnimationMode.WaitForCompletion);
			yield return GeneralActions.Wait(UnityEngine.Random.value);
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		private bool PrePrepareData()
		{
			return true;
		}

		private bool PrepareData()
		{
			if (!(base.AgentOwner is AnimalInstance animal))
			{
				return false;
			}
			Vec3Int randomPointForAnimalRaid = IdlePointManager.GetRandomPointForAnimalRaid(animal, 12f);
			SetTarget(TargetIndex.A, new TargetObject(randomPointForAnimalRaid));
			return true;
		}
	}
}
