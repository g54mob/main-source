using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldEnvironment.Foliage
{
	public class FoliageGenerator
	{
		private struct SurfacePoint
		{
			public Vector3 WorldPos;

			public Vector3 Normal;

			public float Steepness;
		}

		private readonly FoliageSpawnConfig _config;

		private readonly List<Vector3> _placedTreePositions = new List<Vector3>();

		private readonly List<List<Vector3>> _placedPropPositions = new List<List<Vector3>>();

		private readonly List<KeyValuePair<Vector3, float>> _forbiddenZones = new List<KeyValuePair<Vector3, float>>();

		public FoliageGenerator(FoliageSpawnConfig config)
		{
			_config = config;
			for (int i = 0; i < config.Props.Count; i++)
			{
				_placedPropPositions.Add(new List<Vector3>());
			}
		}

		public void AddForbiddenZone(Vector3 center, float radius)
		{
			_forbiddenZones.Add(new KeyValuePair<Vector3, float>(center, radius));
		}

		public void SpawnFoliageOnIsland(Vector3 islandCenter, int chunkX, int chunkY, int globalSeed, Transform parent)
		{
			System.Random prng = new System.Random(globalSeed ^ ((chunkX * 73856093) ^ (chunkY * 1920164489)) ^ 0x17B50BD5);
			Terrain terrainUnderPoint = GetTerrainUnderPoint(islandCenter);
			if (terrainUnderPoint == null)
			{
				Debug.LogWarning($"[FoliageGenerator] Не знайдено Terrain під {islandCenter}");
				return;
			}
			List<SurfacePoint> list = SampleSurface(terrainUnderPoint, islandCenter);
			if (list.Count == 0)
			{
				Debug.LogWarning($"[FoliageGenerator] Немає валідних точок поверхні для {islandCenter}");
				return;
			}
			ShuffleList(list, prng);
			SpawnTrees(terrainUnderPoint, list, prng);
			SpawnProps(list, prng, parent);
		}

		private void SpawnTrees(Terrain terrain, List<SurfacePoint> surface, System.Random prng)
		{
			if (_config.Trees.Count == 0)
			{
				return;
			}
			TerrainData terrainData = terrain.terrainData;
			Vector3 position = terrain.transform.position;
			List<TreeInstance> list = new List<TreeInstance>(terrainData.treeInstances);
			List<TreeInstance> list2 = new List<TreeInstance>();
			foreach (SurfacePoint item2 in surface)
			{
				foreach (TreeSpawnSettings tree in _config.Trees)
				{
					if (!(item2.Steepness > tree.MaxSteepness) && !(prng.NextDouble() > (double)tree.SpawnChance) && IsTreePositionClear(item2.WorldPos, tree.MinDistance) && !IsInForbiddenZone(item2.WorldPos))
					{
						float x = Mathf.Clamp01((item2.WorldPos.x - position.x) / terrainData.size.x);
						float z = Mathf.Clamp01((item2.WorldPos.z - position.z) / terrainData.size.z);
						float y = Mathf.Clamp01((item2.WorldPos.y - position.y) / terrainData.size.y);
						float heightScale = Mathf.Lerp(tree.MinHeight, tree.MaxHeight, (float)prng.NextDouble());
						float widthScale = Mathf.Lerp(tree.MinWidth, tree.MaxWidth, (float)prng.NextDouble());
						float rotation = (tree.RandomRotation ? ((float)(prng.NextDouble() * 3.1415927410125732 * 2.0)) : 0f);
						TreeInstance item = new TreeInstance
						{
							prototypeIndex = tree.TreePrototypeIndex,
							position = new Vector3(x, y, z),
							heightScale = heightScale,
							widthScale = widthScale,
							rotation = rotation,
							color = Color.white,
							lightmapColor = Color.white
						};
						list2.Add(item);
						_placedTreePositions.Add(item2.WorldPos);
						break;
					}
				}
			}
			if (list2.Count > 0)
			{
				list.AddRange(list2);
				terrainData.SetTreeInstances(list.ToArray(), snapToHeightmap: true);
				terrain.Flush();
			}
		}

		private void SpawnProps(List<SurfacePoint> surface, System.Random prng, Transform parent)
		{
			if (_config.Props.Count == 0)
			{
				return;
			}
			for (int i = 0; i < _config.Props.Count; i++)
			{
				PropSpawnSettings propSpawnSettings = _config.Props[i];
				if (propSpawnSettings.Prefab == null)
				{
					continue;
				}
				List<Vector3> list = _placedPropPositions[i];
				foreach (SurfacePoint item in surface)
				{
					if (!(item.Steepness > propSpawnSettings.MaxSteepness) && !(prng.NextDouble() > (double)propSpawnSettings.SpawnChance) && IsPropPositionClear(item.WorldPos, propSpawnSettings.MinDistance, list) && !IsInForbiddenZone(item.WorldPos))
					{
						float num = Mathf.Lerp(propSpawnSettings.MinScale, propSpawnSettings.MaxScale, (float)prng.NextDouble());
						Quaternion rotation;
						if (propSpawnSettings.AlignToTerrainNormal)
						{
							Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, item.Normal);
							float y = (propSpawnSettings.RandomYRotation ? ((float)(prng.NextDouble() * 360.0)) : 0f);
							rotation = quaternion * Quaternion.Euler(0f, y, 0f);
						}
						else
						{
							float y2 = (propSpawnSettings.RandomYRotation ? ((float)(prng.NextDouble() * 360.0)) : 0f);
							rotation = Quaternion.Euler(0f, y2, 0f);
						}
						UnityEngine.Object.Instantiate(propSpawnSettings.Prefab, item.WorldPos, rotation, parent).transform.localScale = Vector3.one * num;
						list.Add(item.WorldPos);
					}
				}
			}
		}

		private List<SurfacePoint> SampleSurface(Terrain terrain, Vector3 islandCenter)
		{
			List<SurfacePoint> list = new List<SurfacePoint>();
			TerrainData terrainData = terrain.terrainData;
			Vector3 position = terrain.transform.position;
			float surfaceSampleStep = _config.SurfaceSampleStep;
			float x = terrainData.size.x;
			float z = terrainData.size.z;
			for (float num = 0f; num < x; num += surfaceSampleStep)
			{
				for (float num2 = 0f; num2 < z; num2 += surfaceSampleStep)
				{
					float x2 = position.x + num;
					float z2 = position.z + num2;
					float x3 = Mathf.Clamp01(num / x);
					float y = Mathf.Clamp01(num2 / z);
					float num3 = terrain.SampleHeight(new Vector3(x2, 0f, z2));
					float num4 = position.y + num3;
					if (!(num4 <= islandCenter.y))
					{
						float steepness = terrainData.GetSteepness(x3, y);
						if (!(steepness > _config.GlobalMaxSteepness))
						{
							Vector3 interpolatedNormal = terrainData.GetInterpolatedNormal(x3, y);
							list.Add(new SurfacePoint
							{
								WorldPos = new Vector3(x2, num4, z2),
								Normal = interpolatedNormal,
								Steepness = steepness
							});
						}
					}
				}
			}
			return list;
		}

		private bool IsTreePositionClear(Vector3 pos, float minDist)
		{
			float num = minDist * minDist;
			foreach (Vector3 placedTreePosition in _placedTreePositions)
			{
				float num2 = pos.x - placedTreePosition.x;
				float num3 = pos.z - placedTreePosition.z;
				if (num2 * num2 + num3 * num3 < num)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsPropPositionClear(Vector3 pos, float minDist, List<Vector3> placedList)
		{
			float num = minDist * minDist;
			foreach (Vector3 placed in placedList)
			{
				float num2 = pos.x - placed.x;
				float num3 = pos.z - placed.z;
				if (num2 * num2 + num3 * num3 < num)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsInForbiddenZone(Vector3 pos)
		{
			foreach (KeyValuePair<Vector3, float> forbiddenZone in _forbiddenZones)
			{
				float num = pos.x - forbiddenZone.Key.x;
				float num2 = pos.z - forbiddenZone.Key.z;
				float value = forbiddenZone.Value;
				if (num * num + num2 * num2 < value * value)
				{
					return true;
				}
			}
			return false;
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

		private static void ShuffleList<T>(List<T> list, System.Random prng)
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
			_placedTreePositions.Clear();
			foreach (List<Vector3> placedPropPosition in _placedPropPositions)
			{
				placedPropPosition.Clear();
			}
			_forbiddenZones.Clear();
		}
	}
}
