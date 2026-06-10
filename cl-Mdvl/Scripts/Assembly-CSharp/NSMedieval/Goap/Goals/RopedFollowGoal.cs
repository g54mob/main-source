using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RopedFollowGoal : Goal
	{
		private const float DisableTimeWhenFails = 8f;

		private DateTime disabledTime;

		private readonly CreatureBase ropeFollower;

		private CreatureBase ropeOwner;

		private WalkableModel savedWalkableModel;

		public RopedFollowGoal(Agent selfAgent)
			: base("RopedFollowGoal", selfAgent)
		{
			ropeFollower = base.AgentOwner as CreatureBase;
			AddInitStep(new ThreadSequenceStep(StartCheck, ValidatePath));
		}

		public override void Dispose()
		{
			base.Dispose();
			ropeOwner = null;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (ropeFollower != null && savedWalkableModel != null)
			{
				ropeFollower.SetWalkableModel(savedWalkableModel);
			}
			base.EndGoalWith(condition);
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IRopableAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			ropeOwner = ropeFollower?.RopedTo() as CreatureBase;
			if (ropeFollower == null || ropeOwner == null)
			{
				return false;
			}
			if (disabledTime == default(DateTime))
			{
				if (base.AgentOwner is HumanoidInstance { RopedAllowedToIdle: not false })
				{
					return Vector3.Distance(ropeOwner.GetPosition(), ropeFollower.GetPosition()) > ropeFollower.RopedFollowRange;
				}
				return true;
			}
			if ((System.DateTime.Now - disabledTime).TotalSeconds < 8.0)
			{
				return false;
			}
			disabledTime = default(DateTime);
			return true;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction setUpFollowTarget = new GoapAction("SetupFollowTarget");
			setUpFollowTarget.OnInit = delegate
			{
				ropeOwner = ropeFollower.RopedTo() as CreatureBase;
				if (ropeOwner == null)
				{
					setUpFollowTarget.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					SetTarget(TargetIndex.A, new TargetObject(ropeOwner));
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopedFollowGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("RopedFollowGoal: SetTarget to ");
						messageBuilder.AppendFormatted(ropeOwner?.GetFullName());
					}
					Log.Debug(messageBuilder);
					if (ropeFollower is AnimalInstance)
					{
						ropeFollower.CombatAi.SetState(CombatAiState.AnimalRetreatingNoPathToTrader, false);
					}
					savedWalkableModel = ropeFollower.WalkableModel;
					ropeFollower.SetWalkableModel(ropeOwner?.WalkableModel);
					messageBuilder = new FVLogDebugInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopedFollowGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("followCreature.OnInit: Set walkable model to ");
						messageBuilder.AppendFormatted(ropeOwner?.GetFullName());
					}
					Log.Debug(messageBuilder);
				}
			};
			yield return setUpFollowTarget;
			GoapAction goapAction = GoToActions.GoToCreatureTarget(TargetIndex.A, ropeFollower.RopedFollowRange);
			goapAction.FailAtCondition(() => ropeOwner == null);
			if (ropeFollower is HumanoidInstance { RopedShouldAlwaysWalk: not false })
			{
				goapAction.WithMovementSpeedMultiplier(0.4f);
			}
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopedFollowGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("followCreature.OnComplete: ");
					messageBuilder.AppendFormatted(base.AgentOwner);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				if (ropeFollower is AnimalInstance animalInstance)
				{
					bool flag = !HasPathToRopeOwner();
					ropeFollower?.CombatAi?.SetState(CombatAiState.AnimalRetreatingNoPathToTrader, flag);
					if (flag)
					{
						animalInstance.PetOwner?.GetGoapAgent()?.Abort();
					}
				}
			};
			yield return goapAction;
			GoapAction goapAction2 = GeneralActions.Wait(1f);
			if (ropeFollower is HumanoidInstance { RopedShouldAlwaysWalk: not false })
			{
				goapAction2.WithMovementSpeedMultiplier(0.4f);
			}
			yield return goapAction2;
		}

		private bool HasPathToRopeOwner()
		{
			if (CombatUtils.IsNullOrDisposed(ropeFollower))
			{
				return false;
			}
			if (ropeFollower is AnimalInstance animalInstance)
			{
				if (!(animalInstance.PetOwner is HumanoidInstance humanoidInstance) || !humanoidInstance.IsTrader())
				{
					return true;
				}
				if (humanoidInstance.HasDied || humanoidInstance.HasDisposed)
				{
					return true;
				}
				return PathfinderUtil.IsPathPossible(humanoidInstance.WalkableModel, ropeFollower.GetNode(), humanoidInstance.GetNode());
			}
			return PathfinderUtil.IsPathPossible(ropeOwner.WalkableModel, ropeFollower.GetNode(), ropeOwner.GetNode());
		}

		private bool StartCheck()
		{
			if (ropeFollower == null || ropeFollower.HasDisposed || ropeFollower.HasDied)
			{
				return false;
			}
			if (ropeOwner == null || ropeOwner.HasDisposed)
			{
				return false;
			}
			if (!HasPathToRopeOwner())
			{
				return false;
			}
			return true;
		}

		private bool ValidatePath()
		{
			IGoapTargetable goapTargetable = ropeOwner;
			P2PPath p2PPath = P2PPath.Construct(ropeFollower, goapTargetable.GetGridPosition());
			p2PPath.TraversalProvider = ropeOwner.PathTraversalProvider;
			MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2PPath);
			if (p2PPath.State != PathState.Calculated)
			{
				disabledTime = System.DateTime.Now;
				Path.ReleasePath(p2PPath);
				return false;
			}
			Path.ReleasePath(p2PPath);
			return true;
		}
	}
}
