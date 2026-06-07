using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Window_Info_Popup : APopupWindow
{
	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private Button button_OK;

	private bool result;

	public Action<bool> OnResultCallback;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void Setup(string msg)
	{
	}

	public void RegisterResultCallback(Action<bool> callback)
	{
	}

	private void OnButtonOKClick()
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
