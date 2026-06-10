using System;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.EnvironmentEffects;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Tools;
using NSMedieval.Utils;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval
{
	public class MapEdgeFrameChunk : MapChunk
	{
		[NonSerialized]
		private Heightmap heightmap;

		[NonSerialized]
		private System.Random plantsVisualRandom;

		protected override void RecalculateMaxHeight()
		{
		}

		public new void Setup(bool loadFromSave, int chunkX, int chunkY, int chunkZ, Vec3Int mapSize, int chunkSize)
		{
			base.Setup(loadFromSave, chunkX, chunkY, chunkZ, mapSize, chunkSize);
			int seed = chunkX + chunkZ * mapSizeX + GlobalSaveController.CurrentVillageData.MapSeed.GetHashCodeDeterministic();
			plantsVisualRandom = new System.Random(seed);
			heightmap = MonoSingleton<Heightmap>.Instance;
			base.ChunkGeneratedEvent += OnChunkGenerated;
		}

		public override void LoadMesh(int elevationLevel)
		{
			int meshIndexForElevationLevel = GetMeshIndexForElevationLevel(elevationLevel);
			if (!(meshCache[meshIndexForElevationLevel] == null))
			{
				base.LoadMesh(elevationLevel);
			}
		}

		protected override void OnGenerateMeshesFinished()
		{
			base.OnGenerateMeshesFinished();
			int meshCacheIndex = vertices.Keys.Max();
			AddLayerCrossSectionToMesh(meshCacheIndex);
		}

		protected override void OnDestroy()
		{
			base.ChunkGeneratedEvent -= OnChunkGenerated;
			base.OnDestroy();
		}

		private void OnChunkGenerated()
		{
			base.ChunkGeneratedEvent -= OnChunkGenerated;
			SpawnPlantsVisuals();
		}

		private void SpawnPlantsVisuals()
		{
			VillageMap villageMap = VillageManager.ActiveVillage.Map;
			NSMedieval.Model.MapNew.Map mapBlueprint = GlobalSaveController.CurrentVillageData.MapBlueprint;
			Vec3Int mapSize = GlobalSaveController.CurrentVillageData.MapSize;
			int num = plantsVisualRandom.Next(0, 10);
			for (int i = 0; i < num; i++)
			{
				int num2 = chunkX + plantsVisualRandom.Next(0, chunkSize - 1);
				int num3 = chunkZ + plantsVisualRandom.Next(0, chunkSize - 1);
				if (num3 >= GridDataIndexTools.SizeZ + 80 || num2 >= GridDataIndexTools.SizeX + 80 || GridDataIndexTools.InRangeXZ(num2, num3))
				{
					continue;
				}
				heightmap.MapFromEdgeFrameToMapCoords(num2, num3, out var xMapSpace, out var zMapSpace);
				int heightAt = heightmap.GetHeightAt(xMapSpace, zMapSpace);
				WaterDepthLevel waterDepthLevel = villageMap.WaterManager.GetWaterDepthLevel(xMapSpace, heightAt, zMapSpace);
				if (waterDepthLevel <= WaterDepthLevel.Low)
				{
					mapBlueprint.GetPlantsDistribution(mapSize, waterDepthLevel, out var outputPlantsList);
					if (outputPlantsList != null)
					{
						PlantMapResource plant = outputPlantsList.PickRandom(plantsVisualRandom);
						SpawnPlantVisual(plant, new Vec3Int(num2, heightAt, num3));
					}
				}
			}
		}

		private void SpawnPlantVisual(PlantMapResource plant, Vec3Int gridPosition)
		{
			if (!(plant == null))
			{
				Vector3 position = new Vector3(gridPosition.x, gridPosition.y * World.MapBlockHeight, gridPosition.z);
				string objectAddress = plant.PrefabIDs.PickRandom(plantsVisualRandom);
				GameObject gameObject = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(objectAddress), position, Quaternion.identity, base.transform);
				PlantMapResourceView component = gameObject.GetComponent<PlantMapResourceView>();
				component.Setup(null, plant, gridPosition);
				PlantLifePhases plantLifePhases = ((plant.CutPhase != -1 && plantsVisualRandom.NextDouble() < 0.800000011920929) ? plant.GetCutPhase() : plant.LifePhases.PickRandom(plantsVisualRandom));
				component.ApplyAppearance(stuntedAppearance: (plantsVisualRandom.NextDouble() > 0.95) ? plant.StuntedAppearance : null, appearance: plantLifePhases.Appearance);
				gameObject.DeleteChildIfExists("birds_scare_position");
				gameObject.DeleteChildIfExists("ShakeLeavesVolume");
				gameObject.DeleteChildIfExists("DustParticlesHolder");
				gameObject.DeleteAllComponentsIfExist<ResourceDestroy>();
				gameObject.DeleteAllComponentsIfExist<Shaker>();
				gameObject.DeleteAllComponentsIfExist<BirdsScare>();
				gameObject.DeleteAllComponentsIfExist<MeshVariationHandler>();
				gameObject.DeleteAllComponentsIfExist<PlantMapResourceView>();
				gameObject.DeleteAllComponentsIfExist<ClickDetection>();
				gameObject.DeleteAllComponentsIfExist<PaticleExistRandomize>();
				gameObject.DeleteAllComponentsIfExist<BoxCollider>();
				gameObject.name = "fake_" + gameObject.name;
			}
		}

		protected override bool CanStartGeneratingMesh()
		{
			if (!MonoSingleton<Heightmap>.IsInstantiated() || MonoSingleton<Heightmap>.IsApplicationIsQuitting())
			{
				return false;
			}
			if (MonoSingleton<Heightmap>.Instance.IsReady)
			{
				maxHeight = CalculateMaxHeight();
				chunkY = maxHeight + 1;
				meshLevelUpdate = maxHeight + 1;
			}
			return MonoSingleton<Heightmap>.Instance.IsReady;
		}

		private void AddLayerCrossSectionToMesh(int meshCacheIndex)
		{
			bool[,] array = new bool[chunkSize, chunkSize];
			for (int num = mapSizeY; num >= 0; num--)
			{
				Array.Clear(array, 0, array.Length);
				for (int i = 0; i < chunkSize; i++)
				{
					for (int j = 0; j < chunkSize; j++)
					{
						if (array[j, i] || !IsBlockAt(j, num, i))
						{
							continue;
						}
						int num2 = j;
						int num3 = i;
						int k = 1;
						int l = 1;
						for (; j + k < chunkSize && IsBlockAt(j + k, num, i) && !array[j + k, i]; k++)
						{
						}
						for (; i + l < chunkSize; l++)
						{
							bool flag = true;
							for (int m = 0; m < k; m++)
							{
								if (!IsBlockAt(j + m, num, i + l) || array[j + m, i + l])
								{
									flag = false;
									break;
								}
							}
							if (!flag)
							{
								break;
							}
						}
						int num4 = num * World.MapBlockHeight;
						Vector3 v = new Vector3(num2, num4, num3);
						Vector3 v2 = new Vector3(num2 + k, num4, num3);
						Vector3 v3 = new Vector3(num2 + k, num4, num3 + l);
						Vector3 v4 = new Vector3(num2, num4, num3 + l);
						int count = vertices[meshCacheIndex].Count;
						AddQuad(meshCacheIndex, v4, v3, v2, v, Vector3.up, count);
						for (int n = 0; n < k; n++)
						{
							for (int num5 = 0; num5 < l; num5++)
							{
								array[num2 + n, num3 + num5] = true;
							}
						}
						j += k - 1;
					}
				}
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			bool IsBlockAt(int x, int y, int z)
			{
				return !MapChunk.IsEmptyValue(GetChunkDataAt(x, y, z, mapSizeY));
			}
		}

		private int CalculateMaxHeight()
		{
			int num = -1;
			for (int i = 0; i < chunkSize; i++)
			{
				for (int j = 0; j < chunkSize; j++)
				{
					int x = chunkX + i;
					int z = chunkZ + j;
					if (heightmap.IsInFrame(x, z))
					{
						num = Math.Max(num, heightmap.GetHeightEdgeFrameIncluded(x, z));
					}
				}
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected override byte GetChunkDataAt(int x, int y, int z, int maxElevationLevel)
		{
			int num = x + chunkX;
			if (num < -80 || num >= mapSizeX + 80)
			{
				return 0;
			}
			int num2 = z + chunkZ;
			if (num2 < -80 || num2 >= mapSizeZ + 80)
			{
				return 0;
			}
			if (!heightmap.IsInFrame(num, num2))
			{
				return 0;
			}
			int heightEdgeFrameIncluded = heightmap.GetHeightEdgeFrameIncluded(num, num2);
			if (y >= heightEdgeFrameIncluded || y >= maxElevationLevel)
			{
				return 0;
			}
			return 1;
		}
	}
}
