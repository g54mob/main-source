using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.GameConfigs;
using Restory.Data.Localization;
using Restory.EventSystems.ExitEvents;
using Restory.Gameplay.GameSettings;
using Restory.Gameplay.GameSettings.Observers;
using Restory.UI.Views.SettingsMenu;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.SettingsMenu
{
	public class GUI_SettingsMenu : MonoBehaviour, IExitablePanel
	{
		[SerializeField]
		private GUI_SettingsMenuView view;

		[SerializeField]
		private bool isShown;

		[SerializeField]
		private GUI_PanelStack panelStack;

		[SerializeField]
		private int[] availableFpsLocksInitial = new int[5] { -1, 30, 60, 120, 144 };

		[SerializeField]
		private string languageSelectorValueKey = "UI_LANGUAGE_SELECTOR";

		[SerializeField]
		private string fpsLockUnlimitedValueKey = "UI_UNLIMITED";

		[SerializeField]
		private string fpsLockValueFormat = "{0} FPS";

		private readonly List<SystemLanguage> availableLanguages = new List<SystemLanguage>();

		private readonly List<Resolution> availableResolutions = new List<Resolution>();

		private readonly List<int> availableFpsLocks = new List<int>();

		private GameConfig gameConfig;

		private GameSettingsLanguageChangeObserver gameSettingsLanguageChangeObserver;

		private LocalizationSystem localizationSystem;

		private GameSettingsManager gameSettingsManager;

		private GameSettingsDataSaveLoadSystem gameSettingsSaver;

		public bool IsVisible => isShown;

		public event Action OnIsVisibleChanged;

		[Inject]
		private void Construct(GameSettingsManager gameSettingsManager, GameSettingsLanguageChangeObserver gameSettingsLanguageChangeObserver, GameSettingsDataSaveLoadSystem gameSettingsSaver, GameConfig gameConfig, LocalizationSystem localizationSystem)
		{
			this.gameSettingsManager = gameSettingsManager;
			this.gameSettingsLanguageChangeObserver = gameSettingsLanguageChangeObserver;
			this.gameSettingsSaver = gameSettingsSaver;
			this.gameConfig = gameConfig;
			this.localizationSystem = localizationSystem;
			if (isShown)
			{
				SubscribeSettings();
				SubscribeView();
				SetSettings();
			}
		}

		private void OnEnable()
		{
			if (isShown)
			{
				SubscribeSettings();
				SubscribeView();
				SetSettings();
			}
		}

		private void OnDisable()
		{
			if (isShown)
			{
				UnsubscribeSettings();
				UnsubscribeView();
			}
		}

		public void Show()
		{
			if (!isShown)
			{
				isShown = true;
				panelStack?.AddPanel(base.gameObject);
				SubscribeSettings();
				SubscribeView();
				SetSettings();
				view.Show();
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		public void Hide()
		{
			if (isShown)
			{
				isShown = false;
				panelStack?.RemovePanel(base.gameObject);
				UnsubscribeSettings();
				UnsubscribeView();
				view.Hide();
				gameSettingsSaver.Save();
				this.OnIsVisibleChanged?.Invoke();
			}
		}

		private void SubscribeGameSettingsLanguageChangeObserver()
		{
			UnsubscribeGameSettingsLanguageChangeObserver();
			if (gameSettingsLanguageChangeObserver != null)
			{
				gameSettingsLanguageChangeObserver.AddSubscriber(this, ResolveLanguageChanged);
			}
		}

		private void UnsubscribeGameSettingsLanguageChangeObserver()
		{
			if (gameSettingsLanguageChangeObserver != null)
			{
				gameSettingsLanguageChangeObserver.RemoveSubscriber(this);
			}
		}

		private void SubscribeSettings()
		{
			UnsubscribeSettings();
			if (!(gameSettingsManager == null))
			{
				gameSettingsManager.AudioSettings.Master.OnSettingsChanged.AddListener(ResolveMasterVolumeChanged);
				gameSettingsManager.AudioSettings.Music.OnSettingsChanged.AddListener(ResolveMusicVolumeChanged);
				gameSettingsManager.AudioSettings.SFX.OnSettingsChanged.AddListener(ResolveSFXVolumeChanged);
				gameSettingsManager.OnLocalisationChanged.AddListener(ResolveOnLanguageChanged);
				gameSettingsManager.OnGraphicsSettingsChange.AddListener(ResolveOnGraphicsSettingsChange);
			}
		}

		private void UnsubscribeSettings()
		{
			if (!(gameSettingsManager == null))
			{
				gameSettingsManager.AudioSettings.Master.OnSettingsChanged.RemoveListener(ResolveMasterVolumeChanged);
				gameSettingsManager.AudioSettings.Music.OnSettingsChanged.RemoveListener(ResolveMusicVolumeChanged);
				gameSettingsManager.AudioSettings.SFX.OnSettingsChanged.RemoveListener(ResolveSFXVolumeChanged);
				gameSettingsManager.OnLocalisationChanged.RemoveListener(ResolveOnLanguageChanged);
			}
		}

		private void SubscribeView()
		{
			UnsubscribeView();
			view.OnCloseClicked += Hide;
			view.OnMasterVolumeChanged += ResolveViewOnMasterVolumeChanged;
			view.OnMusicVolumeChanged += ResolveViewOnMusicVolumeChanged;
			view.OnSFXVolumeChanged += ResolveViewOnSFXVolumeChanged;
			view.OnLanguageChanged += ResolveViewOnLanguageChanged;
			view.OnResolutionChanged += ResolveViewOnResolutionChanged;
			view.OnScreenModeChanged += ResolveViewOnScreenModeChanged;
			view.OnMonitorChanged += ResolveViewOnMonitorChanged;
			view.OnVSyncChanged += ResolveViewOnVSyncChanged;
			view.OnFpsLockChanged += ResolveViewOnFpsLockChanged;
		}

		private void UnsubscribeView()
		{
			view.OnCloseClicked -= Hide;
			view.OnMasterVolumeChanged -= ResolveViewOnMasterVolumeChanged;
			view.OnMusicVolumeChanged -= ResolveViewOnMusicVolumeChanged;
			view.OnSFXVolumeChanged -= ResolveViewOnSFXVolumeChanged;
			view.OnLanguageChanged -= ResolveViewOnLanguageChanged;
			view.OnResolutionChanged -= ResolveViewOnResolutionChanged;
			view.OnScreenModeChanged -= ResolveViewOnScreenModeChanged;
			view.OnMonitorChanged -= ResolveViewOnMonitorChanged;
			view.OnVSyncChanged -= ResolveViewOnVSyncChanged;
			view.OnFpsLockChanged -= ResolveViewOnFpsLockChanged;
		}

		private void SetSettings()
		{
			if (!(gameSettingsManager == null))
			{
				ResolveMasterVolumeChanged(gameSettingsManager.AudioSettings.Master);
				ResolveMusicVolumeChanged(gameSettingsManager.AudioSettings.Music);
				ResolveSFXVolumeChanged(gameSettingsManager.AudioSettings.SFX);
				ResolveOnLanguageChanged(gameSettingsManager.Localization);
				ResolveOnGraphicsSettingsChange();
			}
		}

		private void SetViewResolutions()
		{
			availableResolutions.Clear();
			availableResolutions.AddRange(GameSettingsManager.GetResolutions());
			if (!availableResolutions.Contains(gameSettingsManager.ScreenResolution))
			{
				availableResolutions.Add(gameSettingsManager.ScreenResolution);
			}
			List<string> list = new List<string>(availableResolutions.Count);
			foreach (Resolution availableResolution in availableResolutions)
			{
				list.Add($"{availableResolution.width}x{availableResolution.height}");
			}
			view.SetResolutionOptions(list);
		}

		private void SetViewMonitor()
		{
			List<DisplayInfo> displayInfos = GameSettingsManager.GetDisplayInfos();
			List<string> list = new List<string>(displayInfos.Count);
			for (int i = 0; i < displayInfos.Count; i++)
			{
				list.Add(displayInfos[i].name);
			}
			view.SetMonitorOptions(list);
		}

		private void SetViewFpsLock()
		{
			availableFpsLocks.Clear();
			availableFpsLocks.AddRange(availableFpsLocksInitial);
			if (!availableFpsLocks.Contains(gameSettingsManager.FpsLock))
			{
				availableFpsLocks.Add(gameSettingsManager.FpsLock);
			}
			List<string> list = new List<string>(availableFpsLocks.Count);
			foreach (int availableFpsLock in availableFpsLocks)
			{
				if (availableFpsLock == -1)
				{
					list.Add(localizationSystem.GetTranslation(fpsLockUnlimitedValueKey));
				}
				else
				{
					list.Add(availableFpsLock.ToString(fpsLockValueFormat));
				}
			}
			view.SetFpsLockOptions(list);
		}

		private void ResolveViewOnMasterVolumeChanged(float value)
		{
			gameSettingsManager.AudioSettings.Master.Volume = Mathf.InverseLerp(0f, 100f, value);
		}

		private void ResolveViewOnMusicVolumeChanged(float value)
		{
			gameSettingsManager.AudioSettings.Music.Volume = Mathf.InverseLerp(0f, 100f, value);
		}

		private void ResolveViewOnSFXVolumeChanged(float value)
		{
			gameSettingsManager.AudioSettings.SFX.Volume = Mathf.InverseLerp(0f, 100f, value);
		}

		private void ResolveViewOnLanguageChanged(int index)
		{
			gameSettingsManager.Localization = availableLanguages[index];
		}

		private void ResolveViewOnResolutionChanged(int index)
		{
			if (index < 0 || index >= availableResolutions.Count)
			{
				Debug.LogWarning($"Resolution index {index} is out of range.");
			}
			else
			{
				gameSettingsManager.ScreenResolution = availableResolutions[index];
			}
		}

		private void ResolveViewOnScreenModeChanged(int index)
		{
			gameSettingsManager.Fullscreen = index == 0;
		}

		private void ResolveViewOnMonitorChanged(int index)
		{
			gameSettingsManager.ScreenIndex = index;
		}

		private void ResolveViewOnVSyncChanged(bool vSync)
		{
			gameSettingsManager.Vsync = vSync;
		}

		private void ResolveViewOnFpsLockChanged(int index)
		{
			if (index < 0 || index >= availableFpsLocks.Count)
			{
				Debug.LogWarning($"FpsLock index {index} is out of range.");
			}
			else
			{
				gameSettingsManager.FpsLock = availableFpsLocks[index];
			}
		}

		private void ResolveMasterVolumeChanged(AudioFMODSettings.AudioTypeSettings settings)
		{
			view.SetMasterVolumeValue(settings.Volume * 100f, notify: false);
		}

		private void ResolveMusicVolumeChanged(AudioFMODSettings.AudioTypeSettings settings)
		{
			view.SetMusicVolumeValue(settings.Volume * 100f, notify: false);
		}

		private void ResolveSFXVolumeChanged(AudioFMODSettings.AudioTypeSettings settings)
		{
			view.SetSFXVolumeValue(settings.Volume * 100f, notify: false);
		}

		private void ResolveOnLanguageChanged(SystemLanguage language)
		{
			availableLanguages.Clear();
			availableLanguages.AddRange(gameConfig.SupportedLocalizations);
			view.SetLanguageOptions(availableLanguages.Select((SystemLanguage systemLanguage) => localizationSystem.GetTranslation(languageSelectorValueKey, systemLanguage.ToString())).ToList());
			view.SetLanguageIndex(availableLanguages.IndexOf(language), notify: false);
		}

		private void ResolveOnGraphicsSettingsChange()
		{
			int index = availableResolutions.IndexOf(gameSettingsManager.ScreenResolution);
			SetViewResolutions();
			view.SetResolutionIndex(index, notify: false);
			view.SetScreenModeIndex((!gameSettingsManager.Fullscreen) ? 1 : 0, notify: false);
			SetViewMonitor();
			view.SetMonitorIndex(gameSettingsManager.ScreenIndex, notify: false);
			view.SetVSyncEnabled(gameSettingsManager.Vsync, notify: false);
			SetViewFpsLock();
			int index2 = availableFpsLocks.IndexOf(gameSettingsManager.FpsLock);
			view.SetFpsLockIndex(index2, notify: false);
		}

		public void OnExitEvent()
		{
			Hide();
		}

		private void ResolveLanguageChanged(SystemLanguage language)
		{
			ResolveOnLanguageChanged(language);
			ResolveOnGraphicsSettingsChange();
		}
	}
}
