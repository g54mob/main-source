using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class DailyReportPersistentData
{
	public DailyReportTableData FoodData;

	public DailyReportTableData WaterData;

	public DailyReportTableData EnergyData;

	public Dictionary<int, int> GatheredResources;

	public Dictionary<int, int> CraftedResources;

	[OptionalField(VersionAdded = 3)]
	public Dictionary<int, int> GrownResources;

	[OptionalField(VersionAdded = 4)]
	public CountedItemPersistentData[] Consumed;

	[OptionalField(VersionAdded = 4)]
	public CountedItemPersistentData[] Processed;

	public float TravelledDistance;

	[OptionalField(VersionAdded = 2)]
	public float ExperienceGained;

	[OptionalField(VersionAdded = 2)]
	public int ResearchPointsGained;

	[OptionalField(VersionAdded = 4)]
	public int LandmarksSalvaged;

	[OptionalField(VersionAdded = 4)]
	public ushort[] ActorRescues;

	[OptionalField(VersionAdded = 4)]
	public ushort[] ActorDeaths;

	[OptionalField(VersionAdded = 4)]
	public int StartAgentCount;

	public DailyReportPersistentData(DailyReport report)
	{
		FoodData = new DailyReportTableData(report.FoodData);
		WaterData = new DailyReportTableData(report.WaterData);
		EnergyData = new DailyReportTableData(report.EnergyData);
		GatheredResources = ReturnResourceDictionary(report.GatheredResources);
		CraftedResources = ReturnResourceDictionary(report.CraftedResources);
		GrownResources = ReturnResourceDictionary(report.FarmedResources);
		Consumed = CountedItemPersistentData.FromDictionary(report.Consumed);
		Processed = CountedItemPersistentData.FromDictionary(report.Processed);
		TravelledDistance = report.TravelledDistance;
		ExperienceGained = report.ExperienceGained;
		ResearchPointsGained = report.ResearchPointsGained;
		LandmarksSalvaged = report.LandmarksSalvaged;
		ActorRescues = ((report.ActorRescues != null) ? report.ActorRescues.ToArray() : null);
		ActorDeaths = ((report.ActorDeaths != null) ? report.ActorDeaths.ToArray() : null);
		StartAgentCount = report.StartAgentCount;
	}

	public Dictionary<ItemProperties, int> ReturnResourceDictionary(Dictionary<int, int> resources)
	{
		Dictionary<ItemProperties, int> dictionary = new Dictionary<ItemProperties, int>();
		if (resources.IsNullOrEmpty())
		{
			return dictionary;
		}
		foreach (KeyValuePair<int, int> resource in resources)
		{
			if (GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(resource.Key, out var reference))
			{
				dictionary.Add(reference, resource.Value);
			}
		}
		return dictionary;
	}

	private Dictionary<int, int> ReturnResourceDictionary(Dictionary<ItemProperties, int> resources)
	{
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<ItemProperties, int> resource in resources)
		{
			int key = GameManager.PersistenceManager.ReturnPropertiesIndex(resource.Key);
			dictionary.Add(key, resource.Value);
		}
		return dictionary;
	}
}
