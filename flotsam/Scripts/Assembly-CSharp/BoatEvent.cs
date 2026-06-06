public class BoatEvent : GameEvent
{
	public BoatType BoatType;

	public BoatEvent(GameEventType eventType, BoatType boatType)
		: base(eventType)
	{
		BoatType = boatType;
	}
}
