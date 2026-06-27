using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Devices
{
	public sealed class BigCompetitionDevicePackPool : ConcreteGameObjectPool
	{
		public BigCompetitionDevicePackPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
