using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace WorldEnvironment.Structures
{
	public class StructureGenerator
	{
		private struct SurfacePoint
		{
			public Vector3 WorldPos;

			public Vector3 Normal;

			public float Steepness;
		}

		private struct TerrainBounds
		{
			public float MinX;

			public float MaxX;

			public float MinZ;

			public float MaxZ;

			public bool Contains(Vector3 pos)
			{
				if (pos.x >= MinX && pos.x <= MaxX && pos.z >= MinZ)
				{
					return pos.z <= MaxZ;
				}
				return false;
			}
		}

		private readonly StructureSpawnConfig _config;

		private readonly DiContainer _diContainer;

		private readonly List<KeyValuePair<Vector3, float>> _spawnedStructureDatas = new List<KeyValuePair<Vector3, float>>();

		public StructureGenerator(StructureSpawnConfig config, DiContainer diContainer)
		{
			_config = config;
			_diContainer = diContainer;
		}

		public void SpawnStructuresOnIsland(Vector3 islandCenter, int chunkX, int chunkY, int globalSeed, Transform parent, Action<Vector3, float> onStructureSpawned = null)
		{
			int num = globalSeed ^ ((chunkX * 73856093) ^ (chunkY * 1920164489));
			System.Random random = new System.Random(num);
			Terrain terrainUnderPoint = GetTerrainUnderPoint(islandCenter);
			if (terrainUnderPoint == null)
			{
				Debug.LogWarning($"[StructureGenerator] Не знайдено Terrain під {islandCenter}");
				return;
			}
			Vector3 terrainCenter = GetTerrainCenter(terrainUnderPoint);
			TerrainBounds terrainBounds = GetTerrainBounds(terrainUnderPoint);
			List<SurfacePoint> list = SampleValidSurfacePoints(terrainUnderPoint, terrainCenter, islandCenter.y, terrainBounds);
			if (list.Count == 0)
			{
				Debug.LogWarning($"[StructureGenerator] Немає валідних точок поверхні для острова на {islandCenter}");
				return;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num2 = 0;
			int num3 = random.Next(1, _config.MaxStructuresPerIsland + 1);
			for (int i = 0; i < num3 && num2 < _config.MaxStructuresPerIsland; i++)
			{
				int num4 = random.Next(_config.Structures.Count);
				StructureSettings structureSettings = _config.Structures[num4];
				if (random.NextDouble() > (double)structureSettings.SpawnChance || (structureSettings.RequiresExistingStructure && num2 == 0))
				{
					continue;
				}
				if (structureSettings.MaxCountPerIsland > 0)
				{
					if (!dictionary.ContainsKey(num4))
					{
						dictionary[num4] = 0;
					}
					if (dictionary[num4] >= structureSettings.MaxCountPerIsland)
					{
						continue;
					}
				}
				List<SurfacePoint> list2 = new List<SurfacePoint>(list);
				Shuffle(list2, random);
				if (TryPlaceStructure(list2, terrainUnderPoint, terrainBounds, structureSettings, random, out var resultPos, out var resultRot))
				{
					StructureComponent structureComponent = UnityEngine.Object.Instantiate(structureSettings.Prefab, resultPos, resultRot, parent);
					_spawnedStructureDatas.Add(new KeyValuePair<Vector3, float>(resultPos, structureSettings.ClearanceRadius));
					if (!dictionary.ContainsKey(num4))
					{
						dictionary[num4] = 0;
					}
					dictionary[num4]++;
					num2++;
					System.Random prng = new System.Random((num * 1000003) ^ num2);
					structureComponent.GenerateLoot(prng, structureSettings, _diContainer, $"{num}_{num2}");
					onStructureSpawned?.Invoke(resultPos, structureSettings.ClearanceRadius);
				}
				else
				{
					Debug.LogWarning("[StructureGenerator] Не вдалось розмістити '" + structureSettings.Prefab.name + "' " + $"на острові {islandCenter} — немає підходящої позиції/ротації.");
				}
			}
		}

		private bool TryPlaceStructure(List<SurfacePoint> surface, Terrain terrain, TerrainBounds bounds, StructureSettings settings, System.Random prng, out Vector3 resultPos, out Quaternion resultRot)
		{
			resultPos = Vector3.zero;
			resultRot = Quaternion.identity;
			Vector3 fromDirection = settings.Prefab.UpAxis.ToVector();
			float rotationSearchStep = _config.RotationSearchStep;
			int num = Mathf.RoundToInt(360f / rotationSearchStep);
			float num2 = (float)(prng.NextDouble() * 360.0);
			List<Vector3> localBoundaryPoints = settings.Prefab.GetLocalBoundaryPoints();
			int num3 = Mathf.Min(_config.MaxRetries, surface.Count);
			for (int i = 0; i < num3; i++)
			{
				SurfacePoint surfacePoint = surface[i];
				if (surfacePoint.Steepness > settings.MaxSteepness || (settings.PreferSlopes && surfacePoint.Steepness < settings.MinSteepnessForSlopes) || !IsPositionClear(surfacePoint.WorldPos, settings.ClearanceRadius))
				{
					continue;
				}
				Quaternion quaternion = Quaternion.FromToRotation(fromDirection, surfacePoint.Normal);
				for (int j = 0; j < num; j++)
				{
					Quaternion quaternion2 = Quaternion.AngleAxis(num2 + (float)j * rotationSearchStep, surfacePoint.Normal) * quaternion;
					if (IsBoundaryFlat(localBoundaryPoints, surfacePoint.WorldPos, quaternion2, terrain, bounds))
					{
						resultPos = surfacePoint.WorldPos;
						resultRot = quaternion2;
						return true;
					}
				}
			}
			return false;
		}

		private List<SurfacePoint> SampleValidSurfacePoints(Terrain terrain, Vector3 terrainCenter, float pivotY, TerrainBounds bounds)
		{
			List<SurfacePoint> list = new List<SurfacePoint>();
			TerrainData terrainData = terrain.terrainData;
			Vector3 position = terrain.transform.position;
			float islandRadius = _config.IslandRadius;
			float num = islandRadius * islandRadius;
			for (float num2 = terrainCenter.x - islandRadius; num2 <= terrainCenter.x + islandRadius; num2 += 2f)
			{
				if (num2 < bounds.MinX || num2 > bounds.MaxX)
				{
					continue;
				}
				for (float num3 = terrainCenter.z - islandRadius; num3 <= terrainCenter.z + islandRadius; num3 += 2f)
				{
					if (num3 < bounds.MinZ || num3 > bounds.MaxZ)
					{
						continue;
					}
					float num4 = num2 - terrainCenter.x;
					float num5 = num3 - terrainCenter.z;
					if (num4 * num4 + num5 * num5 > num)
					{
						continue;
					}
					float x = (num2 - position.x) / terrainData.size.x;
					float y = (num3 - position.z) / terrainData.size.z;
					float num6 = terrain.SampleHeight(new Vector3(num2, 0f, num3));
					float num7 = position.y + num6;
					if (!(num7 <= pivotY))
					{
						float steepness = terrainData.GetSteepness(x, y);
						if (!(steepness > 30f))
						{
							list.Add(new SurfacePoint
							{
								WorldPos = new Vector3(num2, num7, num3),
								Normal = terrainData.GetInterpolatedNormal(x, y),
								Steepness = steepness
							});
						}
					}
				}
			}
			return list;
		}

		private bool IsBoundaryFlat(List<Vector3> localPoints, Vector3 spawnPos, Quaternion spawnRot, Terrain terrain, TerrainBounds bounds)
		{
			if (localPoints.Count < 2)
			{
				return true;
			}
			List<Vector3> list = new List<Vector3>(localPoints.Count);
			foreach (Vector3 localPoint in localPoints)
			{
				Vector3 vector = spawnPos + spawnRot * localPoint;
				if (!bounds.Contains(vector))
				{
					return false;
				}
				list.Add(vector);
			}
			float maxHeightDifference = _config.MaxHeightDifference;
			float boundaryCheckStep = _config.BoundaryCheckStep;
			for (int i = 0; i < list.Count - 1; i++)
			{
				for (int j = i + 1; j < list.Count; j++)
				{
					if (!IsLineFlatOnTerrain(list[i], list[j], terrain, boundaryCheckStep, maxHeightDifference, bounds))
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool IsLineFlatOnTerrain(Vector3 pointA, Vector3 pointB, Terrain terrain, float step, float maxAllowedDiff, TerrainBounds bounds)
		{
			float num = Vector3.Distance(pointA, pointB);
			if (num < 0.001f)
			{
				return true;
			}
			int num2 = Mathf.Max(2, Mathf.CeilToInt(num / step) + 1);
			float num3 = terrain.SampleHeight(pointA);
			for (int i = 1; i < num2; i++)
			{
				float t = (float)i / (float)(num2 - 1);
				Vector3 vector = Vector3.Lerp(pointA, pointB, t);
				if (!bounds.Contains(vector))
				{
					return false;
				}
				float num4 = terrain.SampleHeight(vector);
				if (Mathf.Abs(num4 - num3) > maxAllowedDiff)
				{
					return false;
				}
				num3 = num4;
			}
			return true;
		}

		private static Vector3 GetTerrainCenter(Terrain terrain)
		{
			Vector3 position = terrain.transform.position;
			Vector3 size = terrain.terrainData.size;
			return new Vector3(position.x + size.x * 0.5f, position.y, position.z + size.z * 0.5f);
		}

		private Terrain GetTerrainUnderPoint(Vector3 worldPos)
		{
			Terrain[] activeTerrains = Terrain.activeTerrains;
			foreach (Terrain terrain in activeTerrains)
			{
				float x = terrain.transform.position.x;
				float z = terrain.transform.position.z;
				if (worldPos.x >= x && worldPos.x <= x + terrain.terrainData.size.x && worldPos.z >= z && worldPos.z <= z + terrain.terrainData.size.z)
				{
					return terrain;
				}
			}
			return Terrain.activeTerrain;
		}

		private static TerrainBounds GetTerrainBounds(Terrain terrain)
		{
			Vector3 position = terrain.transform.position;
			return new TerrainBounds
			{
				MinX = position.x,
				MaxX = position.x + terrain.terrainData.size.x,
				MinZ = position.z,
				MaxZ = position.z + terrain.terrainData.size.z
			};
		}

		private bool IsPositionClear(Vector3 pos, float requiredRadius)
		{
			foreach (KeyValuePair<Vector3, float> spawnedStructureData in _spawnedStructureDatas)
			{
				float num = requiredRadius + spawnedStructureData.Value;
				float num2 = pos.x - spawnedStructureData.Key.x;
				float num3 = pos.z - spawnedStructureData.Key.z;
				if (num2 * num2 + num3 * num3 < num * num)
				{
					return false;
				}
			}
			return true;
		}

		private static void Shuffle<T>(List<T> list, System.Random prng)
		{
			for (int num = list.Count - 1; num > 0; num--)
			{
				int num2 = prng.Next(num + 1);
				int index = num;
				int index2 = num2;
				T val = list[num2];
				T val2 = list[num];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public void ClearData()
		{
			_spawnedStructureDatas.Clear();
		}
	}
}
