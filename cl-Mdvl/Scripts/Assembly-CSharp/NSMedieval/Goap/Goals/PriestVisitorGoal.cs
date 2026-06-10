using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class PriestVisitorGoal : RoleVisitorGoal
	{
		public PriestVisitorGoal(Agent selfAgent)
			: base("PriestVisitorGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return IdleAction();
		}

		protected override Room GetRoom()
		{
			Room closestReachableRoom = NSMedieval.RoomDetection.RoomDetection.GetClosestReachableRoom(NpcInstance, "advanced_chapel_christian");
			if (closestReachableRoom == null)
			{
				return NpcInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetRoleRoom();
			}
			return closestReachableRoom;
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(WalkSpeed).FailAtCondition(base.FailWhenUnderWater);
			goapAction.TriggerAnimation("PriestWalk", ActionAnimationMode.Interrupt);
			goapAction.OnInit = delegate
			{
				Log.Info("PriestVisitorGoal GotoAction OnInit", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\PriestVisitorGoal.cs");
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus state)
			{
				if (state != ActionCompletionStatus.Success)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\PriestVisitorGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(GetType().Name);
						messageBuilder.AppendLiteral(" GotoAction failed with state: ");
						messageBuilder.AppendFormatted(state);
					}
					Log.Info(messageBuilder);
				}
				else
				{
					Transform defaultLookAtPosition = base.RoleInstance.GetDefaultLookAtPosition();
					if ((object)defaultLookAtPosition != null)
					{
						NpcInstance.FaceObject(defaultLookAtPosition.position);
					}
					MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				}
			};
			return goapAction;
		}

		private GoapAction IdleAction()
		{
			GoapAction goapAction = new GoapAction("PriestIdleAction");
			ActionEndingConditions.CompleteAfterTimeExpires(time: Random.value * 20f + 5f, action: goapAction.TriggerAnimation("PriestIdle", ActionAnimationMode.Interrupt));
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			};
			return goapAction;
		}

		public override void Start()
		{
			base.Start();
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "RoleActive", value: true);
			EquipProp(equipped: true);
		}

		private void EquipProp(bool equipped)
		{
			if (MonoSingleton<NPCManager>.Instance.GetView(NpcInstance).BodyPreview is NPCBodyPreview nPCBodyPreview)
			{
				nPCBodyPreview.SetPriestPropsEnabled(equipped);
			}
		}
	}
}
