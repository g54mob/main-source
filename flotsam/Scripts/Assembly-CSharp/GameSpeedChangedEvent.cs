public class GameSpeedChangedEvent : GameEvent
{
	private static GameSpeedChangedEvent _instance;

	public GameSpeed GameSpeed { get; private set; } = GameSpeed.One;

	public GameSpeed ZeroedGameSpeed { get; private set; } = GameSpeed.One;

	private GameSpeedChangedEvent()
		: base(GameEventType.GameSpeedChange)
	{
	}

	public static void Dispatch(GameSpeed gameSpeed, GameSpeed zeroedGameSpeed)
	{
		if (_instance == null)
		{
			_instance = new GameSpeedChangedEvent();
		}
		_instance.GameSpeed = gameSpeed;
		_instance.ZeroedGameSpeed = zeroedGameSpeed;
		_instance.Dispatch();
	}
}
