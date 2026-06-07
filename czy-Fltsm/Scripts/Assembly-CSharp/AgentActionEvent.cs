public class AgentActionEvent : GameEvent
{
	public Agent Agent { get; private set; }

	public DrifterAttributes.AttributeType AttributeType { get; private set; }

	public AgentActionEvent(GameEventType gameEventType, Agent agent, DrifterAttributes.AttributeType type)
		: base(gameEventType)
	{
		Agent = agent;
		AttributeType = type;
	}

	public static void Dispatch(GameEventType gameEventType, Agent agent, DrifterAttributes.AttributeType type)
	{
		new AgentActionEvent(gameEventType, agent, type).Dispatch();
	}
}
