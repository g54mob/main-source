using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class BardVisitorGoal : RoleVisitorGoal
	{
		public BardVisitorGoal(Agent selfAgent)
			: base("BardVisitorGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return IdleAction();
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(WalkSpeed).FailAtCondition(base.FailWhenUnderWater);
			goapAction.TriggerAnimation("BardWalk", ActionAnimationMode.Interrupt);
			goapAction.OnInit = delegate
			{
				Log.Info("BardVisitorGoal GotoAction OnInit", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\BardVisitorGoal.cs");
			};
			goapAction.OnComplete = delegate(ActionCompletionStatus state)
			{
				if (state != ActionCompletionStatus.Success)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\BardVisitorGoal.cs");
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
			GoapAction goapAction = new GoapAction("BardIdleAction");
			ActionEndingConditions.CompleteAfterTimeExpires(time: Random.value * 20f + 5f, action: goapAction.TriggerAnimation("BardIdle", ActionAnimationMode.Interrupt));
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
				nPCBodyPreview.SetLuteEnabled(equipped);
			}
		}
	}
}
