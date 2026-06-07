public class WeightEvent : GameEvent
{
	private static WeightEvent s_instance;

	public float Weight { get; private set; }

	public WeightTier WeightTier { get; private set; }

	private WeightEvent(GameEventType eventType, float weight, WeightTier weightTier)
		: base(eventType)
	{
		Weight = weight;
		WeightTier = weightTier;
	}

	public static void Dispatch(GameEventType eventType, float weight, WeightTier weightTier)
	{
		GetInstance(eventType, weight, weightTier).Dispatch();
	}

	private static WeightEvent GetInstance(GameEventType eventType, float weight, WeightTier weightTier)
	{
		if (s_instance == null)
		{
			s_instance = new WeightEvent(eventType, weight, weightTier);
		}
		else
		{
			s_instance.EventType = eventType;
			s_instance.Weight = weight;
			s_instance.WeightTier = weightTier;
		}
		return s_instance;
	}
}
