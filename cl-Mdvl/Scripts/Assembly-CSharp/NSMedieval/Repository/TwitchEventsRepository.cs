using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class TwitchEventsRepository : DynamicJsonRepository<TwitchEventsRepository, TwitchEventsData>
	{
		protected override string JsonFile()
		{
			return "Twitch/TwitchEventsRepository.json";
		}
	}
}
