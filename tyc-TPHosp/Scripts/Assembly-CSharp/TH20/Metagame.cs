#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using TH20.Analytics;
using TH20.EventAwardRemixBadge;
using TH20.EventAwardSilver;
using TH20.EventAwardStar;
using TH20.EventPlayableHospital;
using TH20.EventUnlockHospital;
using TH20.EventUnlockItem;
using UnityConsole;
using UnityEngine;

namespace TH20
{
	public class Metagame : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<RoomDatabase> RoomDatabase;

			public SharedInstance<RoomItemDatabase> RoomItemDatabase;

			public SharedInstance<RoomItemDatabase> LandscapeItemDatabase;

			public SharedInstance<MetagameObjectiveManager.Config> MetagameObjectiveManagerConfig;

			public SharedInstance<LevelList> _levelList;

			public LevelList StartUnlockedList;

			public SharedInstance<MetagameCutsceneConfig> CutsceneConfig;

			public SharedInstance<RadioConfig> RadioConfig;

			public MetagameMapAmbienceConfig MetagameMapAmbienceConfig;

			public AudioClip[] MusicTracks;

			public GameObject MipMapVisualiserPrefab;

			public StaffCustomisationOptions StaffCustomisationOptions;

			public SharedInstance<LevelConfig> SandboxUnlockLevelConfig;

			public SharedInstance<LevelConfig> BigfootDLCCompleteLevelConfig;

			public SharedInstance<LevelConfig> JungleDLCCompleteLevelConfig;

			public SharedInstance<LevelConfig> CloseEncountersDLCLevelConfig;

			public SharedInstance<LevelConfig> LifeUniverseLevelComplete;

			public SharedInstance<LevelConfig> CollaborativePortfolioLevelConfig;

			public SharedInstance<LevelConfig> Region1FinalLevelConfig;

			public SharedInstance<LevelConfig> OffTheGridDLCLevelConfig;

			public SharedInstance<LevelConfig> CultureShockDLCLevelConfig;

			public SharedInstance<LevelConfig> TimeTravelDLCLevelConfig;

			public SharedInstance<LevelConfig> SpeedyRecoveryDLCLevelConfig;

			public SharedInstance<LevelConfig>[] Region1RemixConfigs;

			public SharedInstance<LevelConfig>[] Region2RemixConfigs;

			public GameObject SuperBugLetterPrefab;

			public int StartingShares = 10000;

			public float MinShareValue = 1f;

			public SharedInstance<SkipStateManager.Config> SkipStateManagerConfig;
		}

		[DontSave]
		public TH20.EventUnlockHospital.Action OnHospitalUnlocked;

		[DontSave]
		public TH20.EventPlayableHospital.Action OnHospitalBecamePlayable;

		[DontSave]
		public TH20.EventAwardStar.Action OnStarAwarded;

		[DontSave]
		public TH20.EventAwardSilver.Action OnSilverAwarded;

		[DontSave]
		public TH20.EventUnlockItem.Action OnItemUnlocked;

		[DontSave]
		public TH20.EventAwardRemixBadge.Action OnRemixBadgeAwarded;

		[DontSave]
		public Action<int> OnSharesChanged;

		private string _organisationName;

		private int _totalSilver;

		private int _totalSilverCumulative;

		private int _totalShares;

		private HUDSavedState _hudSavedState;

		private Dictionary<LevelConfig, MetagameHospitalRecord> _hospitalRecords;

		private Dictionary<string, MetagameHospitalRecord> _hospitalRecordsByLevelID;

		private HashSet<LevelConfig> _hasSeenUnlockCutscene;

		private readonly List<ISilverUnlockToken> _silverUnlockables;

		private readonly List<ResearchProjectDefinition> _completedResearchProjects;

		private Dictionary<ResearchProjectDefinition, float> _availableResearchProjects;

		private readonly MetagameObjectiveManager _objectiveManager;

		private readonly MetagameCutsceneEvents _cutsceneEvents;

		private OnlineChallengeViewRecord _onlineChallengeViewRecord;

		private List<LevelConfig> _newlyVisibleLevels = new List<LevelConfig>();

		private List<LevelConfig> _newlyUnlockedLevels = new List<LevelConfig>();

		private List<LevelConfig> _newlyPlayableLevels = new List<LevelConfig>();

		private List<LevelConfig> _levelsNotPlayed = new List<LevelConfig>();

		private RadioStatus _radioStatus;

		private CollaborativeMetagameData _collaborativeMetagameData;

		[DontSave]
		private Config _config;

		[DontSave]
		private App _app;

		private string _lastPlayedLevelID;

		private int _playthroughID;

		private List<string> _unlockMeTagList;

		[DontSave]
		private Level _currentLevel;

		[DontSave]
		private MetagameMapAnalytics _metagameMapAnalytics;

		[DontSave]
		private OnlineMetadataManager _onlineMetadataManager;

		[DontSave]
		private CareerStatsManager _careerStatsManager;

		[DontSave]
		private HighlightManager _highlightManager;

		[DontSave]
		private ObjectiveEvents _objectiveEvents;

		[DontSave]
		private LevelEventsIntermediary _levelEventsIntermediary;

		[DontSave]
		private Preferences _userPreferences;

		[DontSave]
		private bool _hasUnsavedChangesHighImportance;

		[DontSave]
		private bool _hasUnsavedChangesMediumImportance;

		[DontSave]
		private bool _hasUnsavedChangesLowImportance;

		[DontSave]
		public bool GiveAllCollaborativeRewards;

		[DontSave]
		private SkipStateManager _skipStateManager;

		public bool HasSeenBigfootCompleteEvent { get; set; }

		public bool HasSeenJungleCompleteEvent { get; set; }

		public bool HasSeenCloseEncountersCompleteEvent { get; set; }

		public bool HasSeenOffTheGridCompleteEvent { get; set; }

		public bool HasSeenCultureShockCompleteEvent { get; set; }

		public bool HasSeenTimeTravelCompleteEvent { get; set; }

		public bool HasSeenRemixRegion1UnlockEvent { get; set; }

		public bool HasSeenEmergencyPostCutsceneEvent { get; set; }

		public App App => _app;

		public OnlineMetadataManager OnlineMetadataManager => _onlineMetadataManager;

		public CareerStatsManager CareerStatsManager => _careerStatsManager;

		public RadioStatus RadioStatus => _radioStatus;

		public CollaborativeMetagameData CollaborativeMetagameData => _collaborativeMetagameData;

		public CollaborativePortfolio CollaborativePortfolio => _app.CollaborativePortfolio;

		public SuperBugProjectManager SuperBugManager => _app.SuperBugManager;

		public ObjectiveEvents ObjectiveEvents => _objectiveEvents;

		public MetagameObjectiveManager ObjectiveManager => _objectiveManager;

		public MetagameCutsceneEvents CutsceneEvents => _cutsceneEvents;

		public OnlineChallengeViewRecord OnlineChallengeViewRecord => _onlineChallengeViewRecord;

		public LevelEventsIntermediary LevelEventsIntermediary => _levelEventsIntermediary;

		public string LastPlayedLevelID => _lastPlayedLevelID;

		public Level CurrentLevel => _currentLevel;

		public Config MetagameConfig => _config;

		public HighlightManager HighlightManager => _highlightManager;

		public SharedInstance<RoomDatabase> RoomDatabase => _config.RoomDatabase;

		public SharedInstance<RoomItemDatabase> RoomItemDatabase => _config.RoomItemDatabase;

		public SharedInstance<RoomItemDatabase> LandscapeItemDatabase => _config.LandscapeItemDatabase;

		public LevelList LevelList => _config._levelList.Instance;

		public List<LevelConfig> VisibleLevels
		{
			get
			{
				List<string> list = _hospitalRecordsByLevelID.Where(delegate(KeyValuePair<string, MetagameHospitalRecord> record)
				{
					KeyValuePair<string, MetagameHospitalRecord> keyValuePair = record;
					return keyValuePair.Value.IsVisible();
				}).Select(delegate(KeyValuePair<string, MetagameHospitalRecord> record)
				{
					KeyValuePair<string, MetagameHospitalRecord> keyValuePair = record;
					return keyValuePair.Key;
				}).ToList();
				List<LevelConfig> list2 = new List<LevelConfig>();
				foreach (string item in list)
				{
					LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item);
					list2.Add(levelConfigByID);
				}
				return list2;
			}
		}

		public int NumLevelsNotPlayed
		{
			get
			{
				if (_currentLevel != null)
				{
					_levelsNotPlayed.Remove(_currentLevel.Config);
				}
				return _levelsNotPlayed.Count;
			}
		}

		public List<string> UnlockMeTagList => _unlockMeTagList;

		public string OrganisationName
		{
			get
			{
				return _organisationName;
			}
			set
			{
				string organisationName = _organisationName;
				_organisationName = value;
				_hasUnsavedChangesHighImportance = true;
				this.OnOrganisationNameChanged?.Invoke(organisationName, _organisationName);
			}
		}

		public SkipStateManager SkipStateManager => _skipStateManager;

		public List<ISilverUnlockToken> SilverUnlockables => _silverUnlockables;

		public List<ResearchProjectDefinition> CompletedResearchProjects => _completedResearchProjects;

		public int PlaythroughID => _playthroughID;

		public event Action<string, string> OnOrganisationNameChanged;

		public Metagame(Config config, App app)
		{
			CreateAndBindEvents();
			_config = config;
			_app = app;
			_organisationName = LocalizationManager.GetTranslation("Menu/Metagame/Foundation/Two Point Foundation");
			_totalShares = config.StartingShares;
			_playthroughID = RandomUtils.GlobalRandomInstance.Next();
			_metagameMapAnalytics = new MetagameMapAnalytics(this, app.AnalyticsManager);
			_hospitalRecordsByLevelID = new Dictionary<string, MetagameHospitalRecord>();
			_hasSeenUnlockCutscene = new HashSet<LevelConfig>();
			foreach (SharedInstance<LevelConfig> level in _config._levelList.Instance.Levels)
			{
				_hospitalRecordsByLevelID.Add(level.Instance.UniqueId, new MetagameHospitalRecord());
			}
			_objectiveEvents = new ObjectiveEvents();
			_levelEventsIntermediary = new LevelEventsIntermediary(app);
			_objectiveManager = new MetagameObjectiveManager(_config.MetagameObjectiveManagerConfig.Instance, this);
			_cutsceneEvents = new MetagameCutsceneEvents(this);
			_onlineChallengeViewRecord = new OnlineChallengeViewRecord(this);
			_collaborativeMetagameData = new CollaborativeMetagameData(app, this);
			_onlineMetadataManager = new OnlineMetadataManager(app, this);
			_careerStatsManager = new CareerStatsManager(this);
			_highlightManager = new HighlightManager();
			_silverUnlockables = new List<ISilverUnlockToken>();
			_completedResearchProjects = new List<ResearchProjectDefinition>();
			_availableResearchProjects = new Dictionary<ResearchProjectDefinition, float>();
			_radioStatus = new RadioStatus(_config.RadioConfig.Instance, app.DynamicPlaylistManager);
			_hudSavedState = new HUDSavedState();
			_unlockMeTagList = new List<string>();
			RegisterEvents();
			RegisterDebugCommands();
			foreach (SharedInstance<LevelConfig> level2 in config.StartUnlockedList.Levels)
			{
				UnlockItem(level2.Instance, spendSilver: false, showMessage: false);
			}
			UnlockFreeCustomisationOptions();
			UpdateLevelProgression();
			GetAndClearNewlyVisibleLevels();
			GetAndClearNewlyUnlockedLevels();
			GetAndClearNewlyPlayableLevels();
			_skipStateManager = new SkipStateManager(_config.SkipStateManagerConfig.Instance, _app, this);
			VerifyDatabases();
		}

		private void VerifyDatabases()
		{
			SharedInstance<RoomDefinition>[] rooms = RoomDatabase.Instance.Rooms;
			for (int i = 0; i < rooms.Length; i++)
			{
				_ = rooms[i];
			}
			SharedInstance<RoomItemDefinition>[] roomItems = RoomItemDatabase.Instance.RoomItems;
			for (int i = 0; i < roomItems.Length; i++)
			{
				_ = roomItems[i];
			}
			roomItems = LandscapeItemDatabase.Instance.RoomItems;
			for (int i = 0; i < roomItems.Length; i++)
			{
				_ = roomItems[i];
			}
		}

		public void RestoreFromSave(Config config, App app)
		{
			_config = config;
			_app = app;
			VerifyDatabases();
			if (_levelsNotPlayed == null)
			{
				_levelsNotPlayed = new List<LevelConfig>();
			}
			CreateAndBindEvents();
			_metagameMapAnalytics = new MetagameMapAnalytics(this, app.AnalyticsManager);
			if (_hospitalRecordsByLevelID == null)
			{
				_hospitalRecordsByLevelID = new Dictionary<string, MetagameHospitalRecord>();
			}
			if (_hospitalRecords != null)
			{
				foreach (KeyValuePair<LevelConfig, MetagameHospitalRecord> hospitalRecord in _hospitalRecords)
				{
					if (hospitalRecord.Value != null)
					{
						if (!_hospitalRecordsByLevelID.ContainsKey(hospitalRecord.Key.UniqueId))
						{
							_hospitalRecordsByLevelID.Add(hospitalRecord.Key.UniqueId, hospitalRecord.Value);
						}
						else
						{
							_hospitalRecordsByLevelID[hospitalRecord.Key.UniqueId] = hospitalRecord.Value;
						}
						Logging.AlwaysLog(LogChannels.Debug, "Moving hospital record for level: {0} from legacy dictionary to new one", hospitalRecord.Key.UniqueId);
					}
				}
				_hospitalRecords = null;
			}
			foreach (string item in (from x in _hospitalRecordsByLevelID
				select x.Key into x
				where _config._levelList.Instance.Levels.Find((SharedInstance<LevelConfig> l) => l.Instance.UniqueId == x) == null
				select x).ToList())
			{
				if (item == null)
				{
					Logging.Error(LogChannels.Metagame, "Hospital record found in metagame for null level.");
					continue;
				}
				Logging.Warning(LogChannels.Metagame, "Hospital record found in metagame for level which doesn't exist in level list. Removing: {0}", item);
				_hospitalRecordsByLevelID.Remove(item);
			}
			foreach (SharedInstance<LevelConfig> level in _config._levelList.Instance.Levels)
			{
				if (!_hospitalRecordsByLevelID.ContainsKey(level.Instance.UniqueId))
				{
					Logging.AlwaysLog(LogChannels.Debug, "Adding hospital record for level: {0}", level.Instance.UniqueId);
					_hospitalRecordsByLevelID.Add(level.Instance.UniqueId, new MetagameHospitalRecord());
				}
			}
			if (_hasSeenUnlockCutscene == null)
			{
				_hasSeenUnlockCutscene = new HashSet<LevelConfig>();
			}
			_objectiveEvents = new ObjectiveEvents();
			_highlightManager = new HighlightManager();
			_levelEventsIntermediary = new LevelEventsIntermediary(app);
			if (_onlineChallengeViewRecord == null)
			{
				_onlineChallengeViewRecord = new OnlineChallengeViewRecord(this);
			}
			else
			{
				_onlineChallengeViewRecord.RestoreFromSave(this);
			}
			if (_collaborativeMetagameData != null)
			{
				_collaborativeMetagameData.RestoreFromSave(app, this);
			}
			else
			{
				_collaborativeMetagameData = new CollaborativeMetagameData(app, this);
			}
			_silverUnlockables.RemoveAll((ISilverUnlockToken x) => x == null);
			if (_availableResearchProjects == null)
			{
				_availableResearchProjects = new Dictionary<ResearchProjectDefinition, float>();
			}
			_completedResearchProjects.RemoveAll((ResearchProjectDefinition x) => x == null);
			if (_radioStatus == null)
			{
				_radioStatus = new RadioStatus(_config.RadioConfig.Instance, app.DynamicPlaylistManager);
			}
			else
			{
				_radioStatus.RestoreFromSave(_config.RadioConfig.Instance, app.DynamicPlaylistManager);
			}
			if (_hudSavedState == null)
			{
				_hudSavedState = new HUDSavedState();
			}
			if (_unlockMeTagList == null)
			{
				_unlockMeTagList = new List<string>();
			}
			_objectiveManager.RestoreFromSave(_config.MetagameObjectiveManagerConfig.Instance, this);
			_cutsceneEvents.RestoreFromSave(this);
			_onlineMetadataManager = new OnlineMetadataManager(app, this);
			_careerStatsManager = new CareerStatsManager(this);
			RegisterEvents();
			RegisterDebugCommands();
			foreach (SharedInstance<LevelConfig> level2 in config.StartUnlockedList.Levels)
			{
				UnlockItem(level2.Instance, spendSilver: false, showMessage: false);
			}
			UpdateLevelProgression();
			UnlockFreeCustomisationOptions();
			AwardPrimeGamingKudosh();
			GetAndClearNewlyVisibleLevels();
			GetAndClearNewlyUnlockedLevels();
			GetAndClearNewlyPlayableLevels();
			_skipStateManager = new SkipStateManager(_config.SkipStateManagerConfig.Instance, _app, this);
		}

		private void UnlockFreeCustomisationOptions()
		{
			CustomisationOption[] doctor = _config.StaffCustomisationOptions.Doctor;
			foreach (CustomisationOption customisationOption in doctor)
			{
				if (customisationOption.SilverCost() <= 0)
				{
					UnlockItem(customisationOption, spendSilver: false, showMessage: false);
				}
			}
			doctor = _config.StaffCustomisationOptions.Nurse;
			foreach (CustomisationOption customisationOption2 in doctor)
			{
				if (customisationOption2.SilverCost() <= 0)
				{
					UnlockItem(customisationOption2, spendSilver: false, showMessage: false);
				}
			}
			doctor = _config.StaffCustomisationOptions.Assistant;
			foreach (CustomisationOption customisationOption3 in doctor)
			{
				if (customisationOption3.SilverCost() <= 0)
				{
					UnlockItem(customisationOption3, spendSilver: false, showMessage: false);
				}
			}
			doctor = _config.StaffCustomisationOptions.Janitor;
			foreach (CustomisationOption customisationOption4 in doctor)
			{
				if (customisationOption4.SilverCost() <= 0)
				{
					UnlockItem(customisationOption4, spendSilver: false, showMessage: false);
				}
			}
		}

		public void AwardPrimeGamingKudosh()
		{
			if (_app == null || _app.GameMode is GameModeSandbox)
			{
				return;
			}
			List<string>[] primeGamingKudoshIDsClaimed = _app.UserProfile.PrimeGamingKudoshIDsClaimed;
			List<string> list = primeGamingKudoshIDsClaimed[_app.SaveSystem.CurrentSaveSlot];
			string[] dropIDsWithKudosh = _app.PrimeGaming.DropIDsWithKudosh;
			foreach (string item in dropIDsWithKudosh)
			{
				if (_app.UserProfile.PrimeGamingEntitlements.Contains(item) && !list.Contains(item))
				{
					AwardSilver(_app.PrimeGaming.StandardKudoshAward);
					list.Add(item);
				}
			}
			primeGamingKudoshIDsClaimed[_app.SaveSystem.CurrentSaveSlot] = list;
			_app.UserProfile.PrimeGamingKudoshIDsClaimed = primeGamingKudoshIDsClaimed;
		}

		private void CreateAndBindEvents()
		{
			GameEventsRegistry.RegisterGlobalEvent(this);
			OnHospitalUnlocked = new TH20.EventUnlockHospital.Action();
			OnHospitalBecamePlayable = new TH20.EventPlayableHospital.Action();
			OnStarAwarded = new TH20.EventAwardStar.Action();
			OnSilverAwarded = new TH20.EventAwardSilver.Action();
			OnItemUnlocked = new TH20.EventUnlockItem.Action();
			OnRemixBadgeAwarded = new TH20.EventAwardRemixBadge.Action();
		}

		private void RegisterEvents()
		{
			LevelEventsIntermediary levelEventsIntermediary = _levelEventsIntermediary;
			levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			LevelEventsIntermediary levelEventsIntermediary2 = _levelEventsIntermediary;
			levelEventsIntermediary2.OnBalanceUpdated = (Action<int>)Delegate.Combine(levelEventsIntermediary2.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			LevelEventsIntermediary levelEventsIntermediary3 = _levelEventsIntermediary;
			levelEventsIntermediary3.OnReputationChanged = (Action<float>)Delegate.Combine(levelEventsIntermediary3.OnReputationChanged, new Action<float>(OnReputationChanged));
			LevelEventsIntermediary levelEventsIntermediary4 = _levelEventsIntermediary;
			levelEventsIntermediary4.OnPrestigeChanged = (Action<PrestigeTracker>)Delegate.Combine(levelEventsIntermediary4.OnPrestigeChanged, new Action<PrestigeTracker>(OnPrestigeChanged));
			LevelEventsIntermediary levelEventsIntermediary5 = _levelEventsIntermediary;
			levelEventsIntermediary5.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(levelEventsIntermediary5.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			LevelEventsIntermediary levelEventsIntermediary6 = _levelEventsIntermediary;
			levelEventsIntermediary6.OnSandboxResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(levelEventsIntermediary6.OnSandboxResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Combine(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
		}

		public override void Destroy()
		{
			UnregisterDebugCommands();
			App app = _app;
			app.OnLevelLoaded = (Action<Level, bool>)Delegate.Remove(app.OnLevelLoaded, new Action<Level, bool>(OnLevelLoaded));
			LevelEventsIntermediary levelEventsIntermediary = _levelEventsIntermediary;
			levelEventsIntermediary.OnEndOfMonthStatsCompiled = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelEventsIntermediary.OnEndOfMonthStatsCompiled, new Action<LevelStatsDatabase.MonthStats>(OnEndOfMonthStatsCompiled));
			LevelEventsIntermediary levelEventsIntermediary2 = _levelEventsIntermediary;
			levelEventsIntermediary2.OnBalanceUpdated = (Action<int>)Delegate.Remove(levelEventsIntermediary2.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			LevelEventsIntermediary levelEventsIntermediary3 = _levelEventsIntermediary;
			levelEventsIntermediary3.OnReputationChanged = (Action<float>)Delegate.Remove(levelEventsIntermediary3.OnReputationChanged, new Action<float>(OnReputationChanged));
			LevelEventsIntermediary levelEventsIntermediary4 = _levelEventsIntermediary;
			levelEventsIntermediary4.OnPrestigeChanged = (Action<PrestigeTracker>)Delegate.Remove(levelEventsIntermediary4.OnPrestigeChanged, new Action<PrestigeTracker>(OnPrestigeChanged));
			LevelEventsIntermediary levelEventsIntermediary5 = _levelEventsIntermediary;
			levelEventsIntermediary5.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(levelEventsIntermediary5.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			LevelEventsIntermediary levelEventsIntermediary6 = _levelEventsIntermediary;
			levelEventsIntermediary6.OnSandboxResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(levelEventsIntermediary6.OnSandboxResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			_collaborativeMetagameData.Destroy();
			_cutsceneEvents.Destroy();
			_objectiveManager.Destroy();
			_highlightManager.Destroy();
			_onlineChallengeViewRecord.Destroy();
			_careerStatsManager.Destroy();
			_radioStatus.Destroy();
			_onlineMetadataManager.Destroy();
			_levelEventsIntermediary.Destroy();
			_metagameMapAnalytics.Destroy();
			_skipStateManager.Destroy();
			base.Destroy();
		}

		public void VerifyEvents()
		{
		}

		public void Update(float timeDelta, float unscaledTimeDelta)
		{
			_objectiveManager.Update(timeDelta, unscaledTimeDelta);
			_highlightManager.Update();
			bool flag = _hasUnsavedChangesLowImportance || _hasUnsavedChangesMediumImportance || _hasUnsavedChangesHighImportance;
			bool flag2 = _hasUnsavedChangesMediumImportance || _hasUnsavedChangesHighImportance;
			if (DebugVars.EnableAutoSaveMetagameOnChange.Value && ((_app.UserPreferences.Game.CareerAutoSaveFrequency == Preferences.GamePreferences.CareerAutoSaveFrequencyOption.EveryChange && flag) || (_app.UserPreferences.Game.CareerAutoSaveFrequency == Preferences.GamePreferences.CareerAutoSaveFrequencyOption.MostChanges && flag2) || (_app.UserPreferences.Game.CareerAutoSaveFrequency == Preferences.GamePreferences.CareerAutoSaveFrequencyOption.ImportantChangesOnly && _hasUnsavedChangesHighImportance)))
			{
				_hasUnsavedChangesHighImportance = false;
				_hasUnsavedChangesMediumImportance = false;
				_hasUnsavedChangesLowImportance = false;
				_app.SaveMetagameDeferred();
			}
		}

		public void SetCurrentLevel(Level currentLevel)
		{
			_currentLevel = currentLevel;
			_lastPlayedLevelID = ((_currentLevel == null) ? null : _currentLevel.UniqueID);
		}

		public int LevelPlaythroughID(LevelConfig config)
		{
			return GetHospitalRecord(config)?.LevelPlaythroughID() ?? (-1);
		}

		[CanBeNull]
		public MetagameHospitalRecord GetHospitalRecord(LevelConfig level, bool canBeNull = false)
		{
			MetagameHospitalRecord metagameHospitalRecord = (_hospitalRecordsByLevelID.ContainsKey(level.UniqueId) ? _hospitalRecordsByLevelID[level.UniqueId] : null);
			if (!canBeNull && metagameHospitalRecord == null && SandboxSaveManager.CurrentSettings == null)
			{
				Logging.Error(LogChannels.Metagame, "Missing hospital record for level {0}, did you forget to add it to the metagame config level list?", level.GetDisplayName());
			}
			return metagameHospitalRecord;
		}

		public int TotalStars()
		{
			int num = 0;
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				if (item.Value != null)
				{
					num += item.Value.TotalStars();
				}
			}
			return num;
		}

		public int TotalRemixBadges()
		{
			int num = 0;
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				if (item.Value != null)
				{
					num += (item.Value.HasRemixBadgeBeenAwarded() ? 1 : 0);
				}
			}
			return num;
		}

		public int TotalSilver()
		{
			return _totalSilver;
		}

		public int TotalSilverCumulative()
		{
			return _totalSilverCumulative;
		}

		public int TotalFoundationValue()
		{
			int num = 0;
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				if (levelConfigByID != null && !levelConfigByID.IsDebugLevel)
				{
					MetagameHospitalRecord value = item.Value;
					if ((value.HasPlayed() || !levelConfigByID.IssueSharesOnStart) && value.GetRecordData() != null)
					{
						num = FinanceManager.AddBalance(num, value.GetHospitalValue());
					}
				}
			}
			return num;
		}

		public float GetShareValue()
		{
			return Mathf.Max((float)TotalFoundationValue() / (float)_totalShares, _config.MinShareValue);
		}

		public int GetNumShares()
		{
			return _totalShares;
		}

		public void IssueSharesForLevel(LevelConfig levelConfig)
		{
			MetagameHospitalRecord hospitalRecord = GetHospitalRecord(levelConfig);
			if (hospitalRecord != null)
			{
				int initialBalance = levelConfig.GetFinanceManagerConfig().GetInitialBalance();
				float shareValue = GetShareValue();
				int num = ((shareValue > 0f) ? Mathf.CeilToInt((float)initialBalance / shareValue) : initialBalance);
				AddShares(num);
				hospitalRecord.SetSharesUsed(num);
				_hasUnsavedChangesMediumImportance = true;
			}
		}

		public void ResetShares(MetagameHospitalRecord record)
		{
			if (record != null && record.GetRecordData() != null)
			{
				int sharesUsed = record.GetSharesUsed();
				if (sharesUsed > 0)
				{
					record.SetSharesUsed(0);
					AddShares(-sharesUsed);
					_hasUnsavedChangesMediumImportance = true;
				}
			}
		}

		private void AddShares(int numShares)
		{
			_totalShares += numShares;
			_totalShares = Mathf.Max(_config.StartingShares, _totalShares);
			OnSharesChanged.InvokeSafe(_totalShares);
		}

		public void AwardRemixBadge(LevelConfig levelConfig, bool debug)
		{
			_hospitalRecordsByLevelID[levelConfig.UniqueId].AwardRemixBadge();
			UpdateLevelProgression();
			if (debug)
			{
				GetAndClearNewlyVisibleLevels();
				GetAndClearNewlyUnlockedLevels();
				GetAndClearNewlyPlayableLevels();
			}
			_hasUnsavedChangesHighImportance = true;
			OnRemixBadgeAwarded.InvokeSafe(levelConfig, debug);
		}

		public void AwardStar(MetagameHospitalRecord.StarIndex index, LevelConfig levelConfig, bool debug)
		{
			for (int i = 0; i < (int)index; i++)
			{
				if (!_hospitalRecordsByLevelID[levelConfig.UniqueId].HasStarBeenAwarded(i))
				{
					Logging.Warning(LogChannels.Metagame, "Attempting to award star {0} when star {1} hasn't been awarded yet!", index, (MetagameHospitalRecord.StarIndex)i);
				}
			}
			_hospitalRecordsByLevelID[levelConfig.UniqueId].AwardStar(index);
			Logging.AlwaysLog(LogChannels.Metagame, "Awarded star {0} for level {1}", index, levelConfig.GetDisplayName());
			UpdateLevelProgression();
			if (debug)
			{
				GetAndClearNewlyVisibleLevels();
				GetAndClearNewlyUnlockedLevels();
				GetAndClearNewlyPlayableLevels();
			}
			_hasUnsavedChangesHighImportance = true;
			OnStarAwarded.InvokeSafe(index, levelConfig, debug);
		}

		public void AwardSilver(int amount)
		{
			if (amount != 0)
			{
				_totalSilver += amount;
				_totalSilverCumulative += amount;
				_hasUnsavedChangesMediumImportance = true;
				OnSilverAwarded.InvokeSafe(amount);
			}
		}

		public bool CanAffordSilver(ISilverUnlockable unlockable)
		{
			return _totalSilver >= unlockable.SilverCost();
		}

		public bool HasUnlocked(ISilverUnlockable unlockable)
		{
			bool flag = _silverUnlockables.Contains(unlockable.SilverUnlockToken);
			if (!flag && SandboxSaveManager.CurrentSettings != null)
			{
				flag = SandboxSaveManager.CurrentSettings.ShouldUnlockableItemBeUnlockedForCheckType(unlockable.GetSandboxCheckType());
			}
			return flag;
		}

		public bool IsBlacklisted(IRoomItemDefinition roomItem)
		{
			LevelItemList levelItemBlacklist = _currentLevel.Config.GetLevelItemBlacklist();
			if (levelItemBlacklist != null && levelItemBlacklist.ContainsRoomItem(roomItem))
			{
				return true;
			}
			return false;
		}

		public bool IsWhitelisted(IRoomItemDefinition roomItem)
		{
			if (!roomItem.MustBeWhiteListed)
			{
				return true;
			}
			LevelItemList levelItemWhitelist = _currentLevel.Config.GetLevelItemWhitelist();
			if (levelItemWhitelist != null && levelItemWhitelist.ContainsRoomItem(roomItem))
			{
				return true;
			}
			return false;
		}

		public void UnlockItem(ISilverUnlockable silverUnlockable, bool spendSilver, bool showMessage)
		{
			if (_silverUnlockables.Contains(silverUnlockable.SilverUnlockToken))
			{
				return;
			}
			if (!spendSilver)
			{
				_silverUnlockables.Add(silverUnlockable.SilverUnlockToken);
				UpdateLevelProgression();
				OnItemUnlocked.InvokeSafe(silverUnlockable);
				_hasUnsavedChangesMediumImportance = true;
				if (showMessage && _currentLevel != null)
				{
					_currentLevel.Advisor.ShowUnlockedMessage(silverUnlockable);
				}
			}
			else if (CanAffordSilver(silverUnlockable))
			{
				int num = silverUnlockable.SilverCost();
				_silverUnlockables.Add(silverUnlockable.SilverUnlockToken);
				_totalSilver -= num;
				UpdateLevelProgression();
				OnItemUnlocked.InvokeSafe(silverUnlockable);
				_hasUnsavedChangesMediumImportance = true;
				if (showMessage && _currentLevel != null)
				{
					_currentLevel.Advisor.ShowUnlockedMessage(silverUnlockable);
				}
				AudioManager.Instance.Play("KudoshPurchase");
			}
			else
			{
				Logging.Warning(LogChannels.Metagame, "Can't afford silver item {0}", silverUnlockable);
			}
		}

		public bool HasUnlockedRoomOfType(RoomDefinition.Type roomType)
		{
			SharedInstance<RoomDefinition>[] rooms = RoomDatabase.Instance.Rooms;
			for (int i = 0; i < rooms.Length; i++)
			{
				RoomDefinition instance = rooms[i].Instance;
				if (instance._type == roomType && HasUnlocked(instance))
				{
					return true;
				}
			}
			return false;
		}

		private void OnLevelLoaded(Level level, bool loadedFromSave)
		{
			_newlyVisibleLevels.Clear();
			_newlyPlayableLevels.Clear();
			_newlyUnlockedLevels.Clear();
			_levelsNotPlayed.Remove(level.Config);
		}

		private void OnEndOfMonthStatsCompiled(LevelStatsDatabase.MonthStats monthStats)
		{
			if (!_hospitalRecordsByLevelID.ContainsKey(_currentLevel.Config.UniqueId))
			{
				_hospitalRecordsByLevelID.Add(_currentLevel.Config.UniqueId, new MetagameHospitalRecord());
			}
			_hospitalRecordsByLevelID[_currentLevel.Config.UniqueId].SetHospitalValue(monthStats.HospitalValue);
			_hospitalRecordsByLevelID[_currentLevel.Config.UniqueId].SetHospitalDate(_currentLevel.TimelineManager.Day, _currentLevel.TimelineManager.Month, _currentLevel.TimelineManager.Year);
		}

		private void OnPrestigeChanged(PrestigeTracker prestigeTracker)
		{
			if (!_hospitalRecordsByLevelID.ContainsKey(_currentLevel.Config.UniqueId))
			{
				_hospitalRecordsByLevelID.Add(_currentLevel.Config.UniqueId, new MetagameHospitalRecord());
			}
			_hospitalRecordsByLevelID[_currentLevel.Config.UniqueId].SetPrestigeLevel(prestigeTracker.Level);
		}

		private void OnReputationChanged(float reputation)
		{
			if (!_hospitalRecordsByLevelID.ContainsKey(_currentLevel.Config.UniqueId))
			{
				_hospitalRecordsByLevelID.Add(_currentLevel.Config.UniqueId, new MetagameHospitalRecord());
			}
			_hospitalRecordsByLevelID[_currentLevel.Config.UniqueId].SetReputation(reputation);
		}

		public void OnResearchProjectComplete(ResearchProject researchProject)
		{
			_completedResearchProjects.AddUnique(researchProject.Definition);
			_hasUnsavedChangesMediumImportance = true;
		}

		public bool HasCompletedResearchProject(ResearchProjectDefinition researchProject)
		{
			return _completedResearchProjects.Contains(researchProject);
		}

		private void OnBalanceUpdated(int balance)
		{
			if (!_hospitalRecordsByLevelID.ContainsKey(_currentLevel.Config.UniqueId))
			{
				_hospitalRecordsByLevelID.Add(_currentLevel.Config.UniqueId, new MetagameHospitalRecord());
			}
			_hospitalRecordsByLevelID[_currentLevel.Config.UniqueId].SetBalance(balance);
		}

		private void UpdateLevelProgression()
		{
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				if (levelConfigByID != null && !levelConfigByID.IsDebugLevel)
				{
					if (!item.Value.IsVisible() && levelConfigByID.IsVisible(this))
					{
						MakeHospitalVisible(levelConfigByID);
					}
					if (levelConfigByID.IsPlayable(this))
					{
						MakeHospitalUnlocked(levelConfigByID);
						MakeHospitalPlayable(levelConfigByID);
					}
				}
			}
		}

		public void MakeHospitalVisible(LevelConfig level)
		{
			if (_hospitalRecordsByLevelID.TryGetValue(level.UniqueId, out var value) && !value.IsVisible())
			{
				value.SetVisible();
				_newlyVisibleLevels.Add(level);
				_hasUnsavedChangesHighImportance = true;
				OnHospitalUnlocked.InvokeSafe(level);
			}
		}

		private void MakeHospitalUnlocked(LevelConfig level)
		{
			if (_hospitalRecordsByLevelID.TryGetValue(level.UniqueId, out var value) && !value.IsUnlocked())
			{
				value.SetUnlocked();
				_newlyUnlockedLevels.Add(level);
				_levelsNotPlayed.AddUnique(level);
				_hasUnsavedChangesHighImportance = true;
				OnHospitalUnlocked.InvokeSafe(level);
			}
		}

		public void MakeHospitalPlayable(LevelConfig level)
		{
			if (_hospitalRecordsByLevelID.TryGetValue(level.UniqueId, out var value))
			{
				MakeHospitalVisible(level);
				if (!value.IsPlayable())
				{
					value.SetPlayable();
					value.SetHospitalValue(level.GetFinanceManagerConfig().GetInitialBalance());
					value.SetHospitalDate(0, 0, 0);
					_newlyPlayableLevels.Add(level);
					_levelsNotPlayed.AddUnique(level);
					_hasUnsavedChangesHighImportance = true;
					OnHospitalBecamePlayable.InvokeSafe(level);
				}
			}
		}

		public bool HasSeenUnlockCutscene(LevelConfig config)
		{
			return _hasSeenUnlockCutscene.Contains(config);
		}

		public void SeenCutscene(LevelConfig config)
		{
			if (!_hasSeenUnlockCutscene.Contains(config))
			{
				_hasSeenUnlockCutscene.Add(config);
				_hasUnsavedChangesLowImportance = true;
			}
		}

		public List<LevelConfig> GetAndClearNewlyUnlockedLevels()
		{
			List<LevelConfig> result = new List<LevelConfig>(_newlyUnlockedLevels);
			_newlyUnlockedLevels.Clear();
			return result;
		}

		public List<LevelConfig> GetAndClearNewlyVisibleLevels()
		{
			List<LevelConfig> result = new List<LevelConfig>(_newlyVisibleLevels);
			_newlyVisibleLevels.Clear();
			return result;
		}

		public List<LevelConfig> GetAndClearNewlyPlayableLevels()
		{
			List<LevelConfig> result = new List<LevelConfig>(_newlyPlayableLevels);
			_newlyPlayableLevels.Clear();
			return result;
		}

		public void SetHUDSavedState(string key, bool value)
		{
			_hudSavedState.Set(key, value);
			_hasUnsavedChangesLowImportance = true;
		}

		public void GetHUDSavedState(string key, out bool value)
		{
			_hudSavedState.Get<bool>(key, out value);
		}

		public void UnlockResearchProject(ResearchProjectDefinition definition)
		{
			if (!_availableResearchProjects.ContainsKey(definition))
			{
				_availableResearchProjects.Add(definition, 0f);
				_hasUnsavedChangesLowImportance = true;
			}
		}

		public bool IsResearchProjectUnlocked(ResearchProjectDefinition definition)
		{
			return _availableResearchProjects.ContainsKey(definition);
		}

		public void UpdateResearchProjectPoints(ResearchProjectDefinition definition, float points)
		{
			if (!_availableResearchProjects.ContainsKey(definition))
			{
				_availableResearchProjects.Add(definition, 0f);
			}
			if (definition.Repeatable && points >= definition.ResearchPoints)
			{
				points = 0f;
			}
			_availableResearchProjects[definition] = points;
		}

		public float GetResearchProjectPoints(ResearchProjectDefinition definition)
		{
			if (_availableResearchProjects.ContainsKey(definition))
			{
				return _availableResearchProjects[definition];
			}
			return 0f;
		}

		public void ClearUnsavedChangesFlags()
		{
			_hasUnsavedChangesHighImportance = false;
			_hasUnsavedChangesMediumImportance = false;
			_hasUnsavedChangesLowImportance = false;
		}

		public void RemoveExcludedResearchProjects()
		{
			ResearchProjectDefinition[] array = _availableResearchProjects.Keys.ToArray();
			foreach (ResearchProjectDefinition researchProjectDefinition in array)
			{
				if (researchProjectDefinition.IsExcluded(_currentLevel))
				{
					_availableResearchProjects.Remove(researchProjectDefinition);
				}
			}
		}

		public bool IsSandboxUnlocked()
		{
			if (_config.SandboxUnlockLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.SandboxUnlockLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsCollaborativePortfolioUnlocked()
		{
			if (_config.CollaborativePortfolioLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.CollaborativePortfolioLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsBigfootDLCCompleted()
		{
			if (_config.BigfootDLCCompleteLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.BigfootDLCCompleteLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsJungleDLCCompleted()
		{
			if (_config.JungleDLCCompleteLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.JungleDLCCompleteLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsCloseEncountersDLCCompleted()
		{
			if (_config.CloseEncountersDLCLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.CloseEncountersDLCLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsOffTheGridDLCCompleted()
		{
			if (_config.OffTheGridDLCLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.OffTheGridDLCLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsCultureShockDLCCompleted()
		{
			if (_config.CultureShockDLCLevelConfig == null || _config.CultureShockDLCLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.CultureShockDLCLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsTimeTravelDLCCompleted()
		{
			if (_config.TimeTravelDLCLevelConfig == null || _config.TimeTravelDLCLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.TimeTravelDLCLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsSpeedyRecoveryDLCCompleted()
		{
			if (_config.SpeedyRecoveryDLCLevelConfig == null || _config.SpeedyRecoveryDLCLevelConfig.Instance == null)
			{
				return false;
			}
			_hospitalRecordsByLevelID.TryGetValue(_config.SpeedyRecoveryDLCLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public bool IsRemixRegion1Unlocked()
		{
			_hospitalRecordsByLevelID.TryGetValue(_config.Region1FinalLevelConfig.Instance.UniqueId, out var value);
			return value?.HasStarPreviouslyBeenAwarded(0) ?? false;
		}

		public void TriggerUnlockMeTag(string tag)
		{
			_unlockMeTagList.Add(tag);
		}

		public bool IsUnlockMeTagTriggered(string tag)
		{
			if (tag.IsNullOrEmpty())
			{
				return false;
			}
			return _unlockMeTagList.Contains(tag);
		}

		public bool IsCollaborativeResearchProjectCompleted(CollaborativeProjectDefinition projectDefinition)
		{
			return CollaborativePortfolio.IsResearchProjectTypeCompleted(projectDefinition);
		}

		public bool IsSuperBugVictoryAchieved(SuperBugRequirement requirement)
		{
			return CollaborativePortfolio.IsSuperBugVictoryAchieved(requirement);
		}

		private void RegisterDebugCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("ResetMetagame", "Resets the metagame values", "ResetMetagame", DebugResetMetagame);
			ConsoleCommandsDatabase.RegisterCommand("AwardStar", "Awards star to current level", "AwardStar [Star1|Star2|Star3]", DebugAwardStar);
			ConsoleCommandsDatabase.RegisterSimpleCommand("AwardStarInAllLevels", "Awards 1 star on all levels", DebugAwardStarInAllLevels);
			ConsoleCommandsDatabase.RegisterSimpleCommand("AwardAllStarsInAllLevels", "Awards 3 stars on all levels", DebugAwardAllStarsInAllLevels);
			ConsoleCommandsDatabase.RegisterCommand("AwardSilver", "Awards silver to the player", "AwardSilver", DebugAwardSilver);
			ConsoleCommandsDatabase.RegisterCommand("UnlockEverything", "Unlocks everyting in the game i.e. levels, rooms, items", "UnlockEverything", DebugUnlockEverything);
			ConsoleCommandsDatabase.RegisterCommand("UnlockLevel", "Unlocks one specific level", "UnlockLevel [level unique id]", DebugUnlockLevel);
			ConsoleCommandsDatabase.RegisterCommand("UnlockAllLevels", "Unlocks all levels in the game", "UnlockAllLevels", DebugUnlockAllLevels);
			ConsoleCommandsDatabase.RegisterCommand("LockAllSilverItems", "Locks all silver items in the game", "LockAllSilverItems", DebugLockAllSilverItems);
			ConsoleCommandsDatabase.RegisterCommand("UnlockAllSilverItems", "Unlocks all silver items in the game", "UnlockAllSilverItems", DebugUnlockAllSilverItems);
			ConsoleCommandsDatabase.RegisterCommand("LogFoundationValue", "Prints information about the foundation value", "LogFoundationValue", Debug_LogFoundationValue);
			ConsoleCommandsDatabase.RegisterCommand("ToggleAddWallBackFace", "Toggles adding a wall back face programmatically", "ToggleAddWallBackFace", Debug_ToggleAddWallBackFace);
			ConsoleCommandsDatabase.RegisterCommand("ToggleUseDefaultWallPrefabs", "Toggles using default wall prefabs for performance testing", "ToggleUseDefaultWallPrefabs", Debug_UseDefaultWallPrefabs);
			ConsoleCommandsDatabase.RegisterCommand("ToggleCursor", "Toggles cursor mode", "Toggle Cursor to be visible/invisible", Debug_ToggleCursor);
		}

		private void UnregisterDebugCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ResetMetagame");
			ConsoleCommandsDatabase.UnRegisterCommand("AwardStar");
			ConsoleCommandsDatabase.UnRegisterCommand("AwardSilver");
			ConsoleCommandsDatabase.UnRegisterCommand("UnlockAllLevels");
			ConsoleCommandsDatabase.UnRegisterCommand("UnlockAllSilverItems");
			ConsoleCommandsDatabase.UnRegisterCommand("LogFoundationValue");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleAddWallBackFace");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleUseDefaultWallPrefabs");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleCursor");
		}

		private ConsoleCommandResult DebugResetMetagame(string[] args)
		{
			Reset();
			return ConsoleCommandResult.Succeeded();
		}

		public void Reset()
		{
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				item.Value.Reset();
			}
			_playthroughID = RandomUtils.GlobalRandomInstance.Next();
			_totalSilver = 0;
			_silverUnlockables.Clear();
			UpdateLevelProgression();
			GetAndClearNewlyVisibleLevels();
			GetAndClearNewlyUnlockedLevels();
		}

		private ConsoleCommandResult DebugAwardStar(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int index)
			{
				AwardStar((MetagameHospitalRecord.StarIndex)index, _currentLevel.Config, debug: true);
			}, args);
		}

		private void DebugAwardStarInAllLevels()
		{
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				AwardStar(MetagameHospitalRecord.StarIndex.Star1, levelConfigByID, debug: true);
			}
		}

		private void DebugAwardAllStarsInAllLevels()
		{
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				AwardStar(MetagameHospitalRecord.StarIndex.Star1, levelConfigByID, debug: true);
				AwardStar(MetagameHospitalRecord.StarIndex.Star2, levelConfigByID, debug: true);
				AwardStar(MetagameHospitalRecord.StarIndex.Star3, levelConfigByID, debug: true);
				AwardRemixBadge(levelConfigByID, debug: true);
			}
		}

		private ConsoleCommandResult DebugAwardSilver(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(AwardSilver, args);
		}

		private ConsoleCommandResult DebugUnlockEverything(string[] args)
		{
			DebugUnlockAllLevels(args);
			DebugUnlockAllSilverItems(args);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugUnlockLevel(string[] args)
		{
			string text = args[0];
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				if (item.Key == text)
				{
					LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
					MakeHospitalVisible(levelConfigByID);
					MakeHospitalUnlocked(levelConfigByID);
					MakeHospitalPlayable(levelConfigByID);
					SeenCutscene(levelConfigByID);
					return ConsoleCommandResult.Succeeded();
				}
			}
			return ConsoleCommandResult.Failed("Couldn't find level with ID " + text);
		}

		private ConsoleCommandResult DebugUnlockAllLevels(string[] args)
		{
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				MakeHospitalVisible(levelConfigByID);
				MakeHospitalUnlocked(levelConfigByID);
				MakeHospitalPlayable(levelConfigByID);
				SeenCutscene(levelConfigByID);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLockAllSilverItems(string[] args)
		{
			_silverUnlockables.Clear();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugUnlockAllSilverItems(string[] args)
		{
			int num = 0;
			SharedInstance<RoomDefinition>[] rooms = RoomDatabase.Instance.Rooms;
			foreach (SharedInstance<RoomDefinition> sharedInstance in rooms)
			{
				num += sharedInstance.Instance.SilverCost();
			}
			SharedInstance<RoomItemDefinition>[] roomItems = RoomItemDatabase.Instance.RoomItems;
			for (int i = 0; i < roomItems.Length; i++)
			{
				RoomItemDefinition instance = roomItems[i].Instance;
				num += instance.SilverCost();
				if (instance.Upgrades != null)
				{
					SharedInstance<RoomItemUpgradeDefinition>[] upgrades = instance.Upgrades;
					foreach (SharedInstance<RoomItemUpgradeDefinition> sharedInstance2 in upgrades)
					{
						num += sharedInstance2.Instance.SilverCost();
					}
				}
			}
			AwardSilver(num);
			rooms = RoomDatabase.Instance.Rooms;
			foreach (SharedInstance<RoomDefinition> sharedInstance3 in rooms)
			{
				UnlockItem(sharedInstance3.Instance, spendSilver: false, showMessage: false);
			}
			roomItems = RoomItemDatabase.Instance.RoomItems;
			for (int i = 0; i < roomItems.Length; i++)
			{
				RoomItemDefinition instance2 = roomItems[i].Instance;
				UnlockItem(instance2, spendSilver: false, showMessage: false);
				if (instance2.Upgrades != null)
				{
					SharedInstance<RoomItemUpgradeDefinition>[] upgrades = instance2.Upgrades;
					foreach (SharedInstance<RoomItemUpgradeDefinition> sharedInstance4 in upgrades)
					{
						UnlockItem(sharedInstance4.Instance, spendSilver: false, showMessage: false);
					}
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_LogFoundationValue(string[] args)
		{
			int num = TotalFoundationValue();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Foundation Value = {0}", StringUtils.FormatCurrency(num)).AppendLine();
			foreach (KeyValuePair<string, MetagameHospitalRecord> item in _hospitalRecordsByLevelID)
			{
				LevelConfig levelConfigByID = _config._levelList.Instance.GetLevelConfigByID(item.Key);
				if (levelConfigByID != null && !levelConfigByID.IsDebugLevel)
				{
					MetagameHospitalRecord value = item.Value;
					if (value.GetRecordData() != null)
					{
						num += value.GetHospitalValue();
						stringBuilder.AppendFormat("+ Hospital {0} - {1}", levelConfigByID.GetDisplayName(), StringUtils.FormatCurrency(value.GetHospitalValue())).AppendLine();
					}
				}
			}
			return ConsoleCommandResult.Succeeded(stringBuilder.ToString());
		}

		private ConsoleCommandResult Debug_ToggleAddWallBackFace(string[] args)
		{
			RoomFloorPlanVisual.ShouldAddBackFaceProgrammatically = !RoomFloorPlanVisual.ShouldAddBackFaceProgrammatically;
			return ConsoleCommandResult.Succeeded(string.Format("ShouldAddBackFaceProgrammatically = {0}", RoomFloorPlanVisual.ShouldAddBackFaceProgrammatically ? "TRUE" : "FALSE"));
		}

		private ConsoleCommandResult Debug_UseDefaultWallPrefabs(string[] args)
		{
			RoomWallDefinition.UseDefaultWallPrefabs = !RoomWallDefinition.UseDefaultWallPrefabs;
			return ConsoleCommandResult.Succeeded(string.Format("UseDefaultWallPrefabs = {0}", RoomWallDefinition.UseDefaultWallPrefabs ? "TRUE" : "FALSE"));
		}

		private ConsoleCommandResult Debug_ToggleCursor(string[] args)
		{
			CursorManager.HideCursorOverride = !CursorManager.HideCursorOverride;
			return ConsoleCommandResult.Succeeded($"Cursor mode = {CursorManager.HideCursorOverride}");
		}
	}
}
