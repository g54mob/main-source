public static class BuildingUtl
{
	private static readonly int[] kResourceValue;

	private static readonly string[] kResourceIcons;

	public static bool IsResource(this BuildingType rt)
	{
		return false;
	}

	public static ResourceType GetResourceType(this BuildingType t)
	{
		return default(ResourceType);
	}

	public static bool IsRoad(this BuildingType rt)
	{
		return false;
	}

	public static BaseTileType GetTgtTileType(this BuildingType bt)
	{
		return default(BaseTileType);
	}

	public static bool IsWorkstation(this BuildingType rt)
	{
		return false;
	}

	public static bool CanAim(this BuildingType rt)
	{
		return false;
	}

	public static bool IsBounceHarvester(this BuildingType rt)
	{
		return false;
	}

	public static bool IsIdleHarvester(this BuildingType rt)
	{
		return false;
	}

	public static ResourceType GetRegrowthBonusResource(this BuildingType rt)
	{
		return default(ResourceType);
	}

	public static bool IsRegrowthBonus(this BuildingType rt)
	{
		return false;
	}

	public static ResourceType GetWorkstationResource(this BuildingType rt)
	{
		return default(ResourceType);
	}

	public static BuildingType GetStorageTgt(this BuildingType bt)
	{
		return default(BuildingType);
	}

	public static BuildingType GetStorageTgt(this ResourceType rt)
	{
		return default(BuildingType);
	}

	public static BuildingType GetFertilizerTgt(this BuildingType bt)
	{
		return default(BuildingType);
	}

	public static bool IsFertilizer(this BuildingType bt)
	{
		return false;
	}

	public static bool ShouldDisplayRange(this BuildingType bt)
	{
		return false;
	}

	public static bool IsStorage(this BuildingType bt)
	{
		return false;
	}

	public static bool IsResourceHousing(this BuildingType bt)
	{
		return false;
	}

	public static bool IsBabyWorker(this BuildingType bt)
	{
		return false;
	}

	public static ResourceType GetStorageResource(this BuildingType bt)
	{
		return default(ResourceType);
	}

	public static ResourceType GetStoredResource(this BuildingType bt)
	{
		return default(ResourceType);
	}

	public static bool IsStarterBlueprint(this BuildingType t)
	{
		return false;
	}

	public static bool IsInfiniteUpgrade(this BuildingType t)
	{
		return false;
	}

	public static int GetBuyCost(this ResourceType rt)
	{
		return 0;
	}

	public static int GetSellCost(this ResourceType rt)
	{
		return 0;
	}

	public static string GetResourceTxt(this ResourceType rt, int amt)
	{
		return null;
	}

	public static string GetResourceIconTag(this ResourceType rt)
	{
		return null;
	}

	public static bool IsLevelCompletionBonus(this BuildingType bt)
	{
		return false;
	}

	public static LevelType GetTgtLvl(this BuildingType bt)
	{
		return default(LevelType);
	}

	public static BuildingType GetCompletionIdol(this LevelType lt)
	{
		return default(BuildingType);
	}

	public static BuildingType GetCompletionBld(this LevelType lt)
	{
		return default(BuildingType);
	}

	public static BuildingType GetNextLevelUnlockedBld(this LevelType lt)
	{
		return default(BuildingType);
	}

	public static StatPropType GetTrophyProp(this BuildingType bt)
	{
		return default(StatPropType);
	}

	public static int GetResourceCapacity(this BuildingType t, int lvl)
	{
		return 0;
	}

	public static int GetHarvestTime(this BuildingType t, int lvl)
	{
		return 0;
	}

	public static int GetHarvestLength(this BuildingType t, int lvl)
	{
		return 0;
	}

	public static int GetBabyWorkerBounceLimit(this BuildingType t, int lvl)
	{
		return 0;
	}

	public static BaseState GetTgtBaseUI(this BuildingType t)
	{
		return default(BaseState);
	}

	public static CharType GetHousingChar(this BuildingType t)
	{
		return default(CharType);
	}

	public static bool HasHousingUpgrade(this BuildingType t)
	{
		return false;
	}

	public static bool IsInRange(float startX, float startY, float range, BuildingInst tgtBld)
	{
		return false;
	}

	public static int GetNumGearsRequiredToUgpradeElevator(int lvl)
	{
		return 0;
	}

	public static StatType GetHousingUpgradeStat(this BuildingType t)
	{
		return default(StatType);
	}

	public static StatType GetStatScalingBonus(this BuildingType t)
	{
		return default(StatType);
	}
}
