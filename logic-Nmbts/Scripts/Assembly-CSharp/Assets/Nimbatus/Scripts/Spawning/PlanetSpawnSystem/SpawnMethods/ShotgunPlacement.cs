using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class ShotgunPlacement : SpawnMethod
	{
		[MinMaxSlider(0f, 10f, false)]
		public Vector2Int MetersAboveSurface;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			List<Vector3> list = new List<Vector3>();
			for (float num = 0f; num < 45f; num += 5f)
			{
				for (int i = 0; i < 100; i += 10)
				{
					Vector2 position = GetPosition(sector, region, num, i);
					NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(position);
					if (data.HasValue && data.Value.Volume < 0.5f)
					{
						list.Add(position);
					}
				}
			}
			list.Shuffle(RandomGenerator);
			int num2 = RandomGenerator.Next(MetersAboveSurface.x, MetersAboveSurface.y);
			foreach (Vector3 item in list)
			{
				Vector2 startPosition = new Vector2(item.x, item.y);
				int num3 = RandomGenerator.Next(0, 360);
				Vector3 pos;
				Vector3 n;
				if (TransformHelper.GetSurfacePosition(startPosition, num3, out pos, out n))
				{
					Vector3 vector = pos + n * num2;
					InteractiveWorldObject interactiveWorldObject = InstantiateSpawnObject(objectToSpawn, vector, SpawnTransformHelper.NormalToRotation(n));
					if (interactiveWorldObject != null)
					{
						return interactiveWorldObject;
					}
				}
			}
			return null;
		}
	}
}
