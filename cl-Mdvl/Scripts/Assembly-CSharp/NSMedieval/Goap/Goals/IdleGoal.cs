using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class IdleGoal : Goal
	{
		public IdleGoal(Agent selfAgent)
			: base("IdleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IPathfindingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			Log.Trace("IdleGoal: GetNextAction", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\IdleGoal.cs");
			bool flag = true;
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			CaptiveNpcBehaviour captiveNpcBehaviour = humanoidInstance?.CaptiveNpcBehaviour;
			if (captiveNpcBehaviour != null && !CombatUtils.IsNullOrDisposed(humanoidInstance))
			{
				if (captiveNpcBehaviour.IsPlayerVillagePrisoner && captiveNpcBehaviour.IsInPrisonCell)
				{
					flag = Random.value < 0.9f;
				}
				if (captiveNpcBehaviour.Owner != null && captiveNpcBehaviour.Owner.ActiveBehaviour is TraderBehaviour traderBehaviour && traderBehaviour.TraderType.IdleDoNotWalk && captiveNpcBehaviour.Humanoid.GetNode().CreaturesCount <= 1)
				{
					flag = Random.value < 0.05f;
				}
			}
			if (flag)
			{
				yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f);
				MonoSingleton<AnimationController>.Instance.GenerateNewAnimationRnd(base.AgentOwner);
				yield return GeneralActions.Instant().TriggerAnimation("Bored", ActionAnimationMode.WaitForCompletion);
				yield return GeneralActions.Wait(Random.value);
				yield break;
			}
			if (captiveNpcBehaviour.Owner != null)
			{
				float time = Random.value * 20f + 5f;
				yield return GeneralActions.Instant().TriggerAnimation("DepressedSit", ActionAnimationMode.Interrupt, isSequenced: true).CompleteAfterTimeExpires(time);
			}
			else if (captiveNpcBehaviour.IsPlayerVillagePrisoner && !captiveNpcBehaviour.IsCaptiveLabourer && captiveNpcBehaviour.IsInPrisonCell)
			{
				float time = Random.Range(15f, 30f);
				yield return GeneralActions.Instant().TriggerAnimation("DepressedSit", ActionAnimationMode.Interrupt, isSequenced: true).CompleteAfterTimeExpires(time);
			}
			else
			{
				float time = 1f + Random.value * 5f;
				yield return GeneralActions.Instant().TriggerAnimation("Laydown", ActionAnimationMode.WaitForCompletion, isSequenced: true).CompleteAfterTimeExpires(time);
			}
			yield return GeneralActions.Instant();
		}

		private bool PrepareData()
		{
			if (LoadingController.IsSceneTransition || !MonoSingleton<World>.IsInstantiated())
			{
				return false;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			IdlePointManager.AnimalIdlePoint idlePoint;
			Vec3Int reachablePosition = ((!(creatureBase is AnimalInstance creature)) ? (creatureBase.Map.IdlePoints.GetIdlePointForWorker(creatureBase)?.Position ?? creatureBase.GetGridPosition()) : (creatureBase.Map.IdlePoints.GetIdlePointForAnimal(creature, out idlePoint)?.Position ?? creatureBase.GetGridPosition()));
			SetTarget(TargetIndex.A, new TargetObject(reachablePosition));
			return true;
		}
	}
}
