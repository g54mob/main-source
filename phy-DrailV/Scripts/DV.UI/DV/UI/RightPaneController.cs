using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using DV.Common;
using DV.Interaction.Inputs;
using DV.Scenarios.Common;
using DV.UI.PresetEditors;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class RightPaneController : AUIController
	{
		[Header("Controllers")]
		[NullCheck]
		public SettingsController settingsController;

		[NullCheck]
		public SaveLoadController saveLoadController;

		[NullCheck]
		public LauncherController launcherController;

		[NullCheck]
		public UserProfileController userProfileController;

		[NullCheck]
		public InitialScreenController initialScreenController;

		[NullCheck]
		public ContinueLoadNewController continueLoadNewController;

		[NullCheck]
		public ScenarioTopLevelController scenarioTopLevelController;

		[NullCheck]
		public DifficultyController difficultyController;

		[NullCheck]
		public BugReportController bugReportController;

		[Header("UI references")]
		[NullCheck]
		public UIMenuController menuController;

		[NullCheck]
		public GameObject changeUserButton;

		[NullCheck]
		public UIMenu userProfileMenu;

		[NullCheck]
		public ControlMapperSaver controlMapperSaver;

		private ASettingsProvider settingsProvider;

		private AUserProfileProvider userProfileProvider;

		private AScenarioProvider scenarioProvider;

		private ContinueLoadNewControllerSingle lastClickedPanel;

		public event Action<UIStartGameData> StartNewGameRequested;

		public event Action<ISaveGame> ContinueGameRequested;

		public void SetProviders(AMainMenuProvider mainMenuProvider, ASettingsProvider settingsProvider, AUserProfileProvider userProfileProvider, AScenarioProvider scenarioProvider, ABugReportDataProvider bugProvider)
		{
			if ((bool)this.userProfileProvider)
			{
				Util.RunOnce(this, "SetProviders");
				return;
			}
			this.settingsProvider = settingsProvider;
			this.userProfileProvider = userProfileProvider;
			this.scenarioProvider = scenarioProvider;
			NullChecking.NullCheck(settingsProvider, "settingsProvider", this, "SetProviders");
			NullChecking.NullCheck(userProfileProvider, "userProfileProvider", this, "SetProviders");
			NullChecking.NullCheck(scenarioProvider, "scenarioProvider", this, "SetProviders");
			NullChecking.NullCheck(bugProvider, "bugProvider", this, "SetProviders");
			settingsController.SetProvider(settingsProvider);
			saveLoadController.SetProvider(userProfileProvider);
			userProfileController.SetProvider(userProfileProvider);
			initialScreenController.SetProvider(mainMenuProvider, userProfileProvider, scenarioProvider, settingsProvider.IsVR);
			bugReportController.SetProvider(bugProvider);
			if (mainMenuProvider.DefaultMenuIndexOverride.HasValue)
			{
				menuController.defaultMenuIndex = mainMenuProvider.DefaultMenuIndexOverride.Value;
			}
			UpdateLauncher(launcherController);
			userProfileProvider.UserProfileChanged += OnUserProfileChanged;
			RefreshInterface(dueToMenuNavigation: false);
		}

		private void UpdateLauncher(LauncherController launcherController)
		{
			ISaveGame lastPlayedSave = userProfileProvider.GetLastPlayedSave();
			if (lastPlayedSave != null)
			{
				launcherController.SetData(lastPlayedSave, userProfileProvider, scenarioProvider, UpdateLauncher);
			}
			else if (userProfileProvider.CurrentSession != null)
			{
				IGameSession currentSession = userProfileProvider.CurrentSession;
				IScenario scenario = userProfileProvider.GetSessionScenario(currentSession, scenarioProvider.CRUD);
				if (scenario == null)
				{
					scenario = scenarioProvider.CRUD.Scenarios.FirstOrDefault();
				}
				IDifficulty sessionDifficulty = userProfileProvider.GetSessionDifficulty(currentSession);
				launcherController.SetData(new UIStartGameData(currentSession, sessionDifficulty, scenario, skipTutorial: false), userProfileProvider, scenarioProvider, null);
			}
			else
			{
				launcherController.SetData((ISaveGame)null, userProfileProvider, scenarioProvider, (LauncherController.UpdateRequest)UpdateLauncher);
			}
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
			RefreshInterface(dueToMenuNavigation: false);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				menuController.MenuChanged += OnMenuChanged;
				continueLoadNewController.StartNewCareerRequested += SwitchToStartNewCareer;
				continueLoadNewController.StartNewFreeRoamRequested += SwitchToStartNewFreeRoam;
				continueLoadNewController.ContinueCareerRequested += SwitchToContinueCareer;
				continueLoadNewController.ContinueFreeRoamRequested += SwitchToContinueFreeRoam;
				continueLoadNewController.LoadCareerRequested += SwitchToLoadCareer;
				continueLoadNewController.LoadFreeRoamRequested += SwitchToLoadFreeRoam;
				continueLoadNewController.EditDifficultyRequested += SwitchToDifficultyEditor;
				continueLoadNewController.EditScenarioRequested += SwitchToScenarioEditor;
				scenarioTopLevelController.BackRequested += SwitchBackFromScenarioEditor;
				difficultyController.BackRequested += SwitchBackFromDifficultyEditor;
				saveLoadController.LoadRequested += SwitchTo;
				saveLoadController.BackRequested += SwitchBackFromLoad;
				launcherController.StartNewRequested += OnStartNewGameRequested;
				launcherController.ContinueGameRequested += OnContinueGameRequested;
				controlMapperSaver.EnabledChanged += RefreshInterfaceMenuNavigation;
			}
			else
			{
				menuController.MenuChanged -= OnMenuChanged;
				continueLoadNewController.StartNewCareerRequested -= SwitchToStartNewCareer;
				continueLoadNewController.StartNewFreeRoamRequested -= SwitchToStartNewFreeRoam;
				continueLoadNewController.ContinueCareerRequested -= SwitchToContinueCareer;
				continueLoadNewController.ContinueFreeRoamRequested -= SwitchToContinueFreeRoam;
				continueLoadNewController.LoadCareerRequested -= SwitchToLoadCareer;
				continueLoadNewController.LoadFreeRoamRequested -= SwitchToLoadFreeRoam;
				continueLoadNewController.EditDifficultyRequested -= SwitchToDifficultyEditor;
				continueLoadNewController.EditScenarioRequested -= SwitchToScenarioEditor;
				scenarioTopLevelController.BackRequested -= SwitchBackFromScenarioEditor;
				difficultyController.BackRequested -= SwitchBackFromDifficultyEditor;
				saveLoadController.LoadRequested -= SwitchTo;
				saveLoadController.BackRequested -= SwitchBackFromLoad;
				launcherController.StartNewRequested -= OnStartNewGameRequested;
				launcherController.ContinueGameRequested -= OnContinueGameRequested;
				controlMapperSaver.EnabledChanged -= RefreshInterfaceMenuNavigation;
			}
		}

		private void SwitchToStartNewCareer(UIStartGameData data)
		{
			SwitchTo(data);
		}

		private void SwitchToContinueCareer(ISaveGame saveGame)
		{
			SwitchTo(saveGame);
		}

		private void SwitchToContinueFreeRoam(ISaveGame saveGame)
		{
			SwitchTo(saveGame);
		}

		private void SwitchTo(UIStartGameData startGameData)
		{
			launcherController.SetData(startGameData, userProfileProvider, scenarioProvider, null);
			menuController.SwitchMenu(GetMenuIndexFor(launcherController));
		}

		private void SwitchTo(ISaveGame saveGameToContinue)
		{
			launcherController.SetData(saveGameToContinue, userProfileProvider, scenarioProvider, UpdateLauncher);
			menuController.SwitchMenu(GetMenuIndexFor(launcherController));
		}

		private void SwitchToStartNewFreeRoam(UIStartGameData data)
		{
			launcherController.SetData(data, userProfileProvider, scenarioProvider, null);
			menuController.SwitchMenu(GetMenuIndexFor(launcherController));
		}

		private void SwitchToLoadCareer(IGameSession session)
		{
			bool inMainMenu = true;
			saveLoadController.SetData(inMainMenu, null, session);
			menuController.SwitchMenu(GetMenuIndexFor(saveLoadController));
		}

		private void SwitchToLoadFreeRoam(IGameSession session)
		{
			bool inMainMenu = true;
			saveLoadController.SetData(inMainMenu, null, session);
			menuController.SwitchMenu(GetMenuIndexFor(saveLoadController));
		}

		private void SwitchToScenarioEditor(IScenario scenario, ContinueLoadNewControllerSingle eventSource)
		{
			lastClickedPanel = eventSource;
			scenarioTopLevelController.SetData(scenarioProvider, scenario);
			menuController.SwitchMenu(GetMenuIndexFor(scenarioTopLevelController));
		}

		private void SwitchToDifficultyEditor(IDifficulty difficulty, ContinueLoadNewControllerSingle eventSource)
		{
			lastClickedPanel = eventSource;
			difficultyController.SetData(scenarioProvider.CRUD, difficulty, settingsProvider.IsVR);
			menuController.SwitchMenu(GetMenuIndexFor(difficultyController));
		}

		private void SwitchBackFromScenarioEditor(IScenario scenario)
		{
			if (lastClickedPanel == null)
			{
				Debug.LogError("lastClickedPanel can't be null now", this);
				return;
			}
			menuController.SwitchMenuTask(initialScreenController.startMenuIndex).ContinueWith(delegate
			{
				Debug.Log("Returned from scenario editor with '" + scenario?.Name + "'");
				lastClickedPanel.RefreshData();
				lastClickedPanel.ChangeScenario(scenario);
				lastClickedPanel = null;
			}).Forget();
		}

		private void SwitchBackFromDifficultyEditor(IDifficulty difficulty)
		{
			if (lastClickedPanel == null)
			{
				Debug.LogError("lastClickedPanel can't be null now", this);
				return;
			}
			menuController.SwitchMenuTask(initialScreenController.startMenuIndex).ContinueWith(delegate
			{
				Debug.Log("Returned from difficulty editor with '" + difficulty?.Name + "'");
				lastClickedPanel.RefreshData();
				lastClickedPanel.ChangeDifficulty(difficulty);
				lastClickedPanel = null;
			}).Forget();
		}

		private void SwitchBackFromLoad()
		{
			menuController.SwitchMenu(initialScreenController.startMenuIndex);
		}

		private void OnStartNewGameRequested(UIStartGameData data)
		{
			this.StartNewGameRequested?.Invoke(data);
		}

		private void OnContinueGameRequested(ISaveGame saveGame)
		{
			this.ContinueGameRequested?.Invoke(saveGame);
		}

		private void OnUserProfileChanged()
		{
			RefreshInterface(dueToMenuNavigation: false);
			UpdateLauncher(launcherController);
		}

		private void OnMenuChanged(UIMenu _)
		{
			RefreshInterface(dueToMenuNavigation: true);
		}

		private int GetMenuIndexFor(AUIController controller)
		{
			UIMenu component = controller.GetComponent<UIMenu>();
			if (!component)
			{
				throw new Exception(controller.GetType().Name + " is expected to also have a UIMenu component on same gameobject");
			}
			int num = menuController.controlledMenus.IndexOf(component);
			if (num == -1)
			{
				throw new Exception(controller.GetType().Name + " is not a member of '" + menuController.name + "' UIMenuController list of controlled menus");
			}
			return num;
		}

		private void RefreshInterfaceMenuNavigation()
		{
			RefreshInterface(dueToMenuNavigation: true);
		}

		private void RefreshInterface(bool dueToMenuNavigation)
		{
			bool active = menuController.ActiveMenu != null && menuController.ActiveMenu != userProfileMenu && !controlMapperSaver.isActiveAndEnabled;
			changeUserButton.SetActive(active);
			changeUserButton.GetComponent<UserProfileViewElement>().SetData(userProfileProvider?.GetCurrentProfile(), null);
			if ((bool)userProfileProvider && !dueToMenuNavigation)
			{
				initialScreenController.SwitchStartScreen();
			}
		}
	}
}
