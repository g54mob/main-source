using System.Collections.Generic;
using Pug.Conversion;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class FishingTableConverter : SingleAuthoringComponentConverter<FishingTableAuthoring>
{
	protected override void Convert(FishingTableAuthoring authoring)
	{
		if (Application.isPlaying)
		{
			FishingTable fishingTable = Manager.mod.FishingTable;
			BlobAssetReference<FishingTableBlob> blobAsset = CreateBlob(fishingTable);
			base.BlobAssetStore.TryAdd(ref blobAsset);
			AddComponentData(new FishingTableCD
			{
				Value = blobAsset
			});
		}
	}

	private BlobAssetReference<FishingTableBlob> CreateBlob(FishingTable fishingTable)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		ref FishingTableBlob reference = ref blobBuilder.ConstructRoot<FishingTableBlob>();
		BlobBuilderArray<FishingInfoData> blobBuilderArray = blobBuilder.Allocate(ref reference.fishingInfoByBiome, 12);
		foreach (KeyValuePair<Biome, FishingTable.FishingInfo> item in fishingTable.fishingInfoByBiome)
		{
			blobBuilderArray[(int)item.Key] = new FishingInfoData
			{
				lootTableID = item.Value.lootTableID,
				fishLootTableID = item.Value.fishLootTableID
			};
		}
		BlobBuilderArray<FishingInfoData> blobBuilderArray2 = blobBuilder.Allocate(ref reference.fishingInfoByWaterTileset, 75);
		foreach (KeyValuePair<Tileset, FishingTable.FishingInfo> item2 in fishingTable.fishingInfoByWaterTileset)
		{
			blobBuilderArray2[(int)item2.Key] = new FishingInfoData
			{
				lootTableID = item2.Value.lootTableID,
				fishLootTableID = item2.Value.fishLootTableID
			};
		}
		BlobBuilderArray<FishingStruggleInfoData> blobBuilderArray3 = blobBuilder.Allocate(ref reference.fishingStruggleInfo, fishingTable.fishStruggleInfos.Count);
		for (int i = 0; i < fishingTable.fishStruggleInfos.Count; i++)
		{
			FishingTable.FishStruggleInfo struggleInfo = fishingTable.fishStruggleInfos[i];
			CreateBlobForStruggleInfo(ref blobBuilderArray3[i], struggleInfo, blobBuilder);
		}
		CreateBlobForStruggleInfo(ref reference.defaultFishingStruggleInfo, fishingTable.defaultFishingStruggleInfo, blobBuilder);
		return blobBuilder.CreateBlobAssetReference<FishingTableBlob>(Allocator.Persistent);
	}

	private void CreateBlobForStruggleInfo(ref FishingStruggleInfoData fishingStruggleInfoData, FishingTable.FishStruggleInfo struggleInfo, BlobBuilder blobBuilder)
	{
		fishingStruggleInfoData = new FishingStruggleInfoData
		{
			fishID = struggleInfo.fishID,
			difficultyRatio = struggleInfo.difficultyRatio
		};
		BlobBuilderArray<FishingTable.FishStruggleData> blobBuilderArray = blobBuilder.Allocate(ref fishingStruggleInfoData.struggleData, struggleInfo.struggleData.Count);
		for (int i = 0; i < struggleInfo.struggleData.Count; i++)
		{
			blobBuilderArray[i] = new FishingTable.FishStruggleData
			{
				time = struggleInfo.struggleData[i].time,
				isStruggling = struggleInfo.struggleData[i].isStruggling
			};
		}
	}
}
