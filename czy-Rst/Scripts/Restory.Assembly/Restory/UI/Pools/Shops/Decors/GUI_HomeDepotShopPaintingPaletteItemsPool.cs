using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Decors
{
	public sealed class GUI_HomeDepotShopPaintingPaletteItemsPool : ConcreteGameObjectPool
	{
		public GUI_HomeDepotShopPaintingPaletteItemsPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
