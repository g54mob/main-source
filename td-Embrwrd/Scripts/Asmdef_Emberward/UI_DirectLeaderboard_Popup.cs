using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DirectLeaderboard_Popup : APopupWindow
{
	[SerializeField]
	private Button button_Leave;

	[SerializeField]
	private UI_LeaderBoard ui_LeaderBoard;

	[SerializeField]
	private Transform node_TabLayout;

	[SerializeField]
	private GameObject prefab_LeaderBoardCharacterTabEntry;

	[SerializeField]
	private CanvasGroup canvasGroup_Tab;

	private List<UI_Obj_LeaderBoardCharacterTabEntry> list_TabEntries;

	private bool isButtonClicked;

	private eLeaderboardType curLeaderboardType;

	private string curLeaderBoardName;

	private eCharacterType curLeaderboardCharacter;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	public void SetupCharacterTabs(List<eCharacterType> characterTypes)
	{
	}

	private void Update()
	{
	}

	private void OnClickCharacterTab(eCharacterType characterType)
	{
	}

	public void ShowLeaderboard(string leaderboardName, string extraLeaderBoardName, eCharacterType characterType)
	{
	}

	public void ShowLeaderboard(eLeaderboardType leaderboardType, string extraLeaderBoardName, eCharacterType characterType)
	{
	}

	private void OnLeaderLoadFinished()
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
