using Coherence.Toolkit;

namespace VampireSurvivors
{
	public class CoffinXInstantiator : INetworkObjectInstantiator
	{
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
