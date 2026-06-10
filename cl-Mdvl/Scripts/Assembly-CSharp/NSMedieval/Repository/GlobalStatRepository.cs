using NSEipix.Repository;
using NSMedieval.GlobalStats;

namespace NSMedieval.Repository
{
	public class GlobalStatRepository : DynamicJsonRepository<GlobalStatRepository, GlobalStat>
	{
		protected override string JsonFile()
		{
			return "GlobalStats/GlobalStatRepository.json";
		}
	}
}
