using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CheckStartNewGamePopup : APopupWindow
{
	[SerializeField]
	private Button button_OK;

	[SerializeField]
	private Button button_Cancel;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private UI_PlayerCharacter ui_PlayerCharacter;

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

	private void OnButtonCancelClick()
	{
	}

	public override void OnTriggerKeybind(string keyName)
	{
	}

	private string GetContinueInfo()
	{
		return null;
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
