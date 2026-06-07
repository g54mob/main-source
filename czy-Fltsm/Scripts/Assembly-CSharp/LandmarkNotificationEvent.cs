public class LandmarkNotificationEvent : GenericGameEvent<LandmarkNotificationEvent>
{
	public Landmark Landmark { get; private set; }

	public LandmarkBehaviour LandmarkBehaviour { get; private set; }

	public LandmarkAction LandmarkAction { get; private set; }

	public LandmarkSpawner LandmarkSpawner { get; private set; }

	public static void Spawned(LandmarkSpawner landmarkSpawner)
	{
		ReturnInstance(GameEventType.LandmarkSpawned, landmarkSpawner.LandmarkBehaviour, null, landmarkSpawner).Dispatch();
	}

	public static void Disposed(LandmarkSpawner landmarkSpawner)
	{
		ReturnInstance(GameEventType.LandmarkDisposed, landmarkSpawner.LandmarkBehaviour, null, landmarkSpawner).Dispatch();
	}

	public static void Initialize(LandmarkBehaviour landmarkBehaviour)
	{
		ReturnInstance(GameEventType.LandmarkNotificationInitialize, landmarkBehaviour).Dispatch();
	}

	public static void Idle(LandmarkBehaviour landmarkBehaviour, LandmarkAction landmarkAction)
	{
		ReturnInstance(GameEventType.LandmarkNotificationIdle, landmarkBehaviour, landmarkAction).Dispatch();
	}

	public static void Update(LandmarkBehaviour landmarkBehaviour, LandmarkAction landmarkAction)
	{
		ReturnInstance(GameEventType.LandmarkNotificationUpdate, landmarkBehaviour, landmarkAction).Dispatch();
	}

	public static void Working(LandmarkBehaviour landmarkBehaviour, LandmarkAction landmarkAction)
	{
		ReturnInstance(GameEventType.LandmarkNotificationWorking, landmarkBehaviour, landmarkAction).Dispatch();
	}

	public static void Completed(LandmarkBehaviour landmarkBehaviour, LandmarkAction landmarkAction)
	{
		ReturnInstance(GameEventType.LandmarkActionCompleted, landmarkBehaviour, landmarkAction).Dispatch();
	}

	public static void Remove(LandmarkBehaviour landmarkBehaviour)
	{
		ReturnInstance(GameEventType.LandmarkNotificationDestroy, landmarkBehaviour).Dispatch();
	}

	public static void Selected(Landmark landmark)
	{
		ReturnInstance(GameEventType.LandmarkSelected, landmark).Dispatch();
	}

	public static void Deselected(Landmark landmark)
	{
		ReturnInstance(GameEventType.LandmarkDeselected, landmark).Dispatch();
	}

	private static LandmarkNotificationEvent ReturnInstance(GameEventType gameEventType, Landmark landmark)
	{
		LandmarkNotificationEvent landmarkNotificationEvent = GenericGameEvent<LandmarkNotificationEvent>.ReturnInstance(gameEventType);
		landmarkNotificationEvent.Landmark = landmark;
		landmarkNotificationEvent.LandmarkBehaviour = landmark.Behaviour;
		return landmarkNotificationEvent;
	}

	private static LandmarkNotificationEvent ReturnInstance(GameEventType gameEventType, LandmarkBehaviour landmarkBehaviour, LandmarkAction landmarkAction = null, LandmarkSpawner landmarkSpawner = null)
	{
		LandmarkNotificationEvent landmarkNotificationEvent = GenericGameEvent<LandmarkNotificationEvent>.ReturnInstance(gameEventType);
		landmarkNotificationEvent.LandmarkBehaviour = landmarkBehaviour;
		landmarkNotificationEvent.LandmarkAction = landmarkAction;
		landmarkNotificationEvent.LandmarkSpawner = landmarkSpawner;
		return landmarkNotificationEvent;
	}
}
