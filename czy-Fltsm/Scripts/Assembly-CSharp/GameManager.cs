using System.Collections;
using System.Collections.Generic;
using M4.Session;
using MiniJSON;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam;
using PajamaLlama.Flotsam.Performance;
using PajamaLlama.SurvivalGuide;
using PajamaLlama.Utilities;
using UnityEngine;

[RequireComponent(typeof(GraphManager))]
[RequireComponent(typeof(PhysicsManager), typeof(StoryManager))]
[RequireComponent(typeof(WorldManager), typeof(TimeManager))]
[RequireComponent(typeof(AgentManager))]
[RequireComponent(typeof(CursorManager))]
[RequireComponent(typeof(SurvivalGuideManager))]
[RequireComponent(typeof(WorldMapManager))]
public class GameManager : SceneBehaviour
{
	public delegate IEnumerator ManagerCoroutine();

	[SerializeField]
	[Tooltip("A boolean that has to be set for the intro scene so it does not initialize unused managers causing errors.")]
	private bool _isIntroScene;

	[SerializeField]
	private bool _initializeEnvironment = true;

	[Header("Settings")]
	[SerializeField]
	private GameSettings _settings;

	public static Environment EnvironmentInstance = null;

	public static WorldManager WorldManager = null;

	public static ResourceManager ResourceManager = null;

	public static TimeManager TimeManager = null;

	public static AgentManager AgentManager = null;

	public static UIManager UIManager = null;

	public static AudioManager AudioManager = null;

	public static PersistenceManager PersistenceManager = null;

	public static StoryManager StoryManager = null;

	public static readonly RadioMessagesManager RadioMessagesManager = new RadioMessagesManager();

	public static FlotsamInputManager InputManager = null;

	public static PhysicsManager PhysicsManager = null;

	public static GraphManager GraphManager = null;

	public static readonly GameStatsManager GameStatsManager = new GameStatsManager();

	public static AnalyticsManager AnalyticsManager = null;

	public static WorldMapManager WorldMapManager = null;

	public static TerrainManager TerrainManager = null;

	public static EffectsManager EffectsManager = null;

	public static HighlightManager HighlightManager = null;

	public static UpdateManager UpdateManager = null;

	public static CursorManager CursorManager = null;

	public static ExpertiseManager ExpertiseManager = null;

	public static SurvivalGuideManager SurvivalGuideManager = null;

	public static PrefabManager PrefabManager = null;

	public static MainMenu MainMenu = null;

	public static string UnityCloudVersion = "0.0.0";

	private bool _initialized;

	private StatsAndAchievementsManager _statsAndAchievementsManager;

	public static bool Initialized
	{
		get
		{
			if (Instance != null)
			{
				return Instance._initialized;
			}
			return false;
		}
	}

	public static GameManager Instance { get; private set; }

	public static GameSettings Settings { get; private set; }

	public bool IntroScene => _isIntroScene;

	public bool InitializeEnvironment => _initializeEnvironment;

	public static bool Gamepaused
	{
		get
		{
			if (!(UIManager != null))
			{
				return Time.timeScale == 0f;
			}
			return UIManager.IsPaused;
		}
	}

	public static bool IsQuittingToDesktop { get; private set; } = false;

	public Dictionary<string, object> BuildManifest { get; private set; } = new Dictionary<string, object>();

	protected override void Awake()
	{
		LoadBuildManifest();
		Debug.Log($">>> Current version: {Application.version} <<<");
		InitializeReferences();
		LoadingScreen.AddTask(InitializeManagers, "InitializeManagers");
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, GameStart);
		GameEventDispatcher.RemoveListener(GameEventType.GameEnd, ClearManagers);
		RadioMessagesManager?.OnDestroy();
	}

	private void GameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, GameStart);
		if (!_initialized)
		{
			GameEventDispatcher.AddListener(GameEventType.GameEnd, ClearManagers);
		}
		_initialized = true;
	}

	private void InitializeReferences()
	{
		Instance = this;
		GameSettings.SetInstance(_settings);
		Settings = _settings;
		GameSpeedManager.Reset();
		WorldManager = GetComponent<WorldManager>();
		ResourceManager = GetComponent<ResourceManager>();
		TimeManager = GetComponent<TimeManager>();
		UIManager = Object.FindAnyObjectByType<UIManager>();
		AgentManager = GetComponent<AgentManager>();
		AudioManager = GetComponent<AudioManager>();
		PersistenceManager = GetComponent<PersistenceManager>();
		StoryManager = GetComponent<StoryManager>();
		PhysicsManager = GetComponent<PhysicsManager>();
		GraphManager = GetComponent<GraphManager>();
		AnalyticsManager = GetComponent<AnalyticsManager>();
		TerrainManager = GetComponent<TerrainManager>();
		WorldMapManager = GetComponent<WorldMapManager>();
		EffectsManager = GetComponent<EffectsManager>();
		HighlightManager = GetComponent<HighlightManager>();
		UpdateManager = GetComponent<UpdateManager>();
		CursorManager = GetComponent<CursorManager>();
		MainMenu = Object.FindAnyObjectByType<MainMenu>();
		SurvivalGuideManager = GetComponent<SurvivalGuideManager>();
		ExpertiseManager = GetComponent<ExpertiseManager>();
		PrefabManager = GetComponent<PrefabManager>();
		_statsAndAchievementsManager = GetComponent<StatsAndAchievementsManager>();
		Settings.AgentSettings.Initialize();
		if (_initializeEnvironment && EnvironmentInstance == null)
		{
			EnvironmentInstance = Object.FindAnyObjectByType<Environment>();
			if (EnvironmentInstance == null)
			{
				Debugger.Error("No environment found!", this);
			}
		}
	}

	private void InitializeManagers()
	{
		LoadingScreen.AddTask(GameStatsManager.Initialize, "GameStatsManager.Initialize");
		LoadingScreen.AddTask(AnalyticsManager.Initialize, "AnalyticsManager.Initialize");
		LoadingScreen.AddTask(CursorManager.Initialize, "CursorManager.Initialize");
		if (UIManager == null && !_isIntroScene)
		{
			Debugger.Error("No UIManager found.", this);
		}
		if (!_isIntroScene)
		{
			LoadingScreen.AddTask(UIManager.Initialize, "UIManager.Initialize");
		}
		if (_initializeEnvironment)
		{
			if (UpdateManager != null)
			{
				LoadingScreen.AddTask(UpdateManager.Initialize, "UpdateManager.Initialize");
			}
			if (EffectsManager != null)
			{
				LoadingScreen.AddTask(EffectsManager.Initialize, "EffectsManager.Initialize");
			}
			LoadingScreen.AddTask(WorldManager.Initialize, "WorldManager.Initialize");
			LoadingScreen.AddTask(TerrainManager.Initialize, "TerrainManager.Initialize");
			LoadingScreen.AddTask(PhysicsManager.Initialize, "PhysicsManager.Initialize");
		}
		if (_isIntroScene)
		{
			return;
		}
		GameEventDispatcher.AddListener(GameEventType.GameStart, GameStart);
		if (AgentManager == null)
		{
			Debugger.Error("No AgentManager found.", this);
			return;
		}
		if (Session.Profile.ActiveRun == null)
		{
			Debug.LogWarning("A game Scene is being loaded without an active run, a debug run is started.");
			Session.Profile.StartDebugRun(loadGameScene: false);
		}
		LoadingScreen.AddTask(AgentManager.Initialize, "AgentManager.Initialize");
		LoadingScreen.AddTask(ExpertiseManager.Initialize, "ExpertiseManager.Initialize");
		LoadingScreen.AddTask(CameraController.Instance.Initialize, "CameraController.Initialize");
		if (AudioManager == null)
		{
			Debugger.Error("No AudioManager found.", this);
		}
		LoadingScreen.AddTask(AudioManager.Initialize, "AudioManager.Initialize");
		LoadingScreen.AddTask(GraphManager.Initialize, "GraphManager.Initialize");
		if (PersistenceManager == null)
		{
			Debugger.Error("No PersistanceManager found.", this);
		}
		LoadingScreen.AddTask(RadioMessagesManager.Initialize, "RadioMessagesManager.Initialize");
		if (!PersistenceManager.Initialize())
		{
			LoadingScreen.AddTask(WorldManager.GenerateCommunitiesAndPopulateWorld, "WorldManager.GenerateCommunitiesAndPopulateWorld");
			if (StoryManager != null)
			{
				LoadingScreen.AddTask(StoryManager.Initialize, "StoryManager.Initialize");
			}
			else
			{
				Debugger.Error("No StoryManager found.", this);
			}
			if (TimeManager != null)
			{
				LoadingScreen.AddTask(TimeManager.Initialize, "TimeManager.Initialize");
			}
			else
			{
				Debugger.Error("No Time Manager found.", this);
			}
		}
		if (SurvivalGuideManager != null)
		{
			LoadingScreen.AddTask(SurvivalGuideManager.Initialize, "SurvivalGuideManager.Initialize");
		}
		else
		{
			Debugger.Error("No SurvivalGuideManager found.", this);
		}
		LoadingScreen.AddTask(ResourceManager.Initialize, "ResourceManager.Initialize");
		LoadingScreen.AddTask(WorldMapManager.Initialize, "WorldMapManager.Initialize");
		LoadingScreen.AddTask(_statsAndAchievementsManager.Initialize, "StatsAndAchievementsManager.Initialize");
		if ((bool)PrefabManager)
		{
			LoadingScreen.AddTask(PrefabManager.Initialize, "PrefabManager.Initialize");
		}
		LoadingScreen.FallbackGameStart();
	}

	private void LateUpdate()
	{
		if (!_isIntroScene)
		{
			if (_initialized)
			{
				Community.PlayerCommunity.Inventory.LateUpdate();
				Producer.UpdateQueuedProducer();
				PLCoroutine.ValidateCoroutines();
			}
			GameSpeedManager.DispatchChangedEvent();
		}
	}

	private void OnDisable()
	{
		CameraController.SetInstance(null);
		EnvironmentInstance = null;
		Navigator.Navigators.Clear();
		Obstacle.AllObstacles.Clear();
		Construction.Townheart = null;
		Buildable.BuildableParent = null;
		Buildable.BlockingPolygons.Clear();
		Buildable.FreeformBlockerPolygons.Clear();
		InventorySlots.ClearCachedVisuals();
		GameSpeedManager.Reset();
	}

	private void ClearManagers(GameEvent gameEvent)
	{
		GameStatsManager.Clear();
		if (UIManager != null)
		{
			UIManager.Clear();
		}
		RadioMessagesManager.Clear();
	}

	public static void QuitToDesktop()
	{
		IsQuittingToDesktop = true;
		Application.Quit();
	}

	private void LoadBuildManifest()
	{
		TextAsset textAsset = (TextAsset)Resources.Load("UnityCloudBuildManifest.json");
		if (!(textAsset == null))
		{
			BuildManifest = Json.Deserialize(textAsset.text) as Dictionary<string, object>;
		}
	}
}
