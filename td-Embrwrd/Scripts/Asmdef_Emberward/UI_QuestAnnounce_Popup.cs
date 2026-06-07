using TMPro;
using UnityEngine;

public class UI_QuestAnnounce_Popup : APopupWindow
{
	[SerializeField]
	private TMP_Text text_QuestDescription;

	private QuestData questData;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void TriggerAnimation_AlreadyHaveQuest()
	{
	}

	public void TriggerAnimation_NewQuest_Step1()
	{
	}

	public void TriggerAnimation_NewQuest_Step2()
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
