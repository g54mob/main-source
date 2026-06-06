public class AgentActionItemPropertiesEvent : AgentActionEvent
{
	public ItemProperties ItemProperties { get; private set; }

	public AgentActionItemPropertiesEvent(GameEventType gameEventType, Agent agent, ItemProperties itemProperties, DrifterAttributes.AttributeType type)
		: base(gameEventType, agent, type)
	{
		ItemProperties = itemProperties;
	}
}
