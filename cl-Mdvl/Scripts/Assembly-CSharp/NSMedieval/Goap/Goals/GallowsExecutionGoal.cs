using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.PlayerTriggeredEventSystem;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class GallowsExecutionGoal : EventBaseGoal
	{
		private readonly HumanoidInstance humanoidOwner;

		private readonly List<Vector3> animationPositions = new List<Vector3>();

		private WalkableModel savedWalkableModel;

		public GallowsExecutionGoal(Agent selfAgent)
			: base("GallowsExecutionGoal", selfAgent, GoalInterruptMode.Never)
		{
			humanoidOwner = (HumanoidInstance)base.AgentOwner;
		}

		public override bool AgentTypeCheck()
		{
			if (humanoidOwner.IsCaptive())
			{
				return base.AgentTypeCheck();
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, AnimationTrigger, value: false);
			if (humanoidOwner.GoapAgent != null)
			{
				humanoidOwner.GoapAgent.Abort();
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToGallows();
			yield return WaitForExecution();
			yield return GeneralActions.Wait(3f);
			yield return MoveTransformToPosition("GoToStairs", animationPositions[0], 1f, "Hanging");
			yield return MoveTransformToPosition("GoUpstairs", animationPositions[1], 3f);
			yield return MoveTransformToPosition("GoToRope", animationPositions[2], 1.2f);
			yield return WaitForDeath();
		}

		protected GoapAction WaitForExecution()
		{
			return GeneralActions.WaitForever("WaitingForExecution").CompleteAtCondition(GetEventInstance().Started).FailAtCondition(base.EventEnded)
				.FailAtCondition(base.EventFailed);
		}

		private GoapAction GoToGallows()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailAtCondition(base.EventEnded).FailAtCondition(base.EventFailed)
				.WithMovementSpeedMultiplier(0.4f);
			goapAction.OnPreInit = delegate
			{
				savedWalkableModel = humanoidOwner.WalkableModel;
				WalkableModel byID = Repository<WalkableModelRepository, WalkableModel>.Instance.GetByID("worker");
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(humanoidOwner.GetFullName());
					messageBuilder.AppendLiteral(" Setting walkable model to ");
					messageBuilder.AppendFormatted(byID.GetID());
				}
				Log.Trace(messageBuilder);
				humanoidOwner.SetWalkableModel(byID);
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("GallowsExecutionGoal goToGallowsAction completed with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				humanoidOwner.SetWalkableModel(savedWalkableModel);
				FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendFormatted(humanoidOwner.GetFullName());
					messageBuilder2.AppendLiteral(" Returning walkable model to ");
					messageBuilder2.AppendFormatted(savedWalkableModel.GetID());
				}
				Log.Trace(messageBuilder2);
				if (status != ActionCompletionStatus.Success)
				{
					GetEventInstance().RemoveParticipantFromEvent(Participant);
					EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					CheckIn();
					humanoidOwner.FaceObject(GetEventInstance().GetFurnitureCenterPosition().ToVector3World());
				}
			};
			return goapAction;
		}

		private GoapAction MoveTransformToPosition(string actionName, Vector3 targetPosition, float duration, string animationTrigger = null)
		{
			Transform agentTransform = ((CreatureBase)base.AgentOwner).GetAgentView<AnimatedAgentView>().transform;
			Vector3 startPosition = Vector3.zero;
			GoapAction moveTransformToPosition = GeneralActions.WaitForever().FailAtCondition(GetEventInstance().Interrupted).CompleteAtCondition(base.EventEnded);
			moveTransformToPosition.OnInit = delegate
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(actionName);
					messageBuilder.AppendLiteral(" MoveTransformToPosition.OnInit");
				}
				Log.Debug(messageBuilder);
				if (!(base.AgentOwner is CreatureBase))
				{
					moveTransformToPosition.Complete(ActionCompletionStatus.Fail);
				}
				startPosition = agentTransform.position;
				if (!string.IsNullOrEmpty(animationTrigger))
				{
					AnimationTrigger = animationTrigger;
					moveTransformToPosition.TriggerAnimation(AnimationTrigger, ActionAnimationMode.Interrupt);
				}
			};
			float elapsedTime = 0f;
			moveTransformToPosition.OnTick = delegate(float delta)
			{
				float t = Mathf.Clamp01(elapsedTime / duration);
				agentTransform.position = Vector3.Lerp(startPosition, targetPosition, t);
				elapsedTime += delta;
				if (elapsedTime >= duration)
				{
					moveTransformToPosition.Complete(ActionCompletionStatus.Success);
				}
			};
			moveTransformToPosition.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(48, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(actionName);
					messageBuilder.AppendLiteral(" MoveTransformToPosition.OnComplete with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				agentTransform.position = targetPosition;
			};
			return moveTransformToPosition;
		}

		private GoapAction WaitForDeath()
		{
			GoapAction goapAction = GeneralActions.Wait(7f).FailAtCondition(GetEventInstance().Interrupted);
			goapAction.OnInit = delegate
			{
				Log.Debug("GallowsExecutionGoal waitForDeath.OnInit", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("GallowsExecutionGoal waitForDeath.OnComplete with status ");
					messageBuilder.AppendFormatted(status);
				}
				Log.Debug(messageBuilder);
				GetEventInstance()?.ChangeStateEnd();
				humanoidOwner.GetStat(StatType.Health).SetCurrent(0f);
			};
			return goapAction;
		}

		protected override bool FindTargets()
		{
			if (!(MonoSingleton<PlayerTriggeredEventManager>.Instance.CurrentEvent is HangingEventInstance hangingEventInstance))
			{
				return false;
			}
			Vec3Int lhs = hangingEventInstance.ReservedPositions[0];
			bool isEnabled;
			if (lhs == Vec3Int.zero)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" failed to find startPosition");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			Vector3 vector = hangingEventInstance.AnimationPositions[0];
			if (vector == Vector3.zero)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" failed to find stairsPosition");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			Vector3 vector2 = hangingEventInstance.AnimationPositions[1];
			if (vector2 == Vector3.zero)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" failed to find stairsTopPosition");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			Vector3 vector3 = hangingEventInstance.AnimationPositions[2];
			if (vector3 == Vector3.zero)
			{
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\GallowsExecutionGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" failed to find ropePosition");
				}
				Log.Debug(messageBuilder);
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(lhs));
			animationPositions.Clear();
			animationPositions.Add(vector);
			animationPositions.Add(vector2);
			animationPositions.Add(vector3);
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
	}
}
