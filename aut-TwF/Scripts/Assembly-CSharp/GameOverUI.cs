using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class GameOverUI : HUDMenu
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
		endGameInfoUI.UpdateData();
	}

	public void OnRestartButtonPressed()
	{
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
}
