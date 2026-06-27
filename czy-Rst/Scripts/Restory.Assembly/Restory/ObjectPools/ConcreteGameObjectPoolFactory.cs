using Restory.Utils.Observers;
using UnityEngine;
using Zenject;

namespace Restory.ObjectPools
{
	public sealed class ConcreteGameObjectPoolFactory : IFactory<GameObject, string, ConcreteGameObjectPool>, IFactory
	{
		private readonly DiContainer diContainer;

		private readonly ApplicationQuitStartObserver applicationQuitStartObserver;

		public ConcreteGameObjectPoolFactory(DiContainer diContainer, ApplicationQuitStartObserver applicationQuitStartObserver)
		{
			this.diContainer = diContainer;
			this.applicationQuitStartObserver = applicationQuitStartObserver;
		}

		public ConcreteGameObjectPool Create(GameObject prefab, string name = "ConcreteGameObjectPoolContainer")
		{
			return new ConcreteGameObjectPool(diContainer, applicationQuitStartObserver, prefab, name);
		}
	}
}
