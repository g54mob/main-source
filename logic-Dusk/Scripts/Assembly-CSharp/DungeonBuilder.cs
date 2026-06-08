using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonBuilder : MonoBehaviour
{
	public static DungeonBuilder Instance;

	public static int SeedLargeDebris = -1;

	public static int SeedSmallDebris = -1;

	public static int SeedFuel = -1;

	public static int SeedSubSystemContents = -1;

	public GameObject roomPrefab;

	public GameObject roomTilePrefab;

	public GameObject doorPrefab;

	public GameObject powerInletPrefab;

	public GameObject waypointPrefab;

	public GameObject terminalPrefab;

	public GameObject defensePrefab;

	public GameObject ventPrefab;

	public GameObject fuelAccessPrefab;

	public GameObject audioEmitterPrefab;

	public bool enableLargeObjectPlacement = true;

	public bool enableDebrisPlacement = true;

	public bool debugDisableHiddingModelsAtStart;

	private Room firstRoom;

	private DungeonGenerator dungeonGenerator;

	private DungeonBoard dungeonBoard;

	private List<Corridor> builtDoors;

	private bool initialized;

	private DungeonTypeEnum dungeonType;

	public List<Room> builtRooms { get; private set; }

	private void Initialize()
	{
		if (!initialized)
		{
			dungeonGenerator = DungeonGenerator.GetInstance();
			dungeonBoard = dungeonGenerator.dungeonBoard;
			builtRooms = new List<Room>();
			builtDoors = new List<Corridor>();
			initialized = true;
		}
	}

	private void Awake()
	{
		Instance = this;
		Initialize();
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		RemoveSoundSources();
		roomPrefab = null;
		roomTilePrefab = null;
		doorPrefab = null;
		powerInletPrefab = null;
		waypointPrefab = null;
		terminalPrefab = null;
		defensePrefab = null;
		ventPrefab = null;
		fuelAccessPrefab = null;
		audioEmitterPrefab = null;
		ResourceManager.UnloadAssetFromPartialName("Prefabs/Walls/");
	}

	private void Update()
	{
		if ((GameEditorScript.Instance == null || GameEditorScript.Instance.currentEditMode == GameEditorScript.EditModeEnum.RandomMode) && GlobalSettings.cheatMode && Input.GetKeyDown(KeyCode.B) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
		{
			Debug.Log("Lets build something");
			BuildDungeon(0f, 0f, DungeonTypeEnum.Derelict);
		}
	}

	public void BuildDungeon(float xOffset, float yOffset, DungeonTypeEnum dungeonType)
	{
		this.dungeonType = dungeonType;
		Initialize();
		ClearBuilder();
		if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ShipUpgradeSlots = 0;
		}
		dungeonBoard = DungeonGenerator.GetInstance().dungeonBoard;
		int num = -1;
		System.Random random = null;
		if (dungeonBoard.rooms.Count > 0)
		{
			int count = dungeonBoard.rooms.Count;
			for (int i = 0; i < count; i++)
			{
				DungeonRoom dungeonRoom = dungeonBoard.rooms[i];
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(roomPrefab, Vector3.zero, Quaternion.identity);
				Coordinate2D dimensions = dungeonRoom.dimensions;
				Vector3 vector = new Vector3((float)dungeonRoom.origin.x + (float)dimensions.x / 2f - 0.5f, (float)dungeonRoom.origin.y + (float)dimensions.y / 2f - 0.5f, 0f);
				vector.x += xOffset;
				vector.y += yOffset;
				gameObject.transform.localScale = new Vector3(dimensions.x, dimensions.y, 0.1f);
				gameObject.transform.position = vector;
				gameObject.GetComponent<Renderer>().enabled = false;
				Vector3 position = vector;
				for (int j = 0; j < dimensions.x; j++)
				{
					position.x = vector.x + (float)j - ((float)dimensions.x / 2f - 0.5f);
					for (int k = 0; k < dimensions.y; k++)
					{
						position.y = vector.y + (float)k - ((float)dimensions.y / 2f - 0.5f);
						if (UnityEngine.Random.Range(0, 100) < 0)
						{
							int num2 = 0;
							num2++;
						}
						else
						{
							GameObject gameObject2 = (GameObject)UnityEngine.Object.Instantiate(roomTilePrefab, position, Quaternion.AngleAxis(-90f, new Vector3(1f, 0f, 0f)));
							gameObject2.transform.parent = gameObject.transform;
						}
					}
				}
				Room room = gameObject.GetComponent(typeof(Room)) as Room;
				List<DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigRoom> roomTileList = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.dungeonRoomConfig.roomTileList;
				int num3 = UnityEngine.Random.Range(0, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.propertyHeader.dungeonRoomConfig.roomWeight);
				DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigRoom roomConfig = null;
				int count2 = roomTileList.Count;
				for (int l = 0; l < count2; l++)
				{
					DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigRoom dungeonRoomConfigRoom = roomTileList[l];
					if (num3 < dungeonRoomConfigRoom.weightAdj)
					{
						roomConfig = dungeonRoomConfigRoom;
						break;
					}
				}
				room.roomConfig = roomConfig;
				room.metaDataList = dungeonRoom.metaDataList;
				builtRooms.Add(room);
				room.scannerBroken = dungeonRoom.scannerBroken;
				room.motionBroken = dungeonRoom.motionBroken;
				GameObject gameObject3 = (GameObject)UnityEngine.Object.Instantiate(waypointPrefab, vector, Quaternion.identity);
				Waypoint waypoint = gameObject3.GetComponent(typeof(Waypoint)) as Waypoint;
				waypoint.Room = room;
				waypoint.IsMainRoomWaypoint = true;
				waypoint.WaypointType = WaypointTypeEnum.Spawn;
				room.Waypoints.Add(waypoint);
				if (dungeonRoom.subSystemList.Count > 0 && dungeonType == DungeonTypeEnum.Derelict)
				{
					int count3 = dungeonRoom.subSystemList.Count;
					for (int m = 0; m < count3; m++)
					{
						DungeonBoardShipSubSystems dungeonBoardShipSubSystems = dungeonRoom.subSystemList[m];
						Vector3 position2 = new Vector3(dungeonBoardShipSubSystems.origin.x + dungeonBoardShipSubSystems.dimensions.x / 2, dungeonBoardShipSubSystems.origin.y + dungeonBoardShipSubSystems.dimensions.y / 2, 0f);
						position2.x += xOffset;
						position2.y += yOffset;
						if (!dungeonBoardShipSubSystems.isPerm)
						{
							PlaceShipUpgradeSubsystem(room, position2, dungeonBoardShipSubSystems);
						}
						else
						{
							PlaceShipUpgradeSubsystem(room, position2, dungeonBoardShipSubSystems);
						}
					}
				}
				if (dungeonRoom.fuelAccess == null)
				{
					continue;
				}
				Vector3 position3 = new Vector3((float)dungeonRoom.fuelAccess.origin.x + 0.5f, (float)dungeonRoom.fuelAccess.origin.y + 0.5f, 0f);
				position3.x += xOffset;
				position3.y += yOffset;
				GameObject gameObject4 = (GameObject)UnityEngine.Object.Instantiate(fuelAccessPrefab, Vector3.zero, Quaternion.identity);
				gameObject4.transform.position = position3;
				if (position3.x >= room.transform.position.x + (room.transform.localScale.x / 2f - 1f) && position3.y < room.transform.position.y + (room.transform.localScale.y / 2f - 0.5f) && position3.y > room.transform.position.y - (room.transform.localScale.y / 2f - 0.5f))
				{
					gameObject4.transform.Rotate(new Vector3(0f, 0f, 90f));
				}
				else if (position3.x < room.transform.position.x + room.transform.localScale.x && position3.y < room.transform.position.y + (room.transform.localScale.y / 2f - 1f) && position3.y > room.transform.position.y - (room.transform.localScale.y / 2f - 1f))
				{
					gameObject4.transform.Rotate(new Vector3(0f, 0f, -90f));
				}
				else if (position3.y > room.transform.position.y)
				{
					gameObject4.transform.Rotate(new Vector3(0f, 0f, 180f));
				}
				FuelAccess component = gameObject4.GetComponent<FuelAccess>();
				component.metaDataList = dungeonRoom.fuelAccess.metaDataList;
				bool flag = false;
				bool flag2 = false;
				string metaData = component.GetMetaData("fueljump");
				string metaData2 = component.GetMetaData("fuelprop");
				if (metaData != string.Empty)
				{
					int result = 0;
					if (int.TryParse(metaData, out result))
					{
						component.countJumpFuel = result;
						flag = true;
					}
				}
				if (metaData2 != string.Empty)
				{
					int result2 = 0;
					if (int.TryParse(metaData2, out result2))
					{
						component.countPropulsionFuel = result2;
						flag2 = true;
					}
				}
				num = (int)DateTime.Now.Ticks;
				if (SeedFuel != -1)
				{
					num = SeedFuel;
				}
				random = new System.Random(num);
				if (GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty != null)
				{
					if (!flag2 && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasChancePropulsionFuel && random.Next(0, 100) < GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.chancePropulsionFuel)
					{
						component.countPropulsionFuel = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.propulsionFuelMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.propulsionFuelMax + 1);
					}
					if (!flag && GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasChanceJumpFuel && random.Next(0, 100) < GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.chanceJumpFuel)
					{
						component.countJumpFuel = random.Next(GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.jumpFuelMin, GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.jumpFuelMax + 1);
					}
				}
				component.roomLocation = room;
				room.roomItems.Add(component);
			}
		}
		if ((dungeonType == DungeonTypeEnum.Derelict || dungeonType == DungeonTypeEnum.Station) && !GlobalSettings.IsGameEditor)
		{
			int num4 = 0;
			int count4 = DungeonManager.Instance.UpgradeSubSystems.Count;
			for (int n = 0; n < count4; n++)
			{
				if (DungeonManager.Instance.UpgradeSubSystems[n].IsPermUpgrade)
				{
					num4++;
				}
			}
			GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.LoadSlotsFromData(num4);
			InitialSubSystemConfiguration();
		}
		if (dungeonBoard.doors.Count > 0)
		{
			int count5 = dungeonBoard.doors.Count;
			for (int num5 = 0; num5 < count5; num5++)
			{
				DungeonDoor dungeonDoor = dungeonBoard.doors[num5];
				GameObject gameObject5 = (GameObject)UnityEngine.Object.Instantiate(doorPrefab, Vector3.zero, Quaternion.identity);
				Coordinate2D dimensions2 = dungeonDoor.dimensions;
				gameObject5.transform.localScale = new Vector3(dimensions2.x, dimensions2.y, 0.1f);
				Vector3 position4 = new Vector3((float)dungeonDoor.origin.x + (float)dimensions2.x / 2f - 0.5f, (float)dungeonDoor.origin.y + (float)dimensions2.y / 2f - 0.5f, 0f);
				position4.x += xOffset;
				position4.y += yOffset;
				gameObject5.transform.position = position4;
				if (dungeonDoor.horizontal)
				{
					gameObject5.transform.Rotate(0f, 0f, 90f);
				}
				Corridor corridor = gameObject5.GetComponent(typeof(Corridor)) as Corridor;
				corridor.metaDataList = dungeonDoor.metaDataList;
				builtDoors.Add(corridor);
				Room room2 = builtRooms[dungeonDoor.rooms[0].index];
				corridor.rooms[0] = room2;
				if (!dungeonDoor.airlock)
				{
					Room room3 = builtRooms[dungeonDoor.rooms[1].index];
					corridor.rooms[1] = room3;
					room3.AddCorridor(corridor);
					corridor.Waypoints[1].ConnectedWaypoints.Add(room3.Waypoints[0]);
					room3.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[1]);
					room2.Waypoints[0].ConnectedRooms.Add(room3.Waypoints[0]);
					room3.Waypoints[0].ConnectedRooms.Add(room2.Waypoints[0]);
					corridor.Waypoints[0].ConnectedWaypoints.Add(room2.Waypoints[0]);
					room2.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[0]);
				}
				else
				{
					float num6 = 0f;
					float num7 = 0f;
					if (DungeonManager.Instance != null && DungeonManager.Instance.DungeonSize != null)
					{
						num6 = DungeonManager.Instance.DungeonSize.x / 2;
						num7 = DungeonManager.Instance.DungeonSize.y / 2;
					}
					else
					{
						num6 = -7f;
						num7 = 2.5f;
					}
					if (corridor.transform.rotation.w == 1f)
					{
						if (corridor.transform.position.x > num6)
						{
							corridor.Waypoints[0].ConnectedWaypoints.Add(room2.Waypoints[0]);
							room2.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[0]);
						}
						else
						{
							corridor.Waypoints[1].ConnectedWaypoints.Add(room2.Waypoints[0]);
							room2.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[1]);
						}
					}
					else if (corridor.transform.rotation.w >= 0.65f && corridor.transform.rotation.w <= 0.75f)
					{
						if (corridor.transform.position.y > num7)
						{
							corridor.Waypoints[0].ConnectedWaypoints.Add(room2.Waypoints[0]);
							room2.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[0]);
						}
						else
						{
							corridor.Waypoints[1].ConnectedWaypoints.Add(room2.Waypoints[0]);
							room2.Waypoints[0].ConnectedWaypoints.Add(corridor.Waypoints[1]);
						}
					}
				}
				room2.AddCorridor(corridor);
				if (!dungeonDoor.airlock)
				{
					continue;
				}
				if (!dungeonDoor.dontTranslateAirlock)
				{
					if (dungeonDoor.origin.x == 0 && !dungeonDoor.horizontal)
					{
						gameObject5.transform.Translate(new Vector3(-4f, 0f, 0f));
					}
					else
					{
						gameObject5.transform.Translate(new Vector3(4f, 0f, 0f));
					}
				}
				corridor.IsAirlock = true;
				corridor.LeadsIntoShip = dungeonDoor.initialDockingAirlock;
				firstRoom = room2;
			}
		}
		float z = 0f;
		int count6 = builtRooms.Count;
		for (int num8 = 0; num8 < count6; num8++)
		{
			Room room4 = builtRooms[num8];
			float x = room4.transform.localScale.x;
			float y = room4.transform.localScale.y;
			room4.wallModels = new List<GameObject>();
			room4.wallModelsRenderers = new Dictionary<GameObject, Renderer>();
			GameObject gameObject6 = null;
			DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigWall dungeonRoomConfigWall = null;
			UnityEngine.Object original = ResourceManager.LoadAsset<GameObject>(string.Format("Prefabs/Walls/{0}", room4.roomConfig.cornerFileName));
			for (int num9 = 0; (float)num9 < x; num9++)
			{
				int num10 = UnityEngine.Random.Range(0, room4.roomConfig.wallWeight);
				int count7 = room4.roomConfig.wallList.Count;
				for (int num11 = 0; num11 < count7; num11++)
				{
					DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigWall dungeonRoomConfigWall2 = room4.roomConfig.wallList[num11];
					if (num10 < dungeonRoomConfigWall2.weightAdj)
					{
						dungeonRoomConfigWall = dungeonRoomConfigWall2;
						break;
					}
				}
				UnityEngine.Object original2 = ResourceManager.LoadAsset<GameObject>(string.Format("Prefabs/Walls/{0}", dungeonRoomConfigWall.fileName));
				Vector3 vector2 = new Vector3((float)(num9 + 1) + room4.transform.position.x - x / 2f, room4.transform.position.y + y / 2f, z);
				gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original2, Vector3.zero, Quaternion.identity);
				gameObject6.transform.localPosition = vector2;
				bool flag3 = true;
				count7 = builtDoors.Count;
				for (int num12 = 0; num12 < count7; num12++)
				{
					Corridor corridor2 = builtDoors[num12];
					Bounds bounds = corridor2.GetComponent<Collider>().bounds;
					bounds.Expand(new Vector3(-0.1f, 1f, 0f));
					if (bounds.Intersects(gameObject6.GetComponent<Collider>().bounds))
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					gameObject6.transform.parent = room4.transform;
					room4.wallModels.Add(gameObject6);
					room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
					room4.wallModelsRenderers[gameObject6].enabled = false;
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject6);
				}
				gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original2, Vector3.zero, Quaternion.identity);
				vector2 = new Vector3((float)num9 + room4.transform.position.x - x / 2f, room4.transform.position.y - y / 2f, z);
				gameObject6.transform.position = vector2;
				gameObject6.transform.Rotate(new Vector3(0f, 0f, 180f));
				flag3 = true;
				count7 = builtDoors.Count;
				for (int num13 = 0; num13 < count7; num13++)
				{
					Corridor corridor3 = builtDoors[num13];
					Bounds bounds2 = corridor3.GetComponent<Collider>().bounds;
					bounds2.Expand(new Vector3(-0.1f, 1f, 0f));
					if (bounds2.Intersects(gameObject6.GetComponent<Collider>().bounds))
					{
						flag3 = false;
					}
				}
				if (flag3)
				{
					gameObject6.transform.parent = room4.transform;
					room4.wallModels.Add(gameObject6);
					room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
					room4.wallModelsRenderers[gameObject6].enabled = false;
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject6);
				}
			}
			for (int num14 = 0; (float)num14 < y; num14++)
			{
				int num15 = UnityEngine.Random.Range(0, room4.roomConfig.wallWeight);
				int count8 = room4.roomConfig.wallList.Count;
				for (int num16 = 0; num16 < count8; num16++)
				{
					DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigWall dungeonRoomConfigWall3 = room4.roomConfig.wallList[num16];
					if (num15 < dungeonRoomConfigWall3.weightAdj)
					{
						dungeonRoomConfigWall = dungeonRoomConfigWall3;
						break;
					}
				}
				UnityEngine.Object original3 = ResourceManager.LoadAsset<GameObject>(string.Format("Prefabs/Walls/{0}", dungeonRoomConfigWall.fileName));
				gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original3, Vector3.zero, Quaternion.identity);
				Vector3 position5 = new Vector3(room4.transform.position.x - x / 2f, (float)num14 + room4.transform.position.y - y / 2f + 1f, z);
				gameObject6.transform.Rotate(new Vector3(0f, 0f, 90f));
				gameObject6.transform.position = position5;
				bool flag4 = true;
				count8 = builtDoors.Count;
				for (int num17 = 0; num17 < count8; num17++)
				{
					Corridor corridor4 = builtDoors[num17];
					Bounds bounds3 = corridor4.GetComponent<Collider>().bounds;
					bounds3.Expand(new Vector3(1f, -0.1f, 0f));
					if (bounds3.Intersects(gameObject6.GetComponent<Collider>().bounds))
					{
						flag4 = false;
					}
				}
				if (flag4)
				{
					gameObject6.transform.parent = room4.transform;
					room4.wallModels.Add(gameObject6);
					room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
					room4.wallModelsRenderers[gameObject6].enabled = false;
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject6);
				}
				gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original3, Vector3.zero, Quaternion.identity);
				position5 = new Vector3(room4.transform.position.x + x / 2f, (float)num14 + room4.transform.position.y - y / 2f, z);
				gameObject6.transform.Rotate(new Vector3(0f, 0f, -90f));
				gameObject6.transform.position = position5;
				flag4 = true;
				count8 = builtDoors.Count;
				for (int num18 = 0; num18 < count8; num18++)
				{
					Corridor corridor5 = builtDoors[num18];
					Bounds bounds4 = corridor5.GetComponent<Collider>().bounds;
					bounds4.Expand(new Vector3(1f, -0.1f, 0f));
					if (bounds4.Intersects(gameObject6.GetComponent<Collider>().bounds))
					{
						flag4 = false;
					}
				}
				if (flag4)
				{
					gameObject6.transform.parent = room4.transform;
					room4.wallModels.Add(gameObject6);
					room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
					room4.wallModelsRenderers[gameObject6].enabled = false;
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject6);
				}
			}
			gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity);
			Vector3 position6 = new Vector3(room4.transform.position.x - x / 2f, room4.transform.position.y + y / 2f, z);
			gameObject6.transform.position = position6;
			gameObject6.transform.parent = room4.transform;
			room4.wallModels.Add(gameObject6);
			room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
			room4.wallModelsRenderers[gameObject6].enabled = false;
			gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity);
			position6 = new Vector3(room4.transform.position.x + x / 2f, room4.transform.position.y + y / 2f, z);
			gameObject6.transform.position = position6;
			gameObject6.transform.Rotate(new Vector3(0f, 0f, -90f));
			gameObject6.transform.parent = room4.transform;
			room4.wallModels.Add(gameObject6);
			room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
			room4.wallModelsRenderers[gameObject6].enabled = false;
			gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity);
			position6 = new Vector3(room4.transform.position.x - x / 2f, room4.transform.position.y - y / 2f, z);
			gameObject6.transform.position = position6;
			gameObject6.transform.Rotate(new Vector3(0f, 0f, 90f));
			gameObject6.transform.parent = room4.transform;
			room4.wallModels.Add(gameObject6);
			room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
			room4.wallModelsRenderers[gameObject6].enabled = false;
			gameObject6 = (GameObject)UnityEngine.Object.Instantiate(original, Vector3.zero, Quaternion.identity);
			position6 = new Vector3(room4.transform.position.x + x / 2f, room4.transform.position.y - y / 2f, z);
			gameObject6.transform.position = position6;
			gameObject6.transform.Rotate(new Vector3(0f, 0f, 180f));
			gameObject6.transform.parent = room4.transform;
			room4.wallModels.Add(gameObject6);
			room4.wallModelsRenderers[gameObject6] = gameObject6.GetComponentInChildren<Renderer>();
			room4.wallModelsRenderers[gameObject6].enabled = false;
		}
		BoardingShip boardingShip = null;
		Corridor corridor6 = null;
		Room[] array = UnityEngine.Object.FindObjectsOfType(typeof(BoardingShip)) as Room[];
		int num19 = array.Length;
		int num20 = 0;
		if (num20 < num19)
		{
			boardingShip = (BoardingShip)array[num20];
		}
		Corridor[] array2 = UnityEngine.Object.FindObjectsOfType(typeof(Corridor)) as Corridor[];
		num19 = array2.Length;
		for (int num21 = 0; num21 < num19; num21++)
		{
			Corridor corridor7 = array2[num21];
			if (corridor7.LeadsIntoShip)
			{
				corridor6 = corridor7;
				break;
			}
		}
		if (boardingShip != null && corridor6 != null)
		{
			firstRoom = corridor6.rooms[0];
			firstRoom.AddCorridor(corridor6);
			boardingShip.Dock(corridor6);
		}
		else if (!(firstRoom == null))
		{
		}
		if (firstRoom != null)
		{
			num19 = firstRoom.Waypoints.Count;
			for (int num22 = 0; num22 < num19; num22++)
			{
				firstRoom.Waypoints[num22].WaypointType = WaypointTypeEnum.None;
			}
		}
		num19 = dungeonBoard.rooms.Count;
		for (int num23 = 0; num23 < num19; num23++)
		{
			DungeonRoom dungeonRoom2 = dungeonBoard.rooms[num23];
			if (dungeonRoom2.powerInlet == null)
			{
				continue;
			}
			Room room5 = builtRooms[dungeonRoom2.index];
			Vector3 position7 = new Vector3((float)dungeonRoom2.powerInlet.origin.x + 0.5f, (float)dungeonRoom2.powerInlet.origin.y + 0.5f, 0f);
			position7.x += xOffset;
			position7.y += yOffset;
			GameObject gameObject7 = (GameObject)UnityEngine.Object.Instantiate(powerInletPrefab, position7, Quaternion.identity);
			DungeonPowerInlet dungeonPowerInlet = gameObject7.GetComponentInChildren(typeof(DungeonPowerInlet)) as DungeonPowerInlet;
			dungeonPowerInlet.roomLocation = room5;
			room5.roomItems.Add(dungeonPowerInlet);
			int item = dungeonRoom2.powerGrids[0];
			for (int num24 = 0; num24 < num19; num24++)
			{
				DungeonRoom dungeonRoom3 = dungeonBoard.rooms[num24];
				if (dungeonRoom3.powerGrids.Contains(item) && builtRooms[dungeonRoom3.index] != null)
				{
					dungeonPowerInlet.rooms.Add(builtRooms[dungeonRoom3.index]);
					if (builtRooms[dungeonRoom3.index].potentialPowerSourceList == null)
					{
						builtRooms[dungeonRoom3.index].potentialPowerSourceList = new List<DungeonPowerInlet>();
					}
					builtRooms[dungeonRoom3.index].potentialPowerSourceList.Add(dungeonPowerInlet);
				}
			}
		}
		num19 = dungeonBoard.rooms.Count;
		for (int num25 = 0; num25 < num19; num25++)
		{
			DungeonRoom dungeonRoom4 = dungeonBoard.rooms[num25];
			if (dungeonRoom4.terminal == null)
			{
				continue;
			}
			Room room6 = builtRooms[dungeonRoom4.index];
			GameObject gameObject8;
			if (!dungeonRoom4.terminal.horizontal)
			{
				Vector2 vector3 = new Vector3(dungeonRoom4.terminal.origin.x, (float)dungeonRoom4.terminal.origin.y + 0.5f, 0f);
				vector3.x += xOffset;
				vector3.y += yOffset;
				gameObject8 = (GameObject)UnityEngine.Object.Instantiate(terminalPrefab, vector3, Quaternion.identity);
				if (vector3.x < room6.transform.position.x)
				{
					gameObject8.transform.Rotate(new Vector3(0f, 0f, 90f));
				}
				else
				{
					gameObject8.transform.Rotate(new Vector3(0f, 0f, -90f));
				}
			}
			else
			{
				Vector3 position8 = new Vector3((float)dungeonRoom4.terminal.origin.x + 0.5f, dungeonRoom4.terminal.origin.y, 0f);
				position8.x += xOffset;
				position8.y += yOffset;
				gameObject8 = (GameObject)UnityEngine.Object.Instantiate(terminalPrefab, position8, Quaternion.identity);
				if (position8.y < room6.transform.position.y)
				{
					gameObject8.transform.Rotate(new Vector3(0f, 0f, 180f));
				}
			}
			DungeonTerminal dungeonTerminal = gameObject8.GetComponentInChildren(typeof(DungeonTerminal)) as DungeonTerminal;
			dungeonTerminal.roomLocation = room6;
			if (GameSaveFile.Get("NC", false) && UnityEngine.Random.Range(0, 100) < 10)
			{
				dungeonTerminal.TakeDamage(1000f, DamageType.Physical, null, true);
			}
			room6.roomItems.Add(dungeonTerminal);
			dungeonTerminal.type = dungeonRoom4.terminal.type;
		}
		num19 = dungeonBoard.rooms.Count;
		for (int num26 = 0; num26 < num19; num26++)
		{
			DungeonRoom dungeonRoom5 = dungeonBoard.rooms[num26];
			if (dungeonRoom5.defense == null)
			{
				continue;
			}
			Quaternion identity = Quaternion.identity;
			Vector3 position9 = new Vector3(dungeonRoom5.defense.origin.x, dungeonRoom5.defense.origin.y, -0.1f);
			position9.x += xOffset;
			position9.y += yOffset;
			GameObject gameObject9 = (GameObject)UnityEngine.Object.Instantiate(defensePrefab, position9, identity);
			Room room7 = builtRooms[dungeonRoom5.index];
			Transform transform = gameObject9.transform.Find("ShipDefensesPrefab");
			Transform transform2 = null;
			Transform transform3 = null;
			if (transform != null)
			{
				transform2 = transform.Find("DVOverlay");
				if (transform2 != null)
				{
					transform2.parent = null;
				}
				transform3 = transform.Find("SVOverlay");
				if (transform3 != null)
				{
					transform3.parent = null;
				}
			}
			else
			{
				Debug.LogError("Couldn't find object named ShipDefensesPrefab");
			}
			if (position9.x > room7.transform.position.x && position9.y < room7.transform.position.y + (room7.transform.localScale.y / 2f - 0.5f) && position9.y > room7.transform.position.y - (room7.transform.localScale.y / 2f - 0.5f))
			{
				gameObject9.transform.Rotate(new Vector3(0f, 0f, -90f));
			}
			else if (position9.x < room7.transform.position.x && position9.y < room7.transform.position.y + (room7.transform.localScale.y / 2f - 0.5f) && position9.y > room7.transform.position.y - (room7.transform.localScale.y / 2f - 0.5f))
			{
				gameObject9.transform.Rotate(new Vector3(0f, 0f, 90f));
			}
			else if (position9.y < room7.transform.position.y)
			{
				gameObject9.transform.Rotate(new Vector3(0f, 0f, 180f));
			}
			if (transform != null)
			{
				if (transform2 != null)
				{
					transform2.parent = transform;
				}
				if (transform3 != null)
				{
					transform3.parent = transform;
				}
			}
			DungeonDefense dungeonDefense = gameObject9.GetComponentInChildren(typeof(DungeonDefense)) as DungeonDefense;
			dungeonDefense.roomLocation = room7;
			room7.roomItems.Add(dungeonDefense);
		}
		num19 = dungeonBoard.rooms.Count;
		for (int num27 = 0; num27 < num19; num27++)
		{
			DungeonRoom dungeonRoom6 = dungeonBoard.rooms[num27];
			if (dungeonRoom6.vent != null)
			{
				Quaternion identity2 = Quaternion.identity;
				if (dungeonRoom6.vent.horizontal)
				{
					identity2.eulerAngles = new Vector3(0f, 90f, 270f);
				}
				else
				{
					identity2.eulerAngles = new Vector3(90f, 180f, 0f);
				}
				Vector3 position10 = new Vector3(dungeonRoom6.vent.origin.x, dungeonRoom6.vent.origin.y, -0.1f);
				position10.x += xOffset;
				position10.y += yOffset;
				GameObject gameObject10 = (GameObject)UnityEngine.Object.Instantiate(ventPrefab, position10, identity2);
				Room room8 = builtRooms[dungeonRoom6.index];
				SwamSpawnVent swamSpawnVent = gameObject10.GetComponentInChildren(typeof(SwamSpawnVent)) as SwamSpawnVent;
				swamSpawnVent.roomLocation = room8;
				swamSpawnVent.benign = !GameSaveFile.Get("D_VENT", true);
				room8.roomItems.Add(swamSpawnVent);
			}
		}
		int num28 = Mathf.RoundToInt((float)(builtRooms.Count - 1) * 0.33f);
		if (num28 <= 0)
		{
			num28 = 1;
		}
		do
		{
			Room room9 = null;
			do
			{
				int index = UnityEngine.Random.Range(0, builtRooms.Count);
				if (!builtRooms[index].boardingVessel && builtRooms[index].asRAmbientEquipment == null)
				{
					room9 = builtRooms[index];
				}
			}
			while (room9 == null);
			if (!room9.boardingVessel)
			{
				GameObject gameObject11 = (GameObject)UnityEngine.Object.Instantiate(audioEmitterPrefab, Vector3.zero, Quaternion.identity);
				List<RoomItem> damagableRoomItems = room9.GetDamagableRoomItems(false);
				if (damagableRoomItems != null && damagableRoomItems.Count > 0)
				{
					int index2 = UnityEngine.Random.Range(0, damagableRoomItems.Count);
					gameObject11.transform.parent = damagableRoomItems[index2].gameObject.transform;
					gameObject11.transform.localPosition = Vector3.zero;
				}
				else
				{
					gameObject11.transform.parent = room9.gameObject.transform;
					float x2 = UnityEngine.Random.Range(room9.transform.position.x - room9.transform.localScale.x / 2f, room9.transform.position.x + room9.transform.localScale.x / 2f);
					float y2 = UnityEngine.Random.Range(room9.transform.position.y - room9.transform.localScale.y / 2f, room9.transform.position.y + room9.transform.localScale.y / 2f);
					gameObject11.transform.position = new Vector3(x2, y2, 0f);
				}
				room9.asRAmbientEquipment = gameObject11.GetComponent<AudioSource>();
				room9.asRAmbientEquipment.spatialBlend = 1f;
				room9.asRAmbientEquipment.loop = true;
				room9.asRAmbientEquipment.playOnAwake = false;
				GameAudio.SoundEnum key = GameAudio.SoundEnum.None;
				switch (UnityEngine.Random.Range(0, 21))
				{
				case 0:
					key = GameAudio.SoundEnum.Remote_A_Emiter1;
					break;
				case 1:
					key = GameAudio.SoundEnum.Remote_A_Emiter2;
					break;
				case 2:
					key = GameAudio.SoundEnum.Remote_A_Emiter3;
					break;
				case 3:
					key = GameAudio.SoundEnum.Remote_A_Emiter4;
					break;
				case 4:
					key = GameAudio.SoundEnum.Remote_A_Emiter5;
					break;
				case 5:
					key = GameAudio.SoundEnum.Remote_A_Emiter6;
					break;
				case 6:
					key = GameAudio.SoundEnum.Remote_A_Emiter7;
					break;
				case 7:
					key = GameAudio.SoundEnum.Remote_A_Emiter8;
					break;
				case 8:
					key = GameAudio.SoundEnum.Remote_A_Emiter9;
					break;
				case 9:
					key = GameAudio.SoundEnum.Remote_A_Emiter10;
					break;
				case 10:
					key = GameAudio.SoundEnum.Remote_A_Emiter11;
					break;
				case 11:
					key = GameAudio.SoundEnum.Remote_A_Emiter12;
					break;
				case 12:
					key = GameAudio.SoundEnum.Remote_A_Emiter13;
					break;
				case 13:
					key = GameAudio.SoundEnum.Remote_A_Emiter14;
					break;
				case 14:
					key = GameAudio.SoundEnum.Remote_A_Emiter15;
					break;
				case 15:
					key = GameAudio.SoundEnum.Remote_A_Emiter16;
					break;
				case 16:
					key = GameAudio.SoundEnum.Remote_A_Emiter17;
					break;
				case 17:
					key = GameAudio.SoundEnum.Remote_A_Emiter18;
					break;
				case 18:
					key = GameAudio.SoundEnum.Remote_A_Emiter19;
					break;
				case 19:
					key = GameAudio.SoundEnum.Remote_A_Emiter20;
					break;
				case 20:
					key = GameAudio.SoundEnum.Remote_A_Emiter21;
					break;
				}
				room9.asRAmbientEquipment.clip = GameAudio.GetClip(key);
				room9.asRAmbientEquipment.volume = GameAudio.VolumeMultiplier(key, GameAudio.AmbienceVolume);
			}
			num28--;
		}
		while (num28 > 0);
		num = (int)DateTime.Now.Ticks;
		if (SeedLargeDebris != -1)
		{
			num = SeedLargeDebris;
		}
		random = new System.Random(num);
		if (enableLargeObjectPlacement)
		{
			DungeonGenerator instance = DungeonGenerator.GetInstance();
			num19 = dungeonBoard.rooms.Count;
			for (int num29 = 0; num29 < num19; num29++)
			{
				DungeonRoom dungeonRoom7 = dungeonBoard.rooms[num29];
				Room room10 = builtRooms[dungeonRoom7.index];
				float num30 = (float)(dungeonRoom7.dimensions.x * dungeonRoom7.dimensions.y) * room10.roomConfig.propFactor;
				if (dungeonRoom7.dimensions.x <= 2 || dungeonRoom7.dimensions.y <= 2 || !(num30 > 9f))
				{
					continue;
				}
				Bounds bounds5 = room10.GetComponent<Collider>().bounds;
				float num31 = 0f;
				switch (GameSaveFile.Get("P_QWO", 0))
				{
				case 0:
					num31 = 0.2f;
					break;
				case 1:
					num31 = 0.1f;
					break;
				case 2:
					num31 = 0.05f;
					break;
				}
				int num32 = 0;
				num32 = ((GameSaveFile.Get("NC", false) && !GlobalSettings.IsTutorial) ? random.Next(0, (int)(num31 * num30)) : random.Next(0, 2));
				List<DungeonTile> usedTiles = dungeonRoom7.usedTiles;
				float num33 = dungeonRoom7.origin.x;
				float num34 = dungeonRoom7.endpoints.x;
				float num35 = dungeonRoom7.origin.y;
				float num36 = dungeonRoom7.endpoints.y;
				for (int num37 = 0; num37 < num32; num37++)
				{
					bool flag5 = false;
					int num38 = 0;
					Vector3 zero = Vector3.zero;
					string empty = string.Empty;
					int maxValue = 4;
					if (num30 < 15f)
					{
						maxValue = 1;
					}
					else if (num30 < 25f)
					{
						maxValue = 2;
					}
					else if (num30 < 64f)
					{
						maxValue = 3;
					}
					int num39 = random.Next(0, maxValue);
					Quaternion rotation = Quaternion.identity;
					bool flag6 = false;
					int num40 = random.Next(0, room10.roomConfig.propWeight);
					DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigProp dungeonRoomConfigProp = null;
					int count9 = room10.roomConfig.propList.Count;
					for (int num41 = 0; num41 < count9; num41++)
					{
						DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigProp dungeonRoomConfigProp2 = room10.roomConfig.propList[num41];
						if (num40 < dungeonRoomConfigProp2.weightAdj)
						{
							dungeonRoomConfigProp = dungeonRoomConfigProp2;
							break;
						}
					}
					if (random.Next(0, 100) < dungeonRoomConfigProp.chanceOfRotate)
					{
						rotation = Quaternion.AngleAxis(random.NextFloat(dungeonRoomConfigProp.rotateMin, dungeonRoomConfigProp.rotateMax), Vector3.forward);
					}
					flag6 = !dungeonRoomConfigProp.excludeFromCollision;
					empty = dungeonRoomConfigProp.fileName;
					GameObject mesh = ResourceManager.GetMesh(ResourceManager.MeshTypeEnum.LargeObject, empty);
					GameObject gameObject12 = (GameObject)UnityEngine.Object.Instantiate(mesh, zero, rotation);
					if (flag6)
					{
						room10.StaticCollisionObjects.Add(gameObject12);
					}
					do
					{
						zero.x = random.NextFloat(num33, num34);
						zero.y = random.NextFloat(num35, num36);
						int num42 = (int)Mathf.Round(zero.x);
						int num43 = (int)Mathf.Round(zero.y);
						bool flag7 = false;
						if (num42 == (int)num33 || num42 == (int)num34 || num43 == (int)num35 || num43 == (int)num36)
						{
							gameObject12.transform.position = zero;
							Bounds bounds6 = gameObject12.GetComponent<Collider>().bounds;
							if (bounds5.min.y > bounds6.min.y || bounds5.max.y < bounds6.max.y || bounds5.min.x > bounds6.min.x || bounds5.max.x < bounds6.max.x)
							{
								num38++;
								continue;
							}
							int num44 = (int)Mathf.Round(bounds6.min.x - 0.5f);
							int num45 = (int)Mathf.Round(bounds6.max.x + 0.5f);
							int num46 = (int)Mathf.Round(bounds6.min.y - 0.5f);
							int num47 = (int)Mathf.Round(bounds6.max.y + 0.5f);
							num44--;
							num45++;
							num46--;
							num47++;
							if (num44 < 0)
							{
								num44 = 0;
							}
							if (num46 < 0)
							{
								num46 = 0;
							}
							if (num45 >= instance.tiles.GetLength(0))
							{
								num45 = instance.tiles.GetLength(0) - 1;
							}
							if (num47 >= instance.tiles.GetLength(1))
							{
								num47 = instance.tiles.GetLength(1) - 1;
							}
							if (dungeonRoom7.powerInlet != null)
							{
								float num48 = dungeonRoom7.powerInlet.origin.x - dungeonRoom7.powerInlet.dimensions.x / 2;
								float num49 = dungeonRoom7.powerInlet.origin.x + dungeonRoom7.powerInlet.dimensions.x / 2;
								float num50 = dungeonRoom7.powerInlet.origin.y - dungeonRoom7.powerInlet.dimensions.y / 2;
								float num51 = dungeonRoom7.powerInlet.origin.y + dungeonRoom7.powerInlet.dimensions.y / 2;
								int num52 = -1;
								Coordinate2D origin = dungeonRoom7.origin;
								num52 = ((dungeonRoom7.powerInlet.origin.x != origin.x) ? ((dungeonRoom7.powerInlet.origin.x == origin.x + dungeonRoom7.dimensions.x - 2) ? 1 : ((dungeonRoom7.powerInlet.origin.y == origin.y + dungeonRoom7.dimensions.y - 2) ? 2 : ((dungeonRoom7.powerInlet.origin.y != origin.y) ? (-1) : 3))) : 0);
								if (num48 < 0f)
								{
									num48 = 0f;
								}
								if (num49 > (float)(dungeonRoom7.origin.x + dungeonRoom7.dimensions.x))
								{
									num49 = dungeonRoom7.origin.x + dungeonRoom7.dimensions.x;
								}
								if (num51 > (float)(dungeonRoom7.origin.y + dungeonRoom7.dimensions.y))
								{
									num51 = dungeonRoom7.origin.y + dungeonRoom7.dimensions.y;
								}
								if (num50 < 0f)
								{
									num50 = 0f;
								}
								bool flag8 = false;
								switch (num52)
								{
								case 0:
									if (!((float)num44 <= num49))
									{
										break;
									}
									if ((float)num46 <= num50 && (float)num47 >= num51)
									{
										flag8 = true;
									}
									else if (num51 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num50 && (float)num46 <= num51)
										{
											flag8 = true;
										}
										else if ((float)num47 >= num50 && (float)num47 <= num51)
										{
											flag8 = true;
										}
									}
									break;
								case 1:
									if (!((float)num45 >= num48))
									{
										break;
									}
									if ((float)num46 <= num50 && (float)num47 >= num51)
									{
										flag8 = true;
									}
									else if (num51 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num50 && (float)num46 <= num51)
										{
											flag8 = true;
										}
										else if ((float)num47 >= num50 && (float)num47 <= num51)
										{
											flag8 = true;
										}
									}
									break;
								case 2:
									if ((float)num44 <= num48 && (float)num45 >= num49 && (float)num47 >= num50)
									{
										flag8 = true;
									}
									break;
								case 3:
									if ((float)num44 <= num48 && (float)num45 >= num49 && (float)num46 <= num51)
									{
										flag8 = true;
									}
									break;
								}
								if (flag8)
								{
									num38++;
									flag7 = true;
								}
							}
							if (dungeonRoom7.fuelAccess != null)
							{
								float num53 = dungeonRoom7.fuelAccess.origin.x - dungeonRoom7.fuelAccess.dimensions.x / 2;
								float num54 = dungeonRoom7.fuelAccess.origin.x + dungeonRoom7.fuelAccess.dimensions.x / 2;
								float num55 = dungeonRoom7.fuelAccess.origin.y - dungeonRoom7.fuelAccess.dimensions.y / 2;
								float num56 = dungeonRoom7.fuelAccess.origin.y + dungeonRoom7.fuelAccess.dimensions.y / 2;
								int num57 = -1;
								Coordinate2D origin2 = dungeonRoom7.origin;
								num57 = ((dungeonRoom7.fuelAccess.origin.x != origin2.x) ? ((dungeonRoom7.fuelAccess.origin.x == origin2.x + dungeonRoom7.dimensions.x - 2) ? 1 : ((dungeonRoom7.fuelAccess.origin.y == origin2.y + dungeonRoom7.dimensions.y - 2) ? 2 : ((dungeonRoom7.fuelAccess.origin.y != origin2.y) ? (-1) : 3))) : 0);
								if (num53 < 0f)
								{
									num53 = 0f;
								}
								if (num54 > (float)(dungeonRoom7.origin.x + dungeonRoom7.dimensions.x))
								{
									num54 = dungeonRoom7.origin.x + dungeonRoom7.dimensions.x;
								}
								if (num56 > (float)(dungeonRoom7.origin.y + dungeonRoom7.dimensions.y))
								{
									num56 = dungeonRoom7.origin.y + dungeonRoom7.dimensions.y;
								}
								if (num55 < 0f)
								{
									num55 = 0f;
								}
								bool flag9 = false;
								switch (num57)
								{
								case 0:
									if (!((float)num44 <= num54))
									{
										break;
									}
									if ((float)num46 <= num55 && (float)num47 >= num56)
									{
										flag9 = true;
									}
									else if (num56 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num55 && (float)num46 <= num56)
										{
											flag9 = true;
										}
										else if ((float)num47 >= num55 && (float)num47 <= num56)
										{
											flag9 = true;
										}
									}
									break;
								case 1:
									if (!((float)num45 >= num53))
									{
										break;
									}
									if ((float)num46 <= num55 && (float)num47 >= num56)
									{
										flag9 = true;
									}
									else if (num56 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num55 && (float)num46 <= num56)
										{
											flag9 = true;
										}
										else if ((float)num47 >= num55 && (float)num47 <= num56)
										{
											flag9 = true;
										}
									}
									break;
								case 2:
									if ((float)num44 <= num53 && (float)num45 >= num54 && (float)num47 >= num55)
									{
										flag9 = true;
									}
									break;
								case 3:
									if ((float)num44 <= num53 && (float)num45 >= num54 && (float)num46 <= num56)
									{
										flag9 = true;
									}
									break;
								}
								if (flag9)
								{
									num38++;
									flag7 = true;
								}
							}
							if (dungeonRoom7.terminal != null)
							{
								float num58 = dungeonRoom7.terminal.origin.x - 1;
								float num59 = dungeonRoom7.terminal.origin.x + 1;
								float num60 = dungeonRoom7.terminal.origin.y - 1;
								float num61 = dungeonRoom7.terminal.origin.y + 1;
								if (dungeonRoom7.terminal.horizontal)
								{
									num58 -= 1f;
									num59 += 1f;
								}
								else
								{
									num60 -= 1f;
									num61 += 1f;
								}
								int num62 = -1;
								Coordinate2D origin3 = dungeonRoom7.origin;
								num62 = ((dungeonRoom7.terminal.origin.x != origin3.x) ? ((dungeonRoom7.terminal.origin.x == origin3.x + dungeonRoom7.dimensions.x - 1) ? 1 : ((dungeonRoom7.terminal.origin.y == origin3.y + dungeonRoom7.dimensions.y - 1) ? 2 : ((dungeonRoom7.terminal.origin.y != origin3.y) ? (-1) : 3))) : 0);
								if (num58 < 0f)
								{
									num58 = 0f;
								}
								if (num59 > (float)(dungeonRoom7.origin.x + dungeonRoom7.dimensions.x + 1))
								{
									num59 = dungeonRoom7.origin.x + dungeonRoom7.dimensions.x;
								}
								if (num61 > (float)(dungeonRoom7.origin.y + dungeonRoom7.dimensions.y))
								{
									num61 = dungeonRoom7.origin.y + dungeonRoom7.dimensions.y;
								}
								if (num60 < 0f)
								{
									num60 = 0f;
								}
								bool flag10 = false;
								switch (num62)
								{
								case 0:
									if (!((float)num44 <= num59))
									{
										break;
									}
									if ((float)num46 <= num60 + 2f && (float)num47 >= num61 - 1f)
									{
										flag10 = true;
									}
									else if (num61 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num60 && (float)num46 <= num61)
										{
											flag10 = true;
										}
										else if ((float)num47 >= num60 && (float)num47 <= num61)
										{
											flag10 = true;
										}
									}
									break;
								case 1:
									if (!((float)num45 >= num58))
									{
										break;
									}
									if ((float)num46 <= num60 + 2f && (float)num47 >= num61 - 1f)
									{
										flag10 = true;
									}
									else if (num61 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num60 && (float)num46 <= num61)
										{
											flag10 = true;
										}
										else if ((float)num47 >= num60 && (float)num47 <= num61)
										{
											flag10 = true;
										}
									}
									break;
								case 2:
									if (!((float)num47 >= num60))
									{
										break;
									}
									if ((float)num44 <= num58 + 1f && (float)num45 >= num59 - 1f)
									{
										flag10 = true;
									}
									else if (num59 == (float)dungeonRoom7.dimensions.x)
									{
										if ((float)num44 >= num58 && (float)num44 <= num59)
										{
											flag10 = true;
										}
										else if ((float)num45 >= num58 && (float)num45 <= num59)
										{
											flag10 = true;
										}
									}
									break;
								case 3:
									if (!((float)num46 <= num61))
									{
										break;
									}
									if ((float)num44 <= num58 + 1f && (float)num45 >= num59 - 1f)
									{
										flag10 = true;
									}
									else if (num59 == (float)dungeonRoom7.dimensions.x)
									{
										if ((float)num44 >= num58 && (float)num44 <= num59)
										{
											flag10 = true;
										}
										else if ((float)num45 >= num58 && (float)num45 <= num59)
										{
											flag10 = true;
										}
									}
									break;
								}
								if (flag10)
								{
									num38++;
									flag7 = true;
								}
							}
							if (dungeonRoom7.defense != null)
							{
								float num63 = dungeonRoom7.defense.origin.x - 1;
								float num64 = dungeonRoom7.defense.origin.x;
								float num65 = dungeonRoom7.defense.origin.y - 1;
								float num66 = dungeonRoom7.defense.origin.y + 1;
								int num67 = -1;
								Coordinate2D origin4 = dungeonRoom7.origin;
								num67 = ((dungeonRoom7.defense.origin.x != origin4.x) ? ((dungeonRoom7.defense.origin.x == origin4.x + dungeonRoom7.dimensions.x - 1) ? 1 : ((dungeonRoom7.defense.origin.y == origin4.y + dungeonRoom7.dimensions.y - 1) ? 2 : ((dungeonRoom7.defense.origin.y != origin4.y) ? (-1) : 3))) : 0);
								if (num63 < 0f)
								{
									num63 = 0f;
								}
								if (num64 > (float)(dungeonRoom7.origin.x + dungeonRoom7.dimensions.x))
								{
									num64 = dungeonRoom7.origin.x + dungeonRoom7.dimensions.x;
								}
								if (num66 >= (float)(dungeonRoom7.origin.y + dungeonRoom7.dimensions.y))
								{
									num66 = dungeonRoom7.origin.y + dungeonRoom7.dimensions.y - 1;
								}
								if (num65 < 0f)
								{
									num65 = 0f;
								}
								bool flag11 = false;
								switch (num67)
								{
								case 0:
									if ((float)num44 <= num64 && (float)num46 <= num65 && (float)num47 >= num66 - 1f)
									{
										flag11 = true;
									}
									break;
								case 1:
									if ((float)num45 >= num63 && (float)num46 <= num65 && (float)num47 >= num66 - 1f)
									{
										flag11 = true;
									}
									break;
								case 2:
									if ((float)num47 >= num65 && (float)num44 <= num63 && (float)num45 >= num64 - 1f)
									{
										flag11 = true;
									}
									break;
								case 3:
									if ((float)num46 <= num66 && (float)num44 <= num63 && (float)num45 >= num64 - 1f)
									{
										flag11 = true;
									}
									break;
								}
								if (flag11)
								{
									num38++;
									flag7 = true;
								}
							}
							if (dungeonRoom7.vent != null)
							{
								float num68 = dungeonRoom7.vent.origin.x + 1;
								float num69 = dungeonRoom7.vent.origin.x;
								float num70 = dungeonRoom7.vent.origin.y - 1;
								float num71 = dungeonRoom7.vent.origin.y + 1;
								if (dungeonRoom7.vent.horizontal)
								{
									num68 -= 1f;
									num69 += 1f;
								}
								else
								{
									num70 -= 1f;
									num71 += 1f;
								}
								int num72 = -1;
								Coordinate2D origin5 = dungeonRoom7.origin;
								num72 = ((dungeonRoom7.vent.origin.x != origin5.x) ? ((dungeonRoom7.vent.origin.x == origin5.x + dungeonRoom7.dimensions.x - 1) ? 1 : ((dungeonRoom7.vent.origin.y == origin5.y + dungeonRoom7.dimensions.y - 1) ? 2 : ((dungeonRoom7.vent.origin.y != origin5.y) ? (-1) : 3))) : 0);
								if (num68 < 0f)
								{
									num68 = 0f;
								}
								if (num69 > (float)(dungeonRoom7.origin.x + dungeonRoom7.dimensions.x + 1))
								{
									num69 = dungeonRoom7.origin.x + dungeonRoom7.dimensions.x;
								}
								if (num71 > (float)(dungeonRoom7.origin.y + dungeonRoom7.dimensions.y))
								{
									num71 = dungeonRoom7.origin.y + dungeonRoom7.dimensions.y;
								}
								if (num70 < 0f)
								{
									num70 = 0f;
								}
								bool flag12 = false;
								switch (num72)
								{
								case 0:
									if (!((float)num44 <= num69))
									{
										break;
									}
									if ((float)num46 <= num70 + 2f && (float)num47 >= num71 - 1f)
									{
										flag12 = true;
									}
									else if (num71 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num70 && (float)num46 <= num71)
										{
											flag12 = true;
										}
										else if ((float)num47 >= num70 && (float)num47 <= num71)
										{
											flag12 = true;
										}
									}
									break;
								case 1:
									if (!((float)num45 >= num68))
									{
										break;
									}
									if ((float)num46 <= num70 + 2f && (float)num47 >= num71 - 1f)
									{
										flag12 = true;
									}
									else if (num71 == (float)dungeonRoom7.dimensions.y)
									{
										if ((float)num46 >= num70 && (float)num46 <= num71)
										{
											flag12 = true;
										}
										else if ((float)num47 >= num70 && (float)num47 <= num71)
										{
											flag12 = true;
										}
									}
									break;
								case 2:
									if (!((float)num47 >= num70))
									{
										break;
									}
									if ((float)num44 <= num68 + 1f && (float)num45 >= num69 - 1f)
									{
										flag12 = true;
									}
									else if (num69 == (float)dungeonRoom7.dimensions.x)
									{
										if ((float)num44 >= num68 && (float)num44 <= num69)
										{
											flag12 = true;
										}
										else if ((float)num45 >= num68 && (float)num45 <= num69)
										{
											flag12 = true;
										}
									}
									break;
								case 3:
									if (!((float)num46 <= num71))
									{
										break;
									}
									if ((float)num44 <= num68 + 1f && (float)num45 >= num69 - 1f)
									{
										flag12 = true;
									}
									else if (num69 == (float)dungeonRoom7.dimensions.x)
									{
										if ((float)num44 >= num68 && (float)num44 <= num69)
										{
											flag12 = true;
										}
										else if ((float)num45 >= num68 && (float)num45 <= num69)
										{
											flag12 = true;
										}
									}
									break;
								}
								if (flag12)
								{
									num38++;
									flag7 = true;
								}
							}
							if (usedTiles != null)
							{
								int count10 = usedTiles.Count;
								for (int num73 = 0; num73 < count10; num73++)
								{
									DungeonTile dungeonTile = usedTiles[num73];
									if (dungeonTile.position.x >= num44 && dungeonTile.position.x <= num45 && dungeonTile.position.y >= num46 && dungeonTile.position.y <= num47)
									{
										num38++;
										flag7 = true;
										break;
									}
								}
							}
							if (flag7)
							{
								continue;
							}
							for (int num74 = num44; num74 < num45; num74++)
							{
								for (int num75 = num46; num75 < num47; num75++)
								{
									if (instance.tiles[num74, num75].roomItemType != BoardTileRoomItemType.None)
									{
										num38++;
										flag7 = true;
										break;
									}
								}
								if (flag7)
								{
									break;
								}
							}
							if (flag7)
							{
								continue;
							}
							if (room10.environmentModelsLarge != null)
							{
								int count11 = room10.environmentModelsLarge.Count;
								Bounds bounds7 = gameObject12.GetComponent<Collider>().bounds;
								bool flag13 = false;
								if (room10 == firstRoom)
								{
									if (!GameSaveFile.Get("D_BLKOBJ_F", false))
									{
										flag13 = true;
									}
								}
								else if (!GameSaveFile.Get("D_BLKOBJ_O", true))
								{
									flag13 = true;
								}
								if (flag13 && (room10.transform.localScale.x <= 4f || room10.transform.localScale.y <= 4f))
								{
									bounds7.Expand(2f);
								}
								for (int num76 = 0; num76 < count11; num76++)
								{
									GameObject gameObject13 = room10.environmentModelsLarge[num76];
									if (gameObject13.GetComponent<Collider>().bounds.Intersects(bounds7))
									{
										num38++;
										flag7 = true;
										break;
									}
								}
								if (flag7)
								{
									continue;
								}
							}
							goto IL_4254;
						}
						num38++;
						flag7 = true;
						goto IL_4254;
						IL_4254:
						if (!flag7)
						{
							flag5 = true;
						}
					}
					while (!flag5 && num38 < 1000);
					if (flag5)
					{
						if (room10.environmentModelsLarge == null)
						{
							room10.environmentModelsLarge = new List<GameObject>();
							room10.environmentModelsLargeRenderers = new Dictionary<GameObject, Renderer>();
						}
						room10.environmentModelsLarge.Add(gameObject12);
						Renderer componentInChildren = gameObject12.GetComponentInChildren<Renderer>();
						if (componentInChildren != null)
						{
							if (!debugDisableHiddingModelsAtStart)
							{
								componentInChildren.enabled = false;
							}
							room10.environmentModelsLargeRenderers[gameObject12] = componentInChildren;
						}
						else if (!debugDisableHiddingModelsAtStart)
						{
							gameObject12.SetActive(false);
						}
					}
					else
					{
						UnityEngine.Object.Destroy(gameObject12);
					}
				}
			}
		}
		if (SeedSmallDebris != -1)
		{
			num = SeedSmallDebris;
		}
		random = new System.Random(num);
		if (!enableDebrisPlacement)
		{
			return;
		}
		int count12 = dungeonBoard.rooms.Count;
		for (int num77 = 0; num77 < count12; num77++)
		{
			DungeonRoom dungeonRoom8 = dungeonBoard.rooms[num77];
			Room room11 = builtRooms[dungeonRoom8.index];
			Bounds bounds8 = room11.GetComponent<Collider>().bounds;
			float num78 = (float)(dungeonRoom8.dimensions.x * dungeonRoom8.dimensions.y) * room11.roomConfig.debrisFactor;
			float num79 = 0f;
			switch (GameSaveFile.Get("P_QWO", 0))
			{
			case 0:
				num79 = 0.5f;
				break;
			case 1:
				num79 = 0.25f;
				break;
			case 2:
				num79 = 0.1f;
				break;
			}
			int num80 = random.Next(0, (int)(num79 / 1f * num78));
			List<DungeonTile> usedTiles2 = dungeonRoom8.usedTiles;
			float min = dungeonRoom8.origin.x;
			float max = dungeonRoom8.endpoints.x;
			float min2 = dungeonRoom8.origin.y;
			float max2 = dungeonRoom8.endpoints.y;
			for (int num81 = 0; num81 < num80; num81++)
			{
				bool flag14 = false;
				int num82 = 0;
				Vector3 zero2 = Vector3.zero;
				string empty2 = string.Empty;
				int num83 = random.Next(0, room11.roomConfig.debrisWeight);
				DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigDebris dungeonRoomConfigDebris = null;
				int count13 = room11.roomConfig.debrisList.Count;
				for (int num84 = 0; num84 < count13; num84++)
				{
					DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigDebris dungeonRoomConfigDebris2 = room11.roomConfig.debrisList[num84];
					if (num83 < dungeonRoomConfigDebris2.weightAdj)
					{
						dungeonRoomConfigDebris = dungeonRoomConfigDebris2;
						break;
					}
				}
				empty2 = dungeonRoomConfigDebris.fileName;
				GameObject mesh2 = ResourceManager.GetMesh(ResourceManager.MeshTypeEnum.Debris, empty2);
				Quaternion rotation2 = Quaternion.AngleAxis(random.NextFloat(-180f, 180f), Vector3.forward);
				GameObject gameObject14 = (GameObject)UnityEngine.Object.Instantiate(mesh2, zero2, rotation2);
				do
				{
					zero2.x = random.NextFloat(min, max);
					zero2.y = random.NextFloat(min2, max2);
					gameObject14.transform.position = zero2;
					Bounds bounds9 = gameObject14.GetComponent<Collider>().bounds;
					if (bounds8.min.y > bounds9.min.y || bounds8.max.y < bounds9.max.y || bounds8.min.x > bounds9.min.x || bounds8.max.x < bounds9.max.x)
					{
						num82++;
						continue;
					}
					bool flag15 = false;
					int num85 = (int)bounds9.min.x;
					int num86 = (int)bounds9.min.y;
					int num87 = (int)bounds9.max.x;
					int num88 = (int)bounds9.max.y;
					if (usedTiles2 != null && !flag15)
					{
						int count14 = usedTiles2.Count;
						int num89 = 0;
						if (num89 < count14)
						{
							DungeonTile dungeonTile2 = usedTiles2[num89];
							if (dungeonTile2.position.x >= num85 && dungeonTile2.position.x <= num87 && dungeonTile2.position.y >= num86 && dungeonTile2.position.y <= num88)
							{
								num82++;
								flag15 = true;
							}
						}
					}
					if (!flag15)
					{
						flag14 = true;
					}
				}
				while (!flag14 && num82 < 1000);
				if (flag14)
				{
					if (mesh2 != null)
					{
						if (!debugDisableHiddingModelsAtStart)
						{
							gameObject14.SetActive(false);
						}
						if (room11.environmentModels == null)
						{
							room11.environmentModels = new List<GameObject>();
						}
						room11.environmentModels.Add(gameObject14);
					}
				}
				else
				{
					UnityEngine.Object.Destroy(gameObject14);
				}
			}
		}
	}

	private void PlaceShipUpgradeSubsystem(Room room, Vector3 position, DungeonBoardShipSubSystems dSubSystem)
	{
		if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
		{
			GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.ShipUpgradeSlots++;
		}
		GameObject gameObject = null;
		gameObject = ((!dSubSystem.isPerm) ? ((GameObject)UnityEngine.Object.Instantiate(ResourceManager.UpgradeSubSystem1SlotPrefab, position, Quaternion.identity)) : ((GameObject)UnityEngine.Object.Instantiate(ResourceManager.UpgradeSubSystemPermSlotPrefab, position, Quaternion.identity)));
		ShipUpgradeSubsystemObject component = gameObject.GetComponent<ShipUpgradeSubsystemObject>();
		component.metaDataList = dSubSystem.metaDataList;
		component.IsPermUpgrade = dSubSystem.isPerm;
		if (DungeonManager.Instance != null)
		{
			DungeonManager.Instance.UpgradeSubSystems.Add(component);
		}
		component.roomLocation = room;
		room.roomItems.Add(component);
	}

	private ShipUpgradeInGameObject CreateShipUpgrade(Room room, Vector3 position, ShipUpgradeType specifiedShipUpgrade, System.Random rnd)
	{
		return CreateShipUpgrade(room, position, specifiedShipUpgrade, null, rnd);
	}

	private ShipUpgradeInGameObject CreateShipUpgrade(Room room, Vector3 position, ShipUpgradeType specifiedShipUpgrade, ShipUpgradeSubsystemObject slot, System.Random rnd)
	{
		GameObject gameObject = null;
		gameObject = ((!(slot != null) || !slot.IsPermUpgrade) ? UnityEngine.Object.Instantiate(ResourceManager.ShipUpgradeObjectPrefab) : UnityEngine.Object.Instantiate(ResourceManager.ShipUpgradePermObjectPrefab));
		gameObject.transform.position = position;
		ShipUpgradeInGameObject component = gameObject.GetComponent<ShipUpgradeInGameObject>();
		component.roomLocation = room;
		ShipUpgradeType upgradeType = ShipUpgradeType.Unknown;
		bool flag = true;
		bool flag2 = false;
		if (slot != null)
		{
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
			{
				string metaData = slot.GetMetaData("shipupgradetype");
				if (metaData != string.Empty && metaData != "0")
				{
					flag = false;
					switch (metaData)
					{
					case "1":
						component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.ShipSurveyor);
						break;
					case "2":
						component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.PowerManager);
						break;
					case "3":
						component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.RemotePower);
						break;
					case "4":
						component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.Transporter);
						break;
					case "5":
						component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.LongRangeScanner);
						break;
					}
				}
			}
			else if (slot.IsPermUpgrade)
			{
				flag = false;
				ShipUpgradeType shipUpgradeType = ShipUpgradeType.Unknown;
				switch (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.ToLower())
				{
				case "military":
					shipUpgradeType = ShipUpgradeType.PermCannon;
					break;
				case "barge":
					shipUpgradeType = ((UnityEngine.Random.Range(0, 2) != 0) ? ShipUpgradeType.PermDecontaminate : ShipUpgradeType.PermCollector);
					break;
				case "salvage":
					shipUpgradeType = ShipUpgradeType.PermCollector;
					break;
				case "tech":
				case "muteki":
					shipUpgradeType = ShipUpgradeType.PermOverload;
					break;
				case "private":
					shipUpgradeType = (ShipUpgradeType)UnityEngine.Random.Range(7, 9);
					break;
				case "medical":
					shipUpgradeType = ShipUpgradeType.PermDecontaminate;
					break;
				case "government":
					shipUpgradeType = ((UnityEngine.Random.Range(0, 2) != 0) ? ShipUpgradeType.PermOverload : ShipUpgradeType.PermCollector);
					break;
				default:
					shipUpgradeType = ShipUpgradeType.Unknown;
					break;
				}
				if (shipUpgradeType != ShipUpgradeType.Unknown)
				{
					component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(shipUpgradeType);
				}
			}
		}
		else if (specifiedShipUpgrade != ShipUpgradeType.Unknown)
		{
			component.ThisUpgrade = ShipUpgradeFactory.CreateUpgrade(specifiedShipUpgrade);
			flag = false;
			flag2 = true;
		}
		if (flag)
		{
			if (rnd == null)
			{
				component.ThisUpgrade = ShipUpgradeFactory.CreateRandom(out upgradeType);
			}
			else
			{
				component.ThisUpgrade = ShipUpgradeFactory.CreateRandom(rnd, out upgradeType);
			}
			flag2 = true;
		}
		if (flag2)
		{
			int num = UnityEngine.Random.Range(0, 5);
			component.ThisUpgrade.NumMissions = num;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					float num2 = UnityEngine.Random.Range(3f, 6f);
					float num3 = component.ThisUpgrade.UpgradeBreakFactor * num2;
					component.ThisUpgrade.BreakProbability += num3;
				}
			}
		}
		if (slot == null || !slot.IsPermUpgrade)
		{
			SlotInfo nextFreeSlot = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GetNextFreeSlot(component.ThisUpgrade.GroupKey);
			if (nextFreeSlot != null)
			{
				nextFreeSlot.InstallUpgrade(component.ThisUpgrade, GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.InstalledInventory);
				component.ThisUpgrade.SaveData(GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.GroupKey, nextFreeSlot.SlotNumber, true);
			}
		}
		DungeonManager.Instance.ShipUpgrades.Add(component);
		return component;
	}

	private void InitialSubSystemConfiguration()
	{
		if (!GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			System.Random random = null;
			if (GlobalSettings.gameMode != GameModeEnum.Normal)
			{
				int seed = (int)DateTime.Now.Ticks;
				if (SeedSubSystemContents != -1)
				{
					seed = SeedSubSystemContents;
				}
				random = new System.Random(seed);
			}
			bool flag = false;
			bool flag2 = false;
			ShipUpgradeType specifiedShipUpgrade = ShipUpgradeType.Unknown;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name == "Medical")
			{
				flag2 = true;
				specifiedShipUpgrade = ShipUpgradeType.Quarantine;
			}
			for (int i = 0; i < 2; i++)
			{
				switch (i)
				{
				case 0:
					flag = ((random != null) ? ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeWorkingChanceSet) ? (random.Next(1, 101) <= 75) : (random.Next(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeWorkingChance)) : ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeWorkingChanceSet) ? (UnityEngine.Random.Range(1, 101) <= 75) : (UnityEngine.Random.Range(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeWorkingChance)));
					break;
				case 1:
					if (DungeonManager.Instance.UpgradeSubSystems.Count < 2)
					{
						continue;
					}
					flag = ((random != null) ? ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeSecondWorkingChance) ? (random.Next(1, 101) <= 10) : ((float)random.Next(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeSecondWorkingChance)) : ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeSecondWorkingChance) ? (UnityEngine.Random.Range(1, 101) <= 10) : ((float)UnityEngine.Random.Range(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeSecondWorkingChance)));
					break;
				}
				if (!flag)
				{
					continue;
				}
				ShipUpgradeSubsystemObject shipUpgradeSubsystemObject = null;
				IEnumerable<ShipUpgradeSubsystemObject> source = DungeonManager.Instance.UpgradeSubSystems.Where((ShipUpgradeSubsystemObject x) => x != null && !x.IsPermUpgrade);
				List<ShipUpgradeSubsystemObject> sourceList = source.ToList();
				int num = 0;
				do
				{
					shipUpgradeSubsystemObject = CommonMethods.PickRandomItem(sourceList);
					num++;
				}
				while (i == 1 && shipUpgradeSubsystemObject.InstalledShipObject != null && num < 100);
				if (!(shipUpgradeSubsystemObject != null))
				{
					continue;
				}
				ShipUpgradeInGameObject shipUpgradeInGameObject = null;
				if (flag2 && GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
				{
					bool flag3 = false;
					if ((random != null) ? (random.Next(0, 100) < 75) : (UnityEngine.Random.Range(0, 100) < 75))
					{
						shipUpgradeInGameObject = CreateShipUpgrade(shipUpgradeSubsystemObject.roomLocation, shipUpgradeSubsystemObject.HookUpPoint.transform.position, specifiedShipUpgrade, random);
						flag2 = false;
					}
				}
				if (shipUpgradeInGameObject == null)
				{
					shipUpgradeInGameObject = CreateShipUpgrade(shipUpgradeSubsystemObject.roomLocation, shipUpgradeSubsystemObject.HookUpPoint.transform.position, ShipUpgradeType.Unknown, random);
				}
				shipUpgradeSubsystemObject.InstalledShipObject = shipUpgradeInGameObject;
				bool flag4 = false;
				if ((random != null) ? (random.Next(1, 101) <= 60) : (UnityEngine.Random.Range(1, 101) <= 60))
				{
					shipUpgradeInGameObject.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose;
				}
				else
				{
					shipUpgradeInGameObject.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorking;
				}
			}
			int count = DungeonManager.Instance.UpgradeSubSystems.Count;
			for (int num2 = 0; num2 < count; num2++)
			{
				ShipUpgradeSubsystemObject shipUpgradeSubsystemObject2 = DungeonManager.Instance.UpgradeSubSystems[num2];
				if (!shipUpgradeSubsystemObject2.IsPermUpgrade)
				{
					if (!(shipUpgradeSubsystemObject2.InstalledShipObject == null))
					{
						continue;
					}
					bool flag5 = false;
					if (!((random == null) ? ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeBrokenChanceSet) ? (UnityEngine.Random.Range(1, 101) <= 25) : (UnityEngine.Random.Range(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeBrokenChance)) : ((GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty == null || !GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.hasShipUpgradeBrokenChanceSet) ? (random.Next(1, 101) <= 25) : (random.Next(1, 101) <= GlobalSettings.GameState.ThePlayer.CurrentDungeonProperty.shipUpgradeBrokenChance))))
					{
						continue;
					}
					ShipUpgradeInGameObject shipUpgradeInGameObject2 = null;
					if (flag2 && GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
					{
						bool flag6 = false;
						if ((random != null) ? (random.Next(0, 100) < 75) : (UnityEngine.Random.Range(0, 100) < 75))
						{
							shipUpgradeInGameObject2 = CreateShipUpgrade(shipUpgradeSubsystemObject2.roomLocation, shipUpgradeSubsystemObject2.HookUpPoint.transform.position, specifiedShipUpgrade, random);
							flag2 = false;
						}
					}
					if (shipUpgradeInGameObject2 == null)
					{
						shipUpgradeInGameObject2 = CreateShipUpgrade(shipUpgradeSubsystemObject2.roomLocation, shipUpgradeSubsystemObject2.HookUpPoint.transform.position, ShipUpgradeType.Unknown, random);
					}
					shipUpgradeInGameObject2.ThisUpgrade.Break();
					shipUpgradeSubsystemObject2.InstalledShipObject = shipUpgradeInGameObject2;
					bool flag7 = false;
					if ((random != null) ? (random.Next(1, 101) <= 50) : (UnityEngine.Random.Range(1, 101) <= 50))
					{
						shipUpgradeInGameObject2.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledBrokenLoose;
					}
					else
					{
						shipUpgradeInGameObject2.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledBroken;
					}
				}
				else
				{
					ShipUpgradeInGameObject shipUpgradeInGameObject3 = CreateShipUpgrade(shipUpgradeSubsystemObject2.roomLocation, shipUpgradeSubsystemObject2.HookUpPoint.transform.position, ShipUpgradeType.Unknown, shipUpgradeSubsystemObject2, random);
					shipUpgradeInGameObject3.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorking;
					shipUpgradeSubsystemObject2.InstalledShipObject = shipUpgradeInGameObject3;
				}
			}
		}
		else
		{
			if (DungeonManager.Instance.UpgradeSubSystems == null)
			{
				return;
			}
			int count2 = DungeonManager.Instance.UpgradeSubSystems.Count;
			for (int num3 = 0; num3 < count2; num3++)
			{
				ShipUpgradeSubsystemObject shipUpgradeSubsystemObject3 = DungeonManager.Instance.UpgradeSubSystems[num3];
				string metaData = shipUpgradeSubsystemObject3.GetMetaData("shipupgrade");
				if (metaData != string.Empty && metaData != "0")
				{
					ShipUpgradeInGameObject shipUpgradeInGameObject4 = CreateShipUpgrade(shipUpgradeSubsystemObject3.roomLocation, shipUpgradeSubsystemObject3.HookUpPoint.transform.position, ShipUpgradeType.Unknown, shipUpgradeSubsystemObject3, null);
					switch (metaData)
					{
					case "1":
						shipUpgradeInGameObject4.ThisUpgrade.Break();
						shipUpgradeSubsystemObject3.InstalledShipObject = shipUpgradeInGameObject4;
						shipUpgradeInGameObject4.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledBroken;
						break;
					case "2":
						shipUpgradeInGameObject4.ThisUpgrade.Break();
						shipUpgradeSubsystemObject3.InstalledShipObject = shipUpgradeInGameObject4;
						shipUpgradeInGameObject4.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledBrokenLoose;
						break;
					case "3":
						shipUpgradeSubsystemObject3.InstalledShipObject = shipUpgradeInGameObject4;
						shipUpgradeInGameObject4.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorking;
						break;
					case "4":
						shipUpgradeSubsystemObject3.InstalledShipObject = shipUpgradeInGameObject4;
						shipUpgradeInGameObject4.ShipUpgradeStatus = ShipUpgradeInGameObject.ShipUpgradeStatusEnum.InstalledWorkingLoose;
						break;
					}
				}
			}
		}
	}

	private void ClearBuilder()
	{
		foreach (Room builtRoom in builtRooms)
		{
			if (builtRoom != null && builtRoom.gameObject != null)
			{
				UnityEngine.Object.Destroy(builtRoom.gameObject);
			}
		}
		builtRooms.Clear();
		foreach (Corridor builtDoor in builtDoors)
		{
			if (builtDoor != null && builtDoor.gameObject != null)
			{
				UnityEngine.Object.Destroy(builtDoor.gameObject);
			}
		}
		builtDoors.Clear();
	}

	private void RemoveSoundSources()
	{
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter1);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter2);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter3);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter4);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter5);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter6);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter7);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter8);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter9);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter10);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter11);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter12);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter13);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter14);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter15);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter16);
		GameAudio.RemoveClip(GameAudio.SoundEnum.Remote_A_Emiter17);
	}
}
