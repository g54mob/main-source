using Coherence.Toolkit;

namespace VampireSurvivors
{
	[DisplayName("HostPlayerOptionsInstantiator", "Instances of this prefab will be instantiated and destroyed when they are no longer needed.")]
	public class HostPlayerOptionsInstantiator : INetworkObjectInstantiator
	{
		public void OnUniqueObjectReplaced(ICoherenceSync instance)
		{
		}

		public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
		{
		}

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
	}
}
