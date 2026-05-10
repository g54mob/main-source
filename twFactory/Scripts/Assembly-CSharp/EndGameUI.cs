using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class EndGameUI : HUDMenu
{
	[SerializeField]
	private EndGameInfoUI endGameInfoUI;

	[SerializeField]
	private GameObject upgradesButton;

	public override bool BackButtonPressed()
	{
		return true;
	}

	protected override void Start()
	{
		base.Start();
		if ((bool)endGameInfoUI)
		{
			endGameInfoUI.UpdateData();
		}
		if (LTFunctionLibrary.GetLTGameManager().FirstTimeBossDefeated)
		{
			StartCoroutine(ShowBossRewardCoroutine());
		}
	}

	public void OnRestartButtonPressed()
	{
		if (!LTGameManager.wishlistMessageShown && LTGameManager.playedGames == 2)
		{
			ShowWishlistModalWindow(OnRestartButtonPressed);
			LTGameManager.wishlistMessageShown = true;
			return;
		}
		float time = 1f;
		float masterVolume = SettingsController.instance.GetMasterVolume();
		base.Hud.FadeInOut.FadeIn(time, delegate(float timePercentage)
		{
			AudioSystem.Instance.SetMixerVolume(masterVolume - masterVolume * timePercentage, AudioSystem.EAudioMixerGroup.Master);
		}, delegate
		{
			LTFunctionLibrary.GetLTGameManager().RestartGame();
		});
	}

	public void OnUpgradesButtonPressed()
	{
		(base.Hud as LTHUD).ShowUpgradesUI();
	}

	public void OnMainMenuButtonPressed()
	{
		if (!LTGameManager.wishlistMessageShown && LTGameManager.playedGames == 2)
		{
			ShowWishlistModalWindow(OnMainMenuButtonPressed);
			LTGameManager.wishlistMessageShown = true;
			return;
		}
		float time = 1f;
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

	private void ShowWishlistModalWindow(Action noAction)
	{
		string localizedString = new LocalizedString("UI_Common", "UI_Common_modalWindow_addToWishlist").GetLocalizedString();
		string localizedString2 = new LocalizedString("UI_Common", "UI_Common_maybeLater").GetLocalizedString();
		Action yesAction = delegate
		{
			Application.OpenURL("steam://openurl/https://store.steampowered.com/app/2707490/Tower_Factory/");
		};
		base.Hud.ShowModalWindowTwoButtons(localizedString, "", null, yesAction, noAction, "", localizedString2);
	}

	private IEnumerator ShowBossRewardCoroutine()
	{
		yield return new WaitForSecondsRealtime(1f);
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_InGame", "UI_InGame_victory_modalWindow_bossReward_header").Entry.GetLocalizedString();
		string rewardDescription = LTFunctionLibrary.GetMatchInfo().CurrentLevelData.RewardDescription;
		Sprite rewardImage = LTFunctionLibrary.GetMatchInfo().CurrentLevelData.RewardImage;
		string localizedString2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_ok").Entry.GetLocalizedString();
		GameManager.instance.PlayerController.CurrentHUD.ShowModalWindowOneButton(rewardDescription, localizedString, rewardImage, null, localizedString2);
	}
}
