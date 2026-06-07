using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_WelcomeToDemo_Popup : APopupWindow
{
	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private TMP_Text text_Content;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	private void OnClickButton_OK()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
