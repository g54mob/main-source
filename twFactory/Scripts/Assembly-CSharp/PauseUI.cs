using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class PauseUI : HUDMenu
{
	[SerializeField]
	private TextMeshProUGUI levelNameText;

	[SerializeField]
	private TextMeshProUGUI modeNameText;

	[SerializeField]
	private GameObject wishlistButton;

	private bool isExiting;

	protected override void Start()
	{
		base.Start();
	}

	private void OnEnable()
	{
		UpdateModeNameText();
		UpdateLevelNameText();
	}

	private void UpdateLevelNameText()
	{
		levelNameText.text = string.Empty;
		if ((bool)MatchInfo.instance?.CurrentLevelData)
		{
			levelNameText.text = MatchInfo.instance.CurrentLevelData.DisplayName.GetLocalizedString();
		}
	}

	private void UpdateModeNameText()
	{
		modeNameText.text = string.Empty;
		if ((bool)MatchInfo.instance?.CurrentMatchSettings)
		{
			modeNameText.text = MatchInfo.instance.CurrentMatchSettings.DisplayName.GetLocalizedString();
		}
	}

	private void ExitToMainMenu()
	{
		float time = 1f;
		isExiting = true;
		float masterVolume = SettingsController.instance.GetMasterVolume();
		base.Hud.FadeInOut.FadeIn(time, delegate(float timePercentage)
		{
			AudioSystem.Instance.SetMixerVolume(masterVolume - masterVolume * timePercentage, AudioSystem.EAudioMixerGroup.Master);
		}, delegate
		{
			LoadingScreenController.sceneToLoadIdx = 0;
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		});
	}

	public override bool BackButtonPressed()
	{
		if (!isExiting && base.BackButtonPressed())
		{
			OnContinueButtonPressed();
			return true;
		}
		return false;
	}

	public void OnContinueButtonPressed()
	{
		LTFunctionLibrary.GetLTGameManager().PauseGame(pause: false);
	}

	public void OnSettingsButtonPressed()
	{
		(base.Hud as LTHUD).ShowSettingsUI();
	}

	public void OnAddToWishlistButtonPressed()
	{
		Application.OpenURL("steam://openurl/https://store.steampowered.com/app/2707490/Tower_Factory/");
	}

	public void OnSurrenderButtonPressed()
	{
		Action yesAction = delegate
		{
			LTFunctionLibrary.GetLTGameManager().GameOver();
		};
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_pause_modalWindow_surrender_message_01").Entry.GetLocalizedString();
		base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
	}

	public void OnSaveAndExitButtonPressed()
	{
		Action yesAction = delegate
		{
			Dictionary<string, object> metadata = new Dictionary<string, object>
			{
				{
					"levelDataId",
					MatchInfo.instance.CurrentLevelData.Id
				},
				{
					"mapGeneratorVersion",
					MatchInfo.instance.CurrentLevelData.MapGeneratorVersion
				},
				{
					"currentCycle",
					LTFunctionLibrary.GetCyclesManager().CurrentCycle
				},
				{
					"currentTime",
					LTFunctionLibrary.GetTimeManager().GetTimeSeconds()
				}
			};
			SaveSystem.instance.SaveGame(metadata);
			ExitToMainMenu();
		};
		string localizedString = LocalizationSettings.StringDatabase.GetLocalizedString("UI_InGame", "UI_InGame_pause_modalWindow_saveAndExit_body", null, FallbackBehavior.UseProjectSettings);
		base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, null);
	}

	public void OnExitButtonPressed()
	{
		ExitToMainMenu();
	}
}
