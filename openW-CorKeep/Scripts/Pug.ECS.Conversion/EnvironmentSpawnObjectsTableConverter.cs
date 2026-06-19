using System.Collections.Generic;
using Pug.Conversion;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class EnvironmentSpawnObjectsTableConverter : SingleAuthoringComponentConverter<EnvironmentSpawnObjectsTableAuthoring>
{
	protected override void Convert(EnvironmentSpawnObjectsTableAuthoring authoring)
	{
		EnvironmentSpawnObjectsTable environmentSpawnObjectsTable = (Application.isPlaying ? Manager.mod.SpawnTable : authoring.table);
		List<ValueWithWeight<int>> list = new List<ValueWithWeight<int>>();
		EnsureHasBuffer<EnvironmentSpawnObjectBuffer>();
		foreach (EnvironmentSpawnData spawnObject in environmentSpawnObjectsTable.spawnObjects)
		{
			EnvironmentSpawnData.SpawnCheck spawnCheck = spawnObject.spawnCheck;
			EnvironmentSpawnObjectBuffer environmentSpawnObjectBuffer = new EnvironmentSpawnObjectBuffer
			{
				spawnChance = spawnCheck.spawnChance.AsWorldGenSettingDependentValue(),
				spawnsInBiome = spawnCheck.biome,
				canSpawnInBlockedArea = spawnCheck.canSpawnInBlockedArea,
				skipSpawnForPartialMap = spawnCheck.skipSpawnForPartialMaps,
				spawnsOnTileType = spawnCheck.tileType,
				alsoSpawnNextNObjectsFromSameBiome = 0
			};
			foreach (Tileset tileset in spawnCheck.tilesets)
			{
				Tileset item = tileset;
				environmentSpawnObjectBuffer.onlySpawnsOnTilesets.Add(in item);
			}
			foreach (TileRequirement item3 in spawnCheck.adjacentTiles.list)
			{
				environmentSpawnObjectBuffer.adjacentTiles.Add(new TileRequirement
				{
					mustAlsoMatchTileset = item3.mustAlsoMatchTileset,
					tileset = item3.tileset,
					tileType = item3.tileType
				});
			}
			int num = 0;
			foreach (SpawnObjectData spawn in spawnObject.spawns)
			{
				if (PugDatabase.GetObjectInfo(spawn.objectID, spawn.variation.min) == null)
				{
					Debug.LogError($"Couldn't find object info for {spawn.objectID}");
				}
				else
				{
					num++;
				}
			}
			bool flag = true;
			foreach (SpawnObjectData spawn2 in spawnObject.spawns)
			{
				ObjectInfo objectInfo = PugDatabase.GetObjectInfo(spawn2.objectID, spawn2.variation.min);
				if (objectInfo == null)
				{
					continue;
				}
				if (objectInfo.tileType != TileType.none && spawn2.variation.min != spawn2.variation.max)
				{
					Debug.LogError($"tile env spawn doesn't take variation range into account ({spawn2.objectID})");
				}
				int amount = ((spawn2.amount == 0) ? objectInfo.initialAmount : spawn2.amount);
				EnvironmentSpawnObjectBuffer elementData = environmentSpawnObjectBuffer;
				if (flag)
				{
					elementData.alsoSpawnNextNObjectsFromSameBiome = num - 1;
					flag = false;
				}
				else
				{
					elementData.spawnChance = WorldGenSettingDependentValue<float>.FromConstant(0f);
				}
				list.Clear();
				if (spawn2.advancedVariationControl)
				{
					list.AddRange(spawn2.weightedVariations.value);
				}
				else
				{
					for (int i = spawn2.variation.min; i <= spawn2.variation.max; i++)
					{
						list.Add(new ValueWithWeight<int>(i, 1f));
					}
				}
				elementData.objectId = spawn2.objectID;
				elementData.variations = CreateVariationBlob(list);
				elementData.accumulatedVariationProbability = CreateNormalizedWeightsBlob(list);
				elementData.amount = amount;
				elementData.isTile = objectInfo.tileType != TileType.none;
				elementData.tileType = objectInfo.tileType;
				elementData.tileset = (Tileset)objectInfo.tileset;
				elementData.clusterSpawnChance = spawn2.clusterSpawnChance;
				elementData.spawnAlgorithm = ((spawn2.spawnType == EnvironmentSpawnType.Cluster) ? EnvironmentObjectSpawnAlgorithm.Cluster : EnvironmentObjectSpawnAlgorithm.Spot);
				elementData.clusterSpreadChance = spawn2.clusterSpreadChance;
				elementData.clusterSpreadType = (spawn2.clusterSpreadFourWayOnly ? ClusterSpreadType.FourWay : ClusterSpreadType.EightWay);
				AddToBuffer(elementData);
			}
		}
		foreach (RespawnData respawnObject in environmentSpawnObjectsTable.respawnObjects)
		{
			RespawnData.SpawnCheck spawnCheck2 = respawnObject.spawnCheck;
			EnvironmentSpawnObjectBuffer environmentSpawnObjectBuffer2 = new EnvironmentSpawnObjectBuffer
			{
				respawn = true,
				spawnChance = spawnCheck2.spawnChance.AsWorldGenSettingDependentValue(),
				spawnsInBiome = spawnCheck2.biome,
				maxSpawnPerTile = spawnCheck2.maxSpawnPerTile.GetValueForCurrentPlatform(),
				respawnChanceDecay = spawnCheck2.spawnChanceDecay,
				minTilesRequiredToRespawn = spawnCheck2.minTilesRequired,
				maxSpawnsPerRespawn = spawnCheck2.maxSpawnsPerRespawn,
				spawnsOnTileType = spawnCheck2.tileType,
				alsoSpawnNextNObjectsFromSameBiome = 0
			};
			foreach (Tileset tileset2 in spawnCheck2.tilesets)
			{
				Tileset item2 = tileset2;
				environmentSpawnObjectBuffer2.onlySpawnsOnTilesets.Add(in item2);
			}
			foreach (TileRequirement item4 in spawnCheck2.adjacentTiles.list)
			{
				environmentSpawnObjectBuffer2.adjacentTiles.Add(new TileRequirement
				{
					mustAlsoMatchTileset = item4.mustAlsoMatchTileset,
					tileset = item4.tileset,
					tileType = item4.tileType
				});
			}
			int num2 = 0;
			foreach (SpawnObjectData spawn3 in respawnObject.spawns)
			{
				if (PugDatabase.GetObjectInfo(spawn3.objectID, spawn3.variation.min) == null)
				{
					Debug.LogError($"Couldn't find object info for {spawn3.objectID}");
				}
				else
				{
					num2++;
				}
			}
			bool flag2 = true;
			foreach (SpawnObjectData spawn4 in respawnObject.spawns)
			{
				ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(spawn4.objectID, spawn4.variation.min);
				if (objectInfo2 == null)
				{
					continue;
				}
				if (objectInfo2.tileType != TileType.none && spawn4.variation.min != spawn4.variation.max)
				{
					Debug.LogError($"tile env spawn doesn't take variation range into account ({spawn4.objectID})");
				}
				int amount2 = ((spawn4.amount == 0) ? objectInfo2.initialAmount : spawn4.amount);
				EnvironmentSpawnObjectBuffer elementData2 = environmentSpawnObjectBuffer2;
				if (flag2)
				{
					elementData2.alsoSpawnNextNObjectsFromSameBiome = num2 - 1;
					flag2 = false;
				}
				else
				{
					elementData2.spawnChance = WorldGenSettingDependentValue<float>.FromConstant(0f);
				}
				list.Clear();
				if (spawn4.advancedVariationControl)
				{
					list.AddRange(spawn4.weightedVariations.value);
				}
				else
				{
					for (int j = spawn4.variation.min; j <= spawn4.variation.max; j++)
					{
						list.Add(new ValueWithWeight<int>(j, 1f));
					}
				}
				elementData2.objectId = spawn4.objectID;
				elementData2.variations = CreateVariationBlob(list);
				elementData2.accumulatedVariationProbability = CreateNormalizedWeightsBlob(list);
				elementData2.amount = amount2;
				elementData2.isTile = objectInfo2.tileType != TileType.none;
				elementData2.tileType = objectInfo2.tileType;
				elementData2.tileset = (Tileset)objectInfo2.tileset;
				elementData2.clusterSpawnChance = spawn4.clusterSpawnChance;
				elementData2.spawnAlgorithm = ((spawn4.spawnType == EnvironmentSpawnType.Cluster) ? EnvironmentObjectSpawnAlgorithm.Cluster : EnvironmentObjectSpawnAlgorithm.Spot);
				elementData2.clusterSpreadChance = spawn4.clusterSpreadChance;
				elementData2.clusterSpreadType = (spawn4.clusterSpreadFourWayOnly ? ClusterSpreadType.FourWay : ClusterSpreadType.EightWay);
				AddToBuffer(elementData2);
			}
		}
	}

	private BlobAssetReference<BlobArray<int>> CreateVariationBlob(List<ValueWithWeight<int>> variations)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, 1024);
		BlobBuilderArray<int> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<int>>(), variations.Count);
		for (int i = 0; i < variations.Count; i++)
		{
			blobBuilderArray[i] = variations[i].value;
		}
		BlobAssetReference<BlobArray<int>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<int>>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		return blobAsset;
	}

	private BlobAssetReference<BlobArray<float>> CreateNormalizedWeightsBlob(List<ValueWithWeight<int>> variations)
	{
		float num = 0f;
		foreach (ValueWithWeight<int> variation in variations)
		{
			num += variation.weight;
		}
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp, 1024);
		BlobBuilderArray<float> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<BlobArray<float>>(), variations.Count);
		float num2 = 0f;
		for (int i = 0; i < variations.Count; i++)
		{
			num2 += variations[i].weight / num;
			blobBuilderArray[i] = num2;
		}
		BlobAssetReference<BlobArray<float>> blobAsset = blobBuilder.CreateBlobAssetReference<BlobArray<float>>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		return blobAsset;
	}
}
