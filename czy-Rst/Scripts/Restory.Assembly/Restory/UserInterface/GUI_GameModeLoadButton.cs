using System.Linq;
using JetBrains.Annotations;
using Restory.AssetManagement.References;
using Restory.Data.GameConfigs;
using Restory.Data.Locations;
using Restory.Data.ReadWriteServices.Interfaces;
using Restory.Data.SaveLoad;
using Restory.Infrastructure.StateMachine;
using Restory.Infrastructure.StateMachine.States.InitializationStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_GameModeLoadButton : MonoBehaviour, IInitializable
	{
		[Header("General settings")]
		[SerializeField]
		private Button button;

		[SerializeField]
		[Tooltip("Preset wich start long way to destinationPreset. \nExample: WarningScreen -> CGI Screen -> <DestinationPreset>")]
		private GameScenesAssetRef presetRef;

		[SerializeField]
		private bool checkSaveData = true;

		[SerializeField]
		[Tooltip("Final point. Used to check existing save data")]
		private GameMode gameplayMode;

		private GlobalStateMachine stateMachine;

		private IReadWriteDataService saveSystem;

		private PlayerProfileService profileService;

		private GameConfig gameConfig;

		public GameScenesAssetRef PresetRef => presetRef;

		private void Awake()
		{
			TryGetComponent<Button>(out button);
			if (button != null)
			{
				button.onClick.AddListener(LoadPreset);
			}
		}

		[Inject]
		private void Construct(GlobalStateMachine stateMachine, IReadWriteDataService saveSystem, GameConfig gameConfig, PlayerProfileService profileService)
		{
			this.stateMachine = stateMachine;
			this.saveSystem = saveSystem;
			this.gameConfig = gameConfig;
			this.profileService = profileService;
		}

		public void Initialize()
		{
			bool flag = SupportsInFileConfig();
			if (checkSaveData)
			{
				flag &= SaveFileExists();
			}
			base.gameObject.SetActive(flag);
		}

		[UsedImplicitly]
		public void LoadPreset()
		{
			if (stateMachine == null)
			{
				Debug.LogError("IAF Error: [GUI_GameModeLoadButton] tried to make the game state machine enter LoadPresetListState, but the state machine is null! Probably missed installation process for scene: " + SceneManager.GetActiveScene().name, base.gameObject);
			}
			else
			{
				stateMachine.Enter<StartLoadingPresetListState, GameScenesAssetRef>(presetRef);
			}
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
	}
}
