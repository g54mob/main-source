using System;
using UnityEngine;

[Serializable]
public class DialogueEventOpenClosePanel : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Open/Close Panel";

	[SerializeField]
	private bool _open = true;

	[SerializeField]
	private PanelID _panelID = PanelID.None;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (_open)
		{
			GameManager.UIManager.DisplayPanel(_panelID);
		}
		else
		{
			GameManager.UIManager.ClosePanel(_panelID);
		}
	}
}
