using PajamaLlama.Flotsam;

public class AsyncSaveEvent : GameEvent
{
	public SaveTaskBase SaveTask { get; private set; }

	public bool Succes { get; private set; }

	public AsyncSaveEvent(GameEventType type)
		: base(type)
	{
	}

	public static void DispatchStarted()
	{
		GameEventDispatcher.Dispatch(GameEventType.AsyncSaveStarted);
	}

	public static void DispatchCompleted(SaveTaskBase saveTask)
	{
		AsyncSaveEvent asyncSaveEvent = new AsyncSaveEvent(GameEventType.AsyncSaveCompleted);
		asyncSaveEvent.SaveTask = saveTask;
		asyncSaveEvent.Succes = saveTask.Success;
		asyncSaveEvent.Dispatch();
	}
}
