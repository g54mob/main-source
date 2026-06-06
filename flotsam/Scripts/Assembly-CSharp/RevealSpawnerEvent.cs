using System.Collections.Generic;

public class RevealSpawnerEvent : GameEvent
{
	private static List<RevealSpawnerEvent> _instances = new List<RevealSpawnerEvent>();

	public ISpawner Spawner { get; private set; }

	public DialogueTrigger PrePanDialogue { get; private set; }

	public DialogueTrigger PostPanDialogue { get; private set; }

	public float CenterOnTownheartWaitTime { get; private set; }

	public bool OpenMapIfInactive { get; private set; }

	private RevealSpawnerEvent()
		: base(GameEventType.RevealSpawner)
	{
	}

	private static RevealSpawnerEvent GetInstance()
	{
		RevealSpawnerEvent revealSpawnerEvent = null;
		if (0 < _instances.Count)
		{
			int index = _instances.Count - 1;
			revealSpawnerEvent = _instances[index];
			_instances.RemoveAt(index);
		}
		else
		{
			revealSpawnerEvent = new RevealSpawnerEvent();
			_instances.Add(revealSpawnerEvent);
		}
		return revealSpawnerEvent;
	}

	public override void Dispose()
	{
		Spawner = null;
		PrePanDialogue = null;
		PostPanDialogue = null;
		CenterOnTownheartWaitTime = 0f;
		OpenMapIfInactive = true;
		_instances.Add(this);
	}

	public static void Dispatch(ISpawner spawner, DialogueTrigger prePanDialogue, DialogueTrigger postPanDialogue)
	{
		RevealSpawnerEvent instance = GetInstance();
		instance.Spawner = spawner;
		instance.PrePanDialogue = prePanDialogue;
		instance.PostPanDialogue = postPanDialogue;
		instance.Dispatch();
	}

	public static void Dispatch(ISpawner spawner, float centerOnTownheartWaitTime, bool openMapIfInactive)
	{
		RevealSpawnerEvent instance = GetInstance();
		instance.Spawner = spawner;
		instance.CenterOnTownheartWaitTime = centerOnTownheartWaitTime;
		instance.OpenMapIfInactive = openMapIfInactive;
		instance.Dispatch();
	}
}
