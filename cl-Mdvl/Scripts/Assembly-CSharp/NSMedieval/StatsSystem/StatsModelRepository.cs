using System.Linq;
using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class StatsModelRepository : DynamicJsonRepository<StatsModelRepository, StatsModel>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/StatsModelRepository.json";
		}

		public Stat GetStatByType(string modelId, StatType statType)
		{
			return GetByID(modelId).Stats.FirstOrDefault((Stat x) => x.Type == statType);
		}
	}
}
