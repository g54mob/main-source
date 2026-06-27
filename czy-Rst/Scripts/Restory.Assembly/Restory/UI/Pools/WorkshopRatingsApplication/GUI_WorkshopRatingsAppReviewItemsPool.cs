using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UI.Pools.WorkshopRatingsApplication
{
	public sealed class GUI_WorkshopRatingsAppReviewItemsPool : ConcreteGameObjectPool
	{
		public GUI_WorkshopRatingsAppReviewItemsPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
