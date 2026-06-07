using System;
using UnityEngine;

[Serializable]
public class DialogueEventUnlockUnlockable : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Unlock Unlockable";

	[SerializeField]
	private Unlockable _unlockable;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (_unlockable != null)
		{
			_unlockable.Unlock();
		}
		else
		{
			Debug.LogError($"No unlockable provided in dialogue {dialogue.DialogueProperties}");
		}
	}
}
