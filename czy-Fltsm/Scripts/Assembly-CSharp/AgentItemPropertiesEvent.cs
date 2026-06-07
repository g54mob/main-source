public class AgentItemPropertiesEvent : AgentEvent
{
	private static AgentItemPropertiesEvent _instance;

	public AgentItemPropertiesEvent(GameEventType eventType, Agent agent, ItemProperties itemProperties)
		: base(eventType, agent)
	{
		base.ItemProperties = itemProperties;
	}

	public static void Dispatch(GameEventType eventType, Agent agent, ItemProperties itemProperties)
	{
		if (_instance == null)
		{
			_instance = new AgentItemPropertiesEvent(eventType, agent, itemProperties);
		}
		else
		{
			_instance.EventType = eventType;
			_instance.Agent = agent;
			_instance.ItemProperties = itemProperties;
		}
		_instance.Dispatch();
	}
}
