using System.Collections.Generic;
using UnityEngine;

public class ResearchState : StateManager
{
	public ResearchType type;

	public Research recipe;

	public bool isReadyToClaim;

	public BuildObjectAvailability availability;

	private float craftingTime;

	public readonly List<Requirement> derivedRequirements = new List<Requirement>();

	public readonly List<Requirement> permanentUnlockRequirements = new List<Requirement>();

	public bool isCostGridStale;

	public int numCompleted;

	public ResearchState()
	{
		Initialize();
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromResearch(type);
	}

	public void LoadResearch(Research r)
	{
		recipe = r;
		craftingTime = recipe.craftingTime;
		type = r.type;
		isUnitProgressHardCapped = true;
	}

	public bool IsAvailable()
	{
		return availability == BuildObjectAvailability.Available;
	}

	public override void Reset()
	{
		base.Reset();
		numCompleted = 0;
		availability = BuildObjectAvailability.Locked;
	}

	private float GetBaseProductionRate()
	{
		craftingTime = recipe.craftingTime;
		if (craftingTime > 0f && recipe.isLeveledResearch)
		{
			int level = parentTown.LevelOfResearch(type);
			float growthPercent = recipe.timeScaleValue;
			if (recipe.isInfiniteResearch)
			{
				growthPercent = 0.2f;
			}
			float num = GameUtility.ExponentGrowth(1f, level, growthPercent);
			craftingTime *= num;
		}
		if (craftingTime >= 0f)
		{
			return 1f / craftingTime;
		}
		return 1f;
	}

	public void StoreLeveledAttributes()
	{
		StoreRequirementCache();
		StoreDynamicStateCache();
		if (GameManager.GameState == GameState.InGame)
		{
			CalcAppliedProductionLimit();
			PerformCalcSpeed();
		}
		isCostGridStale = true;
	}

	public void StoreDynamicStateCache()
	{
		RemoveSelfFromRequesters();
		input.Clear();
		inputCount = 0;
		output.Clear();
		outputCount = 0;
		baseProductionRate = GetBaseProductionRate();
		Dictionary<ItemType, double> items = recipe.InputsForLevel(numCompleted).items;
		StoreInputs(items, showCurrency: false, showResearch: false);
		StoreInputs(items, showCurrency: false, showResearch: true);
		StoreInputs(items, showCurrency: true, showResearch: false);
	}

	public override void StoreItemStateCache()
	{
		base.StoreItemStateCache();
		baseProductionRate = GetBaseProductionRate();
		SetProductionBuilding(parentTown.buildings[BuildingType.School]);
	}

	private void StoreInputs(Dictionary<ItemType, double> dict, bool showCurrency, bool showResearch)
	{
		foreach (KeyValuePair<ItemType, double> item in dict)
		{
			ItemType key = item.Key;
			bool flag = Item.IsCurrency(key) && key != ItemType.ResearchPointsGeneral_Disabled;
			bool flag2 = key == ItemType.ResearchTomeGeneral || key == ItemType.ResearchTomeIndustry1 || key == ItemType.ResearchTomeIndustry2 || key == ItemType.ResearchTomeIndustry3 || key == ItemType.ResearchTomeMagic1 || key == ItemType.ResearchTomeMagic2 || key == ItemType.ResearchTomeMagic3;
			if (showCurrency == flag && showResearch == flag2 && parentTown.inventory.TryGetValue(key, out var value))
			{
				AddInput(value, item.Value, baseProductionRate);
			}
		}
	}

	public override void LoadModifiers()
	{
		base.LoadModifiers();
		AddModifier(UpgradeType.ResearchSpeed);
		AddModifier(UpgradeType.OmniResearchSpeed);
		AddModifier(PerkType.ResearchSpeed);
		AddModifier(PerkType.GlobalResearchSpeed);
		if (GameManager.Instance.isExtraActive)
		{
			AddModifier(GameModifier.ExtraActive, 2f);
		}
		else if (GameManager.Instance.isExtraIdle)
		{
			AddModifier(GameModifier.ExtraIdle, 0.5f);
		}
	}

	protected override void CalcSpeed()
	{
		base.CalcSpeed();
		double num = GameUtility.RoundedDoubleFromFloat(parentTown.MultiplierForPerk(PerkType.ResearchEfficiency));
		inputAmountMultiplier *= num;
		inputAmountMultiplier *= GameManager.Instance.wonderMultiplierMonastery;
		if (recipe.isLeveledResearch && !recipe.isLevelCostSpecified)
		{
			int level = parentTown.LevelOfResearch(type);
			float growthPercent = recipe.costScaleValue;
			if (recipe.isInfiniteResearch)
			{
				growthPercent = 0.5f;
			}
			double num2 = GameUtility.ExponentGrowth(1f, level, growthPercent);
			if (num2 < 2147483647.0)
			{
				num2 = GameUtility.RoundToInt(num2);
			}
			inputAmountMultiplier *= num2;
		}
	}

	protected override void OnUnitCompleted()
	{
		GameManager.Instance.OnResearchReadyToClaim(this);
		if (appliedAutoClaim)
		{
			Claim();
		}
		else
		{
			isReadyToClaim = true;
		}
		if (isReadyToClaim || availability != BuildObjectAvailability.Available)
		{
			parentTown.DeactivateState(this);
		}
		if (base.producingBuilding != null)
		{
			MenuManager.Instance.researchPanel.ReloadRepeatsForBuilding(base.producingBuilding.type);
		}
	}

	public void Claim()
	{
		parentTown.IncrementResearch(type);
		isReadyToClaim = false;
		unitProgress = 0.0;
		GameManager.Instance.SetStaleFlagsForCompletedResearch(this);
		MenuManager.Instance.researchPanel.DeselectIfVisible(this);
	}

	public void DebugAdjustCraftingTime(float t)
	{
		craftingTime = t;
		StoreItemStateCache();
	}

	public override string ToString()
	{
		return "ResearchState " + type;
	}

	public override bool IsWorkerAssignment()
	{
		return false;
	}

	public string GetLocalizedOutput()
	{
		EntityLevel entityLevel = GameUtility.PrimaryReward(recipe.reward);
		if (entityLevel.entityId.type != EntityType.None)
		{
			return GetLocalizedEntity(entityLevel.entityId, recipe.overrideLocalizationLevel);
		}
		Debug.LogError("No reward for " + type);
		return TextDisplay.Text("Research" + type);
	}

	public static string GetLocalizedEntity(EntityId id, int lvl)
	{
		NaturalResource i;
		NaturalResource i2;
		string text = (id.TryAsFarming(out i) ? (TextDisplay.LabelForItem(Item.ItemFromNaturalResource(i)) + " " + "Cultivation".Localized()) : ((!id.TryAsMining(out i2)) ? TextDisplay.LabelForEntity(id) : (TextDisplay.LabelForItem(Item.ItemFromNaturalResource(i2)) + " " + "Prospecting".Localized())));
		if (lvl > 0)
		{
			return string.Format(TextDisplay.KeyValueFormatSpaced, text, TextDisplay.GetFormattedLevelAbbreviation(lvl));
		}
		return text;
	}

	public string GetLabel()
	{
		return Research.GetLabel(type, numCompleted);
	}

	private void StoreRequirementCache()
	{
		derivedRequirements.Clear();
		List<RequirementId> list = recipe.RequirementsForLevel(numCompleted);
		if (list == null)
		{
			return;
		}
		foreach (RequirementId item in list)
		{
			Requirement cachedRequirement = parentTown.GetCachedRequirement(item);
			if (cachedRequirement != null && !derivedRequirements.Contains(cachedRequirement))
			{
				derivedRequirements.Add(cachedRequirement);
			}
		}
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		if (parentTown == MenuManager.Instance.researchPanel.displayedTown)
		{
			MenuManager.Instance.researchPanel.isTownLayoutStale = true;
		}
	}

	public override void CalcOptimalWorkers()
	{
		if (base.activePauseState || isLocked)
		{
			return;
		}
		if (unitProgress >= 1.0 || availability == BuildObjectAvailability.Completed)
		{
			if (numWorkersAssigned > 0f)
			{
				AutoAssignNumWorkers(0f);
			}
		}
		else
		{
			base.CalcOptimalWorkers();
		}
	}

	public float CurrentMaxWorkers()
	{
		if (GameManager.Instance.isExtraActive)
		{
			return float.MaxValue;
		}
		if (recipe.isInfiniteResearch)
		{
			return float.MaxValue;
		}
		if (recipe.isLeveledResearch)
		{
			return recipe.maxWorkers + (float)numCompleted;
		}
		return recipe.maxWorkers;
	}
}
