using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Decors
{
	public sealed class GUI_HomeDepotShopCartPanelToolMultipleUnitItemPool : ConcreteGameObjectPool
	{
		public GUI_HomeDepotShopCartPanelToolMultipleUnitItemPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
