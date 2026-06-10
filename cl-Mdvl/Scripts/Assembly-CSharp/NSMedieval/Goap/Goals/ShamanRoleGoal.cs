using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ShamanRoleGoal : RoleGoal
	{
		public ShamanRoleGoal(Agent selfAgent)
			: base("ShamanRoleGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			base.AllowedRoleId = "shaman";
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GotoAction();
			yield return ShamanIdleAction();
		}

		private GoapAction GotoAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).WithMovementSpeedMultiplier(0.4f).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.TriggerAnimation("ShamanWalk", ActionAnimationMode.Interrupt);
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

		private GoapAction ShamanIdleAction()
		{
			GoapAction goapAction = new GoapAction("ShamanIdleAction");
			ActionEndingConditions.CompleteAfterTimeExpires(time: Random.value * 20f + 5f, action: goapAction.TriggerAnimation("ShamanIdle", ActionAnimationMode.Interrupt)).FailAtCondition(base.RoleNotAssigned);
			goapAction.OnInit = delegate
			{
				EquipProp(equipped: true);
			};
			goapAction.OnComplete = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				EquipProp(equipped: false);
			};
			return goapAction;
		}

		protected override void OnPropEquipCall(WorkerBodyPreview workerBodyPreview, bool equipped)
		{
			base.OnPropEquipCall(workerBodyPreview, equipped);
			workerBodyPreview.SetDrumsEnabled(equipped);
		}
	}
}
