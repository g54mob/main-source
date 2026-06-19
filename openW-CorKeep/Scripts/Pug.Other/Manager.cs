using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HarmonyLib;
using I2.Loc;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugMod;
using PugTilemap;
using Unity.Entities;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	[ClearOnReload]
	private static bool _DEBUG_MODE = false;

	[ClearOnReload]
	private static bool _DEMO_MODE = false;

	[ClearOnReload]
	private static bool okayToQuit;

	[ClearOnReload]
	private static PlatformInterface _platformInterface;

	[ClearOnReload]
	private static FilesystemInterface _filesystemInterface;

	[ClearOnReload]
	private static List<IModPlatform> _modLoaders;

	private const string _pidFileName = "PID.txt";

	public static bool enableConsole = false;

	protected List<ManagerBase> _allManagers = new List<ManagerBase>();

	private static Manager _instance;

	[Header("Manager references:")]
	[SerializeField]
	protected PlatformManager _platformManager;

	[SerializeField]
	protected FilesystemManager _filesystemManager;

	[SerializeField]
	protected PrefsManager _prefsManager;

	[SerializeField]
	protected SaveManager _saveManager;

	[SerializeField]
	protected ModManager _modManager;

	[SerializeField]
	protected LoadManager _loadManager;

	[SerializeField]
	protected EffectsManager _effectsManager;

	[SerializeField]
	protected PhysicsManager _physicsManager;

	[SerializeField]
	protected UpdateManager _updateManager;

	[SerializeField]
	protected MemoryManager _memoryManager;

	[SerializeField]
	protected CameraManager _cameraManager;

	[SerializeField]
	protected MusicManager _musicManager;

	[SerializeField]
	protected AudioManager _audioManager;

	[SerializeField]
	protected ManagerBase _controlMappingManager;

	[SerializeField]
	protected InputManager _inputManager;

	[SerializeField]
	protected TextManager _textManager;

	[SerializeField]
	protected MenuManager _menuManager;

	[SerializeField]
	protected UIManager _uiManager;

	[SerializeField]
	protected AchievementsManager _achievementsManager;

	[SerializeField]
	protected WorldGenManager _worldGenManager;

	[SerializeField]
	protected NetworkingManager _networkingManager;

	[SerializeField]
	protected ECSManager _ecsManager;

	[SerializeField]
	protected RGBManager _rgbManager;

	[SerializeField]
	protected LightManager _lightManager;

	[SerializeField]
	protected TraceManager _traceManager;

	[SerializeField]
	protected StreamManager _streamManager;

	private static readonly Regex versionRegex = new Regex("^(\\d+)\\.(\\d+)\\.(\\d+)");

	public static string version;

	public static string minorVersion;

	public static string fullVersion;

	private static List<IEnumerator> _startAfterInitComplete = new List<IEnumerator>();

	private SinglePugMap _map;

	private bool _managersInitialized;

	private List<string> _issuesDuringStartup = new List<string>();

	public static bool DEBUG_MODE => _DEBUG_MODE;

	public static bool DEMO_MODE => _DEMO_MODE;

	public List<ManagerBase> allManagers => _allManagers;

	public SceneHandler currentSceneHandler { get; set; }

	public static Manager main => _instance;

	public static PlatformManager platform => main._platformManager;

	public static FilesystemManager filesystemManager => main._filesystemManager;

	public static PrefsManager prefs => main._prefsManager;

	public static SaveManager saves => main._saveManager;

	public static LoadManager load => main._loadManager;

	public static ModManager mod => main._modManager;

	public static EffectsManager effects => main._effectsManager;

	public static PhysicsManager physics => main._physicsManager;

	public static UpdateManager update => main._updateManager;

	public static MemoryManager memory => main._memoryManager;

	public static CameraManager camera => main._cameraManager;

	public static MusicManager music => main._musicManager;

	public static AudioManager audio => main._audioManager;

	public static InputManager input => main._inputManager;

	public static ManagerBase controlMapping => main._controlMappingManager;

	public static TextManager text => main._textManager;

	public static MenuManager menu => main._menuManager;

	public static UIManager ui => main._uiManager;

	public static AchievementsManager achievements => main._achievementsManager;

	public static NetworkingManager networking => main._networkingManager;

	public static WorldGenManager worldGen => main._worldGenManager;

	public static ECSManager ecs => main._ecsManager;

	public static RGBManager rgb => main._rgbManager;

	public static LightManager lights => main._lightManager;

	public static TraceManager trace => main._traceManager;

	public static StreamManager stream => main._streamManager;

	public static SceneHandler sceneHandler => main.currentSceneHandler;

	public static SinglePugMap multiMap => main._map;

	public PlayerController player { get; set; }

	public List<PlayerController> nonLocalPlayers { get; set; } = new List<PlayerController>();

	public List<PlayerController> allPlayers { get; set; } = new List<PlayerController>();

	public bool Initialized => _managersInitialized;

	public static event Action afterQuitHandlers;

	public static event Func<bool> wantsToQuit;

	private static void WaitForPid(string pidString)
	{
		int result = 0;
		if (int.TryParse(pidString, out result))
		{
			Process.GetProcessById(result).WaitForExit();
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void ResetEvents()
	{
		Manager.afterQuitHandlers = null;
		Manager.wantsToQuit = null;
		Application.quitting -= OnQuit;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	private static void EarlyInit()
	{
		LogSystemInfoAtStartup();
		LoadManager.SetCpuLoadPriority(prioritizeLoading: true);
		string text = null;
		QualitySettings.maxQueuedFrames = 2;
		Application.wantsToQuit += WantsToQuitHandler;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 30;
		Application.quitting += OnQuit;
		CommandLineArgs.Init(Environment.GetCommandLineArgs());
		if (CommandLineArgs.Has("-waitfor"))
		{
			try
			{
				WaitForPid(CommandLineArgs.GetParam("-waitfor"));
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}
		new Harmony("CoreKeeperDefaultPatches").PatchAll(typeof(MissingBurstFunctionFallback_v1_8_25));
		PlatformInterface platformInterface = null;
		PlatformInterface platformInterface3;
		if (1 == 0)
		{
			PlatformInterface platformInterface2 = new StandalonePlatform();
			platformInterface3 = platformInterface2;
		}
		else
		{
			PlatformInterface platformInterface2 = new SteamPlatform();
			platformInterface3 = platformInterface2;
		}
		platformInterface = platformInterface3;
		if (platformInterface != null && !platformInterface.Init())
		{
			UnityEngine.Debug.LogError("Platform init " + platformInterface.Name + " failed");
			platformInterface = null;
		}
		if (platformInterface != null)
		{
			platformInterface.Update();
			CommandLineArgs.Init(platformInterface.GetCommandLine());
			_platformInterface = platformInterface;
			text = platformInterface.SavePrefix;
			FilesystemInterface filesystemInterface = new StandaloneFilesystem(text, _platformInterface);
			API.ConfigFilesystem = new StandaloneFilesystem(text, "mods", _platformInterface);
			API.ConfigFilesystem.Write("README.txt", Encoding.UTF8.GetBytes("This directory is used for mod configuration files.\n\nMODS ARE NOT LOADED FROM HERE"));
			_filesystemInterface = filesystemInterface;
			if (CommandLineArgs.Has("-extralog"))
			{
				string environmentVariable = Environment.GetEnvironmentVariable("PUG_MOD_CSHARP_DEFINES");
				Environment.SetEnvironmentVariable("PUG_MOD_CSHARP_DEFINES", environmentVariable + ";ENABLE_UNITY_COLLECTIONS_CHECKS");
			}
			PlatformConfiguration.Init();
			bool num = CommandLineArgs.Has("-safemode");
			API.Rendering = new ModAPIRendering();
			API.Client = new ModAPIClient();
			API.Server = new ModAPIServer();
			API.Authoring = new ModAPIAuthoring();
			API.Localization = new ModAPILocalization();
			API.Config = new ModAPIConfig(API.ConfigFilesystem);
			API.ModLoader = new ModAPIModLoader();
			API.Reflection = new ModAPIReflection();
			API.Experimental = new ModAPIExperimental();
			_modLoaders = new List<IModPlatform>();
			if (!num)
			{
				_modLoaders.Add(new SideLoader());
			}
			string userIdentifier;
			if (!num)
			{
				userIdentifier = ((_platformInterface == null) ? Environment.UserName : (_platformInterface.Name + ":" + _platformInterface.GetAccountId()));
				_modLoaders.Add(new ModIOLoader(userIdentifier));
			}
			userIdentifier = Environment.UserName;
			_modLoaders.Add(new SteamWorkshopLoader(userIdentifier));
			StandaloneFilesystem configFilesystem = new StandaloneFilesystem(text, "modloader", _platformInterface);
			Integration.Instance.Init(configFilesystem);
			foreach (IModPlatform modLoader in _modLoaders)
			{
				modLoader.Init();
			}
			ModManager.EarlyInit();
			SpriteInstancingModAssetProcessor.Init();
			Integration.Instance.Update();
			SpriteInstancingModAssetProcessor.Done();
		}
		else
		{
			UnityEngine.Debug.LogError("No platform interface available after initialization! Shutting down...");
			QuitGame();
		}
	}

	private static void LogSystemInfoAtStartup()
	{
		UnityEngine.Debug.Log("--- Startup info ---\n" + $"Time (UTC): {DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}\n" + "Game version: " + Application.version + "\nUnity version: " + Application.unityVersion + "\nOS version: " + SystemInfo.operatingSystem + "\n" + $"Graphics device: {SystemInfo.graphicsDeviceName} ({SystemInfo.graphicsDeviceType}, {SystemInfo.graphicsDeviceVersion})\n" + "--- END Startup info ---");
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void PreLaunch()
	{
		if (_platformInterface == null)
		{
			UnityEngine.Debug.LogError("PlatformInterface is null in Manager.PreLaunch. Shutting down...");
			QuitGame();
			return;
		}
		if (!_platformInterface.BeforeSceneLoad())
		{
			UnityEngine.Debug.LogError("PlatformInterface.BeforeSceneLoad failed. Shutting down...");
			QuitGame();
			return;
		}
		Match match = versionRegex.Match(Application.version);
		if (!match.Success)
		{
			UnityEngine.Debug.LogWarning("failed to match version " + Application.version + " to regex");
			version = "";
			minorVersion = Application.version;
		}
		else
		{
			version = match.Groups[0].Value;
			minorVersion = Application.version.Substring(version.Length, Application.version.Length - version.Length);
		}
		fullVersion = version + minorVersion;
		if (SystemRequirements.Check())
		{
			UnityEngine.Debug.Log("Checking system requirements: PASS");
		}
		else
		{
			UnityEngine.Debug.LogError("Checking system requirements: FAIL");
			foreach (string error in SystemRequirements.errors)
			{
				UnityEngine.Debug.LogError(error);
			}
			UnityEngine.Debug.LogError("System requirements not met: Game will probably not run correctly (missing/broken visuals etc.)");
		}
		if (!(SceneManager.GetActiveScene().name == "Loading"))
		{
			if (null == UnityEngine.Object.FindObjectOfType<SceneHandler>(includeInactive: true))
			{
				UnityEngine.Debug.Log("There is no scene handler in this scene. Skipping automatic Manager prelaunch.");
				return;
			}
			UnityEngine.Debug.Log("Manager prelaunch and GO initialization starting...");
			InitializeGlobalManagerInstantly();
		}
	}

	private static void InitializeGlobalManagerInstantly()
	{
		foreach (float item in InitializeGlobalManager(allowAsyncOperations: false))
		{
			_ = item;
		}
	}

	public static IEnumerable<float> InitializeGlobalManager(bool allowAsyncOperations)
	{
		UnityEngine.Debug.Log("Initialize global manager");
		if (!UnityMainThreadDispatcher.Exists())
		{
			new GameObject("UnityMainThreadDispatcher").AddComponent<UnityMainThreadDispatcher>();
		}
		SpriteTempEffectID.Init();
		SortingLayerID.Init();
		ObjectLayerID.Init();
		ObjectLayerMask.Init();
		Yielders.Init();
		Tween.Init();
		float progress = 0f;
		while (!_filesystemInterface.IsInitialized)
		{
			UnityEngine.Debug.Log("Manager.InitializeGlobalManager: waiting for file system interface to initialize.");
			yield return progress;
		}
		progress += 0.05f;
		if (!ScriptableData.isLoaded)
		{
			if (!allowAsyncOperations)
			{
				ScriptableData.Load();
			}
			else
			{
				Task scriptableDataLoadTask = ScriptableData.LoadAsync();
				while (!scriptableDataLoadTask.IsCompleted)
				{
					yield return progress;
				}
				if (!scriptableDataLoadTask.IsCompletedSuccessfully)
				{
					UnityEngine.Debug.LogError("Error during ScriptableData async initialization");
					if (scriptableDataLoadTask.Exception != null)
					{
						UnityEngine.Debug.LogException(scriptableDataLoadTask.Exception);
					}
				}
			}
		}
		if (!ScriptableData.isLoaded)
		{
			UnityEngine.Debug.LogError("Failed to load ScriptableData, stopping init");
			if (!CommandLineArgs.Has("-safemode") && Integration.Instance.LoadedMods.Any())
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("-safemode", "");
				dictionary.Add("-showforcedsafemodeinfo", "");
				_platformInterface.Restart(dictionary);
			}
			else
			{
				QuitGame();
			}
			yield break;
		}
		LocalizationManager.InitializeIfNeeded();
		LanguageSourceData i2LanguageData = LocalizationManager.Sources[1];
		IReadOnlyList<TextDataBlock> dataBlocks = ScriptableData.GetDataBlocks<TextDataBlock>();
		IReadOnlyList<LanguageDataBlock> dataBlocks2 = ScriptableData.GetDataBlocks<LanguageDataBlock>();
		if (!I2TextDataBlockImporter.TryImport(i2LanguageData, dataBlocks, dataBlocks2))
		{
			UnityEngine.Debug.LogError("I2 TextDataBlock AutoImport failed");
		}
		progress += 0.05f;
		yield return progress;
		SpriteAssetManager.LoadAndCompile();
		progress += 0.05f;
		yield return progress;
		UnityEngine.Debug.Log("Global manager Resources.Load");
		GameObject globalObjectsResource = null;
		foreach (float item in LoadGlobalObjects(allowAsyncOperations, delegate(GameObject go)
		{
			globalObjectsResource = go;
		}))
		{
			yield return progress + 0.05f * item;
		}
		progress += 0.05f;
		globalObjectsResource.SetActive(value: false);
		_instance = UnityEngine.Object.Instantiate(globalObjectsResource).GetComponent<Manager>();
		_startAfterInitComplete = new List<IEnumerator>();
		foreach (float item2 in _instance.InitializeManagers())
		{
			yield return progress + 0.79999995f * item2;
		}
		if (!_instance.Initialized)
		{
			UnityEngine.Debug.LogError("Manager failed to initialize properly. Check previous log messages for errors. Exiting...");
			CreateGeneralServerFailMessage();
			if (!CommandLineArgs.Has("-safemode") && Integration.Instance.LoadedMods.Any())
			{
				Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
				dictionary2.Add("-safemode", "");
				dictionary2.Add("-showforcedsafemodeinfo", "");
				_platformInterface.Restart(dictionary2);
			}
			else
			{
				Application.Quit();
			}
		}
		else
		{
			_instance.gameObject.SetActive(value: true);
			while (_startAfterInitComplete != null && _startAfterInitComplete.Count > 0)
			{
				_instance.StartCoroutine(_startAfterInitComplete[0]);
				_startAfterInitComplete.RemoveAt(0);
			}
			_startAfterInitComplete = null;
		}
	}

	private static IEnumerable<float> LoadGlobalObjects(bool useAsyncLoading, Action<GameObject> onLoaded)
	{
		string globalObjectsPath = "Global Objects (Main Manager)";
		if (!useAsyncLoading)
		{
			onLoaded?.Invoke(Resources.Load<GameObject>(globalObjectsPath));
			yield break;
		}
		ResourceRequest resourceRequest = Resources.LoadAsync<GameObject>(globalObjectsPath);
		UnityEngine.Debug.Log("Manager: started resources load for " + globalObjectsPath + ".");
		while (!resourceRequest.isDone)
		{
			yield return resourceRequest.progress;
		}
		UnityEngine.Debug.Log("Manager: resources load for " + globalObjectsPath + " finished.");
		GameObject obj = resourceRequest.asset as GameObject;
		onLoaded?.Invoke(obj);
	}

	private static void LogSpritePackingInfo()
	{
		SpriteInstancingManager.AtlasStats atlasStats = SpriteInstancingManager.atlasStats;
		if (!atlasStats.isValid)
		{
			UnityEngine.Debug.LogError("SpriteInstancing atlas has not been packed!");
		}
		else if (atlasStats.emptySpacePercent > 5f)
		{
			string message = "Sprite instancing atlas packing could be improved. " + $"Empty space: {atlasStats.emptySpacePercent:0.0}% (max recommended {5f:0.0}%). " + "Check Sprite Asset Debugger window to debug.";
			if (atlasStats.emptySpacePercent > 10f)
			{
				UnityEngine.Debug.LogError(message);
			}
			else
			{
				UnityEngine.Debug.LogWarning(message);
			}
		}
	}

	public static void FindAndAssignMultiMap()
	{
		main._map = UnityEngine.Object.FindObjectOfType<SinglePugMap>();
	}

	protected virtual void AddSpecializedManagers()
	{
		_allManagers.Add(_platformManager);
		_allManagers.Add(_filesystemManager);
		_allManagers.Add(_prefsManager);
		_allManagers.Add(_saveManager);
		_allManagers.Add(_updateManager);
		_allManagers.Add(_memoryManager);
		_allManagers.Add(_physicsManager);
		_allManagers.Add(_loadManager);
		_allManagers.Add(_modManager);
		_allManagers.Add(_cameraManager);
		_allManagers.Add(_lightManager);
		_allManagers.Add(_musicManager);
		_allManagers.Add(_audioManager);
		_allManagers.Add(_inputManager);
		_allManagers.Add(_controlMappingManager);
		_allManagers.Add(_effectsManager);
		_allManagers.Add(_textManager);
		_allManagers.Add(_menuManager);
		_allManagers.Add(_uiManager);
		_allManagers.Add(_achievementsManager);
		_allManagers.Add(_worldGenManager);
		_allManagers.Add(_networkingManager);
		_allManagers.Add(_ecsManager);
		_allManagers.Add(_rgbManager);
		_allManagers.Add(_traceManager);
		_allManagers.Add(_streamManager);
	}

	protected virtual void Awake()
	{
	}

	private IEnumerable<float> InitializeManagers()
	{
		Stopwatch.StartNew();
		float progress = 0f;
		UnityEngine.Debug.Log("Start initializing all managers");
		if (_instance != this && _instance != null)
		{
			UnityEngine.Debug.LogWarning("There already exists a global Manager! Destroying the new one (this).", this);
			UnityEngine.Object.DestroyImmediate(base.gameObject);
			yield break;
		}
		_platformManager.platformImpl = _platformInterface;
		_filesystemManager.platformImpl = _filesystemInterface;
		if (_modLoaders != null)
		{
			_modManager.ModPlatforms.AddRange(_modLoaders);
		}
		Application.runInBackground = true;
		_instance = this;
		PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
		PlayerLoopSystem playerLoopSystem = default(PlayerLoopSystem);
		bool flag = false;
		for (int i = 0; i < currentPlayerLoop.subSystemList.Length; i++)
		{
			if (!(currentPlayerLoop.subSystemList[i].type == typeof(EarlyUpdate)))
			{
				continue;
			}
			PlayerLoopSystem[] subSystemList = currentPlayerLoop.subSystemList[i].subSystemList;
			PlayerLoopSystem[] array = new PlayerLoopSystem[subSystemList.Length - 1];
			int num = 0;
			for (int j = 0; j < subSystemList.Length; j++)
			{
				if (subSystemList[j].type == typeof(EarlyUpdate.PlayerCleanupCachedData))
				{
					playerLoopSystem = subSystemList[j];
					flag = true;
				}
				else if (num < array.Length)
				{
					array[num++] = subSystemList[j];
				}
			}
			if (flag)
			{
				currentPlayerLoop.subSystemList[i].subSystemList = array;
			}
		}
		if (flag)
		{
			for (int k = 0; k < currentPlayerLoop.subSystemList.Length; k++)
			{
				if (!(currentPlayerLoop.subSystemList[k].type == typeof(PreLateUpdate)))
				{
					continue;
				}
				PlayerLoopSystem[] subSystemList2 = currentPlayerLoop.subSystemList[k].subSystemList;
				PlayerLoopSystem[] array2 = new PlayerLoopSystem[subSystemList2.Length + 1];
				int num2 = 0;
				for (int l = 0; l < subSystemList2.Length; l++)
				{
					if (subSystemList2[l].type == typeof(PreLateUpdate.EndGraphicsJobsAfterScriptUpdate))
					{
						array2[num2++] = playerLoopSystem;
					}
					array2[num2++] = subSystemList2[l];
				}
				currentPlayerLoop.subSystemList[k].subSystemList = array2;
			}
		}
		PlayerLoop.SetPlayerLoop(currentPlayerLoop);
		AddSpecializedManagers();
		int processorCount = SystemInfo.processorCount;
		if (JobsUtility.JobWorkerCount > processorCount - 1)
		{
			JobsUtility.ResetJobWorkerCount();
		}
		UnityEngine.Debug.Log("Core count is " + processorCount);
		UnityEngine.Debug.Log("Job worker count is " + JobsUtility.JobWorkerCount);
		float setupProgress = 0f;
		foreach (ManagerBase allManager in _allManagers)
		{
			bool flag2;
			try
			{
				flag2 = allManager.Setup();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				flag2 = false;
			}
			if (!flag2)
			{
				UnityEngine.Debug.LogErrorFormat("Setup failed for {0}", allManager.name);
				yield break;
			}
			setupProgress += 1f / (float)_allManagers.Count;
			yield return progress + 0.1f * setupProgress;
		}
		progress += 0.1f;
		float startupProgress = 0f;
		foreach (ManagerBase allManager2 in _allManagers)
		{
			bool flag3;
			try
			{
				flag3 = allManager2.Init();
			}
			catch (Exception exception2)
			{
				UnityEngine.Debug.LogException(exception2);
				flag3 = false;
			}
			if (!flag3)
			{
				UnityEngine.Debug.LogErrorFormat("Init failed for {0}", allManager2.name);
				yield break;
			}
			startupProgress += 1f / (float)_allManagers.Count;
			yield return progress + 0.9f * startupProgress;
		}
		if (CommandLineArgs.Has("-versionsuffix"))
		{
			string param = CommandLineArgs.GetParam("-versionsuffix");
			if (param != null)
			{
				UnityEngine.Debug.Log("Using version suffix: " + param);
				version += param;
			}
		}
		Cursor.visible = false;
		int customWindowScale = CommandLineArgs.GetCustomWindowScale();
		if (customWindowScale > 0)
		{
			Screen.SetResolution(customWindowScale * 480, customWindowScale * 270, fullscreen: false);
		}
		CrashReportHandler.enableCaptureExceptions = CrashReportHandler.enableCaptureExceptions && !CommandLineArgs.Has("-nonetwork");
		Profiler.maxUsedMemory = 1073741824;
		_achievementsManager.InitializeAchievements();
		_managersInitialized = true;
	}

	private static void CancelInitialization(ManagerBase specializedManager)
	{
		UnityEngine.Debug.LogErrorFormat("{0} aborted setup, exiting...", specializedManager.name);
		QuitGame();
	}

	private static void QuitHandler()
	{
		UnityEngine.Debug.Log("Running quit handlers");
		if (main != null)
		{
			for (int num = main._allManagers.Count - 1; num >= 0; num--)
			{
				ManagerBase managerBase = main._allManagers[num];
				try
				{
					managerBase.Deinit();
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
				}
			}
			if (ecs.BlobAssetStore.IsCreated)
			{
				ecs.BlobAssetStore.Dispose();
				ecs.BlobAssetStore = default(BlobAssetStore);
			}
		}
		Manager.afterQuitHandlers?.Invoke();
		if (File.Exists("PID.txt"))
		{
			File.Delete("PID.txt");
		}
	}

	private static bool WantsToQuitHandler()
	{
		UnityEngine.Debug.Log("Got quit request");
		bool flag = true;
		if (Manager.wantsToQuit != null)
		{
			Delegate[] invocationList = Manager.wantsToQuit.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				Func<bool> func = (Func<bool>)invocationList[i];
				try
				{
					if (func())
					{
						continue;
					}
				}
				catch (Exception exception)
				{
					UnityEngine.Debug.LogException(exception);
					continue;
				}
				UnityEngine.Debug.Log("Exit blocked by " + func.Target.GetType());
				flag = false;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.Log("Quit blocked");
		}
		okayToQuit = flag;
		return flag;
	}

	private static void OnQuit()
	{
		if (okayToQuit)
		{
			QuitHandler();
		}
	}

	private void Update()
	{
		int num = (Application.isFocused ? (prefs.vsync ? 1 : 0) : 0);
		int maxQueuedFrames = prefs.maxQueuedFrames;
		int num2 = (Application.isFocused ? prefs.targetFrameRate : Mathf.Max(30, PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate));
		if (num != QualitySettings.vSyncCount)
		{
			QualitySettings.vSyncCount = num;
		}
		if (num == 0 && num2 != Application.targetFrameRate)
		{
			Application.targetFrameRate = num2;
		}
		if (maxQueuedFrames != QualitySettings.maxQueuedFrames)
		{
			QualitySettings.maxQueuedFrames = maxQueuedFrames;
		}
	}

	public static void RunAfterInitComplete(IEnumerator iEnumerator)
	{
		if (main != null && main.isActiveAndEnabled)
		{
			main.StartCoroutine(iEnumerator);
		}
		else
		{
			_startAfterInitComplete.Add(iEnumerator);
		}
	}

	public void AddArgumentStartupIssue(string argument, string extraInfo = "")
	{
		if (extraInfo == null)
		{
			extraInfo = "";
		}
		AddStartupIssue("Ignoring " + argument + " argument, because \"" + CommandLineArgs.GetParam(argument) + "\" is not valid value for this option. " + extraInfo);
	}

	public void AddStartupIssue(string issueDescription)
	{
		_issuesDuringStartup.Add(issueDescription);
	}

	public string StartupIssueList()
	{
		return string.Join("\n", _issuesDuringStartup);
	}

	private static bool IsPreviousServerRunning()
	{
		bool num = CheckPIDFile();
		if (!num)
		{
			File.WriteAllText("PID.txt", Process.GetCurrentProcess().Id.ToString());
		}
		return num;
	}

	private static bool CheckPIDFile()
	{
		if (File.Exists("PID.txt"))
		{
			if (!int.TryParse(File.ReadAllText("PID.txt"), out var result))
			{
				return false;
			}
			try
			{
				Process processById = Process.GetProcessById(result);
				Process currentProcess = Process.GetCurrentProcess();
				if (processById != null && processById.MainModule.FileName == currentProcess.MainModule.FileName)
				{
					return true;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		return false;
	}

	private static void CreateGeneralServerFailMessage()
	{
	}

	public static void QuitGame()
	{
		Application.Quit();
	}
}
