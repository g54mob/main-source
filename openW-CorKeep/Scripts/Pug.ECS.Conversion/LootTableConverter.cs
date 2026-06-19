using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

public class LootTableConverter : SingleAuthoringComponentConverter<LootTableAuthoring>
{
	protected override void Convert(LootTableAuthoring authoring)
	{
		using BlobBuilder blobBuilder = new BlobBuilder(Allocator.Temp);
		ref LootTableBankBlob reference = ref blobBuilder.ConstructRoot<LootTableBankBlob>();
		List<LootTable> list = ((!Application.isPlaying) ? authoring.lootTableBank.GetLootTables() : Manager.mod.LootTable);
		BlobBuilderArray<EntityLootTable> blobBuilderArray = blobBuilder.Allocate(ref reference.lootTables, list.Count);
		int num = 0;
		foreach (LootTable item in list)
		{
			blobBuilderArray[num].lootTableID = item.id;
			blobBuilderArray[num].minUniqueDrops = item.minUniqueDrops;
			blobBuilderArray[num].maxUniqueDrops = item.maxUniqueDrops;
			blobBuilderArray[num].dontAllowDuplicates = item.dontAllowDuplicates;
			BlobBuilderArray<EntityLootInfo> blobBuilderArray2 = blobBuilder.Allocate(ref blobBuilderArray[num].lootTable, item.lootInfos.Count);
			int num2 = 0;
			foreach (LootInfo lootInfo in item.lootInfos)
			{
				_ = lootInfo;
				blobBuilderArray2[num2].objectID = item.lootInfos[num2].objectID;
				blobBuilderArray2[num2].accumulatedDropChance = item.lootInfos[num2].accumulatedDropChance;
				blobBuilderArray2[num2].weight = item.lootInfos[num2].weight;
				blobBuilderArray2[num2].amount = item.lootInfos[num2].amount;
				blobBuilderArray2[num2].onlyDropsInBiome = item.lootInfos[num2].onlyDropsInBiome;
				num2++;
			}
			BlobBuilderArray<EntityLootInfo> blobBuilderArray3 = blobBuilder.Allocate(ref blobBuilderArray[num].guaranteedDropsLootTable, item.guaranteedLootInfos.Count);
			int num3 = 0;
			foreach (LootInfo guaranteedLootInfo in item.guaranteedLootInfos)
			{
				_ = guaranteedLootInfo;
				blobBuilderArray3[num3].objectID = item.guaranteedLootInfos[num3].objectID;
				blobBuilderArray3[num3].accumulatedDropChance = item.guaranteedLootInfos[num3].accumulatedDropChance;
				blobBuilderArray3[num3].weight = item.guaranteedLootInfos[num3].weight;
				blobBuilderArray3[num3].amount = item.guaranteedLootInfos[num3].amount;
				blobBuilderArray3[num3].onlyDropsInBiome = item.guaranteedLootInfos[num3].onlyDropsInBiome;
				num3++;
			}
			num++;
		}
		BlobAssetReference<LootTableBankBlob> blobAsset = blobBuilder.CreateBlobAssetReference<LootTableBankBlob>(Allocator.Persistent);
		base.BlobAssetStore.TryAdd(ref blobAsset);
		AddComponentData(new LootTableBankCD
		{
			Value = blobAsset
		});
	}

	[Conditional("UNITY_EDITOR")]
	private void EmitWarningIfMissingIDs(List<LootTable> lootTables)
	{
		HashSet<LootTableID> hashSet = new HashSet<LootTableID>();
		foreach (LootTable lootTable in lootTables)
		{
			hashSet.Add(lootTable.id);
		}
		foreach (LootTableID value in Enum.GetValues(typeof(LootTableID)))
		{
			if (!hashSet.Contains(value))
			{
				UnityEngine.Debug.LogWarning(string.Format("{0}: Missing loot table for ID {1}.", "LootTableConverter", value));
			}
		}
	}

	[Conditional("UNITY_EDITOR")]
	private void EmitWarningIfDuplicateIDs(List<LootTable> lootTables)
	{
		HashSet<LootTableID> hashSet = new HashSet<LootTableID>();
		foreach (LootTable lootTable in lootTables)
		{
			if (!hashSet.Add(lootTable.id))
			{
				UnityEngine.Debug.LogWarning(string.Format("{0}: Duplicate loot table ID found: {1}.", "LootTableConverter", lootTable.id));
			}
		}
	}
}
