using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class DialoguePanelOptions
{
	[SerializeField]
	[Tooltip("Use this if this node needs to be spoken by someone else than the rest of the dialogue (otherwise set the speaker in the dialogue's entry node)")]
	private DialogueContext.ActorType _speakerOverride;

	[SerializeField]
	private bool _showSpeakerPortrait = true;

	[SerializeField]
	[ConditionalHide("_showSpeakerPortrait", true)]
	private Activity _speakerPortraitActivity = Activity.DynamicPortrait;

	[SerializeField]
	[ConditionalHide("_showSpeakerPortrait", true)]
	private Sprite _speakerPortraitOverride;

	[SerializeField]
	[ConditionalHide("_showSpeakerPortrait", true)]
	private LocalizedString _speakerNameOverride = null;

	[SerializeField]
	private bool _pauseGame;

	[SerializeField]
	private bool _blockGameInputs;

	[SerializeField]
	private bool _blockTownMovement = true;

	[SerializeField]
	private UIElementsLayerID _blockUILayersInputs;

	[SerializeField]
	private UIElementsLayerID _hideUILayers;

	public DialogueContext.ActorType SpeakerOverride => _speakerOverride;

	public bool ShowSpeakerPortrait => _showSpeakerPortrait;

	public Activity SpeakerActivity => _speakerPortraitActivity;

	public Sprite SpeakerPortraitOverride => _speakerPortraitOverride;

	public LocalizedString SpeakerNameOverride => _speakerNameOverride;

	public bool PauseGame => _pauseGame;

	public bool BlockGameInputs => _blockGameInputs;

	public bool BlockTownMovement => _blockTownMovement;

	public UIElementsLayerID BlockUILayersInputs => _blockUILayersInputs;

	public UIElementsLayerID HideUILayers => _hideUILayers;
}
