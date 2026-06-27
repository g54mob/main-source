using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Elements
{
	public sealed class GUI_ElementsShopElementPool : ConcreteGameObjectPool
	{
		public GUI_ElementsShopElementPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
