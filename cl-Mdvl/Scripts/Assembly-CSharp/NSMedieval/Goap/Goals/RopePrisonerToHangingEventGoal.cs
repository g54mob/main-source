using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.State;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RopePrisonerToHangingEventGoal : EventBaseGoal
	{
		private PrisonerBehaviour prisonerToEscort;

		private GameObject ropeEffect;

		private new HumanoidInstance HumanoidInstance => base.AgentOwner as HumanoidInstance;

		public RopePrisonerToHangingEventGoal(Agent selfAgent)
			: base("RopePrisonerToHangingEventGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<HumanoidInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindTargets));
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (ropeEffect != null)
			{
				Object.Destroy(ropeEffect);
				ropeEffect = null;
			}
			base.EndGoalWith(condition);
			prisonerToEscort?.Humanoid?.RopeTo(null);
			HumanoidView agentView = HumanoidInstance.GetAgentView<HumanoidView>();
			if (agentView != null)
			{
				agentView.IsRunningDisabledGoap = false;
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToCreatureTarget(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(base.EventEnded)
				.FailAtCondition(base.EventFailed)
				.FailAtCondition(() => prisonerToEscort == null || prisonerToEscort.Humanoid.HasDied || prisonerToEscort.Humanoid.HasDisposed);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(66, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopePrisonerToHangingEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("RopePrisonerToHangingEventGoal goToPrisoner completed with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				if (status != ActionCompletionStatus.Success)
				{
					EndGoalWith(GoalCondition.Incompletable);
				}
			};
			yield return goapAction;
			GoapAction goapAction2 = new GoapAction("ForcePrisonerToFollow");
			goapAction2.CompleteMode = ActionCompleteMode.Instant;
			goapAction2.OnInit = delegate
			{
				HumanoidInstance.FaceObject(prisonerToEscort.Humanoid.GetTransform());
				HumanoidInstance.GetAgentView<HumanoidView>().IsRunningDisabledGoap = true;
				MonoSingleton<ReservationManager>.Instance.SetPreferedReservable(prisonerToEscort.Humanoid, HumanoidInstance);
				MonoSingleton<ReservationManager>.Instance.TryToExclusiveReservation(HumanoidInstance, prisonerToEscort.Humanoid, 1f);
				prisonerToEscort.Humanoid.RopeTo(HumanoidInstance, matchSpeed: true);
				ropeEffect = CommonGoalMethods.CreateRopeEffect(HumanoidInstance, prisonerToEscort.Humanoid);
				prisonerToEscort.GoapAgent.Abort();
				prisonerToEscort.GoapAgent.ForceNextGoal("RopedFollowGoal");
			};
			goapAction2.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(18, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopePrisonerToHangingEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(status);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(prisonerToEscort.Humanoid.GetFullName());
					messageBuilder.AppendLiteral(" is now roped to ");
					messageBuilder.AppendFormatted(((HumanoidInstance)base.AgentOwner).GetFullName());
				}
				Log.Debug(messageBuilder);
			};
			yield return goapAction2;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
			GoapAction goapAction3 = GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailAtCondition(base.EventEnded).FailAtCondition(base.EventFailed)
				.WithMovementSpeedMultiplier(0.4f)
				.FailAtCondition(() => prisonerToEscort == null || prisonerToEscort.Humanoid.HasDied || prisonerToEscort.Humanoid.HasDisposed);
			goapAction3.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopePrisonerToHangingEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("RopePrisonerToHangingEventGoal goToGallows completed with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				HumanoidInstance.FaceObject(GetEventInstance().GetFurnitureCenterPosition().ToVector3World());
			};
			yield return goapAction3;
			GoapAction goapAction4 = new GoapAction("Release prisoner");
			goapAction4.CompleteMode = ActionCompleteMode.Instant;
			goapAction4.OnInit = delegate
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(22, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopePrisonerToHangingEventGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(prisonerToEscort.Humanoid.GetFullName());
					messageBuilder.AppendLiteral(" is now released from ");
					messageBuilder.AppendFormatted(((HumanoidInstance)base.AgentOwner).GetFullName());
				}
				Log.Debug(messageBuilder);
				CheckIn();
				prisonerToEscort.Humanoid.RopeTo(null);
				prisonerToEscort.GoapAgent.Abort();
				prisonerToEscort.GoapAgent.ForceNextGoal("GallowsExecutionGoal");
			};
			yield return goapAction4;
			yield return GeneralActions.Wait(3f).TriggerAnimation("Roping", ActionAnimationMode.Ignore);
			yield return HangingAction();
		}

		private GoapAction HangingAction()
		{
			GoapAction action = new GoapAction("HangingAction");
			action.CompleteAtCondition(base.EventEnded).FailAtCondition(base.EventFailed);
			action.OnInit = delegate
			{
				AnimationTrigger = "RitualStanding";
				action.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt, GetTarget(TargetIndex.B).IsInitialized);
			};
			action.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
				if (base.AgentOwner.GetGoapAgent() is WorkerGoapAgent workerGoapAgent)
				{
					workerGoapAgent.LeavePlayerTriggeredEvent();
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			return action;
		}

		protected override bool FindTargets()
		{
			if (!(GetEventInstance() is HangingEventInstance hangingEventInstance))
			{
				return false;
			}
			if (!FindPrisoner(hangingEventInstance))
			{
				return false;
			}
			SetTarget(TargetIndex.B, new TargetObject(hangingEventInstance.ReservedPositions[1]));
			return true;
		}

		protected override PlayerTriggeredEventInstance GetEventInstance()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is HangingEventInstance result))
			{
				return null;
			}
			return result;
		}

		private bool FindPrisoner(HangingEventInstance hangingEventInstance)
		{
			HumanoidInstance firstAttendeeOfType = hangingEventInstance.GetFirstAttendeeOfType<HumanoidInstance>(EventAttendeeType.PrisonerParticipant);
			if (firstAttendeeOfType == null)
			{
				return false;
			}
			QueueTarget(TargetIndex.A, new TargetObject(firstAttendeeOfType, firstAttendeeOfType.GetGridPosition()));
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			prisonerToEscort = GetTarget(TargetIndex.A).GetObjectAs<HumanoidInstance>().PrisonerBehaviour;
			return prisonerToEscort != null;
		}

		public override bool CanStart(bool isForced = false)
		{
			return GetEventInstance()?.HasAttendeeOfType<HumanoidInstance>(EventAttendeeType.PrisonerParticipant) ?? false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is CreatureBase;
		}
	}
}
