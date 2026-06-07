using UnityEngine;

public class DialogueNodeEmptyProperties : DialogueNodeProperties
{
	[Header("Empty Node")]
	[SerializeField]
	private bool _hideDialoguePanel;

	[SerializeField]
	private bool _progressDialogue;

	protected override string DefaultNodeName => "Empty";

	public bool HideDialoguePanel => _hideDialoguePanel;

	public bool ProgressDialogue => _progressDialogue;
}
