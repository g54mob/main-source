using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Decors
{
	public sealed class GUI_HomeDepotShopCartPanelPcAppItemsPool : ConcreteGameObjectPool
	{
		public GUI_HomeDepotShopCartPanelPcAppItemsPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
