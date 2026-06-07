using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_CheckBackToTitlePopup : APopupWindow
{
	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private Button button_Cancel;

	private bool result;

	public Action<bool> OnResultCallback;

	protected override void CloseWindowProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	public void RegisterResultCallback(Action<bool> callback)
	{
	}

	private void OnButtonOKClick()
	{
	}

	private void OnButtonCancelClick()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
