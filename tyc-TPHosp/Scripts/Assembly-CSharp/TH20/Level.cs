#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using FullInspector.Generated.SharedInstance;
using FullInspector.Internal;
using FullSerializerSave;
using JetBrains.Annotations;
using SharpConfig;
using TH20.Analytics;
using UnityConsole;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	public class Level : MustCallDestroy
	{
		[Serializable]
		private class RoomItemLayout
		{
			public int ID;

			public string ContentID;

			public Vector3 LocalPosition;

			public float Rotation;
		}

		[Serializable]
		private class RoomLayout
		{
			public bool IsHospital;

			public bool PlotBought;

			public int HospitalPlot;

			public string DefinitionName;

			public int DefinitionID;

			public GridCoord Anchor;

			public bool[,] Tiles;

			public List<RoomItemLayout> Items = new List<RoomItemLayout>();
		}

		private readonly LevelConfig _config;

		[DontSave]
		private App _app;

		[DontSave]
		private InputManager _inputManager;

		[DontSave]
		private LevelCommonScript _levelCommonScript;

		[DontSave]
		private LocalPreferences _localPreferences;

		[DontSave]
		private Preferences _userPreferences;

		private readonly GameTime _gameTime;

		[DontSave]
		private LevelCameraManager _levelCameraManager;

		private readonly TopDownCameraLogic _topDownCameraLogic;

		private readonly RandomLookAtCameraPOI _randomlyLookAtCameraPOI;

		private readonly Entity _randomlyLookAtCameraPOIEntity;

		private readonly BuildingLogic _buildingLogic;

		private readonly SFXManager _sfxManager;

		[DontSave]
		private AudioListenerManager _audioListenerManager;

		[DontSave]
		private HospitalAudioMixerManager _hospitalAudioMixerManager;

		[DontSave]
		private HospitalAudioAmbienceManager _audioAmbienceManager;

		[DontSave]
		private CursorManager _cursorManager;

		private readonly CharacterManager _characterManager;

		[DontSave]
		private StaffRecordManager _staffRecordManager;

		private readonly HospitalAwardsManager _hospitalAwardsManager;

		private readonly YearlyTargetsManager _yearlyTargetsManager;

		[DontSave]
		private LevelHUD _hud;

		[DontSave]
		private HospitalHUDManager _hospitalHUDManager;

		[DontSave]
		private InWorldMessages _inWorldMessages;

		[DontSave]
		private string _organisationName;

		private readonly HUDSavedState _hudSavedState;

		private readonly WorldState _worldState;

		private readonly StaffWorkScheduler _staffWorkScheduler;

		private readonly FinanceManager _financeManager;

		private readonly TimelineManager _timelineManager;

		private readonly LoanManager _loanManager;

		private readonly MarketingManager _marketingManager;

		private readonly HospitalEventLog _hospitalEventLog;

		private readonly HospitalFailState _hospitalFailState;

		private HospitalPolicy _hospitalPolicy;

		[DontSave]
		private Radio _radio;

		private readonly TannoyManager _tannoyManager;

		private readonly AttributesManager _attributesManager;

		private readonly LevelScriptManager _levelScriptManager;

		[UsedImplicitly]
		private readonly Notifications _notifications;

		private readonly VisualManager _visualManager;

		[DontSave]
		private DataViewManager _dataViewManager;

		[DontSave]
		private StatusIconManager _statusIconManager;

		private readonly JobApplicantManager _jobApplicantManager;

		private readonly ResearchManager _researchManager;

		private readonly ChallengeManager _challengeManager;

		private readonly Advisor _advisor;

		private readonly CharacterLookAtManager _characterLookAtManager;

		private readonly CharacterTraitsManager _characterTraitsManager;

		private readonly EntityManager _entityManager;

		private readonly WorkLifeBalanceManager _workLifeBalanceManager;

		private readonly TimerManager _timerManager;

		private readonly ToughLuckBalancer _toughLuckBalancer;

		private readonly GuestTrainers _guestTrainers;

		[DontSave]
		private TutorialManager _tutorialManager;

		private readonly MonoBeastManager _monoBeastManager;

		private readonly ReceptionManager _receptionManager;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		private readonly ObjectiveEvents _objectiveEvents;

		private readonly HospitalEvents _hospitalEvents;

		private readonly CameraEvents _cameraEvents;

		private readonly HospitalEditEvents _hospitalEditEvents;

		private readonly ChallengeEvents _challengeEvents;

		private readonly HUDEvents _hudEvents;

		[DontSave]
		private byte[] _thumbnailPNG;

		private readonly LevelStatsDatabase _levelStatsDatabase;

		private readonly LevelAnalyticsManager _levelAnalyticsManager;

		private readonly ReputationTracker _reputationTracker;

		private readonly PrestigeTracker _prestigeTracker;

		private readonly GameplayStatsTracker _gameplayStatsTracker;

		[DontSave]
		private LevelDataManager m_levelDataManager;

		[DontSave]
		private Metagame _metagame;

		[DontSave]
		private MetagameMap _metagameMap;

		[DontSave]
		private DateTime _realWorldInitTime;

		[DontSave]
		private LevelStatsCapture _levelStatsCapture;

		[DontSave]
		private bool _shouldAutoSaveThisFrame;

		[DontSave]
		private bool _awardCeremonyInProgress;

		[DontSave]
		private List<AudioEmitter> _notificationAudioExclusiveModeEmitters;

		[DontSave]
		private BehaviourTreePool _behaviourTreePool;

		[DontSave]
		private QueuePathManager _queuePathManager;

		private ItemSpawnLimits _itemSpawnLimits;

		private UGCDefinitionsFixUp _ugcDefinitionsFixUp;

		private RoomCustomisations _roomCustomisations;

		private List<FloorVisualOverrideDefinitionUGC> _floorVisualOverrideDefinitionUGCs;

		private List<WallVisualOverrideDefinitionUGC> _wallVisualOverrideDefinitionUGCs;

		[DontSave]
		public Action PostConstruct;

		[DontSave]
		private ICursorSelectable _cursorSelectable;

		[DontSave]
		private Character _cursorCharacter;

		[DontSave]
		private RoomItem _cursorRoomItem;

		private const int VersionLatest = 5;

		public DateTime RealWorldInitTime => _realWorldInitTime;

		public List<FloorVisualOverrideDefinitionUGC> FloorVisualOverrideDefinitionUGCs => _floorVisualOverrideDefinitionUGCs;

		public List<WallVisualOverrideDefinitionUGC> WallVisualOverrideDefinitionUGCs => _wallVisualOverrideDefinitionUGCs;

		public double[] TimeScaleDurations => _gameTime.TimeScaleDurations;

		public string UniqueID => _config.UniqueId;

		public HighlightManager HighlightManager => _metagame.HighlightManager;

		public string OrganisationName
		{
			get
			{
				return _organisationName;
			}
			set
			{
				_organisationName = value;
			}
		}

		public FinanceManager FinanceManager => _financeManager;

		public ReputationTracker ReputationTracker => _reputationTracker;

		public PrestigeTracker PrestigeTracker => _prestigeTracker;

		public CharacterManager CharacterManager => _characterManager;

		public GameplayStatsTracker GameplayStatsTracker => _gameplayStatsTracker;

		public TopDownCameraLogic CameraLogic => _topDownCameraLogic;

		public InWorldMessages InWorldMessages => _inWorldMessages;

		public HUD HUD => _hud;

		public HospitalHUDManager HospitalHUDManager => _hospitalHUDManager;

		public InputManager InputManager => _inputManager;

		public WorldState WorldState => _worldState;

		public LevelConfig Config => _config;

		public Metagame Metagame => _metagame;

		public MetagameMap MetagameMap => _metagameMap;

		public StaffWorkScheduler StaffWorkScheduler => _staffWorkScheduler;

		public StaffRecordManager StaffRecordManager => _staffRecordManager;

		public HospitalAwardsManager HospitalAwardsManager => _hospitalAwardsManager;

		public YearlyTargetsManager YearlyTargetsManager => _yearlyTargetsManager;

		public JobApplicantManager JobApplicantManager => _jobApplicantManager;

		public ResearchManager ResearchManager => _researchManager;

		public Radio Radio => _radio;

		public TannoyManager TannoyManager => _tannoyManager;

		public LevelScriptManager LevelScriptManager => _levelScriptManager;

		public LevelAnalyticsManager LevelAnalyticsManager => _levelAnalyticsManager;

		public DataViewManager DataViewManager => _dataViewManager;

		public VisualManager VisualManager => _visualManager;

		public CursorManager CursorManager => _cursorManager;

		public ChallengeManager ChallengeManager => _challengeManager;

		public ChallengeEvents ChallengeEvents => _challengeEvents;

		public Advisor Advisor => _advisor;

		public BuildingLogic BuildingLogic => _buildingLogic;

		public GameTime GameTime => _gameTime;

		public CharacterLookAtManager CharacterLookAtManager => _characterLookAtManager;

		public LevelStatsDatabase LevelStatsDatabase => _levelStatsDatabase;

		public LevelDataManager LevelDataManager => m_levelDataManager;

		public LoanManager LoanManager => _loanManager;

		public TimelineManager TimelineManager => _timelineManager;

		public LocalPreferences LocalPreferences => _localPreferences;

		public Preferences UserPreferences => _userPreferences;

		public MarketingManager MarketingManager => _marketingManager;

		public EntityManager EntityManager => _entityManager;

		public CharacterEvents CharacterEvents => _characterEvents;

		public BuildEvents BuildEvents => _buildEvents;

		public ObjectiveEvents ObjectiveEvents => _objectiveEvents;

		public HospitalEvents HospitalEvents => _hospitalEvents;

		public HUDEvents HUDEvents => _hudEvents;

		public CameraEvents CameraEvents => _cameraEvents;

		public HospitalEditEvents HospitalEditEvents => _hospitalEditEvents;

		public Notifications Notifications => _notifications;

		public AttributesManager AttributesManager => _attributesManager;

		public WorkLifeBalanceManager WorkLifeBalanceManager => _workLifeBalanceManager;

		public TimerManager TimerManager => _timerManager;

		public ToughLuckBalancer ToughLuckBalancer => _toughLuckBalancer;

		public byte[] ThumbnailPNG => _thumbnailPNG;

		public GuestTrainers GuestTrainers => _guestTrainers;

		public TutorialManager TutorialManager => _tutorialManager;

		public HospitalAudioMixerManager HospitalAudioMixerManager => _hospitalAudioMixerManager;

		public CharacterTraitsManager CharacterTraitsManager => _characterTraitsManager;

		public App App => _app;

		public HospitalEventLog HospitalEventLog => _hospitalEventLog;

		public MonoBeastManager MonoBeastManager => _monoBeastManager;

		public ReceptionManager ReceptionManager => _receptionManager;

		public HUDSavedState HUDSavedState => _hudSavedState;

		public StatusIconManager StatusIconManager => _statusIconManager;

		public HospitalFailState HospitalFailState => _hospitalFailState;

		public bool AwardCeremonyInProgress
		{
			get
			{
				return _awardCeremonyInProgress;
			}
			set
			{
				_awardCeremonyInProgress = value;
			}
		}

		public bool NotificationAudioExclusiveMode => _notificationAudioExclusiveModeEmitters.Count > 0;

		public CharacterNameGenerator CharacterNameGenerator => _config.GetCharacterNameGenerator();

		public ItemSpawnLimits ItemSpawnLimits => _itemSpawnLimits;

		public BehaviourTreePool BehaviourTreePool => _behaviourTreePool;

		public QueuePathManager QueuePathManager => _queuePathManager;

		public HospitalPolicy HospitalPolicy => _hospitalPolicy;

		public UGCDefinitionsFixUp UGCDefinitionsFixUp => _ugcDefinitionsFixUp;

		public RoomCustomisations RoomCustomisations => _roomCustomisations;

		public void AddNotificationAudioExclusiveModeEmitter(AudioEmitter audioEmitter)
		{
			if (audioEmitter != null)
			{
				_notificationAudioExclusiveModeEmitters.AddUnique(audioEmitter);
			}
		}

		public Level(App app, InputManager inputManager, LevelCommonScript levelCommonScript, Metagame metagame, MetagameMap metagameMap, LevelConfig config, Preferences userPreferences, LocalPreferences localPreferences, AnalyticsManager analyticsManager)
		{
			_config = config;
			_app = app;
			_inputManager = inputManager;
			_levelCommonScript = levelCommonScript;
			_metagame = metagame;
			_metagameMap = metagameMap;
			_userPreferences = userPreferences;
			_localPreferences = localPreferences;
			_ugcDefinitionsFixUp = new UGCDefinitionsFixUp();
			_entityManager = new EntityManager();
			_wallVisualOverrideDefinitionUGCs = new List<WallVisualOverrideDefinitionUGC>();
			_floorVisualOverrideDefinitionUGCs = new List<FloorVisualOverrideDefinitionUGC>();
			_characterEvents = new CharacterEvents();
			_buildEvents = new BuildEvents();
			_objectiveEvents = new ObjectiveEvents();
			_hospitalEvents = new HospitalEvents();
			_cameraEvents = new CameraEvents();
			_hospitalEditEvents = new HospitalEditEvents();
			_challengeEvents = new ChallengeEvents();
			_hudEvents = new HUDEvents();
			_behaviourTreePool = new BehaviourTreePool();
			_queuePathManager = new QueuePathManager();
			_timelineManager = new TimelineManager();
			_timerManager = new TimerManager();
			_levelCameraManager = new LevelCameraManager();
			_prestigeTracker = new PrestigeTracker(_config.GetPrestigeConfig(), this, _buildEvents, _characterEvents);
			_audioListenerManager = new AudioListenerManager(_metagameMap, this, _levelCameraManager, _config.GetAudioListenerManagerConfig());
			_hospitalAudioMixerManager = new HospitalAudioMixerManager(this, _levelCameraManager, _localPreferences, _config.GetHospitalAudioMixerManagerConfig());
			_roomCustomisations = new RoomCustomisations();
			_hudSavedState = new HUDSavedState();
			_hud = new LevelHUD(_levelCommonScript.MenusTransform, _levelCommonScript.InWorldTransform, _config.GetHUDConfig(), _inputManager, this);
			ArrivalTimePortalComponent.Reset();
			_reputationTracker = new ReputationTracker(_config.GetReputationTrackerConfig(), this);
			_researchManager = new ResearchManager(GetResearchManagerConfig(), this, _buildEvents, _characterEvents);
			_gameTime = new GameTime(_config.GetGameTimeConfig(), this);
			_cursorManager = new CursorManager(_config.GetCursorManagerConfig(), _inputManager);
			_visualManager = new VisualManager(_config.GetVisualManagerConfig(), _buildEvents, this);
			_worldState = new WorldState(_config.GetWorldStateConfig(), this, metagame, _visualManager, _config.GetDataViewManagerConfig().ValueMaterial, _config.GetBuildingLogicConfig().RoomItemEditConfig);
			_dataViewManager = new DataViewManager(_config.GetDataViewManagerConfig(), this, _worldState, _visualManager);
			_buildingLogic = new BuildingLogic(_config.GetBuildingLogicConfig(), this, _worldState, _visualManager, _dataViewManager, _buildEvents);
			_characterManager = new CharacterManager(_config.GetCharacterManagerConfig(), this, _prestigeTracker, _reputationTracker, CharacterNameGenerator, _visualManager);
			_audioAmbienceManager = new HospitalAudioAmbienceManager(_gameTime, _characterManager, _worldState, _metagameMap, _levelCameraManager, _config.GetHospitalAudioAmbienceManagerConfig());
			_characterLookAtManager = new CharacterLookAtManager(_characterManager);
			_hospitalAwardsManager = new HospitalAwardsManager(this, GetHospitalAwardsManagerConfig());
			_workLifeBalanceManager = new WorkLifeBalanceManager(_config.GetWorkLifeBalanceConfig(), this);
			_financeManager = new FinanceManager(GetFinanceManagerConfig(), this);
			_hospitalFailState = new HospitalFailState(this);
			_levelStatsDatabase = new LevelStatsDatabase(this, _timelineManager, _financeManager, _reputationTracker, _prestigeTracker, _researchManager, _characterManager, _characterEvents);
			_yearlyTargetsManager = new YearlyTargetsManager(_config.GetYearlyTargetsManagerConfig(), _levelStatsDatabase, _financeManager, _reputationTracker, _metagame);
			_loanManager = new LoanManager(_config.GetLoanManagerConfig(), this);
			_marketingManager = new MarketingManager(_config.GetMarketingConfig(), this);
			_hospitalEventLog = new HospitalEventLog(_config.GetHospitalEventLogConfig(), this);
			_hospitalPolicy = new HospitalPolicy(_config.GetHospitalPolicyConfig());
			_topDownCameraLogic = new TopDownCameraLogic(_inputManager, _config.GetTopDownCameraLogicConfig(), userPreferences, localPreferences, null, _cameraEvents, this);
			if (_config.GetLevelLightingConfig() != null)
			{
				_topDownCameraLogic.ShadowPlaneHeight = _config.GetLevelLightingConfig().ShadowPlaneHeight;
				_topDownCameraLogic.ShadowPlaneFadeDistance = _config.GetLevelLightingConfig().ShadowPlaneFadeDistance;
				if (_config.GetLevelLightingConfig().TopDownCameraFarClipPlane.UseOverride)
				{
					_topDownCameraLogic.CameraComponent.farClipPlane = _config.GetLevelLightingConfig().TopDownCameraFarClipPlane.Value;
				}
			}
			_topDownCameraLogic.SetLevelBounds(_worldState);
			_levelCameraManager.RegisterCamera(_topDownCameraLogic);
			_randomlyLookAtCameraPOIEntity = new PlainEntity(new EntityDefinition(), this);
			CameraLookAtPOISourceComponent cameraLookAtPOISourceComponent = _randomlyLookAtCameraPOIEntity.AddComponent<CameraLookAtPOISourceComponent>();
			cameraLookAtPOISourceComponent.SetCamera(_topDownCameraLogic);
			_randomlyLookAtCameraPOI = new RandomLookAtCameraPOI(cameraLookAtPOISourceComponent);
			_characterLookAtManager.AddGlobalPOI(_randomlyLookAtCameraPOI);
			_radio = new Radio(this, metagame.MetagameConfig.RadioConfig.Instance);
			_tannoyManager = new TannoyManager(this, _config.GetTannoyManagerConfig());
			_attributesManager = new AttributesManager();
			metagame.SetCurrentLevel(this);
			_metagameMap.InitialiseFromLevel(this, _gameTime, _topDownCameraLogic);
			_inputManager.AddGraphicRayCaster(_levelCommonScript.Raycaster);
			_levelScriptManager = new LevelScriptManager(GetLevelScriptConfig(), this, GetStaffChallengeManagerConfig());
			_notifications = new Notifications(_config.GetNotificationMessagesConfig(), _gameTime, _hud, this, _config.GetDialogueMessageManagerConfig());
			_hospitalHUDManager = new HospitalHUDManager(app, this);
			_inWorldMessages = new InWorldMessages(_hud);
			_statusIconManager = new StatusIconManager(_config.GetStatusIconManagerConfig(), this, _dataViewManager, _buildEvents, _characterEvents);
			_characterTraitsManager = new CharacterTraitsManager(config.GetCharacterTraitsConfig(), this);
			_jobApplicantManager = new JobApplicantManager(GetJobApplicantManagerConfig(), this, _prestigeTracker, _reputationTracker, CharacterNameGenerator, _characterTraitsManager);
			_levelAnalyticsManager = new LevelAnalyticsManager(analyticsManager, this, _timelineManager, _levelStatsDatabase, _financeManager);
			_sfxManager = new SFXManager(this, _config.GetSFXManagerConfig());
			_staffRecordManager = new StaffRecordManager(_characterManager, _timelineManager, _characterEvents, _financeManager, _buildEvents);
			_staffWorkScheduler = new StaffWorkScheduler(_buildEvents, _characterEvents);
			_gameplayStatsTracker = new GameplayStatsTracker(_buildEvents, _characterEvents);
			m_levelDataManager = new LevelDataManager(this);
			_levelStatsCapture = new LevelStatsCapture(_characterManager);
			_challengeManager = new ChallengeManager(this, GetChallengeManagerConfig());
			_advisor = new Advisor(_app, this, GetAdvisorConfig(), _hud);
			_toughLuckBalancer = new ToughLuckBalancer();
			_guestTrainers = new GuestTrainers(IsSandbox() ? _config.GetSandboxGuestTrainersConfig() : _config.GetGuestTrainersConfig(), this);
			_tutorialManager = new TutorialManager(this);
			_monoBeastManager = new MonoBeastManager(_config.GetMonoBeastManagerConfig(), this);
			_receptionManager = new ReceptionManager(this);
			_notificationAudioExclusiveModeEmitters = new List<AudioEmitter>();
			_cursorManager.PushMode(new CursorSelect(_cursorManager, this, _worldState, _buildEvents, _characterManager, _metagame.HighlightManager, _monoBeastManager));
			_radio.Start();
			_realWorldInitTime = DateTime.UtcNow;
			RegisterDebugCommands();
			InitialiseGameEvents();
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			BuildEvents buildEvents = BuildEvents;
			buildEvents.OnCursorHighlight = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorHighlight, new Action<ICursorSelectable>(OnCursorSelection));
			PostConstruct.InvokeSafe();
			PostConstruct = null;
			InitHospitalScenario();
			_itemSpawnLimits = new ItemSpawnLimits(_config.GetItemSpawnLimitsConfig(), this);
			SetCameraFocusToMainEntrance();
			StartCameraFadeIn(2f);
			if (_app.LocalPreferences.Video.Particles == LocalPreferences.VideoPreferences.ParticleQualityMode.Low)
			{
				ParticleQualityController[] array = UnityEngine.Object.FindObjectsOfType<ParticleQualityController>();
				foreach (ParticleQualityController obj in array)
				{
					obj.ParticleSystem.Stop();
					obj.ParticleSystem.Clear();
				}
			}
		}

		private void InitialiseGameEvents()
		{
			_buildEvents.Initialise(this);
			_cameraEvents.Initialise();
			_characterEvents.Initialise(this);
			_hospitalEvents.Initialise();
			_hospitalEditEvents.Initialise(this, _config.GetCursorEditHospitalConfig());
			_objectiveEvents.Initialise();
			_hudEvents.Initialise(isGlobalHUD: false);
		}

		private void RestoreGameEventsFromSave()
		{
			_buildEvents.Initialise(this);
			_cameraEvents.Initialise();
			_characterEvents.RestoreFromSave();
			_hospitalEvents.Initialise();
			_hospitalEditEvents.Initialise(this, _config.GetCursorEditHospitalConfig());
			_objectiveEvents.Initialise();
			_hudEvents.Initialise(isGlobalHUD: false);
			_levelStatsDatabase.RestoreFromSave();
		}

		public void RestoreFromSave(App app, InputManager inputManager, LevelCommonScript levelCommonScript, Metagame metagame, MetagameMap metagameMap, Preferences userPreferences, LocalPreferences localPreferences, AnalyticsManager analyticsManager)
		{
			_app = app;
			_inputManager = inputManager;
			_levelCommonScript = levelCommonScript;
			_metagame = metagame;
			_metagameMap = metagameMap;
			_userPreferences = userPreferences;
			_localPreferences = localPreferences;
			if (_ugcDefinitionsFixUp == null)
			{
				_ugcDefinitionsFixUp = new UGCDefinitionsFixUp();
			}
			else
			{
				_ugcDefinitionsFixUp.RestoreRoomItemsFromSave(_app.UGCRuntimePrefabManager, _app.UGCRoomItemDefinitionDatabase);
				_ugcDefinitionsFixUp.RestoreWallVisualOverrideFromSave(app.UGCWallVisualOverrideDefinitionDatabase);
				_ugcDefinitionsFixUp.RestoreFloorVisualOverrideFromSave(app.UGCFloorVisualOverrideDefinitionDatabase);
			}
			if (_wallVisualOverrideDefinitionUGCs == null)
			{
				_wallVisualOverrideDefinitionUGCs = new List<WallVisualOverrideDefinitionUGC>();
			}
			if (_floorVisualOverrideDefinitionUGCs == null)
			{
				_floorVisualOverrideDefinitionUGCs = new List<FloorVisualOverrideDefinitionUGC>();
			}
			if (_hospitalPolicy == null)
			{
				_hospitalPolicy = new HospitalPolicy(_config.GetHospitalPolicyConfig());
			}
			ArrivalTimePortalComponent.Reset();
			_behaviourTreePool = new BehaviourTreePool();
			_queuePathManager = new QueuePathManager();
			_characterManager.PreRestoreFromSave();
			_entityManager.PreRestoreFromSave();
			_financeManager.RestoreFromSave();
			_hospitalFailState.RestoreFromSave();
			_yearlyTargetsManager.RestoreFromSave(_metagame);
			_loanManager.RestoreFromSave();
			_characterLookAtManager.RestoreFromSave();
			_gameplayStatsTracker.RestoreFromSave();
			_levelCameraManager = new LevelCameraManager();
			_prestigeTracker.RestoreFromSave();
			_audioListenerManager = new AudioListenerManager(_metagameMap, this, _levelCameraManager, _config.GetAudioListenerManagerConfig());
			_hospitalAudioMixerManager = new HospitalAudioMixerManager(this, _levelCameraManager, _localPreferences, _config.GetHospitalAudioMixerManagerConfig());
			_hud = new LevelHUD(_levelCommonScript.MenusTransform, _levelCommonScript.InWorldTransform, _config.GetHUDConfig(), _inputManager, this);
			_gameTime.RestoreFromSave(this);
			_visualManager.RestoreFromSave(_buildEvents, this);
			_cursorManager = new CursorManager(_config.GetCursorManagerConfig(), _inputManager);
			_worldState.RestoreFromSave(_metagame);
			if (_roomCustomisations == null)
			{
				_roomCustomisations = new RoomCustomisations();
			}
			_itemSpawnLimits.RestoreFromSave();
			_levelScriptManager.RestoreFromSave();
			_notifications.RestoreFromSave(_hud, this);
			_dataViewManager = new DataViewManager(_config.GetDataViewManagerConfig(), this, _worldState, _visualManager);
			_characterManager.RestoreFromSave();
			_audioAmbienceManager = new HospitalAudioAmbienceManager(_gameTime, _characterManager, _worldState, _metagameMap, _levelCameraManager, _config.GetHospitalAudioAmbienceManagerConfig());
			_hospitalAwardsManager.RestoreFromSave();
			_characterManager.PostRestoreFromSave();
			_entityManager.PostRestoreFromSave();
			_topDownCameraLogic.RestoreFromSave(_inputManager, _userPreferences, _localPreferences, null, this);
			if (_config.GetLevelLightingConfig() != null)
			{
				_topDownCameraLogic.ShadowPlaneHeight = _config.GetLevelLightingConfig().ShadowPlaneHeight;
				_topDownCameraLogic.ShadowPlaneFadeDistance = _config.GetLevelLightingConfig().ShadowPlaneFadeDistance;
				if (_config.GetLevelLightingConfig().TopDownCameraFarClipPlane.UseOverride)
				{
					_topDownCameraLogic.CameraComponent.farClipPlane = _config.GetLevelLightingConfig().TopDownCameraFarClipPlane.Value;
				}
			}
			_levelCameraManager.RegisterCamera(_topDownCameraLogic);
			_randomlyLookAtCameraPOI.RestoreFromSave(_entityManager);
			_radio = new Radio(this, metagame.MetagameConfig.RadioConfig.Instance);
			_tannoyManager.RestoreFromSave(this, _config.GetTannoyManagerConfig());
			metagame.SetCurrentLevel(this);
			_metagameMap.InitialiseFromLevel(this, _gameTime, _topDownCameraLogic);
			_inputManager.AddGraphicRayCaster(_levelCommonScript.Raycaster);
			_workLifeBalanceManager.RestoreFromSave();
			_hospitalHUDManager = new HospitalHUDManager(app, this);
			_inWorldMessages = new InWorldMessages(_hud);
			_statusIconManager = new StatusIconManager(_config.GetStatusIconManagerConfig(), this, _dataViewManager, _buildEvents, _characterEvents);
			_buildingLogic.RestoreFromSave(_dataViewManager);
			_levelAnalyticsManager.RestoreFromSave(analyticsManager);
			m_levelDataManager = new LevelDataManager(this);
			_levelStatsCapture = new LevelStatsCapture(_characterManager);
			_staffRecordManager = new StaffRecordManager(_characterManager, _timelineManager, _characterEvents, _financeManager, _buildEvents);
			_sfxManager.RestoreFromSave();
			_staffWorkScheduler.RestoreFromSave();
			_challengeManager.RestoreFromSave();
			_reputationTracker.RestoreFromSave(_characterManager);
			_researchManager.RestoreFromSave();
			_guestTrainers.RestoreFromSave();
			_tutorialManager = new TutorialManager(this);
			_monoBeastManager.RestoreFromSave();
			_receptionManager.RestoreFromSave();
			_jobApplicantManager.RestoreFromSave();
			_hospitalEventLog.RestoreFromSave();
			_advisor.RestoreFromSave(_app, this, _config.GetAdvisorConfig(), _hud);
			_cursorManager.PushMode(new CursorSelect(_cursorManager, this, _worldState, _buildEvents, _characterManager, _metagame.HighlightManager, _monoBeastManager));
			_notificationAudioExclusiveModeEmitters = new List<AudioEmitter>();
			_radio.Start();
			_realWorldInitTime = DateTime.UtcNow;
			RegisterDebugCommands();
			RestoreGameEventsFromSave();
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			BuildEvents buildEvents = BuildEvents;
			buildEvents.OnCursorHighlight = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorHighlight, new Action<ICursorSelectable>(OnCursorSelection));
			PostConstruct.InvokeSafe();
			PostConstruct = null;
			_entityManager.VerifyAfterLoad();
			StartCameraFadeIn(2f);
			if (_app.LocalPreferences.Video.Particles == LocalPreferences.VideoPreferences.ParticleQualityMode.Low)
			{
				ParticleQualityController[] array = UnityEngine.Object.FindObjectsOfType<ParticleQualityController>();
				foreach (ParticleQualityController obj in array)
				{
					obj.ParticleSystem.Stop();
					obj.ParticleSystem.Clear();
				}
			}
		}

		public void Update()
		{
			if (!_metagameMap.IsVisible)
			{
				_gameTime.Update();
				float deltaTime = GameTime.deltaTime;
				float unscaledDeltaTime = GameTime.unscaledDeltaTime;
				float num = ((_gameTime.IsSuperPaused || _gameTime.IsPausedByUser || _gameTime.IsPausedByMenu) ? 0f : GameTime.unscaledDeltaTime);
				bool num2 = _hud.IsFullscreenMenuOpen();
				InboxMenu inboxMenu = _hud.FindMenu<InboxMenu>();
				bool flag = inboxMenu == null || inboxMenu.IsClosed();
				RibbonMenu ribbonMenu = _hud.FindMenu<RibbonMenu>();
				bool hireMenuClosed = ribbonMenu == null || ribbonMenu.CurrentMode != RibbonMenu.Mode.Hire;
				HandlePauseLogic();
				if (!_gameTime.IsSuperPaused && !_hud.IsPauseTimeMenuOpen)
				{
					_topDownCameraLogic.Update();
					_randomlyLookAtCameraPOI.Update(Time.deltaTime);
				}
				FadeMeshNearCameraComponent.UpdateAll();
				FadeMeshWorldHeightComponent.Update();
				_audioListenerManager.Update();
				_hospitalAudioMixerManager.Update();
				_audioAmbienceManager.Update();
				_cursorManager.Update();
				_levelScriptManager.Update(deltaTime, num);
				_challengeManager.Update(deltaTime);
				_advisor.Update(num);
				_workLifeBalanceManager.Update();
				_staffWorkScheduler.Update();
				_entityManager.Tick();
				_behaviourTreePool.Tick();
				_queuePathManager.Tick();
				_characterManager.Update(deltaTime);
				AutomaticSlidingDoorsCollision.Tick(_characterManager);
				_monoBeastManager.Update();
				_characterLookAtManager.Update();
				_timerManager.Update(deltaTime, num);
				_timelineManager.Update(deltaTime);
				_tutorialManager.Update();
				_inWorldMessages.Update(unscaledDeltaTime);
				_statusIconManager.Update();
				_jobApplicantManager.Update(deltaTime, hireMenuClosed);
				_radio.Update(num);
				if (!_awardCeremonyInProgress && !NotificationAudioExclusiveMode)
				{
					_tannoyManager.Update();
				}
				ProcessNotificationAudioExclusiveMode();
				_attributesManager.Update();
				_worldState.Update(deltaTime);
				_reputationTracker.Update(deltaTime);
				_dataViewManager.Update();
				if (!num2 && flag)
				{
					_notifications.Update();
				}
				_hospitalHUDManager.Update();
				_visualManager.Update();
				_hospitalEventLog.Update();
				_levelStatsCapture.Update();
				HandleAutosave();
			}
			else
			{
				_radio.Update(GameTime.unscaledDeltaTime, bInLevel: false);
			}
		}

		public void LateUpdate()
		{
			if (!_metagameMap.IsVisible)
			{
				_entityManager.LateTick();
				_hud.Update();
			}
		}

		private void HandlePauseLogic()
		{
			if (!_app.MessageBox.IsVisibleOrClosing && !_app.ExtContentManager.ExtContentUIManager.AreAnyUIScreensShown() && _inputManager.GetKeyDown(KeyCode.Escape))
			{
				_hospitalHUDManager.TogglePauseMenu();
			}
		}

		private void ProcessNotificationAudioExclusiveMode()
		{
			if (_notificationAudioExclusiveModeEmitters.Count <= 0)
			{
				return;
			}
			bool flag = false;
			while (!flag)
			{
				flag = true;
				foreach (AudioEmitter notificationAudioExclusiveModeEmitter in _notificationAudioExclusiveModeEmitters)
				{
					bool flag2 = false;
					if (notificationAudioExclusiveModeEmitter.Finished)
					{
						flag2 = true;
					}
					if (flag2)
					{
						_notificationAudioExclusiveModeEmitters.Remove(notificationAudioExclusiveModeEmitter);
						flag = false;
						break;
					}
				}
			}
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day != 0)
			{
				return;
			}
			switch (_userPreferences.Game.LevelAutoSaveFrequency)
			{
			case Preferences.GamePreferences.LevelAutoSaveFrequencyOption.EveryMonth:
				_shouldAutoSaveThisFrame = true;
				break;
			case Preferences.GamePreferences.LevelAutoSaveFrequencyOption.Every3Months:
				if (month % 3 == 0)
				{
					_shouldAutoSaveThisFrame = true;
				}
				break;
			case Preferences.GamePreferences.LevelAutoSaveFrequencyOption.Every6Months:
				if (month % 6 == 0)
				{
					_shouldAutoSaveThisFrame = true;
				}
				break;
			case Preferences.GamePreferences.LevelAutoSaveFrequencyOption.EveryYear:
				if (month == 0)
				{
					_shouldAutoSaveThisFrame = true;
				}
				break;
			}
		}

		private void HandleAutosave()
		{
			if (_shouldAutoSaveThisFrame)
			{
				_shouldAutoSaveThisFrame = false;
				_app.AutoSaveDeferred();
			}
		}

		public override void Destroy()
		{
			_hospitalEditEvents.OnEnd.InvokeSafe();
			BuildEvents buildEvents = BuildEvents;
			buildEvents.OnCursorHighlight = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorHighlight, new Action<ICursorSelectable>(OnCursorSelection));
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			_inputManager.RemoveGraphicRayCaster(_levelCommonScript.Raycaster);
			UnregisterDebugCommands();
			_gameTime.Destroy();
			_itemSpawnLimits.Destroy();
			_hospitalEventLog.Destroy();
			_levelScriptManager.Destroy();
			_levelAnalyticsManager.Destroy();
			_radio.Destroy();
			_audioAmbienceManager.Destroy();
			_tannoyManager.Destroy();
			_audioListenerManager.Destroy();
			_hospitalAudioMixerManager.Destroy();
			_visualManager.Destroy();
			_notifications.Destroy();
			m_levelDataManager.Destroy();
			_levelStatsCapture.Destroy();
			_workLifeBalanceManager.Destroy();
			_advisor.Destroy();
			_toughLuckBalancer.Destroy();
			_dataViewManager.Destroy();
			_gameplayStatsTracker.Destroy();
			_characterLookAtManager.RemoveGlobalPOI(_randomlyLookAtCameraPOI);
			_randomlyLookAtCameraPOIEntity.Destroy();
			_levelCameraManager.Destroy();
			_levelCameraManager.UnregisterCamera(_topDownCameraLogic);
			_topDownCameraLogic.Destroy();
			_staffWorkScheduler.Destroy();
			_statusIconManager.Destroy();
			_inWorldMessages.Destroy();
			_prestigeTracker.Destroy();
			_reputationTracker.Destroy();
			_hospitalAwardsManager.Destroy();
			_yearlyTargetsManager.Destroy();
			_staffRecordManager.Destroy();
			_characterManager.Destroy();
			_sfxManager.Destroy();
			_buildingLogic.Destroy();
			_worldState.Destroy();
			_hospitalHUDManager.Destroy();
			_cursorManager.Destroy();
			_hud.Destroy();
			_loanManager.Destroy();
			_levelStatsDatabase.Destroy();
			_hospitalFailState.Destroy();
			_financeManager.Destroy();
			_guestTrainers.Destroy();
			_tutorialManager.Destroy();
			_monoBeastManager.Destroy();
			_receptionManager.Destroy();
			_jobApplicantManager.Destroy();
			_researchManager.Destroy();
			_challengeManager.Destroy();
			_timerManager.Destroy();
			_timelineManager.Destroy();
			_entityManager.Destroy();
			_buildEvents.Destroy();
			_characterEvents.Destroy();
			_hospitalEditEvents.Destroy();
			_hudEvents.Destroy();
			_behaviourTreePool.Destroy();
			_queuePathManager.Destroy();
			GameEventsRegistry.VerifyAndClearLevelEvents();
			base.Destroy();
		}

		public void OnGUI()
		{
			_cursorManager.OnGUI();
			if (DebugVars.ShowDebugInfo.Value)
			{
				_worldState.DebugGUI();
				_characterManager.DebugGUI();
				_reputationTracker.DebugGUI();
				_cursorManager.DebugGUI();
				_hud.DebugGUI();
				_staffWorkScheduler.DebugGUI();
				_workLifeBalanceManager.DebugGUI();
				_behaviourTreePool.DebugGUI();
				NavPath.DebugGUI(_characterManager);
				DebugGUI();
			}
		}

		public void OnDrawGizmos()
		{
			if (DebugVars.ShowDebugInfo.Value)
			{
				_worldState.DebugDraw();
				_cursorManager.DebugDraw();
				_characterManager.DebugDraw();
			}
		}

		public void AddTimelineUpdateListener(Action<int, int, int> listener)
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, listener);
		}

		public void RemoveTimelineUpdateListener(Action<int, int, int> listener)
		{
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, listener);
		}

		public byte[] TakeThumbnail()
		{
			if (Camera.main == _topDownCameraLogic.CameraComponent)
			{
				_thumbnailPNG = CameraUtils.TakeScreenShotAsBytes(_topDownCameraLogic.CameraComponent, 300, 180);
				return _thumbnailPNG;
			}
			return _thumbnailPNG;
		}

		public void StartCameraFadeIn(float transitionTime)
		{
			if (_topDownCameraLogic != null)
			{
				_topDownCameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraCloudZoomComponent>().ZoomIn(transitionTime, 50f);
			}
			_app.FadeIn(transitionTime, Color.white);
		}

		private void SetCameraFocusToMainEntrance()
		{
			GameObject gameObject = GameObject.Find("CameraStartTransform");
			if (gameObject != null)
			{
				Transform transform = gameObject.transform;
				_topDownCameraLogic.SetInitialFocalPoint(transform.position, transform.rotation.eulerAngles.y);
			}
			else if (_worldState.HospitalPlots.Count != 0 && _worldState.HospitalPlots[0].HospitalMap != null && _worldState.HospitalPlots[0].HospitalMap.FloorPlan != null)
			{
				RoomItem door = _worldState.HospitalPlots[0].HospitalMap.FloorPlan.Door;
				if (door != null)
				{
					Vector3 vector = door.GridRotation.DirectionVector() * _config.InitialCameraOffset;
					_topDownCameraLogic.SetFocalPoint(door.WorldPosition + vector, snap: true);
				}
			}
		}

		private void InitHospitalScenario()
		{
			if (Config.HospitalScenario.NotNull() && !IsSandbox())
			{
				Config.HospitalScenario.Instance.ApplyToLevel(this);
			}
		}

		public bool IsSandbox()
		{
			return SandboxSaveManager.CurrentSettings != null;
		}

		public SandboxSettings GetSandboxSettings()
		{
			return SandboxSaveManager.CurrentSettings;
		}

		public JobApplicantManager.Config GetJobApplicantManagerConfig()
		{
			if (IsSandbox())
			{
				JobApplicantManager.Config jobApplicantsConfig = SandboxSaveManager.CurrentSettings.JobApplicantsConfig;
				int jobApplicantsIndex = SandboxSaveManager.CurrentSettings.GetJobApplicantsIndex();
				JobApplicantManager.Config config = null;
				if (UniqueID == "934" || UniqueID == "935" || UniqueID == "936")
				{
					config = _config.GetSandboxJobApplicantManagerConfig();
				}
				if (jobApplicantsConfig != null && jobApplicantsIndex != 0)
				{
					if (config != null)
					{
						jobApplicantsConfig.Qualifications = config.Qualifications;
					}
					return jobApplicantsConfig;
				}
				if (config != null)
				{
					return config;
				}
			}
			return _config.GetJobApplicantManagerConfig();
		}

		private LevelScriptManager.Config GetLevelScriptConfig()
		{
			if (IsSandbox())
			{
				LevelScriptManager.Config levelScriptConfig = SandboxSaveManager.CurrentSettings.LevelScriptConfig;
				if (levelScriptConfig != null)
				{
					return levelScriptConfig;
				}
			}
			return _config.GetLevelScriptConfig();
		}

		private ResearchManager.Config GetResearchManagerConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.ResearchConfig.NotNull())
			{
				return App.SandboxSettingsConfig.ResearchConfig.Instance;
			}
			return _config.GetResearchManagerConfig();
		}

		private FinanceManager.Config GetFinanceManagerConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.FinanceConfig.NotNull())
			{
				return App.SandboxSettingsConfig.FinanceConfig.Instance;
			}
			return _config.GetFinanceManagerConfig();
		}

		private Advisor.Config GetAdvisorConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.AdvisorConfig.NotNull())
			{
				return App.SandboxSettingsConfig.AdvisorConfig.Instance;
			}
			return _config.GetAdvisorConfig();
		}

		private ChallengeManager.Config GetChallengeManagerConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.ChallengeConfig.NotNull())
			{
				return App.SandboxSettingsConfig.ChallengeConfig.Instance;
			}
			return _config.GetChallengeManagerConfig();
		}

		public ChallengeManager.Config GetLevelOnlyChallengeConfig()
		{
			return _config.GetChallengeManagerConfig();
		}

		private StaffChallengeManager.Config GetStaffChallengeManagerConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.StaffChallengeConfig.NotNull())
			{
				return App.SandboxSettingsConfig.StaffChallengeConfig.Instance;
			}
			return _config.GetStaffChallengeManagerConfig();
		}

		private HospitalAwardsManager.Config GetHospitalAwardsManagerConfig()
		{
			if (IsSandbox() && App.SandboxSettingsConfig.HospitalAwardsConfig.NotNull())
			{
				return App.SandboxSettingsConfig.HospitalAwardsConfig.Instance;
			}
			return _config.GetHospitalAwardsConfig();
		}

		private void RegisterDebugCommands()
		{
			ConsoleCommandsDatabase.RegisterCommand("LoadDevConfig", "Load the Dev Config file", "LoadDevConfig", Debug_LoadDevConfig);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugPause", "Toggle game debug pause", "ToggleDebugPause", ToggleDebugPause);
			ConsoleCommandsDatabase.RegisterCommand("ToggleSelectionInfo", "Toggle cursor selection info", "ToggleSelectionInfo", ToggleSelectionInfo);
			ConsoleCommandsDatabase.RegisterCommand("DebugKillCharacter", "Kill the character currently selected", "DebugKillCharacter", DebugKillCharacter);
			ConsoleCommandsDatabase.RegisterCommand("DebugDestroyCharacter", "Destroy the character currently selected", "DebugDestroyCharacter", DebugDestroyCharacter);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterToiletFull", "Set the selected character's toilet attribute to full", "SetCharacterToiletFull", SetCharacterToiletFull);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterBoredomFull", "Set the selected character's boredom attribute to full", "SetCharacterBoredomFull", SetCharacterBoredomFull);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterEnergyEmpty", "Set the selected character's energy attribute to empty", "SetCharacterEnergyEmpty", SetCharacterEnergyEmpty);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterHungerFull", "Set the selected character's hunger attribute to full", "SetCharacterHungerFull", SetCharacterHungerFull);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterLitterFull", "Set the selected character's litter attribute to full", "SetCharacterLitterFull", SetCharacterLitterFull);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterThirstFull", "Set the selected character's thirst attribute to full", "SetCharacterThirstFull", SetCharacterThirstFull);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterHappinessEmpty", "Set the selected character's happiness attribute to empty", "SetCharacterHappinessEmpty", SetCharacterHappinessEmpty);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterHappinessFull", "Set the selected character's happiness attribute to full", "SetCharacterHappinessFull", SetCharacterHappinessFull);
			ConsoleCommandsDatabase.RegisterCommand("PixelateCharacter", "Makes the selected character pixelated", "PixelateCharacter", SetCharacterPixelated);
			ConsoleCommandsDatabase.RegisterCommand("ApplyCharacterMask", "Apply Character Mask", "Apply Character Mask", ApplyCharacterMask);
			ConsoleCommandsDatabase.RegisterCommand("RemoveCharacterSkinOverride", "Remove Character Skin Override", "Remove Character Skin Override", RemoveCharacterSkinOverride);
			ConsoleCommandsDatabase.RegisterCommand("SetCharacterNameOverride", "Set character's user specified name", "SetCharacterNameOverride", Debug_SetCharacterNameOverride);
			ConsoleCommandsDatabase.RegisterCommand("SetRoomNameOverride", "Set room's user specified name", "SetRoomNameOverride", Debug_SetRoomNameOverride);
			ConsoleCommandsDatabase.RegisterCommand("AddStaffXP", "Increase the selected staff member's XP", "AddStaffXP", AddStaffXP);
			ConsoleCommandsDatabase.RegisterCommand("SetStaffRank", "Set staff member's rank level", "SetStaffRank", Debug_SetStaffRank);
			ConsoleCommandsDatabase.RegisterCommand("SetStaffRequiresTraining", "Set staff member requires training", "SetStaffRequiresTraining", Debug_SetStaffRequiresTraining);
			ConsoleCommandsDatabase.RegisterCommand("StaffResign", "Make the selected staff member resign", "StaffResign", Debug_StaffResign);
			ConsoleCommandsDatabase.RegisterCommand("StaffThreatenToLeave", "Make the selected staff member threaten to leave", "StaffResign", Debug_StaffThreatenToLeave);
			ConsoleCommandsDatabase.RegisterCommand("ApplyDamage", "Applies damage to the room item", "ApplyDamage", Debug_ApplyDamage);
			ConsoleCommandsDatabase.RegisterCommand("SetMaintenanceLevelFull", "Set the selected room item's maintenance attribute to full", "SetMaintenanceLevelFull", Debug_SetMaintenanceLevelFull);
			ConsoleCommandsDatabase.RegisterCommand("UpgradeItem", "Upgrades the selected room item", "UpgradeItem", Debug_UpgradeItem);
			ConsoleCommandsDatabase.RegisterCommand("CompleteDiagnosis", "Completes diagnosis and sends patient to treatment room", "CompleteDiagnosis", DebugCompleteDiagnosis);
			ConsoleCommandsDatabase.RegisterCommand("RageQuit", "Make the patient rage quit", "RageQuit", DebugRageQuit);
			ConsoleCommandsDatabase.RegisterCommand("AssignQualification", "Assign qualification to staff member", "AssignQualification", Debug_AssignQualification);
			ConsoleCommandsDatabase.RegisterCommand("ClearQualifications", "Removes all qualifications on the staff member", "ClearQualifications", Debug_ClearQualifications);
			ConsoleCommandsDatabase.RegisterCommand("MarkForPromotion", "Sets the selected character as ready for promotion", "MarkForPromotion", Debug_MarkForPromotion);
			ConsoleCommandsDatabase.RegisterCommand("AssignTrait", "Assign trait to character", "AssignTrait", Debug_AssignTrait);
			ConsoleCommandsDatabase.RegisterCommand("ClearTraits", "Removes all traits on a character", "ClearQualifications", Debug_ClearTraits);
			ConsoleCommandsDatabase.RegisterCommand("SetHiresFlavourTrait", "Assigns the specified flavour trait key to the first doctor in the hire menu", "SetHiresFlavourTrait <TraitNumber> <Gender>", Debug_SetHiresFlavourTrait);
			ConsoleCommandsDatabase.RegisterCommand("AssignGuiltTrip", "Assigns the specified guilt trip key to a character", "AssignGuiltTrip <TraitNumber> <Gender>", Debug_AssignGuiltTrip);
			ConsoleCommandsDatabase.RegisterCommand("EditHospital", "Edit hospital layout", "EditHospital", Debug_EditHospital);
			ConsoleCommandsDatabase.RegisterCommand("BuyPlot", "Buy a specific hospital plot", "BuyPlot", Debug_BuyPlot);
			ConsoleCommandsDatabase.RegisterCommand("SellPlot", "Sell a specific hospital plot", "SellPlot", Debug_SellPlot);
			ConsoleCommandsDatabase.RegisterCommand("OffsetLandscapeItems", "Offset all landscape items", "OffsetLandscapeItems X Y", Debug_OffsetLandscapeItems);
			ConsoleCommandsDatabase.RegisterCommand("NukeLandscapeItems", "Deletes all landscape items containing tag", "NukeLandscapeItems <tag>", Debug_NukeLandscapeItems);
			ConsoleCommandsDatabase.RegisterCommand("DestroyItems", "Destroys all room items containing tag", "DestroyItems <tag>", Debug_DestroyItems);
			ConsoleCommandsDatabase.RegisterCommand("NumItemsWithTag", "Prints number of items matching debug tag", "DestroyItems <tag>", Debug_PrintNumItemsWithTag);
			ConsoleCommandsDatabase.RegisterCommand("CompletePlotChallenges", "Complete hospital plot challenges", "CompletePlotChallenges", Debug_CompletePlotChallenges);
			ConsoleCommandsDatabase.RegisterCommand("DestroyAllRooms", "Destroys all rooms", "DestroyAllRooms", Debug_DestroyAllRooms);
			ConsoleCommandsDatabase.RegisterCommand("LoadRoomLayout", "Load room layout config file", "LoadRoomLayout", Debug_LoadRoomLayout);
			ConsoleCommandsDatabase.RegisterCommand("SaveRoomLayout", "Save room layout config file", "SaveRoomLayout", Debug_SaveRoomLayout);
			ConsoleCommandsDatabase.RegisterCommand("SpawnRequiredStaff", "Spawn required staff", "SpawnRequiredStaff", Debug_SpawnRequiredStaff);
			ConsoleCommandsDatabase.RegisterCommand("ReloadRoomLights", "Reload Room Lights", "Reload Room Lights", Debug_ReloadRoomLights);
			ConsoleCommandsDatabase.RegisterCommand("AutoReloadLighting", "Auto Reload Room Lights", "Auto Reload Room Lights", Debug_AutoReloadLighting);
			ConsoleCommandsDatabase.RegisterCommand("PlaySoundEventEndlessly", "Play and loop a Sound Event Endlessly", "Play and loop a Sound Event Endlessly", Debug_PlaySoundEventEndlessly);
			ConsoleCommandsDatabase.RegisterCommand("SetWorkLifeBalance", "Sets the staff work life balance slider", "SetWorkLifeBalance <type> <rank> <slider>", Debug_SetWorkLifeBalance);
			ConsoleCommandsDatabase.RegisterCommand("DumpStaffJobScores", "Dumps out a log of all job scores for the selected staff member", "DumpStaffJobScores", Debug_DumpStaffJobScores);
			ConsoleCommandsDatabase.RegisterCommand("LogStaffRecord", "Logs the current staff record for the current year", "LogStaffRecord", LogStaffRecord);
			ConsoleCommandsDatabase.RegisterCommand("RetroEveryone", "Make all characters have retro effect", "RetroEveryone", RetroEveryone);
			ConsoleCommandsDatabase.RegisterCommand("DisableAllCharacterVisualModes", "Disable all visual modes on all characters", "DisableAllCharacterVisualModes", DisableAllCharacterVisualModes);
			ConsoleCommandsDatabase.RegisterCommand("SaveScenario", "Saves current level scenario", "SaveScenario", Debug_SaveScenario);
			ConsoleCommandsDatabase.RegisterCommand("ToggleStaffCustomisationMenu", "Show menu that allows staff customisation", "Show menu that allows staff customisation", Debug_ToggleStaffCustomisationMenu);
			ConsoleCommandsDatabase.RegisterCommand("ShowHospitalEventLog", "ShowHospitalEventLog", "ShowHospitalEventLog", Debug_ShowHospitalEventLog);
			ConsoleCommandsDatabase.RegisterCommand("PushCursorVaccinate", "Activate Vaccinate Cursor", "Activate Vaccinate Cursor", Debug_PushCursorVaccinate);
			ConsoleCommandsDatabase.RegisterCommand("ToggleLevelCamera", "Toggles level camera on/off, to be used when other cameras are available", "ToggleLevelCamera", Debug_ToggleLevelCamera);
			ConsoleCommandsDatabase.RegisterCommand("ToggleDebugLevelCamera", "Allows greater pitch angles on the level camera", "ToggleDebugLevelCamera", Debug_ToggleDebugLevelCamera);
			ConsoleCommandsDatabase.RegisterCommand("DisableAA", "Disable Antialiasing", "DisableAA", Debug_DisableAA);
			ConsoleCommandsDatabase.RegisterCommand("EnableSMAA", "Enable Subpixel Morphological Antialiasing", "EnableSMAA", Debug_EnableSMAA);
			ConsoleCommandsDatabase.RegisterCommand("EnableFXAA", "Enable Fast Approximate Antialiasing", "EnableFXAA", Debug_EnableFXAA);
			ConsoleCommandsDatabase.RegisterCommand("EnableTAA", "Enable Temporal Antialiasing", "EnableTAA", Debug_EnableTAA);
			ConsoleCommandsDatabase.RegisterCommand("DisableLargeRT", "Disables Large RT for capturing", "DisableLargeRT", Debug_DisableLargeRT);
			ConsoleCommandsDatabase.RegisterCommand("EnableLargeRT", "Enable Large RT for capturing", "EnableLargeRT <scale>", Debug_EnableLargeRT);
			ConsoleCommandsDatabase.RegisterCommand("ToggleShadowCulling", "Toggle the shadow culling optimisation", "ToggleShadowCulling", Debug_ToggleShadowCulling);
			ConsoleCommandsDatabase.RegisterCommand("SetTextureOverrideOnAllItems", "", "", Debug_SetTextureOverrideOnAllItems);
		}

		private ConsoleCommandResult Debug_CompletePlotChallenges(string[] args)
		{
			foreach (HospitalPlot hospitalPlot in WorldState.HospitalPlots)
			{
				hospitalPlot.CompletePlotChallenges();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void UnregisterDebugCommands()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("LoadDevConfig");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugPause");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleSelectionInfo");
			ConsoleCommandsDatabase.UnRegisterCommand("DebugKillCharacter");
			ConsoleCommandsDatabase.UnRegisterCommand("DebugDestroyCharacter");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterToiletFull");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterToiletFull");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterBoredomFull");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterEnergyEmpty");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterHungerFull");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterLitterFull");
			ConsoleCommandsDatabase.UnRegisterCommand("SetCharacterThirstFull");
			ConsoleCommandsDatabase.UnRegisterCommand("ApplyCharacterMask");
			ConsoleCommandsDatabase.UnRegisterCommand("PixelateCharacter");
			ConsoleCommandsDatabase.UnRegisterCommand("AddStaffXP");
			ConsoleCommandsDatabase.UnRegisterCommand("SetStaffRank");
			ConsoleCommandsDatabase.UnRegisterCommand("ApplyDamage");
			ConsoleCommandsDatabase.UnRegisterCommand("SetMaintenanceLevelFull");
			ConsoleCommandsDatabase.UnRegisterCommand("UnlockAllIllnesses");
			ConsoleCommandsDatabase.UnRegisterCommand("CompleteDiagnosis");
			ConsoleCommandsDatabase.UnRegisterCommand("AssignQualification");
			ConsoleCommandsDatabase.UnRegisterCommand("ClearQualifications");
			ConsoleCommandsDatabase.UnRegisterCommand("MarkForPromotion");
			ConsoleCommandsDatabase.UnRegisterCommand("SetHiresFlavourTrait");
			ConsoleCommandsDatabase.UnRegisterCommand("AssignGuiltTrip");
			ConsoleCommandsDatabase.UnRegisterCommand("EditHospital");
			ConsoleCommandsDatabase.UnRegisterCommand("SpawnRequiredStaff");
			ConsoleCommandsDatabase.UnRegisterCommand("ReloadRoomLights");
			ConsoleCommandsDatabase.UnRegisterCommand("AutoReloadLighting");
			ConsoleCommandsDatabase.UnRegisterCommand("PlaySoundEventEndlessly");
			ConsoleCommandsDatabase.UnRegisterCommand("SetWorkLifeBalance");
			ConsoleCommandsDatabase.UnRegisterCommand("DumpStaffJobScores");
			ConsoleCommandsDatabase.UnRegisterCommand("LogStaffRecord");
			ConsoleCommandsDatabase.UnRegisterCommand("RetroEveryone");
			ConsoleCommandsDatabase.UnRegisterCommand("DisableAllCharacterVisualModes");
			ConsoleCommandsDatabase.UnRegisterCommand("ShowHospitalEventLog");
			ConsoleCommandsDatabase.UnRegisterCommand("PushCursorVaccinate");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleLevelCamera");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleDebugLevelCamera");
			ConsoleCommandsDatabase.UnRegisterCommand("DisableAA");
			ConsoleCommandsDatabase.UnRegisterCommand("EnableSMAA");
			ConsoleCommandsDatabase.UnRegisterCommand("EnableFXAA");
			ConsoleCommandsDatabase.UnRegisterCommand("EnableTAA");
			ConsoleCommandsDatabase.UnRegisterCommand("EnableLargeRT");
			ConsoleCommandsDatabase.UnRegisterCommand("DisableLargeRT");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleShadowCulling");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleStaffCustomisationMenu");
			ConsoleCommandsDatabase.UnRegisterCommand("SetTextureOverrideOnAllItems");
			ConsoleCommandsDatabase.UnRegisterCommand("SetTextureOverrideOnAllFloorTiles");
			ConsoleCommandsDatabase.UnRegisterCommand("SetTextureOverrideOnAllWalls");
		}

		private void OnCursorSelection(ICursorSelectable cursorSelectable)
		{
			_cursorSelectable = cursorSelectable;
			_cursorCharacter = _cursorSelectable as Character;
			_cursorRoomItem = _cursorSelectable as RoomItem;
		}

		private ConsoleCommandResult ToggleDebugPause(string[] args)
		{
			_gameTime.IsPausedByUser = !_gameTime.IsPausedByUser;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult ToggleSelectionInfo(string[] args)
		{
			if (_cursorSelectable != null)
			{
				_cursorSelectable.ToggleDebugInfo();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugKillCharacter(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Health, -100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugDestroyCharacter(string[] args)
		{
			if (_cursorCharacter != null)
			{
				CharacterEvents.OnDestroyCharacter.InvokeSafe(_cursorCharacter);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterToiletFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Toilet, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterBoredomFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Boredom, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterEnergyEmpty(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Energy, -100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterHungerFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Hunger, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterLitterFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Litter, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterThirstFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Thirst, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterHappinessEmpty(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Happiness, -100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterHappinessFull(string[] args)
		{
			ModifyCursorCharacterAttribute(CharacterAttributes.Type.Happiness, 100f);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult SetCharacterPixelated(string[] args)
		{
			if (_cursorCharacter != null)
			{
				_cursorCharacter.GetOrAddComponent<PixelateCharacterComponent>();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult ApplyCharacterMask(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("Invalid number of arguments");
			}
			if (_cursorCharacter != null)
			{
				SharedInstance_TH20TH20_CharModule_Mask[] array = Resources.FindObjectsOfTypeAll<SharedInstance_TH20TH20_CharModule_Mask>();
				foreach (SharedInstance_TH20TH20_CharModule_Mask sharedInstance_TH20TH20_CharModule_Mask in array)
				{
					if (sharedInstance_TH20TH20_CharModule_Mask.name == args[0])
					{
						_cursorCharacter.Visual.SetModularMask(sharedInstance_TH20TH20_CharModule_Mask.Instance);
						return ConsoleCommandResult.Succeeded();
					}
				}
			}
			return ConsoleCommandResult.Failed($"Mask {args[0]} does not exists");
		}

		private ConsoleCommandResult RemoveCharacterSkinOverride(string[] args)
		{
			if (_cursorCharacter != null)
			{
				_cursorCharacter.Visual.SetSkinSelectionOverride(null);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed();
		}

		private ConsoleCommandResult RetroEveryone(string[] args)
		{
			foreach (Character allCharacter in _characterManager.AllCharacters)
			{
				allCharacter.Visual.RetroModeEnabled = true;
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DisableAllCharacterVisualModes(string[] args)
		{
			foreach (Character allCharacter in _characterManager.AllCharacters)
			{
				allCharacter.Visual.RetroModeEnabled = false;
				allCharacter.Visual.GreyAnatomyModeEnabled = false;
				allCharacter.Visual.ValueModeEnabled = false;
				allCharacter.Visual.ShockModeEnabled = false;
				allCharacter.Visual.XRayModeEnabled = false;
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult AddStaffXP(string[] args)
		{
			return ConsoleCommandHelpers.ExtractInt(delegate(int amount)
			{
				ModifyCursorCharacterAttribute(CharacterAttributes.Type.XP, amount);
			}, args);
		}

		private ConsoleCommandResult Debug_SetStaffRank(string[] args)
		{
			Staff cursorStaff = _cursorCharacter as Staff;
			if (cursorStaff != null)
			{
				return ConsoleCommandHelpers.ExtractInt(delegate(int rank)
				{
					cursorStaff.SetRank(rank);
				}, args);
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private string GetConcatenatedArgsString(string[] args)
		{
			return string.Empty;
		}

		private ConsoleCommandResult Debug_SetCharacterNameOverride(string[] args)
		{
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetRoomNameOverride(string[] args)
		{
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetStaffRequiresTraining(string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				staff.Debug_ForceRequiresTraining();
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private ConsoleCommandResult Debug_StaffResign(string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				staff.Resign();
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private ConsoleCommandResult Debug_StaffThreatenToLeave(string[] args)
		{
			if (_cursorCharacter is Staff param)
			{
				CharacterEvents.OnStaffThreatenToLeave.InvokeSafe(param);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private ConsoleCommandResult Debug_ApplyDamage(string[] args)
		{
			if (_cursorRoomItem != null && _cursorRoomItem.MaintenanceLevel != null)
			{
				_cursorRoomItem.MaintenanceLevel.Modify(5f, 1f);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetMaintenanceLevelFull(string[] args)
		{
			if (_cursorRoomItem != null && _cursorRoomItem.MaintenanceLevel != null)
			{
				_cursorRoomItem.MaintenanceLevel.Modify(100f, 1f);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UpgradeItem(string[] args)
		{
			if (_cursorRoomItem != null && _cursorRoomItem.MaintenanceLevel != null && _cursorRoomItem.Definition.GetNextUpgrade(_cursorRoomItem.UpgradeLevel) != null)
			{
				_cursorRoomItem.Upgrade(null);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void ModifyCursorCharacterAttribute(CharacterAttributes.Type attributeName, float valueChange)
		{
			if (_cursorCharacter != null)
			{
				_cursorCharacter.GetCharacterAttributes().GetAttribute(attributeName)?.Modify(valueChange, 1f);
			}
		}

		private ConsoleCommandResult DebugRageQuit(string[] args)
		{
			if (_cursorCharacter is Patient patient)
			{
				patient.RageQuit();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugCompleteDiagnosis(string[] args)
		{
			if (_cursorCharacter is Patient patient)
			{
				patient.ModifyDiagnosisCertainty(100f);
				if (patient.ReasonUsingRoom != ReasonUseRoom.Treatment)
				{
					patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, _researchManager), immediately: true);
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		public void Debug_RegisterAssignQualification(QualificationDefinition definition)
		{
			ConsoleCommandsDatabase.RegisterCommand($"AssignQualification {definition.NameLocalised}", "Assign qualification " + definition.NameLocalised.ToString() + "to staff member", "AssignQualification", Debug_AssignQualification);
		}

		private ConsoleCommandResult Debug_AssignQualification(params string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				QualificationDefinition qualificationDefinition = null;
				if (args.Length >= 1)
				{
					string text = args[0];
					for (int i = 1; i < args.Length; i++)
					{
						text = text + " " + args[i];
					}
					foreach (QualificationDefinition key in _jobApplicantManager.Qualifications.List.Keys)
					{
						if (string.Equals(key.NameLocalised.ToString(), text, StringComparison.OrdinalIgnoreCase))
						{
							qualificationDefinition = key;
							break;
						}
					}
					if (qualificationDefinition != null)
					{
						staff.Debug_AssignQualification(qualificationDefinition);
						return ConsoleCommandResult.Succeeded();
					}
					return ConsoleCommandResult.Failed("Couldn't find qualification with name " + text);
				}
				return ConsoleCommandResult.Failed("Missing qualification name parameter");
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private ConsoleCommandResult Debug_ClearQualifications(params string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				staff.Debug_RemoveQualifications();
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		private ConsoleCommandResult Debug_MarkForPromotion(params string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				staff.Debug_MarkForPromotion();
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No staff member selected");
		}

		public void Debug_RegisterAssignTrait(CharacterTraitDefinition definition)
		{
			ConsoleCommandsDatabase.RegisterCommand($"AssignTrait {definition.GetShortName(Character.Sex.Male)}", "Assign trait " + SharedInstanceUtils.GetSharedInstance(definition).name + "to staff member", "AssignTrait", Debug_AssignTrait);
		}

		private ConsoleCommandResult Debug_AssignTrait(string[] args)
		{
			if (_cursorCharacter != null)
			{
				CharacterTraitDefinition characterTraitDefinition = null;
				if (args.Length >= 1)
				{
					string text = args[0];
					for (int i = 1; i < args.Length; i++)
					{
						text = text + " " + args[i];
					}
					foreach (CharacterTraitDefinition key in _characterTraitsManager.AllTraits.List.Keys)
					{
						if (string.Equals(key.ShortNameLocalisedMale.ToString(), text, StringComparison.OrdinalIgnoreCase))
						{
							characterTraitDefinition = key;
							break;
						}
					}
					if (characterTraitDefinition != null)
					{
						_cursorCharacter.Traits.Add(characterTraitDefinition);
						return ConsoleCommandResult.Succeeded();
					}
					return ConsoleCommandResult.Failed("Couldn't find trait with name " + text);
				}
				return ConsoleCommandResult.Failed("Missing trait name parameter");
			}
			return ConsoleCommandResult.Failed("No character selected");
		}

		private ConsoleCommandResult Debug_ClearTraits(string[] args)
		{
			if (_cursorCharacter != null)
			{
				_cursorCharacter.Traits.RemoveAll(_cursorCharacter);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("No character selected");
		}

		private ConsoleCommandResult Debug_SetHiresFlavourTrait(string[] args)
		{
			if (args.Length == 2)
			{
				string s = args[0];
				if (int.TryParse(s, out var _))
				{
					string text = args[1];
					if (text[0] == 'F' || text[0] == 'M')
					{
						Character.Sex sex = ((text[0] == 'F') ? Character.Sex.Female : Character.Sex.Male);
						StaffDefinition.Type staffType = StaffDefinition.Type.Doctor;
						JobApplicant jobApplicant = _jobApplicantManager.GetJobApplicantPool(staffType).Applicants[0];
						CharacterTraits newTraits = _characterTraitsManager.Debug_GenerateSpecificFlavourTrait(staffType, sex, int.Parse(s));
						jobApplicant.Debug_SetTraits(newTraits);
						return ConsoleCommandResult.Succeeded();
					}
					return ConsoleCommandResult.Failed("Gender must be either Male, Female, M or F");
				}
				return ConsoleCommandResult.Failed("Trait ID must be a number");
			}
			return ConsoleCommandResult.Failed("Invalid peramiters. Must provide <TraitNumber> <Gender>");
		}

		private ConsoleCommandResult Debug_AssignGuiltTrip(string[] args)
		{
			if (_cursorCharacter != null)
			{
				if (args.Length == 2)
				{
					Staff staff = _cursorCharacter as Staff;
					string s = args[0];
					if (int.TryParse(s, out var _))
					{
						string text = args[1];
						if (text[0] == 'F' || text[0] == 'M')
						{
							Character.Sex sex = ((text[0] == 'F') ? Character.Sex.Female : Character.Sex.Male);
							LocalisedString newGuiltTrip = _characterTraitsManager.Debug_GetSpecificGuiltTrip(sex, int.Parse(s));
							staff?.Debug_SetGuiltTrip(newGuiltTrip);
							return ConsoleCommandResult.Succeeded();
						}
						return ConsoleCommandResult.Failed("Gender must be either Male, Female, M or F");
					}
					return ConsoleCommandResult.Failed("Guilt trip ID must be a number");
				}
				return ConsoleCommandResult.Failed("Invalid peramiters. Must provide <GuiltTripNumber> <Gender>");
			}
			return ConsoleCommandResult.Failed("No character selected");
		}

		private ConsoleCommandResult Debug_EditHospital(string[] args)
		{
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_BuyPlot(string[] args)
		{
			ConsoleCommandResult result = ConsoleCommandResult.Succeeded();
			ConsoleCommandResult result2 = ConsoleCommandHelpers.ExtractInt(delegate(int plotIndex)
			{
				List<HospitalPlot> hospitalPlots = _worldState.HospitalPlots;
				if (plotIndex >= 0 && plotIndex < hospitalPlots.Count)
				{
					hospitalPlots[plotIndex].Buy();
				}
				else
				{
					result = ConsoleCommandResult.Failed("Invalid plot index");
				}
			}, args);
			if (!result2.succeeded)
			{
				return result2;
			}
			return result;
		}

		private ConsoleCommandResult Debug_OffsetLandscapeItems(string[] args)
		{
			if (int.TryParse(args[0], out var result) && int.TryParse(args[1], out var result2))
			{
				HospitalEditEvents.OnOffsetLandsacpeItems.InvokeSafe(result, result2);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_NukeLandscapeItems(string[] args)
		{
			if (args.Length != 0)
			{
				HospitalEditEvents.OnNukeLandscapeItems.InvokeSafe(args[0]);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Missing item tag parameter");
		}

		private ConsoleCommandResult Debug_DestroyItems(string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("Missing item tag parameter");
			}
			string toCheck = args[0];
			List<RoomItem> list = new List<RoomItem>();
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.Definition.DebugTag.Contains(toCheck, StringComparison.OrdinalIgnoreCase))
					{
						list.Add(item);
					}
				}
			}
			foreach (RoomItem item2 in list)
			{
				_buildEvents.OnRoomItemDestroy.InvokeSafe(item2);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PrintNumItemsWithTag(string[] args)
		{
			string text = string.Join(" ", args);
			int num = 0;
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.Definition.DebugTag == text)
					{
						num++;
					}
				}
			}
			return ConsoleCommandResult.Succeeded(num.ToString());
		}

		private ConsoleCommandResult Debug_SellPlot(string[] args)
		{
			ConsoleCommandResult result = ConsoleCommandResult.Succeeded();
			ConsoleCommandResult result2 = ConsoleCommandHelpers.ExtractInt(delegate(int plotIndex)
			{
				List<HospitalPlot> hospitalPlots = _worldState.HospitalPlots;
				if (plotIndex >= 0 && plotIndex < hospitalPlots.Count)
				{
					hospitalPlots[plotIndex].Sell();
				}
				else
				{
					result = ConsoleCommandResult.Failed("Invalid plot index");
				}
			}, args);
			if (!result2.succeeded)
			{
				return result2;
			}
			return result;
		}

		private ConsoleCommandResult Debug_LoadRoomLayout(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("Invalid number of arguments");
			}
			string text = Path.Combine(Directories.GameOutputDirectory, args[0]);
			Configuration configuration = Configuration.LoadFromFile(text);
			fsSerializer fsSerializer2 = new fsSerializer();
			if (configuration == null)
			{
				return ConsoleCommandResult.Failed($"Missing room layout file {text}");
			}
			string stringValue = configuration["Level"]["Name"].StringValue;
			string stringValue2 = configuration["Level"]["ID"].StringValue;
			if (!string.IsNullOrEmpty(stringValue2))
			{
				if (stringValue2 != _config.UniqueId)
				{
					return ConsoleCommandResult.Failed($"Wrong room layout level ID. Wanted {stringValue2} but have {_config.UniqueId} loaded");
				}
			}
			else if (!string.IsNullOrEmpty(stringValue) && stringValue != _config.GetDisplayName())
			{
				return ConsoleCommandResult.Failed($"Wrong room layout level. Wanted {stringValue} but have {_config.GetDisplayName()} loaded");
			}
			foreach (Character allCharacter in CharacterManager.AllCharacters)
			{
				CharacterEvents.OnDestroyCharacter.InvokeSafe(allCharacter);
			}
			_worldState.DestroyAllRooms();
			int intValue = configuration["Version"]["Number"].IntValue;
			SharedInstance_TH20TH20_RoomDefinition[] sharedInstances = SharedInstanceUtils.GetSharedInstances<SharedInstance_TH20TH20_RoomDefinition>();
			SharedInstance_TH20TH20_RoomItemDefinition[] sharedInstances2 = SharedInstanceUtils.GetSharedInstances<SharedInstance_TH20TH20_RoomItemDefinition>();
			List<RoomItemDefinitionUGC> allUGCRoomItems = GetAllUGCRoomItems();
			foreach (Setting item in configuration["Rooms"])
			{
				RoomLayout instance = null;
				string input = ((intValue > 4) ? item.StringValue.Replace("\\{", "{").Replace("\\}", "}") : HexadecimalEncoding.FromHexString(item.StringValue));
				fsData data = fsJsonParser.Parse(input);
				fsSerializer2.TryDeserialize(data, ref instance).AssertSuccessWithoutWarnings();
				if (instance.HospitalPlot < _worldState.HospitalPlots.Count)
				{
					HospitalPlot hospitalPlot = _worldState.HospitalPlots[instance.HospitalPlot];
					if (instance.PlotBought)
					{
						_financeManager.OnMoneyAwarded(hospitalPlot.Definition.Cost);
						hospitalPlot.BuyAndBuildImmediately();
					}
					HospitalMap hospitalMap = hospitalPlot.HospitalMap;
					if (hospitalMap == null)
					{
						continue;
					}
					if (instance.IsHospital)
					{
						BuildRoomItems(instance.Items, hospitalMap.FloorPlan, sharedInstances2, allUGCRoomItems);
						continue;
					}
					RoomDefinition roomDefinition = ((intValue <= 3) ? GetRoomDefinitionFromName(instance.DefinitionName, sharedInstances) : GetRoomDefinitionFromID(instance.DefinitionID, sharedInstances));
					if (roomDefinition != null)
					{
						if (!roomDefinition.IsHospitalUnbuilt)
						{
							_metagame.UnlockItem(roomDefinition, spendSilver: false, showMessage: false);
						}
						BuildRoom(roomDefinition, hospitalMap, instance.Anchor, instance.Tiles, instance.Items, sharedInstances2, allUGCRoomItems);
					}
					else
					{
						Logging.Warning("Room layout contains room that doesn't have a definition. Ignoring. Room name: {0}", instance.DefinitionName);
					}
				}
				else
				{
					Logging.Warning("Room layout contains room with plot ID {0} but there are only {1} plots available. Ignoring.", instance.HospitalPlot, _worldState.HospitalPlots.Count);
				}
			}
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item2 in allRoom.FloorPlan.Items)
				{
					RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, item2, _worldState, null, null);
					if (allRoom.Definition.IsHospitalOrBay)
					{
						_worldState.AddNeedSatisfyingRoomItem(item2);
					}
				}
				IRoomItemDefinition missing;
				if (allRoom.Definition.IsHospitalOrBay)
				{
					allRoom.FloorPlanVisual.CreateRoomItems();
					allRoom.FloorPlan.AddItemsToWorld();
				}
				else if (allRoom.GetMissingRequiredItem(out missing))
				{
					allRoom.Debug_SetMissingRequiredItems(missing: true);
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private List<RoomItemDefinitionUGC> GetAllUGCRoomItems()
		{
			List<RoomItemDefinitionUGC> list = new List<RoomItemDefinitionUGC>();
			foreach (IRoomItemDefinition availableRoomItem in WorldState.AvailableRoomItems)
			{
				if (availableRoomItem is RoomItemDefinitionUGC)
				{
					list.Add((RoomItemDefinitionUGC)availableRoomItem);
				}
			}
			return list;
		}

		private ConsoleCommandResult Debug_SaveRoomLayout(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("Invalid number of arguments");
			}
			int num = 0;
			Configuration configuration = new Configuration();
			configuration["Version"]["Number"].IntValue = 5;
			configuration["Level"]["Name"].StringValue = _config.GetDisplayName();
			configuration["Level"]["ID"].StringValue = _config.UniqueId;
			Section section = configuration["Rooms"];
			string filename = Path.Combine(Directories.GameOutputDirectory, args[0]);
			fsSerializer fsSerializer2 = new fsSerializer();
			foreach (Room allRoom in _worldState.AllRooms)
			{
				RoomLayout roomLayout = null;
				HospitalPlot plot = allRoom.FloorPlan.HospitalMap.Plot;
				int hospitalPlotIndex = _worldState.GetHospitalPlotIndex(plot);
				if (allRoom.Definition.IsHospitalOrBay)
				{
					roomLayout = new RoomLayout
					{
						IsHospital = true,
						PlotBought = plot.Bought,
						HospitalPlot = hospitalPlotIndex,
						Anchor = allRoom.FloorPlan.Anchor
					};
					foreach (RoomItem item in allRoom.FloorPlan.Items)
					{
						RoomItemDefinition.Type itemType = item.Definition.ItemType;
						if (!item.Definition.SaveInRoomLayout || itemType == RoomItemDefinition.Type.Door || itemType == RoomItemDefinition.Type.SideDoor || itemType == RoomItemDefinition.Type.Window || itemType == RoomItemDefinition.Type.Landscape)
						{
							continue;
						}
						if (item.Definition is RoomItemDefinition)
						{
							if (App.AssetIDs.Reverse.TryGetValue(item.Definition, out var value))
							{
								int iD = value + 1;
								roomLayout.Items.Add(new RoomItemLayout
								{
									ID = iD,
									LocalPosition = item.LocalPosition,
									Rotation = item.Rotation
								});
							}
							else
							{
								Logging.Error("Failed to find ID for room item; will not save in room layout: {0}", item.Definition);
							}
						}
						else if (item.Definition is RoomItemDefinitionUGC)
						{
							RoomItemDefinitionUGC roomItemDefinitionUGC = (RoomItemDefinitionUGC)item.Definition;
							roomLayout.Items.Add(new RoomItemLayout
							{
								ID = 0,
								ContentID = roomItemDefinitionUGC.ContentID,
								LocalPosition = item.LocalPosition,
								Rotation = item.Rotation
							});
						}
					}
				}
				else
				{
					if (allRoom.Definition.IsHospitalUnbuilt)
					{
						continue;
					}
					if (App.AssetIDs.Reverse.TryGetValue(allRoom.Definition, out var value2))
					{
						int definitionID = value2 + 1;
						roomLayout = new RoomLayout
						{
							IsHospital = false,
							HospitalPlot = hospitalPlotIndex,
							DefinitionName = allRoom.Definition.GetSanitizedName(),
							DefinitionID = definitionID,
							Anchor = allRoom.FloorPlan.Anchor,
							Tiles = allRoom.FloorPlan.Tiles
						};
						foreach (RoomItem item2 in allRoom.FloorPlan.Items)
						{
							if (item2.IsHospitalWindow)
							{
								continue;
							}
							if (item2.Definition is RoomItemDefinition)
							{
								if (App.AssetIDs.Reverse.TryGetValue(item2.Definition, out var value3))
								{
									int iD2 = value3 + 1;
									roomLayout.Items.Add(new RoomItemLayout
									{
										ID = iD2,
										LocalPosition = item2.LocalPosition,
										Rotation = item2.Rotation
									});
								}
								else
								{
									Logging.Error("Failed to find ID for room item; will not save in room layout: {0}", item2.Definition);
								}
							}
							else if (item2.Definition is RoomItemDefinitionUGC)
							{
								RoomItemDefinitionUGC roomItemDefinitionUGC2 = (RoomItemDefinitionUGC)item2.Definition;
								roomLayout.Items.Add(new RoomItemLayout
								{
									ID = 0,
									ContentID = roomItemDefinitionUGC2.ContentID,
									LocalPosition = item2.LocalPosition,
									Rotation = item2.Rotation
								});
							}
						}
					}
					else
					{
						Logging.Error("Failed to find ID for room; will not save in room layout: {0}", allRoom.Definition);
					}
				}
				if (roomLayout != null)
				{
					fiSerializationManager.DisableAutomaticSerialization = true;
					fiSerializationManager.IsInSaveOrLoad = true;
					fsSerializer2.TrySerialize(roomLayout, out var data).AssertSuccessWithoutWarnings();
					fiSerializationManager.DisableAutomaticSerialization = false;
					fiSerializationManager.IsInSaveOrLoad = false;
					string stringValue = fsJsonPrinter.CompressedJson(data).Replace("{", "\\{").Replace("}", "\\}");
					section[$"Room{num++}"].StringValue = stringValue;
				}
			}
			configuration.SaveToFile(filename);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_DestroyAllRooms(string[] args)
		{
			Room[] array = _worldState.AllRooms.ToArray();
			foreach (Room room in array)
			{
				if (room.Definition.IsHospitalOrBay)
				{
					RoomItem[] array2 = room.FloorPlan.Items.ToArray();
					foreach (RoomItem roomItem in array2)
					{
						RoomItemDefinition.Type itemType = roomItem.Definition.ItemType;
						if (itemType != RoomItemDefinition.Type.Landscape && itemType != RoomItemDefinition.Type.Door && itemType != RoomItemDefinition.Type.SideDoor)
						{
							BuildEvents.OnRoomItemDestroy.InvokeSafe(roomItem);
						}
					}
				}
				else
				{
					_worldState.RemoveRoom(room, affectNavigation: false);
					BuildEvents.OnRoomDeleted.InvokeSafe(room);
					room.FloorPlan.RemoveItemsFromWorld();
					room.Destroy();
				}
			}
			_worldState.UpdateNavigation();
			return ConsoleCommandResult.Succeeded();
		}

		private static RoomDefinition GetRoomDefinitionFromName(string roomName, SharedInstance_TH20TH20_RoomDefinition[] roomSharedInstances)
		{
			foreach (SharedInstance_TH20TH20_RoomDefinition sharedInstance_TH20TH20_RoomDefinition in roomSharedInstances)
			{
				if (sharedInstance_TH20TH20_RoomDefinition.Instance.GetSanitizedName() == roomName)
				{
					return sharedInstance_TH20TH20_RoomDefinition.Instance;
				}
			}
			return null;
		}

		private static RoomDefinition GetRoomDefinitionFromID(int roomDefinitionID, SharedInstance_TH20TH20_RoomDefinition[] roomSharedInstances)
		{
			foreach (SharedInstance_TH20TH20_RoomDefinition sharedInstance_TH20TH20_RoomDefinition in roomSharedInstances)
			{
				if (sharedInstance_TH20TH20_RoomDefinition.ID == roomDefinitionID)
				{
					return sharedInstance_TH20TH20_RoomDefinition.Instance;
				}
			}
			return null;
		}

		private static IRoomItemDefinition GetRoomItemDefinitionFromRoomItemLayout(RoomItemLayout roomItemLayout, SharedInstance_TH20TH20_RoomItemDefinition[] roomItemSharedInstances, List<RoomItemDefinitionUGC> ugcRoomItems)
		{
			if (roomItemLayout.ID != 0)
			{
				foreach (SharedInstance_TH20TH20_RoomItemDefinition sharedInstance_TH20TH20_RoomItemDefinition in roomItemSharedInstances)
				{
					if (sharedInstance_TH20TH20_RoomItemDefinition.ID == roomItemLayout.ID)
					{
						return sharedInstance_TH20TH20_RoomItemDefinition.Instance;
					}
				}
			}
			else
			{
				foreach (RoomItemDefinitionUGC ugcRoomItem in ugcRoomItems)
				{
					if (ugcRoomItem.ContentID == roomItemLayout.ContentID)
					{
						return ugcRoomItem;
					}
				}
			}
			return null;
		}

		private void BuildRoom(RoomDefinition roomDefinition, HospitalMap hospitalMap, GridCoord worldCoord, bool[,] tiles, List<RoomItemLayout> items, SharedInstance_TH20TH20_RoomItemDefinition[] roomItemSharedInstances, List<RoomItemDefinitionUGC> ugcRoomItems)
		{
			Room room = new Room(roomDefinition, this);
			FloorPlan floorPlan = new FloorPlan(roomDefinition, this, hospitalMap)
			{
				Anchor = worldCoord,
				Tiles = tiles
			};
			RoomFloorPlanVisual roomFloorPlanVisual = new RoomFloorPlanVisual(WorldState, _visualManager, roomDefinition.ToString(), roomDefinition.GetFloorTile(WorldState), _dataViewManager.ValueMaterial, _config.GetBuildingLogicConfig().RoomItemEditConfig, roomDefinition._wallsInterior, BuildEvents);
			room.Initialise(floorPlan, roomFloorPlanVisual);
			if (items != null)
			{
				BuildRoomItems(items, floorPlan, roomItemSharedInstances, ugcRoomItems);
			}
			floorPlan.RecalculateWalls();
			foreach (RoomItem item in floorPlan.Items)
			{
				RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, item, _worldState, null, null);
			}
			roomFloorPlanVisual.UpdateFromRoom(floorPlan);
			roomFloorPlanVisual.TriggerConstructionAnimations(floorPlan.Anchor);
			room.FloorPlan.AddItemsToWorld();
			_worldState.AddRoom(room, animateWalls: true);
			BuildEvents.OnNewRoomBuiltEvent.InvokeSafe(room);
			_financeManager.OnMoneyAwarded(roomDefinition._cost);
			_worldState.BuildRoom(room, GameAlgorithms.CalculatePurchaseCostOfRoom(room.FloorPlan, isNewRoom: true));
			room.Open();
		}

		private void BuildRoomItems(List<RoomItemLayout> items, FloorPlan floorPlan, SharedInstance_TH20TH20_RoomItemDefinition[] roomItemSharedInstances, List<RoomItemDefinitionUGC> ugcRoomItems)
		{
			foreach (RoomItemLayout item2 in items)
			{
				IRoomItemDefinition roomItemDefinitionFromRoomItemLayout = GetRoomItemDefinitionFromRoomItemLayout(item2, roomItemSharedInstances, ugcRoomItems);
				if (roomItemDefinitionFromRoomItemLayout != null && roomItemDefinitionFromRoomItemLayout.SaveInRoomLayout)
				{
					_metagame.UnlockItem(roomItemDefinitionFromRoomItemLayout, spendSilver: false, showMessage: false);
					_financeManager.OnMoneyAwarded.InvokeSafe(roomItemDefinitionFromRoomItemLayout.GetCost());
					RoomItem item = new RoomItem(roomItemDefinitionFromRoomItemLayout, floorPlan, this)
					{
						LocalPosition = item2.LocalPosition,
						Rotation = item2.Rotation
					};
					floorPlan.AddItem(item);
				}
				else
				{
					Logging.Warning("Room layout contains item which either doesn't have a definition or is no longer meant to be in room layouts. Ignoring. Item ID: {0}", item2.ID);
				}
			}
		}

		private ConsoleCommandResult Debug_SpawnRequiredStaff(string[] args)
		{
			foreach (Room allRoom in _worldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay)
				{
					List<StaffRequired> list = new List<StaffRequired>();
					allRoom.RemainingStaffRequired(list);
					foreach (StaffRequired item in list)
					{
						WeightedList<QualificationDefinition> weightedList = new WeightedList<QualificationDefinition>();
						if (item.QualificationInstance != null)
						{
							weightedList.Add(item.QualificationInstance, 100);
						}
						JobApplicant jobApplicant = new JobApplicant(item.Definition, CharacterNameGenerator, 0f, 50, RandomUtils.GlobalRandomInstance.Next(0, 5), weightedList, _characterTraitsManager, _metagame, this);
						SpawnStaffMember(jobApplicant, allRoom);
					}
				}
				else if (allRoom.Definition.IsAmbulanceBayOnly)
				{
					foreach (Job allJob in _staffWorkScheduler.AllJobs)
					{
						if (allJob is JobAmbulance)
						{
							StaffRequired staffRequired = allJob.StaffRequired();
							WeightedList<QualificationDefinition> weightedList2 = new WeightedList<QualificationDefinition>();
							weightedList2.Add(staffRequired.QualificationInstance, 100);
							JobApplicant jobApplicant2 = new JobApplicant(staffRequired.Definition, CharacterNameGenerator, 0f, 50, RandomUtils.GlobalRandomInstance.Next(0, 5), weightedList2, _characterTraitsManager, _metagame, this);
							SpawnStaffMember(jobApplicant2, allRoom);
						}
					}
				}
				else
				{
					JobApplicantPool jobApplicantPool = _jobApplicantManager.GetJobApplicantPool(StaffDefinition.Type.Janitor);
					while (jobApplicantPool.Applicants.Count != 0)
					{
						JobApplicant jobApplicant3 = jobApplicantPool.Applicants.RandomItem();
						SpawnStaffMember(jobApplicant3, allRoom);
						jobApplicantPool.RemoveApplicant(jobApplicant3);
					}
				}
			}
			foreach (Job allJob2 in _staffWorkScheduler.AllJobs)
			{
				if (allJob2.Available())
				{
					JobApplicantPool jobApplicantPool2 = _jobApplicantManager.GetJobApplicantPool(allJob2.StaffType());
					if (jobApplicantPool2.Applicants.Count != 0)
					{
						JobApplicant jobApplicant4 = jobApplicantPool2.Applicants.RandomItem();
						SpawnStaffMember(jobApplicant4, _worldState.AllRooms[0]);
						jobApplicantPool2.RemoveApplicant(jobApplicant4);
					}
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult LogStaffRecord(string[] args)
		{
			if (_cursorCharacter is Staff staff)
			{
				Logging.Info(LogChannels.Debug, staff.StaffRecord.ToString());
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ReloadRoomLights(string[] args)
		{
			foreach (Room allRoom in WorldState.AllRooms)
			{
				allRoom.ReloadRoomLights();
			}
			VisualManager.RoomLightingManager.RegenerateInteriorVolumeLights();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PlaySoundEventEndlessly(string[] args)
		{
			EmptyMonoBehaviour emptyMonoBehaviour = new GameObject("Play Sound Event Endlessly").AddComponent<EmptyMonoBehaviour>();
			if (AudioManager.Instance.DoesSoundEventExist(args[0]))
			{
				emptyMonoBehaviour.StartCoroutine(PlaySoundEventEndlesslyCoroutine(args[0]));
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed();
		}

		private IEnumerator PlaySoundEventEndlesslyCoroutine(string audioEvent)
		{
			while (true)
			{
				AudioEmitter emitter = AudioManager.Instance.Play(audioEvent);
				yield return new WaitUntil(() => emitter.Finished);
			}
		}

		private ConsoleCommandResult Debug_AutoReloadLighting(string[] args)
		{
			new GameObject("Auto Reload Room Lights").AddComponent<EmptyMonoBehaviour>().StartCoroutine(AutoReloadRoomLighting());
			return ConsoleCommandResult.Succeeded();
		}

		private IEnumerator AutoReloadRoomLighting()
		{
			while (true)
			{
				VisualManager.RoomLightingManager.ReloadConfig();
				foreach (Room allRoom in WorldState.AllRooms)
				{
					allRoom.ReloadRoomLights();
				}
				VisualManager.RoomLightingManager.RegenerateExteriorVolumeLights(WorldState.ExteriorState.Values, WorldState.Anchor.ToWorldPosition());
				VisualManager.RoomLightingManager.RegenerateInteriorVolumeLights();
				CameraLogic.ReloadLevelLightingConfig(Config.GetLevelLightingConfig());
				yield return null;
			}
		}

		private void SpawnStaffMember(JobApplicant jobApplicant, Room room)
		{
			Vector3 randomSpawnPositionForCharacter = RoomAlgorithms.GetRandomSpawnPositionForCharacter(room.FloorPlan);
			Staff staff = _characterManager.SpawnStaff(jobApplicant, randomSpawnPositionForCharacter, navDisabled: false);
			CharacterEvents.OnStaffDrop.InvokeSafe(staff, room, param3: true);
			CharacterEvents.OnStaffHired.InvokeSafe(staff, jobApplicant, jobApplicant.RecruitmentFee);
		}

		private ConsoleCommandResult Debug_SetWorkLifeBalance(string[] args)
		{
			if (args.Length != 3)
			{
				return ConsoleCommandResult.Failed("Incorrect number of arguments");
			}
			if (int.TryParse(args[0], out var result) && int.TryParse(args[1], out var result2) && float.TryParse(args[2], out var result3))
			{
				_workLifeBalanceManager.SetWorkLifeBalance((StaffDefinition.Type)result, result2, result3);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Failed to parse arguments");
		}

		private void DebugGUI()
		{
			GridCoord gridPosition = _cursorManager.GridPosition;
			string[] guiText = new string[1] { (_cursorSelectable != null) ? _cursorSelectable.ToString() : "" };
			guiText[0] += $"\n{gridPosition.X}, {gridPosition.Y} ({_cursorManager.WorldPosition.x}, {_cursorManager.WorldPosition.z})";
			guiText[0] += $"\n {HospitalAttributeMap.Attribute.Temperature} = {_worldState.HospitalAttributeMaps[0].GetMapAttribute(_cursorManager.WorldPosition)}";
			guiText[0] += $"\n {HospitalAttributeMap.Attribute.Attractiveness} = {_worldState.HospitalAttributeMaps[1].GetMapAttribute(_cursorManager.WorldPosition)}";
			guiText[0] += $"\n {HospitalAttributeMap.Attribute.Hygiene} = {_worldState.HospitalAttributeMaps[2].GetMapAttribute(_cursorManager.WorldPosition)}";
			int areaIDAtPosition = _worldState.NavMesh.GetAreaIDAtPosition(_cursorManager.WorldPosition, AllowDistanceOffNavMesh.Allow);
			guiText[0] += $"\n NavID = {areaIDAtPosition}";
			RoomAlgorithms.IterateRoomItemsAtCoord(_worldState, gridPosition, delegate(RoomItem item)
			{
				guiText[0] += $"\n {item}";
			});
			HospitalMap hospitalMapAtWorldPosition = _worldState.GetHospitalMapAtWorldPosition(_cursorManager.WorldPosition);
			if (hospitalMapAtWorldPosition != null)
			{
				guiText[0] += $"\n{gridPosition.X - hospitalMapAtWorldPosition.Anchor.X}, {gridPosition.Y - hospitalMapAtWorldPosition.Anchor.Y}";
				hospitalMapAtWorldPosition.CacheArrivalDeparturePositions();
				bool flag = RoomAlgorithms.PositionConnectsToEntrance(_cursorManager.WorldPosition, hospitalMapAtWorldPosition);
				guiText[0] += $"\n Connected = {flag}";
				DebugDrawUtils.Bounds(hospitalMapAtWorldPosition.FloorPlan.WorldBounds, Color.blue, 0.1f);
			}
			hospitalMapAtWorldPosition = ((hospitalMapAtWorldPosition != null) ? hospitalMapAtWorldPosition : _worldState.HospitalMaps[0]);
			if (hospitalMapAtWorldPosition != null)
			{
				GridCoord gridCoord = gridPosition - hospitalMapAtWorldPosition.Anchor;
				if (hospitalMapAtWorldPosition.IndoorState.ValidIndex(gridCoord.X, gridCoord.Y))
				{
					guiText[0] += $"\n Indoor State = {hospitalMapAtWorldPosition.IndoorState[gridCoord.X, gridCoord.Y]}";
				}
			}
			Vector2 screenPosition = _cursorManager.ScreenPosition;
			GUI.Label(new Rect(screenPosition.x, (float)Screen.height - screenPosition.y, 300f, 300f), guiText[0]);
		}

		private ConsoleCommandResult Debug_SaveScenario(string[] args)
		{
			if (Config.HospitalScenario.NotNull())
			{
				Config.HospitalScenario.Instance.SaveSnapshot(this);
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Level Config is missing a reference to a Hospital Scenario Config file");
		}

		private ConsoleCommandResult Debug_ToggleStaffCustomisationMenu(string[] args)
		{
			_hospitalHUDManager.ToggleInfoMenu<StaffCustomisationMenu>(delegate
			{
			});
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ShowHospitalEventLog(string[] args)
		{
			if (_hud.FindMenu<HospitalEventLogMenu>() == null)
			{
				_hud.CreateMenu<HospitalEventLogMenu>().Setup(this);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PushCursorVaccinate(string[] args)
		{
			if (!CursorManager.IsModeActive<CursorVaccinate>())
			{
				CursorManager.PushMode(new CursorVaccinate(CursorManager, this));
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ToggleLevelCamera(string[] args)
		{
			CameraLogic.CameraComponent.gameObject.SetActive(!CameraLogic.CameraComponent.gameObject.activeSelf);
			return ConsoleCommandResult.Succeeded(string.Format("Level Camera = {0}", CameraLogic.CameraComponent.gameObject.activeSelf ? "On" : "Off"));
		}

		private ConsoleCommandResult Debug_ToggleDebugLevelCamera(string[] args)
		{
			CameraLogic.IsDebugCameraEnabled = !CameraLogic.IsDebugCameraEnabled;
			return ConsoleCommandResult.Succeeded(string.Format("Debug Camera = {0}", CameraLogic.IsDebugCameraEnabled ? "On" : "Off"));
		}

		private ConsoleCommandResult Debug_LoadDevConfig(string[] args)
		{
			_app.LoadDevConfig();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnableLargeRT(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Incorrect arguments.  Requires 1 for rt scale. EnableLargeRT 1.7 for example");
			}
			float num = float.Parse(args[0]);
			RenderTexture targetTexture = CameraLogic.CameraComponent.targetTexture;
			if (targetTexture != null)
			{
				CameraLogic.CameraComponent.targetTexture = null;
				targetTexture.Release();
			}
			RenderTexture renderTexture = new RenderTexture((int)((float)Screen.currentResolution.width * num), (int)((float)Screen.currentResolution.height * num), 24, RenderTextureFormat.RGB565);
			renderTexture.Create();
			CameraLogic.CameraComponent.targetTexture = renderTexture;
			_levelCommonScript.DebugLargeRenderTargetGameObject.SetActive(value: true);
			_levelCommonScript.DebugLargeRenderTextureImage.texture = renderTexture;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_DisableLargeRT(string[] args)
		{
			RenderTexture targetTexture = CameraLogic.CameraComponent.targetTexture;
			CameraLogic.CameraComponent.targetTexture = null;
			_levelCommonScript.DebugLargeRenderTargetGameObject.SetActive(value: false);
			_levelCommonScript.DebugLargeRenderTextureImage.texture = null;
			if (targetTexture != null)
			{
				targetTexture.Release();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_DisableAA(string[] args)
		{
			CameraLogic.PostProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnableSMAA(string[] args)
		{
			CameraLogic.PostProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnableFXAA(string[] args)
		{
			CameraLogic.PostProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnableTAA(string[] args)
		{
			CameraLogic.PostProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ToggleShadowCulling(string[] args)
		{
			RoomLightingManager.DEBUG_DisableShadowCulling = !RoomLightingManager.DEBUG_DisableShadowCulling;
			return ConsoleCommandResult.Succeeded($"DisableShadowCulling = {RoomLightingManager.DEBUG_DisableShadowCulling}");
		}

		private ConsoleCommandResult Debug_SetTextureOverrideOnAllItems(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("Filepath to png or jpg expected");
			}
			byte[] data = File.ReadAllBytes(args[0].Replace("\"", ""));
			Texture2D texture2D = new Texture2D(512, 512);
			texture2D.LoadImage(data, markNonReadable: false);
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					item.Visual.OverrideTextureDiffuse = texture2D;
				}
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_DumpStaffJobScores(string[] args)
		{
			Staff cursorStaff = _cursorCharacter as Staff;
			if (cursorStaff == null)
			{
				return ConsoleCommandResult.Failed("No staff member selected");
			}
			List<Job> list = new List<Job>(_staffWorkScheduler.AllJobs);
			list.RemoveAll((Job job) => !job.IsSuitable(cursorStaff, checkExclusion: true, out var _));
			list.Sort((Job job1, Job job2) => job2.GetJobScore(cursorStaff).CompareTo(job1.GetJobScore(cursorStaff)));
			Logging.Info(LogChannels.StaffWork, "=== Job scores for {0} ===", cursorStaff);
			foreach (Job item in list)
			{
				Logging.Info(LogChannels.StaffWork, "{0}: {1}", item.DebugDescription(), item.GetJobScore(cursorStaff));
			}
			Logging.Info(LogChannels.StaffWork, "========================");
			return ConsoleCommandResult.Succeeded();
		}
	}
}
