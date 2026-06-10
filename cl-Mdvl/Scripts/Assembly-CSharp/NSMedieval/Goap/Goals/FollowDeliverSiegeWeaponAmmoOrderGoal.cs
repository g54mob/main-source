using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CommanderAI.Orders;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;

namespace NSMedieval.Goap.Goals
{
	public class FollowDeliverSiegeWeaponAmmoOrderGoal : FollowOrderBaseGoal<DeliverSiegeWeaponAmmoOrder>
	{
		public FollowDeliverSiegeWeaponAmmoOrderGoal(Agent selfAgent)
			: base(selfAgent, "FollowDeliverSiegeWeaponAmmoOrderGoal")
		{
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		protected override bool CanStartFollowingOrder()
		{
			SiegeWeaponComponentInstance siegeWeaponComponentInstance = base.CurrentOrder.SiegeWeaponComponentInstance;
			bool num = siegeWeaponComponentInstance != null && !siegeWeaponComponentInstance.HasDisposed && siegeWeaponComponentInstance.OwnerBuilding != null && !siegeWeaponComponentInstance.OwnerBuilding.HasDisposed && siegeWeaponComponentInstance.Storage.IsEmpty();
			ResourcePileInstance ammoPileInstance = base.CurrentOrder.AmmoPileInstance;
			bool flag = ammoPileInstance != null && !ammoPileInstance.HasDisposed;
			return num && flag;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			MonoSingleton<ReservationManager>.Instance.ReleaseObject(base.CurrentOrder.SiegeWeaponComponentInstance, base.AgentOwner);
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.PickupResourceFromPile(TargetIndex.A, 1);
			yield return GoToActions.GoToTargetNoRotation(TargetIndex.B, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.B);
			yield return ResourceActions.DeliverToSiegeWeapon(TargetIndex.B).FailIfTargetDisposedForbidenOrNull(TargetIndex.B).TriggerAnimation("DropPile", ActionAnimationMode.WaitForCompletion);
		}

		private bool PrepareData()
		{
			QueueTarget(TargetIndex.A, new TargetObject(base.CurrentOrder.AmmoPileInstance));
			return true;
		}

		private bool ReserveTargets()
		{
			if (!MonoSingleton<ReservationManager>.Instance.TryReserveObject(base.CurrentOrder.SiegeWeaponComponentInstance, base.AgentOwner))
			{
				return false;
			}
			SetTarget(TargetIndex.B, new TargetObject(base.CurrentOrder.SiegeWeaponComponentInstance));
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}
	}
}
