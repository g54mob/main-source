using Coherence.Toolkit;

namespace VampireSurvivors;

public class EmptyInstantiator : INetworkObjectInstantiator
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
