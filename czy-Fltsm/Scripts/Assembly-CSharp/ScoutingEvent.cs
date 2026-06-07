using PajamaLlama.Flotsam.World;

public class ScoutingEvent : GameEvent
{
	private static ScoutingEvent _instance;

	public IWorldRegion Region { get; private set; }

	public Agent Agent { get; private set; }

	private ScoutingEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void DispatchScoutRegion(Agent agent, IWorldRegion region)
	{
		ScoutingEvent instance = GetInstance(GameEventType.ScoutRegion);
		instance.Agent = agent;
		instance.Region = region;
		instance.Dispatch();
	}

	public static void DispatchRegionScouted(Agent agent, IWorldRegion region)
	{
		ScoutingEvent instance = GetInstance(GameEventType.RegionScouted);
		instance.Agent = agent;
		instance.Region = region;
		instance.Dispatch();
	}

	private static ScoutingEvent GetInstance(GameEventType gameEventType)
	{
		if (_instance == null)
		{
			_instance = new ScoutingEvent(gameEventType);
		}
		else
		{
			_instance.EventType = gameEventType;
		}
		return _instance;
	}
}
