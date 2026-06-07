using System.Collections.Generic;
using UnityEngine;

public class Perk
{
	public PerkType perkType;

	public bool isGlobal;

	public int maxLevel;

	public List<RequirementId> requirements;

	public int[] costArray;

	public float[] effectArray;

	public float growthValue;

	public GrowthRateType growthRateType;

	public Perk(PerkType t)
	{
		perkType = t;
		AddRequirements();
		ConfigureForType();
	}

	private float[] Linear(int numLevels, float multiplier)
	{
		float[] array = new float[numLevels];
		for (int i = 0; i < numLevels; i++)
		{
			int num = i + 1;
			array[i] = (float)num * multiplier;
		}
		return array;
	}

	private float[] LinearEffect(int numLevels, float multiplier)
	{
		float[] array = new float[numLevels];
		for (int i = 0; i < numLevels; i++)
		{
			int num = i + 1;
			array[i] = 1f + (float)num * multiplier;
		}
		return array;
	}

	private int[] MultiplicativeCost(int[] source, float multiplier)
	{
		int[] array = new int[source.Length];
		for (int i = 0; i < source.Length; i++)
		{
			array[i] = Mathf.RoundToInt((float)source[i] * multiplier);
		}
		return array;
	}

	private float[] MultiplicativeEffect(float[] source, float multiplier)
	{
		float[] array = new float[source.Length];
		for (int i = 0; i < source.Length; i++)
		{
			array[i] = 1f + source[i] * multiplier;
		}
		return array;
	}

	private void ConfigureForType()
	{
		isGlobal = IsGlobal(perkType);
		maxLevel = 1;
		growthValue = GrowthValueForPerk(perkType);
		growthRateType = GrowthTypeForPerk(perkType);
		switch (perkType)
		{
		case PerkType.ConstructionSpeed:
			costArray = new int[25]
			{
				2, 4, 6, 8, 10, 12, 15, 18, 22, 26,
				30, 35, 40, 45, 50, 55, 60, 65, 70, 75,
				80, 85, 90, 95, 100
			};
			effectArray = new float[25]
			{
				1.5f, 2f, 2.5f, 3f, 4.5f, 5f, 7f, 9f, 11f, 14f,
				16f, 21f, 26f, 31f, 41f, 51f, 61f, 71f, 81f, 91f,
				101f, 126f, 151f, 176f, 201f
			};
			break;
		case PerkType.ConstructionCost:
			costArray = new int[15]
			{
				2, 4, 6, 8, 10, 15, 20, 25, 30, 40,
				50, 60, 70, 85, 100
			};
			effectArray = Data.efficiencyPerkDecay15;
			break;
		case PerkType.KnowledgeSpeed:
			costArray = Data.costArrayTownPerks_2_150_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_1000_25, 0.5f);
			break;
		case PerkType.CultivationSpeed:
		case PerkType.ProspectingSpeed:
			costArray = new int[15]
			{
				2, 4, 6, 8, 10, 15, 20, 25, 30, 40,
				50, 60, 70, 85, 100
			};
			effectArray = new float[15]
			{
				1.2f, 1.4f, 1.6f, 1.8f, 2f, 2.5f, 3f, 3.5f, 4f, 5f,
				6f, 7f, 8f, 9.5f, 11f
			};
			break;
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
			costArray = new int[10] { 5, 6, 7, 8, 9, 10, 12, 14, 16, 20 };
			effectArray = new float[10] { 1.5f, 2.25f, 3.5f, 5.25f, 8f, 12f, 18f, 26f, 40f, 60f };
			break;
		case PerkType.GlobalMarketSpeed:
			costArray = new int[15]
			{
				2, 4, 6, 8, 10, 15, 20, 25, 30, 40,
				50, 60, 70, 85, 100
			};
			effectArray = new float[15]
			{
				1.2f, 1.4f, 1.6f, 1.8f, 2f, 2.5f, 3f, 3.5f, 4f, 5f,
				6f, 7f, 8f, 9.5f, 11f
			};
			break;
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
			costArray = new int[10] { 5, 6, 7, 8, 9, 10, 12, 14, 16, 20 };
			effectArray = new float[10] { 1.5f, 2.25f, 3.5f, 5.25f, 8f, 12f, 18f, 26f, 40f, 60f };
			break;
		case PerkType.TownTradingSpeed:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 0.25f);
			break;
		case PerkType.GlobalTradingSpeed:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 0.25f);
			break;
		case PerkType.StorageBoost:
			costArray = new int[10] { 4, 8, 12, 16, 20, 25, 30, 35, 40, 50 };
			effectArray = new float[10] { 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 4f, 6f, 8f, 10f };
			break;
		case PerkType.CraftingSpeed:
			costArray = new int[40]
			{
				2, 3, 4, 5, 6, 8, 10, 12, 14, 16,
				20, 24, 28, 32, 36, 44, 52, 60, 68, 76,
				92, 108, 124, 140, 156, 188, 220, 252, 284, 316,
				380, 444, 508, 572, 636, 764, 892, 1020, 1150, 1280
			};
			effectArray = MultiplicativeEffect(Data.effectArray_1_5000_40, 0.2f);
			break;
		case PerkType.HarvestingSpeed:
		{
			costArray = Data.costArrayTownPerks_2_150_25;
			float[] source3 = new float[25]
			{
				0.25f, 0.5f, 0.75f, 1f, 1.5f, 2f, 3f, 4f, 5f, 6f,
				10f, 15f, 20f, 25f, 30f, 40f, 50f, 60f, 70f, 80f,
				100f, 120f, 150f, 200f, 250f
			};
			effectArray = MultiplicativeEffect(source3, 1f);
			break;
		}
		case PerkType.ResearchSpeed:
			costArray = Data.costArrayTownPerks_2_150_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_1000_25, 0.1f);
			break;
		case PerkType.GlobalResearchSpeed:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_1000_25, 0.1f);
			break;
		case PerkType.LandCapacity:
			costArray = Data.costArray_2_100_25;
			effectArray = LinearEffect(25, 0.2f);
			break;
		case PerkType.MarketValue:
		{
			costArray = Data.costArrayTownPerks_2_150_25;
			float[] source2 = new float[25]
			{
				1f, 2f, 3f, 4f, 5f, 6f, 8f, 10f, 12f, 15f,
				20f, 25f, 30f, 35f, 40f, 50f, 60f, 70f, 80f, 90f,
				100f, 120f, 150f, 200f, 250f
			};
			effectArray = MultiplicativeEffect(source2, 0.1f);
			break;
		}
		case PerkType.IdleGain:
			costArray = new int[14]
			{
				2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
				12, 14, 17, 20
			};
			effectArray = Linear(14, 6f);
			break;
		case PerkType.ClickPower:
			costArray = Data.costArray_2_100_25;
			effectArray = MultiplicativeEffect(Data.effectArray_ClickPower, 1f);
			break;
		case PerkType.GlobalTradingCapacity:
			costArray = new int[15]
			{
				2, 4, 6, 8, 10, 12, 14, 16, 18, 20,
				22, 24, 26, 28, 30
			};
			effectArray = new float[15]
			{
				0.05f, 0.1f, 0.2f, 0.5f, 1f, 1.5f, 2f, 2.5f, 3f, 3.5f,
				4f, 5f, 6f, 8f, 10f
			};
			break;
		case PerkType.GlobalXPBoost:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 0.2f);
			break;
		case PerkType.TownXPBoost:
			costArray = Data.costArray_100_2000_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_100_25, 0.2f);
			break;
		case PerkType.MoreStartingLand:
			costArray = Data.costArrayTownPerks_2_150_25;
			effectArray = new float[25]
			{
				10f, 20f, 30f, 40f, 50f, 60f, 75f, 90f, 110f, 125f,
				150f, 175f, 200f, 225f, 250f, 300f, 350f, 400f, 450f, 500f,
				600f, 700f, 800f, 900f, 1000f
			};
			break;
		case PerkType.HousingCapacity:
			costArray = Data.costArray_5_300_25;
			effectArray = LinearEffect(25, 0.2f);
			break;
		case PerkType.GoodsConsumption:
		{
			costArray = Data.costArray_5_300_25;
			float[] source = new float[25]
			{
				1f, 2f, 3f, 4f, 5f, 10f, 15f, 20f, 25f, 30f,
				50f, 60f, 70f, 80f, 90f, 125f, 150f, 175f, 200f, 225f,
				300f, 350f, 400f, 450f, 500f
			};
			effectArray = MultiplicativeEffect(source, 0.25f);
			break;
		}
		case PerkType.TownOmnistoneDemand:
			costArray = MultiplicativeCost(Data.costArray_100_2000_25, 0.5f);
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 0.2f);
			break;
		case PerkType.RemoveBiomeNegatives:
			costArray = new int[5] { 50, 100, 150, 200, 250 };
			effectArray = new float[5] { 0.8f, 0.6f, 0.4f, 0.2f, 0f };
			break;
		case PerkType.ExtraQuestCoins:
			costArray = new int[15]
			{
				50, 60, 70, 80, 90, 100, 120, 140, 160, 180,
				200, 240, 280, 330, 400
			};
			effectArray = new float[15]
			{
				5f, 11f, 18f, 26f, 35f, 45f, 56f, 70f, 86f, 104f,
				125f, 149f, 177f, 210f, 250f
			};
			break;
		case PerkType.ResearchEfficiency:
			costArray = Data.costArray_5_100_15;
			effectArray = Data.efficiencyPerkDecay15;
			break;
		case PerkType.UpgradeEfficiency:
			costArray = Data.costArray_5_100_15;
			effectArray = Data.efficiencyPerkDecay15;
			break;
		case PerkType.ConstructionEfficiency:
			costArray = new int[10] { 5, 10, 20, 30, 50, 80, 120, 175, 250, 350 };
			effectArray = new float[10] { 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.3f, 0.2f, 0.1f, 0f };
			break;
		case PerkType.SkillGainSpeed:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_1000_25, 0.2f);
			break;
		case PerkType.ResourceRegen:
			costArray = Data.costArray_5_300_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 1f);
			break;
		case PerkType.NaturalResourceCapacity:
			costArray = Data.costArray_2_100_25;
			effectArray = MultiplicativeEffect(Data.effectArray_1_500_25, 0.5f);
			break;
		case PerkType.Specialization:
			costArray = new int[1] { 4 };
			break;
		case PerkType.SpecializationCount:
			costArray = new int[9] { 5, 7, 10, 13, 17, 22, 28, 34, 40 };
			effectArray = new float[9] { 1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f };
			break;
		case PerkType.SpecializationValue:
			costArray = new int[16]
			{
				2, 4, 6, 8, 10, 12, 14, 16, 18, 20,
				24, 28, 32, 38, 44, 50
			};
			effectArray = new float[16]
			{
				3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 11f, 12f,
				13f, 14f, 15f, 16f, 18f, 20f
			};
			break;
		case PerkType.SpecializationDemand:
			costArray = Data.costArray_2_100_25;
			effectArray = Data.effectArray_1_500_25;
			break;
		}
		if (costArray != null)
		{
			maxLevel = costArray.Length;
		}
		if (effectArray != null)
		{
			int num = effectArray.Length;
			if (costArray != null)
			{
				_ = costArray.Length;
			}
			maxLevel = num;
		}
	}

	private void AddRequirements()
	{
		switch (perkType)
		{
		case PerkType.Specialization:
			AddRequirement(new RequirementId(QuestType.GeneralStoreForMarketPanel));
			break;
		case PerkType.SpecializationCount:
		case PerkType.SpecializationValue:
		case PerkType.SpecializationDemand:
			AddRequirement(new RequirementId(PerkType.Specialization));
			break;
		case PerkType.StorageBoost:
			AddRequirement(RequirementId.RequiredTownLevelLocal(10));
			break;
		case PerkType.ExtraQuestCoins:
			AddRequirement(RequirementId.RequiredTownLevelLocal(20));
			break;
		case PerkType.RemoveBiomeNegatives:
			AddRequirement(RequirementId.RequiredTownLevelLocal(30));
			break;
		case PerkType.TownXPBoost:
			AddRequirement(RequirementId.RequiredTownLevelLocal(40));
			break;
		case PerkType.TownOmnistoneDemand:
			AddRequirement(new RequirementId(BuildingType.ManaReactor));
			break;
		case PerkType.ConstructionEfficiency:
			AddRequirement(new RequirementId(QuestType.MilestoneAnyTownLevel40));
			break;
		case PerkType.CultivationSpeed:
			AddRequirement(new RequirementId(QuestType.MilestoneBuildFarm));
			break;
		case PerkType.ProspectingSpeed:
			AddRequirement(new RequirementId(QuestType.QuarryForProspectingPanel));
			break;
		case PerkType.ResearchEfficiency:
			AddRequirement(new RequirementId(QuestType.SchoolForResearchPanel));
			break;
		case PerkType.ResearchSpeed:
		case PerkType.GlobalResearchSpeed:
			AddRequirement(new RequirementId(QuestType.SchoolForResearchPanel));
			break;
		case PerkType.UpgradeEfficiency:
			AddRequirement(new RequirementId(QuestType.ResearchForUpgrades));
			break;
		case PerkType.GourmetFoodsDemand:
		case PerkType.GourmetFoodsStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Plains));
			AddRequirement(new RequirementId(ResearchType.GourmetKitchen));
			break;
		case PerkType.BooksDemand:
		case PerkType.BookStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Forest));
			AddRequirement(new RequirementId(BuildingType.Bookstore));
			break;
		case PerkType.ConstructionDemand:
		case PerkType.ConstructionStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.River));
			AddRequirement(new RequirementId(BuildingType.GeneralGoods));
			break;
		case PerkType.HardwareDemand:
		case PerkType.HardwareStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Mountains));
			AddRequirement(new RequirementId(BuildingType.HardwareStore));
			break;
		case PerkType.JewelryDemand:
		case PerkType.JewelryStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Desert));
			AddRequirement(new RequirementId(BuildingType.JewelryStore));
			break;
		case PerkType.ClothingDemand:
		case PerkType.ClothingStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Snow));
			AddRequirement(new RequirementId(BuildingType.ClothingStore));
			break;
		case PerkType.MedicineDemand:
		case PerkType.MedicineStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Jungle));
			AddRequirement(new RequirementId(BuildingType.Apothecary));
			break;
		case PerkType.MagicDemand:
		case PerkType.MagicStoreSpeed:
			AddRequirement(new RequirementId(BiomeType.Magic));
			AddRequirement(new RequirementId(BuildingType.ArcaneStore));
			break;
		case PerkType.TownTradingSpeed:
			AddRequirement(new RequirementId(BuildingType.TradingPost));
			break;
		case PerkType.KnowledgeSpeed:
			AddRequirement(new RequirementId(BuildingType.GeneralLab));
			break;
		case PerkType.GlobalTradingSpeed:
		case PerkType.GlobalTradingCapacity:
			AddRequirement(new RequirementId(QuestType.TradingPostForTradingPanel));
			break;
		case PerkType.GoodsConsumption:
		case (PerkType)7:
		case (PerkType)8:
		case PerkType.HousingCapacity:
		case PerkType.MarketValue:
		case PerkType.ConstructionCost:
		case PerkType.ConstructionSpeed:
		case (PerkType)14:
		case (PerkType)15:
		case PerkType.FarmingMinigame:
		case PerkType.MiningMinigame:
		case PerkType.WaterMinigame:
		case PerkType.ResearchMinigame:
		case PerkType.DiceMinigame:
		case PerkType.WoodMinigame:
		case PerkType.MinigameXPGainSpeed:
		case PerkType.GlobalXPBoost:
		case (PerkType)26:
		case PerkType.MoreStartingLand:
		case PerkType.LandCapacity:
		case PerkType.ResourceRegen:
		case PerkType.ClickPower:
		case PerkType.IdleGain:
		case PerkType.HarvestingSpeed:
		case PerkType.GlobalMarketSpeed:
			break;
		}
	}

	public void AddRequirement(RequirementId id)
	{
		if (requirements == null)
		{
			requirements = new List<RequirementId>();
		}
		requirements.Add(id);
	}

	public static bool IsPrestigePerk(PerkType t)
	{
		return !IsGlobal(t);
	}

	public static bool IsGlobal(PerkType t)
	{
		switch (t)
		{
		case PerkType.SkillGainSpeed:
		case PerkType.NaturalResourceCapacity:
		case PerkType.ResearchEfficiency:
		case PerkType.GoodsConsumption:
		case PerkType.HousingCapacity:
		case PerkType.FarmingMinigame:
		case PerkType.MiningMinigame:
		case PerkType.WaterMinigame:
		case PerkType.ResearchMinigame:
		case PerkType.DiceMinigame:
		case PerkType.WoodMinigame:
		case PerkType.MinigameXPGainSpeed:
		case PerkType.GlobalXPBoost:
		case PerkType.UpgradeEfficiency:
		case PerkType.MoreStartingLand:
		case PerkType.ResourceRegen:
		case PerkType.ConstructionEfficiency:
		case PerkType.ClickPower:
		case PerkType.IdleGain:
		case PerkType.SpecializationCount:
		case PerkType.SpecializationValue:
		case PerkType.Specialization:
		case PerkType.SpecializationDemand:
		case PerkType.GlobalMarketSpeed:
		case PerkType.GlobalTradingSpeed:
		case PerkType.GlobalResearchSpeed:
		case PerkType.GlobalTradingCapacity:
			return true;
		case PerkType.CraftingSpeed:
		case PerkType.ResearchSpeed:
		case PerkType.CultivationSpeed:
		case PerkType.MarketValue:
		case PerkType.ConstructionCost:
		case PerkType.ConstructionSpeed:
		case PerkType.ProspectingSpeed:
		case PerkType.LandCapacity:
		case PerkType.HarvestingSpeed:
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
		case PerkType.TownTradingSpeed:
		case PerkType.TownXPBoost:
		case PerkType.TownOmnistoneDemand:
		case PerkType.RemoveBiomeNegatives:
		case PerkType.ExtraQuestCoins:
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
		case PerkType.KnowledgeSpeed:
		case PerkType.StorageBoost:
			return false;
		default:
			return false;
		}
	}

	public static bool IsMega(PerkType t)
	{
		return t >= PerkType.MegaTownLevelCost;
	}

	public static float GrowthValueForPerk(PerkType t)
	{
		return t switch
		{
			PerkType.SpecializationCount => 1f, 
			PerkType.SpecializationValue => 0.5f, 
			PerkType.SpecializationDemand => 1f, 
			PerkType.SkillGainSpeed => 0.2f, 
			PerkType.LandCapacity => 0.2f, 
			PerkType.MinigameXPGainSpeed => 0.5f, 
			PerkType.CraftingSpeed => 0.2f, 
			PerkType.ResearchSpeed => 0.5f, 
			PerkType.ResearchEfficiency => -0.1f, 
			PerkType.GoodsConsumption => 0.2f, 
			PerkType.HarvestingSpeed => 0.5f, 
			PerkType.HousingCapacity => 0.2f, 
			PerkType.ClickPower => 0.5f, 
			PerkType.IdleGain => 6f, 
			PerkType.MarketValue => 0.1f, 
			PerkType.GlobalXPBoost => 0.2f, 
			PerkType.TownXPBoost => 0.2f, 
			PerkType.NaturalResourceCapacity => 0.5f, 
			PerkType.ResourceRegen => 0.25f, 
			PerkType.ConstructionCost => -0.1f, 
			PerkType.UpgradeEfficiency => -0.1f, 
			PerkType.ConstructionSpeed => 0.5f, 
			PerkType.MoreStartingLand => 10f, 
			_ => 0f, 
		};
	}

	public static GrowthRateType GrowthTypeForPerk(PerkType t)
	{
		switch (t)
		{
		case PerkType.MoreStartingLand:
		case PerkType.IdleGain:
		case PerkType.SpecializationCount:
		case PerkType.SpecializationDemand:
		case PerkType.ExtraQuestCoins:
		case PerkType.StorageBoost:
		case PerkType.GlobalTradingCapacity:
			return GrowthRateType.Linear;
		case PerkType.GoodsConsumption:
		case PerkType.LandCapacity:
		case PerkType.ConstructionEfficiency:
		case PerkType.SpecializationValue:
		case PerkType.GourmetFoodsDemand:
		case PerkType.BooksDemand:
		case PerkType.ConstructionDemand:
		case PerkType.HardwareDemand:
		case PerkType.JewelryDemand:
		case PerkType.ClothingDemand:
		case PerkType.MedicineDemand:
		case PerkType.MagicDemand:
		case PerkType.TownOmnistoneDemand:
		case PerkType.GourmetFoodsStoreSpeed:
		case PerkType.BookStoreSpeed:
		case PerkType.ConstructionStoreSpeed:
		case PerkType.HardwareStoreSpeed:
		case PerkType.JewelryStoreSpeed:
		case PerkType.ClothingStoreSpeed:
		case PerkType.MedicineStoreSpeed:
		case PerkType.MagicStoreSpeed:
			return GrowthRateType.Multiplicative;
		case PerkType.CraftingSpeed:
		case PerkType.ResearchSpeed:
		case PerkType.HarvestingSpeed:
		case PerkType.GlobalResearchSpeed:
			return GrowthRateType.Custom;
		case PerkType.MarketValue:
		case PerkType.ConstructionSpeed:
			return GrowthRateType.Exponential;
		default:
			return GrowthRateType.Exponential;
		}
	}
}
