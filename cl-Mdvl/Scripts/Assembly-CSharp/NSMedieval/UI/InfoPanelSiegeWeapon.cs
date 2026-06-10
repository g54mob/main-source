using System.Collections.Generic;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelSiegeWeapon : SelectionExtraView
	{
		public List<SiegeWeaponComponentInstance> SiegeWeaponComponentInstances { get; }

		public InfoPanelSiegeWeapon(SiegeWeaponComponentInstance siegeWeaponComponentInstance)
		{
			SiegeWeaponComponentInstances = new List<SiegeWeaponComponentInstance> { siegeWeaponComponentInstance };
		}

		public InfoPanelSiegeWeapon(List<SiegeWeaponComponentInstance> siegeWeaponComponentInstances)
		{
			SiegeWeaponComponentInstances = siegeWeaponComponentInstances;
		}
	}
}
