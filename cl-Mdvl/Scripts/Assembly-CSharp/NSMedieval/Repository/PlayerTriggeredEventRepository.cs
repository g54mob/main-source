using NSEipix.Repository;
using NSMedieval.PlayerTriggeredEventSystem;

namespace NSMedieval.Repository
{
	public class PlayerTriggeredEventRepository : DynamicJsonRepository<PlayerTriggeredEventRepository, PlayerTriggeredEvent>
	{
		protected override string JsonFile()
		{
			return "PlayerTriggeredEventSystem/PlayerTriggeredEvent.json";
		}
	}
}
