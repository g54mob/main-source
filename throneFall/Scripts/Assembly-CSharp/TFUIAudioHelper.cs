using UnityEngine;

[RequireComponent(typeof(ThronefallUIElement))]
public class TFUIAudioHelper : MonoBehaviour
{
	public bool playOnColdSelect;

	public ThronefallAudioManager.AudioOneShot onSelect = ThronefallAudioManager.AudioOneShot.ButtonSelect;

	public ThronefallAudioManager.AudioOneShot onApply = ThronefallAudioManager.AudioOneShot.ButtonApply;

	private ThronefallUIElement tfui;

	private bool selected
	{
		get
		{
			if (tfui.CurrentState == ThronefallUIElement.SelectionState.Selected || tfui.CurrentState == ThronefallUIElement.SelectionState.FocussedAndSelected)
			{
				if (tfui.PreviousState != ThronefallUIElement.SelectionState.FocussedAndSelected)
				{
					return tfui.PreviousState != ThronefallUIElement.SelectionState.Selected;
				}
				return false;
			}
			return false;
		}
	}

	private void Start()
	{
		tfui = GetComponent<ThronefallUIElement>();
		tfui.onApply.AddListener(PlayApply);
		tfui.onSelectionStateChange.AddListener(PlaySelect);
		if (selected && playOnColdSelect)
		{
			PlaySelect();
		}
	}

	private void PlayApply()
	{
		ThronefallAudioManager.Oneshot(onApply);
	}

	private void PlaySelect()
	{
		if (selected)
		{
			ThronefallAudioManager.Oneshot(onSelect);
		}
	}
}
