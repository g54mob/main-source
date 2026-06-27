using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tooltips
{
	public sealed class AnotherDeviceFromSameOrderInShipmentTooltipViewPool : ConcreteGameObjectPool
	{
		public AnotherDeviceFromSameOrderInShipmentTooltipViewPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
