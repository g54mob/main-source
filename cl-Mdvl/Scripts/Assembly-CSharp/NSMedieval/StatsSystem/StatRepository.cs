using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class StatRepository : MultiJsonRepository<StatRepository, Stat>
	{
		protected override string[] JsonFiles()
		{
			return new string[2] { "StatsSystem/BuildingStats.json", "StatsSystem/TrebuchetStats.json" };
		}
	}
}
