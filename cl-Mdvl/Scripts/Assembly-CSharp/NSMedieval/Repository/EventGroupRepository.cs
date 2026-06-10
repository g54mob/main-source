using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class EventGroupRepository : DynamicJsonRepository<EventGroupRepository, EventGroup>
	{
		protected override string JsonFile()
		{
			return "GameEventSystem/EventGroups.json";
		}
	}
}
