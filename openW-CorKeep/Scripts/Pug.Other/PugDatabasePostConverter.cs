using System.Collections.Generic;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class PugDatabasePostConverter : PostConverter
{
	public override bool CanRunInStagingWorld => false;

	public override void PostConvert(GameObject authoring)
	{
		if (!authoring.TryGetComponent<PugDatabaseAuthoring>(out var component))
		{
			return;
		}
		List<DatabaseConversionUtility.PrefabData> prefabList = DatabaseConversionUtility.GetPrefabList(component);
		if (prefabList.Count == 0)
		{
			return;
		}
		List<PugDatabase.EntityPrefabInfo> list = new List<PugDatabase.EntityPrefabInfo>();
		foreach (DatabaseConversionUtility.PrefabData item in prefabList)
		{
			foreach (PrefabInfo prefabInfo in item.ObjectInfo.prefabInfos)
			{
				if (prefabInfo != null && !(prefabInfo.ecsPrefab == null))
				{
					Entity entity = GetEntity(prefabInfo.ecsPrefab);
					IEntityMonoBehaviourData component2 = prefabInfo.ecsPrefab.GetComponent<IEntityMonoBehaviourData>();
					if (component2 != null)
					{
						ObjectInfo objectInfo = component2.ObjectInfo;
						ObjectDataCD objectDataCD = new ObjectDataCD
						{
							objectID = objectInfo.objectID,
							amount = objectInfo.initialAmount,
							variation = objectInfo.variation
						};
						list.Add(new PugDatabase.EntityPrefabInfo
						{
							entity = entity,
							objectID = objectDataCD.objectID,
							variation = objectDataCD.variation
						});
					}
				}
			}
		}
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		BlobBuilderArray<PugDatabase.EntityObjectInfo> blobBuilderArray = blobBuilder.Allocate(ref blobBuilder.ConstructRoot<PugDatabase.PugDatabaseBank>().objectInfos, prefabList.Count + 1);
		blobBuilderArray[0].objectID = ObjectID.None;
		blobBuilder.Allocate(ref blobBuilderArray[0].requiredObjectsToCraft, 0);
		blobBuilder.Allocate(ref blobBuilderArray[0].prefabEntities, 0);
		for (int i = 1; i < prefabList.Count + 1; i++)
		{
			ObjectInfo objectInfo2 = prefabList[i - 1].ObjectInfo;
			blobBuilderArray[i].objectID = objectInfo2.objectID;
			blobBuilderArray[i].objectType = objectInfo2.objectType;
			blobBuilderArray[i].initialAmount = objectInfo2.initialAmount;
			blobBuilderArray[i].variation = objectInfo2.variation;
			blobBuilderArray[i].variationIsDynamic = objectInfo2.variationIsDynamic;
			blobBuilderArray[i].variationToToggleTo = objectInfo2.variationToToggleTo;
			blobBuilderArray[i].rarity = objectInfo2.rarity;
			blobBuilderArray[i].sellValue = objectInfo2.sellValue;
			blobBuilderArray[i].buyValueMultiplier = objectInfo2.buyValueMultiplier;
			blobBuilderArray[i].CraftingSettings = objectInfo2.craftingSettings;
			blobBuilderArray[i].craftingTime = objectInfo2.craftingTime;
			blobBuilderArray[i].isStackable = objectInfo2.isStackable;
			blobBuilderArray[i].prefabTileSize = new int2(objectInfo2.prefabTileSize.x, objectInfo2.prefabTileSize.y);
			blobBuilderArray[i].prefabCornerOffset = new int2(objectInfo2.prefabCornerOffset.x, objectInfo2.prefabCornerOffset.y);
			blobBuilderArray[i].centerIsAtEntityPosition = objectInfo2.centerIsAtEntityPosition;
			blobBuilderArray[i].tileset = objectInfo2.tileset;
			blobBuilderArray[i].tileType = objectInfo2.tileType;
			blobBuilderArray[i].salvageMultiplier = objectInfo2.salvageMultiplier;
			BlobBuilderArray<ObjectWithAmount> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[i].requiredObjectsToCraft, objectInfo2.requiredObjectsToCraft.Count);
			for (int j = 0; j < objectInfo2.requiredObjectsToCraft.Count; j++)
			{
				blobBuilderArray2[j].objectID = objectInfo2.requiredObjectsToCraft[j].objectID;
				blobBuilderArray2[j].amount = objectInfo2.requiredObjectsToCraft[j].amount;
			}
			int num = 0;
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].objectID == objectInfo2.objectID && list[k].variation == objectInfo2.variation)
				{
					num++;
				}
			}
			if (num == 0)
			{
				Debug.LogError($"no entity prefabs for {objectInfo2.objectID}, make sure it doesnt have IsCustomScenePrefab marked");
				continue;
			}
			int num2 = 0;
			BlobBuilderArray<Entity> blobBuilderArray3 = blobBuilder.Allocate(ref blobBuilderArray[i].prefabEntities, num);
			for (int l = 0; l < list.Count; l++)
			{
				if (list[l].objectID == objectInfo2.objectID && list[l].variation == objectInfo2.variation)
				{
					blobBuilderArray3[num2++] = list[l].entity;
				}
			}
		}
		BlobAssetReference<PugDatabase.PugDatabaseBank> blobAsset = blobBuilder.CreateBlobAssetReference<PugDatabase.PugDatabaseBank>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		base.EntityManager.AddComponentData(GetEntity(authoring), new PugDatabase.DatabaseBankCD
		{
			databaseBankBlob = blobAsset
		});
		Debug.Log($"PugDatabase initialized {list.Count} prefabs");
	}
}
