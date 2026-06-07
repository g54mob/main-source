using System;
using System.IO;
using System.Linq;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Craft.Parts.Styles;
using Assets.Scripts.Design;
using Assets.Scripts.DevConsole;
using Assets.Scripts.Flight;
using Assets.Scripts.GameLoop;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Assets.Scripts.Logging;
using Assets.Scripts.Menu;
using Assets.Scripts.Mods;
using Assets.Scripts.OperatingSystem;
using Assets.Scripts.Scenes;
using Assets.Scripts.Services.Ads;
using Assets.Scripts.Services.Analytics;
using Assets.Scripts.Services.Purchasing;
using Assets.Scripts.Settings;
using Assets.Scripts.Social;
using Assets.Scripts.Social.Achievements;
using Assets.Scripts.Startup;
using Assets.Scripts.State;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Audio;
using ModApi.CelestialData;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Decals;
using ModApi.Craft.Parts.Styles;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.DevConsole;
using ModApi.Flight;
using ModApi.Input;
using ModApi.Levels;
using ModApi.Mods;
using ModApi.Planet.Modifiers;
using ModApi.Scenes;
using ModApi.Scenes.Parameters;
using ModApi.Services.Purchasing;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using ModApi.State;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts
{
	public sealed class Game : IGame
	{
		public const string RequiredResourcesFolder = "InstalledResources/Required";

		public static readonly Guid SessionID = Guid.NewGuid();

		public static readonly Version Version = new Version(1, 3, 205, 0);

		private static volatile Game _instance;

		private static object _lock = new object();

		private static GameLoopRegistrar _loop = new GameLoopRegistrar();

		private static DateTime _startTime = DateTime.Now;

		private GameState _gameState;

		private GameObject _rootGameObject;

		public static bool InDesignerScene => Instance.SceneManager.InDesignerScene;

		public static bool InfiniteFuelEnabled { get; set; }

		public static bool InFlightScene => Instance.SceneManager.InFlightScene;

		public static bool InLevel => Instance.LevelManager.CurrentLevel != null;

		public static bool InMenuScene => Instance.SceneManager.InMenuScene;

		public static bool InPlanetStudioScene => Instance.SceneManager.InPlanetStudioScene;

		public static Game Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						EnsureInitialized();
					}
				}
				return _instance;
			}
		}

		public static bool InTechTreeScene => Instance.SceneManager.InTechTreeScene;

		public static bool IsCareer => Instance.GameState.Mode == GameStateMode.Career;

		public static bool IsInitialized { get; private set; }

		public static GameLoopRegistrar Loop => _loop;

		public static bool MaxWarpUnlocked { get; set; }

		public static string PersistentDataPath => Application.persistentDataPath;

		public static float ResolutionScale { get; private set; }

		public static string SimpleRocketsWebsiteUrl => "https://www.simplerockets.com";

		public static float UiScale => Instance.Settings.Game.General.UserInterfaceScale.Value;

		public AdManagerScript Ads { get; private set; }

		public IAnalyticsManager Analytics { get; private set; }

		public IAudioPlayer AudioPlayer { get; private set; }

		public DesignerPartList CachedDesignerParts { get; private set; }

		public CelestialDatabase CelestialDatabase { get; private set; }

		public CraftDesigns CraftDesigns { get; private set; }

		public ICraftLoader CraftLoader { get; private set; }

		public CraftThemes CraftThemes { get; private set; }

		public GlobalDebugScript Debug { get; private set; }

		public IDesigner Designer { get; set; }

		public DevConsoleManagerScript DevConsole { get; private set; }

		IDevConsole IGame.DevConsole => DevConsoleService.Instance;

		public IDevice Device { get; private set; }

		public IFlightScene FlightScene { get; private set; }

		public FuselageMeshes FuselageMeshes { get; private set; }

		IGameState IGame.GameState => GameState;

		public GameState GameState
		{
			get
			{
				return _gameState;
			}
			set
			{
				SetGameState(value);
			}
		}

		public GameStateManager GameStateManager { get; private set; }

		public IPurchaseService InAppPurchases { get; private set; }

		public InputManagerScript InputManager { get; private set; }

		public IGameInputs Inputs { get; private set; }

		public ILevelManager LevelManager { get; private set; }

		public MobileManagerScript MobileManager { get; private set; }

		public IModManager ModManager => ModManagerScript?.ModManager as IModManager;

		public ModManagerScript ModManagerScript { get; private set; }

		public MusicPlayer MusicPlayer { get; private set; }

		public PartDecalManager PartDecalManager { get; private set; }

		public IPartStyleManager PartStyleManager { get; private set; }

		public PartTypeList PartTypes { get; private set; }

		public PropulsionData PropulsionData { get; private set; }

		public IGameQualitySettings QualitySettings { get; private set; }

		float IGame.ResolutionScale => ResolutionScale;

		public IResourceLoader ResourceLoader { get; private set; }

		public ISceneManager SceneManager { get; private set; }

		public ApplicationSettings Settings { get; private set; }

		IApplicationSettings IGame.Settings => Settings;

		public DateTime StartTime => _startTime;

		public ThemeManager ThemeManager { get; private set; }

		public UrlHandlerScript UrlHandler { get; set; }

		public IUserInterface UserInterface { get; private set; }

		Version IGame.Version => Version;

		public string VersionWithSuffix
		{
			get
			{
				string empty = string.Empty;
				return string.Format(arg1: Instance.Device.IsEducationBuild ? "e" : ((!Instance.InAppPurchases.EnabledInBuild) ? "c" : "f"), format: "{0}{1}", arg0: Version);
			}
		}

		internal AchievementManagerScript AchievementManager { get; private set; }

		internal SocialPlatformManagerScript SocialPlatformManager { get; private set; }

		private Game()
		{
		}

		public static void EnsureInitialized()
		{
			if (_instance == null)
			{
				_instance = new Game();
				_instance.Initialize();
			}
		}

		public static void InstallTextFileResource(string resourcePath, string targetPath)
		{
			string path = Path.ChangeExtension(resourcePath, null);
			if (targetPath.EndsWith(".bytes"))
			{
				targetPath = targetPath.Substring(0, targetPath.Length - ".bytes".Length);
			}
			TextAsset textAsset = Resources.Load<TextAsset>(path);
			File.WriteAllBytes(targetPath, textAsset.bytes);
		}

		public static void Quit()
		{
			ForceQuit();
		}

		public void BeginDesign(bool saveGameState)
		{
			if (saveGameState)
			{
				GameState.Save();
			}
			SceneManager.LoadDesigner();
		}

		public void BeginFlight(string launchCraftDesignId, string launchCraftName, string returnToScene, long launchCost)
		{
			FlightSceneScript.ReturnToSceneAfterFlight = returnToScene;
			GameState gameState = Instance.GameState;
			ILevel currentLevel = LevelManager.CurrentLevel;
			gameState.SelectedCraftDesignId = launchCraftDesignId;
			LaunchLocation launchLocation = ((currentLevel != null) ? currentLevel.LaunchLocation : gameState.SelectedLaunchLocation);
			FlightSceneLoadParameters loadParameters = FlightSceneLoadParameters.NewCraft(launchCraftDesignId, launchCraftName, launchLocation, launchCost);
			currentLevel?.OverrideFlightSceneLoadParameters(loadParameters);
			StartFlightScene(loadParameters);
		}

		public void InstallResources()
		{
			string path = "InstalledResources/Required";
			string[] array = Resources.Load<TextAsset>(Path.Combine(path, "Manifest")).text.Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string text in array)
			{
				try
				{
					string text2 = Utilities.CombinePaths(PersistentDataPath, text);
					if (text2.EndsWith("/"))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text2);
						if (!directoryInfo.Exists)
						{
							Directory.CreateDirectory(directoryInfo.FullName);
						}
					}
					else
					{
						InstallTextFileResource(Path.Combine(path, text), text2);
					}
				}
				catch (Exception ex)
				{
					UnityEngine.Debug.LogErrorFormat("Failed to copy required game state file: {0}. Error: {1}", text, ex.ToString());
				}
			}
		}

		public bool LoadGameState(string gameStateId = null, string gameStateTag = "Active")
		{
			bool result = false;
			if (gameStateId == null)
			{
				gameStateId = Settings.GameStateId;
			}
			Settings.GameStateId = gameStateId;
			Settings.SaveIfNecessary();
			try
			{
				if (GameStateManager.CheckGameStateTagExists(gameStateId, gameStateTag))
				{
					GameState = GameStateManager.LoadGameState(gameStateId, gameStateTag);
					if (GameState != null)
					{
						result = true;
						UnityEngine.Debug.Log("Loaded Game State: " + gameStateId + "  (" + gameStateTag + ")");
					}
				}
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
			return result;
		}

		public bool LoadGameStateOrDefault(string gameStateId = null, string gameStateTag = "Active")
		{
			bool flag = LoadGameState(gameStateId, gameStateTag);
			if (!flag)
			{
				UnityEngine.Debug.LogError("Failed to load game state: " + (gameStateId ?? "null") + " (" + (gameStateTag ?? "null") + ")");
				if (GameStateManager.CheckGameStateTagExists(Settings.GameStateId, gameStateTag))
				{
					MenuScript.ErrorDialogMessage = "The game failed to load the save. Check the log for more info.";
				}
				else if (gameStateId != null)
				{
					MenuScript.ErrorDialogMessage = "The game attempted to load a save that does not exist. Check the log for more info.";
				}
				if (gameStateTag == "Active")
				{
					GameState = GameStateManager.CreateDefaultGameStateSet();
					UnityEngine.Debug.Log("Created Default Game State");
				}
				else
				{
					LoadGameStateOrDefault(gameStateId);
				}
				SceneManager.LoadMenu();
			}
			return flag;
		}

		public void ResumeFlight(int craftNodeId, string planetName)
		{
			FlightSceneScript.ReturnToSceneAfterFlight = "Menu";
			FlightSceneLoadParameters loadParameters = FlightSceneLoadParameters.ResumeCraft(craftNodeId, planetName);
			LevelManager.CurrentLevel?.OverrideFlightSceneLoadParameters(loadParameters);
			StartFlightScene(loadParameters);
		}

		public void SetGameState(GameState gameState, bool temporary = false)
		{
			if (_gameState != gameState)
			{
				_gameState = gameState;
				if (_gameState != null && Settings.GameStateId != _gameState.Id && !temporary)
				{
					Settings.GameStateId = _gameState.Id;
					Settings.Save();
				}
				ApplicationState.GameStateType = _gameState?.Type ?? GameStateType.Default;
				CraftDesigns.EditorCraftId = _gameState?.EditorCraftId ?? "__editor__";
			}
		}

		public void StartFlightScene(FlightSceneLoadParameters loadParameters)
		{
			GameState.PreflightLoadParameters = loadParameters;
			GameState.Save();
			string tagPreFlight = GameState.GetTagPreFlight();
			if (!string.IsNullOrWhiteSpace(tagPreFlight))
			{
				GameStateManager.CopyGameStateTag(GameState.Id, GameState.GetTagActive(), tagPreFlight);
			}
			string tagQuicksave = GameState.GetTagQuicksave();
			if (!string.IsNullOrWhiteSpace(tagQuicksave))
			{
				GameStateManager.DeleteGameStateTag(GameState.Id, tagQuicksave);
			}
			Instance.SceneManager.LoadFlight(loadParameters);
		}

		private static void ForceQuit()
		{
			IsInitialized = false;
			if (!Application.isEditor)
			{
				Application.Quit();
			}
		}

		private static void WarnForOnDestroyUsage()
		{
		}

		private void BackupUserData(string backupFolderName)
		{
			string sourceDirectoryPath = Path.Combine(PersistentDataPath, "UserData/");
			string destinationDirectoryPath = Path.Combine(PersistentDataPath, backupFolderName);
			try
			{
				Utilities.CopyDirectory(sourceDirectoryPath, destinationDirectoryPath, copySubDirectories: true, overwriteFiles: true);
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogError("An error occurred trying to backup the user data to folder: targetPath");
				UnityEngine.Debug.LogException(exception);
			}
		}

		private void BackupUserDataOnVersionUpgrade()
		{
			if (Settings.AppVersionLastRun < new Version(0, 9, 300, 0))
			{
				BackupUserData("UserData_Backup_0.9.300.0");
			}
		}

		private void Initialize()
		{
			try
			{
				Culture.Original.ToString();
				_rootGameObject = new GameObject("Game");
				UnityEngine.Object.DontDestroyOnLoad(_rootGameObject);
				LogHistory.Initialize(100, 100, StartupUtilities.GetDeviceInformation);
				InstallResources();
				Device = new Device();
				if (!Application.isPlaying && Device.IsUnityEditor)
				{
					UnityEngine.Debug.LogError("Game.cs constructor running outside of play mode!");
				}
				ResourceLoader = new ResourceLoader();
				_ = Device.IsUnityEditor;
				UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
				SystemUtils.SaveWindowHandle();
				ApplicationEventNotifier applicationEventNotifier = _rootGameObject.AddComponent<ApplicationEventNotifier>();
				applicationEventNotifier.Focused += OnFocused;
				applicationEventNotifier.Paused += OnPaused;
				applicationEventNotifier.Quit += OnQuit;
				Debug = GlobalDebugScript.Create(_rootGameObject);
				Settings = ApplicationSettings.Load();
				bool isNewVersion = Settings.AppVersionLastRun < Version;
				EnumSetting<DisplayQualitySettings.MobileDeviceEmulationMode> mobileEmulation = Settings.Quality.Display.MobileEmulation;
				if (mobileEmulation.Value != DisplayQualitySettings.MobileDeviceEmulationMode.None)
				{
					ModApi.Device.EnableMobileBuildEmulation(mobileEmulation.Value == DisplayQualitySettings.MobileDeviceEmulationMode.Tablet);
				}
				BackupUserDataOnVersionUpgrade();
				CelestialDatabase = CelestialDatabase.Create(isNewVersion);
				SceneManager = Assets.Scripts.Scenes.SceneManager.Create(_rootGameObject);
				InAppPurchases = PurchasingManagerScript.Create(_rootGameObject);
				Analytics = AnalyticsManagerScript.Create(_rootGameObject);
				Ads = AdManagerScript.Create(_rootGameObject);
				InputManager = InputManagerScript.Create(_rootGameObject);
				Inputs = InputManager.Inputs;
				LevelManager = Assets.Scripts.Levels.LevelManager.Create(_rootGameObject);
				AchievementManager = AchievementManagerScript.Create(_rootGameObject);
				SocialPlatformManager = SocialPlatformManagerScript.Create(_rootGameObject);
				GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Audio/AudioPlayer")) as GameObject;
				gameObject.transform.SetParent(_rootGameObject.transform);
				gameObject.name = "AudioPlayer";
				AudioPlayer = gameObject.GetComponent<AudioPlayer>();
				GameObject gameObject2 = UnityEngine.Object.Instantiate(Resources.Load("Audio/MusicPlayer")) as GameObject;
				gameObject2.transform.SetParent(_rootGameObject.transform);
				MusicPlayer = gameObject2.GetComponent<MusicPlayer>();
				QualitySettings = Settings.Quality;
				QualitySettings.ApplySettings();
				QualitySettings.Display.ResolutionScale.Changed += delegate(object s, SettingChangedEventArgs<float> e)
				{
					ResolutionScale = e.Setting.Value;
				};
				ResolutionScale = QualitySettings.Display.ResolutionScale.Value;
				XmlLayoutResourceDatabase.instance.ToString();
				UserInterface = new UserInterface();
				DevConsole = DevConsoleManagerScript.Create(_rootGameObject);
				FuselageMeshes = new FuselageMeshes(ResourceLoader);
				PartStyleManager = PartStyleManagerScript.Create(_rootGameObject);
				LoadCraftData();
				LoadPlanetData();
				CraftLoader = CraftLoaderScript.Create(_rootGameObject);
				ApplicationState.Initialize();
				string gameStatesFolder = Utilities.CombinePaths(PersistentDataPath, "UserData/GameStates/");
				GameStateManager = new GameStateManager(gameStatesFolder, SceneManager);
				LoadGameStateOrDefault();
				FlightSceneScript.OnSingletonUpdated = delegate(IFlightScene x)
				{
					FlightScene = x;
				};
				ModManagerScript = ModManagerScript.Create(_rootGameObject);
				PartStyleManager.RebuildTextureArrays();
				PartDecalManager = PartDecalManager.Create(_rootGameObject);
				GameObject gameObject3 = UnityEngine.Object.Instantiate(Resources.Load("UrlHandler")) as GameObject;
				gameObject3.transform.SetParent(_rootGameObject.transform);
				gameObject3.name = "UrlHandler";
				UrlHandler = gameObject3.GetComponent<UrlHandlerScript>();
				MobileManager = MobileManagerScript.Create(_rootGameObject);
				SystemUtils.ChangeWindowName("Juno: New Origins");
				IsInitialized = true;
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
			}
		}

		private void LoadCraftData()
		{
			ThemeManager = new ThemeManager();
			CraftThemes = new CraftThemes(ResourceLoader.LoadText("Craft/CraftThemes"));
			CraftDesigns = new CraftDesigns(Utilities.CombinePaths(PersistentDataPath, "UserData/CraftDesigns/"));
			PropulsionData = new PropulsionData(ResourceLoader.LoadText("Craft/Parts/Propulsion"));
			PartModifierData.Register(typeof(PartModifierData).Assembly, null);
			PartModifierData.Register(typeof(Game).Assembly, null);
			PartTypes = new PartTypeList();
			CachedDesignerParts = new DesignerPartList(PartTypes);
			PartLoader.LoadParts(from x in Resources.LoadAll<TextAsset>("Craft/Parts/Definitions")
				select x.text, null);
			CachedDesignerParts.LoadCachedSubassemblies();
		}

		private void LoadPlanetData()
		{
			PlanetModifier.Register(typeof(PlanetModifier).Assembly, null);
		}

		private void OnFocused(bool focusState)
		{
			if (focusState && ThemeManager != null)
			{
				ThemeManager.OnApplicationFocus();
			}
		}

		private void OnPaused(bool pauseState)
		{
		}

		private void OnQuit()
		{
			ForceQuit();
		}
	}
}
