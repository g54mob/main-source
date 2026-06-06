public class LoadingEvent : GameEvent
{
	public float Progress { get; private set; }

	public string Label { get; private set; }

	public LoadingEvent(GameEventType gameEventType)
		: base(gameEventType)
	{
	}

	public LoadingEvent(float progress)
		: base(GameEventType.LoadingUpdateProgress)
	{
		Progress = progress;
	}

	public LoadingEvent(string label)
		: base(GameEventType.LoadingUpdateLabel)
	{
		Label = label;
	}
}
