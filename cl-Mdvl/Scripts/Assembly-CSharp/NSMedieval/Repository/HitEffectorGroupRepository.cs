using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class HitEffectorGroupRepository : DynamicJsonRepository<HitEffectorGroupRepository, HitEffectorGroup>
	{
		protected override string JsonFile()
		{
			return "StatsSystem/HitEffectorGroups.json";
		}
	}
}
