using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnMethods
{
	public class AbsolutePosition : SpaceSpawnMethod
	{
		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn)
		{
			Vector2 spawnOrigin = GetSpawnOrigin();
			return InstantiateSpawnObject(objectToSpawn, spawnOrigin, Quaternion.identity);
		}
	}
}
