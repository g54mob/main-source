using TMPro;
using UnityEngine;

[RequireComponent(typeof(KeyAssignment))]
public class KeyAssignmentStylesApplier : StylesApplierBase
{
	private KeyAssignment keyAssignment;

	private KeyAssignmentAudioEffect keyAssignmentAudioEffect;

	private TextMeshProUGUI labelText;

	public override void Initialize()
	{
		keyAssignment = GetComponent<KeyAssignment>();
		keyAssignmentAudioEffect = GetComponent<KeyAssignmentAudioEffect>();
		labelText = base.transform.FindComponent<TextMeshProUGUI>("LabelText", isRecursively: true);
	}

	public override void UpdateStyles()
	{
		if (keyAssignmentAudioEffect != null)
		{
			keyAssignmentAudioEffect.Volume = gameStylesData.volumeStylesData.uiVolume;
			keyAssignmentAudioEffect.ToggleOverClip = null;
			keyAssignmentAudioEffect.ToggleOffClip = null;
			keyAssignmentAudioEffect.ToggleOnClip = gameStylesData.toggleOnClip;
			keyAssignmentAudioEffect.KeyChangedClip = gameStylesData.keyChangedClip;
		}
	}

	public override void UpdateTexts()
	{
		if (!string.IsNullOrEmpty(baseId))
		{
			labelText.text = LanguagesManager.Instance.GetText("keyassignment.text." + baseId, baseId);
		}
		keyAssignment.PressAKeyText = LanguagesManager.Instance.GetText("keyassignment.pressakey", "Press a key");
	}
}
