using I2.Loc;
using TMPro;
using UnityEngine;

public class UIInteractableTextToggle : UIInteractableToggle
{
	[Header("Text Toggle")]
	[SerializeField]
	[Tooltip("Text component to update when toggling.")]
	private TextMeshProUGUI _toggleText;

	[SerializeField]
	[Tooltip("Text to set when toggle is on.")]
	private LocalizedString _onText = null;

	[SerializeField]
	[Tooltip("Text to set when toggle is off.")]
	private LocalizedString _offText = null;

	public override void Toggle(bool toggled, bool sendEvent = false)
	{
		base.Toggle(toggled, sendEvent);
		_toggleText.text = (base.IsOn ? _onText : _offText);
	}
}
