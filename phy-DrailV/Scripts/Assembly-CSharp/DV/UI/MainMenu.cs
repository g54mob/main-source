using System;
using System.Linq;
using DV.Common;
using DV.UI.PresetEditors;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class MainMenu : SingletonBehaviour<MainMenu>
	{
		public MainMenuController controller;

		public AMainMenuProvider provider;

		private void Start()
		{
			controller.SetProvider(provider);
			SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true);
			QualitySettings.antiAliasing = 8;
			if (PreferencesUtils.IsExcluded(Preferences.FrameLimit) || GamePreferences.Get<int>(Preferences.FrameLimit) != 0)
			{
				Application.targetFrameRate = Screen.currentResolution.refreshRate;
			}
			Resources.UnloadUnusedAssets();
			GC.Collect();
			if (RailTrack.pointSets != null && RailTrack.pointSets.Count != 0)
			{
				Debug.LogError(string.Format("There are {0} pointsets leftover in {1}.{2}", RailTrack.pointSets.Count, "RailTrack", "pointSets"));
			}
			SetupListeners(on: true);
			if (DevUtil.IsDevMachine())
			{
				try
				{
					CheckCommandLine();
				}
				catch (Exception ex)
				{
					Debug.LogError("Error parsing command line arguments: " + ex.Message);
					Debug.LogException(ex);
				}
			}
		}

		private void CheckCommandLine()
		{
			string text = Bootstrap.commandLineArgs.FirstOrDefault((string arg) => arg.StartsWith("-continueGame"));
			string text2 = Bootstrap.commandLineArgs.FirstOrDefault((string arg) => arg.StartsWith("-startGame"));
			if (!string.IsNullOrEmpty(text))
			{
				string[] array = text.Split(':');
				if (array.Length != 2)
				{
					throw new ArgumentException("'-continueGame:[GAMEMODE]' expected, got '" + text + "'");
				}
				string text3 = array[1].ToLower();
				if (text3 == "Career".ToLower())
				{
					text3 = "Career";
				}
				else
				{
					if (!(text3 == "FreeRoam".ToLower()))
					{
						throw new ArgumentException("Invalid game mode '" + text3 + "'");
					}
					text3 = "FreeRoam";
				}
				IGameSession gameSession = SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSessionPerMode[text3];
				if (gameSession == null)
				{
					throw new ArgumentException("There are no sessions for mode " + text3);
				}
				if (gameSession.LatestSave == null)
				{
					throw new ArgumentException("Session " + gameSession.Name + " doesn't have any saves");
				}
				OnContinueGameRequested(gameSession.LatestSave);
			}
			else
			{
				if (string.IsNullOrEmpty(text2))
				{
					return;
				}
				string[] array2 = text2.Split(':');
				if (array2.Length != 2)
				{
					throw new ArgumentException("'-startGame:[GAMEMODE]' expected, got '" + text + "'");
				}
				string text4 = DateTime.Now.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
				string text5 = array2[1];
				if (text5.ToLower() == "FreeRoam".ToLower())
				{
					UIStartGameData fallbackData = AStartGameData.GetFallbackData("Free roam via command line " + text4, isCareer: false);
					OnStartNewGameRequested(fallbackData);
					return;
				}
				if (!(text5.ToLower() == "Career".ToLower()))
				{
					throw new ArgumentException("Invalid game mode '" + text5 + "'");
				}
				UIStartGameData fallbackData2 = AStartGameData.GetFallbackData("Career via command line " + text4, isCareer: true);
				OnStartNewGameRequested(fallbackData2);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				controller.StartNewGameRequested += OnStartNewGameRequested;
				controller.ContinueGameRequested += OnContinueGameRequested;
				controller.QuitRequested += OnQuitRequested;
			}
			else
			{
				controller.StartNewGameRequested -= OnStartNewGameRequested;
				controller.ContinueGameRequested -= OnContinueGameRequested;
				controller.QuitRequested -= OnQuitRequested;
			}
		}

		private void OnStartNewGameRequested(UIStartGameData data)
		{
			AStartGameData.FromUIData(data).MakeCurrent();
			LoadGame();
		}

		private void OnContinueGameRequested(ISaveGame saveGame)
		{
			AStartGameData.Continue(saveGame, useSessionDifficulty: true).MakeCurrent();
			LoadGame();
		}

		private void LoadGame()
		{
			SceneSwitcher.SwitchToScene(DVScenes.Game);
		}

		public static void GoBackToMainMenu()
		{
			SceneSwitcher.SwitchToScene(DVScenes.MainMenu);
		}

		private void OnQuitRequested()
		{
			if (SingletonBehaviour<GamePreferences>.Instance.IsDirty)
			{
				GamePreferences.SavePreferences();
			}
			SceneSwitcher.QuitGame();
		}
	}
}
