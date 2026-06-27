using System;
using System.Linq;
using Restory.AssetManagement.References;
using Restory.Data.GameConfigs;
using Restory.Data.Locations;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Observers;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using Restory.UserInterface.ConfirmationDialogues;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.GameplayMenu
{
	public class GUI_StartNewGameButton : MonoBehaviour, IInitializable, IDisposable
	{
		[Header("General settings")]
		[SerializeField]
		private string warningMessageLocalizationId = "<AWESOME_ID>";

		[SerializeField]
		private Button button;

		[SerializeField]
		[Tooltip("Preset which start long way to destinationPreset. \nExample: WarningScreen -> CGI Screen -> <DestinationPreset>")]
		private GameScenesAssetRef nextPresetToLoadRef;

		[SerializeField]
		[Tooltip("Final point. Used to check existing save data")]
		private GameMode gameplayMode;

		private GlobalStateMachine stateMachine;

		private GameConfig gameConfig;

		private PlayerProfileService playerProfileService;

		private PlayerProfileChangeObserver playerProfileChangeObserver;

		private GameObject confirmationDialogue;

		private void Awake()
		{
			if (button == null)
			{
				TryGetComponent<Button>(out button);
			}
		}

		private void OnEnable()
		{
			if ((bool)button)
			{
				button.onClick.AddListener(ShowDialogueWindow);
			}
		}

		private void OnDisable()
		{
			if ((bool)button)
			{
				button.onClick.RemoveAllListeners();
			}
		}

		[Inject]
		private void Construct(GlobalStateMachine stateMachine, GameConfig gameConfig, PlayerProfileService playerProfileService, PlayerProfileChangeObserver playerProfileChangeObserver, [Inject(Id = "MainMenuWindow")] GameObject confirmationDialogue)
		{
			this.stateMachine = stateMachine;
			this.gameConfig = gameConfig;
			this.confirmationDialogue = confirmationDialogue;
			this.playerProfileChangeObserver = playerProfileChangeObserver;
			this.playerProfileService = playerProfileService;
			playerProfileChangeObserver.AddSubscriber(this, UpdateState);
		}

		public void Initialize()
		{
			UpdateState();
		}

		public void Dispose()
		{
		}

		private void OnDestroy()
		{
			playerProfileChangeObserver?.RemoveSubscriber(this);
			stateMachine = null;
			gameConfig = null;
			playerProfileChangeObserver = null;
			confirmationDialogue = null;
			button = null;
		}

		private void UpdateState()
		{
			bool active = SupportsInFileConfig();
			base.gameObject.SetActive(active);
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

		private void ShowDialogueWindow()
		{
			GUI_ConfirmationDialog component;
			if (!playerProfileService.GameProgressExists())
			{
				StartNewGame();
			}
			else if (confirmationDialogue.TryGetComponent<GUI_ConfirmationDialog>(out component))
			{
				component.ShowLocalizedMessage(warningMessageLocalizationId, OnPositiveClick);
			}
		}

		private void OnPositiveClick()
		{
			playerProfileService.BackupSaveData();
			playerProfileService.DeleteGameProgress(playerProfileService.CurrentProfile);
			StartNewGame();
		}

		private void StartNewGame()
		{
			if (stateMachine == null)
			{
				Debug.LogError("IAF Error: [GUI_GameModeLoadButton] tried to make the game state machine enter LoadPresetListState, but the state machine is null! Probably missed installation process for scene: " + SceneManager.GetActiveScene().name, base.gameObject);
			}
			else
			{
				stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(nextPresetToLoadRef);
			}
		}
	}
}
