public class GameEvent : EventBase<GameEventType>
{
	public GameEvent(GameEventType eventType)
		: base(eventType)
	{
	}

	public static void Dispatch(GameEventType eventType)
	{
		new GameEvent(eventType).Dispatch();
	}

	protected override void DispatchEvent()
	{
		GameEventDispatcher.Dispatch(this);
	}
}
