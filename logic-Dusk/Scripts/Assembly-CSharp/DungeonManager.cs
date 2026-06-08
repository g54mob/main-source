using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BoardEditor;
using UnityEngine;
using UnityEngine.UI;

public class DungeonManager : MonoBehaviour, ICommandable
{
	public const float SHIP_OFFSET_X = -7f;

	public const float SHIP_OFFSET_Y = 2.5f;

	private const float HINT_PULSE_DELAY = 0.75f;

	private const float HINT_COMPLETED_FADEOUT = 0.4f;

	private const float HINT_SPACING_DELAY = 1f;

	private const int LOOT_EDGE_PADDING = 1;

	private const float EXIT_TRANSPORT_TIME = 1.5f;

	private const float EXIT_FINAL_TIME = 0.8f;

	private const float BARK_COOLDOWN = 7f;

	public static DungeonManager Instance;

	public static string DungeonFileAtNextInstatiate = string.Empty;

	public static int SeedScrap = -1;

	public static int SeedUniqueDungeonSetup = -1;

	public static int SeedDungeonSize = -1;

	private static bool hasTestedForAirlockWarning;

	private static bool hasTestedForShipExplored;

	public static bool DisableTrackingCommandCounts;

	private static bool isTrackingCommandCounts;

	private static int countOpenCloseCommands;

	public GameObject HintPanelGameObject;

	public GameObject HintAttentionObject;

	public GameObject TutorialHintPanelGameObject;

	public GameObject TutorialHintAttentionObject;

	public GameObject TutorialHintBackgroundObject;

	public GameObject labelObject;

	public GameObject canvasLabelObject;

	public MenuPanelUI menuPanel;

	public Room[] rooms;

	public Corridor[] corridors;

	public Door[] doors;

	public Light SchematicBaseLight;

	public Room currentRoom;

	public int numberOfHiddenLootItems = 4;

	public int numberOfVisibleLootItems = 8;

	public int lootLargeRoomBias = 10;

	public Color SVPoweredRoom = Color.green;

	public Color SVUnPoweredRoom = Color.white;

	public Color SVPoweredAirlock = Color.yellow;

	public Color SVUnPoweredAirlock = Color.yellow;

	public Color SVPoweredDoor = Color.green;

	public Color SVUnPoweredDoor = Color.white;

	public Color DVWeldedDoor = Color.gray;

	public Color SVWeldedDoor = Color.gray;

	public Color DVPoweredAirlock = Color.yellow;

	public Color DVUnPoweredAirlock = Color.yellow;

	public Color DVPoweredDoor = Color.green;

	public Color DVUnPoweredDoor = Color.white;

	public Color DVUpgradeAddedBlink = Color.blue;

	public Color EdgeOutlinePoweredColor = Color.green;

	public Color EdgeOutlineUnPoweredColor = Color.white;

	public bool generateDungeon;

	public GameObject scrapObjectPrefab;

	private DungeonBuilder dungeonBuilder;

	private RoomItem[] roomItems;

	private LootItem[] lootItems;

	private SwamSpawnVent[] vents;

	private DroneManager droneManager;

	private MissionState missionStateStartup;

	private MissionState missionStateEnding;

	private Vector3 svCameraCenter = Vector3.zero;

	private List<Corridor> leadInOpenCorridors;

	private List<Room> transporterRooms = new List<Room>();

	private bool hasExtraStartingReceiverRoom;

	public RevealedRoomType revealedRoomType;

	public List<ShipUpgradeInGameObject> ShipUpgrades = new List<ShipUpgradeInGameObject>();

	private List<ShipInfestationType> _infestationType = new List<ShipInfestationType>();

	private int actualHiddenLootItems;

	private int actualVisibleLootItems;

	private float _exitTransportCountdown;

	private float _exitFinalCountdown;

	private List<Drone> _transportableDronesOnExit;

	private List<ShipUpgradeInGameObject> _transportableShipUpgradesOnExit;

	private bool showQuickTutorialAfterLog;

	private float timeIgnoreAllInput;

	private AudioSource asRAmbience;

	private AudioSource asMotherShipAmbience;

	private AudioSource asMotherShipShipCreak;

	private AudioSource asRandomStaticAmbience;

	private AudioSource asPickup;

	private GameAudio.SoundEnum soundRAmbientStatic;

	private GameAudio.SoundEnum soundRAmbientHost;

	private GameAudio.SoundEnum soundShipCreak;

	private bool isRAmbiencePaused;

	private bool isRandomStaticAmbiencePaused;

	private bool isPickupPaused;

	private float nextRandomAmbientSound;

	public string DebugShipDataFile = string.Empty;

	private bool isWaitingToCleanupMemory = true;

	private float timerMemoryCleanupAfterLoad = 1f;

	private bool needDisplayToFirstTransporterClearMsg;

	private bool playedPanErrorSound;

	private float _ownedDbfNonBarkTimer = 420f;

	private Vector3 lastPositionCurrentDrone = Vector3.zero;

	private bool ignoreNextMainVideoStatusMessage;

	private List<CommandDefinition> commandList;

	private List<CommandDefinition> baseCommandList;

	private System.Random _random = new System.Random();

	private LootItem lootItemObjectTran;

	private List<Bounds> corridorBoundsList;

	private static float _barkResponseTimeStamp;

	public UpgradePickupItem PickupItemTemplate { get; private set; }

	public BoardingShip BoardingVessel { get; private set; }

	public int LastRevealedRoomNumber { get; set; }

	public Coordinate2D DungeonSize { get; private set; }

	public DungeonDefense[] defenses { get; private set; }

	public TerminalManager terminalManager { get; private set; }

	public bool isShowingReconnectingMessage { get; private set; }

	public int CountExtraTransporters
	{
		get
		{
			if (transporterRooms != null)
			{
				return transporterRooms.Count;
			}
			return 0;
		}
	}

	public List<ShipUpgradeSubsystemObject> UpgradeSubSystems { get; set; }

	public Room RevealedRoom { get; set; }

	public bool IsExiting { get; private set; }

	public bool ignoreAllInputForAMoment { get; set; }

	public bool hasStarted { get; private set; }

	public bool isShowingAlias { get; private set; }

	public bool IsPrimaryCommandContext { get; set; }

	public string CommandHeader
	{
		get
		{
			return "Ship";
		}
	}

	public int PropulsionFuelAddedWhenCommandeering { get; private set; }

	public int JumpFuelAddedWhenCommandeering { get; private set; }

	public int RationsAddedWhenCommandeering { get; private set; }

	private void Awake()
	{
		Instance = this;
		ShipUpgrades.Clear();
		UpgradeSubSystems = new List<ShipUpgradeSubsystemObject>();
		if (!ResourceManager.OneTimeDungeonLoadPerformed)
		{
			ResourceManager.OneTimeDungeonResourceLoad();
		}
		else
		{
			ResourceManager.ReInitDungeonResources();
		}
		Room.ClearCachedTiles();
		DungeonTypeEnum dungeonTypeEnum = DungeonTypeEnum.Derelict;
		string empty = string.Empty;
		bool flag = false;
		if (!GlobalSettings.GameStartedFromGalaxyMap)
		{
			HelpTextManager.Initialize();
			string text = string.Empty;
			if (GlobalSettings.IsTutorial)
			{
				TextAsset textAsset = Resources.Load<TextAsset>(DungeonFileAtNextInstatiate);
				if (textAsset != null)
				{
					text = textAsset.text;
					DungeonFileAtNextInstatiate = string.Empty;
				}
				else
				{
					Debug.LogError(string.Format("Couldn't start the tutorial - not found: {0}", DungeonFileAtNextInstatiate));
				}
			}
			else if (File.Exists(DebugShipDataFile))
			{
				text = File.ReadAllText(DebugShipDataFile);
			}
			if (!string.IsNullOrEmpty(text))
			{
				List<IGEObject> boardObjects = new List<IGEObject>();
				DesignedDungeonManager.InitializeTiles();
				List<DesignedDungeonManager.MetaData> shipMetaData = null;
				flag = DesignedDungeonManager.LoadBoardFromXml(text, ref boardObjects, ref shipMetaData);
				if (flag)
				{
					GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip = true;
					GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.metaDataList = shipMetaData;
					DesignedDungeonManager.BuildDesignedDungeon(boardObjects, true, true);
					if (GlobalSettings.IsTutorial)
					{
						new TutorialManagerClass();
					}
				}
			}
		}
		else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			flag = true;
			DesignedDungeonManager.tiles = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.designedShipTileData;
			DesignedDungeonManager.BuildDesignedDungeon(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.designedBoardObjects, true, true);
		}
		if (generateDungeon)
		{
			dungeonBuilder = (DungeonBuilder)UnityEngine.Object.FindObjectOfType(typeof(DungeonBuilder));
			if (dungeonBuilder != null)
			{
				Coordinate2D coordinate2D = new Coordinate2D();
				if (!flag)
				{
					if (GlobalSettings.gameMode != GameModeEnum.Normal)
					{
						int seed = GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "SEED_D", -1);
						UnityEngine.Random.seed = seed;
					}
					do
					{
						DroneManager.SeedLootableDrones = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DroneManager.SeedLootableDrones == -1);
					do
					{
						DungeonBuilder.SeedLargeDebris = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonBuilder.SeedLargeDebris == -1);
					do
					{
						DungeonBuilder.SeedSmallDebris = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonBuilder.SeedSmallDebris == -1);
					do
					{
						DungeonBuilder.SeedFuel = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonBuilder.SeedFuel == -1);
					do
					{
						SeedScrap = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (SeedScrap == -1);
					do
					{
						DungeonGenerator.SeedPowerInlet = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedPowerInlet == -1);
					do
					{
						GameplayManager.SeedAirlookFailEvent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedAirlookFailEvent == -1);
					do
					{
						GameplayManager.SeedAsteroidEvent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedAsteroidEvent == -1);
					do
					{
						GameplayManager.SeedDoorCloseEvent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedDoorCloseEvent == -1);
					do
					{
						GameplayManager.SeedDoorFailEvent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedDoorFailEvent == -1);
					do
					{
						GameplayManager.SeedRadiationEvent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedRadiationEvent == -1);
					do
					{
						DungeonGenerator.SeedFuelInlet = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedFuelInlet == -1);
					do
					{
						DungeonGenerator.SeedTerminalInlet = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedTerminalInlet == -1);
					do
					{
						DungeonGenerator.SeedVent = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedVent == -1);
					do
					{
						DungeonGenerator.SeedSubSystem = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedSubSystem == -1);
					do
					{
						GameplayManager.SeedGenerateEnemies = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (GameplayManager.SeedGenerateEnemies == -1);
					do
					{
						EnemyManager.SeedAdditionalSlime = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (EnemyManager.SeedAdditionalSlime == -1);
					do
					{
						SeedUniqueDungeonSetup = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (SeedUniqueDungeonSetup == -1);
					do
					{
						SeedDungeonSize = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (SeedDungeonSize == -1);
					do
					{
						DungeonGenerator.SeedDungeonBaseProperties = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedDungeonBaseProperties == -1);
					do
					{
						DungeonGenerator.SeedAirlocks = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedAirlocks == -1);
					do
					{
						DungeonGenerator.SeedDoors = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedDoors == -1);
					do
					{
						DungeonGenerator.SeedDefense = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonGenerator.SeedDefense == -1);
					do
					{
						DungeonBuilder.SeedSubSystemContents = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
					}
					while (DungeonBuilder.SeedSubSystemContents == -1);
					if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
					{
						do
						{
							GameplayManager.SeedDailyShipUpgrades = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
						}
						while (GameplayManager.SeedDailyShipUpgrades == -1);
					}
					if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
					{
						dungeonTypeEnum = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType;
						if (GlobalSettings.gameMode == GameModeEnum.Normal)
						{
							coordinate2D = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.GetRandomSize(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value, null);
						}
						else
						{
							int seed2 = (int)DateTime.Now.Ticks;
							if (SeedDungeonSize != -1)
							{
								seed2 = SeedDungeonSize;
							}
							System.Random rnd = new System.Random(seed2);
							coordinate2D = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.GetRandomSize(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value, rnd);
						}
						empty = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name;
					}
					bool flag2 = false;
					do
					{
						flag2 = false;
						try
						{
							if (GlobalSettings.GameStartedFromGalaxyMap)
							{
								DungeonGenerator.GetInstance().GenerateDungeon(dungeonTypeEnum, coordinate2D.x, coordinate2D.y, empty);
								Debug.Log(string.Format("Created a {0}x{1} sized dungeon for '{2}'", coordinate2D.x, coordinate2D.y, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DisplayName));
							}
							else
							{
								DungeonGenerator.GetInstance().GenerateDungeon(dungeonTypeEnum, coordinate2D.x, coordinate2D.y, empty);
								coordinate2D.x = 36;
								coordinate2D.y = 28;
							}
						}
						catch (Exception)
						{
							flag2 = true;
							coordinate2D.x++;
							coordinate2D.y++;
						}
					}
					while (flag2);
				}
				else
				{
					Rect designedDungeonRect = DesignedDungeonManager.GetDesignedDungeonRect();
					coordinate2D.x = (int)(designedDungeonRect.width - designedDungeonRect.x);
					coordinate2D.y = (int)(designedDungeonRect.height - designedDungeonRect.y);
				}
				DungeonSize = coordinate2D;
				dungeonBuilder.BuildDungeon(0f, 0f, dungeonTypeEnum);
				Vector3 position = new Vector3((float)coordinate2D.x / 2f, (float)coordinate2D.y / 2f, -20f);
				if (GlobalSettings.IsTutorial)
				{
					position.x += 10f;
				}
				DroneManager.Instance.SchematicCamera.transform.position = position;
			}
		}
		rooms = UnityEngine.Object.FindObjectsOfType(typeof(Room)) as Room[];
		corridors = UnityEngine.Object.FindObjectsOfType(typeof(Corridor)) as Corridor[];
		roomItems = UnityEngine.Object.FindObjectsOfType(typeof(RoomItem)) as RoomItem[];
		droneManager = UnityEngine.Object.FindObjectOfType(typeof(DroneManager)) as DroneManager;
		doors = UnityEngine.Object.FindObjectsOfType(typeof(Door)) as Door[];
		defenses = UnityEngine.Object.FindObjectsOfType(typeof(DungeonDefense)) as DungeonDefense[];
		vents = UnityEngine.Object.FindObjectsOfType(typeof(SwamSpawnVent)) as SwamSpawnVent[];
		svCameraCenter = droneManager.SchematicCamera.transform.position;
		for (int i = 0; i < rooms.Length; i++)
		{
			if (rooms[i].boardingVessel)
			{
				Room room = rooms[i];
				rooms[i] = rooms[0];
				rooms[0] = room;
				BoardingVessel = (BoardingShip)room;
				break;
			}
		}
		if (dungeonTypeEnum == DungeonTypeEnum.Outpost)
		{
			Vector3 position2 = BoardingVessel.transform.position;
			position2.x = -7f - BoardingVessel.transform.localScale.x * 0.75f;
			position2.y = 2.5f - BoardingVessel.transform.localScale.y;
			BoardingVessel.transform.position = position2;
		}
		Vector3 position3 = svCameraCenter;
		if (svCameraCenter.x - BoardingVessel.transform.position.x > 19f)
		{
			position3.x -= 15f;
		}
		else if (svCameraCenter.x - BoardingVessel.transform.position.x <= -19f)
		{
			position3.x += 15f;
		}
		if (svCameraCenter.y - BoardingVessel.transform.position.y >= 19f)
		{
			position3.y -= 15f;
		}
		else if (svCameraCenter.y - BoardingVessel.transform.position.y <= -19f)
		{
			position3.y += 15f;
		}
		svCameraCenter.x += 15f;
		position3.x += 15f;
		droneManager.SchematicCamera.transform.position = position3;
		if (MenuBackground.Instance != null)
		{
			Vector3 position4 = droneManager.SchematicCamera.transform.position;
			position4.z = MenuBackground.Instance.gameObject.transform.position.z;
			MenuBackground.Instance.gameObject.transform.position = position4;
		}
		droneManager.SchematicCamera.orthographicSize = 21f;
		for (int j = 0; j < corridors.Length; j++)
		{
			if (corridors[j].LeadsIntoShip)
			{
				Corridor corridor = corridors[j];
				corridors[j] = corridors[0];
				corridors[0] = corridor;
				break;
			}
		}
		for (int k = 0; k < rooms.Length; k++)
		{
			Room room2 = rooms[k];
			room2.labelObject = (GameObject)UnityEngine.Object.Instantiate(canvasLabelObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
			room2.labelObject.transform.parent = rooms[k].transform;
			room2.labelObject.transform.localPosition = new Vector3(0f, 0.03f, -1f);
			room2.labelObject.transform.localScale = new Vector3(1f, 1f, 1f);
			Vector3 localScale = room2.transform.localScale;
			Vector3 localScale2 = room2.labelObject.transform.localScale;
			bool flag3 = room2.transform.rotation.w >= 0.65f && room2.transform.rotation.w <= 0.75f;
			if (localScale.x > localScale.y && !flag3)
			{
				localScale2.x *= localScale.y / localScale.x;
			}
			else if (localScale.y > localScale.x && !flag3)
			{
				localScale2.y *= localScale.x / localScale.y;
			}
			room2.labelObject.transform.localScale = localScale2;
			Text text2 = null;
			Transform transform = room2.labelObject.transform.FindChild("label");
			if (transform != null)
			{
				rooms[k].labelBorder = transform.GetComponent<Image>();
				rooms[k].labelBorder.enabled = false;
				Transform transform2 = transform.FindChild("Text");
				if (transform2 != null)
				{
					text2 = transform2.gameObject.GetComponent<Text>();
					rooms[k].labelTextObject = text2;
				}
				Transform transform3 = transform.FindChild("Overlay");
				if (transform3 != null)
				{
					rooms[k].overlayObject = transform3.gameObject.GetComponent<Image>();
					rooms[k].overlayObject.gameObject.SetActive(false);
					transform2 = transform3.FindChild("radWarning1");
					if (transform2 != null)
					{
						rooms[k].overlayWarning1Object = transform2.gameObject.GetComponent<Image>();
					}
					transform2 = transform3.FindChild("radWarning2");
					if (transform2 != null)
					{
						rooms[k].overlayWarning2Object = transform2.gameObject.GetComponent<Image>();
					}
				}
			}
			string metaData = room2.GetMetaData("roomnum");
			if (metaData == string.Empty || metaData == "0")
			{
				if (k > 0)
				{
					text2.text = "R?";
					rooms[k].labelTextObject.enabled = false;
				}
				else
				{
					text2.text = "r" + (k + 1);
					room2.LabelSimple = "r" + (k + 1);
				}
				room2.Label = text2.text;
				continue;
			}
			text2.text = "r" + metaData;
			room2.LabelSimple = "r" + metaData;
			room2.Label = text2.text;
			room2.LabelSimple = text2.text.Replace('0', '\0');
			int result = -1;
			if (int.TryParse(metaData, out result))
			{
				Instance.LastRevealedRoomNumber = result;
			}
		}
		LastRevealedRoomNumber = 1;
		for (int l = 0; l < corridors.Length; l++)
		{
			Corridor corridor2 = corridors[l];
			if (corridor2.labelObjectSV == null)
			{
				corridor2.labelObjectSV = (GameObject)UnityEngine.Object.Instantiate(canvasLabelObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
				corridor2.labelObjectSV.transform.parent = corridors[l].transform;
				corridor2.labelObjectSV.transform.localPosition = new Vector3(0f, 0f, -55.5f);
				corridor2.labelObjectSV.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				corridor2.labelObjectSV.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}
			corridor2.labelObjectSV.transform.parent = corridors[l].transform;
			corridor2.labelObjectSV.transform.localPosition = new Vector3(0f, 0f, -55.5f);
			Text text3 = null;
			Transform transform4 = corridor2.labelObjectSV.transform.FindChild("label");
			if (transform4 != null)
			{
				transform4 = transform4.FindChild("Text");
				if (transform4 != null)
				{
					text3 = (corridor2.labelTextObject = transform4.gameObject.GetComponent<Text>());
				}
			}
			Door door = (Door)corridors[l].gameObject.GetComponentInChildren(typeof(Door));
			if (corridor2.IsAirlock)
			{
				text3.text = "a" + (l + 1);
				door.LabelSimple = "a" + (l + 1);
			}
			else
			{
				text3.text = "d" + (l + 1);
				door.LabelSimple = "d" + (l + 1);
			}
			string metaData2 = corridor2.GetMetaData("doornum");
			if (metaData2 != string.Empty && metaData2 != "0")
			{
				if (corridor2.IsAirlock)
				{
					text3.text = "a" + metaData2;
					door.LabelSimple = "a" + metaData2;
				}
				else
				{
					text3.text = "d" + metaData2;
					door.LabelSimple = "d" + metaData2;
				}
			}
			door.Label = text3.text;
		}
		leadInOpenCorridors = new List<Corridor>();
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount > GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots)
		{
			Debug.LogWarning(string.Format("More ship upgrades installed than should be!!! Should be {0}, but is {1}", GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots, GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount));
		}
		AddSoundSources();
		if (!GlobalSettings.IsTutorial)
		{
			HintManager.HintPanelGameObject = HintPanelGameObject;
			HintManager.AddAttentionObject(HintAttentionObject);
		}
		else
		{
			HintManager.HintPanelGameObject = TutorialHintPanelGameObject;
			HintManager.HintBackgroundObject = TutorialHintBackgroundObject;
			HintManager.AddAttentionObject(TutorialHintAttentionObject);
		}
		HintManager.FlushHints();
	}

	private void Start()
	{
		if (HintPanelGameObject != null)
		{
			HintManager.OnScreenPosition = HintManager.HintPanelGameObject.transform.position;
			HintManager.OffScreenPosition = new Vector3(HintManager.OnScreenPosition.x + 900f, HintManager.OnScreenPosition.y);
			Transform transform = HintManager.HintPanelGameObject.transform.transform.Find("HintText");
			if (transform != null)
			{
				HintManager.HintText = transform.gameObject.GetComponent<Text>();
			}
			Transform transform2 = transform.Find("BorderImage");
			if (transform2 != null)
			{
				HintManager.HintBorder = transform2.gameObject.GetComponent<Image>();
			}
			else
			{
				transform2 = HintManager.HintPanelGameObject.transform.Find("BorderImage");
				if (transform2 != null)
				{
					HintManager.HintBorder = transform2.gameObject.GetComponent<Image>();
				}
			}
			HintManager.defaultRingColor = HintManager.HintBorder.color;
		}
		_infestationType = new List<ShipInfestationType>();
		if (GlobalSettings.GameStartedFromGalaxyMap)
		{
			_infestationType = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationType;
		}
		else
		{
			_infestationType.Add(ShipInfestationType.Swarm);
		}
		int seed = (int)DateTime.Now.Ticks;
		if (SeedScrap != -1)
		{
			seed = SeedScrap;
		}
		System.Random random = new System.Random(seed);
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasHiddenRations)
		{
			actualHiddenLootItems = numberOfHiddenLootItems;
		}
		else
		{
			actualHiddenLootItems = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationHiddenMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationHiddenMax + 1);
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasVisibleRations)
		{
			actualVisibleLootItems = numberOfVisibleLootItems;
		}
		else
		{
			int num = UnityEngine.Random.Range((int)((float)Instance.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationRatioMin), (int)((float)Instance.rooms.Count() * GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationRatioMax));
			actualVisibleLootItems = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationVisibleMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.rationVisibleMax + 1) + num;
		}
		if (GlobalSettings.GameStartedFromGalaxyMap && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties != null)
		{
			actualHiddenLootItems = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.HiddenRationMin, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.HiddenRationMax + 1);
			actualVisibleLootItems = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.VisibleRationMin, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.EarlyPlayProperties.VisibleRationMax + 1);
		}
		if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
		{
			actualVisibleLootItems = (int)((float)actualVisibleLootItems * 2f);
			actualHiddenLootItems = (int)((float)actualHiddenLootItems * 2f);
		}
		if (!GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			float num2 = 1f;
			switch (GameSaveFile.Get("DIFF_SCRAP", 0))
			{
			case 1:
				num2 = 1.5f;
				break;
			case 2:
				num2 = 0.5f;
				break;
			}
			actualHiddenLootItems = (int)((float)actualHiddenLootItems * num2);
			actualVisibleLootItems = (int)((float)actualVisibleLootItems * num2);
			RandomlyPlaceLoot(random);
			droneManager.RandomlyPlaceLootableDrones();
		}
		else
		{
			int count = DungeonBuilder.Instance.builtRooms.Count;
			int droneNumberNext = 10;
			for (int i = 0; i < count; i++)
			{
				Room room = DungeonBuilder.Instance.builtRooms[i];
				string metaData = room.GetMetaData("rations");
				int result = 0;
				int.TryParse(metaData, out result);
				if (result > 0)
				{
					for (int j = 0; j < result; j++)
					{
						PlaceLootInRoom(room, false, random);
					}
				}
				metaData = room.GetMetaData("rationshidden");
				result = 0;
				int.TryParse(metaData, out result);
				if (result > 0)
				{
					for (int k = 0; k < result; k++)
					{
						PlaceLootInRoom(room, true, random);
					}
				}
				string metaData2 = room.GetMetaData("lootabledrones");
				int result2 = 0;
				int.TryParse(metaData2, out result2);
				if (result2 > 0)
				{
					for (int l = 0; l < result2; l++)
					{
						droneManager.PlaceLootableDroneInRoom(room, ref droneNumberNext, true);
					}
				}
				metaData2 = room.GetMetaData("lootabledronesdead");
				result2 = 0;
				int.TryParse(metaData2, out result2);
				if (result2 > 0)
				{
					for (int m = 0; m < result2; m++)
					{
						droneManager.PlaceLootableDroneInRoom(room, ref droneNumberNext, false);
					}
				}
			}
		}
		InitializeRoomPower();
		NavigationHelper.LoadAllWaypoints();
		if (GameplayManager.TransporterShipUpgradeActive())
		{
			needDisplayToFirstTransporterClearMsg = true;
			PlaceTransporterReceivers();
		}
		GameplayManager.Instance.GenerateEnemies();
		if (!GlobalSettings.IsTutorial && EnemyManager.Instance.ShouldSpawnDronesBestFriend())
		{
			SpawnDbfInRandomRoom();
		}
		if (!GameplayManager.TransporterShipUpgradeActive())
		{
			DungeonUniqueSetupPostProcess(false);
		}
		else
		{
			DungeonUniqueSetupPostProcess(true);
		}
		if (GlobalSettings.GameStartedFromGalaxyMap)
		{
			if (GlobalSettings.gameMode != GameModeEnum.DailyChallenge)
			{
				GlobalSettings.ShowingGameOverlayWindow = true;
				int num3 = GameSaveFile.Get("MISSIONS", 0);
				if (num3 > 1)
				{
					RevealUsefulRoom();
				}
				DungeonManagerGUI.Instance._shipsLogWindow = new ShipsLogsWindow();
				DungeonManagerGUI.Instance._shipsLogWindow.LoadShipsLogsForCurrentDungeon(RevealedRoom, revealedRoomType, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationTypeCount);
				switch (UnityEngine.Random.Range(0, 2))
				{
				case 0:
					GameAudio.Play2DSFX(GameAudio.SoundEnum.Docking1, DroneManager.Instance.SchematicCamera.gameObject, GameAudio.AlertVolume);
					break;
				case 1:
					GameAudio.Play2DSFX(GameAudio.SoundEnum.Docking2, DroneManager.Instance.SchematicCamera.gameObject, GameAudio.AlertVolume);
					break;
				}
			}
		}
		else
		{
			Application.runInBackground = GameSaveFile.Get("O_RIB", false);
		}
		PickupItemTemplate = (UpgradePickupItem)UnityEngine.Object.FindObjectOfType(typeof(UpgradePickupItem));
		PickupItemTemplate.gameObject.GetComponent<Renderer>().enabled = false;
		if (_infestationType == null || !_infestationType.Contains(ShipInfestationType.Swarm))
		{
			SwamSpawnVent[] array = vents;
			foreach (SwamSpawnVent swamSpawnVent in array)
			{
				swamSpawnVent.benign = true;
			}
		}
		if (GameplayManager.TransporterShipUpgradeActive())
		{
			TransporterShipUpgrade transporterShipUpgrade = null;
			List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
			int count2 = itemsCopy.Count;
			for (int num4 = 0; num4 < count2; num4++)
			{
				IInventoryItem inventoryItem = itemsCopy[num4];
				if (inventoryItem is BaseShipUpgrade && inventoryItem is TransporterShipUpgrade)
				{
					transporterShipUpgrade = (TransporterShipUpgrade)inventoryItem;
					break;
				}
			}
			GameObject asset = ResourceManager.GetAsset<GameObject>("TransporterReceiverPrefab");
			List<TransporterReceiver> list = new List<TransporterReceiver>();
			count2 = transporterRooms.Count;
			for (int num5 = 0; num5 < count2; num5++)
			{
				Room room2 = transporterRooms[num5];
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(asset, Vector3.zero, Quaternion.identity);
				TransporterReceiver item = (TransporterReceiver)gameObject.GetComponent(typeof(TransporterReceiver));
				list.Add(item);
				RoomItem roomItem = (RoomItem)gameObject.GetComponent(typeof(RoomItem));
				roomItem.roomLocation = room2;
				roomItem.transform.parent = room2.transform;
				Vector3 position = room2.transform.position;
				position.x -= room2.transform.localScale.x / 2f - 1f;
				position.y += room2.transform.localScale.y / 2f - 1f;
				roomItem.transform.position = position;
				room2.roomItems.Add(roomItem);
				int count3 = room2.roomItems.Count;
				for (int num6 = 0; num6 < count3; num6++)
				{
					RoomItem roomItem2 = room2.roomItems[num6];
					UnityEngine.Object component = roomItem2.GetComponent(typeof(SwamSpawnVent));
					if (component != null)
					{
						SwamSpawnVent swamSpawnVent2 = (SwamSpawnVent)component;
						swamSpawnVent2.benign = true;
					}
				}
			}
			transporterShipUpgrade.Reset();
			for (int num7 = 0; num7 < count2; num7++)
			{
				TransporterReceiver transporterReceiver = list[num7];
				if ((num7 > 0 && !hasExtraStartingReceiverRoom) || (num7 > 1 && hasExtraStartingReceiverRoom))
				{
					transporterReceiver.TakeOffline();
					transporterShipUpgrade.InitalizeReceiver(transporterReceiver);
					continue;
				}
				if (num7 == 1)
				{
					foreach (Corridor corridor in transporterReceiver.roomLocation.corridors)
					{
						corridor.door.close();
					}
				}
				transporterReceiver.roomLocation.ExternallyMarkAsOnSchematic();
				transporterShipUpgrade.BringReceiverOnline(transporterReceiver);
			}
		}
		if (GlobalSettings.UseCombinedTerminal)
		{
			terminalManager = new TerminalManager();
		}
		BoardingVessel.fadeIn();
		UpgradeSubSystems.AddRange(UnityEngine.Object.FindObjectsOfType<ShipUpgradeSubsystemObject>());
		if (!GlobalSettings.IsTutorial && !GameSaveFile.Get("WS_FIRSTDUN_TUT", false))
		{
			if (!GlobalSettings.ShowingGameOverlayWindow)
			{
				HintManager.BeginHintBatch();
				HintManager.PushHint(new SpacerHint(0.1f));
				HintManager.PushHint(new OpenD1Hint());
				HintManager.PushHint(new SpacerHint(1f));
				HintManager.PushHint(new SpaceToChangeViewHint());
				HintManager.EndHintBatch();
			}
			else
			{
				showQuickTutorialAfterLog = true;
			}
		}
		asRAmbience.Play();
		asMotherShipAmbience.transform.position = DroneManager.Instance.DroneCamera.transform.position;
		asMotherShipShipCreak.transform.position = DroneManager.Instance.CurrentDrone.transform.position;
		if (!DisableTrackingCommandCounts)
		{
			CheckTrackingDoorToggleHint();
		}
		else
		{
			isTrackingCommandCounts = false;
		}
		GlobalSettings.PerformanceFarView = GameSaveFile.Get("P_FARVIEW", 0);
		DroneUIObject.DisableHelpText = GameSaveFile.Get("HNT_DISABLE", false);
		int num8 = GameSaveFile.Get("Q_NOISE", 0);
		if (NoiseEffect.InstanceList != null)
		{
			int count4 = NoiseEffect.InstanceList.Count;
			for (int num9 = 0; num9 < count4; num9++)
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
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost && !GameSaveFile.Get("HNT_TRANSPOST", false))
		{
			HintManager.PushHint(new TransportOutpostHint());
		}
		if (menuPanel != null)
		{
			menuPanel.gameObject.SetActive(false);
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
		{
			Room room3 = transporterRooms[0];
			Vector3 position2 = DroneManager.Instance.SchematicCamera.transform.position;
			position2.x = room3.transform.position.x;
			position2.y = room3.transform.position.y;
			if (position2.y > svCameraCenter.y + 15f)
			{
				position2.y = svCameraCenter.y + 15f;
			}
			if (position2.y < svCameraCenter.y + -15f)
			{
				position2.y = svCameraCenter.y + -15f;
			}
			if (position2.x > svCameraCenter.x + 15f)
			{
				position2.x = svCameraCenter.x + 15f;
			}
			if (position2.x < svCameraCenter.x + -15f)
			{
				position2.x = svCameraCenter.x + -15f;
			}
			DroneManager.Instance.SchematicCamera.transform.position = position2;
		}
	}

	private void SpawnDbfInRandomRoom()
	{
		List<Room> list = rooms.ToList();
		list.Remove(BoardingVessel);
		foreach (Corridor corridor in BoardingVessel.corridors)
		{
			Room[] array = corridor.rooms;
			foreach (Room room in array)
			{
				list.Remove(room);
				foreach (Corridor corridor2 in room.corridors)
				{
					Room[] array2 = corridor2.rooms;
					foreach (Room item in array2)
					{
						list.Remove(item);
					}
				}
			}
		}
		Room room2 = null;
		for (int k = 0; k < 20; k++)
		{
			room2 = CommonMethods.PickRandomItem(list, _random);
			if (!(room2 is BoardingShip))
			{
				break;
			}
		}
		if (room2 != null)
		{
			Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(room2);
			EnemyManager.Instance.CreateDronesBestFriend(mainRoomWaypoint);
			UniverseSaveFile.Save("DBF_SPAWN", UniverseSaveFile.Get("DBF_SPAWN", 0) + 1);
		}
	}

	public void OnDestroy()
	{
		HintPanelGameObject = null;
		HintAttentionObject = null;
		TutorialHintPanelGameObject = null;
		TutorialHintAttentionObject = null;
		TutorialHintBackgroundObject = null;
		labelObject = null;
		SchematicBaseLight = null;
		scrapObjectPrefab = null;
		asRAmbience = null;
		asMotherShipAmbience = null;
		asMotherShipShipCreak = null;
		asRandomStaticAmbience = null;
		asPickup = null;
		Resources.UnloadUnusedAssets();
		ResourceManager.UnloadAsset("TransporterReceiverPrefab");
		ResourceManager.UnloadDungeonResources();
		RemoveSoundSources();
		Instance = null;
	}

	private void CheckTrackingDoorToggleHint()
	{
		isTrackingCommandCounts = GameSaveFile.Get("HNT_TOGGLEDOOR", 0) < 2;
		if (!isTrackingCommandCounts)
		{
			DisableTrackingCommandCounts = true;
			countOpenCloseCommands = 0;
		}
	}

	public void DronesInitialized()
	{
		if (GlobalSettings.GameStartedFromGalaxyMap)
		{
			TakeInventorySnapshot(ref missionStateStartup);
		}
	}

	private void TakeInventorySnapshot(ref MissionState missionState)
	{
		missionState = new MissionState();
		List<Drone> list = null;
		List<Drone> list2 = null;
		if (!GlobalSettings.CommandeeringShip)
		{
			missionState.shipState.scrapMax = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
			missionState.shipState.pfuelReserveMax = GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax;
		}
		else
		{
			missionState.shipState.scrapMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax;
			missionState.shipState.pfuelReserveMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax;
		}
		if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null)
		{
			foreach (SlotInfo slot in GlobalSettings.GameState.ThePlayer.MyShip.slotList)
			{
				if (missionState.shipState.slotInfoList == null)
				{
					missionState.shipState.slotInfoList = new List<MissionState.SlotState>();
				}
				missionState.shipState.slotInfoList.Add(new MissionState.SlotState(slot));
			}
		}
		if (GlobalSettings.MissionStarted)
		{
			List<Drone> transportableDrones = null;
			List<Drone> collectedDrones = null;
			list2 = GetDronesNotAbleToReturnToMotherShip(out transportableDrones, out collectedDrones);
			list = ((!GlobalSettings.CommandeeringShip) ? droneManager.dronesList.Where((Drone x) => x != null && (!x.IsDead || x.CanBeTowed || x.IsBeingTowed) && x.IsVisible && x.CurrentRoom == BoardingVessel).ToList() : droneManager.dronesList);
			List<Drone> list3 = ((!GlobalSettings.CommandeeringShip) ? droneManager.LootableDronesList.Where((Drone x) => x != null && x.CurrentRoom == BoardingVessel).ToList() : droneManager.LootableDronesList.Where((Drone x) => x != null && x.Found).ToList());
			if (list3.Count > 0)
			{
				list.AddRange(list3);
			}
		}
		else
		{
			list = droneManager.dronesList;
		}
		foreach (Drone item in list)
		{
			if (list2 == null || (!list2.Contains(item) && !item.ignoreOnExit))
			{
				missionState.AddDrone(item);
			}
		}
		foreach (IInventoryItem item2 in GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy)
		{
			if (item2 is BaseShipUpgrade && !((BaseShipUpgrade)item2).IsPermanentUpgrade)
			{
				missionState.AddShipUpgrade((BaseShipUpgrade)item2);
			}
		}
		foreach (ShipUpgradeInGameObject shipUpgrade in ShipUpgrades)
		{
			if (BoardingVessel.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds))
			{
				if (shipUpgrade.ThisUpgrade == null || !shipUpgrade.ThisUpgrade.IsPermanentUpgrade)
				{
					missionState.AddShipUpgrade(shipUpgrade.ThisUpgrade);
				}
			}
			else if (GlobalSettings.CommandeeringShip && shipUpgrade.ThisUpgrade != null && shipUpgrade.ThisUpgrade.BrokenState != BrokenStateEnum.Broken && (shipUpgrade.ThisUpgrade == null || !shipUpgrade.ThisUpgrade.IsPermanentUpgrade))
			{
				missionState.AddShipUpgrade(shipUpgrade.ThisUpgrade);
			}
		}
		if (GlobalSettings.GameState.ThePlayer != null)
		{
			if (!GlobalSettings.CommandeeringShip)
			{
				missionState.DungeonInfo = GlobalSettings.GameState.ThePlayer.MyShip;
			}
			else
			{
				missionState.DungeonInfo = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
			}
		}
	}

	private void PlaceTransporterReceivers()
	{
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(DungeonPowerInlet));
		if (array.Length > 0)
		{
			Room room = null;
			bool flag = false;
			int num = 0;
			int num2 = 0;
			do
			{
				flag = false;
				int num3 = UnityEngine.Random.Range(0, array.Length);
				room = ((DungeonPowerInlet)array[num3]).roomLocation;
				if (num2 == 0 && room.transform.localScale.x <= 3f && room.transform.localScale.y <= 3f)
				{
					flag = true;
					num++;
				}
				else if (num2 == 1 && room.transform.localScale.x <= 2f && room.transform.localScale.y <= 2f)
				{
					flag = true;
					num++;
				}
				else if (num2 == 3 && ((room.transform.localScale.x <= 2f && room.transform.localScale.y <= 3f) || (room.transform.localScale.x <= 3f && room.transform.localScale.y <= 2f)))
				{
					flag = true;
					num++;
				}
				else if (num2 == 4 && (room.transform.localScale.x <= 2f || room.transform.localScale.y <= 2f))
				{
					flag = true;
					num++;
				}
				if (flag && num >= 100 && num2 < 4)
				{
					num2++;
					num = 0;
				}
			}
			while (flag && num < 100);
			transporterRooms.Add(room);
			if (room.environmentModelsLarge != null)
			{
				room.environmentModelsLarge.Clear();
			}
			if (room.environmentModelsLargeRenderers != null)
			{
				int count = room.environmentModelsLargeRenderers.Count;
				for (int i = 0; i < count; i++)
				{
					UnityEngine.Object.Destroy(room.environmentModelsLargeRenderers.ElementAt(i).Key);
				}
				room.environmentModelsLarge.Clear();
			}
			List<Room> adjacentRooms = room.getAdjacentRooms();
			List<Corridor> list = new List<Corridor>();
			List<Corridor> list2 = new List<Corridor>();
			foreach (Room item in adjacentRooms)
			{
				if (!(item != BoardingVessel))
				{
					continue;
				}
				Corridor connectingCooridor = room.GetConnectingCooridor(item);
				if (connectingCooridor != null)
				{
					if (connectingCooridor.door.state == DoorState.Open && !connectingCooridor.IsAirlock)
					{
						list.Add(connectingCooridor);
					}
					else if (!connectingCooridor.IsAirlock)
					{
						list2.Add(connectingCooridor);
					}
				}
			}
			Room room2 = null;
			if (list.Count > 0)
			{
				if (list.Count > 1)
				{
					int num4 = UnityEngine.Random.Range(0, list.Count + 1);
					for (int j = 0; j < list.Count; j++)
					{
						if (j != num4)
						{
							list[j].door.close();
						}
						else
						{
							room2 = list[j].getOtherRoom(room);
						}
					}
				}
			}
			else
			{
				int index = UnityEngine.Random.Range(0, list2.Count);
				if (list2[index] != null)
				{
					if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost && list2[index].door != null)
					{
						list2[index].door.open();
					}
					room2 = list2[index].getOtherRoom(room);
				}
			}
			if (room2 != null)
			{
				foreach (Waypoint waypoint in room2.Waypoints)
				{
					waypoint.WaypointType = WaypointTypeEnum.None;
				}
			}
		}
		Room room3 = null;
		UnityEngine.Object[] array2 = UnityEngine.Object.FindObjectsOfType(typeof(Room));
		if (UnityEngine.Random.Range(0, 3) == 0)
		{
			do
			{
				int num5 = UnityEngine.Random.Range(0, array2.Length);
				room3 = (Room)array2[num5];
			}
			while (transporterRooms.Contains(room3) && !(room3 is BoardingShip) && room3 != BoardingVessel && room3.Label.ToLower() != "r1");
			if (room3 != null && !(room3 is BoardingShip))
			{
				if (room3.boardingVessel)
				{
					int num6 = 0;
					num6++;
				}
				hasExtraStartingReceiverRoom = true;
				foreach (Corridor corridor in room3.corridors)
				{
					corridor.door.close();
				}
				transporterRooms.Add(room3);
			}
			room3 = null;
		}
		int num7 = 1;
		num7 = UnityEngine.Random.Range(Mathf.FloorToInt(rooms.Count() / 10) + 1, Mathf.FloorToInt(rooms.Count() / 5) + 1);
		if (num7 > array2.Length - transporterRooms.Count - 2)
		{
			num7 = array2.Length - transporterRooms.Count - 2;
		}
		if (num7 > 0)
		{
			for (int k = 0; k < num7; k++)
			{
				room3 = null;
				do
				{
					int num8 = UnityEngine.Random.Range(0, array2.Length);
					room3 = (Room)array2[num8];
				}
				while (transporterRooms.Contains(room3) || room3.boardingVessel || room3.Label.ToLower() == "r1");
				if (room3 != null)
				{
					transporterRooms.Add(room3);
				}
			}
		}
		foreach (Room transporterRoom in transporterRooms)
		{
			if (!(transporterRoom != null))
			{
				continue;
			}
			foreach (Waypoint waypoint2 in transporterRoom.Waypoints)
			{
				waypoint2.WaypointType = WaypointTypeEnum.None;
			}
		}
	}

	public void InitializeRoomPower()
	{
		int num = rooms.Length;
		for (int i = 0; i < num; i++)
		{
			Room room = rooms[i];
			if (!(room is BoardingShip))
			{
				room.gameObject.GetComponent<Renderer>().enabled = false;
				room.power(null, false);
			}
			else
			{
				room.power(null, true);
			}
		}
		UpdateCameraView();
	}

	public void UpdateCameraView()
	{
		lastPositionCurrentDrone = Vector3.zero;
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			SchematicBaseLight.enabled = false;
			asRAmbience.Play();
			asMotherShipAmbience.Play();
			if (DroneManager.Instance.CurrentDrone != null)
			{
				asMotherShipShipCreak.transform.position = DroneManager.Instance.CurrentDrone.transform.position;
			}
		}
		else
		{
			asRAmbience.Pause();
			asMotherShipAmbience.transform.position = DroneManager.Instance.SchematicCamera.transform.position;
			asMotherShipShipCreak.transform.position = DroneManager.Instance.SchematicCamera.transform.position;
			if (asRandomStaticAmbience.isPlaying)
			{
				asRandomStaticAmbience.Stop();
			}
		}
		int num = rooms.Length;
		for (int i = 0; i < num; i++)
		{
			Room room = rooms[i];
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				if (!(room is BoardingShip))
				{
					room.gameObject.GetComponent<Renderer>().enabled = false;
				}
				room.labelTextObject.enabled = false;
			}
			else if (room.onSchematic)
			{
				room.labelTextObject.enabled = true;
			}
			room.RefreshCameraView();
		}
		num = corridors.Length;
		for (int j = 0; j < num; j++)
		{
			Corridor corridor = corridors[j];
			Text labelTextObject = corridor.labelTextObject;
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				corridor.labelObjectSV.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				corridor.labelTextObject.color = corridor.labelColorDroneview;
				if (currentRoom != null && corridor.containsRoom(currentRoom))
				{
					corridor.Show();
					if (corridor.door != null)
					{
						corridor.door.hide(false);
					}
				}
				else
				{
					corridor.Hide();
					if (corridor.door != null)
					{
						corridor.door.hide(true);
					}
				}
			}
			else
			{
				corridor.labelObjectSV.transform.localScale = new Vector3(1f, 1f, 1f);
				if (corridor.door.IsDisconnected)
				{
					corridor.labelTextObject.color = corridor.door.DisconnectedColor;
				}
				else if (corridor.door.IsDead)
				{
					corridor.labelTextObject.color = corridor.door.DeadColor;
				}
				else
				{
					corridor.labelTextObject.color = corridor.door.SchematicViewColor;
				}
				if (corridor.onSchematic)
				{
					corridor.Show();
					corridor.labelTextObject.enabled = true;
					if (corridor.door != null)
					{
						corridor.door.hide(false);
					}
				}
				else
				{
					corridor.Hide();
					corridor.labelTextObject.enabled = false;
					if (corridor.door != null)
					{
						corridor.door.hide(true);
					}
				}
			}
			corridor.UpdateCameraView();
		}
		num = doors.Length;
		for (int k = 0; k < num; k++)
		{
			doors[k].swichCameraView();
		}
		num = roomItems.Length;
		for (int l = 0; l < num; l++)
		{
			roomItems[l].UpdateCameraView();
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			SchematicBaseLight.enabled = true;
		}
	}

	private void Update()
	{
		if (LogUI.Instance != null && LogUI.Instance.IsShowing)
		{
			if (!LogUI.Instance.PumpUpdate())
			{
				return;
			}
			if (LogUI.Instance.Tag == 1)
			{
				if (GlobalSettings.ShowingGameOverlayWindow && !GlobalSettings.GameIsOver)
				{
					GlobalSettings.ShowingGameOverlayWindow = false;
					DungeonManagerGUI.Instance.Disable();
					hasStarted = true;
					if (showQuickTutorialAfterLog)
					{
						HintManager.BeginHintBatch();
						HintManager.PushHint(new SpacerHint(0.1f));
						HintManager.PushHint(new OpenD1Hint());
						HintManager.PushHint(new SpacerHint(1f));
						HintManager.PushHint(new SpaceToChangeViewHint());
						HintManager.EndHintBatch();
						showQuickTutorialAfterLog = false;
					}
				}
			}
			else if (LogUI.Instance.Tag == 2)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					GalaxyMapManager.IsSpaceDownAfterDungeon = true;
					GalaxyMapManager.SpaceDownTimer = 0f;
				}
				if (GlobalSettings.gameMode != GameModeEnum.DailyChallenge)
				{
					DungeonManagerGUI.Instance.derelictStatisticsWindow.ForceText(">\r\n> Reconnecting to mothership...");
					isShowingReconnectingMessage = true;
					GameplayManager.Instance.ReturnToHomeShip();
				}
			}
			else if (LogUI.Instance.Tag == 3)
			{
				GameplayManager.Instance.ShowPauseMenuPostDeath(false);
			}
		}
		if (GlobalSettings.IsTutorial)
		{
			TutorialManagerClass.Instance.Update();
		}
		if (isWaitingToCleanupMemory)
		{
			timerMemoryCleanupAfterLoad -= Time.deltaTime;
			if (timerMemoryCleanupAfterLoad <= 0f)
			{
				isWaitingToCleanupMemory = false;
				Resources.UnloadUnusedAssets();
			}
		}
		if (ignoreAllInputForAMoment)
		{
			timeIgnoreAllInput -= Time.deltaTime;
			if (!(timeIgnoreAllInput <= 0f))
			{
				ConsoleWindow3.Instance.IsDisabled = true;
				return;
			}
			ignoreAllInputForAMoment = false;
			ConsoleWindow3.Instance.IsDisabled = false;
		}
		if (!GlobalSettings.IsGamePaused && IsExiting)
		{
			ProcessExit();
		}
		if (!GlobalSettings.IsGamePaused && !DungeonManagerGUI.Instance.isShowingDerelictStatisticsWindow && !isShowingReconnectingMessage)
		{
			if (needDisplayToFirstTransporterClearMsg)
			{
				SystemMessageManager.ShowSystemMessage("Room " + transporterRooms[0].LabelSimple + " is clear of infestations and safe for transport", ConsoleMessageType.Benefit);
				needDisplayToFirstTransporterClearMsg = false;
			}
			if (!GlobalSettings.IsTutorial && GlobalSettings.MissionStarted && GlobalSettings.OwnsDronesBestFriend)
			{
				_ownedDbfNonBarkTimer -= Time.deltaTime;
				if (_ownedDbfNonBarkTimer <= 0f)
				{
					_ownedDbfNonBarkTimer = 420f;
					int num = _random.Next(1, 101);
					if (num < 30)
					{
						PlayDbfNonBark();
					}
				}
			}
			HintManager.Update();
			if (GlobalSettings.cameraMode == CameraMode.Drone && droneManager.CurrentDrone != null)
			{
				if (lastPositionCurrentDrone != droneManager.CurrentDrone.transform.position)
				{
					Corridor corridor = null;
					Corridor[] array = corridors;
					foreach (Corridor corridor2 in array)
					{
						if (corridor2.GetComponent<Collider>().bounds.Contains(droneManager.CurrentDrone.transform.position))
						{
							corridor = corridor2;
							corridor2.activateRooms();
							break;
						}
					}
					if (currentRoom == null || currentRoom != droneManager.CurrentDrone.CurrentRoom)
					{
						Room[] array2 = rooms;
						foreach (Room room in array2)
						{
							if (room.GetComponent<Collider>().bounds.Contains(droneManager.CurrentDrone.transform.position))
							{
								currentRoom = room;
								toggleCorridorsVisible();
								break;
							}
						}
					}
					if (corridor == null)
					{
						Room[] array3 = rooms;
						foreach (Room room2 in array3)
						{
							if (room2 is BoardingShip)
							{
								continue;
							}
							if (room2 == currentRoom)
							{
								room2.fadeIn();
								continue;
							}
							bool flag = false;
							if (GlobalSettings.PerformanceFarView <= 1 && currentRoom != null)
							{
								int count = currentRoom.corridors.Count;
								for (int l = 0; l < count; l++)
								{
									if (currentRoom.corridors[l].door.state == DoorState.Open && room2 == currentRoom.corridors[l].getOtherRoom(currentRoom) && (GlobalSettings.PerformanceFarView != 0 || Vector3.Distance(DroneManager.Instance.CurrentDrone.transform.position, room2.transform.position) < 10f))
									{
										room2.fadeIn();
										flag = true;
										break;
									}
								}
							}
							if (!flag)
							{
								room2.FadeOut();
							}
						}
					}
					lastPositionCurrentDrone = droneManager.CurrentDrone.transform.position;
				}
				if (!asRandomStaticAmbience.isPlaying)
				{
					nextRandomAmbientSound -= Time.deltaTime;
				}
				if (nextRandomAmbientSound <= 0f)
				{
					switch (UnityEngine.Random.Range(0, 6))
					{
					case 0:
						soundRAmbientStatic = GameAudio.SoundEnum.Remote_A_StaticA;
						break;
					case 1:
						soundRAmbientStatic = GameAudio.SoundEnum.Remote_A_StaticB;
						break;
					case 2:
						soundRAmbientStatic = GameAudio.SoundEnum.Remote_A_StaticC;
						break;
					case 3:
						soundRAmbientStatic = GameAudio.SoundEnum.Remote_A_StaticD;
						break;
					case 4:
						soundRAmbientStatic = GameAudio.SoundEnum.Remote_A_StaticE;
						break;
					default:
						soundRAmbientStatic = GameAudio.SoundEnum.None;
						break;
					}
					if (soundRAmbientStatic != GameAudio.SoundEnum.None)
					{
						asRandomStaticAmbience.clip = GameAudio.GetClip(soundRAmbientStatic);
						asRandomStaticAmbience.volume = GameAudio.VolumeMultiplier(soundRAmbientStatic, GameAudio.AmbienceVolume);
						asRandomStaticAmbience.Play();
					}
					else
					{
						asRandomStaticAmbience.clip = null;
					}
					nextRandomAmbientSound = (float)UnityEngine.Random.Range(1000, 5000) / 1000f;
				}
			}
			else if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				int count2 = droneManager.dronesList.Count;
				for (int m = 0; m < count2; m++)
				{
					Drone drone = droneManager.dronesList[m];
					if (!drone.IsDead && drone.CurrentRoom != null && !drone.CurrentRoom.isExplored)
					{
						drone.CurrentRoom.ExternallyMarkAsExplored();
					}
				}
				if (!GameplayManager.Instance.isCommandeering && GameplayManager.Instance.WindowState != GameWindowStates.ShowHelpManual && !DroneManager.Instance.swapUIShown && !GlobalSettings.GameIsOver && !CommonMethods.AnyModifierKeysPressed() && !DialogUI.Instance.IsShowing && !AliasUI.Instance.IsShowing)
				{
					bool flag2 = false;
					Vector3 position = droneManager.SchematicCamera.transform.position;
					if (Input.GetButton("Up"))
					{
						position.y += Time.deltaTime * 9f;
						if (position.y > svCameraCenter.y + 15f)
						{
							position.y = svCameraCenter.y + 15f;
							if (!playedPanErrorSound)
							{
								playedPanErrorSound = true;
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							playedPanErrorSound = false;
						}
						flag2 = true;
					}
					else if (Input.GetButton("Down"))
					{
						position.y -= Time.deltaTime * 9f;
						if (position.y < svCameraCenter.y + -15f)
						{
							position.y = svCameraCenter.y + -15f;
							if (!playedPanErrorSound)
							{
								playedPanErrorSound = true;
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							playedPanErrorSound = false;
						}
						flag2 = true;
					}
					else if (Input.GetButton("Right"))
					{
						position.x += Time.deltaTime * 9f;
						if (position.x > svCameraCenter.x + 15f)
						{
							position.x = svCameraCenter.x + 15f;
							if (!playedPanErrorSound)
							{
								playedPanErrorSound = true;
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							playedPanErrorSound = false;
						}
						flag2 = true;
					}
					else if (Input.GetButton("Left"))
					{
						position.x -= Time.deltaTime * 9f;
						if (position.x < svCameraCenter.x + -15f)
						{
							position.x = svCameraCenter.x + -15f;
							if (!playedPanErrorSound)
							{
								playedPanErrorSound = true;
								GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
							}
						}
						else
						{
							playedPanErrorSound = false;
						}
						flag2 = true;
					}
					if (flag2)
					{
						droneManager.SchematicCamera.transform.position = position;
						if (MenuBackground.Instance != null)
						{
							Vector3 position2 = droneManager.SchematicCamera.transform.position;
							position2.z = MenuBackground.Instance.gameObject.transform.position.z;
							MenuBackground.Instance.gameObject.transform.position = position2;
						}
						GameplayManager.Instance.arrowPressedOnSchematic = true;
						GameplayManager.Instance.SVInfoUI.ShowCtrlHint();
					}
					else
					{
						playedPanErrorSound = false;
						if (Input.GetKeyDown(KeyCode.Home))
						{
							droneManager.SchematicCamera.transform.position = svCameraCenter;
							if (MenuBackground.Instance != null)
							{
								Vector3 position3 = droneManager.SchematicCamera.transform.position;
								position3.z = MenuBackground.Instance.gameObject.transform.position.z;
								MenuBackground.Instance.gameObject.transform.position = position3;
							}
						}
						GameplayManager.Instance.arrowPressedOnSchematic = false;
						GameplayManager.Instance.SVInfoUI.HideCtrlHint();
					}
				}
				if (GlobalSettings.cheatMode && Input.GetMouseButtonDown(0))
				{
					int num2 = LayerMask.NameToLayer("DoorLayer");
					int layerMask = 1 << num2;
					RaycastHit hitInfo = default(RaycastHit);
					Ray ray = droneManager.SchematicCamera.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, layerMask) && hitInfo.transform != null)
					{
						Door door = (Door)hitInfo.transform.parent.gameObject.GetComponent(typeof(Door));
						if (door != null && door.powered)
						{
							if (door.state == DoorState.Closed)
							{
								door.open();
							}
							else
							{
								door.close();
							}
						}
					}
				}
			}
			if (GlobalSettings.MissionStarted)
			{
				DungeonInfo dungeonInfo = null;
				if (GlobalSettings.GameState.ThePlayer != null)
				{
					dungeonInfo = GlobalSettings.GameState.ThePlayer.MyShip;
				}
				if (dungeonInfo != null)
				{
					dungeonInfo.TimeInMission += Time.deltaTime;
					if (!GlobalSettings.IsTutorial)
					{
						bool videoSignalLost = dungeonInfo.VideoSignalLost;
						dungeonInfo.VideoFailManager.Update();
						if (!videoSignalLost && dungeonInfo.VideoSignalLost)
						{
							if (!GameSaveFile.Get("HNT_SHPWR", false))
							{
								GalaxyMapManager.ShipDeteriorating = true;
							}
							UniverseSaveFile.Save(GlobalSettings.GameState.ThePlayer.MyShip.GroupKey, "SVVIDVFAIL", true);
						}
						if (!dungeonInfo.VideoSignalLostWarningTemp)
						{
							if (!ignoreNextMainVideoStatusMessage)
							{
								if (!dungeonInfo.VideoSignalLost && videoSignalLost)
								{
									SystemMessageManager.ShowSystemMessage("Main video signal restored.", ConsoleMessageType.Notification);
								}
								else if (dungeonInfo.VideoSignalLost && !videoSignalLost)
								{
									SystemMessageManager.ShowSystemMessage("Main video signal lost.", ConsoleMessageType.Warning);
								}
							}
							else
							{
								ignoreNextMainVideoStatusMessage = false;
							}
						}
						else if (GlobalSettings.cameraMode == CameraMode.Drone && dungeonInfo.VideoSignalLost && !videoSignalLost)
						{
							ignoreNextMainVideoStatusMessage = true;
							SystemMessageManager.ShowSystemMessage("Main video signal weakening", ConsoleMessageType.Warning);
						}
					}
				}
			}
		}
		else if (!DungeonManagerGUI.Instance.isShowingDerelictStatisticsWindow)
		{
		}
		asRAmbience.volume = GameAudio.VolumeMultiplier(soundRAmbientHost, GameAudio.AmbienceVolume);
		asRandomStaticAmbience.volume = GameAudio.VolumeMultiplier(soundRAmbientStatic, GameAudio.AmbienceVolume);
		asMotherShipAmbience.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.A_MotherShip, GameAudio.AmbienceVolume);
		asMotherShipShipCreak.volume = GameAudio.VolumeMultiplier(soundShipCreak, GameAudio.AmbienceVolume);
	}

	private void toggleCorridorsVisible()
	{
		int num = corridors.Length;
		for (int i = 0; i < num; i++)
		{
			Corridor corridor = corridors[i];
			if (GlobalSettings.cameraMode != CameraMode.Drone)
			{
				continue;
			}
			if (corridor.containsRoom(currentRoom))
			{
				if (!corridor.IsTileVisible)
				{
					corridor.Show();
					if (corridor.door != null)
					{
						corridor.door.hide(false);
					}
				}
			}
			else if (corridor.IsTileVisible)
			{
				corridor.Hide();
				if (corridor.door != null)
				{
					corridor.door.hide(true);
				}
			}
		}
	}

	private List<DungeonTerminalType> dungeonTerminalTypesActive()
	{
		List<DungeonTerminalType> list = new List<DungeonTerminalType>();
		RoomItem[] array = roomItems;
		foreach (RoomItem roomItem in array)
		{
			if (roomItem is DungeonTerminal && ((DungeonTerminal)roomItem).isActivated() && !list.Contains(((DungeonTerminal)roomItem).type))
			{
				list.Add(((DungeonTerminal)roomItem).type);
			}
		}
		return list;
	}

	public static LootItem[] getPossibleLootItems()
	{
		return UnityEngine.Object.FindObjectsOfType(typeof(LootItem)) as LootItem[];
	}

	public void RegisterCommands()
	{
		List<CommandDefinition> commands = CommandHelper.GetCommands("DungeonManager");
		if (GlobalSettings.GameStartedFromGalaxyMap && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Station))
		{
			commands.AddRange(CommandHelper.GetCommands("DungeonManager.Derelict"));
		}
		foreach (CommandDefinition item in commands)
		{
			CommandTree.AddCommand(item, CommandTypeEnum.ObjectCommand, this);
		}
	}

	public List<CommandDefinition> QueryAvailableCommands()
	{
		if (!GlobalSettings.UseCommandTree)
		{
			if (baseCommandList == null)
			{
				baseCommandList = new List<CommandDefinition>();
				baseCommandList.AddRange(CommandHelper.GetCommands("DungeonManager"));
			}
			if (commandList == null)
			{
				commandList = new List<CommandDefinition>();
			}
			else
			{
				commandList.Clear();
			}
			commandList.AddRange(baseCommandList);
			if (GlobalSettings.GameStartedFromGalaxyMap && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Derelict || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Station))
			{
				commandList.AddRange(CommandHelper.GetCommands("DungeonManager.Derelict"));
			}
			if (!GlobalSettings.UseCombinedTerminal)
			{
				bool flag = false;
				bool flag2 = false;
				List<DungeonTerminalType> list = dungeonTerminalTypesActive();
				if (list.Count > 0)
				{
					foreach (DungeonTerminalType item in list)
					{
						switch (item)
						{
						case DungeonTerminalType.Scan:
							if (!flag)
							{
								flag = true;
								commandList.AddRange(CommandHelper.GetCommands("DungeonTerminalType.Scan"));
							}
							break;
						case DungeonTerminalType.defense:
							if (!flag2)
							{
								flag2 = true;
								commandList.AddRange(CommandHelper.GetCommands("DungeonTerminalType.defense"));
							}
							break;
						}
					}
				}
			}
		}
		return commandList;
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			return QueryAvailableCommands();
		}
		return new List<CommandDefinition>();
	}

	public virtual List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return new List<CommandDefinition>();
	}

	public void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "alias":
		{
			command.Handled = true;
			if (command.Arguments == null || command.Arguments.Count == 0)
			{
				ConsoleWindow3.Instance.IsVisible = false;
				AliasUI.Instance.Show();
				break;
			}
			string text4 = string.Empty;
			foreach (string argument in command.Arguments)
			{
				if (text4.Length > 0)
				{
					text4 += " ";
				}
				text4 += argument;
			}
			string[] array13 = text4.Split('=');
			if (text4.Length < 3 || !text4.Contains("=") || array13.Length != 2)
			{
				SendConsoleMessage("Invalid 'alias' command provided.  'alias name=value' format expected.\r\nUse 'help alias' for more information.", ConsoleMessageType.Warning);
				break;
			}
			if (CommandHelper.DoesAliasCommandExist(array13[0]))
			{
				SendConsoleMessage(string.Format("There is already an alias defined by the name of '{0}'.\r\nUse 'alias' to open the editor to edit an exiting command.", array13[0]), ConsoleMessageType.Warning);
				break;
			}
			FileStream fileStream = null;
			fileStream = File.Open(GameFileHelper.AliasFullPath(), FileMode.Append);
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(Environment.NewLine);
				byte[] bytes2 = Encoding.UTF8.GetBytes(text4);
				int count = bytes2.Length;
				fileStream.Write(bytes2, 0, count);
				fileStream.Write(bytes, 0, bytes.Length);
				SendConsoleMessage(string.Format("'{0}' command added.", array13[0]), ConsoleMessageType.Benefit);
			}
			catch (Exception ex)
			{
				Debug.LogError(string.Format("Error while writing alias file!  Exception: {0}", ex.Message));
				break;
			}
			finally
			{
				try
				{
					fileStream.Close();
				}
				catch (Exception)
				{
				}
			}
			CommandHelper.ReloadAliasFile(false);
			break;
		}
		case "degauss":
			command.Handled = true;
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				SendConsoleMessage("Switch views to use this feature.", ConsoleMessageType.Warning);
			}
			else if (DroneManager.Instance.CurrentDrone != null && !DroneManager.Instance.CurrentDrone.IsDead)
			{
				HUDCameraController.Instance.Degauss(DroneManager.Instance.CurrentDrone.DroneNumber);
			}
			break;
		case "static":
			command.Handled = true;
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				SendConsoleMessage("Switch views to use this feature.", ConsoleMessageType.Warning);
			}
			else
			{
				HUDOnlyCameraController.Instance.FireStaticOnDisabled(DroneManager.Instance.CurrentDrone.DroneNumber);
			}
			break;
		case "open":
		{
			if (GlobalSettings.MissionStarted && command.Arguments.Count == 1 && command.Arguments[0].ToLower() == "all")
			{
				int num23 = 0;
				int num24 = 0;
				Door[] array18 = doors;
				foreach (Door door8 in array18)
				{
					if (!door8.IsDead && door8.state == DoorState.Closed)
					{
						if (door8.powered && !door8.corridor.IsAirlock)
						{
							door8.open();
							num23++;
						}
						else if (door8.IsDisconnected)
						{
							num24++;
						}
					}
				}
				if (num23 > 0)
				{
					SendConsoleMessage(num23 + " doors opened", ConsoleMessageType.Info);
				}
				if (num24 > 0)
				{
					SendConsoleMessage(num24 + " doors didn't respond", ConsoleMessageType.Warning);
				}
				command.Handled = true;
				break;
			}
			bool flag15 = false;
			if (command.Arguments.Count == 1 && command.Arguments[0].Length == 2 && (command.Arguments[0][0] == 'a' || command.Arguments[0][0] == 'A') && !GameSaveFile.Get("WS_ALOCK_AL", false) && (command.Arguments[0][1] == 'l' || command.Arguments[0][1] == 'L'))
			{
				if (!GameSaveFile.Get("HNT_DISABLE", false))
				{
					SendConsoleMessage("Warning: Did you mean a1 (\"a one\")?", ConsoleMessageType.Warning);
					SendConsoleMessage("This warning will not appear again", ConsoleMessageType.Info);
					command.Handled = true;
					flag15 = true;
				}
				GameSaveFile.Save("WS_ALOCK_AL", true);
			}
			if (!flag15 && command.Arguments.Count > 0)
			{
				string text5 = string.Empty;
				bool flag16 = false;
				foreach (string argument2 in command.Arguments)
				{
					string text6 = argument2.ToLower();
					if (text6.StartsWith("r"))
					{
						Room[] array19 = rooms;
						foreach (Room room17 in array19)
						{
							if (!room17.Label.Equals(text6, StringComparison.InvariantCultureIgnoreCase))
							{
								continue;
							}
							foreach (Corridor corridor in room17.corridors)
							{
								if (!corridor.door.IsDead && corridor.door.state == DoorState.Closed)
								{
									if (corridor.door.powered && (!corridor.IsAirlock || Instance.BoardingVessel.CurrentAirlock == corridor))
									{
										corridor.door.open();
									}
									else if (corridor.door.IsDisconnected)
									{
										SendConsoleMessage("Door not responding: " + corridor.door.Label, ConsoleMessageType.Warning);
									}
									command.Handled = true;
								}
							}
							ConsoleWindow3.SendConsoleResponse(string.Format("all doors to room '{0}' now open", room17.Label), ConsoleMessageType.Warning);
						}
						continue;
					}
					if (isTrackingCommandCounts && !flag16)
					{
						countOpenCloseCommands++;
						flag16 = true;
					}
					Door[] array20 = doors;
					foreach (Door door9 in array20)
					{
						if (!(door9.LabelSimple.ToLower() == text6))
						{
							continue;
						}
						if (isTrackingCommandCounts && countOpenCloseCommands >= 10)
						{
							text5 = text5 + text6 + " ";
						}
						if (door9.powered)
						{
							if (door9.state == DoorState.Closed)
							{
								bool flag17 = false;
								bool flag18 = false;
								if (door9.IsDead || door9.IsDisconnected)
								{
									SendConsoleMessage("Door not responding: " + door9.Label, ConsoleMessageType.Warning);
								}
								else if (door9.corridor != null && door9.corridor.LeadsIntoShip)
								{
									flag18 = true;
									if (!GlobalSettings.MissionStarted)
									{
										GameplayManager.Instance.StartMission();
										SendConsoleMessage("Mission Started", ConsoleMessageType.Healthy);
										HintManager.HintCompleted(typeof(OpenD1Hint));
									}
								}
								if (door9.corridor.IsAirlock && !hasTestedForAirlockWarning && !flag18)
								{
									if ((!command.RequestConfirmed && GameSaveFile.Get("DIFF_W_AR", false)) || !GameSaveFile.Get("WS_ALOCK", false))
									{
										if (!GameSaveFile.Get("HNT_DISABLE", false))
										{
											SendConsoleMessage("Warning: opening airlock will depressurize room", ConsoleMessageType.Warning);
											SendConsoleMessage("Unsecured contents will be evacuated to space", ConsoleMessageType.Warning);
											SendConsoleMessage("Re-issue command to open airlock", ConsoleMessageType.Info);
											SendConsoleMessage("This warning will not appear again", ConsoleMessageType.Info);
											command.RequestConfirmation = true;
											flag17 = true;
										}
										GameSaveFile.Save("WS_ALOCK", true);
									}
									if (!GameSaveFile.Get("DIFF_W_AR", false))
									{
										hasTestedForAirlockWarning = true;
									}
								}
								if (!flag17)
								{
									door9.open();
								}
								command.Handled = true;
							}
							else
							{
								SendConsoleMessage(string.Format("Door {0} already opened", door9.Label), ConsoleMessageType.Info);
								command.Handled = true;
							}
						}
						else
						{
							if (door9.IsDisconnected)
							{
								SendConsoleMessage("Door not responding: " + door9.Label, ConsoleMessageType.Warning);
							}
							else
							{
								SendConsoleMessage("Door not powered: " + door9.Label, ConsoleMessageType.Warning);
							}
							command.Handled = true;
						}
					}
				}
				if (isTrackingCommandCounts && !string.IsNullOrEmpty(text5))
				{
					HintManager.PushHint(new DoorShortcutHint("open", text5));
					GameSaveFile.Save("HNT_TOGGLEDOOR", GameSaveFile.Get("HNT_TOGGLEDOOR", 0) + 1);
					countOpenCloseCommands = 0;
					CheckTrackingDoorToggleHint();
				}
			}
			if (!command.Handled)
			{
				SendConsoleMessage("Invalid command provided.  ex: open d1", ConsoleMessageType.Warning);
				command.Handled = true;
			}
			break;
		}
		case "close":
		{
			command.Handled = true;
			if (GlobalSettings.MissionStarted && command.Arguments.Count == 1 && command.Arguments[0].ToLower() == "all")
			{
				if (GlobalSettings.CrippledCommandList != null && GlobalSettings.CrippledCommandList.Contains(command.Command.CommandName))
				{
					SendConsoleMessage(string.Format("'{0}' is a corrupted command", command.Command.CommandName), ConsoleMessageType.Warning);
					break;
				}
				int num6 = 0;
				int num7 = 0;
				Door[] array3 = doors;
				foreach (Door door2 in array3)
				{
					if (door2.IsDead || door2.state != DoorState.Open)
					{
						continue;
					}
					if (door2.powered && !door2.corridor.IsAirlock)
					{
						if (!door2.IsTryingToClose)
						{
							door2.close();
						}
						num6++;
					}
					else if (door2.IsDisconnected)
					{
						num7++;
					}
				}
				if (num6 > 0)
				{
					SendConsoleMessage(num6 + " doors closed", ConsoleMessageType.Info);
				}
				if (num7 > 0)
				{
					SendConsoleMessage(num7 + " doors didn't respond", ConsoleMessageType.Warning);
				}
				break;
			}
			bool flag = GlobalSettings.CrippledCommandList != null && GlobalSettings.CrippledCommandList.Contains(command.Command.CommandName);
			bool flag2 = false;
			string text = string.Empty;
			bool flag3 = false;
			foreach (string argument3 in command.Arguments)
			{
				string text2 = argument3.ToLower();
				if (text2.StartsWith("r"))
				{
					Room[] array4 = rooms;
					foreach (Room room5 in array4)
					{
						if (!room5.Label.Equals(text2, StringComparison.InvariantCultureIgnoreCase))
						{
							continue;
						}
						foreach (Corridor corridor2 in room5.corridors)
						{
							if (corridor2.door.IsDead || corridor2.door.state != DoorState.Open)
							{
								continue;
							}
							if (corridor2.door.powered && (!flag || (corridor2.IsAirlock && Instance.BoardingVessel.CurrentAirlock == corridor2)))
							{
								if (!corridor2.door.IsTryingToClose)
								{
									corridor2.door.close();
								}
								flag2 = true;
							}
							else if (corridor2.door.IsDisconnected && !flag)
							{
								SendConsoleMessage("Door not responding: " + corridor2.door.Label, ConsoleMessageType.Warning);
							}
							command.Handled = true;
						}
						ConsoleWindow3.SendConsoleResponse(string.Format("all doors to room '{0}' now closed", room5.Label), ConsoleMessageType.Warning);
					}
					continue;
				}
				if (isTrackingCommandCounts && !flag3)
				{
					countOpenCloseCommands++;
					flag3 = true;
				}
				Door[] array5 = doors;
				foreach (Door door3 in array5)
				{
					if (!(door3.LabelSimple.ToLower() == text2.ToLower()))
					{
						continue;
					}
					if (isTrackingCommandCounts && countOpenCloseCommands >= 10)
					{
						text = text + text2 + " ";
					}
					if (door3.state == DoorState.Open)
					{
						if (door3.powered && (!flag || (door3.corridor.IsAirlock && Instance.BoardingVessel.CurrentAirlock == door3.corridor)))
						{
							if (!door3.IsTryingToClose)
							{
								door3.close();
							}
							flag2 = true;
						}
						else if (door3.IsDead || (door3.IsDisconnected && !flag))
						{
							SendConsoleMessage("Door not responding: " + door3.Label, ConsoleMessageType.Warning);
						}
						command.Handled = true;
					}
					else
					{
						SendConsoleMessage(string.Format("Door {0} already closed", door3.Label), ConsoleMessageType.Info);
						command.Handled = true;
					}
				}
			}
			if (isTrackingCommandCounts && !string.IsNullOrEmpty(text))
			{
				HintManager.PushHint(new DoorShortcutHint("close", text));
				GameSaveFile.Save("HNT_TOGGLEDOOR", GameSaveFile.Get("HNT_TOGGLEDOOR", 0) + 1);
				countOpenCloseCommands = 0;
				CheckTrackingDoorToggleHint();
			}
			if (flag && !flag2)
			{
				SystemMessageManager.ShowSystemMessage(string.Format("'close' is a corrupted command - can't toggle door closed", command.Command.CommandName), ConsoleMessageType.Warning);
			}
			break;
		}
		case "info":
			if (command.Arguments.Count == 0 && GlobalSettings.cameraMode == CameraMode.Drone)
			{
				if (droneManager.CurrentDrone.CurrentRoom != null)
				{
					DisplayInfoForRoom(droneManager.CurrentDrone.CurrentRoom);
				}
				else
				{
					SendConsoleMessage("Current drone is not in a room.", ConsoleMessageType.Error);
				}
			}
			else if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				if (command.DroneNumbers.Count == 1)
				{
					Drone drone = droneManager.dronesList.First((Drone x) => x != null && x.DroneNumber == command.DroneNumbers[0]);
					if (drone.CurrentRoom != null)
					{
						DisplayInfoForRoom(drone.CurrentRoom);
					}
					else
					{
						SendConsoleMessage(string.Format("Drone {0} is not in a room!", command.DroneNumbers[0]), ConsoleMessageType.Error);
					}
				}
				else if (command.DroneNumbers.Count > 1)
				{
					SendConsoleMessage("Too many drones specified - can only provide one", ConsoleMessageType.Warning);
				}
			}
			else
			{
				SendConsoleMessage("Incorrect number of arguments specified", ConsoleMessageType.Error);
			}
			command.Handled = true;
			break;
		case "status":
			SendConsoleMessage("Status of derelict ship:", ConsoleMessageType.Info);
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsQuarentined)
			{
				SendConsoleMessage("<color=#FFF000> - QUARANTINED</color>", ConsoleMessageType.Info);
			}
			SendConsoleMessage(string.Format(" -Type: {0}", (GlobalSettings.GameState.ThePlayer == null || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? "Unknown" : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DisplayName), ConsoleMessageType.Info);
			if (revealedRoomType != RevealedRoomType.None && RevealedRoom != null)
			{
				SendConsoleMessage(string.Format(" -{0} found in room {1}", CommonMethods.GetRevealedRoomDescription(revealedRoomType), RevealedRoom.Label), ConsoleMessageType.Info);
			}
			SendConsoleMessage(string.Format(" -Infestation types detected: {0}", (GlobalSettings.GameState.ThePlayer == null || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? "0" : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InfestationTypeCount), ConsoleMessageType.Info);
			SendConsoleMessage(string.Format(" -Hull integrity: {0}", (GlobalSettings.GameState.ThePlayer == null || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? HullIntegrity.None : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.HullIntegrity), ConsoleMessageType.Info);
			SendConsoleMessage(string.Format(" -Age: {0} ({1})", (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null) ? GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Age : 0, (GlobalSettings.GameState.ThePlayer == null || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon == null) ? "??" : GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.AgeText), ConsoleMessageType.Info);
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Station && !GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.suppressCommandeer)
			{
				SendConsoleMessage(string.Format(" -Scrap Capacity: {0}", (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null) ? GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax : 0), ConsoleMessageType.Info);
			}
			command.Handled = true;
			break;
		case "flag":
			if (command.Arguments != null && command.Arguments.Count == 1 && "clear".StartsWith(command.Arguments.Last().ToLower()))
			{
				Room[] array15 = rooms;
				foreach (Room room13 in array15)
				{
					room13.ClearRoomFlag();
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.FlagRemoved);
			}
			else
			{
				bool flag7 = false;
				bool flag8 = false;
				bool flag9 = false;
				foreach (string argument4 in command.Arguments)
				{
					string value = argument4.ToLower();
					Room[] array16 = rooms;
					foreach (Room room14 in array16)
					{
						if (room14.Label.Equals(value, StringComparison.InvariantCultureIgnoreCase))
						{
							bool flag10 = room14.ToggleRoomFlag();
							if (!flag8 && flag10)
							{
								flag8 = true;
							}
							else if (!flag9 && !flag10)
							{
								flag9 = true;
							}
							flag7 = true;
							break;
						}
					}
				}
				if (!flag7)
				{
					SendConsoleMessage("'flag' command - invalid arguments provided.  Ex: 'flag r2 r3'", ConsoleMessageType.Warning);
				}
				else
				{
					if (flag8)
					{
						GameAudio.Play2DSFX(GameAudio.SoundEnum.FlagPlaced);
					}
					if (flag9)
					{
						GameAudio.Play2DSFX(GameAudio.SoundEnum.FlagRemoved);
					}
				}
			}
			command.Handled = true;
			break;
		case "time":
		{
			int num3 = (int)GlobalSettings.MissionTime % 60;
			int num4 = (int)GlobalSettings.MissionTime / 60;
			int num5 = num4 / 60;
			num4 %= 60;
			SendConsoleMessage(string.Format("Mission Time: {0:00}:{1:00}:{2:00}", num5, num4, num3), ConsoleMessageType.Info);
			command.Handled = true;
			break;
		}
		case "toggle":
		{
			foreach (string argument5 in command.Arguments)
			{
				Door[] array7 = doors;
				foreach (Door door5 in array7)
				{
					if (!(door5.LabelSimple == argument5))
					{
						continue;
					}
					if (!door5.IsDead)
					{
						if (door5.powered)
						{
							if (door5.state == DoorState.Open)
							{
								if (GlobalSettings.CrippledCommandList != null && GlobalSettings.CrippledCommandList.Contains("close") && (!door5.corridor.IsAirlock || Instance.BoardingVessel.CurrentAirlock != door5.corridor))
								{
									SystemMessageManager.ShowSystemMessage(string.Format("'close' is a corrupted command - can't toggle door closed", command.Command.CommandName), ConsoleMessageType.Warning);
								}
								else if (!door5.IsTryingToClose)
								{
									door5.close();
								}
								command.Handled = true;
								continue;
							}
							bool flag6 = false;
							if (door5.corridor.LeadsIntoShip)
							{
								if (!GlobalSettings.MissionStarted)
								{
									GameplayManager.Instance.StartMission();
									SendConsoleMessage("Mission Started", ConsoleMessageType.Healthy);
									HintManager.HintCompleted(typeof(OpenD1Hint));
								}
							}
							else if (door5.corridor.IsAirlock && !hasTestedForAirlockWarning)
							{
								if ((!command.RequestConfirmed && GameSaveFile.Get("DIFF_W_AR", false)) || !GameSaveFile.Get("WS_ALOCK", false))
								{
									if (!GameSaveFile.Get("HNT_DISABLE", false))
									{
										SendConsoleMessage("Warning: opening airlock will depressurize room", ConsoleMessageType.Warning);
										SendConsoleMessage("Unsecured contents will be evacuated to space", ConsoleMessageType.Warning);
										SendConsoleMessage("Re-issue command to open airlock", ConsoleMessageType.Info);
										SendConsoleMessage("This warning will not appear again", ConsoleMessageType.Info);
										command.RequestConfirmation = true;
										flag6 = true;
									}
									GameSaveFile.Save("WS_ALOCK", true);
								}
								if (!GameSaveFile.Get("DIFF_W_AR", false))
								{
									hasTestedForAirlockWarning = true;
								}
							}
							if (!flag6)
							{
								door5.open();
							}
							command.Handled = true;
						}
						else
						{
							if (door5.IsDisconnected)
							{
								SendConsoleMessage("Door not responding: " + door5.Label, ConsoleMessageType.Error);
							}
							else
							{
								SendConsoleMessage("Door not powered: " + door5.Label, ConsoleMessageType.Error);
							}
							command.Handled = true;
						}
					}
					else
					{
						SendConsoleMessage("Door not responding: " + door5.Label, ConsoleMessageType.Error);
						command.Handled = true;
					}
				}
			}
			break;
		}
		case "shipscan":
			if (GlobalSettings.UseCombinedTerminal)
			{
				break;
			}
			SendConsoleMessage("Scanning...", ConsoleMessageType.Info);
			if (command.Arguments.Count == 0 || command.Arguments[0].ToLower() == "all")
			{
				command.Handled = true;
				Room[] array11 = rooms;
				foreach (Room room9 in array11)
				{
					if (room9.isPowered && room9.Label.ToLower() != "r1")
					{
						string result;
						if (room9.scan(true, out result))
						{
							SendConsoleMessage(room9.Label + ": " + result, ConsoleMessageType.Info);
						}
						else
						{
							SendConsoleMessage(room9.Label + ": Error Scanning", ConsoleMessageType.Error);
						}
					}
				}
			}
			else
			{
				foreach (string argument6 in command.Arguments)
				{
					Room[] array12 = rooms;
					foreach (Room room10 in array12)
					{
						if (room10.Label.ToLower() == argument6.ToLower() && room10.isPowered && room10.Label.ToLower() != "r1")
						{
							command.Handled = true;
							string result2;
							if (room10.scan(true, out result2))
							{
								SendConsoleMessage(room10.Label + ": " + result2, ConsoleMessageType.Info);
							}
							else
							{
								SendConsoleMessage(room10.Label + ": Error Scanning", ConsoleMessageType.Error);
							}
						}
					}
				}
			}
			ConsoleWindow3.SendConsoleResponse("View scan results on schematic view", ConsoleMessageType.Info);
			break;
		case "defense":
		{
			if (GlobalSettings.UseCombinedTerminal)
			{
				break;
			}
			command.Handled = true;
			DungeonDefense[] array9 = defenses;
			foreach (DungeonDefense dungeonDefense in array9)
			{
				if (dungeonDefense != null && dungeonDefense.Powered && !dungeonDefense.IsDead)
				{
					if (dungeonDefense.toggleArmed())
					{
						SendConsoleMessage("Defenses Activated", ConsoleMessageType.Info);
					}
					else
					{
						SendConsoleMessage("Defenses Deactivated", ConsoleMessageType.Info);
					}
				}
			}
			break;
		}
		case "areasensorall":
		{
			command.Handled = true;
			Room[] array10 = rooms;
			foreach (Room room7 in array10)
			{
				room7.AreaSensorVisual.Enable();
			}
			break;
		}
		case "openall":
		{
			command.Handled = true;
			Door[] array6 = doors;
			foreach (Door door4 in array6)
			{
				if (door4.state == DoorState.Closed)
				{
					door4.open(false);
				}
			}
			break;
		}
		case "closeall":
		{
			command.Handled = true;
			Door[] array8 = doors;
			foreach (Door door6 in array8)
			{
				if (door6.state == DoorState.Open)
				{
					door6.close(false);
				}
			}
			break;
		}
		case "powerall":
		case "pa":
		{
			command.Handled = true;
			Door[] array = doors;
			foreach (Door door in array)
			{
				if (!door.powered)
				{
					door.power(true);
				}
			}
			Room[] array2 = rooms;
			foreach (Room room2 in array2)
			{
				if (!room2.isPowered)
				{
					room2.power(null, true);
				}
			}
			UpdateCameraView();
			break;
		}
		case "scanall":
		case "sa":
		{
			command.Handled = true;
			Room[] array17 = rooms;
			foreach (Room room16 in array17)
			{
				if (!room16.boardingVessel)
				{
					room16.scan(true);
				}
			}
			break;
		}
		case "nr":
			command.Handled = true;
			NavigationHelper.Refresh();
			break;
		case "tree":
			command.Handled = true;
			CommandTree.WriteTree();
			break;
		case "run":
		{
			if (command.Arguments == null || command.Arguments.Count != 1)
			{
				break;
			}
			string text3 = command.Arguments[0].ToLower();
			string secretCommandResults = CommandHelper.GetSecretCommandResults(text3);
			switch (text3)
			{
			case "avnt":
			case "avirusnamedtom":
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					HUDCameraController.Instance.FireStaticOnDisabled(DroneManager.Instance.CurrentDrone.DroneNumber);
				}
				GameAudio.Play2DSFX(GameAudio.SoundEnum.AVNTLaugh);
				command.Handled = true;
				break;
			default:
				if (secretCommandResults != string.Empty)
				{
					SendConsoleMessage(secretCommandResults, ConsoleMessageType.Info);
					command.Handled = true;
				}
				break;
			}
			break;
		}
		case "reloadalias":
		{
			command.Handled = true;
			bool forceRecreateFile = false;
			if (command.Arguments != null && command.Arguments.Count > 0 && "force".StartsWith(command.Arguments.First().ToLower()))
			{
				forceRecreateFile = true;
			}
			CommandHelper.ReloadAliasFile(forceRecreateFile);
			break;
		}
		case "wtf":
			command.Handled = true;
			GlobalSettings.cheatMode = true;
			RevealEverything();
			break;
		case "breakrooms":
		{
			Room[] array14 = rooms;
			foreach (Room room12 in array14)
			{
				foreach (RoomItem roomItem in room12.roomItems)
				{
					if (roomItem is IBreakable)
					{
						((IBreakable)roomItem).Break();
					}
				}
			}
			command.Handled = true;
			SendConsoleMessage("Look what you've done!!!", ConsoleMessageType.Warning);
			break;
		}
		case "listall":
			command.Handled = true;
			SendConsoleMessage("Listing all upgrades for all drones, dead or alive", ConsoleMessageType.None);
			foreach (Drone drones in droneManager.dronesList)
			{
				bool flag4 = false;
				foreach (BaseDroneUpgrade upgrade in drones.Upgrades)
				{
					if (upgrade != null)
					{
						SendConsoleMessage(string.Format("\tDrone {0}: {1}", drones.DroneNumber, upgrade.Name), ConsoleMessageType.Info);
						flag4 = true;
					}
				}
				if (flag4)
				{
					SendConsoleMessage(string.Empty, ConsoleMessageType.None);
				}
			}
			{
				foreach (Drone lootableDrones in droneManager.LootableDronesList)
				{
					bool flag5 = false;
					foreach (BaseDroneUpgrade upgrade2 in lootableDrones.Upgrades)
					{
						if (upgrade2 != null)
						{
							SendConsoleMessage(string.Format("\tLootable Drone, {0} ({1}): {2}", lootableDrones.DroneName, (!lootableDrones.CanBeFullyRepaired) ? "Destroyed" : "Disabled", upgrade2.Name), ConsoleMessageType.Info);
							flag5 = true;
						}
					}
					if (flag5)
					{
						SendConsoleMessage(string.Empty, ConsoleMessageType.None);
					}
				}
				break;
			}
		case "exit":
			if (GlobalSettings.GameIsOver)
			{
				break;
			}
			if (!GlobalSettings.GameStartedFromGalaxyMap && !GlobalSettings.IsTutorial)
			{
				SystemMessageManager.ShowSystemMessage("Can't do that Tim, need to start from GalaxyMapScene ;-)", ConsoleMessageType.Warning);
				break;
			}
			if (!BoardingVessel.PrepareToLeave())
			{
				SystemMessageManager.ShowSystemMessage("Live enemies in the docking ship!", ConsoleMessageType.Error);
			}
			else
			{
				bool flag11 = false;
				if (!GameSaveFile.Get("HNT_COMMANDEER", false) && !GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsQuarentined && CanCommandeer())
				{
					int num21 = 0;
					foreach (ShipUpgradeSubsystemObject upgradeSubSystem in UpgradeSubSystems)
					{
						if (upgradeSubSystem.InstalledShipObject != null && (upgradeSubSystem.InstalledShipObject.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorking || upgradeSubSystem.InstalledShipObject.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose) && upgradeSubSystem.roomLocation.GetComponent<Collider>().bounds.Intersects(upgradeSubSystem.InstalledShipObject.gameObject.GetComponent<Collider>().bounds))
						{
							num21++;
						}
					}
					num21 /= 2;
					Debug.Log(string.Format("Can commandeer - here are the stats: My Slots: {0}, Their Slots: {1}, My Upg Count: {2}, Their Upgrade Count: {3}", GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ShipUpgradeSlots, GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount, num21));
					if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ShipUpgradeSlots > GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots && num21 > 0)
					{
						if (!GameSaveFile.Get("HNT_DISABLE", false))
						{
							SendConsoleMessage("Warning: conditions seem favorable to 'commandeer' derelict", ConsoleMessageType.Warning);
							SendConsoleMessage("Re-issue command to exit", ConsoleMessageType.Info);
							SendConsoleMessage("This warning will not appear again", ConsoleMessageType.Info);
							flag11 = true;
						}
						GameSaveFile.Save("HNT_COMMANDEER", true);
					}
				}
				if (!GameSaveFile.Get("HNT_TOW", false))
				{
					bool flag12 = false;
					foreach (Drone drones2 in DroneManager.Instance.dronesList)
					{
						if (!drones2.IsDead)
						{
							foreach (BaseDroneUpgrade upgrade3 in drones2.Upgrades)
							{
								if (upgrade3 is TowUpgrade)
								{
									flag12 = true;
									break;
								}
							}
						}
						if (flag12)
						{
							break;
						}
					}
					if (flag12)
					{
						bool flag13 = false;
						bool flag14 = false;
						ShipUpgradeInGameObject shipUpgrade;
						foreach (ShipUpgradeInGameObject shipUpgrade2 in ShipUpgrades)
						{
							shipUpgrade = shipUpgrade2;
							if (shipUpgrade.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose && shipUpgrade.IsKnown)
							{
								Room room15 = rooms.First((Room x) => x.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds));
								if (!room15.boardingVessel)
								{
									flag13 = true;
									break;
								}
							}
						}
						if (!flag13)
						{
							foreach (Drone drones3 in DroneManager.Instance.dronesList)
							{
								if (drones3.IsDead && drones3.CanBeTowed && (drones3.CurrentRoom == null || (drones3.CurrentRoom != BoardingVessel && drones3.CurrentRoom.isExplored)))
								{
									flag14 = true;
									break;
								}
							}
							if (!flag14)
							{
								foreach (Drone lootableDrones2 in DroneManager.Instance.LootableDronesList)
								{
									if (lootableDrones2.IsDead && lootableDrones2.CanBeTowed && (lootableDrones2.CurrentRoom == null || (lootableDrones2.CurrentRoom != BoardingVessel && lootableDrones2.CurrentRoom.isExplored)))
									{
										flag14 = true;
										break;
									}
								}
							}
						}
						if (flag13 || flag14)
						{
							if (!GameSaveFile.Get("HNT_DISABLE", false))
							{
								if (flag13)
								{
									SendConsoleMessage("Warning: ship upgrade detected that can be salvaged.", ConsoleMessageType.Warning);
								}
								else
								{
									SendConsoleMessage("Warning: lootable drone detected that can be salvaged.", ConsoleMessageType.Warning);
								}
								SendConsoleMessage("Recommended: 'tow' back to docking bay", ConsoleMessageType.Warning);
								SendConsoleMessage("Re-issue command to exit", ConsoleMessageType.Info);
								SendConsoleMessage("This warning will not appear again", ConsoleMessageType.Info);
								flag11 = true;
							}
							GameSaveFile.Save("HNT_TOW", true);
						}
					}
				}
				if (!flag11)
				{
					ProcessCommandToLeaveDungeon();
				}
			}
			command.Handled = true;
			break;
		case "restart_same":
			GameplayManager.Instance.PauseMessageResetPressed(true);
			break;
		case "commandeer":
		{
			bool allRoomsExplored = false;
			bool allEnemiesDead = false;
			bool radiationContained = false;
			bool radiationNotTooSpread = false;
			bool allAirlocksClosed = false;
			if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
			{
				SendConsoleMessage("Cannot commandeer in a Daily Challenge!", ConsoleMessageType.Error);
			}
			else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Station || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.suppressCommandeer)
			{
				SendConsoleMessage("Cannot commandeer this type of vessel", ConsoleMessageType.Error);
			}
			else if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsQuarentined)
			{
				SendConsoleMessage("Cannot commandeer quanrentined vessels", ConsoleMessageType.Error);
			}
			else if (CanCommandeer(out allRoomsExplored, out allEnemiesDead, out radiationContained, out radiationNotTooSpread, out allAirlocksClosed))
			{
				GameplayManager.Instance.ShowShipSwapWindow();
			}
			else
			{
				SendConsoleMessage("Cannot commandeer vessel:", ConsoleMessageType.Error);
				if (!allRoomsExplored || !allEnemiesDead)
				{
					SendConsoleMessage("Ship does not yet meet commandeer regulations\r\n'help commandeer' for more information", ConsoleMessageType.Error);
					Debug.Log(string.Format("Commandeer fail: {0} and {1} status", allRoomsExplored, allEnemiesDead));
				}
				else
				{
					if (!radiationContained)
					{
						SendConsoleMessage("Dangerous radation is not properly contained", ConsoleMessageType.Error);
					}
					if (!radiationNotTooSpread)
					{
						SendConsoleMessage("Radiation has spread too much to salvage this derelict", ConsoleMessageType.Error);
						Debug.Log(string.Format("Derelict is {0}% radiated", GetPercentageRadiated()));
					}
					if (!allAirlocksClosed)
					{
						SendConsoleMessage("For safety reasons all airlocks must be closed first", ConsoleMessageType.Error);
					}
				}
			}
			command.Handled = true;
			break;
		}
		case "radiate":
			command.Handled = true;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				Room room3 = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
				if (room3 != null)
				{
					room3.Radiate("dev command");
				}
			}
			break;
		case "killdoor":
			command.Handled = true;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				Door door7 = doors.FirstOrDefault((Door x) => x.LabelSimple.ToLower() == command.Arguments.First().ToLower());
				if (door7 != null)
				{
					door7.TakeDamage(9999999f, DamageType.Physical, null);
				}
			}
			break;
		case "dbf":
		{
			command.Handled = true;
			Room room11 = null;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				room11 = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			}
			if (room11 == null)
			{
				room11 = CommonMethods.PickRandomItem(rooms.ToList());
			}
			EnemyManager.Instance.CreateDronesBestFriend(NavigationHelper.GetMainRoomWaypoint(room11));
			break;
		}
		case "brute":
		{
			command.Handled = true;
			Room room8 = null;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				room8 = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			}
			if (room8 == null)
			{
				room8 = CommonMethods.PickRandomItem(rooms.ToList());
			}
			EnemyManager.Instance.CreateBrute(NavigationHelper.GetMainRoomWaypoint(room8));
			break;
		}
		case "swarm":
		{
			command.Handled = true;
			Room room6 = null;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				room6 = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			}
			if (room6 == null)
			{
				room6 = CommonMethods.PickRandomItem(rooms.ToList());
			}
			EnemyManager.Instance.CreateSwarm(NavigationHelper.GetMainRoomWaypoint(room6));
			break;
		}
		case "bot":
		{
			command.Handled = true;
			Room room4 = null;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				room4 = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			}
			if (room4 == null)
			{
				room4 = CommonMethods.PickRandomItem(rooms.ToList());
			}
			EnemyManager.Instance.CreatePatrolBot(NavigationHelper.GetMainRoomWaypoint(room4));
			break;
		}
		case "slime":
		{
			command.Handled = true;
			Room room = null;
			if (command.Arguments != null && command.Arguments.Count > 0)
			{
				room = rooms.FirstOrDefault((Room x) => x.Label.ToLower() == command.Arguments.First().ToLower());
			}
			if (room == null)
			{
				room = CommonMethods.PickRandomItem(rooms.ToList());
			}
			EnemyManager.Instance.CreateSlime(NavigationHelper.GetMainRoomWaypoint(room), true);
			break;
		}
		}
	}

	private void ShowMessageIfAllDoorsToRoomOpen(Door door)
	{
		Room[] array = door.corridor.rooms;
		foreach (Room room in array)
		{
			if (!(room != null) || room.boardingVessel || room.Label.Contains("?"))
			{
				continue;
			}
			bool flag = true;
			foreach (Corridor corridor in room.corridors)
			{
				if (corridor.door.state == DoorState.Closed)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				ConsoleWindow3.SendConsoleResponse(string.Format("all doors to room '{0}' now open", room.Label), ConsoleMessageType.Warning);
			}
		}
	}

	private void ShowMessageIfAllDoorsToRoomClose(Door door)
	{
		Room[] array = door.corridor.rooms;
		foreach (Room room in array)
		{
			if (!(room != null) || room.boardingVessel || room.Label.Contains("?"))
			{
				continue;
			}
			bool flag = true;
			foreach (Corridor corridor in room.corridors)
			{
				if (corridor.door.state == DoorState.Open)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				ConsoleWindow3.SendConsoleResponse(string.Format("all doors to room '{0}' now closed", room.Label), ConsoleMessageType.Warning);
			}
		}
	}

	private bool CanCommandeer()
	{
		bool allRoomsExplored = false;
		bool allEnemiesDead = false;
		bool radiationContained = false;
		bool radiationNotTooSpread = false;
		bool allAirlocksClosed = false;
		return CanCommandeer(out allRoomsExplored, out allEnemiesDead, out radiationContained, out radiationNotTooSpread, out allAirlocksClosed);
	}

	private bool CanCommandeer(out bool allRoomsExplored, out bool allEnemiesDead, out bool radiationContained, out bool radiationNotTooSpread, out bool allAirlocksClosed)
	{
		allRoomsExplored = rooms.All((Room x) => x.isExplored);
		allEnemiesDead = EnemyManager.Instance.Enemies.All((BaseEnemy x) => x.IsDead);
		radiationContained = rooms.All((Room x) => RadiationIsContained(x));
		radiationNotTooSpread = GetPercentageRadiated() <= 50f;
		allAirlocksClosed = !corridors.Any((Corridor x) => x.IsAirlock && x != BoardingVessel.CurrentAirlock && x.door.state != DoorState.Closed);
		return (allRoomsExplored && allEnemiesDead && radiationContained && radiationNotTooSpread && allAirlocksClosed) || GlobalSettings.cheatMode;
	}

	private float GetPercentageRadiated()
	{
		return (float)rooms.Count((Room x) => x.IsRadiated || x.IsFillingWithRadiation) * 100f / (float)rooms.Count();
	}

	private bool RadiationIsContained(Room room)
	{
		if (!room.IsFillingWithRadiation && !room.IsRadiated)
		{
			return true;
		}
		foreach (Corridor corridor in room.corridors)
		{
			if (corridor.door.state != DoorState.Closed)
			{
				Room room2 = corridor.rooms.FirstOrDefault((Room x) => x != room);
				if (room2 == null || (!room2.IsFillingWithRadiation && !room2.IsRadiated))
				{
					Debug.Log(string.Format("Commandeer fail: Door {0} is not containing radiation", corridor.door.Label));
					return false;
				}
			}
		}
		return true;
	}

	private void ProcessCommandToLeaveDungeon()
	{
		ProcessCommandToLeaveDungeon(false);
	}

	private void ProcessCommandToLeaveDungeon(bool ignoreFleetoveflowfilMessage)
	{
		if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
		{
			CollectorPermUpgrade.Instance.ReclaimCollectedItems();
		}
		List<Drone> transportableDrones = null;
		List<Drone> collectedDrones = null;
		List<ShipUpgradeInGameObject> transportableShipUpgrades = null;
		List<Drone> dronesToIgnore = null;
		List<Drone> dronesNotAbleToReturnToMotherShip = GetDronesNotAbleToReturnToMotherShip(out transportableDrones, out collectedDrones);
		int count = dronesNotAbleToReturnToMotherShip.Count;
		if (!ignoreFleetoveflowfilMessage)
		{
			int num = droneManager.dronesList.Where((Drone x) => x != null && !x.IsDead && x.IsVisible && x.CurrentRoom == BoardingVessel && !x.IsInSpace).Count();
			int num2 = GlobalSettings.GameState.ThePlayer.Drones.Count - num - count;
			int num3 = 0;
			int num4 = 0;
			IEnumerable<Drone> enumerable = null;
			List<Drone> list = null;
			enumerable = ((!GlobalSettings.CommandeeringShip) ? droneManager.LootableDronesList.Where((Drone x) => x != null && x.CurrentRoom == BoardingVessel) : droneManager.LootableDronesList.Where((Drone x) => x != null && x.Found && x.CanBeTowed));
			if (enumerable != null)
			{
				list = enumerable.ToList();
				num4 += list.Count;
			}
			if (collectedDrones != null)
			{
				num4 += collectedDrones.Count;
			}
			if (GlobalSettings.CommandeeringShip)
			{
				num += count;
			}
			if (transportableDrones != null)
			{
				num3 = transportableDrones.Count((Drone x) => !droneManager.dronesList.Contains(x));
				if (num3 > 0)
				{
					if (list == null)
					{
						list = transportableDrones.Where((Drone x) => !droneManager.dronesList.Contains(x)).ToList();
					}
					else
					{
						list.AddRange(transportableDrones.Where((Drone x) => !droneManager.dronesList.Contains(x)).ToList());
					}
				}
			}
			if (num2 + num + num4 + num3 > 7 && list.Count > 0)
			{
				dronesToIgnore = new List<Drone>();
				int num5 = num2 + num + num4 + num3 - 7;
				enumerable = list.OrderBy((Drone x) => x.NumberOfUpgradeSlots);
				List<Drone> list2 = enumerable.ToList();
				string text = string.Empty;
				int num6 = enumerable.Count();
				int num7 = 0;
				for (int num8 = 0; num8 < num6; num8++)
				{
					if (!string.IsNullOrEmpty(text))
					{
						text += ", ";
					}
					dronesToIgnore.Add(enumerable.ElementAt(num8));
					text += enumerable.ElementAt(num8).DroneName;
					num7++;
					if (num7 >= num5)
					{
						break;
					}
				}
				string message = "Unable to bring back all found drones because that would exceed your " + 7 + " maximum capacity\r\n\r\nThe following is the list of new drones that will be left behind (including any upgrades) if you continue:\n" + text + "\n\nProceed to leave?";
				DialogUI.Instance.ShowDialog("Fleet Full", message, ModalWindowType.YesNo, delegate(ModalWindowResult result, string resultInput)
				{
					if (result == ModalWindowResult.Yes)
					{
						int count2 = dronesToIgnore.Count;
						for (int i = 0; i < count2; i++)
						{
							dronesToIgnore[i].ignoreOnExit = true;
						}
						ProcessCommandToLeaveDungeon(true);
					}
					else if (GlobalSettings.CommandeeringShip)
					{
						GlobalSettings.CommandeeringShip = false;
					}
				}, 1);
				return;
			}
		}
		if (GameplayManager.TransporterShipUpgradeActive() && !GlobalSettings.CommandeeringShip)
		{
			ShipUpgradeInGameObject shipUpgrade;
			foreach (ShipUpgradeInGameObject shipUpgrade2 in ShipUpgrades)
			{
				shipUpgrade = shipUpgrade2;
				if (shipUpgrade.ThisUpgrade != null && shipUpgrade.ThisUpgrade.IsPermanentUpgrade)
				{
					continue;
				}
				Room room = rooms.First((Room x) => x.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds));
				if (!room.roomItems.Any((RoomItem x) => x is TransporterReceiver))
				{
					continue;
				}
				TransporterReceiver transporterReceiver = (TransporterReceiver)room.roomItems.First((RoomItem x) => x is TransporterReceiver);
				if (transporterReceiver.IsResponding)
				{
					if (transportableShipUpgrades == null)
					{
						transportableShipUpgrades = new List<ShipUpgradeInGameObject>();
					}
					transportableShipUpgrades.Add(shipUpgrade);
				}
			}
		}
		if (count > 0)
		{
			string message2 = string.Format("There are {0} drone(s) not in the docking bay, and will be left behind.\n\nAre you sure you want to leave?", count);
			DialogUI.Instance.ShowDialog("Leave Drone(s) Behind?", message2, ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
			{
				if (result == ModalWindowResult.Yes)
				{
					BeginExit(transportableDrones, transportableShipUpgrades, collectedDrones);
				}
				else
				{
					if (dronesToIgnore != null)
					{
						int count2 = dronesToIgnore.Count;
						for (int i = 0; i < count2; i++)
						{
							dronesToIgnore[i].ignoreOnExit = false;
						}
					}
					BoardingShip.Instance.CancelExit();
				}
			}, 1);
		}
		else
		{
			BeginExit(transportableDrones, transportableShipUpgrades, collectedDrones);
		}
	}

	private void BeginExit(List<Drone> transportableDrones, List<ShipUpgradeInGameObject> transportableShipUpgrades, List<Drone> collectedDrones)
	{
		IsExiting = true;
		if (GlobalSettings.gameMode == GameModeEnum.Normal && GameSaveFile.Get("D_ABN_RVT", false))
		{
			GalaxySaveFile.Save(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "VISITED", true);
			string key = "ST_CUR_VISITED_" + GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType;
			string key2 = "ST_TTL_VISITED_" + GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType;
			string key3 = "ST_BST_VISITED_" + GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType;
			int num = GameSaveFile.Get(key, 0) + 1;
			GameSaveFile.Save(key, num);
			GameSaveFile.Save(key2, GameSaveFile.Get(key2, 0) + 1);
			if (num > GameSaveFile.Get(key3, 0))
			{
				GameSaveFile.Save(key3, num);
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			DroneManager.Instance.switchCameraView();
		}
		bool flag = transportableDrones != null && transportableDrones.Count > 0;
		bool flag2 = collectedDrones != null && collectedDrones.Count > 0;
		bool flag3 = transportableShipUpgrades != null && transportableShipUpgrades.Count > 0;
		if (flag || flag3)
		{
			_exitTransportCountdown = 1.5f;
			if (flag)
			{
				_transportableDronesOnExit = transportableDrones;
			}
			else
			{
				_transportableDronesOnExit = new List<Drone>();
			}
			if (flag3)
			{
				_transportableShipUpgradesOnExit = transportableShipUpgrades;
			}
			else
			{
				_transportableShipUpgradesOnExit = new List<ShipUpgradeInGameObject>();
			}
			SystemMessageManager.ShowSystemMessage("Transporting items to docking bay first...", ConsoleMessageType.Info);
		}
		if (flag2)
		{
			_exitTransportCountdown = 1.5f;
			if (_transportableDronesOnExit == null)
			{
				_transportableDronesOnExit = new List<Drone>();
			}
			_transportableDronesOnExit.AddRange(collectedDrones);
			SystemMessageManager.ShowSystemMessage("Transfering objects from Collector...", ConsoleMessageType.Info);
		}
		Corridor.hasShownDockHintAtLeastOnce = false;
		DungeonPowerInlet.hasShownNavigateHintAtLeastOnce = false;
		DungeonPowerInlet.hasShownMotionHintAtLeastOnce = false;
		hasTestedForShipExplored = false;
		HintManager.HintCompleted(typeof(ExitHint));
		HintManager.HintCompleted(typeof(ShipExploredHint));
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			if (!(drones != null))
			{
				continue;
			}
			foreach (BaseDroneUpgrade upgrade in drones.Upgrades)
			{
				if (upgrade != null && upgrade.UsedThisMission && upgrade.BrokenState != BrokenStateEnum.Broken)
				{
					upgrade.NumMissions++;
					bool flag4 = false;
					if (upgrade.BreakProbability > 15f)
					{
						Debug.Log(string.Format("Upgrade used, and has a high enough probability of breaking ({0}%) testing to see if broke: {1}", upgrade.BreakProbability, upgrade.Name));
						if (UnityEngine.Random.Range(0f, 100f) < upgrade.BreakProbability)
						{
							upgrade.Break();
							flag4 = true;
						}
					}
					else
					{
						Debug.Log(string.Format("Upgrade used but has a low probability of breaking ({0}%) so NOT testing to see if broke: {1}", upgrade.BreakProbability, upgrade.Name));
					}
					if (!flag4)
					{
						float num2 = UnityEngine.Random.Range(3f, 6f);
						float num3 = upgrade.UpgradeBreakFactor * num2;
						if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
						{
							num3 = (GameSaveFile.Get("NC", false) ? (num3 * 0.75f) : (num3 * 0.5f));
						}
						switch (GameSaveFile.Get("DIFF_UPG", 0))
						{
						case 1:
							num3 *= 0.5f;
							break;
						case 2:
							num3 *= 1.5f;
							break;
						}
						upgrade.BreakProbability += num3;
						Debug.Log(string.Format("Upgrade's break probability has been increased to: {0}% - {1}", upgrade.BreakProbability, upgrade.Name));
					}
				}
				if (upgrade != null)
				{
					upgrade.UsedThisMission = false;
				}
			}
		}
		if (!GlobalSettings.CommandeeringShip)
		{
			List<IInventoryItem> itemsCopy = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy;
			int count = itemsCopy.Count;
			for (int num4 = count - 1; num4 >= 0; num4--)
			{
				if (itemsCopy[num4] is BaseShipUpgrade)
				{
					BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)itemsCopy[num4];
					if (baseShipUpgrade != null)
					{
						if (baseShipUpgrade.UsedThisMission && baseShipUpgrade.BrokenState == BrokenStateEnum.OK)
						{
							baseShipUpgrade.NumMissions++;
							bool flag5 = false;
							if (baseShipUpgrade.BreakProbability > 15f)
							{
								Debug.Log(string.Format("Ship Upgrade used, and has a high enough probability of breaking ({0}%) testing to see if broke: {1}", baseShipUpgrade.BreakProbability, baseShipUpgrade.Name));
								if (UnityEngine.Random.Range(0f, 100f) < baseShipUpgrade.BreakProbability)
								{
									baseShipUpgrade.Break();
									flag5 = true;
								}
							}
							else
							{
								Debug.Log(string.Format("Ship Upgrade used but has a low probability of breaking ({0}%) so NOT testing to see if broke: {1}", baseShipUpgrade.BreakProbability, baseShipUpgrade.Name));
							}
							if (!flag5)
							{
								float num5 = UnityEngine.Random.Range(3f, 6f);
								float num6 = baseShipUpgrade.UpgradeBreakFactor * num5;
								if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
								{
									num6 = (GameSaveFile.Get("NC", false) ? (num6 * 0.75f) : (num6 * 0.5f));
								}
								switch (GameSaveFile.Get("DIFF_UPG", 0))
								{
								case 1:
									num6 *= 0.5f;
									break;
								case 2:
									num6 *= 1.5f;
									break;
								}
								baseShipUpgrade.BreakProbability += num6;
								Debug.Log(string.Format("Ship Upgrade's break probability has been increased to: {0}% - {1}", baseShipUpgrade.BreakProbability, baseShipUpgrade.Name));
							}
							else
							{
								SlotInfo slotByUpgrade = GlobalSettings.GameState.ThePlayer.MyShip.GetSlotByUpgrade(baseShipUpgrade);
								if (slotByUpgrade != null)
								{
									slotByUpgrade.UnInstallUpgrade();
								}
								GlobalSettings.GameState.ThePlayer.AddToInventory(baseShipUpgrade);
							}
						}
						if (baseShipUpgrade != null)
						{
							int slotIndex = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.GetSlotIndex(baseShipUpgrade);
							baseShipUpgrade.SaveData("SHIP", slotIndex);
							baseShipUpgrade.UsedThisMission = false;
						}
					}
				}
			}
			if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null)
			{
				count = GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count;
				for (int num7 = count - 1; num7 >= 0; num7--)
				{
					SlotInfo slotInfo = GlobalSettings.GameState.ThePlayer.MyShip.slotList[num7];
					if (slotInfo.InstalledUpgrade != null && slotInfo.BrokenState == BrokenStateEnum.OK)
					{
						slotInfo.NumMissions++;
						bool flag6 = false;
						if (slotInfo.BreakProbability > 15f)
						{
							if (UnityEngine.Random.Range(0f, 100f) < slotInfo.BreakProbability)
							{
								slotInfo.Break();
								flag6 = true;
							}
						}
						else
						{
							Debug.Log(string.Format("Slot has a low probability of breaking ({0}%) so NOT testing to see if broke: {1}", slotInfo.BreakProbability, slotInfo.SlotNumber));
						}
						if (!flag6)
						{
							float num8 = UnityEngine.Random.Range(1.5f, 3f);
							if (GlobalSettings.GameState.ThePlayer.CurrentStarSystem != null && GlobalSettings.GameState.ThePlayer.CurrentStarSystem.IsNursery)
							{
								num8 = (GameSaveFile.Get("NC", false) ? (num8 * 0.75f) : (num8 * 0.5f));
							}
							switch (GameSaveFile.Get("DIFF_UPG", 0))
							{
							case 1:
								num8 *= 0.5f;
								break;
							case 2:
								num8 *= 1.5f;
								break;
							}
							bool flag7 = false;
							if (slotInfo.BreakProbability <= 15f)
							{
								flag7 = true;
							}
							slotInfo.BreakProbability += num8;
							if (flag7 && slotInfo.BreakProbability > 15f && !GameSaveFile.Get("HNT_SHPWR", false))
							{
								GalaxyMapManager.ShipDeteriorating = true;
							}
							Debug.Log(string.Format("Slot's break probability has been increased to: {0}% - {1}", slotInfo.BreakProbability, slotInfo.SlotNumber));
						}
						else
						{
							BaseShipUpgrade installedUpgrade = slotInfo.InstalledUpgrade;
							slotInfo.UnInstallUpgrade();
							GlobalSettings.GameState.ThePlayer.AddToInventory(installedUpgrade);
						}
					}
				}
			}
		}
		GameplayManager.Instance.ReleaseSteam();
		if (DroneManager.Instance != null)
		{
			DroneManager.Instance.CleanUpBeforeClose();
		}
		_exitFinalCountdown = 0.8f;
	}

	private void ProcessExit()
	{
		if (!IsExiting)
		{
			return;
		}
		if (_exitTransportCountdown > 0f)
		{
			_exitTransportCountdown -= Time.deltaTime;
			if (_exitTransportCountdown <= 0f)
			{
				TransportStuffPriorToLeaving(_transportableDronesOnExit, _transportableShipUpgradesOnExit);
			}
		}
		else
		{
			if (!(_exitFinalCountdown > 0f))
			{
				return;
			}
			_exitFinalCountdown -= Time.deltaTime;
			if (!(_exitFinalCountdown <= 0f))
			{
				return;
			}
			if (!GlobalSettings.IsTutorial)
			{
				if (GlobalSettings.gameMode != GameModeEnum.DailyChallenge)
				{
					ShowDerelictStatisticsWindow();
				}
				int scrapMax = GlobalSettings.GameState.ThePlayer.MyShip.ScrapMax;
				int pFuelMax = GlobalSettings.GameState.ThePlayer.MyShip.PFuelMax;
				if (GlobalSettings.CommandeeringShip)
				{
					scrapMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ScrapMax;
					pFuelMax = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax;
				}
				if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap > GlobalSettings.GameState.ThePlayer.Inventory.Scrap)
				{
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap = scrapMax;
				}
				if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap + RationsAddedWhenCommandeering <= scrapMax)
				{
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap += RationsAddedWhenCommandeering;
				}
				else
				{
					GlobalSettings.GameState.ThePlayer.Inventory.Scrap = scrapMax;
				}
				GlobalSettings.GameState.ThePlayer.Inventory.AddReservePropulsionFuel(PropulsionFuelAddedWhenCommandeering);
				GlobalSettings.GameState.ThePlayer.Inventory.JumpFuel += JumpFuelAddedWhenCommandeering;
				int num = GameSaveFile.Get("ST_CUR_SCRAP_COL", 0) + RationsAddedWhenCommandeering;
				GameSaveFile.Save("ST_CUR_SCRAP_COL", num);
				GameSaveFile.Save("ST_TTL_SCRAP_COL", GameSaveFile.Get("ST_TTL_SCRAP_COL", 0) + RationsAddedWhenCommandeering);
				if (num > GameSaveFile.Get("ST_BST_SCRAP_COL", 0))
				{
					GameSaveFile.Save("ST_BST_SCRAP_COL", num);
				}
				num = GameSaveFile.Get("ST_CUR_PFUEL_COL", 0) + PropulsionFuelAddedWhenCommandeering;
				GameSaveFile.Save("ST_CUR_PFUEL_COL", num);
				GameSaveFile.Save("ST_TTL_PFUEL_COL", GameSaveFile.Get("ST_TTL_PFUEL_COL", 0) + PropulsionFuelAddedWhenCommandeering);
				if (num > GameSaveFile.Get("ST_BST_PFUEL_COL", 0))
				{
					GameSaveFile.Save("ST_BST_PFUEL_COL", num);
				}
				num = GameSaveFile.Get("ST_CUR_JFUEL_COL", 0) + JumpFuelAddedWhenCommandeering;
				GameSaveFile.Save("ST_CUR_JFUEL_COL", num);
				GameSaveFile.Save("ST_TTL_JFUEL_COL", GameSaveFile.Get("ST_TTL_JFUEL_COL", 0) + JumpFuelAddedWhenCommandeering);
				if (num > GameSaveFile.Get("ST_BST_JFUEL_COL", 0))
				{
					GameSaveFile.Save("ST_BST_JFUEL_COL", num);
				}
				_transportableDronesOnExit = null;
				_transportableShipUpgradesOnExit = null;
				if (GlobalSettings.gameMode == GameModeEnum.DailyChallenge)
				{
					GlobalSettings.IsGamePaused = true;
					if (GalaxyProcessor.universeMapManager != null)
					{
						GalaxyProcessor.universeMapManager.Clear();
						GalaxyProcessor.universeMapManager = null;
					}
					GalaxyMapManager.hasBoardedDungeon = false;
					if (GameplayManager.Instance.SyncSceneDronesWithGlobalPlayerDrones())
					{
						GameplayManager.Instance.GotoMainMenu();
					}
				}
			}
			else
			{
				GameplayManager.Instance.ReturnToHomeShip();
			}
		}
	}

	public void CommandeerCurrentDerelict()
	{
		DungeonInfo myShip = GlobalSettings.GameState.ThePlayer.MyShip;
		DungeonInfo currentDockedDungeon = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon;
		if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap > currentDockedDungeon.ScrapMax)
		{
			GlobalSettings.GameState.ThePlayer.Inventory.Scrap = currentDockedDungeon.ScrapMax;
		}
		List<BaseShipUpgrade> list = myShip.UninstallShipUpgradesFromAllSlots();
		List<BaseShipUpgrade> list2 = currentDockedDungeon.UninstallShipUpgradesFromAllSlots();
		if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				if (GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num] is BaseShipUpgrade && ((BaseShipUpgrade)GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num]).IsPermanentUpgrade)
				{
					string groupKey = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num].GroupKey;
					GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.RemoveInventoryItem(GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num]);
					UniverseSaveFile.ClearGroup(groupKey, "SHIP");
				}
			}
		}
		UniverseSaveFile.ClearGroupAndChildren("SLOT_");
		int freeSlotCount = currentDockedDungeon.GetFreeSlotCount();
		UniverseSaveFile.BeginBatch();
		if (freeSlotCount > 0)
		{
			if (list != null)
			{
				int count2 = list.Count;
				List<int> list3 = new List<int>();
				for (int i = 0; i < count2; i++)
				{
					BaseShipUpgrade baseShipUpgrade = list[i];
					if (baseShipUpgrade != null && baseShipUpgrade.BrokenState == BrokenStateEnum.OK && !currentDockedDungeon.IsUpgradeOfTypeInstalledInSlot(baseShipUpgrade.GetType()))
					{
						SlotInfo nextFreeSlot = currentDockedDungeon.GetNextFreeSlot(baseShipUpgrade.GroupKey);
						nextFreeSlot.InstallUpgrade(baseShipUpgrade, currentDockedDungeon.InstalledInventory);
						baseShipUpgrade.SaveData("SHIP", nextFreeSlot.SlotNumber);
						list3.Add(i);
						freeSlotCount = currentDockedDungeon.GetFreeSlotCount();
						if (freeSlotCount <= 0)
						{
							break;
						}
					}
				}
				for (int j = 0; j < count2; j++)
				{
					if (!list3.Contains(j))
					{
						BaseShipUpgrade baseShipUpgrade2 = list[j];
						GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(baseShipUpgrade2);
						if (baseShipUpgrade2 != null)
						{
							baseShipUpgrade2.SaveData("PLAYER", -1);
						}
					}
				}
			}
		}
		else if (list != null)
		{
			int count3 = list.Count;
			for (int k = 0; k < count3; k++)
			{
				BaseShipUpgrade baseShipUpgrade3 = list[k];
				GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(baseShipUpgrade3);
				if (baseShipUpgrade3 != null)
				{
					baseShipUpgrade3.SaveData("PLAYER", -1);
				}
			}
		}
		freeSlotCount = currentDockedDungeon.GetFreeSlotCount();
		if (freeSlotCount > 0)
		{
			if (list2 != null)
			{
				int count4 = list2.Count;
				List<int> list4 = new List<int>();
				for (int l = 0; l < count4; l++)
				{
					BaseShipUpgrade baseShipUpgrade4 = list2[l];
					if (baseShipUpgrade4.BrokenState == BrokenStateEnum.OK && !currentDockedDungeon.IsUpgradeOfTypeInstalledInSlot(baseShipUpgrade4.GetType()))
					{
						SlotInfo nextFreeSlot2 = currentDockedDungeon.GetNextFreeSlot(baseShipUpgrade4.GroupKey);
						nextFreeSlot2.InstallUpgrade(baseShipUpgrade4, currentDockedDungeon.InstalledInventory);
						baseShipUpgrade4.SaveData("SHIP", nextFreeSlot2.SlotNumber);
						list4.Add(l);
						freeSlotCount = currentDockedDungeon.GetFreeSlotCount();
						if (freeSlotCount <= 0)
						{
							break;
						}
					}
				}
				for (int m = 0; m < count4; m++)
				{
					if (!list4.Contains(m))
					{
						BaseShipUpgrade baseShipUpgrade5 = list2[m];
						GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(baseShipUpgrade5);
						baseShipUpgrade5.SaveData("PLAYER", -1);
					}
				}
			}
		}
		else if (list2 != null)
		{
			int count5 = list2.Count;
			for (int n = 0; n < count5; n++)
			{
				BaseShipUpgrade baseShipUpgrade6 = list2[n];
				GlobalSettings.GameState.ThePlayer.Inventory.AddInventoryItem(baseShipUpgrade6);
				baseShipUpgrade6.SaveData("PLAYER", -1);
			}
		}
		UniverseSaveFile.EndBatch();
		if (ShipUpgrades != null)
		{
			int count6 = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.Count;
			for (int num2 = count6 - 1; num2 >= 0; num2--)
			{
				IInventoryItem inventoryItem = GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num2];
				if (inventoryItem is BaseShipUpgrade && ((BaseShipUpgrade)inventoryItem).IsPermanentUpgrade)
				{
					GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.RemoveInventoryItem(inventoryItem);
				}
			}
			count6 = ShipUpgrades.Count;
			for (int num3 = count6 - 1; num3 >= 0; num3--)
			{
				if (ShipUpgrades[num3] != null && ShipUpgrades[num3].ThisUpgrade != null && ShipUpgrades[num3].ThisUpgrade.IsPermanentUpgrade)
				{
					GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AddInventoryItem(ShipUpgrades[num3].ThisUpgrade);
				}
			}
		}
		RationsAddedWhenCommandeering = 0;
		PropulsionFuelAddedWhenCommandeering = 0;
		JumpFuelAddedWhenCommandeering = 0;
		if (lootItems != null)
		{
			LootItem[] array = lootItems;
			foreach (LootItem lootItem in array)
			{
				if (lootItem != null)
				{
					if ((lootItem.Found || lootItem.Explored) && !lootItem.collected)
					{
						RationsAddedWhenCommandeering++;
					}
					continue;
				}
				Debug.LogError("Prevented CommandeerCurrentDerelict Error: lootItem in lootItems is null!");
				if (ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
				{
					SystemMessageManager.ShowSystemMessage("DEV INFO: There was a null object in CommandeerCurrentDerelict().\r\n  Check the log to see which object and correct.\r\n  This message has been added to aid in debugging.\r\n  It only shows on systems that allow cheat mode.", ConsoleMessageType.Error);
				}
			}
		}
		else
		{
			Debug.LogError("Prevented CommandeerCurrentDerelict Error: lootItems is null!");
			if (ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
			{
				SystemMessageManager.ShowSystemMessage("DEV INFO: There was a null object in CommandeerCurrentDerelict().\r\n  Check the log to see which object and correct.\r\n  This message has been added to aid in debugging.\r\n  It only shows on systems that allow cheat mode.", ConsoleMessageType.Error);
			}
		}
		Room[] array2 = rooms;
		foreach (Room room in array2)
		{
			if (room != null)
			{
				FuelAccess fuelAccess = (FuelAccess)room.GetRoomItem(typeof(FuelAccess), true);
				if (fuelAccess != null)
				{
					PropulsionFuelAddedWhenCommandeering += fuelAccess.countPropulsionFuel;
					JumpFuelAddedWhenCommandeering += fuelAccess.countJumpFuel;
				}
			}
			else
			{
				Debug.LogError("Prevented CommandeerCurrentDerelict Error: room in rooms is null!");
				if (ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
				{
					SystemMessageManager.ShowSystemMessage("DEV INFO: There was a null object in CommandeerCurrentDerelict().\r\n  Check the log to see which object and correct.\r\n  This message has been added to aid in debugging.\r\n  It only shows on systems that allow cheat mode.", ConsoleMessageType.Error);
				}
			}
		}
		List<DropableItem> value = null;
		if (DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Probe, out value))
		{
			foreach (DropableItem item in value)
			{
				ProbeItem probeItem = (ProbeItem)item;
				if (!probeItem.IsDead)
				{
					ProbeUpgrade probeUpgrade = (ProbeUpgrade)probeItem.DroppingUpgrade;
					if (probeUpgrade.Quantity < probeUpgrade.Capacity)
					{
						probeUpgrade.AddItem(1);
					}
				}
			}
		}
		GlobalSettings.CommandeeringShip = true;
		if (!DungeonPowerInlet.hasTestedDestroyedAIState && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.StartsWith("MUTEKI") && ObjectiveManual.IsObjectiveStepActive("singularity", "stepD") && GalaxySaveFile.Get(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, "AI", 0) == 3)
		{
			LogManager.LogDataFile.SaveValue("singularity", "stepD", 3);
			LogManager.LogDataFile.SaveValue("singularity", "stepE", 3);
		}
		ProcessCommandToLeaveDungeon();
	}

	private List<Drone> GetDronesNotAbleToReturnToMotherShip(out List<Drone> transportableDrones, out List<Drone> collectedDrones)
	{
		transportableDrones = null;
		collectedDrones = null;
		List<Drone> list = ((!GlobalSettings.CommandeeringShip) ? droneManager.dronesList.Where((Drone x) => x != null && !x.IsDead && x.IsVisible && x.CurrentRoom != BoardingVessel && !x.IsInSpace).ToList() : new List<Drone>());
		int count = list.Count;
		if (GameplayManager.TransporterShipUpgradeActive())
		{
			for (int num = count - 1; num >= 0; num--)
			{
				Drone drone = list[num];
				foreach (RoomItem roomItem3 in drone.CurrentRoom.roomItems)
				{
					UnityEngine.Object component = roomItem3.GetComponent(typeof(TransporterReceiver));
					if (!(component != null))
					{
						continue;
					}
					TransporterReceiver transporterReceiver = (TransporterReceiver)component;
					if (transporterReceiver.IsResponding)
					{
						if (transportableDrones == null)
						{
							transportableDrones = new List<Drone>();
						}
						transportableDrones.Add(drone);
						list.RemoveAt(num);
					}
					break;
				}
			}
			count = list.Count;
			foreach (Drone drones in droneManager.dronesList)
			{
				if ((!drones.CanBeTowed && !drones.IsBeingTowed) || !(drones.CurrentRoom != BoardingVessel) || !(drones.CurrentRoom != null))
				{
					continue;
				}
				RoomItem roomItem = drones.CurrentRoom.GetRoomItem(typeof(TransporterReceiver), false);
				if (!(roomItem != null))
				{
					continue;
				}
				TransporterReceiver transporterReceiver2 = (TransporterReceiver)roomItem.GetComponent(typeof(TransporterReceiver));
				if (transporterReceiver2.IsResponding)
				{
					if (transportableDrones == null)
					{
						transportableDrones = new List<Drone>();
					}
					transportableDrones.Add(drones);
				}
			}
			foreach (Drone lootableDrones in droneManager.LootableDronesList)
			{
				if (lootableDrones.ignoreOnExit || (!lootableDrones.CanBeTowed && !lootableDrones.IsBeingTowed) || !(lootableDrones.CurrentRoom != null))
				{
					continue;
				}
				RoomItem roomItem2 = lootableDrones.CurrentRoom.GetRoomItem(typeof(TransporterReceiver), false);
				if (!(roomItem2 != null))
				{
					continue;
				}
				TransporterReceiver transporterReceiver3 = (TransporterReceiver)roomItem2.GetComponent(typeof(TransporterReceiver));
				if (transporterReceiver3.IsResponding)
				{
					if (transportableDrones == null)
					{
						transportableDrones = new List<Drone>();
					}
					transportableDrones.Add(lootableDrones);
				}
			}
		}
		if (CollectorPermUpgrade.Instance != null && (CollectorPermUpgrade.Instance.collectedFleetDrones != null || CollectorPermUpgrade.Instance.collectedLootableDrones != null))
		{
			if (collectedDrones == null)
			{
				collectedDrones = new List<Drone>();
			}
			if (CollectorPermUpgrade.Instance.collectedFleetDrones != null)
			{
				foreach (Drone collectedFleetDrone in CollectorPermUpgrade.Instance.collectedFleetDrones)
				{
					if (!collectedFleetDrone.ignoreOnExit)
					{
						collectedDrones.Add(collectedFleetDrone);
					}
				}
			}
			if (CollectorPermUpgrade.Instance.collectedLootableDrones != null)
			{
				foreach (Drone collectedLootableDrone in CollectorPermUpgrade.Instance.collectedLootableDrones)
				{
					if (!collectedLootableDrone.ignoreOnExit)
					{
						collectedDrones.Add(collectedLootableDrone);
					}
				}
			}
		}
		return list;
	}

	private void ShowDerelictStatisticsWindow()
	{
		GlobalSettings.ShowingGameOverlayWindow = true;
		GlobalSettings.IsGamePaused = true;
		TakeInventorySnapshot(ref missionStateEnding);
		DungeonManagerGUI.Instance.derelictStatisticsWindow = new DerelictStatisticsWindow(ref missionStateStartup, ref missionStateEnding);
		DungeonManagerGUI.Instance.derelictStatisticsWindow.ShowWindow();
		DungeonManagerGUI.Instance.isShowingDerelictStatisticsWindow = true;
	}

	private void TransportStuffPriorToLeaving(List<Drone> transportableDrones, List<ShipUpgradeInGameObject> transportableShipUpgrades)
	{
		if (transportableDrones != null && transportableDrones.Count > 0)
		{
			foreach (Drone transportableDrone in transportableDrones)
			{
				if (!transportableDrone.ignoreOnExit)
				{
					transportableDrone.CurrentRoom = BoardingVessel;
					transportableDrone.MoveToPosition(FindFreeSpotInRoom(BoardingVessel));
					transportableDrone.StopPriorNavigation();
					Debug.Log("Moving drone on exit thanks to active ship transporter: " + transportableDrone.DroneName);
				}
			}
		}
		if (transportableShipUpgrades == null || transportableShipUpgrades.Count <= 0)
		{
			return;
		}
		foreach (ShipUpgradeInGameObject transportableShipUpgrade in transportableShipUpgrades)
		{
			transportableShipUpgrade.transform.position = FindFreeSpotInRoom(BoardingVessel);
			transportableShipUpgrade.Scanned();
			transportableShipUpgrade.Show = true;
			if (transportableShipUpgrade.ThisUpgrade != null)
			{
				Debug.Log("Moving ship upgrade on exit thanks to active ship transporter: " + transportableShipUpgrade.ThisUpgrade.Name);
			}
		}
	}

	private Vector3 FindFreeSpotInRoom(Room room)
	{
		bool flag = false;
		Vector3 foundPosition = Vector3.zero;
		foreach (Drone drones in droneManager.dronesList)
		{
			if (drones.CurrentRoom != room || !FindFreePosition(room, drones.Position, out foundPosition))
			{
				continue;
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			foundPosition = NavigationHelper.GetMainRoomWaypoint(room).transform.position;
		}
		return foundPosition;
	}

	private bool FindFreePosition(Room room, Vector3 startPosition, out Vector3 foundPosition)
	{
		foundPosition = Vector3.zero;
		float num = _random.Next(1, 361);
		Vector3 vector = new Vector3(Mathf.Cos(num * ((float)Math.PI / 180f)), Mathf.Sin(num * ((float)Math.PI / 180f)), 0f);
		float num2 = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
		Drone drone = droneManager.dronesList.First();
		Renderer component = drone.GetComponent<Renderer>();
		float num3 = 0f;
		if (component != null)
		{
			Vector2 vector2 = new Vector2(component.bounds.size.x * 0.8f, component.bounds.size.y * 0.8f);
			num3 = vector2.magnitude;
		}
		else
		{
			num3 = new Vector2(0.8f, 0.8f).magnitude;
		}
		for (int i = 0; i < 8; i++)
		{
			Vector3 vector3 = startPosition + vector * num3;
			if (PositionInRoomAndNotColliding(room, vector3))
			{
				foundPosition = vector3;
				return true;
			}
			num2 += 45f;
			vector = new Vector3(Mathf.Cos(num2 * ((float)Math.PI / 180f)), Mathf.Sin(num2 * ((float)Math.PI / 180f)), 0f);
		}
		return false;
	}

	private bool PositionInRoomAndNotColliding(Room room, Vector3 testPosition)
	{
		if (!room.GetComponent<Collider>().bounds.Contains(testPosition))
		{
			return false;
		}
		foreach (Drone drones in droneManager.dronesList)
		{
			if (drones.CurrentRoom == room && drones.GetComponent<Collider>().bounds.Contains(testPosition))
			{
				return false;
			}
		}
		foreach (Drone lootableDrones in droneManager.LootableDronesList)
		{
			if (lootableDrones.CurrentRoom == room && lootableDrones.GetComponent<Collider>().bounds.Contains(testPosition))
			{
				return false;
			}
		}
		foreach (ShipUpgradeInGameObject shipUpgrade in ShipUpgrades)
		{
			if (shipUpgrade.GetComponent<Collider>().bounds.Contains(testPosition))
			{
				return false;
			}
		}
		return true;
	}

	private void DisplayInfoForRoom(Room room)
	{
		SendConsoleMessage(string.Format("Items found in {0}:", room.Label), ConsoleMessageType.Info);
		int num = 0;
		if (room.GetType() == typeof(BoardingShip))
		{
			num++;
			SendConsoleMessage(string.Format("\tAirlock: {0}\r\n\t   <use '{1}' to open/close airlock>", BoardingVessel.CurrentAirlock.door.Label, BoardingVessel.CurrentAirlock.door.Label), ConsoleMessageType.Info);
		}
		int num2 = 0;
		foreach (RoomItem roomItem in room.roomItems)
		{
			if (roomItem == null || !roomItem.Found || roomItem is TransporterReceiver)
			{
				continue;
			}
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			num++;
			if (roomItem.GetType() != typeof(LootItem))
			{
				bool flag = false;
				if (roomItem.IsDead)
				{
					text = " (Destroyed)";
				}
				else if (roomItem.GetType() == typeof(DungeonPowerInlet))
				{
					text += "\r\n\t   <use 'generator' to power>";
				}
				else if (roomItem.GetType() == typeof(DungeonTerminal))
				{
					text += "\r\n\t   <use 'interface' to access>";
				}
				else if (roomItem.GetType() == typeof(DungeonDefense))
				{
					text += "\r\n\t   <controlled via ship access terminals>";
				}
				else if (roomItem.GetType() == typeof(FuelAccess))
				{
					text += "\r\n\t   <use 'gather' to access>";
					text2 = " (p-fuel charge max: " + GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.PFuelMax + ")";
				}
				else if (roomItem.GetType() == typeof(ShipUpgradeSubsystemObject))
				{
					ShipUpgradeSubsystemObject shipUpgradeSubsystemObject = (ShipUpgradeSubsystemObject)roomItem;
					if (shipUpgradeSubsystemObject != null && shipUpgradeSubsystemObject.InstalledShipObject != null)
					{
						if (shipUpgradeSubsystemObject.IsDead || (shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade != null && shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade.BrokenState == BrokenStateEnum.Broken))
						{
							text3 = "\t   <cannot use 'tow' on destroyed ship upgrade>";
						}
						else if (shipUpgradeSubsystemObject.InstalledShipObject.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorking)
						{
							text3 = ((shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade == null || !shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade.IsPermanentUpgrade) ? "\t   <cannot use 'tow', upgrade firmly installed>" : "\t   <cannot use 'tow', upgrade permanently installed>");
						}
						else if (shipUpgradeSubsystemObject.InstalledShipObject.ShipUpgradeStatus != ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose)
						{
							text += "\r\n\t   <use 'tow' to salvage back to docking bay>";
						}
						else if (!roomItem.ItemName.Contains("<empty>"))
						{
							flag = true;
						}
						if (shipUpgradeSubsystemObject.IsPermUpgrade)
						{
							text2 = " }<color=#8ed0ff>perm</color>{";
						}
						if (shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade != null)
						{
							text2 = text2 + " (" + shipUpgradeSubsystemObject.InstalledShipObject.ThisUpgrade.BreakProbability.ToString("0.00") + "%)";
						}
					}
				}
				if (!flag)
				{
					SendConsoleMessage(string.Format("\t{0}{1}{2}", roomItem.ItemName, text2, text), ConsoleMessageType.Info);
					if (!string.IsNullOrEmpty(text3))
					{
						SendConsoleMessage(string.Format("{0}", text3), ConsoleMessageType.Warning);
					}
				}
			}
			else
			{
				num2++;
			}
		}
		if (ShipUpgrades != null)
		{
			foreach (ShipUpgradeInGameObject shipUpgrade in ShipUpgrades)
			{
				if (shipUpgrade != null && shipUpgrade.ThisUpgrade != null && shipUpgrade.Found && room.GetComponent<Collider>().bounds.Intersects(shipUpgrade.GetComponent<Collider>().bounds) && shipUpgrade.ShipUpgradeStatus == ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose)
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					num++;
					empty = ((shipUpgrade.ThisUpgrade.BrokenState != BrokenStateEnum.Broken) ? "\r\n\t   <use 'tow' to salvage back to docking bay>" : " (Destroyed)");
					empty2 = " (" + shipUpgrade.ThisUpgrade.BreakProbability.ToString("0.00") + "%)";
					SendConsoleMessage(string.Format("\tShip Upgrade: <color=#8ed0ff>{0}</color>{1}{2}", shipUpgrade.ThisUpgrade.Name, empty2, empty), ConsoleMessageType.Info);
				}
			}
		}
		if (num2 > 0)
		{
			SendConsoleMessage(string.Format("    Scrap ({0})\r\n\t   <use 'gather' to acquire>", num2), ConsoleMessageType.Info);
		}
		if (droneManager.dronesList != null)
		{
			foreach (Drone drones in droneManager.dronesList)
			{
				if (drones != null && drones.IsDead && drones.CurrentRoom != null && drones.CurrentRoom == room)
				{
					string empty3 = string.Empty;
					string text4 = string.Empty;
					num++;
					if (drones.IsDead && !drones.CanBeTowed && !drones.IsBeingTowed)
					{
						empty3 = " (Destroyed)";
						text4 = "\t   <cannot use 'tow' on destroyed drone, only disabled drones>";
					}
					else
					{
						empty3 = "\r\n\t   <use 'tow' to salvage back to docking bay>";
					}
					empty3 += "\r\n\t   <use 'swap' to exchange upgrades>";
					SendConsoleMessage(string.Format("\t<color=#8ed0ff>Drone {0} - {1}</color>{2}", drones.DroneNumber, drones.DroneName, empty3), ConsoleMessageType.Info);
					if (!string.IsNullOrEmpty(text4))
					{
						SendConsoleMessage(string.Format("{0}", text4), ConsoleMessageType.Warning);
					}
				}
			}
		}
		if (droneManager.LootableDronesList != null)
		{
			foreach (Drone lootableDrones in droneManager.LootableDronesList)
			{
				if (lootableDrones != null && lootableDrones.Found && lootableDrones.CurrentRoom != null && lootableDrones.CurrentRoom == room)
				{
					string empty4 = string.Empty;
					string text5 = string.Empty;
					num++;
					if (lootableDrones.IsDead && !lootableDrones.CanBeTowed && !lootableDrones.IsBeingTowed)
					{
						empty4 = " (Destroyed)";
						text5 = "\t   <cannot use 'tow' on destroyed drone, only disabled drones>";
					}
					else
					{
						empty4 = "\r\n\t   <use 'tow' to salvage back to docking bay>";
					}
					empty4 += "\r\n\t   <use 'swap' to exchange upgrades>";
					SendConsoleMessage(string.Format("\t<color=#8ed0ff>Drone - {0}</color>{1}", lootableDrones.DroneName, empty4), ConsoleMessageType.Info);
					if (!string.IsNullOrEmpty(text5))
					{
						SendConsoleMessage(string.Format("{0}", text5), ConsoleMessageType.Warning);
					}
				}
			}
		}
		if (num == 0)
		{
			SendConsoleMessage("\t(nothing found)", ConsoleMessageType.Info);
		}
	}

	public void RevealEverything()
	{
		Door[] array = doors;
		foreach (Door door in array)
		{
			if (!door.powered)
			{
				door.power(true);
			}
		}
		Room[] array2 = rooms;
		foreach (Room room in array2)
		{
			if (!room.isPowered)
			{
				room.power(null, true);
			}
			room.isExplored = true;
			foreach (RoomItem roomItem in room.roomItems)
			{
				if (roomItem != null)
				{
					roomItem.Show = true;
				}
			}
		}
		foreach (Drone lootableDrones in droneManager.LootableDronesList)
		{
			if (!lootableDrones.IsVisible)
			{
				Drone drone = lootableDrones;
				droneManager.ShowDrone(ref drone);
			}
		}
		foreach (ShipUpgradeInGameObject shipUpgrade in ShipUpgrades)
		{
			shipUpgrade.GetComponent<Renderer>().enabled = true;
			shipUpgrade.Scanned();
		}
		droneManager.UpdateCameraView();
	}

	public void SendConsoleMessage(string message, ConsoleMessageType messageType)
	{
		ConsoleWindow3.SendConsoleResponse(message, messageType);
	}

	public bool WouldBeLostInSpace(Vector3 position)
	{
		bool flag = true;
		bool flag2 = true;
		for (int i = 0; i < 2; i++)
		{
			Room[] array = rooms;
			foreach (Room room in array)
			{
				if (room.GetComponent<Collider>().bounds.Contains(position))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				Corridor[] array2 = corridors;
				foreach (Corridor corridor in array2)
				{
					if (corridor.GetComponent<Collider>().bounds.Contains(position))
					{
						flag2 = false;
						break;
					}
				}
			}
			if (!flag || !flag2)
			{
				break;
			}
			position += new Vector3(0.2f, 0.2f, 0f);
		}
		return flag && flag2;
	}

	public void DungeonUniqueSetupPostProcess(bool ignoreFarDoor)
	{
		int seed = (int)DateTime.Now.Ticks;
		if (SeedUniqueDungeonSetup != -1)
		{
			seed = SeedUniqueDungeonSetup;
		}
		System.Random random = new System.Random(seed);
		List<Room> list = new List<Room>();
		int i = 0;
		int num = 1;
		List<Corridor> list2 = new List<Corridor>();
		Room[] array = rooms;
		foreach (Room room in array)
		{
			if (!room.isPowered)
			{
				continue;
			}
			list.Add(room);
			foreach (Room adjacentRoom in room.getAdjacentRooms())
			{
				list.Add(adjacentRoom);
				if (!(adjacentRoom != null))
				{
					continue;
				}
				foreach (Room adjacentRoom2 in adjacentRoom.getAdjacentRooms())
				{
					if (!(adjacentRoom2 != room))
					{
						continue;
					}
					list.Add(adjacentRoom2);
					bool flag = true;
					foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
					{
						if (enemy.CurrentRoom == adjacentRoom2 && !enemy.IsDead)
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					Corridor[] array2 = corridors;
					foreach (Corridor corridor in array2)
					{
						if (!corridor.rooms.Contains(adjacentRoom) || !corridor.rooms.Contains(adjacentRoom2) || corridor.IsAirlock)
						{
							continue;
						}
						bool flag2 = true;
						if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
						{
							string metaData = corridor.GetMetaData("doorstate");
							if (metaData != "0" && metaData != string.Empty)
							{
								flag2 = false;
							}
						}
						if (flag2)
						{
							list2.Add(corridor);
						}
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			for (; i < num; i++)
			{
				if (list2.Where((Corridor x) => x.door.state == DoorState.Closed).Count() == 0)
				{
					break;
				}
				IEnumerable<Corridor> enumerable = null;
				if (!GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
				{
					list2 = list2;
				}
				Corridor corridor2 = list2.FirstOrDefault((Corridor x) => !x.rooms[0].DoesRoomItemExist(typeof(SwamSpawnVent)) && !x.rooms[1].DoesRoomItemExist(typeof(SwamSpawnVent)) && x.door.state == DoorState.Closed && !x.IsAirlock);
				if (corridor2 == null)
				{
					corridor2 = list2.FirstOrDefault((Corridor x) => x.door.state == DoorState.Closed && !x.IsAirlock);
				}
				if (corridor2 == null)
				{
					break;
				}
				corridor2.door.open();
				leadInOpenCorridors.Add(corridor2);
			}
		}
		bool flag3 = true;
		if (!ignoreFarDoor)
		{
			List<Corridor> list3 = new List<Corridor>();
			Corridor[] array3 = corridors;
			foreach (Corridor corridor3 in array3)
			{
				flag3 = true;
				foreach (Room item in list)
				{
					if (corridor3.containsRoom(item) || list3.Contains(corridor3))
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					list3.Add(corridor3);
				}
			}
			int num3 = -1;
			num3 = ((GlobalSettings.gameMode != GameModeEnum.Normal) ? random.Next(0, list3.Count - 1) : UnityEngine.Random.Range(0, list3.Count - 1));
			if (list3.Count > 0 && list3[num3] != null && list3[num3].door != null && !list3[num3].IsAirlock)
			{
				list3[num3].door.open();
			}
		}
		if (!GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			return;
		}
		Corridor[] array4 = corridors;
		foreach (Corridor corridor4 in array4)
		{
			string metaData2 = corridor4.GetMetaData("doorstate");
			if (metaData2 != "0" && metaData2 != string.Empty)
			{
				if (metaData2 == "1")
				{
					corridor4.door.close();
				}
				else if (metaData2 == "2")
				{
					corridor4.door.open();
				}
				else
				{
					Debug.LogWarning("Unknown 'doorstate' in designed ship!");
				}
			}
		}
	}

	public void RevealUsefulRoom()
	{
		float num = 0.85f;
		float num2 = 0.5f;
		bool flag = false;
		bool flag2 = false;
		float num3 = UnityEngine.Random.Range(0f, 1f);
		if (!(num3 <= num))
		{
			return;
		}
		num3 = UnityEngine.Random.Range(0f, 1f);
		if (num3 < num2)
		{
			flag2 = true;
			int count = droneManager.LootableDronesList.Count;
			for (int i = 0; i < count; i++)
			{
				Drone drone = droneManager.LootableDronesList[i];
				if (!IsLeadInRoom(drone.CurrentRoom) && (!GlobalSettings.UseTransporters || !transporterRooms.Contains(drone.CurrentRoom)))
				{
					drone.CurrentRoom.ExternallyMarkAsExplored();
					drone.CurrentRoom.scan(false);
					Drone drone2 = drone;
					droneManager.ShowDrone(ref drone2);
					flag = true;
					RevealedRoom = drone.CurrentRoom;
					revealedRoomType = RevealedRoomType.DeadDrone;
					break;
				}
			}
		}
		if (flag2 && (!flag2 || flag))
		{
			return;
		}
		int num4 = rooms.Length;
		for (int j = 0; j < num4; j++)
		{
			Room room = rooms[j];
			if ((GlobalSettings.UseTransporters && transporterRooms.Contains(room)) || IsLeadInRoom(room))
			{
				continue;
			}
			int num5 = 0;
			int count2 = room.roomItems.Count;
			for (int k = 0; k < count2; k++)
			{
				RoomItem roomItem = room.roomItems[k];
				if (roomItem.GetType() == typeof(LootItem))
				{
					num5++;
				}
			}
			if (num5 <= 2)
			{
				continue;
			}
			room.ExternallyMarkAsExplored();
			room.scan(false);
			RevealedRoom = room;
			revealedRoomType = RevealedRoomType.Loot;
			int count3 = droneManager.LootableDronesList.Count;
			for (int l = 0; l < count3; l++)
			{
				Drone drone3 = droneManager.LootableDronesList[l];
				if (drone3.CurrentRoom == room)
				{
					drone3.CurrentRoom.ExternallyMarkAsExplored();
					Drone drone4 = drone3;
					droneManager.ShowDrone(ref drone4);
					revealedRoomType = RevealedRoomType.DeadDrone;
				}
			}
			for (int m = 0; m < count2; m++)
			{
				RoomItem roomItem2 = room.roomItems[m];
				if (roomItem2 is SwamSpawnVent)
				{
					((SwamSpawnVent)roomItem2).ForceOverlayVisibleAtNextUpdate();
				}
			}
			break;
		}
	}

	public bool IsLeadInRoom(Room room)
	{
		bool result = false;
		foreach (Corridor leadInOpenCorridor in leadInOpenCorridors)
		{
			if (leadInOpenCorridor.rooms.Contains(room))
			{
				result = true;
			}
		}
		foreach (Corridor corridor in room.corridors)
		{
			if (corridor.LeadsIntoShip)
			{
				result = true;
			}
		}
		return result;
	}

	public void OverrideLootItems(UnityEngine.Object[] sentLootItems)
	{
		if (lootItems != null)
		{
			Debug.LogWarning("should not be in here if the loot items already exists");
			return;
		}
		lootItems = new LootItem[sentLootItems.Length];
		int num = 0;
		foreach (UnityEngine.Object obj in sentLootItems)
		{
			LootItem lootItem = (LootItem)obj;
			lootItems[num++] = lootItem;
			Room[] array = rooms;
			foreach (Room room in array)
			{
				if (!room.boardingVessel && room.GetComponent<Collider>().bounds.Intersects(lootItem.GetComponent<Collider>().bounds))
				{
					room.roomItems.Add(lootItem);
					lootItem.roomLocation = room;
					lootItem.DefaultVisible = true;
					break;
				}
			}
		}
	}

	private void RandomlyPlaceLoot(System.Random rnd)
	{
		int num = 0;
		UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(typeof(LootItem));
		LootItem lootItem = (LootItem)obj;
		lootItems = new LootItem[0];
		int num2 = 0;
		for (int i = 0; i < 2; i++)
		{
			int num3 = actualHiddenLootItems;
			if (i == 1)
			{
				num3 = actualVisibleLootItems;
			}
			if (num3 <= 0)
			{
				continue;
			}
			num2 = lootItems.Length;
			Array.Resize(ref lootItems, lootItems.Length + num3);
			List<Bounds> list = new List<Bounds>();
			Corridor[] array = corridors;
			foreach (Corridor corridor in array)
			{
				if (corridor != null)
				{
					Bounds bounds = corridor.GetComponent<Collider>().bounds;
					float angle = 0f;
					Vector3 axis = Vector3.zero;
					Vector3 zero = Vector3.zero;
					corridor.transform.rotation.ToAngleAxis(out angle, out axis);
					zero = ((angle != 0f) ? new Vector3(2f, 0f, 0f) : new Vector3(0f, 2f, 0f));
					bounds.Expand(zero);
					list.Add(bounds);
				}
			}
			List<Room> list2 = new List<Room>();
			float num4 = float.MinValue;
			Room[] array2 = rooms;
			foreach (Room room in array2)
			{
				if (!room.boardingVessel)
				{
					list2.Add(room);
					if (room.GetComponent<Collider>().bounds.size.magnitude > num4)
					{
						num4 = room.GetComponent<Collider>().bounds.size.magnitude;
					}
				}
			}
			UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
			for (int l = 0; l < num3; l++)
			{
				int num5 = -1;
				bool flag = false;
				do
				{
					num5 = rnd.Next(0, list2.Count());
					int maxValue = (int)((float)lootLargeRoomBias * (1f - list2[num5].GetComponent<Collider>().bounds.size.magnitude / num4));
					if (rnd.Next(0, maxValue) == 0)
					{
						flag = true;
					}
				}
				while (!flag);
				Room room2 = list2[num5];
				Rect rect = new Rect(room2.transform.position.x - room2.transform.localScale.x / 2f + 1f, room2.transform.position.y - room2.transform.localScale.y / 2f + 1f, room2.transform.localScale.x - 2f, room2.transform.localScale.y - 2f);
				rect.x += lootItem.transform.localScale.x / 2f;
				rect.y += lootItem.transform.localScale.y / 2f;
				rect.width -= lootItem.transform.localScale.x;
				rect.height -= lootItem.transform.localScale.y;
				bool flag2 = false;
				int num6 = 0;
				Vector3 vector;
				do
				{
					float num7 = rnd.NextFloat(0f, 1f);
					float num8 = rnd.NextFloat(0f, 1f);
					vector = new Vector3(rect.x + rect.width * num7, rect.y + rect.height * num8, 0f);
					Bounds bounds2 = new Bounds(vector, lootItem.transform.localScale);
					bounds2.Expand(0.1f);
					num6++;
					flag2 = !room2.RoomItemsBoundsHit(bounds2, null, null);
					if (!flag2)
					{
						continue;
					}
					foreach (Bounds item in list)
					{
						if (item.Intersects(bounds2))
						{
							flag2 = false;
							break;
						}
					}
				}
				while (num6 < 20 && !flag2);
				if (flag2)
				{
					lootItems[l + num2] = (LootItem)UnityEngine.Object.Instantiate(obj, vector, Quaternion.identity);
					lootItems[l + num2].transform.Translate(new Vector3(0f, 0f, -0.1f));
					lootItems[l + num2].transform.Rotate(new Vector3(-90f, 0f, 0f));
					lootItems[l + num2].roomLocation = room2;
					lootItems[l + num2].roomLocation.roomItems.Add(lootItems[l + num2]);
					if (i == 1)
					{
						lootItems[l + num2].DefaultVisible = true;
					}
				}
				num++;
				if (num > num3 * 3)
				{
					Debug.LogWarning("Break Out of Loot Placement After " + num3 * 3 + "Attempts");
					break;
				}
			}
		}
	}

	public void PlaceLootInRoom(Corridor corridor, bool isHidden, System.Random rnd)
	{
		List<Room> list = new List<Room>();
		int num = corridor.rooms.Length;
		for (int i = 0; i < num; i++)
		{
			Room room = corridor.rooms[i];
			if (room != null && !room.boardingVessel)
			{
				list.Add(room);
			}
		}
		int index = rnd.Next(0, list.Count);
		PlaceLootInRoom(list[index], isHidden, rnd);
	}

	public void PlaceLootInRoom(Room room, bool isHidden, System.Random rnd)
	{
		if (lootItemObjectTran == null)
		{
			lootItemObjectTran = scrapObjectPrefab.GetComponent<LootItem>();
		}
		if (corridorBoundsList == null)
		{
			corridorBoundsList = new List<Bounds>();
			int num = corridors.Length;
			for (int i = 0; i < num; i++)
			{
				Corridor corridor = corridors[i];
				if (corridor != null)
				{
					Bounds bounds = corridor.GetComponent<Collider>().bounds;
					float angle = 0f;
					Vector3 axis = Vector3.zero;
					Vector3 zero = Vector3.zero;
					corridor.transform.rotation.ToAngleAxis(out angle, out axis);
					zero = ((angle != 0f) ? new Vector3(2f, 0f, 0f) : new Vector3(0f, 2f, 0f));
					bounds.Expand(zero);
					corridorBoundsList.Add(bounds);
				}
			}
		}
		Rect rect = new Rect(room.transform.position.x - room.transform.localScale.x / 2f + 1f, room.transform.position.y - room.transform.localScale.y / 2f + 1f, room.transform.localScale.x - 2f, room.transform.localScale.y - 2f);
		rect.x += lootItemObjectTran.transform.localScale.x / 2f;
		rect.y += lootItemObjectTran.transform.localScale.y / 2f;
		rect.width -= lootItemObjectTran.transform.localScale.x;
		rect.height -= lootItemObjectTran.transform.localScale.y;
		bool flag = false;
		int num2 = 0;
		Vector3 vector;
		do
		{
			float num3 = rnd.NextFloat(0f, 1f);
			float num4 = rnd.NextFloat(0f, 1f);
			vector = new Vector3(rect.x + rect.width * num3, rect.y + rect.height * num4, 0f);
			Bounds bounds2 = new Bounds(vector, lootItemObjectTran.transform.localScale);
			bounds2.Expand(0.1f);
			num2++;
			flag = !room.RoomItemsBoundsHit(bounds2, null, null);
			if (!flag)
			{
				continue;
			}
			int count = corridorBoundsList.Count;
			for (int j = 0; j < count; j++)
			{
				if (corridorBoundsList[j].Intersects(bounds2))
				{
					flag = false;
					break;
				}
			}
		}
		while (num2 < 20 && !flag);
		if (flag)
		{
			PlaceLootInRoom(room, isHidden, vector);
		}
	}

	public void PlaceLootInRoom(Room room, bool isHidden, Vector3 vec)
	{
		if (lootItems == null)
		{
			lootItems = new LootItem[0];
		}
		LootItem component = scrapObjectPrefab.GetComponent<LootItem>();
		if (corridorBoundsList == null)
		{
			corridorBoundsList = new List<Bounds>();
			int num = corridors.Length;
			for (int i = 0; i < num; i++)
			{
				Corridor corridor = corridors[i];
				if (corridor != null)
				{
					Bounds bounds = corridor.GetComponent<Collider>().bounds;
					float angle = 0f;
					Vector3 axis = Vector3.zero;
					Vector3 zero = Vector3.zero;
					corridor.transform.rotation.ToAngleAxis(out angle, out axis);
					zero = ((angle != 0f) ? new Vector3(2f, 0f, 0f) : new Vector3(0f, 2f, 0f));
					bounds.Expand(zero);
					corridorBoundsList.Add(bounds);
				}
			}
		}
		Rect rect = new Rect(vec.x - 0.5f, vec.y - 0.5f, 1f, 1f);
		bool flag = false;
		int num2 = 0;
		do
		{
			Bounds bounds2 = new Bounds(vec, component.transform.localScale);
			bounds2.Expand(0.2f);
			num2++;
			flag = !room.RoomItemsBoundsHit(bounds2, null, null);
			if (flag)
			{
				int count = corridorBoundsList.Count;
				for (int j = 0; j < count; j++)
				{
					if (corridorBoundsList[j].Intersects(bounds2))
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				float num3 = UnityEngine.Random.Range(0f, 1f);
				float num4 = UnityEngine.Random.Range(0f, 1f);
				vec = new Vector3(rect.x + rect.width * num3, rect.y + rect.height * num4, 0f);
			}
		}
		while (num2 < 20 && !flag);
		Array.Resize(ref lootItems, lootItems.Length + 1);
		lootItems[lootItems.Length - 1] = (LootItem)UnityEngine.Object.Instantiate(component, vec, Quaternion.identity);
		lootItems[lootItems.Length - 1].transform.Translate(new Vector3(0f, 0f, -0.1f));
		lootItems[lootItems.Length - 1].transform.Rotate(new Vector3(-90f, 0f, 0f));
		lootItems[lootItems.Length - 1].roomLocation = room;
		lootItems[lootItems.Length - 1].roomLocation.roomItems.Add(lootItems[lootItems.Length - 1]);
		if (!isHidden)
		{
			lootItems[lootItems.Length - 1].DefaultVisible = true;
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				lootItems[lootItems.Length - 1].gameObject.GetComponent<Renderer>().enabled = false;
			}
		}
	}

	public void CleanUpLootPrefab()
	{
		UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(typeof(LootItem));
		LootItem lootItem = (LootItem)obj;
		lootItem.roomLocation = null;
		lootItem.GetComponent<Renderer>().enabled = false;
		lootItem.enabled = false;
		lootItem.transform.position = new Vector3(-5000f, 0f, 0f);
		lootItem.gameObject.SetActive(false);
	}

	public GameObject InstantiateGameObject(GameObject sourceObject)
	{
		return UnityEngine.Object.Instantiate(sourceObject);
	}

	public void DisableAllInputForAMoment()
	{
		ignoreAllInputForAMoment = true;
		timeIgnoreAllInput = 0.25f;
		if (ConsoleWindow3.Instance != null)
		{
			ConsoleWindow3.Instance.IsDisabled = true;
		}
	}

	public void PlayPickupSound()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic && !asPickup.isPlaying)
		{
			asPickup.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Schematic_ItemPickedUp, GameAudio.InterfaceVolume);
			asPickup.Play();
		}
	}

	private void AddSoundSources()
	{
		asRAmbience = base.gameObject.AddComponent<AudioSource>();
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			soundRAmbientHost = GameAudio.SoundEnum.Remote_A_HostShip1;
			break;
		case 1:
			soundRAmbientHost = GameAudio.SoundEnum.Remote_A_HostShip2;
			break;
		case 2:
			soundRAmbientHost = GameAudio.SoundEnum.Remote_A_HostShip3;
			break;
		}
		asRAmbience.clip = GameAudio.GetClip(soundRAmbientHost);
		asRAmbience.volume = GameAudio.VolumeMultiplier(soundRAmbientHost, GameAudio.AmbienceVolume);
		asRAmbience.playOnAwake = false;
		asRAmbience.loop = true;
		asMotherShipAmbience = base.gameObject.AddComponent<AudioSource>();
		asMotherShipAmbience.clip = GameAudio.GetClip(GameAudio.SoundEnum.A_MotherShip);
		asMotherShipAmbience.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.A_MotherShip, GameAudio.AmbienceVolume);
		asMotherShipAmbience.playOnAwake = false;
		asMotherShipAmbience.loop = true;
		asMotherShipShipCreak = base.gameObject.AddComponent<AudioSource>();
		asMotherShipShipCreak.playOnAwake = false;
		asMotherShipShipCreak.loop = false;
		asRandomStaticAmbience = base.gameObject.AddComponent<AudioSource>();
		asRandomStaticAmbience.playOnAwake = false;
		asRandomStaticAmbience.loop = false;
		asPickup = base.gameObject.AddComponent<AudioSource>();
		asPickup.clip = GameAudio.GetClip(GameAudio.SoundEnum.Schematic_ItemPickedUp);
		asPickup.volume = GameAudio.VolumeMultiplier(GameAudio.SoundEnum.Schematic_ItemPickedUp, GameAudio.InterfaceVolume);
		asPickup.playOnAwake = false;
		asPickup.loop = false;
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_HostShip1);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_HostShip2);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_HostShip3);
		GameAudio.RemoveClip(GameAudio.SoundEnum.A_MotherShip);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Schematic_ItemPickedUp);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_StaticA);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_StaticB);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_StaticC);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_StaticD);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_StaticE);
	}

	public void PauseSoundsOnMenuOpen()
	{
		if (asRAmbience.isPlaying)
		{
			isRAmbiencePaused = true;
			asRAmbience.Pause();
		}
		if (asRandomStaticAmbience.isPlaying)
		{
			isRandomStaticAmbiencePaused = true;
			asRandomStaticAmbience.Pause();
		}
		if (asPickup.isPlaying)
		{
			isPickupPaused = true;
			asPickup.Pause();
		}
	}

	public void ResumeSoundsOnMenuClose()
	{
		if (isRAmbiencePaused)
		{
			isRAmbiencePaused = false;
			asRAmbience.Play();
		}
		if (isRandomStaticAmbiencePaused)
		{
			isRandomStaticAmbiencePaused = false;
			asRandomStaticAmbience.Play();
		}
		if (isPickupPaused)
		{
			isPickupPaused = false;
			asPickup.Play();
		}
	}

	public void TestForExploredHint()
	{
		if (hasTestedForShipExplored)
		{
			return;
		}
		if (!GameSaveFile.Get("HNT_SHIPEXPLORED", false))
		{
			bool flag = true;
			Room[] array = rooms;
			foreach (Room room in array)
			{
				if (!room.boardingVessel && !room.hasDroneEverEnteredRoom)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				GameSaveFile.Save("HNT_SHIPEXPLORED_TRY", GameSaveFile.Get("HNT_SHIPEXPLORED_TRY", 0) + 1);
				if (GameSaveFile.Get("HNT_SHIPEXPLORED_TRY", 0) >= 3)
				{
					GameSaveFile.Save("HNT_SHIPEXPLORED", true);
				}
				HintManager.PushHint(new ShipExploredHint());
				hasTestedForShipExplored = true;
			}
		}
		else
		{
			hasTestedForShipExplored = true;
		}
	}

	public void CloseAliasWindow()
	{
		DungeonManagerGUI.Instance.aliasFileEditor = null;
		isShowingAlias = false;
		ConsoleWindow3.Instance.IsVisible = true;
		DisableAllInputForAMoment();
		CommandHelper.ReloadAliasFile(false);
		DungeonManagerGUI.Instance.Disable();
		AliasUI.Instance.Hide();
	}

	public void PlayDbfBark()
	{
		BoardingVessel.PlayOwnedDbfBarkSound();
	}

	public void PlayDbfNonBark()
	{
		BoardingVessel.PlayOwnedDbfNonBarkSound();
	}

	public void PlayDbfWhine()
	{
		BoardingVessel.PlayOwnedDbfWhineSound();
	}

	public void RandomBarkOnMiscSoundIfOwned()
	{
		if (GlobalSettings.OwnsDronesBestFriend && !(Time.time - _barkResponseTimeStamp < 7f))
		{
			int num = _random.Next(1, 101);
			if (num <= 25)
			{
				PlayDbfBark();
				_barkResponseTimeStamp = Time.time;
			}
		}
	}

	public void RefreshAfterDroneChange()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			asMotherShipShipCreak.transform.position = DroneManager.Instance.CurrentDrone.transform.position;
		}
		else
		{
			asMotherShipShipCreak.transform.position = DroneManager.Instance.SchematicCamera.transform.position;
		}
	}

	public void PlayMothershipCreak()
	{
		switch (UnityEngine.Random.Range(0, 3))
		{
		case 0:
			soundShipCreak = GameAudio.SoundEnum.ShipCreak1;
			break;
		case 1:
			soundShipCreak = GameAudio.SoundEnum.ShipCreak2;
			break;
		case 2:
			soundShipCreak = GameAudio.SoundEnum.ShipCreak3;
			break;
		}
		asMotherShipShipCreak.clip = GameAudio.GetClip(soundShipCreak);
		asMotherShipShipCreak.volume = GameAudio.VolumeMultiplier(soundShipCreak, GameAudio.AmbienceVolume);
		asMotherShipShipCreak.Play();
		RefreshAfterDroneChange();
	}
}
