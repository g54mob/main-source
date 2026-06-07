public class AttributeEvent : GameEvent
{
	public DrifterAttributes.AttributeType AttributeType { get; private set; }

	public Agent Agent { get; private set; }

	public AttributeEvent(GameEventType eventType, DrifterAttributes.AttributeType attributeType, Agent agent)
		: base(eventType)
	{
		AttributeType = attributeType;
		Agent = agent;
	}
}
