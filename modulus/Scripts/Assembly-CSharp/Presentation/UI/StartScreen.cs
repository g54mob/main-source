#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using System.IO;
using Data.FeatureFlags.Validators;
using Data.Variables;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory.Map;
using Presentation.Gametester;
using Presentation.Locators;
using Presentation.UI.LoadingScreen;
using Presentation.UI.Menus;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;
using Utils.SceneHandling;

namespace Presentation.UI
{
	public class StartScreen : MonoBehaviour
	{
		[SerializeField]
		private Button _newGameButton;

		[SerializeField]
		private Button _newZenGameButton;

		[SerializeField]
		private Button _continueButton;

		[SerializeField]
		private GameObject _continueIsOldMapContainer;

		[SerializeField]
		private Button _loadButton;

		[SerializeField]
		private Button _settingsButton;

		[SerializeField]
		private Button _manualButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private GameObject _GDPRPanel;

		[SerializeField]
		private GameObject _WIPDisclaimerPanel;

		[SerializeField]
		private GameObject _playtestDisclaimerPanel;

		[SerializeField]
		private GameObject _mainMenuPanel;

		[SerializeField]
		private GameObject _gameTesterPanel;

		[SerializeField]
		private LoadingScreenSO _loadingScreenSO;

		[SerializeField]
		private FeatureFlagValidator _useGameTesterValidator;

		[SerializeField]
		private FeatureFlagValidator _playtestValidator;

		[SerializeField]
		private FeatureFlagValidator _kioskValidator;

		[SerializeField]
		private SaveFileUtils _saveFileUtils;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _loadMenuLocator;

		[SerializeField]
		private UIMenuLocator _createSaveMenuLocator;

		[SerializeField]
		private UIMenuLocator _createSaveWithMapSelectionMenuLocator;

		[SerializeField]
		private UIMenuLocator _settingsMenuLocator;

		[SerializeField]
		private UIMenuLocator _manualMenuLocator;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private SaveInfoToLoadSO _saveInfoToLoad;

		[SerializeField]
		private MapOverrider _mapOverrider;

		[SerializeField]
		private IntEvent _deletedSaveFileEvent;

		[SerializeField]
		private SaveFileUtils _saveFileUtilsSO;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		[SerializeField]
		private GameObject _supportersEditionBanners;

		[SerializeField]
		private GameObject _regularDrone;

		[SerializeField]
		private GameObject _supportersEditionDrone;

		private List<SaveFile> _saveFiles = new List<SaveFile>();

		private void Start()
		{
			SetSaveLoadButtons();
			if (_useGameTesterValidator.IsEnabledFeatureFlag())
			{
				_gameTesterPanel.SetActive(!GametesterGGManager.IsUnlocked);
			}
			if (_playtestValidator.IsEnabledFeatureFlag())
			{
				if (PlayerPrefs.GetInt("Disclaimer202502") != 0)
				{
					ShowMainMenu();
				}
				else
				{
					_playtestDisclaimerPanel.SetActive(value: true);
				}
			}
			else if (_kioskValidator.IsEnabledFeatureFlag())
			{
				_WIPDisclaimerPanel.SetActive(value: true);
			}
			else
			{
				ShowMainMenu();
			}
			if (_integrationManagerLocator.Integration.IsSupportersEdition())
			{
				ShowSupportersEditionAssets();
			}
		}

		private void ShowSupportersEditionAssets()
		{
			_supportersEditionBanners.SetActive(value: true);
			_regularDrone.SetActive(value: false);
			_supportersEditionDrone.SetActive(value: true);
		}

		private void SetSaveLoadButtons()
		{
			_saveFiles = _saveFileUtils.GetSaveFilesOrBackup();
			SaveFile? saveFile = null;
			foreach (SaveFile saveFile2 in _saveFiles)
			{
				if (SaveDirectoryVersionsHandler.CanHandle(saveFile2) && (!DemoUtils.IsDemo() || saveFile2.Info.IsDemoSave))
				{
					saveFile = saveFile2;
					break;
				}
			}
			if (Directory.Exists(SaveSystem.AutoSavePath) && _saveFileUtilsSO.TryGetSaveFile("AutoSave", SaveSystem.AutoSavePath, out var outSaveFile) && (!DemoUtils.IsDemo() || outSaveFile.Info.IsDemoSave) && (!saveFile.HasValue || outSaveFile.Info.LastModifiedTime.Ticks > saveFile.Value.Info.LastModifiedTime.Ticks))
			{
				saveFile = outSaveFile;
			}
			if (saveFile.HasValue)
			{
				_currentSavePath.SetValue(saveFile.Value.Path);
				_continueButton.gameObject.SetActive(value: true);
				_continueIsOldMapContainer.SetActive(saveFile.Value.Info.IsMapOld);
				_loadButton.gameObject.SetActive(value: true);
			}
			else
			{
				_continueButton.gameObject.SetActive(value: false);
				_continueIsOldMapContainer.SetActive(value: false);
				_loadButton.gameObject.SetActive(value: false);
			}
		}

		private void OnDeletedSaveFile(int saveCount)
		{
			SetSaveLoadButtons();
		}

		private void Awake()
		{
			_newGameButton.onClick.AddListener(OnNewGameButtonClicked);
			_newZenGameButton.onClick.AddListener(OnNewZenGameButtonClicked);
			_continueButton.onClick.AddListener(OnContinueButtonClicked);
			_loadButton.onClick.AddListener(OnLoadButtonClicked);
			_settingsButton.onClick.AddListener(OnSettingsButtonClicked);
			_manualButton.onClick.AddListener(OnManualButtonClicked);
			_deletedSaveFileEvent.Register(OnDeletedSaveFile);
		}

		private void OnDestroy()
		{
			_newGameButton.onClick.RemoveListener(OnNewGameButtonClicked);
			_newZenGameButton.onClick.RemoveListener(OnNewZenGameButtonClicked);
			_continueButton.onClick.RemoveListener(OnContinueButtonClicked);
			_loadButton.onClick.RemoveListener(OnLoadButtonClicked);
			_settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
			_manualButton.onClick.RemoveListener(OnManualButtonClicked);
			_deletedSaveFileEvent.UnRegister(OnDeletedSaveFile);
		}

		private void OnContinueButtonClicked()
		{
			if (Directory.Exists(SaveSystem.AutoSavePath) && _saveFileUtilsSO.TryGetSaveFile("AutoSave", SaveSystem.AutoSavePath, out var outSaveFile))
			{
				if (_saveFiles.Count == 0 || outSaveFile.Info.LastModifiedTime.Ticks > _saveFiles[0].Info.LastModifiedTime.Ticks)
				{
					OverrideMapOrLoadFactory(outSaveFile);
					return;
				}
				this.Log($"Autosave isn't the latest saved savegame {outSaveFile.Info.LastModifiedTime} vs {_saveFiles[0].Info.LastModifiedTime}", "OnContinueButtonClicked", 195);
			}
			this.Log("Load non autosave game", "OnContinueButtonClicked", 199);
			OverrideMapOrLoadFactory(_saveFiles[0]);
		}

		private void OverrideMapOrLoadFactory(SaveFile saveFile)
		{
			_saveInfoToLoad.SetPathToLoad(saveFile.Path);
			if (!saveFile.Info.IsMapOld)
			{
				LoadFactory();
				return;
			}
			MenuModalDialogDto dto = new MenuModalDialogDto("LoadSave.ModalTitleOverrideMap", "LoadSave.ModalTextOverrideMap", Sizes.S, delegate
			{
				OverrideSave(saveFile);
			}, showCancelButton: true, LoadFactory)
			{
				OverrideSuccessButtonTextKey = "LoadSave.ModalButtonOverrideMap",
				OverrideCancelButtonTextKey = "LoadSave.ModalButtonDontConvert"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void OverrideSave(SaveFile saveFile)
		{
			_mapOverrider.TryOverrideLevel(saveFile.Path, saveFile.Info.MapName);
			_continueIsOldMapContainer.SetActive(value: false);
			_showUIMenuEvent.Fire(new UIMenuMenuData(_loadMenuLocator.UIMenu));
			_saveFiles = _saveFileUtils.GetSaveFilesOrBackup();
		}

		private void LoadFactory()
		{
			_loadingScreenSO.ShowLoadingScreen(showProgressBar: true);
			SceneHandler.Instance.LoadScene("Factory");
		}

		private void OnLoadButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_loadMenuLocator.UIMenu));
		}

		private void OnNewGameButtonClicked()
		{
			_showUIMenuEvent.Fire(new NewGameUIMenuData(_createSaveMenuLocator.UIMenu));
		}

		private void OnNewZenGameButtonClicked()
		{
			_showUIMenuEvent.Fire(new NewGameUIMenuData(_createSaveMenuLocator.UIMenu, zenMode: true));
		}

		private void OnSettingsButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_settingsMenuLocator.UIMenu));
		}

		private void OnManualButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIPageMenuData(_manualMenuLocator.UIMenu));
		}

		public void ShowMainMenu()
		{
			_mainMenuPanel.SetActive(value: true);
			(_mainMenuPanel.transform as RectTransform).ForceUpdateRectTransforms();
		}

		public void GameTesterPanelHidden()
		{
			if (_playtestValidator.IsEnabledFeatureFlag())
			{
				_playtestDisclaimerPanel.SetActive(value: true);
			}
			else
			{
				ShowMainMenu();
			}
		}
	}
}
