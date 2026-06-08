using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
	private const float GAMEOVER_TIME_BEFORE_WINDOW = 3f;

	public static GameplayManager Instance;

	public static int SeedRadiationEvent = -1;

	public static int SeedDoorCloseEvent = -1;

	public static int SeedDoorFailEvent = -1;

	public static int SeedAirlookFailEvent = -1;

	public static int SeedAsteroidEvent = -1;

	public static int SeedGenerateEnemies = -1;

	public static int SeedDailyShipUpgrades = -1;

	public Color MainTextColor = GlobalSettings.Constants.CONSOLE_GREEN;

	public Color PredictedTextColor = Color.black;

	public Color CursorColor = GlobalSettings.Constants.CONSOLE_GREEN;

	public float CursorAlpha = 0.3f;

	public Color PredictedHighlightColor = Color.white;

	public float PredictedHighlightAlpha = 0.9f;

	public GameObject videoSignalMissingObject;

	public SVInformationUI SVInfoUI;

	private System.Random _random = new System.Random();

	private DroneManager _droneManager;

	private DroneSummaryWindow _droneSummaryWindowForSchematic;

	private DungeonManager _dungeonManager;

	private GameEventManager gameEventManager;

	public bool ShowConsoleWindow = true;

	public GameObject ConsoleUiObject;

	private ConsoleWindow3 _consoleWindow;

	public GameObject ScreenDimUIObject;

	private Image screenDimUIImage;

	private bool isShowingDroneSwapUI;

	public GameObject DroneSwapUi;

	private DroneSwapUi2 _droneSwapUi;

	public GameObject HelpManualUiObject;

	private HelpManual _helpManualWindow;

	public GameObject SchematicViewCanvasObject;

	private SchematicViewCanvas _schemViewCanvas;

	private GameWindowStates _windowState;

	public int missionProfitLoss;

	private readonly float GAME_OVER_DELAY_TIME = 3f;

	private bool startedGamedOverTimer;

	private float _gameOverTimer;

	private List<string> _savedScreenShots = new List<string>();

	private float _screenshotReportTimer;

	private float _gameOverTimerBeforeWindow;

	private GameObject _blankScreenObject;

	private bool _showSchematicToggleItems = true;

	private bool showingPauseMenuAfterDeath;

	private bool _firstUpdate = true;

	private bool hasTestedMouseDownWarning;

	private bool autoFullScreen;

	private float timerTillFullScreen;

	private bool _userHideConsole;

	private int guiLastKnownRations = -1;

	private int guiLastKnownPFuelCollected = -1;

	private int guiLastKnownJFuelCollected = -1;

	private bool recordedRectsForMouseHint;

	public bool CommandBeingTyped
	{
		get
		{
			return _consoleWindow.CommandBeingEntered;
		}
	}

	public bool isCommandeering
	{
		get
		{
			return _windowState == GameWindowStates.ShowShipSwap;
		}
	}

	public PauseMenu pauseMenu { get; private set; }

	public bool arrowPressedOnSchematic { get; set; }

	public bool isHidingCanvases { get; private set; }

	public bool showSchematicToggleItems
	{
		get
		{
			return _showSchematicToggleItems;
		}
		private set
		{
			_showSchematicToggleItems = value;
		}
	}

	public GameWindowStates WindowState
	{
		get
		{
			return _windowState;
		}
		set
		{
			_windowState = value;
		}
	}

	private void Awake()
	{
		Instance = this;
		int vSyncCount = QualitySettings.vSyncCount;
		Debug.Log("SU AUDIT - BEGIN in GameplayManager.Awake()");
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					IInventoryItem inventoryItem = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[i];
					if (inventoryItem != null)
					{
						if (inventoryItem is BaseShipUpgrade)
						{
							Debug.Log(string.Format("SU AUDIT - ItemsCopy[ {0} ] == {1}", i, inventoryItem.GetType()));
						}
						else
						{
							Debug.Log(string.Format("SU AUDIT - ItemsCopy[ {0} ] is not a SHIP upgrade!  Should be impossible.", i));
						}
					}
					else
					{
						Debug.Log(string.Format("SU AUDIT - ItemsCopy[ {0} ] is null.", i));
					}
				}
			}
			else
			{
				Debug.Log("SU AUDIT - ItemsCopy.Count == 0.  There are no upgrades.");
			}
		}
		else
		{
			Debug.Log("SU AUDIT - ItemsCopy == null.  There are no upgrades.");
		}
		Debug.Log("SU AUDIT - END in GameplayManager.Awake()");
		GlobalSettings.MissionTime = 0f;
		EventManager.Initialize();
		SystemMessageManager.Initialize();
		_gameOverTimer = GAME_OVER_DELAY_TIME;
		_savedScreenShots.Clear();
		_droneManager = DroneManager.Instance;
		GlobalSettings.IsGamePaused = false;
		if (GlobalSettings.UseTransporters && !TransporterShipUpgradeActive())
		{
			BaseShipUpgrade item = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.Transporter);
			GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(item);
		}
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			int seed = (int)DateTime.Now.Ticks;
			if (SeedDailyShipUpgrades != -1)
			{
				seed = SeedDailyShipUpgrades;
			}
			System.Random random = new System.Random(seed);
			int num = random.Next(0, 3);
			if (num > 0)
			{
				int num2 = -1;
				for (int j = 0; j < num; j++)
				{
					int num3 = 0;
					int num4 = -1;
					bool flag = j == 1 || num == 1;
					do
					{
						num4 = random.Next(1, 12);
						num3++;
					}
					while ((num4 == 10 || num4 == 6 || num4 == 5 || num4 == num2 || (!flag && num4 >= 7 && num4 <= 11)) && num3 < 100);
					if (num3 < 100)
					{
						num2 = num4;
						BaseShipUpgrade item2 = ShipUpgradeFactory.CreateUpgrade((ShipUpgradeType)num2);
						GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(item2);
					}
				}
			}
		}
		GlobalSettings.CrippledCommandList = null;
		GameAudio.Initialize();
		SVInfoUI.gameObject.SetActive(false);
		GlobalSettings.EnableShiftButtonForChangeView = GameSaveFile.Get("INSHIFTVIEW", false);
		videoSignalMissingObject.SetActive(false);
		DungeonPowerInlet.hasTestedDestroyedAIState = false;
	}

	private void Start()
	{
		SystemMessageManager.Instance.LoadResources();
		GameFileHelper.EnsureGameFileDirectoriesExist();
		_consoleWindow = ConsoleUiObject.GetComponent<ConsoleWindow3>();
		if (DroneSwapUi != null)
		{
			_droneSwapUi = DroneSwapUi.GetComponent<DroneSwapUi2>();
		}
		if (_droneSwapUi != null)
		{
			_droneSwapUi.IsVisible = false;
		}
		if (ScreenDimUIObject != null)
		{
			ScreenDimUIObject.SetActive(true);
			screenDimUIImage = ScreenDimUIObject.GetComponent<Image>();
		}
		_helpManualWindow = new HelpManual();
		_droneManager.ShowDroneWindow = true;
		if (SchematicViewCanvasObject != null)
		{
			_schemViewCanvas = SchematicViewCanvasObject.GetComponent<SchematicViewCanvas>();
			_schemViewCanvas.IsVisible = false;
		}
		DroneUpgradeFactory.Initialize();
		if (GlobalSettings.cheatMode)
		{
			InitCheatModeUI();
		}
		_dungeonManager = DungeonManager.Instance;
		_consoleWindow.AddCommandableObject(_droneManager);
		if (!GlobalSettings.UseCommandTree)
		{
			_consoleWindow.AddCommandableObject(_dungeonManager);
		}
		if (!GlobalSettings.IsTutorial)
		{
			ConsoleWindow3.SendConsoleResponse("Type 'help' to open salvage operations manual", ConsoleMessageType.SpecialInfo);
			ConsoleWindow3.SendConsoleResponse("Type 'help <command>' for more detailed help", ConsoleMessageType.SpecialInfo);
			ConsoleWindow3.SendConsoleResponse("Use Ctrl + arrow keys for history & cursor movement", ConsoleMessageType.SpecialInfo);
			ConsoleWindow3.SendConsoleResponse("Use F8 to toggle the size of the console", ConsoleMessageType.SpecialInfo);
			ConsoleWindow3.SendConsoleResponse("Use Ctrl +/- to adjust console font size", ConsoleMessageType.SpecialInfo);
		}
		DroneManager droneManager = _droneManager;
		droneManager.OnSelectedDrone = (DroneSelectedDelegate)Delegate.Combine(droneManager.OnSelectedDrone, new DroneSelectedDelegate(OnDroneSelected));
		OnDroneSelected(1);
		SyncCheatModeUI();
		gameEventManager = new GameEventManager();
		if (GameSaveFile.Get("D_RAD", true))
		{
			gameEventManager.AddEvent(new RoomDestroyEvent(SeedRadiationEvent));
		}
		gameEventManager.AddEvent(new CloseCommandEvent(SeedDoorCloseEvent));
		gameEventManager.AddEvent(new DoorFailEvent(SeedDoorFailEvent));
		gameEventManager.AddEvent(new AirlockSealFailEvent(SeedAirlookFailEvent));
		gameEventManager.AddEvent(new AsteroidEvent(SeedAsteroidEvent));
		CommandHelper.Initialize();
		if (GlobalSettings.gameMode == GameModeEnum.Normal && GameSaveFile.Get("ALIAS_VER", 0) < 1)
		{
			CommandHelper.SyncAliasFile();
		}
		if (GlobalSettings.UseCommandTree)
		{
			_consoleWindow.RegisterCommandableObject(_dungeonManager);
			_dungeonManager.RegisterCommands();
		}
		if (GlobalSettings.GameState.ThePlayer != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					IInventoryItem inventoryItem = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[i];
					if (inventoryItem != null)
					{
						_consoleWindow.AddCommandableObject((BaseShipUpgrade)inventoryItem);
						((BaseShipUpgrade)inventoryItem).Initialize();
					}
				}
			}
		}
		if (GlobalSettings.UseCombinedTerminal)
		{
			if (_dungeonManager.terminalManager != null)
			{
				_consoleWindow.AddCommandableObject(_dungeonManager.terminalManager);
			}
			else
			{
				Debug.LogError("Terminal manager is unexpectedly null!");
			}
		}
		if (_dungeonManager.BoardingVessel != null)
		{
			_consoleWindow.AddCommandableObject(_dungeonManager.BoardingVessel);
		}
		_blankScreenObject = UnityEngine.Object.Instantiate(ResourceManager.BlankScreenPrefab);
		_blankScreenObject.GetComponent<Renderer>().enabled = false;
		if (SteamCore.Instance != null)
		{
			SteamCore instance = SteamCore.Instance;
			instance.overlayToggled = (SteamCore.ScreenShownToggle)Delegate.Combine(instance.overlayToggled, new SteamCore.ScreenShownToggle(SteamOverlayToggle));
		}
	}

	private void OnDestroy()
	{
	}

	public void InitCheatModeUI()
	{
		if (GameplayManagerGUI.Instance._inventoryWindow == null)
		{
			GameplayManagerGUI.Instance._droneSummaryWindowForInstall = new DroneSummaryWindow(false);
			GameplayManagerGUI.Instance._droneSummaryWindowForInstall.OnDroneSelected += OnDroneWindowSelectedForInstall;
			Inventory inventory = ((GlobalSettings.GameState.ThePlayer == null) ? new Inventory(100, "GMM_TEMP", false) : GlobalSettings.GameState.ThePlayer.Inventory);
			GameplayManagerGUI.Instance._inventoryWindow = new InventoryWindow(inventory);
			GameplayManagerGUI.Instance._inventoryWindow.AllowDragDrop = false;
			GameplayManagerGUI.Instance._inventoryWindow.InstallInventoryItem += OnInventoryItemToBeInstalled;
			GameplayManagerGUI.Instance._storeWindow = new StoreWindow();
			GameplayManagerGUI.Instance._droneInstallUpgradesWindow = new DroneInstallUpgradesWindow();
			DroneInstallUpgradesWindow droneInstallUpgradesWindow = GameplayManagerGUI.Instance._droneInstallUpgradesWindow;
			droneInstallUpgradesWindow.OnSelectedDrone = (DroneSelectedDelegate)Delegate.Combine(droneInstallUpgradesWindow.OnSelectedDrone, new DroneSelectedDelegate(GameplayManagerGUI.Instance._droneSummaryWindowForInstall.SetSelectedDrone));
			_droneSummaryWindowForSchematic = new DroneSummaryWindow(true);
			_droneSummaryWindowForSchematic.OnDroneSelected += OnDroneWindowSelectedForSchematic;
			DroneManager droneManager = _droneManager;
			droneManager.OnSelectedDrone = (DroneSelectedDelegate)Delegate.Combine(droneManager.OnSelectedDrone, new DroneSelectedDelegate(_droneSummaryWindowForSchematic.SetSelectedDrone));
			_droneSummaryWindowForSchematic.SetWindowPosition(Screen.width - 425, 1f, 85f);
			_droneManager.dronesList.ForEach(delegate(Drone x)
			{
				x.OnReceivedDamage += _droneSummaryWindowForSchematic.DroneReceivedDamage;
			});
			_droneSummaryWindowForSchematic.SetSelectedDrone(1);
			GameplayManagerGUI.Instance.guiRationsNeeded = "Needed for closest: " + GlobalSettings.GameState.ThePlayer.RationsNeededForClosestUnvisitedDungeon;
		}
	}

	public void SyncCheatModeUI()
	{
		if (GameplayManagerGUI.Instance._inventoryWindow != null)
		{
			GameplayManagerGUI.Instance._inventoryWindow.TopDockingCoordinate = GameplayManagerGUI.Instance._droneSummaryWindowForInstall.BottomOfWindow;
			GameplayManagerGUI.Instance._storeWindow.TopDockingCoordinate = GameplayManagerGUI.Instance._droneSummaryWindowForInstall.BottomOfWindow;
			GameplayManagerGUI.Instance._droneInstallUpgradesWindow.TopDockingCoordinate = GameplayManagerGUI.Instance._droneSummaryWindowForInstall.BottomOfWindow;
		}
	}

	public void GenerateEnemies()
	{
		List<ShipInfestationType> list = new List<ShipInfestationType>();
		if (!GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			list.Add(ShipInfestationType.Swarm);
			if (GlobalSettings.GameStartedFromGalaxyMap)
			{
				list = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType;
			}
			if (!EnemyManager.Instance.SpawnFixedEnemies)
			{
				int seed = (int)DateTime.Now.Ticks;
				if (SeedGenerateEnemies != -1)
				{
					seed = SeedGenerateEnemies;
				}
				System.Random rnd = new System.Random(seed);
				List<Waypoint> waypoints = NavigationHelper.GetWaypoints(WaypointTypeEnum.Spawn);
				Dictionary<Waypoint, bool> waypointEnemies = new Dictionary<Waypoint, bool>();
				waypoints.ForEach(delegate(Waypoint x)
				{
					waypointEnemies.Add(x, false);
				});
				int num = DungeonManager.Instance.rooms.Length / 2;
				int num2 = num;
				if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
				{
					if (GlobalSettings.GameStartedFromGalaxyMap && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties != null)
					{
						if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.EnemyCountMax <= 0)
						{
							return;
						}
						num2 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? rnd.Next(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.EnemyCountMin, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.EnemyCountMax + 1) : UnityEngine.Random.Range(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.EnemyCountMin, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.EnemyCountMax + 1));
					}
					else
					{
						num2 = Mathf.RoundToInt((float)num * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EnemyRatioValue);
					}
					if (!GlobalSettings.IsTutorial && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType != null && num2 < GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType.Count)
					{
						num2 = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType.Count;
					}
				}
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				if (true && list != null)
				{
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					int num10 = 0;
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Swarm))
					{
						num7 = 5 / list.Count;
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Brute))
					{
						num8 = 7 / list.Count;
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Slime))
					{
						num9 = 4 / list.Count;
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.PatrolBot))
					{
						num10 = 5 / list.Count;
					}
					int num11 = num7 + num8 + num9 + num10;
					float num12 = (float)num7 / (float)num11;
					float num13 = (float)num8 / (float)num11;
					float num14 = (float)num9 / (float)num11;
					float num15 = (float)num10 / (float)num11;
					float num16 = num12 + num13 + num14 + num15;
					float key = num12 % num16;
					float num17 = num13 % num16;
					float num18 = num14 % num16;
					float num19 = num15 % num16;
					SortedList<float, int> sortedList = new SortedList<float, int>();
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Swarm))
					{
						sortedList.Add(key, 0);
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Brute))
					{
						if (sortedList.ContainsKey(num17))
						{
							num17 += 1E-05f;
						}
						sortedList.Add(num17, 1);
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.Slime))
					{
						if (sortedList.ContainsKey(num18))
						{
							num18 += 2E-05f;
						}
						sortedList.Add(num18, 2);
					}
					if (list.Any((ShipInfestationType x) => x == ShipInfestationType.PatrolBot))
					{
						if (sortedList.ContainsKey(num19))
						{
							num19 += 3E-05f;
						}
						sortedList.Add(num19, 3);
					}
					sortedList.Reverse();
					num3 = (int)((float)num2 * num12);
					num4 = (int)((float)num2 * num13);
					num5 = (int)((float)num2 * num14);
					num6 = (int)((float)num2 * num15);
					int num20 = 0;
					while (num3 + num4 + num5 + num6 < num2 && num20 < 100)
					{
						IEnumerator<KeyValuePair<float, int>> enumerator = sortedList.GetEnumerator();
						while (enumerator.MoveNext())
						{
							switch (enumerator.Current.Value)
							{
							case 0:
								num3++;
								break;
							case 1:
								num4++;
								break;
							case 2:
								num5++;
								break;
							case 3:
								num6++;
								break;
							}
							if (num3 + num4 + num5 + num6 >= num2)
							{
								break;
							}
						}
						num20++;
					}
					{
						foreach (ShipInfestationType item in list)
						{
							if (GlobalSettings.gameMode == GameModeEnum.Normal)
							{
								switch (item)
								{
								case ShipInfestationType.Swarm:
									SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num3, delegate(Waypoint w)
									{
										EnemyManager.Instance.CreateSwarm(w);
									});
									break;
								case ShipInfestationType.Brute:
									SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num4, delegate(Waypoint w)
									{
										EnemyManager.Instance.CreateBrute(w);
									});
									break;
								case ShipInfestationType.Slime:
									SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num5, delegate(Waypoint w)
									{
										EnemyManager.Instance.CreateSlime(w, true);
									});
									break;
								case ShipInfestationType.PatrolBot:
									SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num6, delegate(Waypoint w)
									{
										EnemyManager.Instance.CreatePatrolBot(w);
									});
									break;
								}
								continue;
							}
							switch (item)
							{
							case ShipInfestationType.Swarm:
								SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num3, delegate(Waypoint w)
								{
									EnemyManager.Instance.CreateSwarm(w);
								}, rnd);
								break;
							case ShipInfestationType.Brute:
								SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num4, delegate(Waypoint w)
								{
									EnemyManager.Instance.CreateBrute(w);
								}, rnd);
								break;
							case ShipInfestationType.Slime:
								SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num5, delegate(Waypoint w)
								{
									EnemyManager.Instance.CreateSlime(w, true, rnd);
								}, rnd);
								break;
							case ShipInfestationType.PatrolBot:
								SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, num6, delegate(Waypoint w)
								{
									EnemyManager.Instance.CreatePatrolBot(w);
								}, rnd);
								break;
							}
						}
						return;
					}
				}
				if (list == null)
				{
					int num21 = 0;
					num21++;
				}
				return;
			}
			Debug.Log("Spawning fixed enemies");
			Waypoint spawnPoint = NavigationHelper.GetWaypoints(WaypointTypeEnum.SpawnFixedFar).FirstOrDefault();
			EnemyManager.Instance.CreateSwarm(spawnPoint);
			Waypoint spawnPoint2 = NavigationHelper.GetWaypoints(WaypointTypeEnum.SpawnFixedClose).FirstOrDefault();
			EnemyManager.Instance.CreateSwarm(spawnPoint2);
			{
				foreach (Waypoint waypoint2 in NavigationHelper.GetWaypoints(WaypointTypeEnum.Spawn))
				{
					EnemyManager.Instance.CreateSwarm(waypoint2);
				}
				return;
			}
		}
		foreach (Room builtRoom in DungeonBuilder.Instance.builtRooms)
		{
			string metaData = builtRoom.GetMetaData("enemy");
			if (!(metaData != string.Empty) || !(metaData != "0"))
			{
				continue;
			}
			Waypoint waypoint = builtRoom.Waypoints.FirstOrDefault((Waypoint x) => x != null && x.WaypointType == WaypointTypeEnum.Spawn);
			if (waypoint != null)
			{
				switch (metaData)
				{
				case "1":
					EnemyManager.Instance.CreatePatrolBot(waypoint);
					break;
				case "2":
					EnemyManager.Instance.CreateSwarm(waypoint);
					break;
				case "3":
					EnemyManager.Instance.CreateBrute(waypoint);
					break;
				case "4":
					EnemyManager.Instance.CreateSlime(waypoint);
					break;
				}
			}
			else
			{
				int num22 = 0;
				num22++;
			}
		}
	}

	public void StartMission()
	{
		GlobalSettings.MissionStarted = true;
		int num = UniverseSaveFile.Get("DBF_HOME", 0);
		if (num > 0)
		{
			GlobalSettings.OwnsDronesBestFriend = true;
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict && GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Transporter && !((BaseShipUpgrade)x).IsBroken) && !GameSaveFile.Get("HNT_SU_TPT", false) && !GameSaveFile.Get("HNT_TRANSPOST", false))
		{
			List<Room> list = new List<Room>();
			int num2 = DungeonManager.Instance.rooms.Length;
			for (int num3 = 0; num3 < num2; num3++)
			{
				Room room = DungeonManager.Instance.rooms[num3];
				RoomItem roomItem = room.GetRoomItem(typeof(TransporterReceiver), true);
				if (roomItem != null && ((TransporterReceiver)roomItem).IsResponding && room.onSchematic)
				{
					list.Add(room);
				}
			}
			if (list.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, list.Count);
				HintManager.PushHint(new TransportSUHint(DroneManager.Instance.CurrentDrone.DroneNumber, list[index].Label));
			}
		}
		if (GlobalSettings.OwnsDronesBestFriend)
		{
			int num4 = _random.Next(1, 101);
			if (num4 <= 30)
			{
				_dungeonManager.PlayDbfWhine();
			}
		}
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			SteamLeaderboard.PostChallengeScore(GlobalSettings.gameMode, 0, SteamLeaderboard.ScoreStatusEnum.Partial);
		}
	}

	private void SpawnEnemiesOnFreeWaypointsRandom(Dictionary<Waypoint, bool> waypointEnemies, int numberOfEnemies, Action<Waypoint> spawnAction)
	{
		SpawnEnemiesOnFreeWaypointsRandom(waypointEnemies, numberOfEnemies, spawnAction, _random);
	}

	private void SpawnEnemiesOnFreeWaypointsRandom(Dictionary<Waypoint, bool> waypointEnemies, int numberOfEnemies, Action<Waypoint> spawnAction, System.Random rnd)
	{
		for (int i = 0; i < numberOfEnemies; i++)
		{
			int num = waypointEnemies.Where((KeyValuePair<Waypoint, bool> x) => !x.Value).Count();
			if (num == 0)
			{
				break;
			}
			int num2 = rnd.Next(0, num);
			int num3 = 0;
			foreach (KeyValuePair<Waypoint, bool> waypointEnemy in waypointEnemies)
			{
				Waypoint key = waypointEnemy.Key;
				if (!waypointEnemy.Value && num3++ == num2)
				{
					waypointEnemies[key] = true;
					spawnAction(key);
					break;
				}
			}
		}
	}

	private void Update()
	{
		if (_firstUpdate)
		{
			_firstUpdate = false;
			_schemViewCanvas.SetData();
		}
		if (autoFullScreen)
		{
			timerTillFullScreen -= Time.deltaTime;
			if (timerTillFullScreen <= 0f)
			{
				autoFullScreen = false;
				Screen.fullScreen = true;
			}
		}
		EventManager.Instance.Update();
		if (_consoleWindow != null)
		{
			if (GlobalSettings.ShowingGameOverlayWindow || _windowState == GameWindowStates.ShowShipSwap)
			{
				if (_consoleWindow.IsVisible)
				{
					_consoleWindow.IsVisible = false;
				}
			}
			else if (!_consoleWindow.IsVisible && !_userHideConsole && !GlobalSettings.GameIsOver && !isShowingDroneSwapUI && _windowState != GameWindowStates.ShowHelpManual && !AliasUI.Instance.IsShowing && !DungeonManager.Instance.isShowingAlias)
			{
				_consoleWindow.IsVisible = true;
			}
		}
		if (!DialogUI.Instance.IsShowing && !GlobalSettings.IsGamePaused && !AliasUI.Instance.IsShowing)
		{
			if (_consoleWindow != null && _consoleWindow.IsDisabled && !DungeonManager.Instance.ignoreAllInputForAMoment)
			{
				_consoleWindow.IsDisabled = false;
			}
			if ((_windowState == GameWindowStates.None || _windowState == GameWindowStates.ShowUpgradeSwap) && GlobalSettings.cameraMode == CameraMode.Schematic && (!GlobalSettings.GameIsOver || LogUI.Instance.Tag != 3))
			{
				if (!_schemViewCanvas.IsVisible && !isHidingCanvases)
				{
					_schemViewCanvas.IsVisible = true;
				}
			}
			else if (_schemViewCanvas.IsVisible)
			{
				_schemViewCanvas.IsVisible = false;
			}
			if (!GlobalSettings.IsGamePaused && _windowState != GameWindowStates.ShowShipSwap && _windowState != GameWindowStates.ShowHelpManual)
			{
				if (GlobalSettings.cheatMode)
				{
					GameplayManagerGUI.Instance._droneSummaryWindowForInstall.Update();
					_droneSummaryWindowForSchematic.Update();
				}
				bool flag = false;
				bool flag2 = false;
				if (!GlobalSettings.GameIsOver)
				{
					if (GlobalSettings.MissionStarted)
					{
						GlobalSettings.MissionTime += Time.deltaTime;
					}
					bool flag3 = false;
					int count = _droneManager.dronesList.Count;
					for (int i = 0; i < count; i++)
					{
						Drone drone = _droneManager.dronesList[i];
						if (!drone.IsDead || (drone.CurrentRoom == DungeonManager.Instance.BoardingVessel && (drone.CanBeTowed || drone.IsBeingTowed)))
						{
							flag3 = true;
							break;
						}
					}
					bool flag4 = false;
					if (!flag3 && GlobalSettings.GameState.ThePlayer != null)
					{
						flag4 = GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => !x.IsDead && x.DroneNumber > 4);
					}
					if (!flag3 && !flag4)
					{
						int count2 = _droneManager.LootableDronesList.Count;
						for (int num = 0; num < count2; num++)
						{
							Drone drone2 = _droneManager.LootableDronesList[num];
							if (drone2.CurrentRoom.boardingVessel)
							{
								flag3 = true;
								break;
							}
						}
					}
					if (!flag3 && !flag4)
					{
						if (!startedGamedOverTimer)
						{
							if (!GlobalSettings.IsTutorial && GlobalSettings.gameMode == GameModeEnum.Normal)
							{
								if (GameSaveFile.Get("D_SFTRST", false))
								{
									GlobalSettings.IsGamePaused = true;
									DialogUI.Instance.ShowDialog("Soft Reset", "Initiate Soft Reset to avoid game over?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
									{
										if (result == ModalWindowResult.Yes)
										{
											PauseMenuSoftReset();
										}
										else
										{
											GlobalSettings.IsGamePaused = false;
											startedGamedOverTimer = true;
											InitiateGameOver();
										}
									}, 1);
								}
								else
								{
									InitiateGameOver();
								}
							}
							else
							{
								InitiateGameOver();
							}
						}
						else
						{
							InitiateGameOver();
						}
					}
					if (GlobalSettings.GameState.ThePlayer != null)
					{
						List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
						int count3 = itemsCopy.Count;
						for (int num2 = 0; num2 < count3; num2++)
						{
							((BaseShipUpgrade)itemsCopy[num2]).Update();
						}
					}
					if (_droneManager.CurrentDrone != null)
					{
						flag = _droneManager.CurrentDrone.VideoSignalLost;
						if (!flag)
						{
							flag = DroneManager.Instance.CurrentDrone.IsDead && !DroneManager.Instance.CurrentDrone.CanBeFullyRepaired;
						}
						if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.MyShip != null)
						{
							flag2 = GlobalSettings.GameState.ThePlayer.MyShip.VideoSignalLost;
						}
						if (GameplayManagerGUI.Instance._blankedOutScreen)
						{
							if (GlobalSettings.cameraMode == CameraMode.Drone)
							{
								if (!flag)
								{
									RestoreVideo();
								}
							}
							else if (!flag2)
							{
								RestoreVideo();
							}
						}
						else if (GlobalSettings.cameraMode == CameraMode.Drone)
						{
							if (flag)
							{
								CutOutVideo();
							}
						}
						else if (flag2)
						{
							CutOutVideo();
						}
					}
					else if (_droneManager.isInLostVideoState)
					{
						if (GlobalSettings.cameraMode == CameraMode.Drone)
						{
							CutOutVideo();
						}
						else
						{
							RestoreVideo();
						}
					}
				}
				else if (_gameOverTimerBeforeWindow > 0f)
				{
					_gameOverTimerBeforeWindow -= Time.deltaTime;
					if (_gameOverTimerBeforeWindow <= 0f)
					{
						GlobalSettings.ShowingGameOverlayWindow = true;
						if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
						{
							DialogUI.Instance.ShowDialog("Daily Challenge Lost", "You have died!  A score of 0 has been posted to the Steam leaderboards", ModalWindowType.OK, delegate
							{
								ShowPauseMenuPostDeath(true);
							});
						}
						else if (GlobalSettings.gameMode == GameModeEnum.WeeklyChallenge)
						{
							DialogUI.Instance.ShowDialog("Weekly Challenge Lost", "You have died!  A score of 0 has been posted to the Steam leaderboards", ModalWindowType.OK, delegate
							{
								ShowPauseMenuPostDeath(true);
							});
						}
						else
						{
							GameplayManagerGUI.Instance._gameOverWindow.ShowWindow();
							MainMenu.ArchiveRunStats();
						}
					}
				}
				bool flag5 = false;
				flag5 = ((!GlobalSettings.EnableShiftButtonForChangeView) ? (!CommandBeingTyped && (Input.GetKeyDown(KeyCode.BackQuote) || Input.GetKeyDown(KeyCode.Space))) : ((!GlobalSettings.cheatMode && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))) || (!CommandBeingTyped && (Input.GetKeyDown(KeyCode.BackQuote) || Input.GetKeyDown(KeyCode.Space)))));
				bool flag6 = _consoleWindow.NotProcessingSpace && Input.GetKeyDown(KeyCode.Space);
				if ((flag5 || flag6) && !GlobalSettings.CommandeeringShip && !GlobalSettings.GameIsOver && !DungeonManager.Instance.IsExiting)
				{
					if ((GlobalSettings.cameraMode == CameraMode.Drone && flag2) || (GlobalSettings.cameraMode == CameraMode.Schematic && flag))
					{
						CutOutVideo();
					}
					_droneManager.switchCameraView();
					if (!HintManager.HintCompleted(typeof(SpaceToChangeViewHint)))
					{
						SpaceToChangeViewHint.MarkCompleted();
					}
				}
				if (!hasTestedMouseDownWarning && Input.GetMouseButtonDown(0))
				{
					if (!GameSaveFile.Get("WS_NOMOUSE_REQ", false))
					{
						GameSaveFile.Save("WS_NOMOUSE_REQ", true);
					}
					hasTestedMouseDownWarning = true;
				}
				if (GlobalSettings.cameraMode == CameraMode.Schematic && Input.GetButtonUp("Quote"))
				{
					AttemptToggleIcons();
				}
				if (!GlobalSettings.ShowingGameOverlayWindow && Input.GetKeyDown(KeyCode.F7))
				{
					_userHideConsole = !_userHideConsole;
					_consoleWindow.IsVisible = !_userHideConsole;
				}
				if (Input.GetButtonDown("Screen Capture"))
				{
					string text = GameFileHelper.GenerateUniqueScreenshotFilename();
					Application.CaptureScreenshot(text);
					_savedScreenShots.Add(text);
					_screenshotReportTimer = 1f;
				}
				if (_savedScreenShots.Count > 0)
				{
					_screenshotReportTimer -= Time.deltaTime;
					if (_screenshotReportTimer <= 0f)
					{
						foreach (string savedScreenShot in _savedScreenShots)
						{
							_dungeonManager.SendConsoleMessage("Saved screenshot: " + savedScreenShot, ConsoleMessageType.Info);
						}
						_savedScreenShots.Clear();
					}
				}
				if (GlobalSettings.cheatMode)
				{
					if (Input.GetKeyDown(KeyCode.Z) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
					{
						GlobalSettings.SafeTutorialMode = !GlobalSettings.SafeTutorialMode;
						string message = string.Format("Safe mode: {0}", (!GlobalSettings.SafeTutorialMode) ? "Off" : "On");
						SystemMessageManager.ShowSystemMessage(message, ConsoleMessageType.Info);
					}
					if (Input.GetKeyDown(KeyCode.I) && CommonMethods.ControlKeyIsBeingPressed())
					{
						GameplayManagerGUI.Instance.ToggleItemInstallMode();
					}
					else if (Input.GetKeyDown(KeyCode.U) && CommonMethods.ControlKeyIsBeingPressed())
					{
						GameplayManagerGUI.Instance.ToggleStoreMode();
					}
					if (Input.GetKeyDown(KeyCode.E) && CommonMethods.ControlKeyIsBeingPressed())
					{
						EnemyManager.Instance.ShowEnemyDebugWindow = !EnemyManager.Instance.ShowEnemyDebugWindow;
					}
					if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
					{
						if (Input.GetButtonDown("Right"))
						{
							_droneManager.ChooseNextPreset();
							PresetManager.TakeSnapshot(_droneManager.IDronesList);
						}
						else if (Input.GetButtonDown("Left"))
						{
							_droneManager.ChoosePrevPreset();
							PresetManager.TakeSnapshot(_droneManager.IDronesList);
						}
						if (Input.GetKeyDown(KeyCode.U))
						{
							_droneManager.RandomlyChooseUpgrades();
							PresetManager.TakeSnapshot(_droneManager.IDronesList);
						}
						else if (Input.GetKeyDown(KeyCode.R))
						{
							_droneManager.RandomizeFleetUpgrades(2);
							PresetManager.TakeSnapshot(_droneManager.IDronesList);
						}
					}
				}
				SystemMessageManager.Instance.Update();
				gameEventManager.Update();
			}
			bool flag7 = !CommandBeingTyped && Input.GetKeyDown(KeyCode.Escape);
			bool flag8 = GlobalSettings.GameIsOver && LogUI.Instance.Tag == 3 && Input.GetKeyDown(KeyCode.Space);
			if (flag7 || flag8)
			{
				if (_windowState != GameWindowStates.ShowHelpManual)
				{
					Input.ResetInputAxes();
				}
				if (_windowState == GameWindowStates.None)
				{
					ShowPauseMenuPostDeath(false);
				}
				else if (_windowState == GameWindowStates.ShowUpgradeSwap)
				{
					_droneManager.HideUpgradeSwapUI();
				}
				else if (_windowState == GameWindowStates.ShowShipSwap)
				{
					_windowState = GameWindowStates.None;
					CommandeerUI.Instance.Hide();
					ConsoleWindow3.SendConsoleResponse("Commandeering canceled", ConsoleMessageType.Info);
				}
				else if (_windowState != GameWindowStates.ShowHelpManual)
				{
					PauseMessageCancelPressed();
				}
			}
			if (GlobalSettings.cheatMode)
			{
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int count4 = _droneManager.dronesList.Count;
				for (int num6 = 0; num6 < count4; num6++)
				{
					Drone drone3 = _droneManager.dronesList[num6];
					num3 += ((!drone3.IsDead) ? drone3.GetLootCount() : 0);
					num4 += ((!drone3.IsDead) ? drone3.GetPropulsionFuelCount() : 0);
					num5 += ((!drone3.IsDead) ? drone3.GetJumpFuelCount() : 0);
				}
				if (guiLastKnownRations != num3)
				{
					GameplayManagerGUI.Instance.guiRationsCollected = "Scrap - collected / on mother ship: " + num3 + " / " + GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
				}
				if (guiLastKnownPFuelCollected != num4)
				{
					GameplayManagerGUI.Instance.guiPropulsionFuelCollected = "Propulsion Fuel - collected / on mother ship: " + num4 + " / " + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelCharge + " (+" + GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve + ")";
				}
				if (guiLastKnownJFuelCollected != num5)
				{
					GameplayManagerGUI.Instance.guiJumpFuelCollected = "Jump Fuel - collected / on mother ship: " + num5 + " / " + GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel;
				}
				int num7 = (int)GlobalSettings.MissionTime % 60;
				int num8 = (int)GlobalSettings.MissionTime / 60;
				int num9 = num8 / 60;
				num8 %= 60;
				if (GlobalSettings.MissionStarted)
				{
					GameplayManagerGUI.Instance.guiMissionHours = num9.ToString("00");
					GameplayManagerGUI.Instance.guiMissionMinutes = num8.ToString("00");
					GameplayManagerGUI.Instance.guiMissionSeconds = num7.ToString("00");
				}
			}
		}
		else if (DialogUI.Instance.IsShowing && (pauseMenu == null || !pauseMenu.IsLoaded))
		{
			if (DialogUI.Instance.TestKeyInput())
			{
				Input.ResetInputAxes();
			}
			else if (!_consoleWindow.IsDisabled)
			{
				_consoleWindow.IsDisabled = true;
			}
		}
		else
		{
			_consoleWindow.IsDisabled = true;
		}
	}

	private void InitiateGameOver()
	{
		_gameOverTimer -= Time.deltaTime;
		if (!(_gameOverTimer <= 0f))
		{
			return;
		}
		GlobalSettings.GameIsOver = true;
		if (GlobalSettings.OwnsDronesBestFriend)
		{
			int num = _random.Next(1, 101);
			if (num <= 75)
			{
				_dungeonManager.PlayDbfWhine();
			}
		}
		int value = GameSaveFile.Get("ST_TTL_PLAYER_DEATH", 0) + 1;
		GameSaveFile.Save("ST_TTL_PLAYER_DEATH", value);
		value = GameSaveFile.Get("ST_CUR_DRN_DEAD", 0) + DroneManager.Instance.dronesList.Count;
		GameSaveFile.Save("ST_CUR_DRN_DEAD", value);
		GameSaveFile.Save("ST_TTL_DRN_DEAD", GameSaveFile.Get("ST_TTL_DRN_DEAD", 0) + DroneManager.Instance.dronesList.Count);
		if (value > GameSaveFile.Get("ST_BST_DRN_DEAD", 0))
		{
			GameSaveFile.Save("ST_BST_DRN_DEAD", value);
		}
		GameplayManagerGUI.Instance.Enable();
		if (!GlobalSettings.IsTutorial)
		{
			if (!GameSaveFile.Get("NC", false))
			{
				GalaxyProcessor.RevertNurseryFromCopy();
			}
			GameSaveFile.Save("DIED", true);
			if (GlobalSettings.gameMode != GameModeEnum.Normal)
			{
				SteamLeaderboard.PostChallengeScore(GlobalSettings.gameMode, 0, SteamLeaderboard.ScoreStatusEnum.Final);
			}
			HintManager.FlushHints();
		}
		GameplayManagerGUI.Instance._gameOverWindow = new GameOverWindow();
		ConsoleWindow3.SendConsoleResponse(string.Format("You lived for {0} days.", GameSaveFile.Get("ST_CUR_DAYS", 0)), ConsoleMessageType.Info);
		SystemMessageManager.ShowSystemMessage("All Drones Destroyed.  Hit ESC to restart...", ConsoleMessageType.Info);
		_dungeonManager.RevealEverything();
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			_droneManager.switchCameraView();
		}
		if (!GlobalSettings.IsTutorial)
		{
			_gameOverTimerBeforeWindow = 3f;
		}
	}

	public void ShowPauseMenuPostDeath(bool excludeCancelOnPauseMenu)
	{
		if (PauseMenu.Instance == null)
		{
			if (GlobalSettings.GameIsOver)
			{
				GlobalSettings.ShowingGameOverlayWindow = false;
				showingPauseMenuAfterDeath = true;
				MainMenu.PlayerReset();
			}
			_windowState = GameWindowStates.Message;
			GlobalSettings.IsGamePaused = true;
			DungeonManager.Instance.PauseSoundsOnMenuOpen();
			DroneManager.Instance.PauseSoundsOnMenuOpen();
			pauseMenu = new PauseMenu(false, excludeCancelOnPauseMenu);
			pauseMenu.cancelSelected = PauseMenuCanceled;
			pauseMenu.restartVerify = PauseMenuResetVerify;
			pauseMenu.restartSelected = PauseMenuReset;
			pauseMenu.restartSoftVerify = PauseMenuSoftResetVerify;
			pauseMenu.softResetSelected = PauseMenuSoftReset;
			pauseMenu.fullRestartSelected = PauseMenuFullReset;
			pauseMenu.mainMenuVerify = PauseMainMenuVerifyPressed;
			pauseMenu.mainMenuSelected = PauseMessageMainMenuPressed;
			pauseMenu.exitVerify = PauseMenuVerifySavePressed;
			pauseMenu.exitSelected = PauseMessageMainMenuPressed;
		}
	}

	public void CloseHelpWindow()
	{
		_windowState = GameWindowStates.None;
		_helpManualWindow.IsVisible = false;
		_consoleWindow.IsVisible = true;
		DungeonManager.Instance.DisableAllInputForAMoment();
	}

	public void AttemptToggleIcons()
	{
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			return;
		}
		_showSchematicToggleItems = !_showSchematicToggleItems;
		foreach (IToggleVisibilityInSchematic allToggleItem in GetAllToggleItems())
		{
			allToggleItem.SetSchematicVisibility(_showSchematicToggleItems);
		}
		if (!_showSchematicToggleItems)
		{
			SVInfoUI.ShowIconOff();
			if (GlobalSettings.IsTutorial && !GameSaveFile.Get("WS_TUT_SQ", false))
			{
				GlobalSettings.IsGamePaused = true;
				DialogUI.Instance.ShowDialog("Tip!", "Hitting the Single-Quote key hides the overlays in this view to make the rooms easier to see.\r\n\r\nPressing the Single-Quote again (after closing this message) will bring the icons back.", ModalWindowType.OK, delegate
				{
					GlobalSettings.IsGamePaused = false;
				});
				GameSaveFile.Save("WS_TUT_SQ", true);
			}
		}
		else
		{
			SVInfoUI.HideIconOff();
		}
	}

	private List<IToggleVisibilityInSchematic> GetAllToggleItems()
	{
		List<IToggleVisibilityInSchematic> list = new List<IToggleVisibilityInSchematic>();
		GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject gameObject in array)
		{
			MonoBehaviour monoBehaviour = gameObject.GetComponents<MonoBehaviour>().FirstOrDefault((MonoBehaviour x) => x is IToggleVisibilityInSchematic);
			if (monoBehaviour != null)
			{
				list.Add((IToggleVisibilityInSchematic)monoBehaviour);
			}
		}
		return list;
	}

	private void PauseMenuCanceled()
	{
		_windowState = GameWindowStates.None;
		_consoleWindow.IsDisabled = false;
		Input.ResetInputAxes();
		if (showingPauseMenuAfterDeath)
		{
			ResetGameState();
			Application.LoadLevel("MenuScene");
		}
		else
		{
			DungeonManager.Instance.ResumeSoundsOnMenuClose();
			DroneManager.Instance.ResumeSoundsOnMenuClose();
			DroneManager.Instance.EnablePixelRender();
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
		if (!GlobalSettings.IsTutorial && !GlobalSettings.GameIsOver)
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
		return true;
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
		PauseMessageResetPressed(false);
		MainMenu.PlayerReset();
	}

	private void PauseMenuFullReset()
	{
		PauseMessageResetPressed(false);
		FullReset();
	}

	private void FullReset()
	{
		MainMenu.PlayerReset();
		GalaxyReset();
		UniverseMapManager.Instance.UniverseReset();
	}

	private bool PauseMenuSoftResetVerify()
	{
		if (!GlobalSettings.IsTutorial && !GlobalSettings.GameIsOver)
		{
			DialogUI.Instance.ShowDialog("Are you sure?", "Initiate soft reset?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Yes)
				{
					ConfirmSoftResetResult(result, string.Empty);
				}
			}, 1);
			return false;
		}
		return true;
	}

	private void ConfirmSoftResetResult(ModalWindowResult result, string input)
	{
		if (result == ModalWindowResult.Yes)
		{
			GlobalSettings.IsGamePaused = false;
			PauseMenuSoftReset();
		}
		else
		{
			Input.ResetInputAxes();
		}
	}

	private void PauseMenuSoftReset()
	{
		ReleaseSteam();
		if (!GlobalSettings.IsTutorial)
		{
			GameSaveFile.Save("PLAYS", GameSaveFile.Get("PLAYS", 0) + 1);
			UniverseSaveFile.Save("UNIVERSE_PLAYS", UniverseSaveFile.Get("UNIVERSE_PLAYS", 0) + 1);
			if (GameSaveFile.Get("VIEWED_TUT", false))
			{
				GameSaveFile.Save("PLAYS_SINCE_TUT", GameSaveFile.Get("PLAYS_SINCE_TUT", 0) + 1);
			}
		}
		GlobalSettings.IsTutorial = false;
		GlobalSettings.RetrySameInitialState = false;
		int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
		GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		_windowState = GameWindowStates.None;
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
		bool gameStartedFromGalaxyMap = GlobalSettings.GameStartedFromGalaxyMap;
		_gameOverTimer = GAME_OVER_DELAY_TIME;
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.CleanUpBeforeClose();
		}
		ResetPerDungeonState();
		Application.LoadLevel("GalaxyMapScene");
	}

	private void GalaxyReset()
	{
		StarField.ClearOnReset();
		int value = GalaxySaveFile.Get<int>("GALAXY_SEED");
		GalaxySaveFile.EraseFile();
		GalaxySaveFile.Save("GALAXY_SEED", value);
		GalaxyProcessor.LoadUnlockedInfestationTypeList();
	}

	public void PauseMessageResetPressed(bool sameInitialState)
	{
		ReleaseSteam();
		GlobalSettings.RetrySameInitialState = sameInitialState;
		int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
		GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		_windowState = GameWindowStates.None;
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
		bool gameStartedFromGalaxyMap = GlobalSettings.GameStartedFromGalaxyMap;
		ResetGameState();
		_gameOverTimer = GAME_OVER_DELAY_TIME;
		if (gameStartedFromGalaxyMap)
		{
			ResetGameState();
			Application.LoadLevel("GalaxyMapScene");
		}
		else
		{
			GlobalSettings.GameState = null;
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void ReleaseSteam()
	{
		try
		{
			SteamCore instance = SteamCore.Instance;
			instance.overlayToggled = (SteamCore.ScreenShownToggle)Delegate.Remove(instance.overlayToggled, new SteamCore.ScreenShownToggle(SteamOverlayToggle));
		}
		catch (Exception)
		{
		}
	}

	private void ConfirmCantSave(ModalWindowResult result, string input)
	{
	}

	private bool PauseMainMenuVerifyPressed()
	{
		if (!GlobalSettings.IsTutorial && !GlobalSettings.GameIsOver)
		{
			pauseMenu.ExternalClose();
			if (GlobalSettings.gameMode != GameModeEnum.DailyChallenge || !GlobalSettings.MissionStarted)
			{
				DialogUI.Instance.ShowDialog("Are you sure?", "If you return to the main menu, progress before this ship will be saved, but you will no longer be able to return to this ship at a later point.\r\n\r\nAre you sure you want to leave and go to the main menu?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.Yes)
					{
						PauseMessageMainMenuPressed();
					}
				}, 1);
			}
			else
			{
				DialogUI.Instance.ShowDialog("Daily Challenge Warning", "Because you have started the Daily Challenge, if you return to the main menu then a score of 0 will be submitted for today.\r\n\r\nAre you sure you want to leave and go to the main menu?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.Yes)
					{
						PauseMessageMainMenuPressed();
					}
				}, 1);
			}
			return false;
		}
		return true;
	}

	private bool PauseMenuVerifySavePressed()
	{
		if (!GlobalSettings.IsTutorial)
		{
			pauseMenu.ExternalClose();
			DialogUI.Instance.ShowDialog("Are you sure?", "If you exit the game, progress before this ship will be saved, but you will not be able to revisit this ship at a later point.\r\n\r\nAre you sure you want to exit?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Yes)
				{
					PauseMessageMainMenuPressed();
					GlobalSettings.IsGamePaused = false;
					GlobalSettings.IsExitingApplication = true;
					Application.Quit();
					GalaxyMapManager.hasBoardedDungeon = false;
					UnityEngine.Object.Destroy(this);
				}
			}, 1);
			return false;
		}
		return true;
	}

	private void PauseMessageMainMenuPressed()
	{
		if (GlobalSettings.MissionStarted && GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			SteamLeaderboard.PostChallengeScore(GlobalSettings.gameMode, 0, SteamLeaderboard.ScoreStatusEnum.Final);
		}
		if (GlobalSettings.GameState.ThePlayer != null)
		{
			int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
			GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		}
		DialogUI.Instance.CloseDialog();
		GalaxyMapManager.hasBoardedDungeon = false;
		GotoMainMenu();
	}

	public void GotoMainMenu()
	{
		ReleaseSteam();
		if (!GlobalSettings.IsTutorial)
		{
			GameSaveFile.Save("PLAYS", GameSaveFile.Get("PLAYS", 0) + 1);
			UniverseSaveFile.Save("UNIVERSE_PLAYS", UniverseSaveFile.Get("UNIVERSE_PLAYS", 0) + 1);
			if (GameSaveFile.Get("VIEWED_TUT", false))
			{
				GameSaveFile.Save("PLAYS_SINCE_TUT", GameSaveFile.Get("PLAYS_SINCE_TUT", 0) + 1);
			}
		}
		GlobalSettings.IsTutorial = false;
		GlobalSettings.RetrySameInitialState = false;
		int daysAlive = GlobalSettings.GameState.ThePlayer.DaysAlive;
		GlobalSettings.SubmitBestDaysSurvived(daysAlive);
		_windowState = GameWindowStates.None;
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
		bool gameStartedFromGalaxyMap = GlobalSettings.GameStartedFromGalaxyMap;
		_gameOverTimer = GAME_OVER_DELAY_TIME;
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.CleanUpBeforeClose();
		}
		Application.LoadLevel("MenuScene");
	}

	public static void ResetGameState()
	{
		ResetPerDungeonState();
		DroneNameGenerator.ClearUniqueDroneNameHistory();
		HelpTextManager.Reset();
		GlobalSettings.GameStateIsLoaded = false;
		ConsoleWindow3.Instance = null;
	}

	public static void ResetPerDungeonState()
	{
		if (HelpTextManager.Instance != null)
		{
			HelpTextManager.Reset();
		}
		GlobalSettings.MissionStarted = false;
		GlobalSettings.cheatMode = false;
		GlobalSettings.cameraMode = CameraMode.Drone;
		GlobalSettings.GameStartedFromGalaxyMap = false;
		GlobalSettings.GameIsOver = false;
		GlobalSettings.ShowingGameOverlayWindow = false;
		NavigationHelper.Clear();
		ShipUpgradeFactory.Reset();
		if (EventManager.Instance != null)
		{
			EventManager.Instance.ResetAll();
		}
	}

	private void PauseMessageCancelPressed()
	{
		GlobalSettings.IsGamePaused = false;
		DialogUI.Instance.CloseDialog();
		_windowState = GameWindowStates.None;
		_droneManager.ShowDroneWindow = true;
	}

	public void ReturnToHomeShip()
	{
		if (!GlobalSettings.IsTutorial)
		{
			SyncSceneDronesWithGlobalPlayerDrones();
			if (!GlobalSettings.CommandeeringShip)
			{
				TransferShipUpgradesToInventory();
				SaveMyShipPropertyChangesPostDungeon();
			}
			if (CheckForDronesBestFriendInDroneBay())
			{
				UniverseSaveFile.Save("DBF_HOME", UniverseSaveFile.Get("DBF_HOME", 0) + 1);
			}
			ResetPerDungeonState();
			Application.LoadLevel("GalaxyMapScene");
		}
		else
		{
			ResetGameState();
			GlobalSettings.IsTutorial = false;
			Application.LoadLevel("MenuScene");
		}
	}

	private void TransferShipUpgradesToInventory()
	{
		foreach (ShipUpgradeInGameObject shipUpgrade in _dungeonManager.ShipUpgrades)
		{
			BoardingShip boardingVessel = _dungeonManager.BoardingVessel;
			if (boardingVessel != null)
			{
				if (boardingVessel.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds))
				{
					GlobalSettings.GameState.ThePlayer.AddToInventory(shipUpgrade.ThisUpgrade);
				}
			}
			else
			{
				Debug.Log("droneBay == null");
			}
		}
	}

	private void SaveMyShipPropertyChangesPostDungeon()
	{
		UniverseSaveFile.Save("PLAYER", "MTIME", GlobalSettings.GameState.ThePlayer.MyShip.TimeInMission);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoLoss);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_WRN", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextWarningVideoLoss);
		UniverseSaveFile.Save("PLAYER", "RESTORE_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoRestore);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MIN", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMin);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MAX", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMax);
	}

	public static bool CheckForDronesBestFriendInDroneBay()
	{
		foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
		{
			if (!enemy.IsDead && enemy is DronesBestFriend && enemy.CurrentRoom is BoardingShip)
			{
				return true;
			}
		}
		return false;
	}

	public bool SyncSceneDronesWithGlobalPlayerDrones()
	{
		int scrap = GlobalSettings.GameState.ThePlayer.Inventory.Scrap;
		int propulsionFuelReserve = GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve;
		int jumpFuel = GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel;
		List<Drone> list = new List<Drone>();
		Drone drone;
		foreach (Drone drones in _droneManager.dronesList)
		{
			drone = drones;
			IDrone drone2 = GlobalSettings.GameState.ThePlayer.Drones.FirstOrDefault((IDrone x) => x.DroneNumber == drone.DroneNumber);
			if (drone2 == null || drone.InterfaceDisconnected)
			{
				continue;
			}
			bool flag = drone.DungeonLeftIn != null && drone.DungeonLeftIn != GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
			bool flag2 = drone.DungeonLeftIn == null && drone.IsDead && !drone.IsVisible;
			if (flag || flag2)
			{
				continue;
			}
			drone.UnsubscribeFromUpgradesEvents();
			DroneItemDropper.DroppedItemDict.Clear();
			if ((drone.CurrentRoom != _dungeonManager.BoardingVessel && !GlobalSettings.CommandeeringShip) || (drone.IsDead && !drone.CanBeTowed && !drone.IsBeingTowed))
			{
				drone.IsVisible = false;
				drone2.DungeonLeftIn = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
				drone2.LastPosition = drone.GetDronePosition();
				drone2.LastRotation = drone.GetDroneRotation();
				list.Add(drone);
				if (drone.CurrentRoom == _dungeonManager.BoardingVessel)
				{
					foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
					{
						GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade);
					}
				}
				if (drone.CurrentRoom != null)
				{
					Debug.Log("*** Drone " + drone.DroneNumber + " left behind in room " + drone.CurrentRoom.labelObject);
				}
				else
				{
					Debug.Log("*** Drone " + drone.DroneNumber + " left behind");
				}
				int num = GameSaveFile.Get("ST_CUR_DRN_DEAD", 0) + 1;
				GameSaveFile.Save("ST_CUR_DRN_DEAD", num);
				GameSaveFile.Save("ST_TTL_DRN_DEAD", GameSaveFile.Get("ST_TTL_DRN_DEAD", 0) + 1);
				if (num > GameSaveFile.Get("ST_BST_DRN_DEAD", 0))
				{
					GameSaveFile.Save("ST_BST_DRN_DEAD", num);
				}
			}
			else
			{
				drone2.DungeonLeftIn = null;
				drone2.LastPosition = Vector3.zero;
			}
			SyncSingleSceneDroneToGlobal(drone2, drone);
		}
		Drone leftBehindDrone;
		foreach (Drone item in list)
		{
			leftBehindDrone = item;
			IDrone drone3 = GlobalSettings.GameState.ThePlayer.Drones.First((IDrone x) => x.DroneNumber == leftBehindDrone.DroneNumber);
			if (!GlobalSettings.IsTutorial)
			{
				UniverseSaveFile.ClearGroup(string.Format("DRONE_{0}", drone3.InternalID));
			}
			if (GlobalSettings.CommandeeringShip && !leftBehindDrone.CanBeFullyRepaired)
			{
				foreach (BaseDroneUpgrade upgrade2 in leftBehindDrone.Upgrades)
				{
					GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade2);
				}
			}
			GlobalSettings.GameState.ThePlayer.Drones.Remove(drone3);
			GlobalSettings.GameState.ThePlayer.DronesLeftBehind.Add(drone3);
		}
		if (GlobalSettings.GameState.ThePlayer.Drones.Count < 7)
		{
			foreach (Drone lootableDrones in _droneManager.LootableDronesList)
			{
				if (lootableDrones.ignoreOnExit || (!(lootableDrones.CurrentRoom == _dungeonManager.BoardingVessel) && (!GlobalSettings.CommandeeringShip || !lootableDrones.Found)))
				{
					continue;
				}
				if (GlobalSettings.CommandeeringShip && !lootableDrones.CanBeFullyRepaired)
				{
					foreach (BaseDroneUpgrade upgrade3 in lootableDrones.Upgrades)
					{
						GlobalSettings.GameState.ThePlayer.AddToInventory(upgrade3);
					}
					continue;
				}
				NonVisualDrone nonVisualDrone = new NonVisualDrone();
				bool flag3 = false;
				int i;
				for (i = 5; i <= 7; i++)
				{
					if (!GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => x.DroneNumber == i))
					{
						nonVisualDrone.DroneNumber = i;
						nonVisualDrone.DroneName = lootableDrones.DroneName;
						nonVisualDrone.engineType = lootableDrones.engineType;
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					Debug.Log("Drone NOT Added, trying open slots");
					int i2;
					for (i2 = 4; i2 >= 1; i2--)
					{
						if (!GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => x.DroneNumber == i2))
						{
							nonVisualDrone.DroneNumber = i2;
							nonVisualDrone.DroneName = lootableDrones.DroneName;
							nonVisualDrone.engineType = lootableDrones.engineType;
							flag3 = true;
							break;
						}
					}
				}
				if (flag3)
				{
					int newInternalID = 0;
					do
					{
						newInternalID = UnityEngine.Random.Range(1, int.MaxValue);
					}
					while (GlobalSettings.GameState.ThePlayer.Drones.Any((IDrone x) => x != null && x.InternalID == newInternalID));
					nonVisualDrone.InternalID = newInternalID;
					nonVisualDrone.Initalize(false);
					SyncSingleSceneDroneToGlobal(nonVisualDrone, lootableDrones);
					nonVisualDrone.OverrideCurrentHitpoints(0f);
					GlobalSettings.GameState.ThePlayer.Drones.Add(nonVisualDrone);
					string groupKey = string.Format("DRONE_{0}", nonVisualDrone.InternalID);
					UniverseSaveFile.Save(groupKey, "ID", nonVisualDrone.InternalID);
					UniverseSaveFile.Save(groupKey, "DVPSEED", nonVisualDrone.DVPSeed);
					UniverseSaveFile.Save(groupKey, "DVPNAME", nonVisualDrone.DVPName);
					UniverseSaveFile.Save(groupKey, "CSID", nonVisualDrone.CSID);
					UniverseSaveFile.Save(groupKey, "NUM", nonVisualDrone.DroneNumber);
					UniverseSaveFile.Save(groupKey, "NAME", nonVisualDrone.DroneName);
					UniverseSaveFile.Save(groupKey, "SPD", nonVisualDrone.OriginalSpeed);
					UniverseSaveFile.Save(groupKey, "SLOTCT", nonVisualDrone.NumberOfUpgradeSlots);
					UniverseSaveFile.Save(groupKey, "THP", nonVisualDrone.TotalHitpoints);
					UniverseSaveFile.Save(groupKey, "HP", nonVisualDrone.CurrentHitPoints);
					UniverseSaveFile.Save(groupKey, "DRONE_APPLIED_MODS", (int)nonVisualDrone.AppliedModifications);
					UniverseSaveFile.Save(groupKey, "DRONE_VIS_IDX", nonVisualDrone.DroneVisualIndex);
				}
			}
		}
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			int num2 = GlobalSettings.GameState.ThePlayer.Inventory.Scrap - scrap;
			int num3 = GlobalSettings.GameState.ThePlayer.Inventory.PropulsionFuelReserve - propulsionFuelReserve;
			int num4 = GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel - jumpFuel;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			float num8 = 0f;
			foreach (IDrone drone4 in GlobalSettings.GameState.ThePlayer.Drones)
			{
				num8 += drone4.CurrentHitPoints;
				if (!drone4.IsDead || drone4.CanBeFullyRepaired)
				{
					num5++;
				}
				foreach (BaseDroneUpgrade upgrade4 in drone4.Upgrades)
				{
					if (upgrade4 != null && upgrade4.BrokenState != BrokenStateEnum.Broken)
					{
						num6++;
					}
				}
			}
			foreach (ShipUpgradeInGameObject shipUpgrade in _dungeonManager.ShipUpgrades)
			{
				BoardingShip boardingVessel = _dungeonManager.BoardingVessel;
				if (boardingVessel != null && boardingVessel.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds))
				{
					num7++;
				}
			}
			int num9 = num2 * 20;
			int num10 = num3 * 5;
			int num11 = num4 * 20;
			int num12 = Mathf.RoundToInt(num8 * 1f);
			int num13 = num5 * 35;
			int num14 = num6 * 25;
			int num15 = num7 * 30;
			int finalScore = num9 + num10 + num11 + num12 + num13 + num14 + num15;
			if (SteamLeaderboard.HasDailyLeaderboard)
			{
				if (GlobalSettings.MissionStarted)
				{
					DialogUI.Instance.ShowDialog("Daily Challenge Score", string.Format("Final score calculated as follows:\n\n - Scrap: \t\t\t{3, 5} ( {1, 3} * {2, 2} )\n - P-Fuel: \t\t\t{6, 5} ( {4, 3} * {5, 2} )\n - J-Fuel: \t\t\t{9, 5} ( {7, 3} * {8, 2} )\n - Drone HP: \t\t{12, 5} ( {10, 3} * {11, 2} )\n - Drones: \t\t\t{15, 5} ( {13, 3} * {14, 2} )\n - Drone Upgrades: \t{18, 5} ( {16, 3} * {17, 2} )\n - Ship Upgrades: \t{21, 5} ( {19, 3} * {20, 2} )\n\n - Total: \t\t\t{0, 5}", finalScore, num2, 20, num9, num3, 5, num10, num4, 20, num11, num8, 1, num12, num5, 35, num13, num6, 25, num14, num7, 30, num15), ModalWindowType.OK, delegate
					{
						SteamLeaderboard.PostChallengeScore(GlobalSettings.gameMode, finalScore, SteamLeaderboard.ScoreStatusEnum.Final);
						GlobalSettings.ShowDailyLeaderboard = true;
						Instance.GotoMainMenu();
					}, 1);
				}
				else
				{
					DialogUI.Instance.ShowDialog("Daily Challenge is Incomplete", "The mission was not started - no score to submit!", ModalWindowType.OK, delegate
					{
						Instance.GotoMainMenu();
					});
				}
				return false;
			}
			DialogUI.Instance.ShowDialog("Error with Daily Challenge", string.Format("Because the leaderboard could not be found, your score cannot be submitted!"), ModalWindowType.OK, delegate
			{
				Instance.GotoMainMenu();
			});
			return false;
		}
		return true;
	}

	private void SyncSingleSceneDroneToGlobal(IDrone globalDrone, Drone sceneDrone)
	{
		GameSaveFile.BeginBatch();
		UniverseSaveFile.BeginBatch();
		GalaxySaveFile.BeginBatch();
		if (sceneDrone.CurrentRoom == _dungeonManager.BoardingVessel || GlobalSettings.CommandeeringShip)
		{
			int lootCount = sceneDrone.GetLootCount(true);
			int num = GameSaveFile.Get("ST_CUR_SCRAP_COL", 0) + lootCount;
			int scrapMax = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
			if (GlobalSettings.CommandeeringShip)
			{
				scrapMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax;
			}
			if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + lootCount <= scrapMax)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.Scrap += lootCount;
			}
			else
			{
				GlobalSettings.GameState.ThePlayer.Inventory.Scrap = scrapMax;
			}
			GameSaveFile.Save("ST_CUR_SCRAP_COL", num);
			GameSaveFile.Save("ST_TTL_SCRAP_COL", GameSaveFile.Get("ST_TTL_SCRAP_COL", 0) + lootCount);
			if (GameSaveFile.Get("ST_BST_SCRAP_COL", 0) < num)
			{
				GameSaveFile.Save("ST_BST_SCRAP_COL", num);
			}
			int value = GameSaveFile.Get("ST_CUR_PFUEL_COL", 0) + sceneDrone.GetPropulsionFuelCount(false);
			GameSaveFile.Save("ST_CUR_PFUEL_COL", value);
			GameSaveFile.Save("ST_TTL_PFUEL_COL", GameSaveFile.Get("ST_TTL_PFUEL_COL", 0) + sceneDrone.GetPropulsionFuelCount(false));
			value = GameSaveFile.Get("ST_CUR_JFUEL_COL", 0) + sceneDrone.GetJumpFuelCount(false);
			GameSaveFile.Save("ST_CUR_JFUEL_COL", value);
			GameSaveFile.Save("ST_TTL_JFUEL_COL", GameSaveFile.Get("ST_TTL_JFUEL_COL", 0) + sceneDrone.GetJumpFuelCount(false));
			int propulsionFuelCount = sceneDrone.GetPropulsionFuelCount(true);
			GlobalSettings.GameState.ThePlayer.Inventory.AddReservePropulsionFuel(propulsionFuelCount);
			GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel += sceneDrone.GetJumpFuelCount(true);
		}
		globalDrone.RemoveAllUpgrades();
		globalDrone.OverrideCurrentHitpoints(sceneDrone.CurrentHitPoints);
		globalDrone.OverrideTotalHitpoints(sceneDrone.TotalHitpoints);
		if (sceneDrone.IsDisabledButAlive)
		{
			globalDrone.OverrideIsDead(false);
		}
		else
		{
			globalDrone.OverrideIsDead(sceneDrone.IsDead);
		}
		globalDrone.OriginalSpeed = sceneDrone.OriginalSpeed;
		globalDrone.NumberOfUpgradeSlots = sceneDrone.NumberOfUpgradeSlots;
		globalDrone.TimeInMission = sceneDrone.TimeInMission;
		globalDrone.VideoSignalLost = sceneDrone.VideoSignalLost;
		globalDrone.TimeOfNextVideoLoss = sceneDrone.TimeOfNextVideoLoss;
		globalDrone.TimeOfNextVideoRestore = sceneDrone.TimeOfNextVideoRestore;
		globalDrone.TimeTilNextFailMin = sceneDrone.TimeTilNextFailMin;
		globalDrone.TimeTilNextFailMax = sceneDrone.TimeTilNextFailMax;
		globalDrone.VideoLossDuration = sceneDrone.VideoLossDuration;
		globalDrone.AppliedModifications = sceneDrone.AppliedModifications;
		globalDrone.DroneVisualIndex = sceneDrone.DroneVisualIndex;
		if (sceneDrone.IsDead)
		{
			globalDrone.DaysTraveledWhileDead = 0;
		}
		globalDrone.IsVisible = true;
		globalDrone.CanBeFullyRepaired = sceneDrone.CanBeFullyRepaired;
		globalDrone.engineType = sceneDrone.engineType;
		globalDrone.DVPSeed = sceneDrone.DVPSeed;
		globalDrone.DVPName = sceneDrone.DVPName;
		globalDrone.CSID = sceneDrone.CSID;
		globalDrone.TraitVeer = sceneDrone.TraitVeer;
		globalDrone.TraitPermVeer = sceneDrone.TraitPermVeer;
		globalDrone.TraitPitchOffset = sceneDrone.TraitPitchOffset;
		if (CollectorPermUpgrade.Instance != null && sceneDrone.InternalID > 0)
		{
			globalDrone.InternalID = sceneDrone.InternalID;
			globalDrone.DroneNumber = sceneDrone.DroneNumber;
			globalDrone.DroneName = sceneDrone.DroneName;
			if (UniverseSaveFile.Get(string.Format("DRONE_{0}", sceneDrone.InternalID), "ID", -1) == -1)
			{
				UniverseSaveFile.Save(string.Format("DRONE_{0}", sceneDrone.InternalID), "ID", sceneDrone.InternalID);
			}
		}
		int num2 = 0;
		foreach (BaseDroneUpgrade upgrade in sceneDrone.Upgrades)
		{
			if (upgrade != null)
			{
				upgrade.CancelAbility();
				upgrade.CleanUpForLeavingDungeon();
				globalDrone.AddDroneUpgrade(num2, upgrade);
			}
			num2++;
		}
		GameSaveFile.EndBatch();
		UniverseSaveFile.EndBatch();
		GalaxySaveFile.EndBatch();
	}

	private bool OnInventoryItemToBeInstalled(IInventoryItem item)
	{
		return GameplayManagerGUI.Instance._droneInstallUpgradesWindow.InstallUpgradeOnCurrentDrone((BaseDroneUpgrade)item);
	}

	private void OnDroneWindowSelectedForInstall(int droneNumber)
	{
		if (_windowState != GameWindowStates.ShowDroneInstallUpgrades)
		{
			GameplayManagerGUI.Instance.ToggleItemInstallMode();
		}
		GameplayManagerGUI.Instance._droneInstallUpgradesWindow.SelectDrone(droneNumber);
	}

	private void OnDroneWindowSelectedForSchematic(int droneNumber)
	{
		_droneManager.SetDroneNumber(droneNumber);
	}

	public static void ShowConsoleMessage(string message, ConsoleMessageType type)
	{
		if (DungeonManager.Instance != null)
		{
			DungeonManager.Instance.SendConsoleMessage(message, type);
		}
	}

	public void RemoveAllDroneContextsFromConsole()
	{
		int count = DroneManager.Instance.dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone commandableObject = DroneManager.Instance.dronesList[i];
			if (_consoleWindow != null)
			{
				_consoleWindow.RemoveCommandableObject(commandableObject);
			}
		}
		count = DroneManager.Instance.LootableDronesList.Count;
		for (int j = 0; j < count; j++)
		{
			Drone commandableObject2 = DroneManager.Instance.LootableDronesList[j];
			if (_consoleWindow != null)
			{
				_consoleWindow.RemoveCommandableObject(commandableObject2);
			}
		}
	}

	public void OnDroneSelected(int droneNumber)
	{
		if (GlobalSettings.cameraMode != CameraMode.Drone)
		{
			return;
		}
		RemoveAllDroneContextsFromConsole();
		int count = _droneManager.dronesList.Count;
		for (int i = 0; i < count; i++)
		{
			Drone drone = _droneManager.dronesList[i];
			if (drone.DroneNumber == droneNumber)
			{
				_consoleWindow.AddCommandableObject(drone);
			}
		}
	}

	public void HookObjectToConsole(ICommandable commandableObject)
	{
		_consoleWindow.AddCommandableObject(commandableObject);
	}

	public void UnhookObjectFromConsole(ICommandable commandableObject)
	{
		_consoleWindow.RemoveCommandableObject(commandableObject);
	}

	public bool AddUI(GameWindowIds windowID)
	{
		return AddUI(windowID, -1);
	}

	public bool AddUI(GameWindowIds windowID, int droneNumber)
	{
		if (windowID == GameWindowIds.UpgradeSwapWindow)
		{
			if (!isShowingDroneSwapUI)
			{
				if (_droneSwapUi != null)
				{
					Drone currentDrone = _droneManager.CurrentDrone;
					Drone drone = null;
					float num = float.MaxValue;
					foreach (Drone drones in _droneManager.dronesList)
					{
						if (drones == currentDrone)
						{
							continue;
						}
						bool flag = false;
						if (currentDrone.CurrentRoom != null)
						{
							if (drones.CurrentRoom == currentDrone.CurrentRoom)
							{
								flag = true;
							}
							else if (drones.CurrentCorridor != null && drones.CurrentCorridor.rooms.Contains(currentDrone.CurrentRoom))
							{
								flag = true;
							}
						}
						else if (currentDrone.CurrentCorridor != null)
						{
							if (drones.CurrentCorridor == currentDrone.CurrentCorridor)
							{
								flag = true;
							}
							else if (drones.CurrentRoom != null && currentDrone.CurrentCorridor.rooms.Contains(drones.CurrentRoom))
							{
								flag = true;
							}
						}
						if (!flag)
						{
							continue;
						}
						if (droneNumber == -1)
						{
							float num2 = Vector3.Distance(currentDrone.Position, drones.Position);
							if (num2 < num)
							{
								num = num2;
								drone = drones;
							}
						}
						else if (drones.DroneNumber == droneNumber)
						{
							drone = drones;
						}
					}
					if (droneNumber == -1 || drone == null)
					{
						foreach (Drone lootableDrones in _droneManager.LootableDronesList)
						{
							if (!lootableDrones.IsOverlayVisible)
							{
								continue;
							}
							bool flag2 = false;
							if (currentDrone.CurrentRoom != null)
							{
								if (lootableDrones.CurrentRoom == currentDrone.CurrentRoom)
								{
									flag2 = true;
								}
								else if (lootableDrones.CurrentCorridor != null && lootableDrones.CurrentCorridor.rooms.Contains(currentDrone.CurrentRoom))
								{
									flag2 = true;
								}
							}
							else if (currentDrone.CurrentCorridor != null)
							{
								if (lootableDrones.CurrentCorridor == currentDrone.CurrentCorridor)
								{
									flag2 = true;
								}
								else if (lootableDrones.CurrentRoom != null && currentDrone.CurrentCorridor.rooms.Contains(lootableDrones.CurrentRoom))
								{
									flag2 = true;
								}
							}
							if (!flag2)
							{
								continue;
							}
							if (droneNumber == -1)
							{
								float num3 = Vector3.Distance(currentDrone.Position, lootableDrones.Position);
								if (num3 < num)
								{
									num = num3;
									drone = lootableDrones;
								}
							}
							else if (lootableDrones.DroneNumber == droneNumber)
							{
								drone = lootableDrones;
							}
						}
					}
					if (drone != null)
					{
						GameAudio.Play2DSFX(GameAudio.SoundEnum.UIDialogShow);
						_consoleWindow.IsVisible = false;
						_droneSwapUi.IsVisible = true;
						screenDimUIImage.enabled = true;
						Color color = screenDimUIImage.color;
						color.a = 0.6f;
						screenDimUIImage.color = color;
						_droneSwapUi.SetDrones(currentDrone, drone);
						isShowingDroneSwapUI = true;
						if (_windowState == GameWindowStates.None)
						{
							_windowState = GameWindowStates.ShowUpgradeSwap;
						}
						return true;
					}
					return false;
				}
				Debug.LogWarning("swap UI not loaded properly!");
				return false;
			}
			Debug.Log("Drone swap window already showing");
			return false;
		}
		Debug.Log("Window type not supported by AddUI(): " + windowID);
		return false;
	}

	public bool HideUI(GameWindowIds windowID, bool respectPin)
	{
		if (windowID == GameWindowIds.UpgradeSwapWindow)
		{
			if (isShowingDroneSwapUI)
			{
				if (_droneSwapUi != null)
				{
					_droneSwapUi.IsVisible = false;
					screenDimUIImage.enabled = false;
				}
				_consoleWindow.IsVisible = true;
				isShowingDroneSwapUI = false;
				if (_windowState == GameWindowStates.ShowUpgradeSwap)
				{
					_windowState = GameWindowStates.None;
				}
			}
			return true;
		}
		Debug.Log("Window type not supported by HideUI(): " + windowID);
		return false;
	}

	public Rect GetConsoleWindowRect()
	{
		return _consoleWindow.GetConsoleRect();
	}

	public static bool TransporterShipUpgradeActive()
	{
		return GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Any((IInventoryItem x) => ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.Transporter && !((BaseShipUpgrade)x).IsBroken);
	}

	public void ShowShipSwapWindow()
	{
		_windowState = GameWindowStates.ShowShipSwap;
		CommandeerUI.Instance.Show();
	}

	private void CutOutVideo()
	{
		GameplayManagerGUI.Instance._blankedOutScreen = true;
		videoSignalMissingObject.SetActive(true);
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (_droneManager.HUDCamera != null)
			{
				_droneManager.HUDCamera.gameObject.SetActive(false);
				_droneManager.HUDOverlayCamera.gameObject.SetActive(false);
			}
		}
		else
		{
			_droneManager.SchematicCamera.gameObject.SetActive(false);
		}
		_droneManager.SchematicCamera.cullingMask = _droneManager.SchematicCameraMask & ~_droneManager.HudCameraMask;
		_blankScreenObject.transform.position = new Vector3(0f, 0f, -5f);
		_blankScreenObject.GetComponent<Renderer>().enabled = true;
	}

	private void RestoreVideo()
	{
		GameplayManagerGUI.Instance._blankedOutScreen = false;
		videoSignalMissingObject.SetActive(false);
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (_droneManager.HUDCamera != null)
			{
				_droneManager.HUDCamera.gameObject.SetActive(true);
			}
			if (_droneManager.HUDOverlayCamera != null && _droneManager.isHUDOverlayCameraInUse)
			{
				_droneManager.HUDOverlayCamera.gameObject.SetActive(true);
			}
		}
		else
		{
			DroneManager.Instance.SchematicCamera.gameObject.SetActive(true);
		}
		_droneManager.SchematicCamera.cullingMask = _droneManager.SchematicCameraMask;
		_blankScreenObject.GetComponent<Renderer>().enabled = false;
	}

	public void ShowHelpManualWindow()
	{
		_windowState = GameWindowStates.ShowHelpManual;
		_helpManualWindow.IsVisible = true;
		Manual.ShowEnterOnSubMenu = true;
		_consoleWindow.IsVisible = false;
	}

	private void SteamOverlayToggle(bool isOn)
	{
		if (isOn)
		{
			DroneManager.Instance.HideUpgradeSwapUI();
			ShowPauseMenuPostDeath(false);
		}
		else if (Screen.fullScreen && GameSaveFile.Get("O_RFS", false))
		{
			Screen.fullScreen = false;
			autoFullScreen = true;
			timerTillFullScreen = 0.3f;
		}
	}
}
