using System;
using System.IO;
using Analytics;
using Factory;
using Motorways.Audio;
using Motorways.Commands;
using Motorways.Processes;
using Screens;
using Server;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Motorways.Views
{
	public class StartupScreen : BaseScalingScreen
	{
		public enum DebugAutoStartType
		{
			None = 0,
			NewGame = 1,
			SavedGame = 2,
			BookmarkedSavedGame = 3
		}

		private enum StartupScreenStage
		{
			StartFade = 0,
			WaitForFadeToComplete = 1,
			LoadAtlas = 2,
			WaitForAtlasToLoad = 3,
			LoadMenuCity = 4,
			StartGame = 5,
			WaitForGameToStart = 6,
			Hold = 7,
			TransitionToMainMenu = 8,
			SimulateMenuCity = 9
		}

		public interface IObserver
		{
			void OnStartupScreenTransitionedIn();
		}

		public const string DebugAutoStartTypeEditorPrefsKey = "DebugAutoStartType";

		public const string DebugAutoStartCityEditorPrefsKey = "DebugAutoStartCity";

		public const string DebugAutoStartGameModeEditorPrefsKey = "DebugAutoStartGameMode";

		public const string DebugAutoStartBookmarkedSavedGameEditorPrefsKey = "DebugAutoStartBookedmarkedSavedGame";

		public const string DebugAutoStartPausedEditorPrefsKey = "DebugAutoStartPaused";

		public const string HasEnforcedMaxResolutionPlayerPrefsKey = "HasEnforcedMaxResolution";

		private static readonly Vector2Int MinimumResolution = new Vector2Int(400, 300);

		private static readonly Vector2Int DefaultResolution = new Vector2Int(1920, 1080);

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("StartupScreen");

		[Dependency]
		private IHardwareCapabilities _hardwareCapabilities;

		[Dependency]
		private DeepLinkProcessor _deepLinkProcessor;

		public MapLibrary mapLibrary;

		public MapDefinition tutorialDefinition;

		[SerializeField]
		private CityDefinition _newCity;

		public MapDefinition mapDefinition;

		private MotorwaysGame _menuGame;

		private bool _shouldSimulateMenuGame;

		[Serialize(false, null)]
		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		private SplashScreen _splashScreen;

		private GameStarter _gameStarter;

		private AssetBundleUtility.AsyncLoadResult _atlasAsyncLoadResult;

		[Tooltip("Duration to stay on the splash screen for")]
		public float holdTime = 1.5f;

		private float _holdTimer = -1f;

		private bool _shouldSkipHold;

		private StartupScreenStage[] _startupSequence;

		private int _stageIndex;

		private static readonly StartupScreenStage[] DeactivatedSaveGameSequence = new StartupScreenStage[7]
		{
			StartupScreenStage.LoadAtlas,
			StartupScreenStage.WaitForAtlasToLoad,
			StartupScreenStage.LoadMenuCity,
			StartupScreenStage.StartGame,
			StartupScreenStage.StartFade,
			StartupScreenStage.WaitForFadeToComplete,
			StartupScreenStage.SimulateMenuCity
		};

		private static readonly StartupScreenStage[] TutorialSequence = new StartupScreenStage[8]
		{
			StartupScreenStage.StartFade,
			StartupScreenStage.WaitForFadeToComplete,
			StartupScreenStage.LoadAtlas,
			StartupScreenStage.WaitForAtlasToLoad,
			StartupScreenStage.LoadMenuCity,
			StartupScreenStage.Hold,
			StartupScreenStage.StartGame,
			StartupScreenStage.SimulateMenuCity
		};

		private static readonly StartupScreenStage[] MainMenuSequence = new StartupScreenStage[8]
		{
			StartupScreenStage.StartFade,
			StartupScreenStage.WaitForFadeToComplete,
			StartupScreenStage.LoadAtlas,
			StartupScreenStage.WaitForAtlasToLoad,
			StartupScreenStage.LoadMenuCity,
			StartupScreenStage.Hold,
			StartupScreenStage.TransitionToMainMenu,
			StartupScreenStage.SimulateMenuCity
		};

		private static string CanAutoResumeDeactivatedGamePlayerPrefsKey = "CanAutoResumeDeactivatedGame";

		private static int CanResume = 1;

		private static int CannotResume = 0;

		public CityDefinition BackgroundCityDefinition => _newCity;

		protected ObserverList<IObserver> Observers => _observers;

		private StartupScreenStage CurrentStage => _startupSequence[_stageIndex];

		public static bool CanAutoResumeDeactivatedGame
		{
			get
			{
				return PlayerPrefs.GetInt(CanAutoResumeDeactivatedGamePlayerPrefsKey, CanResume) == CanResume;
			}
			set
			{
				PlayerPrefs.SetInt(CanAutoResumeDeactivatedGamePlayerPrefsKey, value ? CanResume : CannotResume);
				PlayerPrefs.Save();
			}
		}

		public void StartSimulatingMenuGame()
		{
			_shouldSimulateMenuGame = true;
		}

		public void StopSimulatingMenuGame()
		{
			_shouldSimulateMenuGame = false;
		}

		public void PlayMenuGameAudio()
		{
			_menuGame.StartAudio();
		}

		public void StopMenuGameAudio()
		{
			_menuGame.StopAudio();
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			_splashScreen = UnityEngine.Object.FindObjectOfType<SplashScreen>();
			_startupSequence = SelectStartupSequence(out _gameStarter);
			_holdTimer = holdTime;
			VerifyResolution();
			base.TransitionIn(outScreen);
			_themeDatabase.SetCurrentMapDefinition(mapDefinition, 0f);
			if (GraphicsSettings.currentRenderPipeline is UniversalRenderPipelineAsset universalRenderPipelineAsset)
			{
				universalRenderPipelineAsset.msaaSampleCount = _player.AntiAliasingMSAALevelForUniversalRenderPipeline;
			}
			_player.FirstSession = !_player.FirstSession.HasValue;
			if (FeatureToggle.IsFeatureEnabled(Feature.Analytics))
			{
				_appScope.Get<AnalyticsEventHandler>().SetAnalyticsConsentState(_player.AnalyticsConsentState);
			}
			ObserverList<IObserver>.Enumerator enumerator = Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnStartupScreenTransitionedIn();
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			_scaleToCamera = false;
		}

		private void AdvanceStartupSequenceStage()
		{
			_stageIndex++;
		}

		private StartupScreenStage[] SelectStartupSequence(out GameStarter gameStarter)
		{
			gameStarter = null;
			if (_deepLinkProcessor.hasChallengeToUse)
			{
				return MainMenuSequence;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.SoakTest))
			{
				return MainMenuSequence;
			}
			if (Application.isEditor)
			{
				gameStarter = LoadSimulationJournalGameStarter();
				if (gameStarter != null)
				{
					return DeactivatedSaveGameSequence;
				}
			}
			gameStarter = LoadDeactivatedSaveGameStarter();
			if (gameStarter != null)
			{
				return DeactivatedSaveGameSequence;
			}
			if (ShouldLoadTutorial())
			{
				gameStarter = LoadTutorialGameStarter();
				return TutorialSequence;
			}
			return MainMenuSequence;
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (!Diagnostics.Verify(_startupSequence != null, "No startup sequence specified! Transitioning to main menu as backup."))
			{
				_startupSequence = MainMenuSequence;
				return;
			}
			if (CurrentStage != StartupScreenStage.SimulateMenuCity && (Input.anyKey || Input.touchCount > 0))
			{
				_shouldSkipHold = true;
			}
			if (CurrentStage == StartupScreenStage.StartFade)
			{
				if (_splashScreen != null)
				{
					_splashScreen.StartFade();
				}
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.WaitForFadeToComplete)
			{
				if (_splashScreen != null && !_splashScreen.IsFadeComplete())
				{
					return;
				}
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.LoadAtlas)
			{
				StartLoadingAtlas();
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.WaitForAtlasToLoad)
			{
				if (!_atlasAsyncLoadResult.HasValue)
				{
					return;
				}
				RoadTileAtlas roadTileAtlas = null;
				TextAsset textAsset = _atlasAsyncLoadResult.asset as TextAsset;
				if ((bool)textAsset)
				{
					using BinaryReader reader = new BinaryReader(new MemoryStream(textAsset.bytes));
					roadTileAtlas = _appScope.Import<RoadTileAtlas>(reader);
				}
				if (roadTileAtlas == null)
				{
					Diagnostics.FailAssert("RoadTileAtlas failed to load from AssetBundle. Try rebuilding the RoadTileAtlas asset bundle (Assets -> Asset Bundles -> Build RoadTileAtlas");
					roadTileAtlas = _appScope.Get<RoadTileAtlas>();
					roadTileAtlas.Initialize();
				}
				_appScope.Get<RailTileAtlas>().Initialize();
				_appScope.Get<BoatPathTileAtlas>().Initialize();
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.LoadMenuCity)
			{
				CityDefinition backgroundCityDefinition = BackgroundCityDefinition;
				backgroundCityDefinition.CompileTilemap();
				_menuGame = _appScope.Get<MotorwaysGame>();
				_menuGame.SetMapDefinition(mapDefinition);
				_menuGame.Start(backgroundCityDefinition, GameMode.Background, null);
				BuildMenuCityRoads();
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.StartGame && _gameStarter.CanStart)
			{
				if (!_gameStarter.Start(_screenStack, _appScope))
				{
					TransitionToMainMenu();
				}
				else
				{
					Get.State |= StateType.SkippingMenu;
				}
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.WaitForGameToStart)
			{
				return;
			}
			if (CurrentStage == StartupScreenStage.Hold)
			{
				_holdTimer -= deltaTime;
				if (_holdTimer <= 0f || _shouldSkipHold)
				{
					_holdTimer = -1f;
					if (_deepLinkProcessor.hasChallengeToUse)
					{
						_stageIndex = Array.IndexOf(_startupSequence, StartupScreenStage.SimulateMenuCity);
						_deepLinkProcessor.hasChallengeToUse = false;
						TransitionToMapSelect();
						return;
					}
					AdvanceStartupSequenceStage();
				}
			}
			if (CurrentStage == StartupScreenStage.TransitionToMainMenu)
			{
				TransitionToMainMenu();
				AdvanceStartupSequenceStage();
			}
			if (CurrentStage == StartupScreenStage.SimulateMenuCity && _shouldSimulateMenuGame)
			{
				_menuGame.Tick(deltaTime);
			}
		}

		private void TransitionToMainMenu()
		{
			StartSimulatingMenuGame();
			PlayMenuGameAudio();
			_screenStack.PushScreen<MainMenuScreen>(ScreenStack.MotorwaysScreen.MainMenu);
		}

		private void TransitionToMapSelect()
		{
			StartSimulatingMenuGame();
			PlayMenuGameAudio();
			_screenStack.PushScreen<MainMenuScreen>(ScreenStack.MotorwaysScreen.MainMenu);
			_screenStack.PushScreen(ScreenStack.MotorwaysScreen.MapSelect, delegate(MapSelectScreen screen)
			{
				screen.PrepareScreen(null, handleDeeplinkChallenge: true, changeBlurWhenTransitioning: true);
			});
		}

		private void StartLoadingAtlas()
		{
			_atlasAsyncLoadResult = AssetBundleUtility.LoadAssetAsync("roadtileatlas", "roadtileatlas", this);
		}

		private GameStarter LoadDeactivatedSaveGameStarter()
		{
			if (!CanAutoResumeDeactivatedGame)
			{
				return null;
			}
			MotorwaysGameJournalSave motorwaysGameJournalSave = LoadDeactivatedSavedGameJournal();
			GameStarter gameStarter = new GameStarter(this);
			if (motorwaysGameJournalSave == null)
			{
				return null;
			}
			if (!gameStarter.StartFromSavedGame(mapLibrary, motorwaysGameJournalSave, replaceTopScreen: false, skipNextTransition: true))
			{
				return null;
			}
			return gameStarter;
		}

		private GameStarter LoadTutorialGameStarter()
		{
			GameStarter gameStarter = new GameStarter(this);
			if (!gameStarter.StartFromMapDefinition(tutorialDefinition, GameMode.Tutorial, 2f))
			{
				return null;
			}
			return gameStarter;
		}

		private GameStarter LoadSimulationJournalGameStarter()
		{
			string text = UnityEngine.Object.FindObjectOfType<AppRuntime>()?._playbackSimJournalPath;
			if (string.IsNullOrEmpty(text) || !File.Exists(text))
			{
				return null;
			}
			Game game = _appScope.Get<Game>();
			CommandJournal commandJournal = null;
			using (BinaryReader reader = new BinaryReader(File.Open(text, FileMode.Open, FileAccess.Read)))
			{
				commandJournal = game.Scope.Import<CommandJournal>(reader);
			}
			GameStarter gameStarter = null;
			if (commandJournal != null)
			{
				for (int i = 0; i < commandJournal.EntryCount; i++)
				{
					if (commandJournal.GetEntry(i) is InitCityCommand initCityCommand)
					{
						MapDefinition mapByName = mapLibrary.GetMapByName(initCityCommand.CityName);
						gameStarter = new GameStarter(this);
						gameStarter.StartFromMapDefinition(mapByName, GameMode.Normal);
						break;
					}
				}
			}
			_appScope.Release(game);
			return gameStarter;
		}

		private MotorwaysGameJournalSave LoadDeactivatedSavedGameJournal()
		{
			if (!_player.HasLocalSavedGame)
			{
				return null;
			}
			MotorwaysGameJournalSave motorwaysGameJournalSave = (MotorwaysGameJournalSave)_player.LocalSavedGame;
			if (motorwaysGameJournalSave == null)
			{
				return null;
			}
			if (motorwaysGameJournalSave.Motive != GameJournalMotive.AppDeactivated)
			{
				return null;
			}
			return motorwaysGameJournalSave;
		}

		private void VerifyResolution()
		{
			if (!_hardwareCapabilities.SupportsChangingResolution)
			{
				return;
			}
			bool flag = false;
			Vector2Int vector2Int = Vector2Int.zero;
			if (Screen.width <= MinimumResolution.x || Screen.height <= MinimumResolution.y)
			{
				vector2Int = DefaultResolution;
				flag = true;
				Log.Info("Resolution of {0}x{1} is below the minimum. The window will be resized to close to {2}x{3}.", Screen.width, Screen.height, DefaultResolution.x, DefaultResolution.y);
			}
			if (!PlayerPrefs.HasKey("HasEnforcedMaxResolution"))
			{
				PlayerPrefs.SetInt("HasEnforcedMaxResolution", 1);
				Vector2Int defaultMaximumResolution = _hardwareCapabilities.DefaultMaximumResolution;
				if (defaultMaximumResolution.x > 0 && defaultMaximumResolution.y > 0 && Screen.width > defaultMaximumResolution.x && Screen.height > defaultMaximumResolution.y)
				{
					vector2Int = defaultMaximumResolution;
					flag = true;
					Log.Info("Resolution of {0}x{1} is above the default maximum resolution. The window will be resized to close to {2}x{3}.", Screen.width, Screen.height, defaultMaximumResolution.x, defaultMaximumResolution.y);
				}
			}
			if (!flag)
			{
				return;
			}
			float num = -1f;
			Vector2Int vector2Int2 = Vector2Int.zero;
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				float magnitude = (new Vector2Int(resolution.width, resolution.height) - vector2Int).magnitude;
				if (num < 0f || num > magnitude)
				{
					num = magnitude;
					vector2Int2 = new Vector2Int(resolution.width, resolution.height);
				}
			}
			if (num >= 0f)
			{
				Log.Info("Changing resolution to {0}x{1}.", vector2Int2.x, vector2Int2.y);
				Screen.SetResolution(vector2Int2.x, vector2Int2.y, Screen.fullScreen);
			}
		}

		private bool ShouldLoadTutorial()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.AlwaysEnterTutorial))
			{
				return true;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.AppleStoreDemo))
			{
				return false;
			}
			bool isAnyTutorialCompleted = _player.IsAnyTutorialCompleted;
			bool flag = _player.IsTutorialTypeCompleted(TutorialProgressionProcess.TutorialTypeForInputType(_inputState.CurrentDeviceInputType));
			Log.Info("Has the player completed the tutorial for {0}? {1}\nHas the player completed any tutorial? {2}", _inputState.CurrentDeviceInputType, flag, isAnyTutorialCompleted);
			return !isAnyTutorialCompleted;
		}

		private void BuildMenuCityRoads()
		{
			ScheduleLineOfRoads(new Vector2Int(-125, 50), 10, TileDirection.North);
			ScheduleLineOfRoads(new Vector2Int(-125, 50), 18, TileDirection.SouthWest);
			ScheduleLineOfRoads(new Vector2Int(-127, 48), 1, TileDirection.SouthEast);
			ScheduleLineOfRoads(new Vector2Int(-132, 43), 42, TileDirection.East);
			ScheduleLineOfRoads(new Vector2Int(-95, 43), 8, TileDirection.SouthEast);
			ScheduleLineOfRoads(new Vector2Int(-87, 35), 16, TileDirection.East);
			ScheduleLineOfRoads(new Vector2Int(-125, 60), 7, TileDirection.NorthEast);
			ScheduleLineOfRoads(new Vector2Int(-118, 67), 25, TileDirection.East);
			ScheduleLineOfRoads(new Vector2Int(-93, 67), 25, TileDirection.North);
			ScheduleLineOfRoads(new Vector2Int(-110, 42), 2, TileDirection.North);
			_menuGame.Tick(0f);
		}

		private void ScheduleLineOfRoads(Vector2Int start, int length, TileDirection direction)
		{
			EditTileCommand editTileCommand = EditTileCommand.Create(_menuGame.Scope, AddRoadLineEdit.Create(_menuGame.Scope, start, direction, length));
			editTileCommand.FrameIndex = 0;
			_menuGame.Scope.Get<Simulation>().ScheduleCommand(editTileCommand);
		}
	}
}
