using Restory.ObjectPools;
using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Competitions
{
	public sealed class CompetitionElementPositionObjectsPool : ConcreteGameObjectPool
	{
		public CompetitionElementPositionObjectsPool(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver, GameObject prefab)
			: base(diContainer, applicationQuitStartObserver, prefab)
		{
		}
	}
}
