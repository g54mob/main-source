public class DecorationEvent : GameEvent
{
	private static readonly DecorationEvent _instance = new DecorationEvent();

	public Decoration Deco { get; private set; }

	public DecorationProperties Properties { get; private set; }

	public DecorationEvent()
		: base(GameEventType.None)
	{
	}

	public static void DispatchConstructed(Decoration decoration)
	{
		GetInstance(GameEventType.DecorationBuilt, decoration).Dispatch();
	}

	public static void DispatchPlaced(Decoration decoration)
	{
		GetInstance(GameEventType.DecorationPlaced, decoration).Dispatch();
	}

	public static void DispatchSelectedInBuildMenu(DecorationProperties properties)
	{
		GetInstance(GameEventType.DecorationSelectedInBuildMenu, null, properties).Dispatch();
	}

	public static void DispatchRemoved(Decoration decoration)
	{
		GetInstance(GameEventType.DecorationRemoved, decoration).Dispatch();
	}

	public static void DispatchSelected(Decoration decoration)
	{
		GetInstance(GameEventType.DecorationSelected, decoration).Dispatch();
	}

	private static DecorationEvent GetInstance(GameEventType eventType, Decoration decoration = null, DecorationProperties properties = null)
	{
		_instance.EventType = eventType;
		_instance.Deco = decoration;
		_instance.Properties = ((properties != null) ? properties : ((decoration != null) ? decoration.Properties : null));
		return _instance;
	}
}
