using System;
using Coherence.Toolkit;
using VampireSurvivors.Objects;

namespace VampireSurvivors
{
	public class DestructibleInstantiator : INetworkObjectInstantiator
	{
		public static Action<Destructible> OnRemoteDestructibleSpawned;

		public ICoherenceSync Instantiate(SpawnInfo spawnInfo)
		{
			return null;
		}

		public void Destroy(ICoherenceSync obj)
		{
		}

		public void OnApplicationQuit()
		{
		}

		public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
		{
		}

		public void OnUniqueObjectReplaced(ICoherenceSync instance)
		{
		}
	}
}
