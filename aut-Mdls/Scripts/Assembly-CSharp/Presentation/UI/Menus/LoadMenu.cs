#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using System.IO;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory;
using Logic.Factory.Map;
using Presentation.UI.LoadingScreen;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using Presentation.UI.SaveUI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Utils.Enums;
using Utils.SceneHandling;

namespace Presentation.UI.Menus
{
	public class LoadMenu : GamecontrolMenu
	{
		[Header("Purpose")]
		[SerializeField]
		private bool _actAsSaveMenu;

		[SerializeField]
		private bool _isStartScene;

		[Header("Refs")]
		[SerializeField]
		private Button _backButton;

		[SerializeField]
		private LoadAndSaveFileButton loadAndSaveFileButtonPrefab;

		[SerializeField]
		private Transform _buttonsParent;

		[SerializeField]
		private Toggle _devMapsToggle;

		[SerializeField]
		private SaveFileUtils _saveFileUtilsSO;

		[SerializeField]
		private MapOverrider _mapOverrider;

		[SerializeField]
		private string _factoryScene = "Factory";

		[SerializeField]
		private string _emptyScene = "Empty";

		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[Header("Saving")]
		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private SavingSpinnerSO _savingSpinnerSO;

		[SerializeField]
		private GameObject _newSaveButtonContainer;

		[SerializeField]
		private Button _newSaveButton;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private UIMenuLocator _createSaveMenuUILocator;

		[Header("Loading")]
		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private LoadingScreenSO _loadingScreenSO;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private SaveInfoToLoadSO _saveInfoToLoad;

		[SerializeField]
		private Transform _autoSaveParent;

		[SerializeField]
		private IntEvent _deletedSaveFileEvent;

		[Header("Save Info Section")]
		[SerializeField]
		private GameObject _infoSection;

		[SerializeField]
		private Button _loadOrSaveButton;

		[SerializeField]
		private TextMeshProUGUI _loadOrSaveButtonText;

		[SerializeField]
		private Button _overrideMapButton;

		[SerializeField]
		private GameObject _overrideMapContainer;

		[SerializeField]
		private TextMeshProUGUI _nameText;

		[SerializeField]
		private TextMeshProUGUI _modifiedText;

		[SerializeField]
		private TextMeshProUGUI _playtimeText;

		[SerializeField]
		private RawImage _savePreviewImage;

		[SerializeField]
		private Color _saveNameColorDefault;

		[SerializeField]
		private Color _autosaveNameColor;

		private bool _isDevEnvironment;

		private string _currentFullSavePath;

		private SaveInfoPersistentSO _currentSaveFileInfo;

		private readonly List<LoadAndSaveFileButton> _loadAndSaveButtons = new List<LoadAndSaveFileButton>();

		private LoadAndSaveFileButton _activeLoadAndSaveButton;

		private List<SaveFile> _saveFiles;

		private SaveFile? _currentSaveFile;

		public bool IsStartScene => _isStartScene;

		private string GetSavePath()
		{
			if (!_isDevEnvironment || !_devMapsToggle.isOn)
			{
				return SaveSystem.GetFullSavePathForFileName("Levels");
			}
			return SaveSystem.GetFullStreamingAssetPathForFileName("Levels");
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			_isDevEnvironment = false;
			_devMapsToggle.gameObject.SetActive(value: false);
			_devMapsToggle.isOn = false;
			if (Application.isEditor || Debug.isDebugBuild)
			{
				_isDevEnvironment = true;
				_devMapsToggle.gameObject.SetActive(value: true);
			}
			_devMapsToggle.onValueChanged.AddListener(OnToggle);
			_backButton.onClick.AddListener(base.GoBack);
			_loadOrSaveButton.onClick.AddListener(LoadOrSaveFile);
			_overrideMapButton.onClick.AddListener(OverrideMap);
			_newSaveButton.onClick.AddListener(CreateNewSave);
			_titleText.SetText(LocalizationUtility.GetLocalizedText(_actAsSaveMenu ? "LoadSave.SaveScreenTitle" : "LoadSave.LoadScreenTitle"));
			_loadOrSaveButtonText.SetText(LocalizationUtility.GetLocalizedText(_actAsSaveMenu ? "LoadSave.ButtonOverwriteSave" : "LoadSave.ButtonLoad"));
			DestroyOldButtons();
			SpawnLoadOrSaveButtons();
			_scrollRect.verticalNormalizedPosition = 1f;
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_devMapsToggle.onValueChanged.RemoveListener(OnToggle);
			_backButton.onClick.RemoveListener(base.GoBack);
			_loadOrSaveButton.onClick.RemoveListener(LoadOrSaveFile);
			_overrideMapButton.onClick.RemoveListener(OverrideMap);
			_newSaveButton.onClick.RemoveListener(CreateNewSave);
		}

		private void CreateNewSave()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_createSaveMenuUILocator.UIMenu));
			(_createSaveMenuUILocator.UIMenu as CreateSaveMenu).SetShowDevMapToggleState(_devMapsToggle.isOn && _isDevEnvironment);
		}

		private void OnToggle(bool devMaps)
		{
			DestroyOldButtons();
			SpawnLoadOrSaveButtons();
		}

		private void DestroyOldButtons()
		{
			for (int num = _buttonsParent.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_buttonsParent.transform.GetChild(num).gameObject);
			}
			_loadAndSaveButtons.Clear();
			if (_autoSaveParent.childCount > 0)
			{
				UnityEngine.Object.Destroy(_autoSaveParent.GetChild(0).gameObject);
			}
		}

		private void SpawnLoadOrSaveButtons(bool skipGettingSaves = false)
		{
			_autoSaveParent.gameObject.SetActive(value: false);
			if (!skipGettingSaves)
			{
				_saveFiles = _saveFileUtilsSO.GetSaveFilesInDirectory(GetSavePath());
			}
			if (_actAsSaveMenu)
			{
				SpawnSaveButtons();
			}
			else
			{
				SpawnLoadButtons();
			}
		}

		private void SpawnSaveButtons()
		{
			_newSaveButtonContainer.SetActive(value: true);
			_autoSaveParent.gameObject.SetActive(value: false);
			bool foundCurrentSaveFile = false;
			foundCurrentSaveFile = SpawnRegularSaveGameButtons(foundCurrentSaveFile);
			if (!TrySelectAutoSavesOriginalSavegame(foundCurrentSaveFile))
			{
				if (_saveFiles.Count > 0)
				{
					ShowButtonAsSelected(_loadAndSaveButtons[0], _saveFiles[0]);
				}
				else
				{
					_infoSection.SetActive(value: false);
				}
			}
		}

		private void SpawnLoadButtons()
		{
			_newSaveButtonContainer.SetActive(value: false);
			bool foundCurrentSaveFile = false;
			foundCurrentSaveFile = SpawnRegularSaveGameButtons(foundCurrentSaveFile);
			if (!SpawnAutoSaveButton(foundCurrentSaveFile))
			{
				if (_saveFiles.Count > 0)
				{
					ShowButtonAsSelected(_loadAndSaveButtons[0], _saveFiles[0]);
					_currentSaveFile = _saveFiles[0];
				}
				else
				{
					_infoSection.SetActive(value: false);
				}
			}
		}

		private void ShowButtonAsSelected(LoadAndSaveFileButton loadAndSaveButton, SaveFile saveFile, bool isAutosave = false)
		{
			_activeLoadAndSaveButton = loadAndSaveButton;
			_activeLoadAndSaveButton.gameObject.SetActive(value: true);
			loadAndSaveButton.IsActive = true;
			ShowSaveFileInfo(loadAndSaveButton, saveFile, isAutosave);
		}

		private bool SpawnRegularSaveGameButtons(bool foundCurrentSaveFile)
		{
			foreach (SaveFile saveFile in _saveFiles)
			{
				LoadAndSaveFileButton loadAndSaveFileButton = UnityEngine.Object.Instantiate(loadAndSaveFileButtonPrefab, _buttonsParent);
				_loadAndSaveButtons.Add(loadAndSaveFileButton);
				if (saveFile.Info != null)
				{
					loadAndSaveFileButton.SetExistingButton(saveFile, saveFile.Name, saveFile.Path, saveFile.Info, this);
				}
				else
				{
					loadAndSaveFileButton.SetExistingButton(saveFile, saveFile.Name, saveFile.Path, this);
				}
				if (CompareSaveNames(_currentSavePath.Value, saveFile.Path))
				{
					ShowButtonAsSelected(loadAndSaveFileButton, saveFile);
					_currentSaveFile = saveFile;
					foundCurrentSaveFile = true;
				}
				else
				{
					loadAndSaveFileButton.IsActive = false;
				}
			}
			return foundCurrentSaveFile;
		}

		private bool TrySelectAutoSavesOriginalSavegame(bool foundCurrentSaveFile)
		{
			if (Directory.Exists(SaveSystem.AutoSavePath) && _saveFileUtilsSO.TryGetSaveFile("AutoSave", SaveSystem.AutoSavePath, out var outSaveFile) && !foundCurrentSaveFile)
			{
				foreach (LoadAndSaveFileButton loadAndSaveButton in _loadAndSaveButtons)
				{
					if (loadAndSaveButton.SaveName.Equals(outSaveFile.Info.AutoSaveSourceSaveName))
					{
						ShowButtonAsSelected(loadAndSaveButton, loadAndSaveButton.SaveFile);
						return true;
					}
				}
			}
			return foundCurrentSaveFile;
		}

		private bool SpawnAutoSaveButton(bool foundSaveFileToShow)
		{
			if (!Directory.Exists(SaveSystem.AutoSavePath))
			{
				_autoSaveParent.gameObject.SetActive(value: false);
				return foundSaveFileToShow;
			}
			if (_saveFileUtilsSO.TryGetSaveFile("AutoSave", SaveSystem.AutoSavePath, out var outSaveFile))
			{
				LoadAndSaveFileButton loadAndSaveFileButton = UnityEngine.Object.Instantiate(loadAndSaveFileButtonPrefab, _buttonsParent);
				_autoSaveParent.gameObject.SetActive(value: true);
				loadAndSaveFileButton.transform.SetParent(_autoSaveParent);
				loadAndSaveFileButton.SetExistingButton(outSaveFile, "AutoSave", SaveSystem.AutoSavePath, outSaveFile.Info, this, isAutosave: true);
				if (CompareSaveNames(_currentSavePath.Value, SaveSystem.AutoSavePath))
				{
					ShowButtonAsSelected(loadAndSaveFileButton, outSaveFile, isAutosave: true);
					_currentSaveFile = outSaveFile;
					foundSaveFileToShow = true;
				}
				return foundSaveFileToShow;
			}
			_autoSaveParent.gameObject.SetActive(value: false);
			return foundSaveFileToShow;
		}

		private bool CompareSaveNames(string path1, string path2)
		{
			return Path.GetFileName(path1) == Path.GetFileName(path2);
		}

		public void ShowSaveFileInfo(LoadAndSaveFileButton loadAndSaveFileButton, SaveFile saveFile, bool isAutoSave = false)
		{
			_currentSaveFile = saveFile;
			_infoSection.SetActive(value: true);
			_currentFullSavePath = saveFile.Path;
			_currentSaveFileInfo = saveFile.Info;
			if (loadAndSaveFileButton != null)
			{
				if (_activeLoadAndSaveButton != null && _activeLoadAndSaveButton != loadAndSaveFileButton)
				{
					_activeLoadAndSaveButton.IsActive = false;
				}
				_activeLoadAndSaveButton = loadAndSaveFileButton;
				_activeLoadAndSaveButton.IsActive = true;
			}
			else
			{
				_activeLoadAndSaveButton.IsActive = false;
			}
			if (saveFile.Info != null)
			{
				TimeSpan timeSpan = TimeSpan.FromMinutes(saveFile.Info.TotalPlayTimeMins);
				_playtimeText.SetText(string.Format(LocalizationUtility.GetLocalizedText("LoadSave.PlayTime"), (int)timeSpan.TotalHours, timeSpan.Minutes));
				_modifiedText.SetText($"{saveFile.Info.LastModifiedTime.ToShortDateString()} {saveFile.Info.LastModifiedTime.ToShortTimeString()}");
			}
			else
			{
				_playtimeText.SetText(string.Format(LocalizationUtility.GetLocalizedText("LoadSave.PlayTime"), "-", "-"));
				_modifiedText.SetText("-");
			}
			bool active = saveFile.Info != null && saveFile.Info.IsMapOld;
			_overrideMapButton.gameObject.SetActive(active);
			_overrideMapContainer.SetActive(active);
			_nameText.color = (isAutoSave ? _autosaveNameColor : _saveNameColorDefault);
			string value = (string.IsNullOrEmpty(saveFile.Info.GetDisplaySaveName(saveFile)) ? saveFile.Name : saveFile.Info.GetDisplaySaveName(saveFile));
			_nameText.SetText(isAutoSave ? (LocalizationUtility.GetLocalizedText("AutoSave.Autosave") + "(" + saveFile.Info.AutoSaveSourceSaveName.UnsanitizeSpaces() + ")") : value.UnsanitizeSpaces());
			LoadThumbnail(saveFile.Path);
		}

		private void LoadThumbnail(string saveFilePath)
		{
			string path = Path.Combine(saveFilePath, "Thumbnail.png");
			if (File.Exists(path))
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(2, 2);
				texture2D.LoadImage(data);
				_savePreviewImage.texture = texture2D;
			}
		}

		public void RefreshButtons(bool deletedButtonIsActive)
		{
			DestroyOldButtons();
			_saveFiles = _saveFileUtilsSO.GetSaveFilesInDirectory(GetSavePath());
			_deletedSaveFileEvent.Fire(_saveFiles.Count);
			if (_saveFiles.Count == 0)
			{
				if (!_actAsSaveMenu)
				{
					GoBack();
				}
				return;
			}
			if (deletedButtonIsActive)
			{
				_currentSavePath.SetValue(_saveFiles[0].Path);
				_currentSaveFile = _saveFiles[0];
			}
			SpawnLoadOrSaveButtons(skipGettingSaves: true);
		}

		private bool IsFactoryScene()
		{
			return SceneManager.GetActiveScene().name == _factoryScene;
		}

		private void LoadOrSaveFile()
		{
			if (_activeLoadAndSaveButton != null && !_activeLoadAndSaveButton.SaveInfoPersistentSO.IsDemoSave)
			{
				this.LogError("Won't save or load save files that aren't from the demo", "LoadOrSaveFile", 410);
			}
			else if (_actAsSaveMenu)
			{
				MenuModalDialogDto dto = new MenuModalDialogDto("LoadSave.OverwriteSaveWarning", Sizes.S, SaveFile, showCancelButton: true)
				{
					OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
					OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
				};
				_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
			}
			else if (IsFactoryScene())
			{
				MenuModalDialogDto dto2 = new MenuModalDialogDto("LoadSave.LoadDifferentSaveWarning", Sizes.S, LoadCurrentSavePath, showCancelButton: true)
				{
					OverrideSuccessButtonTextKey = "LoadSave.ButtonLoad",
					OverrideCancelButtonTextKey = "ModalGeneric.CancelButton"
				};
				_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto2));
			}
			else
			{
				LoadCurrentSavePath();
			}
		}

		private void LoadCurrentSavePath()
		{
			this.Log(_currentSavePath.Value, "LoadCurrentSavePath", 442);
			_loadingScreenSO.ShowLoadingScreen(OnLoadingScreenCallback, _currentSaveFile, showProgressBar: true);
		}

		private void OnLoadingScreenCallback(SaveFile? saveFile)
		{
			if (_pauseState != null)
			{
				_pauseState.SetPauseState(active: false);
			}
			_currentSaveFile = saveFile;
			_saveInfoToLoad.SetPathToLoad(_currentFullSavePath);
			if (IsFactoryScene())
			{
				_factoryClearer.ClearLevel();
				SceneHandler.Instance.LoadSceneSimple(_emptyScene, LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum.FinishedLoadingSceneEmpty);
			}
			else
			{
				SceneHandler.Instance.LoadScene(_factoryScene);
			}
		}

		private void SaveFile()
		{
			_savingSpinnerSO.ShowSavingSpinner();
			_factorySaver.SaveFactory(_currentFullSavePath);
			_uiMenuManagerLocator.UIMenuManager.CloseAllOpenMenus();
		}

		private void OverrideMap()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("LoadSave.ModalTitleOverrideMap", "LoadSave.ModalTextOverrideMap", Sizes.S, OverrideSave, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "LoadSave.ModalButtonOverrideMap",
				OverrideCancelButtonTextKey = "LoadSave.ModalButtonDontConvert"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void OverrideSave()
		{
			_mapOverrider.TryOverrideLevel(_currentFullSavePath, _currentSaveFileInfo.MapName);
			RefreshButtons(deletedButtonIsActive: false);
		}
	}
}
