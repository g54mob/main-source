using System;
using UnityEngine;

[Serializable]
public class DialogueEventOpenCloseWorldMap : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Open/Close World Map";

	[SerializeField]
	private bool _open = true;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (_open)
		{
			GameManager.WorldMapManager.WorldMap.Open();
		}
		else
		{
			GameManager.WorldMapManager.WorldMap.Close();
		}
	}
}
