using System.Collections.Generic;

public class BiomeState
{
	public BiomeType biomeType;

	public bool isLocked;

	public readonly List<RequirementId> requirementTemplates = new List<RequirementId>();

	public readonly List<Requirement> requirements = new List<Requirement>();

	public void Initialize()
	{
		Reset();
	}

	public void Reset()
	{
		isLocked = true;
	}

	public void Unlock()
	{
		isLocked = false;
		if (GameManager.GameState == GameState.InGame)
		{
			GameManager.Instance.TryAddUnlock(EntityId.FromBiome(biomeType));
			MenuManager.Instance.navigationPanel.SetAlertForPanel(MenuManager.Instance.worldPanel, nextState: true);
		}
	}

	public bool ShouldBeAvailable()
	{
		if (GameManager.Instance.isUnlockedBiomesMode)
		{
			return true;
		}
		foreach (Requirement requirement in requirements)
		{
			if (!requirement.IsMet())
			{
				return false;
			}
		}
		return true;
	}

	public void StoreRequirementCache()
	{
		GameManager.Instance.StoreRequirementCacheInTarget(requirementTemplates, null, requirements);
	}

	public BiomeState(BiomeType t)
	{
		biomeType = t;
		switch (t)
		{
		case BiomeType.River:
			requirementTemplates.Add(new RequirementId(Quest.UnlockWorldPanel));
			break;
		case BiomeType.Forest:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneRiverLevelForForest));
			break;
		case BiomeType.Mountains:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneForestLevelForMountains));
			requirementTemplates.Add(RequirementId.FullGame());
			break;
		case BiomeType.Jungle:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneMountainLevelForJungle));
			requirementTemplates.Add(RequirementId.FullGame());
			break;
		case BiomeType.Desert:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneJungleLevelForDesert));
			requirementTemplates.Add(RequirementId.FullGame());
			break;
		case BiomeType.Snow:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneDesertLevelForSnow));
			requirementTemplates.Add(RequirementId.FullGame());
			break;
		case BiomeType.Magic:
			requirementTemplates.Add(new RequirementId(QuestType.MilestoneSnowLevelForMagic));
			requirementTemplates.Add(RequirementId.FullGame());
			break;
		case BiomeType.Plains:
			break;
		}
	}

	public Quest PrimaryRequiredQuest()
	{
		foreach (Requirement requirement in requirements)
		{
			if (requirement is RequiredQuest requiredQuest)
			{
				return requiredQuest.cachedQuest;
			}
		}
		return null;
	}

	public bool IsLockedButReadyToClaim()
	{
		if (isLocked)
		{
			foreach (Requirement requirement in requirements)
			{
				if ((!(requirement is RequiredQuest { cachedQuest: not null } requiredQuest) || !requiredQuest.cachedQuest.IsReadyToClaim()) && !requirement.IsMet())
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
