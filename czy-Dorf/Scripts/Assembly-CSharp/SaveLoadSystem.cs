using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Dorfromantik;
using Dorfromantik.CreativeMode;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveLoadSystem : MonoBehaviour
{
	private sealed class _003CSetupLoadedGame_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SaveLoadSystem _003C_003E4__this;

		public SaveGameData_003 loadedGame;

		private GameMode _003CloadedGameMode_003E5__2;

		private Stopwatch _003CstopWatch_003E5__3;

		private int _003CtotalTilesToLoad_003E5__4;

		private int _003CloadedTilesCount_003E5__5;

		private int _003ClastFrameLoadedTiles_003E5__6;

		private List<TileData_003>.Enumerator _003C_003E7__wrap6;

		private int _003Ci_003E5__8;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSetupLoadedGame_003Ed__35(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				SaveLoadSystem saveLoadSystem = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CloadedGameMode_003E5__2 = saveLoadSystem.saveFileManager.GameModeById(loadedGame.gameMode);
					_003CstopWatch_003E5__3 = new Stopwatch();
					_003CstopWatch_003E5__3.Start();
					if (loadedGame.surroundedTilesCount == 0)
					{
						saveLoadSystem.loadingProgressRouter.OnCompleted += saveLoadSystem.InitializeSurroundedTilesCount;
					}
					saveLoadSystem.rewardSystem.ResetLevelAndScore(loadedGame);
					if (loadedGame.gameMode == GameModeId.Creative)
					{
						saveLoadSystem.biomeSectionManager.SetupAvailableBiomes(loadedGame.excludedBiomes);
					}
					else
					{
						saveLoadSystem.biomeSectionManager.SetupAvailableBiomesFromPlayerPrefs();
					}
					saveLoadSystem.biomeSectionManager.SetWorldSeed(saveLoadSystem.world.transform, loadedGame.biomeSeed);
					if (OverwritingSingleton<GameSession>.Instance.GameMode.setupPreplacedTiles)
					{
						saveLoadSystem.preplacedTileSectionManager.SetupPredefinedTiles(loadedGame.preplacedTiles);
						saveLoadSystem.preplacedTileSectionManager.SetupPendingLockedChallenges(loadedGame.pendingLockedChallenges);
						saveLoadSystem.preplacedTileSectionManager.SetWorldSeed(saveLoadSystem.world.transform, loadedGame.preplacedTileSeed);
					}
					if (loadedGame.gameMode == GameModeId.Creative && string.IsNullOrWhiteSpace(loadedGame.initialVersion))
					{
						Tile tileToPlaceDirectly = saveLoadSystem.tileGenerator.GenerateBaseTile();
						saveLoadSystem.tilePlacer.PlaceTileDirectly(tileToPlaceDirectly, Vector2Int.zero);
					}
					if (_003CloadedGameMode_003E5__2.usesCustomConfiguration)
					{
						OverwritingSingleton<GameSession>.Instance.SetGameMode(_003CloadedGameMode_003E5__2);
						saveLoadSystem.customModeConfiguration.LoadFrom(loadedGame.customModeData);
					}
					_003CtotalTilesToLoad_003E5__4 = loadedGame.tileStack.Count + loadedGame.tiles.Count;
					_003CloadedTilesCount_003E5__5 = 0;
					foreach (Tile initialTile in saveLoadSystem.world.InitialTiles)
					{
						saveLoadSystem.biomeManager.ApplyBiome(initialTile);
					}
					_003ClastFrameLoadedTiles_003E5__6 = 0;
					new List<float>();
					_003C_003E7__wrap6 = loadedGame.tiles.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_036d;
				case 1:
					_003C_003E1__state = -3;
					_003CstopWatch_003E5__3.Reset();
					_003CstopWatch_003E5__3.Start();
					goto IL_036d;
				case 2:
					{
						_003C_003E1__state = -1;
						_003CstopWatch_003E5__3.Reset();
						_003CstopWatch_003E5__3.Start();
						goto IL_04a9;
					}
					IL_04bb:
					if (_003Ci_003E5__8 < loadedGame.tileStack.Count)
					{
						Tile tile = saveLoadSystem.tileGenerator.CreateTileFromSaveData(loadedGame.tileStack[_003Ci_003E5__8]);
						if (tile == null)
						{
							Debug.LogWarning($"failed creating stacked tile {loadedGame.tileStack[_003Ci_003E5__8]} - skip");
						}
						else
						{
							saveLoadSystem.tileStack.ReplaceStackedTile(_003Ci_003E5__8 + 1, tile, randomizeSeed: false, generateDuplicate: false);
							_003CloadedTilesCount_003E5__5++;
							_003ClastFrameLoadedTiles_003E5__6++;
							saveLoadSystem.loadingProgressRouter.SetProgress((float)_003CloadedTilesCount_003E5__5 / (float)_003CtotalTilesToLoad_003E5__4);
							if (_003CloadedTilesCount_003E5__5 % 1000 == 0)
							{
								Resources.UnloadUnusedAssets();
							}
							if (_003CstopWatch_003E5__3.ElapsedMilliseconds > saveLoadSystem.LoadingFrameBudget)
							{
								_003ClastFrameLoadedTiles_003E5__6 = 0;
								_003C_003E2__current = null;
								_003C_003E1__state = 2;
								return true;
							}
						}
						goto IL_04a9;
					}
					saveLoadSystem.inputRouter.DiscardCurrentPreviewTile(refillStack: true, initial: true);
					saveLoadSystem.tileGenerator.Setup(loadedGame);
					if (loadedGame.tileStackCount == 0 && loadedGame.gameMode == GameModeId.Creative)
					{
						saveLoadSystem.tileStack.SetHeight(30);
					}
					else
					{
						saveLoadSystem.tileStack.SetHeight(loadedGame.tileStackCount);
					}
					if (OverwritingSingleton<GameSession>.Instance.GameMode.setupChallenges)
					{
						foreach (SessionQuest item in saveLoadSystem.sessionQuestManager.SelectablePassiveChallenges())
						{
							saveLoadSystem.sessionQuestWatcher.SetupWatchedChallenge(item, -1);
						}
						saveLoadSystem.sessionQuestWatcher.PrepareLockedChallenges(saveLoadSystem.sessionQuestManager.LockedChallenges());
					}
					saveLoadSystem.tileGenerator.Setup(loadedGame);
					if (loadedGame.gameMode == GameModeId.Creative)
					{
						saveLoadSystem.creativeModeConfiguration.LoadFrom(loadedGame.groupTypeConfiguration, loadedGame.excludedBiomes);
					}
					else
					{
						if (_003CloadedGameMode_003E5__2.usesCustomConfiguration)
						{
							PlayerPrefsAccessor.SetString("CustomModeConfigString", loadedGame.customModeData.configString);
							PlayerPrefsAccessor.SetInt("CustomModeSeed", loadedGame.customModeData.seed);
							OverwritingSingleton<GameSession>.Instance.SetGameMode(_003CloadedGameMode_003E5__2);
							saveLoadSystem.customModeConfiguration.LoadFrom(loadedGame.customModeData);
						}
						if (loadedGame.tileStackCount == 0)
						{
							saveLoadSystem.rewardSystem.GameOver(animate: false, setHighscore: false);
							if (Singleton<MainMenuUi>.Instance.ActiveScreen != MainMenuScreenType.None)
							{
								OverwritingSingleton<IngameUi>.Instance.ShowUi(shouldShow: false);
							}
						}
						saveLoadSystem.creativeModeConfiguration.LoadFrom(PlayerPrefsAccessor.GetString("ExcludedBiomesClassic"));
					}
					for (int i = 0; i < saveLoadSystem.specialTileSpawners.Count; i++)
					{
						List<int> lastRewardedScore = loadedGame.lastRewardedScore;
						if (lastRewardedScore != null && lastRewardedScore.Count > i)
						{
							List<int> lastRewardedStep = loadedGame.lastRewardedStep;
							if (lastRewardedStep != null && lastRewardedStep.Count > i)
							{
								saveLoadSystem.specialTileSpawners[i].Setup(loadedGame.lastRewardedStep[i], loadedGame.lastRewardedScore[i]);
								continue;
							}
						}
						saveLoadSystem.specialTileSpawners[i].Setup();
					}
					if (string.IsNullOrWhiteSpace(loadedGame.initialVersion))
					{
						loadedGame.initialVersion = "0.1.9";
					}
					saveLoadSystem.saveFileManager.SetActiveGame(loadedGame);
					OverwritingSingleton<GameSession>.Instance.BroadcastWorldWasSetup();
					return false;
					IL_04a9:
					_003Ci_003E5__8++;
					goto IL_04bb;
					IL_036d:
					while (_003C_003E7__wrap6.MoveNext())
					{
						TileData_003 current3 = _003C_003E7__wrap6.Current;
						if (!saveLoadSystem.loadSeeds)
						{
							current3.seed = -1;
						}
						Tile tile2 = saveLoadSystem.tileGenerator.CreateTileFromSaveData(current3);
						if (tile2 == null)
						{
							Debug.LogWarning($"failed creating placed tile at {current3.gridPos} - skip");
							continue;
						}
						tile2.Rotate(current3.rotation, animate: false);
						saveLoadSystem.tilePlacer.PlaceTileDirectly(tile2, new Vector2Int(current3.gridPos[0], current3.gridPos[1]));
						_003CloadedTilesCount_003E5__5++;
						_003ClastFrameLoadedTiles_003E5__6++;
						saveLoadSystem.loadingProgressRouter.SetProgress((float)_003CloadedTilesCount_003E5__5 / (float)_003CtotalTilesToLoad_003E5__4);
						if (_003CstopWatch_003E5__3.ElapsedMilliseconds <= saveLoadSystem.LoadingFrameBudget)
						{
							continue;
						}
						_003ClastFrameLoadedTiles_003E5__6 = 0;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap6 = default(List<TileData_003>.Enumerator);
					_003Ci_003E5__8 = 0;
					goto IL_04bb;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap6/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Predicate<Tile> _003C_003E9__36_0;

		internal bool _003CInitializeSurroundedTilesCount_003Eb__36_0(Tile x)
		{
			return x.NeighborCount == 6;
		}
	}

	[SerializeField]
	public string defaultSaveName = "Dorfromantik";

	[SerializeField]
	private bool loadSeeds = true;

	[SerializeField]
	private KeyCode loadKey = KeyCode.L;

	[SerializeField]
	private bool loadLegacyJson;

	[SerializeField]
	private World world;

	[SerializeField]
	private TilePlacer tilePlacer;

	[SerializeField]
	private SessionQuestWatcher sessionQuestWatcher;

	[SerializeField]
	private List<SpecialTileSpawner> specialTileSpawners;

	[SerializeField]
	private ScreenRecorder screenRecorder;

	[SerializeField]
	private InstanceDrawer instanceDrawer;

	[SerializeField]
	private TileGenerator tileGenerator;

	[SerializeField]
	private TileFactory tileFactory;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private BiomeSectionManager biomeSectionManager;

	[SerializeField]
	private PreplacedTileSectionManager preplacedTileSectionManager;

	[SerializeField]
	private InputRouter inputRouter;

	[FormerlySerializedAs("sessionQuestLibrary")]
	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[FormerlySerializedAs("saveGameManager")]
	[SerializeField]
	private SaveFileManager saveFileManager;

	[SerializeField]
	private CreativeModeConfiguration creativeModeConfiguration;

	[SerializeField]
	private CustomModeConfiguration customModeConfiguration;

	[SerializeField]
	private CustomModePresetManager presetManager;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	[SerializeField]
	private MonthlyModeManager monthlyModeManager;

	private BiomeManager biomeManager;

	private TileStack tileStack;

	private Dictionary<int, QuestTile> questTilePrefabByID;

	private Dictionary<string, Dictionary<string, ElementGroupSegment>> segmentByGroupTypeAndSegmentType;

	public int overrideFrameBudget = -1;

	private int LoadingFrameBudget
	{
		get
		{
			if (overrideFrameBudget <= 0)
			{
				return 15;
			}
			return overrideFrameBudget;
		}
	}

	private void Awake()
	{
		tileStack = UnityEngine.Object.FindObjectOfType<TileStack>();
		biomeManager = world.GetComponent<BiomeManager>();
	}

	public void SaveActiveGame()
	{
		if (loadingProgressRouter.IsLoading)
		{
			return;
		}
		SaveFileManager saveFileManager = this.saveFileManager;
		SaveGameData_003 saveGameData_ = saveFileManager.ActiveSaveGame ?? (saveFileManager.ActiveSaveGame = new SaveGameData_003());
		saveGameData_.score = rewardSystem.Score;
		saveGameData_.perfectPlacements = rewardSystem.PerfectPlacementCount;
		saveGameData_.questsFulfilled = rewardSystem.QuestFulfilledCount;
		saveGameData_.questsFailed = rewardSystem.QuestFailedCount;
		saveGameData_.consecutivePerfectFits = rewardSystem.ConsecutivePerfectFits;
		saveGameData_.consecutivePlacementsWithoutRotate = rewardSystem.ConsecutivePlacementsWithoutRotate;
		saveGameData_.level = rewardSystem.Level;
		saveGameData_.biomeSeed = biomeSectionManager.Seed;
		saveGameData_.preplacedTileSeed = preplacedTileSectionManager.Seed;
		saveGameData_.playtime = rewardSystem.Playtime;
		saveGameData_.gameMode = OverwritingSingleton<GameSession>.Instance.GameMode.id;
		saveGameData_.generatedQuestCount = tileGenerator.GeneratedQuestCount;
		saveGameData_.generatedTileCount = tileGenerator.GeneratedTileCount;
		saveGameData_.placedTileCount = rewardSystem.PlacedTileCount;
		saveGameData_.surroundedTilesCount = rewardSystem.SurroundedTilesCount;
		if (string.IsNullOrWhiteSpace(saveGameData_.initialVersion))
		{
			saveGameData_.initialVersion = Application.version;
		}
		saveGameData_.lastPlayedVersion = Application.version;
		saveGameData_.SaveTiles(world.GetAllPlacedTiles());
		instanceDrawer.DrawAllInstances();
		screenRecorder.CaptureScreenshotInstantly();
		saveGameData_.screenshot = screenRecorder.screenshotData;
		saveGameData_.SetLastPlayedTime(DateTime.Now);
		saveGameData_.SaveTileStack(tileStack.GetGeneratedTiles());
		saveGameData_.tileStackCount = tileStack.RawHeight;
		saveGameData_.SavePendingLockedChallenges(preplacedTileSectionManager.pendingLockedChallenges);
		saveGameData_.SavePreplacedTiles(preplacedTileSectionManager);
		saveGameData_.lastRewardedScore = new List<int>();
		saveGameData_.lastRewardedStep = new List<int>();
		foreach (SpecialTileSpawner specialTileSpawner in specialTileSpawners)
		{
			saveGameData_.lastRewardedStep.Add(specialTileSpawner.LastRewardedStep);
			saveGameData_.lastRewardedScore.Add(specialTileSpawner.LastRewardedScore);
		}
		if (OverwritingSingleton<GameSession>.Instance.GameMode.id == GameModeId.Creative)
		{
			saveGameData_.groupTypeConfiguration = new List<GroupTypeProbability>(creativeModeConfiguration.groupTypeProbabilities);
			saveGameData_.excludedBiomes = new List<BiomeId>(creativeModeConfiguration.excludedBiomes);
		}
		if (OverwritingSingleton<GameSession>.Instance.GameMode.usesCustomConfiguration)
		{
			saveGameData_.customModeData = new CustomModeData(customModeConfiguration);
		}
		saveGameData_.SaveWatchedChallenges(sessionQuestWatcher.watchedSessionQuests);
		foreach (WatchedSessionQuest watchedSessionQuest in sessionQuestWatcher.watchedSessionQuests)
		{
			if (!watchedSessionQuest.SessionQuest.Passive)
			{
				sessionQuestManager.UpdateSessionQuestData(watchedSessionQuest.SessionQuest, save: false);
			}
		}
		sessionQuestManager.SaveSessionQuestData();
		this.saveFileManager.SaveGameFile(saveGameData_);
	}

	public void LoadSaveGame(string saveGameName = "")
	{
		saveGameName = (string.IsNullOrWhiteSpace(saveGameName) ? defaultSaveName : saveGameName);
		SaveGameData_003 loadedGame;
		if (loadLegacyJson)
		{
			loadedGame = (SaveGameData_003)SaveGameConverter.UpgradeSaveGame(JsonLoader.LoadJsonFromDataLocation<SaveGameData_001>(Path.Combine("Saves", saveGameName) + ".json"));
			StartCoroutine(SetupLoadedGame(loadedGame));
			return;
		}
		string text = Path.Combine("Saves", saveGameName);
		SuccessStatus successStatus;
		SaveGameData saveGameData = BinarySaveLoad.LoadFromBinary<SaveGameData>(text, out successStatus);
		if (saveGameData == null)
		{
			SetupNewGame();
			return;
		}
		loadedGame = (SaveGameData_003)SaveGameConverter.LoadCurrentVersionSavegame(saveGameData.version, text);
		StartCoroutine(SetupLoadedGame(loadedGame));
	}

	public void LoadSaveGame(SaveGameData_003 saveGameToLoad)
	{
		if (saveGameToLoad == null || !saveGameToLoad.HasStarted)
		{
			SetupNewGame();
		}
		else
		{
			StartCoroutine(SetupLoadedGame(saveGameToLoad));
		}
	}

	public void SetupNewGame()
	{
		if (OverwritingSingleton<GameSession>.Instance.GameMode.setupPreplacedTiles)
		{
			preplacedTileSectionManager.SetupPredefinedTiles(null);
			preplacedTileSectionManager.SetupPendingLockedChallenges(null);
			preplacedTileSectionManager.SetWorldSeed(world.transform, tileGenerator.TileGenerationSeed);
		}
		if (OverwritingSingleton<GameSession>.Instance.GameMode.usesCustomConfiguration)
		{
			GameMode gameMode = saveFileManager.GameModeById((GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 3));
			OverwritingSingleton<GameSession>.Instance.SetGameMode(gameMode);
			Debug.Log($"Setup New Game - last played GameMode is {gameMode}");
			switch (gameMode.configType)
			{
			case CustomConfigType.PredefinedWithRandomSeed:
				customModeConfiguration.SetupFromConfigString(gameMode.configurationString, Randomizer.GetRandomSeed());
				break;
			case CustomConfigType.Custom:
				customModeConfiguration.SetupFromConfigString(PlayerPrefsAccessor.GetString("CustomModeConfigString"), PlayerPrefsAccessor.GetInt("CustomModeSeed", 0));
				break;
			case CustomConfigType.Monthly:
				customModeConfiguration.InitializeCurrentTime();
				customModeConfiguration.SetupFromConfigString(monthlyModeManager.GetCurrentConfigString());
				break;
			}
			tileStack.Regenerate();
			float value = customModeConfiguration.GetValue(CustomRuleType.TileStackHeight);
			if (customModeConfiguration.HasInfiniteTileStack || value < 0f)
			{
				tileStack.SetHeight(40);
			}
			else
			{
				tileStack.SetHeight(Mathf.RoundToInt(customModeConfiguration.GetValue(CustomRuleType.TileStackHeight)));
			}
			tileStack.SetInfinite(customModeConfiguration.HasInfiniteTileStack);
		}
		if (OverwritingSingleton<GameSession>.Instance.GameMode.setupChallenges)
		{
			for (int i = 0; i < 3; i++)
			{
				PlayerPrefsAccessor.SetInt(Constants.PlayerPrefKeys.SelectedSessionQuests[i], -1);
			}
			sessionQuestManager.UpdateOrder();
			foreach (SessionQuest item in sessionQuestManager.SelectablePassiveChallenges())
			{
				sessionQuestWatcher.SetupWatchedChallenge(item, -1);
			}
			sessionQuestWatcher.PrepareLockedChallenges(sessionQuestManager.LockedChallenges());
		}
		foreach (SpecialTileSpawner specialTileSpawner in specialTileSpawners)
		{
			specialTileSpawner.Setup();
		}
		if (OverwritingSingleton<GameSession>.Instance.GameMode.id != GameModeId.Creative)
		{
			creativeModeConfiguration.LoadFrom(PlayerPrefsAccessor.GetString("ExcludedBiomesClassic"));
		}
		saveFileManager.SetActiveGame(null);
		loadingProgressRouter.SetProgress(1f);
		OverwritingSingleton<GameSession>.Instance.BroadcastWorldWasSetup();
	}

	public IEnumerator SetupLoadedGame(SaveGameData_003 loadedGame)
	{
		return new _003CSetupLoadedGame_003Ed__35(0)
		{
			_003C_003E4__this = this,
			loadedGame = loadedGame
		};
	}

	private void InitializeSurroundedTilesCount()
	{
		rewardSystem.SurroundedTilesCount = world.GetTileCount((Tile x) => x.NeighborCount == 6);
		loadingProgressRouter.OnCompleted -= InitializeSurroundedTilesCount;
	}

	private void OnDestroy()
	{
		loadingProgressRouter.OnCompleted -= InitializeSurroundedTilesCount;
	}
}
