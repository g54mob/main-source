using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class EquipGoal : Goal
	{
		public EquipGoal(Agent selfAgent)
			: base("EquipGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IEquipableAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			InventoryInstance inventory = ((IEquipableAgent)base.AgentOwner).Inventory;
			if (inventory == null)
			{
				return false;
			}
			return inventory.EquipOrders?.Count > 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition != GoalCondition.Succeeded)
			{
				(base.AgentOwner as IEquipableAgent)?.Inventory?.ClearEquipOrders();
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfResourcePileHasNoResources(TargetIndex.A);
			yield return GeneralActions.WaitForever().TriggerAnimation("PickUpPile", ActionAnimationMode.Interrupt).CompleteActionOnAnimationGoapEvent("ItemPickup", ActionCompletionStatus.Success)
				.FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return ResourceActions.EquipItem(TargetIndex.A, (IEquipableAgent)base.AgentOwner, isManuallyEquipped: true).FailIfTargetDisposedForbidenOrNull(TargetIndex.A);
			yield return GeneralActions.Wait(0.5f);
		}

		private bool PrepareData()
		{
			ResourcePileInstance resourcePileInstance = ((IEquipableAgent)base.AgentOwner).Inventory?.EquipOrders[0];
			if (resourcePileInstance == null || resourcePileInstance.ReachablePositions == null || resourcePileInstance.ReachablePositions.Count <= 0)
			{
				return false;
			}
			if (resourcePileInstance.ReachablePositions == null || resourcePileInstance.ReachablePositions.Count == 0)
			{
				return false;
			}
			SetTarget(TargetIndex.A, new TargetObject(resourcePileInstance, resourcePileInstance.ReachablePositions.First()));
			return true;
		}

		private bool ReserveTargets()
		{
			return MonoSingleton<ReservationManager>.Instance.TryReserveObject(GetTarget(TargetIndex.A).GetAsReservable(), base.AgentOwner);
		}
	}
}
