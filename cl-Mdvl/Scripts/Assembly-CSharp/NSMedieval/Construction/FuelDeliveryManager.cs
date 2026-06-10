using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.Construction
{
	public class FuelDeliveryManager : MonoSingleton<FuelDeliveryManager>
	{
		private readonly List<FuelConsumerComponentInstance> objectsToRefuelRefactored = new List<FuelConsumerComponentInstance>();

		private FuelConsumerCopySettingsData fuelConsumerCopySettingsData;

		public List<FuelConsumerComponentInstance> ObjectsToRefuelRefactored => objectsToRefuelRefactored;

		public FuelConsumerCopySettingsData FuelConsumerCopySettingsData => fuelConsumerCopySettingsData;

		public void SetFuelConsumerCopyFilter(FuelConsumerCopySettingsData fuelConsumerCopyFilter)
		{
			fuelConsumerCopySettingsData = fuelConsumerCopyFilter;
		}

		public void AddToRefuelList(FuelConsumerComponentInstance target)
		{
			if (!objectsToRefuelRefactored.Contains(target))
			{
				objectsToRefuelRefactored.Add(target);
			}
		}

		public void RemoveFromRefuelList(FuelConsumerComponentInstance target)
		{
			objectsToRefuelRefactored.Remove(target);
		}
	}
}
