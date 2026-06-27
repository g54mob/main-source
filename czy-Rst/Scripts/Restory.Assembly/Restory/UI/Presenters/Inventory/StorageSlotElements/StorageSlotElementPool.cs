using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory.StorageSlotElements
{
	public sealed class StorageSlotElementPool : ConcreteGameObjectPool
	{
		public StorageSlotElementPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
