using UnityEngine;

public class DialogueNodePanelProperties : DialogueNodeProperties
{
	public enum PanelAction
	{
		Open = 0,
		Close = 1
	}

	[SerializeField]
	private PanelID _panelID = PanelID.None;

	[SerializeField]
	private PanelAction _action;

	[SerializeField]
	private bool _hideDialoguePanel = true;

	[SerializeField]
	[Tooltip("If false, the dialogue will wait for the player to close the panel before resuming.")]
	[ConditionalEnumHide("_action", 0, false)]
	private bool _progressDialogueImmediately;

	protected override string DefaultNodeName => "Panel";

	public PanelID PanelID => _panelID;

	public PanelAction Action => _action;

	public bool HideDialoguePanel => _hideDialoguePanel;

	public bool ProgressDialogueImmediately => _progressDialogueImmediately;
}
