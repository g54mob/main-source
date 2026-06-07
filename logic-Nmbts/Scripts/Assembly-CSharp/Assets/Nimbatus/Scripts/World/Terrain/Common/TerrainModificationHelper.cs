using System;
using System.ComponentModel;
using System.Threading;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.Core;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain.Common
{
	public static class TerrainModificationHelper
	{
		public static readonly ConcurrentQueue<Action> BackgroundQueue;

		public static bool StopThread;

		static TerrainModificationHelper()
		{
			BackgroundQueue = new ConcurrentQueue<Action>();
			StopThread = false;
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += WorkQueue;
			backgroundWorker.RunWorkerAsync();
		}

		private static void WorkQueue(object sender, DoWorkEventArgs e)
		{
			while (!StopThread)
			{
				try
				{
					int num = BackgroundQueue.Count;
					while (num > 0)
					{
						Action value;
						if (BackgroundQueue.TryDequeue(out value))
						{
							num--;
						}
						if (value != null)
						{
							value();
						}
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				Thread.Sleep(1);
			}
		}

		public static void Enqueue(Action action)
		{
			BackgroundQueue.Enqueue(action);
		}

		public static void LerpRemoveTerrainSphere(NimbatusTerrain terrain, Vector3 worldPos, float radius, float time, EAmmunitionType ammunitionType = EAmmunitionType.None)
		{
			Enqueue(delegate
			{
				LerpRemoveTerrainSphereInternal(terrain, ToInt(worldPos), radius, time, ammunitionType);
			});
		}

		private static void LerpRemoveTerrainSphereInternal(NimbatusTerrain terrain, Vector3 worldPos, float radius, float time, EAmmunitionType ammo)
		{
			if (terrain == null)
			{
				return;
			}
			worldPos.z = 0f;
			NimbatusTerrainData? data = terrain.GetData(worldPos);
			if (!data.HasValue)
			{
				return;
			}
			float num = data.Value.Volume;
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					Vector3 pos = worldPos + new Vector3(i, j, 0f);
					NimbatusTerrainData? data2 = terrain.GetData(pos);
					if (data2.HasValue)
					{
						num = Mathf.Max(data2.Value.Volume, num);
					}
				}
			}
			if (SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone == null)
			{
				return;
			}
			NimbatusClimateZoneLayer layer = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false);
			int num2 = Mathf.RoundToInt(radius);
			for (int k = -num2; k <= num2; k++)
			{
				for (int l = -num2; l <= num2; l++)
				{
					Vector3 vector = worldPos + new Vector3(k, l, 0f);
					NimbatusTerrainData? data3 = terrain.GetData(vector);
					if (!data3.HasValue)
					{
						continue;
					}
					float volume = data3.Value.Volume;
					ushort materialType = data3.Value.MaterialType;
					float materialStrength = layer.GetMaterialStrength(ammo);
					float num3 = volume;
					float num4 = time;
					bool flag = false;
					if (materialStrength < 0f)
					{
						if (num > 0.5f)
						{
							num3 = Mathf.Clamp01(TriangulationHelper.GetVoxelVolumeForSphere(vector, worldPos, radius * 0.5f));
							num4 = time / (layer.MaterialStrength * WorldController.TerrainSettings.GetTerrainHardness());
							materialType = data.Value.MaterialType;
							if (num3 > volume)
							{
								flag = true;
							}
						}
					}
					else
					{
						num3 = Mathf.Clamp01(1f - TriangulationHelper.GetVoxelVolumeForSphere(vector, worldPos, radius * 1.2f));
						num4 = time / (materialStrength * WorldController.TerrainSettings.GetTerrainHardness());
						if (num3 < volume)
						{
							flag = true;
						}
					}
					if (flag)
					{
						if (num4 > 0f)
						{
							terrain.LerpData(vector, new NimbatusTerrainData(num3, materialType), num4);
						}
						else
						{
							terrain.SetData(vector, new NimbatusTerrainData(num3, materialType));
						}
					}
				}
			}
		}

		public static void LerpRebuildTerrainSphere(NimbatusTerrain terrain, Vector3 worldPos, float radius, float time)
		{
			Enqueue(delegate
			{
				LerpRebuildTerrainSphereInternal(terrain, ToInt(worldPos), radius, time);
			});
		}

		private static void LerpRebuildTerrainSphereInternal(NimbatusTerrain terrain, Vector3 worldPos, float radius, float time)
		{
			if (terrain == null)
			{
				return;
			}
			worldPos.z = 0f;
			int num = Mathf.RoundToInt(radius);
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num; j <= num; j++)
				{
					Vector3 vector = worldPos + new Vector3(i, j, 0f);
					NimbatusTerrainData? data = terrain.GetData(vector);
					if (!data.HasValue)
					{
						continue;
					}
					float volume = data.Value.Volume;
					ushort materialType = data.Value.MaterialType;
					bool flag = false;
					float num2 = Mathf.Clamp01(TriangulationHelper.GetVoxelVolumeForSphere(vector, worldPos, radius * 1.5f));
					if (num2 > volume)
					{
						flag = true;
					}
					if (flag)
					{
						if (time > 0f)
						{
							terrain.LerpData(vector, new NimbatusTerrainData(num2, materialType), time);
						}
						else
						{
							terrain.SetData(vector, new NimbatusTerrainData(num2, materialType));
						}
					}
				}
			}
		}

		public static void LerpCollectResources(NimbatusTerrain terrain, ResourceHub hub, Vector3 worldPos, int radius, float time, Action<Color, Vector3> collectAction, bool removeTerrain)
		{
			Enqueue(delegate
			{
				CollectResources(terrain, hub, ToInt(worldPos), radius, time, collectAction, removeTerrain);
			});
		}

		public static bool IsCollectable(Vector3 worldPos, float radius = 3f)
		{
			NimbatusTerrain foreGroundTerrain = RuntimeGlobals.WorldController.ForeGroundTerrain;
			worldPos.z = 0f;
			for (float num = 0f - radius; num <= radius; num += 1f)
			{
				for (float num2 = 0f - radius; num2 <= radius; num2 += 1f)
				{
					Vector3 pos = worldPos + new Vector3(num, num2, 0f);
					NimbatusTerrainData? data = foreGroundTerrain.GetData(pos);
					if (data.HasValue && SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false).IsCollectable && data.Value.Volume > 0.5f)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsTerrainInArea(Vector3 center, Vector3 direction, float radius, float angle)
		{
			if (RuntimeGlobals.WorldController == null)
			{
				return false;
			}
			if (RuntimeGlobals.WorldController.ForeGroundTerrain == null)
			{
				return false;
			}
			NimbatusTerrain foreGroundTerrain = RuntimeGlobals.WorldController.ForeGroundTerrain;
			center.z = 0f;
			for (float num = 0f - radius; num <= radius; num += 1f)
			{
				for (float num2 = 0f - radius; num2 <= radius; num2 += 1f)
				{
					Vector3 vector = center + new Vector3(num, num2, 0f);
					if (IsPointInsideArea(vector, center, direction, radius, angle))
					{
						NimbatusTerrainData? data = foreGroundTerrain.GetData(vector);
						if (data.HasValue && data.Value.Volume > 0.5f)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public static bool IsCollectableMaterialInArea(Vector3 center, Vector3 direction, float radius, float angle, out ETerrainMaterial material)
		{
			material = ETerrainMaterial.None;
			if (RuntimeGlobals.WorldController == null)
			{
				return false;
			}
			if (RuntimeGlobals.WorldController.ForeGroundTerrain == null)
			{
				return false;
			}
			NimbatusTerrain foreGroundTerrain = RuntimeGlobals.WorldController.ForeGroundTerrain;
			center.z = 0f;
			for (float num = 0f - radius; num <= radius; num += 1f)
			{
				for (float num2 = 0f - radius; num2 <= radius; num2 += 1f)
				{
					Vector3 vector = center + new Vector3(num, num2, 0f);
					if (!IsPointInsideArea(vector, center, direction, radius, angle))
					{
						continue;
					}
					NimbatusTerrainData? data = foreGroundTerrain.GetData(vector);
					if (data.HasValue)
					{
						NimbatusClimateZoneLayer layer = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false);
						if (layer.IsCollectable && data.Value.Volume > 0.5f)
						{
							material = layer.TerrainMaterial;
							return true;
						}
					}
				}
			}
			return false;
		}

		private static bool IsPointInsideArea(Vector3 point, Vector3 center, Vector3 direction, float range, float angle)
		{
			Vector3 to = point - center;
			if (Vector3.Angle(direction, to) >= angle / 2f)
			{
				return false;
			}
			return Vector2.Distance(center, point) < range;
		}

		private static void CollectResources(NimbatusTerrain terrain, ResourceHub hub, Vector3 worldPos, int radius, float time, Action<Color, Vector3> collectAction, bool removeTerrain)
		{
			if (terrain == null)
			{
				return;
			}
			worldPos.z = 0f;
			bool flag = false;
			for (int i = -radius; i <= radius; i++)
			{
				for (int j = -radius; j <= radius; j++)
				{
					Vector3 vector = worldPos + new Vector3(i, j, 0f);
					NimbatusTerrainData? data = terrain.GetData(vector);
					if (!data.HasValue)
					{
						continue;
					}
					NimbatusClimateZoneLayer layer = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone.GetLayer(data.Value.MaterialType, false);
					if (layer.IsCollectable && hub.HasCapacity(EnumHelper.ConvertEnum(layer.TerrainMaterial), 1f))
					{
						float volume = data.Value.Volume;
						ushort materialType = data.Value.MaterialType;
						bool flag2 = false;
						float num = Mathf.Clamp01(1f - TriangulationHelper.GetVoxelVolumeForSphere(vector, worldPos, (float)radius * 1.2f));
						if (num < volume && volume >= 0.5f)
						{
							flag2 = true;
						}
						if (!flag2)
						{
							continue;
						}
						float num2 = Mathf.Clamp01(time);
						float amount = (volume - num) * num2 * 0.0625f;
						if (!hub.HasCapacity(EnumHelper.ConvertEnum(layer.TerrainMaterial), amount))
						{
							continue;
						}
						hub.AddResourceToParts(EnumHelper.ConvertEnum(layer.TerrainMaterial), amount);
						terrain.LerpData(vector, new NimbatusTerrainData(num, materialType), num2);
						PlanetLocationData planetLocationData;
						if ((planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation as PlanetLocationData) != null)
						{
							planetLocationData.SetMineralCollected(vector);
						}
						if (!flag)
						{
							if (collectAction != null)
							{
								collectAction(layer.Color, vector);
							}
							flag = true;
						}
					}
					else
					{
						if (!removeTerrain)
						{
							continue;
						}
						float volume2 = data.Value.Volume;
						ushort materialType2 = data.Value.MaterialType;
						bool flag3 = false;
						float num3 = Mathf.Clamp01(1f - TriangulationHelper.GetVoxelVolumeForSphere(vector, worldPos, (float)radius * 1.2f));
						float num4 = time / WorldController.TerrainSettings.GetTerrainHardness();
						if (num3 < volume2)
						{
							flag3 = true;
						}
						if (flag3)
						{
							if (num4 > 0f)
							{
								terrain.LerpData(vector, new NimbatusTerrainData(num3, materialType2), num4);
							}
							else
							{
								terrain.SetData(vector, new NimbatusTerrainData(num3, materialType2));
							}
						}
					}
				}
			}
		}

		private static Vector3 ToInt(Vector3 vector)
		{
			return new Vector3(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y), 0f);
		}
	}
}
