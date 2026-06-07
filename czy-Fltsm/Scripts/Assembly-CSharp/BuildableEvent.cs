public class BuildableEvent : GameEvent
{
	private static BuildableEvent _instance;

	public Buildable Buildable { get; private set; }

	public BuildableProperties BuildableProperties { get; private set; }

	public ModuleProperties ModuleProperties { get; private set; }

	private BuildableEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void Dispatch(GameEventType eventType, Buildable buildable)
	{
		BuildableEvent buildableEvent = ReturnInstance(eventType);
		buildableEvent.Buildable = buildable;
		buildableEvent.BuildableProperties = buildable.Properties;
		buildableEvent.ModuleProperties = null;
		buildableEvent.Dispatch();
	}

	public static void Dispatch(GameEventType eventType, BuildableProperties properties)
	{
		BuildableEvent buildableEvent = ReturnInstance(eventType);
		buildableEvent.Buildable = null;
		buildableEvent.BuildableProperties = properties;
		buildableEvent.ModuleProperties = null;
		buildableEvent.Dispatch();
	}

	public static void Dipatch(GameEventType eventType, Buildable buildable, ModuleProperties moduleProperties)
	{
		BuildableEvent buildableEvent = ReturnInstance(eventType);
		buildableEvent.Buildable = buildable;
		buildableEvent.BuildableProperties = buildable.Properties;
		buildableEvent.ModuleProperties = moduleProperties;
		buildableEvent.Dispatch();
	}

	private static BuildableEvent ReturnInstance(GameEventType eventType)
	{
		if (_instance == null)
		{
			_instance = new BuildableEvent(eventType);
		}
		else
		{
			_instance.EventType = eventType;
		}
		return _instance;
	}
}
