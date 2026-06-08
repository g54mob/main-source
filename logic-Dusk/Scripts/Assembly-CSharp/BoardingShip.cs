using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardingShip : Room, ICommandable
{
	private enum DockingChangeEnum
	{
		NoChange = 0,
		SameSide = 1,
		LeftToRight = 2,
		LeftToTop = 3,
		LeftToBottom = 4,
		RightToLeft = 5,
		RightToTop = 6,
		RightToBottom = 7,
		TopToBottom = 8,
		TopToRight = 9,
		TopToLeft = 10,
		BottomToTop = 11,
		BottomToRight = 12,
		BottomToLeft = 13
	}

	private class TravelingData
	{
		public Vector3 offset;

		public TravelingData(Vector3 offset)
		{
			this.offset = offset;
		}
	}

	private class TravelingDataDrone : TravelingData
	{
		public Drone drone;

		public TravelingDataDrone(Vector3 offset, Drone drone)
			: base(offset)
		{
			this.drone = drone;
		}
	}

	private class TravelingDataEnemy : TravelingData
	{
		public BaseEnemy enemy;

		public TravelingDataEnemy(Vector3 offset, BaseEnemy enemy)
			: base(offset)
		{
			this.enemy = enemy;
		}
	}

	private class TravelingDroppableItem : TravelingData
	{
		public DropableItem item;

		public TravelingDroppableItem(Vector3 offset, DropableItem item)
			: base(offset)
		{
			this.item = item;
		}
	}

	private class TravelingShipUpgradeItem : TravelingData
	{
		public ShipUpgradeInGameObject item;

		public TravelingShipUpgradeItem(Vector3 offset, ShipUpgradeInGameObject item)
			: base(offset)
		{
			this.item = item;
		}
	}

	public static BoardingShip Instance;

	public List<GameObject> wallObjects;

	public AudioSource[] OwnedDbfNonBarkAudio;

	public AudioSource[] OwnedDbfBarkAudio;

	public AudioSource[] OwnedDbfWhineAudio;

	private List<TravelingDataDrone> travelingDroneList;

	private List<TravelingDroppableItem> travelingDroppableItemsList;

	private List<TravelingShipUpgradeItem> travelingShipUpgradeList;

	private List<TravelingDataEnemy> travelingEnemyList;

	private List<CommandDefinition> listCommands;

	private bool hasFirstDockOccured;

	private bool isFadingOutShip;

	private bool isFadingInShip;

	private bool isMovingShip;

	private bool isDockingChanging90Deg;

	private bool isDockingOnOppositeX;

	private bool isDockingOnOppositeY;

	private DockingChangeEnum dockingChange;

	private float timerFade;

	private float timerMove;

	private GameObject fakeFadeObject;

	private GameObject hideBoardingShipObject;

	private GameObject boardingShipOutline;

	private GameObject otherShipOutline;

	private GameObject closedDoorObject;

	private bool isSecondaryScan;

	private int nextObjectiveNotice;

	private float timerObjective;

	private bool closedDoorOnLeaving;

	public float ShipAlpha { get; private set; }

	public Corridor CurrentAirlock { get; private set; }

	public Corridor destinationAirlock { get; private set; }

	public bool IsRedockingShip { get; private set; }

	public bool isExecutingPandemicQuarentineObjective { get; private set; }

	public string CommandHeader
	{
		get
		{
			return "Boarding Vessel";
		}
	}

	public bool IsPrimaryCommandContext { get; set; }

	protected override void Awake()
	{
		Instance = this;
		Transform transform = base.transform.Find("BoardingShipOutline");
		if (transform != null)
		{
			boardingShipOutline = transform.gameObject;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				Vector3 localPosition = boardingShipOutline.transform.localPosition;
				localPosition.x = -0.25f;
				localPosition.y = -0.7f;
				localPosition.z = 2.7f;
				boardingShipOutline.transform.localPosition = localPosition;
			}
		}
		transform = base.transform.Find("ShipEdgeOutline");
		if (transform != null)
		{
			otherShipOutline = transform.gameObject;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				otherShipOutline.GetComponent<Renderer>().enabled = false;
			}
		}
		transform = base.transform.Find("dronebaydoor");
		if (transform != null)
		{
			closedDoorObject = transform.gameObject;
		}
		if (OwnedDbfNonBarkAudio == null || OwnedDbfBarkAudio == null || OwnedDbfWhineAudio == null)
		{
			Debug.LogWarning("missing owned dbf audio!");
		}
		base.Awake();
	}

	protected override void Start()
	{
		ShipAlpha = 1f;
		Transform transform = base.transform.Find("FakeFadeLayer");
		if (transform != null)
		{
			fakeFadeObject = transform.gameObject;
			Color color = fakeFadeObject.GetComponent<Renderer>().material.color;
			color.a = 0f;
			fakeFadeObject.GetComponent<Renderer>().material.color = color;
		}
		transform = base.transform.Find("HideBoardingShip");
		if (transform != null)
		{
			hideBoardingShipObject = transform.gameObject;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				hideBoardingShipObject.gameObject.SetActive(true);
			}
			else
			{
				hideBoardingShipObject.gameObject.SetActive(false);
			}
		}
		if (wallObjects != null)
		{
			int count = wallObjects.Count;
			for (int i = 0; i < count; i++)
			{
				if (wallObjects[i] != null)
				{
					if (base.wallModels == null)
					{
						base.wallModels = new List<GameObject>();
					}
					if (base.wallModelsRenderers == null)
					{
						base.wallModelsRenderers = new Dictionary<GameObject, Renderer>();
					}
					GameObject gameObject = wallObjects[i];
					base.wallModels.Add(gameObject);
					base.wallModelsRenderers[gameObject] = gameObject.GetComponentInChildren<Renderer>();
					base.wallModelsRenderers[gameObject].enabled = false;
				}
			}
		}
		base.Start();
	}

	protected override void OnDestroy()
	{
		fakeFadeObject = null;
		hideBoardingShipObject = null;
		boardingShipOutline = null;
		otherShipOutline = null;
		closedDoorObject = null;
		Instance = null;
		base.OnDestroy();
	}

	protected override void Update()
	{
		if (!GlobalSettings.IsGamePaused)
		{
			if (IsRedockingShip)
			{
				if (isFadingOutShip || isFadingInShip)
				{
					timerFade -= Time.deltaTime;
					if (timerFade <= 0f)
					{
						timerFade = 0f;
						if (isFadingOutShip)
						{
							isFadingOutShip = false;
							ShipAlpha = 0f;
							visitedOutline.SetAlpha(ShipAlpha);
							if (fakeFadeObject != null)
							{
								Color color = fakeFadeObject.GetComponent<Renderer>().material.color;
								color.a = 1f;
								fakeFadeObject.GetComponent<Renderer>().material.color = color;
							}
							if (boardingShipOutline != null)
							{
								Color color2 = boardingShipOutline.GetComponent<Renderer>().material.color;
								color2.a = ShipAlpha;
								boardingShipOutline.GetComponent<Renderer>().material.color = color2;
							}
							if (otherShipOutline != null)
							{
								Color color3 = otherShipOutline.GetComponent<Renderer>().material.color;
								color3.a = ShipAlpha;
								otherShipOutline.GetComponent<Renderer>().material.color = color3;
							}
							isMovingShip = true;
							timerMove = 3f;
						}
						else if (isFadingInShip)
						{
							isFadingInShip = false;
							ShipAlpha = 1f;
							visitedOutline.SetAlpha(ShipAlpha);
							if (fakeFadeObject != null)
							{
								Color color4 = fakeFadeObject.GetComponent<Renderer>().material.color;
								color4.a = 0f;
								fakeFadeObject.GetComponent<Renderer>().material.color = color4;
							}
							RefreshAlphaOnShipObjects();
							EndDock();
							IsRedockingShip = false;
							SystemMessageManager.ShowSystemMessage("Boarding ship has docked", ConsoleMessageType.Info);
							EventManager.Instance.Publish(GeneralEventType.ReDocked, new GeneralEventArgs(this));
						}
					}
					else
					{
						ShipAlpha = timerFade / 1f;
						if (isFadingInShip)
						{
							ShipAlpha = 1f - ShipAlpha;
						}
						visitedOutline.SetAlpha(ShipAlpha);
						if (fakeFadeObject != null)
						{
							if (GlobalSettings.cameraMode == CameraMode.Drone)
							{
								fakeFadeObject.GetComponent<Renderer>().enabled = true;
								Color color5 = fakeFadeObject.GetComponent<Renderer>().material.color;
								color5.a = 1f - ShipAlpha;
								fakeFadeObject.GetComponent<Renderer>().material.color = color5;
							}
							else
							{
								fakeFadeObject.GetComponent<Renderer>().enabled = false;
							}
						}
						RefreshAlphaOnShipObjects();
					}
					if (GlobalSettings.cameraMode != CameraMode.Schematic)
					{
						SetDroneViewMaterial();
					}
				}
				else if (isMovingShip)
				{
					timerMove -= Time.deltaTime;
					if (timerMove <= 0f)
					{
						isMovingShip = false;
						timerMove = 0f;
						BeginFadeIn();
					}
				}
			}
			if (isExecutingPandemicQuarentineObjective)
			{
				timerObjective -= Time.deltaTime;
				if (timerObjective <= 0f)
				{
					isExecutingPandemicQuarentineObjective = false;
					timerObjective = 0f;
					SystemMessageManager.ShowSystemMessage(string.Format("///[JIL]: scan successful, saving results", nextObjectiveNotice), ConsoleMessageType.JIL_Good);
					if (!isSecondaryScan)
					{
						if (ObjectiveManual.IsObjectiveStepActive("pandemic", "stepB"))
						{
							LogManager.LogDataFile.SaveValue("pandemic", "stepB", 3);
							LogManager.LogDataFile.SaveValue("pandemic", "stepC", 1);
						}
						LogManager.LogDataFile.SaveValue("pandemic", "stepBAge", GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Age);
						SystemMessageManager.ShowSystemMessage(string.Format("///[JIL]: Holmes Algorithm: uninstalled", nextObjectiveNotice), ConsoleMessageType.JIL_Good);
					}
				}
				else if (timerObjective <= (float)nextObjectiveNotice)
				{
					SystemMessageManager.ShowSystemMessage(string.Format("///[JIL]: Holmes Algorithm: {0} seconds remaining...", nextObjectiveNotice), ConsoleMessageType.JIL_Info);
					nextObjectiveNotice--;
				}
			}
		}
		base.Update();
	}

	private void RefreshAlphaOnShipObjects()
	{
		if (boardingShipOutline != null)
		{
			Color color = boardingShipOutline.GetComponent<Renderer>().material.color;
			color.a = ShipAlpha;
			boardingShipOutline.GetComponent<Renderer>().material.color = color;
		}
		if (otherShipOutline != null)
		{
			Color color2 = otherShipOutline.GetComponent<Renderer>().material.color;
			color2.a = ShipAlpha;
			otherShipOutline.GetComponent<Renderer>().material.color = color2;
		}
		if (isRoomStatusPlaneActive)
		{
			Color color3 = SVRoomStatusLayer.GetComponent<Renderer>().material.color;
			color3.a = ShipAlpha;
			SVRoomStatusLayer.GetComponent<Renderer>().material.color = color3;
		}
		if (isEnvPressureStatusPlaneActive)
		{
			Color color4 = SVEnvPressureStatusLayer.GetComponent<Renderer>().material.color;
			color4.a = ShipAlpha;
			SVEnvPressureStatusLayer.GetComponent<Renderer>().material.color = color4;
		}
		if (isEnvRadiationStatusPlaneActive)
		{
			Color color5 = SVEnvRadiationStatusLayer.GetComponent<Renderer>().material.color;
			color5.a = ShipAlpha;
			SVEnvRadiationStatusLayer.GetComponent<Renderer>().material.color = color5;
		}
		if (base.labelTextObject != null)
		{
			Color color6 = base.labelTextObject.color;
			color6.a = ShipAlpha;
			base.labelTextObject.color = color6;
		}
	}

	public override void SetSchematicViewMaterial()
	{
		base.SetSchematicViewMaterial();
		Color color = roomMaterial.color;
		color.a = ShipAlpha;
		roomMaterial.color = color;
		if (base.labelTextObject != null)
		{
			color = base.labelTextObject.color;
			color.a = ShipAlpha;
			base.labelTextObject.color = color;
		}
	}

	protected override void SetDroneViewMaterial()
	{
		base.SetDroneViewMaterial();
		Color color = roomMaterial.color;
		color.a = ShipAlpha;
		roomMaterial.color = color;
	}

	public void Dock(Corridor airlockCorridor)
	{
		EventManager.Instance.Publish(GeneralEventType.Undocking, new GeneralEventArgs(this));
		destinationAirlock = airlockCorridor;
		if (CurrentAirlock != null)
		{
			float num = 0f;
			float num2 = 0f;
			if (DungeonManager.Instance != null && DungeonManager.Instance.DungeonSize != null)
			{
				num = DungeonManager.Instance.DungeonSize.x / 2;
				num2 = DungeonManager.Instance.DungeonSize.y / 2;
			}
			else
			{
				num = -7f;
				num2 = 2.5f;
			}
			isDockingChanging90Deg = false;
			if (destinationAirlock.transform.rotation.w == 1f)
			{
				if (CurrentAirlock.transform.rotation.w == 1f)
				{
					isDockingOnOppositeY = false;
					isDockingOnOppositeX = false;
					if (destinationAirlock.transform.position.x > num)
					{
						if (CurrentAirlock.transform.position.x > num)
						{
							isDockingOnOppositeX = false;
							dockingChange = DockingChangeEnum.SameSide;
						}
						else
						{
							isDockingOnOppositeX = true;
							dockingChange = DockingChangeEnum.LeftToRight;
						}
					}
					else if (CurrentAirlock.transform.position.x > num)
					{
						isDockingOnOppositeX = true;
						dockingChange = DockingChangeEnum.RightToLeft;
					}
					else
					{
						isDockingOnOppositeX = false;
						dockingChange = DockingChangeEnum.SameSide;
					}
				}
				else
				{
					isDockingChanging90Deg = true;
					if (destinationAirlock.transform.position.y < CurrentAirlock.transform.position.y)
					{
						if (destinationAirlock.transform.position.x > num)
						{
							isDockingOnOppositeX = false;
							isDockingOnOppositeY = true;
							dockingChange = DockingChangeEnum.TopToRight;
						}
						else
						{
							isDockingOnOppositeX = true;
							isDockingOnOppositeY = false;
							dockingChange = DockingChangeEnum.TopToLeft;
						}
					}
					else if (destinationAirlock.transform.position.x > num)
					{
						isDockingOnOppositeX = true;
						isDockingOnOppositeY = false;
						dockingChange = DockingChangeEnum.BottomToRight;
					}
					else
					{
						isDockingOnOppositeX = false;
						isDockingOnOppositeY = true;
						dockingChange = DockingChangeEnum.BottomToLeft;
					}
				}
			}
			else if (destinationAirlock.transform.rotation.w >= 0.65f && destinationAirlock.transform.rotation.w <= 0.75f)
			{
				if (CurrentAirlock.transform.rotation.w >= 0.65f && CurrentAirlock.transform.rotation.w <= 0.75f)
				{
					isDockingOnOppositeY = false;
					isDockingOnOppositeX = false;
					if (destinationAirlock.transform.position.y > num2)
					{
						if (CurrentAirlock.transform.position.y > num2)
						{
							isDockingOnOppositeY = false;
							dockingChange = DockingChangeEnum.SameSide;
						}
						else
						{
							isDockingOnOppositeY = true;
							dockingChange = DockingChangeEnum.BottomToTop;
						}
					}
					else if (CurrentAirlock.transform.position.y > num2)
					{
						isDockingOnOppositeY = true;
						dockingChange = DockingChangeEnum.TopToBottom;
					}
					else
					{
						isDockingOnOppositeY = false;
						dockingChange = DockingChangeEnum.SameSide;
					}
				}
				else
				{
					isDockingChanging90Deg = true;
					if (destinationAirlock.transform.position.x > CurrentAirlock.transform.position.x)
					{
						if (destinationAirlock.transform.position.y > num2)
						{
							isDockingOnOppositeX = false;
							isDockingOnOppositeY = true;
							dockingChange = DockingChangeEnum.RightToBottom;
						}
						else
						{
							isDockingOnOppositeX = true;
							isDockingOnOppositeY = false;
							dockingChange = DockingChangeEnum.LeftToBottom;
						}
					}
					else if (destinationAirlock.transform.position.y > num2)
					{
						isDockingOnOppositeX = true;
						isDockingOnOppositeY = false;
						dockingChange = DockingChangeEnum.RightToTop;
					}
					else
					{
						isDockingOnOppositeX = false;
						isDockingOnOppositeY = true;
						dockingChange = DockingChangeEnum.LeftToTop;
					}
				}
			}
			DetachShipFromAirlock();
		}
		if (!hasFirstDockOccured)
		{
			ConnectShipToAirlock();
			hasFirstDockOccured = true;
			return;
		}
		BeginFadeOut();
		if (!GameSaveFile.Get("HNT_ALOCK_DOCK", false))
		{
			HintManager.HintCompleted(typeof(DockHint));
		}
	}

	public bool PrepareToLeave()
	{
		EnemyManager instance = EnemyManager.Instance;
		if (CurrentAirlock != null && CurrentAirlock.door.state == DoorState.Open)
		{
			if (!CurrentAirlock.door.close())
			{
				IEnumerable<BaseEnemy> source = instance.Enemies.Where((BaseEnemy x) => x != null && GetComponent<Collider>().bounds.Intersects(x.GetComponent<Collider>().bounds) && !x.IsDead);
				if (source.Count() > 0)
				{
					return false;
				}
			}
			else
			{
				closedDoorOnLeaving = true;
			}
		}
		if (instance.Enemies.Any((BaseEnemy x) => x != null && !(x is DronesBestFriend) && (x.CurrentRoom == this || GetComponent<Collider>().bounds.Intersects(x.GetComponent<Collider>().bounds)) && !x.IsDead))
		{
			return false;
		}
		return true;
	}

	public void CancelExit()
	{
		if (closedDoorOnLeaving)
		{
			closedDoorOnLeaving = false;
			CurrentAirlock.door.open();
		}
	}

	private void DetachShipFromAirlock()
	{
		Room firstRoom = null;
		Waypoint waypoint = null;
		Waypoint waypoint2 = null;
		Waypoint waypoint3 = null;
		Waypoint waypoint4 = null;
		Corridor corridor = null;
		Room room = null;
		if (CurrentAirlock.rooms[0] == this)
		{
			firstRoom = CurrentAirlock.rooms[1];
		}
		else
		{
			firstRoom = CurrentAirlock.rooms[0];
		}
		waypoint = CurrentAirlock.Waypoints.First((Waypoint x) => x.Room == this);
		waypoint2 = CurrentAirlock.Waypoints.First((Waypoint x) => x.Room == firstRoom);
		waypoint3 = Waypoints.First((Waypoint x) => x.IsMainRoomWaypoint);
		waypoint4 = firstRoom.Waypoints.First((Waypoint x) => x.IsMainRoomWaypoint);
		waypoint.ConnectedWaypoints.Remove(waypoint3);
		waypoint3.ConnectedWaypoints.Clear();
		waypoint.Room = null;
		waypoint4.ConnectedWaypoints.Remove(waypoint2);
		waypoint4.ConnectedWaypoints.Remove(waypoint);
		waypoint3.ConnectedRooms.Remove(waypoint4);
		waypoint4.ConnectedRooms.Remove(waypoint3);
		RemoveCorridor(CurrentAirlock);
		if (CurrentAirlock.door.state == DoorState.Open)
		{
			CurrentAirlock.door.close();
		}
		corridor = CurrentAirlock;
		room = corridor.getOtherRoom(this);
		CurrentAirlock.rooms[1] = null;
		CurrentAirlock.power();
		CurrentAirlock.LeadsIntoShip = false;
		CurrentAirlock = null;
		if (corridor.door.state == DoorState.Open)
		{
			room.AirlockOpened(corridor.door);
			SystemMessageManager.ShowSystemMessage("Airlock didn't close when detaching boarding vessel", ConsoleMessageType.Warning);
		}
	}

	private void ConnectShipToAirlock()
	{
		Room firstRoom = null;
		Waypoint waypoint = null;
		Waypoint doorWaypointInDerelict = null;
		Waypoint waypoint2 = null;
		Waypoint waypoint3 = null;
		firstRoom = destinationAirlock.rooms[0];
		destinationAirlock.rooms[1] = this;
		AddCorridor(destinationAirlock);
		doorWaypointInDerelict = destinationAirlock.Waypoints.FirstOrDefault((Waypoint x) => x.Room == firstRoom);
		if (doorWaypointInDerelict == null)
		{
			foreach (Waypoint waypoint4 in destinationAirlock.Waypoints)
			{
				if (waypoint4.GetComponent<Collider>().bounds.Intersects(firstRoom.GetComponent<Collider>().bounds))
				{
					doorWaypointInDerelict = waypoint4;
					break;
				}
			}
		}
		if (doorWaypointInDerelict == null)
		{
			Debug.LogError("Could not dock to airlock!");
			return;
		}
		waypoint = destinationAirlock.Waypoints.First((Waypoint x) => x != doorWaypointInDerelict);
		waypoint2 = Waypoints.First((Waypoint x) => x.IsMainRoomWaypoint);
		waypoint3 = firstRoom.Waypoints.First((Waypoint x) => x.IsMainRoomWaypoint);
		waypoint.ConnectedWaypoints.Clear();
		doorWaypointInDerelict.ConnectedWaypoints.Clear();
		if (waypoint2.ConnectedWaypoints != null)
		{
			waypoint2.ConnectedWaypoints.Clear();
		}
		else
		{
			waypoint2.ConnectedWaypoints = new List<Waypoint>();
		}
		waypoint2.Room = this;
		waypoint3.ConnectedWaypoints.Remove(doorWaypointInDerelict);
		waypoint3.ConnectedWaypoints.Remove(waypoint);
		waypoint.ConnectedWaypoints.Add(doorWaypointInDerelict);
		doorWaypointInDerelict.ConnectedWaypoints.Add(waypoint);
		waypoint2.ConnectedRooms.Add(waypoint3);
		waypoint3.ConnectedRooms.Add(waypoint2);
		doorWaypointInDerelict.ConnectedWaypoints.Add(waypoint3);
		waypoint2.ConnectedWaypoints.Add(waypoint);
		doorWaypointInDerelict.Room = firstRoom;
		waypoint.ConnectedWaypoints.Add(waypoint2);
		waypoint3.ConnectedWaypoints.Add(doorWaypointInDerelict);
		waypoint.Room = this;
		destinationAirlock.rooms[1] = this;
		Vector3 position = destinationAirlock.transform.position;
		float num = 1f;
		float num2 = 0f;
		float num3 = 0f;
		if (DungeonManager.Instance != null && DungeonManager.Instance.DungeonSize != null)
		{
			num2 = DungeonManager.Instance.DungeonSize.x / 2;
			num3 = DungeonManager.Instance.DungeonSize.y / 2;
		}
		else
		{
			num2 = -7f;
			num3 = 2.5f;
		}
		int num4 = 0;
		if (destinationAirlock.transform.rotation.w == 1f)
		{
			if (destinationAirlock.transform.position.x > num2)
			{
				num = -1f;
				num4 = 3;
			}
			else
			{
				num4 = 2;
			}
			position.x -= (base.transform.localScale.x / 2f + destinationAirlock.transform.localScale.x / 2f) * num;
		}
		else if (destinationAirlock.transform.rotation.w >= 0.65f && destinationAirlock.transform.rotation.w <= 0.75f)
		{
			if (destinationAirlock.transform.position.y > num3)
			{
				num = -1f;
				num4 = 0;
			}
			else
			{
				num4 = 1;
			}
			position.y -= (base.transform.localScale.y / 2f + destinationAirlock.transform.localScale.y / 2f + destinationAirlock.transform.localScale.y) * num;
		}
		else
		{
			Debug.Log("*** ROT: " + destinationAirlock.transform.rotation);
		}
		base.transform.position = position;
		base.transform.rotation = destinationAirlock.transform.rotation;
		if (labelObject != null)
		{
			labelObject.transform.rotation = Quaternion.identity;
			labelObject.transform.parent = base.transform;
			labelObject.transform.localPosition = new Vector3(0f, 0.03f, -1f);
			labelObject.transform.localScale = new Vector3(1f, 1f, 1f);
			Vector3 localScale = base.transform.localScale;
			Vector3 localScale2 = labelObject.transform.localScale;
			bool flag = base.transform.rotation.w >= 0.65f && base.transform.rotation.w <= 0.75f;
			if (localScale.x > localScale.y && !flag)
			{
				localScale2.x *= localScale.y / localScale.x;
			}
			else if (localScale.y > localScale.x && !flag)
			{
				localScale2.y *= localScale.x / localScale.y;
			}
			labelObject.transform.localScale = localScale2;
		}
		Vector3 localPosition = closedDoorObject.transform.localPosition;
		localPosition.z = -0.046f;
		switch (num4)
		{
		case 0:
			localPosition.x = 0.53f;
			localPosition.y = 0f;
			break;
		case 1:
			localPosition.x = -0.511f;
			localPosition.y = 0f;
			break;
		case 2:
			localPosition.x = -0.511f;
			localPosition.y = 0f;
			break;
		case 3:
			localPosition.x = 0.53f;
			localPosition.y = 0f;
			break;
		}
		closedDoorObject.transform.localPosition = localPosition;
		if (boardingShipOutline != null)
		{
			Vector3 localPosition2 = boardingShipOutline.transform.localPosition;
			switch (num4)
			{
			case 0:
				localPosition2.x = 0.25f;
				localPosition2.y = -0.7f;
				localPosition2.z = 2.7f;
				break;
			case 1:
				localPosition2.x = -0.25f;
				localPosition2.y = -0.7f;
				localPosition2.z = 2.7f;
				break;
			case 2:
				localPosition2.x = -0.25f;
				localPosition2.y = -0.7f;
				localPosition2.z = 2.7f;
				break;
			case 3:
				localPosition2.x = 0.25f;
				localPosition2.y = -0.7f;
				localPosition2.z = 2.7f;
				break;
			}
			boardingShipOutline.transform.localPosition = localPosition2;
		}
		if (otherShipOutline != null)
		{
			Vector3 localPosition3 = otherShipOutline.transform.localPosition;
			Debug.Log("Pos New: " + localPosition3);
			switch (num4)
			{
			case 0:
				localPosition3.x = -0.7f;
				localPosition3.y = 0f;
				localPosition3.z = 2.7f;
				break;
			case 1:
				localPosition3.x = 0.631f;
				localPosition3.y = 0f;
				localPosition3.z = 2.7f;
				break;
			case 2:
				localPosition3.x = 0.631f;
				localPosition3.y = 0f;
				localPosition3.z = 2.7f;
				break;
			case 3:
				localPosition3.x = -0.7f;
				localPosition3.y = 0f;
				localPosition3.z = 2.7f;
				break;
			}
			otherShipOutline.transform.localPosition = localPosition3;
		}
		CurrentAirlock = destinationAirlock;
		destinationAirlock = null;
	}

	private void BeginFadeOut()
	{
		DroneManager instance = DroneManager.Instance;
		IEnumerable<Drone> enumerable = instance.dronesList.Where((Drone x) => x != null && x.CurrentRoom == this);
		if (enumerable != null)
		{
			travelingDroneList = new List<TravelingDataDrone>();
			foreach (Drone item in enumerable)
			{
				if (item != null)
				{
					Vector3 offset = item.transform.position - Waypoints[0].transform.position;
					travelingDroneList.Add(new TravelingDataDrone(offset, item));
				}
			}
		}
		enumerable = instance.LootableDronesList.Where((Drone x) => x != null && x.CurrentRoom == this);
		List<Drone> list = null;
		if (enumerable != null)
		{
			list = enumerable.ToList();
		}
		if (travelingDroneList == null && list != null)
		{
			travelingDroneList = new List<TravelingDataDrone>();
		}
		if (list != null)
		{
			foreach (Drone item2 in list)
			{
				if (item2 != null)
				{
					Vector3 offset2 = item2.transform.position - Waypoints[0].transform.position;
					travelingDroneList.Add(new TravelingDataDrone(offset2, item2));
				}
			}
		}
		if (travelingDroneList != null && travelingDroneList.Count > 0)
		{
			foreach (TravelingDataDrone travelingDrone in travelingDroneList)
			{
				if (travelingDrone != null && travelingDrone.drone != null)
				{
					travelingDrone.drone.BeginMoveWithBoardingVessel();
				}
			}
		}
		UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(DropableItem));
		if (array.Length > 0)
		{
			UnityEngine.Object[] array2 = array;
			foreach (UnityEngine.Object obj in array2)
			{
				if (!(obj != null))
				{
					continue;
				}
				DropableItem dropableItem = (DropableItem)obj;
				if (dropableItem.GetComponent<Collider>() != null && GetComponent<Collider>().bounds.Intersects(dropableItem.GetComponent<Collider>().bounds))
				{
					Vector3 offset3 = dropableItem.transform.position - Waypoints[0].transform.position;
					if (travelingDroppableItemsList == null)
					{
						travelingDroppableItemsList = new List<TravelingDroppableItem>();
					}
					dropableItem.IsConnectedToBoardingShip = true;
					travelingDroppableItemsList.Add(new TravelingDroppableItem(offset3, dropableItem));
				}
			}
		}
		array = UnityEngine.Object.FindObjectsOfType(typeof(ShipUpgradeInGameObject));
		if (array.Length > 0)
		{
			UnityEngine.Object[] array3 = array;
			foreach (UnityEngine.Object obj2 in array3)
			{
				if (!(obj2 != null))
				{
					continue;
				}
				ShipUpgradeInGameObject upgrade = (ShipUpgradeInGameObject)obj2;
				if (!GetComponent<Collider>().bounds.Intersects(upgrade.GetComponent<Collider>().bounds))
				{
					continue;
				}
				bool flag = false;
				if (upgrade.IsBeingTowed)
				{
					if (travelingDroneList != null)
					{
						TravelingDataDrone travelingDataDrone = travelingDroneList.First((TravelingDataDrone x) => x != null && !x.drone.IsDead && x.drone.ItemBeingTowed == upgrade);
						if (travelingDataDrone != null)
						{
							flag = true;
						}
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					Vector3 offset4 = upgrade.transform.position - Waypoints[0].transform.position;
					if (travelingShipUpgradeList == null)
					{
						travelingShipUpgradeList = new List<TravelingShipUpgradeItem>();
					}
					upgrade.IsConnectedToBoardingShip = true;
					travelingShipUpgradeList.Add(new TravelingShipUpgradeItem(offset4, upgrade));
					upgrade.gameObject.transform.rotation = Quaternion.identity;
				}
			}
		}
		EnemyManager instance2 = EnemyManager.Instance;
		List<SwarmManager> list2 = new List<SwarmManager>();
		foreach (BaseEnemy enemy in instance2.Enemies)
		{
			if (!(enemy != null) || enemy is SlimeEnemy)
			{
				continue;
			}
			bool flag2 = false;
			Vector3 offset5 = Vector3.zero;
			if (enemy is BruteEnemy)
			{
				if (GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds))
				{
					enemy.TravelingInShip = true;
					flag2 = true;
				}
			}
			else if (enemy is PatrolBotEnemy)
			{
				if (GetComponent<Collider>().bounds.Intersects(enemy.GetComponent<Collider>().bounds))
				{
					enemy.TravelingInShip = true;
					flag2 = true;
				}
			}
			else if (enemy is SwarmEnemy)
			{
				SwarmManager swarmManager = ((SwarmEnemy)enemy).swarmManager;
				if (!list2.Contains(swarmManager) && enemy.GetComponent<Collider>() != null)
				{
					Bounds bounds = enemy.GetComponent<Collider>().bounds;
					bounds.Expand(new Vector3(1f, 1f, 1f));
					if (GetComponent<Collider>().bounds.Intersects(bounds))
					{
						list2.Add(swarmManager);
						swarmManager.SetTravelingInShip(true);
						SwarmEnemy alphaEnemy = swarmManager.GetAlphaEnemy();
						if (alphaEnemy != null)
						{
							offset5 = alphaEnemy.MainVisibleObject.transform.position - Waypoints[0].transform.position;
						}
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				if (travelingEnemyList == null)
				{
					travelingEnemyList = new List<TravelingDataEnemy>();
				}
				travelingEnemyList.Add(new TravelingDataEnemy(offset5, enemy));
			}
		}
		if (base.AreaSensorVisual.IsEnabled)
		{
			base.AreaSensorVisual.Disable();
		}
		IsRedockingShip = true;
		isFadingOutShip = true;
		timerFade = 1f;
	}

	private void BeginFadeIn()
	{
		ConnectShipToAirlock();
		if (travelingDroneList != null)
		{
			foreach (TravelingDataDrone travelingDrone in travelingDroneList)
			{
				Vector3 offset = travelingDrone.offset;
				Vector3 position = Waypoints[0].transform.position;
				if (isDockingChanging90Deg)
				{
					float x = offset.x;
					offset.x = offset.y;
					offset.y = x;
				}
				switch (dockingChange)
				{
				case DockingChangeEnum.TopToRight:
					travelingDrone.drone.RotateDeg(-90f);
					break;
				case DockingChangeEnum.TopToLeft:
					travelingDrone.drone.RotateDeg(90f);
					break;
				case DockingChangeEnum.BottomToRight:
					travelingDrone.drone.RotateDeg(90f);
					break;
				case DockingChangeEnum.BottomToLeft:
					travelingDrone.drone.RotateDeg(-90f);
					break;
				case DockingChangeEnum.LeftToRight:
				case DockingChangeEnum.RightToLeft:
					isDockingOnOppositeY = true;
					travelingDrone.drone.RotateDeg(180f);
					break;
				case DockingChangeEnum.TopToBottom:
				case DockingChangeEnum.BottomToTop:
					isDockingOnOppositeX = true;
					travelingDrone.drone.RotateDeg(180f);
					break;
				case DockingChangeEnum.RightToTop:
					travelingDrone.drone.RotateDeg(90f);
					break;
				case DockingChangeEnum.RightToBottom:
					travelingDrone.drone.RotateDeg(-90f);
					break;
				case DockingChangeEnum.LeftToTop:
					travelingDrone.drone.RotateDeg(-90f);
					break;
				case DockingChangeEnum.LeftToBottom:
					travelingDrone.drone.RotateDeg(90f);
					break;
				}
				if (isDockingOnOppositeX)
				{
					offset.x = 0f - offset.x;
				}
				if (isDockingOnOppositeY)
				{
					offset.y = 0f - offset.y;
				}
				position += offset;
				travelingDrone.drone.MoveToPosition(position);
			}
		}
		if (travelingEnemyList != null)
		{
			foreach (TravelingDataEnemy travelingEnemy in travelingEnemyList)
			{
				Vector3 offset2 = travelingEnemy.offset;
				Vector3 position2 = Waypoints[0].transform.position;
				if (isDockingChanging90Deg)
				{
					float x2 = offset2.x;
					offset2.x = offset2.y;
					offset2.y = x2;
				}
				if (isDockingOnOppositeX)
				{
					offset2.x = 0f - offset2.x;
				}
				if (isDockingOnOppositeY)
				{
					offset2.y = 0f - offset2.y;
				}
				position2 += offset2;
				if (travelingEnemy.enemy is SwarmEnemy)
				{
					((SwarmEnemy)travelingEnemy.enemy).swarmManager.SetSwarmPosition(position2);
				}
				else
				{
					travelingEnemy.enemy.SetPosition(position2);
				}
			}
		}
		if (travelingDroppableItemsList != null)
		{
			foreach (TravelingDroppableItem travelingDroppableItems in travelingDroppableItemsList)
			{
				Vector3 offset3 = travelingDroppableItems.offset;
				Vector3 position3 = Waypoints[0].transform.position;
				if (isDockingChanging90Deg)
				{
					float x3 = offset3.x;
					offset3.x = offset3.y;
					offset3.y = x3;
				}
				if (isDockingOnOppositeX)
				{
					offset3.x = 0f - offset3.x;
				}
				if (isDockingOnOppositeY)
				{
					offset3.y = 0f - offset3.y;
				}
				position3 += offset3;
				travelingDroppableItems.item.gameObject.transform.position = position3;
			}
		}
		if (travelingShipUpgradeList != null)
		{
			foreach (TravelingShipUpgradeItem travelingShipUpgrade in travelingShipUpgradeList)
			{
				Vector3 offset4 = travelingShipUpgrade.offset;
				Vector3 position4 = Waypoints[0].transform.position;
				if (isDockingChanging90Deg)
				{
					float x4 = offset4.x;
					offset4.x = offset4.y;
					offset4.y = x4;
				}
				if (isDockingOnOppositeX)
				{
					offset4.x = 0f - offset4.x;
				}
				if (isDockingOnOppositeY)
				{
					offset4.y = 0f - offset4.y;
				}
				position4 += offset4;
				travelingShipUpgrade.item.gameObject.transform.position = position4;
				travelingShipUpgrade.item.ReconnectSvVisuals();
			}
		}
		try
		{
			NavigationHelper.Refresh();
		}
		catch (Exception ex)
		{
			if (ConfigFile.GetSetting("AllowCheating").ToLower() == "yes")
			{
				SystemMessageManager.ShowSystemMessage("DEV NOTE: NavigationHelper.Refresh() failed with an exception.\r\nHave ignored the error so that the\r\ndocking ship doesn't break.\r\nNeed to fix the error (see log)!", ConsoleMessageType.Error);
			}
			Debug.LogError(string.Format("NavigationHelper.Refresh() Error Ignored so that Docking doesn't break: {0}", ex.ToString()));
		}
		isFadingInShip = true;
		timerFade = 1f;
		dockingChange = DockingChangeEnum.NoChange;
		visitedOutline.RefreshLines();
	}

	private void EndDock()
	{
		if (travelingDroneList != null)
		{
			foreach (TravelingDataDrone travelingDrone in travelingDroneList)
			{
				travelingDrone.drone.EndMoveWithBoardingVessel();
			}
			travelingDroneList = null;
		}
		if (travelingEnemyList != null)
		{
			foreach (TravelingDataEnemy travelingEnemy in travelingEnemyList)
			{
				if (travelingEnemy.enemy is SwarmEnemy)
				{
					((SwarmEnemy)travelingEnemy.enemy).swarmManager.SetTravelingInShip(false);
				}
				else
				{
					travelingEnemy.enemy.TravelingInShip = false;
				}
			}
			travelingEnemyList = null;
		}
		if (travelingDroppableItemsList != null)
		{
			foreach (TravelingDroppableItem travelingDroppableItems in travelingDroppableItemsList)
			{
				travelingDroppableItems.item.IsConnectedToBoardingShip = false;
			}
			travelingDroppableItemsList = null;
		}
		if (travelingShipUpgradeList != null)
		{
			foreach (TravelingShipUpgradeItem travelingShipUpgrade in travelingShipUpgradeList)
			{
				travelingShipUpgrade.item.IsConnectedToBoardingShip = false;
			}
			travelingShipUpgradeList = null;
		}
		if (CurrentAirlock != null)
		{
			CurrentAirlock.Scanned();
			CurrentAirlock.power();
			CurrentAirlock.LeadsIntoShip = true;
		}
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

	public override void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			roomRenderer.enabled = true;
			if (boardingShipOutline != null)
			{
				boardingShipOutline.GetComponent<Renderer>().enabled = false;
			}
			Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
			int num = componentsInChildren.Length;
			for (int i = 0; i < num; i++)
			{
				Transform transform = componentsInChildren[i];
				if (transform.name[0] == 'd' && transform.name.StartsWith("default") && transform.GetComponent<Renderer>() != null)
				{
					transform.GetComponent<Renderer>().enabled = true;
				}
			}
			ShowRegisteredEnimies();
		}
		else
		{
			roomRenderer.enabled = false;
			if (boardingShipOutline != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Outpost)
			{
				boardingShipOutline.GetComponent<Renderer>().enabled = true;
			}
			Transform[] componentsInChildren2 = GetComponentsInChildren<Transform>();
			int num2 = componentsInChildren2.Length;
			for (int j = 0; j < num2; j++)
			{
				Transform transform2 = componentsInChildren2[j];
				if (transform2.name[0] == 'd' && transform2.name.StartsWith("default") && transform2.GetComponent<Renderer>() != null)
				{
					transform2.GetComponent<Renderer>().enabled = false;
				}
			}
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Outpost)
		{
			if (otherShipOutline != null)
			{
				if (GlobalSettings.cameraMode == CameraMode.Drone)
				{
					otherShipOutline.GetComponent<Renderer>().enabled = false;
				}
				else
				{
					otherShipOutline.GetComponent<Renderer>().enabled = true;
				}
			}
		}
		else
		{
			otherShipOutline.GetComponent<Renderer>().enabled = false;
		}
		base.UpdateCameraView();
	}

	public void BeginPandemicQuarantineObjective(bool isSecondaryScan)
	{
		this.isSecondaryScan = isSecondaryScan;
		isExecutingPandemicQuarentineObjective = true;
		timerObjective = 10f;
		nextObjectiveNotice = 9;
		SystemMessageManager.ShowSystemMessage("///[JIL]: Initiating Holmes Algorithm: 10 seconds remaining...", ConsoleMessageType.JIL_Info);
	}

	public void EndPandemicQuarantineObjective()
	{
		isExecutingPandemicQuarentineObjective = false;
		SystemMessageManager.ShowSystemMessage("///[JIL]: Holmes Algorithm: CANCELED!", ConsoleMessageType.JIL_Warning);
	}

	public void PlayOwnedDbfNonBarkSound()
	{
		AudioSource audioSource = CommonMethods.PickRandomItem(OwnedDbfNonBarkAudio);
		if (audioSource != null)
		{
			audioSource.volume = GameAudio.AlertVolume;
			audioSource.Play();
		}
		else
		{
			Debug.LogWarning("no owned dbf audio found!");
		}
	}

	public void PlayOwnedDbfBarkSound()
	{
		AudioSource audioSource = CommonMethods.PickRandomItem(OwnedDbfBarkAudio);
		if (audioSource != null)
		{
			audioSource.volume = GameAudio.AlertVolume;
			audioSource.Play();
		}
		else
		{
			Debug.LogWarning("no owned dbf bark audio found!");
		}
	}

	public void PlayOwnedDbfWhineSound()
	{
		AudioSource audioSource = CommonMethods.PickRandomItem(OwnedDbfWhineAudio);
		if (audioSource != null)
		{
			audioSource.volume = GameAudio.AlertVolume;
			audioSource.Play();
		}
		else
		{
			Debug.LogWarning("no owned dbf bark audio found!");
		}
	}

	public List<CommandDefinition> QueryAvailableCommands()
	{
		if (listCommands == null)
		{
			listCommands = new List<CommandDefinition>();
			DungeonTypeEnum dungeonTypeEnum = DungeonTypeEnum.Derelict;
			if (GlobalSettings.GameState.ThePlayer != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon != null)
			{
				dungeonTypeEnum = GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType;
			}
			listCommands = CommandHelper.GetCommands("BoardingVessel");
		}
		return listCommands;
	}

	public List<CommandDefinition> QueryContextCommands()
	{
		return QueryAvailableCommands();
	}

	public void ExecuteCommand(ExecutedCommand command, bool partOfMultiCommand)
	{
		switch (command.Command.CommandName)
		{
		case "dock":
			command.Handled = true;
			if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType == DungeonTypeEnum.Outpost)
			{
				ConsoleWindow3.SendConsoleResponse("cannot dock to an Outpost - use 'transport' command", ConsoleMessageType.Warning);
			}
			else if (!isMovingShip && !isFadingInShip)
			{
				if (command.Arguments.Count == 0)
				{
					ConsoleWindow3.SendConsoleResponse("No location to dock at provided.  ex: dock d12", ConsoleMessageType.Warning);
					break;
				}
				Door door = DungeonManager.Instance.doors.FirstOrDefault((Door x) => x != null && x.LabelSimple.ToLower() == command.Arguments.First().ToLower());
				if (door == null || door.corridor == null || !door.corridor.IsAirlock || !door.corridor.IsVisible || !door.corridor.onSchematic)
				{
					ConsoleWindow3.SendConsoleResponse(string.Format("An invalid value provided for the airlock: {0}", command.Arguments.First()), ConsoleMessageType.Warning);
					break;
				}
				if (CurrentAirlock != null)
				{
					if (CurrentAirlock.door.Label == door.Label)
					{
						ConsoleWindow3.SendConsoleResponse(string.Format("Already docked at airlock {0}!", command.Arguments.First()), ConsoleMessageType.Warning);
						break;
					}
					if (CurrentAirlock.door.state == DoorState.Open)
					{
						bool flag = false;
						if (!CurrentAirlock.door.IsTryingToClose)
						{
							flag = CurrentAirlock.door.close();
						}
						if (!flag && !command.RequestConfirmed)
						{
							command.RequestConfirmation = true;
							ConsoleWindow3.SendConsoleResponse(string.Format("   Safety precaution: <color=\"#FF0000\">re-enter the 'dock' command</color>\n   to confirm detatching with the airlock unable to close.", command.Arguments.First()), ConsoleMessageType.Info);
							GameAudio.Play2DSFX(GameAudio.SoundEnum.Notification);
							break;
						}
					}
				}
				Dock(door.corridor);
				if (GlobalSettings.cameraMode == CameraMode.Drone && DroneManager.Instance.CurrentDrone != null && DroneManager.Instance.CurrentDrone.CurrentRoom != null && DroneManager.Instance.CurrentDrone.CurrentRoom.boardingVessel)
				{
					DroneManager.Instance.switchCameraView();
				}
				ConsoleWindow3.SendConsoleResponse(string.Format("commencing re-docking procedure..."), ConsoleMessageType.Info);
			}
			else
			{
				ConsoleWindow3.SendConsoleResponse(string.Format("Boarding ship is currently moving toward, or \r\ndocking at, another airlock.  Unable to accept this \r\ncommand at the moment."), ConsoleMessageType.Warning);
			}
			break;
		}
	}

	public List<CommandDefinition> QueryDeveloperSpecialCaseCommands()
	{
		return null;
	}
}
