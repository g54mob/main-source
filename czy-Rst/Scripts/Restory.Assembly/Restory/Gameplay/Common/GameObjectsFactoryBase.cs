using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Common
{
	public abstract class GameObjectsFactoryBase
	{
		private readonly DiContainer diContainer;

		protected GameObjectsFactoryBase(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public GameObject CreateInstanceFromPrefab(GameObject prefab)
		{
			return diContainer.InstantiatePrefab(prefab);
		}

		public void DisposeInstance(GameObject instance)
		{
			Object.Destroy(instance);
		}
	}
}
