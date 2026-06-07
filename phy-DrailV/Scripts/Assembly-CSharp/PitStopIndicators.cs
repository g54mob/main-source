using System.Collections.Generic;
using DV;
using DV.ThingTypes;
using UnityEngine;

public class PitStopIndicators : MonoBehaviour
{
	public LocoResourceModule[] resourceModules;

	public void UpdateResourceModules(Dictionary<ResourceType, LocoParameterData> locoParams, bool resetTarget)
	{
		LocoResourceModule[] array = resourceModules;
		foreach (LocoResourceModule resourceModule in array)
		{
			UpdateResourceModule(resourceModule, locoParams, resetTarget);
		}
	}

	public void UpdatePricesDependingOnLocoType(TrainCar trainCar, TrainCarLivery locoLivery)
	{
		LocoResourceModule[] array = resourceModules;
		foreach (LocoResourceModule locoResourceModule in array)
		{
			if (locoResourceModule.HasCarTypeDependentPrice)
			{
				locoResourceModule.UpdateResourcePricePerUnit(trainCar, ResourceTypes.GetFullUnitPriceOfResource(locoResourceModule.resourceType, locoLivery, null, Globals.G.GameParams.ResourcesParams));
			}
		}
	}

	public void UpdateIndependentPrices(TrainCar trainCar)
	{
		LocoResourceModule[] array = resourceModules;
		foreach (LocoResourceModule locoResourceModule in array)
		{
			if (!locoResourceModule.HasCarTypeDependentPrice)
			{
				locoResourceModule.UpdateResourcePricePerUnit(trainCar, ResourceTypes.GetFullUnitPriceOfResource(locoResourceModule.resourceType, null, null, Globals.G.GameParams.ResourcesParams));
			}
		}
	}

	public void ClearPricesThatDependOnLocoType(TrainCar trainCar)
	{
		LocoResourceModule[] array = resourceModules;
		foreach (LocoResourceModule locoResourceModule in array)
		{
			if (locoResourceModule.HasCarTypeDependentPrice)
			{
				locoResourceModule.UpdateResourcePricePerUnit(trainCar, -1f);
			}
		}
	}

	private void UpdateResourceModule(LocoResourceModule resourceModule, Dictionary<ResourceType, LocoParameterData> locoParams, bool resetTarget)
	{
		if (locoParams.ContainsKey(resourceModule.resourceType))
		{
			resourceModule.UpdateResourceModule(locoParams[resourceModule.resourceType]);
		}
		else
		{
			resourceModule.UpdateResourceModule(null);
		}
	}

	public void ResetResourceModuleState()
	{
		LocoResourceModule[] array = resourceModules;
		foreach (LocoResourceModule obj in array)
		{
			obj.CancelShopping();
			obj.UpdateResourceModule(null);
		}
	}
}
