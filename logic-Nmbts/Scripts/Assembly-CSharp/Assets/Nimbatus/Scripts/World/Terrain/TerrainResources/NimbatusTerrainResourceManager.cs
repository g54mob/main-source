using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine.Analytics;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainResources
{
	public class NimbatusTerrainResourceManager : SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>
	{
		public Dictionary<ETerrainMaterial, ResourceSetting> ResourceSettings;

		protected Dictionary<ETerrainMaterial, double> TerrainResourceDictionary = new Dictionary<ETerrainMaterial, double>();

		internal override string Filename
		{
			get
			{
				return "Resources.xml";
			}
		}

		protected override void PreLoad()
		{
			TerrainResourceDictionary.Clear();
		}

		protected override void PostLoad()
		{
			foreach (KeyValuePair<ETerrainMaterial, ResourceSetting> resourceSetting in ResourceSettings)
			{
				if (!TerrainResourceDictionary.ContainsKey(resourceSetting.Key))
				{
					if (RuntimeGlobals.GameModeSettings.InCampaignTutorial && resourceSetting.Key == ETerrainMaterial.RareOre)
					{
						TerrainResourceDictionary.Add(resourceSetting.Key, 0.0);
					}
					else
					{
						TerrainResourceDictionary.Add(resourceSetting.Key, resourceSetting.Value.GetStartingAmount());
					}
				}
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			foreach (KeyValuePair<ETerrainMaterial, double> item in TerrainResourceDictionary)
			{
				dictionary.Add(item.Key.ToString(), item.Value);
			}
			Analytics.CustomEvent("ResourceAmount", dictionary);
		}

		public void AddResources(ETerrainMaterial key, double value)
		{
			if (key >= ETerrainMaterial.None && key <= ETerrainMaterial.RareOre)
			{
				if (!TerrainResourceDictionary.ContainsKey(key))
				{
					TerrainResourceDictionary.Add(key, 0.0);
				}
				double num = TerrainResourceDictionary[key];
				TerrainResourceDictionary[key] = Math.Max(0.0, num + value);
				if (key == ETerrainMaterial.CommonOre && TerrainResourceDictionary[key] >= 5000.0)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.AbundantResources);
				}
				if (key == ETerrainMaterial.RareOre && TerrainResourceDictionary[key] >= 1000.0)
				{
					BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.CapitalistConstructor);
				}
			}
		}

		public bool HasResources(ETerrainMaterial key, float value)
		{
			if (TerrainResourceDictionary.ContainsKey(key))
			{
				return TerrainResourceDictionary[key] >= (double)value;
			}
			return false;
		}

		public void UseResources(ETerrainMaterial key, float value)
		{
			if (TerrainResourceDictionary.ContainsKey(key))
			{
				TerrainResourceDictionary[key] -= value;
			}
		}

		public KeyValuePair<ETerrainMaterial, float> GetConversion(ETerrainMaterial from, ETerrainMaterial to, float value)
		{
			if (TerrainResourceDictionary.ContainsKey(from) && TerrainResourceDictionary.ContainsKey(to))
			{
				float num = ResourceSettings[from].ConversionRate / ResourceSettings[to].ConversionRate;
				return new KeyValuePair<ETerrainMaterial, float>(to, value * num);
			}
			throw new Exception("Can't convert resources");
		}

		public double GetAvailableResources(ETerrainMaterial key)
		{
			if (TerrainResourceDictionary.ContainsKey(key))
			{
				return TerrainResourceDictionary[key];
			}
			return 0.0;
		}

		public ResourceSetting GetResourceSetting(ETerrainMaterial key)
		{
			if (ResourceSettings.ContainsKey(key))
			{
				return ResourceSettings[key];
			}
			return null;
		}

		protected override void LoadFromFile(ResourceManagerData data)
		{
			foreach (ResourceData resource in data.ResourceList)
			{
				AddResources(resource.Type, resource.Value);
			}
		}

		protected override ResourceManagerData SaveToFile()
		{
			ResourceManagerData resourceManagerData = new ResourceManagerData();
			foreach (KeyValuePair<ETerrainMaterial, double> item in TerrainResourceDictionary)
			{
				int key = (int)item.Key;
				if (key >= 0 && key <= 2)
				{
					resourceManagerData.ResourceList.Add(new ResourceData(item.Key, item.Value));
				}
			}
			return resourceManagerData;
		}
	}
}
