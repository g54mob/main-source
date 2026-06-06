using PajamaLlama.Flotsam.Morale;

public class AchievementEvent : GameEvent
{
	private static AchievementEvent _instance;

	public EnergyManualProducer EnergyManualProducer { get; private set; }

	public MoraleEffect MoraleEffect { get; private set; }

	public AchievementEvent(GameEventType type)
		: base(type)
	{
	}

	private static AchievementEvent Get(GameEventType type)
	{
		if (_instance == null)
		{
			_instance = new AchievementEvent(type);
		}
		else
		{
			_instance.EventType = type;
		}
		_instance.Clear();
		return _instance;
	}

	private void Clear()
	{
		EnergyManualProducer = null;
		MoraleEffect = null;
	}

	public static void Dispatch(GameEventType type, EnergyManualProducer energyManualProducer)
	{
		AchievementEvent achievementEvent = Get(type);
		achievementEvent.EnergyManualProducer = energyManualProducer;
		achievementEvent.Dispatch();
	}

	public static void Dispatch(GameEventType type, MoraleEffect moraleEffect)
	{
		AchievementEvent achievementEvent = Get(type);
		achievementEvent.MoraleEffect = moraleEffect;
		achievementEvent.Dispatch();
	}
}
