using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Views.Tooltips
{
	public sealed class InventoryItemTooltipViewPool : ConcreteGameObjectPool
	{
		public InventoryItemTooltipViewPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
