#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using ATM;
using Backtrace.Unity;
using BehaviorDesigner.Runtime;
using FullInspector;
using FullInspector.Generated.SharedInstance;
using I2.Loc;
using Rewired;
using SharpConfig;
using Steamworks;
using TH20.Analytics;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityConsole;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TH20
{
	public class App : MustCallDestroy
	{
		private enum DebugLocTextMode
		{
			AllTextItems = 0,
			AllTranslatedItems = 1,
			ItemsMissingLocaliseComponent = 2,
			ItemsLocaliseTermNone = 3,
			ItemsNonNoneMissingTranslation = 4,
			ItemsMissingTranslation = 5
		}

		private readonly AppConfig _config;

		private readonly SharedInstance<AppConfig> _configInstance;

		private Configuration _developerConfig;

		private readonly MonoBehaviour _behaviourToRunCoroutinesOn;

		private readonly UnhandledErrorReporter _unhandledErrorReporter;

		private readonly ScreenFade _screenFade;

		private readonly LoadSaveProgressScreen _loadSaveProgressScreen;

		private readonly FullScreenVideoMenu _fullScreenVideoMenu;

		private readonly MessageBox _messageBox;

		private readonly BackupSaveBox _backupSaveBox;

		private OpeningScreen _openingScreen;

		private readonly GameObject _saveOverlay;

		private readonly PreferencesScreen _preferencesScreen;

		private BacktraceClient _backtraceClient;

		private readonly InputManager _inputManager;

		private readonly ExtContentManager _extContentManager;

		private readonly DynamicPlaylistManager _dynamicPlaylistManager;

		private readonly AppAudioMixerManager _appAudioMixerManager;

		private readonly AnalyticsManager _analyticsManager;

		private readonly OnlineAnalyticsManager _onlineAnalyticsManager;

		private readonly DebugFlyCamera _debugFlyCamera;

		private readonly ConsoleKeyBindingManager _consoleKeyBindingManager;

		private readonly SaveSystem _saveSystem;

		private readonly SandboxSaveManager _sandboxSaveManager;

		private readonly BiDictionary<int, object> _assetIDs;

		private readonly AudioManager _audioManager;

		private Preferences _userPreferences;

		private LocalPreferences _localPreferences;

		private UserProfile _userProfile;

		private readonly CollaborativePortfolio _collaborativePortfolio;

		private readonly SuperBugProjectManager _superBugManager;

		private PrefabPoolManager _prefabPoolManager;

		private readonly RoomTemplatesManager _roomTemplatesManager;

		private readonly CloudDataManager _cloudDataManager;

		private readonly PrimeGaming _primeGaming;

		private Level _loadedLevel;

		private string _loadedLevelSceneName;

		private GameMode _gameMode;

		private MetagameMapScene _metagameMapScene;

		private LevelCommonScript _levelCommonScript;

		private readonly SoundTest _soundTest;

		private PerformanceCapture _performance;

		private MemoryUsageCapture _memoryUsageCapture;

		private UGCRuntimePrefabManager _ugcRuntimePrefabManager;

		private UGCRoomItemDefinitionDatabase _ugcRoomItemDefinitionDatabase;

		private UGCWallVisualOverrideDefinitionDatabase _ugcWallVisualOverrideDefinitionDatabase;

		private UGCFloorVisualOverrideDefinitionDatabase _ugcFloorVisualOverrideDefinitionDatabase;

		private readonly ATMManager _atmManager;

		private readonly ControlBindingsLocalisationParamsManager _controlBindingsLocalisationParamsManager;

		private DLCManager _dlcManager;

		private readonly StateMachine _stateMachine;

		private bool _promptQuitGamePending;

		private DateTime _lastUnloadUnusedAssets;

		public static Action OnConnectionEstablished;

		public Action OnAppReadyToShow;

		public Action<Level, bool> OnLevelLoaded;

		public Action OnLevelLoadStarting;

		public Action<Level> OnLevelAboutToBeUnloaded;

		private bool _showMissingTranslations;

		private bool _showMissingTranslationsTextBorders = true;

		private DebugLocTextMode _showMissingTranslationsMode = DebugLocTextMode.ItemsMissingLocaliseComponent;

		private Coroutine _saveSpamCoroutine;

		public bool IsLoading { get; private set; }

		public bool IsRestoringFromSave { get; set; }

		public AppConfig Config => _config;

		public Level Level => _loadedLevel;

		public SaveSystem SaveSystem => _saveSystem;

		public CollaborativePortfolio CollaborativePortfolio => _collaborativePortfolio;

		public CollaborativeProjectList CollaborativeProjectList => _config.CollaborativeProjectList.Instance;

		public SuperBugProjectManager SuperBugManager => _superBugManager;

		public CloudDataManager CloudDataManager => _cloudDataManager;

		public SuperBugConfig SuperBugConfig => _config.SuperBugConfig.Instance;

		public Preferences UserPreferences => _userPreferences;

		public LocalPreferences LocalPreferences => _localPreferences;

		public UserProfile UserProfile => _userProfile;

		public ExtContentManager ExtContentManager => _extContentManager;

		public DynamicPlaylistManager DynamicPlaylistManager => _dynamicPlaylistManager;

		public MessageBox MessageBox => _messageBox;

		public BackupSaveBox BackupSave => _backupSaveBox;

		public OpeningScreen OpeningScreen => _openingScreen;

		public PreferencesScreen PreferencesScreen => _preferencesScreen;

		public FullScreenVideoMenu FullScreenVideoMenu => _fullScreenVideoMenu;

		public AnalyticsManager AnalyticsManager => _analyticsManager;

		public MetagameMapScene MetagameMapScene => _metagameMapScene;

		public MetagameMap MetagameMap
		{
			get
			{
				if (_gameMode == null)
				{
					return null;
				}
				return _gameMode.MetagameMap;
			}
		}

		public Metagame Metagame
		{
			get
			{
				if (_gameMode == null)
				{
					return null;
				}
				return _gameMode.Metagame;
			}
		}

		public BiDictionary<int, object> AssetIDs => _assetIDs;

		public LoadSaveProgressScreen LoadSaveProgressScreen => _loadSaveProgressScreen;

		public SharedInstance<AppConfig> ConfigInstance => _configInstance;

		public GameMode GameMode => _gameMode;

		public InputManager InputManager => _inputManager;

		public LevelCommonScript LevelCommonScript => _levelCommonScript;

		public DLCManager DLCManager => _dlcManager;

		public PrimeGaming PrimeGaming => _primeGaming;

		public SandboxSaveManager SandboxSaveManager => _sandboxSaveManager;

		public SandboxSettingsConfig SandboxSettingsConfig => _config.SandboxSettingsConfig.Instance;

		public GameObject SaveOverlay => _saveOverlay;

		public PlatformFeatureSupport PlatformFeatureSupport => _config.PlatformFeatureSupportConfig;

		public RoomTemplatesManager RoomTemplatesManager => _roomTemplatesManager;

		public UGCRuntimePrefabManager UGCRuntimePrefabManager => _ugcRuntimePrefabManager;

		public UGCRoomItemDefinitionDatabase UGCRoomItemDefinitionDatabase => _ugcRoomItemDefinitionDatabase;

		public UGCWallVisualOverrideDefinitionDatabase UGCWallVisualOverrideDefinitionDatabase => _ugcWallVisualOverrideDefinitionDatabase;

		public UGCFloorVisualOverrideDefinitionDatabase UGCFloorVisualOverrideDefinitionDatabase => _ugcFloorVisualOverrideDefinitionDatabase;

		public static bool IsQuitting { get; private set; }

		public App(GraphicRaycaster graphicRaycaster, EventSystem eventSystem, MonoBehaviour behaviourToRunCoroutinesOn, UnhandledErrorDialogue unhandledErrorDialogue, ConsoleUI consoleUI, ScreenFade screenFade, LoadSaveProgressScreen loadSaveProgressScreen, FullScreenVideoMenu fullScreenVideoMenu, MessageBox messageBox, BackupSaveBox backupSaveBox, SoundTest soundTest, BacktraceClient backtraceClient, SharedInstance<AppConfig> config)
		{
			_config = config.Instance;
			_configInstance = config;
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			_screenFade = screenFade;
			_loadSaveProgressScreen = loadSaveProgressScreen;
			_fullScreenVideoMenu = fullScreenVideoMenu;
			_messageBox = messageBox;
			_soundTest = soundTest;
			_backtraceClient = backtraceClient;
			_backupSaveBox = backupSaveBox;
			_backupSaveBox.Initialise(this);
			_lastUnloadUnusedAssets = DateTime.UtcNow;
			ThreadingUtils.Initialise();
			PlatformFileManager.AssignApp(this);
			OSManager.AssignApp(this);
			OSManager.OnUserChanged = (Action)Delegate.Combine(OSManager.OnUserChanged, new Action(UpdateAnalyticsManagerUser));
			Logging.Logger.AddLogHandler(new FileLogHandler(_config.LoggingConfig.Instance));
			Debug.CurrentAssertMode = Debug.AssertMode.LogError;
			Logging.AlwaysLog("Version {0} (Build: {1})", GameVersionNumber.Version.FullVersionString, OSManager.BuildVersion());
			if (TMP_Settings.instance == null)
			{
				bool flag = File.Exists(Application.dataPath + Path.DirectorySeparatorChar + "resources.assets");
				bool flag2 = File.Exists(Application.dataPath + Path.DirectorySeparatorChar + "resources.assets.resS");
				bool flag3 = File.Exists(Application.dataPath + Path.DirectorySeparatorChar + "resources.resource");
				Logging.Error("TMP_Settings.instance is null. has \"resources.assets\" = {0} has \"resources.assets.resS\" = {1} has \"resources.resource\" = {2} ", flag, flag2, flag3);
			}
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
			Shader.SetGlobalTexture("_TH20Noise", config.Instance.NoiseTexture);
			_atmManager = new ATMManager(this, _loadSaveProgressScreen);
			_assetIDs = AssetIDMapping.GenerateExternalReferencesList(config);
			OnlineManager.Initialise(_config.OnlineManagerConfig.Instance, _behaviourToRunCoroutinesOn, _assetIDs, this);
			PlatformStatsAndAchievements.Initialise(_config.StatsAsAchievementsData.Instance);
			bool flag4 = false;
			if (OnlineManager.IsInitialized())
			{
				int appBuildId = SteamApps.GetAppBuildId();
				Logging.AlwaysLog("Steam build ID: {0}", appBuildId);
				if (SteamApps.GetCurrentBetaName(out var pchName, 128))
				{
					Logging.AlwaysLog("Steam branch: {0}", pchName);
					if (pchName == "closed_beta_testing" || pchName == "twopointhospital_press_build" || (pchName.StartsWith("twopointhospital_") && pchName.EndsWith("_beta")) || (pchName.StartsWith("twopointhospital_") && pchName.EndsWith("_press")))
					{
						flag4 = true;
					}
				}
				else
				{
					flag4 = true;
				}
			}
			Logging.AlwaysLog("IsPublicBuild = {0}", flag4);
			_dlcManager = new DLCManager(_config.DLCConfig.Instance);
			Directories.Initialise();
			DebugVars.Initialise();
			DebugVars.SetValuesFromCommandLine();
			_inputManager = new InputManager(_config.InputManagerConfig.Instance, eventSystem);
			_controlBindingsLocalisationParamsManager = new ControlBindingsLocalisationParamsManager();
			_userPreferences = Preferences.LoadOrCreateNew(OSManager.GetLanguage(), _controlBindingsLocalisationParamsManager);
			_localPreferences = LocalPreferences.LoadOrCreateNew();
			_performance = new PerformanceCapture(_userPreferences, _localPreferences);
			_memoryUsageCapture = new MemoryUsageCapture();
			_ugcRuntimePrefabManager = new UGCRuntimePrefabManager();
			_ugcRoomItemDefinitionDatabase = new UGCRoomItemDefinitionDatabase();
			_ugcWallVisualOverrideDefinitionDatabase = new UGCWallVisualOverrideDefinitionDatabase();
			_ugcFloorVisualOverrideDefinitionDatabase = new UGCFloorVisualOverrideDefinitionDatabase();
			ReInput.InitializedEvent += OnReInputInitialized;
			IntialiseLocalisation();
			Behavior.CreateBehaviorManager();
			BehaviorManager.instance.UpdateInterval = UpdateIntervalType.Manual;
			GameAlgorithms.Initialise(_config.GameAlgorithmsConfig.Instance);
			_analyticsManager = new AnalyticsManager(this, _config.AnalyticsManagerConfig, _behaviourToRunCoroutinesOn, "TH20", flag4);
			if (Config.ExtContentManagerConfig.Instance.bEnabled)
			{
				_extContentManager = new ExtContentManager(this, _config.ExtContentManagerConfig.Instance, _behaviourToRunCoroutinesOn, graphicRaycaster.transform, _analyticsManager, _inputManager, _messageBox);
			}
			unhandledErrorDialogue.Setup(_behaviourToRunCoroutinesOn);
			_unhandledErrorReporter = new UnhandledErrorReporter(unhandledErrorDialogue, SetSuperPaused, Logging.Logger, _analyticsManager, _backtraceClient);
			_inputManager.AddGraphicRayCaster(graphicRaycaster);
			TooltipManager.CreateInstance(_inputManager);
			TooltipManager.Instance.PushGUIRoot(graphicRaycaster.transform);
			_saveOverlay = UnityEngine.Object.Instantiate(_config.SaveOverlayPrefab, graphicRaycaster.transform, worldPositionStays: false);
			_saveOverlay.transform.SetSiblingIndex(0);
			_dynamicPlaylistManager = new DynamicPlaylistManager(_config.DynamicPlaylistManagerConfig.Instance, _config.MetagameConfig.Instance.RadioConfig.Instance, _behaviourToRunCoroutinesOn);
			_dynamicPlaylistManager.SetOwnerGameObjectForAudio(_behaviourToRunCoroutinesOn.gameObject);
			_primeGaming = new PrimeGaming(this);
			_cloudDataManager = new CloudDataManager(this);
			_preferencesScreen = UnityEngine.Object.Instantiate(_config.PreferencesScreenPrefab, graphicRaycaster.transform, worldPositionStays: false).GetComponent<PreferencesScreen>();
			_preferencesScreen.Setup(this, _controlBindingsLocalisationParamsManager, _behaviourToRunCoroutinesOn);
			_preferencesScreen.transform.SetSiblingIndex(0);
			_consoleKeyBindingManager = new ConsoleKeyBindingManager(_inputManager);
			_prefabPoolManager = new PrefabPoolManager(_config.PrefabPoolManagerConfig.Instance);
			_developerConfig = new Configuration();
			string text = Path.Combine(Directories.GameOutputDirectory, "UserConfig.ini");
			Configuration configuration = Configuration.LoadFromFile(text);
			if (configuration == null)
			{
				Logging.Info("Couldn't load user config from {0}; just leaving defaults", text);
			}
			else
			{
				Logging.Info("Successfully loaded user config from {0}. Merging with defaults.", text);
				_developerConfig.MergeConfig(configuration);
			}
			DebugVars.SetValuesFromConfigFile(_developerConfig);
			_consoleKeyBindingManager.BindDebugKeys(_developerConfig);
			_debugFlyCamera = new DebugFlyCamera(_config.DebugFlyCameraConfig.Instance, _inputManager, _developerConfig);
			UnityEngine.Object.FindObjectOfType<ConsoleController>().ToggleKey = KeyCode.None;
			ConsoleCommandsDatabase.RegisterCommand("SearchCommand", "Search for a command", "Search for a command", Debug_FindCommand);
			ConsoleCommandsDatabase.RegisterCommand("FindCommand", "Search for a command", "Search for a command", Debug_FindCommand);
			ConsoleCommandsDatabase.RegisterCommand("SetDebugFlyCameraEnabled", "Sets whether debug fly camera is active", "SetDebugFlyCameraEnabled [true|false]", SetDebugFlyCameraEnabled);
			ConsoleCommandsDatabase.RegisterCommand("SetLoggingLevel", "Sets the minimum log level; less important messages than this will not get logged", "SetLoggingLevel [Verbose|Debug|Info|Warning|Error|Critical]", SetLoggingLevel);
			ConsoleCommandsDatabase.RegisterCommand("QuickSave", "Perform a quick save", "QuickSave", Debug_QuickSave);
			ConsoleCommandsDatabase.RegisterCommand("QuickLoad", "Perform a quick load", "QuickLoad", Debug_QuickLoad);
			ConsoleCommandsDatabase.RegisterCommand("ToggleSoundTest", "Toggle Sound Test Menu. Used for playing a sfx anywhere the mouse clicks", "ToggleSoundTest", Debug_ToggleSoundTest);
			ConsoleCommandsDatabase.RegisterCommand("StartSaveLoadTest", "Start save/load test running", "StartSaveLoadTest", Debug_StartSaveLoadTest);
			ConsoleCommandsDatabase.RegisterCommand("StartSaveTest", "Start save test running", "StartSaveTest", Debug_StartSaveTest);
			ConsoleCommandsDatabase.RegisterCommand("LoadLevel", "Loads a level with a given ID", "LoadLevel LevelID", Debug_LoadLevel);
			ConsoleCommandsDatabase.RegisterCommand("CheckAssetID", "Checks to see if an Asset ID is present in the external references list", "CheckAssetID [int]", Debug_CheckAssetID);
			ConsoleCommandsDatabase.RegisterCommand("GenerateAssetIDCSV", "Generates the asset ID CSV file", "GenerateAssetIDCSV", Debug_GenerateAssetIDCSV);
			ConsoleCommandsDatabase.RegisterCommand("GenerateAssetIDList", "Generates the asset ID list again, for profiling purposes really", "GenerateAssetIDList", Debug_GenerateAssetIDList);
			ConsoleCommandsDatabase.RegisterCommand("EnablePostProcessing", "Turn post processing on again", "EnablePostProcessing", Debug_EnablePostProcessing);
			ConsoleCommandsDatabase.RegisterCommand("DisablePostProcessing", "Turn post processing off again", "DisablePostProcessing", Debug_DisablePostProcessing);
			ConsoleCommandsDatabase.RegisterCommand("NavAreaTestStart", "Start Nav Mesh Area Lookup Testing", "NavAreaTestStart", Debug_NavAreaTestStart);
			ConsoleCommandsDatabase.RegisterCommand("NavAreaTestStop", "Stop Nav Mesh Area Lookup Testing", "NavAreaTestStop", Debug_NavAreaTestStop);
			ConsoleCommandsDatabase.RegisterCommand("LogAudioSettings", "Log Audio Settings", "LogAudioSettings", Debug_LogAudioSettings);
			ConsoleCommandsDatabase.RegisterCommand("ForceGargageCollection", "ForceGargageCollection", "ForceGargageCollection", Debug_ForceGargageCollection);
			ConsoleCommandsDatabase.RegisterCommand("SetLogLevelForCallStacksInLogFile", "SetLogLevelForCallStacksInLogFile", "SetLogLevelForCallStacksInLogFile", Debug_SetLogLevelForCallStacksInLogFile);
			ConsoleCommandsDatabase.RegisterSimpleCommand("QuitToMenu", "Quits to the frontend, performing an autosave", QuitToMenu);
			ConsoleCommandsDatabase.RegisterSimpleCommand("QuitToMenuDontSave", "Quits to the frontend, without saving", QuitToMenuDontSave);
			ConsoleCommandsDatabase.RegisterSimpleCommand("SkipFullscreenVideo", "Skips the current fullscreen video", delegate
			{
				_fullScreenVideoMenu.Skip();
			});
			ConsoleCommandsDatabase.RegisterSimpleCommand("SetAllDLCOwnedAndInstalled", "Pretends all DLC is owned and installed", Debug_SetAllDLCOwnedAndInstalled);
			ConsoleCommandsDatabase.RegisterCommand("UGCCreateNewRoomItem", "", "UGCCreateNewRoomItem <contentID>", Debug_UGCCreateNewRoomItem);
			ConsoleCommandsDatabase.RegisterCommand("UGCSetRuntimePrefab", "", "UGCSetRuntimePrefab <contentID> <path to jpg>", Debug_UGCSetRuntimePrefab);
			ConsoleCommandsDatabase.RegisterCommand("UGCItemSetIcon", "", "UGCItemSetIcon <contentID> <path to jpg>", Debug_UGCRoomItemSetIcon);
			ConsoleCommandsDatabase.RegisterCommand("UGCRoomItemSetCost", "", "UGCItemSetCost <contentID> <cost>", Debug_UGCRoomItemSetCost);
			ConsoleCommandsDatabase.RegisterCommand("UGCAddWallDiffuseTexture", "", "UGCAddWallDiffuseTexture <contentID> <cost>", Debug_UGCAddWallDiffuseTexture);
			ConsoleCommandsDatabase.RegisterCommand("UGCCreateAndSetWallVisualOverrideOnGPOffices", "", "UGCCreateAndSetWallVisualOverrideOnGPOffices <contentID> <cost>", Debug_UGCCreateAndSetWallVisualOverrideOnGPOffices);
			ConsoleCommandsDatabase.RegisterCommand("UGCAddFloorDiffuseTexture", "", "UGCAddFloorDiffuseTexture <contentID> <cost>", Debug_UGCAddFloorDiffuseTexture);
			ConsoleCommandsDatabase.RegisterCommand("UGCCreateAndSetFloorVisualOverrideOnGPOffices", "", "UGCCreateAndSetFloorVisualOverrideOnGPOffices <contentID> <cost>", Debug_UGCCreateAndSetFloorVisualOverrideOnGPOffices);
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerModeMono", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Mono));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerModeStereo", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Stereo));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerModeQuad", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Quad));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerMode5point1", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Mode5point1));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerMode7point1", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Mode7point1));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerModeSurround", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Surround));
			ConsoleCommandsDatabase.RegisterCommand("SetSpeakerModePrologic", "Set the speaker mode", "Set speaker mode", (string[] _) => Debug_SetSpeakerMode(AudioSpeakerMode.Prologic));
			ConsoleCommandsDatabase.RegisterCommand("GC", "Enables or disables garbage collection", "GC <enable>", Debug_GC);
			ConsoleCommandsDatabase.RegisterCommand("LogTestException", "Throws an exception, to test error handling stuff", "LogTestError", Debug_LogTestException);
			ConsoleCommandsDatabase.RegisterCommand("ToggleSaveSpam", "Toggles spam quick save on/off", "ToggleSaveSpam", Debug_ToggleSaveSpam);
			ConsoleCommandsDatabase.RegisterCommand("SetFullScreenMode", "Set the FullscreenMode based on arg", "SetFullScreenMode", Debug_SetFullScreenMode);
			ConsoleCommandsDatabase.RegisterCommand("PrintDisplayInfo", "Print current display settings", "PrintDisplayInfo", Debug_PrintDisplayInfo);
			_sandboxSaveManager = new SandboxSaveManager(_config.SandboxSettingsConfig.Instance, _assetIDs);
			_saveSystem = new SaveSystem(_assetIDs);
			_userProfile = UserProfile.LoadOrCreateNew(this);
			_superBugManager = new SuperBugProjectManager(this);
			_collaborativePortfolio = new CollaborativePortfolio(this);
			CollaborativePortfolio collaborativePortfolio = _collaborativePortfolio;
			collaborativePortfolio.OnPortfolioInitialised = (Action)Delegate.Combine(collaborativePortfolio.OnPortfolioInitialised, new Action(OnCollaborativePortfolioReady));
			_onlineAnalyticsManager = new OnlineAnalyticsManager(_analyticsManager);
			_audioManager = new AudioManager(_userPreferences, _config.AudioManagerConfig.Instance);
			_audioManager.LoadEventBank("HospitalAudioBank");
			_appAudioMixerManager = new AppAudioMixerManager(_localPreferences, _config.AppAudioMixerManagerConfig);
			_dynamicPlaylistManager.AppAudioMixerManager = _appAudioMixerManager;
			_roomTemplatesManager = new RoomTemplatesManager();
			consoleUI.OnToggleConsole += OnToggleConsole;
			soundTest.Setup(_inputManager);
			_stateMachine = new StateMachine(null);
			_stateMachine.PushState(new AppStateSegaSting(this));
			StartCoroutine(LoadMetagameSceneAndShowOpeningScreen());
			Application.wantsToQuit += WantsToQuit;
			if (IsOSXYosemti())
			{
				Material[] array = Resources.FindObjectsOfTypeAll<Material>();
				foreach (Material material in array)
				{
					if (TH20Standard.IsTH20Standard(material))
					{
						material.enableInstancing = false;
					}
				}
			}
			if (!string.IsNullOrEmpty(_analyticsManager.CurrentUserID))
			{
				_analyticsManager.SendInitAnalytics();
			}
		}

		public void LoadDevConfig()
		{
			Configuration config = Configuration.LoadFromString(_config.DefaultDevConfig.text);
			_developerConfig.MergeConfig(config);
			DebugVars.SetValuesFromConfigFile(_developerConfig);
			_consoleKeyBindingManager.BindDebugKeys(_developerConfig);
			Logging.Info("Successfully loaded default developer config");
		}

		public bool IsOSXYosemti()
		{
			string[] array = SystemInfo.operatingSystem.Split(' ');
			if (array.Length < 1)
			{
				return false;
			}
			if (array[0] != "Mac")
			{
				return false;
			}
			string[] array2 = array[3].Split('.');
			if (array2.Length < 2)
			{
				return false;
			}
			if (array2[0] != "10")
			{
				return false;
			}
			if (array2[1] != "10")
			{
				return false;
			}
			return true;
		}

		public void SetGameMode<T>() where T : GameMode, new()
		{
			_gameMode = new T();
			_gameMode.Init(this);
		}

		private IEnumerator LoadMetagameSceneAndShowOpeningScreen()
		{
			Logging.Info(LogChannels.GameFlow, "Loading MetagameScene scene");
			AsyncOperation loadMetagameSceneOperation = SceneManager.LoadSceneAsync("MetagameScene", LoadSceneMode.Additive);
			loadMetagameSceneOperation.allowSceneActivation = false;
			while (loadMetagameSceneOperation.progress < 0.9f)
			{
				yield return null;
			}
			loadMetagameSceneOperation.allowSceneActivation = true;
			yield return loadMetagameSceneOperation;
			GameObject[] rootGameObjects = SceneManager.GetSceneByName("MetagameScene").GetRootGameObjects();
			foreach (GameObject gameObject in rootGameObjects)
			{
				_metagameMapScene = gameObject.GetComponentInChildren<MetagameMapScene>();
				if (_metagameMapScene != null)
				{
					break;
				}
			}
			if (_metagameMapScene == null)
			{
				Logging.Error(LogChannels.GameFlow, "Failed to find MetagameMapScene component in MetagameMapScene scene");
			}
			FullScreenVideoMenu.Initialise(_metagameMapScene, _userPreferences);
			yield return LoadAndShowOpeningScreen();
		}

		private IEnumerator LoadAndShowOpeningScreen()
		{
			Logging.Info(LogChannels.GameFlow, "Loading OpeningScreen scene");
			AsyncOperation loadOpeningScreenOperation = SceneManager.LoadSceneAsync("OpeningScreen", LoadSceneMode.Additive);
			loadOpeningScreenOperation.allowSceneActivation = false;
			while (loadOpeningScreenOperation.progress < 0.9f)
			{
				yield return null;
			}
			loadOpeningScreenOperation.allowSceneActivation = true;
			yield return loadOpeningScreenOperation;
			GameObject[] rootGameObjects = SceneManager.GetSceneByName("OpeningScreen").GetRootGameObjects();
			foreach (GameObject gameObject in rootGameObjects)
			{
				_openingScreen = gameObject.GetComponentInChildren<OpeningScreen>();
				if (_openingScreen != null)
				{
					break;
				}
			}
			Logging.Info(LogChannels.GameFlow, "Setting up OpeningScreen");
			_openingScreen.Setup(this, _inputManager, _metagameMapScene);
			if (DebugVars.SkipFrontEndToSandbox.Value)
			{
				Logging.Info(LogChannels.GameFlow, "Skipping OpeningScreen; loading straight into Sandbox");
				SetGameMode<GameModeSandbox>();
				StartCoroutine(_gameMode.LoadAsync(ignoreSave: true, 0));
			}
			else if (DebugVars.SkipFrontEnd.Value)
			{
				Logging.Info(LogChannels.GameFlow, "Skipping OpeningScreen; loading straight into Career");
				int mostRecentMetagameSaveSlotIndex = _saveSystem.MostRecentMetagameSaveSlotIndex;
				bool num = mostRecentMetagameSaveSlotIndex < 0;
				SetGameMode<GameModeCareer>();
				if (num)
				{
					StartCoroutine(_gameMode.LoadAsync(ignoreSave: true, 0));
				}
				else
				{
					StartCoroutine(_gameMode.LoadAsync(ignoreSave: false, mostRecentMetagameSaveSlotIndex));
				}
			}
			else
			{
				Logging.Info(LogChannels.GameFlow, "Showing OpeningScreen");
				_openingScreen.Show();
			}
		}

		public void OnApplicationFocus(bool focus)
		{
			if (_inputManager != null)
			{
				_inputManager.OnApplicationFocus(focus);
			}
			OnlineManager.OnApplicationFocus(focus);
		}

		public void SetSuperPaused(bool superPaused)
		{
			if (_loadedLevel != null)
			{
				_loadedLevel.GameTime.IsSuperPaused = superPaused;
			}
		}

		public bool GetSuperPaused()
		{
			if (_loadedLevel == null)
			{
				return false;
			}
			return _loadedLevel.GameTime.IsSuperPaused;
		}

		private ConsoleCommandResult SetLoggingLevel(params string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Requires 1 argument");
			}
			try
			{
				Logging.Logger.MinimumLogLevel = (LogLevel)Enum.Parse(typeof(LogLevel), args[0]);
			}
			catch (Exception ex)
			{
				return ConsoleCommandResult.Failed(ex.Message);
			}
			return ConsoleCommandResult.Succeeded();
		}

		public void Update()
		{
			ThreadingUtils.Update();
			_inputManager.Update();
			if (!_loadSaveProgressScreen.IsVisible)
			{
				_consoleKeyBindingManager.Update();
				if (Metagame != null && !_messageBox.IsVisibleOrClosing)
				{
					if (_inputManager.GetButtonDown(49))
					{
						QuickSaveDeferred();
					}
					if (_inputManager.GetButtonDown(50) && ((Level != null && Level.MetagameMap.StateMachine.TopState is SandboxStateInHospital) || GameMode is GameModeCareer))
					{
						QuickLoad();
					}
				}
				_debugFlyCamera.Update();
				if (TooltipManager.Instance != null)
				{
					TooltipManager.Instance.Update();
				}
				_appAudioMixerManager.SetSFXVolumeOverride(1f);
			}
			else
			{
				_appAudioMixerManager.SetSFXVolumeOverride(1f - _loadSaveProgressScreen.Alpha);
			}
			_appAudioMixerManager.Update();
			OnlineManager.Update();
			PlatformStatsAndAchievements.Update();
			OSManager.Update();
			_extContentManager?.Update();
			_dynamicPlaylistManager?.Update();
			_audioManager.Update();
			if (_gameMode != null)
			{
				_gameMode.Update(GameTime.deltaTime, GameTime.unscaledDeltaTime);
			}
			_collaborativePortfolio.Update(GameTime.deltaTime, GameTime.unscaledDeltaTime);
			_superBugManager.Update(GameTime.deltaTime, GameTime.unscaledDeltaTime);
			if (_loadedLevel != null)
			{
				_loadedLevel.Update();
			}
			_atmManager.Update();
			_performance.Update();
			_memoryUsageCapture.Update();
			ProcessPromptQuitGamePending();
			ProcessMessageBox();
			if ((DateTime.UtcNow - _lastUnloadUnusedAssets).TotalMinutes > 30.0)
			{
				Resources.UnloadUnusedAssets();
				_lastUnloadUnusedAssets = DateTime.UtcNow;
			}
		}

		public void LateUpdate()
		{
			if (_loadedLevel != null)
			{
				_loadedLevel.LateUpdate();
			}
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("GC");
			ConsoleCommandsDatabase.UnRegisterCommand("SetDebugFlyCameraEnabled");
			ConsoleCommandsDatabase.UnRegisterCommand("SetLoggingLevel");
			ConsoleCommandsDatabase.UnRegisterCommand("QuickSave");
			ConsoleCommandsDatabase.UnRegisterCommand("QuickLoad");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleSoundTest");
			ConsoleCommandsDatabase.UnRegisterCommand("StartSaveLoadTest");
			ConsoleCommandsDatabase.UnRegisterCommand("LoadLevel");
			ConsoleCommandsDatabase.UnRegisterCommand("CheckAssetID");
			ConsoleCommandsDatabase.UnRegisterCommand("GenerateAssetIDList");
			ConsoleCommandsDatabase.UnRegisterCommand("EnablePostProcessing");
			ConsoleCommandsDatabase.UnRegisterCommand("DisablePostProcessing");
			ConsoleCommandsDatabase.UnRegisterCommand("NavAreaTestStart");
			ConsoleCommandsDatabase.UnRegisterCommand("NavAreaTestStop");
			ConsoleCommandsDatabase.UnRegisterCommand("LogAudioSettings");
			ConsoleCommandsDatabase.UnRegisterCommand("ForceGargageCollection");
			ConsoleCommandsDatabase.UnRegisterCommand("QuitToMenu");
			ConsoleCommandsDatabase.UnRegisterCommand("QuitToMenuDontSave");
			ConsoleCommandsDatabase.UnRegisterCommand("SkipFullscreenVideo");
			ConsoleCommandsDatabase.UnRegisterCommand("SetAllDLCOwnedAndInstalled");
			ConsoleCommandsDatabase.UnRegisterCommand("UGCCreateNewRoomItem");
			ConsoleCommandsDatabase.UnRegisterCommand("UGCSetRuntimePrefab");
			ConsoleCommandsDatabase.UnRegisterCommand("UGCItemSetIcon");
			ConsoleCommandsDatabase.UnRegisterCommand("UGCRoomItemSetCost");
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleSaveSpam");
			ConsoleCommandsDatabase.UnRegisterCommand("SetFullScreenMode");
			ConsoleCommandsDatabase.UnRegisterCommand("PrintDisplayInfo");
			if (_gameMode != null)
			{
				_gameMode.Destroy();
				_gameMode = null;
			}
			if (_loadedLevel != null)
			{
				_loadedLevel.Destroy();
				_loadedLevel = null;
			}
			DitheredRendererManager.Destroy();
			HighlightRendererProxy.Destroy();
			_stateMachine.Destroy();
			_appAudioMixerManager.Destroy();
			_onlineAnalyticsManager.Destroy();
			_superBugManager.Destroy();
			_collaborativePortfolio.Destroy();
			_cloudDataManager.Destroy();
			_debugFlyCamera.Destroy();
			_saveSystem.Destroy();
			_sandboxSaveManager.Destroy();
			TooltipManager.DestroyInstance();
			_unhandledErrorReporter.Destroy();
			OSManager.OnUserChanged = (Action)Delegate.Remove(OSManager.OnUserChanged, new Action(UpdateAnalyticsManagerUser));
			_analyticsManager.Destroy();
			GameAlgorithms.Destroy();
			_controlBindingsLocalisationParamsManager.Destroy();
			_inputManager.Destroy();
			PlatformFileManager.Destroy();
			PlatformStatsAndAchievements.Destroy();
			OnlineManager.Destroy();
			OSManager.Destroy();
			_dynamicPlaylistManager?.Destroy();
			_extContentManager?.Destroy();
			AudioManager.Instance.Destroy();
			ReInput.InitializedEvent -= OnReInputInitialized;
			ActionExtension.VerifyCallValid = true;
			OnAppReadyToShow.VerifyIsNull();
			OnLevelLoaded.VerifyIsNull();
			OnLevelAboutToBeUnloaded.VerifyIsNull();
			ActionExtension.VerifyCallValid = false;
			GameEventsRegistry.VerifyAndClearGlobalEvents();
			_atmManager.Destroy();
			_performance.Destroy();
			_memoryUsageCapture.Destroy();
			ThreadingUtils.Destroy();
			base.Destroy();
		}

		public void OnGUI()
		{
			if (_loadedLevel != null)
			{
				_loadedLevel.OnGUI();
			}
			if (DebugVars.ShowDebugInfo.Value)
			{
				OnDebugGUI();
			}
		}

		public void OnDrawGizmos()
		{
			if (_loadedLevel != null)
			{
				_loadedLevel.OnDrawGizmos();
			}
		}

		public IEnumerator UnloadLevelIfLoaded()
		{
			if (_loadedLevel != null)
			{
				Logging.Info(LogChannels.GameFlow, "Unloading level {0}", _loadedLevel.Config.UniqueId);
				try
				{
					OnLevelAboutToBeUnloaded.InvokeSafe(_loadedLevel);
				}
				catch (Exception ex)
				{
					Logging.Error(LogChannels.GameFlow, "Exception thrown whilst invoking OnLevelAboutToBeUnloaded: {0}", ex);
				}
				try
				{
					_loadedLevel.Destroy();
				}
				catch (Exception ex2)
				{
					Logging.Error(LogChannels.GameFlow, "Exception thrown whilst destroying level during unload: {0}", ex2);
				}
				_loadedLevel = null;
				Logging.Info(LogChannels.GameFlow, "Level unloaded");
			}
			else
			{
				Logging.Info(LogChannels.GameFlow, "Not unloading level as no level is currently loaded");
			}
			if (_loadedLevelSceneName != null)
			{
				Logging.Info(LogChannels.GameFlow, "Unloading level scene {0}", _loadedLevelSceneName);
				yield return SceneManager.UnloadSceneAsync(_loadedLevelSceneName);
				_lastUnloadUnusedAssets = DateTime.UtcNow;
				yield return Resources.UnloadUnusedAssets();
				_loadedLevelSceneName = null;
				Logging.Info(LogChannels.GameFlow, "Level scene unloaded");
			}
		}

		public Coroutine StartCoroutine(IEnumerator coroutine)
		{
			return _behaviourToRunCoroutinesOn.StartCoroutine(coroutine);
		}

		public void StopCoroutine(Coroutine coroutine)
		{
			if (coroutine != null)
			{
				_behaviourToRunCoroutinesOn.StopCoroutine(coroutine);
			}
		}

		public void LoadLevel(LevelConfig config, SaveFileHeader manuallyChosenSaveFile, bool ignoreSave, bool saveOldLevel = true)
		{
			if (IsLoading)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring LoadLevel as we're already loading");
				return;
			}
			Logging.Info(LogChannels.GameFlow, "Started loading level {0}", config.UniqueId);
			StartCoroutine(LoadLevelCoroutine(config, manuallyChosenSaveFile, ignoreSave, saveOldLevel));
		}

		public void FadeOut(float fadeTime, Color color, Action callbackFinished = null)
		{
			StartCoroutine(FadeOutCoroutine(fadeTime, color, callbackFinished));
		}

		public void FadeIn(float fadeTime, Color color, Action callbackFinished = null)
		{
			StartCoroutine(FadeInCoroutine(fadeTime, color, callbackFinished));
		}

		public IEnumerator FadeOutCoroutine(float fadeTime, Color color, Action callbackFinished = null)
		{
			Logging.Info(LogChannels.GameFlow, "Fade out starting for {0}s to {1}", fadeTime, color);
			_screenFade.SetFadeColor(color);
			_screenFade.SetFadeOpacity(0f);
			for (float fadeTimeLeft = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : fadeTime); fadeTimeLeft > 0f; fadeTimeLeft -= Time.unscaledDeltaTime)
			{
				_screenFade.SetFadeOpacity(Mathf.Clamp01(1f - fadeTimeLeft / fadeTime));
				yield return null;
			}
			_screenFade.SetFadeOpacity(1f);
			callbackFinished?.InvokeSafe();
			Logging.Info(LogChannels.GameFlow, "Fade out completed");
		}

		public IEnumerator FadeInCoroutine(float fadeTime, Color color, Action callbackFinished = null)
		{
			Logging.Info(LogChannels.GameFlow, "Fade in starting for {0}s to {1}", fadeTime, color);
			_screenFade.SetFadeColor(color);
			_screenFade.SetFadeOpacity(1f);
			for (float fadeTimeLeft = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : fadeTime); fadeTimeLeft > 0f; fadeTimeLeft -= Time.unscaledDeltaTime)
			{
				_screenFade.SetFadeOpacity(Mathf.Clamp01(fadeTimeLeft / fadeTime));
				yield return null;
			}
			_screenFade.SetFadeOpacity(0f);
			callbackFinished?.InvokeSafe();
			Logging.Info(LogChannels.GameFlow, "Fade in completed");
		}

		private IEnumerator LoadLevelCoroutine(LevelConfig levelConfig, SaveFileHeader manuallyChosenSaveFile, bool ignoreSave, bool saveOldLevel = true)
		{
			OnLevelLoadStarting.InvokeSafe();
			IsLoading = true;
			Logging.Info(LogChannels.GameFlow, "Starting LoadLevel coroutine");
			if (saveOldLevel && _loadedLevel != null && _loadedLevel.Config.UniqueId != levelConfig.UniqueId && !_loadedLevel.FinanceManager.IsBankrupt)
			{
				Logging.Info(LogChannels.GameFlow, "Switching from one level to another; auto-saving before unloading.");
				yield return QuickSaveWithOverlayCoroutine();
			}
			_loadSaveProgressScreen.Show(levelConfig);
			while (_loadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			yield return UnloadLevelIfLoaded();
			_loadSaveProgressScreen.SetProgress(0.25f);
			Logging.Info(LogChannels.GameFlow, "Loading level {0} - {1}", levelConfig.GetDisplayName(), levelConfig.SceneName);
			Application.backgroundLoadingPriority = ThreadPriority.Low;
			AsyncOperation loadLevelOperation = SceneManager.LoadSceneAsync(levelConfig.SceneName, LoadSceneMode.Additive);
			loadLevelOperation.allowSceneActivation = true;
			while (!loadLevelOperation.isDone)
			{
				float num = Mathf.Clamp01(loadLevelOperation.progress / 0.9f);
				_loadSaveProgressScreen.SetProgress(0.25f + num * 0.75f);
				yield return null;
			}
			yield return loadLevelOperation;
			_loadedLevelSceneName = levelConfig.SceneName;
			_loadSaveProgressScreen.SetProgress(1f);
			yield return null;
			Logging.Info(LogChannels.GameFlow, "Setting level scene as active");
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(levelConfig.SceneName));
			SaveFileHeader saveFileToUse = manuallyChosenSaveFile;
			if (saveFileToUse == null && !ignoreSave)
			{
				Logging.Info(LogChannels.GameFlow, "Checking whether a save exists for the level");
				saveFileToUse = _saveSystem.GetSaveForLevel(levelConfig.UniqueId);
			}
			if (saveFileToUse != null)
			{
				Debug.AssertMode currentAssertMode = Debug.CurrentAssertMode;
				Debug.CurrentAssertMode = Debug.AssertMode.ThrowException;
				try
				{
					Logging.Info(LogChannels.GameFlow, "Save exists for level; loading save data from file");
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					LevelSaveDataAndHeader levelSaveDataAndHeader = _saveSystem.LoadLevel(saveFileToUse.FilePath);
					stopwatch.Stop();
					long num2 = stopwatch.ElapsedTicks / 10;
					Logging.Info(LogChannels.Save, "Loaded level save in {0}s", (float)num2 / 1000000f);
					if (levelSaveDataAndHeader == null)
					{
						throw new CorruptSaveException("Loaded data is null; must have had error on save");
					}
					if (levelSaveDataAndHeader.LevelSaveData == null)
					{
						throw new CorruptSaveException("Loaded level save data is null; must have had error on save");
					}
					if (levelSaveDataAndHeader.LevelSaveData.Level == null)
					{
						throw new CorruptSaveException("Loaded level is null; must have had error on save");
					}
					_loadedLevel = levelSaveDataAndHeader.LevelSaveData.Level;
					try
					{
						stopwatch.Reset();
						stopwatch.Start();
						IsRestoringFromSave = true;
						_loadedLevel.RestoreFromSave(this, _inputManager, _levelCommonScript, Metagame, MetagameMap, _userPreferences, _localPreferences, _analyticsManager);
						IsRestoringFromSave = false;
						stopwatch.Stop();
						long num3 = stopwatch.ElapsedTicks / 10;
						Logging.Info(LogChannels.Save, "Restored level from save in {0}s", (float)num3 / 1000000f);
					}
					catch (Exception ex)
					{
						IsRestoringFromSave = false;
						Logging.Info(LogChannels.Save, "Exception while restoring level save after a load. Could be a bug, could be an old save. Exception: " + ex);
						try
						{
							if (_loadedLevel != null)
							{
								_loadedLevel.Destroy();
							}
						}
						catch (Exception ex2)
						{
							Logging.Warning(LogChannels.Save, "Failed to destroy level after failed restore. Exception: " + ex2);
							throw new CorruptSaveUnstableGameException("Failed to restore level after load, and failed to destroy the partially restored object too. (destroy exception is logged)", ex);
						}
						_loadedLevel = null;
						throw new CorruptSaveException("Failed to restore level after load", ex);
					}
				}
				catch (Exception ex3)
				{
					Logging.Error(LogChannels.Save, "Exception encountered whilst loading level save: " + ex3);
					_loadedLevel = null;
				}
				finally
				{
					Debug.CurrentAssertMode = currentAssertMode;
				}
			}
			else
			{
				Logging.Info(LogChannels.GameFlow, "No save exists; starting afresh");
				_loadedLevel = new Level(this, _inputManager, _levelCommonScript, _gameMode.Metagame, _gameMode.MetagameMap, levelConfig, _userPreferences, _localPreferences, _analyticsManager);
			}
			if (_loadedLevel == null)
			{
				Logging.Info(LogChannels.GameFlow, "Level failed to load; trying to go back to previous state");
				Metagame.SetCurrentLevel(null);
				MetagameMap.InitialiseFromLevel(null, null, null);
				yield return UnloadLevelIfLoaded();
				SceneManager.SetActiveScene(SceneManager.GetSceneByName(_gameMode.GetMetagameSceneName()));
				_loadSaveProgressScreen.Hide();
				while (_loadSaveProgressScreen.IsAnimating)
				{
					yield return null;
				}
				if (MetagameMap.StateMachine.TopState is MetagameStateInHospital metagameStateInHospital)
				{
					metagameStateInHospital.OnReturnToMetagameMap();
				}
				if (MetagameMap.StateMachine.TopState is SandboxStateInHospital sandboxStateInHospital)
				{
					SandboxSaveManager.CurrentSettings = null;
					sandboxStateInHospital.OnReturnToMetagameMap();
				}
				MetagameMap.Open();
				FadeIn(_config.LevelLoadFadeTime, Color.white);
				SaveFileHeader backupLevelHeader = null;
				if (SaveSystem.TryGetBackupLevelSave(levelConfig.UniqueId, out var saveData))
				{
					backupLevelHeader = saveData.LevelSaveFileHeader;
				}
				_backupSaveBox.ShowLevelBackup(levelConfig, backupLevelHeader);
				IsLoading = false;
				yield break;
			}
			if (_loadedLevel != null && Metagame != null)
			{
				if (SandboxSaveManager.CurrentSettings != null)
				{
					_loadedLevel.OrganisationName = SandboxSaveManager.CurrentSettings.DisplayName;
				}
				else
				{
					_loadedLevel.OrganisationName = Metagame.OrganisationName;
				}
			}
			OnLevelLoaded.InvokeSafe(_loadedLevel, saveFileToUse != null);
			_loadSaveProgressScreen.Hide();
			while (_loadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			if (saveFileToUse == null)
			{
				QuickSaveDeferred();
			}
			Logging.Info(LogChannels.GameFlow, "Level load complete");
			IsLoading = false;
		}

		private SaveData CreateSaveData()
		{
			return new SaveData
			{
				Level = _loadedLevel
			};
		}

		private MetagameSaveData CreateMetagameSaveData()
		{
			return new MetagameSaveData
			{
				Metagame = Metagame
			};
		}

		public void AutoSaveDeferred()
		{
			StartCoroutine(AutoSaveWithOverlay());
		}

		private IEnumerator AutoSaveWithOverlay()
		{
			_lastUnloadUnusedAssets = DateTime.UtcNow;
			Resources.UnloadUnusedAssets();
			_saveOverlay.SetActive(value: true);
			yield return null;
			_saveSystem.AutoSave(CreateMetagameSaveData(), CreateSaveData());
			_saveOverlay.SetActive(value: false);
		}

		public void QuickSaveInstantly()
		{
			_saveSystem.ManualSave(CreateMetagameSaveData(), CreateSaveData());
		}

		public void QuickSaveDeferred()
		{
			StartCoroutine(QuickSaveWithOverlayCoroutine());
		}

		public IEnumerator QuickSaveWithOverlayCoroutine()
		{
			if (GameMode.AllowGameToBeSaved())
			{
				_lastUnloadUnusedAssets = DateTime.UtcNow;
				yield return Resources.UnloadUnusedAssets();
				_saveOverlay.SetActive(value: true);
				_inputManager.Flush();
				yield return null;
				QuickSaveInstantly();
				_saveOverlay.SetActive(value: false);
				_inputManager.Flush();
			}
		}

		public void Save(string saveName)
		{
			_saveOverlay.SetActive(value: true);
			_saveSystem.ManualSaveAs(CreateMetagameSaveData(), CreateSaveData(), saveName);
			_saveOverlay.SetActive(value: false);
		}

		public void SaveMetagameInstantly()
		{
			if (GameMode.AllowGameToBeSaved())
			{
				_saveSystem.SaveMetagame(CreateMetagameSaveData());
			}
		}

		public void SaveMetagameDeferred()
		{
			StartCoroutine(SaveMetagameWithOverlayCoroutine());
		}

		public IEnumerator SaveMetagameWithOverlayCoroutine()
		{
			_saveOverlay.SetActive(value: true);
			yield return null;
			SaveMetagameInstantly();
			_saveOverlay.SetActive(value: false);
		}

		public void QuickLoad()
		{
			if (!GameMode.AllowGameToBeSaved())
			{
				return;
			}
			if (IsLoading)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring QuickLoad as we're already loading");
				return;
			}
			if (MetagameMap.IsTransitioning)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring QuickLoad as we're MetagameMap is the middle of a transition");
				return;
			}
			if (!(MetagameMap?.StateMachine?.TopState is MetagameState metagameState) || !metagameState.CanQuickLoadInThisState())
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring QuickLoad as the player is not in control.  We are likely in a cutscene or post cutscene event");
				return;
			}
			SaveFileHeader mostRecentSave = _saveSystem.MostRecentSave;
			if (mostRecentSave == null)
			{
				_messageBox.Show("Can't load save", "There's no recent save to continue from. Sorry!", "That's a shame");
			}
			else
			{
				Load(mostRecentSave);
			}
		}

		public void Load(SaveFileHeader saveFile)
		{
			if (IsLoading)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring Load as we're already loading");
			}
			else if (!ShowMessageBoxIfSaveHeaderCantLoad(saveFile, null))
			{
				LevelConfig levelConfigByID = Metagame.LevelList.GetLevelConfigByID(saveFile.LevelID);
				Logging.Info(LogChannels.GameFlow, "Loading saved game \"{0}\"", saveFile.GetDisplayName());
				LoadLevel(levelConfigByID, saveFile, ignoreSave: false);
				if (MetagameMap.IsVisible)
				{
					MetagameMap.CloseAfterLoad();
				}
			}
		}

		public bool ShowMessageBoxIfSaveHeaderCantLoad(SaveFileHeader saveFileHeader, LevelConfig config)
		{
			if (SaveFileVersionIsTooNewToLoad(saveFileHeader.Version))
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring save file (and showing message) as save file is from newer version.");
				_messageBox.Show(ScriptLocalization.Menu_Messages.CantLoadLevelSave_CS, ScriptLocalization.Menu_Messages.CantLoadLevelSave_Too_New_CS, ScriptLocalization.Menu_Messages.OK_Button_CS);
				return true;
			}
			if (saveFileHeader.IsBroken)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring save file (and showing message) as save file is broken.");
				SaveFileHeader backupLevelHeader = null;
				if (config != null && SaveSystem.TryGetBackupLevelSave(config.UniqueId, out var saveData))
				{
					backupLevelHeader = saveData.LevelSaveFileHeader;
				}
				_backupSaveBox.ShowLevelBackup(config, backupLevelHeader);
				return true;
			}
			if (Metagame.LevelList.GetLevelConfigByID(saveFileHeader.LevelID) == null)
			{
				Logging.Info(LogChannels.GameFlow, "Ignoring save file (and showing message) as level doesn't exist.");
				_messageBox.Show(ScriptLocalization.Menu_Messages.CantLoadLevelSave_CS, ScriptLocalization.Menu_Messages.CantLoadSaveNotExist_CS, ScriptLocalization.Menu_Messages.OK_Button_CS);
				return true;
			}
			return false;
		}

		private static bool SaveFileVersionIsTooNewToLoad(VersionNumber version)
		{
			if (DebugVars.DisableOldSaveVersionCheck.Value)
			{
				return false;
			}
			if (version.Major == 1 && version.Minor == 18)
			{
				return false;
			}
			if (GameVersionNumber.Version.Patch == 0 && (GameVersionNumber.Version.PreReleaseVersion == "0.editor" || GameVersionNumber.Version.PreReleaseVersion == "0.local"))
			{
				return false;
			}
			return version > GameVersionNumber.Version;
		}

		private void IntialiseLocalisation()
		{
			if (LocalizationManager.HasLanguage("English"))
			{
				RegisterDebugLocalizationCommands();
				LocalizationManager.EnableChangingCultureInfo(bEnable: true);
			}
		}

		public void QuitToMenu()
		{
			StartCoroutine(QuitToMenuCoroutine(save: true));
		}

		public void QuitToMenuDontSave()
		{
			StartCoroutine(QuitToMenuCoroutine(save: false));
		}

		private IEnumerator QuitToMenuCoroutine(bool save)
		{
			IsQuitting = true;
			Logging.Info(LogChannels.GameFlow, "Starting QuitToMenuCoroutine");
			_loadSaveProgressScreen.Show();
			while (_loadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			if (save)
			{
				if (_loadedLevel != null)
				{
					QuickSaveInstantly();
				}
				else if (Metagame != null)
				{
					SaveMetagameInstantly();
				}
			}
			yield return UnloadLevelIfLoaded();
			_loadSaveProgressScreen.SetProgress(0.5f);
			if (_gameMode != null)
			{
				yield return _gameMode.Unload();
				_gameMode.Destroy();
				_gameMode = null;
			}
			_loadSaveProgressScreen.SetProgress(1f);
			_openingScreen.Show();
			_loadSaveProgressScreen.Hide();
			while (_loadSaveProgressScreen.IsAnimating)
			{
				yield return null;
			}
			IsQuitting = false;
			Logging.Info(LogChannels.GameFlow, "Finishing QuitToMenuCoroutine");
		}

		public bool ShouldQuitNow()
		{
			bool result = true;
			if ((!(OpeningScreen != null) || !OpeningScreen.IsVisible) && !TH20.QuitGame.applicationQuitCalled && !_promptQuitGamePending)
			{
				result = false;
			}
			return result;
		}

		private bool WantsToQuit()
		{
			bool num = ShouldQuitNow();
			if (!num)
			{
				_promptQuitGamePending = true;
			}
			return num;
		}

		private void OnReInputInitialized()
		{
			Logging.Info(LogChannels.Preferences, "Reapply control preferences");
			_userPreferences.Control.Apply(_controlBindingsLocalisationParamsManager);
		}

		private void ProcessPromptQuitGamePending()
		{
			if (_promptQuitGamePending)
			{
				_promptQuitGamePending = false;
				MessageBox.ShowAs2ChoiceAndCancel(ScriptLocalization.Menu_Messages.AreYouSureQuit_Title_CS, OptionsMenu.AddLastSaveInfoIfAppropriate(ScriptLocalization.Menu_Messages.AreYouSureQuit_CS, SaveSystem), ScriptLocalization.Menu_Messages.QuitSave_Button_CS, ScriptLocalization.Menu_Messages.QuitDontSave_Button_CS, ScriptLocalization.Menu_Messages.Cancel_Button_CS, QuitGame, QuitGameDontSave, QuitGameCancel);
			}
		}

		private void QuitGameCancel()
		{
			_promptQuitGamePending = false;
		}

		public void QuitGame()
		{
			PlatformFileManager.AllowAsync = false;
			if (_loadedLevel != null)
			{
				QuickSaveInstantly();
			}
			else if (Metagame != null)
			{
				SaveMetagameInstantly();
			}
			TH20.QuitGame.Quit();
		}

		public void QuitGameDontSave()
		{
			TH20.QuitGame.Quit();
		}

		public static bool IsSceneLoaded(string sceneName)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				if (SceneManager.GetSceneAt(i).name == sceneName)
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerator LoadLevelCommon()
		{
			if (_levelCommonScript == null)
			{
				Logging.Info(LogChannels.GameFlow, "Loading level common scene");
				AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_config.LevelCommonSceneName, LoadSceneMode.Additive);
				asyncOperation.allowSceneActivation = true;
				yield return asyncOperation;
				LoadSaveProgressScreen.SetProgress(0.25f);
				_levelCommonScript = UnityEngine.Object.FindObjectOfType<LevelCommonScript>();
				TooltipManager.Instance.PushGUIRoot(_levelCommonScript.MenusTransform);
			}
		}

		private void OnCollaborativePortfolioReady()
		{
			if (CollaborativePortfolio.PortfolioDataController?.PortfolioData?.SuperBugRewardRecord != null && _userProfile.SuperBugRewardRecord == null)
			{
				_userProfile.SuperBugRewardRecord = new SuperBugRewardRecord(CollaborativePortfolio.PortfolioDataController.PortfolioData.SuperBugRewardRecord);
			}
		}

		public void ReloadSaves()
		{
			_userProfile = UserProfile.LoadOrCreateNew(this);
			_userPreferences = Preferences.LoadOrCreateNew(OSManager.GetLanguage(), _controlBindingsLocalisationParamsManager);
			_localPreferences = LocalPreferences.LoadOrCreateNew();
			SandboxSaveManager.RefreshSaveLists();
			SaveSystem.RefreshSaveLists();
			DynamicPlaylistManager.LoadFromFile();
			_performance.Refresh(_userPreferences, _localPreferences);
			_preferencesScreen.Refresh(_userPreferences, _localPreferences);
			_audioManager.Refresh(_userPreferences);
			_appAudioMixerManager.Refresh(_localPreferences);
			FullScreenVideoMenu.Initialise(_metagameMapScene, _userPreferences);
			_userPreferences.Control.Apply(_controlBindingsLocalisationParamsManager);
		}

		private void OnPlayfabConnectionEstablished()
		{
			Logging.Info("[OnlineConnection] OnPlayfabConnectionEstablished Starting Coroutines");
			SuperBugManager.Initialise();
			CollaborativePortfolio.RestoreFromSave(this);
			if (Metagame != null)
			{
				Metagame.OnlineMetadataManager.InitDataFiles();
			}
			if (_loadedLevel == null)
			{
				return;
			}
			foreach (OnlineChallengeObjective onlineChallenge in _loadedLevel.LevelScriptManager.OnlineChallenges)
			{
				onlineChallenge.OnConnectionEstablished();
			}
		}

		public void StopGettingLatestOnlineMetadata()
		{
			Logging.Info("[OnlineConnection] StopGettingLatestOnlineMetadata Stopping Coroutines");
			SuperBugManager.StopGettingLatest();
			CollaborativePortfolio.StopGettingLatest();
			if (Metagame != null)
			{
				Metagame.OnlineMetadataManager.StopGettingLatest();
			}
		}

		private void UpdateAnalyticsManagerUser()
		{
			OnlinePlayerID localPlayerID = OnlineManager.GetLocalPlayerID();
			_analyticsManager.OnUserChanged(localPlayerID.ToString());
		}

		private ConsoleCommandResult SetDebugFlyCameraEnabled(string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				_debugFlyCamera.Enabled = enabled;
			}, args);
		}

		private ConsoleCommandResult Debug_ToggleSoundTest(string[] args)
		{
			_soundTest.gameObject.SetActive(!_soundTest.gameObject.activeSelf);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_StartSaveLoadTest(string[] args)
		{
			StartCoroutine(Debug_SaveLoadTestCoroutine());
			return ConsoleCommandResult.Succeeded();
		}

		private IEnumerator Debug_SaveLoadTestCoroutine()
		{
			int i = 0;
			while (i < 1000)
			{
				yield return QuickSaveWithOverlayCoroutine();
				yield return new WaitForSeconds(RandomUtils.GlobalRandomInstance.Next(10, 15));
				QuickLoad();
				yield return new WaitForSeconds(RandomUtils.GlobalRandomInstance.Next(10, 15));
				int num = i + 1;
				i = num;
			}
			yield return null;
		}

		private ConsoleCommandResult Debug_StartSaveTest(string[] args)
		{
			StartCoroutine(Debug_SaveTestCoroutine());
			return ConsoleCommandResult.Succeeded();
		}

		private IEnumerator Debug_SaveTestCoroutine()
		{
			int i = 0;
			while (i < 10000)
			{
				yield return QuickSaveWithOverlayCoroutine();
				yield return new WaitForSeconds(RandomUtils.GlobalRandomInstance.NextFloat(1f, 3f));
				int num = i + 1;
				i = num;
			}
			yield return null;
		}

		private ConsoleCommandResult Debug_GC(string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool b)
			{
				if (b)
				{
					GC.Enable();
				}
				else
				{
					GC.Disable();
				}
			}, args);
		}

		private ConsoleCommandResult Debug_LogTestException(string[] args)
		{
			StartCoroutine(Debug_ThrowExceptionCoroutine());
			return ConsoleCommandResult.Succeeded();
		}

		private static IEnumerator Debug_ThrowExceptionCoroutine()
		{
			yield return null;
			throw new Exception("Test exception");
		}

		private ConsoleCommandResult Debug_ToggleSaveSpam(string[] args)
		{
			if (_saveSpamCoroutine == null)
			{
				_saveSpamCoroutine = StartCoroutine(Debug_ToggleSaveSpamCoroutine());
			}
			else
			{
				StopCoroutine(_saveSpamCoroutine);
				_saveSpamCoroutine = null;
			}
			return ConsoleCommandResult.Succeeded();
		}

		private IEnumerator Debug_ToggleSaveSpamCoroutine()
		{
			WaitForSeconds yielder = new WaitForSeconds(1f);
			while (true)
			{
				yield return yielder;
				if (_loadedLevel != null)
				{
					QuickSaveInstantly();
				}
				else if (Metagame != null)
				{
					SaveMetagameInstantly();
				}
			}
		}

		private ConsoleCommandResult Debug_FindCommand(string[] args)
		{
			string text = string.Empty;
			foreach (string item in ConsoleCommandsDatabase.CommandsContainingStrings(args))
			{
				text = text + item + "\n";
			}
			return ConsoleCommandResult.Succeeded(text);
		}

		private ConsoleCommandResult Debug_SetSpeakerMode(AudioSpeakerMode mode)
		{
			AudioConfiguration configuration = AudioSettings.GetConfiguration();
			configuration.speakerMode = mode;
			AudioSettings.Reset(configuration);
			return ConsoleCommandResult.Succeeded($"Speaker mode is now = {AudioSettings.GetConfiguration().speakerMode}");
		}

		private ConsoleCommandResult Debug_QuickLoad(string[] args)
		{
			if (!PreferencesScreen.isActiveAndEnabled)
			{
				QuickLoad();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_QuickSave(string[] args)
		{
			if (!PreferencesScreen.isActiveAndEnabled)
			{
				QuickSaveDeferred();
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void RegisterDebugLocalizationCommands()
		{
			LocalizationManager.HasLanguage("English");
			if (LocalizationManager.Sources.Count != 0)
			{
				ConsoleCommandsDatabase.RegisterCommand("Language", "Set the current language", "Language [code]", Debug_SetLanguage);
				foreach (LanguageData mLanguage in LocalizationManager.Sources[0].mLanguages)
				{
					string text = $"Language {mLanguage.Code}";
					ConsoleCommandsDatabase.RegisterCommand(text, $"Sets the current language to {mLanguage.Name}", text, Debug_SetLanguage);
				}
			}
			ConsoleCommandsDatabase.RegisterCommand("ShowMissingTranslations", "Highlights missing translations on the HUD", "ShowMissingTranslations [true|false]", Debug_ShowMissingTranslations);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_AllTextItems", "Shows all current text elements on the HUD", "DebugLocText_SetMode_AllTextItems", DebugLocText_SetMode_AllTextItems);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_AllTranslatedItems", "Shows all current text elements on the HUD with current language translations", "DebugLocText_SetMode_AllTranslatedItems", DebugLocText_SetMode_AllTranslatedItems);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_ItemsMissingLocaliseComponent", "Shows all current text elements on the HUD with missing localise component", "DebugLocText_SetMode_ItemsMissingLocaliseComponent", DebugLocText_SetMode_ItemsMissingLocaliseComponent);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_ItemsLocaliseTermNone", "Shows all current text elements on the HUD with localise component with Term 'none'", "DebugLocText_SetMode_ItemsLocaliseTermNone", DebugLocText_SetMode_ItemsLocaliseTermNone);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_ItemsMissingTranslation", "Shows all current text elements on the HUD with missing current language translations", "DebugLocText_SetMode_ItemsMissingTranslation", DebugLocText_SetMode_ItemsMissingTranslation);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_SetMode_ItemsNonNoneMissingTranslation", "Shows all current text elements on the HUD with none None localise terms but missing current language translations", "DebugLocText_SetMode_ItemsNonNoneMissingTranslation", DebugLocText_SetMode_ItemsNonNoneMissingTranslation);
			ConsoleCommandsDatabase.RegisterCommand("DebugLocText_ToggleShowBorders", "Toggles wether text box broders are displayed", "DebugLocText_ToggleShowBorders", DebugLocText_ToggleShowBorders);
		}

		private ConsoleCommandResult Debug_SetLanguage(string[] args)
		{
			if (args.Length >= 1)
			{
				LocalizationManager.CurrentLanguageCode = args[0];
				return ConsoleCommandResult.Succeeded();
			}
			return ConsoleCommandResult.Failed("Not enough arguments");
		}

		private ConsoleCommandResult Debug_ShowMissingTranslations(params string[] args)
		{
			return ConsoleCommandHelpers.ExtractBool(delegate(bool enabled)
			{
				_showMissingTranslations = enabled;
			}, args);
		}

		private void EnsureShowMissingTranslationsEnabled()
		{
			_showMissingTranslations = true;
		}

		private void ProcessMessageBox()
		{
			if (MessageBox != null)
			{
				HUD hUD = null;
				if (MetagameMap != null && MetagameMap.IsVisible)
				{
					hUD = MetagameMap.HUD;
				}
				else if (_loadedLevel != null)
				{
					hUD = _loadedLevel.HUD;
				}
				hUD?.SetMessageBoxOpenStatus(MessageBox.IsVisibleOrClosing);
				if (MessageBox.IsVisible && Input.GetKeyDown(KeyCode.Escape))
				{
					MessageBox.Cancel();
				}
			}
		}

		private ConsoleCommandResult Debug_LoadLevel(string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("No arguments given; must give Level ID");
			}
			string levelID = args[0];
			SharedInstance<LevelConfig> sharedInstance = Metagame.LevelList.Levels.Find((SharedInstance<LevelConfig> l) => l.Instance.UniqueId == levelID);
			if (sharedInstance == null)
			{
				return ConsoleCommandResult.Failed("Couldn't find level with ID " + levelID);
			}
			SaveFileHeader saveForLevel = MetagameMap.SaveSystem.GetSaveForLevel(levelID);
			if (saveForLevel != null && ShowMessageBoxIfSaveHeaderCantLoad(saveForLevel, sharedInstance.Instance))
			{
				return ConsoleCommandResult.Succeeded();
			}
			if (MetagameMap.IsVisible)
			{
				MetagameMap.Close(sharedInstance.Instance);
			}
			else
			{
				LoadLevel(sharedInstance.Instance, null, ignoreSave: false);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_CheckAssetID(string[] args)
		{
			if (args.Length == 0)
			{
				return ConsoleCommandResult.Failed("No arguments given; must give Asset ID");
			}
			if (!int.TryParse(args[0], out var result))
			{
				return ConsoleCommandResult.Failed("Asset ID is not an integer");
			}
			if (!AssetIDMappingQueries.TryLookupAssetIDDetails(_configInstance, result, out var path, out var owningAssetID, out var obj))
			{
				return ConsoleCommandResult.Succeeded("Asset ID is not present in map");
			}
			return ConsoleCommandResult.Succeeded($"Asset ID Found!\nType: {obj.GetType()}\nOwning asset: {owningAssetID}\nMember path: {path}\nObj as string: {obj}");
		}

		private ConsoleCommandResult Debug_GenerateAssetIDList(string[] args)
		{
			AssetIDMapping.GenerateExternalReferencesList(_configInstance);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_GenerateAssetIDCSV(string[] args)
		{
			AssetIDMappingCSVGenerator.GenerateAssetIDCSVFile(_configInstance, Path.Combine(Directories.GameOutputDirectory, "AssetIDs.csv"));
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_DisablePostProcessing(string[] args)
		{
			PostProcessLayer[] array = UnityEngine.Object.FindObjectsOfType<PostProcessLayer>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_EnablePostProcessing(string[] args)
		{
			PostProcessLayer[] array = UnityEngine.Object.FindObjectsOfType<PostProcessLayer>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = true;
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_NavAreaTestStart(string[] args)
		{
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_NavAreaTestStop(string[] args)
		{
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ForceGargageCollection(string[] args)
		{
			System.GC.Collect();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetLogLevelForCallStacksInLogFile(string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Requires 1 argument");
			}
			try
			{
				Logging.Logger.GetLogHandler<FileLogHandler>().LogLevelToPrintCallstacks = (LogLevel)Enum.Parse(typeof(LogLevel), args[0]);
				Logging.Logger.UpdateHandlersThatWantCallStacks();
			}
			catch (Exception ex)
			{
				return ConsoleCommandResult.Failed(ex.Message);
			}
			return ConsoleCommandResult.Succeeded();
		}

		private void Debug_SetAllDLCOwnedAndInstalled()
		{
		}

		private ConsoleCommandResult Debug_LogAudioSettings(string[] args)
		{
			string text = $"MusicVolume: {_localPreferences.Audio.MusicVolume}\nMasterVolume: {_localPreferences.Audio.MasterVolume}\nSFXVolume: {_localPreferences.Audio.SFXVolume}\nTannoyVolume: {_localPreferences.Audio.TannoyVolume}\nDJVolume: {_localPreferences.Audio.DJVolume}\n";
			Logging.Info(LogChannels.Preferences, text);
			UnityEngine.Debug.Log(text);
			return ConsoleCommandResult.Succeeded(text);
		}

		private void OnToggleConsole(bool enabled)
		{
			_inputManager.Enabled = !enabled;
		}

		private ConsoleCommandResult DebugLocText_SetMode_AllTextItems(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.AllTextItems;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_SetMode_AllTranslatedItems(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.AllTranslatedItems;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_SetMode_ItemsMissingLocaliseComponent(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.ItemsMissingLocaliseComponent;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_SetMode_ItemsLocaliseTermNone(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.ItemsLocaliseTermNone;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_SetMode_ItemsMissingTranslation(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.ItemsMissingTranslation;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_SetMode_ItemsNonNoneMissingTranslation(params string[] args)
		{
			_showMissingTranslationsMode = DebugLocTextMode.ItemsNonNoneMissingTranslation;
			EnsureShowMissingTranslationsEnabled();
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult DebugLocText_ToggleShowBorders(params string[] args)
		{
			_showMissingTranslationsTextBorders = !_showMissingTranslationsTextBorders;
			return ConsoleCommandResult.Succeeded();
		}

		private void OnDebugGUI()
		{
			if (_showMissingTranslations)
			{
				ShowMissingTranslations();
			}
		}

		private void ShowMissingTranslations()
		{
			TMP_Text[] array = UnityEngine.Object.FindObjectsOfType<TMP_Text>();
			Color backgroundColor = GUI.backgroundColor;
			GUIStyle style = new GUIStyle
			{
				normal = new GUIStyleState
				{
					background = Texture2D.whiteTexture
				}
			};
			Color backgroundColor2 = _showMissingTranslationsMode switch
			{
				DebugLocTextMode.AllTextItems => new Color(0.5f, 1f, 0.5f, 0.5f), 
				DebugLocTextMode.AllTranslatedItems => new Color(0f, 1f, 0f, 0.5f), 
				DebugLocTextMode.ItemsMissingLocaliseComponent => new Color(1f, 0f, 0f, 0.5f), 
				DebugLocTextMode.ItemsLocaliseTermNone => new Color(1f, 1f, 0f, 0.5f), 
				DebugLocTextMode.ItemsNonNoneMissingTranslation => new Color(1f, 0.5f, 1f, 0.5f), 
				DebugLocTextMode.ItemsMissingTranslation => new Color(1f, 0.5f, 0.5f, 0.5f), 
				_ => new Color(0.5f, 0f, 0.5f, 0.5f), 
			};
			Color backgroundColor3 = new Color(1f, 1f, 1f, 1f);
			float num = 1f;
			TMP_Text[] array2 = array;
			foreach (TMP_Text tMP_Text in array2)
			{
				bool flag = false;
				Localize component = tMP_Text.GetComponent<Localize>();
				bool flag2 = component != null;
				bool flag3 = component != null && component.Term != string.Empty;
				bool flag4 = flag3 && component.Term == "-";
				string text = string.Empty;
				if (flag3)
				{
					text = LocalizationManager.GetTranslation(component.Term);
				}
				bool flag5 = text != string.Empty && !text.Contains("Missing Translation");
				switch (_showMissingTranslationsMode)
				{
				case DebugLocTextMode.AllTextItems:
					flag = true;
					break;
				case DebugLocTextMode.AllTranslatedItems:
					flag = flag5;
					break;
				case DebugLocTextMode.ItemsMissingLocaliseComponent:
					flag = !flag2;
					break;
				case DebugLocTextMode.ItemsLocaliseTermNone:
					flag = flag4;
					break;
				case DebugLocTextMode.ItemsNonNoneMissingTranslation:
					flag = flag3 && !flag4 && !flag5;
					break;
				case DebugLocTextMode.ItemsMissingTranslation:
					flag = !flag5;
					break;
				}
				if (flag)
				{
					Rect screenSpaceRect = tMP_Text.rectTransform.GetScreenSpaceRect();
					GUI.backgroundColor = backgroundColor2;
					GUI.Box(screenSpaceRect, "", style);
					if (_showMissingTranslationsTextBorders)
					{
						GUI.backgroundColor = backgroundColor3;
						Rect position = screenSpaceRect;
						position.height = num;
						GUI.Box(position, "", style);
						position = screenSpaceRect;
						position.y = screenSpaceRect.yMax;
						position.height = num;
						GUI.Box(position, "", style);
						position = screenSpaceRect;
						position.width = num;
						GUI.Box(position, "", style);
						position = screenSpaceRect;
						position.x = screenSpaceRect.xMax;
						position.width = num;
						GUI.Box(position, "", style);
					}
				}
			}
			GUI.backgroundColor = backgroundColor;
		}

		public LevelConfig GetDebugLevelOverride()
		{
			string stringValue = _developerConfig["Startup"]["LevelToLoad"].StringValue;
			LevelConfig levelConfig = Metagame.LevelList.GetLevelConfigByDisplayName(stringValue);
			if (levelConfig == null)
			{
				levelConfig = Metagame.LevelList.GetLevelConfigByID(stringValue);
			}
			return levelConfig;
		}

		private ConsoleCommandResult Debug_UGCAddWallDiffuseTexture(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Filepath to png or jpg expected");
			}
			string contentID = args[0];
			byte[] data = File.ReadAllBytes(args[1]);
			Texture2D texture2D = new Texture2D(512, 512);
			texture2D.LoadImage(data, markNonReadable: false);
			_ugcWallVisualOverrideDefinitionDatabase.SetDiffuseTexture(contentID, texture2D);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCAddFloorDiffuseTexture(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Filepath to png or jpg expected");
			}
			string contentID = args[0];
			byte[] data = File.ReadAllBytes(args[1]);
			Texture2D texture2D = new Texture2D(512, 512);
			texture2D.LoadImage(data, markNonReadable: false);
			_ugcFloorVisualOverrideDefinitionDatabase.SetDiffuseTexture(contentID, texture2D);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCCreateAndSetWallVisualOverrideOnGPOffices(string[] args)
		{
			if (Metagame == null)
			{
				return ConsoleCommandResult.Failed("No Metagame available");
			}
			if (Metagame.CurrentLevel == null)
			{
				return ConsoleCommandResult.Failed("No CurrentLevel available");
			}
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC = new WallVisualOverrideDefinitionUGC(args[0], _ugcWallVisualOverrideDefinitionDatabase);
			Metagame.CurrentLevel.WallVisualOverrideDefinitionUGCs.Add(wallVisualOverrideDefinitionUGC);
			Metagame.CurrentLevel.UGCDefinitionsFixUp.AddWallVisualOverride(wallVisualOverrideDefinitionUGC);
			Metagame.CurrentLevel.RoomCustomisations.SetDefaultWallVisualOverride(RoomDefinition.Type.GPOffice, wallVisualOverrideDefinitionUGC);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCCreateAndSetFloorVisualOverrideOnGPOffices(string[] args)
		{
			if (Metagame == null)
			{
				return ConsoleCommandResult.Failed("No Metagame available");
			}
			if (Metagame.CurrentLevel == null)
			{
				return ConsoleCommandResult.Failed("No CurrentLevel available");
			}
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC = new FloorVisualOverrideDefinitionUGC(args[0], _ugcFloorVisualOverrideDefinitionDatabase);
			Metagame.CurrentLevel.FloorVisualOverrideDefinitionUGCs.Add(floorVisualOverrideDefinitionUGC);
			Metagame.CurrentLevel.UGCDefinitionsFixUp.AddFloorVisualOverride(floorVisualOverrideDefinitionUGC);
			Metagame.CurrentLevel.RoomCustomisations.SetDefaultFloorVisualOverride(RoomDefinition.Type.GPOffice, floorVisualOverrideDefinitionUGC);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCSetRuntimePrefab(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Filepath to png or jpg expected");
			}
			string text = "Picture Canvas 1";
			string contentID = args[0];
			byte[] data = File.ReadAllBytes(args[1].Replace("\"", ""));
			Texture2D texture2D = new Texture2D(512, 512);
			texture2D.LoadImage(data, markNonReadable: false);
			RoomItemDefinition roomItemDefinition = null;
			SharedInstance_TH20TH20_RoomItemDefinition[] array = Resources.FindObjectsOfTypeAll<SharedInstance_TH20TH20_RoomItemDefinition>();
			foreach (SharedInstance_TH20TH20_RoomItemDefinition sharedInstance_TH20TH20_RoomItemDefinition in array)
			{
				if (sharedInstance_TH20TH20_RoomItemDefinition.Instance.DebugTag == text)
				{
					roomItemDefinition = sharedInstance_TH20TH20_RoomItemDefinition.Instance;
					break;
				}
			}
			if (roomItemDefinition == null)
			{
				return ConsoleCommandResult.Failed(string.Format("Could not find RoomItemDefinition with a DebugTag of \"{0}\", tag"));
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(roomItemDefinition.GetPrefab(), _ugcRuntimePrefabManager.RuntimePrefabRoot.transform);
			gameObject.name = roomItemDefinition.GetPrefab().name;
			gameObject.name += "(UGC Runtime Prefab)";
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				Material[] materials = renderer.materials;
				for (int j = 0; j < materials.Length; j++)
				{
					materials[0].SetTexture("_MainTex", texture2D);
				}
				renderer.sharedMaterials = materials;
			}
			_ugcRuntimePrefabManager.AddOrReplaceRuntimePrefab(new UGCRuntimePrefabKey(contentID, 0), gameObject);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCRoomItemSetIcon(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Filepath to png or jpg expected");
			}
			string contentID = args[0];
			byte[] data = File.ReadAllBytes(args[1].Replace("\"", ""));
			Texture2D texture2D = new Texture2D(512, 512);
			texture2D.LoadImage(data, markNonReadable: false);
			Sprite icon = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
			_ugcRoomItemDefinitionDatabase.SetIcon(contentID, icon);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCRoomItemSetCost(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			if (args.Length < 2)
			{
				return ConsoleCommandResult.Failed("Cost parameter expected");
			}
			string contentID = args[0];
			int cost = int.Parse(args[1]);
			_ugcRoomItemDefinitionDatabase.SetCost(contentID, cost);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_UGCCreateNewRoomItem(string[] args)
		{
			if (Metagame == null)
			{
				return ConsoleCommandResult.Failed("No Metagame available");
			}
			if (Metagame.CurrentLevel == null)
			{
				return ConsoleCommandResult.Failed("No CurrentLevel available");
			}
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("ContentID parameter needed to create new UGC asset");
			}
			string text = "Picture Canvas 1";
			string contentID = args[0];
			RoomItemDefinition roomItemDefinitionBase = null;
			SharedInstance_TH20TH20_RoomItemDefinition[] array = Resources.FindObjectsOfTypeAll<SharedInstance_TH20TH20_RoomItemDefinition>();
			foreach (SharedInstance_TH20TH20_RoomItemDefinition sharedInstance_TH20TH20_RoomItemDefinition in array)
			{
				if (sharedInstance_TH20TH20_RoomItemDefinition.Instance.DebugTag == text)
				{
					roomItemDefinitionBase = sharedInstance_TH20TH20_RoomItemDefinition.Instance;
					break;
				}
			}
			RoomItemDefinitionUGC roomItemDefinitionUGC = new RoomItemDefinitionUGC(contentID, roomItemDefinitionBase, _ugcRuntimePrefabManager, _ugcRoomItemDefinitionDatabase);
			Metagame.CurrentLevel.WorldState.AvailableRoomItems.Add(roomItemDefinitionUGC);
			Metagame.CurrentLevel.UGCDefinitionsFixUp.AddRoomItem(roomItemDefinitionUGC);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_SetFullScreenMode(string[] args)
		{
			if (args.Length < 1)
			{
				return ConsoleCommandResult.Failed("Parameter required ExclusiveFullScreen | FullScreenWindow | MaximizedWindow | Windowed");
			}
			if (!Enum.TryParse<FullScreenMode>(args[0], ignoreCase: true, out var result))
			{
				return ConsoleCommandResult.Failed("Invalid parameter specified " + args[0]);
			}
			Screen.SetResolution(Screen.width, Screen.height, result);
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_PrintDisplayInfo(string[] args)
		{
			return ConsoleCommandResult.Succeeded($"FullScreenMode: {Screen.fullScreenMode}, RunInBackground: {Application.runInBackground}, Resolution: {Screen.width}X{Screen.height}");
		}
	}
}
