using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("Pool", "Instances of this prefab will be pooled.")]
	public class NetworkPool : INetworkObjectInstantiator, IDisposable
	{
		[SerializeField]
		[Tooltip("Maximum number of objects held by this pool.")]
		private int maxSize;

		[SerializeField]
		[Tooltip("Initial number of objects that will be instantiated in the Start method of CoherenceBridge.")]
		private int initialSize;

		private CoherenceObjectPool<ICoherenceSync> pool;

		private MonoBehaviour syncPrefab;

		private ICoherenceBridge lastBridge;

		private Vector3 position;

		private Quaternion rotation;

		private GameObject container;

		private bool warmingUp;

		public void OnUniqueObjectReplaced(ICoherenceSync instance)
		{
		}

		public ICoherenceSync Instantiate(SpawnInfo spawnInfo)
		{
			return null;
		}

		public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
		{
		}

		public static string GetContainerName(string assetName)
		{
			return null;
		}

		public void Destroy(ICoherenceSync obj)
		{
		}

		public void OnApplicationQuit()
		{
		}

		private CoherenceSync CreatePooledItem()
		{
			return null;
		}

		private void OnReturnedToPool(ICoherenceSync sync)
		{
		}

		private bool OnTakeFromPool(ICoherenceSync sync)
		{
			return false;
		}

		private void OnDestroyPoolObject(ICoherenceSync sync)
		{
		}

		private void OnPrefabLoaded(CoherenceBridge bridge, ICoherenceSync prefab)
		{
		}

		private void InstantiateContainer(string assetName)
		{
		}

		private void InstantiatePool()
		{
		}

		public void Dispose()
		{
		}
	}
}
