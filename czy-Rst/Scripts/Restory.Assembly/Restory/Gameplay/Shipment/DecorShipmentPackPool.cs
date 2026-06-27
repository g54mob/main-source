using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shipment
{
	public sealed class DecorShipmentPackPool : ConcreteGameObjectPool
	{
		public DecorShipmentPackPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
