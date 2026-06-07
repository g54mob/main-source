public class MarkerEvent : GameEvent
{
	public Marker Marker;

	public MarkerEvent(GameEventType eventType, Marker marker)
		: base(eventType)
	{
		Marker = marker;
	}

	public static void Dispatch(GameEventType eventType, Marker marker)
	{
		new MarkerEvent(eventType, marker).Dispatch();
	}
}
