using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.Shops.Competitions
{
	public sealed class CompetitionDeviceProcurementItemsUiPool : ConcreteGameObjectPool
	{
		public CompetitionDeviceProcurementItemsUiPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
