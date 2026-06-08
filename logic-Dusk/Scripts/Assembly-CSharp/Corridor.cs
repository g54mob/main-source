using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corridor : MonoBehaviour, IMetaData, IOverlayCommunication, IDiscoverable, IObjectState, IUpdateCameraView
{
	public static Material CorridorDVMaterial;

	public static Material CorridorSVMaterial;

	public static bool hasShownDockHintAtLeastOnce;

	public Room[] rooms;

	private bool _isExplored;

	private Image labelObject;

	private Image topBorder;

	private Image bottomBorder;

	private Image leftBorder;

	private Image rightBorder;

	public Door door;

	public AudioSource vacuumSound;

	public GameObject labelObjectSV;

	public Color labelColorDroneview = Color.blue;

	public Color labelColorSchematicView = Color.white;

	public Material solidOutline;

	public Material dottedOutline;

	public bool LeadsIntoShip;

	public List<Waypoint> Waypoints;

	private bool scanning;

	private bool shownAtLastOnce;

	private CameraMode currentCameraMode;

	private int knownRoomCount;

	private List<GameObject> corridorTileObjects;

	private Color corridorOriginalColor = Color.white;

	private Color panelOriginalColor = Color.white;

	private ColorBlinkManager blinkManager;

	private ColorBlinkManager blinkManagerPanel;

	public List<BaseEnemy> knownEnemiesList;

	private bool hasBlinkedOn;

	private float destructionAttackTimer;

	private float destructionAttackTime = 1f;

	private float radiationSourceFactor = 1f;

	private bool _onSchematic;

	public bool isPowered { get; private set; }

	public bool isWelded { get; set; }

	public bool isExplored
	{
		get
		{
			if (_isExplored)
			{
				return _isExplored;
			}
			int num = rooms.Length;
			for (int i = 0; i < num; i++)
			{
				Room room = rooms[i];
				if (room != null && room.isExplored)
				{
					_isExplored = true;
					return true;
				}
			}
			return false;
		}
	}

	public bool isScanned
	{
		get
		{
			return isExplored;
		}
	}

	public bool isSurroundedByRadiation { get; set; }

	public DateTime timeExpires { get; private set; }

	public bool hasBeenDiscovered { get; private set; }

	public bool hasBlinkedOnSchematic { get; private set; }

	public bool hasBlinkedFirstTimeOnSchematic { get; private set; }

	public bool hasOverlayBeenTriggered { get; private set; }

	public Text labelTextObject { get; set; }

	public bool IsAirlock { get; set; }

	public bool IsVisible { get; private set; }

	public bool IsTileVisible { get; private set; }

	public DroneUIObject droneUIObject { get; private set; }

	public bool onSchematic
	{
		get
		{
			return _onSchematic;
		}
		set
		{
			_onSchematic = value;
			if (value)
			{
				labelTextObject.enabled = true;
				if (!shownAtLastOnce)
				{
					MarkAsDiscovered();
				}
				if (labelObject != null && GlobalSettings.cameraMode == CameraMode.Schematic)
				{
					labelObject.enabled = true;
					topBorder.enabled = true;
					bottomBorder.enabled = true;
					leftBorder.enabled = true;
					rightBorder.enabled = true;
				}
				if (droneUIObject != null)
				{
					droneUIObject.ShowOneObjectByName("Text");
				}
			}
		}
	}

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	private void Awake()
	{
		if (CorridorDVMaterial == null)
		{
			CorridorDVMaterial = ResourceManager.LoadAsset<Material>("Structures/CorridorDroneViewMtl");
		}
		if (CorridorSVMaterial == null)
		{
			CorridorSVMaterial = ResourceManager.LoadAsset<Material>("Structures/CorridorSchematicMtl");
		}
		door = (Door)GetComponentInChildren(typeof(Door));
	}

	private void Start()
	{
		Transform transform = base.transform.Find("DroneUI");
		if (transform != null)
		{
			droneUIObject = (DroneUIObject)transform.gameObject.GetComponent(typeof(DroneUIObject));
			droneUIObject.objectBecameVisible += SetVisibleOnProximityToOverlay;
			droneUIObject.parentObject = base.gameObject;
			if (onSchematic)
			{
				onSchematic = true;
			}
		}
		Transform[] componentsInChildren = GetComponentsInChildren<Transform>();
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			Transform transform2 = componentsInChildren[i];
			string text = transform2.name;
			if (text.Length >= 4 && text[0] == 'T' && transform2.name.StartsWith("Tile"))
			{
				if (corridorTileObjects == null)
				{
					corridorTileObjects = new List<GameObject>(20);
				}
				corridorTileObjects.Add(transform2.gameObject);
			}
		}
		if (corridorTileObjects != null)
		{
			int count = corridorTileObjects.Count;
			for (int j = 0; j < count; j++)
			{
				corridorTileObjects[j].GetComponent<Renderer>().enabled = false;
			}
		}
		droneUIObject.blinkingStoppedOnViewChange += PostBlinkStoppedOnViewChange;
		droneUIObject.blinkingCompleted += PostBlinkStoppedOnViewChange;
		transform = labelObjectSV.transform.FindChild("label");
		if (transform != null)
		{
			labelObject = transform.gameObject.GetComponent<Image>();
			labelObject.enabled = false;
			topBorder = labelObject.transform.Find("TopBorder").gameObject.GetComponent<Image>();
			bottomBorder = labelObject.transform.Find("BottomBorder").gameObject.GetComponent<Image>();
			leftBorder = labelObject.transform.Find("LeftBorder").gameObject.GetComponent<Image>();
			rightBorder = labelObject.transform.Find("RightBorder").gameObject.GetComponent<Image>();
			topBorder.enabled = false;
			bottomBorder.enabled = false;
			leftBorder.enabled = false;
			rightBorder.enabled = false;
		}
		RefreshColors();
	}

	private void OnDestroy()
	{
		labelTextObject = null;
		labelObject = null;
		topBorder = null;
		bottomBorder = null;
		leftBorder = null;
		rightBorder = null;
		labelObjectSV = null;
		solidOutline = null;
		dottedOutline = null;
	}

	public void SetVisibleOnProximityToOverlay(GameObject data)
	{
		hasOverlayBeenTriggered = true;
		door.fillSVA.GetComponent<Renderer>().material = solidOutline;
		door.fillSVB.GetComponent<Renderer>().material = solidOutline;
		MarkAsDiscovered();
		SetVisible(data);
		if (!IsAirlock || (GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Derelict && GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.DungeonType != DungeonTypeEnum.Station) || hasShownDockHintAtLeastOnce)
		{
			return;
		}
		bool flag = false;
		Room[] array = rooms;
		foreach (Room room in array)
		{
			if (room != null && room.boardingVessel)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			if (!GameSaveFile.Get("HNT_ALOCK_DOCK", false))
			{
				HintManager.PushHint(new DockHint(door.Label));
				hasShownDockHintAtLeastOnce = true;
			}
			else
			{
				hasShownDockHintAtLeastOnce = true;
			}
		}
	}

	public void SetVisible(GameObject data)
	{
		IsVisible = true;
		if (knownEnemiesList != null)
		{
			int count = knownEnemiesList.Count;
			for (int i = 0; i < count; i++)
			{
				knownEnemiesList[i].EnableRenderer(true);
			}
		}
	}

	private void Update()
	{
		if (knownRoomCount != rooms.Length)
		{
			if (droneUIObject != null)
			{
				if (droneUIObject.roomLst == null)
				{
					droneUIObject.roomLst = new List<Room>();
				}
				else
				{
					droneUIObject.roomLst.Clear();
				}
				droneUIObject.roomLst.AddRange(rooms);
				Room[] array = rooms;
				foreach (Room room in array)
				{
					if (room != null)
					{
						room.AddDroneOverlayUI(droneUIObject);
					}
				}
			}
			knownRoomCount = rooms.Length;
		}
		if (scanning && droneUIObject != null)
		{
			droneUIObject.MakeVisible();
			IsVisible = true;
			scanning = false;
			if (knownEnemiesList != null)
			{
				int count = knownEnemiesList.Count;
				for (int j = 0; j < count; j++)
				{
					knownEnemiesList[j].EnableRenderer(true);
				}
			}
		}
		if (isSurroundedByRadiation)
		{
			destructionAttackTimer += Time.deltaTime * radiationSourceFactor;
			if (destructionAttackTimer > destructionAttackTime)
			{
				destructionAttackTimer = 0f;
				foreach (Drone drones in DroneManager.Instance.dronesList)
				{
					if (drones.CurrentCorridor == this)
					{
						drones.TakeDamage(2f, DamageType.Radiation, null);
					}
				}
			}
		}
		if (blinkManager != null)
		{
			Color color = blinkManager.Update(Time.deltaTime);
			if (blinkManager.IsActive && GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				GetComponent<Renderer>().material.color = color;
				door.fillSVCorridor.GetComponent<Renderer>().material.color = color;
			}
			else
			{
				GetComponent<Renderer>().material.color = corridorOriginalColor;
				door.fillSVCorridor.GetComponent<Renderer>().material.color = corridorOriginalColor;
				blinkManager = null;
			}
			color = blinkManagerPanel.Update(Time.deltaTime);
			if (blinkManagerPanel.IsActive && GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				door.fillSVA.GetComponent<Renderer>().material.color = color;
				door.fillSVB.GetComponent<Renderer>().material.color = color;
			}
			else
			{
				color = (door.IsDisconnected ? door.DisconnectedColor : ((!door.IsDead) ? panelOriginalColor : door.DeadColor));
				door.fillSVA.GetComponent<Renderer>().material.color = color;
				door.fillSVB.GetComponent<Renderer>().material.color = color;
				blinkManagerPanel = null;
			}
		}
		if (GlobalSettings.cameraMode == CameraMode.Drone && IsAirlock && door.state == DoorState.Open)
		{
			door.corridor.vacuumSound.volume = GameAudio.RemoteVolume * 1f;
		}
	}

	public void Show()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic || corridorTileObjects == null)
		{
			if (!hasBlinkedOn)
			{
				hasBlinkedOn = true;
			}
		}
		else
		{
			int count = corridorTileObjects.Count;
			for (int i = 0; i < count; i++)
			{
				corridorTileObjects[i].GetComponent<Renderer>().enabled = true;
			}
		}
		shownAtLastOnce = true;
		IsTileVisible = true;
	}

	public void Hide()
	{
		if (corridorTileObjects == null)
		{
			GetComponent<Renderer>().enabled = false;
		}
		else
		{
			int count = corridorTileObjects.Count;
			for (int i = 0; i < count; i++)
			{
				corridorTileObjects[i].GetComponent<Renderer>().enabled = false;
			}
		}
		IsTileVisible = false;
	}

	public void Scanned()
	{
		scanning = true;
	}

	public void activateRooms()
	{
		Room[] array = rooms;
		foreach (Room room in array)
		{
			if (room != null && !room.GetComponent<Renderer>().enabled)
			{
				room.fadeIn();
			}
		}
	}

	public bool containsRoom(Room roomSearchingFor)
	{
		int num = rooms.Length;
		for (int i = 0; i < num; i++)
		{
			if (rooms[i] == roomSearchingFor)
			{
				return true;
			}
		}
		return false;
	}

	public Room getOtherRoom(Room givenRoom)
	{
		bool flag = false;
		Room result = null;
		int num = rooms.Length;
		for (int i = 0; i < num; i++)
		{
			Room room = rooms[i];
			if (room == givenRoom)
			{
				flag = true;
			}
			else
			{
				result = room;
			}
		}
		if (flag)
		{
			return result;
		}
		return null;
	}

	public void power()
	{
		bool flag = false;
		int num = rooms.Length;
		for (int i = 0; i < num; i++)
		{
			Room room = rooms[i];
			if (room != null)
			{
				flag = flag || room.isPowered;
			}
		}
		isPowered = flag;
		RefreshColors();
		if (door != null)
		{
			door.power(isPowered);
		}
	}

	public void RefreshColors()
	{
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			return;
		}
		Color white = Color.white;
		if (IsAirlock)
		{
			white = ((!isPowered) ? DungeonManager.Instance.SVUnPoweredAirlock : DungeonManager.Instance.SVPoweredAirlock);
		}
		else
		{
			white = ((!isPowered) ? DungeonManager.Instance.SVUnPoweredDoor : DungeonManager.Instance.SVPoweredDoor);
			if (isWelded)
			{
				white = DungeonManager.Instance.SVWeldedDoor;
			}
		}
		if (door.fillSVA != null)
		{
			if (!door.IsDisconnected && !door.IsDead)
			{
				door.fillSVA.GetComponent<Renderer>().material.color = white;
				door.fillSVB.GetComponent<Renderer>().material.color = white;
				labelTextObject.color = white;
			}
			else if (door.IsDead)
			{
				white = door.DeadColor;
				if (isWelded)
				{
					white = DungeonManager.Instance.SVWeldedDoor;
					door.fillSVA.GetComponent<Renderer>().material.color = white;
					door.fillSVB.GetComponent<Renderer>().material.color = white;
				}
				labelTextObject.color = white;
			}
			else if (door.IsDisconnected)
			{
				labelTextObject.color = door.DisconnectedColor;
			}
		}
		else
		{
			labelTextObject.color = white;
		}
		if (blinkManagerPanel != null && blinkManagerPanel.IsActive)
		{
			blinkManagerPanel.startColor = white;
			panelOriginalColor = white;
		}
		if (topBorder != null)
		{
			topBorder.color = white;
			bottomBorder.color = white;
			leftBorder.color = white;
			rightBorder.color = white;
		}
	}

	public void UpdateCameraView()
	{
		UpdateCameraView(false);
	}

	public void UpdateCameraView(bool force)
	{
		if (GlobalSettings.cameraMode == CameraMode.Drone)
		{
			if (IsAirlock && door.state == DoorState.Open && this != BoardingShip.Instance.CurrentAirlock)
			{
				door.corridor.vacuumSound.volume = GameAudio.RemoteVolume * 1f;
				door.corridor.vacuumSound.Play();
			}
			GetComponent<Renderer>().material = CorridorDVMaterial;
			if (currentCameraMode != GlobalSettings.cameraMode || force)
			{
				if (IsTileVisible && corridorTileObjects != null)
				{
					int count = corridorTileObjects.Count;
					for (int i = 0; i < count; i++)
					{
						corridorTileObjects[i].GetComponent<Renderer>().enabled = true;
					}
				}
				GetComponent<Renderer>().enabled = false;
				currentCameraMode = GlobalSettings.cameraMode;
				if (labelObject != null)
				{
					labelObject.enabled = false;
					topBorder.enabled = false;
					bottomBorder.enabled = false;
					leftBorder.enabled = false;
					rightBorder.enabled = false;
				}
				door.sliderA.GetComponent<Renderer>().enabled = true;
				door.sliderB.GetComponent<Renderer>().enabled = true;
				SetVisible(null);
			}
		}
		else
		{
			if (door.corridor != null && door.corridor.vacuumSound.isPlaying)
			{
				door.corridor.vacuumSound.Stop();
			}
			GetComponent<Renderer>().material = CorridorSVMaterial;
			if (currentCameraMode != GlobalSettings.cameraMode || force)
			{
				if (IsTileVisible && corridorTileObjects != null)
				{
					int count2 = corridorTileObjects.Count;
					for (int j = 0; j < count2; j++)
					{
						corridorTileObjects[j].GetComponent<Renderer>().enabled = false;
					}
				}
				if (onSchematic)
				{
					labelObject.enabled = true;
					topBorder.enabled = true;
					bottomBorder.enabled = true;
					leftBorder.enabled = true;
					rightBorder.enabled = true;
				}
				currentCameraMode = GlobalSettings.cameraMode;
				if (hasBeenDiscovered)
				{
					if (!hasBlinkedFirstTimeOnSchematic)
					{
						BlinkOnSchematic();
					}
					else if (hasOverlayBeenTriggered && !hasBlinkedOnSchematic)
					{
						BlinkOnSchematic();
					}
				}
				door.sliderA.GetComponent<Renderer>().enabled = false;
				door.sliderB.GetComponent<Renderer>().enabled = false;
				RefreshColors();
			}
		}
		door.CameraChanged();
	}

	private void PostBlinkStoppedOnViewChange()
	{
		door.ForceSetDoorColorsRegardlessOfView();
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			RefreshColors();
		}
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}

	public override string ToString()
	{
		if (door != null)
		{
			return door.Label;
		}
		return base.ToString();
	}

	public Color GetBlinkColor(string overlayName)
	{
		Color result = Color.black;
		if (GlobalSettings.cameraMode != CameraMode.Schematic)
		{
			result = ((!IsAirlock) ? ((!isPowered) ? DungeonManager.Instance.DVUnPoweredDoor : DungeonManager.Instance.DVPoweredDoor) : ((!isPowered) ? DungeonManager.Instance.DVUnPoweredAirlock : DungeonManager.Instance.DVPoweredAirlock));
		}
		else if (overlayName == "Text")
		{
			result = ((!IsAirlock) ? ((!isPowered) ? DungeonManager.Instance.SVUnPoweredDoor : DungeonManager.Instance.SVPoweredDoor) : ((!isPowered) ? DungeonManager.Instance.SVUnPoweredAirlock : DungeonManager.Instance.SVPoweredAirlock));
			if (door.IsDisconnected)
			{
				result = door.DisconnectedColor;
			}
			else if (door.IsDead)
			{
				result = door.DeadColor;
			}
		}
		return result;
	}

	private void MarkAsDiscovered()
	{
		hasBeenDiscovered = true;
		timeExpires = DateTime.Now.AddSeconds(5.0);
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			BlinkOnSchematic();
		}
		else if (hasOverlayBeenTriggered)
		{
			hasBlinkedFirstTimeOnSchematic = true;
		}
	}

	private void BlinkOnSchematic()
	{
		if (hasBlinkedFirstTimeOnSchematic)
		{
			hasBlinkedOnSchematic = true;
		}
		else
		{
			hasBlinkedFirstTimeOnSchematic = true;
		}
		if (DateTime.Compare(DateTime.Now, timeExpires) <= 0)
		{
			if (IsAirlock)
			{
				panelOriginalColor = ((!isPowered) ? DungeonManager.Instance.SVUnPoweredAirlock : DungeonManager.Instance.SVPoweredAirlock);
			}
			else
			{
				panelOriginalColor = ((!isPowered) ? DungeonManager.Instance.SVUnPoweredDoor : DungeonManager.Instance.SVPoweredDoor);
			}
			if (door.IsDisconnected)
			{
				panelOriginalColor = door.DisconnectedColor;
			}
			else if (door.IsDead)
			{
				panelOriginalColor = door.DeadColor;
			}
			corridorOriginalColor = door.fillSVCorridor.GetComponent<Renderer>().material.color;
			if (blinkManager == null)
			{
				blinkManager = new ColorBlinkManager();
			}
			if (blinkManagerPanel == null)
			{
				blinkManagerPanel = new ColorBlinkManager();
			}
			blinkManager.Start(corridorOriginalColor, Color.black, 0.2f, 3);
			blinkManagerPanel.Start(panelOriginalColor, Color.black, 0.2f, 3);
		}
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
	}

	public void DeRegisterEnemy(BaseEnemy enemy)
	{
		if (knownEnemiesList != null && knownEnemiesList.Contains(enemy))
		{
			knownEnemiesList.Remove(enemy);
		}
	}
}
