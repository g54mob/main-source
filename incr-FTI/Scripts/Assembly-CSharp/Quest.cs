using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public class Quest
{
	public QuestType type;

	public QuestDef def;

	public RequirementGroup completionRequirement = new RequirementGroup();

	public RequirementGroup displayRequirement = new RequirementGroup();

	public ItemList rewardItems;

	public BuildObjectAvailability availability;

	public static int DynamicQuestIdOffset = 10000;

	public static int DynamicQuestLevelOffset = 100;

	private const int idOffsetMinigameWood = 0;

	private const int idOffsetMinigameMining = 1;

	private const int idOffsetMinigameFarming = 2;

	private const int idOffsetMinigameWater = 3;

	private const int idOffsetMinigameDice = 4;

	private const int idOffsetMinigameResearch = 5;

	private string overrideLocalizationKey;

	private Sprite overrideImage;

	public float layoutHeight;

	public bool cachedReadyToClaimFlag;

	public bool hasTriggeredNotification;

	public static QuestType ResourceUnlockQuestRock = QuestType.MilestoneTownLevel2;

	public static QuestType ResourceUnlockQuestWater = QuestType.MilestoneTownLevel3;

	public static QuestType ResourceUnlockQuestGrain = QuestType.MilestoneTownLevel4;

	public static QuestType ResourceUnlockQuestApples = QuestType.MilestoneTownLevel5;

	public static QuestType ResourceUnlockQuestCotton = QuestType.MilestoneTownLevel6;

	public static QuestType UnlockPrioritization = QuestType.MilestoneTownLevel7;

	public static QuestType ResourceUnlockQuestIron = QuestType.MilestoneTownLevel8;

	public static QuestType ResourceUnlockQuestCoal = QuestType.MilestoneTownLevel9;

	public static QuestType UnlockAutoBalance = QuestType.MilestoneTownLevel10;

	public static QuestType ResourceUnlockQuestCopper = QuestType.MilestoneTownLevel11;

	public static QuestType ResourceUnlockQuestSilver = QuestType.MilestoneTownLevel12;

	public static QuestType ResourceUnlockQuestGold = QuestType.MilestoneTownLevel14;

	public static QuestType UnlockWorldPanel = QuestType.MilestoneTownLevel15;

	public static QuestType ResourceUnlockQuestRuby = QuestType.MilestoneDesertLevel10;

	public static QuestType ResourceUnlockQuestSapphire = QuestType.MilestoneSnowLevel10;

	public static QuestType ResourceUnlockQuestAmethyst = QuestType.MilestoneJungleLevel10;

	public static QuestType ResourceUnlockQuestTopaz = QuestType.MilestoneMountainLevel10;

	public static QuestType SearchHeaderUnlockQuest = QuestType.GeneralStoreForMarketPanel;

	public static QuestType FrequentProgressUpdates = QuestType.GeneralStoreForMarketPanel;

	public static QuestType DisplayCategoryHeaders = QuestType.MilestoneTownLevel6;

	public static QuestType UnlockPause = QuestType.MilestoneTownLevel2;

	public static QuestType UnlockProductionLimits = QuestType.MilestoneTownLevel3;

	public static int NumWorkersToAssign = 6;

	private Town parentTown;

	public QuestGroup questGroup => def.questGroup;

	public Quest(QuestDef questDef, Town town)
	{
		def = questDef;
		type = questDef.type;
		parentTown = town;
		if (def.rewardItems != null && def.rewardItems.items.Count > 0)
		{
			if (rewardItems == null)
			{
				rewardItems = new ItemList();
			}
			rewardItems.AddList(def.rewardItems);
		}
	}

	public string GetLabel()
	{
		if (overrideLocalizationKey != null)
		{
			return overrideLocalizationKey.Localized();
		}
		using (List<EntityLevel>.Enumerator enumerator = def.derivedRewards.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				EntityLevel current = enumerator.Current;
				if (current.entityId.type == EntityType.Quest)
				{
					return TextDisplay.LabelForQuest(type);
				}
				_ = current.entityId.type;
				_ = 14;
				return TextDisplay.LabelForEntity(current.entityId);
			}
		}
		return "Empty".Localized();
	}

	public Sprite GetSprite()
	{
		if (null != overrideImage)
		{
			return overrideImage;
		}
		if (def.isPermanentResearchUnlock)
		{
			return IconManager.Instance.research;
		}
		EntityLevel entityLevel = GameUtility.PrimaryReward(def.derivedRewards);
		if (entityLevel.entityId.type != EntityType.None)
		{
			return IconManager.SpriteForEntity(entityLevel.entityId);
		}
		return null;
	}

	public static QuestType DynamicQuestTypeFor(QuestCategory category, int idOffset, int level = 0)
	{
		int num = (int)category * DynamicQuestIdOffset;
		int num2 = level * DynamicQuestLevelOffset;
		return (QuestType)(num + num2 + idOffset);
	}

	public static List<QuestDef> DynamicTownQuestsFromCategory(QuestCategory category)
	{
		List<QuestDef> list = new List<QuestDef>();
		return category switch
		{
			_ => list, 
		};
	}

	private static void LoadMinigameUpgradeWithQuests(UpgradeType upgradeType, QuestCategory questCategory, int idOffset)
	{
		if (Crafting.upgradeCache.TryGetValue(upgradeType, out var value))
		{
			for (int i = 0; i < value.levels.Count; i++)
			{
				UpgradeLevelDef upgradeLevelDef = value.levels[i];
				QuestType t = DynamicQuestTypeFor(questCategory, idOffset, i);
				upgradeLevelDef.AddRequirement(new RequirementId(t));
			}
		}
		else
		{
			Debug.LogError("Did not find cached upgrade for " + upgradeType.ToString() + " " + questCategory);
		}
	}

	public void SetAsComplete()
	{
		availability = BuildObjectAvailability.Completed;
		CalcRequirementActivity();
	}

	public void CalcRequirementActivity()
	{
		bool isActive = availability == BuildObjectAvailability.Available;
		foreach (Requirement requirement in completionRequirement.requirements)
		{
			if (requirement is RequiredProductionCountInstanced requiredProductionCountInstanced)
			{
				requiredProductionCountInstanced.isActive = isActive;
			}
		}
	}

	public void Reset()
	{
		availability = BuildObjectAvailability.Locked;
		displayRequirement.Reset();
		completionRequirement.Reset();
		cachedReadyToClaimFlag = false;
		hasTriggeredNotification = false;
	}

	public Dictionary<string, fsData> GetData()
	{
		List<fsData> list = null;
		if (list != null)
		{
			return new Dictionary<string, fsData>
			{
				["type"] = new fsData((long)type),
				["value"] = new fsData(list)
			};
		}
		return null;
	}

	public bool IsActivelyPromptingForHarvesterHut()
	{
		if (availability != BuildObjectAvailability.Available)
		{
			return false;
		}
		if (type == QuestType.AssignWorkersForGeneralStore && GameManager.Instance.activeTown.harvesting.TryGetValue(HarvestRecipeType.Tree, out var value) && value.numWorkersAssigned < (float)NumWorkersToAssign && value.producingBuilding.numAvailable > 0.0)
		{
			return false;
		}
		foreach (Requirement requirement in completionRequirement.requirements)
		{
			if (requirement is RequiredMinBuildingCount { buildingType: BuildingType.HarvesterHut } requiredMinBuildingCount && !requiredMinBuildingCount.IsMet())
			{
				return true;
			}
		}
		return false;
	}

	public bool IsActivelyPromptingForHouse()
	{
		if (availability != BuildObjectAvailability.Available)
		{
			return false;
		}
		foreach (Requirement requirement in completionRequirement.requirements)
		{
			if (requirement is RequiredMinBuildingCount { buildingType: BuildingType.House } requiredMinBuildingCount && !requiredMinBuildingCount.IsMet())
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		return "Quest " + type;
	}

	public bool IsReadyToClaim()
	{
		if (availability != BuildObjectAvailability.Available || completionRequirement == null)
		{
			cachedReadyToClaimFlag = false;
		}
		else if (!cachedReadyToClaimFlag && completionRequirement.IsMet())
		{
			cachedReadyToClaimFlag = true;
		}
		return cachedReadyToClaimFlag;
	}

	public void StoreRequirementCache()
	{
		GameManager.Instance.StoreRequirementCacheInTarget(def.displayRequirement, parentTown, displayRequirement.requirements);
		GameManager.Instance.StoreRequirementCacheInTarget(def.completionRequirement, parentTown, completionRequirement.requirements);
	}
}
