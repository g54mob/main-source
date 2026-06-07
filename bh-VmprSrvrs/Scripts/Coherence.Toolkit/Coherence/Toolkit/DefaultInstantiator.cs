namespace Coherence.Toolkit
{
	[DisplayName("Default", "Instances of this prefab will be instantiated and destroyed when they are no longer needed.")]
	public class DefaultInstantiator : INetworkObjectInstantiator
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
