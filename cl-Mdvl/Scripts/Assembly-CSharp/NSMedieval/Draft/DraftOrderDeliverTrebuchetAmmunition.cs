using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Goals;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Draft
{
	public class DraftOrderDeliverTrebuchetAmmunition : DraftOrder
	{
		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		public DraftOrderDeliverTrebuchetAmmunition(SiegeWeaponComponentInstance siegeWeaponComponentInstance)
			: base(DraftOrderType.ForceAttackTarget)
		{
			this.siegeWeaponComponentInstance = siegeWeaponComponentInstance;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			return true;
		}

		public override void Execute(HumanoidInstance instance)
		{
			if (siegeWeaponComponentInstance == null || siegeWeaponComponentInstance.HasDisposed)
			{
				return;
			}
			if (!siegeWeaponComponentInstance.Storage.IsEmpty())
			{
				DamagePopup.Create(siegeWeaponComponentInstance.GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("trebuchet_storage_full"));
			}
			else if (!(instance.GetGoapAgent().GetCurrentGoal() is DeliverAmmunitionToTrebuchetGoal deliverAmmunitionToTrebuchetGoal) || deliverAmmunitionToTrebuchetGoal.SiegeWeaponComponentInstance != siegeWeaponComponentInstance)
			{
				if (instance.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					instance.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
				}
				instance.GetGoapAgent().ForceNextGoal(new DeliverAmmunitionToTrebuchetGoal(instance.GetGoapAgent(), siegeWeaponComponentInstance, forceOperationGoal: false));
			}
		}

		public override void OnNewOrder(HumanoidInstance instance, DraftOrder newOrder)
		{
		}

		public override void OnDraftEnd(HumanoidInstance instance)
		{
		}
	}
}
