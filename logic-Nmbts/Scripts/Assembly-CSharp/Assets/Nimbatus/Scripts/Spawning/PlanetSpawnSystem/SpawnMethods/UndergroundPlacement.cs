using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class UndergroundPlacement : SpawnMethod
	{
		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			List<Vector3> list = new List<Vector3>();
			for (float num = 0f; num < 45f; num += 5f)
			{
				for (int i = 0; i < 100; i += 10)
				{
					Vector2 position = GetPosition(sector, region, num, i);
					NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(position);
					if (data.HasValue && data.Value.Volume > 0.5f)
					{
						list.Add(position);
					}
				}
			}
			list.Shuffle(RandomGenerator);
			foreach (Vector3 item in list)
			{
				InteractiveWorldObject interactiveWorldObject = InstantiateSpawnObject(objectToSpawn, item, objectToSpawn.transform.rotation);
				if (interactiveWorldObject != null)
				{
					return interactiveWorldObject;
				}
			}
			return null;
		}
	}
}
