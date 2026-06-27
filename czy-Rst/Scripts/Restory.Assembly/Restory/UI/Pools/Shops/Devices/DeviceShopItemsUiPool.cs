using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Devices
{
	public sealed class DeviceShopItemsUiPool : ConcreteGameObjectPool
	{
		public DeviceShopItemsUiPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
