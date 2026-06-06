using PajamaLlama.SurvivalGuide;

public class PageEvent : GameEvent
{
	private static PageEvent _instance;

	public PageIndex Index { get; private set; }

	public IPage Page { get; private set; }

	private PageEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void Dispatch(GameEventType eventType, PageIndex index)
	{
		if (_instance == null)
		{
			_instance = new PageEvent(eventType);
		}
		else
		{
			_instance.EventType = eventType;
		}
		_instance.Index = index;
		_instance.Page = index.Page;
		_instance.Dispatch();
	}
}
