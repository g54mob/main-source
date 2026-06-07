public class EnergyGridEvent : GameEvent
{
	public EnergyGrid Grid;

	public EnergyGridEvent(GameEventType eventType, EnergyGrid grid)
		: base(eventType)
	{
		Grid = grid;
	}
}
