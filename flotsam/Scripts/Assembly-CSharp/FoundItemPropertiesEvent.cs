public class FoundItemPropertiesEvent : GameEvent
{
	public ItemProperties ItemProperties;

	public Community Community;

	public FoundItemPropertiesEvent(GameEventType eventType, ItemProperties properties, Community community)
		: base(eventType)
	{
		ItemProperties = properties;
		Community = community;
	}
}
