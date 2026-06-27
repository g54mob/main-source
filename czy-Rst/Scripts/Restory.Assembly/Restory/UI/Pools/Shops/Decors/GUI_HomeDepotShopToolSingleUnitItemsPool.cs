using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Decors
{
	public sealed class GUI_HomeDepotShopToolSingleUnitItemsPool : ConcreteGameObjectPool
	{
		public GUI_HomeDepotShopToolSingleUnitItemsPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
