using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class SergeantRoleGoal : RoleGoal
	{
		public SergeantRoleGoal(Agent selfAgent)
			: base("SergeantRoleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			base.AllowedRoleId = "sergeant";
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return RoleIdleAction();
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f).FailAtCondition(base.RoleNotAssigned);
			goapAction.TriggerAnimation("SargeantWalk", ActionAnimationMode.Interrupt);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus state)
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				EquipProp(equipped: false);
				if (state == ActionCompletionStatus.Success)
				{
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SergeantRoleGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Walking complete/ Looking at: ");
						messageBuilder.AppendFormatted(base.HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetDefaultLookAtPosition());
					}
					Log.Debug(messageBuilder);
					base.HumanoidInstance.LookAt(base.HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetDefaultLookAtPosition());
				}
			};
			return goapAction;
		}

		private GoapAction RoleIdleAction()
		{
			GoapAction goapAction = new GoapAction("SergeantIdleAction");
			float num = Random.value * 20f + 5f;
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SergeantRoleGoal.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Playing at position for ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" seconds");
			}
			Log.Debug(messageBuilder);
			goapAction.TriggerAnimation("SargeantIdle", ActionAnimationMode.Interrupt).CompleteAfterTimeExpires(num).FailAtCondition(base.RoleNotAssigned);
			return goapAction;
		}
	}
}
