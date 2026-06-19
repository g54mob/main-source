#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SandboxMenu : AnimatedMenuBase
	{
		private enum TabMode
		{
			NewGame = 0,
			BrowseLocal = 1,
			BrowseWorkshop = 2
		}

		private struct WorkshopSetting
		{
			public GameItemBase WorkshopItem;

			public SandboxSettings Settings;

			public SaveFileHeader SaveFileHeader;
		}

		public struct IDAndName
		{
			public string ID;

			public string Name;

			public IDAndName(string id, string name)
			{
				ID = id;
				Name = name;
			}
		}

		public struct DLCAndUGCPresence
		{
			public List<uint> presentDLC;

			public List<uint> missingDLC;

			public List<IDAndName> presentWorkshopItems;

			public List<IDAndName> missingWorkshopItems;

			public List<IDAndName> presentLocalUGCItems;

			public List<IDAndName> missingLocalUGCItems;

			public List<uint> missingDLCThatPreventsLevelStart;
		}

		private const uint HospitalPassDlcId = 898770u;

		[InspectorDivider]
		[InspectorMargin(8)]
		[InspectorHeader("Sandbox Settings")]
		[SerializeField]
		private Color _selectedTabTint = Color.white;

		[SerializeField]
		private Color _unselectedTabTint = Color.grey;

		[SerializeField]
		private TMP_Text _sandboxSaveCount;

		[InspectorMargin(8)]
		[InspectorHeader("Tabs")]
		[SerializeField]
		private ButtonAnimator _buttonNew;

		[SerializeField]
		private GameObject _newGamePanel;

		[InspectorMargin(4)]
		[SerializeField]
		private ButtonAnimator _buttonBrowse;

		[SerializeField]
		private GameObject _browseGamePanel;

		[InspectorMargin(4)]
		[SerializeField]
		private ButtonAnimator _buttonBrowseCloud;

		[SerializeField]
		private GameObject _browseCloudPanel;

		[InspectorMargin(8)]
		[InspectorHeader("New Game Buttons")]
		[SerializeField]
		private GameObject _newGameButtons;

		[SerializeField]
		private ButtonAnimator _buttonStart;

		[SerializeField]
		private ButtonAnimator _buttonReset;

		[InspectorMargin(8)]
		[InspectorHeader("Browse Local Buttons")]
		[SerializeField]
		private GameObject _browseGameButtons;

		[SerializeField]
		private ButtonAnimator _buttonContinue;

		[SerializeField]
		private ButtonAnimator _buttonRestart;

		[SerializeField]
		private ButtonAnimator _buttonPublish;

		[SerializeField]
		private ButtonAnimator _buttonDelete;

		[InspectorMargin(8)]
		[InspectorHeader("Browse Cloud Buttons")]
		[SerializeField]
		private GameObject _browseCloudButtons;

		[SerializeField]
		private ButtonAnimator _buttonLoadCloudSave;

		[SerializeField]
		private ButtonAnimator _buttonWorkshop;

		[InspectorMargin(8)]
		[SerializeField]
		private Transform _settingsRoot;

		[SerializeField]
		private ScrollRect _settingsScrollRect;

		[SerializeField]
		private SandboxInfoPanel _infoMenu;

		[SerializeField]
		private GameObject _helpPanel;

		[SerializeField]
		private SandboxMenuSettingCycleImage _mapSelectControl;

		[InspectorMargin(8)]
		[InspectorHeader("Prefabs")]
		[SerializeField]
		private GameObject _prefabSettingInput;

		[SerializeField]
		private GameObject _prefabSettingToggle;

		[SerializeField]
		private GameObject _prefabSettingSlider;

		private MetagameMap _metagameMap;

		private SandboxSettings _settings;

		private WorkshopSetting _workshopSetting;

		private SandboxSettingsConfig _config;

		private SandboxSaveManager _sandboxSaveManager;

		private SaveSystem _saveSystem;

		private DLCManager _dlcManager;

		private ExtContentManager _extContentManager;

		private List<SandboxMenuSetting> _menuSettings = new List<SandboxMenuSetting>();

		private Dictionary<LevelConfig, SandboxTextImageOption> _cachedLevelOptions;

		private SandboxTextImageOption[] _cachedLocalSandboxOptions;

		private bool _userSetName;

		private TabMode _tabMode;

		private bool _buttonsRegistered;

		private bool _eventsRegistered;

		private List<WorkshopSetting> _workshopSettings = new List<WorkshopSetting>();

		private List<SandboxTextImageOption> _cachedWorkshopSandboxOptions = new List<SandboxTextImageOption>();

		private DLCAndUGCPresence _dlcAndUGCPresence;

		private static List<uint> _primeLootSharesDLC = new List<uint> { 1035020u, 1144500u, 1376920u };

		private static bool _everLoggedInWithPrime;

		private bool IsPlayingLevel => SandboxSaveManager.CurrentSettings == _settings;

		public void Setup(SandboxSettingsConfig config, MetagameMap metagameMap, SandboxSaveManager saveManager, bool everConnectedToPrime)
		{
			_config = config;
			_metagameMap = metagameMap;
			_sandboxSaveManager = saveManager;
			_saveSystem = _metagameMap.App.SaveSystem;
			_dlcManager = _metagameMap.App.DLCManager;
			_everLoggedInWithPrime = everConnectedToPrime;
			_extContentManager = _metagameMap.App.ExtContentManager;
			_dlcAndUGCPresence.presentDLC = new List<uint>();
			_dlcAndUGCPresence.missingDLC = new List<uint>();
			_dlcAndUGCPresence.presentWorkshopItems = new List<IDAndName>();
			_dlcAndUGCPresence.missingWorkshopItems = new List<IDAndName>();
			_dlcAndUGCPresence.presentLocalUGCItems = new List<IDAndName>();
			_dlcAndUGCPresence.missingLocalUGCItems = new List<IDAndName>();
			_dlcAndUGCPresence.missingDLCThatPreventsLevelStart = new List<uint>();
			_sandboxSaveManager.SortSettingsByLastPlayed(_saveSystem);
			if (!_buttonsRegistered)
			{
				_buttonsRegistered = true;
				_buttonNew.Button.onPrimaryDown.AddListener(OnNewGameTab);
				_buttonBrowse.Button.onPrimaryDown.AddListener(OnBrowseGamesTab);
				_buttonBrowseCloud.Button.onPrimaryDown.AddListener(OnBrowseWorkshopTab);
				_buttonStart.Button.onPrimaryDown.AddListener(OnStartGame);
				_buttonReset.Button.onPrimaryDown.AddListener(OnResetSettings);
				_buttonContinue.Button.onPrimaryDown.AddListener(OnContinueGame);
				_buttonRestart.Button.onPrimaryDown.AddListener(OnRestartGame);
				_buttonPublish.Button.onPrimaryDown.AddListener(OnPublishGame);
				_buttonDelete.Button.onPrimaryDown.AddListener(OnDeleteGame);
				_buttonLoadCloudSave.Button.onPrimaryDown.AddListener(OnLoadWorkshopSave);
				_buttonWorkshop.Button.onPrimaryDown.AddListener(OnWorkshopOpen);
			}
			CacheSandboxData();
			CacheLevelOptions();
			CacheWorkshopSaves();
			if (_sandboxSaveManager.AllSettings.Count == 0)
			{
				_tabMode = TabMode.NewGame;
				_settings = new SandboxSettings(_config);
			}
			else
			{
				_tabMode = TabMode.BrowseLocal;
				_settings = ChooseAppropriateSandboxToDisplay();
			}
			RefreshDLCAndUGCRequired();
			_infoMenu.Setup(_settings, GetSaveFileHeader(), _metagameMap, _sandboxSaveManager, _dlcManager, _dlcAndUGCPresence);
			RefreshMapSelect();
			OnSetSandboxName(_settings.DisplayName);
			CreateSettings();
			RefreshSettings();
			RefreshButtons();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			RegisterEvents();
			UpdateCacheLevelOptions();
		}

		public override void CloseMenu()
		{
			UnregisterEvents();
			base.CloseMenu();
		}

		private void RegisterEvents()
		{
			if (!_eventsRegistered)
			{
				_eventsRegistered = true;
				SandboxSaveManager.OnSandboxDeleted = (Action<SandboxSettings>)Delegate.Combine(SandboxSaveManager.OnSandboxDeleted, new Action<SandboxSettings>(OnSandboxDeleted));
				LocalizationManager.OnLocalizeEvent += OnLocalize;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemCreated += ContentSourceWorkshopOnOnGameItemCreated;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemUpdated += ContentSourceWorkshopOnOnGameItemUpdated;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnWorkshopInstalledItemCreated += RefreshWorkshopItemStatus;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnWorkshopInstalledItemUpdated += RefreshWorkshopItemStatus;
			}
		}

		private void UnregisterEvents()
		{
			if (_eventsRegistered)
			{
				_eventsRegistered = false;
				LocalizationManager.OnLocalizeEvent -= OnLocalize;
				SandboxSaveManager.OnSandboxDeleted = (Action<SandboxSettings>)Delegate.Remove(SandboxSaveManager.OnSandboxDeleted, new Action<SandboxSettings>(OnSandboxDeleted));
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemCreated -= ContentSourceWorkshopOnOnGameItemCreated;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnGameItemUpdated -= ContentSourceWorkshopOnOnGameItemUpdated;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnWorkshopInstalledItemCreated -= RefreshWorkshopItemStatus;
				ExtContentUtils.ExtContentManager.ContentSourceWorkshop.OnWorkshopInstalledItemUpdated -= RefreshWorkshopItemStatus;
			}
		}

		private void CacheSandboxData()
		{
			List<SandboxSettings> allSettings = _sandboxSaveManager.AllSettings;
			_cachedLocalSandboxOptions = new SandboxTextImageOption[allSettings.Count];
			for (int i = 0; i < allSettings.Count; i++)
			{
				SandboxSettings sandboxSettings = allSettings[i];
				_cachedLocalSandboxOptions[i] = new SandboxTextImageOption
				{
					Text = sandboxSettings.DisplayName,
					Image = sandboxSettings.GetThumbnailTexture(_saveSystem, null, _metagameMap.Level)
				};
			}
		}

		private void CacheLevelOptions()
		{
			if (_cachedLevelOptions != null)
			{
				return;
			}
			_cachedLevelOptions = new Dictionary<LevelConfig, SandboxTextImageOption>();
			SandboxLevelOption[] levelOptions = _config.LevelOptions;
			foreach (SandboxLevelOption sandboxLevelOption in levelOptions)
			{
				LevelConfig instance = sandboxLevelOption.Level.Instance;
				if (DLCUtils.IsDLCInstalled(instance.GetRequiredDlcPack()))
				{
					_cachedLevelOptions.Add(instance, new SandboxTextImageOption
					{
						Text = sandboxLevelOption.Level.Instance.GetLocalisedDisplayName(),
						Image = SandboxThumbnail.Generate(sandboxLevelOption.Level.Instance, sandboxLevelOption.GetThumbnailStyle(_config.ThumbnailStyle.Instance))
					});
				}
			}
		}

		private void ContentSourceWorkshopOnOnGameItemCreated(GameItemBase item)
		{
			ContentSourceWorkshopOnOnGameItemEventGeneral(item);
		}

		private void ContentSourceWorkshopOnOnGameItemUpdated(GameItemBase item)
		{
			ContentSourceWorkshopOnOnGameItemEventGeneral(item);
		}

		private void ContentSourceWorkshopOnOnGameItemEventGeneral(GameItemBase item)
		{
			if (item.ContentType == EContentType.SandboxSave)
			{
				CacheWorkshopSaves();
				if (_tabMode == TabMode.BrowseWorkshop)
				{
					RefreshMapSelect();
				}
				RefreshButtons();
			}
		}

		private void CacheWorkshopSaves()
		{
			List<GameItemBase> allGameItemsSorted = ExtContentUtils.ExtContentManager.ContentSourceWorkshop.GetAllGameItemsSorted(EContentType.SandboxSave);
			_workshopSettings.Clear();
			_cachedWorkshopSandboxOptions.Clear();
			foreach (GameItemBase item in allGameItemsSorted)
			{
				SandboxSettings sandboxSettings = _sandboxSaveManager.LoadFromFolder(item.InstalledFolderPathSpec);
				if (sandboxSettings != null)
				{
					SaveFileHeader saveFileHeader = _saveSystem.LoadSaveHeaderFromFolder(item.InstalledFolderPathSpec);
					_workshopSettings.Add(new WorkshopSetting
					{
						SaveFileHeader = saveFileHeader,
						Settings = sandboxSettings,
						WorkshopItem = item
					});
					_cachedWorkshopSandboxOptions.Add(new SandboxTextImageOption
					{
						Text = sandboxSettings.DisplayName,
						Image = sandboxSettings.GetThumbnailTexture(_saveSystem, saveFileHeader, _metagameMap.Level)
					});
				}
			}
		}

		private void OnLocalize()
		{
			UpdateCacheLevelOptions();
		}

		private void UpdateCacheLevelOptions()
		{
			if (_cachedLevelOptions == null)
			{
				return;
			}
			foreach (LevelConfig key in _cachedLevelOptions.Keys)
			{
				_cachedLevelOptions[key].Text = key.GetLocalisedDisplayName();
			}
			RefreshMapSelect();
		}

		private int CurrentMapIndex()
		{
			LevelConfig[] array = _cachedLevelOptions.Keys.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == _settings.LevelConfig)
				{
					return i;
				}
			}
			return 0;
		}

		private int CurrentSandboxIndex()
		{
			List<SandboxSettings> allSettings = _sandboxSaveManager.AllSettings;
			for (int i = 0; i < allSettings.Count; i++)
			{
				if (allSettings[i] == _settings)
				{
					return i;
				}
			}
			return 0;
		}

		private int CurrentWorkshopSandboxIndex()
		{
			for (int i = 0; i < _workshopSettings.Count; i++)
			{
				if (_workshopSettings[i].Settings == _settings)
				{
					return i;
				}
			}
			return 0;
		}

		private void CreateSettings()
		{
			foreach (SandboxMenuSetting menuSetting in _menuSettings)
			{
				UnityEngine.Object.Destroy(menuSetting.gameObject);
			}
			_menuSettings.Clear();
			CreateInput(_config.LevelName, _config.LevelTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.DisplayName, 24, OnSetSandboxName);
			CreateSlider(_config.CashName, _config.CashTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Balance, _config.BalanceOptions, delegate(float value)
			{
				_settings.Balance = (int)value;
			}, (float value) => StringUtils.FormatCurrency((int)value));
			CreateSlider(_config.KudoshName, _config.KudoshTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Kudosh, _config.KudoshOptions, delegate(float value)
			{
				_settings.Kudosh = (int)value;
			}, (float value) => StringUtils.FormatSilverCurrency((int)value));
			CreateSlider(_config.IncomeMultiplierName, _config.IncomeMultiplierTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.IncomeMultiplier, _config.IncomeMultiplier, delegate(float value)
			{
				_settings.IncomeMultiplier = value;
			}, (float value) => value.ToString("x 0.00"));
			CreateSlider(_config.PatientArrivalRateName, _config.PatientArrivalRateTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.PatientArrivalRate, _config.PatientArrivalRateOptions, delegate(float value)
			{
				_settings.PatientArrivalRate = value;
			}, (float value) => value.ToString("x 0.00"));
			CreateToggle(_config.IllnessesName, _config.IllnessesTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.GetIllnessListIndex(), _config.WeightedIllnesses, delegate(int value)
			{
				_settings.SetIllnessListIndex(value);
			});
			CreateToggle(_config.ObjectivesName, _config.ObjectivesTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.GetLevelScriptIndex(), _config.LevelScripts, delegate(int value)
			{
				_settings.SetLevelScriptIndex(value);
			});
			CreateToggle(_config.JobApplicantsName, _config.JobApplicantsTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.GetJobApplicantsIndex(), _config.JobApplicants, delegate(int value)
			{
				_settings.SetJobApplicantsIndex(value);
			});
			CreateToggle(_config.TemperatureName, _config.TemperatureTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.Temperature, _config.TemperatureOptions, delegate(int value)
			{
				_settings.Temperature = value;
			});
			CreateToggle(_config.RoomsName, _config.RoomsTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Rooms, _config.RoomOptions, delegate(int value)
			{
				_settings.Rooms = value;
			});
			CreateToggle(_config.ItemsName, _config.ItemsTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Items, _config.ItemOptions, delegate(int value)
			{
				_settings.Items = value;
			});
			CreateToggle(_config.UpgradesName, _config.UpgradesTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Upgrades, _config.UpgradeOptions, delegate(int value)
			{
				_settings.Upgrades = value;
			});
			CreateToggle(_config.PlotsName, _config.PlotsTooltip, canBeEditedWhenPlayingLevel: false, () => _settings.Plots, _config.PlotOptions, delegate(int value)
			{
				_settings.Plots = value;
			});
			CreateToggle(_config.ChallengesStaffName, _config.ChallengesStaffTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.ChallengesStaff, _config.OnOffOptions, delegate(int value)
			{
				_settings.ChallengesStaff = value;
			});
			CreateToggle(_config.ChallengesPatientsName, _config.ChallengesPatientsTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.ChallengesPatient, _config.OnOffOptions, delegate(int value)
			{
				_settings.ChallengesPatient = value;
			});
			CreateToggle(_config.ChallengesVIPsName, _config.ChallengesVIPsTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.ChallengesVisitor, _config.OnOffOptions, delegate(int value)
			{
				_settings.ChallengesVisitor = value;
			});
			CreateToggle(_config.ChallengesDisastersName, _config.ChallengesDisastersTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.ChallengesDisasters, _config.OnOffOptions, delegate(int value)
			{
				_settings.ChallengesDisasters = value;
			});
			CreateToggle(_config.ChallengesEpidemicsName, _config.ChallengesEpidemicsTooltip, canBeEditedWhenPlayingLevel: true, () => _settings.ChallengesEpidemics, _config.OnOffOptions, delegate(int value)
			{
				_settings.ChallengesEpidemics = value;
			});
		}

		private void RefreshSettings()
		{
			SaveFileHeader saveFileHeader = GetSaveFileHeader();
			bool flag = _tabMode != TabMode.BrowseWorkshop;
			bool flag2 = saveFileHeader != null || IsPlayingLevel;
			_infoMenu.Refresh(saveFileHeader, _settings, _dlcAndUGCPresence);
			GameObjectUtils.SetActive(_helpPanel, _tabMode == TabMode.NewGame);
			GameObjectUtils.SetActive(_infoMenu.gameObject, _tabMode != TabMode.NewGame);
			foreach (SandboxMenuSetting menuSetting in _menuSettings)
			{
				bool flag3 = !(!menuSetting.CanBeEditedWhenPlayingLevel && flag2) && flag;
				menuSetting.OnSettingChanged();
				menuSetting.SetActive(flag3);
				if (menuSetting.DisabledOverlay != null)
				{
					menuSetting.DisabledOverlay.SetActive(!flag3);
				}
			}
			if (PlatformFileManager.LimitNumberOfSandboxSaves)
			{
				_sandboxSaveCount.text = $"{_sandboxSaveManager.AllSettings.Count.ToString()} / {PlatformFileManager.MaxSandboxSaves}";
			}
			else
			{
				_sandboxSaveCount.text = _sandboxSaveManager.AllSettings.Count.ToString();
			}
			_buttonReset.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
		}

		private void RefreshWorkshopItemStatus(WorkshopInstalledItem workshopInstalledItem)
		{
			RefreshWorkshopItemStatus();
		}

		private void RefreshWorkshopItemStatus()
		{
			RefreshDLCAndUGCRequired();
			_infoMenu.RefreshContentRequiredInfo(_dlcAndUGCPresence);
		}

		private void ResetSettingsScrollbar()
		{
			_settingsScrollRect.verticalNormalizedPosition = 1f;
		}

		private SaveFileHeader GetSaveFileHeader()
		{
			if (_tabMode == TabMode.BrowseLocal)
			{
				return _saveSystem.GetSaveForSandbox(_settings);
			}
			if (_tabMode == TabMode.BrowseWorkshop)
			{
				return _workshopSetting.SaveFileHeader;
			}
			return null;
		}

		private void RefreshMapSelect()
		{
			switch (_tabMode)
			{
			case TabMode.NewGame:
				_mapSelectControl.Setup(canBeEditedWhenPlayingLevel: true, loop: true, _cachedLevelOptions.Values.ToArray(), CurrentMapIndex, OnMapSelected);
				break;
			case TabMode.BrowseLocal:
				_mapSelectControl.Setup(canBeEditedWhenPlayingLevel: true, loop: false, _cachedLocalSandboxOptions, CurrentSandboxIndex, OnSandboxSelected);
				break;
			case TabMode.BrowseWorkshop:
				_mapSelectControl.Setup(canBeEditedWhenPlayingLevel: true, loop: false, _cachedWorkshopSandboxOptions.ToArray(), CurrentWorkshopSandboxIndex, OnWorkshopSandboxSelected);
				break;
			}
		}

		private void RefreshButtons()
		{
			bool flag = _tabMode == TabMode.NewGame;
			bool flag2 = _tabMode == TabMode.BrowseLocal;
			bool flag3 = _tabMode == TabMode.BrowseWorkshop;
			bool flag4 = _sandboxSaveManager.AllSettings.Count != 0;
			bool flag5 = _workshopSettings.Count != 0;
			bool flag6 = _dlcAndUGCPresence.missingDLCThatPreventsLevelStart.Count == 0;
			bool flag7 = _dlcAndUGCPresence.missingDLC.Count == 0;
			_buttonNew.CurrentState = ((flag || !_sandboxSaveManager.CanCreateNewSave()) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			_buttonBrowse.CurrentState = ((flag2 || !flag4) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			_buttonBrowseCloud.CurrentState = ((flag3 || !flag5) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			GameObjectUtils.SetActive(_newGameButtons, flag);
			GameObjectUtils.SetActive(_browseGameButtons, flag2);
			GameObjectUtils.SetActive(_browseCloudButtons, flag3);
			SetTabTint(_newGamePanel, flag ? _selectedTabTint : _unselectedTabTint, selectable: true);
			SetTabTint(_browseGamePanel, flag2 ? _selectedTabTint : _unselectedTabTint, flag4);
			SetTabTint(_browseCloudPanel, flag3 ? _selectedTabTint : _unselectedTabTint, flag5);
			switch (_tabMode)
			{
			case TabMode.NewGame:
				_newGamePanel.transform.SetSiblingIndex(2);
				break;
			case TabMode.BrowseLocal:
				_browseGamePanel.transform.SetSiblingIndex(2);
				_buttonRestart.CurrentState = ((!flag6) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_buttonContinue.CurrentState = ((!flag7) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				break;
			case TabMode.BrowseWorkshop:
				_browseCloudPanel.transform.SetSiblingIndex(2);
				_buttonLoadCloudSave.CurrentState = ((!flag7) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				break;
			}
		}

		private void SetTabTint(GameObject panel, Color tint, bool selectable)
		{
			CanvasGroup component = panel.GetComponent<CanvasGroup>();
			if (component != null)
			{
				component.alpha = (selectable ? 1f : 0.5f);
			}
			for (int i = 0; i < panel.transform.childCount; i++)
			{
				Image component2 = panel.transform.GetChild(i).GetComponent<Image>();
				if (component2 != null)
				{
					component2.color = (selectable ? tint : _selectedTabTint);
				}
			}
		}

		private T CreateMenuSetting<T>(GameObject prefab) where T : SandboxMenuSetting
		{
			T component = UnityEngine.Object.Instantiate(prefab, _settingsRoot).GetComponent<T>();
			_menuSettings.Add(component);
			return component;
		}

		private void CreateToggle(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<int> getValue, IEnumerable<SandboxToggleOption> options, Action<int> valueChanged)
		{
			CreateMenuSetting<SandboxMenuSettingToggle>(_prefabSettingToggle).Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel, getValue, options.ToArray(), valueChanged.InvokeSafe<int>);
		}

		private void CreateInput(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<string> getValue, int maxCharacters, Action<string> valueChanged)
		{
			CreateMenuSetting<SandboxMenuSettingInput>(_prefabSettingInput).Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel, getValue, maxCharacters, valueChanged.InvokeSafe<string>);
		}

		private void CreateSlider(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel, Func<float> getValue, SandboxSliderOption option, Action<float> valueChanged, Func<float, string> format)
		{
			CreateMenuSetting<SandboxMenuSettingSlider>(_prefabSettingSlider).Setup(settingName, settingTooltip, canBeEditedWhenPlayingLevel, getValue, option, valueChanged.InvokeSafe<float>, format);
		}

		private SandboxSettings ChooseAppropriateSandboxToDisplay()
		{
			if (SandboxSaveManager.CurrentSettings == null)
			{
				return _sandboxSaveManager.AllSettings[0];
			}
			return SandboxSaveManager.CurrentSettings;
		}

		private WorkshopSetting ChooseAppropriateWorkshopSandboxToDisplay()
		{
			return _workshopSettings[0];
		}

		private void OnNewGameTab()
		{
			_tabMode = TabMode.NewGame;
			_settings = new SandboxSettings(_config);
			OnSetSandboxName(_settings.DisplayName);
			RefreshDLCAndUGCRequired();
			RefreshMapSelect();
			ResetSettingsScrollbar();
			RefreshSettings();
			RefreshButtons();
		}

		private void OnBrowseGamesTab()
		{
			_tabMode = TabMode.BrowseLocal;
			_settings = ChooseAppropriateSandboxToDisplay();
			RefreshDLCAndUGCRequired();
			RefreshMapSelect();
			ResetSettingsScrollbar();
			RefreshSettings();
			RefreshButtons();
			OnSetSandboxName(_settings.DisplayName);
		}

		private void OnBrowseWorkshopTab()
		{
			CacheWorkshopSaves();
			_tabMode = TabMode.BrowseWorkshop;
			_workshopSetting = ChooseAppropriateWorkshopSandboxToDisplay();
			_settings = _workshopSetting.Settings;
			RefreshDLCAndUGCRequired();
			RefreshMapSelect();
			ResetSettingsScrollbar();
			RefreshSettings();
			RefreshButtons();
			OnSetSandboxName(_settings.DisplayName);
		}

		private void OnResetSettings()
		{
			_settings.Reset();
			_userSetName = false;
			SetSandboxNameFromMap();
			RefreshDLCAndUGCRequired();
			RefreshMapSelect();
			ResetSettingsScrollbar();
			RefreshSettings();
			RefreshButtons();
		}

		private void OnSandboxDeleted(SandboxSettings settings)
		{
			CacheSandboxData();
			if (_sandboxSaveManager.AllSettings.Count == 0)
			{
				OnNewGameTab();
				return;
			}
			_tabMode = TabMode.BrowseLocal;
			_settings = _sandboxSaveManager.AllSettings[Mathf.Max(_mapSelectControl.CardIndex - 1, 0)];
			RefreshDLCAndUGCRequired();
			RefreshMapSelect();
			ResetSettingsScrollbar();
			RefreshSettings();
			RefreshButtons();
			_mapSelectControl.OnSettingChanged();
		}

		private void OnSandboxSelected(int value)
		{
			_settings = _sandboxSaveManager.AllSettings[value];
			RefreshDLCAndUGCRequired();
			RefreshSettings();
			RefreshButtons();
		}

		private void OnWorkshopSandboxSelected(int value)
		{
			_workshopSetting = _workshopSettings[value];
			_settings = _workshopSetting.Settings;
			RefreshDLCAndUGCRequired();
			RefreshSettings();
			RefreshButtons();
		}

		private void OnSetSandboxName(string sandboxName)
		{
			bool flag = string.IsNullOrWhiteSpace(sandboxName);
			if (flag && _settings.Name.IsNullOrEmpty())
			{
				SetSandboxNameFromMap();
			}
			else
			{
				if (flag)
				{
					sandboxName = _settings.LevelConfig.GetLocalisedDisplayName();
				}
				if (_settings.DisplayName != sandboxName)
				{
					_userSetName = true;
					_settings.DisplayName = sandboxName;
					if (_tabMode == TabMode.NewGame)
					{
						_settings.Name = _sandboxSaveManager.CreateUniqueSaveName(_settings.DisplayName);
					}
				}
			}
			if (_tabMode == TabMode.BrowseLocal)
			{
				_cachedLocalSandboxOptions[CurrentSandboxIndex()].Text = sandboxName;
				_mapSelectControl.Refresh(_cachedLocalSandboxOptions);
			}
			_infoMenu.Refresh(GetSaveFileHeader(), _settings, _dlcAndUGCPresence);
		}

		private void OnMapSelected(int mapIndex)
		{
			_settings.LevelConfig = _cachedLevelOptions.Keys.ToArray()[mapIndex];
			if (!_userSetName)
			{
				SetSandboxNameFromMap();
				RefreshDLCAndUGCRequired();
				RefreshSettings();
				RefreshButtons();
			}
		}

		private void SetSandboxNameFromMap()
		{
			_userSetName = false;
			_settings.DisplayName = _settings.LevelConfig.GetLocalisedDisplayName();
			_settings.Name = _sandboxSaveManager.CreateUniqueSaveName(_settings.DisplayName);
		}

		private bool ApplyAndSaveSettings()
		{
			if (_sandboxSaveManager.SaveSandboxSettings(_settings))
			{
				if (IsPlayingLevel)
				{
					_settings.Apply(_metagameMap.Level, playingLevel: true);
				}
				_settings.OnSettingsChanged.InvokeSafe();
				return true;
			}
			Logging.Error(LogChannels.Sandbox, "Failed to save sandbox settings ({0})", _settings.Name);
			return false;
		}

		private void OnStartGame()
		{
			if (ApplyAndSaveSettings())
			{
				StartOrContinueGame(newGame: true);
			}
		}

		private void StartOrContinueGame(bool newGame)
		{
			if (IsPlayingDifferentLevel() && !_metagameMap.App.UserPreferences.Game.AutoSaveOnLevelChange)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(OptionsMenu.ApplyLocalisationParam(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_CS, "CURRENT_LEVEL", SandboxSaveManager.CurrentSettings.DisplayName), _saveSystem), ScriptLocalization.Menu_Messages.ChangeLevelSave_CS, ScriptLocalization.Menu_Messages.ChangeLevelDontSave_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					StartLevel(saveOldLevel: true, newGame);
				}, delegate
				{
					StartLevel(saveOldLevel: false, newGame);
				});
			}
			else
			{
				StartLevel(saveOldLevel: true, newGame);
			}
		}

		private bool IsPlayingDifferentLevel()
		{
			if (SandboxSaveManager.CurrentSettings != null && SandboxSaveManager.CurrentSettings != _settings)
			{
				return _metagameMap.Metagame.CurrentLevel != null;
			}
			return false;
		}

		private void StartLevel(bool saveOldLevel, bool newGame)
		{
			if (_metagameMap.StateMachine.TopState is SandboxStatePlayer sandboxStatePlayer)
			{
				CloseMenuImmediately();
				sandboxStatePlayer.LaunchHospital(_settings, restartLevel: false, saveOldLevel, newGame);
			}
		}

		private void OnContinueGame()
		{
			if (_dlcAndUGCPresence.missingLocalUGCItems.Count > 0)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotPublished_Title_CS, ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotPublished_Body_CS, ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, OnContinueGameInner);
			}
			else if (_dlcAndUGCPresence.missingWorkshopItems.Count > 0)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotSubscribedTo_Title_CS, ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotSubscribedTo_Body_CS, ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, OnContinueGameInner);
			}
			else
			{
				OnContinueGameInner();
			}
		}

		private void OnContinueGameInner()
		{
			if (ApplyAndSaveSettings())
			{
				StartOrContinueGame(newGame: false);
			}
		}

		private void OnRestartGame()
		{
			_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
			_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Misc.RestartHospital_CS, ScriptLocalization.Misc.RestartHospitalWarning_CS, ScriptLocalization.Misc.Restart_CS, ScriptLocalization.Misc.Cancel_CS, TryRestartLevel);
		}

		private void TryRestartLevel()
		{
			if (IsPlayingDifferentLevel() && !_metagameMap.App.UserPreferences.Game.AutoSaveOnLevelChange)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(OptionsMenu.ApplyLocalisationParam(ScriptLocalization.Menu_Messages.AreYouSureChangeLevel_CS, "CURRENT_LEVEL", SandboxSaveManager.CurrentSettings.DisplayName), _saveSystem), ScriptLocalization.Menu_Messages.ChangeLevelSave_CS, ScriptLocalization.Menu_Messages.ChangeLevelDontSave_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, delegate
				{
					RestartLevel(saveOldLevel: true);
				}, delegate
				{
					RestartLevel(saveOldLevel: false);
				});
			}
			else
			{
				RestartLevel(saveOldLevel: true);
			}
		}

		private void RestartLevel(bool saveOldLevel)
		{
			if (_metagameMap.StateMachine.TopState is SandboxStatePlayer sandboxStatePlayer)
			{
				CloseMenuImmediately();
				sandboxStatePlayer.LaunchHospital(_settings, restartLevel: true, saveOldLevel);
			}
		}

		private void OnPublishGame()
		{
			if (_dlcAndUGCPresence.presentLocalUGCItems.Count > 0 || _dlcAndUGCPresence.missingLocalUGCItems.Count > 0)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages_UGC.SandboxSaveUsesLocalContent_Title_CS, ScriptLocalization.Menu_Messages_UGC.SandboxSaveUsesLocalContent_Body_CS + "\n\n" + ExtContentMessages.GetReferToUGCDocsMessage(), ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, OnPublishGameInner);
			}
			else
			{
				OnPublishGameInner();
			}
		}

		private void OnPublishGameInner()
		{
			Texture2D image = _cachedLocalSandboxOptions[CurrentSandboxIndex()].Image;
			if (_sandboxSaveManager.PublishWorkshopItem(_settings, image))
			{
				CacheWorkshopSaves();
			}
			else
			{
				_metagameMap.App.MessageBox.Show("Error!", "Failed to publish sandbox game", ScriptLocalization.Menu_Messages.OK_Button_CS);
			}
		}

		private void OnLoadWorkshopSave()
		{
			if (_dlcAndUGCPresence.missingLocalUGCItems.Count > 0)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotPublished_Title_CS, ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotPublished_Body_CS, ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, OnLoadWorkshopSaveInner);
			}
			else if (_dlcAndUGCPresence.missingWorkshopItems.Count > 0)
			{
				_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
				_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotSubscribedTo_Title_CS, ScriptLocalization.Menu_Messages_Sandbox.SandboxSaveUsesContentNotSubscribedTo_Body_CS, ScriptLocalization.Misc.Continue_CS, ScriptLocalization.Misc.Cancel_CS, OnLoadWorkshopSaveInner);
			}
			else
			{
				OnLoadWorkshopSaveInner();
			}
		}

		private void OnLoadWorkshopSaveInner()
		{
			if (_sandboxSaveManager.LoadWorkshopItem(_workshopSetting.Settings, _workshopSetting.WorkshopItem))
			{
				OnContinueGame();
			}
			else
			{
				_metagameMap.App.MessageBox.Show("Error!", "Failed to load sandbox game", ScriptLocalization.Menu_Messages.OK_Button_CS);
			}
		}

		private void OnDeleteGame()
		{
			_metagameMap.App.MessageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
			_metagameMap.App.MessageBox.ShowAsYesNo(ScriptLocalization.Menu_Sandbox.DeleteHospitalWarningTitle_CS, ScriptLocalization.Menu_Sandbox.DeleteHospitalWarningMessage_CS, ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, delegate
			{
				_metagameMap.App.SandboxSaveManager.Delete(_settings);
				_metagameMap.MapUI.RefreshMapPins();
			});
		}

		private void OnWorkshopOpen()
		{
			GameItemBase workshopItem = _workshopSetting.WorkshopItem;
			if (workshopItem?.PublishedWorkshopMetaData != null)
			{
				string publishedFileId = workshopItem.PublishedWorkshopMetaData.PublishedFileId;
				string steamURL = string.Empty;
				string browserURL = string.Empty;
				ExtContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForPublishedFileId(publishedFileId, ref steamURL, ref browserURL);
				WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
			}
		}

		private void RefreshDLCAndUGCRequired()
		{
			RefreshDLCAndUGCRequired(_dlcAndUGCPresence, _settings, GetSaveFileHeader(), _extContentManager);
		}

		private static void RefreshDLCAndUGCRequired(DLCAndUGCPresence dlcAndUGCPresence, SandboxSettings settings, SaveFileHeader saveHeader, ExtContentManager extContentManager)
		{
			DLCItemDefinition requiredDlcPack = settings.LevelConfig.GetRequiredDlcPack();
			dlcAndUGCPresence.presentDLC.Clear();
			dlcAndUGCPresence.missingDLC.Clear();
			dlcAndUGCPresence.missingDLCThatPreventsLevelStart.Clear();
			if (requiredDlcPack != null)
			{
				if (DLCUtils.IsDLCInstalled(requiredDlcPack))
				{
					dlcAndUGCPresence.presentDLC.Add(requiredDlcPack.AppID);
				}
				else
				{
					dlcAndUGCPresence.missingDLC.Add(requiredDlcPack.AppID);
					dlcAndUGCPresence.missingDLCThatPreventsLevelStart.Add(requiredDlcPack.AppID);
				}
			}
			HashSet<uint> hashSet = new HashSet<uint>();
			bool flag = false;
			foreach (WeightedIllness illness in settings.IllnessConfig.Illnesses)
			{
				SharedInstance<DLCItemDefinition> dLCPackRequired = illness.Definition.Instance.DLCPackRequired;
				if (dLCPackRequired != null)
				{
					uint appID = dLCPackRequired.Instance.AppID;
					hashSet.Add(appID);
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				foreach (uint item in hashSet)
				{
					if (DLCUtils.IsDLCInstalled(item))
					{
						dlcAndUGCPresence.presentDLC.AddUnique(item);
						continue;
					}
					dlcAndUGCPresence.missingDLC.AddUnique(item);
					dlcAndUGCPresence.missingDLCThatPreventsLevelStart.Add(item);
				}
			}
			if (saveHeader != null && saveHeader.UsedDLCAppIDs != null)
			{
				foreach (uint usedDLCAppID in saveHeader.UsedDLCAppIDs)
				{
					if (DLCUtils.IsDLCInstalled(usedDLCAppID))
					{
						dlcAndUGCPresence.presentDLC.AddUnique(usedDLCAppID);
					}
					else if (!_everLoggedInWithPrime || !_primeLootSharesDLC.Contains(usedDLCAppID))
					{
						dlcAndUGCPresence.missingDLC.AddUnique(usedDLCAppID);
					}
				}
			}
			dlcAndUGCPresence.presentWorkshopItems.Clear();
			dlcAndUGCPresence.missingWorkshopItems.Clear();
			if (saveHeader != null && saveHeader.UsedWorkshopItemPublishedFileIds != null && saveHeader.UsedWorkshopItemNames != null && saveHeader.UsedWorkshopItemPublishedFileIds.Count == saveHeader.UsedWorkshopItemNames.Count)
			{
				for (int i = 0; i < saveHeader.UsedWorkshopItemPublishedFileIds.Count; i++)
				{
					string workshopItemPublishedFileId = saveHeader.UsedWorkshopItemPublishedFileIds[i];
					string text = saveHeader.UsedWorkshopItemNames[i];
					if (extContentManager.ContentSourceWorkshop.InstalledItems.Find((WorkshopInstalledItem x) => x.PublishedFileId.ToString() == workshopItemPublishedFileId) != null)
					{
						dlcAndUGCPresence.presentWorkshopItems.Add(new IDAndName(workshopItemPublishedFileId, text));
					}
					else
					{
						dlcAndUGCPresence.missingWorkshopItems.Add(new IDAndName(workshopItemPublishedFileId, text));
					}
				}
			}
			dlcAndUGCPresence.presentLocalUGCItems.Clear();
			dlcAndUGCPresence.missingLocalUGCItems.Clear();
			if (saveHeader == null || saveHeader.UsedLocalUGCItemIDs == null || saveHeader.UsedLocalUGCItemNames == null || saveHeader.UsedLocalUGCItemIDs.Count != saveHeader.UsedLocalUGCItemNames.Count)
			{
				return;
			}
			for (int num = 0; num < saveHeader.UsedLocalUGCItemIDs.Count; num++)
			{
				string ugcItemID = saveHeader.UsedLocalUGCItemIDs[num];
				string text2 = saveHeader.UsedLocalUGCItemNames[num];
				if (extContentManager.ContentSourceLocalMods.GameItems.Find((GameItemBase x) => x.ContentID == ugcItemID) != null)
				{
					dlcAndUGCPresence.presentLocalUGCItems.Add(new IDAndName(ugcItemID, text2));
				}
				else
				{
					dlcAndUGCPresence.missingLocalUGCItems.Add(new IDAndName(ugcItemID, text2));
				}
			}
		}

		protected override void Update()
		{
			base.Update();
			ExtContentUtils.CheckShowGameItemDevInfoPanelInput(_workshopSetting.WorkshopItem);
		}
	}
}
