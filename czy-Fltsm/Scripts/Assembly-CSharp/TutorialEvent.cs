public class TutorialEvent : GameEvent
{
	private static TutorialEvent s_instance;

	public TutorialID Id { get; private set; }

	public TutorialEvent(GameEventType eventType, TutorialID id)
		: base(eventType)
	{
		Id = id;
	}

	public static void Dispatch(GameEventType eventType, TutorialID id)
	{
		GetInstance(eventType, id).Dispatch();
	}

	private static TutorialEvent GetInstance(GameEventType eventType, TutorialID id)
	{
		if (s_instance == null)
		{
			s_instance = new TutorialEvent(eventType, id);
		}
		else
		{
			s_instance.EventType = eventType;
			s_instance.Id = id;
		}
		return s_instance;
	}
}
