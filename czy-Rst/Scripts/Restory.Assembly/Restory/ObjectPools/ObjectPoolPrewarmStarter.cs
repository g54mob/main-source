using System.Collections;
using Restory.Data.ObjectPool;
using Restory.Wrappers.Zenject;
using UnityEngine;
using Zenject;

namespace Restory.ObjectPools
{
	[InitializationExecutionOrder(Priority = -100)]
	public class ObjectPoolPrewarmStarter : IInitializableCoroutine
	{
		private ObjectPoolSettings objectPoolSettings;

		private GlobalObjectPool objectPool;

		[Inject]
		private void Construct(GlobalObjectPool objectPool, ObjectPoolSettings objectPoolSettings)
		{
			this.objectPool = objectPool;
			this.objectPoolSettings = objectPoolSettings;
		}

		public IEnumerator Initialize()
		{
			WaitForEndOfFrame delay = new WaitForEndOfFrame();
			int maxInstantiateCountPerFrame = objectPoolSettings.MaxInstantiateCountPerFrame;
			float totalInstantiated = 0f;
			if (!objectPoolSettings)
			{
				yield break;
			}
			foreach (ObjectPoolItem objectPoolItem in objectPoolSettings.PrewarmItems)
			{
				for (int i = 0; i < objectPoolItem.Size.Min; i++)
				{
					objectPool.Prewarm(objectPoolItem.Prefab, 1);
					totalInstantiated += 1f;
					if (totalInstantiated % (float)maxInstantiateCountPerFrame == 0f)
					{
						yield return delay;
					}
				}
			}
		}
	}
}
