using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PreviousAchievementUnlockNotify_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Close;

	[SerializeField]
	private Transform node_Layout;

	[SerializeField]
	private ScrollRect scrollview;

	[SerializeField]
	private GameObject prefab_AchievementJournalEntry;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void Update()
	{
	}

	public void Setup(List<eAchievementType> list_UnlockedAchievements)
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
