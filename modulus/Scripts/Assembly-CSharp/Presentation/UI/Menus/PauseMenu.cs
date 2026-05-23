#define ENABLE_DEBUG_LOGS
using System.IO;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Events.Generic;
using Events.UI.Overlays;
using Logic.Factory;
using Presentation.Locators;
using Presentation.UI.LoadingScreen;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;
using Utils.SceneHandling;

namespace Presentation.UI.Menus
{
	public class PauseMenu : GamecontrolMenu
	{
		[SerializeField]
		private Button _resumeButton;

		[SerializeField]
		private Button _backToMainMenuButton;

		[SerializeField]
		private Button _saveAndQuitButton;

		[SerializeField]
		private AutoSaveService _autoSaveService;

		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private Button _settingsButton;

		[SerializeField]
		private Button _manualButton;

		[SerializeField]
		private Button _loadButton;

		[SerializeField]
		private ShowMenuModalDialogEvent _showMenuModalDialogEvent;

		[SerializeField]
		private UIMenuLocator _settingsMenuLocator;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private LoadingScreenSO _loadingScreenSO;

		[SerializeField]
		private string _startScreenScene = "StartScreen";

		[SerializeField]
		private UIMenuLocator _manualMenuLocator;

		[SerializeField]
		private FactoryClearer _factoryClearer;

		[SerializeField]
		private PersistentSOLibrary _persistentSoLibrary;

		[SerializeField]
		private IntEvent _deletedSaveFileEvent;

		[SerializeField]
		private FactorySaver _factorySaver;

		[SerializeField]
		private CurrentSavePathSO _currentSavePath;

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		[SerializeField]
		private Image _logoImage;

		[SerializeField]
		private Sprite _supportersEditionLogo;

		[SerializeField]
		private GameObject _supporterEditionLabel;

		[Header("Save And Quit logic")]
		[SerializeField]
		private SaveInfoPersistentSO _saveInfoPersistentSO;

		protected override void Awake()
		{
			base.Awake();
			_resumeButton.onClick.AddListener(base.GoBack);
			_backToMainMenuButton.onClick.AddListener(OnBackToMainMenuButtonClicked);
			_quitButton.onClick.AddListener(OnQuitButtonClicked);
			_saveAndQuitButton.onClick.AddListener(OnSaveAndQuitButtonClicked);
			_settingsButton.onClick.AddListener(OnSettingsButtonClicked);
			_manualButton.onClick.AddListener(OnManualButtonClicked);
			_deletedSaveFileEvent.Register(OnDeleteSaveFile);
			if (_integrationManagerLocator.Integration.IsSupportersEdition())
			{
				_logoImage.overrideSprite = _supportersEditionLogo;
				_supporterEditionLabel.SetActive(value: true);
			}
			else
			{
				_supporterEditionLabel.SetActive(value: false);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_resumeButton.onClick.RemoveListener(base.GoBack);
			_backToMainMenuButton.onClick.RemoveListener(OnBackToMainMenuButtonClicked);
			_quitButton.onClick.RemoveListener(OnQuitButtonClicked);
			_saveAndQuitButton.onClick.RemoveListener(OnSaveAndQuitButtonClicked);
			_settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
			_manualButton.onClick.RemoveListener(OnManualButtonClicked);
			_deletedSaveFileEvent.UnRegister(OnDeleteSaveFile);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			base.ShowMenu(menuData);
			if (!_uiVisibility.Value)
			{
				_uiVisibility.SetValue(value: true);
			}
		}

		private void OnSettingsButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIMenuMenuData(_settingsMenuLocator.UIMenu, AbstractUIMenuData.ToggleTypes.DisableFactoryActions | AbstractUIMenuData.ToggleTypes.DisableUIActions));
		}

		private void OnManualButtonClicked()
		{
			_showUIMenuEvent.Fire(new UIPageMenuData(_manualMenuLocator.UIMenu, AbstractUIMenuData.ToggleTypes.DisableFactoryActions | AbstractUIMenuData.ToggleTypes.DisableUIActions));
		}

		private void OnBackToMainMenuButtonClicked()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("InGameMenu.BackToMainWarning", Sizes.S, LoadMainMenu, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
				OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}

		private void LoadMainMenu()
		{
			_loadingScreenSO.ShowLoadingScreen(showProgressBar: false);
			_factoryClearer.ClearLevel();
			_persistentSoLibrary.ResetPersistentSOs();
			_pauseState.SetPauseState(active: false);
			_pauseState.SetPausedBuildMode(active: false);
			SceneHandler.Instance.LoadScene(_startScreenScene, LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum.End);
		}

		private void OnDeleteSaveFile(int saveCount)
		{
		}

		private void OnSaveAndQuitButtonClicked()
		{
			string text = SaveSystem.GameSavePath + "/Levels/" + _saveInfoPersistentSO.AutoSaveSourceSaveName;
			if (_currentSavePath.Value != SaveSystem.AutoSavePath)
			{
				_factorySaver.SaveFactory(_currentSavePath.Value);
				this.Log("Save and quit to " + _currentSavePath.Value, "OnSaveAndQuitButtonClicked", 150);
			}
			else if (_currentSavePath.Value == SaveSystem.AutoSavePath && !string.IsNullOrEmpty(text) && Directory.Exists(text))
			{
				_factorySaver.SaveFactory(text);
				this.Log("Save and quit to \"" + text + "\"", "OnSaveAndQuitButtonClicked", 156);
			}
			else
			{
				_autoSaveService.AutoSave();
				this.Log("Save and quit to autosave path", "OnSaveAndQuitButtonClicked", 161);
			}
			ApplicationUtils.QuitApplication();
		}

		private void OnQuitButtonClicked()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("General.ExitWarning", Sizes.S, ApplicationUtils.QuitApplication, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
				OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
			};
			_showMenuModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}
	}
}
