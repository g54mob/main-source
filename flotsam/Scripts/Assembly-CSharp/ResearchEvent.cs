public class ResearchEvent : GameEvent
{
	private static ResearchEvent s_instance;

	public CommunityResearch.Research Research { get; private set; }

	public ResearchEvent(GameEventType eventType, CommunityResearch.Research research)
		: base(eventType)
	{
		Research = research;
	}

	public static void Dispatch(GameEventType eventType, CommunityResearch.Research research)
	{
		if (s_instance == null)
		{
			s_instance = new ResearchEvent(eventType, research);
		}
		else
		{
			s_instance.EventType = eventType;
			s_instance.Research = research;
		}
		s_instance.Dispatch();
	}
}
