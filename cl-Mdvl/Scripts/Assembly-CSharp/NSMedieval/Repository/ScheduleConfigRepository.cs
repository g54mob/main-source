using NSEipix.Repository;
using NSMedieval.Goap;

namespace NSMedieval.Repository
{
	public class ScheduleConfigRepository : DynamicJsonRepository<ScheduleConfigRepository, ScheduleConfig>
	{
		protected override string JsonFile()
		{
			return "Creature/ScheduleConfigRepository.json";
		}
	}
}
