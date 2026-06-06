public class AgentFloatEvent : GameEvent
{
	public Agent Agent;

	public float Value { get; private set; }

	public AgentFloatEvent(GameEventType eventType, Agent agent, float value)
		: base(eventType)
	{
		Agent = agent;
		Value = value;
	}
}
