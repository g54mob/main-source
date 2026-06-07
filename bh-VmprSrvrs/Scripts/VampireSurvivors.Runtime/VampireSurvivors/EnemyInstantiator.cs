using System;
using System.Reflection;
using Coherence.Toolkit;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors
{
	public class EnemyInstantiator : INetworkObjectInstantiator
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

		private static object GetFieldValue(object obj, string fieldName)
		{
			return null;
		}

		private static FieldInfo GetFieldInfo(Type type, string fieldName)
		{
			return null;
		}
	}
}
