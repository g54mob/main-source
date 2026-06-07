using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnigmaSanctumIntro_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Close;

	[SerializeField]
	private List<UI_Obj_EnigmaSanctumIntroEntry> list_IntroEntries;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void Start()
	{
	}

	private void OnCloseButtonClicked()
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
