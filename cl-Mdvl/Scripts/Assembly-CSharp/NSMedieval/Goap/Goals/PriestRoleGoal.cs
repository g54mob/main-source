using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class PriestRoleGoal : RoleGoal
	{
		public PriestRoleGoal(Agent selfAgent)
			: base("PriestRoleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			base.AllowedRoleId = "priest";
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return PriestIdleAction();
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.TriggerAnimation("PriestWalk", ActionAnimationMode.Interrupt);
			goapAction.OnComplete = delegate(ActionCompletionStatus state)
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				EquipProp(equipped: false);
				if (state == ActionCompletionStatus.Success)
				{
					base.HumanoidInstance.LookAt(base.HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.RoleInstance.GetDefaultLookAtPosition());
				}
			};
			return goapAction;
		}

		private GoapAction PriestIdleAction()
		{
			GoapAction goapAction = new GoapAction("PriestIdleAction");
			ActionEndingConditions.CompleteAfterTimeExpires(time: Random.value * 20f + 5f, action: goapAction.TriggerAnimation("PriestIdle", ActionAnimationMode.Interrupt)).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "PriestIdle", value: false);
				EquipProp(equipped: false);
			};
			return goapAction;
		}

		protected override void OnPropEquipCall(WorkerBodyPreview workerBodyPreview, bool equipped)
		{
			base.OnPropEquipCall(workerBodyPreview, equipped);
			workerBodyPreview.SetPriestPropsEnabled(equipped);
		}
	}
}
