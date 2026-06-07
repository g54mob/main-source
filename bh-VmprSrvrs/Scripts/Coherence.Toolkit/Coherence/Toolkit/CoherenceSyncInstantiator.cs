using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	[DisplayName("DestroyCoherenceSync", "Instances of this prefab will be instantiated normally, but only the CoherenceSync component will be destroyed or disabled.Use it when you want to keep the GameObject to be reused or destroyed manually.")]
	public class CoherenceSyncInstantiator : INetworkObjectInstantiator
	{
		[SerializeField]
		[Tooltip("Choose what you want to happen when Destroy is called:\n\nDestroy: CoherenceSync component is destroyed, GameObject remains and can no longer be synced over the network.\n\nDisable: CoherenceSync component is disabled. You can reuse the instance for a different network entity by re-enabling it locally.")]
		private OnDestroyBehaviour onDestroyBehaviour;

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

		public void Destroy(ICoherenceSync obj)
		{
		}

		public void OnApplicationQuit()
		{
		}
	}
}
