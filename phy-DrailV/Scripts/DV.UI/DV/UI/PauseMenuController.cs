using System;
using DV.Common;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI
{
	public class PauseMenuController : AUIController
	{
		private APauseMenuProvider provider;

		[NullCheck]
		public UIMenuController submenuController;

		[NullCheck]
		public SettingsController settingsController;

		[NullCheck]
		public SaveLoadController saveLoadController;

		[NullCheck]
		public BugReportController bugReportController;

		[NullCheck]
		public TutorialsMenuController tutorialsMenuController;

		[NullCheck]
		public GameObject background;

		[NullCheck]
		public PopupManager popupManager;

		[Header("Buttons")]
		[NullCheck]
		public ButtonDV loadSaveButton;

		[NullCheck]
		public ButtonDV tutorialsButton;

		[NullCheck]
		public ButtonDV hackySaveButton;

		[NullCheck]
		public ButtonDV settingsButton;

		[NullCheck]
		public ButtonDV manualButton;

		[NullCheck]
		public ButtonDV bugReportButton;

		[NullCheck]
		public ButtonDV exitLevelButton;

		[NullCheck]
		public ButtonDV quitGameButton;

		[NullCheck]
		public ButtonDV closeMenuButton;

		[NullCheck]
		public ButtonDV backToInitialButton;

		[NullCheck]
		public ButtonDV inventoryAccessButton;

		[Header("Tutorial")]
		[NullCheck]
		public GameObject tutorialFrame;

		[NullCheck]
		public GameObject tutorialHighlight;

		[Header("Popups")]
		[NullCheck]
		public Popup yesNoPopupPrefab;

		[NullCheck]
		public Popup yesNoCancelPopupPrefab;

		private readonly PopupLocalizationKeys popupQuitLocalizationKeys = new PopupLocalizationKeys
		{
			positiveKey = "mm/pause_quit_save",
			negativeKey = "mm/pause_quit_no_save",
			abortionKey = "cancel",
			labelKey = "mm/pause_quit_confirm"
		};

		private readonly PopupLocalizationKeys popupLeaveLocalizationKeys = new PopupLocalizationKeys
		{
			positiveKey = "mm/pause_leave_save",
			negativeKey = "mm/pause_leave_no_save",
			abortionKey = "cancel",
			labelKey = "mm/pause_leave_confirm"
		};

		private readonly PopupLocalizationKeys popupQuitLeaveCantSaveLocalizationKeys = new PopupLocalizationKeys
		{
			positiveKey = "yes",
			negativeKey = "no",
			labelKey = "mm/pause_tutorial_quit_confirm"
		};

		public event Action ExitLevelRequested;

		public event Action QuitGameRequested;

		public event Action CloseRequested;

		public event Action InventoryRequested;

		private void Start()
		{
			if ((bool)EventSystem.current && EventSystem.current.sendNavigationEvents)
			{
				Debug.LogError("EventSystem.sendNavigationEvents is on, it should be disabled.");
			}
		}

		public void SetProvider(APauseMenuProvider provider)
		{
			if (this.provider != null)
			{
				Util.RunOnce(this, "SetProvider");
				return;
			}
			this.provider = provider;
			settingsController.SetProvider(provider.SettingsProvider);
			saveLoadController.SetProvider(provider.UserProfileProvider);
			saveLoadController.SetData(inMainMenu: false, provider, provider.Session);
			bugReportController.SetProvider(provider.BugReportDataProvider);
			tutorialsMenuController.SetProvider(provider.TutorialsMenuProvider);
			CachePanels();
			RefreshInterface();
		}

		private void OnEnable()
		{
			backToInitialButton.gameObject.SetActive(value: false);
			background.SetActive(value: false);
			submenuController.SwitchMenu(0);
			SetupListeners(on: true);
			RefreshInterface();
		}

		private void RefreshInterface()
		{
			if (provider != null && provider.TutorialsMenuProvider != null)
			{
				tutorialsButton.ToggleInteractable(provider.TutorialsMenuProvider.IsQuickTutorialUserControlAllowed() || provider.TutorialsMenuProvider.IsMetaTutorialHackActive());
				tutorialHighlight.SetActive(provider.TutorialsMenuProvider.IsQuickTutorialRunning() && tutorialsButton.interactable);
			}
			bugReportButton.gameObject.SetActive(provider != null && provider.BugReportDataProvider.IsReportingSupported());
		}

		private void CachePanels()
		{
			OnSettingsClicked(null);
			OnManualClicked(null);
			OnBugReportClicked(null);
			OnLoadSaveClicked(null);
			OnSettingsClicked(null);
			OnCloseMenuClicked(null);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				loadSaveButton.Clicked += OnLoadSaveClicked;
				tutorialsButton.Clicked += OnTutorialsClicked;
				hackySaveButton.Clicked += OnHackySaveClicked;
				settingsButton.Clicked += OnSettingsClicked;
				manualButton.Clicked += OnManualClicked;
				bugReportButton.Clicked += OnBugReportClicked;
				exitLevelButton.Clicked += OnExitLevelClicked;
				quitGameButton.Clicked += OnQuitClicked;
				closeMenuButton.Clicked += OnCloseMenuClicked;
				backToInitialButton.Clicked += OnBackToInitialClicked;
				inventoryAccessButton.Clicked += OnInventoryAccessClicked;
				saveLoadController.LoadRequested += OnLoadGameClicked;
				submenuController.MenuChanged += OnSubmenuChanged;
				settingsController.LocalizationButtonPressed += OnLocalizationButtonPressed;
			}
			else
			{
				loadSaveButton.Clicked -= OnLoadSaveClicked;
				tutorialsButton.Clicked -= OnTutorialsClicked;
				hackySaveButton.Clicked -= OnHackySaveClicked;
				settingsButton.Clicked -= OnSettingsClicked;
				manualButton.Clicked -= OnManualClicked;
				bugReportButton.Clicked -= OnBugReportClicked;
				exitLevelButton.Clicked -= OnExitLevelClicked;
				quitGameButton.Clicked -= OnQuitClicked;
				closeMenuButton.Clicked -= OnCloseMenuClicked;
				backToInitialButton.Clicked -= OnBackToInitialClicked;
				inventoryAccessButton.Clicked -= OnInventoryAccessClicked;
				saveLoadController.LoadRequested -= OnLoadGameClicked;
				submenuController.MenuChanged -= OnSubmenuChanged;
				settingsController.LocalizationButtonPressed -= OnLocalizationButtonPressed;
			}
		}

		private void OnLoadGameClicked(ISaveGame save)
		{
			saveLoadController.Provider.LoadGame(save);
		}

		private void OnSubmenuChanged(UIMenu menu)
		{
			bool active = menu != submenuController.controlledMenus[0];
			backToInitialButton.gameObject.SetActive(active);
			background.SetActive(active);
		}

		private void OnHackySaveClicked(IClickable _)
		{
			saveLoadController.Provider.SaveGame(SaveType.Quick);
		}

		private void OnExitLevelClicked(IClickable _)
		{
			LeaveAfterGameSavedCheck(this.ExitLevelRequested);
		}

		private void OnLocalizationButtonPressed()
		{
			LeaveAfterGameSavedCheck(provider.SettingsProvider.OpenLocalizationScene);
		}

		private void LeaveAfterGameSavedCheck(Action leaveAction)
		{
			if ((bool)provider && provider.HasUnsavedProgress)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				Popup popupPrefab;
				PopupLocalizationKeys locKeys;
				if (provider.UserProfileProvider.IsSavingRestrictedByTutorial())
				{
					popupPrefab = yesNoPopupPrefab;
					locKeys = popupQuitLeaveCantSaveLocalizationKeys;
				}
				else
				{
					popupPrefab = yesNoCancelPopupPrefab;
					locKeys = popupLeaveLocalizationKeys;
				}
				popupManager.ShowPopup(popupPrefab, locKeys).Closed += delegate(PopupResult result)
				{
					(bool shouldQuitOrLeave, bool shouldSave) tuple = ShouldQuitOrLeaveGameOnPopupClosed(result);
					var (flag, _) = tuple;
					if (tuple.shouldSave)
					{
						provider.UserProfileProvider.SaveGame(SaveType.Auto);
					}
					if (flag)
					{
						leaveAction?.Invoke();
					}
				};
			}
			else
			{
				leaveAction?.Invoke();
			}
		}

		private (bool shouldQuitOrLeave, bool shouldSave) ShouldQuitOrLeaveGameOnPopupClosed(PopupResult result)
		{
			if (result.closedBy == PopupClosedByAction.Abortion)
			{
				return (shouldQuitOrLeave: false, shouldSave: false);
			}
			bool num = provider.UserProfileProvider.IsSavingRestrictedByTutorial();
			bool flag = result.closedBy == PopupClosedByAction.Positive;
			if (!num)
			{
				return (shouldQuitOrLeave: true, shouldSave: flag);
			}
			return (shouldQuitOrLeave: flag, shouldSave: false);
		}

		private void OnBackToInitialClicked(IClickable _)
		{
			submenuController.SwitchMenu(0);
		}

		private void OnLoadSaveClicked(IClickable _)
		{
			submenuController.SwitchMenu(1);
		}

		private void OnSettingsClicked(IClickable _)
		{
			submenuController.SwitchMenu(2);
		}

		private void OnManualClicked(IClickable _)
		{
			submenuController.SwitchMenu(3);
		}

		private void OnBugReportClicked(IClickable _)
		{
			submenuController.SwitchMenu(4);
		}

		private void OnTutorialsClicked(IClickable _)
		{
			submenuController.SwitchMenu(5);
		}

		private void OnInventoryAccessClicked(IClickable _)
		{
			this.InventoryRequested?.Invoke();
		}

		private void OnQuitClicked(IClickable _)
		{
			if ((bool)provider && provider.HasUnsavedProgress)
			{
				if (!popupManager.CanShowPopup())
				{
					Debug.LogWarning("PopupManager can't show popups at this moment", this);
					return;
				}
				Popup popupPrefab;
				PopupLocalizationKeys locKeys;
				if (provider.UserProfileProvider.IsSavingRestrictedByTutorial())
				{
					popupPrefab = yesNoPopupPrefab;
					locKeys = popupQuitLeaveCantSaveLocalizationKeys;
				}
				else
				{
					popupPrefab = yesNoCancelPopupPrefab;
					locKeys = popupQuitLocalizationKeys;
				}
				popupManager.ShowPopup(popupPrefab, locKeys).Closed += OnQuitGamePopupClosed;
			}
			else
			{
				this.QuitGameRequested?.Invoke();
			}
		}

		private void OnQuitGamePopupClosed(PopupResult result)
		{
			(bool shouldQuitOrLeave, bool shouldSave) tuple = ShouldQuitOrLeaveGameOnPopupClosed(result);
			var (flag, _) = tuple;
			if (tuple.shouldSave)
			{
				provider.UserProfileProvider.SaveGame(SaveType.Auto);
			}
			if (flag)
			{
				this.QuitGameRequested?.Invoke();
			}
		}

		private void OnCloseMenuClicked(IClickable _)
		{
			this.CloseRequested?.Invoke();
		}

		public void RequestClose()
		{
			this.CloseRequested?.Invoke();
		}
	}
}
