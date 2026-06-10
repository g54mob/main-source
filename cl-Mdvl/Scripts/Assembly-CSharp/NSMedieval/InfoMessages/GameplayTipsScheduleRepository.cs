using NSEipix.Repository;

namespace NSMedieval.InfoMessages
{
	public class GameplayTipsScheduleRepository : JsonRepository<GameplayTipsScheduleRepository, GameplayTipsScheduler>
	{
		protected override string JsonFile()
		{
			return "Almanac/GameplayTipsScheduler.json";
		}
	}
}
