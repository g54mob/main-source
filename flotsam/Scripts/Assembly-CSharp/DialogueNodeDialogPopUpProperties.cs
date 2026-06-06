using UnityEngine;

public class DialogueNodeDialogPopUpProperties : DialogueNodeProperties
{
	[SerializeField]
	private DialogProperties _popUpProperties;

	[SerializeField]
	private bool _isInputDialog;

	[SerializeField]
	private bool _hideDialoguePanel = true;

	protected override string DefaultNodeName => "Dialog PopUp";

	public DialogProperties PopUpProperties => _popUpProperties;

	public bool IsInputDialog => _isInputDialog;

	public bool HideDialoguePanel => _hideDialoguePanel;
}
