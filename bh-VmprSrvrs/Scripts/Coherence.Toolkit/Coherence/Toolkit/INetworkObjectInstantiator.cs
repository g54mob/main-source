namespace Coherence.Toolkit
{
	public interface INetworkObjectInstantiator
	{
		void OnUniqueObjectReplaced(ICoherenceSync instance);

		ICoherenceSync Instantiate(SpawnInfo spawnInfo);

		void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader);

		void Destroy(ICoherenceSync obj);

		void OnApplicationQuit();
	}
}
