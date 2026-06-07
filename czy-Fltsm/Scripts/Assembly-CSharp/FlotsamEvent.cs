public class FlotsamEvent : GameEvent
{
	private static FlotsamEvent _instance;

	public Flotsam Flotsam { get; private set; }

	public FlotsamProperties FlotsamProperties { get; private set; }

	private FlotsamEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void Dispatch(GameEventType eventType, Flotsam flotsam)
	{
		if (_instance == null)
		{
			_instance = new FlotsamEvent(eventType);
		}
		else
		{
			_instance.EventType = eventType;
		}
		_instance.Flotsam = flotsam;
		_instance.Dispatch();
	}
}
