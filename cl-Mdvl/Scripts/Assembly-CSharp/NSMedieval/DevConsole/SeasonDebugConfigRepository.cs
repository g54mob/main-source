using NSEipix.Repository;

namespace NSMedieval.DevConsole
{
	public class SeasonDebugConfigRepository : JsonRepository<SeasonDebugConfigRepository, SeasonDebugConfig>
	{
		protected override string JsonFile()
		{
			return "Debug/SesonDebugConfig.json";
		}
	}
}
