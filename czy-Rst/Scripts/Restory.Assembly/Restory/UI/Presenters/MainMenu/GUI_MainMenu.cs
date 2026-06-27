using System;
using System.Linq;
using Restory.AssetManagement.References;
using Restory.Data.GameConfigs;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.UI.Presenters.ConfirmationDialog;
using Restory.UI.Presenters.SettingsMenu;
using Restory.UI.Views.MainMenu;
using Restory.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Restory.UI.Presenters.MainMenu
{
	public class GUI_MainMenu : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private GUI_MainMenuView view;

		[SerializeField]
		private GUI_SettingsMenu settingsMenu;

		[SerializeField]
		private GUI_ConfirmationDialog confirmationDialog;

		[SerializeField]
		private GUI_DataCollectionNoticeNotification dataCollectionNoticeNotification;

		[SerializeField]
		private string confirmationDialogNameGameLocID = "UI_CONFIRMATION_DIALOGUE_NEW_GAME";

		[SerializeField]
		private GameMode gameplayMode;

		[SerializeField]
		private GameScenesAssetRef gamePresetToLoadRef;

		[SerializeField]
		private GameScenesAssetRef disclaimerPresetToLoadRef;

		private GlobalStateMachine stateMachine;

		private IReadWriteDataService saveSystem;

		private PlayerProfileService profileService;

		private GameConfig gameConfig;

		[Inject]
		private void Construct(GlobalStateMachine stateMachine, IReadWriteDataService saveSystem, GameConfig gameConfig, PlayerProfileService profileService)
		{
			this.stateMachine = stateMachine;
			this.saveSystem = saveSystem;
			this.gameConfig = gameConfig;
			this.profileService = profileService;
		}

		private void OnEnable()
		{
			SubscribeToClicks();
		}

		private void OnDisable()
		{
			if (view.MonoShellExists())
			{
				UnsubscribeFromClicks();
			}
		}

		public void Initialize()
		{
			UpdateButtonsVisibility();
			dataCollectionNoticeNotification.Initialize();
		}

		public void Dispose()
		{
			dataCollectionNoticeNotification.Dispose();
		}

		private void SubscribeToClicks()
		{
			view.OnContinueClick += ResolveContinueMenu;
			view.OnNewGameClick += ResolveNewGameMenu;
			view.OnSettingsClick += ResolveLanguageMenu;
			view.OnQuitClick += ResolveQuitMenu;
		}

		private void UnsubscribeFromClicks()
		{
			view.OnContinueClick -= ResolveContinueMenu;
			view.OnNewGameClick -= ResolveNewGameMenu;
			view.OnSettingsClick -= ResolveLanguageMenu;
			view.OnQuitClick -= ResolveQuitMenu;
		}

		private void NewGame()
		{
			UnsubscribeFromClicks();
			profileService.BackupSaveData();
			profileService.DeleteGameProgress(profileService.CurrentProfile);
			stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(disclaimerPresetToLoadRef);
		}

		private void UpdateButtonsVisibility()
		{
			bool flag = SupportsInFileConfig();
			view.ContinueButtonVisibility = flag && SaveFileExists();
			view.NewButtonVisibility = flag;
		}

		private bool SupportsInFileConfig()
		{
			bool result = false;
			GameConfig.PresetActivationRuleset presetActivationRuleset = gameConfig.PresetActivationRulesets.FirstOrDefault((GameConfig.PresetActivationRuleset x) => x.Mode == gameplayMode);
			if (presetActivationRuleset != null)
			{
				result = presetActivationRuleset.Platforms.GetSupportedStatus();
			}
			return result;
		}

		private bool SaveFileExists()
		{
			return saveSystem.SaveFileExists(new SaveFileNameParameters(gameplayMode, profileService.CurrentProfile));
		}

		private void ResolveContinueMenu()
		{
			UnsubscribeFromClicks();
			stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(gamePresetToLoadRef);
		}

		private void ResolveNewGameMenu()
		{
			if (SaveFileExists())
			{
				confirmationDialog.Show(confirmationDialogNameGameLocID, NewGame, confirmationDialog.Hide);
			}
			else
			{
				NewGame();
			}
		}

		private void ResolveLanguageMenu()
		{
			settingsMenu.Show();
		}

		private void ResolveQuitMenu()
		{
			UnsubscribeFromClicks();
			Addressables.ClearResourceLocators();
			Resources.UnloadUnusedAssets();
			Application.Quit();
		}
	}
}
