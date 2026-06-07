using System;
using UnityEngine;

[Serializable]
public class DialogueEventSetGameSpeed : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Set Game Speed";

	[SerializeField]
	private GameSpeed _speed = GameSpeed.One;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (_speed == GameSpeed.Zero)
		{
			GameSpeedManager.ToggleGameSpeedZero();
		}
		else
		{
			GameSpeedManager.SetGameSpeed(_speed);
		}
	}
}
