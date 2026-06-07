using System;
using Coherence.Toolkit;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors
{
	public class ItemInstantiator : INetworkObjectInstantiator
	{
		public static Action<Pickup> OnRemoteItemInstantiated;

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
