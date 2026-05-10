using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : HUDMenu, ISavable
{
	[SerializeField]
	private GameObject versionWindow;

	[SerializeField]
	private Toggle showVersionWindowToggle;

	[SerializeField]
	private GameObject showVersionWindowButton;

	[SerializeField]
	private GameObject wishlistButton;

	[SerializeField]
	[Savable("autoShowVersionWindow", true, false)]
	private bool autoShowVersionWindow = true;

	private LTMainMenuHUD ltMainMenuHud;

	protected override void Awake()
	{
		base.Awake();
		versionWindow.SetActive(value: false);
	}

	protected override void Start()
	{
		base.Start();
		ltMainMenuHud = base.Hud as LTMainMenuHUD;
		showVersionWindowButton.SetActive(value: false);
	}

	private void OnEnable()
	{
		base.Hud.BlurBackground(enable: false);
	}

	public override bool BackButtonPressed()
	{
		return true;
	}

	public void OnPlayButtonPressed()
	{
		ltMainMenuHud.ShowNewGameMenuUI();
	}

	public void OnUpgradesButtonPressed()
	{
		ltMainMenuHud.ShowUpgradesMenuUI();
	}

	public void OnSettingsButtonPressed()
	{
		ltMainMenuHud.ShowSettingsMenuUI();
	}

	public void OnProfileButtonPressed()
	{
		ltMainMenuHud.ShowProfileMenuUI();
	}

	public void OnCreditsButtonPressed()
	{
		ltMainMenuHud.ShowCreditsMenuUI();
	}

	public void OnExitButtonPressed()
	{
		Application.Quit();
	}

	public void OnTwitterButtonPressed()
	{
		Application.OpenURL("https://twitter.com/GiusCaminiti");
	}

	public void OnDiscordButtonPressed()
	{
		Application.OpenURL("https://discord.gg/WMf3U3WqBN");
	}

	public void OnWishlistButtonPressed()
	{
		Application.OpenURL("steam://openurl/https://store.steampowered.com/app/2707490/Tower_Factory/");
	}

	public void OnShowVersionWindowButtonPressed()
	{
		versionWindow.SetActive(value: true);
	}

	public void OnCloseVersionWindowButtonPressed()
	{
		versionWindow.SetActive(value: false);
	}

	public void OnShowOnUpdateTogglePressed(bool value)
	{
		autoShowVersionWindow = value;
		SaveSystem.instance.SaveData();
	}

	public void OnQuickMatchButtonPressed(LevelData levelData)
	{
		if (SaveSystem.instance.ExistsSavedGame())
		{
			string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_NewGameMenu", "UI_NewGameMenu_modalWindow_pendingSavedGame_body", null, FallbackBehavior.UseProjectSettings);
			Action yesAction = delegate
			{
				SaveSystem.instance.DeleteSavedGame();
				OnQuickMatchButtonPressed(levelData);
			};
			base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
			return;
		}
		MatchInfo.instance.CurrentLevelData = levelData;
		MatchInfo.instance.CurrentMatchMode = EMatchMode.Endless;
		float time = 2f;
		float startingVolume = AudioSystem.Instance.GetCurrentMixerVolumePercentage(AudioSystem.EAudioMixerGroup.Master);
		base.Hud.FadeInOut.FadeIn(time, delegate(float timePercentage)
		{
			AudioSystem.Instance.SetMixerVolume(startingVolume - startingVolume * timePercentage, AudioSystem.EAudioMixerGroup.Master);
		}, delegate
		{
			LoadingScreenController.sceneToLoadIdx = 3;
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		});
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
