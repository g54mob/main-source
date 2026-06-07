using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SaveErrorPopup : APopupWindow
{
	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private Button button_OK;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnHideAllErrorUI()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Setup(string msg)
	{
	}

	private void OnButtonOKClick()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
