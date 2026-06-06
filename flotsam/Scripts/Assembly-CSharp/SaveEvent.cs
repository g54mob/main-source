using System;

public class SaveEvent : GameEvent
{
	public SaveInfo Save;

	[Obsolete]
	public SaveEvent(GameEventType eventType, SaveMetaInfo saveMetaInfo)
		: base(eventType)
	{
	}

	private SaveEvent(GameEventType eventType, SaveInfo save)
		: base(eventType)
	{
		Save = save;
	}

	public static void Dispatch(GameEventType eventType, SaveInfo saveInfo)
	{
		new SaveEvent(eventType, saveInfo).Dispatch();
	}
}
