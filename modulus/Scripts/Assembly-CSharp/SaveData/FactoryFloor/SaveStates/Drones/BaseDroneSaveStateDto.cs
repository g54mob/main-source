using System;
using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Newtonsoft.Json;

namespace SaveData.FactoryFloor.SaveStates.Drones
{
	[Serializable]
	public class BaseDroneSaveStateDto
	{
		public int CurrentTime;

		public Dictionary<int, int> Resources;

		[JsonConstructor]
		public BaseDroneSaveStateDto(int currentTime, Dictionary<int, int> resources)
		{
			Resources = resources;
			CurrentTime = currentTime;
		}

		public BaseDroneSaveStateDto(int currentTime, Dictionary<ResourceDataSO, int> resources)
		{
			Resources = new Dictionary<int, int>();
			foreach (KeyValuePair<ResourceDataSO, int> resource in resources)
			{
				Resources.Add(resource.Key.ID, resource.Value);
			}
			CurrentTime = currentTime;
		}

		public Dictionary<ResourceDataSO, int> GetResources(ResourceDatabaseSO resourceDatabase)
		{
			Dictionary<ResourceDataSO, int> dictionary = new Dictionary<ResourceDataSO, int>();
			if (Resources == null)
			{
				return dictionary;
			}
			foreach (KeyValuePair<int, int> resource in Resources)
			{
				dictionary.Add(resourceDatabase.GetResourceDataFromID(resource.Key), resource.Value);
			}
			return dictionary;
		}
	}
}
