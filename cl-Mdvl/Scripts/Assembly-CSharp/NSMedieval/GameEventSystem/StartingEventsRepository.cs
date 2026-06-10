using NSEipix.Repository;

namespace NSMedieval.GameEventSystem
{
	public class StartingEventsRepository : DynamicJsonRepository<StartingEventsRepository, StartingEventSchedule>
	{
		protected override string JsonFile()
		{
			return "Data/StartingEventSchedule.json";
		}
	}
}
