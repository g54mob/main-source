public class StringEvent : GameEvent
{
	private static StringEvent _instance;

	public string Data { get; private set; }

	public StringEvent(GameEventType eventType, string data)
		: base(eventType)
	{
		Data = data;
	}

	public static void Dispatch(GameEventType eventType, string data)
	{
		if (_instance == null)
		{
			_instance = new StringEvent(eventType, data);
		}
		else
		{
			_instance.EventType = eventType;
			_instance.Data = data;
		}
		_instance.Dispatch();
	}
}
