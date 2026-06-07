public class EnergyEvent : GameEvent
{
	public float Amount;

	public EnergyEvent(GameEventType eventType, float amount)
		: base(eventType)
	{
		Amount = amount;
	}
}
