using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem.SpawnMethods
{
	public class OnRadius : SpaceSpawnMethod
	{
		public float Radius;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn)
		{
			Vector2 spawnOrigin = GetSpawnOrigin();
			float num = Random.Range(0f, 360f);
			Vector2 position = spawnOrigin + new Vector2(Mathf.Cos(num * 57.29578f) * Radius, Mathf.Sin(num * 57.29578f) * Radius);
			return InstantiateSpawnObject(objectToSpawn, position, Quaternion.identity);
		}
	}
}
