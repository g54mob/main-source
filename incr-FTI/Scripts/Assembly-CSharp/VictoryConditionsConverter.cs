using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;

public class VictoryConditionsConverter : CustomConverter<VictoryConditions>
{
	public override Type ModelType => typeof(VictoryConditions);

	public override object CreateInstance(fsData data, Type storageType)
	{
		return new VictoryConditions();
	}

	protected override fsResult DoSerialize(VictoryConditions sourceRuleSet, Dictionary<string, fsData> serialized)
	{
		fsResult success = fsResult.Success;
		NullSafeSerialize(serialized, "localizationKey", sourceRuleSet.localizationKey);
		if (sourceRuleSet.happinessRequirement != null)
		{
			serialized["requiredHappiness"] = new fsData(sourceRuleSet.happinessRequirement.requiredValue);
		}
		if (sourceRuleSet.populationRequirement != null)
		{
			serialized["requiredPopulation"] = new fsData(sourceRuleSet.populationRequirement.targetCount);
		}
		if (sourceRuleSet.requiredProductionCounts != null)
		{
			List<fsData> list = new List<fsData>();
			foreach (RequiredProductionCount requiredProductionCount in sourceRuleSet.requiredProductionCounts)
			{
				list.Add(new fsData((long)requiredProductionCount.itemType));
				list.Add(new fsData(requiredProductionCount.targetCount));
			}
			serialized["requiredProduction"] = new fsData(list);
		}
		if (sourceRuleSet.requiredItemSales != null)
		{
			List<fsData> list2 = new List<fsData>();
			foreach (RequiredItemSales requiredItemSale in sourceRuleSet.requiredItemSales)
			{
				list2.Add(new fsData((long)requiredItemSale.itemType));
				list2.Add(new fsData(requiredItemSale.count));
			}
			serialized["requiredItemSales"] = new fsData(list2);
		}
		if (sourceRuleSet.requiredBuildings != null)
		{
			List<fsData> list3 = new List<fsData>();
			foreach (RequiredMinBuildingCount requiredBuilding in sourceRuleSet.requiredBuildings)
			{
				list3.Add(new fsData((long)requiredBuilding.buildingType));
				list3.Add(new fsData(requiredBuilding.numBuildingsRequired));
			}
			serialized["requiredBuildings"] = new fsData(list3);
		}
		return success;
	}

	protected override fsResult DoDeserialize(Dictionary<string, fsData> data, ref VictoryConditions model)
	{
		fsResult success = fsResult.Success;
		fsResult fsResult2 = (success += NullSafeDeserialize<string>(data, "localizationKey", out model.localizationKey));
		if (fsResult2.Failed)
		{
			return success;
		}
		if (data.TryGetValue("requiredHappiness", out var value))
		{
			if (value.IsInt64)
			{
				model.happinessRequirement = new RequiredMinHappiness((int)value.AsInt64);
			}
			else
			{
				Debug.LogWarning("Unable to parse happiness requirement data: " + value);
			}
		}
		if (data.TryGetValue("requiredPopulation", out var value2))
		{
			if (value2.IsDouble)
			{
				RequiredPopulationCount populationRequirement = new RequiredPopulationCount((float)value2.AsDouble);
				model.populationRequirement = populationRequirement;
			}
			else
			{
				Debug.LogWarning("Unable to parse happiness requirement data: " + value);
			}
		}
		if (data.TryGetValue("requiredProduction", out var value3) && value3.IsList)
		{
			List<fsData> asList = value3.AsList;
			for (int i = 0; i < asList.Count; i += 2)
			{
				ItemType t = (ItemType)asList[i].AsInt64;
				int num = (int)asList[i + 1].AsInt64;
				if (model.requiredProductionCounts == null)
				{
					model.requiredProductionCounts = new List<RequiredProductionCount>();
				}
				model.requiredProductionCounts.Add(new RequiredProductionCount(t, num, global: false));
			}
		}
		if (data.TryGetValue("requiredItemSales", out var value4) && value4.IsList)
		{
			List<fsData> asList2 = value4.AsList;
			for (int j = 0; j < asList2.Count; j += 2)
			{
				ItemType t2 = (ItemType)asList2[j].AsInt64;
				int num2 = (int)asList2[j + 1].AsInt64;
				if (model.requiredItemSales == null)
				{
					model.requiredItemSales = new List<RequiredItemSales>();
				}
				model.requiredItemSales.Add(new RequiredItemSales(t2, num2));
			}
		}
		if (data.TryGetValue("requiredBuildings", out var value5) && value5.IsList)
		{
			List<fsData> asList3 = value5.AsList;
			for (int k = 0; k < asList3.Count; k += 2)
			{
				BuildingType type = (BuildingType)asList3[k].AsInt64;
				int count = (int)asList3[k + 1].AsInt64;
				if (model.requiredBuildings == null)
				{
					model.requiredBuildings = new List<RequiredMinBuildingCount>();
				}
				model.requiredBuildings.Add(new RequiredMinBuildingCount(type, count));
			}
		}
		return success;
	}
}
