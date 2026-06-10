using Social;

namespace NSEipix.Repository
{
	public class EventInteractionDataRepository : DynamicJsonRepository<EventInteractionDataRepository, EventInteractionData>
	{
		protected override string JsonFile()
		{
			return "SocialInteraction/EventInteractionData.json";
		}
	}
}
