using System;
using UnityEngine;

[Serializable]
public class DialogueEventGameEvent : IDialogueEvent
{
	[SerializeField]
	private GameEventType _gameEventType;

	[SerializeField]
	private bool _shouldTriggerOnDialogueRepeat = true;

	public bool ShouldTriggerOnDialogueRepeat => _shouldTriggerOnDialogueRepeat;

	public void TriggerEvent(Dialogue dialogue)
	{
		GameEventDispatcher.Dispatch(_gameEventType);
	}
}
