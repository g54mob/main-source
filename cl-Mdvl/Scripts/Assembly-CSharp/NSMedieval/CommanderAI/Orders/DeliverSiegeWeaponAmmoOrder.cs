using NSMedieval.BuildingComponents;
using NSMedieval.State;

namespace NSMedieval.CommanderAI.Orders
{
	public class DeliverSiegeWeaponAmmoOrder : OrderBase
	{
		public readonly SiegeWeaponComponentInstance SiegeWeaponComponentInstance;

		public readonly ResourcePileInstance AmmoPileInstance;

		public DeliverSiegeWeaponAmmoOrder(SiegeWeaponComponentInstance siegeWeaponComponentInstance, ResourcePileInstance ammoPileInstance)
		{
			SiegeWeaponComponentInstance = siegeWeaponComponentInstance;
			AmmoPileInstance = ammoPileInstance;
		}

		public override string ToString()
		{
			return string.Format("{0} siegeWeapon: {1}, ammo: {2}", "DeliverSiegeWeaponAmmoOrder", SiegeWeaponComponentInstance, AmmoPileInstance);
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is DeliverSiegeWeaponAmmoOrder deliverSiegeWeaponAmmoOrder))
			{
				return false;
			}
			if (SiegeWeaponComponentInstance == deliverSiegeWeaponAmmoOrder.SiegeWeaponComponentInstance)
			{
				return AmmoPileInstance == deliverSiegeWeaponAmmoOrder.AmmoPileInstance;
			}
			return false;
		}
	}
}
