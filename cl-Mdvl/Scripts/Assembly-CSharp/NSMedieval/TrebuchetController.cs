using System;
using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval
{
	public class TrebuchetController : MonoSingleton<TrebuchetController>
	{
		public event Action<SiegeWeaponComponentInstance> SiegeWeaponAttackReadyEvent;

		public event Action<SiegeWeaponComponentInstance> SiegeWeaponAmmunitionDepletedEvent;

		public void OnTrebuchetAttackReady(SiegeWeaponComponentInstance instance)
		{
			this.SiegeWeaponAttackReadyEvent?.Invoke(instance);
		}

		public void OnTrebuchetAmmunitionDepleted(SiegeWeaponComponentInstance instance)
		{
			this.SiegeWeaponAmmunitionDepletedEvent?.Invoke(instance);
		}
	}
}
