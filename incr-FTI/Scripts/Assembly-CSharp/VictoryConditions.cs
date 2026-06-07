using System;
using System.Collections.Generic;

public class VictoryConditions
{
	[NonSerialized]
	public int id;

	public string localizationKey;

	public List<RequiredMinBuildingCount> requiredBuildings;

	public List<RequiredProductionCount> requiredProductionCounts;

	public List<RequiredItemSales> requiredItemSales;

	public List<RequiredGenericFlag> requiredFlags;

	public List<RequiredGenericCount> requiredCounts;

	public RequiredMinHappiness happinessRequirement;

	public RequiredPopulationCount populationRequirement;

	public bool hasAnyRequirement;

	public VictoryConditions()
	{
	}

	public VictoryConditions(int id)
	{
		this.id = id;
	}

	private void CacheHasAnyRequirement()
	{
		hasAnyRequirement = happinessRequirement != null || populationRequirement != null || (requiredBuildings != null && requiredBuildings.Count > 0) || (requiredProductionCounts != null && requiredProductionCounts.Count > 0) || (requiredFlags != null && requiredFlags.Count > 0) || (requiredItemSales != null && requiredItemSales.Count > 0);
	}

	public void SetHappinessRequirement(int minRequiredHappiness)
	{
		if (happinessRequirement == null)
		{
			happinessRequirement = new RequiredMinHappiness(minRequiredHappiness);
		}
		else
		{
			happinessRequirement.requiredValue = minRequiredHappiness;
		}
		hasAnyRequirement = true;
	}

	public void ClearHappinessRequirement()
	{
		happinessRequirement = null;
		CacheHasAnyRequirement();
	}

	public void ClearPopulationRequirement()
	{
		populationRequirement = null;
		CacheHasAnyRequirement();
	}

	public void Reset()
	{
		id = 0;
		requiredBuildings = null;
		requiredProductionCounts = null;
		requiredItemSales = null;
		requiredFlags = null;
		requiredCounts = null;
		happinessRequirement = null;
		populationRequirement = null;
		hasAnyRequirement = false;
	}

	public void SetRequiredItemProduction(ItemType t, int count)
	{
		if (requiredProductionCounts == null)
		{
			requiredProductionCounts = new List<RequiredProductionCount>();
		}
		else
		{
			foreach (RequiredProductionCount requiredProductionCount in requiredProductionCounts)
			{
				if (requiredProductionCount.itemType == t)
				{
					requiredProductionCount.targetCount = count;
					return;
				}
			}
		}
		requiredProductionCounts.Add(new RequiredProductionCount(t, count, global: false));
		hasAnyRequirement = true;
	}

	public void SetRequiredItemSales(ItemType t, int count)
	{
		if (requiredItemSales == null)
		{
			requiredItemSales = new List<RequiredItemSales>();
		}
		else
		{
			foreach (RequiredItemSales requiredItemSale in requiredItemSales)
			{
				if (requiredItemSale.itemType == t)
				{
					requiredItemSale.count = count;
					return;
				}
			}
		}
		requiredItemSales.Add(new RequiredItemSales(t, count));
		hasAnyRequirement = true;
	}

	public bool IsMet()
	{
		bool result = false;
		if (happinessRequirement != null)
		{
			if (!happinessRequirement.IsMet())
			{
				return false;
			}
			result = true;
		}
		if (populationRequirement != null)
		{
			if (!populationRequirement.IsMet())
			{
				return false;
			}
			result = true;
		}
		if (requiredBuildings != null)
		{
			foreach (RequiredMinBuildingCount requiredBuilding in requiredBuildings)
			{
				if (!requiredBuilding.IsMet())
				{
					return false;
				}
				result = true;
			}
		}
		if (requiredProductionCounts != null)
		{
			foreach (RequiredProductionCount requiredProductionCount in requiredProductionCounts)
			{
				if (!requiredProductionCount.IsMet())
				{
					return false;
				}
				result = true;
			}
		}
		if (requiredItemSales != null)
		{
			foreach (RequiredItemSales requiredItemSale in requiredItemSales)
			{
				if (!requiredItemSale.IsMet())
				{
					return false;
				}
				result = true;
			}
		}
		return result;
	}

	public VictoryConditions GetData()
	{
		return FileManager.DeepCopy(this);
	}

	public void LoadFromData(VictoryConditions other)
	{
		Reset();
		if (other != null)
		{
			id = other.id;
			localizationKey = other.localizationKey;
			VictoryConditions victoryConditions = FileManager.DeepCopy(other);
			happinessRequirement = victoryConditions.happinessRequirement;
			populationRequirement = victoryConditions.populationRequirement;
			requiredBuildings = victoryConditions.requiredBuildings;
			requiredProductionCounts = victoryConditions.requiredProductionCounts;
			requiredItemSales = victoryConditions.requiredItemSales;
			CacheHasAnyRequirement();
		}
	}
}
