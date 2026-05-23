using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Data.FeatureFlags.Validators;
using Data.SaveData;
using Data.Variables;
using Events.Analytics;
using Logic.Factory;
using NaughtyAttributes;
using Presentation.UI.LoadingScreen;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.SaveUI;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;
using Utils.SceneHandling;

namespace Presentation.UI.Menus
{
	public class CreateSaveMenu : GamecontrolMenu
	{
		[SerializeField]
		private Toggle _devMapsToggle;

		[SerializeField]
		private Button _createButton;

		[SerializeField]
		private Button _backButton;

		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private EnableGameCaptureValidator _enableGameCaptureShortcutsValidator;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private LoadingScreenSO _loadingScreenSO;

		[SerializeField]
		private string _factoryScene;

		[SerializeField]
		private string _startScene;

		[SerializeField]
		private SaveInfoToLoadSO _saveInfoToLoad;

		[SerializeField]
		private TextMeshProUGUI _errorText;

		[SerializeField]
		private SavingSpinnerSO _savingSpinnerSO;

		[SerializeField]
		private SaveFileUtils _saveFileUtils;

		[SerializeField]
		private Image _thumbnailImage;

		[SerializeField]
		private Sprite _thumbnailClassic;

		[SerializeField]
		private Sprite _thumbnailCreative;

		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		[SerializeField]
		private BoolVariableSO _startedTutorialAtLeastOnce;

		[SerializeField]
		private ZenModeVariableSO _zenModeSO;

		[SerializeField]
		private AnalyticsDesignEvent _analyticsDesignEvent;

		[SerializeField]
		private Toggle _showTutorialToggle;

		[SerializeField]
		private ShowTutorialSO showTutorialVariable;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private bool _hasMapSelection;

		[SerializeField]
		[ShowIf("_hasMapSelection")]
		private ToggleGroup _mapSelectionToggleGroup;

		[SerializeField]
		[ShowIf("_hasMapSelection")]
		private List<Toggle> _mapSelectionToggles;

		private bool _isDevEnvironment;

		private InputActionMap _debugActionMap;

		private bool _isDebugActionMapEnabled;

		private readonly List<string> _saveFileNames = new List<string>();

		private readonly List<string> _devSaveFileNames = new List<string>();

		private bool _selectedZenMode;

		private bool _isNewGame;

		private readonly char[] _invalidFileNameChars = Path.GetInvalidFileNameChars();

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			if (menuData is NewGameUIMenuData newGameUIMenuData)
			{
				_isNewGame = true;
				_selectedZenMode = newGameUIMenuData.ZenMode;
			}
			else
			{
				_selectedZenMode = _zenModeSO.Value;
			}
			_thumbnailImage.sprite = (_selectedZenMode ? _thumbnailCreative : _thumbnailClassic);
			_isDevEnvironment = false;
			_devMapsToggle.gameObject.SetActive(value: false);
			_devMapsToggle.isOn = false;
			_inputField.text = string.Empty;
			ResetErrorText();
			if (Application.isEditor || Debug.isDebugBuild)
			{
				_isDevEnvironment = true;
				_devMapsToggle.gameObject.SetActive(value: true);
			}
			_createButton.onClick.AddListener(CreateSave);
			_createButton.interactable = true;
			_backButton.onClick.AddListener(base.GoBack);
			_inputField.onSelect.AddListener(OnInputFieldSelect);
			_inputField.onDeselect.AddListener(OnInputFieldDeSelect);
			_debugActionMap = _inputActionAsset.FindActionMap("Debug");
			_isDebugActionMapEnabled = _debugActionMap.enabled;
			GetExistingSaveFileNames();
			if (SceneManager.GetActiveScene().name != _startScene)
			{
				_showTutorialToggle.gameObject.SetActive(value: false);
			}
			else if (_selectedZenMode)
			{
				_showTutorialToggle.gameObject.SetActive(value: false);
			}
			else
			{
				_showTutorialToggle.gameObject.SetActive(value: true);
				_showTutorialToggle.onValueChanged.AddListener(HandleSkipTutorialChanged);
				HandleSkipTutorialChanged(_showTutorialToggle.isOn);
			}
			_inputField.Select();
			if (_hasMapSelection && _mapSelectionToggles.Count > 0)
			{
				_mapSelectionToggles[0].isOn = true;
			}
		}

		private void HandleSkipTutorialChanged(bool value)
		{
			showTutorialVariable.SetValue(value);
		}

		private void GetExistingSaveFileNames()
		{
			_saveFileNames.Clear();
			_devSaveFileNames.Clear();
			foreach (SaveFile saveFile in _saveFileUtils.GetSaveFiles())
			{
				_saveFileNames.Add(saveFile.Name);
			}
			foreach (SaveFile devSaveFile in _saveFileUtils.GetDevSaveFiles())
			{
				_devSaveFileNames.Add(devSaveFile.Name);
			}
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_showTutorialToggle.onValueChanged.RemoveListener(HandleSkipTutorialChanged);
			_showTutorialToggle.SetIsOnWithoutNotify(value: true);
			_createButton.onClick.RemoveListener(CreateSave);
			_backButton.onClick.RemoveListener(base.GoBack);
			_inputField.onSelect.RemoveListener(OnInputFieldSelect);
			_inputField.onDeselect.RemoveListener(OnInputFieldDeSelect);
			if (_isDebugActionMapEnabled && _enableGameCaptureShortcutsValidator.IsEnabledFeatureFlag())
			{
				_debugActionMap.Enable();
			}
		}

		public void SetShowDevMapToggleState(bool isOn)
		{
			_devMapsToggle.isOn = isOn;
		}

		private string Sanitize(string value)
		{
			string text = value.SanitizeSpaces();
			char[] invalidFileNameChars = _invalidFileNameChars;
			foreach (char c in invalidFileNameChars)
			{
				text = text.Replace(c.ToString(), string.Empty);
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				SetErrorText("LoadSave.InputEmpty");
				text = string.Empty;
			}
			return text;
		}

		private bool ValidateInput(string value, string path, out string sanitizedSaveFileName)
		{
			sanitizedSaveFileName = string.Empty;
			ResetErrorText();
			if (string.IsNullOrWhiteSpace(value))
			{
				SetErrorText("LoadSave.InputEmpty");
				return false;
			}
			if (value.Equals("AutoSave"))
			{
				SetErrorText("LoadSave.InputCanNotBeAutoSave");
				return false;
			}
			string pattern = "[<>;{}[\\]\\\"'\\\\]";
			if (Regex.IsMatch(value, pattern))
			{
				SetErrorText("LoadSave.InputEmpty");
				return false;
			}
			List<string> source = ((_isDevEnvironment && _devMapsToggle.isOn) ? _devSaveFileNames : _saveFileNames);
			sanitizedSaveFileName = Sanitize(value);
			string[] directories = Directory.GetDirectories(path);
			bool flag = false;
			string[] array = directories;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Split('\\', '/')[^1].Equals(sanitizedSaveFileName))
				{
					flag = true;
					break;
				}
			}
			if (source.Contains(sanitizedSaveFileName, StringComparer.OrdinalIgnoreCase) || flag)
			{
				SetErrorText("LoadSave.SaveExists");
				return false;
			}
			return true;
		}

		private void CreateSave()
		{
			string input = _inputField.text.Trim();
			input = Regex.Replace(input, "\\s{2,}", " ");
			string text = ((_isDevEnvironment && _devMapsToggle.isOn) ? SaveSystem.GetFullStreamingAssetPathForFileName("Levels") : SaveSystem.GetFullSavePathForFileName("Levels"));
			if (!ValidateInput(input, text, out var sanitizedSaveFileName) || string.IsNullOrEmpty(sanitizedSaveFileName))
			{
				return;
			}
			text = text + "\\" + sanitizedSaveFileName;
			_createButton.interactable = false;
			if (IsFactoryScene())
			{
				_savingSpinnerSO.ShowSavingSpinner();
				_factorySaver.SaveFactory(text);
				_currentSavePath.SetValue(text);
				string text2 = (_selectedZenMode ? "CREATIVE_MODE" : "CAMPAIGN_MODE");
				string text3 = (_isNewGame ? "NEW_GAME" : "OLD_GAME");
				_analyticsDesignEvent.Fire((text3 + ":" + text2 + ":FACTORYSCENE", 0f));
				_uiMenuManagerLocator.UIMenuManager.CloseAllOpenMenus();
				return;
			}
			string mapName = GetMapName();
			string mapPath = SaveSystem.CreateFullLevelsStreamingAssetPath(mapName);
			_saveInfoToLoad.SetNewSave(text, mapPath, _selectedZenMode);
			_loadingScreenSO.ShowLoadingScreen(showProgressBar: true);
			string text4 = (_selectedZenMode ? "CREATIVE_MODE" : "CAMPAIGN_MODE");
			string text5 = (_isNewGame ? "NEW_GAME" : "OLD_GAME");
			_analyticsDesignEvent.Fire((text5 + ":" + text4 + ":STARTSCENE:" + mapName, 0f));
			if (!_startedTutorialAtLeastOnce.Value)
			{
				_startedTutorialAtLeastOnce.SetValue(value: true);
				_globalPersistentManager.SaveGlobalPersistentSOs();
			}
			SceneHandler.Instance.LoadScene("Factory");
		}

		private string GetMapName()
		{
			return "DefaultLevel";
		}

		private void ResetErrorText()
		{
			_errorText.text = string.Empty;
			_errorText.gameObject.SetActive(value: false);
		}

		private void SetErrorText(string locaKey)
		{
			_errorText.text = LocalizationUtility.GetLocalizedText(locaKey);
			_errorText.gameObject.SetActive(value: true);
		}

		private void OnInputFieldSelect(string inputFieldText)
		{
			_debugActionMap.Disable();
			InputSystem.DisableDevice(Keyboard.current);
		}

		private void OnInputFieldDeSelect(string inputFieldText)
		{
			if (_isDebugActionMapEnabled && _enableGameCaptureShortcutsValidator.IsEnabledFeatureFlag())
			{
				_debugActionMap.Enable();
			}
			InputSystem.EnableDevice(Keyboard.current);
		}

		public bool IsFactoryScene()
		{
			return SceneManager.GetActiveScene().name == _factoryScene;
		}
	}
}
