public class EnergyGridConnectionEvent : GameEvent
{
	public EnergyGridConnector ComponentA;

	public EnergyGridConnector ComponentB;

	private static EnergyGridConnectionEvent _instance;

	public EnergyGridConnectionEvent(GameEventType eventType, EnergyGridConnector a, EnergyGridConnector b)
		: base(eventType)
	{
		ComponentA = a;
		ComponentB = b;
	}

	public static void Dispatch(GameEventType eventType, EnergyGridConnector a, EnergyGridConnector b)
	{
		if (_instance == null)
		{
			_instance = new EnergyGridConnectionEvent(eventType, a, b);
		}
		else
		{
			_instance.EventType = eventType;
			_instance.ComponentA = a;
			_instance.ComponentB = b;
		}
		_instance.Dispatch();
	}
}
