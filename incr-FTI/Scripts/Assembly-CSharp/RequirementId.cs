using System;

public readonly struct RequirementId : IEquatable<RequirementId>
{
	public readonly RequirementType type;

	public readonly EntityId entityId;

	public readonly double targetCount;

	public readonly bool isTargetingGlobalStat;

	public readonly int data;

	public static RequirementId None = new RequirementId(RequirementType.None, EntityId.None, 0.0, 0, global: false);

	public RequirementId(RequirementType t, EntityId id, double count, int extraData, bool global)
	{
		type = t;
		entityId = id.GetCopy();
		targetCount = count;
		isTargetingGlobalStat = global;
		data = extraData;
	}

	public RequirementId(RequirementType t, double count, bool global = false)
	{
		type = t;
		entityId = EntityId.None;
		targetCount = count;
		data = 0;
		isTargetingGlobalStat = global;
		if (t == RequirementType.TownLevel)
		{
			isTargetingGlobalStat = false;
		}
	}

	public RequirementId(SkillType skillType, EntityId id, int level)
	{
		type = RequirementType.SkillLevel;
		entityId = id.GetCopy();
		targetCount = level;
		isTargetingGlobalStat = false;
		data = (int)skillType;
	}

	public RequirementId(SkillType skillType, double targetXP)
	{
		type = RequirementType.SkillXP;
		entityId = EntityId.None;
		isTargetingGlobalStat = false;
		data = (int)skillType;
		targetCount = targetXP;
	}

	public RequirementId(SkillType skillType, int numSkills, int level)
	{
		if (skillType == SkillType.None)
		{
			type = RequirementType.SkillLevelCount;
			entityId = EntityId.None;
			targetCount = level;
			isTargetingGlobalStat = false;
			data = (int)skillType;
			data += numSkills * 100;
		}
		else
		{
			type = RequirementType.SkillXP;
			entityId = EntityId.None;
			isTargetingGlobalStat = false;
			data = (int)skillType;
			float initialValue = 100f;
			float growthRate = 0.3f;
			float growthAdditive = 100f;
			targetCount = GameUtility.AdditiveExponentGrowth(initialValue, level, growthRate, growthAdditive);
			targetCount *= numSkills;
			targetCount = GameUtility.TruncateToSignificantDigits(targetCount, 2);
		}
	}

	public RequirementId(BuildingType t, double count = 1.0)
	{
		type = RequirementType.MinBuildingCount;
		entityId = EntityId.FromBuilding(t);
		targetCount = count;
		isTargetingGlobalStat = false;
		data = 0;
	}

	public static RequirementId RequiredGlobalBuildingCount(BuildingType t, double count = 1.0)
	{
		EntityId id = EntityId.FromBuilding(t);
		return new RequirementId(RequirementType.MinBuildingCount, id, count, 0, global: true);
	}

	public RequirementId(MenuPanelType t, int level)
	{
		type = RequirementType.MinigameLevel;
		entityId = EntityId.FromMenuPanel(t);
		targetCount = level;
		isTargetingGlobalStat = true;
		data = 0;
	}

	public RequirementId(ResearchType t)
	{
		type = RequirementType.Research;
		entityId = EntityId.FromResearch(t);
		targetCount = 0.0;
		isTargetingGlobalStat = false;
		data = 0;
	}

	public RequirementId(UpgradeType t, int level, bool global = false)
	{
		type = RequirementType.Upgrade;
		entityId = EntityId.FromUpgrade(t);
		targetCount = level;
		isTargetingGlobalStat = global;
		data = 0;
	}

	public RequirementId(PerkType t, int level = 1)
	{
		type = RequirementType.Perk;
		entityId = EntityId.FromPerk(t);
		targetCount = level;
		isTargetingGlobalStat = Perk.IsGlobal(t);
		data = 0;
	}

	public RequirementId(ItemType t)
	{
		type = RequirementType.Item;
		entityId = EntityId.FromItem(t);
		targetCount = 0.0;
		isTargetingGlobalStat = true;
		data = 0;
	}

	public RequirementId(NaturalResource t)
	{
		type = RequirementType.NaturalResource;
		entityId = EntityId.FromNaturalResource(t);
		targetCount = 0.0;
		isTargetingGlobalStat = true;
		data = 0;
	}

	public RequirementId(HarvestRecipeType t)
	{
		type = RequirementType.HarvestRecipe;
		entityId = EntityId.FromHarvestRecipe(t);
		targetCount = 0.0;
		isTargetingGlobalStat = false;
		data = 0;
	}

	public RequirementId(BiomeType t)
	{
		type = RequirementType.Biome;
		entityId = EntityId.FromBiome(t);
		targetCount = 0.0;
		isTargetingGlobalStat = false;
		data = 0;
	}

	public RequirementId(QuestType t, bool global = false)
	{
		type = RequirementType.Quest;
		entityId = EntityId.FromQuest(t);
		targetCount = 0.0;
		isTargetingGlobalStat = true;
		data = 0;
	}

	public RequirementId(ItemType t, double count, bool global)
	{
		type = RequirementType.ProductionCount;
		entityId = EntityId.FromItem(t);
		targetCount = count;
		isTargetingGlobalStat = global;
		data = 0;
	}

	public static RequirementId BiomeTownLevel(BiomeType b, int requiredLevel)
	{
		return new RequirementId(RequirementType.TownLevel, EntityId.FromBiome(b), requiredLevel, 0, global: true);
	}

	public static RequirementId RequiredTownLevelGlobal(int requiredLevel, BiomeType specifiedBiome = BiomeType.None)
	{
		return new RequirementId(RequirementType.TownLevel, EntityId.FromBiome(specifiedBiome), requiredLevel, 0, global: true);
	}

	public static RequirementId RequiredTownLevelLocal(int requiredLevel)
	{
		return new RequirementId(RequirementType.TownLevel, EntityId.None, requiredLevel, 0, global: false);
	}

	public static RequirementId ResearchCount(int count, bool global)
	{
		return new RequirementId(RequirementType.MinResearchCount, EntityId.None, count, 0, global);
	}

	public static RequirementId ExcludeFromBiome(BiomeType t)
	{
		return new RequirementId(RequirementType.ExcludedBiome, EntityId.FromBiome(t), 0.0, 0, global: false);
	}

	public static RequirementId BuildingSkills(BuildingType t, int requiredTotalLevels)
	{
		return new RequirementId(RequirementType.BuildingSkills, EntityId.FromBuilding(t), requiredTotalLevels, 0, global: false);
	}

	public static RequirementId MarketSellCount(BuildingType t, double requiredCount)
	{
		return new RequirementId(RequirementType.MarketSellCount, EntityId.FromBuilding(t), requiredCount, 0, global: false);
	}

	public static RequirementId CoinSpendCount(ItemType t, double requiredCount)
	{
		return new RequirementId(RequirementType.CoinSpendCount, EntityId.FromItem(t), requiredCount, 0, global: false);
	}

	public static RequirementId FullGame()
	{
		return new RequirementId(RequirementType.FullGame, 0.0, global: true);
	}

	public static RequirementId RequiredPopulation(int count)
	{
		return new RequirementId(RequirementType.MinWorkerCount, EntityId.FromItem(ItemType.Worker), count, 0, global: false);
	}

	public override string ToString()
	{
		return "ReqId " + type.ToString() + " " + entityId.ToString() + " " + targetCount + " data " + data;
	}

	public bool Equals(RequirementId other)
	{
		if (type == other.type && entityId.Equals(other.entityId) && targetCount.Equals(other.targetCount) && data == other.data)
		{
			return isTargetingGlobalStat == other.isTargetingGlobalStat;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is RequirementId other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ((((((int)type * 397) ^ entityId.GetHashCode()) * 397) ^ targetCount.GetHashCode()) * 397) ^ isTargetingGlobalStat.GetHashCode();
	}
}
