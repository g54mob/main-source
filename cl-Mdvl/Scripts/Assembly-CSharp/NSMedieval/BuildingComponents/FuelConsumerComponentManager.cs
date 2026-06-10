using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Village;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class FuelConsumerComponentManager : ComponentBaseManager<FuelConsumerComponent, FuelConsumerComponentInstance>
	{
		public List<FuelConsumerComponentInstance> AllFuelConsumers => InstanceComponentDictionary.Keys.ToList();

		public FuelConsumerComponentManager(VillageMap map)
			: base(map)
		{
		}

		public List<WorldObject> GetFuelConsumerBuildingsPathfinding(bool onlyPlayerOwnedBuildings, Func<FuelConsumerComponentInstance, bool> condition = null)
		{
			List<WorldObject> list = new List<WorldObject>();
			KeyValuePair<WorldObject, FuelConsumerComponentInstance>[] array = WorldObjectComponentInstanceDictionary.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<WorldObject, FuelConsumerComponentInstance> keyValuePair = array[i];
				if (keyValuePair.Key == null || keyValuePair.Key.HasDisposed || (onlyPlayerOwnedBuildings && !keyValuePair.Key.OwnedByPlayer()) || keyValuePair.Value == null || keyValuePair.Value.HasDisposed)
				{
					continue;
				}
				if (condition != null)
				{
					if (condition(keyValuePair.Value))
					{
						list.Add(keyValuePair.Key);
					}
				}
				else
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}
	}
}
