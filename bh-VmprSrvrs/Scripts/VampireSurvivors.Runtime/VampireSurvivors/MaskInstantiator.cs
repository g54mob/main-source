using System;
using Coherence.Toolkit;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public class MaskInstantiator : INetworkObjectInstantiator
	{
		public static Action<EnemyController> OnRemoteEnemySpawned;

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
