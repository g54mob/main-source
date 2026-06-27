using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public sealed class SmallUnlicensedDevicePackagePool : ConcreteGameObjectPool
	{
		public SmallUnlicensedDevicePackagePool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
