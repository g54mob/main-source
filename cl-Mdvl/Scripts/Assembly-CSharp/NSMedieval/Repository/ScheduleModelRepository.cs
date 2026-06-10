using NSEipix.Repository;
using NSMedieval.Goap;

namespace NSMedieval.Repository
{
	public class ScheduleModelRepository : DynamicJsonRepository<ScheduleModelRepository, ScheduleModel>
	{
		protected override string JsonFile()
		{
			return "Creature/ScheduleModelRepository.json";
		}
	}
}
