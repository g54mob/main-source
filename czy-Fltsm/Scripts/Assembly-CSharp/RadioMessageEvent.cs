public class RadioMessageEvent : GameEvent
{
	private static readonly RadioMessageEvent _instance = new RadioMessageEvent();

	public RadioMessage Message { get; private set; }

	public RadioMessageEvent()
		: base(GameEventType.None)
	{
	}

	public static void DispatchReceived(RadioMessage radioMessage)
	{
		GetInstance(GameEventType.RadioMessageReceived, radioMessage).Dispatch();
	}

	public static void DispatchRead(RadioMessage radioMessage)
	{
		GetInstance(GameEventType.RadioMessageRead, radioMessage).Dispatch();
	}

	public static void DispatchTimedOut(RadioMessage radioMessage)
	{
		GetInstance(GameEventType.RadioMessageTimedOut, radioMessage).Dispatch();
	}

	private static RadioMessageEvent GetInstance(GameEventType eventType, RadioMessage radioMessage)
	{
		_instance.EventType = eventType;
		_instance.Message = radioMessage;
		return _instance;
	}
}
