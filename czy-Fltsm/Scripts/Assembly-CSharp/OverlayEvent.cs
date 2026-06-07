public class OverlayEvent : GameEvent
{
	private static OverlayEvent _instance;

	public Overlays.Type OverlayType { get; private set; }

	private OverlayEvent()
		: base(GameEventType.OverlayUpdate)
	{
	}

	public static void DispatchUpdated(Overlays.Type type)
	{
		if (_instance == null)
		{
			_instance = new OverlayEvent();
		}
		_instance.OverlayType = type;
		_instance.Dispatch();
	}
}
