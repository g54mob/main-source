using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Credits_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Close;

	[FormerlySerializedAs("button_MusicCreditPatreon")]
	[SerializeField]
	private Button button_MusicCreditLink;

	[SerializeField]
	private Button button_JPTransCreditLink;

	protected override void ShowWindowProc()
	{
	}

	private void OnButtonJPTransCreditLinkClick()
	{
	}

	private void OnButtonMusicCreditPatreonClick()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void OnButtonCloseClick()
	{
	}

	private void Toggle(bool isOn)
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
