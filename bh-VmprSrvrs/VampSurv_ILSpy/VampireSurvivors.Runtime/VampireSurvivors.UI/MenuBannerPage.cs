using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class MenuBannerPage : BaseUIPage
{
	private RectTransform _Banner;

	private RectTransform _SafeArea;

	private GameObject _TwitchModeEnabled;

	private GameObject _AccountButton;

	private GameObject _LeaveAdventureButton;

	private GameObject _QuitGameButton;

	private RectTransform _LocalSafeArea;

	private AdventureManager _adventure;

	private void Construct(AdventureManager adventure)
	{
		_adventure = adventure;
	}

	private void Start()
	{
		UpdateLayout();
	}

	protected override void Update()
	{
		base.Update();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x186D1AC40\"");
	}

	private void UpdateLayout()
	{
		bool flag = TwitchIntegration._sInstance.IsTwitchOn();
		if (flag)
		{
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			bool flag2 = playerCount > 1 || MultiplayerManager.s_instance.IsOnlineMultiplayer;
			flag = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		}
		_TwitchModeEnabled.SetActive(flag);
		bool active = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField && AccountButtonController.CanShow;
		_AccountButton.SetActive(active);
		bool flag3 = AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		bool active2 = false;
		if (!flag3)
		{
			active2 = QuitGameButton.ShouldShow;
		}
		_QuitGameButton.SetActive(active2);
		bool flag4 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
		bool flag5 = false;
		if (!flag4)
		{
			flag5 = QuitGameButton.ShouldShow;
		}
		bool flag6 = !flag5;
		bool active3 = !flag6;
		_LeaveAdventureButton.SetActive(active3);
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		bool flag = TwitchIntegration._sInstance.IsTwitchOn();
		if (flag)
		{
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			bool flag2 = playerCount > 1 || MultiplayerManager.s_instance.IsOnlineMultiplayer;
			flag = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		}
		_TwitchModeEnabled.SetActive(flag);
	}

	public void LeaveAdventure()
	{
		_adventure.ExitAdventureMode();
	}
}
