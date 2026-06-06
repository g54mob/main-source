using System;
using NewGameplayScripts;
using UnityEngine;

public class FloorsButtonLevel_2 : MonoBehaviour
{
	[SerializeField]
	private SwitchFloorButton floorButton;

	private void Start()
	{
		DialogueManager.Instance.OnDialogueStart += DialogueManager_OnDialogueStart;
		DialogueManager.Instance.OnDialogueFinish += DialogueManager_OnDialogueFinish;
	}

	private void DialogueManager_OnDialogueStart(object sender, EventArgs e)
	{
		floorButton.HideFloorButton();
	}

	private void DialogueManager_OnDialogueFinish(object sender, EventArgs e)
	{
		floorButton.ShowFloorButton();
	}

	private void OnDestroy()
	{
		DialogueManager.Instance.OnDialogueStart -= DialogueManager_OnDialogueStart;
		DialogueManager.Instance.OnDialogueFinish -= DialogueManager_OnDialogueFinish;
	}
}
