using UnityEngine;

public class Requirement
{
	private static int initIdCounter;

	public int initId;

	public bool isTargetingGlobalStat;

	protected void TryAddToProcessingQueue()
	{
		initId = initIdCounter;
		initIdCounter++;
	}

	public virtual bool IsImpossible()
	{
		return false;
	}

	public virtual bool IsMet()
	{
		return false;
	}

	public virtual void Reset()
	{
	}

	public virtual void StoreItemStateCache(Town town)
	{
	}

	public virtual void StoreItemStateCacheGlobal()
	{
	}

	public virtual Requirement GetCopy()
	{
		return null;
	}

	public static Requirement FromId(RequirementId id)
	{
		Requirement requirement = FromId_Internal(id);
		requirement.isTargetingGlobalStat = id.isTargetingGlobalStat;
		return requirement;
	}

	private static Requirement FromId_Internal(RequirementId id)
	{
		int num = ((id.targetCount > 3.4028234663852886E+38) ? int.MaxValue : ((!(id.targetCount < -3.4028234663852886E+38)) ? Mathf.RoundToInt((float)id.targetCount) : int.MinValue));
		switch (id.type)
		{
		case RequirementType.Research:
			return new RequiredResearch(id.entityId.AsResearch);
		case RequirementType.MinResearchCount:
			return new RequiredMinResearchCount(num, id.isTargetingGlobalStat);
		case RequirementType.Quest:
			return new RequiredQuest(id.entityId.AsQuest);
		case RequirementType.NaturalResource:
			return new RequiredNaturalResource(id.entityId.AsNaturalResource);
		case RequirementType.HarvestRecipe:
			return new RequiredHarvestRecipe(id.entityId.AsHarvestRecipe);
		case RequirementType.Item:
			return new RequiredItem(id.entityId.AsItem);
		case RequirementType.ProductionCount:
			return new RequiredProductionCount(id.entityId.AsItem, id.targetCount, id.isTargetingGlobalStat);
		case RequirementType.MinBuildingCount:
			return new RequiredMinBuildingCount(id.entityId.AsBuilding, num);
		case RequirementType.MinigameLevel:
			return new RequiredMinigameLevel(id.entityId.AsMenuPanel, num);
		case RequirementType.CoinSpendCount:
			return new RequiredCoinSpendCount(id.entityId.AsItem, id.targetCount);
		case RequirementType.MarketSellCount:
			return new RequiredMarketSellCount(id.entityId.AsBuilding, id.targetCount);
		case RequirementType.FullGame:
			return new RequiredFullGame();
		case RequirementType.Biome:
			return new RequiredBiome(id.entityId.AsBiome);
		case RequirementType.ExcludedBiome:
			return new RequiredBiome(id.entityId.AsBiome, exclude: true);
		case RequirementType.SkillLevel:
			return new RequiredSkillLevel((SkillType)id.data, id.entityId, num);
		case RequirementType.SkillLevelCount:
		{
			int num2 = id.data % 100;
			int targetCount = Mathf.RoundToInt((float)(id.data - num2) / 100f);
			return new RequiredSkillLevelCount((SkillType)num2, num, targetCount);
		}
		case RequirementType.SkillXP:
			return new RequiredSkillXP((SkillType)id.data, id.targetCount);
		case RequirementType.BuildingSkills:
			return new RequiredBuildingSkills(id.entityId.AsBuilding, num);
		case RequirementType.Upgrade:
			return new RequiredUpgrade(id.entityId.AsUpgrade, num);
		case RequirementType.TotalUpgradeCount:
			return new RequiredUpgradeCount(num);
		case RequirementType.Perk:
			return new RequiredPerk(id.entityId.AsPerk, num);
		case RequirementType.WorkerAssignCount:
			return new RequiredGenericCount(num, GameManager.Instance.NumWorkersAssigned, EntityId.FromNaturalResource(NaturalResource.Tree), "AssignWorkers");
		case RequirementType.TownLevel:
		{
			if (id.entityId.TryAsBiome(out var t))
			{
				return new RequiredTownLevel(num, t);
			}
			return new RequiredTownLevel(num, BiomeType.None);
		}
		case RequirementType.MinWorkerCount:
			return new RequiredPopulationCount(num);
		default:
			return null;
		}
	}

	public virtual bool IsVisible()
	{
		return true;
	}
}
