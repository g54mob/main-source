using Pug.Conversion;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class CustomScenePostConverter : PostConverter
{
	public override bool CanRunInStagingWorld => false;

	public override void PostConvert(GameObject authoringObject)
	{
		if (!PostConverter.TryGetActiveComponent<CustomSceneAuthoring>(authoringObject, out var component))
		{
			return;
		}
		CustomScenesDataTable customScenesDataTable = component.CustomScenesDataTable;
		if (customScenesDataTable == null)
		{
			Debug.LogError("CustomScenesDataTable not set");
			return;
		}
		BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<CustomSceneBlob> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<CustomSceneTableBlob>().scenes, customScenesDataTable.scenes.Count);
		for (int i = 0; i < customScenesDataTable.scenes.Count; i++)
		{
			CustomScenesDataTable.Scene scene = customScenesDataTable.scenes[i];
			blobBuilderArray[i].sceneName = scene.sceneName;
			int num = 0;
			foreach (GameObject prefab in scene.prefabs)
			{
				if (!(prefab == null))
				{
					num++;
				}
			}
			BlobBuilderArray<Entity> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabs, num);
			BlobBuilderArray<float3> blobBuilderArray3 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabPositions, num);
			BlobBuilderArray<OptionalValue<float3>> blobBuilderArray4 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabDirections, num);
			BlobBuilderArray<OptionalValue<PaintableColor>> blobBuilderArray5 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabColors, num);
			BlobBuilderArray<InventoryOverrideData> blobBuilderArray6 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabInventoryOverrides, num);
			BlobBuilderArray<int2> blobBuilderArray7 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabSizes, num);
			BlobBuilderArray<int2> blobBuilderArray8 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabCornerOffsets, num);
			BlobBuilderArray<ObjectDataCD> blobBuilderArray9 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabObjectDatas, num);
			num = 0;
			foreach (GameObject prefab2 in scene.prefabs)
			{
				if (prefab2 == null)
				{
					continue;
				}
				blobBuilderArray2[num] = GetEntity(prefab2);
				blobBuilderArray3[num] = scene.prefabPositions[num];
				if (PostConverter.TryGetActiveComponent<EntityMonoBehaviourData>(prefab2, out var component2))
				{
					blobBuilderArray7[num] = component2.objectInfo.prefabTileSize.ToInt2();
					blobBuilderArray8[num] = component2.objectInfo.prefabCornerOffset.ToInt2();
					ObjectDataCD objectDataCD = new ObjectDataCD
					{
						objectID = component2.objectInfo.objectID,
						variation = component2.objectInfo.variation,
						amount = component2.objectInfo.initialAmount
					};
					blobBuilderArray9[num] = objectDataCD;
				}
				else
				{
					blobBuilderArray7[num] = 1;
					if (PostConverter.TryGetActiveComponent<PlaceableObjectAuthoring>(prefab2, out var component3))
					{
						blobBuilderArray7[num] = component3.prefabTileSize.ToInt2();
						blobBuilderArray8[num] = component3.prefabCornerOffset.ToInt2();
					}
				}
				if (scene.prefabDirections != null && scene.prefabDirections.Count != 0)
				{
					blobBuilderArray4[num] = scene.prefabDirections[num];
				}
				if (scene.prefabColors != null && scene.prefabColors.Count != 0)
				{
					blobBuilderArray5[num] = scene.prefabColors[num];
				}
				if (scene.prefabInventoryOverrides != null && scene.prefabInventoryOverrides.Count != 0)
				{
					CustomScenesDataTable.InventoryOverride inventoryOverride = scene.prefabInventoryOverrides[num];
					blobBuilderArray6[num].hasAnyInventoryOverride = inventoryOverride.hasAnyInventoryOverride;
					blobBuilderArray6[num].hasLootTableOverride = inventoryOverride.hasLootTableOverride;
					blobBuilderArray6[num].lootTableOverride = inventoryOverride.lootTableOverride;
					if (inventoryOverride.hasItemsOverride)
					{
						blobBuilderArray6[num].hasItemsOverride = true;
						blobBuilderArray6[num].itemsToRemove = inventoryOverride.itemsToRemove;
						BlobBuilderArray<InitialInventoryItem> blobBuilderArray10 = blobBuilder.Allocate(ref blobBuilderArray6[num].itemsOverride, inventoryOverride.itemsOverride.Count);
						for (int j = 0; j < blobBuilderArray10.Length; j++)
						{
							blobBuilderArray10[j] = inventoryOverride.itemsOverride[j];
						}
					}
				}
				num++;
			}
			int num2 = 0;
			foreach (CustomScenesDataTable.Map map in scene.maps)
			{
				using PugMapData.TileIterator tileIterator = map.mapData.GetTileIterator();
				while (tileIterator.MoveNext())
				{
					num2++;
				}
			}
			BlobBuilderArray<TileCD> blobBuilderArray11 = blobBuilder.Allocate(ref blobBuilderArray[i].tiles, num2);
			BlobBuilderArray<int2> blobBuilderArray12 = blobBuilder.Allocate(ref blobBuilderArray[i].tilePositions, num2);
			int2 int5 = int.MaxValue;
			int2 int6 = int.MinValue;
			num2 = 0;
			foreach (CustomScenesDataTable.Map map2 in scene.maps)
			{
				using PugMapData.TileIterator tileIterator2 = map2.mapData.GetTileIterator();
				while (tileIterator2.MoveNext())
				{
					TileInfo tileInfo = tileIterator2.CurrentTileData;
					blobBuilderArray11[num2] = new TileCD
					{
						tileset = tileInfo.tileset,
						tileType = tileInfo.tileType
					};
					blobBuilderArray12[num2] = tileIterator2.CurrentPosition.ToInt2() + map2.localPosition;
					int5 = math.min(int5, blobBuilderArray12[num2]);
					int6 = math.max(int6, blobBuilderArray12[num2]);
					num2++;
				}
			}
			if (scene.hasCenter)
			{
				blobBuilderArray[i].centerPosition = scene.center;
			}
			else if (scene.maps.Count > 0)
			{
				blobBuilderArray[i].centerPosition = (int2)math.round((float2)(int5 + int6) / 2f);
			}
			blobBuilderArray[i].canFlipX = scene.canFlipX;
			blobBuilderArray[i].canFlipY = scene.canFlipY;
			blobBuilderArray[i].maxOccurrences = scene.maxOccurrences;
			blobBuilderArray[i].replacedByContentBundle = (scene.replacedByContentBundle.TryGetValue(out var output) ? new OptionalValue<DataBlockAddress>(output) : default(OptionalValue<DataBlockAddress>));
			BlobBuilderArray<Biome> blobBuilderArray13 = blobBuilder.Allocate(ref blobBuilderArray[i].biomesToSpawnIn.classic, scene.biomesToSpawnIn.classic.Count);
			for (int k = 0; k < scene.biomesToSpawnIn.classic.Count; k++)
			{
				blobBuilderArray13[k] = scene.biomesToSpawnIn.classic[k];
			}
			BlobBuilderArray<Biome> blobBuilderArray14 = blobBuilder.Allocate(ref blobBuilderArray[i].biomesToSpawnIn.fullRelease, scene.biomesToSpawnIn.fullRelease.Count);
			for (int l = 0; l < scene.biomesToSpawnIn.fullRelease.Count; l++)
			{
				blobBuilderArray14[l] = scene.biomesToSpawnIn.fullRelease[l];
			}
			blobBuilderArray[i].minDistanceFromCoreInClassicWorlds = scene.minDistanceFromCoreInClassicWorlds;
			blobBuilderArray[i].hasCenter = scene.hasCenter;
			blobBuilderArray[i].boundsSize = scene.boundsSize;
			blobBuilderArray[i].radius = scene.radius;
		}
		BlobAssetReference<CustomSceneTableBlob> blobAsset = blobBuilder.CreateBlobAssetReference<CustomSceneTableBlob>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		base.EntityManager.AddComponentData(GetEntity(authoringObject), new CustomSceneTableCD
		{
			Value = blobAsset
		});
		blobBuilder.Dispose();
	}
}
