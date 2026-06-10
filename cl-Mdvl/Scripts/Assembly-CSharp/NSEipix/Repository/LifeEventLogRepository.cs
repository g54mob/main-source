using Social;

namespace NSEipix.Repository
{
	public class LifeEventLogRepository : DynamicJsonRepository<LifeEventLogRepository, LifeEventLog>
	{
		protected override string JsonFile()
		{
			return "SocialInteraction/LifeEventLog.json";
		}
	}
}
