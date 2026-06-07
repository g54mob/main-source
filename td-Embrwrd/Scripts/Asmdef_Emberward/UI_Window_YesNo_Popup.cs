using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Window_YesNo_Popup : APopupWindow
{
	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private TMP_Text text_Button_Yes;

	[SerializeField]
	private TMP_Text text_Button_No;

	[SerializeField]
	private Button button_Yes;

	[SerializeField]
	private Button button_No;

	private bool isButtonClicked;

	public Action<bool> resultCallback;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	public void SetupContentByLocKey(string contentLocKey, string yesButtonLocKey, string noButtonLocKey, Action<bool> resultCallback)
	{
	}

	public void SetupContentByString(string content, string yesButtonText, string noButtonText, Action<bool> resultCallback)
	{
	}

	public void RegisterResultCallback(Action<bool> callback)
	{
	}

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnClickButton_Yes()
	{
	}

	private void OnClickButton_No()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
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
