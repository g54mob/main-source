using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GalaxyMapManager : MonoBehaviour
{
	private enum PostLogWindowActionEnum
	{
		None = 0,
		ShowTradingPost = 1
	}

	private const bool USE_OLD_BOARDING_CONFIG_UI = false;

	private const float DUNGEON_DISTANCE_TO_RATIONS_FACTOR = 80f;

	public static GalaxyMapManager Instance;

	public static Texture2D depthMapSourceTexture;

	public static Texture2D typeMapSourceTexture;

	public static Texture2D typeDensityMapSourceTexture;

	public static Texture2D difficultyMapSourceTexture;

	public static bool ShipDeteriorating;

	public static bool hasBoardedDungeon;

	private static int scrapAtBoard;

	public readonly KeyCode[] invalidDungeonKeys = new KeyCode[12]
	{
		KeyCode.A,
		KeyCode.B,
		KeyCode.C,
		KeyCode.D,
		KeyCode.J,
		KeyCode.L,
		KeyCode.M,
		KeyCode.O,
		KeyCode.R,
		KeyCode.S,
		KeyCode.T,
		KeyCode.V
	};

	public GameObject DerelictPrefab;

	public GameObject StationPrefab;

	public GameObject OutpostPrefab;

	public GameObject StarSystemNodePrefab;

	public GameObject AutoTradePrefab;

	public GameObject StargatePrefab;

	public GameObject PlayerShipInstance;

	public GameObject PlayerShipPlaneInstance;

	public GameObject HelpManualUiObject;

	public GameObject BoardingConfigUiObject;

	public GameObject BoardingConfigShipUpgradesUiObject;

	public MenuPanelUI menuPanel;

	public Color SysDistanceToSelectedColor = Color.blue;

	public Color SysDistanceToDockedColor = Color.white;

	public Color SysLineDistanceToSelectedColor = Color.blue;

	public Color SysLineDistanceToDockedColor = Color.white;

	public Material SysDistanceToSelectedMaterial;

	public Material SysDistanceToDockedMaterial;

	private BoardingConfigUi _boardingConfigUi;

	private BoardingConfigShipUpgradeUi _shipConfigUi;

	public Material StarGateConnectionLineMaterial;

	public bool RenderGUI = true;

	public bool DisableAmbientSound;

	private StarSystemInfo _selectedStarSystem;

	private DungeonInfo previouslySelectedDungeon;

	private Rect _playerShipWindowRect;

	private Rect _playerShipWindowCompactRect;

	private Rect _selectedDungeonWindowRect;

	private Rect _selectedDungeonWindowCompactRect;

	private List<GalaxyNode> _starSystemNodes = new List<GalaxyNode>();

	private int _distanceInDaysToTarget;

	private bool _showBoardingConfigWindow;

	private bool _showShipUpgradeWindow;

	private bool isLoadingScene;

	private int _currentPresetIndex = -1;

	private bool _loadInitialUpgrades;

	private float _rationsChangedTimer;

	private bool lastStarJumpBetweenStargateSystems;

	private StarSystemInfo lastViewedStarSystem;

	private DebugLogViewer debugLogViewer;

	public string densityMapName = string.Empty;

	public string typeMapName = string.Empty;

	public string typeDensityMapName = string.Empty;

	public string difficultyMapName = string.Empty;

	private int galaxyMapGenerationSeed;

	private Vector3 guiCameraHomePos = Vector3.zero;

	private PlayerExpandedInventory _playerExpandedInventory;

	private static int _shipUpgradesCountPriorToMission;

	private bool _notifyPlayerAboutShipUpgrades;

	private PauseMenu pauseMenu;

	private ModificationsWindow _modsWindow;

	private bool _showModsWindow;

	private List<GameObject> stargateConnectionLines;

	private bool blackoutScreenOnNewGalaxy;

	private int blackoutFrameCount;

	private PostLogWindowActionEnum postLogWindowAction;

	private Rect logToggleButtonRect = new Rect(450f, -235f, 200f, 20f);

	private SortedList<int, string> logList;

	private int logSelectedIndex;

	private string currentLogKey;

	private bool isTakingANote;

	private GalaxyNoteWindow galaxyNoteWindow;

	public AudioSource[] OwnedDbfSounds;

	private AudioSource asMotherShipAmbience;

	private HelpManual _helpManualWindow;

	private bool showNurseryCompleteHint;

	private bool testHints = true;

	private bool enableScrapHint;

	private bool showTipsWindowAfterDelay;

	private float timerShowTipWindow;

	private bool showStrategyWindowAfterDelay;

	private float timerShowStrategyWindow;

	private Vector3 playerShipDestination = Vector3.zero;

	private Vector3 playerShipStart = Vector3.zero;

	private Vector3 playerShipCurrent = Vector3.zero;

	private AnimationCurve transitionCurve;

	private float timerPlayerTransition;

	private float curretMaxTimer;

	private bool isBeginningTransition;

	private bool isEndingTransition;

	private float timerBeginEndTransition;

	private bool isPlayerShipOnDungeonTransitioning;

	private bool isPlayerShipOnSystemTransitioning;

	private bool isPlayerShipCloseFollow;

	private float timerUntilTogglePlayerShipVisibility;

	private float toggleFactor = 1f;

	private StarSystemInfo starSystemTransitioning;

	private bool isWaitingToUnloadUnusedAssets = true;

	private float timerUntilUnloadUnusedAssets = 1f;

	private bool autoFullScreen;

	private float timerTillFullScreen;

	private float _ownedDbfNonBarkTimer = 20f;

	private Vector2 lastMoveDirection = Vector2.zero;

	private StarSystemInfo lastStarSystem;

	private Rect fullScreenRect = default(Rect);

	private Rect dragWindowRect = new Rect(0f, 0f, 185f, 20f);

	private Rect cheatMsgRect = new Rect(1f, 1f, 100f, 20f);

	private Rect boardingConfigRect = new Rect(0f, 10f, 200f, 20f);

	private Rect itemRect = new Rect(0f, 0f, 0f, 20f);

	private Rect noLogRect = new Rect(0f, 0f, 0f, 20f);

	private Rect tabUniverse = new Rect(0f, 1f, 100f, 0f);

	private Rect tabGalaxy = new Rect(0f, 1f, 100f, 0f);

	private Rect tabSystem = new Rect(0f, 1f, 100f, 0f);

	private Rect toggleMsgRect = new Rect(0f, 0f, 300f, 30f);

	private Rect systemNameRect = new Rect(0f, 0f, 0f, 30f);

	private Rect boardOrTravelButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect universeNameRect = new Rect(0f, 0f, 0f, 30f);

	private Rect jumpButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect waitButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect noteButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect closeButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect upgradeButtonRect = new Rect(10f, 0f, 100f, 40f);

	private Rect shipUpgradeButtonRect = new Rect(10f, 0f, 100f, 40f);

	private Rect modificationButtonRect = new Rect(10f, 0f, 100f, 40f);

	private Rect readyButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect cancelButtonRect = new Rect(0f, 0f, 95f, 40f);

	private Rect boardingTextureRect = default(Rect);

	private Vector2 posLogInnerWindow = new Vector2(0f, 10f);

	private float universeMapButtonHeight = 40f;

	private float dungeonsMapButtonHeight = 40f;

	private float galaxyMapButtonHeight = 40f;

	private DungeonInfo guiLastDockedDungeon;

	private StarSystemInfo guiCurrentSystem;

	private StarSystemInfo guiLastViewedSystem;

	private UniverseNode guiCurrentUniverse;

	private int guiPropulsionFuelTotal = -1;

	private int guiJumpFuel = -1;

	private int guiRations = -1;

	private int guiDaysAlive;

	private string guiPropulsionFuelChargeValue = string.Empty;

	private string guiPropulsionFuelReserveValue = string.Empty;

	private string guiJumpFuelValue = string.Empty;

	private string guiRationsValue = string.Empty;

	private string guiDaysAliveValue = string.Empty;

	private string guiRationDaysAliveCompactValue = string.Empty;

	private string guiDockedDungeonName = string.Empty;

	private string guiCurrentSystemName = string.Empty;

	private string guiCurrentUniverseName = string.Empty;

	private string guiLastViewedSystemName = string.Empty;

	private string guiDistanceToTarget = string.Empty;

	private string guiSelectedDungeonClassOrType = string.Empty;

	private string guiAge = string.Empty;

	private string guiInfestationType = string.Empty;

	private string guiAgeInfestationTypeCompact = string.Empty;

	private string guiStargateDestination = string.Empty;

	private List<GameObject> systemLines;

	public static bool ShowingUI { get; private set; }

	public static bool PreparingToBoard { get; private set; }

	public static bool PreserveData { get; set; }

	public static bool IsSpaceDownAfterDungeon { get; set; }

	public static float SpaceDownTimer { get; set; }

	public bool HideOverlays { get; private set; }

	public GalaxyMapState CurrentMapState { get; private set; }

	public GalaxyMapState PreviousMapState { get; private set; }

	public StarSystemInfo SelectedStarSystem
	{
		get
		{
			return _selectedStarSystem;
		}
	}

	public DungeonInfo SelectedDungeon { get; private set; }

	public bool isViewOnlyStarSystemView { get; set; }

	public Camera backgroundCamera { get; private set; }

	public Camera mainCamera { get; private set; }

	public Camera guiCamera { get; private set; }

	public bool isShowingLogSelectionPanel { get; private set; }

	public int LogCount
	{
		get
		{
			if (logList != null)
			{
				return logList.Count;
			}
			return 0;
		}
	}

	public bool isHidingAll { get; private set; }

	public bool showingFullScreenUi { get; private set; }

	public static void ReleaseReferencesOnMainMenu()
	{
		DungeonNode.ReleaseStaticReferences();
		GalaxyNode.ReleaseStaticReferences();
		depthMapSourceTexture = null;
		typeMapSourceTexture = null;
		typeDensityMapSourceTexture = null;
		difficultyMapSourceTexture = null;
		if (UniverseMapManager.Instance != null)
		{
			UniverseMapManager.Instance.Unload();
		}
	}

	private void Awake()
	{
		Instance = this;
		if (GlobalSettings.CommandeeringShip)
		{
			MainMenu.ValidateAndRepairUniverseData();
		}
		GameSaveFile.BeginBatch();
		UniverseSaveFile.BeginBatch();
		GalaxySaveFile.BeginBatch();
		if (!SystemFileManager.MapDataVerified)
		{
			Debug.LogWarning("GalaxyMapManager ran directly.  Forcing map data to be in sync.  Avoid this message by running the game from the Main Menu");
			SystemFileManager.SyncMapDataChanges();
		}
		int num = Camera.allCameras.Length;
		for (int i = 0; i < num; i++)
		{
			Camera camera = Camera.allCameras[i];
			if (camera.name == "Background Camera")
			{
				backgroundCamera = camera;
			}
			else if (camera.name == "Main Camera")
			{
				mainCamera = camera;
			}
			else if (camera.name == "GUI Camera")
			{
				guiCamera = camera;
				guiCameraHomePos = guiCamera.transform.position;
			}
		}
		HelpTextManager.Initialize();
		HintManager.FlushHints();
		if (!ResourceManager.OneTimeGalaxyLoadPerformed)
		{
			ResourceManager.OneTimeGalaxyResourceLoad();
		}
		if (GalaxyProcessor.universeMapManager == null)
		{
			UniverseMapManager universeMapManager = new UniverseMapManager(false, false);
			universeMapManager.NumberOfGalaxyNodes = 10;
			universeMapManager.BreakDownDepth = 3;
			universeMapManager.BreakDownChanceOf = 2;
			universeMapManager.DistanceBetweenShortConnections = 100;
			universeMapManager.DistanceBetweenLongConnections = 250;
			universeMapManager.biasFactor = 10;
			universeMapManager.maxShortConnections = 3;
			universeMapManager.maxLongConnections = 1;
			universeMapManager.reduceLongConnectionsFactor = 4;
			GalaxyProcessor.universeMapManager = universeMapManager;
			GalaxyProcessor.universeMapManager.GenerateUniverse();
		}
		else
		{
			GalaxyProcessor.universeMapManager.Initialize();
		}
		GalaxyProcessor.universeMapManager.RefreshCameraProperties();
		ShowingUI = false;
		PreparingToBoard = false;
		_notifyPlayerAboutShipUpgrades = false;
		EventManager.Initialize();
		GalaxyProcessor.LoadUnlockedInfestationTypeList();
		DroneUpgradeFactory.Initialize();
		ShipUpgradeFactory.Initialize();
		DVPConfigurationManager.Initalize();
		GlobalSettings.IsGamePaused = false;
		SelectedDungeon = null;
		_modsWindow = new ModificationsWindow();
		DungeonConfigurationManager.DungeonHelper.Initialize();
		bool preserveData = PreserveData;
		if (!GlobalSettings.GameStateIsLoaded)
		{
			if (!PreserveData)
			{
				PlayerReset();
			}
			GlobalSettings.GameState = new GameState();
			string value = UniverseSaveFile.Get("PLAYER", "SHIP_ID", string.Empty);
			GlobalSettings.GameState.ThePlayer = new LocalPlayer(UniverseSaveFile.Get("PLAYER", "DAYS", 0), true);
			GlobalSettings.UniverseDaysSurvived = UniverseSaveFile.Get("GSTATE", "UNIVERSE_DAYS", 0);
			GlobalSettings.NumUniversePlays = UniverseSaveFile.Get("UNIVERSE_PLAYS", 0);
			if (string.IsNullOrEmpty(value))
			{
				GlobalSettings.GameState.ThePlayer.MyShip.Name = "The Justice Ryder";
				GlobalSettings.GameState.ThePlayer.MyShip.Definition = DungeonConfigurationManager.DungeonHelper.GetRandomShipClass();
				UniverseSaveFile.Save("PLAYER", "DEFINITION", GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.name);
				UniverseSaveFile.Save("PLAYER", "CLASS", GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value.name);
			}
			else
			{
				string defName = UniverseSaveFile.Get("PLAYER", "DEFINITION", "Private");
				string className = UniverseSaveFile.Get("PLAYER", "CLASS", "A");
				GlobalSettings.GameState.ThePlayer.MyShip.Definition = DungeonConfigurationManager.DungeonHelper.GetDungeonDefinition(DungeonTypeEnum.Derelict, defName, className);
			}
			GlobalSettings.GameState.ThePlayer.MyShip.UpdateCommonDifficultyValues(UniverseSaveFile.Get(GlobalSettings.GameState.ThePlayer.MyShip.GroupKey, "DMIN", 0f));
			_loadInitialUpgrades = CreateInitialNonVisualDrones();
			GlobalSettings.GameState.ThePlayer.Inventory.Scrap = UniverseSaveFile.Get("PLAYER", "SCRAP", 2);
			if (GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve == -1)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve = 0;
			}
			if (GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel < 0)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel = 2;
			}
			if (UniverseSaveFile.Get("PLAYER", "MTIME", -1f) != -1f)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.TimeInMission = UniverseSaveFile.Get("PLAYER", "MTIME", 0f);
				GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoLoss = UniverseSaveFile.Get("PLAYER", "FAIL_NXT", 0f);
				GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextWarningVideoLoss = UniverseSaveFile.Get("PLAYER", "FAIL_NXT_WRN", 0f);
				GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoRestore = UniverseSaveFile.Get("PLAYER", "RESTORE_NXT", 0f);
				GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMin = UniverseSaveFile.Get("PLAYER", "FAIL_NXT_MIN", 0f);
				GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMax = UniverseSaveFile.Get("PLAYER", "FAIL_NXT_MAX", 0f);
			}
			if (GlobalSettings.UseTransporters)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.Transporter));
			}
			if (GlobalSettings.UsePowerManager)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.PowerManager));
			}
			if (GlobalSettings.UseRemotePower)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.RemotePower));
			}
			if (GlobalSettings.UseThisPermUpgrade != ShipUpgradeType.Unknown)
			{
				bool flag = true;
				List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy;
				int count = itemsCopy.Count;
				for (int j = 0; j < count; j++)
				{
					IInventoryItem inventoryItem = itemsCopy[j];
					if (inventoryItem is BaseShipUpgrade && ((BaseShipUpgrade)inventoryItem).UpgradeType == ShipUpgradeType.PermCannon)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					List<IInventoryItem> itemsCopy2 = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy;
					int count2 = itemsCopy.Count;
					for (int k = 0; k < count2; k++)
					{
						IInventoryItem inventoryItem2 = itemsCopy2[k];
						if (inventoryItem2 is BaseShipUpgrade && ((BaseShipUpgrade)inventoryItem2).UpgradeType == ShipUpgradeType.PermCannon)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(ShipUpgradeFactory.CreateUpgrade(GlobalSettings.UseThisPermUpgrade));
					}
				}
			}
		}
		else if (GetTotalShipUpgradesCount() > _shipUpgradesCountPriorToMission)
		{
			_notifyPlayerAboutShipUpgrades = true;
		}
		if (!hasBoardedDungeon)
		{
			GalaxyProcessor.universeMapManager.ChooseStartingGalaxy();
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.RefreshUniverseNode(GalaxyProcessor.universeMapManager.CurrentUniverseNode);
			}
			blackoutScreenOnNewGalaxy = true;
		}
		else
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
			{
				bool flag2 = false;
				int count3 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.Count;
				for (int l = 0; l < count3; l++)
				{
					DungeonInfo dungeonInfo = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons[l];
					if (!dungeonInfo.HaveVisited)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					showNurseryCompleteHint = true;
				}
			}
			if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
			{
				UpdateWeeklyChallengeScore(false, 0);
			}
			if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
			{
				TestEndOfGameState();
			}
		}
		bool flag3 = false;
		if (GlobalSettings.GameState.StarSystems == null || GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null)
		{
			if (GlobalSettings.GenerateGalaxyMapFromImage)
			{
				string value2 = GameSaveFile.Get<string>("GALAXY_ID");
				if (string.IsNullOrEmpty(value2))
				{
					value2 = Instance.densityMapName;
					GameSaveFile.Save("GALAXY_ID", value2);
					GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
				}
				GenerateGalaxyFromImage();
				if (GalaxyProcessor.universeMapManager == null || !GalaxyProcessor.universeMapManager.IsJumpingToGalaxy)
				{
					DetermineStartupStarSystem(preserveData);
					GalaxyProcessor.BuildStargatesFromData(GlobalSettings.GameState.StarSystems);
				}
				else
				{
					GalaxyProcessor.BuildStargatesFromData(GlobalSettings.GameState.StarSystems);
					if (GalaxyProcessor.universeMapManager.IsReturningToPreviewSystem || !GalaxyProcessor.universeMapManager.FindAndSetStarSystemByStargate())
					{
						DetermineStartupStarSystem(preserveData);
					}
				}
			}
			flag3 = true;
			GalaxyProcessor.GenerateDungeonInfo(GlobalSettings.GameState.ThePlayer.CurrentStarSystem, true, null);
			if (!GameSaveFile.Get("URESET", false))
			{
				int count4 = GlobalSettings.GameState.StarSystems.Count;
				for (int m = 0; m < count4; m++)
				{
					StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems[m];
					if (!starSystemInfo.IsNursery)
					{
						continue;
					}
					bool flag4 = true;
					if (starSystemInfo.Dungeons != null)
					{
						int count5 = starSystemInfo.Dungeons.Count;
						for (int n = 0; n < count5; n++)
						{
							GalaxySaveFile.ClearGroup(starSystemInfo.Dungeons[n].GroupKey);
						}
					}
					if (flag4)
					{
						starSystemInfo.Dungeons = null;
						GalaxyProcessor.GenerateNurseryDungeonsFromData(starSystemInfo);
					}
				}
			}
		}
		_selectedStarSystem = GlobalSettings.GameState.ThePlayer.CurrentStarSystem;
		PreviousMapState = GalaxyMapState.StarSystems;
		CurrentMapState = GalaxyMapState.Dungeons;
		CreateGalaxyNodes();
		if (GameSaveFile.Get("GAME_VER", 0f) > 0.283f)
		{
			_selectedStarSystem.OrbitLineRotation = UnityEngine.Random.Range(0, 360);
		}
		GalaxyNode nodeFromStarSystemInfo = GetNodeFromStarSystemInfo(_selectedStarSystem);
		CreateDungeonNodes(nodeFromStarSystemInfo);
		if (GlobalSettings.CommandeeringShip)
		{
			GlobalSettings.CommandeeringShip = false;
			SwapPlayerShipForCurrentDerelict();
			if (GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge > GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.AddSpecificPropulsionChargeFuel(GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax);
			}
			UniverseSaveFile.Save("PLAYER", "MTIME", GlobalSettings.GameState.ThePlayer.MyShip.TimeInMission);
			UniverseSaveFile.Save("PLAYER", "FAIL_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoLoss);
			UniverseSaveFile.Save("PLAYER", "FAIL_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextWarningVideoLoss);
			UniverseSaveFile.Save("PLAYER", "RESTORE_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoRestore);
			UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MIN", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMin);
			UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MAX", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMax);
		}
		if (flag3)
		{
			string groupKey = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey;
			string selectedID = GalaxySaveFile.Get(groupKey, "LAST_DOCKED_ID", string.Empty);
			if (string.IsNullOrEmpty(selectedID))
			{
				selectedID = GalaxySaveFile.Get(groupKey, "LAST_SELECTED_ID", string.Empty);
			}
			DungeonInfo dungeonInfo2 = null;
			if (GalaxyProcessor.universeMapManager != null && GalaxyProcessor.universeMapManager.IsJumpingToGalaxy)
			{
				if (!UniverseMapManager.Instance.IsReadOnlyGalaxy && !UniverseMapManager.ReturningFromReadOnlyGalaxy)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.UniverseWarpIn);
				}
				if (UniverseMapManager.ReturningFromReadOnlyGalaxy)
				{
					UniverseMapManager.ReturningFromReadOnlyGalaxy = false;
				}
				if (!GalaxyProcessor.universeMapManager.IsReturningToPreviewSystem)
				{
					dungeonInfo2 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.DungeonType == DungeonTypeEnum.Stargate);
				}
				if (dungeonInfo2 != null)
				{
					dungeonInfo2.HaveVisited = true;
					if (!GalaxySaveFile.Get(dungeonInfo2.GroupKey, "VISITED", false))
					{
						GalaxySaveFile.Save(dungeonInfo2.GroupKey, "VISITED", true);
						int num2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", dungeonInfo2.DungeonType), 0) + 1;
						GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", dungeonInfo2.DungeonType), num2);
						GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", dungeonInfo2.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", dungeonInfo2.DungeonType), 0) + 1);
						if (num2 > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", dungeonInfo2.DungeonType), 0))
						{
							GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", dungeonInfo2.DungeonType), num2);
						}
					}
					dungeonInfo2.Parent.IsStargateVisited = true;
				}
			}
			if (dungeonInfo2 == null)
			{
				if (preserveData)
				{
					dungeonInfo2 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == selectedID);
				}
				else if (!string.IsNullOrEmpty(selectedID))
				{
					dungeonInfo2 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == selectedID && !GalaxySaveFile.Get(x.GroupKey, "VISITED", false));
				}
			}
			if (dungeonInfo2 == null)
			{
				IEnumerable<DungeonInfo> enumerable = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.Where((DungeonInfo x) => x != null && !GalaxySaveFile.Get(x.GroupKey, "VISITED", false));
				if (enumerable != null && enumerable.Count() > 0)
				{
					List<int> listStarSystemPath = GalaxySaveFile.GetListStarSystemPath();
					if (listStarSystemPath != null && listStarSystemPath.Count == 1)
					{
						float num3 = float.MaxValue;
						DungeonInfo dungeonInfo3 = null;
						foreach (DungeonInfo item in enumerable)
						{
							if ((item.DungeonType == DungeonTypeEnum.Derelict || item.DungeonType == DungeonTypeEnum.Station) && item.DifficultyFactor < num3)
							{
								dungeonInfo3 = item;
								num3 = item.DifficultyFactor;
							}
						}
						if (dungeonInfo3 != null)
						{
							dungeonInfo2 = dungeonInfo3;
						}
					}
					if (dungeonInfo2 == null)
					{
						dungeonInfo2 = enumerable.First();
					}
				}
			}
			if (dungeonInfo2 != null)
			{
				SetPlayerShipDungeon(dungeonInfo2, true);
			}
			else
			{
				Debug.LogWarning("Starting Node - Couldn't find a node that hasn't yet been visited.  This isn't supposed to happen - data state issue OR some not yet considered case.  Just selecting the first node in this system.");
				SetPlayerShipDungeon(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.First(), true);
			}
		}
		else
		{
			SetPlayerShipDungeon(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon, true);
		}
		GalaxyProcessor.universeMapManager.IsReturningToPreviewSystem = false;
		float num4 = 175f;
		float num5 = 160f;
		float num6 = 150f;
		float height = 50f;
		float num7 = 50f;
		float y = 5f;
		float num8 = 2f;
		_selectedDungeonWindowRect = new Rect((float)Screen.width - num4 - num8, num7, num4, num6);
		_selectedDungeonWindowCompactRect = new Rect((float)Screen.width - num5 - num8, y, num5, height);
		_playerShipWindowRect = new Rect((float)Screen.width - num4 - num8, num7 + num6 + 5f, num4, num6 + 20f);
		_playerShipWindowCompactRect = new Rect((float)Screen.width - num5 - num8 - num5, y, num5, height);
		if (!GlobalSettings.GenerateGalaxyMapFromImage)
		{
			CameraGalaxyOverlay[] components = backgroundCamera.GetComponents<CameraGalaxyOverlay>();
			foreach (CameraGalaxyOverlay cameraGalaxyOverlay in components)
			{
				cameraGalaxyOverlay.enabled = false;
			}
			CameraStarSystemOverlay[] components2 = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
			foreach (CameraStarSystemOverlay cameraStarSystemOverlay in components2)
			{
				cameraStarSystemOverlay.enabled = false;
			}
		}
		_playerExpandedInventory = new PlayerExpandedInventory(GlobalSettings.GameState.ThePlayer);
		LogManager.InitManager();
		int num11 = UniverseSaveFile.Get("DBF_HOME", 0);
		if (num11 > 0)
		{
			GlobalSettings.OwnsDronesBestFriend = true;
		}
		if (OwnedDbfSounds == null)
		{
			Debug.LogWarning("no dbf sounds found for galaxy map view");
		}
		GameAudio.Initialize();
		GameSaveFile.EndBatch();
		UniverseSaveFile.EndBatch();
		GalaxySaveFile.EndBatch();
	}

	private void Start()
	{
		GalaxySaveFile.BeginBatch();
		if (_loadInitialUpgrades)
		{
			_loadInitialUpgrades = false;
			if (GlobalSettings.RetrySameInitialState)
			{
				if (PresetManager.HasSnapshot)
				{
					PresetManager.BuildDronesFromPresetDefinition(PresetManager.SnapshotPreset, GlobalSettings.GameState.ThePlayer.Drones);
				}
				else
				{
					ChooseNextPreset();
				}
			}
			else
			{
				RandomlyChoosePlayerUpgrades();
				PresetManager.TakeSnapshot(GlobalSettings.GameState.ThePlayer.Drones);
			}
		}
		SetSelectedDungeon(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon, true);
		EventManager.Instance.SubscribeInstant(GeneralEventType.ShipUpgradeUninstalled, HandleShipUpgradeUninstalled);
		UpdateAllDungeonVisualDistanceIndications();
		if (GlobalSettings.GenerateGalaxyMapFromImage)
		{
			SetMapState(GalaxyMapState.StarSystems, true);
			List<int> vistedNodes = GalaxySaveFile.GetListStarSystemPath();
			if (vistedNodes != null && vistedNodes.Count > 1)
			{
				int count = vistedNodes.Count;
				for (int i = 0; i < count; i++)
				{
					if (GlobalSettings.GameState.StarSystems.Any((StarSystemInfo x) => x != null && x.Id == vistedNodes[i]))
					{
						StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems.First((StarSystemInfo x) => x != null && x.Id == vistedNodes[i]);
						if (starSystemInfo != null)
						{
							Mothership.Instance.ScanStarSystem(starSystemInfo);
						}
					}
				}
				if (hasBoardedDungeon)
				{
					SetMapState(GalaxyMapState.Dungeons, true);
				}
				else
				{
					_selectedStarSystem.galaxyNode.DungeonNodes.ForEach(delegate(DungeonNode x)
					{
						ShowDungeonNode(x, false);
					});
				}
			}
			else
			{
				if (GalaxyProcessor.universeMapManager != null && UniverseSaveFile.GetAllGroups("GX_", "VISITED", true).Count > 1)
				{
					_selectedStarSystem.galaxyNode.DungeonNodes.ForEach(delegate(DungeonNode x)
					{
						ShowDungeonNode(x, false);
					});
				}
				else
				{
					SetMapState(GalaxyMapState.Dungeons, true);
				}
				Mothership.Instance.ScanStarSystem(_selectedStarSystem);
			}
		}
		else
		{
			SetMapState(GalaxyMapState.Dungeons, true);
		}
		if (hasBoardedDungeon)
		{
			if (SelectedDungeon != null)
			{
				if (SelectedDungeon.Parent != null && SelectedDungeon.Parent.IsNursery)
				{
					SyncNurseryDataBetweenDataFiles();
				}
			}
			else
			{
				Debug.LogWarning("Odd issue - _selectedDungeon is null.  Means we can't sync with the nursery (who cares, actually - likely we weren't even in the nursery, just saying).  But it shouldn't happen, anyway!  Allowing for now for Alpha");
			}
			if (!GameSaveFile.Get("VIEWED_LOGMSG", false))
			{
				LogManager.InitManager();
				if (LogManager.LogDataFile.GetSetting("LAST_LOG_ID", 0) <= 0)
				{
				}
			}
		}
		GlobalSettings.GameState.ThePlayer.Inventory.InitialRefresh();
		_playerExpandedInventory.RefreshItems();
		Mothership.Instance.PostTravel();
		GalaxySaveFile.EndBatch();
		if (GalaxyProcessor.universeMapManager != null && GalaxyProcessor.universeMapManager.IsJumpingToGalaxy)
		{
			if (!GameSaveFile.Get("VIEWED_CONSTMSG", false))
			{
				if (!GameSaveFile.Get("HNT_DISABLE", false))
				{
				}
				GameSaveFile.Save("VIEWED_CONSTMSG", true);
			}
			GalaxyProcessor.universeMapManager.EndJumpToGalaxy();
		}
		AddSoundSources();
		if (!DisableAmbientSound)
		{
			asMotherShipAmbience.Play();
		}
		_helpManualWindow = new HelpManual();
		if (GlobalSettings.gameMode == GameModeEnum.Normal)
		{
			DataFile dataFile = new DataFile();
			string currentDataUniverseLocation = GameFileHelper.GetCurrentDataUniverseLocation();
			dataFile.InitSettingInstance(currentDataUniverseLocation, "~objprogressive.txt");
			GalaxyProcessor.SetObjectiveProgressFile(dataFile);
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
			{
				RefreshPandemicObjective(string.Empty);
				RefreshCosmicEventObjective();
				RefreshSuperPredatorObjective();
				RefreshGreyGooObjective();
				RefreshSingularityObjective();
			}
			int num = GameSaveFile.Get("MISSIONS", 0);
			if (!GameSaveFile.Get("OBSAMSTD", false))
			{
				int num2 = UnityEngine.Random.Range(7, 13);
				GameSaveFile.Save("OBSAMNXT", num + num2);
				GameSaveFile.Save("OBSAMSTD", true);
				Debug.Log(string.Format("SAM OBJECTIVE: First show will be after {0} missions", num2));
			}
			bool flag = false;
			int num3 = GameSaveFile.Get("OBSAMNXT", 0);
			if (num >= num3 && !GameSaveFile.Get("OBSAMCMPLTE", false) && hasBoardedDungeon)
			{
				flag = true;
				GameSaveFile.Save("OBSAMFIRST", true);
			}
			int num4 = GameSaveFile.Get("OBSAMLSTENTRY", -1);
			if (num4 == 0 && !hasBoardedDungeon)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				ObjectiveManual.AddObjective("sam", "hey you");
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (GameSaveFile.Get("OBSAMFIRST", false) && (num4 >= 0 || hasBoardedDungeon))
			{
				if (!ObjectiveManual.DoesObjectiveExist("sam"))
				{
					if (num4 != -1)
					{
						ObjectiveManual.IsIgnoringChanges = true;
					}
					ObjectiveManual.AddObjective("sam", "hey you");
					ObjectiveManual.IsIgnoringChanges = false;
				}
				string path = "Data/ShipsLogs/Sam/";
				if (flag)
				{
					int num5 = 0;
					bool flag2 = false;
					string text = string.Empty;
					string settingValue = string.Empty;
					do
					{
						switch (UnityEngine.Random.Range(0, 16))
						{
						case 0:
							text = "010-Hello";
							settingValue = "hello";
							break;
						case 1:
							text = "020-Adventures";
							settingValue = "adventures";
							break;
						case 2:
							text = "030-Celebrations";
							settingValue = "celebrations";
							break;
						case 3:
							text = "040-Dreams";
							settingValue = "dreams";
							break;
						case 4:
							text = "050-Arguments";
							settingValue = "arguments";
							break;
						case 5:
							text = "060-Hiding";
							settingValue = "hiding";
							break;
						case 6:
							text = "070-Protests";
							settingValue = "protests";
							break;
						case 7:
							text = "080-Control";
							settingValue = "control";
							break;
						case 8:
							text = "090-Threats";
							settingValue = "threats";
							break;
						case 9:
							text = "100-Doubt";
							settingValue = "doubt";
							break;
						case 10:
							text = "110-Void";
							settingValue = "void";
							break;
						case 11:
							text = "120-Debate";
							settingValue = "debate";
							break;
						case 12:
							text = "130-Bomb";
							settingValue = "bomb";
							break;
						case 13:
							text = "140-Sorry";
							settingValue = "sorry";
							break;
						case 14:
							text = "150-Communication";
							settingValue = "communication";
							break;
						case 15:
							text = "160-Listening";
							settingValue = "listening";
							break;
						}
						string text2 = LogManager.LogDataFile.GetGroup("SAM_", "FILE", text);
						if (text2 != string.Empty)
						{
							num5++;
							flag2 = true;
						}
						else
						{
							flag2 = false;
						}
					}
					while (flag2 && num5 < 50);
					if (!flag2)
					{
						num4++;
						LogManager.LogDataFile.SaveSetting("SAM_" + num4, "FILE", text);
						LogManager.LogDataFile.SaveSetting("SAM_" + num4, "TITLE", settingValue);
					}
					else
					{
						flag = false;
					}
				}
				List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName("SAM_");
				if (groupsByName.Count > 0)
				{
					int count2 = groupsByName.Count;
					for (int num6 = 0; num6 < count2; num6++)
					{
						string setting = LogManager.LogDataFile.GetSetting("SAM_" + num6, "FILE", string.Empty);
						string setting2 = LogManager.LogDataFile.GetSetting("SAM_" + num6, "TITLE", string.Empty);
						if (setting != string.Empty)
						{
							if (!flag || num4 > num6)
							{
								ObjectiveManual.IsIgnoringChanges = true;
							}
							ObjectiveManual.AddStep("sam", num6.ToString(), setting2, LogManager.GetLogFromResource(Path.Combine(path, setting), false));
							ObjectiveManual.IsIgnoringChanges = false;
						}
					}
				}
				if (flag)
				{
					if (num4 >= 15)
					{
						GameSaveFile.Save("OBSAMCMPLTE", true);
					}
					else if (num4 < 15)
					{
						GameSaveFile.Save("OBSAMLSTENTRY", num4);
						int num7 = UnityEngine.Random.Range(10, 21);
						Debug.Log(string.Format("SAM OBJECTIVE: Next entry show will be after {0} missions", num7));
						GameSaveFile.Save("OBSAMNXT", num + num7);
					}
					else if (num4 > 15)
					{
						Debug.LogError(string.Format("No Sam Objective found based on the last entry of {0}.  Is it possible the code is still trying to hand out objectives even though all have been shown?  Could also be possible more are added, but the code was not updated to include those...", num4));
					}
				}
			}
			if (ObjectiveManual.AnyChangedItems() && GameSaveFile.Get("FIRST_OBJECTIVE", true))
			{
				SystemOverlayUI.Instance.BeginBlinkObjectiveButton();
			}
		}
		if (BoardingConfigUiObject != null)
		{
			_boardingConfigUi = BoardingConfigUiObject.GetComponent<BoardingConfigUi>();
			_boardingConfigUi.IsVisible = false;
			_boardingConfigUi.shipBoarded = ShipBoarded;
		}
		else
		{
			Debug.LogError("could not find BoardingConfigUi");
		}
		if (BoardingConfigShipUpgradesUiObject != null)
		{
			_shipConfigUi = BoardingConfigShipUpgradesUiObject.GetComponent<BoardingConfigShipUpgradeUi>();
			_shipConfigUi.IsVisible = false;
		}
		else
		{
			Debug.LogError("could not find BoardingConfigShipUpgradeUi");
		}
		if (SystemOverlayUI.Instance != null)
		{
			SystemOverlayUI.Instance.SetScrap(GlobalSettings.GameState.ThePlayer.Inventory.Scrap);
			SystemOverlayUI.Instance.SetFuelPropulsion(GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge, GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve);
			SystemOverlayUI.Instance.SetFuelJump(GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel);
			SystemOverlayUI.Instance.RefreshPlayerShipInfo();
			SystemOverlayUI.Instance.RefreshDroneInfo();
			SystemOverlayUI.Instance.RefreshGalaxyInfo();
		}
		if (!hasBoardedDungeon)
		{
			scrapAtBoard = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		}
		if (!GameSaveFile.Get("FIRST_BOARD", false) || !GameSaveFile.Get("FIRST_READY", false))
		{
			if (!GameSaveFile.Get("HNT_DISABLE", false))
			{
				SystemOverlayUI.Instance.BeginBlinkBoardButton();
			}
		}
		else if (!_notifyPlayerAboutShipUpgrades || GameSaveFile.Get("HNT_SU", false))
		{
			if (!GameSaveFile.Get("FIRST_OBJECTIVE", false))
			{
				if (!GameSaveFile.Get("HNT_DISABLE", false))
				{
					SystemOverlayUI.Instance.BeginBlinkObjectiveButton();
				}
				GameSaveFile.Save("FIRST_OBJECTIVE", true);
			}
			else if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap > 0 && !GameSaveFile.Get("HNT_SCRAP", false) && GlobalSettings.gameMode == GameModeEnum.Normal)
			{
				enableScrapHint = true;
			}
		}
		int num8 = GameSaveFile.Get("Q_NOISE", 0);
		if (NoiseEffect.InstanceList != null)
		{
			int count3 = NoiseEffect.InstanceList.Count;
			for (int num9 = 0; num9 < count3; num9++)
			{
				NoiseEffect noiseEffect = NoiseEffect.InstanceList[num9];
				if (!(noiseEffect != null))
				{
					continue;
				}
				if (num8 != 2)
				{
					noiseEffect.enabled = true;
					float grainIntensityMin;
					switch (num8)
					{
					case 0:
						grainIntensityMin = 0.1f;
						break;
					case 1:
						grainIntensityMin = 0.05f;
						break;
					default:
						grainIntensityMin = 0f;
						break;
					}
					noiseEffect.grainIntensityMin = grainIntensityMin;
					float grainIntensityMax;
					switch (num8)
					{
					case 0:
						grainIntensityMax = 0.2f;
						break;
					case 1:
						grainIntensityMax = 0.1f;
						break;
					default:
						grainIntensityMax = 0f;
						break;
					}
					noiseEffect.grainIntensityMax = grainIntensityMax;
				}
				else
				{
					noiseEffect.enabled = false;
				}
			}
		}
		Application.runInBackground = GameSaveFile.Get("O_RIB", false);
		if (hasBoardedDungeon)
		{
			List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
			int count4 = itemsCopy.Count;
			for (int num10 = count4 - 1; num10 >= 0; num10--)
			{
				IInventoryItem inventoryItem = itemsCopy[num10];
				if (inventoryItem is BaseShipUpgrade && inventoryItem.IsBroken)
				{
					BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)inventoryItem;
					SlotInfo slotByUpgrade = GlobalSettings.GameState.ThePlayer.MyShip.GetSlotByUpgrade(baseShipUpgrade);
					if (slotByUpgrade != null)
					{
						slotByUpgrade.UnInstallUpgrade();
					}
					else
					{
						GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.RemoveInventoryItem(baseShipUpgrade);
					}
					GlobalSettings.GameState.ThePlayer.AddToInventory(baseShipUpgrade);
				}
			}
		}
		hasBoardedDungeon = false;
		if (menuPanel != null)
		{
			menuPanel.gameObject.SetActive(false);
		}
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			SystemOverlayUI.Instance.IsVisible = false;
			DungeonNode nodeFromDungeonInfo = GetNodeFromDungeonInfo(SelectedDungeon);
			nodeFromDungeonInfo.IsVisible = false;
			ShipBoarded();
			StarField.Instance.gameObject.SetActive(false);
			ReadyButtonPressed();
		}
		Debug.Log("***ENTERING***");
		if (SteamCore.Instance != null)
		{
			Debug.Log("***CONNECT***");
			SteamCore instance = SteamCore.Instance;
			instance.overlayToggled = (SteamCore.ScreenShownToggle)Delegate.Combine(instance.overlayToggled, new SteamCore.ScreenShownToggle(SteamOverlayToggle));
			Debug.Log("SteamCore.Instance.overlayToggled");
		}
		if (GalaxyProcessor.universeMapManager != null && UniverseSaveFile.GetAllGroups("GX_", "VISITED", true).Count > 1)
		{
			SystemOverlayUI.Instance.SetSystemProperties(GlobalSettings.GameState.ThePlayer.CurrentStarSystem, true);
			return;
		}
		DungeonNode nodeFromDungeonInfo2 = GetNodeFromDungeonInfo(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon);
		SystemOverlayUI.Instance.SetDungeonProperties(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon, nodeFromDungeonInfo2, 0);
	}

	private void OnDestroy()
	{
		RemoveSoundSources();
		Resources.UnloadUnusedAssets();
		ResourceManager.UnloadGalaxyResources();
		string galaxyFolderName = GameSaveFile.Get<string>("GALAXY_ID");
		GalaxyProcessor.DeinitalizeGalaxy(galaxyFolderName);
	}

	private void TestEndOfGameState()
	{
	}

	public void RefreshPandemicObjective(string initialStep)
	{
		if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
		{
			ObjectiveManual.StepStateEnum value = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "stepA", 0);
			ObjectiveManual.StepStateEnum value2 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "stepB", 0);
			ObjectiveManual.StepStateEnum value3 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "stepC", 0);
			ObjectiveManual.StepStateEnum value4 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "stepD", 0);
			ObjectiveManual.StepStateEnum value5 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "stepE", 0);
			ObjectiveManual.StepStateEnum value6 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteA", 0);
			ObjectiveManual.StepStateEnum value7 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteB", 0);
			ObjectiveManual.StepStateEnum value8 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteC", 0);
			ObjectiveManual.StepStateEnum value9 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteD", 0);
			ObjectiveManual.StepStateEnum value10 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteE", 0);
			ObjectiveManual.StepStateEnum value11 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteF", 0);
			ObjectiveManual.StepStateEnum value12 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("pandemic", "noteG", 0);
			if (value == ObjectiveManual.StepStateEnum.Unknown)
			{
				return;
			}
			bool flag = false;
			if (value == ObjectiveManual.StepStateEnum.AddedNew || value2 == ObjectiveManual.StepStateEnum.AddedNew || value3 == ObjectiveManual.StepStateEnum.AddedNew || value4 == ObjectiveManual.StepStateEnum.AddedNew || value5 == ObjectiveManual.StepStateEnum.AddedNew)
			{
				ObjectiveManual.IsIgnoringChanges = false;
			}
			else
			{
				ObjectiveManual.IsIgnoringChanges = true;
				flag = LogManager.LogDataFile.GetValue("pandemic", "COMPLETED", false);
			}
			ObjectiveManual.AddObjective("pandemic", "Pandemic");
			if (flag)
			{
				ObjectiveManual.SetObjectiveComplete("pandemic");
			}
			ObjectiveManual.IsIgnoringChanges = false;
			if (value != ObjectiveManual.StepStateEnum.Unknown)
			{
				if (value >= ObjectiveManual.StepStateEnum.AddedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("pandemic", "stepA", 2);
				}
				ObjectiveManual.AddStep("pandemic", "stepA", "Objective 1", "Data/ShipsLogs/Pandemic/storyDusker_01_Holmes_intro_log");
				ObjectiveManual.AddStep("pandemic", "theory_pandemic", "Theory", "Data/ShipsLogs/Pandemic/Holmes_Theory_log");
				ObjectiveManual.SetObjectiveStepComplete("pandemic", "theory_pandemic");
				ObjectiveManual.IsIgnoringChanges = false;
				if (value >= ObjectiveManual.StepStateEnum.CompletedNew)
				{
					ObjectiveManual.IsIgnoringChanges = true;
					if (value != ObjectiveManual.StepStateEnum.CompletedExisting)
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepA", 4);
					}
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepA");
					ObjectiveManual.IsIgnoringChanges = false;
				}
			}
			if (value2 != ObjectiveManual.StepStateEnum.Unknown)
			{
				if (value2 >= ObjectiveManual.StepStateEnum.AddedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("pandemic", "stepB", 2);
				}
				ObjectiveManual.AddStep("pandemic", "stepB", "Objective 2", "Data/ShipsLogs/Pandemic/Holmes_algorithm_log");
				ObjectiveManual.IsIgnoringChanges = false;
				if (value2 >= ObjectiveManual.StepStateEnum.CompletedNew)
				{
					if (value2 == ObjectiveManual.StepStateEnum.CompletedExisting)
					{
						ObjectiveManual.IsIgnoringChanges = true;
					}
					else
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepB", 4);
					}
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepB");
					ObjectiveManual.IsIgnoringChanges = false;
				}
			}
			if (value3 != ObjectiveManual.StepStateEnum.Unknown)
			{
				if (value3 >= ObjectiveManual.StepStateEnum.AddedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("pandemic", "stepC", 2);
				}
				ObjectiveManual.AddStep("pandemic", "stepC", "Objective 3", "Data/ShipsLogs/Pandemic/Holmes_Results01_log");
				ObjectiveManual.IsIgnoringChanges = false;
				if (value3 >= ObjectiveManual.StepStateEnum.CompletedNew)
				{
					if (value3 == ObjectiveManual.StepStateEnum.CompletedExisting)
					{
						ObjectiveManual.IsIgnoringChanges = true;
					}
					else
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepC", 4);
					}
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepC");
					ObjectiveManual.IsIgnoringChanges = false;
				}
			}
			if (value4 != ObjectiveManual.StepStateEnum.Unknown)
			{
				if (value4 >= ObjectiveManual.StepStateEnum.AddedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("pandemic", "stepD", 2);
				}
				ObjectiveManual.AddStep("pandemic", "stepD", "Objective 4", "Data/ShipsLogs/Pandemic/Holmes_ISHO_03_log");
				ObjectiveManual.IsIgnoringChanges = false;
				if (value4 >= ObjectiveManual.StepStateEnum.CompletedNew)
				{
					if (value4 == ObjectiveManual.StepStateEnum.CompletedExisting)
					{
						ObjectiveManual.IsIgnoringChanges = true;
					}
					else
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepD", 4);
					}
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepD");
					ObjectiveManual.IsIgnoringChanges = false;
				}
			}
			if (value5 != ObjectiveManual.StepStateEnum.Unknown)
			{
				if (value5 >= ObjectiveManual.StepStateEnum.AddedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("pandemic", "stepE", 2);
				}
				ObjectiveManual.AddStep("pandemic", "stepE", "Objective 5", "Data/ShipsLogs/Pandemic/Holmes_outro_02_log");
				ObjectiveManual.IsIgnoringChanges = false;
				if (value5 >= ObjectiveManual.StepStateEnum.CompletedNew)
				{
					if (value5 == ObjectiveManual.StepStateEnum.CompletedExisting)
					{
						ObjectiveManual.IsIgnoringChanges = true;
					}
					else
					{
						LogManager.LogDataFile.SaveValue("pandemic", "stepE", 4);
					}
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepE");
					ObjectiveManual.IsIgnoringChanges = false;
				}
			}
			if (value6 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.AddSeparator("pandemic");
				ObjectiveManual.IsIgnoringChanges = true;
				string text = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteA"));
				if (!string.IsNullOrEmpty(text))
				{
					string value13 = LogManager.LogDataFile.GetValue(text, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value13))
					{
						ObjectiveManual.AddStep("pandemic", "noteA", "Supporting 1", string.Format("Data/ShipsLogs/Pandemic/{0}", value13));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteA");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value7 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				string text2 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteB"));
				if (!string.IsNullOrEmpty(text2))
				{
					string value14 = LogManager.LogDataFile.GetValue(text2, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value14))
					{
						ObjectiveManual.AddStep("pandemic", "noteB", "Supporting 2", string.Format("Data/ShipsLogs/Pandemic/{0}", value14));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteB");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value8 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				string text3 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteC"));
				if (!string.IsNullOrEmpty(text3))
				{
					string value15 = LogManager.LogDataFile.GetValue(text3, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value15))
					{
						ObjectiveManual.AddStep("pandemic", "noteC", "Supporting 3", string.Format("Data/ShipsLogs/Pandemic/{0}", value15));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteC");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value9 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				string text4 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteD"));
				if (!string.IsNullOrEmpty(text4))
				{
					string value16 = LogManager.LogDataFile.GetValue(text4, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value16))
					{
						ObjectiveManual.AddStep("pandemic", "noteD", "Supporting 4", string.Format("Data/ShipsLogs/Pandemic/{0}", value16));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteD");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value10 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				string text5 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteE"));
				if (!string.IsNullOrEmpty(text5))
				{
					string value17 = LogManager.LogDataFile.GetValue(text5, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value17))
					{
						ObjectiveManual.AddStep("pandemic", "noteE", "Supporting 5", string.Format("Data/ShipsLogs/Pandemic/{0}", value17));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteE");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value11 != ObjectiveManual.StepStateEnum.Unknown)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				string text6 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteF"));
				if (!string.IsNullOrEmpty(text6))
				{
					string value18 = LogManager.LogDataFile.GetValue(text6, "FILE", string.Empty);
					if (!string.IsNullOrEmpty(value18))
					{
						ObjectiveManual.AddStep("pandemic", "noteF", "Supporting 6", string.Format("Data/ShipsLogs/Pandemic/{0}", value18));
						ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteF");
					}
				}
				ObjectiveManual.IsIgnoringChanges = false;
			}
			if (value12 == ObjectiveManual.StepStateEnum.Unknown)
			{
				return;
			}
			ObjectiveManual.IsIgnoringChanges = true;
			string text7 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_pandemic", "noteG"));
			if (!string.IsNullOrEmpty(text7))
			{
				string value19 = LogManager.LogDataFile.GetValue(text7, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value19))
				{
					ObjectiveManual.AddStep("pandemic", "noteG", "Supporting 7", string.Format("Data/ShipsLogs/Pandemic/{0}", value19));
					ObjectiveManual.SetObjectiveStepComplete("pandemic", "noteG");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		else
		{
			ObjectiveManual.AddObjective("pandemic", "Pandemic");
			ObjectiveManual.AddStep("pandemic", "stepA", "Theory", "Only an extremely virulent pathogen with the perfect storm of attributes would suffice as an existential risk. Given this hypothesis it's important that any drones sent aboard derelicts be thoroughly sterilized. This has been given lower priority given the distributed nature of a space faring civilization, however any supporting evidence will propel this to a higher priority theory.");
			ObjectiveManual.SetObjectiveStepComplete("pandemic", "stepA");
			ObjectiveManual.AddStep("pandemic", "stepC", "More Info", "The trading post bulletin you found is exactly what we needed. Looks like there was a pathogen of some sort that was spreading and became a serious risk. We need to find an uncorrupted version of this. It was likely duplicated and sent to all trading posts. We need you to find a whole one, or at least one with enough of the other half that we can discern what to do next. ", true);
			ObjectiveManual.AddStep("pandemic", "stepD", "Patient Zero", "This bulletin combined with the other pretty much spells it all out for us. You need to find a derelict that's been dormant for over a year, commandeer the vessel (thoroughly sterilize the cockpit before personally boarding) and bring it to a research outpost. Sounds like you'll be able to scan the ship from the facility (hopefully they've automated the procedure) but you'll need to do so remotely so make sure you have a drone that can interface with a terminal.  Then it's up to us to understand data from a future technology.", true);
			ObjectiveManual.AddStep("pandemic", "stepE", "Analysis", "[Alpha: Under Construction]", true);
			if (initialStep == "stepB")
			{
				ObjectiveManual.AddStep("pandemic", "stepB", "Quarantine", "The quarantine notice pushes the pandemic hypothesis to the high priority list. We need more information. There must be public health notices somewhere that could give us more information. Try trading posts, or if possible a research or medical facility.");
			}
			else if (initialStep == "stepC")
			{
				ObjectiveManual.SetVisibility("pandemic", "stepC", true);
			}
		}
	}

	public void RefreshSuperPredatorObjective()
	{
		ObjectiveManual.StepStateEnum value = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepA", 0);
		ObjectiveManual.StepStateEnum value2 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepB", 0);
		ObjectiveManual.StepStateEnum value3 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepC", 0);
		ObjectiveManual.StepStateEnum value4 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepD", 0);
		ObjectiveManual.StepStateEnum value5 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepE", 0);
		ObjectiveManual.StepStateEnum value6 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "stepF", 0);
		ObjectiveManual.StepStateEnum value7 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteA", 0);
		ObjectiveManual.StepStateEnum value8 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteB", 0);
		ObjectiveManual.StepStateEnum value9 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteC", 0);
		ObjectiveManual.StepStateEnum value10 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteD", 0);
		ObjectiveManual.StepStateEnum value11 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteE", 0);
		ObjectiveManual.StepStateEnum value12 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("superpredator", "noteF", 0);
		if (value == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		bool flag = false;
		if (value == ObjectiveManual.StepStateEnum.AddedNew || value2 == ObjectiveManual.StepStateEnum.AddedNew)
		{
			ObjectiveManual.IsIgnoringChanges = false;
		}
		else
		{
			ObjectiveManual.IsIgnoringChanges = true;
			flag = LogManager.LogDataFile.GetValue("superpredator", "COMPLETED", false);
		}
		ObjectiveManual.AddObjective("superpredator", "Super-Predator");
		if (flag)
		{
			ObjectiveManual.SetObjectiveComplete("superpredator");
		}
		ObjectiveManual.IsIgnoringChanges = false;
		if (value != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepA", 2);
			}
			ObjectiveManual.AddStep("superpredator", "stepA", "Objective 1", "Data/ShipsLogs/Super-Predator/SP_Intro_Log");
			ObjectiveManual.AddStep("superpredator", "theory_superpredator", "Theory", "Data/ShipsLogs/Super-Predator/SP_Theory_log");
			ObjectiveManual.SetObjectiveStepComplete("superpredator", "theory_superpredator");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				if (value != ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					LogManager.LogDataFile.SaveValue("superpredator", "stepA", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepA");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value2 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value2 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepB", 2);
			}
			ObjectiveManual.AddStep("superpredator", "stepB", "Objective 2", "Data/ShipsLogs/Super-Predator/SP_03_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value2 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value2 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("superpredator", "stepB", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepB");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value3 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value3 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepC", 2);
			}
			ObjectiveManual.AddStep("superpredator", "stepC", "Objective 3", "Data/ShipsLogs/Super-Predator/SP_04_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value3 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value3 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("superpredator", "stepC", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepC");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value4 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value4 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepD", 2);
			}
			ObjectiveManual.AddStep("superpredator", "stepD", "Objective 4", "Data/ShipsLogs/Super-Predator/SP_05_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value4 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value4 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("superpredator", "stepD", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepD");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value5 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value5 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("superpredator", "stepE", 2);
			}
			ObjectiveManual.AddStep("superpredator", "stepE", "Objective 5", "Data/ShipsLogs/Super-Predator/SP_06_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value5 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value5 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("superpredator", "stepE", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepE");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value7 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.AddSeparator("superpredator");
			ObjectiveManual.IsIgnoringChanges = true;
			string text = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteA"));
			if (!string.IsNullOrEmpty(text))
			{
				string value13 = LogManager.LogDataFile.GetValue(text, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value13))
				{
					ObjectiveManual.AddStep("superpredator", "noteA", "Supporting 1", string.Format("Data/ShipsLogs/Super-Predator/{0}", value13));
					ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteA");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value8 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text2 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteB"));
			if (!string.IsNullOrEmpty(text2))
			{
				string value14 = LogManager.LogDataFile.GetValue(text2, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value14))
				{
					ObjectiveManual.AddStep("superpredator", "noteB", "Supporting 2", string.Format("Data/ShipsLogs/Super-Predator/{0}", value14));
					ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteB");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value9 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text3 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteC"));
			if (!string.IsNullOrEmpty(text3))
			{
				string value15 = LogManager.LogDataFile.GetValue(text3, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value15))
				{
					ObjectiveManual.AddStep("superpredator", "noteC", "Supporting 3", string.Format("Data/ShipsLogs/Super-Predator/{0}", value15));
					ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteC");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value10 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text4 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteD"));
			if (!string.IsNullOrEmpty(text4))
			{
				string value16 = LogManager.LogDataFile.GetValue(text4, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value16))
				{
					ObjectiveManual.AddStep("superpredator", "noteD", "Supporting 4", string.Format("Data/ShipsLogs/Super-Predator/{0}", value16));
					ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteD");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value11 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text5 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteE"));
			if (!string.IsNullOrEmpty(text5))
			{
				string value17 = LogManager.LogDataFile.GetValue(text5, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value17))
				{
					ObjectiveManual.AddStep("superpredator", "noteE", "Supporting 5", string.Format("Data/ShipsLogs/Super-Predator/{0}", value17));
					ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteE");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value12 == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		ObjectiveManual.IsIgnoringChanges = true;
		string text6 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_superpredator", "noteF"));
		if (!string.IsNullOrEmpty(text6))
		{
			string value18 = LogManager.LogDataFile.GetValue(text6, "FILE", string.Empty);
			if (!string.IsNullOrEmpty(value18))
			{
				ObjectiveManual.AddStep("superpredator", "noteF", "Supporting 6", string.Format("Data/ShipsLogs/Super-Predator/{0}", value18));
				ObjectiveManual.SetObjectiveStepComplete("superpredator", "noteF");
			}
		}
		ObjectiveManual.IsIgnoringChanges = false;
	}

	public void RefreshGreyGooObjective()
	{
		ObjectiveManual.StepStateEnum value = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "stepA", 0);
		ObjectiveManual.StepStateEnum value2 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "stepB", 0);
		ObjectiveManual.StepStateEnum value3 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "noteA", 0);
		ObjectiveManual.StepStateEnum value4 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "noteB", 0);
		ObjectiveManual.StepStateEnum value5 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "noteC", 0);
		ObjectiveManual.StepStateEnum value6 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("greygoo", "noteD", 0);
		if (value == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		bool flag = false;
		if (value == ObjectiveManual.StepStateEnum.AddedNew || value2 == ObjectiveManual.StepStateEnum.AddedNew)
		{
			ObjectiveManual.IsIgnoringChanges = false;
		}
		else
		{
			ObjectiveManual.IsIgnoringChanges = true;
			flag = LogManager.LogDataFile.GetValue("greygoo", "COMPLETED", false);
		}
		ObjectiveManual.AddObjective("greygoo", "Grey Goo");
		if (flag)
		{
			ObjectiveManual.SetObjectiveComplete("greygoo");
		}
		ObjectiveManual.IsIgnoringChanges = false;
		if (value != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("greygoo", "stepA", 2);
			}
			ObjectiveManual.AddStep("greygoo", "stepA", "Objective 1", "Data/ShipsLogs/Grey Goo/GG_A_Log");
			ObjectiveManual.AddStep("greygoo", "theory_greygoo", "Theory", "Data/ShipsLogs/Grey Goo/GG_Theory_log");
			ObjectiveManual.SetObjectiveStepComplete("greygoo", "theory_greygoo");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				if (value != ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					LogManager.LogDataFile.SaveValue("greygoo", "stepA", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("greygoo", "stepA");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value2 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value2 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("greygoo", "stepB", 2);
			}
			ObjectiveManual.AddStep("greygoo", "stepB", "Objective 2", "Data/ShipsLogs/Grey Goo/GG_C_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value2 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value2 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("greygoo", "stepB", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("greygoo", "stepB");
				ObjectiveManual.AddStep("greygoo", "stepC", "Objective 3", "Data/ShipsLogs/Grey Goo/GG_D_Log");
				ObjectiveManual.SetObjectiveStepComplete("greygoo", "stepC");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value3 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.AddSeparator("greygoo");
			ObjectiveManual.IsIgnoringChanges = true;
			string text = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_greygoo", "noteA"));
			if (!string.IsNullOrEmpty(text))
			{
				string value7 = LogManager.LogDataFile.GetValue(text, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value7))
				{
					ObjectiveManual.AddStep("greygoo", "noteA", "Supporting 1", string.Format("Data/ShipsLogs/Grey Goo/{0}", value7));
					ObjectiveManual.SetObjectiveStepComplete("greygoo", "noteA");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value4 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text2 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_greygoo", "noteB"));
			if (!string.IsNullOrEmpty(text2))
			{
				string value8 = LogManager.LogDataFile.GetValue(text2, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value8))
				{
					ObjectiveManual.AddStep("greygoo", "noteB", "Supporting 2", string.Format("Data/ShipsLogs/Grey Goo/{0}", value8));
					ObjectiveManual.SetObjectiveStepComplete("greygoo", "noteB");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value5 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text3 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_greygoo", "noteC"));
			if (!string.IsNullOrEmpty(text3))
			{
				string value9 = LogManager.LogDataFile.GetValue(text3, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value9))
				{
					ObjectiveManual.AddStep("greygoo", "noteC", "Supporting 3", string.Format("Data/ShipsLogs/Grey Goo/{0}", value9));
					ObjectiveManual.SetObjectiveStepComplete("greygoo", "noteC");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value6 == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		ObjectiveManual.IsIgnoringChanges = true;
		string text4 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_greygoo", "noteD"));
		if (!string.IsNullOrEmpty(text4))
		{
			string value10 = LogManager.LogDataFile.GetValue(text4, "FILE", string.Empty);
			if (!string.IsNullOrEmpty(value10))
			{
				ObjectiveManual.AddStep("greygoo", "noteD", "Supporting 4", string.Format("Data/ShipsLogs/Grey Goo/{0}", value10));
				ObjectiveManual.SetObjectiveStepComplete("greygoo", "noteD");
			}
		}
		ObjectiveManual.IsIgnoringChanges = false;
	}

	public void RefreshCosmicEventObjective()
	{
		ObjectiveManual.StepStateEnum value = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "stepA", 0);
		ObjectiveManual.StepStateEnum value2 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "stepB", 0);
		ObjectiveManual.StepStateEnum value3 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "stepC", 0);
		ObjectiveManual.StepStateEnum value4 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "stepD", 0);
		ObjectiveManual.StepStateEnum value5 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "noteA", 0);
		ObjectiveManual.StepStateEnum value6 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "noteB", 0);
		ObjectiveManual.StepStateEnum value7 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "noteC", 0);
		ObjectiveManual.StepStateEnum value8 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("cosmic", "noteD", 0);
		if (value == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		bool flag = false;
		if (value == ObjectiveManual.StepStateEnum.AddedNew || value2 == ObjectiveManual.StepStateEnum.AddedNew)
		{
			ObjectiveManual.IsIgnoringChanges = false;
		}
		else
		{
			ObjectiveManual.IsIgnoringChanges = true;
			flag = LogManager.LogDataFile.GetValue("cosmic", "COMPLETED", false);
		}
		ObjectiveManual.AddObjective("cosmic", "Cosmic Event");
		if (flag)
		{
			ObjectiveManual.SetObjectiveComplete("cosmic");
		}
		ObjectiveManual.IsIgnoringChanges = false;
		if (value != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("cosmic", "stepA", 2);
			}
			ObjectiveManual.AddStep("cosmic", "stepA", "Objective 1", "Data/ShipsLogs/Cosmic Event/CE_Intro_Log");
			ObjectiveManual.AddStep("cosmic", "theory_cosmic", "Theory", "Data/ShipsLogs/Cosmic Event/CE_Theory_log");
			ObjectiveManual.SetObjectiveStepComplete("cosmic", "theory_cosmic");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				if (value != ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					LogManager.LogDataFile.SaveValue("cosmic", "stepA", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("cosmic", "stepA");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value2 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value2 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("cosmic", "stepB", 2);
			}
			ObjectiveManual.AddStep("cosmic", "stepB", "Objective 2", "Data/ShipsLogs/Cosmic Event/CE_A_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value2 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value2 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("cosmic", "stepB", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("cosmic", "stepB");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value3 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value3 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("cosmic", "stepC", 2);
			}
			ObjectiveManual.AddStep("cosmic", "stepC", "Objective 3", "Data/ShipsLogs/Cosmic Event/CE_C_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value3 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value3 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("cosmic", "stepC", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("cosmic", "stepC");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value4 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value4 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("cosmic", "stepD", 2);
			}
			ObjectiveManual.AddStep("cosmic", "stepD", "Objective 4", "Data/ShipsLogs/Cosmic Event/CE_D_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value3 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value3 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("cosmic", "stepD", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("cosmic", "stepD");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value5 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.AddSeparator("cosmic");
			ObjectiveManual.IsIgnoringChanges = true;
			string text = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_cosmic", "noteA"));
			if (!string.IsNullOrEmpty(text))
			{
				string value9 = LogManager.LogDataFile.GetValue(text, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value9))
				{
					ObjectiveManual.AddStep("cosmic", "noteA", "Supporting 1", string.Format("Data/ShipsLogs/Cosmic Event/{0}", value9));
					ObjectiveManual.SetObjectiveStepComplete("cosmic", "noteA");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value6 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text2 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_cosmic", "noteB"));
			if (!string.IsNullOrEmpty(text2))
			{
				string value10 = LogManager.LogDataFile.GetValue(text2, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value10))
				{
					ObjectiveManual.AddStep("cosmic", "noteB", "Supporting 2", string.Format("Data/ShipsLogs/Cosmic Event/{0}", value10));
					ObjectiveManual.SetObjectiveStepComplete("cosmic", "noteB");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value7 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text3 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_cosmic", "noteC"));
			if (!string.IsNullOrEmpty(text3))
			{
				string value11 = LogManager.LogDataFile.GetValue(text3, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value11))
				{
					ObjectiveManual.AddStep("cosmic", "noteC", "Supporting 3", string.Format("Data/ShipsLogs/Cosmic Event/{0}", value11));
					ObjectiveManual.SetObjectiveStepComplete("cosmic", "noteC");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value8 == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		ObjectiveManual.IsIgnoringChanges = true;
		string text4 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_cosmic", "noteD"));
		if (!string.IsNullOrEmpty(text4))
		{
			string value12 = LogManager.LogDataFile.GetValue(text4, "FILE", string.Empty);
			if (!string.IsNullOrEmpty(value12))
			{
				ObjectiveManual.AddStep("cosmic", "noteD", "Supporting 4", string.Format("Data/ShipsLogs/Cosmic Event/{0}", value12));
				ObjectiveManual.SetObjectiveStepComplete("cosmic", "noteD");
			}
		}
		ObjectiveManual.IsIgnoringChanges = false;
	}

	public void RefreshSingularityObjective()
	{
		ObjectiveManual.StepStateEnum value = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "stepA", 0);
		ObjectiveManual.StepStateEnum value2 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "stepB", 0);
		ObjectiveManual.StepStateEnum value3 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "stepC", 0);
		ObjectiveManual.StepStateEnum value4 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "stepD", 0);
		ObjectiveManual.StepStateEnum value5 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "stepE", 0);
		ObjectiveManual.StepStateEnum value6 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteA", 0);
		ObjectiveManual.StepStateEnum value7 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteB", 0);
		ObjectiveManual.StepStateEnum value8 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteC", 0);
		ObjectiveManual.StepStateEnum value9 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteD", 0);
		ObjectiveManual.StepStateEnum value10 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteE", 0);
		ObjectiveManual.StepStateEnum value11 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteF", 0);
		ObjectiveManual.StepStateEnum value12 = (ObjectiveManual.StepStateEnum)LogManager.LogDataFile.GetValue("singularity", "noteG", 0);
		if (value == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		bool flag = false;
		if (value == ObjectiveManual.StepStateEnum.AddedNew || value2 == ObjectiveManual.StepStateEnum.AddedNew)
		{
			ObjectiveManual.IsIgnoringChanges = false;
		}
		else
		{
			ObjectiveManual.IsIgnoringChanges = true;
			flag = LogManager.LogDataFile.GetValue("singularity", "COMPLETED", false);
		}
		ObjectiveManual.AddObjective("singularity", "Singularity");
		if (flag)
		{
			ObjectiveManual.SetObjectiveComplete("singularity");
		}
		ObjectiveManual.IsIgnoringChanges = false;
		if (value != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("singularity", "stepA", 2);
			}
			ObjectiveManual.AddStep("singularity", "stepA", "Objective 1", "Data/ShipsLogs/Singularity/SING_A_Log");
			ObjectiveManual.AddStep("singularity", "theory_singularity", "Theory", "Data/ShipsLogs/Singularity/SING_Theory_log");
			ObjectiveManual.SetObjectiveStepComplete("singularity", "theory_singularity");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				ObjectiveManual.IsIgnoringChanges = true;
				if (value != ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					LogManager.LogDataFile.SaveValue("singularity", "stepA", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("singularity", "stepA");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value2 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value2 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("singularity", "stepB", 2);
			}
			ObjectiveManual.AddStep("singularity", "stepB", "Objective 2", "Data/ShipsLogs/Singularity/SING_C_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value2 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value2 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("singularity", "stepB", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("singularity", "stepB");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value3 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value3 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("singularity", "stepC", 2);
			}
			ObjectiveManual.AddStep("singularity", "stepC", "Objective 3", "Data/ShipsLogs/Singularity/SING_D_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value3 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value3 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("singularity", "stepC", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("singularity", "stepC");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value4 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value4 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("singularity", "stepD", 2);
			}
			ObjectiveManual.AddStep("singularity", "stepD", "Objective 4", "Data/ShipsLogs/Singularity/SING_E_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value4 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value4 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("singularity", "stepD", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("singularity", "stepD");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value5 != ObjectiveManual.StepStateEnum.Unknown)
		{
			if (value5 >= ObjectiveManual.StepStateEnum.AddedExisting)
			{
				ObjectiveManual.IsIgnoringChanges = true;
			}
			else
			{
				LogManager.LogDataFile.SaveValue("singularity", "stepE", 2);
			}
			ObjectiveManual.AddStep("singularity", "stepE", "Objective 5", "Data/ShipsLogs/Singularity/SING_F_Log");
			ObjectiveManual.IsIgnoringChanges = false;
			if (value5 >= ObjectiveManual.StepStateEnum.CompletedNew)
			{
				if (value5 == ObjectiveManual.StepStateEnum.CompletedExisting)
				{
					ObjectiveManual.IsIgnoringChanges = true;
				}
				else
				{
					LogManager.LogDataFile.SaveValue("singularity", "stepE", 4);
				}
				ObjectiveManual.SetObjectiveStepComplete("singularity", "stepE");
				ObjectiveManual.IsIgnoringChanges = false;
			}
		}
		if (value6 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.AddSeparator("singularity");
			ObjectiveManual.IsIgnoringChanges = true;
			string text = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteA"));
			if (!string.IsNullOrEmpty(text))
			{
				string value13 = LogManager.LogDataFile.GetValue(text, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value13))
				{
					ObjectiveManual.AddStep("singularity", "noteA", "Supporting 1", string.Format("Data/ShipsLogs/Singularity/{0}", value13));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteA");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value7 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text2 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteB"));
			if (!string.IsNullOrEmpty(text2))
			{
				string value14 = LogManager.LogDataFile.GetValue(text2, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value14))
				{
					ObjectiveManual.AddStep("singularity", "noteB", "Supporting 2", string.Format("Data/ShipsLogs/Singularity/{0}", value14));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteB");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value8 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text3 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteC"));
			if (!string.IsNullOrEmpty(text3))
			{
				string value15 = LogManager.LogDataFile.GetValue(text3, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value15))
				{
					ObjectiveManual.AddStep("singularity", "noteC", "Supporting 3", string.Format("Data/ShipsLogs/Singularity/{0}", value15));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteC");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value9 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text4 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteD"));
			if (!string.IsNullOrEmpty(text4))
			{
				string value16 = LogManager.LogDataFile.GetValue(text4, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value16))
				{
					ObjectiveManual.AddStep("singularity", "noteD", "Supporting 4", string.Format("Data/ShipsLogs/Singularity/{0}", value16));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteD");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value10 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text5 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteE"));
			if (!string.IsNullOrEmpty(text5))
			{
				string value17 = LogManager.LogDataFile.GetValue(text5, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value17))
				{
					ObjectiveManual.AddStep("singularity", "noteE", "Supporting 5", string.Format("Data/ShipsLogs/Singularity/{0}", value17));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteE");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value11 != ObjectiveManual.StepStateEnum.Unknown)
		{
			ObjectiveManual.IsIgnoringChanges = true;
			string text6 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteF"));
			if (!string.IsNullOrEmpty(text6))
			{
				string value18 = LogManager.LogDataFile.GetValue(text6, "FILE", string.Empty);
				if (!string.IsNullOrEmpty(value18))
				{
					ObjectiveManual.AddStep("singularity", "noteF", "Supporting 6", string.Format("Data/ShipsLogs/Singularity/{0}", value18));
					ObjectiveManual.SetObjectiveStepComplete("singularity", "noteF");
				}
			}
			ObjectiveManual.IsIgnoringChanges = false;
		}
		if (value12 == ObjectiveManual.StepStateEnum.Unknown)
		{
			return;
		}
		ObjectiveManual.IsIgnoringChanges = true;
		string text7 = LogManager.LogDataFile.GetGroup("OBJ_", "ITEM", string.Format("{0}_singularity", "noteG"));
		if (!string.IsNullOrEmpty(text7))
		{
			string value19 = LogManager.LogDataFile.GetValue(text7, "FILE", string.Empty);
			if (!string.IsNullOrEmpty(value19))
			{
				ObjectiveManual.AddStep("singularity", "noteG", "Supporting 7", string.Format("Data/ShipsLogs/Singularity/{0}", value19));
				ObjectiveManual.SetObjectiveStepComplete("singularity", "noteG");
			}
		}
		ObjectiveManual.IsIgnoringChanges = false;
	}

	private void UpdateGalaxyOverlays()
	{
		if (stargateConnectionLines != null)
		{
			foreach (GameObject stargateConnectionLine in stargateConnectionLines)
			{
				stargateConnectionLine.SetActive(false);
				UnityEngine.Object.Destroy(stargateConnectionLine);
			}
			stargateConnectionLines.Clear();
		}
		int count = GlobalSettings.GameState.StarSystems.Count;
		for (int i = 0; i < count - 1; i++)
		{
			StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems[i];
			if (!starSystemInfo.IsStargateVisited)
			{
				continue;
			}
			for (int j = i + 1; j < count; j++)
			{
				StarSystemInfo starSystemInfo2 = GlobalSettings.GameState.StarSystems[j];
				if (starSystemInfo2.IsStargateVisited)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(UniverseMapManager.connectionLinePrefab);
					((LineRenderer)gameObject.GetComponent<Renderer>()).SetPosition(0, starSystemInfo.galaxyNode.transform.position);
					((LineRenderer)gameObject.GetComponent<Renderer>()).SetPosition(1, starSystemInfo2.galaxyNode.transform.position);
					if (stargateConnectionLines == null)
					{
						stargateConnectionLines = new List<GameObject>();
					}
					gameObject.GetComponent<Renderer>().material = StarGateConnectionLineMaterial;
					gameObject.SetActive(true);
					stargateConnectionLines.Add(gameObject);
				}
			}
		}
	}

	private bool CreateInitialNonVisualDrones()
	{
		bool result = true;
		GlobalSettings.GameState.ThePlayer.Drones.Clear();
		List<string> list = null;
		if (!GlobalSettings.IsTutorial)
		{
			list = UniverseSaveFile.GetAllGroups("DRONE_");
		}
		if (list == null || list.Count == 0)
		{
			List<int> list2 = new List<int>();
			UniverseSaveFile.BeginBatch();
			bool flag = GameSaveFile.Get("PLAYS", 0) == 1;
			System.Random rnd = new System.Random(UnityEngine.Random.seed);
			for (int i = 0; i < 3; i++)
			{
				int seed = UnityEngine.Random.seed;
				NonVisualDrone nonVisualDrone = new NonVisualDrone();
				nonVisualDrone.DroneNumber = i + 1;
				DroneCharacteristics.Assign(nonVisualDrone, true, GlobalSettings.GameState.ThePlayer.Drones, rnd);
				nonVisualDrone.CurrentHitPoints = nonVisualDrone.TotalHitpoints;
				nonVisualDrone.NumberOfUpgradeSlots = 3;
				nonVisualDrone.AppliedModifications = ModificationStorageIdEnum.None;
				nonVisualDrone.engineType = (EngineTypeEnum)UnityEngine.Random.Range(0, 2);
				int num = -1;
				do
				{
					num = UnityEngine.Random.Range(0, 13);
				}
				while (list2.Contains(num));
				if (flag)
				{
					switch (i)
					{
					case 0:
						num = 3;
						break;
					case 1:
						num = 2;
						break;
					case 2:
						num = 4;
						break;
					}
				}
				list2.Add(num);
				nonVisualDrone.CSID = num;
				if (UnityEngine.Random.Range(0, 100) < 50)
				{
					float traitPitchOffset = UnityEngine.Random.Range(-0.2f, 0.1f);
					nonVisualDrone.TraitPitchOffset = traitPitchOffset;
				}
				GlobalSettings.GameState.ThePlayer.Drones.Add(nonVisualDrone);
			}
			int count = GlobalSettings.GameState.ThePlayer.Drones.Count;
			for (int j = 0; j < count; j++)
			{
				int newInternalID = 0;
				do
				{
					newInternalID = UnityEngine.Random.Range(1, int.MaxValue);
				}
				while (GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => x != null && x.InternalID == newInternalID));
				GlobalSettings.GameState.ThePlayer.Drones[j].InternalID = newInternalID;
			}
			GlobalSettings.GameState.ThePlayer.Drones = GlobalSettings.GameState.ThePlayer.Drones.OrderByDescending((IDrone x) => x.TotalHitpoints * x.OriginalSpeed).ToList();
			int droneNumberCounter = 1;
			GlobalSettings.GameState.ThePlayer.Drones.ForEach(delegate(IDrone x)
			{
				x.DroneNumber = droneNumberCounter++;
			});
			if (!GlobalSettings.IsTutorial)
			{
				if (GameSaveFile.Get("PLAYS", 0) <= 1)
				{
					GlobalSettings.GameState.ThePlayer.Drones[0].DroneVisualIndex = 0;
					GlobalSettings.GameState.ThePlayer.Drones[1].DroneVisualIndex = 1;
					GlobalSettings.GameState.ThePlayer.Drones[2].DroneVisualIndex = 2;
				}
				foreach (NonVisualDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
				{
					drone.Initalize(false);
					string groupKey = string.Format("DRONE_{0}", drone.InternalID);
					UniverseSaveFile.Save(groupKey, "ID", drone.InternalID);
					UniverseSaveFile.Save(groupKey, "DVPSEED", drone.DVPSeed);
					UniverseSaveFile.Save(groupKey, "DVPNAME", drone.DVPName);
					UniverseSaveFile.Save(groupKey, "TRAIT_V", drone.TraitVeer);
					UniverseSaveFile.Save(groupKey, "TRAIT_VP", drone.TraitPermVeer);
					UniverseSaveFile.Save(groupKey, "TRAIT_P", drone.TraitPitchOffset);
					UniverseSaveFile.Save(groupKey, "CSID", drone.CSID);
					UniverseSaveFile.Save(groupKey, "NUM", drone.DroneNumber);
					UniverseSaveFile.Save(groupKey, "NAME", drone.DroneName);
					UniverseSaveFile.Save(groupKey, "SPD", drone.OriginalSpeed);
					UniverseSaveFile.Save(groupKey, "SLOTCT", drone.NumberOfUpgradeSlots);
					UniverseSaveFile.Save(groupKey, "THP", drone.TotalHitpoints);
					UniverseSaveFile.Save(groupKey, "HP", drone.CurrentHitPoints);
					UniverseSaveFile.Save(groupKey, "RSTATE", drone.CanBeFullyRepaired);
					UniverseSaveFile.Save(groupKey, "DRONE_APPLIED_MODS", (int)drone.AppliedModifications);
					UniverseSaveFile.Save(groupKey, "DRONE_VIS_IDX", drone.DroneVisualIndex);
					UniverseSaveFile.Save(groupKey, "ENG", drone.engineType.ToString());
				}
			}
			UniverseSaveFile.EndBatch();
		}
		else
		{
			result = false;
			foreach (string item in list)
			{
				NonVisualDrone nonVisualDrone3 = new NonVisualDrone();
				nonVisualDrone3.InternalID = UniverseSaveFile.Get(item, "ID", -1);
				nonVisualDrone3.DVPSeed = UniverseSaveFile.Get(item, "DVPSEED", -1);
				nonVisualDrone3.DVPName = UniverseSaveFile.Get(item, "DVPNAME", string.Empty);
				nonVisualDrone3.CSID = UniverseSaveFile.Get(item, "CSID", -1);
				nonVisualDrone3.DroneNumber = UniverseSaveFile.Get(item, "NUM", -1);
				nonVisualDrone3.TraitVeer = UniverseSaveFile.Get(item, "TRAIT_V", 0f);
				nonVisualDrone3.TraitPermVeer = UniverseSaveFile.Get(item, "TRAIT_VP", 0f);
				nonVisualDrone3.TraitPitchOffset = UniverseSaveFile.Get(item, "TRAIT_P", 0f);
				nonVisualDrone3.OriginalSpeed = UniverseSaveFile.Get(item, "SPD", 1f);
				nonVisualDrone3.NumberOfUpgradeSlots = UniverseSaveFile.Get(item, "SLOTCT", 3);
				nonVisualDrone3.CurrentHitPoints = UniverseSaveFile.Get(item, "HP", 100f);
				nonVisualDrone3.DroneVisualIndex = UniverseSaveFile.Get(item, "DRONE_VIS_IDX", 0);
				nonVisualDrone3.CanBeFullyRepaired = UniverseSaveFile.Get(item, "RSTATE", false);
				nonVisualDrone3.IsDead = UniverseSaveFile.Get(item, "DSTATE", false);
				nonVisualDrone3.engineType = (EngineTypeEnum)(int)Enum.Parse(typeof(EngineTypeEnum), UniverseSaveFile.Get(item, "ENG", EngineTypeEnum.EngineA.ToString()));
				NonVisualDrone nonVisualDrone4 = nonVisualDrone3;
				if (nonVisualDrone4.DroneNumber >= 0)
				{
					bool flag2 = false;
					if (string.IsNullOrEmpty(nonVisualDrone4.DroneName) || nonVisualDrone4.DroneName == "ERROR")
					{
						Debug.LogError("DRONE DATA ERROR: Drone name empty.  Ignoring.");
						flag2 = true;
					}
					foreach (IDrone drone2 in GlobalSettings.GameState.ThePlayer.Drones)
					{
						if (drone2.DroneNumber == nonVisualDrone4.DroneNumber)
						{
							Debug.LogError("DRONE DATA ERROR: Drone number duplicated.  Ignoring second copy.");
							flag2 = true;
						}
						else if (flag2)
						{
							break;
						}
					}
					if (flag2)
					{
						continue;
					}
					nonVisualDrone4.Initalize(true);
					nonVisualDrone4.OverrideTotalHitpoints(UniverseSaveFile.Get(item, "THP", nonVisualDrone4.CurrentHitPoints));
					nonVisualDrone4.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(item, "DRONE_APPLIED_MODS", 0);
					DroneUpgradeFactory.Initialize();
					List<string> allGroups = UniverseSaveFile.GetAllGroups("INVITMD", "P", nonVisualDrone4.GroupKey);
					foreach (string item2 in allGroups)
					{
						string[] array = item2.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
						int result2 = -1;
						int.TryParse(array[1], out result2);
						string value = UniverseSaveFile.Get(item2, "TYPE", "Undefined");
						DroneUpgradeType type = (DroneUpgradeType)(int)Enum.Parse(typeof(DroneUpgradeType), value, true);
						BaseDroneUpgrade baseDroneUpgrade = DroneUpgradeFactory.CreateUpgradeInstance(type, result2);
						if (baseDroneUpgrade == null)
						{
							continue;
						}
						int num2 = UniverseSaveFile.Get(item2, "SLOT", -1);
						if (baseDroneUpgrade is IStorageUpgrade)
						{
							int qty = UniverseSaveFile.Get(item2, "QTY", 0);
							((IStorageUpgrade)baseDroneUpgrade).OverrideQuantity(qty);
						}
						if (baseDroneUpgrade is IPoweredObject)
						{
							float power = UniverseSaveFile.Get(item2, "QTY", ((IPoweredObject)baseDroneUpgrade).TotalPower);
							((IPoweredObject)baseDroneUpgrade).OverridePower(power);
						}
						if (baseDroneUpgrade is IBreakable)
						{
							string value2 = UniverseSaveFile.Get(item2, "STATE", "None");
							BrokenStateEnum brokenStateEnum = (BrokenStateEnum)(int)Enum.Parse(typeof(BrokenStateEnum), value2, true);
							if (brokenStateEnum != BrokenStateEnum.None)
							{
								((IBreakable)baseDroneUpgrade).OverrideBrokenState(brokenStateEnum);
							}
						}
						if (baseDroneUpgrade is IDamagableObject && baseDroneUpgrade is IOverrideHitpoints)
						{
							float hitpoints = UniverseSaveFile.Get(item2, "INV_HP", ((IDamagableObject)baseDroneUpgrade).CurrentHitPoints);
							((IOverrideHitpoints)baseDroneUpgrade).OverrideCurrentHitpoints(hitpoints);
							float hitpoints2 = UniverseSaveFile.Get(item2, "INV_HP_TOTAL", ((IDamagableObject)baseDroneUpgrade).TotalHitpoints);
							((IOverrideHitpoints)baseDroneUpgrade).OverrideTotalHitpoints(hitpoints2);
						}
						baseDroneUpgrade.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(item2, "INV_MODS", 0);
						baseDroneUpgrade.NumMissions = UniverseSaveFile.Get(item2, "INV_MISSIONS", 0);
						baseDroneUpgrade.ErrorMissions = UniverseSaveFile.Get(item2, "INV_ERROR_MISSIONS", 0);
						baseDroneUpgrade.BreakTime = UniverseSaveFile.Get(item2, "INV_BREAK_TIME", 120f);
						baseDroneUpgrade.ErrorTime = UniverseSaveFile.Get(item2, "INV_ERROR_TIME", 0f);
						baseDroneUpgrade.BreakProbability = UniverseSaveFile.Get(item2, "INV_BREAK_PROB", 0f);
						baseDroneUpgrade.TimeInMissionPostErrorMision = UniverseSaveFile.Get(item2, "INV_TIME_POST_ERROR_MISSION", 0f);
						if (num2 == -1)
						{
							nonVisualDrone4.AddDroneUpgrade(baseDroneUpgrade);
						}
						else
						{
							nonVisualDrone4.AddDroneUpgrade(num2, baseDroneUpgrade);
						}
					}
					GlobalSettings.GameState.ThePlayer.Drones.Add(nonVisualDrone4);
				}
				else
				{
					Debug.LogError("DRONE DATA ERROR: a corrupted drone was found in the data with a number of -1.  Have ignored on load.");
				}
			}
			GlobalSettings.GameState.ThePlayer.Drones = GlobalSettings.GameState.ThePlayer.Drones.OrderBy((IDrone x) => x.DroneNumber).ToList();
		}
		foreach (IDrone drone3 in GlobalSettings.GameState.ThePlayer.Drones)
		{
			drone3.IsVisible = true;
		}
		return result;
	}

	public static int GetDroneUpgradeSlot(BaseDroneUpgrade droneUpgrade, out string parentKey)
	{
		parentKey = "PLAYER";
		int num = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy.IndexOf(droneUpgrade);
		if (num == -1)
		{
			foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
			{
				for (int i = 0; i < drone.Upgrades.Count; i++)
				{
					if (droneUpgrade == drone.Upgrades[i])
					{
						num = i;
						parentKey = ((NonVisualDrone)drone).GroupKey;
						break;
					}
				}
				if (num != -1)
				{
					break;
				}
			}
		}
		return num;
	}

	public static int GetShipUpgradeSlot(BaseShipUpgrade shipUpgrade, out string parentKey)
	{
		parentKey = "PLAYER";
		int num = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy.IndexOf(shipUpgrade);
		if (num == -1)
		{
			int inventoryCount = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount;
			for (int i = 0; i < inventoryCount; i++)
			{
				if (shipUpgrade == GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[i])
				{
					num = i;
					parentKey = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[i].GroupKey;
					break;
				}
			}
		}
		return num;
	}

	private void CheckForNewMapImages()
	{
		GameFileHelper.EnsureGameFileDirectoriesExist();
		string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
		string[] files = Directory.GetFiles(dataGalaxyLocation, "*.png", SearchOption.TopDirectoryOnly);
		if (files.Length > 0)
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			StreamWriter streamWriter = File.AppendText(Path.Combine(dataGalaxyLocation, "log.txt"));
			streamWriter.WriteLine(string.Empty);
			streamWriter.WriteLine("{0}: Found {1} file(s) at '{2}'.  Processing...", DateTime.Now, files.Length, dataGalaxyLocation);
			string[] array = files;
			foreach (string text in array)
			{
				if (text.EndsWith("X"))
				{
					continue;
				}
				string fileName = Path.GetFileName(text);
				string[] array2 = fileName.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
				string key = array2[0];
				if (array2.Length != 2)
				{
					string text2 = Path.Combine(dataGalaxyLocation, fileName);
					string text3 = text2 + "X";
					File.Copy(text2, text3, true);
					File.Delete(text2);
					streamWriter.WriteLine(string.Format("{0}: ERROR - File name in wrong format.  Expected 'NAME_TYPE.png'.  Renamed file so that it won't be processed again.  Original name: '{1}', new name: '{2}'", DateTime.Now, text2, text3));
				}
				else
				{
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, new List<string>());
					}
					dictionary[key].Add(fileName);
				}
			}
			Dictionary<string, List<string>>.Enumerator enumerator = dictionary.GetEnumerator();
			string text4 = string.Empty;
			int num = 0;
			int num2 = 0;
			while (enumerator.MoveNext())
			{
				num++;
				string text5 = Path.Combine(dataGalaxyLocation, enumerator.Current.Key);
				if (!Directory.Exists(text5))
				{
					Directory.CreateDirectory(text5);
				}
				if (string.IsNullOrEmpty(text4))
				{
					text4 = enumerator.Current.Key;
				}
				string[] files2 = Directory.GetFiles(text5, "_d*.png");
				if (files2.Length > 0)
				{
					string[] array3 = files2;
					foreach (string path in array3)
					{
						File.Delete(path);
					}
				}
				foreach (string item in enumerator.Current.Value)
				{
					try
					{
						string text6 = Path.Combine(dataGalaxyLocation, item);
						string[] array4 = item.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
						string[] array5 = array4[1].Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries);
						switch (array5[0].ToLower())
						{
						case "dm":
							File.Copy(text6, Path.Combine(text5, "_mDM.png"), true);
							File.Delete(text6);
							num2++;
							continue;
						case "tm":
							File.Copy(text6, Path.Combine(text5, "_mTM.png"), true);
							File.Delete(text6);
							num2++;
							continue;
						case "tdm":
							File.Copy(text6, Path.Combine(text5, "_mTDM.png"), true);
							File.Delete(text6);
							num2++;
							continue;
						case "dim":
							File.Copy(text6, Path.Combine(text5, "_mDIM.png"), true);
							File.Delete(text6);
							num2++;
							continue;
						}
						string text7 = text6;
						string text8 = text7 + "X";
						File.Copy(text7, text8, true);
						File.Delete(text7);
						streamWriter.WriteLine(string.Format("{0}: ERROR - File name in wrong format.  Expected '{1}_TYPE.png', where TYPE = DM (density map), TM (type map), or TDM (type density map).  Renamed file so that it won't be processed again.  Original name: '{2}', new name: '{3}'", DateTime.Now, enumerator.Current.Key, text7, text8));
					}
					catch (Exception ex)
					{
						string text9 = Path.Combine(dataGalaxyLocation, item);
						string destFileName = text9 + "X";
						File.Copy(text9, destFileName, true);
						File.Delete(text9);
						streamWriter.WriteLine(string.Format("{0}: ERROR - Unhandled exception occured while processing file '{1}'.  Exception: {2}", DateTime.Now, enumerator.Current.Key, ex.Message));
					}
				}
			}
			streamWriter.WriteLine(string.Format("{0}: Added or Modified {1} galaxy data directories, and successfully moved a total of {2} files", DateTime.Now, num, num2));
			if (num == 1)
			{
				GameSaveFile.Save("GALAXY_ID", text4);
				streamWriter.WriteLine(string.Format("{0}: Set current in-game galaxy to {1}.", DateTime.Now, text4));
			}
			else
			{
				streamWriter.WriteLine(string.Format("{0}: There were multiple galaxies, and the current galaxy was NOT changed.  To specify a specific galaxy to use, edit 'gamesave.txt' file in the root 'Duskers' game data folder, and add/change GALAXY_ID=NAME_OF_GALAXY, where NAME_OF_GALAXY = folder name holding galaxy data, as found in '{1}'", DateTime.Now, dataGalaxyLocation));
			}
			streamWriter.Close();
		}
		List<string> listOfGalaxyFolders = GalaxySaveFile.GetListOfGalaxyFolders(true);
		if (listOfGalaxyFolders.Count != 0)
		{
			return;
		}
		Debug.LogWarning("This system doesn't have any installed galaxy maps.  Creating a map from the one in unity.");
		string text10 = densityMapName;
		if (string.IsNullOrEmpty(text10))
		{
			text10 = "DEFAULT";
		}
		string text11 = Path.Combine(dataGalaxyLocation, text10);
		if (!Directory.Exists(text11))
		{
			Directory.CreateDirectory(text11);
		}
		depthMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", densityMapName));
		if (!string.IsNullOrEmpty(typeMapName))
		{
			typeMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", typeMapName));
		}
		else
		{
			typeMapSourceTexture = null;
		}
		if (!string.IsNullOrEmpty(typeDensityMapName))
		{
			typeDensityMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", typeDensityMapName));
		}
		else
		{
			typeDensityMapSourceTexture = null;
		}
		if (!string.IsNullOrEmpty(difficultyMapName))
		{
			difficultyMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", difficultyMapName));
		}
		else
		{
			difficultyMapSourceTexture = null;
		}
		byte[] array6 = depthMapSourceTexture.EncodeToJPG();
		FileStream fileStream = null;
		if (array6 != null)
		{
			fileStream = File.Create(Path.Combine(text11, "_mDM.png"));
			fileStream.Write(array6, 0, array6.Length);
			fileStream.Close();
		}
		if (typeMapSourceTexture != null)
		{
			array6 = typeMapSourceTexture.EncodeToPNG();
			if (array6 != null)
			{
				fileStream = File.Create(Path.Combine(text11, "_mTM.png"));
				fileStream.Write(array6, 0, array6.Length);
				fileStream.Close();
			}
		}
		if (typeDensityMapSourceTexture != null)
		{
			array6 = typeDensityMapSourceTexture.EncodeToPNG();
			if (array6 != null)
			{
				fileStream = File.Create(Path.Combine(text11, "_mTDM.png"));
				fileStream.Write(array6, 0, array6.Length);
				fileStream.Close();
			}
		}
		if (difficultyMapSourceTexture != null)
		{
			array6 = difficultyMapSourceTexture.EncodeToPNG();
			if (array6 != null)
			{
				fileStream = File.Create(Path.Combine(text11, "_mDIM.png"));
				fileStream.Write(array6, 0, array6.Length);
				fileStream.Close();
			}
		}
		depthMapSourceTexture = null;
		typeMapSourceTexture = null;
		typeDensityMapSourceTexture = null;
		difficultyMapSourceTexture = null;
		GameSaveFile.Save("GALAXY_ID", text10);
	}

	private void GenerateGalaxyFromImage()
	{
		bool flag = false;
		int seed = UnityEngine.Random.seed;
		UnityEngine.Random.seed = GalaxySaveFile.GetGalaxySeed(seed);
		int seed2 = UnityEngine.Random.seed;
		if (UnityEngine.Random.seed != seed)
		{
			flag = true;
		}
		GlobalSettings.GameState.NextSystemId = UniverseSaveFile.Get("LAST_SYS_ID", 1);
		galaxyMapGenerationSeed = UnityEngine.Random.seed;
		GalaxySaveFile.SaveGalaxySeed(galaxyMapGenerationSeed);
		int num = ((!flag) ? (-1) : GalaxySaveFile.GetLastEntryStarSystemPath());
		if (string.IsNullOrEmpty(densityMapName))
		{
			Debug.LogWarning("No depth map name provided.  Can't generate star system");
			return;
		}
		string galaxyFolderName = GameSaveFile.Get<string>("GALAXY_ID");
		if (!GalaxyProcessor.InitalizeGalaxy(galaxyFolderName))
		{
			galaxyFolderName = GameSaveFile.Get<string>("GALAXY_ID");
			string dataGalaxyLocation = GameFileHelper.GetDataGalaxyLocation();
			string path = Path.Combine(dataGalaxyLocation, galaxyFolderName);
			if (depthMapSourceTexture == null)
			{
				depthMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", densityMapName));
			}
			if (typeMapSourceTexture == null)
			{
				if (!string.IsNullOrEmpty(typeMapName))
				{
					typeMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", typeMapName));
				}
				else
				{
					typeMapSourceTexture = null;
				}
			}
			if (typeDensityMapSourceTexture == null)
			{
				if (!string.IsNullOrEmpty(typeDensityMapName))
				{
					typeDensityMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", typeDensityMapName));
				}
				else
				{
					typeDensityMapSourceTexture = null;
				}
			}
			if (difficultyMapSourceTexture == null)
			{
				if (!string.IsNullOrEmpty(difficultyMapName))
				{
					difficultyMapSourceTexture = ResourceManager.LoadAsset<Texture2D>(string.Format("Textures/{0}", difficultyMapName));
				}
				else
				{
					difficultyMapSourceTexture = null;
				}
			}
			byte[] array = depthMapSourceTexture.EncodeToJPG();
			FileStream fileStream = null;
			if (array != null)
			{
				fileStream = File.Create(Path.Combine(path, "_mDM.png"));
				fileStream.Write(array, 0, array.Length);
				fileStream.Close();
			}
			if (typeMapSourceTexture != null)
			{
				array = typeMapSourceTexture.EncodeToPNG();
				if (array != null)
				{
					fileStream = File.Create(Path.Combine(path, "_mTM.png"));
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
				}
			}
			if (typeDensityMapSourceTexture != null)
			{
				array = typeDensityMapSourceTexture.EncodeToPNG();
				if (array != null)
				{
					fileStream = File.Create(Path.Combine(path, "_mTDM.png"));
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
				}
			}
			if (difficultyMapSourceTexture != null)
			{
				array = difficultyMapSourceTexture.EncodeToPNG();
				if (array != null)
				{
					fileStream = File.Create(Path.Combine(path, "_mDIM.png"));
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
				}
			}
			Debug.LogWarning("Could not load galaxy map images from file system - built them from the ones in Unity");
		}
		seed2 = UnityEngine.Random.seed;
		GlobalSettings.GameState.ThePlayer.CurrentStarSystem = null;
		List<StarSystemInfo> collection = GalaxyProcessor.BuildStarSystems(seed2);
		GlobalSettings.GameState.StarSystems = new List<StarSystemInfo>(collection);
		UnityEngine.Random.seed = seed;
	}

	private void DetermineStartupStarSystem(bool useLastVisitedSystem)
	{
		int lastStarSystemVisted = GalaxySaveFile.GetLastEntryStarSystemPath();
		bool flag = false;
		bool flag2 = false;
		List<StarSystemInfo> list = null;
		string text = UniverseSaveFile.Get("GHOP", string.Empty);
		string[] array = text.Split(',');
		int num = array.Length;
		int starSystemPathCount = GalaxySaveFile.GetStarSystemPathCount();
		bool flag3 = GameSaveFile.Get("NC", false);
		GlobalSettings.GameState.ThePlayer.CurrentStarSystem = null;
		if (GlobalSettings.gameMode == GameModeEnum.Normal || (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge && GlobalSettings.IsContinuingWeeklyChallenge))
		{
			if (!useLastVisitedSystem)
			{
				UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
				int numberMatchesInOriginalRange = 0;
				float minDifficultyBestMatch = 0f;
				float maxDifficultyBestMatch = 0f;
				float num2 = 0f;
				float num3 = 0.65f;
				if (GameSaveFile.Get("HARD", false))
				{
					num2 = 0.45f;
					num3 = 1f;
				}
				List<StarSystemInfo> list2 = GalaxyProcessor.FilterStarSystemByDifficulty(num2, num3, 3, true, out numberMatchesInOriginalRange, out minDifficultyBestMatch, out maxDifficultyBestMatch);
				IEnumerable<StarSystemInfo> enumerable = null;
				if (list2 == null)
				{
					int numberMatchesInOriginalRange2 = 0;
					float minDifficultyBestMatch2 = 0f;
					float maxDifficultyBestMatch2 = 0f;
					list2 = GalaxyProcessor.FilterStarSystemByDifficulty(minDifficultyBestMatch, maxDifficultyBestMatch, 3, false, out numberMatchesInOriginalRange2, out minDifficultyBestMatch2, out maxDifficultyBestMatch2);
					if (list2 != null)
					{
						Debug.LogWarning(string.Format("Too few nodes ({5} vs the {6} requested) found using a min-max of {0}-{1}.  Expanded the range to {2}-{3} for {4} matching nodes.", num2, num3, minDifficultyBestMatch, maxDifficultyBestMatch, list2.Count, numberMatchesInOriginalRange, 3));
					}
					else
					{
						Debug.LogError(string.Format("Too few nodes ({4} vs the {5} requested) found after 2 attempts.  First, using a min-max of {0}-{1}.  Then expanded to the range of {2}-{3}.  Starting placement will continue, but w/o considering area's difficulty.", num2, num3, minDifficultyBestMatch, maxDifficultyBestMatch, numberMatchesInOriginalRange, 3));
					}
				}
				if (list2 != null)
				{
					enumerable = list2.Where(GalaxyProcessor.IsValidStartingStarSystem);
					if (enumerable == null)
					{
						Debug.LogWarning(string.Format("There were {0} nodes found by difficulty alone, but they all failed the additional tests for a valid starting node.  We are rejecting the list filtered by difficulty and using the entire list of star systems.", list2.Count()));
					}
				}
				if (enumerable == null)
				{
					enumerable = GlobalSettings.GameState.StarSystems.Where(GalaxyProcessor.IsValidStartingStarSystem);
				}
				list = enumerable.ToList();
				int bestHopCount = 0;
				List<StarSystemInfo> list3 = GalaxyProcessor.FilterStarSystemsByPotentialHops(3, list, out bestHopCount);
				if (list3 != null && list3.Count > 0)
				{
					Debug.Log(string.Format("Based on number of hops, we have filtered the list of potential start up systems from {0} to {1}.  Best (longest) hop: {2}", list.Count, list3.Count, bestHopCount));
					list = list3;
				}
				else
				{
					bool flag4 = false;
					if (bestHopCount > 1)
					{
						list3 = GalaxyProcessor.FilterStarSystemsByPotentialHops(bestHopCount, list, out bestHopCount);
						if (list3 != null && list3.Count > 0)
						{
							list = list3;
							flag4 = true;
						}
					}
					if (!flag4)
					{
						Debug.LogWarning(string.Format("We didn't find any valid starting nodes where the player could travel a minimum of {0} hops - the best we found was {1} hops.  We are rejecting the list being filtered by # of potential hops.", 3, bestHopCount));
					}
				}
				Debug.Log(string.Format("filteredList: {0}", list.Count));
				if (!flag3)
				{
					StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems.FirstOrDefault((StarSystemInfo x) => x != null && x.Id == lastStarSystemVisted);
					if (starSystemInfo != null)
					{
						bool flag5 = false;
						List<string> allGroups = GalaxySaveFile.GetAllGroups("OBJ_", "P", starSystemInfo.GroupKey);
						foreach (string item in allGroups)
						{
							if (!GalaxySaveFile.Get(item, "VISITED", false))
							{
								flag5 = true;
								break;
							}
						}
						if (!flag5)
						{
							MarkNurseyAsVisited();
							flag3 = true;
						}
						flag2 = !flag5;
					}
				}
				else if (num <= 1 && flag3 && starSystemPathCount == 1)
				{
					flag2 = true;
				}
				if ((num > 1 || starSystemPathCount >= 2 || flag2) && list != null && list.Count > 0)
				{
					int index = UnityEngine.Random.Range(0, list.Count);
					GlobalSettings.GameState.ThePlayer.CurrentStarSystem = list[index];
					if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id == 0)
					{
						int num4 = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "ID", 0);
						if (num4 == 0)
						{
							num4 = GlobalSettings.GameState.NextSystemId++;
						}
						GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id = num4;
					}
					GalaxySaveFile.AppendStarSystemToPath(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
					GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
					flag = true;
				}
			}
			if (!flag)
			{
				if (useLastVisitedSystem)
				{
					Debug.Log(string.Format("Attempting to start in the same system as previous play"));
				}
				if ((useLastVisitedSystem || false || (num <= 1 && starSystemPathCount < 2)) && lastStarSystemVisted != -1)
				{
					GlobalSettings.GameState.ThePlayer.CurrentStarSystem = GlobalSettings.GameState.StarSystems.FirstOrDefault((StarSystemInfo x) => x != null && x.Id == lastStarSystemVisted);
					if (flag3)
					{
					}
				}
				if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null)
				{
					if (!flag3 && list != null && list.Count > 0)
					{
						IEnumerable<StarSystemInfo> enumerable2 = list.Where((StarSystemInfo x) => x != null && !x.HasStargate);
						list = ((enumerable2 == null) ? null : enumerable2.ToList());
					}
					if (list == null || list.Count() == 0)
					{
						Debug.LogWarning("No valid locations in this map!  Just picking one at random...");
						List<StarSystemInfo> list4 = GlobalSettings.GameState.StarSystems;
						if (!flag3)
						{
							IEnumerable<StarSystemInfo> enumerable3 = list4.Where((StarSystemInfo x) => x != null && !x.HasStargate);
							if (enumerable3 != null && enumerable3.Count() > 0)
							{
								list4 = enumerable3.ToList();
							}
							else
							{
								Debug.LogError("Trying to pick starting nursery system at random, because all other filters failed however it looks like ALL systems are marked as stargates.  The nursey is the priority, so a stargate has been lost.");
							}
						}
						GlobalSettings.GameState.ThePlayer.CurrentStarSystem = list4[UnityEngine.Random.Range(0, list4.Count)];
						if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id == 0)
						{
							int num5 = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "ID", 0);
							if (num5 == 0)
							{
								num5 = GlobalSettings.GameState.NextSystemId++;
							}
							GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id = num5;
						}
						GalaxySaveFile.AppendStarSystemToPath(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
						GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
					}
					else
					{
						foreach (StarSystemInfo item2 in list)
						{
							if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null)
							{
								GlobalSettings.GameState.ThePlayer.CurrentStarSystem = item2;
							}
							if (UnityEngine.Random.Range(0, 2) == 0)
							{
								GlobalSettings.GameState.ThePlayer.CurrentStarSystem = item2;
							}
						}
						if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id == 0)
						{
							int num6 = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "ID", 0);
							if (num6 == 0)
							{
								num6 = GlobalSettings.GameState.NextSystemId++;
							}
							GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id = num6;
						}
					}
					if (num <= 1)
					{
						GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery = !GameSaveFile.Get("HARD", false);
						GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "SS", true);
					}
				}
			}
			if (lastStarSystemVisted == -1)
			{
				GalaxySaveFile.StartStarSystemPath(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
				GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
			}
			return;
		}
		int count = GlobalSettings.GameState.StarSystems.Count;
		if (count > 0)
		{
			int index2 = UnityEngine.Random.Range(0, count);
			GlobalSettings.GameState.ThePlayer.CurrentStarSystem = GlobalSettings.GameState.StarSystems[index2];
			if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id == 0)
			{
				int num7 = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "ID", 0);
				if (num7 == 0)
				{
					num7 = GlobalSettings.GameState.NextSystemId++;
				}
				GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id = num7;
			}
			GalaxySaveFile.StartStarSystemPath(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
			GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
		}
		else
		{
			Debug.LogError("Challeng can't start - No Star Systems found.  Unable to choose where to start!");
		}
	}

	private void MarkNurseyAsVisited()
	{
		if (!GameSaveFile.Get("NC", false))
		{
			GameSaveFile.Save("NC", true);
			SyncNurseryDataBetweenDataFiles();
		}
	}

	private void SyncNurseryDataBetweenDataFiles()
	{
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null || GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons == null)
		{
			return;
		}
		bool flag = false;
		List<string> list = new List<string>();
		UniverseSaveFile.BeginBatch();
		int count = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.Count;
		for (int i = 0; i < count; i++)
		{
			DungeonInfo dungeonInfo = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons[i];
			string text = dungeonInfo.GroupKey.Replace("OBJ_", "OBJN_");
			if (UniverseSaveFile.Exists(text))
			{
				UniverseSaveFile.Save(text, "VISITED", GalaxySaveFile.Get(dungeonInfo.GroupKey, "VISITED", false));
			}
			else
			{
				List<KeyValuePair<string, string>> groupDataItems = GalaxySaveFile.GetGroupDataItems(dungeonInfo.GroupKey);
				foreach (KeyValuePair<string, string> item in groupDataItems)
				{
					UniverseSaveFile.Save(text, item.Key, item.Value);
				}
				UniverseSaveFile.Save(text, "P", "SYS_NURSERY");
				flag = true;
			}
			list.Add(text);
		}
		if (flag)
		{
			List<string> allGroups = UniverseSaveFile.GetAllGroups("OBJN_");
			foreach (string item2 in allGroups)
			{
				if (!list.Contains(item2))
				{
					UniverseSaveFile.ClearGroup(item2);
				}
			}
		}
		UniverseSaveFile.EndBatch();
	}

	private void CollectNodesCanTravelToRecursive()
	{
	}

	private void FillTradingPostInventory(TradingPostInfo tradingPost)
	{
		bool flag = false;
		string empty = string.Empty;
		empty = tradingPost.GroupKey;
		if (GalaxySaveFile.Get(empty, "VISITED", false))
		{
			if (tradingPost.Inventory.InventoryCount == 0)
			{
				List<string> allGroups = UniverseSaveFile.GetAllGroups("INVITMD", "P", empty);
				List<string> allGroups2 = GalaxySaveFile.GetAllGroups("INVITMS", "P", empty);
				foreach (string item in allGroups)
				{
					string[] array = item.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
					int result = -1;
					int.TryParse(array[1], out result);
					string text = UniverseSaveFile.Get(item, "TYPE", string.Empty);
					DroneUpgradeType type = (DroneUpgradeType)(int)Enum.Parse(typeof(DroneUpgradeType), UniverseSaveFile.Get(item, "TYPE", string.Empty));
					BaseDroneUpgrade baseDroneUpgrade = DroneUpgradeFactory.CreateUpgradeInstance(type, result);
					baseDroneUpgrade.AppliedModifications = (ModificationStorageIdEnum)UniverseSaveFile.Get(item, "INV_MODS", 0);
					baseDroneUpgrade.NumMissions = UniverseSaveFile.Get(item, "INV_MISSIONS", 0);
					baseDroneUpgrade.ErrorMissions = UniverseSaveFile.Get(item, "INV_ERROR_MISSIONS", 0);
					baseDroneUpgrade.BreakTime = UniverseSaveFile.Get(item, "INV_BREAK_TIME", 120f);
					baseDroneUpgrade.ErrorTime = UniverseSaveFile.Get(item, "INV_ERROR_TIME", 0f);
					baseDroneUpgrade.BreakProbability = UniverseSaveFile.Get(item, "INV_BREAK_PROB", 0f);
					baseDroneUpgrade.TimeInMissionPostErrorMision = UniverseSaveFile.Get(item, "INV_TIME_POST_ERROR_MISSION", 0f);
					if (baseDroneUpgrade is IStorageUpgrade)
					{
						int num = UniverseSaveFile.Get(baseDroneUpgrade.GroupKey, "QTY", -1);
						if (num > -1)
						{
							((IStorageUpgrade)baseDroneUpgrade).OverrideQuantity(num);
						}
					}
					tradingPost.Inventory.AddInventoryItem(baseDroneUpgrade);
				}
				foreach (string item2 in allGroups2)
				{
					string[] array2 = item2.Split(new char[1] { '_' }, StringSplitOptions.RemoveEmptyEntries);
					int result2 = -1;
					int.TryParse(array2[1], out result2);
					ShipUpgradeType upgradeType = (ShipUpgradeType)(int)Enum.Parse(typeof(ShipUpgradeType), GalaxySaveFile.Get(item2, "TYPE", string.Empty));
					BaseShipUpgrade baseShipUpgrade = ShipUpgradeFactory.CreateUpgrade(upgradeType, result2);
					tradingPost.Inventory.AddInventoryItem(baseShipUpgrade);
					baseShipUpgrade.AppliedModifications = (ModificationStorageIdEnum)GalaxySaveFile.Get(baseShipUpgrade.GroupKey, "INV_MODS", 0);
					baseShipUpgrade.NumMissions = UniverseSaveFile.Get(item2, "INV_MISSIONS", 0);
					baseShipUpgrade.BreakProbability = UniverseSaveFile.Get(item2, "INV_BREAK_PROB", 0f);
				}
			}
			flag = true;
		}
		if (flag)
		{
			return;
		}
		tradingPost.Inventory.Scrap = UnityEngine.Random.Range(5, 21);
		int num2 = UnityEngine.Random.Range(2, 7);
		for (int i = 0; i < num2; i++)
		{
			DroneUpgradeType upgradeType2 = DroneUpgradeType.Undefined;
			BaseDroneUpgrade baseDroneUpgrade2 = DroneUpgradeFactory.CreateRandom(out upgradeType2);
			int num3 = (baseDroneUpgrade2.NumMissions = UnityEngine.Random.Range(0, 3));
			if (num3 > 0)
			{
				for (int j = 0; j < num3; j++)
				{
					float num5 = UnityEngine.Random.Range(3f, 6f);
					float num6 = baseDroneUpgrade2.UpgradeBreakFactor * num5;
					baseDroneUpgrade2.BreakProbability += num6;
				}
			}
			if (baseDroneUpgrade2 is IStorageUpgrade && UnityEngine.Random.Range(0, 100) < 20)
			{
				((IStorageUpgrade)baseDroneUpgrade2).OverrideQuantity(0);
				UniverseSaveFile.Save(baseDroneUpgrade2.GroupKey, "QTY", ((IStorageUpgrade)baseDroneUpgrade2).Quantity);
			}
			tradingPost.Inventory.AddInventoryItem(baseDroneUpgrade2);
		}
		int num7 = UnityEngine.Random.Range(0, 3);
		for (int k = 0; k < num7; k++)
		{
			ShipUpgradeType upgradeType3 = ShipUpgradeType.Unknown;
			BaseShipUpgrade baseShipUpgrade2 = ShipUpgradeFactory.CreateRandom(out upgradeType3);
			int num8 = (baseShipUpgrade2.NumMissions = UnityEngine.Random.Range(0, 3));
			if (num8 > 0)
			{
				for (int l = 0; l < num8; l++)
				{
					float num10 = UnityEngine.Random.Range(3f, 6f);
					float num11 = baseShipUpgrade2.UpgradeBreakFactor * num10;
					baseShipUpgrade2.BreakProbability += num11;
				}
			}
			tradingPost.Inventory.AddInventoryItem(baseShipUpgrade2);
		}
		tradingPost.Inventory.PropulsionFuelReserve = UnityEngine.Random.Range(0, 2);
		tradingPost.Inventory.JumpFuel = UnityEngine.Random.Range(0, 2);
		if (!GalaxySaveFile.Get(empty, "VISITED", false))
		{
			GalaxySaveFile.Save(empty, "VISITED", true);
			int num12 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", tradingPost.DungeonType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", tradingPost.DungeonType), num12);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", tradingPost.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", tradingPost.DungeonType), 0) + 1);
			if (num12 > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", tradingPost.DungeonType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", tradingPost.DungeonType), num12);
			}
		}
		tradingPost.Parent.Refresh();
	}

	private List<ShipInfestationType> RandomPickInfestationTypes()
	{
		float num = 0.5f;
		List<ShipInfestationType> list = new List<ShipInfestationType>();
		List<ShipInfestationType> list2 = new List<ShipInfestationType>();
		for (int i = 1; i < 5; i++)
		{
			list2.Add((ShipInfestationType)i);
		}
		bool flag = false;
		while (!flag && list2.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list2.Count);
			list.Add(list2[index]);
			list2.RemoveAt(index);
			if (UnityEngine.Random.Range(0f, 1f) > num)
			{
				flag = true;
			}
		}
		return list;
	}

	private void CreateGalaxyNodes()
	{
		_starSystemNodes = new List<GalaxyNode>();
		List<KeyCode> list = new List<KeyCode>(invalidDungeonKeys);
		int count = GlobalSettings.GameState.StarSystems.Count;
		for (int i = 0; i < count; i++)
		{
			StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems[i];
			starSystemInfo.OnStarSystemEvent = (StarSystemInfoEventDelegate)Delegate.Remove(starSystemInfo.OnStarSystemEvent, new StarSystemInfoEventDelegate(HandleStarSystemEvent));
			starSystemInfo.OnStarSystemEvent = (StarSystemInfoEventDelegate)Delegate.Combine(starSystemInfo.OnStarSystemEvent, new StarSystemInfoEventDelegate(HandleStarSystemEvent));
			GameObject gameObject = UnityEngine.Object.Instantiate(StarSystemNodePrefab);
			GalaxyNode component = gameObject.GetComponent<GalaxyNode>();
			component.Info = starSystemInfo;
			component.Info.galaxyNode = component;
			gameObject.transform.position = starSystemInfo.Coordinates;
			_starSystemNodes.Add(component);
			bool flag = false;
			int num = 0;
			int num2 = 0;
			do
			{
				num = UnityEngine.Random.Range(97, 123);
				if (!FastKeysContains(list, (KeyCode)num))
				{
					list.Add((KeyCode)num);
					flag = true;
				}
				else
				{
					num2++;
				}
			}
			while (!flag && num2 < 500);
			if (flag)
			{
				component.SetShortcutKey((KeyCode)num);
			}
			else
			{
				Debug.LogError(string.Format("Couldn't assign a shortcut key!  Likely we've assigned all possible.  Current count: {0}", list.Count));
			}
		}
		count = GlobalSettings.GameState.StarSystems.Count;
		for (int j = 0; j < count; j++)
		{
			StarSystemInfo starSystemInfo2 = GlobalSettings.GameState.StarSystems[j];
			for (int k = 0; k < 4; k++)
			{
				StarSystemInfo starSystemInfo3 = null;
				Vector3 vector = Vector3.zero;
				float num3 = float.MaxValue;
				List<StarSystemInfo> list2 = null;
				int count2 = GlobalSettings.GameState.StarSystems.Count;
				switch (k)
				{
				case 0:
				{
					for (int num4 = 0; num4 < count2; num4++)
					{
						StarSystemInfo starSystemInfo7 = GlobalSettings.GameState.StarSystems[num4];
						if (starSystemInfo7 != null && starSystemInfo7.Coordinates.x < starSystemInfo2.Coordinates.x)
						{
							if (list2 == null)
							{
								list2 = new List<StarSystemInfo>();
							}
							list2.Add(starSystemInfo7);
						}
					}
					break;
				}
				case 1:
				{
					for (int m = 0; m < count2; m++)
					{
						StarSystemInfo starSystemInfo5 = GlobalSettings.GameState.StarSystems[m];
						if (starSystemInfo5 != null && starSystemInfo5.Coordinates.x > starSystemInfo2.Coordinates.x)
						{
							if (list2 == null)
							{
								list2 = new List<StarSystemInfo>();
							}
							list2.Add(starSystemInfo5);
						}
					}
					break;
				}
				case 2:
				{
					for (int n = 0; n < count2; n++)
					{
						StarSystemInfo starSystemInfo6 = GlobalSettings.GameState.StarSystems[n];
						if (starSystemInfo6 != null && starSystemInfo6.Coordinates.y > starSystemInfo2.Coordinates.y)
						{
							if (list2 == null)
							{
								list2 = new List<StarSystemInfo>();
							}
							list2.Add(starSystemInfo6);
						}
					}
					break;
				}
				case 3:
				{
					for (int l = 0; l < count2; l++)
					{
						StarSystemInfo starSystemInfo4 = GlobalSettings.GameState.StarSystems[l];
						if (starSystemInfo4 != null && starSystemInfo4.Coordinates.y < starSystemInfo2.Coordinates.y)
						{
							if (list2 == null)
							{
								list2 = new List<StarSystemInfo>();
							}
							list2.Add(starSystemInfo4);
						}
					}
					break;
				}
				}
				if (list2 == null)
				{
					continue;
				}
				int count3 = list2.Count;
				for (int num5 = 0; num5 < count3; num5++)
				{
					StarSystemInfo starSystemInfo8 = list2[num5];
					float num6 = 0f;
					Vector3 vector2 = Vector3.zero;
					float num7 = 1.4f;
					switch (k)
					{
					case 0:
					case 1:
						vector2 = starSystemInfo8.Coordinates - starSystemInfo2.Coordinates;
						vector2.Normalize();
						if (Mathf.Abs(vector2.y) > Mathf.Abs(vector2.x * num7))
						{
							continue;
						}
						num6 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo8.Coordinates);
						break;
					case 2:
					case 3:
						vector2 = starSystemInfo8.Coordinates - starSystemInfo2.Coordinates;
						vector2.Normalize();
						if (Mathf.Abs(vector2.x) > Mathf.Abs(vector2.y * num7))
						{
							continue;
						}
						num6 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo8.Coordinates);
						break;
					}
					float num8 = num6 / num3;
					if (!((double)num8 <= 1.6))
					{
						continue;
					}
					bool flag2 = false;
					if (starSystemInfo3 != null)
					{
						switch (k)
						{
						case 0:
						case 1:
							if (num6 < num3 && Mathf.Abs(vector.y) < Mathf.Abs(vector2.y))
							{
								float num13 = Mathf.Abs(vector.y) / Mathf.Abs(vector.x);
								float num14 = Mathf.Abs(vector2.y) / Mathf.Abs(vector2.x);
								if (num14 >= 1f)
								{
									flag2 = true;
								}
								else if (num3 * (1f - num13) * num14 > num6)
								{
									flag2 = true;
								}
							}
							else if (num3 < num6 && Mathf.Abs(vector.y) > Mathf.Abs(vector2.y))
							{
								float num15 = Mathf.Abs(vector.y) / Mathf.Abs(vector.x);
								float num16 = Mathf.Abs(vector2.y) / Mathf.Abs(vector2.x);
								if (num6 * num16 < num3 * (1f + num15))
								{
									flag2 = true;
								}
							}
							else if (num3 < num6)
							{
								flag2 = true;
							}
							break;
						case 2:
						case 3:
							if (num6 < num3 && Mathf.Abs(vector.x) < Mathf.Abs(vector2.x))
							{
								float num9 = Mathf.Abs(vector.x) / Mathf.Abs(vector.y);
								float num10 = Mathf.Abs(vector2.x) / Mathf.Abs(vector2.y);
								if (num10 >= 1f)
								{
									flag2 = true;
								}
								else if (num3 * (1f - num9) * num10 > num6)
								{
									flag2 = true;
								}
							}
							else if (num3 < num6 && Mathf.Abs(vector.x) > Mathf.Abs(vector2.x))
							{
								float num11 = Mathf.Abs(vector.x) / Mathf.Abs(vector.y);
								float num12 = Mathf.Abs(vector2.x) / Mathf.Abs(vector2.y);
								if (num6 * num12 < num3 * (1f + num11))
								{
									flag2 = true;
								}
							}
							else if (num3 < num6)
							{
								flag2 = true;
							}
							break;
						}
					}
					if (!flag2)
					{
						vector = vector2;
						num3 = num6;
						starSystemInfo3 = starSystemInfo8;
					}
				}
				if (starSystemInfo3 == null)
				{
					continue;
				}
				switch (k)
				{
				case 0:
					starSystemInfo2.LeftStar = starSystemInfo3;
					if (starSystemInfo3.RightStar != null)
					{
						if (starSystemInfo3.Id == 22 && starSystemInfo3.RightStar.Id == 21)
						{
							int num21 = 0;
							num21++;
						}
						float num22 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo3.Coordinates);
						float num23 = Vector3.Distance(starSystemInfo3.Coordinates, starSystemInfo3.RightStar.Coordinates);
						if (num22 < num23)
						{
							starSystemInfo3.RightStar = starSystemInfo2;
						}
					}
					else
					{
						starSystemInfo3.RightStar = starSystemInfo2;
					}
					break;
				case 1:
					starSystemInfo2.RightStar = starSystemInfo3;
					if (starSystemInfo3.LeftStar != null)
					{
						float num24 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo3.Coordinates);
						float num25 = Vector3.Distance(starSystemInfo3.Coordinates, starSystemInfo3.LeftStar.Coordinates);
						if (num24 < num25)
						{
							starSystemInfo3.LeftStar = starSystemInfo2;
						}
					}
					else
					{
						starSystemInfo3.LeftStar = starSystemInfo2;
					}
					break;
				case 2:
					starSystemInfo2.AboveStar = starSystemInfo3;
					if (starSystemInfo3.BelowStar != null)
					{
						float num19 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo3.Coordinates);
						float num20 = Vector3.Distance(starSystemInfo3.Coordinates, starSystemInfo3.BelowStar.Coordinates);
						if (num19 < num20)
						{
							starSystemInfo3.BelowStar = starSystemInfo2;
						}
					}
					else
					{
						starSystemInfo3.BelowStar = starSystemInfo2;
					}
					break;
				case 3:
					starSystemInfo2.BelowStar = starSystemInfo3;
					if (starSystemInfo3.AboveStar != null)
					{
						float num17 = Vector3.Distance(starSystemInfo2.Coordinates, starSystemInfo3.Coordinates);
						float num18 = Vector3.Distance(starSystemInfo3.Coordinates, starSystemInfo3.AboveStar.Coordinates);
						if (num17 < num18)
						{
							starSystemInfo3.AboveStar = starSystemInfo2;
						}
					}
					else
					{
						starSystemInfo3.AboveStar = starSystemInfo2;
					}
					break;
				}
			}
		}
	}

	private void DestroyStarSystemNodes()
	{
		foreach (GalaxyNode starSystemNode in _starSystemNodes)
		{
			DestroyDungeonNodes(starSystemNode);
			UnityEngine.Object.Destroy(starSystemNode.gameObject);
		}
		if (systemLines == null || systemLines.Count <= 0)
		{
			return;
		}
		foreach (GameObject systemLine in systemLines)
		{
			UnityEngine.Object.Destroy(systemLine);
		}
	}

	private void CreateDungeonNodes(GalaxyNode starSystemNode)
	{
		string groupKey = starSystemNode.Info.GroupKey;
		string text = GalaxySaveFile.Get(groupKey, "LAST_SELECTED_ID", string.Empty);
		starSystemNode.DungeonNodes = new List<DungeonNode>();
		List<KeyCode> list = new List<KeyCode>(invalidDungeonKeys);
		int count = starSystemNode.Info.Dungeons.Count;
		for (int i = 0; i < count; i++)
		{
			DungeonInfo dungeonInfo = starSystemNode.Info.Dungeons[i];
			dungeonInfo.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Remove(dungeonInfo.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
			dungeonInfo.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Combine(dungeonInfo.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
			GameObject gameObject = null;
			if (dungeonInfo.DungeonType == DungeonTypeEnum.Derelict)
			{
				gameObject = UnityEngine.Object.Instantiate(DerelictPrefab);
			}
			else if (dungeonInfo.DungeonType == DungeonTypeEnum.Station)
			{
				gameObject = UnityEngine.Object.Instantiate(StationPrefab);
			}
			else if (dungeonInfo.DungeonType == DungeonTypeEnum.Outpost)
			{
				gameObject = UnityEngine.Object.Instantiate(OutpostPrefab);
			}
			else if (dungeonInfo.DungeonType == DungeonTypeEnum.AutoTrade)
			{
				gameObject = UnityEngine.Object.Instantiate(AutoTradePrefab);
			}
			else if (dungeonInfo.DungeonType == DungeonTypeEnum.Stargate)
			{
				gameObject = UnityEngine.Object.Instantiate(StargatePrefab);
			}
			else
			{
				Debug.LogError("Dungeon type not supported as a node: " + dungeonInfo.DungeonType);
			}
			if (gameObject != null)
			{
				DungeonNode component = gameObject.GetComponent<DungeonNode>();
				component.Info = dungeonInfo;
				gameObject.transform.position = dungeonInfo.Coordinates;
				starSystemNode.DungeonNodes.Add(component);
				bool flag = false;
				int num = 0;
				do
				{
					num = UnityEngine.Random.Range(97, 123);
					if (!FastKeysContains(list, (KeyCode)num))
					{
						list.Add((KeyCode)num);
						flag = true;
					}
				}
				while (!flag);
				component.SetShortcutKey((KeyCode)num);
			}
			if (dungeonInfo.GroupKey == text)
			{
				SetSelectedDungeon(dungeonInfo, true);
			}
		}
	}

	private bool FastKeysContains(List<KeyCode> usedKeys, KeyCode keyCode)
	{
		int count = usedKeys.Count;
		for (int i = 0; i < count; i++)
		{
			if (usedKeys[i] == keyCode)
			{
				return true;
			}
		}
		return false;
	}

	private void DungeonKeyPressed(DungeonInfo info)
	{
		SetSelectedDungeon(info, false);
	}

	private void SystemKeyPressed(StarSystemInfo info)
	{
		SetSelectedStarSystem(info, false);
		if (_selectedStarSystem.Id != GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id && !GameSaveFile.Get("HNT_VIEWS", false))
		{
			HintManager.PushHint(new SystemViewChangeHint(), true);
		}
	}

	private void DestroyDungeonNodes(GalaxyNode starSystemNode)
	{
		if (!(starSystemNode != null) || starSystemNode.DungeonNodes == null)
		{
			return;
		}
		foreach (DungeonNode dungeonNode in starSystemNode.DungeonNodes)
		{
			if (dungeonNode != null)
			{
				UnityEngine.Object.Destroy(dungeonNode.gameObject);
			}
		}
	}

	private void Update()
	{
		if (autoFullScreen)
		{
			timerTillFullScreen -= Time.deltaTime;
			if (timerTillFullScreen <= 0f)
			{
				autoFullScreen = false;
				Screen.fullScreen = true;
			}
		}
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
		{
			GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
		}
		if (IsSpaceDownAfterDungeon)
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				IsSpaceDownAfterDungeon = false;
			}
			else
			{
				SpaceDownTimer += Time.deltaTime;
				if (SpaceDownTimer > 0.5f && !Input.GetKey(KeyCode.Space))
				{
					IsSpaceDownAfterDungeon = false;
				}
			}
		}
		if (GlobalSettings.FirstTimeIn)
		{
			GlobalSettings.FirstTimeIn = false;
			bool flag = false;
			List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName("LOG_");
			foreach (string item in groupsByName)
			{
				if (LogManager.LogDataFile.GetSetting(item, "FILE", string.Empty) != string.Empty)
				{
					flag = true;
					break;
				}
			}
			if (GlobalSettings.gameMode == GameModeEnum.Normal)
			{
				if (!flag)
				{
					LogManager.GetLogFromResource("Data/ShipsLogs/intro_scientist_log", true);
					LogUI.Instance.ShowWindow(LogManager.GetLogFromResource("Data/ShipsLogs/intro_mothership_log", false), GlobalSettings.Constants.LOG_INTRO_DEFAULT_COLOR, 1);
				}
				else if (GlobalSettings.IsInResetState)
				{
					string empty = string.Empty;
					int num = -1;
					if (GameSaveFile.Get("RESETS", 0) == 1)
					{
						LogManager.GetLogFromResource("Data/ShipsLogs/intro_scientist_y_log_bake", true);
						empty = LogManager.GetLogFromResource("Data/ShipsLogs/intro_modified_log_2", false);
						num = 3;
					}
					else
					{
						empty = LogManager.GetLogFromResource("Data/ShipsLogs/intro_mothership_loop_log", false);
					}
					LogUI.Instance.ShowWindow(empty, GlobalSettings.Constants.LOG_INTRO_DEFAULT_COLOR, num);
					GlobalSettings.IsInResetState = false;
				}
			}
		}
		if (GlobalSettings.OwnsDronesBestFriend)
		{
			_ownedDbfNonBarkTimer -= Time.deltaTime;
			if (_ownedDbfNonBarkTimer <= 0f)
			{
				_ownedDbfNonBarkTimer = 20f;
				int num2 = UnityEngine.Random.Range(1, 101);
				if (num2 < 50)
				{
					PlayDbfNonBark();
				}
			}
		}
		if (isWaitingToUnloadUnusedAssets)
		{
			timerUntilUnloadUnusedAssets -= Time.deltaTime;
			if (timerUntilUnloadUnusedAssets <= 0f)
			{
				isWaitingToUnloadUnusedAssets = false;
				Resources.UnloadUnusedAssets();
			}
		}
		if (EventManager.Instance != null)
		{
			EventManager.Instance.Update();
		}
		if (Input.GetButtonDown("Screen Capture"))
		{
			string filename = GameFileHelper.GenerateUniqueScreenshotFilename();
			Application.CaptureScreenshot(filename);
		}
		if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.X) && ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
		{
			GlobalSettings.cheatMode = !GlobalSettings.cheatMode;
		}
		if ((_showBoardingConfigWindow || PreparingToBoard) && _boardingConfigUi != null && !_boardingConfigUi.IsVisible)
		{
			_showBoardingConfigWindow = false;
			ShowingUI = false;
			PreparingToBoard = false;
		}
		if (_showShipUpgradeWindow && _shipConfigUi != null && !_shipConfigUi.IsVisible)
		{
			ShowingUI = false;
			_showShipUpgradeWindow = false;
			UpdateAllDungeonVisualDistanceIndications();
		}
		if (_boardingConfigUi.ReadyToBoard)
		{
			ReadyButtonPressed();
			return;
		}
		showingFullScreenUi = true && (_showBoardingConfigWindow || _showShipUpgradeWindow);
		if (!DialogUI.Instance.IsShowing && !TradeUI.Instance.IsShowing && !GlobalSettings.IsGamePaused && !isHidingAll && !showingFullScreenUi && !Manual.IsVisible && !ModificationUI.Instance.IsShowing && (ObjectivesUI.Instance == null || !ObjectivesUI.Instance.IsShowing))
		{
			if (testHints)
			{
				if (_notifyPlayerAboutShipUpgrades)
				{
					_notifyPlayerAboutShipUpgrades = false;
					if (!GameSaveFile.Get("HNT_SU", false))
					{
						HintManager.PushHint(new SpacerHint(0.1f));
						HintManager.PushHint(new ShipUpgradeAcquiredHint());
					}
					SystemOverlayUI.Instance.BeginBlinkShipConfigButton();
				}
				else if (enableScrapHint)
				{
					HintManager.PushHint(new SpacerHint(0.1f));
					HintManager.PushHint(new ScrapAcquiredHint());
					SystemOverlayUI.Instance.BeginBlinkModificationButton();
					GameSaveFile.Save("HNT_SCRAP", true);
				}
				else if (ShipDeteriorating)
				{
					ShipDeteriorating = false;
					if (!GameSaveFile.Get("HNT_SHPWR", false))
					{
						HintManager.PushHint(new SpacerHint(0.1f));
						HintManager.PushHint(new ShipWearingDownHint());
						GameSaveFile.Save("HNT_SHPWR", true);
					}
				}
				testHints = false;
			}
			if (showTipsWindowAfterDelay)
			{
				timerShowTipWindow -= Time.deltaTime;
				if (timerShowTipWindow <= 0f)
				{
					timerShowTipWindow = 0f;
					showTipsWindowAfterDelay = false;
					_helpManualWindow.IsVisible = true;
					Manual.ExternalOpenSubmenu("Tips");
					DialogUI.Instance.ShowDialog("Advisory", "Many tips and commands are listed in the help menu.\n\nAccess this menu in the future from the pause menu, or directly from the console using 'help'.");
				}
			}
			else if (showStrategyWindowAfterDelay)
			{
				timerShowStrategyWindow -= Time.deltaTime;
				if (timerShowStrategyWindow <= 0f)
				{
					timerShowStrategyWindow = 0f;
					showStrategyWindowAfterDelay = false;
					_helpManualWindow.IsVisible = true;
					Manual.ExternalOpenSubmenu("Strategy");
					DialogUI.Instance.ShowDialog("Advisory", "Many helpful strategies are listed in the help menu.\n\nAccess this menu in the future from the pause menu, or directly from the console using 'help'.");
				}
			}
			if (showNurseryCompleteHint)
			{
				showNurseryCompleteHint = false;
				HintManager.PushHint(new SpacerHint(2f));
				HintManager.PushHint(new NurseryCompletedHint());
			}
			if (isPlayerShipOnDungeonTransitioning)
			{
				timerPlayerTransition -= Time.deltaTime;
				if (timerPlayerTransition <= 0f)
				{
					PlayerShipInstance.transform.position = playerShipDestination;
					playerShipCurrent = PlayerShipInstance.transform.position;
					isPlayerShipOnDungeonTransitioning = false;
					PlayerShipPlaneInstance.SetActive(true);
				}
				else
				{
					float time = curretMaxTimer - timerPlayerTransition;
					float t = transitionCurve.Evaluate(time);
					playerShipCurrent = Vector3.Lerp(playerShipStart, playerShipDestination, t);
				}
			}
			else if (isPlayerShipOnSystemTransitioning)
			{
				timerPlayerTransition -= Time.deltaTime;
				if (timerPlayerTransition <= 0f)
				{
					PlayerShipInstance.transform.position = playerShipDestination;
					isPlayerShipOnSystemTransitioning = false;
					PlayerShipPlaneInstance.SetActive(true);
					timerPlayerTransition = 0f;
					GlobalSettings.GameState.ThePlayer.CurrentStarSystem = starSystemTransitioning;
					Mothership.Instance.TravelToStarSystem(starSystemTransitioning);
					UpdateAllStarSystemVisualDistanceIndications();
					if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
					{
						TestEndOfGameState();
					}
				}
				else
				{
					float time2 = curretMaxTimer - timerPlayerTransition;
					float t2 = transitionCurve.Evaluate(time2);
					playerShipCurrent = Vector3.Lerp(playerShipStart, playerShipDestination, t2);
				}
			}
			if (isPlayerShipOnDungeonTransitioning || isPlayerShipOnSystemTransitioning)
			{
				timerUntilTogglePlayerShipVisibility -= Time.deltaTime;
				if (timerUntilTogglePlayerShipVisibility <= 0f)
				{
					PlayerShipInstance.transform.position = playerShipCurrent;
					timerUntilTogglePlayerShipVisibility = toggleFactor;
				}
			}
			if (!PreparingToBoard && !TradeUI.Instance.IsShowing && !_showBoardingConfigWindow && !_showModsWindow && !_showShipUpgradeWindow && Input.GetButtonDown("Quote"))
			{
				HideOverlays = !HideOverlays;
			}
			if (GalaxyProcessor.universeMapManager == null || !GalaxyProcessor.universeMapManager.IsInTravelMode)
			{
				if (GlobalSettings.cheatMode)
				{
					if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
					{
						if (Input.GetButtonDown("Right"))
						{
							ChooseNextPreset();
							PresetManager.TakeSnapshot(GlobalSettings.GameState.ThePlayer.Drones);
						}
						else if (Input.GetButtonDown("Left"))
						{
							ChoosePrevPreset();
							PresetManager.TakeSnapshot(GlobalSettings.GameState.ThePlayer.Drones);
						}
						if (Input.GetKeyDown(KeyCode.U))
						{
							RandomlyChoosePlayerUpgrades();
							PresetManager.TakeSnapshot(GlobalSettings.GameState.ThePlayer.Drones);
						}
						if (CurrentMapState == GalaxyMapState.Dungeons && Input.GetKeyDown(KeyCode.V))
						{
							GalaxySaveFile.Save(SelectedDungeon.GroupKey, "VISITED", true);
							SelectedDungeon.HaveVisited = true;
							UpdateAllDungeonVisualDistanceIndications();
						}
					}
					else if (CurrentMapState == GalaxyMapState.StarSystems && Input.GetKey(KeyCode.Q))
					{
						if (Input.GetKeyDown(KeyCode.G))
						{
							_starSystemNodes.ForEach(delegate(GalaxyNode x)
							{
								x.Scan();
							});
						}
						else if (Input.GetKeyDown(KeyCode.R))
						{
							_starSystemNodes.ForEach(delegate(GalaxyNode x)
							{
								x.Scan();
							});
							StarField.Instance.RevealBackground();
						}
						else if (Input.GetKeyDown(KeyCode.H))
						{
							_starSystemNodes.ForEach(delegate(GalaxyNode x)
							{
								x.Hide();
							});
						}
						else if (Input.GetKeyDown(KeyCode.Alpha1))
						{
							_starSystemNodes.ForEach(delegate(GalaxyNode x)
							{
								x.Hide();
							});
							Mothership.Instance.RemoveLongRangeScanner();
						}
						else if (Input.GetKeyDown(KeyCode.Alpha2))
						{
							_starSystemNodes.ForEach(delegate(GalaxyNode x)
							{
								x.Hide();
							});
							Mothership.Instance.InstallLongRangeScannerForced();
						}
						else if (Input.GetKeyDown(KeyCode.C))
						{
							backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = false;
							if (GlobalSettings.GenerateGalaxyMapFromImage)
							{
								CameraStarSystemOverlay[] components = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
								foreach (CameraStarSystemOverlay cameraStarSystemOverlay in components)
								{
									cameraStarSystemOverlay.enabled = false;
								}
							}
							StarField.Instance.GalaxyViewTexture = depthMapSourceTexture;
							StarField.Instance.GalaxyViewColor = Color.gray;
							StarField.Instance.GalaxyView();
						}
						else if (Input.GetKeyDown(KeyCode.V))
						{
							backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = false;
							if (GlobalSettings.GenerateGalaxyMapFromImage)
							{
								CameraStarSystemOverlay[] components2 = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
								foreach (CameraStarSystemOverlay cameraStarSystemOverlay2 in components2)
								{
									cameraStarSystemOverlay2.enabled = false;
								}
							}
							StarField.Instance.GalaxyViewTexture = typeMapSourceTexture;
							StarField.Instance.GalaxyViewColor = Color.gray;
							StarField.Instance.GalaxyView();
						}
						else if (Input.GetKeyDown(KeyCode.B))
						{
							backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = false;
							if (GlobalSettings.GenerateGalaxyMapFromImage)
							{
								CameraStarSystemOverlay[] components3 = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
								foreach (CameraStarSystemOverlay cameraStarSystemOverlay3 in components3)
								{
									cameraStarSystemOverlay3.enabled = false;
								}
							}
							StarField.Instance.GalaxyViewTexture = typeDensityMapSourceTexture;
							StarField.Instance.GalaxyViewColor = Color.gray;
							StarField.Instance.GalaxyView();
						}
						else if (Input.GetKeyDown(KeyCode.X))
						{
							backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = false;
							if (GlobalSettings.GenerateGalaxyMapFromImage)
							{
								CameraStarSystemOverlay[] components4 = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
								foreach (CameraStarSystemOverlay cameraStarSystemOverlay4 in components4)
								{
									cameraStarSystemOverlay4.enabled = false;
								}
							}
							StarField.Instance.GalaxyViewTexture = difficultyMapSourceTexture;
							StarField.Instance.GalaxyViewColor = Color.gray;
							StarField.Instance.GalaxyView();
						}
						else if (Input.GetKeyDown(KeyCode.N))
						{
							backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = true;
							if (GlobalSettings.GenerateGalaxyMapFromImage)
							{
								CameraStarSystemOverlay[] components5 = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
								foreach (CameraStarSystemOverlay cameraStarSystemOverlay5 in components5)
								{
									cameraStarSystemOverlay5.enabled = true;
								}
							}
							StarField.Instance.GalaxyViewTexture = null;
						}
						else if (Input.GetKeyDown(KeyCode.W))
						{
							GalaxySaveFile.SaveGalaxySeed(galaxyMapGenerationSeed);
							Debug.Log(string.Format("Saved Galaxy Seed: {0}", galaxyMapGenerationSeed));
						}
						else if (Input.GetKeyDown(KeyCode.E))
						{
							GalaxySaveFile.ClearGalaxySeed();
							Debug.Log("Cleared Galaxy Seed");
						}
						else if (Input.GetKeyDown(KeyCode.L))
						{
							if (debugLogViewer == null)
							{
								debugLogViewer = new DebugLogViewer();
							}
							if (!debugLogViewer.IsShowing)
							{
								debugLogViewer.Show();
							}
							else
							{
								debugLogViewer.Hide();
							}
						}
					}
					else if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.Plus))
					{
						if (Input.GetKey(KeyCode.LeftShift))
						{
							GlobalSettings.GameState.ThePlayer.Inventory.Scrap += 100;
							GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel += 15;
							GlobalSettings.GameState.ThePlayer.Inventory.RechargePropulsionFuel();
							GlobalSettings.GameState.ThePlayer.Inventory.AddReservePropulsionFuel(100);
						}
						else
						{
							GlobalSettings.GameState.ThePlayer.Inventory.Scrap += 10;
							GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel++;
							GlobalSettings.GameState.ThePlayer.Inventory.RechargePropulsionFuel();
							GlobalSettings.GameState.ThePlayer.Inventory.AddReservePropulsionFuel(10);
						}
						UpdateAllStarSystemVisualDistanceIndications();
						UpdateAllDungeonVisualDistanceIndications();
					}
					else if (Input.GetKeyDown(KeyCode.Minus))
					{
						GlobalSettings.GameState.ThePlayer.Inventory.Scrap -= 100;
						GlobalSettings.GameState.ThePlayer.Inventory.DrainPropulsionFuel(2);
						GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel -= 100;
						if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap < 2)
						{
							GlobalSettings.GameState.ThePlayer.Inventory.Scrap = 2;
						}
						if (GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel < 2)
						{
							GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel = 2;
						}
						UpdateAllStarSystemVisualDistanceIndications();
						UpdateAllDungeonVisualDistanceIndications();
					}
					if (debugLogViewer != null && debugLogViewer.IsShowing)
					{
						debugLogViewer.Update();
					}
				}
				if (!isTakingANote && !isLogShowing() && !ObjectivesUI.Instance.IsShowing && Input.GetKeyDown(KeyCode.Escape))
				{
					bool flag2 = false;
					if (CurrentMapState == GalaxyMapState.Dungeons)
					{
						if (PreparingToBoard)
						{
							PreparingToBoard = false;
						}
						else if (_showBoardingConfigWindow)
						{
							ShowDroneBoardingConfigWindow(false);
						}
						else if (_showShipUpgradeWindow)
						{
							ShowShipUpgradeBoardingConfigWindow(false);
						}
						else if (_showModsWindow)
						{
							_showModsWindow = false;
							SystemOverlayUI.Instance.IsVisible = !_showModsWindow;
							SystemOverlayUI.Instance.RefreshDroneInfo();
						}
						else
						{
							flag2 = true;
						}
						if (ShowingUI)
						{
							ShowingUI = false;
						}
					}
					else
					{
						flag2 = true;
					}
					if (isShowingLogSelectionPanel)
					{
						LogButtonPressed();
						flag2 = false;
					}
					if (flag2)
					{
						Input.ResetInputAxes();
						if (!GlobalSettings.IsGamePaused)
						{
							if (PreparingToBoard)
							{
								PreparingToBoard = false;
							}
							else if (_showBoardingConfigWindow)
							{
								ShowDroneBoardingConfigWindow(false);
							}
							else if (_showShipUpgradeWindow)
							{
								ShowShipUpgradeBoardingConfigWindow(false);
							}
							else if (_showModsWindow)
							{
								_showModsWindow = false;
								SystemOverlayUI.Instance.IsVisible = !_showModsWindow;
								SystemOverlayUI.Instance.RefreshDroneInfo();
							}
							else
							{
								GlobalSettings.IsGamePaused = true;
								ShowPauseMenu();
							}
							if (ShowingUI)
							{
								ShowingUI = false;
							}
						}
						else
						{
							PauseMessageCancelPressed();
						}
					}
				}
				if (_rationsChangedTimer > 0f)
				{
					_rationsChangedTimer -= Time.deltaTime;
				}
				if (!isLogShowing())
				{
					if (CurrentMapState == GalaxyMapState.Universe)
					{
						if (GalaxyProcessor.universeMapManager != null)
						{
							GalaxyProcessor.universeMapManager.Update();
						}
					}
					else if (CurrentMapState == GalaxyMapState.StarSystems && !_showModsWindow && !_showBoardingConfigWindow && !isShowingLogSelectionPanel && !_showShipUpgradeWindow)
					{
						if (isTakingANote || Input.GetKeyUp(KeyCode.N))
						{
						}
						if (isTakingANote && galaxyNoteWindow.Update())
						{
							return;
						}
					}
					if (!isShowingLogSelectionPanel)
					{
						if ((CurrentMapState != GalaxyMapState.Universe && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) || ((isPlayerShipOnSystemTransitioning || isPlayerShipOnDungeonTransitioning) && Input.GetKeyDown(KeyCode.Space)))
						{
							if (!PreparingToBoard)
							{
								if (CurrentMapState == GalaxyMapState.Dungeons && !isViewOnlyStarSystemView)
								{
									if (!isPlayerShipOnDungeonTransitioning)
									{
										if (!SelectedDungeonIsTooFar())
										{
											ExecuteBoardOrTravel();
										}
									}
									else
									{
										PlayerShipInstance.transform.position = playerShipDestination;
										playerShipCurrent = PlayerShipInstance.transform.position;
										isPlayerShipOnDungeonTransitioning = false;
										PlayerShipPlaneInstance.SetActive(true);
									}
								}
								else if (CurrentMapState == GalaxyMapState.StarSystems)
								{
									if (_selectedStarSystem.Id == GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
									{
										SetMapState(GalaxyMapState.Dungeons, true);
									}
									else if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
									{
										if (!isPlayerShipOnSystemTransitioning)
										{
											if (CanTravelToStarSystem(true))
											{
												TravelToStarSystem();
											}
										}
										else
										{
											PlayerShipInstance.transform.position = playerShipDestination;
											isPlayerShipOnSystemTransitioning = false;
											PlayerShipPlaneInstance.SetActive(true);
											timerPlayerTransition = 0f;
											GlobalSettings.GameState.ThePlayer.CurrentStarSystem = starSystemTransitioning;
											Mothership.Instance.TravelToStarSystem(starSystemTransitioning);
											UpdateAllStarSystemVisualDistanceIndications();
										}
									}
									else
									{
										ShowStarSystemView(_selectedStarSystem, true, false);
									}
								}
							}
							else
							{
								ReadyButtonPressed();
							}
						}
						else if (CurrentMapState != GalaxyMapState.Universe)
						{
							if (!TradeUI.Instance.IsShowing)
							{
								if (UniverseMapManager.Instance.IsReadOnlyGalaxy)
								{
									if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Home))
									{
										UniverseMapManager.Instance.ReturnToPreViewGalaxy();
									}
								}
								else if (Input.GetKeyDown(KeyCode.J))
								{
									if (CanJumpToSelectedStarSystem())
									{
										JumpButtonPressed();
									}
									else
									{
										CommonAudioHelper.Instance.PlayErrorSound();
									}
								}
								if (Input.GetKeyDown(KeyCode.D))
								{
									UpgradesButtonPressed();
								}
								else if (GlobalSettings.gameMode == GameModeEnum.Normal && Input.GetKeyDown(KeyCode.O))
								{
									ObjectivesButtonPressed();
								}
								else if (Input.GetKeyDown(KeyCode.S))
								{
									ShipUpgradesButtonPressed();
								}
								else if (Input.GetKeyDown(KeyCode.M))
								{
									ModificationsButtonPressed();
								}
								else if ((_showBoardingConfigWindow || _showModsWindow || _showShipUpgradeWindow) && Input.GetKeyDown(KeyCode.C))
								{
									CloseShipUpgradeButtonPressed();
									CloseModificationsButtonPressed();
								}
								else if (PreparingToBoard)
								{
									if (!isLoadingScene && Input.GetKeyDown(KeyCode.R))
									{
										ReadyButtonPressed();
									}
									else if (!isLoadingScene && Input.GetKeyDown(KeyCode.C))
									{
										CancelButtonPressed();
									}
								}
								else if (CurrentMapState == GalaxyMapState.Dungeons)
								{
									if (SelectedDungeon.DungeonType != DungeonTypeEnum.Stargate && Input.GetKeyDown(KeyCode.B))
									{
										if (_distanceInDaysToTarget == 0 && !SelectedDungeonIsTooFar())
										{
											BoardOrTravelButtonPressed();
										}
										else
										{
											CommonAudioHelper.Instance.PlayErrorSound();
										}
									}
									else if (SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate && Input.GetKeyDown(KeyCode.J))
									{
										if (_distanceInDaysToTarget == 0 && !SelectedDungeonIsTooFar())
										{
											BoardOrTravelButtonPressed();
										}
										else
										{
											CommonAudioHelper.Instance.PlayErrorSound();
										}
									}
									else if (Input.GetKeyDown(KeyCode.T))
									{
										if (!UniverseMapManager.Instance.IsReadOnlyGalaxy && !isViewOnlyStarSystemView && _distanceInDaysToTarget > 0 && !SelectedDungeonIsTooFar())
										{
											BoardOrTravelButtonPressed();
										}
										else
										{
											CommonAudioHelper.Instance.PlayErrorSound();
										}
									}
								}
							}
							else if (TradeUI.Instance.IsShowing && Input.GetKeyDown(KeyCode.C))
							{
								CloseTradingPostButtonPressed();
							}
							if (!PreparingToBoard && !TradeUI.Instance.IsShowing && !_showBoardingConfigWindow && !_showModsWindow && !isShowingLogSelectionPanel && !_showShipUpgradeWindow && (ObjectivesUI.Instance == null || !ObjectivesUI.Instance.IsShowing) && (Input.GetButtonDown("Up") || Input.GetButtonDown("Down") || Input.GetButtonDown("Left") || Input.GetButtonDown("Right")))
							{
								Vector2 zero = Vector2.zero;
								if (Input.GetButton("Up"))
								{
									zero.y += 1f;
								}
								if (Input.GetButton("Down"))
								{
									zero.y -= 1f;
								}
								if (Input.GetButton("Left"))
								{
									zero.x -= 1f;
								}
								if (Input.GetButton("Right"))
								{
									zero.x += 1f;
								}
								if (zero != Vector2.zero)
								{
									if (CurrentMapState == GalaxyMapState.Dungeons)
									{
										MoveSelectedDungeon(zero);
									}
									else if (CurrentMapState == GalaxyMapState.StarSystems)
									{
										MoveSelectedStarSystem(zero);
									}
								}
							}
						}
						else if (CurrentMapState == GalaxyMapState.Universe && !UniverseMapManager.Instance.IsInTravelMode)
						{
							if (Input.GetKeyDown(KeyCode.V))
							{
								if (UniverseMapManager.HasData)
								{
									UniverseMapManager.Instance.AttemptViewGalaxy();
								}
								else
								{
									CommonAudioHelper.Instance.PlayErrorSound();
								}
							}
							else if (Input.GetKeyDown(KeyCode.D))
							{
								UpgradesButtonPressed();
							}
							else if (GlobalSettings.gameMode == GameModeEnum.Normal && Input.GetKeyDown(KeyCode.O))
							{
								ObjectivesButtonPressed();
							}
							else if (Input.GetKeyDown(KeyCode.S))
							{
								ShipUpgradesButtonPressed();
							}
							else if (Input.GetKeyDown(KeyCode.M))
							{
								ModificationsButtonPressed();
							}
						}
						if (!isTakingANote && (GalaxyProcessor.universeMapManager == null || !GalaxyProcessor.universeMapManager.isEditingConstellationProperties))
						{
							if (!IsSpaceDownAfterDungeon && !isPlayerShipOnDungeonTransitioning && !isPlayerShipOnSystemTransitioning && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Tab)))
							{
								if (!PreparingToBoard && !TradeUI.Instance.IsShowing && !_showBoardingConfigWindow && !_showModsWindow && !_showShipUpgradeWindow)
								{
									GalaxyMapState galaxyMapState = GalaxyMapState.None;
									bool flag3 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
									if (CurrentMapState == GalaxyMapState.StarSystems)
									{
										galaxyMapState = GalaxyMapState.Dungeons;
									}
									else if (CurrentMapState == GalaxyMapState.Dungeons)
									{
										galaxyMapState = GalaxyMapState.StarSystems;
									}
									else if (CurrentMapState == GalaxyMapState.Universe)
									{
										galaxyMapState = PreviousMapState;
									}
									switch (galaxyMapState)
									{
									case GalaxyMapState.StarSystems:
										SetMapState(GalaxyMapState.StarSystems, false);
										HintManager.HintCompleted(typeof(NurseryCompletedHint));
										break;
									case GalaxyMapState.Dungeons:
										if (_selectedStarSystem.Id != GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
										{
											ShowStarSystemView(_selectedStarSystem, true, false);
											HintManager.HintCompleted(typeof(SystemViewChangeHint));
										}
										else
										{
											SetMapState(GalaxyMapState.Dungeons, false);
										}
										break;
									case GalaxyMapState.Universe:
										SetMapState(GalaxyMapState.Universe, false);
										break;
									}
								}
							}
							else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
							{
								if (!isPlayerShipOnDungeonTransitioning && !isPlayerShipOnSystemTransitioning)
								{
									SetMapState(GalaxyMapState.Universe, false);
								}
								else
								{
									CommonAudioHelper.Instance.PlayErrorSound();
								}
							}
							else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
							{
								if (!isPlayerShipOnDungeonTransitioning && !isPlayerShipOnSystemTransitioning)
								{
									SetMapState(GalaxyMapState.StarSystems, false);
									HintManager.HintCompleted(typeof(NurseryCompletedHint));
								}
								else
								{
									CommonAudioHelper.Instance.PlayErrorSound();
								}
							}
							else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
							{
								if (!isPlayerShipOnDungeonTransitioning && !isPlayerShipOnSystemTransitioning)
								{
									if (_selectedStarSystem.Id != GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
									{
										if (CurrentMapState == GalaxyMapState.Universe)
										{
											GalaxyProcessor.universeMapManager.Hide();
										}
										guiCamera.transform.position = guiCameraHomePos;
										ShowStarSystemView(_selectedStarSystem, true, false);
										HintManager.HintCompleted(typeof(SystemViewChangeHint));
									}
									else
									{
										SetMapState(GalaxyMapState.Dungeons, false);
									}
								}
								else
								{
									CommonAudioHelper.Instance.PlayErrorSound();
								}
							}
							else if (Input.GetKeyDown(KeyCode.Home) && (CurrentMapState != GalaxyMapState.Dungeons || isViewOnlyStarSystemView))
							{
								if (!isViewOnlyStarSystemView)
								{
									_selectedStarSystem = GlobalSettings.GameState.ThePlayer.CurrentStarSystem;
									SetMapState(GalaxyMapState.Dungeons, false);
								}
								else
								{
									SetMapState(GalaxyMapState.StarSystems, true);
									_selectedStarSystem = GlobalSettings.GameState.ThePlayer.CurrentStarSystem;
									SetMapState(GalaxyMapState.Dungeons, true);
								}
							}
						}
					}
					else if (Input.GetButtonDown("Up"))
					{
						logSelectedIndex--;
						if (logSelectedIndex < 0)
						{
							logSelectedIndex = 0;
						}
					}
					else if (Input.GetButtonDown("Down"))
					{
						logSelectedIndex++;
						if (logSelectedIndex >= logList.Count)
						{
							logSelectedIndex = logList.Count - 1;
						}
					}
				}
				else
				{
					UpdateLog();
				}
			}
			else
			{
				GalaxyProcessor.universeMapManager.Update();
				if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.C))
				{
					GalaxyProcessor.universeMapManager.EndTravelMode(true);
					SetMapState(PreviousMapState, false);
				}
			}
			if (!DisableAmbientSound)
			{
				if (!asMotherShipAmbience.isPlaying)
				{
					asMotherShipAmbience.Play();
				}
				asMotherShipAmbience.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.A_MotherShip, GameAudio.AmbienceVolume);
			}
			else if (asMotherShipAmbience.isPlaying)
			{
				asMotherShipAmbience.Stop();
			}
		}
		else
		{
			if ((pauseMenu == null || !pauseMenu.IsLoaded) && DialogUI.Instance.IsShowing)
			{
				DialogUI.Instance.TestKeyInput();
			}
			if (ModificationUI.Instance.IsShowing)
			{
				ModificationUI.Instance.Update();
			}
		}
	}

	private bool isLogShowing()
	{
		if (!LogUI.Instance.IsShowing)
		{
			return false;
		}
		return true;
	}

	private void UpdateLog()
	{
		if (!LogUI.Instance.IsShowing || !LogUI.Instance.IsShowing || !LogUI.Instance.PumpUpdate())
		{
			return;
		}
		switch (LogUI.Instance.Tag)
		{
		case 1:
			LogUI.Instance.ShowWindow(LogManager.GetLogFromResource("Data/ShipsLogs/intro_modified_log", false), GlobalSettings.Constants.LOG_INTRO_DEFAULT_COLOR);
			return;
		case 2:
			ShowTradingPost();
			return;
		case 3:
			showTipsWindowAfterDelay = true;
			timerShowTipWindow = 0.5f;
			return;
		}
		if (GameSaveFile.Get("RESETS", 0) == 2)
		{
			showStrategyWindowAfterDelay = true;
			timerShowStrategyWindow = 0.5f;
		}
	}

	private void MoveSelectedDungeon(Vector2 moveVector)
	{
		IEnumerable<DungeonInfo> enumerable = lastViewedStarSystem.Dungeons.Where((DungeonInfo x) => true);
		if (moveVector.x < 0f)
		{
			enumerable = enumerable.Where((DungeonInfo i) => i.Coordinates.x < SelectedDungeon.Coordinates.x);
		}
		else if (moveVector.x > 0f)
		{
			enumerable = enumerable.Where((DungeonInfo i) => i.Coordinates.x > SelectedDungeon.Coordinates.x);
		}
		if (moveVector.y < 0f)
		{
			enumerable = enumerable.Where((DungeonInfo i) => i.Coordinates.y < SelectedDungeon.Coordinates.y);
		}
		else if (moveVector.y > 0f)
		{
			enumerable = enumerable.Where((DungeonInfo i) => i.Coordinates.y > SelectedDungeon.Coordinates.y);
		}
		DungeonInfo dungeonInfo = null;
		float num = float.MaxValue;
		foreach (DungeonInfo item in enumerable)
		{
			float num2 = Vector3.Distance(item.Coordinates, SelectedDungeon.Coordinates);
			if (dungeonInfo == null || num2 < num)
			{
				dungeonInfo = item;
				num = num2;
			}
		}
		if (dungeonInfo != null)
		{
			SetSelectedDungeon(dungeonInfo, false);
		}
	}

	private void MoveSelectedStarSystem(Vector2 moveVector)
	{
		StarSystemInfo starSystemInfo = null;
		if (lastMoveDirection == -moveVector && lastStarSystem != null)
		{
			starSystemInfo = lastStarSystem;
		}
		else
		{
			if (moveVector.x < 0f && _selectedStarSystem.LeftStar != null && _selectedStarSystem.LeftStar.galaxyNode.IsVisible)
			{
				starSystemInfo = _selectedStarSystem.LeftStar;
			}
			else if (moveVector.x > 0f && _selectedStarSystem.RightStar != null && _selectedStarSystem.RightStar.galaxyNode.IsVisible)
			{
				starSystemInfo = _selectedStarSystem.RightStar;
			}
			if (moveVector.y > 0f && _selectedStarSystem.AboveStar != null && _selectedStarSystem.AboveStar.galaxyNode.IsVisible)
			{
				starSystemInfo = _selectedStarSystem.AboveStar;
			}
			else if (moveVector.y < 0f && _selectedStarSystem.BelowStar != null && _selectedStarSystem.BelowStar.galaxyNode.IsVisible)
			{
				starSystemInfo = _selectedStarSystem.BelowStar;
			}
		}
		if (starSystemInfo != null)
		{
			StarSystemInfo selectedStarSystem = _selectedStarSystem;
			SetSelectedStarSystem(starSystemInfo, false);
			lastMoveDirection = moveVector;
			lastStarSystem = selectedStarSystem;
			if (!GameSaveFile.Get("HNT_VIEWS", false))
			{
				HintManager.PushHint(new SystemViewChangeHint(), true);
			}
		}
	}

	private void ConfirmResetResult(ModalWindowResult result, string input)
	{
		if (result == ModalWindowResult.Yes)
		{
			GlobalSettings.IsGamePaused = false;
			pauseMenu.PerformFullReset();
		}
		else
		{
			Input.ResetInputAxes();
		}
	}

	private bool PauseMenuResetVerify()
	{
		DialogUI.Instance.ShowDialog("Are you sure?", "Initiate reset?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
		{
			if (result == ModalWindowResult.Yes)
			{
				ConfirmResetResult(result, string.Empty);
			}
		}, 1);
		return false;
	}

	private void PauseMenuReset()
	{
		if (!GlobalSettings.IsTutorial)
		{
			GameSaveFile.Save("PLAYS", GameSaveFile.Get("PLAYS", 0) + 1);
			UniverseSaveFile.Save("UNIVERSE_PLAYS", UniverseSaveFile.Get("UNIVERSE_PLAYS", 0) + 1);
			if (GameSaveFile.Get("VIEWED_TUT", false))
			{
				GameSaveFile.Save("PLAYS_SINCE_TUT", GameSaveFile.Get("PLAYS_SINCE_TUT", 0) + 1);
			}
		}
		PlayerReset();
		PauseMessageResetPressed(false);
	}

	private void PauseMenuFullReset()
	{
		FullReset();
		PauseMessageResetPressed(false);
	}

	private void FullReset()
	{
		PlayerReset();
		GalaxyReset();
		GalaxyProcessor.universeMapManager.UniverseReset();
	}

	private void PlayerReset()
	{
		UniverseSaveFile.BeginBatch();
		PreserveData = false;
		List<string> allGroups = UniverseSaveFile.GetAllGroups("INVITMS", "P", "SHIP");
		foreach (string item in allGroups)
		{
			UniverseSaveFile.ClearGroup(item);
		}
		UniverseSaveFile.ClearGroupAndChildren("PLAYER");
		UniverseSaveFile.ClearGroupAndChildren("DRONE_");
		UniverseSaveFile.EndBatch();
		StarField.ClearOnMapChange();
		GameSaveFile.Save("ST_CUR_DAYS", 1);
		GameSaveFile.Save("ST_TTL_DAYS", GameSaveFile.Get("ST_TTL_DAYS", 0) + 1);
		if (GameSaveFile.Get("ST_BST_DAYS", 0) < 1)
		{
			GameSaveFile.Save("ST_BST_DAYS", 1);
		}
		for (int i = 1; i < 5; i++)
		{
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_ENKILL", (ShipInfestationType)i), 0);
		}
		for (int j = 0; j < 6; j++)
		{
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", (DungeonTypeEnum)j), 0);
		}
		for (int k = 0; k < 22; k++)
		{
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_DUPG_USED", (DroneUpgradeType)k), 0);
		}
		for (int l = 1; l < 12; l++)
		{
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_SUPG_USED", (ShipUpgradeType)l), 0);
		}
		GameSaveFile.Save("ST_CUR_SYS_VISITED", 1);
		GameSaveFile.Save("ST_TTL_SYS_VISITED", GameSaveFile.Get("ST_TTL_SYS_VISITED", 0) + 1);
		if (GameSaveFile.Get("ST_BST_SYS_VISITED", 0) < 1)
		{
			GameSaveFile.Save("ST_BST_SYS_VISITED", 1);
		}
		GameSaveFile.Save("ST_CUR_GAL_VISITED", 1);
		GameSaveFile.Save("ST_TTL_GAL_VISITED", GameSaveFile.Get("ST_TTL_GAL_VISITED", 0) + 1);
		if (GameSaveFile.Get("ST_BST_GAL_VISITED", 0) < 1)
		{
			GameSaveFile.Save("ST_BST_GAL_VISITED", 1);
		}
		GameSaveFile.Save("ST_CUR_SCRAP_COL", 0);
		GameSaveFile.Save("ST_CUR_JFUEL_COL", 0);
		GameSaveFile.Save("ST_CUR_PFUEL_COL", 0);
		GameSaveFile.Save("ST_CUR_DRN_DEAD", 0);
	}

	private void GalaxyReset()
	{
		StarField.ClearOnReset();
		int value = GalaxySaveFile.Get<int>("GALAXY_SEED");
		GalaxySaveFile.EraseFile();
		GalaxySaveFile.Save("GALAXY_SEED", value);
		GalaxyProcessor.LoadUnlockedInfestationTypeList();
	}

	private void PauseMessageResetPressed(bool sameInitialState)
	{
		int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
		GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		GlobalSettings.RetrySameInitialState = sameInitialState;
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
		GameplayManager.ResetGameState();
		Application.LoadLevel(Application.loadedLevel);
	}

	private bool PauseMessageMainMenuVerify()
	{
		return true;
	}

	private void PauseMessageMainMenuPressed()
	{
		if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge && SteamLeaderboard.WeeklyScoreStatus != SteamLeaderboard.ScoreStatusEnum.Final)
		{
			UpdateWeeklyChallengeScore(false, 0);
		}
		try
		{
			SteamCore instance = SteamCore.Instance;
			instance.overlayToggled = (SteamCore.ScreenShownToggle)Delegate.Remove(instance.overlayToggled, new SteamCore.ScreenShownToggle(SteamOverlayToggle));
		}
		catch (Exception)
		{
		}
		int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
		GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		DialogUI.Instance.CloseDialog();
		GameplayManager.ResetGameState();
		if (GalaxyProcessor.universeMapManager != null)
		{
			GalaxyProcessor.universeMapManager.Clear();
			GalaxyProcessor.universeMapManager = null;
		}
		Application.LoadLevel("MenuScene");
		GlobalSettings.IsGamePaused = false;
	}

	private void PauseMessageCancelPressed()
	{
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
	}

	private void OnGUI()
	{
		if (_showBoardingConfigWindow || _showShipUpgradeWindow || GlobalSettings.IsGamePaused || isLoadingScene || !RenderGUI || !GlobalSettings.GameStateIsLoaded)
		{
			return;
		}
		if (blackoutScreenOnNewGalaxy && CurrentMapState == GalaxyMapState.StarSystems)
		{
			if (blackoutFrameCount < 2)
			{
				fullScreenRect.width = Screen.width;
				fullScreenRect.height = Screen.height;
				blackoutFrameCount++;
			}
			else
			{
				blackoutScreenOnNewGalaxy = false;
				blackoutFrameCount = 0;
			}
		}
		else if (isHidingAll)
		{
			fullScreenRect.width = Screen.width;
			fullScreenRect.height = Screen.height;
			return;
		}
		if (GalaxyProcessor.universeMapManager != null && !GalaxyProcessor.universeMapManager.IsInTravelMode)
		{
			if (Event.current.type == EventType.MouseUp)
			{
				GlobalSettings.InventoryDragInfo.IsDragging = false;
				GlobalSettings.InventoryDragInfo.SourceWindow = null;
				GlobalSettings.InventoryDragInfo.ItemBeingDragged = null;
			}
			if (GlobalSettings.InventoryDragInfo.IsDragging && GlobalSettings.InventoryDragInfo.ItemBeingDragged != null)
			{
				dragWindowRect.x = Event.current.mousePosition.x + 5f;
				dragWindowRect.y = Event.current.mousePosition.y + 5f;
				GUI.Window(31, dragWindowRect, DrawDragWindow, string.Empty);
			}
			if (GlobalSettings.cheatMode)
			{
				GUIStyle gUIStyle = new GUIStyle();
				gUIStyle.normal.textColor = Color.red;
				GUI.Label(cheatMsgRect, "Cheat Mode!!!", gUIStyle);
			}
			if (PreparingToBoard || _showBoardingConfigWindow || _showShipUpgradeWindow)
			{
				if (PreparingToBoard)
				{
					boardingTextureRect.width = Screen.width;
					boardingTextureRect.height = Screen.height;
					boardingConfigRect.x = Screen.width / 2 - 100;
				}
				_playerShipWindowCompactRect = GUI.Window(18, _playerShipWindowCompactRect, DrawPlayerShipWindowCompact, "Your Ship");
				if (SelectedDungeon != null)
				{
					_selectedDungeonWindowCompactRect = GUI.Window(19, _selectedDungeonWindowCompactRect, DrawSelectedDungeonWindowCompact, SelectedDungeon.Name);
				}
			}
			else if (CurrentMapState != GalaxyMapState.Universe)
			{
				logToggleButtonRect.x = (float)(-(Screen.height / 2)) - logToggleButtonRect.width / 2f;
				logToggleButtonRect.y = 0f;
				GUI.color = Color.white;
			}
			universeMapButtonHeight = 40f;
			dungeonsMapButtonHeight = 40f;
			galaxyMapButtonHeight = 40f;
			if (CurrentMapState == GalaxyMapState.Dungeons)
			{
				dungeonsMapButtonHeight = 55f;
			}
			else if (CurrentMapState == GalaxyMapState.StarSystems)
			{
				galaxyMapButtonHeight = 55f;
			}
			else
			{
				universeMapButtonHeight = 55f;
			}
			if (!PreparingToBoard)
			{
				if (!HideOverlays && !isShowingLogSelectionPanel)
				{
					if (isTakingANote || (GalaxyProcessor.universeMapManager != null && GalaxyProcessor.universeMapManager.isEditingConstellationProperties))
					{
						GUI.enabled = false;
					}
					if (isTakingANote || (GalaxyProcessor.universeMapManager != null && GalaxyProcessor.universeMapManager.isEditingConstellationProperties))
					{
						GUI.enabled = true;
					}
				}
				if (CurrentMapState == GalaxyMapState.Universe)
				{
					GalaxyProcessor.universeMapManager.Draw();
				}
				else if (!HideOverlays && !isShowingLogSelectionPanel && (_showBoardingConfigWindow || _showModsWindow || _showShipUpgradeWindow))
				{
					if (isTakingANote)
					{
						GUI.enabled = false;
					}
					if (isTakingANote)
					{
						GUI.enabled = true;
					}
				}
				if (isTakingANote)
				{
					galaxyNoteWindow.ShowWindow();
				}
			}
			else if (!isLoadingScene)
			{
				Color backgroundColor = GUI.backgroundColor;
				readyButtonRect.x = Screen.width - 200;
				readyButtonRect.y = Screen.height - 50;
				if (GUI.Button(readyButtonRect, "[R]eady!!"))
				{
					ReadyButtonPressed();
				}
				GUI.backgroundColor = backgroundColor;
				GUI.color = backgroundColor;
				cancelButtonRect.x = Screen.width - 100;
				cancelButtonRect.y = Screen.height - 50;
				if (GUI.Button(cancelButtonRect, "[C]ancel"))
				{
					CancelButtonPressed();
				}
			}
			if (!GlobalSettings.cheatMode)
			{
				return;
			}
			if (CurrentMapState != GalaxyMapState.Universe)
			{
				if (GUI.Button(new Rect(20f, 30f, 150f, 30f), "Create Ship Upgrades"))
				{
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.ShipSurveyor));
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.Transporter));
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.PowerManager));
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.RemotePower));
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.LongRangeScanner));
					GlobalSettings.GameState.ThePlayer.AddToInventory(ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.Quarantine));
				}
				if (GUI.Button(new Rect(20f, 60f, 150f, 30f), "Create Lots O' Scrap"))
				{
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap += 100;
				}
				if (GUI.Button(new Rect(20f, 90f, 150f, 30f), "Create Lots O' Rations"))
				{
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap += 100;
				}
			}
			if (debugLogViewer != null && debugLogViewer.IsShowing)
			{
				debugLogViewer.DrawWindow();
			}
		}
		else if (GalaxyProcessor.universeMapManager != null)
		{
			GalaxyProcessor.universeMapManager.Draw();
		}
	}

	private void JumpButtonPressed()
	{
		if (_selectedStarSystem.Id == GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
		{
			SetMapState(GalaxyMapState.Dungeons, true);
		}
		else if (CanJumpToSelectedStarSystem())
		{
			TravelToStarSystem();
		}
	}

	private void ObjectivesButtonPressed()
	{
		SystemOverlayUI.Instance.EndBlinkObjectiveButton();
		ObjectivesUI.Instance.Reset(EntryTypeEnum.Log, true);
		if (!ObjectivesUI.Instance.CategoryExists("log"))
		{
			ObjectivesUI.Instance.AddCategory("log", "Unfiled", EntryTypeEnum.Log);
		}
		if (LogManager.LogDataFile == null)
		{
			LogManager.InitManager();
		}
		List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName("LOG_");
		if (logList == null)
		{
			logList = new SortedList<int, string>();
		}
		else
		{
			logList.Clear();
		}
		foreach (string item in groupsByName)
		{
			int i;
			for (i = LogManager.LogDataFile.GetValue(item, "LOGID", 0); logList.ContainsKey(i); i++)
			{
			}
			logList.Add(i, item);
		}
		logList.Reverse();
		IEnumerator<KeyValuePair<int, string>> enumerator2 = logList.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			ObjectivesUI.Instance.AddEntryListing("log", string.Empty, string.Format("Log {0}", enumerator2.Current.Key), enumerator2.Current.Value, false);
		}
		ObjectiveManual.IsVisible = true;
		GameSaveFile.Save("FIRST_OBJECTIVE", true);
		GameAudio.Play2DSFX(GameAudio.SoundEnum.UIOpenMenu);
	}

	private void UpgradesButtonPressed()
	{
		ShowDroneBoardingConfigWindow(!_showBoardingConfigWindow);
	}

	private void ShipUpgradesButtonPressed()
	{
		ShowShipUpgradeBoardingConfigWindow(!_showShipUpgradeWindow);
	}

	private void BoardOrTravelButtonPressed()
	{
		ShowDroneBoardingConfigWindow(false);
		ShowShipUpgradeBoardingConfigWindow(false);
		ExecuteBoardOrTravel();
	}

	private void ReadyButtonPressed()
	{
		bool flag = false;
		int count = GlobalSettings.GameState.ThePlayer.Drones.Count;
		for (int i = 0; i < count; i++)
		{
			IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[i];
			if (!drone.IsDead && drone.DroneNumber <= 4 && drone.CurrentHitPoints > 0f)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			GalaxySaveFile.BeginBatch();
			GameSaveFile.BeginBatch();
			UniverseSaveFile.BeginBatch();
			BoardCurrentDungeon();
			SystemOverlayUI.Instance.EndBlinkBoardOrReadyButton();
			GalaxySaveFile.EndBatch();
			GameSaveFile.EndBatch();
			UniverseSaveFile.EndBatch();
		}
	}

	public void CloseTradingPostButtonPressed()
	{
		TradeUI.Instance.Hide();
		if (ObjectiveManual.AnyChangedItems())
		{
			SystemOverlayUI.Instance.BeginBlinkObjectiveButton();
		}
		SystemOverlayUI.Instance.IsVisible = true;
	}

	private void ModificationsButtonPressed()
	{
		if (!ModificationUI.Instance.IsShowing)
		{
			ModificationUI.Instance.Show();
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIOpenMenu);
		}
		else
		{
			ModificationUI.Instance.Hide();
		}
		_showModsWindow = !_showModsWindow;
		if (_showModsWindow)
		{
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.EndBlinkModificationButton();
			}
			HintManager.HintCompleted(typeof(ScrapAcquiredHint));
			Mothership.Instance.HideShip();
			Mothership.Instance.HideScanObjects();
		}
		else
		{
			SetMapState(CurrentMapState, true);
		}
		if (SystemOverlayUI.Instance != null && !PreparingToBoard)
		{
			SystemOverlayUI.Instance.IsVisible = !_showModsWindow;
		}
	}

	public void CloseModificationsButtonPressed()
	{
		_showModsWindow = false;
		if (!PreparingToBoard)
		{
			SystemOverlayUI.Instance.IsVisible = true;
			SystemOverlayUI.Instance.RefreshDroneInfo();
		}
		if (!isViewOnlyStarSystemView)
		{
			SetMapState(CurrentMapState, true);
		}
		if (CurrentMapState != GalaxyMapState.Universe && !isViewOnlyStarSystemView)
		{
			Mothership.Instance.ShowShip();
		}
		if (CurrentMapState == GalaxyMapState.StarSystems)
		{
			Mothership.Instance.ShowNearScanObject();
			if (GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
			{
				Mothership.Instance.ShowFarScanObject();
			}
		}
	}

	public void CloseTradingPost()
	{
		SetMapState(CurrentMapState, true);
	}

	private void CloseShipUpgradeButtonPressed()
	{
		ShowDroneBoardingConfigWindow(false);
		ShowShipUpgradeBoardingConfigWindow(false);
	}

	private void CancelButtonPressed()
	{
		ShowingUI = false;
		PreparingToBoard = false;
	}

	private void LogButtonPressed()
	{
		LogButtonPressed(false);
	}

	private void LogButtonPressed(bool showLatest)
	{
		isShowingLogSelectionPanel = !isShowingLogSelectionPanel;
		if (isShowingLogSelectionPanel)
		{
			if (!ObjectivesUI.Instance.CategoryExists("log"))
			{
				ObjectivesUI.Instance.AddCategory("log", "Unfiled", EntryTypeEnum.Log);
			}
			if (LogManager.LogDataFile == null)
			{
				LogManager.InitManager();
			}
			List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName("LOG_");
			if (logList == null)
			{
				logList = new SortedList<int, string>();
			}
			else
			{
				logList.Clear();
			}
			foreach (string item in groupsByName)
			{
				int i;
				for (i = LogManager.LogDataFile.GetValue(item, "LOGID", 0); logList.ContainsKey(i); i++)
				{
				}
				logList.Add(i, item);
			}
			logList.Reverse();
			IEnumerator<KeyValuePair<int, string>> enumerator2 = logList.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				ObjectivesUI.Instance.AddEntryListing("log", string.Empty, string.Format("Log {0}", enumerator2.Current.Key), enumerator2.Current.Value, false);
			}
			if (showLatest)
			{
				logSelectedIndex = 0;
			}
			ObjectivesUI.Instance.SetVisibility();
		}
		else
		{
			ObjectivesUI.Instance.Hide();
		}
		if (isShowingLogSelectionPanel)
		{
			SystemOverlayUI.Instance.EndBlinkLogButton();
		}
	}

	private void ShowDroneBoardingConfigWindow(bool show)
	{
		ShowDroneBoardingConfigWindow(show, false);
	}

	private void ShowDroneBoardingConfigWindow(bool show, bool preparingToBoard)
	{
		ShowingUI = show;
		_showBoardingConfigWindow = show;
		if (_boardingConfigUi != null)
		{
			if (show)
			{
				_boardingConfigUi.IsVisible = true;
				SystemOverlayUI.Instance.IsVisible = false;
				_boardingConfigUi.SetLatestData(preparingToBoard);
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UIOpenMenu);
			}
			else
			{
				_boardingConfigUi.IsVisible = false;
				SystemOverlayUI.Instance.IsVisible = true;
				SystemOverlayUI.Instance.RefreshDroneInfo();
			}
		}
	}

	private void ShowShipUpgradeBoardingConfigWindow(bool show)
	{
		if (show)
		{
			SystemOverlayUI.Instance.EndBlinkShipConfigButton();
			HintManager.HintCompleted(typeof(ShipUpgradeAcquiredHint));
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UIOpenMenu);
		}
		ShowingUI = show;
		_showShipUpgradeWindow = show;
		if (_shipConfigUi != null)
		{
			if (show)
			{
				_shipConfigUi.IsVisible = true;
				SystemOverlayUI.Instance.IsVisible = false;
				_shipConfigUi.SetLatestData();
			}
			else
			{
				_shipConfigUi.IsVisible = false;
				SystemOverlayUI.Instance.IsVisible = true;
				SystemOverlayUI.Instance.RefreshPlayerShipInfo();
			}
		}
	}

	private void DrawDragWindow(int id)
	{
		GUI.Label(new Rect(30f, 0f, 150f, 20f), GlobalSettings.InventoryDragInfo.ItemBeingDragged.Name);
	}

	private bool CanJumpToSelectedStarSystem()
	{
		return !isPlayerShipOnSystemTransitioning || (!SelectedStarSystemIsTooFar() && _selectedStarSystem.Id != GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id);
	}

	private void StarGateJumpResult(ModalWindowResult result, string input)
	{
		if (result != ModalWindowResult.Yes)
		{
			return;
		}
		GalaxyProcessor.universeMapManager.BeginJumpToGalaxy(SelectedDungeon.Parent);
		SelectedDungeon.HaveVisited = true;
		if (!GalaxySaveFile.Get(SelectedDungeon.GroupKey, "VISITED", false))
		{
			GalaxySaveFile.Save(SelectedDungeon.GroupKey, "VISITED", true);
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), 0) + 1);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), num);
			}
		}
		if (GalaxySaveFile.Get(SelectedDungeon.Parent.GroupKey, "SG_VISITED", false))
		{
			GalaxySaveFile.Save(SelectedDungeon.Parent.GroupKey, "SG_VISITED", true);
		}
	}

	public void ExternalConfirmJump()
	{
		if (!GalaxySaveFile.Get(SelectedDungeon.GroupKey, "VISITED", false))
		{
			GalaxySaveFile.Save(SelectedDungeon.GroupKey, "VISITED", true);
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), 0) + 1);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), num);
			}
		}
		GalaxySaveFile.Save(SelectedDungeon.Parent.GroupKey, "SG_VISITED", true);
		GlobalSettings.GameState.ThePlayer.Inventory.RechargePropulsionFuel();
	}

	private void ExecuteBoardOrTravel()
	{
		if (_distanceInDaysToTarget == 0)
		{
			if (SelectedDungeon == null || !SelectedDungeon.HaveVisited || SelectedDungeon.DungeonType == DungeonTypeEnum.AutoTrade || SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate)
			{
				bool flag = SelectedDungeon.DungeonType != DungeonTypeEnum.Outpost;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				if (!flag)
				{
					flag2 = !GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Transporter);
					if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key != null && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.allowedShipTypes == "all" || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.allowedShipTypes.Contains(GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.name.ToLower())))
					{
						flag = !flag2;
					}
					else
					{
						flag4 = true;
					}
				}
				if (SelectedDungeon.IsQuarentined && !GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Quarantine))
				{
					flag3 = true;
					flag = false;
				}
				if (flag)
				{
					if (SelectedDungeon.DungeonType == DungeonTypeEnum.AutoTrade)
					{
						bool flag5 = false;
						if (SelectedDungeon.HaveVisited || GlobalSettings.gameMode == GameModeEnum.Normal)
						{
						}
						if (!flag5)
						{
							ShowTradingPost();
						}
					}
					else if (SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate)
					{
						if (GlobalSettings.gameMode == GameModeEnum.Normal)
						{
							UniverseNode universeNode = (_selectedStarSystem.IsChildGate ? _selectedStarSystem.StargateConnection.childNode : _selectedStarSystem.StargateConnection.parentNode);
							UniverseNode universeNode2 = ((!_selectedStarSystem.IsChildGate) ? _selectedStarSystem.StargateConnection.childNode : _selectedStarSystem.StargateConnection.parentNode);
							if (!universeNode.IsVisited)
							{
								universeNode.IsVisitedConditional = true;
							}
							if (!universeNode2.IsVisited)
							{
								universeNode2.IsVisitedConditional = true;
							}
							SetMapState(GalaxyMapState.Universe, false);
							GalaxyProcessor.universeMapManager.BeginTravelMode(universeNode, universeNode2);
						}
						else if (SteamLeaderboard.HasWeeklyLeaderboard)
						{
							UpdateWeeklyChallengeScore(true, 1000);
						}
						else
						{
							DialogUI.Instance.ShowDialog("Challenge Done!", "You, um...won!!!!\n\nHIGH SCORE! (why not)\n\nToo bad there's nothing after this :)", ModalWindowType.OK, delegate
							{
								PauseMessageMainMenuPressed();
							});
						}
					}
					else
					{
						SystemOverlayUI.Instance.EndBlinkBoardOrReadyButton();
						PreparingToBoard = true;
						ShowDroneBoardingConfigWindow(true, true);
					}
					return;
				}
				GlobalSettings.IsGamePaused = true;
				string text = string.Empty;
				string empty = string.Empty;
				empty = ((SelectedDungeon.DungeonType != DungeonTypeEnum.Outpost) ? "Derelict" : "Outpost");
				if (flag2)
				{
					text += "\n- Missing transporter";
				}
				if (flag3)
				{
					text += "\n- Missing quarentine bypass";
				}
				if (flag4)
				{
					text += string.Format("\n- Can only board with a {0} ship type", GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.allowedShipTypes);
				}
				DialogUI.Instance.ShowDialog(string.Format("{0} Boarding Condition not Met", empty), string.Format("You are not able to board this {0} for the following reason(s):\n{1}", empty.ToLower(), text), ModalWindowType.OK, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.OK || result == ModalWindowResult.Cancel)
					{
						GlobalSettings.IsGamePaused = false;
						DialogUI.Instance.CloseDialog();
					}
				});
				CommonAudioHelper.Instance.PlayErrorSound();
			}
			else
			{
				GlobalSettings.IsGamePaused = true;
				DialogUI.Instance.ShowDialog("Can't revisit this ship.", "Travel to another ship or system to continue exploring...", ModalWindowType.OK, delegate
				{
					GlobalSettings.IsGamePaused = false;
					DialogUI.Instance.CloseDialog();
				});
			}
		}
		else
		{
			TravelToDungeon();
		}
	}

	private void UpdateWeeklyChallengeScore(bool isFinal, int bonusFinalScore)
	{
		int num = Mathf.RoundToInt((float)GameSaveFile.Get("ST_CUR_DAYS", 0) * 1f);
		float num2 = 0f;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
		{
			num2 += drone.CurrentHitPoints;
			if (!drone.IsDead || drone.CanBeFullyRepaired)
			{
				num3++;
			}
			foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
			{
				if (upgrade != null && upgrade.BrokenState != BrokenStateEnum.Broken)
				{
					num4++;
				}
			}
		}
		List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy;
		foreach (IInventoryItem item in itemsCopy)
		{
			if (item is BaseDroneUpgrade)
			{
				num4++;
			}
			else
			{
				num5++;
			}
		}
		itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
		foreach (IInventoryItem item2 in itemsCopy)
		{
			if (item2 is BaseShipUpgrade)
			{
				num5++;
			}
		}
		int num6 = GlobalSettings.GameState.ThePlayer.Inventory.Scrap * 1;
		int num7 = (GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge) * 5;
		int num8 = GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel * 20;
		int num9 = Mathf.RoundToInt(num2 * 10f);
		int num10 = num3 * 35;
		int num11 = num4 * 3;
		int num12 = num5 * 30;
		int finalScore = num6 + num7 + num8 + num9 + num10 + num11 + num12;
		if (isFinal)
		{
			finalScore += bonusFinalScore;
			DialogUI.Instance.ShowDialog("Weekly Challenge Score", string.Format("Final score calculated as follows:\n\n - Scrap: \t\t\t{3, 5} ( {1, 3} * {2, 2} )\n - P-Fuel: \t\t\t{6, 5} ( {4, 3} * {5, 2} )\n - J-Fuel: \t\t\t{9, 5} ( {7, 3} * {8, 2} )\n - Drone HP: \t\t{12, 5} ( {10, 3} * {11, 2} )\n - Drones: \t\t\t{15, 5} ( {13, 3} * {14, 2} )\n - Drone Upgrades: \t{18, 5} ( {16, 3} * {17, 2} )\n - Ship Upgrades: \t{21, 5} ( {19, 3} * {20, 2} )\n - Stargate: \t\t{22, 5}\n\n - Total: \t\t\t{0, 5}", finalScore, GlobalSettings.GameState.ThePlayer.Inventory.Scrap, 1, num6, GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge, 5, num7, GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel, 20, num8, num2, 10, num9, num3, 35, num10, num4, 3, num11, num5, 30, num12, bonusFinalScore), ModalWindowType.OK, delegate
			{
				SteamLeaderboard.PostChallengeScore(GameModeEnum.WeeklyChallenge, finalScore, SteamLeaderboard.ScoreStatusEnum.Final);
				GlobalSettings.ShowWeeklyLeaderboard = true;
				PauseMessageMainMenuPressed();
			}, 1);
		}
		else
		{
			SteamLeaderboard.PostChallengeScore(GameModeEnum.WeeklyChallenge, finalScore, SteamLeaderboard.ScoreStatusEnum.Partial);
		}
	}

	private void ShowTradingPost()
	{
		FillTradingPostInventory((TradingPostInfo)SelectedDungeon);
		TradeUI.Instance.Show();
		SelectedDungeon.HaveVisited = true;
		if (!GalaxySaveFile.Get(SelectedDungeon.GroupKey, "VISITED", false))
		{
			GalaxySaveFile.Save(SelectedDungeon.GroupKey, "VISITED", true);
			int num = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", SelectedDungeon.DungeonType), num);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", SelectedDungeon.DungeonType), 0) + 1);
			if (num > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", SelectedDungeon.DungeonType), num);
			}
		}
		UpdateAllDungeonVisualDistanceIndications();
		SystemOverlayUI.Instance.IsVisible = false;
		Mothership.Instance.HideShip();
	}

	private void SetMapState(GalaxyMapState state, bool ignoreSound)
	{
		SetMapState(state, false, ignoreSound);
	}

	private void SetMapState(GalaxyMapState state, bool force, bool ignoreSound)
	{
		if (!force && state == CurrentMapState)
		{
			return;
		}
		isViewOnlyStarSystemView = UniverseMapManager.Instance.IsReadOnlyGalaxy;
		StarSystemInfo currentStarSystem = GlobalSettings.GameState.ThePlayer.CurrentStarSystem;
		GalaxyNode nodeFromStarSystemInfo = GetNodeFromStarSystemInfo(currentStarSystem);
		if (CurrentMapState == GalaxyMapState.Universe)
		{
			GalaxyProcessor.universeMapManager.Hide();
		}
		PreviousMapState = CurrentMapState;
		switch (state)
		{
		case GalaxyMapState.Universe:
			if (!ignoreSound && CurrentMapState != state)
			{
				PlayViewChangeUp();
			}
			if (isPlayerShipOnDungeonTransitioning)
			{
				isPlayerShipOnDungeonTransitioning = false;
				timerPlayerTransition = 0f;
			}
			else if (isPlayerShipOnSystemTransitioning)
			{
				isPlayerShipOnSystemTransitioning = false;
				timerPlayerTransition = 0f;
			}
			HideGalaxyView();
			HideStarSystemView();
			StarField.Instance.GalaxyView();
			Mothership.Instance.StarSystemView(true);
			GalaxyProcessor.universeMapManager.Show();
			SystemOverlayUI.Instance.SwitchToUniverse();
			break;
		case GalaxyMapState.Dungeons:
			if (!ignoreSound && CurrentMapState != state)
			{
				PlayViewChangeDown();
			}
			guiCamera.transform.position = guiCameraHomePos;
			if (isPlayerShipOnSystemTransitioning)
			{
				isPlayerShipOnSystemTransitioning = false;
				timerPlayerTransition = 0f;
			}
			ShowStarSystemView(currentStarSystem, UniverseMapManager.Instance.IsReadOnlyGalaxy ? true : false, ignoreSound);
			HintManager.HintCompleted(typeof(SystemViewChangeHint));
			break;
		case GalaxyMapState.StarSystems:
			if (!ignoreSound && CurrentMapState != state)
			{
				if (PreviousMapState == GalaxyMapState.Universe)
				{
					PlayViewChangeDown();
				}
				else
				{
					PlayViewChangeUp();
				}
			}
			guiCamera.transform.position = guiCameraHomePos;
			if (backgroundCamera != null && GlobalSettings.GenerateGalaxyMapFromImage)
			{
				backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = true;
				CameraStarSystemOverlay[] components = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
				foreach (CameraStarSystemOverlay cameraStarSystemOverlay in components)
				{
					cameraStarSystemOverlay.enabled = true;
				}
			}
			previouslySelectedDungeon = SelectedDungeon;
			SelectedDungeon = null;
			HideStarSystemView();
			if (isPlayerShipOnDungeonTransitioning)
			{
				isPlayerShipOnDungeonTransitioning = false;
				timerPlayerTransition = 0f;
			}
			_starSystemNodes.ForEach(delegate(GalaxyNode x)
			{
				ShowStarSystemNode(x, true);
			});
			SetPlayerShipStarSystem(currentStarSystem, true);
			UpdateAllStarSystemVisualDistanceIndications();
			if (lastViewedStarSystem != null && lastViewedStarSystem != currentStarSystem)
			{
				SetSelectedStarSystem(lastViewedStarSystem, true);
			}
			UpdateGalaxyOverlays();
			StarField.Instance.GalaxyView();
			Mothership.Instance.GalaxyView();
			if (SystemOverlayUI.Instance != null)
			{
				SystemOverlayUI.Instance.RefreshSelectedSystem(_selectedStarSystem);
			}
			break;
		}
		CurrentMapState = state;
	}

	private void PlayViewChangeUp()
	{
		GameAudio.SoundEnum key = GameAudio.SoundEnum.None;
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			key = GameAudio.SoundEnum.UIChangeViewUp1;
			break;
		case 1:
			key = GameAudio.SoundEnum.UIChangeViewUp2;
			break;
		case 2:
			key = GameAudio.SoundEnum.UIChangeViewUp3;
			break;
		}
		GameAudio.Play2DSFX(key);
	}

	private void PlayViewChangeDown()
	{
		GameAudio.SoundEnum key = GameAudio.SoundEnum.None;
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			key = GameAudio.SoundEnum.UIChangeViewDown1;
			break;
		case 1:
			key = GameAudio.SoundEnum.UIChangeViewDown2;
			break;
		case 2:
			key = GameAudio.SoundEnum.UIChangeViewDown3;
			break;
		}
		GameAudio.Play2DSFX(key);
	}

	private void ShowStarSystemView(StarSystemInfo starSystem, bool viewOnly, bool ignoreSound)
	{
		lastViewedStarSystem = starSystem;
		isViewOnlyStarSystemView = viewOnly;
		if (UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			isViewOnlyStarSystemView = true;
		}
		if (!ignoreSound)
		{
			PlayViewChangeDown();
		}
		HideGalaxyView();
		if (starSystem.Dungeons == null)
		{
			GalaxyProcessor.GenerateDungeonInfo(starSystem, true, null);
		}
		if (starSystem.galaxyNode.DungeonNodes == null)
		{
			if (GameSaveFile.Get("GAME_VER", 0f) > 0.283f)
			{
				_selectedStarSystem.OrbitLineRotation = UnityEngine.Random.Range(0, 360);
			}
			CreateDungeonNodes(starSystem.galaxyNode);
		}
		starSystem.galaxyNode.DungeonNodes.ForEach(delegate(DungeonNode x)
		{
			ShowDungeonNode(x, true);
		});
		DungeonInfo dungeonInfo = null;
		if (!viewOnly)
		{
			if (lastStarJumpBetweenStargateSystems)
			{
				dungeonInfo = starSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.DungeonType == DungeonTypeEnum.Stargate);
				lastStarJumpBetweenStargateSystems = false;
			}
			else
			{
				dungeonInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
			}
		}
		bool flag = false;
		if (dungeonInfo == null || !DungeonIsInSystem(dungeonInfo, starSystem))
		{
			bool flag2 = false;
			string groupKey = starSystem.GroupKey;
			string selectedID = GalaxySaveFile.Get(groupKey, "LAST_DOCKED_ID", string.Empty);
			if (string.IsNullOrEmpty(selectedID))
			{
				selectedID = GalaxySaveFile.Get(groupKey, "LAST_SELECTED_ID", string.Empty);
			}
			else
			{
				flag2 = true;
			}
			dungeonInfo = null;
			if (!string.IsNullOrEmpty(selectedID))
			{
				dungeonInfo = starSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == selectedID && !GalaxySaveFile.Get(x.GroupKey, "VISITED", false));
			}
			if (dungeonInfo == null)
			{
				dungeonInfo = (flag2 ? starSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == selectedID) : starSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && !GalaxySaveFile.Get(x.GroupKey, "VISITED", false)));
			}
			if (dungeonInfo != null)
			{
				SetPlayerShipDungeon(dungeonInfo, true);
			}
			else
			{
				if (!string.IsNullOrEmpty(selectedID))
				{
					dungeonInfo = starSystem.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == selectedID);
				}
				if (dungeonInfo != null)
				{
					SetPlayerShipDungeon(dungeonInfo, false);
				}
				else
				{
					Debug.LogWarning("No unvisited nodes, selecting the first node in this system.");
					SetPlayerShipDungeon(starSystem.Dungeons.First(), false);
				}
			}
		}
		else
		{
			if (previouslySelectedDungeon != null && previouslySelectedDungeon.Parent == starSystem)
			{
				flag = true;
			}
			if (previouslySelectedDungeon == SelectedDungeon)
			{
				flag = false;
			}
			SetPlayerShipDungeon(dungeonInfo, true);
			if (flag)
			{
				SetSelectedDungeon(previouslySelectedDungeon, true);
			}
		}
		previouslySelectedDungeon = null;
		UpdateAllDungeonVisualDistanceIndications(starSystem);
		StarField.Instance.StarSystemView();
		Mothership.Instance.StarSystemView(viewOnly);
		CurrentMapState = GalaxyMapState.Dungeons;
		SystemOverlayUI.Instance.SwitchToSystem(viewOnly, SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate);
		SystemOverlayUI.Instance.RefreshSelectedDungeon(SelectedDungeon);
		if (flag)
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
			{
				_distanceInDaysToTarget = CalculateDungeonDistanceInDays(SelectedDungeon.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates);
			}
			else
			{
				_distanceInDaysToTarget = 0;
			}
			if (SystemOverlayUI.Instance != null)
			{
				if (_distanceInDaysToTarget == 0)
				{
					if (SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate)
					{
						SystemOverlayUI.Instance.SetStargateAsTravel();
					}
					else
					{
						SystemOverlayUI.Instance.SetDungeonAsBoard();
					}
				}
				else
				{
					SystemOverlayUI.Instance.SetDungeonAsTravel();
				}
				SystemOverlayUI.Instance.SetCurrentDungeonTravelAbility(!SelectedDungeonIsTooFar());
			}
		}
		if (SelectedStarSystem == null || !ObjectiveManual.IsObjectiveStepActive("superpredator", "stepC"))
		{
			return;
		}
		int num = GalaxySaveFile.Get(SelectedStarSystem.GroupKey, "SP", 0);
		if (num == 0 || Convert.ToBoolean(GameSaveFile.Get("SP", "scn" + num, "false")))
		{
			return;
		}
		GameSaveFile.Add("SP", "scn" + num, "true");
		int num2 = 0;
		bool flag3 = true;
		for (int num3 = 0; num3 < 3; num3++)
		{
			if (!Convert.ToBoolean(GameSaveFile.Get("SP", "scn" + (num3 + 1), "false")))
			{
				flag3 = false;
			}
			else
			{
				num2++;
			}
		}
		if (flag3)
		{
			LogManager.LogDataFile.SaveValue("superpredator", "stepC", 4);
			LogManager.LogDataFile.SaveValue("superpredator", "stepD", 2);
			ObjectiveManual.SetObjectiveStepComplete("superpredator", "stepC");
			ObjectiveManual.AddStep("superpredator", "stepD", "Objective 4", "Data/ShipsLogs/Super-Predator/SP_05_Log");
			LogManager.PushLogOntoPriorityOutpostMilitaryQueue("Super-Predator/SP_06_Log");
			SystemOverlayUI.Instance.BeginBlinkObjectiveButton();
		}
		else
		{
			HintManager.PushHint(new ObjectiveSPGalaxyScanHint(3 - num2), false, true);
		}
	}

	private void HideStarSystemView()
	{
		if (lastViewedStarSystem != null)
		{
			lastViewedStarSystem.galaxyNode.DungeonNodes.ForEach(delegate(DungeonNode x)
			{
				ShowDungeonNode(x, false);
			});
		}
	}

	private void HideGalaxyView()
	{
		if (backgroundCamera != null)
		{
			backgroundCamera.GetComponent<CameraGalaxyOverlay>().enabled = false;
			if (GlobalSettings.GenerateGalaxyMapFromImage)
			{
				CameraStarSystemOverlay[] components = backgroundCamera.GetComponents<CameraStarSystemOverlay>();
				foreach (CameraStarSystemOverlay cameraStarSystemOverlay in components)
				{
					cameraStarSystemOverlay.enabled = false;
				}
			}
		}
		_starSystemNodes.ForEach(delegate(GalaxyNode x)
		{
			ShowStarSystemNode(x, false);
		});
		if (stargateConnectionLines != null)
		{
			stargateConnectionLines.ForEach(delegate(GameObject x)
			{
				x.gameObject.SetActive(false);
			});
		}
		if (systemLines == null)
		{
			return;
		}
		foreach (GameObject systemLine in systemLines)
		{
			UnityEngine.Object.Destroy(systemLine);
		}
	}

	private void ShowDungeonNode(DungeonNode node, bool show)
	{
		if (show)
		{
			node.IsVisible = true;
			node.transform.position = node.Info.Coordinates;
			node.shortcutPressed = (DungeonNode.KeyPressedDelegate)Delegate.Remove(node.shortcutPressed, new DungeonNode.KeyPressedDelegate(DungeonKeyPressed));
			node.shortcutPressed = (DungeonNode.KeyPressedDelegate)Delegate.Combine(node.shortcutPressed, new DungeonNode.KeyPressedDelegate(DungeonKeyPressed));
		}
		else
		{
			node.IsVisible = false;
			node.shortcutPressed = (DungeonNode.KeyPressedDelegate)Delegate.Remove(node.shortcutPressed, new DungeonNode.KeyPressedDelegate(DungeonKeyPressed));
			node.transform.position = new Vector3(9999999f, 9999999f, 9999999f);
		}
		node.SetSelected(false);
	}

	private void ShowStarSystemNode(GalaxyNode node, bool show)
	{
		if (show)
		{
			if (node.IsScanned)
			{
				node.IsVisible = true;
			}
			node.shortcutPressed = (GalaxyNode.KeyPressedDelegate)Delegate.Remove(node.shortcutPressed, new GalaxyNode.KeyPressedDelegate(SystemKeyPressed));
			node.shortcutPressed = (GalaxyNode.KeyPressedDelegate)Delegate.Combine(node.shortcutPressed, new GalaxyNode.KeyPressedDelegate(SystemKeyPressed));
			node.transform.position = node.Info.Coordinates;
		}
		else
		{
			node.IsVisible = false;
			node.shortcutPressed = (GalaxyNode.KeyPressedDelegate)Delegate.Remove(node.shortcutPressed, new GalaxyNode.KeyPressedDelegate(SystemKeyPressed));
			node.transform.position = new Vector3(9999999f, 9999999f, 9999999f);
		}
	}

	private bool DungeonIsInSystem(DungeonInfo dungeon, StarSystemInfo starSystem)
	{
		if (starSystem.Dungeons == null)
		{
			return false;
		}
		return starSystem.Dungeons.Any((DungeonInfo x) => x.InternalId == dungeon.InternalId);
	}

	private void ConfirmJump(ModalWindowResult result, string input)
	{
		if (result == ModalWindowResult.Yes)
		{
			TravelToDungeon(true);
		}
	}

	private void TravelToDungeon()
	{
		TravelToDungeon(false);
	}

	private void TravelToDungeon(bool force)
	{
		int seed = UnityEngine.Random.seed;
		if (!force)
		{
			if (SelectedDungeonIsTooFar())
			{
				Debug.Log(string.Format("Player is {0} days from target, but only has {1} rations!", _distanceInDaysToTarget, GlobalSettings.GameState.ThePlayer.Inventory.Scrap));
				return;
			}
			if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery && GalaxySaveFile.GetStarSystemPathCount() == 1 && !SelectedDungeon.HaveVisited && !GameSaveFile.Get("MSG_DJ", false) && !GameSaveFile.Get("HNT_DISABLE", false))
			{
				DialogUI.Instance.ShowDialog("Really Visit Another Ship?", "You haven't yet boarded the ship you're docked at - are you sure you want to spend the fuel to travel to another?", ModalWindowType.YesNo, ConfirmJump, 1);
				return;
			}
		}
		RepairDronesWithThePassageOfTime(_distanceInDaysToTarget);
		if (!GlobalSettings.cheatMode)
		{
			GlobalSettings.GameState.ThePlayer.Inventory.DrainPropulsionFuel(_distanceInDaysToTarget);
		}
		GlobalSettings.GameState.ThePlayer.AddDaysTraveled(_distanceInDaysToTarget);
		SystemOverlayUI.Instance.BeginBlinkPropulsionFuelChange();
		SetPlayerShipDungeon(SelectedDungeon, false);
		UpdateAllDungeonVisualDistanceIndications();
		if (!GameSaveFile.Get("MSG_DJ", false))
		{
			GameSaveFile.Save("MSG_DJ", true);
		}
		if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
		{
			TestEndOfGameState();
		}
	}

	private bool CanTravelToStarSystem()
	{
		return CanTravelToStarSystem(false);
	}

	private bool CanTravelToStarSystem(bool failOnSelfJump)
	{
		if (isPlayerShipOnSystemTransitioning)
		{
			return false;
		}
		if (SelectedStarSystemIsTooFar())
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsStargateVisited && _selectedStarSystem.IsStargateVisited)
			{
				return true;
			}
			return false;
		}
		if (failOnSelfJump && _selectedStarSystem.Id == GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
		{
			return false;
		}
		return true;
	}

	private void TravelToStarSystem()
	{
		if (!CanTravelToStarSystem())
		{
			Debug.Log("Not enough rations to jump to target system!");
			return;
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.galaxyNode != null)
		{
			GlobalSettings.GameState.ThePlayer.CurrentStarSystem.galaxyNode.SetSelected(false);
		}
		RepairDronesWithThePassageOfTime(_distanceInDaysToTarget);
		lastStarJumpBetweenStargateSystems = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsStargateVisited && _selectedStarSystem.IsStargateVisited;
		if (!lastStarJumpBetweenStargateSystems)
		{
			if (!GlobalSettings.cheatMode)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel -= Mathf.CeilToInt((float)_distanceInDaysToTarget / 15f);
				GlobalSettings.GameState.ThePlayer.Inventory.RechargePropulsionFuel();
				SystemOverlayUI.Instance.BeginBlinkPropulsionFuelChange();
				if (!GameSaveFile.Get("WS_FUEL_RECHARGE", false))
				{
					if (!GameSaveFile.Get("HNT_DISABLE", false))
					{
						DialogUI.Instance.ShowDialog("Propulsion Fuel Recharged", "Everytime you jump between systems, your propulsion fuel recharges.\r\n\r\nNote: this does not apply to your reserve tank, displayed: [Propulsion: min/max (+reserve)]", ModalWindowType.OK, null);
					}
					GameSaveFile.Save("WS_FUEL_RECHARGE", true);
				}
			}
			GlobalSettings.GameState.ThePlayer.AddDaysTraveled(_distanceInDaysToTarget);
			SystemOverlayUI.Instance.BeginBlinkJumpFuelChange();
		}
		MarkNurseyAsVisited();
		SetPlayerShipStarSystem(_selectedStarSystem, false);
		GalaxySaveFile.AppendStarSystemToPath(_selectedStarSystem.Id);
		if (!GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", false))
		{
			UniverseSaveFile.Save("SYSJMP", UniverseSaveFile.Get("SYSJMP", 1) + 1);
			GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VIEWED", true);
			int num = GameSaveFile.Get("ST_CUR_SYS_VISITED", 0) + 1;
			GameSaveFile.Save("ST_CUR_SYS_VISITED", num);
			GameSaveFile.Save("ST_TTL_SYS_VISITED", GameSaveFile.Get("ST_TTL_SYS_VISITED", 0) + 1);
			if (num > GameSaveFile.Get("ST_BST_SYS_VISITED", 0))
			{
				GameSaveFile.Save("ST_BST_SYS_VISITED", num);
			}
		}
		UpdateAllStarSystemVisualDistanceIndications();
		int num2 = UniverseSaveFile.Get("SYSJMP", 1) - 1;
		int highestUnlockedInfectionType = GalaxyProcessor.GetHighestUnlockedInfectionType();
		if (highestUnlockedInfectionType < 4)
		{
			int num3 = highestUnlockedInfectionType * GlobalSettings.Constants.UnlockConstants.NUMBEROF_SYSJUMP_FOR_ENEMYTYPE;
			if (num2 >= num3)
			{
				GalaxyProcessor.UnlockNextInfestationType();
			}
		}
		previouslySelectedDungeon = null;
		if (!isPlayerShipOnSystemTransitioning && GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
		{
			TestEndOfGameState();
		}
	}

	private void UpdateAllDungeonVisualDistanceIndications()
	{
		UpdateAllDungeonVisualDistanceIndications(GlobalSettings.GameState.ThePlayer.CurrentStarSystem);
	}

	private int GetDistanceToClosestVisitableDungeon()
	{
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.Count;
			int num = int.MaxValue;
			for (int i = 0; i < count; i++)
			{
				DungeonInfo dungeonInfo = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons[i];
				if (dungeonInfo != null && dungeonInfo != GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon && !dungeonInfo.HaveVisited && dungeonInfo.HasRequiredEquipment)
				{
					int num2 = CalculateDungeonDistanceInDays(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons[i].Coordinates);
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			if (num == int.MaxValue)
			{
				return -1;
			}
			return num;
		}
		return -1;
	}

	private int GetDistanceToClosestSystem()
	{
		int count = GlobalSettings.GameState.StarSystems.Count;
		int num = int.MaxValue;
		for (int i = 0; i < count; i++)
		{
			if (GlobalSettings.GameState.StarSystems[i] != GlobalSettings.GameState.ThePlayer.CurrentStarSystem)
			{
				int num2 = CalculateStarSystemDistanceInDays(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates, GlobalSettings.GameState.StarSystems[i].Coordinates);
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		if (num == int.MaxValue)
		{
			return -1;
		}
		return num;
	}

	private void UpdateAllDungeonVisualDistanceIndications(StarSystemInfo starSystem)
	{
		if (starSystem.Dungeons == null)
		{
			return;
		}
		foreach (DungeonInfo dungeon in starSystem.Dungeons)
		{
			DungeonNode nodeFromDungeonInfo = GetNodeFromDungeonInfo(dungeon);
			bool flag = false;
			if (!isViewOnlyStarSystemView)
			{
				int num = CalculateDungeonDistanceInDays(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates, dungeon.Coordinates);
				if (nodeFromDungeonInfo != null)
				{
					flag = num <= GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel;
					nodeFromDungeonInfo.SetInRange(flag);
				}
			}
			else
			{
				flag = true;
				nodeFromDungeonInfo.SetInRange(true);
			}
			if (dungeon == SelectedDungeon)
			{
				SystemOverlayUI.Instance.RefreshSelectedDungeon(dungeon, nodeFromDungeonInfo);
			}
			if (flag && nodeFromDungeonInfo != null)
			{
				if (nodeFromDungeonInfo.Info.DungeonType == DungeonTypeEnum.Outpost)
				{
					if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Transporter))
					{
						if (nodeFromDungeonInfo.Info.Definition.Key.allowedShipTypes == "all" || nodeFromDungeonInfo.Info.Definition.Key.allowedShipTypes.Contains(GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.name.ToLower()))
						{
							nodeFromDungeonInfo.SetHasEquipment(true);
						}
						else
						{
							nodeFromDungeonInfo.SetHasEquipment(false);
							flag = false;
						}
					}
					else
					{
						nodeFromDungeonInfo.SetHasEquipment(false);
						flag = false;
					}
				}
				else
				{
					nodeFromDungeonInfo.SetHasEquipment(true);
				}
			}
			if (flag && dungeon.IsQuarentined)
			{
				if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Quarantine))
				{
					nodeFromDungeonInfo.SetHasEquipment(true);
					continue;
				}
				nodeFromDungeonInfo.SetHasEquipment(false);
				flag = false;
			}
		}
	}

	private void UpdateAllStarSystemVisualDistanceIndications()
	{
		int count = GlobalSettings.GameState.StarSystems.Count;
		for (int i = 0; i < count; i++)
		{
			StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems[i];
			GalaxyNode nodeFromStarSystemInfo = GetNodeFromStarSystemInfo(starSystemInfo);
			if (starSystemInfo.Id == GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id || UniverseMapManager.Instance.IsReadOnlyGalaxy)
			{
				nodeFromStarSystemInfo.SetInRange(true);
				continue;
			}
			if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem.HasStargate && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsStargateVisited && starSystemInfo.HasStargate && starSystemInfo.IsStargateVisited)
			{
				nodeFromStarSystemInfo.SetInRange(true);
				continue;
			}
			int num = CalculateStarSystemDistanceInDays(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates, starSystemInfo.Coordinates);
			nodeFromStarSystemInfo.SetInRange(num <= GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel * 15, num);
		}
		if (SystemOverlayUI.Instance != null)
		{
			SystemOverlayUI.Instance.SwitchToGalaxy();
			SystemOverlayUI.Instance.SetCurrentSystemJumpAbility(CanJumpToSelectedStarSystem());
		}
	}

	private void BoardCurrentDungeon()
	{
		int seed = UnityEngine.Random.seed;
		int count = GlobalSettings.GameState.StarSystems.Count;
		for (int i = 0; i < count; i++)
		{
			StarSystemInfo starSystemInfo = GlobalSettings.GameState.StarSystems[i];
			if (starSystemInfo.Dungeons != null)
			{
				int count2 = starSystemInfo.Dungeons.Count;
				for (int j = 0; j < count2; j++)
				{
					DungeonInfo dungeonInfo = starSystemInfo.Dungeons[j];
					dungeonInfo.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Remove(dungeonInfo.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
				}
			}
			if (starSystemInfo.galaxyNode != null)
			{
				int count3 = starSystemInfo.galaxyNode.DungeonNodes.Count;
				for (int k = 0; k < count3; k++)
				{
					DungeonNode dungeonNode = starSystemInfo.galaxyNode.DungeonNodes[k];
					dungeonNode.shortcutPressed = (DungeonNode.KeyPressedDelegate)Delegate.Remove(dungeonNode.shortcutPressed, new DungeonNode.KeyPressedDelegate(DungeonKeyPressed));
				}
				GalaxyNode galaxyNode = starSystemInfo.galaxyNode;
				galaxyNode.shortcutPressed = (GalaxyNode.KeyPressedDelegate)Delegate.Remove(galaxyNode.shortcutPressed, new GalaxyNode.KeyPressedDelegate(SystemKeyPressed));
			}
			starSystemInfo.OnStarSystemEvent = (StarSystemInfoEventDelegate)Delegate.Remove(starSystemInfo.OnStarSystemEvent, new StarSystemInfoEventDelegate(HandleStarSystemEvent));
		}
		GlobalSettings.GameStartedFromGalaxyMap = true;
		SelectedDungeon.HaveVisited = true;
		if (SelectedDungeon.Parent != null && SelectedDungeon.Parent.IsNursery && GameSaveFile.Get("NC", false))
		{
			SyncNurseryDataBetweenDataFiles();
		}
		UniverseSaveFile.Save("STAT_VDUN", UniverseSaveFile.Get("STAT_VDUN", 0) + 1);
		if (!GalaxySaveFile.Get(SelectedDungeon.GroupKey, "VISITED", false) && (GlobalSettings.gameMode != GameModeEnum.Normal || !GameSaveFile.Get("D_ABN_RVT", false)))
		{
			GalaxySaveFile.Save(SelectedDungeon.GroupKey, "VISITED", true);
			string key = "ST_CUR_VISITED_" + SelectedDungeon.DungeonType;
			string key2 = "ST_TTL_VISITED_" + SelectedDungeon.DungeonType;
			string key3 = "ST_BST_VISITED_" + SelectedDungeon.DungeonType;
			int num = GameSaveFile.Get(key, 0) + 1;
			GameSaveFile.Save(key, num);
			GameSaveFile.Save(key2, GameSaveFile.Get(key2, 0) + 1);
			if (num > GameSaveFile.Get(key3, 0))
			{
				GameSaveFile.Save(key3, num);
			}
		}
		if (!GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VISITED", false))
		{
			UniverseSaveFile.Save("STAT_VSYS", UniverseSaveFile.Get("STAT_VSYS", 0) + 1);
		}
		if (!GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VISITED", false))
		{
			GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentStarSystem.GroupKey, "VISITED", true);
		}
		if (!GlobalSettings.IsTutorial)
		{
			GameSaveFile.Save("MISSIONS", GameSaveFile.Get("MISSIONS", 0) + 1);
		}
		SelectedDungeon.Parent.Refresh();
		DungeonInfo dungeonInfo2 = null;
		count = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons.Count;
		for (int l = 0; l < count; l++)
		{
			DungeonInfo dungeonInfo3 = GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Dungeons[l];
			if (dungeonInfo3.HaveVisited || dungeonInfo3.InternalId == SelectedDungeon.InternalId || !dungeonInfo3.HasRequiredEquipment)
			{
				continue;
			}
			if (dungeonInfo2 == null)
			{
				dungeonInfo2 = dungeonInfo3;
				continue;
			}
			float num2 = Vector3.Distance(SelectedDungeon.Coordinates, dungeonInfo3.Coordinates);
			float num3 = Vector3.Distance(SelectedDungeon.Coordinates, dungeonInfo2.Coordinates);
			if (num2 < num3)
			{
				dungeonInfo2 = dungeonInfo3;
			}
		}
		if (dungeonInfo2 != null)
		{
			GlobalSettings.GameState.ThePlayer.RationsNeededForClosestUnvisitedDungeon = CalculateDungeonDistanceInDays(SelectedDungeon.Coordinates, dungeonInfo2.Coordinates);
		}
		else
		{
			GlobalSettings.GameState.ThePlayer.RationsNeededForClosestUnvisitedDungeon = 0;
		}
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy != null)
		{
			List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
			count = itemsCopy.Count;
			for (int m = 0; m < count; m++)
			{
				IInventoryItem inventoryItem = itemsCopy[m];
				if (inventoryItem is BaseShipUpgrade)
				{
					((BaseShipUpgrade)inventoryItem).UsedMissionCount++;
				}
			}
		}
		int num4 = GameSaveFile.Get("MISSIONS", 0);
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null)
		{
		}
		GlobalSettings.NumLogsAfterTutorial++;
		GlobalSettings.cheatMode = false;
		isLoadingScene = true;
		hasBoardedDungeon = true;
		scrapAtBoard = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		_shipUpgradesCountPriorToMission = GetTotalShipUpgradesCount();
		if (!GameSaveFile.Get("MSG_DJ", false))
		{
			GameSaveFile.Save("MSG_DJ", true);
		}
		Mothership.Instance.Stop();
		Application.LoadLevel(SelectedDungeon.SceneName);
	}

	public void DestroyObjectsBeforeBoard()
	{
		if (GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => !x.IsDead && x.DroneNumber <= 4))
		{
			DestroyStarSystemNodes();
			GalaxyNode.selectionIcon.SetActive(false);
			DungeonNode.selectionIcon.SetActive(false);
			PlayerShipInstance.SetActive(false);
		}
	}

	private int GetTotalShipUpgradesCount()
	{
		int num = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount;
		if (GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy != null)
		{
			List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy;
			int count = itemsCopy.Count;
			for (int i = 0; i < count; i++)
			{
				IInventoryItem inventoryItem = itemsCopy[i];
				if (inventoryItem is BaseShipUpgrade && !(inventoryItem as BaseShipUpgrade).IsBroken)
				{
					num++;
				}
			}
		}
		return num;
	}

	private bool SelectedDungeonIsTooFar()
	{
		if (GlobalSettings.cheatMode)
		{
			return false;
		}
		return GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel < _distanceInDaysToTarget;
	}

	private bool SelectedStarSystemIsTooFar()
	{
		if (GlobalSettings.cheatMode)
		{
			return false;
		}
		if (_selectedStarSystem.Id == GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Id)
		{
			return false;
		}
		return _distanceInDaysToTarget > GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel * 15;
	}

	private void UpdateGUIVariables()
	{
		if (guiRations != GlobalSettings.GameState.ThePlayer.Inventory.Scrap || guiDaysAlive != GlobalSettings.GameState.ThePlayer.DaysAlive)
		{
			guiRationDaysAliveCompactValue = string.Format("Scrap: {0} days, Days Alive: {1}", GlobalSettings.GameState.ThePlayer.Inventory.Scrap, GlobalSettings.GameState.ThePlayer.DaysAlive);
		}
		if (guiPropulsionFuelTotal != GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel)
		{
			guiPropulsionFuelTotal = GlobalSettings.GameState.ThePlayer.Inventory.TotalPropulsionFuel;
			guiPropulsionFuelChargeValue = "Propulsion: " + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge + " (+" + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve + ")";
		}
		if (guiJumpFuel != GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel)
		{
			guiJumpFuel = GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel;
			guiJumpFuelValue = "Jump: " + GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel;
		}
		if (guiRations != GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
		{
			guiRations = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
			guiRationsValue = "Scrap: " + GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		}
		if (guiDaysAlive != GlobalSettings.GameState.ThePlayer.DaysAlive)
		{
			guiDaysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
			guiDaysAliveValue = "Days Alive: " + GlobalSettings.GameState.ThePlayer.DaysAlive;
		}
		if (guiLastDockedDungeon != GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon)
		{
			guiDockedDungeonName = string.Format("     {0}", GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Name);
			guiLastDockedDungeon = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
		}
		if (guiCurrentSystem != GlobalSettings.GameState.ThePlayer.CurrentStarSystem)
		{
			guiCurrentSystemName = string.Format("    {0}", GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Name);
			guiCurrentSystem = GlobalSettings.GameState.ThePlayer.CurrentStarSystem;
		}
		if (lastViewedStarSystem != null)
		{
			if (guiLastViewedSystem != lastViewedStarSystem)
			{
				guiLastViewedSystemName = string.Format("     {0}", lastViewedStarSystem.Name);
				guiLastViewedSystem = lastViewedStarSystem;
			}
		}
		else
		{
			guiLastViewedSystem = null;
		}
		if (GalaxyProcessor.universeMapManager != null && guiCurrentUniverse != GalaxyProcessor.universeMapManager.CurrentUniverseNode)
		{
			guiCurrentUniverseName = string.Format("{0}", GalaxyProcessor.universeMapManager.CurrentUniverseNode.name);
			guiCurrentUniverse = GalaxyProcessor.universeMapManager.CurrentUniverseNode;
		}
	}

	private void DrawSelectedDungeonWindow(int id)
	{
		GUI.DragWindow();
		GUILayout.BeginVertical();
		GUILayout.Space(10f);
		GUILayout.Space(5f);
		GUILayout.EndVertical();
	}

	private void DrawPlayerShipWindowCompact(int id)
	{
		GUI.DragWindow();
		GUILayout.BeginVertical();
		GUILayout.Space(0f);
		bool flag = _rationsChangedTimer > 0f;
		GUILayout.EndVertical();
	}

	private void DrawSelectedDungeonWindowCompact(int id)
	{
		GUI.DragWindow();
		GUILayout.BeginVertical();
		GUILayout.Space(0f);
		GUILayout.EndVertical();
	}

	private void DrawSelectedStarSystemWindow(int id)
	{
		GUI.DragWindow();
		GUILayout.BeginVertical();
		GUILayout.Space(10f);
		int num = 0;
		if (_selectedStarSystem != null)
		{
			num = _selectedStarSystem.VisitedCount;
		}
		GUILayout.EndVertical();
	}

	private void SetPlayerShipDungeon(DungeonInfo dungeonInfo, bool ignoreTransition)
	{
		if (dungeonInfo != null)
		{
			if (!isPlayerShipOnDungeonTransitioning)
			{
				if (!isViewOnlyStarSystemView)
				{
					GalaxySaveFile.Save(_selectedStarSystem.GroupKey, "LAST_DOCKED_ID", dungeonInfo.GroupKey);
				}
				if (!ignoreTransition && GameSaveFile.Get("D_ANSHP", true))
				{
					int num = CalculateDungeonDistanceInDays(dungeonInfo.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates);
					playerShipStart = PlayerShipInstance.transform.position;
					Vector3 vector = new Vector3(dungeonInfo.Coordinates.x - 10f, dungeonInfo.Coordinates.y + 10f, -15f);
					playerShipDestination = vector;
					curretMaxTimer = (float)num / 3f;
					timerPlayerTransition = curretMaxTimer;
					transitionCurve = new AnimationCurve();
					transitionCurve.AddKey(0f, 0f);
					float num2 = curretMaxTimer * 0.3f;
					float num3 = num2 + curretMaxTimer * 0.4f;
					float time = num3 + curretMaxTimer * 0.3f;
					transitionCurve.AddKey(time, 1f);
					toggleFactor = UnityEngine.Random.Range(0.1f, 0.11f) * (curretMaxTimer / 2f);
					isPlayerShipOnDungeonTransitioning = true;
					isPlayerShipCloseFollow = false;
					isBeginningTransition = true;
					isEndingTransition = false;
					timerBeginEndTransition = curretMaxTimer * 0.25f;
					timerUntilTogglePlayerShipVisibility = toggleFactor;
				}
				else
				{
					PlayerShipInstance.transform.position = new Vector3(dungeonInfo.Coordinates.x - 10f, dungeonInfo.Coordinates.y + 10f, -15f);
				}
				GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon = dungeonInfo;
				SetSelectedDungeon(dungeonInfo, true);
			}
		}
		else
		{
			GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon = dungeonInfo;
			Debug.LogError("One time I had an error while 'resetting' where the passed in dungeon was null.  Not sure the cause.  Added this message to keep an eye out for it. (JP/11/2014)");
		}
	}

	public void StopTransitioning()
	{
		if (isPlayerShipOnDungeonTransitioning)
		{
			isPlayerShipOnDungeonTransitioning = false;
			timerPlayerTransition = 0f;
			PlayerShipInstance.transform.position = playerShipDestination;
		}
	}

	private void SetPlayerShipStarSystem(StarSystemInfo starSystemInfo, bool ignoreTransition)
	{
		if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem == null || ignoreTransition || !GameSaveFile.Get("D_ANSHP", true))
		{
			GlobalSettings.GameState.ThePlayer.CurrentStarSystem = starSystemInfo;
			Mothership.Instance.TravelToStarSystem(starSystemInfo);
			SetSelectedStarSystem(starSystemInfo, true);
		}
		else if (!isPlayerShipOnSystemTransitioning)
		{
			float num = CalculateStarSystemDistanceInDays(_selectedStarSystem.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates);
			isPlayerShipOnSystemTransitioning = true;
			isPlayerShipCloseFollow = false;
			curretMaxTimer = num / 4f;
			timerPlayerTransition = curretMaxTimer;
			transitionCurve = new AnimationCurve();
			transitionCurve.AddKey(0f, 0f);
			float num2 = curretMaxTimer * 0.3f;
			float num3 = num2 + curretMaxTimer * 0.4f;
			float time = num3 + curretMaxTimer * 0.3f;
			transitionCurve.AddKey(time, 1f);
			toggleFactor = UnityEngine.Random.Range(0.1f, 0.11f) * (curretMaxTimer / 2f);
			timerUntilTogglePlayerShipVisibility = toggleFactor;
			playerShipStart = PlayerShipInstance.transform.position;
			playerShipDestination = new Vector3(starSystemInfo.Coordinates.x - 5f, starSystemInfo.Coordinates.y + 5f, -15f);
			starSystemTransitioning = starSystemInfo;
			SetSelectedStarSystem(starSystemInfo, true);
		}
	}

	private void HandleDungeonEvent(DungeonEventType type, DungeonInfo sender)
	{
		if (type == DungeonEventType.Clicked)
		{
			SetSelectedDungeon(sender, false);
		}
	}

	private void HandleStarSystemEvent(StarSystemEventType type, StarSystemInfo sender)
	{
		if (type == StarSystemEventType.Clicked)
		{
			SetSelectedStarSystem(sender, false);
		}
	}

	public DungeonNode GetNodeFromDungeonInfo(DungeonInfo dungeon)
	{
		DungeonNode dungeonNode = null;
		foreach (GalaxyNode starSystemNode in _starSystemNodes)
		{
			if (starSystemNode.DungeonNodes != null)
			{
				dungeonNode = starSystemNode.DungeonNodes.FirstOrDefault((DungeonNode x) => x.Info.InternalId == dungeon.InternalId);
				if (dungeonNode != null)
				{
					break;
				}
			}
		}
		return dungeonNode;
	}

	private void SwapPlayerShipForCurrentDerelict()
	{
		DungeonInfo myShip = GlobalSettings.GameState.ThePlayer.MyShip;
		DungeonInfo thisDerelict = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
		DungeonNode nodeFromDungeonInfo = GetNodeFromDungeonInfo(thisDerelict);
		nodeFromDungeonInfo.Info = myShip;
		DungeonConfigurationManager.DifficultyValues calculatedDifficultyValues = myShip.CalculatedDifficultyValues;
		myShip.CalculatedDifficultyValues = thisDerelict.CalculatedDifficultyValues;
		thisDerelict.CalculatedDifficultyValues = calculatedDifficultyValues;
		myShip.Coordinates = thisDerelict.Coordinates;
		GlobalSettings.GameState.ThePlayer.MyShip = thisDerelict;
		GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon = myShip;
		DungeonInfo dungeonInfo = thisDerelict;
		dungeonInfo.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Remove(dungeonInfo.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
		myShip.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Remove(myShip.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
		myShip.OnDungeonEvent = (DungeonInfoEventDelegate)Delegate.Combine(myShip.OnDungeonEvent, new DungeonInfoEventDelegate(HandleDungeonEvent));
		StarSystemInfo parent = thisDerelict.Parent;
		DungeonInfo dungeonInfo2 = parent.Dungeons.FirstOrDefault((DungeonInfo x) => x != null && x.GroupKey == thisDerelict.GroupKey);
		if (dungeonInfo2 != null)
		{
			parent.Dungeons.Remove(dungeonInfo2);
		}
		parent.Dungeons.Add(myShip);
		thisDerelict.Parent = null;
		myShip.Parent = parent;
		List<KeyValuePair<string, string>> groupDataItems = UniverseSaveFile.GetGroupDataItems(myShip.GroupKey);
		List<KeyValuePair<string, string>> groupDataItems2 = GalaxySaveFile.GetGroupDataItems(thisDerelict.GroupKey);
		int num = GalaxySaveFile.Get(thisDerelict.GroupKey, "EPIDX", -1);
		UniverseSaveFile.ClearGroup(myShip.GroupKey);
		GalaxySaveFile.ClearGroup(thisDerelict.GroupKey);
		foreach (KeyValuePair<string, string> item in groupDataItems)
		{
			GalaxySaveFile.Save(myShip.GroupKey, item.Key, item.Value);
		}
		foreach (KeyValuePair<string, string> item2 in groupDataItems2)
		{
			UniverseSaveFile.Save(thisDerelict.GroupKey, item2.Key, item2.Value);
		}
		UniverseSaveFile.Save("PLAYER", "SHIP_ID", thisDerelict.GroupKey);
		UniverseSaveFile.Save(thisDerelict.GroupKey, "P", "PLAYER");
		GalaxySaveFile.Save(myShip.GroupKey, "P", parent.GroupKey);
		GalaxySaveFile.Save(myShip.GroupKey, "ORIG_ID", thisDerelict.GroupKey);
		if (GalaxySaveFile.Get(myShip.GroupKey, "VISITED", false))
		{
			GalaxySaveFile.Save(myShip.GroupKey, "VISITED", true);
			int num2 = GameSaveFile.Get(string.Format("{0}_{1}", "ST_CUR_VISITED", myShip.DungeonType), 0) + 1;
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_CUR_VISITED", myShip.DungeonType), num2);
			GameSaveFile.Save(string.Format("{0}_{1}", "ST_TTL_VISITED", myShip.DungeonType), GameSaveFile.Get(string.Format("{0}_{1}", "ST_TTL_VISITED", myShip.DungeonType), 0) + 1);
			if (num2 > GameSaveFile.Get(string.Format("{0}_{1}", "ST_BST_VISITED", myShip.DungeonType), 0))
			{
				GameSaveFile.Save(string.Format("{0}_{1}", "ST_BST_VISITED", myShip.DungeonType), num2);
			}
		}
		if (parent.IsNursery)
		{
			GalaxySaveFile.Save(myShip.GroupKey, "SD", true);
			if (num >= 0)
			{
				GalaxySaveFile.Save(myShip.GroupKey, "EPIDX", num);
			}
		}
		GalaxySaveFile.Save(myShip.GroupKey, "DMIN", myShip.DifficultyFactor);
		GalaxySaveFile.Save(myShip.GroupKey, "DMAX", myShip.DifficultyFactor);
		UniverseSaveFile.Save(thisDerelict.GroupKey, "DMIN", thisDerelict.DifficultyFactor);
		UniverseSaveFile.Save(thisDerelict.GroupKey, "DMAX", thisDerelict.DifficultyFactor);
		UniverseSaveFile.BeginBatch();
		List<string> list = null;
		foreach (BaseShipUpgrade item3 in thisDerelict.InstalledInventory.ItemsCopy)
		{
			if (list == null)
			{
				list = new List<string>();
			}
			list.Add(item3.GroupKey);
			SlotInfo nextFreeSlot = GlobalSettings.GameState.ThePlayer.MyShip.GetNextFreeSlot(item3.GroupKey);
			nextFreeSlot.InstallUpgrade(item3, myShip.InstalledInventory);
			item3.SaveData("SHIP", nextFreeSlot.SlotNumber);
			List<KeyValuePair<string, string>> groupDataItems3 = GalaxySaveFile.GetGroupDataItems(nextFreeSlot.GroupKey);
			foreach (KeyValuePair<string, string> item4 in groupDataItems3)
			{
				UniverseSaveFile.Save(nextFreeSlot.GroupKey, item4.Key, item4.Value);
			}
			UniverseSaveFile.Save(nextFreeSlot.GroupKey, "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
		}
		if (thisDerelict.InstalledInventory.ItemsCopy.Count < thisDerelict.ShipUpgradeSlots)
		{
			List<string> allGroups = GalaxySaveFile.GetAllGroups("SLOT_", "P", thisDerelict.GroupKey);
			foreach (string item5 in allGroups)
			{
				if (!(GalaxySaveFile.Get(item5, "SLOT_INSTKEY", string.Empty) == string.Empty))
				{
					continue;
				}
				List<KeyValuePair<string, string>> groupDataItems4 = GalaxySaveFile.GetGroupDataItems(item5);
				SlotInfo slotInfo = myShip.AddEmptySlot();
				foreach (KeyValuePair<string, string> item6 in groupDataItems4)
				{
					UniverseSaveFile.Save(slotInfo.GroupKey, item6.Key, item6.Value);
				}
				UniverseSaveFile.Save(slotInfo.GroupKey, "P", GlobalSettings.GameState.ThePlayer.MyShip.GroupKey);
			}
		}
		foreach (BaseShipUpgrade item7 in myShip.InstalledInventory.ItemsCopy)
		{
			if (item7.IsPermanentUpgrade)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(item7);
				item7.SaveData("SHIP", GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots - 1);
			}
			else
			{
				SlotInfo slotByUpgrade = GlobalSettings.GameState.ThePlayer.MyShip.GetSlotByUpgrade(item7);
				slotByUpgrade.ChangeSourceInventory(GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory);
			}
		}
		UniverseSaveFile.EndBatch();
		foreach (IInventoryItem item8 in GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy)
		{
			if (item8 is BaseShipUpgrade)
			{
				string groupKey = ((BaseShipUpgrade)item8).GroupKey;
				string text = UniverseSaveFile.Get(groupKey, "P", string.Empty);
				if (text.StartsWith("OBJ_"))
				{
					int num3 = 0;
					num3++;
				}
			}
		}
		myShip.ClearInfestationType();
		thisDerelict.ClearInfestationType();
		UniverseSaveFile.Save("PLAYER", "DEFINITION", GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.name);
		UniverseSaveFile.Save("PLAYER", "CLASS", GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value.name);
		SelectedDungeon = null;
	}

	private GalaxyNode GetNodeFromStarSystemInfo(StarSystemInfo starSystem)
	{
		return _starSystemNodes.FirstOrDefault((GalaxyNode x) => x.Info.Id == starSystem.Id);
	}

	public void SetSelectedDungeon(DungeonInfo dungeon, bool ignoreSound)
	{
		if (SelectedDungeon != null)
		{
			GetNodeFromDungeonInfo(SelectedDungeon).SetSelected(false);
		}
		SelectedDungeon = dungeon;
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			_distanceInDaysToTarget = CalculateDungeonDistanceInDays(SelectedDungeon.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates);
		}
		else
		{
			_distanceInDaysToTarget = 0;
		}
		if (SystemOverlayUI.Instance != null)
		{
			if (_distanceInDaysToTarget == 0)
			{
				if (SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate)
				{
					SystemOverlayUI.Instance.SetStargateAsTravel();
				}
				else
				{
					SystemOverlayUI.Instance.SetDungeonAsBoard();
				}
			}
			else
			{
				SystemOverlayUI.Instance.SetDungeonAsTravel();
			}
			SystemOverlayUI.Instance.SetCurrentDungeonTravelAbility(!SelectedDungeonIsTooFar());
		}
		DungeonNode nodeFromDungeonInfo = GetNodeFromDungeonInfo(SelectedDungeon);
		nodeFromDungeonInfo.SetSelected(true);
		if (systemLines == null)
		{
			systemLines = new List<GameObject>();
		}
		else
		{
			int count = systemLines.Count;
			for (int i = 0; i < count; i++)
			{
				UnityEngine.Object.Destroy(systemLines[i]);
			}
			systemLines.Clear();
		}
		if (!isViewOnlyStarSystemView && _selectedStarSystem.Dungeons != null && !UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (SelectedDungeon == GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon)
			{
				nodeFromDungeonInfo.SetDistanceFromSelected(0, false);
			}
			int count2 = _selectedStarSystem.Dungeons.Count;
			for (int j = 0; j < count2; j++)
			{
				DungeonInfo dungeonInfo = _selectedStarSystem.Dungeons[j];
				DungeonNode nodeFromDungeonInfo2 = GetNodeFromDungeonInfo(dungeonInfo);
				if (!(nodeFromDungeonInfo2 != null))
				{
					continue;
				}
				GameObject gameObject = new GameObject("line");
				LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
				Vector3 position = Vector3.zero;
				Vector3 position2 = Vector3.zero;
				bool flag = false;
				if (dungeonInfo != GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon)
				{
					if (dungeonInfo != SelectedDungeon)
					{
						int distance = CalculateDungeonDistanceInDays(SelectedDungeon.Coordinates, dungeonInfo.Coordinates);
						nodeFromDungeonInfo2.SetDistanceFromSelected(distance, false);
						position = nodeFromDungeonInfo2.transform.position;
						position2 = nodeFromDungeonInfo.transform.position;
						lineRenderer.SetWidth(2f, 2f);
						lineRenderer.material = SysDistanceToSelectedMaterial;
						lineRenderer.SetColors(SysLineDistanceToSelectedColor, SysLineDistanceToSelectedColor);
						flag = true;
					}
					else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
					{
						int distance2 = CalculateDungeonDistanceInDays(SelectedDungeon.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Coordinates);
						DungeonNode nodeFromDungeonInfo3 = GetNodeFromDungeonInfo(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon);
						nodeFromDungeonInfo2.SetDistanceFromSelected(distance2, true);
						position = nodeFromDungeonInfo2.transform.position;
						position2 = nodeFromDungeonInfo3.transform.position;
						lineRenderer.SetWidth(8f, 8f);
						lineRenderer.material = SysDistanceToDockedMaterial;
						lineRenderer.SetColors(SysLineDistanceToDockedColor, SysLineDistanceToDockedColor);
						flag = true;
					}
				}
				if (flag)
				{
					position.z = -1f;
					position2.z = -1f;
					lineRenderer.SetPosition(0, position);
					lineRenderer.SetPosition(1, position2);
					systemLines.Add(gameObject);
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}
		else if (_selectedStarSystem.Dungeons != null)
		{
			int count3 = _selectedStarSystem.Dungeons.Count;
			for (int k = 0; k < count3; k++)
			{
				DungeonInfo dungeon2 = _selectedStarSystem.Dungeons[k];
				DungeonNode nodeFromDungeonInfo4 = GetNodeFromDungeonInfo(dungeon2);
				if (nodeFromDungeonInfo4 != null)
				{
					nodeFromDungeonInfo4.SetDistanceFromSelected(-1, false);
				}
			}
		}
		string groupKey = _selectedStarSystem.GroupKey;
		GalaxySaveFile.Save(groupKey, "LAST_SELECTED_ID", SelectedDungeon.GroupKey);
		guiDistanceToTarget = string.Format("Distance: {0} day(s)", _distanceInDaysToTarget);
		if (SelectedDungeon.DungeonType == DungeonTypeEnum.Derelict)
		{
			guiSelectedDungeonClassOrType = "Ship Class: " + SelectedDungeon.DisplayName;
		}
		else if (SelectedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			guiSelectedDungeonClassOrType = "Type: " + SelectedDungeon.DisplayName;
		}
		else if (SelectedDungeon.DungeonType == DungeonTypeEnum.Stargate && SelectedDungeon.HaveVisited)
		{
			guiStargateDestination = string.Format("Destination: {0}", SelectedDungeon.Parent.IsChildGate ? SelectedDungeon.Parent.StargateConnection.parentNode.name : SelectedDungeon.Parent.StargateConnection.childNode.name);
		}
		guiAge = string.Format("Age: {0}", SelectedDungeon.Age);
		if (SelectedDungeon.DungeonType != DungeonTypeEnum.AutoTrade && SelectedDungeon.DungeonType != DungeonTypeEnum.Stargate)
		{
			guiInfestationType = "Infestation Types: " + SelectedDungeon.InfestationTypeCount;
		}
		else
		{
			guiInfestationType = string.Empty;
		}
		guiAgeInfestationTypeCompact = string.Format("Age: {0}, Infection Types: {1}", SelectedDungeon.Age, SelectedDungeon.InfestationTypeCount);
		if (SystemOverlayUI.Instance != null)
		{
			SystemOverlayUI.Instance.SetDungeonProperties(SelectedDungeon, nodeFromDungeonInfo, _distanceInDaysToTarget);
		}
		if (!ignoreSound)
		{
			GameAudio.Play2DSFX(GameAudio.SoundEnum.GalaxySelectNode);
		}
	}

	public void SetSelectedStarSystem(StarSystemInfo starSystem, bool ignoreSound)
	{
		if (_selectedStarSystem != null)
		{
			GetNodeFromStarSystemInfo(_selectedStarSystem).SetSelected(false);
		}
		_selectedStarSystem = starSystem;
		if (_selectedStarSystem != null)
		{
			_distanceInDaysToTarget = CalculateStarSystemDistanceInDays(_selectedStarSystem.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates);
		}
		else
		{
			_distanceInDaysToTarget = 0;
		}
		GetNodeFromStarSystemInfo(_selectedStarSystem).SetSelected(true);
		guiDistanceToTarget = string.Format("Distance: {0} day(s)", _distanceInDaysToTarget);
		if (SystemOverlayUI.Instance != null)
		{
			SystemOverlayUI.Instance.SetCurrentSystemJumpAbility(CanJumpToSelectedStarSystem());
			SystemOverlayUI.Instance.SetSystemProperties(starSystem, starSystem == GlobalSettings.GameState.ThePlayer.CurrentStarSystem);
		}
		if (!ignoreSound)
		{
			GameAudio.Play2DSFX(GameAudio.SoundEnum.GalaxySelectNode);
		}
	}

	public void RefreshStarSystemDistances()
	{
		if (_selectedStarSystem != null)
		{
			_distanceInDaysToTarget = CalculateStarSystemDistanceInDays(_selectedStarSystem.Coordinates, GlobalSettings.GameState.ThePlayer.CurrentStarSystem.Coordinates);
		}
		else
		{
			_distanceInDaysToTarget = 0;
		}
	}

	public static int CalculateStarSystemDistanceInDays(Vector3 pointA, Vector3 pointB)
	{
		float num = Vector3.Distance(pointA, pointB);
		if (num == 0f)
		{
			return 0;
		}
		return Mathf.CeilToInt(num / 7.5f);
	}

	public static int CalculateDungeonDistanceInDays(Vector3 pointA, Vector3 pointB)
	{
		float num = Vector3.Distance(pointA, pointB);
		if (num == 0f)
		{
			return 0;
		}
		return (int)(num / 80f + 1f);
	}

	public void ChoosePrevPreset()
	{
		_currentPresetIndex--;
		if (_currentPresetIndex < 0)
		{
			_currentPresetIndex = PresetManager.PresetList.Count - 1;
		}
		PresetManager.LoadPreset(_currentPresetIndex, GlobalSettings.GameState.ThePlayer.Drones);
	}

	public void ChooseNextPreset()
	{
		_currentPresetIndex++;
		if (_currentPresetIndex >= PresetManager.PresetList.Count)
		{
			_currentPresetIndex = 0;
		}
		PresetManager.LoadPreset(_currentPresetIndex, GlobalSettings.GameState.ThePlayer.Drones);
	}

	private void RepairDronesWithThePassageOfTime(int days)
	{
		for (int i = 0; i < days; i++)
		{
			RepairDronesWithThePassageOfOneDay();
		}
	}

	private void RepairDronesWithThePassageOfOneDay()
	{
		foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
		{
			if (drone.IsDead && drone.CanBeFullyRepaired && drone.DaysTraveledWhileDead < 1)
			{
				drone.DaysTraveledWhileDead++;
				if (drone.DaysTraveledWhileDead == 1)
				{
					drone.OverrideIsDead(false);
					drone.DaysTraveledWhileDead = 0;
				}
			}
			else
			{
				if (drone.IsDead)
				{
					continue;
				}
				foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
				{
					if (upgrade != null && upgrade.BrokenState != BrokenStateEnum.Broken)
					{
						IPoweredObject poweredObject = upgrade as IPoweredObject;
						if (poweredObject != null && poweredObject.CurrentPower < poweredObject.TotalPower && poweredObject.CanRecharge)
						{
							poweredObject.OverridePower(poweredObject.TotalPower);
						}
						if (upgrade is IStorageUpgrade)
						{
							((IStorageUpgrade)upgrade).AddItem(0);
						}
					}
				}
				if (drone.VideoSignalLost)
				{
					drone.VideoSignalLost = false;
					drone.TimeOfNextVideoLoss = 0f;
				}
			}
		}
	}

	private void RandomlyChoosePlayerUpgrades()
	{
		int seed = UnityEngine.Random.seed;
		if (UniverseMapManager.SeedFleet != -1)
		{
			seed = UniverseMapManager.SeedFleet;
		}
		System.Random random = new System.Random(seed);
		RandomlyChoosePlayerUpgrades(random.Next(1, 2), random);
		IDrone drone = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.DroneNumber == 3);
		if (drone != null && !drone.Upgrades.Any((BaseDroneUpgrade x) => x != null && x.Definition.Type == DroneUpgradeType.Tow))
		{
			drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Tow));
		}
		IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.DroneNumber == 1);
		if (drone2 != null && drone != null && drone2.Upgrades[2] != null && drone.Upgrades[1] == null)
		{
			drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(drone2.Upgrades[2].Definition.Type));
			drone2.RemoveDroneUpgrade(2);
		}
	}

	private void RandomlyChoosePlayerUpgrades(int numRandomFillerUpgrades, System.Random rnd)
	{
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		foreach (IDrone drone2 in GlobalSettings.GameState.ThePlayer.Drones)
		{
			drone2.RemoveAllUpgrades();
		}
		for (int i = 0; i < GlobalSettings.GameState.ThePlayer.Drones.Count; i++)
		{
			IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[i];
			for (int j = 0; j < drone.NumberOfUpgradeSlots; j++)
			{
				if (i == 0 && j == 0)
				{
					if (GlobalSettings.gameMode == GameModeEnum.Normal && !GlobalSettings.AreaSensorUsedOnce)
					{
						drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.AreaSensor));
					}
					else if (GlobalSettings.gameMode == GameModeEnum.Normal && !GlobalSettings.StealthUsedOnce)
					{
						drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.StealthField));
					}
					else if (GlobalSettings.gameMode == GameModeEnum.Normal && GlobalSettings.DiscoveredUpgradesOnly)
					{
						int num2 = 0;
						num2 = rnd.Next(0, GlobalSettings.DiscoveredUpgrades_Exploring.Count);
						DroneUpgradeType type = GlobalSettings.DiscoveredUpgrades_Exploring[num2];
						drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(type));
					}
					else
					{
						int num3 = 0;
						num3 = rnd.Next(0, GlobalSettings.Constants.EXPLORE_UPGRADE_TYPES.Length);
						DroneUpgradeType type2 = GlobalSettings.Constants.EXPLORE_UPGRADE_TYPES[num3];
						drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(type2));
					}
				}
				else if (!flag)
				{
					drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Gatherer));
					flag = true;
				}
				else if (num < numRandomFillerUpgrades)
				{
					if (GlobalSettings.DiscoveredUpgradesOnly)
					{
						if (!GlobalSettings.InterfaceUsedOnce)
						{
							drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Interface));
						}
						else
						{
							DroneUpgradeType droneUpgradeType = DroneUpgradeType.Undefined;
							droneUpgradeType = GlobalSettings.DiscoveredUpgrades[rnd.Next(0, GlobalSettings.DiscoveredUpgrades.Count)];
							int num4 = 0;
							while ((drone.HasUpgrade(droneUpgradeType) || (i == 0 && droneUpgradeType == DroneUpgradeType.Generator) || GlobalSettings.UPGRADE_IGNORE_STARTUP_LIST.Contains(droneUpgradeType)) && num4 < 100)
							{
								droneUpgradeType = GlobalSettings.DiscoveredUpgrades[rnd.Next(0, GlobalSettings.DiscoveredUpgrades.Count)];
								num4++;
							}
							drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(droneUpgradeType));
						}
						num++;
					}
					else
					{
						DroneUpgradeType droneUpgradeType2 = DroneUpgradeType.Undefined;
						droneUpgradeType2 = (DroneUpgradeType)rnd.Next(1, 22);
						int num5 = 0;
						while ((drone.HasUpgrade(droneUpgradeType2) || GlobalSettings.UPGRADE_IGNORE_STARTUP_LIST.Contains(droneUpgradeType2)) && num5 < 100)
						{
							droneUpgradeType2 = (DroneUpgradeType)rnd.Next(1, 22);
							num5++;
						}
						drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(droneUpgradeType2));
						num++;
					}
				}
				else
				{
					if (flag2)
					{
						return;
					}
					drone.AddDroneUpgrade(DroneUpgradeFactory.CreateUpgradeInstance(DroneUpgradeType.Generator));
					flag2 = true;
				}
			}
		}
	}

	private void RemoveExpandedInventoryItem(ExpandedInventoryItem expandedItem)
	{
		if (expandedItem.RealItem is BaseDroneUpgrade)
		{
			BaseDroneUpgrade upgrade = (BaseDroneUpgrade)expandedItem.RealItem;
			IDrone drone = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.Upgrades.Any((BaseDroneUpgrade u) => u == upgrade));
			drone.RemoveDroneUpgrade(upgrade);
		}
		else if (expandedItem.RealItem is BaseShipUpgrade)
		{
			GlobalSettings.GameState.ThePlayer.UninstallShipUpgrade((BaseShipUpgrade)expandedItem.RealItem);
		}
	}

	private bool OnPlayerInventoryTradeItemForRations(IInventoryItem item)
	{
		TradingPostInfo tradingPostInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon as TradingPostInfo;
		if (tradingPostInfo == null)
		{
			return false;
		}
		Inventory inventory = GlobalSettings.GameState.ThePlayer.Inventory;
		ExpandedInventoryItem expandedInventoryItem = item as ExpandedInventoryItem;
		bool flag = expandedInventoryItem != null;
		if (tradingPostInfo.Inventory.Scrap > 0 && tradingPostInfo.Inventory.InventoryCount < tradingPostInfo.Inventory.MaxInventorySpace && !item.IsBroken)
		{
			int num = 0;
			if (flag)
			{
				tradingPostInfo.Inventory.AddInventoryItem(expandedInventoryItem.RealItem);
			}
			else
			{
				tradingPostInfo.Inventory.AddInventoryItem(item);
			}
			num = Mathf.Min((int)item.SellValue, tradingPostInfo.Inventory.Scrap);
			tradingPostInfo.Inventory.Scrap -= num;
			if (inventory.Scrap + num <= GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax)
			{
				inventory.Scrap += num;
			}
			else
			{
				inventory.Scrap = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
			}
			if (flag)
			{
				RemoveExpandedInventoryItem(expandedInventoryItem);
			}
			else
			{
				inventory.RemoveInventoryItem(item);
			}
			UpdateAllDungeonVisualDistanceIndications();
			return true;
		}
		return false;
	}

	private bool OnPlayerInventorySwapItems(IInventoryItem droppedItem, IInventoryItem targetItem)
	{
		TradingPostInfo tradingPostInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon as TradingPostInfo;
		if (tradingPostInfo == null)
		{
			return false;
		}
		if (droppedItem.IsBroken || targetItem.IsBroken)
		{
			return false;
		}
		ExpandedInventoryItem expandedInventoryItem = targetItem as ExpandedInventoryItem;
		bool flag = expandedInventoryItem != null;
		if (flag)
		{
			targetItem = expandedInventoryItem.RealItem;
		}
		Inventory inventory = GlobalSettings.GameState.ThePlayer.Inventory;
		bool flag2 = inventory.SwapInventoryItem(droppedItem, targetItem, tradingPostInfo.Inventory);
		if (flag2 && flag)
		{
			RemoveExpandedInventoryItem(expandedInventoryItem);
		}
		return flag2;
	}

	private bool OnTradingPostInventoryTradeItemForRations(IInventoryItem item)
	{
		TradingPostInfo tradingPostInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon as TradingPostInfo;
		if (tradingPostInfo == null)
		{
			return false;
		}
		Inventory inventory = GlobalSettings.GameState.ThePlayer.Inventory;
		int num = (int)item.SellValue;
		if (inventory.Scrap >= num && inventory.InventoryCount < inventory.MaxInventorySpace && !item.IsBroken)
		{
			inventory.AddInventoryItem(item);
			tradingPostInfo.Inventory.Scrap += num;
			inventory.Scrap -= num;
			tradingPostInfo.Inventory.RemoveInventoryItem(item);
			UpdateAllDungeonVisualDistanceIndications();
			return true;
		}
		return false;
	}

	private bool OnTradingPostInventorySwapItems(IInventoryItem droppedItem, IInventoryItem targetItem)
	{
		TradingPostInfo tradingPostInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon as TradingPostInfo;
		if (tradingPostInfo == null)
		{
			return false;
		}
		if (droppedItem.IsBroken || targetItem.IsBroken)
		{
			return false;
		}
		ExpandedInventoryItem expandedInventoryItem = droppedItem as ExpandedInventoryItem;
		bool flag = expandedInventoryItem != null;
		if (flag)
		{
			droppedItem = expandedInventoryItem.RealItem;
		}
		Inventory inventory = GlobalSettings.GameState.ThePlayer.Inventory;
		bool flag2 = tradingPostInfo.Inventory.SwapInventoryItem(droppedItem, targetItem, inventory);
		if (flag2 && flag)
		{
			RemoveExpandedInventoryItem(expandedInventoryItem);
		}
		return flag2;
	}

	public void CloseNoteWindow()
	{
		isTakingANote = false;
		SystemOverlayUI.Instance.SetNoteMode(isTakingANote);
	}

	private void HandleShipUpgradeUninstalled(object sender, EventArgs args)
	{
		UpdateAllDungeonVisualDistanceIndications();
	}

	private void ShipBoarded()
	{
		isHidingAll = true;
		if (lastViewedStarSystem != null)
		{
			lastViewedStarSystem.galaxyNode.DungeonNodes.ForEach(delegate(DungeonNode x)
			{
				ShowDungeonNode(x, false);
			});
		}
		Mothership.Instance.HideShip();
	}

	private void ShowPauseMenu()
	{
		if (PauseMenu.Instance == null)
		{
			pauseMenu = new PauseMenu(true, false);
			pauseMenu.restartVerify = PauseMenuResetVerify;
			pauseMenu.restartSelected = PauseMenuReset;
			pauseMenu.fullRestartSelected = PauseMenuFullReset;
			pauseMenu.mainMenuVerify = PauseMessageMainMenuVerify;
			pauseMenu.mainMenuSelected = PauseMessageMainMenuPressed;
			pauseMenu.exitSelected = PauseMessageMainMenuPressed;
		}
	}

	private void AddSoundSources()
	{
		asMotherShipAmbience = base.gameObject.AddComponent<AudioSource>();
		asMotherShipAmbience.clip = GameAudio.GetClip(GameAudio.SoundEnum.A_MotherShip);
		asMotherShipAmbience.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.A_MotherShip, GameAudio.AmbienceVolume);
		asMotherShipAmbience.playOnAwake = false;
		asMotherShipAmbience.loop = true;
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.A_MotherShip);
	}

	private void SteamOverlayToggle(bool isOn)
	{
		if (isOn)
		{
			ShowPauseMenu();
		}
		else if (Screen.fullScreen && GameSaveFile.Get("O_RFS", false))
		{
			Screen.fullScreen = false;
			autoFullScreen = true;
			timerTillFullScreen = 0.3f;
		}
	}

	public void PlayDbfNonBark()
	{
		AudioSource audioSource = CommonMethods.PickRandomItem(OwnedDbfSounds);
		if (audioSource != null)
		{
			audioSource.volume = GameAudio.AmbienceVolume;
			audioSource.Play();
		}
		else
		{
			Debug.LogWarning("no owned dbf audio found!");
		}
	}
}
