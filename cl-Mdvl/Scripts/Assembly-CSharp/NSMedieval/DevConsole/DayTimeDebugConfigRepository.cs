using NSEipix.Repository;

namespace NSMedieval.DevConsole
{
	public class DayTimeDebugConfigRepository : JsonRepository<DayTimeDebugConfigRepository, DayTimeDebugConfig>
	{
		protected override string JsonFile()
		{
			return "Debug/DayTimeDebugConfig.json";
		}
	}
}
