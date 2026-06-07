using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_HardModeSelect_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Lv1;

	[SerializeField]
	private Button button_Leave;

	private bool result;

	public Action<bool> OnResultCallback;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void RegisterResultCallback(Action<bool> callback)
	{
	}

	private void OnButtonOKClick()
	{
	}

	private void OnButtonLeaveClick()
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
