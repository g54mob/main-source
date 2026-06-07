public class UnlockableEvent : GameEvent
{
	public Unlockable Unlockable { get; private set; }

	public UnlockableEvent(GameEventType eventType, Unlockable unlockable)
		: base(eventType)
	{
		Unlockable = unlockable;
	}
}
