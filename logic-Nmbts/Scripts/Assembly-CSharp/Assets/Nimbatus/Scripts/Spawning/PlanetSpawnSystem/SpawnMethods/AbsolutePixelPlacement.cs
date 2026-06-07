using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class AbsolutePixelPlacement : SpawnMethod
	{
		public float PositionX;

		public float PositionY;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			return InstantiateSpawnObject(objectToSpawn, new Vector2(PositionX, PositionY), Quaternion.identity);
		}
	}
}
