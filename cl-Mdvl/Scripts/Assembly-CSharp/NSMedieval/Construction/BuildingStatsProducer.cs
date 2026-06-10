using System.Collections.Generic;
using NSMedieval.BuildingComponents;
using NSMedieval.StatsSystem;

namespace NSMedieval.Construction
{
	public static class BuildingStatsProducer
	{
		public static StatsInstance ProduceBuildingStats(BaseBuildingInstance buildableObject, StatsInstance stats)
		{
			Stat[] stats2;
			if (stats != null)
			{
				if (stats.IsGeneratedFromRepository)
				{
					return stats;
				}
				stats2 = buildableObject.Blueprint.Stats;
				foreach (Stat stat in stats2)
				{
					stats.GetStat(stat.Type).SetBlueprint(stat);
				}
				return stats;
			}
			if (buildableObject.Blueprint.Stats == null)
			{
				StatsInstance statsInstance = new StatsInstance(buildableObject, "Building");
				statsInstance.GenerateInstancesFromRepository();
				return statsInstance;
			}
			CustomStatsInstance customStatsInstance = new CustomStatsInstance(buildableObject);
			List<AttributeInstance> customAttributes = new List<AttributeInstance>();
			List<StatInstance> list = new List<StatInstance>();
			stats2 = buildableObject.Blueprint.Stats;
			foreach (Stat blueprint in stats2)
			{
				list.Add(new StatInstance(blueprint, customStatsInstance));
			}
			customStatsInstance.SetCustomAttributes(customAttributes);
			customStatsInstance.SetCustomStats(list);
			return customStatsInstance;
		}
	}
}
