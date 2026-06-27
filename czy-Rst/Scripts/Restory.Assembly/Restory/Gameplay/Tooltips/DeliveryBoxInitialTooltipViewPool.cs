using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public sealed class DeliveryBoxInitialTooltipViewPool : ConcreteGameObjectPool
	{
		public DeliveryBoxInitialTooltipViewPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
