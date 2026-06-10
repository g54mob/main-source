using System;
using System.Collections.Generic;
using Controller;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval
{
	public class InGameMenuView : ClosableUIView
	{
		[SerializeField]
		private SoundButton heraldryButton;

		[SerializeField]
		private SoundButton resumeButton;

		[SerializeField]
		private SoundButton optionsButton;

		[SerializeField]
		private SoundButton saveButton;

		[SerializeField]
		private SoundButton loadButton;

		[SerializeField]
		private SoundButton quitToMainMenuButton;

		[SerializeField]
		private SoundButton quitGameButton;

		[SerializeField]
		private TMP_Text seedNumber;

		private bool menuActive;

		public bool MenuActive => menuActive;

		public override void Show()
		{
			MonoSingleton<UIClosableController>.Instance.CloseAll();
			MonoSingleton<UIController>.Instance.CloseAllPanels();
			base.Show();
			if (!MenuActive)
			{
				PauseGame();
			}
			seedNumber.SetText(MonoSingleton<LocalizationController>.Instance.GetText("map_seed") + ": " + GlobalSaveController.CurrentVillageData.MapSeed);
		}

		private void PauseGame()
		{
			menuActive = true;
			MonoSingleton<UIController>.Instance.OnMenuPause();
			MonoSingleton<GameplayPauseManager>.Instance.Register(this);
		}

		protected override void CloseSelf()
		{
			Hide();
			ResumeGame();
		}

		private void ResumeGame()
		{
			menuActive = false;
			MonoSingleton<UIController>.Instance.OnMenuResume();
			MonoSingleton<GameplayPauseManager>.Instance.Unregister(this);
		}

		private void LoadMainMenu()
		{
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true, showLoadingBar: false);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(LoadHomeSceneDelayed);
		}

		private void LoadHomeSceneDelayed()
		{
			MonoSingleton<GlobalShaderVariables>.Instance.HideForbiddenZone();
			MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
			Hide();
			MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadHomeScene();
		}

		private void QuitGame()
		{
			Log.Info("Quitting to OS from In-Game Menu", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InGameMenuView.cs");
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			MonoSingleton<GlobalShaderVariables>.Instance.HideForbiddenZone();
			MonoSingleton<CameraManager>.Instance.SetBackground(showLowRes: false);
			MonoSingleton<TaskController>.Instance.Stop();
			MonoSingleton<SceneController>.Instance.enabled = false;
			Application.Quit();
		}

		private void Start()
		{
			resumeButton.onClick.AddListener(CloseSelf);
			optionsButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("OptionsView");
			});
			heraldryButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("HeraldryContentView");
			});
			saveButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("SaveView");
			});
			loadButton.onClick.AddListener(delegate
			{
				base.SceneUIManager.ShowNewView("LoadGameView");
			});
			quitToMainMenuButton.onClick.AddListener(delegate
			{
				OnGameLeave(LoadMainMenu);
			});
			quitGameButton.onClick.AddListener(delegate
			{
				OnGameLeave(QuitGame);
			});
			saveButton.gameObject.SetActive(!TutorialManager.IsTutorialActive);
			loadButton.gameObject.SetActive(!TutorialManager.IsTutorialActive);
		}

		protected override void OnDestroy()
		{
			resumeButton.onClick?.RemoveAllListeners();
			optionsButton.onClick?.RemoveAllListeners();
			heraldryButton.onClick?.RemoveAllListeners();
			saveButton.onClick?.RemoveAllListeners();
			loadButton.onClick?.RemoveAllListeners();
			quitToMainMenuButton.onClick?.RemoveAllListeners();
			quitGameButton.onClick?.RemoveAllListeners();
			base.OnDestroy();
		}

		private void OnGameLeave(Action call)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", call),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("quit_prompt_info", buttonActions));
		}
	}
}
