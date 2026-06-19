using PugTilemap;
using Unity.Entities;

public struct FishingTableCD : IComponentData, IQueryTypeParameter
{
	public BlobAssetReference<FishingTableBlob> Value;

	public readonly void GetFishingStats(Tileset waterTileset, Biome biome, out FishingInfoData fishingInfo, out int skillNeeded)
	{
		fishingInfo = default(FishingInfoData);
		skillNeeded = 0;
		if (waterTileset == Tileset.Dirt)
		{
			fishingInfo = GetFishingInfoFromBiome(biome);
			skillNeeded = FishingTable.GetSkillRequiredForBiome(biome);
		}
		if (fishingInfo.lootTableID == LootTableID.Empty)
		{
			fishingInfo = GetFishingInfoFromWaterTileset(waterTileset);
			skillNeeded = FishingTable.GetSkillRequiredForWater(waterTileset);
		}
		if (fishingInfo.lootTableID == LootTableID.Empty)
		{
			fishingInfo = GetFishingInfoFromBiome(biome);
			skillNeeded = FishingTable.GetSkillRequiredForBiome(biome);
		}
	}

	private readonly FishingInfoData GetFishingInfoFromWaterTileset(Tileset tileset)
	{
		return Value.Value.fishingInfoByWaterTileset[(int)tileset];
	}

	private readonly FishingInfoData GetFishingInfoFromBiome(Biome biome)
	{
		return Value.Value.fishingInfoByBiome[(int)biome];
	}

	public readonly ref FishingStruggleInfoData GetFishStruggleInfo(ObjectID fishingLootToSpawn)
	{
		int num = 0;
		BlobAssetReference<FishingTableBlob> value;
		while (true)
		{
			int num2 = num;
			value = Value;
			if (num2 >= value.Value.fishingStruggleInfo.Length)
			{
				break;
			}
			value = Value;
			if (value.Value.fishingStruggleInfo[num].fishID == fishingLootToSpawn)
			{
				value = Value;
				return ref value.Value.fishingStruggleInfo[num];
			}
			num++;
		}
		value = Value;
		return ref value.Value.defaultFishingStruggleInfo;
	}
}
