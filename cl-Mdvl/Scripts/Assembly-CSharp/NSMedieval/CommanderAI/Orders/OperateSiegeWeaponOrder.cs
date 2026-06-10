using NSMedieval.BuildingComponents;

namespace NSMedieval.CommanderAI.Orders
{
	public class OperateSiegeWeaponOrder : OrderBase
	{
		public readonly SiegeWeaponComponentInstance SiegeWeaponComponentInstance;

		public OperateSiegeWeaponOrder(SiegeWeaponComponentInstance siegeWeaponComponentInstance)
		{
			SiegeWeaponComponentInstance = siegeWeaponComponentInstance;
		}

		public override string ToString()
		{
			return string.Format("{0} siegeWeapon: {1}", "OperateSiegeWeaponOrder", SiegeWeaponComponentInstance);
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is OperateSiegeWeaponOrder operateSiegeWeaponOrder))
			{
				return false;
			}
			return SiegeWeaponComponentInstance == operateSiegeWeaponOrder.SiegeWeaponComponentInstance;
		}
	}
}
