using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour, IMetaData, IDiscoverable, IObjectState, IUpdateCameraView
{
	private enum RoomLayerEnum
	{
		RoomLayer = 1,
		PressureLayer = 2,
		RadiationLayer = 4
	}

	public const int DAMAGE_RADIATION_DESTROYED = 5;

	public const int DAMAGE_RADIATION_DESTROYING = 2;

	private const float EXPAND_AMOUNT = 2f;

	private static bool isShowingExitHint;

	private static Dictionary<string, Material> usedMaterialDict;

	public List<RoomItem> roomItems;

	public Color RadiationOverlayLikely = Color.red;

	public Color RadiationOverlayPossible = Color.yellow;

	public Color FlaggedRoomColor = Color.red;

	private List<DroneUIObject> droneUIObjectList;

	public GameObject labelObject;

	public GameObject SVRoomStatusLayer;

	public GameObject SVEnvPressureStatusLayer;

	public GameObject SVEnvRadiationStatusLayer;

	public bool fading;

	public DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigRoom roomConfig;

	public List<BaseEnemy> knownEnemiesList;

	private bool fadingIn;

	private float fadeTimeTotal = 0.25f;

	private float fadeTimeCurrent;

	private List<GameObject> roomTileObjects;

	private bool _isExplored;

	public List<DungeonPowerInlet> potentialPowerSourceList;

	public List<DungeonPowerInlet> currentPowerSourceList;

	private bool _isPowered;

	public Material DroneViewMtl;

	public bool boardingVessel;

	public string Label;

	public bool scannerBroken;

	public bool motionBroken;

	public List<Waypoint> Waypoints;

	public Color DecompressedColorOn = Color.yellow;

	public Color DecompressedColorOff = Color.yellow;

	public Color IrradiatedColorOn = Color.red;

	public Color IrradiatedColorOff = Color.red;

	public Color TransporterOutlineColorStrong = Color.cyan;

	public Color TransporterOutlineColorWeak = Color.blue;

	public Color TransporterOutlineColorOffline = Color.red;

	public Material SchematicViewExploredOnMtl;

	public Material SchematicViewExploredOffMtl;

	public Material SchematicViewUnexploredOnMtl;

	public Material SchematicViewUnexploredOffMtl;

	public Material SchematicViewExploredDestroyedMtl;

	public Material SchematicViewUnexploredDestroyedMtl;

	public Material SchematicViewScannedOnMtl;

	public Material SchematicViewScannedOffMtl;

	public Material SchematicViewScannedDestroyedMtl;

	public Material SchematicViewDepressurizedMtl;

	public List<GameObject> StaticCollisionObjects = new List<GameObject>();

	private float preNaturalRadiationTimer;

	private float mothershipCreakTimer;

	private float destructionTimer;

	private float destructionAttackTimer;

	private float destructionTime = 60f;

	private float destructionAttackTime = 1f;

	private float radiationSourceFactor = 1f;

	private ColorBlinkManager _blinkManager = new ColorBlinkManager();

	private ColorBlinkManager _blinkManagerPressureLayer = new ColorBlinkManager();

	private ColorBlinkManager _blinkManagerRadiationLayer = new ColorBlinkManager();

	private float destructionComtaminationTimer;

	private float destructionComtaminationTime = 20f;

	private AreaSensorVisual _areaSensorVisual;

	private bool isInInitialExposure;

	private bool isPendingRadiationVenting;

	private bool isRadiatedDueToExposure;

	private bool isPendingMothershipCreak;

	private bool willNaturalRadiationFail;

	private float timerExposureEvents;

	private float timerDecontaminateEvents;

	protected bool isRoomStatusPlaneActive;

	protected bool isEnvPressureStatusPlaneActive;

	protected bool isEnvRadiationStatusPlaneActive;

	private Corridor _openAirlock;

	private OutlineGroup notVisitedOutline;

	protected OutlineGroup visitedOutline;

	private OutlineGroup transporterOutline;

	private TransporterShipUpgrade.ReceiverStrengthEnum currentTransporterState = TransporterShipUpgrade.ReceiverStrengthEnum.None;

	private List<GameObject> outlineLineListNotVisible;

	private List<GameObject> outlineLineListVisible;

	private Vector3 lastDronePosition = Vector3.zero;

	protected Renderer roomRenderer;

	protected Material roomMaterial;

	private SchematicIcon[] icons;

	public bool IsVisible { get; protected set; }

	public bool IsPunctured { get; protected set; }

	public bool StartWithTilesVisible { get; set; }

	public bool RadiationLikely { get; set; }

	public bool RadiationPossible { get; set; }

	public bool ShowingRadiationOverlay { get; private set; }

	public List<Corridor> corridors { get; private set; }

	public List<GameObject> environmentModelsLarge { get; set; }

	public List<GameObject> environmentModels { get; set; }

	public List<GameObject> wallModels { get; set; }

	public Dictionary<GameObject, Renderer> environmentModelsLargeRenderers { get; set; }

	public Dictionary<GameObject, Renderer> wallModelsRenderers { get; set; }

	public Text labelTextObject { get; set; }

	public Image labelBorder { get; set; }

	public Image overlayObject { get; set; }

	public Image overlayWarning1Object { get; set; }

	public Image overlayWarning2Object { get; set; }

	public AudioSource asRAmbientEquipment { get; set; }

	public bool onSchematic { get; private set; }

	public bool isFlagged { get; private set; }

	public bool hasDroneEverEnteredRoom { get; private set; }

	public bool isExplored
	{
		get
		{
			return _isExplored;
		}
		set
		{
			_isExplored = value;
			if (value && Label == "R?")
			{
				AssignRoomLabel();
			}
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				notVisitedOutline.HideLines();
				visitedOutline.HideLines();
				notVisitedOutline.ShowLines();
				visitedOutline.ShowLines();
			}
		}
	}

	public bool isPowered
	{
		get
		{
			return _isPowered;
		}
		set
		{
			_isPowered = value;
			if (value && Label == "R?")
			{
				AssignRoomLabel();
			}
		}
	}

	public DateTime timeExpires { get; private set; }

	public bool hasBeenDiscovered { get; private set; }

	public bool hasBlinkedOnSchematic { get; private set; }

	public bool IsDepressurized { get; private set; }

	public bool IsPendingDepressure { get; set; }

	public bool IsPendingPressurize { get; set; }

	public bool IsPendingDecontaminate { get; set; }

	public bool IsDecontaminating { get; set; }

	public bool isScanned { get; private set; }

	public bool isScanning { get; private set; }

	public string LabelSimple { get; set; }

	public bool IsInPreNaturalRadiationState { get; private set; }

	public bool IsFillingWithRadiation { get; private set; }

	public bool IsRadiated { get; private set; }

	public bool IsVentingRadiation { get; private set; }

	public AreaSensorVisual AreaSensorVisual
	{
		get
		{
			return _areaSensorVisual;
		}
	}

	public Corridor openAirlock
	{
		get
		{
			return _openAirlock;
		}
		private set
		{
			_openAirlock = value;
		}
	}

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	public static void ClearCachedTiles()
	{
		if (usedMaterialDict != null)
		{
			usedMaterialDict = null;
		}
	}

	protected virtual void Awake()
	{
		notVisitedOutline = new OutlineGroup(base.gameObject)
		{
			IsState = (RoomFlagsEnum)18,
			IsNotState = RoomFlagsEnum.Explored,
			LineColor = Color.white,
			IsDotted = true
		};
		visitedOutline = new OutlineGroup(base.gameObject, "Visited")
		{
			IsState = RoomFlagsEnum.Explored,
			LineColor = Color.white
		};
		transporterOutline = new OutlineGroup(base.gameObject, "Transporter")
		{
			IsState = RoomFlagsEnum.Any,
			LineColor = TransporterOutlineColorStrong,
			LineCapSize = 0.15f,
			ScaleAdjustment = 1.08f,
			LineWidth = 0.3f,
			EnableDynamicScaling = true
		};
		SVRoomStatusLayer.GetComponent<Renderer>().enabled = false;
		SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = false;
		icons = UnityEngine.Object.FindObjectsOfType(typeof(SchematicIcon)) as SchematicIcon[];
		roomRenderer = GetComponent<Renderer>();
		roomMaterial = roomRenderer.material;
	}

	protected virtual void Start()
	{
		if (corridors == null)
		{
			corridors = new List<Corridor>();
		}
		if (DungeonManager.Instance != null)
		{
			int num = DungeonManager.Instance.corridors.Length;
			for (int i = 0; i < num; i++)
			{
				Corridor corridor = DungeonManager.Instance.corridors[i];
				if (corridor.containsRoom(this))
				{
					AddCorridor(corridor);
				}
			}
		}
		_areaSensorVisual = base.transform.GetComponent<AreaSensorVisual>();
		if (_areaSensorVisual != null)
		{
			_areaSensorVisual.FirstTimeInitialize(this);
		}
		else
		{
			Debug.LogWarning("No AreaSensorVisual on this room! " + Label);
		}
		roomMaterial = DroneViewMtl;
		int num2 = UnityEngine.Random.Range(0, 3);
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		if (usedMaterialDict == null)
		{
			usedMaterialDict = new Dictionary<string, Material>();
		}
		int num3 = componentsInChildren.Length;
		for (int j = 0; j < num3; j++)
		{
			Transform transform = componentsInChildren[j];
			string text = transform.name;
			if (text.Length < 4 || text[0] != 'T' || !text.StartsWith("Tile"))
			{
				continue;
			}
			if (roomTileObjects == null)
			{
				roomTileObjects = new List<GameObject>(20);
			}
			GameObject gameObject = transform.gameObject;
			int num4 = UnityEngine.Random.Range(0, roomConfig.tileWeight);
			DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigTile dungeonRoomConfigTile = null;
			int count = roomConfig.tileList.Count;
			for (int k = 0; k < count; k++)
			{
				DungeonConfigurationManager.DungeonHelper.DungeonRoomConfigTile dungeonRoomConfigTile2 = roomConfig.tileList[k];
				if (num4 < dungeonRoomConfigTile2.weightAdj)
				{
					dungeonRoomConfigTile = dungeonRoomConfigTile2;
					break;
				}
			}
			Renderer component = gameObject.GetComponent<Renderer>();
			if (component != null)
			{
				bool flag = false;
				float x = 0f;
				float y = 0f;
				string text2 = dungeonRoomConfigTile.fileName;
				switch (text2)
				{
				case "tileMilitary1-normal":
					flag = true;
					x = 0f;
					y = 0f;
					text2 = "arrayMilitary";
					break;
				case "tileMilitary2-normal":
					flag = true;
					x = 0.5f;
					y = 0f;
					text2 = "arrayMilitary";
					break;
				case "tileMilitary3-normal":
					flag = true;
					x = 0f;
					y = 0.5f;
					text2 = "arrayMilitary";
					break;
				case "tileMilitaryBlank":
					flag = true;
					x = 0.5f;
					y = 0.5f;
					text2 = "arrayMilitary";
					break;
				}
				if (!usedMaterialDict.ContainsKey(dungeonRoomConfigTile.fileName))
				{
					Material material = component.material;
					material.SetTexture("_BumpMap", ResourceManager.LoadAsset<Texture>(string.Format("Materials/TileMaterials/{0}", text2)));
					if (flag)
					{
						material.SetTextureOffset("_BumpMap", new Vector2(x, y));
						material.SetTextureScale("_BumpMap", new Vector2(0.5f, 0.5f));
					}
					usedMaterialDict.Add(dungeonRoomConfigTile.fileName, material);
				}
				component.material = usedMaterialDict[dungeonRoomConfigTile.fileName];
			}
			if (!string.IsNullOrEmpty(dungeonRoomConfigTile.longSide) && ((dungeonRoomConfigTile.longSide == "x" && base.gameObject.transform.localScale.x > base.gameObject.transform.localScale.y) || (dungeonRoomConfigTile.longSide == "y" && base.gameObject.transform.localScale.y > base.gameObject.transform.localScale.x)))
			{
				Transform parent = gameObject.transform.parent;
				gameObject.transform.parent = null;
				gameObject.transform.Rotate(new Vector3(0f, 1f, 0f), 90f);
				gameObject.transform.parent = parent;
			}
			gameObject.isStatic = true;
			roomTileObjects.Add(gameObject);
		}
		if (roomTileObjects != null)
		{
			int count2 = roomTileObjects.Count;
			for (int l = 0; l < count2; l++)
			{
				GameObject gameObject2 = roomTileObjects[l];
				if (gameObject2.GetComponent<Renderer>() != null)
				{
					gameObject2.GetComponent<Renderer>().enabled = StartWithTilesVisible;
				}
			}
		}
		else
		{
			IsVisible = true;
		}
		notVisitedOutline.RefreshLines();
		visitedOutline.RefreshLines();
		transporterOutline.RefreshLines();
		if (!boardingVessel)
		{
			float num5 = base.transform.localScale.x * 2f + base.transform.localScale.y * 2f;
			outlineLineListNotVisible = new List<GameObject>((int)num5);
			outlineLineListVisible = new List<GameObject>((int)num5);
			float num6 = 0.5f;
			for (int m = 0; m < 4; m++)
			{
				float num7 = 0f;
				num7 = ((m != 0 && m != 1) ? base.transform.localScale.y : base.transform.localScale.x);
				int num8 = (int)num7;
				Vector3 position = base.transform.position - base.transform.localScale / 2f;
				switch (m)
				{
				case 0:
					position.x += num6;
					position.y += num6;
					break;
				case 1:
					position.x += num6;
					position.y = base.transform.position.y + (base.transform.localScale / 2f).y - num6;
					break;
				case 2:
					position.x += num6;
					position.y += num6;
					break;
				case 3:
					position.x = base.transform.position.x + (base.transform.localScale / 2f).x - num6;
					position.y += num6;
					break;
				}
				position.z = 1f;
				for (int n = 0; n < num8; n++)
				{
					bool flag2 = false;
					if (flag2)
					{
						continue;
					}
					GameObject gameObject3 = GameObjectPool.Instance.PopObject("EdgeLineObject");
					gameObject3.transform.position = position;
					switch (m)
					{
					case 1:
						gameObject3.transform.Rotate(new Vector3(0f, 0f, 1f), 180f);
						break;
					case 2:
						gameObject3.transform.Rotate(new Vector3(0f, 0f, 1f), -90f);
						break;
					case 3:
						gameObject3.transform.Rotate(new Vector3(0f, 0f, 1f), 90f);
						break;
					}
					gameObject3.transform.parent = base.transform;
					if (!flag2)
					{
						Transform transform2 = gameObject3.transform.Find("SVEdgeLine");
						if (transform2 != null)
						{
							transform2.gameObject.GetComponent<Renderer>().enabled = false;
						}
						transform2 = gameObject3.transform.Find("DVEdgeLine");
						if (transform2 != null)
						{
							transform2.gameObject.GetComponent<Renderer>().enabled = false;
						}
						outlineLineListNotVisible.Add(gameObject3);
						if (m == 0 || m == 1)
						{
							position.x += 1f;
						}
						else
						{
							position.y += 1f;
						}
					}
				}
			}
		}
		if (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.IsDesignedShip)
		{
			string metaData = GetMetaData("motionstatus");
			if (metaData == "1")
			{
				motionBroken = true;
			}
			else
			{
				motionBroken = false;
			}
		}
		AddSoundSources();
	}

	protected virtual void OnDestroy()
	{
		if (environmentModelsLarge != null)
		{
			int count = environmentModelsLarge.Count;
			for (int i = 0; i < count; i++)
			{
				environmentModelsLarge[i] = null;
			}
			environmentModelsLarge = null;
		}
		if (environmentModels != null)
		{
			int count2 = environmentModels.Count;
			for (int j = 0; j < count2; j++)
			{
				environmentModels[j] = null;
			}
			environmentModels = null;
		}
		if (wallModels != null)
		{
			int count3 = wallModels.Count;
			for (int k = 0; k < count3; k++)
			{
				wallModels[k] = null;
			}
			wallModels = null;
		}
		if (roomTileObjects != null)
		{
			int count4 = roomTileObjects.Count;
			for (int l = 0; l < count4; l++)
			{
				roomTileObjects[l] = null;
			}
			roomTileObjects = null;
		}
		if (StaticCollisionObjects != null)
		{
			int count5 = StaticCollisionObjects.Count;
			for (int m = 0; m < count5; m++)
			{
				StaticCollisionObjects[m] = null;
			}
			StaticCollisionObjects = null;
		}
		if (outlineLineListNotVisible != null)
		{
			int count6 = outlineLineListNotVisible.Count;
			for (int n = 0; n < count6; n++)
			{
				outlineLineListNotVisible[n] = null;
			}
			outlineLineListNotVisible = null;
		}
		if (outlineLineListVisible != null)
		{
			int count7 = outlineLineListVisible.Count;
			for (int num = 0; num < count7; num++)
			{
				outlineLineListVisible[num] = null;
			}
			outlineLineListVisible = null;
		}
		environmentModelsLargeRenderers = null;
		wallModelsRenderers = null;
		usedMaterialDict = null;
		labelObject = null;
		SVRoomStatusLayer = null;
		SVEnvPressureStatusLayer = null;
		SVEnvRadiationStatusLayer = null;
		labelTextObject = null;
		labelBorder = null;
		overlayObject = null;
		overlayWarning1Object = null;
		overlayWarning2Object = null;
		DroneViewMtl = null;
		SchematicViewExploredOnMtl = null;
		SchematicViewExploredOffMtl = null;
		SchematicViewUnexploredOnMtl = null;
		SchematicViewUnexploredOffMtl = null;
		SchematicViewExploredDestroyedMtl = null;
		SchematicViewUnexploredDestroyedMtl = null;
		SchematicViewScannedOnMtl = null;
		SchematicViewScannedOffMtl = null;
		SchematicViewScannedDestroyedMtl = null;
		SchematicViewDepressurizedMtl = null;
		roomRenderer = null;
		roomMaterial = null;
	}

	public bool ToggleRoomFlag()
	{
		isFlagged = !isFlagged;
		if (isFlagged)
		{
			labelTextObject.color = FlaggedRoomColor;
		}
		else if (isPowered)
		{
			labelTextObject.color = DungeonManager.Instance.SVPoweredRoom;
		}
		else
		{
			labelTextObject.color = DungeonManager.Instance.SVUnPoweredRoom;
		}
		return isFlagged;
	}

	public void ClearRoomFlag()
	{
		isFlagged = false;
		if (isPowered)
		{
			labelTextObject.color = DungeonManager.Instance.SVPoweredRoom;
		}
		else
		{
			labelTextObject.color = DungeonManager.Instance.SVUnPoweredRoom;
		}
	}

	public void AddDroneOverlayUI(DroneUIObject droneUIObject)
	{
		if (droneUIObjectList == null)
		{
			droneUIObjectList = new List<DroneUIObject>();
		}
		droneUIObjectList.Add(droneUIObject);
		droneUIObject.gameObject.SetActive(true);
	}

	public void TutorialJumpstartR2()
	{
		Start();
	}

	public void AddCorridor(Corridor corridor)
	{
		if (!(corridor != null))
		{
			return;
		}
		if (corridors == null)
		{
			corridors = new List<Corridor>();
		}
		if (corridor.IsAirlock)
		{
			if (corridor.door.AirlockOpenedEvent == null)
			{
				Door door = corridor.door;
				door.AirlockOpenedEvent = (DoorStateChangedDelegate)Delegate.Combine(door.AirlockOpenedEvent, new DoorStateChangedDelegate(AirlockOpened));
			}
			if (corridor.door.AirlockClosedEvent == null)
			{
				Door door2 = corridor.door;
				door2.AirlockClosedEvent = (DoorStateChangedDelegate)Delegate.Combine(door2.AirlockClosedEvent, new DoorStateChangedDelegate(AirlockClosed));
			}
		}
		else if (corridor.door != null)
		{
			Door door3 = corridor.door;
			door3.DoorOpenedEvent = (DoorStateChangedDelegate)Delegate.Combine(door3.DoorOpenedEvent, new DoorStateChangedDelegate(DoorOpened));
			Door door4 = corridor.door;
			door4.DoorClosedEvent = (DoorStateChangedDelegate)Delegate.Combine(door4.DoorClosedEvent, new DoorStateChangedDelegate(DoorClosed));
		}
		if (!corridors.Contains(corridor))
		{
			corridors.Add(corridor);
		}
	}

	public void RemoveCorridor(Corridor corridor)
	{
		if (corridor.IsAirlock)
		{
			Door door = corridor.door;
			door.AirlockOpenedEvent = (DoorStateChangedDelegate)Delegate.Remove(door.AirlockOpenedEvent, new DoorStateChangedDelegate(AirlockOpened));
			Door door2 = corridor.door;
			door2.AirlockClosedEvent = (DoorStateChangedDelegate)Delegate.Remove(door2.AirlockClosedEvent, new DoorStateChangedDelegate(AirlockClosed));
			Door door3 = corridor.door;
			door3.AirlockOpenedEvent = (DoorStateChangedDelegate)Delegate.Remove(door3.AirlockOpenedEvent, new DoorStateChangedDelegate(AirlockOpened));
			Door door4 = corridor.door;
			door4.AirlockClosedEvent = (DoorStateChangedDelegate)Delegate.Remove(door4.AirlockClosedEvent, new DoorStateChangedDelegate(AirlockClosed));
			Door door5 = corridor.door;
			door5.AirlockOpenedEvent = (DoorStateChangedDelegate)Delegate.Remove(door5.AirlockOpenedEvent, new DoorStateChangedDelegate(AirlockOpened));
			Door door6 = corridor.door;
			door6.AirlockClosedEvent = (DoorStateChangedDelegate)Delegate.Remove(door6.AirlockClosedEvent, new DoorStateChangedDelegate(AirlockClosed));
		}
		else
		{
			Door door7 = corridor.door;
			door7.DoorOpenedEvent = (DoorStateChangedDelegate)Delegate.Remove(door7.DoorOpenedEvent, new DoorStateChangedDelegate(DoorOpened));
			Door door8 = corridor.door;
			door8.DoorClosedEvent = (DoorStateChangedDelegate)Delegate.Remove(door8.DoorClosedEvent, new DoorStateChangedDelegate(DoorClosed));
		}
		corridors.Remove(corridor);
	}

	public void DroneEnteredRoom()
	{
		if (!hasDroneEverEnteredRoom)
		{
			hasDroneEverEnteredRoom = true;
			if (DungeonManager.Instance != null)
			{
				DungeonManager.Instance.TestForExploredHint();
			}
		}
		if (!GlobalSettings.MissionStarted)
		{
			return;
		}
		if (boardingVessel)
		{
			if (!GameSaveFile.Get("HNT_SHIPEXPLORED", false))
			{
				bool flag = true;
				foreach (Drone drones in DroneManager.Instance.dronesList)
				{
					if (drones.CurrentRoom != this)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					HintManager.HintCompleted(typeof(ShipExploredHint));
				}
			}
			if (GameSaveFile.Get("HNT_EXIT", false))
			{
				return;
			}
			bool flag2 = true;
			foreach (Drone drones2 in DroneManager.Instance.dronesList)
			{
				if (drones2.CurrentRoom != this)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				HintManager.PushHint(new ExitHint());
				isShowingExitHint = true;
			}
		}
		else if (isShowingExitHint)
		{
			HintManager.HintCanceled(typeof(ExitHint));
			isShowingExitHint = false;
		}
	}

	private void fade()
	{
		fading = true;
		fadeTimeCurrent = fadeTimeTotal;
	}

	public void fadeIn()
	{
		if (IsVisible || this is BoardingShip)
		{
			return;
		}
		fadingIn = true;
		if (!onSchematic)
		{
			MarkAsDiscovered();
		}
		Show();
		fade();
		onSchematic = true;
		if (corridors != null)
		{
			int count = corridors.Count;
			for (int i = 0; i < count; i++)
			{
				corridors[i].onSchematic = true;
			}
		}
		if (!isExplored)
		{
			isExplored = true;
			if (!onSchematic && GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				isScanning = true;
				_blinkManager.Start((!isPowered) ? SchematicViewScannedOffMtl.color : SchematicViewScannedOnMtl.color, GetBaseColor(), 0.2f, 3);
			}
		}
		roomMaterial = DroneViewMtl;
		foreach (RoomItem roomItem in roomItems)
		{
			if (roomItem != null)
			{
				roomItem.Show = true;
			}
		}
		if (droneUIObjectList != null)
		{
		}
		DroneManager instance = DroneManager.Instance;
		foreach (Drone lootableDrones in instance.LootableDronesList)
		{
			if (lootableDrones.CurrentRoom == this && !lootableDrones.IsVisible)
			{
				Drone drone = lootableDrones;
				instance.ShowDrone(ref drone);
			}
		}
		IEnumerable<ShipUpgradeInGameObject> enumerable = DungeonManager.Instance.ShipUpgrades.Where((ShipUpgradeInGameObject x) => x != null && GetComponent<Collider>().bounds.Intersects(x.GetComponent<Collider>().bounds));
		foreach (ShipUpgradeInGameObject item in enumerable)
		{
			item.Show = true;
		}
		ShowRegisteredEnimies();
	}

	public void FadeOut()
	{
		if (!IsVisible)
		{
			return;
		}
		fadingIn = false;
		fade();
		foreach (RoomItem roomItem in roomItems)
		{
			if (roomItem != null && !(roomItem is TransporterReceiver))
			{
				roomItem.Show = false;
			}
		}
		if (droneUIObjectList != null)
		{
		}
		IEnumerable<ShipUpgradeInGameObject> enumerable = DungeonManager.Instance.ShipUpgrades.Where((ShipUpgradeInGameObject x) => x != null && GetComponent<Collider>().bounds.Intersects(x.GetComponent<Collider>().bounds));
		foreach (ShipUpgradeInGameObject item in enumerable)
		{
			item.Show = false;
		}
		HideRegisteredEnimies();
	}

	public void Show()
	{
		if (roomTileObjects == null)
		{
			base.gameObject.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			foreach (GameObject roomTileObject in roomTileObjects)
			{
				if (roomTileObject.GetComponent<Renderer>() != null)
				{
					roomTileObject.GetComponent<Renderer>().enabled = true;
				}
			}
		}
		if (environmentModels != null && environmentModels.Count > 0)
		{
			foreach (GameObject environmentModel in environmentModels)
			{
				environmentModel.SetActive(true);
			}
		}
		if (environmentModelsLarge != null && environmentModelsLarge.Count > 0)
		{
			foreach (GameObject item in environmentModelsLarge)
			{
				Renderer value;
				if (environmentModelsLargeRenderers.TryGetValue(item, out value))
				{
					value.enabled = true;
				}
				else
				{
					item.SetActive(true);
				}
			}
		}
		if (wallModels != null && wallModels.Count > 0)
		{
			foreach (GameObject wallModel in wallModels)
			{
				Renderer value2;
				if (wallModelsRenderers.TryGetValue(wallModel, out value2))
				{
					value2.enabled = true;
				}
				else
				{
					wallModel.SetActive(true);
				}
			}
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			if (drones.CurrentRoom == this)
			{
				drones.droneViewModel.SetActive(true);
			}
		}
		foreach (Drone lootableDrones in DroneManager.Instance.LootableDronesList)
		{
			if (lootableDrones.CurrentRoom == this)
			{
				lootableDrones.droneViewModel.SetActive(true);
			}
		}
		IsVisible = true;
		if (isPowered && asRAmbientEquipment != null)
		{
			asRAmbientEquipment.Play();
		}
	}

	public void Hide()
	{
		Hide(false);
	}

	public void Hide(bool forChangeToSchematicView)
	{
		if (roomTileObjects == null)
		{
			base.gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			foreach (GameObject roomTileObject in roomTileObjects)
			{
				if (roomTileObject.GetComponent<Renderer>() != null)
				{
					roomTileObject.GetComponent<Renderer>().enabled = false;
				}
			}
		}
		if (environmentModels != null && environmentModels.Count > 0)
		{
			foreach (GameObject environmentModel in environmentModels)
			{
				environmentModel.SetActive(false);
			}
		}
		if (environmentModelsLarge != null && environmentModelsLarge.Count > 0)
		{
			foreach (GameObject item in environmentModelsLarge)
			{
				Renderer value;
				if (environmentModelsLargeRenderers.TryGetValue(item, out value))
				{
					value.enabled = false;
				}
				else
				{
					item.SetActive(false);
				}
			}
		}
		if (wallModels != null && wallModels.Count > 0)
		{
			foreach (GameObject wallModel in wallModels)
			{
				Renderer value2;
				if (wallModelsRenderers.TryGetValue(wallModel, out value2))
				{
					value2.enabled = false;
				}
				else
				{
					wallModel.SetActive(false);
				}
			}
		}
		foreach (Drone lootableDrones in DroneManager.Instance.LootableDronesList)
		{
			if (lootableDrones.CurrentRoom == this)
			{
				lootableDrones.droneViewModel.SetActive(false);
			}
		}
		if (!forChangeToSchematicView)
		{
			IsVisible = false;
			if (asRAmbientEquipment != null && asRAmbientEquipment.isPlaying)
			{
				asRAmbientEquipment.Pause();
			}
		}
	}

	protected virtual void Update()
	{
		if (GlobalSettings.IsGamePaused)
		{
			return;
		}
		if (isScanning && !_blinkManager.IsActive)
		{
			isScanning = false;
		}
		if (fading)
		{
			fadeTimeCurrent += Time.deltaTime;
			float num = fadeTimeCurrent / fadeTimeTotal;
			if (num > 1f)
			{
				if (!(this is BoardingShip))
				{
					if (fadingIn)
					{
						num = 1f;
					}
					else
					{
						num = 0f;
						Hide();
						foreach (RoomItem roomItem in roomItems)
						{
							if (roomItem != null)
							{
								roomItem.Show = false;
							}
						}
					}
				}
				Color color = DroneViewMtl.color;
				color.a = num;
				roomMaterial.color = color;
				fading = false;
			}
			else
			{
				if (!fadingIn)
				{
					num = 1f - num;
				}
				Color color = DroneViewMtl.color;
				color.a = num;
				roomMaterial.color = color;
			}
		}
		if (IsFillingWithRadiation || IsRadiated)
		{
			if (!IsVentingRadiation)
			{
				destructionTimer += Time.deltaTime * radiationSourceFactor;
				destructionAttackTimer += Time.deltaTime * radiationSourceFactor;
				if (!isRadiatedDueToExposure)
				{
					foreach (Corridor corridor in corridors)
					{
						if (corridor.door.state != DoorState.Open)
						{
							continue;
						}
						Room otherRoom = corridor.getOtherRoom(this);
						if (otherRoom != null)
						{
							otherRoom.destructionComtaminationTimer += Time.deltaTime;
							if (otherRoom.destructionComtaminationTimer > otherRoom.destructionComtaminationTime)
							{
								corridor.isSurroundedByRadiation = true;
								otherRoom.Radiate("due to contamination from " + Label);
							}
						}
						else
						{
							corridor.isSurroundedByRadiation = true;
						}
					}
				}
				if (IsFillingWithRadiation && !GlobalSettings.GameIsOver && destructionTimer > destructionTime)
				{
					IsRadiated = true;
					IsFillingWithRadiation = false;
					_blinkManagerRadiationLayer.Stop();
					if (GlobalSettings.cameraMode == CameraMode.Schematic)
					{
						SetSchematicViewMaterial();
					}
					SystemMessageManager.ShowSystemMessage("Radiation has completely flooded room: " + Label, ConsoleMessageType.Warning);
				}
				if (destructionAttackTimer > destructionAttackTime)
				{
					destructionAttackTimer = 0f;
					foreach (Drone drones in DroneManager.Instance.dronesList)
					{
						if (drones.CurrentRoom == this)
						{
							if (IsFillingWithRadiation)
							{
								drones.TakeDamage(2f, DamageType.Radiation, null);
							}
							else if (IsRadiated)
							{
								drones.TakeDamage(5f, DamageType.Radiation, null);
							}
						}
					}
					foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
					{
						if (enemy.CurrentRoom == this)
						{
							if (IsFillingWithRadiation)
							{
								enemy.TakeDamage(2f, DamageType.Radiation, null);
							}
							else if (IsRadiated)
							{
								enemy.TakeDamage(5f, DamageType.Radiation, null);
							}
						}
					}
				}
				if (isPendingRadiationVenting)
				{
					timerExposureEvents -= Time.deltaTime;
					if (timerExposureEvents <= 0f)
					{
						timerExposureEvents = 0f;
						isPendingRadiationVenting = false;
						if (!IsPendingDepressure && !IsDepressurized)
						{
							IsVentingRadiation = true;
							float num2 = 1f;
							if (IsFillingWithRadiation)
							{
								num2 = destructionTimer / destructionTime;
							}
							timerExposureEvents = UnityEngine.Random.Range(2f, 5f) * num2;
							_blinkManagerRadiationLayer.Start(GetBaseColor(), SchematicViewExploredDestroyedMtl.color, 0.2f);
							SystemMessageManager.ShowSystemMessage("Venting radiation in room " + Label, ConsoleMessageType.Benefit);
						}
					}
				}
			}
			else
			{
				timerExposureEvents -= Time.deltaTime;
				if (timerExposureEvents <= 0f)
				{
					timerExposureEvents = 0f;
					IsFillingWithRadiation = false;
					IsRadiated = false;
					IsVentingRadiation = false;
					isRadiatedDueToExposure = false;
					_blinkManagerRadiationLayer.Stop();
					if (GlobalSettings.cameraMode == CameraMode.Schematic)
					{
						SetSchematicViewMaterial();
					}
					SystemMessageManager.ShowSystemMessage("Completely vented radiation in room " + Label, ConsoleMessageType.Benefit);
				}
			}
		}
		else if (IsInPreNaturalRadiationState)
		{
			if (isPendingMothershipCreak)
			{
				mothershipCreakTimer -= Time.deltaTime;
				if (mothershipCreakTimer <= 0f)
				{
					mothershipCreakTimer = 0f;
					isPendingMothershipCreak = false;
					GameAudio.SoundEnum soundEnum = GameAudio.SoundEnum.None;
					DungeonManager.Instance.PlayMothershipCreak();
				}
			}
			preNaturalRadiationTimer -= Time.deltaTime;
			if (preNaturalRadiationTimer <= 0f)
			{
				preNaturalRadiationTimer = 0f;
				IsInPreNaturalRadiationState = false;
				if (!willNaturalRadiationFail)
				{
					Radiate("due to pipe rupture");
				}
			}
		}
		if (IsPendingDepressure)
		{
			timerExposureEvents -= Time.deltaTime;
			if (timerExposureEvents <= 0f)
			{
				IsPendingDepressure = false;
				DepressurizeRoom(false);
			}
		}
		else if (IsPendingPressurize)
		{
			timerExposureEvents -= Time.deltaTime;
			if (timerExposureEvents <= 0f)
			{
				IsPendingPressurize = false;
				PressurizeRoom();
			}
		}
		else if (IsDepressurized)
		{
			List<Room> testedRooms = new List<Room>();
			if (OpenAirlockFound(ref testedRooms, out _openAirlock))
			{
				VaporizePlayerDrones(openAirlock);
			}
			VaporizeEnemiesInRoom();
			VaporizeProbesInRoom();
			VaporizeDroppableItems();
			if (isInInitialExposure)
			{
				timerExposureEvents -= Time.deltaTime;
				if (timerExposureEvents <= 0f)
				{
					timerExposureEvents = UnityEngine.Random.Range(5f, 10f);
					isInInitialExposure = false;
					_blinkManagerPressureLayer.Stop();
					if (IsFillingWithRadiation)
					{
						StartBlinkRadiate();
					}
					if (GlobalSettings.cameraMode == CameraMode.Schematic)
					{
						SetSchematicViewMaterial();
					}
					if (!IsFillingWithRadiation && !IsRadiated && !GameSaveFile.Get("HNT_ALOCK_CLOSE", false) && !GlobalSettings.IsTutorial)
					{
						HintManager.PushHint(new CloseAirlockHint(Label));
					}
				}
			}
			else if (!IsFillingWithRadiation)
			{
				timerExposureEvents -= Time.deltaTime;
				if (timerExposureEvents <= 0f)
				{
					timerExposureEvents = 0f;
					Radiate("due to direct space exposure");
					HintManager.HintCanceled(typeof(CloseAirlockHint));
				}
			}
		}
		if (IsPendingDecontaminate)
		{
			timerDecontaminateEvents -= Time.deltaTime;
			if (timerDecontaminateEvents <= 0f)
			{
				IsPendingDecontaminate = false;
				Decontaminate();
			}
		}
		else if (IsDecontaminating)
		{
			timerDecontaminateEvents -= Time.deltaTime;
			if (timerDecontaminateEvents <= 0f)
			{
				IsDecontaminating = false;
				_blinkManagerRadiationLayer.Stop();
				ShowingRadiationOverlay = false;
				isEnvRadiationStatusPlaneActive = false;
				overlayObject.gameObject.SetActive(false);
				_blinkManagerRadiationLayer.Stop();
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().enabled = false;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					SetSchematicViewMaterial();
				}
				SystemMessageManager.ShowSystemMessage(string.Format("Room decontaminated: {0}", Label), ConsoleMessageType.Benefit);
			}
			if (_blinkManagerRadiationLayer.IsActive)
			{
				Color color2 = Color.white;
				bool flag = _blinkManagerRadiationLayer.Update(Time.deltaTime, out color2);
				if (boardingVessel)
				{
					color2.a = BoardingShip.Instance.ShipAlpha;
				}
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().material.color = color2;
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			if (notVisitedOutline.IsBlinking)
			{
				notVisitedOutline.Update();
			}
			if (visitedOutline.IsBlinking)
			{
				visitedOutline.Update();
			}
			if (transporterOutline.IsBlinking)
			{
				transporterOutline.Update();
			}
			if (_blinkManager.IsActive)
			{
				Color color3 = Color.white;
				bool flag2 = _blinkManager.Update(Time.deltaTime, out color3);
				if (boardingVessel)
				{
					color3.a = BoardingShip.Instance.ShipAlpha;
				}
				SVRoomStatusLayer.GetComponent<Renderer>().material.color = color3;
			}
			if (_blinkManagerPressureLayer.IsActive)
			{
				Color color4 = Color.white;
				bool flag3 = _blinkManagerPressureLayer.Update(Time.deltaTime, out color4);
				if (boardingVessel)
				{
					color4.a = BoardingShip.Instance.ShipAlpha;
				}
				SVEnvPressureStatusLayer.GetComponent<Renderer>().material.color = color4;
			}
			if (_blinkManagerRadiationLayer.IsActive)
			{
				Color color5 = Color.white;
				bool flag4 = _blinkManagerRadiationLayer.Update(Time.deltaTime, out color5);
				if (boardingVessel)
				{
					color5.a = BoardingShip.Instance.ShipAlpha;
				}
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().material.color = color5;
			}
		}
		if (asRAmbientEquipment != null && asRAmbientEquipment.isPlaying)
		{
			asRAmbientEquipment.volume = GameAudio.AmbienceVolume;
		}
	}

	public void TestEdge(Drone drone)
	{
		if (boardingVessel)
		{
			return;
		}
		int count = outlineLineListNotVisible.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (outlineLineListNotVisible[num].GetComponent<Collider>().bounds.Intersects(drone.GetComponent<Collider>().bounds))
			{
				Transform transform = null;
				Transform transform2 = null;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					transform = outlineLineListNotVisible[num].transform.Find("SVEdgeLine");
					transform2 = outlineLineListNotVisible[num].transform.Find("DVEdgeLine");
				}
				else
				{
					transform = outlineLineListNotVisible[num].transform.Find("DVEdgeLine");
					transform2 = outlineLineListNotVisible[num].transform.Find("SVEdgeLine");
				}
				if (transform != null)
				{
					transform.gameObject.GetComponent<Renderer>().enabled = true;
					if (isPowered)
					{
						transform.gameObject.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlinePoweredColor;
					}
					else
					{
						transform.gameObject.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlineUnPoweredColor;
					}
				}
				if (transform2 != null)
				{
					transform2.gameObject.GetComponent<Renderer>().enabled = false;
					if (isPowered)
					{
						transform2.gameObject.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlinePoweredColor;
					}
					else
					{
						transform2.gameObject.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlineUnPoweredColor;
					}
				}
				outlineLineListVisible.Add(outlineLineListNotVisible[num]);
				outlineLineListNotVisible.RemoveAt(num);
			}
		}
	}

	public void power(DungeonPowerInlet powerInlet, bool powerInput)
	{
		if (!powerInput && powerInlet != null)
		{
			if (powerInlet == null)
			{
				currentPowerSourceList.Clear();
			}
			else
			{
				if (powerInlet != null && currentPowerSourceList.Contains(powerInlet))
				{
					currentPowerSourceList.Remove(powerInlet);
				}
				if (currentPowerSourceList.Count > 0)
				{
					return;
				}
			}
		}
		if (powerInput && !isExplored && !isScanned)
		{
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				isScanning = true;
				_blinkManager.Start(SchematicViewUnexploredOnMtl.color, Color.black, 0.2f, 3);
			}
			if (!onSchematic)
			{
				MarkAsDiscovered();
			}
		}
		isPowered = powerInput;
		if (corridors == null)
		{
			Debug.LogWarning(string.Format("This is VERY bad, 'corridors' is null for this room: {0} ({1}).  If you launched the Tutorial directly via Unity Editor don't worry about it so much, I guess...", Label, base.gameObject.name));
		}
		else
		{
			int count = corridors.Count;
			for (int i = 0; i < count; i++)
			{
				Corridor corridor = corridors[i];
				if (corridor != null)
				{
					corridor.power();
				}
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			SetSchematicViewMaterial();
		}
		if (isPowered)
		{
			onSchematic = true;
			if (corridors != null)
			{
				int count2 = corridors.Count;
				for (int j = 0; j < count2; j++)
				{
					corridors[j].onSchematic = true;
				}
			}
			if (corridors != null && GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				int count3 = corridors.Count;
				for (int k = 0; k < count3; k++)
				{
					Corridor corridor2 = corridors[k];
					corridor2.Show();
					if (corridor2.door != null)
					{
						corridor2.door.hide(false);
					}
					labelTextObject.enabled = true;
				}
			}
			if (powerInlet != null && !currentPowerSourceList.Contains(powerInlet))
			{
				currentPowerSourceList.Add(powerInlet);
			}
			notVisitedOutline.SetColor(DungeonManager.Instance.SVPoweredRoom);
			visitedOutline.SetColor(DungeonManager.Instance.SVPoweredRoom);
			if (!isFlagged)
			{
				labelTextObject.color = DungeonManager.Instance.SVPoweredRoom;
			}
			int num = 0;
			if (!boardingVessel && outlineLineListVisible != null)
			{
				num = outlineLineListVisible.Count;
				for (int l = 0; l < num; l++)
				{
					GameObject gameObject = outlineLineListVisible[l];
					Transform transform = gameObject.transform.FindChild("SVEdgeLine");
					transform.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlinePoweredColor;
					transform = gameObject.transform.FindChild("DVEdgeLine");
					transform.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlinePoweredColor;
				}
			}
			num = roomItems.Count;
			for (int m = 0; m < num; m++)
			{
				RoomItem roomItem = roomItems[m];
				if (roomItem != null)
				{
					roomItem.BeginPowerFlow();
				}
			}
		}
		else
		{
			notVisitedOutline.SetColor(DungeonManager.Instance.SVUnPoweredRoom);
			visitedOutline.SetColor(DungeonManager.Instance.SVUnPoweredRoom);
			if (!isFlagged)
			{
				labelTextObject.color = DungeonManager.Instance.SVUnPoweredRoom;
			}
			int num2 = 0;
			if (!boardingVessel && outlineLineListVisible != null)
			{
				num2 = outlineLineListVisible.Count;
				for (int n = 0; n < num2; n++)
				{
					GameObject gameObject2 = outlineLineListVisible[n];
					Transform transform2 = gameObject2.transform.FindChild("SVEdgeLine");
					transform2.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlineUnPoweredColor;
					transform2 = gameObject2.transform.FindChild("DVEdgeLine");
					transform2.GetComponent<Renderer>().material.color = DungeonManager.Instance.EdgeOutlineUnPoweredColor;
				}
			}
			num2 = roomItems.Count;
			for (int num3 = 0; num3 < num2; num3++)
			{
				RoomItem roomItem2 = roomItems[num3];
				if (roomItem2 != null)
				{
					roomItem2.EndPowerFlow();
				}
			}
		}
		UpdateCameraView();
	}

	public void RefreshOnRoomStatusChange()
	{
		onSchematic = true;
		notVisitedOutline.RefreshLines();
		visitedOutline.RefreshLines();
		transporterOutline.RefreshLines();
		notVisitedOutline.ShowLines();
		visitedOutline.ShowLines();
		transporterOutline.ShowLines();
	}

	public void RefreshCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			SetDroneViewMaterial();
			return;
		}
		SetSchematicViewMaterial();
		if (IsVisible)
		{
			Hide();
		}
		notVisitedOutline.ShowLines();
		visitedOutline.ShowLines();
	}

	public virtual void SetSchematicViewMaterial()
	{
		bool flag = false;
		RoomLayerEnum roomLayerEnum = (RoomLayerEnum)0;
		if (isScanned)
		{
			if (IsFillingWithRadiation || IsRadiated)
			{
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().material = SchematicViewScannedDestroyedMtl;
				roomLayerEnum |= RoomLayerEnum.RadiationLayer;
			}
			else if (IsDepressurized)
			{
				SVEnvPressureStatusLayer.GetComponent<Renderer>().material = SchematicViewDepressurizedMtl;
				roomLayerEnum |= RoomLayerEnum.PressureLayer;
			}
			if (isPowered)
			{
				SVRoomStatusLayer.GetComponent<Renderer>().material = SchematicViewScannedOnMtl;
				roomLayerEnum |= RoomLayerEnum.RoomLayer;
			}
			else
			{
				SVRoomStatusLayer.GetComponent<Renderer>().material = SchematicViewScannedOffMtl;
				roomLayerEnum |= RoomLayerEnum.RoomLayer;
			}
			flag = true;
		}
		else if (isExplored)
		{
			if (IsFillingWithRadiation || IsRadiated)
			{
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().material = SchematicViewExploredDestroyedMtl;
				flag = true;
				roomLayerEnum |= RoomLayerEnum.RadiationLayer;
			}
			else if (IsDepressurized)
			{
				SVEnvPressureStatusLayer.GetComponent<Renderer>().material = SchematicViewDepressurizedMtl;
				flag = true;
				roomLayerEnum |= RoomLayerEnum.PressureLayer;
			}
		}
		else if (IsFillingWithRadiation || IsRadiated)
		{
			SVEnvRadiationStatusLayer.GetComponent<Renderer>().material = SchematicViewUnexploredDestroyedMtl;
			flag = true;
			roomLayerEnum |= RoomLayerEnum.RadiationLayer;
		}
		else if (IsDepressurized || IsPendingDepressure)
		{
			SVEnvPressureStatusLayer.GetComponent<Renderer>().material = SchematicViewDepressurizedMtl;
			flag = true;
			roomLayerEnum |= RoomLayerEnum.PressureLayer;
		}
		if (flag)
		{
			Vector2 one = Vector2.one;
			if ((roomLayerEnum & RoomLayerEnum.RoomLayer) == RoomLayerEnum.RoomLayer)
			{
				one.x = base.transform.localScale.x / 8f;
				one.y = base.transform.localScale.y / 8f;
				isRoomStatusPlaneActive = true;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					SVRoomStatusLayer.GetComponent<Renderer>().enabled = true;
				}
				SVRoomStatusLayer.GetComponent<Renderer>().material.mainTextureScale = one;
			}
			if ((roomLayerEnum & RoomLayerEnum.PressureLayer) == RoomLayerEnum.PressureLayer)
			{
				one.x = base.transform.localScale.x / 2f;
				one.y = base.transform.localScale.y / 2f;
				isEnvPressureStatusPlaneActive = true;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = true;
				}
				SVEnvPressureStatusLayer.GetComponent<Renderer>().material.mainTextureScale = one;
			}
			if ((roomLayerEnum & RoomLayerEnum.RadiationLayer) == RoomLayerEnum.RadiationLayer)
			{
				one.x = base.transform.localScale.x / 2f;
				one.y = base.transform.localScale.y / 2f;
				isEnvRadiationStatusPlaneActive = true;
				if (GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					SVEnvRadiationStatusLayer.GetComponent<Renderer>().enabled = true;
				}
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().material.mainTextureScale = one;
			}
		}
		else
		{
			isRoomStatusPlaneActive = false;
			isEnvPressureStatusPlaneActive = false;
			isEnvRadiationStatusPlaneActive = false;
			SVRoomStatusLayer.GetComponent<Renderer>().enabled = false;
			SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = false;
			SVEnvRadiationStatusLayer.GetComponent<Renderer>().enabled = false;
		}
	}

	protected virtual void SetDroneViewMaterial()
	{
		roomMaterial = DroneViewMtl;
	}

	private Color GetCurrentSchematicColor()
	{
		if (isScanned)
		{
			if (IsFillingWithRadiation || IsRadiated)
			{
				return SchematicViewScannedDestroyedMtl.color;
			}
			if (IsDepressurized)
			{
				return DecompressedColorOn;
			}
			if (isPowered)
			{
				return SchematicViewScannedOnMtl.color;
			}
			return SchematicViewScannedOffMtl.color;
		}
		if (isExplored)
		{
			if (IsFillingWithRadiation || IsRadiated)
			{
				return SchematicViewExploredDestroyedMtl.color;
			}
			if (IsDepressurized)
			{
				return DecompressedColorOn;
			}
			if (isPowered)
			{
				return SchematicViewExploredOnMtl.color;
			}
			return SchematicViewExploredOffMtl.color;
		}
		if (IsFillingWithRadiation || IsRadiated)
		{
			return SchematicViewUnexploredDestroyedMtl.color;
		}
		if (IsDepressurized)
		{
			return DecompressedColorOn;
		}
		if (isPowered)
		{
			return SchematicViewUnexploredOnMtl.color;
		}
		return SchematicViewUnexploredOffMtl.color;
	}

	private Color GetBaseColor()
	{
		if (isScanned)
		{
			if (isPowered)
			{
				return SchematicViewScannedOnMtl.color;
			}
			return SchematicViewScannedOffMtl.color;
		}
		if (isExplored)
		{
			if (isPowered)
			{
				return SchematicViewExploredOnMtl.color;
			}
			return SchematicViewExploredOffMtl.color;
		}
		if (isPowered)
		{
			return SchematicViewUnexploredOnMtl.color;
		}
		return SchematicViewUnexploredOffMtl.color;
	}

	public bool scan(bool selfScan)
	{
		string result;
		return scan(selfScan, out result);
	}

	public bool scan(bool selfScan, out string result)
	{
		result = "<no new items>";
		bool flag = false;
		if (selfScan && scannerBroken && !GlobalSettings.cheatMode)
		{
			return false;
		}
		if (!isScanned)
		{
			isScanned = true;
			if (!isExplored && !onSchematic && GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				isScanning = true;
				_blinkManager.Start((!isPowered) ? SchematicViewScannedOffMtl.color : SchematicViewScannedOnMtl.color, Color.black, 0.2f, 3);
			}
			MarkAsDiscovered();
		}
		isExplored = true;
		if (roomItems.Count > 0)
		{
			int count = roomItems.Count;
			for (int i = 0; i < count; i++)
			{
				RoomItem roomItem = roomItems[i];
				if (roomItem != null)
				{
					if (!roomItem.WasScanned && !roomItem.Found)
					{
						flag = true;
					}
					roomItem.UpdateCameraView();
					roomItem.Scanned();
				}
				int num = icons.Length;
				for (int j = 0; j < num; j++)
				{
					icons[j].UpdateCameraView();
				}
			}
		}
		int count2 = corridors.Count;
		for (int k = 0; k < count2; k++)
		{
			Corridor corridor = corridors[k];
			if (corridor != null)
			{
				corridor.Scanned();
			}
		}
		DroneManager instance = DroneManager.Instance;
		count2 = instance.LootableDronesList.Count;
		for (int l = 0; l < count2; l++)
		{
			Drone drone = instance.LootableDronesList[l];
			if (!drone.IsVisible && drone.CurrentRoom == this)
			{
				if (!drone.WasScanned)
				{
					flag = true;
				}
				drone.Scanned();
			}
		}
		count2 = DungeonManager.Instance.ShipUpgrades.Count;
		for (int m = 0; m < count2; m++)
		{
			ShipUpgradeInGameObject shipUpgradeInGameObject = DungeonManager.Instance.ShipUpgrades[m];
			if (GetComponent<Collider>().bounds.Intersects(shipUpgradeInGameObject.GetComponent<Collider>().bounds))
			{
				if (!shipUpgradeInGameObject.WasScanned)
				{
					flag = true;
				}
				shipUpgradeInGameObject.Scanned();
			}
		}
		RefreshCameraView();
		if (flag)
		{
			result = "New items found";
		}
		if (GlobalSettings.GameStartedFromGalaxyMap && ObjectiveManual.IsObjectiveStepActive("greygoo", "stepB") && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Key.name.ToLower() == "space station" && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value != null && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value != null && (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value.name.ToLower() == "a" || GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.Definition.Value.name.ToLower() == "b"))
		{
			bool flag2 = true;
			Room[] rooms = DungeonManager.Instance.rooms;
			foreach (Room room in rooms)
			{
				if (!room.boardingVessel && !room.isScanned)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				LogManager.LogDataFile.SaveValue("greygoo", "stepB", 3);
				SystemMessageManager.ShowSystemMessage("///[JIL]: Holzhauer scan executing, archiving results", ConsoleMessageType.JIL_Good);
			}
		}
		return true;
	}

	public void ExternallyMarkAsExplored()
	{
		if (!isExplored)
		{
			isExplored = true;
			if (!boardingVessel && !onSchematic)
			{
				isScanning = true;
				_blinkManager.Start((!isPowered) ? SchematicViewScannedOffMtl.color : SchematicViewScannedOnMtl.color, Color.black, 0.2f, 3);
				MarkAsDiscovered();
			}
		}
		onSchematic = true;
		if (corridors != null)
		{
			int count = corridors.Count;
			for (int i = 0; i < count; i++)
			{
				corridors[i].onSchematic = true;
			}
		}
		RefreshCameraView();
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			return;
		}
		DungeonManager.Instance.UpdateCameraView();
		MonoBehaviour[] array = UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)) as MonoBehaviour[];
		int num = array.Length;
		for (int j = 0; j < num; j++)
		{
			MonoBehaviour monoBehaviour = array[j];
			if (monoBehaviour is IUpdateCameraView)
			{
				((IUpdateCameraView)monoBehaviour).UpdateCameraView();
			}
		}
		num = DroneManager.Instance.LootableDronesList.Count;
		for (int k = 0; k < num; k++)
		{
			Drone drone = DroneManager.Instance.LootableDronesList[k];
			if (drone.CurrentRoom == this && !drone.IsVisible)
			{
				Drone drone2 = drone;
				DroneManager.Instance.ShowDrone(ref drone2);
			}
		}
	}

	public void ExternallyMarkAsOnSchematic()
	{
		onSchematic = true;
		if (corridors != null)
		{
			int count = corridors.Count;
			for (int i = 0; i < count; i++)
			{
				corridors[i].onSchematic = true;
			}
		}
		if (Label == "R?")
		{
			AssignRoomLabel();
		}
		RefreshCameraView();
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			DungeonManager.Instance.UpdateCameraView();
		}
	}

	public void HideRadiationOverlay()
	{
		labelBorder.enabled = false;
		overlayObject.gameObject.SetActive(false);
	}

	public void RevealRadiationOverlay()
	{
		if (RadiationLikely)
		{
			overlayObject.gameObject.SetActive(true);
			overlayWarning1Object.color = new Color(0.5137255f, 25f / 51f, 0.007843138f);
			overlayWarning2Object.color = new Color(0.5137255f, 25f / 51f, 0.007843138f);
			ShowingRadiationOverlay = true;
		}
		else if (RadiationPossible)
		{
			overlayObject.gameObject.SetActive(true);
			overlayWarning1Object.color = new Color(41f / 85f, 0.20784314f, 7f / 85f);
			overlayWarning2Object.color = new Color(41f / 85f, 0.20784314f, 7f / 85f);
			ShowingRadiationOverlay = true;
		}
		else
		{
			labelBorder.enabled = false;
			ShowingRadiationOverlay = false;
		}
	}

	public List<Room> getAdjacentRooms()
	{
		List<Room> list = new List<Room>();
		foreach (Corridor corridor in corridors)
		{
			Room[] rooms = corridor.rooms;
			foreach (Room room in rooms)
			{
				if (room != this && !list.Contains(room))
				{
					list.Add(room);
				}
			}
		}
		return list;
	}

	public bool DoesRoomItemExist(Type roomItemType)
	{
		if (roomItems.Count > 0)
		{
			foreach (RoomItem roomItem in roomItems)
			{
				if (roomItem != null && roomItem.GetType() == roomItemType)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool RoomItemBoundsIntersect(RoomItem roomItem, Bounds testObjectBounds)
	{
		Bounds bounds = roomItem.itemCollider.bounds;
		if (roomItem is FuelAccess || roomItem is DungeonTerminal)
		{
			bounds.Expand(2f);
		}
		return bounds.Intersects(testObjectBounds);
	}

	public bool RoomItemBoundsContainsObject(RoomItem roomItem, Bounds testObjectBounds)
	{
		Bounds bounds = roomItem.itemCollider.bounds;
		if (roomItem is FuelAccess || roomItem is DungeonTerminal)
		{
			bounds.Expand(2f);
		}
		return bounds.Contains(testObjectBounds.center);
	}

	public bool RoomItemsBoundsHit(Bounds bounds, List<RoomItem> itemsIntersecting, List<RoomItem> itemsContainedIn)
	{
		bool flag = false;
		if (itemsIntersecting != null)
		{
			itemsIntersecting.Clear();
		}
		if (itemsContainedIn != null)
		{
			itemsContainedIn.Clear();
		}
		int count = roomItems.Count;
		for (int i = 0; i < count; i++)
		{
			RoomItem roomItem = roomItems[i];
			if (!(roomItem != null) || !(roomItem.itemCollider != null))
			{
				continue;
			}
			if (RoomItemBoundsContainsObject(roomItem, bounds))
			{
				flag = true;
				if (itemsContainedIn != null)
				{
					itemsContainedIn.Add(roomItem);
				}
				if (itemsIntersecting != null)
				{
					itemsIntersecting.Add(roomItem);
				}
			}
			else if (RoomItemBoundsIntersect(roomItem, bounds))
			{
				flag = true;
				if (itemsIntersecting != null)
				{
					itemsIntersecting.Add(roomItem);
				}
			}
		}
		if (!flag && environmentModelsLarge != null)
		{
			count = environmentModelsLarge.Count;
			for (int j = 0; j < count; j++)
			{
				GameObject gameObject = environmentModelsLarge[j];
				Bounds bounds2 = gameObject.GetComponent<Collider>().bounds;
				bounds2.Expand(2f);
				if (bounds2.Contains(bounds.center))
				{
					flag = true;
				}
				else if (bounds2.Intersects(bounds))
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	public List<RoomItem> GetBoundsHitRoomItems(Bounds bounds, Type classType)
	{
		List<RoomItem> list = new List<RoomItem>();
		if (roomItems.Count > 0)
		{
			foreach (RoomItem roomItem in roomItems)
			{
				if (roomItem != null && roomItem.itemCollider != null && roomItem.GetType() == classType)
				{
					bool flag = false;
					if (roomItem.itemCollider.bounds.Contains(bounds.center))
					{
						flag = true;
					}
					else if (roomItem.itemCollider.bounds.Intersects(bounds))
					{
						flag = true;
					}
					if (flag)
					{
						list.Add(roomItem);
					}
				}
			}
		}
		return list;
	}

	public bool PickSafeLocationForDrone(Drone drone, out Vector3 safePos)
	{
		Vector3 safeTowPos = Vector3.zero;
		return PickSafeLocationForDrone(drone, out safePos, out safeTowPos);
	}

	public bool PickSafeLocationForDrone(Drone drone, out Vector3 safePos, out Vector3 safeTowPos)
	{
		safePos = Vector3.zero;
		safeTowPos = Vector3.zero;
		bool flag = false;
		Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(this);
		if (drone.ItemBeingTowed != null)
		{
			if (drone.ItemBeingTowed is Drone)
			{
				Drone drone2 = (Drone)drone.ItemBeingTowed;
				safeTowPos = drone2.transform.position - drone.transform.position;
			}
			else if (drone.ItemBeingTowed is ShipUpgradeInGameObject)
			{
				ShipUpgradeInGameObject shipUpgradeInGameObject = (ShipUpgradeInGameObject)drone.ItemBeingTowed;
				safeTowPos = shipUpgradeInGameObject.transform.position - drone.transform.position;
			}
			flag = true;
		}
		safePos = mainRoomWaypoint.transform.position;
		Bounds bounds = new Bounds(safePos, drone.GetComponent<Collider>().bounds.size);
		Bounds bounds2 = new Bounds(safePos + safeTowPos, drone.GetComponent<Collider>().bounds.size);
		bool flag2 = false;
		bool flag3 = false;
		if (this is BoardingShip && base.transform.rotation.w >= 0.6f && base.transform.rotation.w <= 0.8f)
		{
			flag3 = true;
		}
		int num = 0;
		do
		{
			flag2 = false;
			int count = DroneManager.Instance.dronesList.Count;
			for (int i = 0; i < count; i++)
			{
				Drone drone3 = DroneManager.Instance.dronesList[i];
				if (drone3 != drone && drone3.CurrentRoom == this && drone3.GetComponent<Collider>().bounds.Intersects(bounds))
				{
					flag2 = true;
				}
				if (!flag2 && flag && drone3.GetComponent<Collider>().bounds.Intersects(bounds2))
				{
					flag2 = true;
				}
			}
			count = DroneManager.Instance.LootableDronesList.Count;
			for (int j = 0; j < count; j++)
			{
				Drone drone4 = DroneManager.Instance.LootableDronesList[j];
				if (drone4 != drone && drone4.CurrentRoom == this && drone4.GetComponent<Collider>().bounds.Intersects(bounds))
				{
					flag2 = true;
				}
				if (!flag2 && flag && drone4.GetComponent<Collider>().bounds.Intersects(bounds2))
				{
					flag2 = true;
				}
			}
			if (!flag2)
			{
				if (RoomItemsBoundsHit(bounds, null, null))
				{
					flag2 = true;
				}
				if (!flag2 && flag && RoomItemsBoundsHit(bounds2, null, null))
				{
					flag2 = true;
				}
			}
			if (!flag2 && EnemyManager.Instance != null && EnemyManager.Instance.Enemies != null)
			{
				count = knownEnemiesList.Count;
				for (int k = 0; k < count; k++)
				{
					BaseEnemy baseEnemy = knownEnemiesList[k];
					if (baseEnemy.GetComponent<Collider>().bounds.Intersects(bounds))
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				num++;
				Vector3 center = bounds.center;
				float num2 = 1.25f;
				switch (num)
				{
				case 1:
					center.x = base.transform.position.x - base.transform.localScale.x / 2f + num2;
					center.y = base.transform.position.y - base.transform.localScale.y / 2f + num2;
					if (flag3)
					{
						center.x = base.transform.position.x - base.transform.localScale.y / 2f + num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				case 2:
					center.x = base.transform.position.x + base.transform.localScale.x / 2f - num2;
					center.y = base.transform.position.y - base.transform.localScale.y / 2f + num2;
					if (flag3)
					{
						center.x = base.transform.position.x - base.transform.localScale.y / 2f + num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				case 3:
					center.x = base.transform.position.x + base.transform.localScale.x / 2f - num2;
					center.y = base.transform.position.y + base.transform.localScale.y / 2f - num2;
					if (flag3)
					{
						center.x = base.transform.position.x + base.transform.localScale.y / 2f - num2;
						center.y = base.transform.position.y - base.transform.localScale.x / 2f + num2;
					}
					break;
				case 4:
					center.x = base.transform.position.x - base.transform.localScale.x / 2f + num2;
					center.y = base.transform.position.y + base.transform.localScale.y / 2f - num2;
					if (flag3)
					{
						center.x = base.transform.position.x + base.transform.localScale.y / 2f - num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				default:
					center.x = UnityEngine.Random.Range(base.transform.position.x - base.transform.localScale.x / 2f + 0.5f, base.transform.position.x + base.transform.localScale.x / 2f - 0.5f);
					center.y = UnityEngine.Random.Range(base.transform.position.y - base.transform.localScale.y / 2f + 0.5f, base.transform.position.y + base.transform.localScale.y / 2f - 0.5f);
					if (flag3)
					{
						center.x = UnityEngine.Random.Range(base.transform.position.x - base.transform.localScale.y / 2f + 0.5f, base.transform.position.x + base.transform.localScale.y / 2f - 0.5f);
						center.y = UnityEngine.Random.Range(base.transform.position.y - base.transform.localScale.x / 2f + 0.5f, base.transform.position.y + base.transform.localScale.x / 2f - 0.5f);
					}
					break;
				}
				bounds.center = center;
				bounds2.center = center + safeTowPos;
			}
			else
			{
				safePos = bounds.center;
			}
		}
		while (flag2 && num < 100);
		return !flag2;
	}

	public bool PickSafeLocationForBounds(Bounds destBounds, out Vector3 safePos)
	{
		safePos = Vector3.zero;
		bool flag = false;
		bool flag2 = false;
		if (this is BoardingShip && base.transform.rotation.w >= 0.6f && base.transform.rotation.w <= 0.8f)
		{
			flag2 = true;
		}
		int num = 0;
		do
		{
			flag = false;
			foreach (Drone drones in DroneManager.Instance.dronesList)
			{
				if (drones.CurrentRoom == this && drones.GetComponent<Collider>().bounds.Intersects(destBounds))
				{
					flag = true;
				}
			}
			foreach (Drone lootableDrones in DroneManager.Instance.LootableDronesList)
			{
				if (lootableDrones.CurrentRoom == this && lootableDrones.GetComponent<Collider>().bounds.Intersects(destBounds))
				{
					flag = true;
				}
			}
			if (!flag && RoomItemsBoundsHit(destBounds, null, null))
			{
				flag = true;
			}
			if (!flag && EnemyManager.Instance != null && EnemyManager.Instance.Enemies != null)
			{
				foreach (BaseEnemy enemy in EnemyManager.Instance.Enemies)
				{
					if (enemy.CurrentRoom == this && enemy.GetComponent<Collider>().bounds.Intersects(destBounds))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				num++;
				Vector3 center = destBounds.center;
				float num2 = 1.25f;
				switch (num)
				{
				case 1:
					center.x = base.transform.position.x - base.transform.localScale.x / 2f + num2;
					center.y = base.transform.position.y - base.transform.localScale.y / 2f + num2;
					if (flag2)
					{
						center.x = base.transform.position.x - base.transform.localScale.y / 2f + num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				case 2:
					center.x = base.transform.position.x + base.transform.localScale.x / 2f - num2;
					center.y = base.transform.position.y - base.transform.localScale.y / 2f + num2;
					if (flag2)
					{
						center.x = base.transform.position.x - base.transform.localScale.y / 2f + num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				case 3:
					center.x = base.transform.position.x + base.transform.localScale.x / 2f - num2;
					center.y = base.transform.position.y + base.transform.localScale.y / 2f - num2;
					if (flag2)
					{
						center.x = base.transform.position.x + base.transform.localScale.y / 2f - num2;
						center.y = base.transform.position.y - base.transform.localScale.x / 2f + num2;
					}
					break;
				case 4:
					center.x = base.transform.position.x - base.transform.localScale.x / 2f + num2;
					center.y = base.transform.position.y + base.transform.localScale.y / 2f - num2;
					if (flag2)
					{
						center.x = base.transform.position.x + base.transform.localScale.y / 2f - num2;
						center.y = base.transform.position.y + base.transform.localScale.x / 2f - num2;
					}
					break;
				default:
					center.x = UnityEngine.Random.Range(base.transform.position.x - base.transform.localScale.x / 2f + 0.5f, base.transform.position.x + base.transform.localScale.x / 2f - 0.5f);
					center.y = UnityEngine.Random.Range(base.transform.position.y - base.transform.localScale.y / 2f + 0.5f, base.transform.position.y + base.transform.localScale.y / 2f - 0.5f);
					if (flag2)
					{
						center.x = UnityEngine.Random.Range(base.transform.position.x - base.transform.localScale.y / 2f + 0.5f, base.transform.position.x + base.transform.localScale.y / 2f - 0.5f);
						center.y = UnityEngine.Random.Range(base.transform.position.y - base.transform.localScale.x / 2f + 0.5f, base.transform.position.y + base.transform.localScale.x / 2f - 0.5f);
					}
					break;
				}
				destBounds.center = center;
			}
			else
			{
				safePos = destBounds.center;
			}
		}
		while (flag && num < 100);
		return !flag;
	}

	public void ExplosionInRoom(float damage)
	{
		ExplosionInRoom(damage, DamageType.Physical);
	}

	public void ExplosionInRoom(float damage, DamageType type)
	{
		ExplosionInRoom(damage, type, Vector3.zero);
	}

	public void ExplosionInRoom(float damage, DamageType type, Vector3 attackerPos)
	{
		if (roomItems.Count <= 0)
		{
			return;
		}
		UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		foreach (RoomItem roomItem in roomItems)
		{
			if (!(roomItem != null) || !(roomItem is ICombatTarget))
			{
				continue;
			}
			ICombatTarget combatTarget = (ICombatTarget)roomItem;
			if (!combatTarget.IsDead)
			{
				float damage2 = damage;
				if (type == DamageType.Splash)
				{
					damage2 = CommonMethods.SplashDamage(damage, attackerPos, combatTarget.Position);
				}
				float num = UnityEngine.Random.Range(1f, 100f);
				if (num <= 50f)
				{
					combatTarget.TakeDamage(damage2, DamageType.Physical, null);
				}
			}
		}
	}

	public void DamageItemsInArea(Bounds bounds, float damage)
	{
		if (roomItems.Count <= 0)
		{
			return;
		}
		foreach (RoomItem roomItem in roomItems)
		{
			if (roomItem is ICombatTarget)
			{
				ICombatTarget combatTarget = (ICombatTarget)roomItem;
				if (!combatTarget.IsDead && roomItem.itemCollider != null && bounds.Intersects(roomItem.itemCollider.bounds) && UnityEngine.Random.Range(1, 101) < 50)
				{
					combatTarget.TakeDamage(damage, DamageType.Physical, null);
				}
			}
		}
	}

	public void StunInRoom(float durationMin, float durationMax)
	{
		if (roomItems.Count <= 0)
		{
			return;
		}
		UnityEngine.Random.seed = (int)DateTime.Now.Ticks;
		foreach (RoomItem roomItem in roomItems)
		{
			if (!(roomItem != null) || !(roomItem is ICombatTarget))
			{
				continue;
			}
			ICombatTarget combatTarget = (ICombatTarget)roomItem;
			if (!combatTarget.IsDead && !combatTarget.IsStunned)
			{
				float num = UnityEngine.Random.Range(1f, 100f);
				if (num <= 75f)
				{
					combatTarget.Stun(durationMin, durationMax);
				}
			}
		}
	}

	public void Radiate(string reason)
	{
		Radiate(reason, 1f);
	}

	public void Radiate(string reason, float radiationSourceFactor)
	{
		if (!IsFillingWithRadiation && !IsRadiated && !IsInPreNaturalRadiationState)
		{
			destructionTimer = 0f;
			destructionComtaminationTimer = 0f;
			this.radiationSourceFactor = radiationSourceFactor;
			SystemMessageManager.ShowSystemMessage(string.Format("Radiation flooding room: {0}, {1}", Label, reason), ConsoleMessageType.DisasterWarning);
			IsFillingWithRadiation = true;
			StartBlinkRadiate();
		}
	}

	public void NaturalRadiateEvent()
	{
		if (!IsFillingWithRadiation && !IsRadiated && !IsInPreNaturalRadiationState)
		{
			IsInPreNaturalRadiationState = true;
			isPendingMothershipCreak = true;
			preNaturalRadiationTimer = UnityEngine.Random.Range(15f, 30f);
			mothershipCreakTimer = 4f;
			if (UnityEngine.Random.Range(0, 100) < 10)
			{
				willNaturalRadiationFail = true;
			}
			if (GlobalSettings.cameraMode == CameraMode.Drone)
			{
				DroneManager.Instance.PlayDroneShipCreak();
			}
		}
	}

	public void DestroyByImpact(string reason, int chanceDoorBreak, int chanceBrokenDoorOpens, int chanceOfOnlyRadiation)
	{
		if (UnityEngine.Random.Range(0, 100) < chanceOfOnlyRadiation)
		{
			Radiate(reason);
			return;
		}
		RandomlyBreakRoomDoor(chanceDoorBreak, chanceBrokenDoorOpens);
		IsPunctured = true;
		DepressurizeRoom(true);
	}

	private void RandomlyBreakRoomDoor(int chanceDoorBreak, int chanceBrokenDoorOpens)
	{
		int count = corridors.Count;
		for (int i = 0; i < count; i++)
		{
			Corridor corridor = corridors[i];
			if (!corridor.isWelded && !corridor.door.IsDead && UnityEngine.Random.Range(0, 100) < chanceDoorBreak)
			{
				if (UnityEngine.Random.Range(0, 100) < chanceBrokenDoorOpens)
				{
					corridor.door.TakeDamage(1000f, DamageType.Physical, null);
				}
				else
				{
					corridor.door.TakeDamage(1000f, DamageType.Impact, null);
				}
				corridor.UpdateCameraView(true);
				corridor.droneUIObject.UpdateCameraView();
			}
		}
	}

	public void BeginDecontaminate()
	{
		timerDecontaminateEvents = 1f;
		IsPendingDecontaminate = true;
	}

	private void Decontaminate()
	{
		StartBlinkRadiate();
		IsDecontaminating = true;
		timerDecontaminateEvents = 5f;
		IsFillingWithRadiation = false;
		IsRadiated = false;
		SystemMessageManager.ShowSystemMessage(string.Format("Begining decontamination of room: {0}", Label), ConsoleMessageType.Info);
	}

	private void StartBlinkRadiate()
	{
		_blinkManagerRadiationLayer.Start(IrradiatedColorOn, IrradiatedColorOff, 0.2f, false);
		SetSchematicViewMaterial();
	}

	public Corridor GetConnectingCooridor(Room otherRoom)
	{
		foreach (Corridor corridor in corridors)
		{
			if (corridor.containsRoom(otherRoom))
			{
				return corridor;
			}
		}
		return null;
	}

	public List<T> GetRoomItems<T>(Type type, bool includeUnknown) where T : RoomItem
	{
		List<T> list = new List<T>();
		int count = roomItems.Count;
		for (int i = 0; i < count; i++)
		{
			RoomItem roomItem = roomItems[i];
			if (roomItem.GetType() == typeof(T) && (includeUnknown || roomItem.HasBeenSeen()))
			{
				list.Add((T)roomItem);
			}
		}
		return list;
	}

	public RoomItem GetRoomItem(Type type, bool includeUnknown)
	{
		int count = roomItems.Count;
		for (int i = 0; i < count; i++)
		{
			RoomItem roomItem = roomItems[i];
			UnityEngine.Object component = roomItem.GetComponent(type);
			if (component != null)
			{
				RoomItem roomItem2 = (RoomItem)component;
				if (includeUnknown || roomItem2.HasBeenSeen())
				{
					return (RoomItem)component;
				}
			}
		}
		return null;
	}

	public List<RoomItem> GetDamagableRoomItems(bool onlyExplored)
	{
		List<RoomItem> list = null;
		foreach (RoomItem roomItem in roomItems)
		{
			if (roomItem is IDamagableObject && !roomItem.IsDead && (!onlyExplored || roomItem.Explored))
			{
				if (list == null)
				{
					list = new List<RoomItem>();
				}
				list.Add(roomItem);
			}
		}
		return list;
	}

	public override string ToString()
	{
		return string.Format("{0} - {1}", base.name, Label);
	}

	public virtual void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (isScanning && _blinkManager.IsActive)
			{
				_blinkManager.Stop();
				isScanning = false;
			}
			if (isExplored || this is BoardingShip)
			{
				if (roomTileObjects == null)
				{
					base.gameObject.GetComponent<Renderer>().enabled = true;
				}
			}
			else
			{
				base.gameObject.GetComponent<Renderer>().enabled = false;
			}
			notVisitedOutline.HideLines();
			visitedOutline.HideLines();
			transporterOutline.HideLines();
			SVRoomStatusLayer.GetComponent<Renderer>().enabled = false;
			SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = false;
			SVEnvRadiationStatusLayer.GetComponent<Renderer>().enabled = false;
			if (!boardingVessel && outlineLineListVisible != null)
			{
				int count = outlineLineListVisible.Count;
				for (int i = 0; i < count; i++)
				{
					GameObject gameObject = outlineLineListVisible[i];
					Transform transform = gameObject.transform.FindChild("SVEdgeLine");
					transform.GetComponent<Renderer>().enabled = false;
					transform = gameObject.transform.FindChild("DVEdgeLine");
					transform.GetComponent<Renderer>().enabled = true;
				}
			}
			if (droneUIObjectList != null)
			{
			}
			HideRadiationOverlay();
			if (IsVisible)
			{
				ShowRegisteredEnimies();
				if (isPowered && asRAmbientEquipment != null)
				{
					asRAmbientEquipment.Play();
				}
			}
		}
		else
		{
			notVisitedOutline.ShowLines();
			visitedOutline.ShowLines();
			if (isRoomStatusPlaneActive)
			{
				SVRoomStatusLayer.GetComponent<Renderer>().enabled = true;
			}
			if (isEnvPressureStatusPlaneActive)
			{
				SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = true;
			}
			if (isEnvRadiationStatusPlaneActive)
			{
				SVEnvRadiationStatusLayer.GetComponent<Renderer>().enabled = true;
			}
			if (hasBeenDiscovered && !hasBlinkedOnSchematic && !boardingVessel)
			{
				BlinkOnSchematic();
			}
			UpdateTransporterReceiver(currentTransporterState);
			if (!boardingVessel && outlineLineListVisible != null)
			{
				int count2 = outlineLineListVisible.Count;
				for (int j = 0; j < count2; j++)
				{
					GameObject gameObject2 = outlineLineListVisible[j];
					Transform transform2 = gameObject2.transform.FindChild("SVEdgeLine");
					transform2.GetComponent<Renderer>().enabled = true;
					transform2 = gameObject2.transform.FindChild("DVEdgeLine");
					transform2.GetComponent<Renderer>().enabled = false;
				}
			}
			if (droneUIObjectList != null)
			{
			}
			if (ShowingRadiationOverlay)
			{
				RevealRadiationOverlay();
			}
			if (asRAmbientEquipment != null)
			{
				asRAmbientEquipment.Pause();
			}
			if (!GlobalSettings.cheatMode)
			{
				HideRegisteredEnimies();
			}
		}
		int count3 = roomItems.Count;
		for (int k = 0; k < count3; k++)
		{
			RoomItem roomItem = roomItems[k];
			if (roomItem != null)
			{
				roomItem.UpdateCameraView();
			}
		}
	}

	public void UpdateTransporterReceiver(TransporterShipUpgrade.ReceiverStrengthEnum strength)
	{
		foreach (RoomItem roomItem in roomItems)
		{
			if (roomItem.GetType() != typeof(TransporterReceiver))
			{
				continue;
			}
			if (!((TransporterReceiver)roomItem).IsOffline)
			{
				transporterOutline.ShowLines();
				switch (strength)
				{
				case TransporterShipUpgrade.ReceiverStrengthEnum.None:
					transporterOutline.SetColor(TransporterOutlineColorOffline);
					break;
				case TransporterShipUpgrade.ReceiverStrengthEnum.Weak:
					transporterOutline.SetColor(TransporterOutlineColorWeak);
					break;
				case TransporterShipUpgrade.ReceiverStrengthEnum.Strong:
					transporterOutline.SetColor(TransporterOutlineColorStrong);
					break;
				}
			}
			currentTransporterState = strength;
			break;
		}
	}

	private void AssignRoomLabel()
	{
		DungeonManager.Instance.LastRevealedRoomNumber++;
		labelTextObject.text = "r" + DungeonManager.Instance.LastRevealedRoomNumber;
		Label = labelTextObject.text;
		LabelSimple = "r" + DungeonManager.Instance.LastRevealedRoomNumber;
		labelTextObject.enabled = false;
		Waypoint mainRoomWaypoint = NavigationHelper.GetMainRoomWaypoint(this);
		if (mainRoomWaypoint != null)
		{
			mainRoomWaypoint.name = "Waypoint Room: " + Label;
		}
		else
		{
			Debug.LogError("Don't know why the Waypoint is null.  Sometimes happens when in _Pro");
		}
	}

	public void AirlockOpened(Door door)
	{
		if (door.corridor.getOtherRoom(this) == null)
		{
			if (GlobalSettings.cameraMode == CameraMode.Drone && this != BoardingShip.Instance.CurrentAirlock)
			{
				door.corridor.vacuumSound.volume = GameAudio.RemoteVolume * 1f;
				door.corridor.vacuumSound.Play();
			}
			if (!IsDepressurized && !IsPendingDepressure)
			{
				DepressurizeRoom(false);
			}
			else if (IsDepressurized)
			{
				DepressurizeAdjacentRooms(new List<Room> { this }, false);
			}
		}
		else
		{
			DoorOpened(door);
		}
	}

	private void AirlockClosed(Door door)
	{
		if (door.corridor.getOtherRoom(this) == null)
		{
			door.corridor.vacuumSound.Stop();
			foreach (Corridor corridor in corridors)
			{
				if (corridor.door != door && corridor.IsAirlock && corridor.door.state == DoorState.Open)
				{
					return;
				}
			}
			List<Room> testedRooms = new List<Room>();
			Corridor airlock = null;
			if (!OpenAirlockFound(ref testedRooms, out airlock))
			{
				PotentiallyNoLongerExposedToOutside();
			}
			HintManager.HintCompleted(typeof(CloseAirlockHint));
		}
		else
		{
			DoorClosed(door);
		}
		foreach (Drone drones in DroneManager.Instance.dronesList)
		{
			if (drones.CurrentRoom == this && drones.isBeingPulledOut && drones.airlockSuckingOut == openAirlock)
			{
				drones.CancelSuckOutOfRoom();
			}
		}
		_openAirlock = null;
	}

	private void DoorOpened(Door door)
	{
		if (!IsDepressurized && !IsPendingDepressure)
		{
			Room otherRoom = door.corridor.getOtherRoom(this);
			if (otherRoom != null && otherRoom.IsDepressurized)
			{
				PotentiallyExposedToOutside(new List<Room> { this }, false);
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && GlobalSettings.PerformanceFarView <= 1 && DroneManager.Instance.CurrentDrone.CurrentRoom == this)
		{
			Room otherRoom2 = door.corridor.getOtherRoom(this);
			if (otherRoom2 != null && (GlobalSettings.PerformanceFarView != 0 || Vector3.Distance(DroneManager.Instance.CurrentDrone.transform.position, otherRoom2.transform.position) < 10f))
			{
				otherRoom2.fadeIn();
			}
		}
	}

	private void DoorClosed(Door door)
	{
		if (IsDepressurized || IsPendingDepressure)
		{
			PotentiallyNoLongerExposedToOutside();
		}
		else if (this == DungeonManager.Instance.BoardingVessel && (IsFillingWithRadiation || IsRadiated))
		{
			timerExposureEvents = UnityEngine.Random.Range(2f, 5f);
			isPendingRadiationVenting = true;
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && GlobalSettings.PerformanceFarView <= 1 && DroneManager.Instance.CurrentDrone.CurrentRoom == this)
		{
			Room otherRoom = door.corridor.getOtherRoom(this);
			if (otherRoom != null)
			{
				otherRoom.FadeOut();
			}
		}
	}

	public bool PotentiallyExposedToOutside(List<Room> testedRoomList, bool onlyTest)
	{
		if (!IsPendingDepressure && !IsDepressurized)
		{
			if (!onlyTest)
			{
				IsPendingDepressure = true;
				IsPendingPressurize = false;
				timerExposureEvents = 5f;
			}
			return true;
		}
		if (IsDepressurized)
		{
			testedRoomList.Add(this);
			return DepressurizeAdjacentRooms(testedRoomList, onlyTest);
		}
		if (IsPendingDepressure)
		{
			return true;
		}
		return false;
	}

	public void PotentiallyNoLongerExposedToOutside()
	{
		PotentiallyNoLongerExposedToOutside(false);
	}

	public void PotentiallyNoLongerExposedToOutside(bool dontTestChildren)
	{
		if (!IsPendingDepressure && !IsDepressurized)
		{
			return;
		}
		List<Room> testedRooms = new List<Room>();
		Corridor airlock = null;
		if (OpenAirlockFound(ref testedRooms, out airlock))
		{
			return;
		}
		if (openAirlock != null)
		{
			foreach (Drone drones in DroneManager.Instance.dronesList)
			{
				if (drones.CurrentRoom == this && drones.isBeingPulledOut && drones.airlockSuckingOut == openAirlock)
				{
					drones.CancelSuckOutOfRoom();
				}
			}
			if (!dontTestChildren)
			{
				Room[] rooms = DungeonManager.Instance.rooms;
				foreach (Room room in rooms)
				{
					if (room != this)
					{
						room.PotentiallyNoLongerExposedToOutside(true);
					}
				}
			}
			openAirlock = null;
		}
		if (IsPendingDepressure)
		{
			IsPendingDepressure = false;
			timerExposureEvents = 0f;
			return;
		}
		IsPendingPressurize = true;
		timerExposureEvents = 5f;
		_blinkManagerPressureLayer.Start(DecompressedColorOn, DecompressedColorOff, 0.2f, false);
		isInInitialExposure = true;
		timerExposureEvents = 2f;
	}

	private bool OpenAirlockFound(ref List<Room> testedRooms, out Corridor airlock)
	{
		airlock = null;
		if (IsPunctured)
		{
			airlock = null;
			return true;
		}
		foreach (Corridor corridor in corridors)
		{
			if (corridor.IsAirlock && corridor.door.state == DoorState.Open && corridor.getOtherRoom(this) == null)
			{
				airlock = corridor;
				return true;
			}
		}
		testedRooms.Add(this);
		foreach (Corridor corridor2 in corridors)
		{
			if (corridor2.door.state == DoorState.Open)
			{
				Room otherRoom = corridor2.getOtherRoom(this);
				if (otherRoom != null && !testedRooms.Contains(otherRoom) && otherRoom.OpenAirlockFound(ref testedRooms, out airlock))
				{
					return true;
				}
			}
		}
		return false;
	}

	private void DepressurizeRoom(bool dontBreakDoors)
	{
		List<Room> testedRooms = new List<Room>();
		if (OpenAirlockFound(ref testedRooms, out _openAirlock))
		{
			IsDepressurized = true;
			SystemMessageManager.ShowSystemMessage(string.Format("Room {0} has been exposed to the outside", Label), ConsoleMessageType.Warning);
			SetSchematicViewMaterial();
			_blinkManagerPressureLayer.Start(DecompressedColorOn, DecompressedColorOff, 0.2f, false);
			isInInitialExposure = true;
			timerExposureEvents = 2f;
			bool flag = false;
			foreach (RoomItem roomItem in roomItems)
			{
				if (roomItem is LootItem)
				{
					if (roomItem.IsInSpace)
					{
						continue;
					}
					if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
					{
						bool flag2 = CollectorPermUpgrade.Instance.CollectScrap((LootItem)roomItem);
						if (!flag)
						{
							flag = flag2;
						}
					}
					roomItem.Vaporize();
				}
				else if (roomItem is ICombatTarget && UnityEngine.Random.Range(0, 3) == 0)
				{
					((ICombatTarget)roomItem).TakeDamage(UnityEngine.Random.Range(100f, 101f), DamageType.Physical, null);
				}
			}
			DroneManager instance = DroneManager.Instance;
			IEnumerable<Drone> enumerable = instance.LootableDronesList.Where((Drone x) => x != null && x.CurrentRoom == this);
			foreach (Drone item in enumerable)
			{
				bool flag3 = true;
				if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
				{
					flag3 = CollectorPermUpgrade.Instance.CollectLootableDrone(item);
					if (!flag)
					{
						flag = flag3;
					}
				}
				item.Vaporize(flag3);
			}
			if (flag)
			{
				GameAudio.Play2DSFX(GameAudio.SoundEnum.ShipCollector);
			}
			VaporizeEnemiesInRoom();
			VaporizeProbesInRoom();
			VaporizeDroppableItems();
			foreach (Corridor corridor2 in corridors)
			{
				foreach (Drone drones in DroneManager.Instance.dronesList)
				{
					if (drones.CurrentCorridor == corridor2)
					{
						drones.CurrentCorridor = null;
						drones.CurrentRoom = this;
					}
				}
			}
			if (UnityEngine.Random.Range(0, 100) < 20)
			{
				int count = corridors.Count;
				if (count > 0)
				{
					bool flag4 = false;
					int num = 0;
					int num2 = count * 5;
					do
					{
						int index = UnityEngine.Random.Range(0, count);
						Corridor corridor = corridors[index];
						if (!corridor.isWelded && corridor.door.state == DoorState.Closed && !corridor.door.IsDead)
						{
							corridor.door.TakeDamage(1000f, DamageType.Impact, null);
							corridor.UpdateCameraView(true);
							corridor.droneUIObject.UpdateCameraView();
							flag4 = true;
						}
						num++;
					}
					while (!flag4 && num < num2);
				}
			}
			VaporizePlayerDrones(openAirlock);
			bool flag5 = DepressurizeAdjacentRooms(new List<Room> { this }, false);
		}
		else
		{
			openAirlock = null;
		}
	}

	private void VaporizePlayerDrones(Corridor airlock)
	{
		DroneManager instance = DroneManager.Instance;
		IEnumerable<Drone> enumerable = instance.dronesList.Where((Drone x) => x != null && x.CurrentRoom == this);
		foreach (Drone item in enumerable)
		{
			Vector3 destinationPoint = Vector3.zero;
			if (airlock != null && airlock.containsRoom(this))
			{
				destinationPoint = airlock.transform.position;
			}
			else if (IsPunctured)
			{
				bool preserve = true;
				if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
				{
					preserve = CollectorPermUpgrade.Instance.CollectLootableDrone(item);
				}
				item.Vaporize(preserve);
			}
			else
			{
				int num = 0;
				Corridor corridor = null;
				foreach (Corridor corridor2 in corridors)
				{
					if (corridor2.door.state == DoorState.Open)
					{
						corridor = corridor2;
						num++;
					}
				}
				if (num == 1)
				{
					Room otherRoom = corridor.getOtherRoom(this);
					if (otherRoom != null && otherRoom.IsPunctured)
					{
						bool preserve2 = true;
						if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
						{
							preserve2 = CollectorPermUpgrade.Instance.CollectLootableDrone(item);
						}
						item.Vaporize(preserve2);
						break;
					}
					destinationPoint = corridor.transform.position;
					if (corridor.transform.rotation.w == 1f)
					{
						if (base.transform.position.x < corridor.getOtherRoom(this).transform.position.x)
						{
							destinationPoint.x += 1f;
						}
						else
						{
							destinationPoint.x -= 1f;
						}
					}
					else if (base.transform.position.y < corridor.getOtherRoom(this).transform.position.y)
					{
						destinationPoint.y += 1f;
					}
					else
					{
						destinationPoint.y -= 1f;
					}
				}
				else
				{
					List<Corridor> corridorList = new List<Corridor>();
					List<Room> testedRooms = new List<Room>();
					testedRooms.Add(this);
					if (!GetCorridorToAirlockPath(ref testedRooms, airlock, ref corridorList))
					{
						break;
					}
					corridor = corridorList[0];
					Room otherRoom2 = corridor.getOtherRoom(this);
					if (otherRoom2 != null && otherRoom2.IsPunctured)
					{
						bool preserve3 = true;
						if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
						{
							preserve3 = CollectorPermUpgrade.Instance.CollectLootableDrone(item);
						}
						item.Vaporize(preserve3);
						break;
					}
					destinationPoint = corridor.transform.position;
					if (corridor.transform.rotation.w == 1f)
					{
						if (base.transform.position.x < corridor.getOtherRoom(this).transform.position.x)
						{
							destinationPoint.x += 1f;
						}
						else
						{
							destinationPoint.x -= 1f;
						}
					}
					else if (base.transform.position.y < corridor.getOtherRoom(this).transform.position.y)
					{
						destinationPoint.y += 1f;
					}
					else
					{
						destinationPoint.y -= 1f;
					}
				}
			}
			item.PullOutOfRoom(destinationPoint, airlock);
		}
	}

	public bool GetCorridorToAirlockPath(ref List<Room> testedRooms, Corridor airlock, ref List<Corridor> corridorList)
	{
		if (IsPunctured)
		{
			return true;
		}
		foreach (Corridor corridor in corridors)
		{
			if (corridor.door.state == DoorState.Open && corridor == airlock)
			{
				return true;
			}
		}
		testedRooms.Add(this);
		List<Corridor> corridorList2 = new List<Corridor>();
		foreach (Corridor corridor2 in corridors)
		{
			if (corridor2.door.state == DoorState.Open && !corridorList.Contains(corridor2))
			{
				Room otherRoom = corridor2.getOtherRoom(this);
				if (!testedRooms.Contains(otherRoom) && otherRoom != null && otherRoom.GetCorridorToAirlockPath(ref testedRooms, airlock, ref corridorList2))
				{
					corridorList.Add(corridor2);
					corridorList.AddRange(corridorList2);
					return true;
				}
			}
		}
		return false;
	}

	private void VaporizeEnemiesInRoom()
	{
		EnemyManager instance = EnemyManager.Instance;
		IEnumerable<BaseEnemy> enumerable = instance.Enemies.Where((BaseEnemy x) => x != null && x.CurrentRoom == this);
		foreach (BaseEnemy item in enumerable)
		{
			if (item is SwarmEnemy)
			{
				SwarmEnemy swarmEnemy = (SwarmEnemy)item;
				if (!swarmEnemy.swarmManager.IsVaporizing)
				{
					swarmEnemy.swarmManager.Vaporize();
				}
			}
			else
			{
				item.TakeDamage(10000f, DamageType.Physical, null);
				item.Vaporize();
			}
		}
	}

	private void VaporizeProbesInRoom()
	{
		List<DropableItem> value = null;
		if (!DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Probe, out value))
		{
			return;
		}
		int count = value.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			ProbeItem probeItem = (ProbeItem)value[num];
			if (probeItem != null && probeItem.CurrentRoom == this && !probeItem.IsInSpace)
			{
				bool flag = true;
				if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector))
				{
					flag = !CollectorPermUpgrade.Instance.CollectProbe(probeItem);
				}
				if (flag)
				{
					probeItem.TakeDamage(10000f, DamageType.Physical, null);
				}
				probeItem.Vaporize();
				if (flag)
				{
					SystemMessageManager.ShowSystemMessage("Probe lost", ConsoleMessageType.Error);
				}
				DroneItemDropper.DroppedItemDict[DropItemType.Probe].Remove(probeItem);
			}
		}
	}

	private void VaporizeDroppableItems()
	{
		List<DropableItem> value = null;
		if (DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Lure, out value))
		{
			int count = value.Count;
			for (int i = 0; i < count; i++)
			{
				if (value[i] != null && ((LureItem)value[i]).CurrentRoom == this && (value[i].ParentAppliedModifications & ModificationStorageIdEnum.MagneticMod) != ModificationStorageIdEnum.MagneticMod)
				{
					if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector) && !value[i].Destroyed && !((LureItem)value[i]).hasBeenAttacked)
					{
						CollectorPermUpgrade.Instance.CollectDroppableItem(value[i]);
					}
					value[i].Vaporize();
				}
			}
		}
		if (DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.ProximityMine, out value))
		{
			int count2 = value.Count;
			for (int j = 0; j < count2; j++)
			{
				if (value[j] != null && ((ProximityMineItem)value[j]).CurrentRoom == this && (value[j].ParentAppliedModifications & ModificationStorageIdEnum.MagneticMod) != ModificationStorageIdEnum.MagneticMod)
				{
					if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector) && !value[j].Destroyed)
					{
						CollectorPermUpgrade.Instance.CollectDroppableItem(value[j]);
					}
					value[j].Vaporize();
				}
			}
		}
		if (DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Sensor, out value))
		{
			int count3 = value.Count;
			for (int k = 0; k < count3; k++)
			{
				if (value[k] != null && ((SensorItem)value[k]).CurrentRoom == this && (value[k].ParentAppliedModifications & ModificationStorageIdEnum.MagneticMod) != ModificationStorageIdEnum.MagneticMod)
				{
					value[k].Vaporize();
				}
			}
		}
		if (DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.StunBomb, out value))
		{
			int count4 = value.Count;
			for (int l = 0; l < count4; l++)
			{
				if (value[l] != null && ((StunItem)value[l]).CurrentRoom == this && (value[l].ParentAppliedModifications & ModificationStorageIdEnum.MagneticMod) != ModificationStorageIdEnum.MagneticMod)
				{
					if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector) && !value[l].Destroyed)
					{
						CollectorPermUpgrade.Instance.CollectDroppableItem(value[l]);
					}
					value[l].Vaporize();
				}
			}
		}
		if (!DroneItemDropper.DroppedItemDict.TryGetValue(DropItemType.Trap, out value))
		{
			return;
		}
		int count5 = value.Count;
		for (int m = 0; m < count5; m++)
		{
			if (value[m] != null && ((TrapItem)value[m]).CurrentRoom == this && (value[m].ParentAppliedModifications & ModificationStorageIdEnum.MagneticMod) != ModificationStorageIdEnum.MagneticMod)
			{
				if (CollectorPermUpgrade.Instance != null && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.PermCollector) && !value[m].Destroyed)
				{
					CollectorPermUpgrade.Instance.CollectDroppableItem(value[m]);
				}
				value[m].Vaporize();
			}
		}
	}

	private bool DepressurizeAdjacentRooms(List<Room> testedRoomList, bool onlyTest)
	{
		bool flag = false;
		foreach (Corridor corridor in corridors)
		{
			if (corridor.door.state != DoorState.Open)
			{
				continue;
			}
			Room otherRoom = corridor.getOtherRoom(this);
			if (otherRoom != null && !testedRoomList.Contains(otherRoom))
			{
				testedRoomList.Add(this);
				if (!flag)
				{
					flag = otherRoom.PotentiallyExposedToOutside(testedRoomList, onlyTest);
				}
			}
		}
		return flag;
	}

	private void PressurizeRoom()
	{
		List<Room> testedRooms = new List<Room>();
		Corridor airlock = null;
		if (OpenAirlockFound(ref testedRooms, out airlock))
		{
			return;
		}
		_blinkManagerPressureLayer.Stop();
		IsDepressurized = false;
		IsPendingDepressure = false;
		isEnvPressureStatusPlaneActive = false;
		SVEnvPressureStatusLayer.GetComponent<Renderer>().enabled = false;
		if ((IsFillingWithRadiation || IsRadiated) && this == DungeonManager.Instance.BoardingVessel)
		{
			timerExposureEvents = UnityEngine.Random.Range(2f, 5f);
			isPendingRadiationVenting = true;
		}
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			SetSchematicViewMaterial();
		}
		_blinkManagerPressureLayer.Stop();
		if (IsFillingWithRadiation)
		{
			StartBlinkRadiate();
		}
		foreach (Corridor corridor in corridors)
		{
			if (corridor.door.state == DoorState.Open)
			{
				Room otherRoom = corridor.getOtherRoom(this);
				if (otherRoom != null)
				{
					otherRoom.PotentiallyNoLongerExposedToOutside();
				}
			}
		}
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			int count = metaDataList.Count;
			for (int i = 0; i < count; i++)
			{
				DesignedDungeonManager.MetaData metaData = metaDataList[i];
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}

	private void MarkAsDiscovered()
	{
		hasBeenDiscovered = true;
		timeExpires = DateTime.Now.AddSeconds(5.0);
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			if (!boardingVessel)
			{
				BlinkOnSchematic();
			}
			else
			{
				hasBlinkedOnSchematic = true;
			}
		}
	}

	private void BlinkOnSchematic()
	{
		hasBlinkedOnSchematic = true;
		if (DateTime.Compare(DateTime.Now, timeExpires) <= 0)
		{
			notVisitedOutline.StartBlink(0.2f, 3);
			visitedOutline.StartBlink(0.2f, 3);
		}
	}

	private void AddSoundSources()
	{
	}

	public void RegisterEnemy(BaseEnemy enemy)
	{
		if (knownEnemiesList == null)
		{
			knownEnemiesList = new List<BaseEnemy>();
		}
		if (!knownEnemiesList.Contains(enemy))
		{
			knownEnemiesList.Add(enemy);
		}
		if (IsVisible || boardingVessel)
		{
			enemy.EnableRenderer(true);
		}
		else
		{
			enemy.EnableRenderer(false);
		}
	}

	public void DeRegisterEnemy(BaseEnemy enemy)
	{
		if (knownEnemiesList != null && knownEnemiesList.Contains(enemy))
		{
			knownEnemiesList.Remove(enemy);
		}
	}

	public void ShowRegisteredEnimies()
	{
		if (knownEnemiesList != null)
		{
			int count = knownEnemiesList.Count;
			for (int i = 0; i < count; i++)
			{
				knownEnemiesList[i].EnableRenderer(true);
			}
		}
	}

	public void HideRegisteredEnimies()
	{
		if (knownEnemiesList != null)
		{
			int count = knownEnemiesList.Count;
			for (int i = 0; i < count; i++)
			{
				knownEnemiesList[i].EnableRenderer(false);
			}
		}
	}
}
