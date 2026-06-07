using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnMethods
{
	public class InsideCircle : SpaceSpawnMethod
	{
		public float Radius;

		public bool HasExclusionRadius;

		[ShowIf("HasExclusionRadius", true)]
		public float ExclusionRadius;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn)
		{
			Vector2 spawnOrigin = GetSpawnOrigin();
			Vector2 vector = spawnOrigin + Random.insideUnitCircle * Radius;
			if (HasExclusionRadius && Vector2.Distance(spawnOrigin, vector) < ExclusionRadius)
			{
				return null;
			}
			return InstantiateSpawnObject(objectToSpawn, vector, Quaternion.identity);
		}
	}
}
