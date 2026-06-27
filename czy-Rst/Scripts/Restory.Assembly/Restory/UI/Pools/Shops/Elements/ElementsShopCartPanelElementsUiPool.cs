using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Elements
{
	public sealed class ElementsShopCartPanelElementsUiPool : ConcreteGameObjectPool
	{
		public ElementsShopCartPanelElementsUiPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
