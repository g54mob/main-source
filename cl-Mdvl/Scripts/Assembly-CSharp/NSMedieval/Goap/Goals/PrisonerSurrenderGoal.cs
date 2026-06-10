using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Goap.Goals
{
	public class PrisonerSurrenderGoal : Goal
	{
		private PrisonerBehaviour prisoner;

		private PrisonerBehaviour Prisoner => prisoner ?? (prisoner = (base.AgentOwner as HumanoidInstance)?.PrisonerBehaviour);

		private HumanoidInstance HumanoidOwner => Prisoner?.Humanoid;

		public PrisonerSurrenderGoal(Agent selfAgent)
			: base("PrisonerSurrenderGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
		}

		public override bool CanStart(bool isForced = false)
		{
			if (HumanoidOwner.HasFainted)
			{
				return false;
			}
			if (!HumanoidOwner.IsCaptive())
			{
				return false;
			}
			if (!Prisoner.HasSurrendered && !Prisoner.IsInPrisonCell && !Prisoner.Shackled)
			{
				return !Prisoner.IsEscaping;
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool ShouldBeAdded()
		{
			PrisonerBehaviour prisonerBehaviour = Prisoner;
			if (prisonerBehaviour != null)
			{
				return !prisonerBehaviour.HasSurrendered;
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "Surrender", value: false);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = new GoapAction("DropEquipmentAction");
			goapAction.OnInit = delegate
			{
				HumanoidOwner.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.LeftHand, forbidDroppedItem: true);
				HumanoidOwner.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.RightHand, forbidDroppedItem: true);
				HumanoidOwner.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.Head, forbidDroppedItem: true);
				HumanoidOwner.Inventory.DropItemFromEquipmentSlot(EquipmentSlotType.BodyArmor, forbidDroppedItem: true);
			};
			yield return goapAction;
			yield return GeneralActions.Wait(1f);
			if (Prisoner.SurrenderWaitExpireTimeMinutes == -1)
			{
				Prisoner.SetSurrenderExpireTime();
			}
			GoapAction goapAction2 = GeneralActions.WaitForever("WaitToBeRopedAction");
			goapAction2.SetAnimationParameter("Surrender", parameterValue: true).CompleteAtCondition(() => HumanoidOwner.RopedTo() != null).FailAfterTimeMinutesTotal(Prisoner.SurrenderWaitExpireTimeMinutes);
			goapAction2.OnComplete = delegate(ActionCompletionStatus status)
			{
				base.Agent.GoalScheduler.DisableGoal("PrisonerSurrenderGoal");
				Prisoner.MarkAsSurrendered();
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "Surrender", value: false);
				if (status == ActionCompletionStatus.Fail)
				{
					base.Agent.ForceNextGoal("PrisonerEscapeGoal");
				}
			};
			yield return goapAction2;
		}
	}
}
