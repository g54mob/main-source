using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class CenterPlacement : SpawnMethod
	{
		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			return InstantiateSpawnObject(objectToSpawn, GetCenterPosition(sector, region), Quaternion.identity);
		}
	}
}
