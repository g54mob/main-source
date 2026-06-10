using NSEipix.Repository;

namespace NSMedieval.StatsSystem
{
	public class WoundsRepository : DynamicJsonRepository<WoundsRepository, StatEffectorWound>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/Wounds.json";
		}
	}
}
