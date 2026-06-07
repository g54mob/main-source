using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class LTMainMenuHUD : MainMenuHUD, ISavable
{
	[Header("LT Main Menu HUD")]
	[SerializeField]
	private MainMenuUI mainMenuUI;

	[SerializeField]
	private NewGameMenuUI newGameMenuUI;

	[SerializeField]
	private GameModeMenuUI gameModeMenuUI;

	[SerializeField]
	private EndlessModeMenuUI endlessModeMenuUI;

	[SerializeField]
	private UpgradesMenuUI upgradesMenuUI;

	[SerializeField]
	private MainMenuSettingsUI mainMenuSettingsUI;

	[SerializeField]
	private ProfileMenuUI profileMenuUI;

	[SerializeField]
	private CreditsMenuUI creditsMenuUI;

	[Savable("firstCoinsMessageShown", true, false)]
	private bool firstCoinsMessageShown;

	protected override void Start()
	{
		base.Start();
		Time.timeScale = 1f;
		base.FadeInOut.FadeOut(2f);
		ShowMainMenuUI();
	}

	public void ShowMainMenuUI()
	{
		ShowMenu(mainMenuUI);
	}

	public void ShowNewGameMenuUI()
	{
		ShowMenu(newGameMenuUI);
	}

	public void ShowGameModeMenuUI()
	{
		ShowMenu(gameModeMenuUI);
	}

	public void ShowEndlessModeMenuUI()
	{
		ShowMenu(endlessModeMenuUI);
	}

	public void ShowUpgradesMenuUI()
	{
		ShowMenu(upgradesMenuUI);
	}

	public void ShowSettingsMenuUI()
	{
		ShowMenu(mainMenuSettingsUI);
	}

	public void ShowProfileMenuUI()
	{
		ShowMenu(profileMenuUI);
	}

	public void ShowCreditsMenuUI()
	{
		ShowMenu(creditsMenuUI);
	}

	private void ShowFirstCoinsModalWindos()
	{
		string localizedString = new LocalizedString("UI_MainMenu", "UI_MainMenu_modalWindow_firstCoin_message").GetLocalizedString();
		string localizedString2 = new LocalizedString("UI_Common", "UI_Common_ok").GetLocalizedString();
		ShowModalWindowOneButton(localizedString, "", null, null, localizedString2);
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		if (!firstCoinsMessageShown && LTFunctionLibrary.GetPlayerUpgradesManager().Money > 0)
		{
			firstCoinsMessageShown = true;
			SaveSystem.instance.SaveData();
			ShowFirstCoinsModalWindos();
		}
	}
}
