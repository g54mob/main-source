using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClockStone;
using HighlightingSystem;
using I2.Loc;
using InControl;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
	public delegate void ConfirmRoomDestructionDelegate(GameObject room);

	public enum CurrentMode
	{
		STANDARD = 0,
		CONSTRUCTION = 1,
		PLACEMENT = 2
	}

	public enum SubMode
	{
		STANDARD = 0,
		NEW_ROOM_SELECTION = 1,
		NEW_ROOM_BUILDING = 2,
		NEW_PIPE = 3,
		DESTROY = 4,
		NONE = 5
	}

	public enum PipeMode
	{
		STARTING_ROOM = 0,
		STARTING_WALL = 1,
		ENDING_ROOM = 2,
		ENDING_WALL = 3
	}

	public TextAsset startingBuildings;

	public static float pipeSize = 11.5f;

	public BuildableObject standardPipe;

	public BuildableObject defaultPenWork;

	public BuildableObject defaultPenHome;

	public GameObject placementGridPrefab;

	public GameObject constructionHolderPrefab;

	public GameObject pipeLinePrefab;

	public GameObject pipeFocusNodePrefab;

	public GameObject constructionPriceIndicatorPrefab;

	public GameObject penDecorationButtonPrefab;

	private Vector3 penDecorationButtonScale = new Vector3(0.125f, 0.125f, 0.125f);

	private List<GameObject> instantiatedPenDecorationButtons = new List<GameObject>();

	public GameObject constructionPlanePrefab;

	private GameObject constructionPlaneRef;

	private Material constructionPlaneMaterial;

	public GameObject pipeExpansionObject;

	public GameObject roomExpansionObject;

	public Color roomFocusColor = Color.cyan;

	public GameObject roomValidIndicator;

	public GameObject roomInvalidIndicator;

	public GameObject cellValidIndicator;

	public GameObject cellInvalidIndicator;

	public GameObject startingPipeCellIndicator;

	public Material validHighlightMaterial;

	public Material invalidHighlightMaterial;

	public GameObject worldMessagePrefab;

	private Transform constructionHolder;

	private Transform constructionHolderCanvasTransform;

	private float indicatorZCoords = -30f;

	private float pipeLineZoffset = 0.01f;

	private float startingPipeLineZPos = -25f;

	private ulong IDCounter;

	private List<ulong> createdRoomIDs = new List<ulong>();

	private List<ulong> createdPipeIDs = new List<ulong>();

	private Dictionary<ulong, CreatedPipe> createdPipes = new Dictionary<ulong, CreatedPipe>();

	private Dictionary<ulong, GameObject> createdObjects = new Dictionary<ulong, GameObject>();

	private Dictionary<ulong, BoundingBoxComponent> createdRoomBBCs = new Dictionary<ulong, BoundingBoxComponent>();

	private GameObject instantiatedStartingPipeCellIndicator;

	private List<object> createdIndicatorKeys = new List<object>();

	private List<ulong> validRoomUIDs = new List<ulong>();

	private Dictionary<object, ConstructionIndicator> createdIndicators = new Dictionary<object, ConstructionIndicator>();

	private SubMode subMode;

	private CurrentMode currentMode;

	private PipeMode currentPipeMode;

	private List<RoomBase> roomList = new List<RoomBase>();

	private GameObject currentBuildNode;

	private Vector3Int? currentlySelectedCell;

	private BuildableObject currentBuildableObject;

	private GameObject roomGhost;

	private Vector3Int roomGhostDimensions;

	private Vector3 roomGhostBoundingBoxSize;

	private GameObject pipeGhost;

	private float raycastDist = 2000f;

	private RaycastHit[] results = new RaycastHit[100];

	private bool requireMouseUp;

	private GameObject mousedOverRoom;

	private PipeFocusArrow mousedOverFocusNode;

	private bool pipeArrowsEnabled = true;

	private CreatedPipe? mousedOverPipe;

	private GameObject lastFocusedRoom;

	private GameObject roomToFocus;

	private List<Vector3Int> mouseOverGridCellTargets = new List<Vector3Int>();

	private Dictionary<Vector3Int, GameObject> gridCellsToNodeDict = new Dictionary<Vector3Int, GameObject>();

	private Vector3Int originalGridPosition;

	private RoomBase currentlyDraggedRoom;

	private List<ulong> pipeIDsForDraggedRoom = new List<ulong>();

	private List<GameObject> draggedPipeCaps = new List<GameObject>();

	private RoomBase endingRoom;

	private RoomBase startingRoom;

	private WallBase endingWall;

	private WallBase startingWall;

	private Vector3Int? chosenStartingCoords;

	private GameObject currentHighlightedRoom;

	private ConnectorLabel startingLabel;

	private List<ForcedNode> forcedNodes = new List<ForcedNode>();

	private float gridCellSize = 10.5f;

	private int gridSizeX = 12;

	private int gridSizeY = 8;

	private int gridSizeZ = 4;

	private int xBoundMin;

	private int xBoundMax;

	private int yBoundMin;

	private int yBoundMax;

	private int zBoundMin;

	private int zBoundMax;

	private List<List<List<ulong?>>> grid = new List<List<List<ulong?>>>();

	private List<List<List<ulong?>>> pipeGrid = new List<List<List<ulong?>>>();

	private List<ulong> pipesToRebuild = new List<ulong>();

	private Texture2D markedGridCellTexture;

	private Texture2D highlightedGridCellTexture;

	private Texture2D highlightedGridCellTextureEmpty;

	private Vector3Int lastHighlightedDimensions;

	private Vector3Int lastHighlightedStartingCoords;

	private bool needsMouseUp;

	private int lastGravboostCheckUpdateTime = -1;

	private bool gravboostCheckCachedVal;

	private string placeRoomSound = "build_new_pen";

	private string playModeEnterSound = "playModeEnter";

	private string buildModeEnterSound = "buildModeEnter";

	private string pipeCompleteSound = "build_pipe_complete";

	private string pipeArrowPressedSound = "pipe_arrow_focus";

	private string pipeSelectRoomSound = "build_pipe_select_room";

	private string pipeSelectWallSound = "build_pipe_select_wall";

	private string grabRoomSound = "build_penGrab";

	private string deleteSound = "build_delete";

	private string cancelPlacementSound = "build_cancel";

	private bool initialized;

	private DogHome homeRef;

	private Camera cameraRef;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private ObjectGrabber grabberRef;

	private NavmeshHelper navmeshRef;

	private CursorController cursorRef;

	private DogPettingController pettingRef;

	private BuildableManager buildableManagerRef;

	private static MusicPlaylistController musicRef;

	private BuildGUI buildGUIRef;

	private BuildToolsPane toolsPaneRef;

	private InventoryManager inventoryRef;

	public void InitializeConstructionManager()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		constructionHolder = Object.Instantiate(constructionHolderPrefab).transform;
		constructionHolderCanvasTransform = constructionHolder.GetChild(0);
		constructionHolderCanvasTransform.transform.localPosition = new Vector3(0f, 0f, indicatorZCoords);
		ObjectPlacementManager.gridPlanePrefab = placementGridPrefab;
		ObjectPlacementManager.worldMessagePrefab = worldMessagePrefab;
		ObjectPlacementManager.OnStart();
		cameraRef = Camera.main;
		penFocusRef = cameraRef.GetComponent<PenFocus>();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		grabberRef = registrationScript.GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		navmeshRef = registrationScript.GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		pettingRef = registrationScript.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
		buildableManagerRef = registrationScript.GetGlobalComponent<BuildableManager>(GlobalObject.BUILDABLE_MANAGER);
		musicRef = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>();
		buildGUIRef = guiRef.buildModeGUI.GetComponent<BuildGUI>();
		toolsPaneRef = buildGUIRef.basicToolsPane.GetComponent<BuildToolsPane>();
		CreateGrid();
		CreateGridCellTextures();
		CreatePipeGhost();
		registrationScript.saveLoadManager.LoadBuildables();
		registrationScript.saveLoadManager.LoadDogs();
		registrationScript.saveLoadManager.LoadDogDens();
		OnExitConstructionMode(playSounds: false);
		SetConstructionMode(CurrentMode.STANDARD, null, playEntrySound: false, playExitSound: false);
		initialized = true;
	}

	private void Update()
	{
		if (initialized)
		{
			if (pipesToRebuild.Count > 0)
			{
				RebuildPipes();
			}
			HandleInput();
		}
	}

	public void PrepareForTravel()
	{
		for (int i = 0; i < roomList.Count; i++)
		{
			if (roomList[i] != null)
			{
				roomList[i].PrepareForTravel();
			}
		}
	}

	public void SaveCameraFocus(SaveableDogHome savedHomeRef)
	{
		if (lastFocusedRoom != null)
		{
			savedHomeRef.lastFocusedRoomUID = lastFocusedRoom.GetComponent<BuildObjectInfo>().GetUID();
		}
	}

	public void LoadCameraFocus(ulong lastFocusedRoomUID)
	{
		GameObject objectForUID = GetObjectForUID(lastFocusedRoomUID);
		if (objectForUID != null)
		{
			FocusRoom(objectForUID, playSound: false);
		}
		else if (createdRoomIDs.Count != 0)
		{
			FocusRoom(GetObjectForUID(createdRoomIDs[0]), playSound: false);
		}
	}

	public void SaveBuildObjects(SaveableDogHome savedHomeRef)
	{
		SaveRooms(savedHomeRef);
		SavePipes(savedHomeRef);
	}

	private void SaveRooms(SaveableDogHome savedHomeRef)
	{
		for (int i = 0; i < createdRoomIDs.Count; i++)
		{
			GameObject gameObject = createdObjects[createdRoomIDs[i]];
			BuildObjectInfo component = gameObject.GetComponent<BuildObjectInfo>();
			SavedRoom savedRoom = new SavedRoom();
			savedRoom.UID = component.GetUID();
			savedRoom.resourceString = component.GetResourceString();
			savedRoom.position = new SerializableVector3(gameObject.transform.position);
			RoomBase component2 = gameObject.GetComponent<RoomBase>();
			savedRoom.numberOfDensToBuild = component2.GetNumberOfDensToBuild();
			savedRoom.carpetPath = inventoryRef.GetPathForCustomizationObject(component2.GetCurrentCarpet());
			savedRoom.wallpaperPath = inventoryRef.GetPathForCustomizationObject(component2.GetCurrentWallpaper());
			savedRoom.placedPlants = component2.GetSaveablePlacedPlants();
			savedRoom.placedPuddles = component2.GetSaveablePlacedPuddles();
			savedRoom.placedObjects = component2.GetSaveablePlacedObjects();
			savedHomeRef.rooms.Add(savedRoom);
		}
		savedHomeRef.placedPlantsIDCounter = ObjectPlacementManager.GetCurrentPlantIDCounter();
		savedHomeRef.placedPuddlesIDCounter = ObjectPlacementManager.GetCurrentPuddleIDCounter();
		savedHomeRef.placedObjectsIDCounter = ObjectPlacementManager.GetCurrentPlaceableIDCounter();
	}

	private void SavePipes(SaveableDogHome savedHomeRef)
	{
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			CreatedPipe createdPipe = createdPipes[createdPipeIDs[i]];
			BuildObjectInfo component = createdPipe.pipeRef.GetComponent<BuildObjectInfo>();
			SavedPipe savedPipe = new SavedPipe();
			savedPipe.position = new SerializableVector3(createdPipe.pipeRef.transform.position);
			savedPipe.UID = component.GetUID();
			savedPipe.resourceString = component.GetResourceString();
			for (int j = 0; j < createdPipe.pipePath.Count; j++)
			{
				savedPipe.pipePath.Add(new SerializableVector3(createdPipe.pipePath[j]));
			}
			savedPipe.roomIDEnd = createdPipe.roomIDEnd;
			savedPipe.roomIDStart = createdPipe.roomIDStart;
			savedPipe.endingWall = createdPipe.endingWall;
			savedPipe.startingWall = createdPipe.startingWall;
			savedPipe.endingLabel = createdPipe.endingLabel;
			savedPipe.startingLabel = createdPipe.startingLabel;
			savedHomeRef.pipes.Add(savedPipe);
		}
	}

	public void LoadBuildObjects(SaveableDogHome savedHomeRef)
	{
		penFocusRef.SetLastFocusedRoom(null, refocusAllowed: true, playSound: false);
		if (startingBuildings != null && (savedHomeRef == null || savedHomeRef.freshHome))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			Stream serializationStream = new MemoryStream(startingBuildings.bytes);
			SaveFile saveFile = (SaveFile)binaryFormatter.Deserialize(serializationStream);
			SceneManagerBase globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
			if (globalComponent.GetGameMode() == GameMode.HOME)
			{
				savedHomeRef = saveFile.mainData.dogPenHome;
				savedHomeRef.rooms[0].numberOfDensToBuild = 1;
			}
			else if (globalComponent.GetGameMode() == GameMode.BREEDING)
			{
				if (saveFile.mainData.dogPenBreedingCenter == null)
				{
					return;
				}
				savedHomeRef = saveFile.mainData.dogPenBreedingCenter;
			}
			if (savedHomeRef == null)
			{
				savedHomeRef = new SaveableDogHome();
			}
			SetIDCounter(savedHomeRef.IDCounter);
			ObjectPlacementManager.SetPlantIDCounter(savedHomeRef.placedPlantsIDCounter);
			ObjectPlacementManager.SetPuddleIDCounter(savedHomeRef.placedPuddlesIDCounter);
			ObjectPlacementManager.SetPlaceableIDCounter(savedHomeRef.placedObjectsIDCounter);
		}
		if (savedHomeRef != null)
		{
			for (int i = 0; i < savedHomeRef.rooms.Count; i++)
			{
				LoadRoom(savedHomeRef.rooms[i]);
			}
			for (int j = 0; j < savedHomeRef.pipes.Count; j++)
			{
				LoadPipe(savedHomeRef.pipes[j]);
			}
			navmeshRef.Rebuild();
		}
	}

	private void LoadRoom(SavedRoom room)
	{
		BuildableObject objectForPath = buildableManagerRef.GetObjectForPath(room.resourceString);
		GameObject gameObject = CreateNewRoomAtPos(objectForPath, room.position.Load(), room.UID, fromLoad: true);
		if (!(gameObject == null))
		{
			RoomBase component = gameObject.GetComponent<RoomBase>();
			component.UpdateNumberOfDensToBuild(room.numberOfDensToBuild);
			if (room.carpetPath != null)
			{
				component.ApplyCarpet(inventoryRef.GetCustomizationObjectForPath(room.carpetPath), fromLoad: true);
			}
			if (room.wallpaperPath != null)
			{
				component.ApplyWallpaper(inventoryRef.GetCustomizationObjectForPath(room.wallpaperPath), fromLoad: true);
			}
			if (room.placedObjects != null)
			{
				component.LoadSavedPlacedObjects(room.placedObjects);
			}
			if (room.placedPlants != null)
			{
				component.LoadSavedPlacedPlants(room.placedPlants);
			}
			if (room.placedPuddles != null)
			{
				component.LoadSavedPlacedPuddles(room.placedPuddles);
			}
		}
	}

	private Quaternion GetRotationForPipeNode(WallDirection attachedWallDir)
	{
		switch (attachedWallDir)
		{
		case WallDirection.LEFT:
			return Quaternion.Euler(0f, 180f, 0f);
		case WallDirection.RIGHT:
			return Quaternion.identity;
		case WallDirection.UP:
			return Quaternion.Euler(0f, 0f, 90f);
		case WallDirection.DOWN:
			return Quaternion.Euler(0f, 0f, -90f);
		case WallDirection.FRONT:
			return Quaternion.Euler(0f, 90f, 0f);
		case WallDirection.BACK:
			return Quaternion.Euler(0f, -90f, 0f);
		default:
			return Quaternion.identity;
		}
	}

	private void LoadPipe(SavedPipe pipe)
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < pipe.pipePath.Count; i++)
		{
			list.Add(pipe.pipePath[i].Load());
		}
		endingRoom = GetObjectForUID(pipe.roomIDEnd).GetComponent<RoomBase>();
		startingRoom = GetObjectForUID(pipe.roomIDStart).GetComponent<RoomBase>();
		startingLabel = pipe.startingLabel;
		endingWall = endingRoom.GetWallForDirection(pipe.endingWall);
		startingWall = startingRoom.GetWallForDirection(pipe.startingWall);
		endingWall.SetWallState(pipe.endingLabel, enabledVal: false);
		startingWall.SetWallState(pipe.startingLabel, enabledVal: false);
		GameObject gameObject = AttachPipeToRooms(startingRoom, startingWall, endingWall, pipe.startingLabel, pipe.endingLabel, list);
		ulong num = IndexObject(gameObject, standardPipe, pipe.UID);
		List<Vector3Int> gridCells = MarkGridForPipePath(list, num);
		GameObject pipeLine = CreatePipeLineForPipePath(list);
		ulong roomIDStart = pipe.roomIDStart;
		ulong roomIDEnd = pipe.roomIDEnd;
		GameObject gameObject2 = Object.Instantiate(pipeFocusNodePrefab);
		GameObject gameObject3 = Object.Instantiate(pipeFocusNodePrefab);
		gameObject2.GetComponent<PipeFocusArrow>().roomToFocus = endingRoom.gameObject;
		gameObject3.GetComponent<PipeFocusArrow>().roomToFocus = startingRoom.gameObject;
		Pipe component = gameObject.GetComponent<Pipe>();
		gameObject2.transform.position = component.GetFirstSegmentEntranceCenter();
		gameObject3.transform.position = component.GetLastSegmentEntranceCenter();
		gameObject2.transform.rotation = GetRotationForPipeNode(startingWall.wallDirection);
		gameObject3.transform.rotation = GetRotationForPipeNode(endingWall.wallDirection);
		CreatedPipe createdPipe = new CreatedPipe(roomIDStart, roomIDEnd, startingWall.wallDirection, endingWall.wallDirection, pipe.startingLabel, pipe.endingLabel, gameObject, list, gridCells, pipeLine, gameObject2, gameObject3);
		createdPipeIDs.Add(num);
		createdPipes[num] = createdPipe;
		createdObjects[num] = createdPipe.pipeRef;
		navmeshRef.AddPortalForPipe(createdPipe);
	}

	public bool IsInConstructionMode()
	{
		return currentMode == CurrentMode.CONSTRUCTION;
	}

	public bool IsInStandardMode()
	{
		return currentMode == CurrentMode.STANDARD;
	}

	public bool IsInPlacementMode()
	{
		return currentMode == CurrentMode.PLACEMENT;
	}

	private static bool IsUIMousedOver()
	{
		return RaycastUtil.GlobalGUICheck();
	}

	public void OnDestroyButtonClicked()
	{
		SetSubMode(SubMode.DESTROY);
	}

	public void OnMoveButtonClicked()
	{
		SetSubMode(SubMode.STANDARD);
	}

	public void OnNewPipeButtonClicked()
	{
		SetSubMode(SubMode.NEW_PIPE);
	}

	public void OnNewRoomButtonClicked()
	{
		SetSubMode(SubMode.NEW_ROOM_SELECTION);
	}

	public void SetSubMode(SubMode newSubMode)
	{
		toolsPaneRef.HighlightToolForSubMode(newSubMode);
		switch (subMode)
		{
		case SubMode.STANDARD:
			OnExitStandardSubMode();
			break;
		case SubMode.NEW_ROOM_SELECTION:
			OnExitNewRoomSelectionSubMode();
			break;
		case SubMode.NEW_ROOM_BUILDING:
			OnExitRoomBuildingSubMode();
			break;
		case SubMode.NEW_PIPE:
			OnExitNewPipeSubMode();
			break;
		case SubMode.DESTROY:
			OnExitDestroySubMode();
			break;
		}
		subMode = newSubMode;
		switch (newSubMode)
		{
		case SubMode.STANDARD:
			OnEnterStandardSubMode();
			break;
		case SubMode.NEW_ROOM_SELECTION:
			OnEnterNewRoomSelectionSubMode();
			break;
		case SubMode.NEW_ROOM_BUILDING:
			OnEnterRoomBuildingSubMode();
			break;
		case SubMode.NEW_PIPE:
			OnEnterNewPipeSubMode();
			break;
		case SubMode.DESTROY:
			OnEnterDestroySubMode();
			break;
		}
	}

	public ulong GetIDCounter()
	{
		return IDCounter;
	}

	public void SetIDCounter(ulong savedIDCounter)
	{
		IDCounter = savedIDCounter;
	}

	public bool AreRoomsConnected(ulong roomIDA, ulong roomIDB)
	{
		if (roomIDA == roomIDB)
		{
			return true;
		}
		return RoomPathfinder.DoesRoomPathExist(roomIDA, roomIDB, this);
	}

	public bool IsObjectInConnectedRoom(GameObject obj, ulong startingRoomID)
	{
		ulong? roomUID = obj.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			return false;
		}
		return AreRoomsConnected(startingRoomID, roomUID.Value);
	}

	public bool IsDogInRoomConnectedToRoom(GameObject dog, ulong roomID)
	{
		ulong? roomUID = dog.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			return false;
		}
		return AreRoomsConnected(roomUID.Value, roomID);
	}

	public bool IsDogInRoomConnectedToObject(GameObject dog, GameObject obj)
	{
		ulong? roomUID = dog.GetComponent<BoundingBoxComponent>().GetRoomUID();
		if (!roomUID.HasValue)
		{
			return false;
		}
		return IsObjectInConnectedRoom(obj, roomUID.Value);
	}

	private void HandleInput()
	{
		switch (currentMode)
		{
		case CurrentMode.STANDARD:
			HandleStandardModeInput();
			break;
		case CurrentMode.CONSTRUCTION:
			HandleConstructionModeInput();
			break;
		case CurrentMode.PLACEMENT:
			HandlePlacementModeInput();
			break;
		}
	}

	private void HandleStandardModeInput()
	{
		CheckMousedOverRooms();
		CheckRoomFocus();
		CheckPipeFocus();
	}

	private void OnExitPlacementMode()
	{
		currentMode = CurrentMode.STANDARD;
		ObjectPlacementManager.OnExitPlacementMode();
	}

	private void OnEnterPlacementMode(ulong roomID, bool playSounds)
	{
		if (playSounds)
		{
			musicRef.OnEnterPlacementBuildingMode();
		}
		ObjectPlacementManager.OnEnterPlacementMode(GetObjectForUID(roomID).GetComponent<RoomBase>(), playSounds);
		penFocusRef.SetLastFocusedRoom(GetObjectForUID(roomID), refocusAllowed: true, playSound: false);
		guiRef.OnPlacementMode();
	}

	private void HandlePlacementModeInput()
	{
		ObjectPlacementManager.HandlePlacementModeInput();
	}

	private void HandleConstructionModeInput()
	{
		if (guiRef != null && !guiRef.GetGUIInteractiveStatus())
		{
			return;
		}
		if (GameControls.actions.CloseMenu.WasPressed && !guiRef.IsPopupLockActive())
		{
			homeRef.RequestExitBuildMode();
			return;
		}
		if (requireMouseUp && GameControls.actions.Interact.WasReleased)
		{
			requireMouseUp = false;
		}
		if (GameControls.actions.Cancel.WasPressed)
		{
			SetSubMode(SubMode.STANDARD);
		}
		switch (subMode)
		{
		case SubMode.STANDARD:
			HandleStandardSubModeInput();
			break;
		case SubMode.NEW_ROOM_SELECTION:
			HandleNewRoomSelectionSubModeInput();
			break;
		case SubMode.NEW_ROOM_BUILDING:
			HandleRoomBuildingSubModeInput();
			break;
		case SubMode.NEW_PIPE:
			HandleNewPipeModeInput();
			break;
		case SubMode.DESTROY:
			HandleDestroyModeInput();
			break;
		}
	}

	private void HandleStandardSubModeInput()
	{
		if (cursorRef.GetCurrentCursor() == CursorController.CursorType.CLICKABLE)
		{
			if (mousedOverRoom != null)
			{
				mousedOverRoom.GetComponent<ConstructionObject>().RestoreMaterials();
				mousedOverRoom = null;
			}
			return;
		}
		if (IsUIMousedOver())
		{
			if (currentlyDraggedRoom != null)
			{
				HideRoomGhost();
			}
			return;
		}
		if (currentlyDraggedRoom != null)
		{
			cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
			currentlyDraggedRoom.GetComponent<ConstructionObject>().RestoreMaterials();
			if (GameControls.actions.Cancel.WasPressed)
			{
				CancelDragRoom();
			}
			else if (GameControls.actions.Interact.WasPressed)
			{
				PlaceDraggedRoom();
			}
			else if (GameControls.actions.DestroyHeldObject.WasPressed)
			{
				DestroyDraggedRoom();
			}
			else
			{
				UpdateDraggedRoom();
			}
			return;
		}
		GameObject gameObject = mousedOverRoom;
		CheckMousedOverRooms();
		if (gameObject != mousedOverRoom)
		{
			if (gameObject != null)
			{
				gameObject.GetComponent<ConstructionObject>().RestoreMaterials();
			}
			if (mousedOverRoom != null)
			{
				mousedOverRoom.GetComponent<ConstructionObject>().SetMaterials(validHighlightMaterial);
			}
		}
		if (mousedOverRoom != null)
		{
			if (!requireMouseUp && GameControls.actions.Interact.WasPressed)
			{
				GrabRoom(mousedOverRoom);
				cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
			}
			else
			{
				cursorRef.SetCursor(CursorController.CursorType.GRABBABLE);
			}
		}
	}

	private void UpdateDraggedRoom()
	{
		Vector3Int mousedOverCell = GetMousedOverCell();
		AttachRoomGhostToCell(mousedOverCell);
	}

	public List<ulong> GetAllAttachedRooms(ulong roomID)
	{
		List<ulong> list = new List<ulong>();
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			ulong num = roomID;
			CreatedPipe createdPipe = createdPipes[createdPipeIDs[i]];
			if (createdPipe.roomIDStart == roomID && createdPipe.startingWall != WallDirection.UP)
			{
				num = createdPipe.roomIDEnd;
			}
			else if (createdPipe.roomIDEnd == roomID && createdPipe.endingWall != WallDirection.UP)
			{
				num = createdPipe.roomIDStart;
			}
			if (num != roomID && !list.Contains(num))
			{
				list.Add(num);
			}
		}
		return list;
	}

	public List<ulong> GetPipeIDsForRoom(RoomBase roomRef)
	{
		List<ulong> list = new List<ulong>();
		ulong uID = roomRef.GetComponent<BuildObjectInfo>().GetUID();
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			if (createdPipes[createdPipeIDs[i]].roomIDEnd == uID || createdPipes[createdPipeIDs[i]].roomIDStart == uID)
			{
				list.Add(createdPipeIDs[i]);
			}
		}
		return list;
	}

	public void SetPipeArrowStatusForRoomWall(RoomBase roomRef, WallDirection dir, bool status)
	{
		List<ulong> pipeIDsForRoom = GetPipeIDsForRoom(roomRef);
		ulong uID = roomRef.GetComponent<BuildObjectInfo>().GetUID();
		for (int i = 0; i < pipeIDsForRoom.Count; i++)
		{
			if (createdPipes[pipeIDsForRoom[i]].roomIDEnd == uID && createdPipes[pipeIDsForRoom[i]].endingWall == dir)
			{
				createdPipes[pipeIDsForRoom[i]].focusNodeEnd.SetActive(status);
				createdPipes[pipeIDsForRoom[i]].focusNodeStart.SetActive(status);
			}
			if (createdPipes[pipeIDsForRoom[i]].roomIDStart == uID && createdPipes[pipeIDsForRoom[i]].startingWall == dir)
			{
				createdPipes[pipeIDsForRoom[i]].focusNodeEnd.SetActive(status);
				createdPipes[pipeIDsForRoom[i]].focusNodeStart.SetActive(status);
			}
		}
	}

	private void GrabRoom(GameObject roomToGrab)
	{
		if (roomToGrab == null)
		{
			Debug.LogError("Attempting to grab an empty room.");
			return;
		}
		if (currentlyDraggedRoom != null)
		{
			Debug.LogError("Attempting to grab a room when we're already holding onto one.");
			return;
		}
		CreateRoomGhost(roomToGrab.GetComponent<RoomBase>().associatedBuildableObject);
		currentlyDraggedRoom = roomToGrab.GetComponent<RoomBase>();
		if (currentlyDraggedRoom == null)
		{
			Debug.LogError("Attempting to grab an object that isn't a room: " + roomToGrab);
			return;
		}
		MarkGridForRoom(roomToGrab, 0uL, clear: true);
		originalGridPosition = GetCoordsForPos(roomToGrab.transform.position);
		ulong uID = currentlyDraggedRoom.GetComponent<BuildObjectInfo>().GetUID();
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			if (createdPipes[createdPipeIDs[i]].roomIDEnd == uID || createdPipes[createdPipeIDs[i]].roomIDStart == uID)
			{
				pipeIDsForDraggedRoom.Add(createdPipeIDs[i]);
				PipeLine component = createdPipes[createdPipeIDs[i]].pipeLineRef.GetComponent<PipeLine>();
				GameObject gameObject = component.DuplicateEndCap();
				GameObject gameObject2 = component.DuplicateStartCap();
				draggedPipeCaps.Add(gameObject);
				draggedPipeCaps.Add(gameObject2);
				roomGhost.transform.position = currentlyDraggedRoom.transform.position;
				if (createdPipes[createdPipeIDs[i]].roomIDEnd == uID)
				{
					gameObject.transform.SetParent(roomGhost.transform);
				}
				else
				{
					gameObject.transform.SetParent(null);
				}
				if (createdPipes[createdPipeIDs[i]].roomIDStart == uID)
				{
					gameObject2.transform.SetParent(roomGhost.transform);
				}
				else
				{
					gameObject2.transform.SetParent(null);
				}
			}
		}
		for (int j = 0; j < pipeIDsForDraggedRoom.Count; j++)
		{
			createdPipes[pipeIDsForDraggedRoom[j]].pipeRef.SetActive(value: false);
			createdPipes[pipeIDsForDraggedRoom[j]].pipeLineRef.SetActive(value: false);
		}
		SetPlacementDecorationButtonVisibility(val: false);
		currentlyDraggedRoom.MovePosition(cameraRef.transform.position + new Vector3(0f, 500f, 0f));
		AudioController.Play(grabRoomSound);
	}

	private void SetPlacementDecorationButtonVisibility(bool val)
	{
		if (!val)
		{
			DestroyPenDecorationButtons();
		}
		else
		{
			CreatePenDecorationButtons();
		}
	}

	private void DestroyDraggedRoom()
	{
		GameObject room = currentlyDraggedRoom.gameObject;
		CancelDragRoom();
		DestroyRoom(room);
	}

	private void DestroyRoom(GameObject room)
	{
		ConfirmRoomDestructionDelegate destructionCallback = ConfirmDestroyRoom;
		if (!room.GetComponent<RoomBase>().ShowPreDestructionWarningIfNeeded(destructionCallback, guiRef))
		{
			ConfirmDestroyRoom(room);
		}
	}

	private void ConfirmDestroyRoom(GameObject room)
	{
		ulong uID = room.GetComponent<BuildObjectInfo>().GetUID();
		if (createdRoomIDs.Contains(uID))
		{
			RoomBase component = createdObjects[uID].GetComponent<RoomBase>();
			roomList.Remove(component);
			createdObjects.Remove(uID);
			createdRoomIDs.Remove(uID);
			createdRoomBBCs.Remove(uID);
		}
		List<ulong> list = new List<ulong>();
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			if (createdPipes[createdPipeIDs[i]].roomIDEnd == uID || createdPipes[createdPipeIDs[i]].roomIDStart == uID)
			{
				list.Add(createdPipeIDs[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			DestroyPipe(createdPipes[list[j]], playSound: false);
		}
		MarkGridForRoom(room, 0uL, clear: true);
		room.GetComponent<RoomBase>().DestroyInternal();
		Object.Destroy(room);
		navmeshRef.Rebuild();
		AudioController.Play(deleteSound);
		SetPlacementDecorationButtonVisibility(val: false);
		if (subMode == SubMode.NONE || subMode == SubMode.STANDARD)
		{
			SetPlacementDecorationButtonVisibility(val: true);
		}
		toolsPaneRef.UpdateRoomButton();
	}

	private void PlaceDraggedRoom()
	{
		if (currentlyDraggedRoom == null || !CanPlaceRoomGhost())
		{
			return;
		}
		PlaceRoomAtPos(currentlyDraggedRoom.gameObject, roomGhost.transform.position);
		for (int i = 0; i < pipeIDsForDraggedRoom.Count; i++)
		{
			if (!pipesToRebuild.Contains(pipeIDsForDraggedRoom[i]))
			{
				pipesToRebuild.Add(pipeIDsForDraggedRoom[i]);
			}
		}
		for (int num = draggedPipeCaps.Count - 1; num >= 0; num--)
		{
			Object.Destroy(draggedPipeCaps[num]);
		}
		draggedPipeCaps.Clear();
		HideRoomGhost();
		currentlyDraggedRoom = null;
		pipeIDsForDraggedRoom.Clear();
		SetPlacementDecorationButtonVisibility(val: true);
	}

	private void CancelDragRoom()
	{
		if (currentlyDraggedRoom == null)
		{
			return;
		}
		PlaceRoomAtCoords(currentlyDraggedRoom.gameObject, originalGridPosition);
		HideRoomGhost();
		currentlyDraggedRoom = null;
		for (int i = 0; i < pipeIDsForDraggedRoom.Count; i++)
		{
			if (createdPipes.ContainsKey(pipeIDsForDraggedRoom[i]))
			{
				createdPipes[pipeIDsForDraggedRoom[i]].pipeRef.SetActive(value: true);
				createdPipes[pipeIDsForDraggedRoom[i]].pipeLineRef.SetActive(value: true);
			}
		}
		for (int num = draggedPipeCaps.Count - 1; num >= 0; num--)
		{
			Object.Destroy(draggedPipeCaps[num]);
		}
		draggedPipeCaps.Clear();
		pipeIDsForDraggedRoom.Clear();
		SetPlacementDecorationButtonVisibility(val: true);
		AudioController.Play(cancelPlacementSound);
	}

	private void HandleNewRoomSelectionSubModeInput()
	{
	}

	private void HandleRoomBuildingSubModeInput()
	{
		if (needsMouseUp && !GameControls.actions.Interact.IsPressed)
		{
			needsMouseUp = false;
		}
		if (IsUIMousedOver())
		{
			HideRoomGhost();
			return;
		}
		cursorRef.SetCursor(CursorController.CursorType.GRABBING2D);
		if (currentlySelectedCell.HasValue && GameControls.actions.Interact.WasPressed && !needsMouseUp && CanPlaceRoomGhost())
		{
			CreateNewRoomAtPos(currentBuildableObject, roomGhost.transform.position);
			return;
		}
		Vector3Int mousedOverCell = GetMousedOverCell();
		if (!(currentlySelectedCell == mousedOverCell))
		{
			OnCellDeselected(currentlySelectedCell);
			OnCellSelected(mousedOverCell);
		}
	}

	private void HandleNewPipeModeInput()
	{
		if (!IsUIMousedOver())
		{
			switch (currentPipeMode)
			{
			case PipeMode.STARTING_ROOM:
				HandleStartingRoomInput();
				break;
			case PipeMode.STARTING_WALL:
				HandleStartingWallInput();
				break;
			case PipeMode.ENDING_ROOM:
				HandleEndingRoomInput();
				break;
			case PipeMode.ENDING_WALL:
				HandleEndingWallInput();
				break;
			}
		}
	}

	private void HandleDestroyModeInput()
	{
		if (IsUIMousedOver())
		{
			if (mousedOverRoom != null)
			{
				mousedOverRoom.GetComponent<ConstructionObject>().RestoreMaterials();
			}
			if (mousedOverPipe.HasValue && mousedOverPipe.Value.pipeRef != null)
			{
				mousedOverPipe.Value.pipeRef.GetComponent<ConstructionObject>().RestoreMaterials();
			}
			return;
		}
		CreatedPipe? createdPipe = mousedOverPipe;
		CheckMousedOverPipes();
		if ((!createdPipe.HasValue && mousedOverPipe.HasValue) || (createdPipe.HasValue && !mousedOverPipe.HasValue) || (createdPipe.HasValue && mousedOverPipe.HasValue && createdPipe.Value.pipeRef != mousedOverPipe.Value.pipeRef))
		{
			if (createdPipe.HasValue && createdPipe.Value.pipeRef != null)
			{
				createdPipe.Value.pipeRef.GetComponent<ConstructionObject>().RestoreMaterials();
			}
			if (mousedOverPipe.HasValue && mousedOverPipe.Value.pipeRef != null)
			{
				mousedOverPipe.Value.pipeRef.GetComponent<ConstructionObject>().SetMaterials(invalidHighlightMaterial);
			}
		}
		if (mousedOverPipe.HasValue)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			if (GameControls.actions.Interact.WasPressed)
			{
				DestroyPipe(mousedOverPipe.Value);
			}
			if (mousedOverRoom != null)
			{
				mousedOverRoom.GetComponent<ConstructionObject>().RestoreMaterials();
				mousedOverRoom = null;
			}
			return;
		}
		GameObject gameObject = mousedOverRoom;
		CheckMousedOverRooms();
		if (gameObject != mousedOverRoom)
		{
			if (gameObject != null)
			{
				gameObject.GetComponent<ConstructionObject>().RestoreMaterials();
			}
			if (mousedOverRoom != null)
			{
				mousedOverRoom.GetComponent<ConstructionObject>().SetMaterials(invalidHighlightMaterial);
			}
		}
		if (mousedOverRoom != null)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			if (GameControls.actions.Interact.WasPressed)
			{
				DestroyRoom(mousedOverRoom);
			}
		}
	}

	private void HandleStartingRoomInput()
	{
		CheckMousedOverRooms();
		startingRoom = CheckRoomSelect();
		if (startingRoom == null)
		{
			if (currentHighlightedRoom != null)
			{
				RemoveHighlightForRoomForSelection();
			}
			return;
		}
		if (currentHighlightedRoom != startingRoom.gameObject)
		{
			HighlightRoomForSelection(startingRoom.gameObject);
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
		}
		if (GameControls.actions.Interact.WasPressed)
		{
			SetPipeMode(PipeMode.STARTING_WALL);
			AudioController.Play(pipeSelectRoomSound);
		}
	}

	private void HandleStartingWallInput()
	{
		if (currentBuildNode != null && GameControls.actions.Interact.WasPressed)
		{
			PipeExpansionNode component = currentBuildNode.GetComponent<PipeExpansionNode>();
			WallBase wallBase = (startingWall = component.attachedWall);
			startingLabel = component.label;
			Vector3 pipePositionForWall = GetPipePositionForWall(component.attachedRoom.GetWallForDirection(wallBase.wallDirection), component.label);
			Vector3Int coordsForPos = GetCoordsForPos(pipePositionForWall);
			coordsForPos.z = 0;
			chosenStartingCoords = GetGridListCoordsForAbsoluteCoords(coordsForPos);
			instantiatedStartingPipeCellIndicator = Object.Instantiate(startingPipeCellIndicator, constructionHolder);
			Vector3 posForCoords = GetPosForCoords(coordsForPos);
			posForCoords.z = indicatorZCoords;
			instantiatedStartingPipeCellIndicator.transform.position = posForCoords;
			SetPipeMode(PipeMode.ENDING_ROOM);
			AudioController.Play(pipeSelectWallSound);
		}
		else
		{
			OnStartingPipeNodeDeselected();
			Vector3Int mousedOverCell = GetMousedOverCell();
			if (mouseOverGridCellTargets.Contains(mousedOverCell))
			{
				OnStartingPipeNodeSelected(gridCellsToNodeDict[mousedOverCell]);
			}
		}
	}

	private void HandleEndingRoomInput()
	{
		CheckMousedOverRooms();
		endingRoom = CheckRoomSelect();
		if (endingRoom == null)
		{
			if (currentHighlightedRoom != null)
			{
				RemoveHighlightForRoomForSelection();
			}
			return;
		}
		if (currentHighlightedRoom != endingRoom.gameObject)
		{
			HighlightRoomForSelection(endingRoom.gameObject);
		}
		else
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
		}
		if (GameControls.actions.Interact.WasPressed)
		{
			SetPipeMode(PipeMode.ENDING_WALL);
			AudioController.Play(pipeSelectRoomSound);
		}
	}

	private List<Vector3> GetPipePath(GameObject pipeRef, RoomBase startingRoom, RoomBase endingRoom, WallBase startingWall, WallBase endingWall, ConnectorLabel startingLabel, ConnectorLabel endingLabel)
	{
		AttachPipeToRoom(pipeRef, startingRoom, startingWall, startingLabel);
		Vector3Int coordsForPos = GetCoordsForPos(pipeRef.transform.position);
		Vector3Int gridListCoordsForAbsoluteCoords = GetGridListCoordsForAbsoluteCoords(coordsForPos);
		AttachPipeToRoom(pipeRef, endingRoom, endingWall, endingLabel);
		Vector3Int coordsForPos2 = GetCoordsForPos(pipeRef.transform.position);
		return PipePathfinder.GetPipePath(endPos: GetGridListCoordsForAbsoluteCoords(coordsForPos2), startPos: gridListCoordsForAbsoluteCoords, grid: grid, pipeGrid: pipeGrid, xMin: xBoundMin - 1, xMax: xBoundMax + 1, yMin: yBoundMin - 1, yMax: yBoundMax + 1, zMin: zBoundMin - 1, zMax: zBoundMax + 1, samePen: startingRoom == endingRoom);
	}

	private GameObject CreatePipeLineForPipePath(List<Vector3> pipePath, int indexOverride = -1)
	{
		GameObject gameObject = Object.Instantiate(pipeLinePrefab, constructionHolder);
		LineRenderer component = gameObject.GetComponent<LineRenderer>();
		int num = createdPipeIDs.Count;
		if (indexOverride != -1)
		{
			num = indexOverride;
		}
		float z = startingPipeLineZPos + (float)num * pipeLineZoffset;
		gameObject.transform.position = new Vector3(0f, 0f, z);
		GameObject obj = Object.Instantiate(pipeLinePrefab);
		obj.transform.parent = gameObject.transform;
		obj.transform.localPosition = Vector3.zero + new Vector3(-0.25f, -0.25f, pipeLineZoffset / 2f);
		LineRenderer component2 = obj.GetComponent<LineRenderer>();
		obj.GetComponent<PipeLine>().SetMaterialToBacking();
		component.positionCount = pipePath.Count;
		component2.positionCount = pipePath.Count;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Vector3 pipeLinePosFromPipePathCoords = GetPipeLinePosFromPipePathCoords(pipePath[0]);
		Vector3 pipeLinePosFromPipePathCoords2 = GetPipeLinePosFromPipePathCoords(pipePath[pipePath.Count - 1]);
		for (int i = 0; i < pipePath.Count; i++)
		{
			Vector3 pipeLinePosFromPipePathCoords3 = GetPipeLinePosFromPipePathCoords(pipePath[i]);
			if (i > 0 && pipeLinePosFromPipePathCoords3 == component.GetPosition(num2 - 1))
			{
				num4++;
				continue;
			}
			component.SetPosition(num2, pipeLinePosFromPipePathCoords3);
			component2.SetPosition(num2, pipeLinePosFromPipePathCoords3);
			if (pipeLinePosFromPipePathCoords3 == pipeLinePosFromPipePathCoords2)
			{
				component.positionCount = num2 + 1;
				component2.positionCount = num2 + 1;
				num4 = 0;
				break;
			}
			if (i != 0 && pipeLinePosFromPipePathCoords3 == pipeLinePosFromPipePathCoords)
			{
				num3 = num2;
			}
			num2++;
		}
		if (num3 != 0)
		{
			for (int j = num3; j < component.positionCount; j++)
			{
				component.SetPosition(j - num3, component.GetPosition(j));
				component2.SetPosition(j - num3, component2.GetPosition(j));
			}
			component.positionCount -= num3;
			component2.positionCount -= num3;
		}
		component.positionCount -= num4;
		component2.positionCount -= num4;
		PipeLine component3 = gameObject.GetComponent<PipeLine>();
		component3.SetMaterialIndex(num);
		Vector3 vector = new Vector3(0f, 0f, pipeLineZoffset / 2f);
		component3.CreateCaps(pipeLinePosFromPipePathCoords + vector, pipeLinePosFromPipePathCoords2 + vector);
		return gameObject;
	}

	private Vector3 GetPipeLinePosFromPipePathCoords(Vector3 pipePathCoord)
	{
		Vector3 posForCoords = GetPosForCoords(GetAbsoluteCoordsForGridListCoords(new Vector3Int((int)pipePathCoord.x, (int)pipePathCoord.y, 0)));
		posForCoords.z = 0f;
		return posForCoords;
	}

	private void HandleEndingWallInput()
	{
		if (currentBuildNode != null && GameControls.actions.Interact.WasPressed)
		{
			PipeExpansionNode component = currentBuildNode.GetComponent<PipeExpansionNode>();
			WallBase attachedWall = component.attachedWall;
			endingWall = attachedWall;
			List<Vector3> pipePath = GetPipePath(pipeGhost, startingRoom, endingRoom, startingWall, endingWall, startingLabel, component.label);
			HidePipeGhost();
			if (pipePath.Count == 0)
			{
				SetSubMode(SubMode.STANDARD);
				return;
			}
			endingWall.SetWallState(component.label, enabledVal: false);
			startingWall.SetWallState(startingLabel, enabledVal: false);
			GameObject gameObject = AttachPipeToRooms(startingRoom, startingWall, endingWall, startingLabel, component.label, pipePath);
			ulong num = IndexObject(gameObject, standardPipe);
			List<Vector3Int> gridCells = MarkGridForPipePath(pipePath, num);
			GameObject pipeLine = CreatePipeLineForPipePath(pipePath);
			ulong uID = startingRoom.GetComponent<BuildObjectInfo>().GetUID();
			ulong uID2 = endingRoom.GetComponent<BuildObjectInfo>().GetUID();
			GameObject gameObject2 = Object.Instantiate(pipeFocusNodePrefab);
			GameObject gameObject3 = Object.Instantiate(pipeFocusNodePrefab);
			gameObject2.GetComponent<PipeFocusArrow>().roomToFocus = endingRoom.gameObject;
			gameObject3.GetComponent<PipeFocusArrow>().roomToFocus = startingRoom.gameObject;
			Pipe component2 = gameObject.GetComponent<Pipe>();
			gameObject2.transform.position = component2.GetFirstSegmentEntranceCenter();
			gameObject3.transform.position = component2.GetLastSegmentEntranceCenter();
			gameObject2.transform.rotation = GetRotationForPipeNode(startingWall.wallDirection);
			gameObject3.transform.rotation = GetRotationForPipeNode(endingWall.wallDirection);
			CreatedPipe createdPipe = new CreatedPipe(uID, uID2, startingWall.wallDirection, endingWall.wallDirection, startingLabel, component.label, gameObject, pipePath, gridCells, pipeLine, gameObject2, gameObject3);
			createdPipeIDs.Add(num);
			createdPipes[num] = createdPipe;
			createdObjects[num] = createdPipe.pipeRef;
			navmeshRef.AddPortalForPipe(createdPipe);
			SetSubMode(SubMode.NEW_PIPE);
			AudioController.Play(pipeCompleteSound);
		}
		else
		{
			OnEndingPipeNodeDeselected();
			Vector3Int mousedOverCell = GetMousedOverCell();
			if (mouseOverGridCellTargets.Contains(mousedOverCell))
			{
				OnEndingPipeNodeSelected(gridCellsToNodeDict[mousedOverCell]);
			}
		}
	}

	private void ClearGridForPipePath(List<Vector3Int> path)
	{
		for (int i = 0; i < path.Count; i++)
		{
			pipeGrid[path[i].x][path[i].y][path[i].z] = null;
		}
	}

	private List<Vector3Int> MarkGridForPipePath(List<Vector3> pipePath, ulong pipeID)
	{
		List<Vector3Int> list = new List<Vector3Int>();
		for (int i = 0; i < pipePath.Count; i++)
		{
			int x = (int)pipePath[i].x;
			int y = (int)pipePath[i].y;
			int z = (int)pipePath[i].z;
			MarkGridForPipe(x, y, z, pipeID, list);
		}
		return list;
	}

	private void RebuildPipes()
	{
		try
		{
			for (int i = 0; i < pipesToRebuild.Count; i++)
			{
				if (createdPipes.ContainsKey(pipesToRebuild[i]))
				{
					CreatedPipe pipe = createdPipes[pipesToRebuild[i]];
					RoomBase component = createdObjects[pipe.roomIDStart].GetComponent<RoomBase>();
					RoomBase component2 = createdObjects[pipe.roomIDEnd].GetComponent<RoomBase>();
					WallBase wallForDirection = component.GetWallForDirection(pipe.startingWall);
					WallBase wallForDirection2 = component2.GetWallForDirection(pipe.endingWall);
					ulong uID = pipe.pipeRef.GetComponent<BuildObjectInfo>().GetUID();
					ClearGridForPipePath(pipe.markedGridCells);
					List<Vector3> pipePath = GetPipePath(pipe.pipeRef, component, component2, wallForDirection, wallForDirection2, pipe.startingLabel, pipe.endingLabel);
					if (pipePath.Count == 0)
					{
						DestroyPipe(pipe);
						continue;
					}
					GameObject gameObject = AttachPipeToRooms(component, wallForDirection, wallForDirection2, pipe.startingLabel, pipe.endingLabel, pipePath);
					IndexObject(gameObject, standardPipe, uID);
					navmeshRef.RemovePortalForPipe(pipe.pipeRef);
					Object.Destroy(pipe.pipeRef);
					pipe.pipeRef = gameObject;
					List<Vector3Int> markedGridCells = MarkGridForPipePath(pipePath, uID);
					pipe.pipePath = pipePath;
					pipe.markedGridCells = markedGridCells;
					Pipe component3 = gameObject.GetComponent<Pipe>();
					pipe.focusNodeStart.transform.position = component3.GetFirstSegmentEntranceCenter();
					pipe.focusNodeEnd.transform.position = component3.GetLastSegmentEntranceCenter();
					Object.Destroy(pipe.pipeLineRef);
					pipe.pipeLineRef = CreatePipeLineForPipePath(pipePath, createdPipeIDs.IndexOf(pipesToRebuild[i]));
					CreatedPipe createdPipe = new CreatedPipe(pipe.roomIDStart, pipe.roomIDEnd, pipe.startingWall, pipe.endingWall, pipe.startingLabel, pipe.endingLabel, pipe.pipeRef, pipe.pipePath, pipe.markedGridCells, pipe.pipeLineRef, pipe.focusNodeStart, pipe.focusNodeEnd);
					createdPipes[pipesToRebuild[i]] = createdPipe;
					createdObjects[pipesToRebuild[i]] = createdPipe.pipeRef;
					navmeshRef.AddPortalForPipe(createdPipe);
				}
			}
		}
		finally
		{
			pipesToRebuild.Clear();
		}
	}

	private void DestroyPipe(CreatedPipe pipe, bool playSound = true)
	{
		ulong uID = pipe.pipeRef.GetComponent<BuildObjectInfo>().GetUID();
		navmeshRef.RemovePortalForPipe(pipe.pipeRef);
		Object.Destroy(pipe.pipeRef);
		Object.Destroy(pipe.pipeLineRef);
		Object.Destroy(pipe.focusNodeEnd);
		Object.Destroy(pipe.focusNodeStart);
		for (int i = 0; i < pipe.markedGridCells.Count; i++)
		{
			pipeGrid[pipe.markedGridCells[i].x][pipe.markedGridCells[i].y][pipe.markedGridCells[i].z] = null;
		}
		if (createdRoomIDs.Contains(pipe.roomIDStart))
		{
			createdObjects[pipe.roomIDStart].GetComponent<RoomBase>().GetWallForDirection(pipe.startingWall).SetWallState(pipe.startingLabel, enabledVal: true);
		}
		if (createdRoomIDs.Contains(pipe.roomIDEnd))
		{
			createdObjects[pipe.roomIDEnd].GetComponent<RoomBase>().GetWallForDirection(pipe.endingWall).SetWallState(pipe.endingLabel, enabledVal: true);
		}
		if (createdPipeIDs.Contains(uID))
		{
			createdPipes.Remove(uID);
			createdPipeIDs.Remove(uID);
			createdObjects.Remove(uID);
		}
		navmeshRef.Rebuild();
		if (playSound)
		{
			AudioController.Play(deleteSound);
		}
	}

	private void MarkGridForPipe(int x, int y, int z, ulong pipeID, List<Vector3Int> markedPath)
	{
		if (x >= 0 && y >= 0 && z >= 0 && x < pipeGrid.Count && y < pipeGrid[x].Count && z < pipeGrid[x][y].Count)
		{
			if (x > xBoundMax)
			{
				xBoundMax = x;
			}
			if (x < xBoundMin)
			{
				xBoundMin = x;
			}
			if (y > yBoundMax)
			{
				yBoundMax = y;
			}
			if (y < yBoundMin)
			{
				yBoundMin = y;
			}
			if (z > zBoundMax)
			{
				zBoundMax = z;
			}
			if (z < zBoundMin)
			{
				zBoundMin = z;
			}
			pipeGrid[x][y][z] = pipeID;
			markedPath.Add(new Vector3Int(x, y, z));
		}
	}

	private void MarkGrid(int x, int y, int z, ulong penID, bool clear = false)
	{
		if (x < 0 || y < 0 || z < 0 || x >= grid.Count || y >= grid[x].Count || z >= grid[x][y].Count)
		{
			return;
		}
		if (x > xBoundMax)
		{
			xBoundMax = x;
		}
		if (x < xBoundMin)
		{
			xBoundMin = x;
		}
		if (y > yBoundMax)
		{
			yBoundMax = y;
		}
		if (y < yBoundMin)
		{
			yBoundMin = y;
		}
		if (z > zBoundMax)
		{
			zBoundMax = z;
		}
		if (z < zBoundMin)
		{
			zBoundMin = z;
		}
		if (clear)
		{
			grid[x][y][z] = null;
		}
		else
		{
			grid[x][y][z] = penID;
		}
		if (!clear && pipeGrid[x][y][z].HasValue)
		{
			ulong value = pipeGrid[x][y][z].Value;
			if (!pipesToRebuild.Contains(value))
			{
				pipesToRebuild.Add(value);
			}
		}
		if (clear)
		{
			markedGridCellTexture.SetPixel(x, y, Color.white);
		}
		else
		{
			markedGridCellTexture.SetPixel(x, y, Color.black);
		}
		markedGridCellTexture.Apply();
		constructionPlaneMaterial.SetTexture("_MarkedGridCells", markedGridCellTexture);
	}

	private RoomBase CheckRoomSelect()
	{
		if (mousedOverRoom != null)
		{
			RoomBase roomBase = mousedOverRoom.GetComponent<RoomBase>();
			if (roomBase != null)
			{
				if (!validRoomUIDs.Contains(roomBase.GetComponent<BuildObjectInfo>().GetUID()))
				{
					roomBase = null;
				}
				return roomBase;
			}
		}
		return null;
	}

	private void CheckRoomFocus()
	{
		if (!GameControls.actions.Cancel.IsPressed && mousedOverRoom != null && penFocusRef.IsZoomedOut() && !RaycastUtil.GlobalGUICheck() && !grabberRef.IsHoldingOrHighlightingObject() && mousedOverRoom.GetComponent<RoomBase>() != null)
		{
			HighlightRoomForFocus(mousedOverRoom);
			if (GameControls.actions.Interact.WasPressed)
			{
				FocusRoom(mousedOverRoom);
			}
		}
		else if (roomToFocus != null)
		{
			RemoveHighlightForRoomToFocus();
		}
	}

	public void DisablePipeArrows()
	{
		pipeArrowsEnabled = false;
	}

	public void EnablePipeArrows()
	{
		pipeArrowsEnabled = true;
	}

	private void CheckPipeFocus()
	{
		GameObject gameObject = null;
		if (!GameControls.actions.CameraRotateMode.IsPressed && !GameControls.actions.CameraPanMode.IsPressed && !GameControls.actions.PettingGrabSwap.IsPressed && pipeArrowsEnabled && !grabberRef.IsHoldingOrHighlightingObject() && !grabberRef.IsHoldingDog() && !pettingRef.InPettingMode() && !penFocusRef.FollowCamActive() && !RaycastUtil.GlobalGUICheck() && guiRef.GetGUIInteractiveStatus() && !cursorRef.HasOverrideUIElement())
		{
			Ray ray = Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition());
			int num = RaycastUtil.BuildNodeCastAllNonAlloc(ray, raycastDist, results);
			if (num > 0)
			{
				RaycastHit closestHitIgnoringObjects = RaycastUtil.GetClosestHitIgnoringObjects(num, ray.origin, results, null, allowDisabledRenderers: false);
				if (closestHitIgnoringObjects.transform != null && closestHitIgnoringObjects.transform.gameObject.layer == LayerMask.NameToLayer("BuildNode"))
				{
					gameObject = closestHitIgnoringObjects.transform.root.gameObject;
				}
			}
		}
		if (gameObject != null)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
		}
		if ((mousedOverFocusNode == null && gameObject != null) || (mousedOverFocusNode != null && gameObject != mousedOverFocusNode.gameObject))
		{
			if (mousedOverFocusNode != null)
			{
				mousedOverFocusNode.RemoveHighlight();
			}
			if (gameObject != null)
			{
				mousedOverFocusNode = gameObject.GetComponent<PipeFocusArrow>();
				mousedOverFocusNode.Highlight();
			}
			else
			{
				mousedOverFocusNode = null;
			}
		}
		if (mousedOverFocusNode != null && GameControls.actions.Interact.WasPressed)
		{
			AudioController.Play(pipeArrowPressedSound);
			FocusRoom(mousedOverFocusNode.roomToFocus, playSound: false);
		}
	}

	private void HighlightRoomForFocus(GameObject room)
	{
		if (roomToFocus == room)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			return;
		}
		if (roomToFocus != null)
		{
			RemoveHighlightForRoomToFocus();
		}
		roomToFocus = room;
		Highlighter highlighter = room.GetComponent<Highlighter>();
		if (highlighter == null)
		{
			highlighter = room.AddComponent<Highlighter>();
			highlighter.overlay = true;
		}
		highlighter.ConstantOnImmediate(roomFocusColor);
		cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
	}

	private void RemoveHighlightForRoomToFocus()
	{
		if (!(roomToFocus == null))
		{
			Highlighter component = roomToFocus.GetComponent<Highlighter>();
			if (component != null)
			{
				component.ConstantOffImmediate();
			}
			roomToFocus = null;
		}
	}

	private void HighlightRoomForSelection(GameObject room)
	{
		if (currentHighlightedRoom == room)
		{
			cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
			return;
		}
		if (currentHighlightedRoom != null)
		{
			RemoveHighlightForRoomForSelection();
		}
		currentHighlightedRoom = room;
		ulong uID = room.GetComponent<BuildObjectInfo>().GetUID();
		if (createdIndicators.ContainsKey(uID))
		{
			createdIndicators[uID].Highlight();
		}
		cursorRef.SetCursor(CursorController.CursorType.CLICKABLE);
	}

	private void RemoveHighlightForRoomForSelection()
	{
		if (!(currentHighlightedRoom == null))
		{
			ulong uID = currentHighlightedRoom.GetComponent<BuildObjectInfo>().GetUID();
			if (createdIndicators.ContainsKey(uID))
			{
				createdIndicators[uID].RemoveHighlight();
			}
			currentHighlightedRoom = null;
		}
	}

	public void EnableModularZoom()
	{
		penFocusRef.EnableModularZoom(lastFocusedRoom);
	}

	public void SetLastFocusedRoom(GameObject obj)
	{
		lastFocusedRoom = obj;
	}

	public GameObject GetLastFocusedRoom()
	{
		return lastFocusedRoom;
	}

	public GameObject GetObjectForUID(ulong uid)
	{
		if (createdObjects.TryGetValue(uid, out var value))
		{
			return value;
		}
		return null;
	}

	public BoundingBoxComponent GetObjectBBCForUID(ulong uid)
	{
		if (createdRoomBBCs.TryGetValue(uid, out var value))
		{
			return value;
		}
		return null;
	}

	public bool AnyGravModsActive()
	{
		if (lastGravboostCheckUpdateTime == Time.frameCount)
		{
			return gravboostCheckCachedVal;
		}
		lastGravboostCheckUpdateTime = Time.frameCount;
		for (int i = 0; i < createdRoomIDs.Count; i++)
		{
			if (GetObjectForUID(createdRoomIDs[i]).GetComponent<RoomBase>().IsGravModActive())
			{
				gravboostCheckCachedVal = true;
				return true;
			}
		}
		gravboostCheckCachedVal = false;
		return false;
	}

	public int GetNumberOfCreatedRooms()
	{
		return createdRoomIDs.Count;
	}

	public ulong GetRoomUIDForIndex(int index)
	{
		return createdRoomIDs[index];
	}

	public List<ulong> GetAllRoomIDsExplicitRef()
	{
		return createdRoomIDs;
	}

	public void FocusRoom(GameObject room, bool playSound = true)
	{
		penFocusRef.RequestMoveToTarget(GetRoomFocusPos(room), room.transform.rotation);
		lastFocusedRoom = room;
		penFocusRef.SetLastFocusedRoom(room, refocusAllowed: true, playSound);
		if (roomToFocus != null)
		{
			RemoveHighlightForRoomToFocus();
		}
	}

	public void BuildSpecificRoom(BuildableObject roomToBuild)
	{
		UpdateBuildableObject(roomToBuild);
		SetSubMode(SubMode.NEW_ROOM_BUILDING);
	}

	private void UpdateBuildableObject(BuildableObject newBuildable)
	{
		currentBuildableObject = newBuildable;
		CreateRoomGhost(currentBuildableObject);
	}

	public Vector3 GetRoomFocusPos(GameObject room)
	{
		float y = 9f;
		float z = -15f;
		return room.transform.position + new Vector3(0f, y, z);
	}

	public GameObject GetCollidingPipe(Vector3 pos)
	{
		Vector3 sizeB = Vector3.one * 0.25f;
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			list.Clear();
			list.AddRange(createdPipes[createdPipeIDs[i]].pipeRef.GetComponent<Pipe>().createdSegments);
			for (int j = 0; j < list.Count; j++)
			{
				BoundingBoxComponent boundingBoxComponent = list[j].GetComponent<BoundingBoxComponent>();
				if (boundingBoxComponent == null)
				{
					boundingBoxComponent = list[j].AddComponent<BoundingBoxComponent>();
				}
				if (CheckCollision(boundingBoxComponent.GetBoxCenter(), pos, boundingBoxComponent.GetBoxSize(), sizeB))
				{
					return createdPipes[createdPipeIDs[i]].pipeRef;
				}
			}
		}
		return null;
	}

	private bool CheckCollision(Vector3 posA, Vector3 posB, Vector3 sizeA, Vector3 sizeB)
	{
		return BoundingBoxComponent.CheckBoxBoxIntersect(posA, sizeA / 2f, posB, sizeB / 2f);
	}

	private void CheckMousedOverRooms()
	{
		mousedOverRoom = null;
		if (!cursorRef.IsPassiveModeCursorEnabled() || !RaycastUtil.StageRaycast(Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition()), out var hitInfo, raycastDist))
		{
			return;
		}
		for (int i = 0; i < roomList.Count; i++)
		{
			if (hitInfo.transform.root.gameObject == roomList[i].gameObject)
			{
				mousedOverRoom = hitInfo.transform.root.gameObject;
				break;
			}
		}
	}

	private void CheckMousedOverPipes()
	{
		mousedOverPipe = null;
		int num = RaycastUtil.StageRaycastAllNonAlloc(Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition()), raycastDist, results);
		if (num == 0)
		{
			return;
		}
		float num2 = float.PositiveInfinity;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < createdPipeIDs.Count; j++)
			{
				if (results[i].transform.root.gameObject == createdObjects[createdPipeIDs[j]])
				{
					float distance = results[i].distance;
					if (distance < num2)
					{
						num2 = distance;
						CreatedPipe value = createdPipes[createdPipeIDs[j]];
						mousedOverPipe = value;
					}
				}
			}
		}
	}

	private void HighlightWallIndicator(GameObject node)
	{
		PipeExpansionNode component = node.GetComponent<PipeExpansionNode>();
		WallBase component2 = component.attachedWall.GetComponent<WallBase>();
		int directionLabelHash = GetDirectionLabelHash(component2.wallDirection, component.label);
		if (createdIndicators.ContainsKey(directionLabelHash))
		{
			createdIndicators[directionLabelHash].Highlight();
		}
	}

	private void RemoveWallIndicatorHighlight(GameObject node)
	{
		PipeExpansionNode component = node.GetComponent<PipeExpansionNode>();
		WallDirection wallDirection = component.attachedWall.wallDirection;
		int directionLabelHash = GetDirectionLabelHash(wallDirection, component.label);
		if (createdIndicators.ContainsKey(directionLabelHash))
		{
			createdIndicators[directionLabelHash].RemoveHighlight();
		}
	}

	private void OnStartingPipeNodeSelected(GameObject node)
	{
		currentBuildNode = node;
		if (!(node == null))
		{
			HighlightWallIndicator(node);
		}
	}

	private void OnStartingPipeNodeDeselected()
	{
		if (!(currentBuildNode == null))
		{
			RemoveWallIndicatorHighlight(currentBuildNode);
			currentBuildNode = null;
		}
	}

	private void OnEndingPipeNodeSelected(GameObject node)
	{
		currentBuildNode = node;
		if (!(node == null))
		{
			HighlightWallIndicator(node);
		}
	}

	private void OnEndingPipeNodeDeselected()
	{
		if (!(currentBuildNode == null))
		{
			RemoveWallIndicatorHighlight(currentBuildNode);
			currentBuildNode = null;
		}
	}

	private void OnCellSelected(Vector3Int? cell)
	{
		currentlySelectedCell = cell;
		if (cell.HasValue)
		{
			AttachRoomGhostToCell(cell.Value);
		}
	}

	private void OnCellDeselected(Vector3Int? cell)
	{
		currentlySelectedCell = null;
		if (cell.HasValue)
		{
			HideRoomGhost();
		}
	}

	private void AttachRoomGhostToCell(Vector3Int cell)
	{
		roomGhost.SetActive(value: true);
		Vector3 posForCoords = GetPosForCoords(cell);
		bool flag = roomGhostDimensions.x % 2 == 0;
		roomGhost.transform.position = posForCoords + new Vector3(flag ? gridCellSize : 0f, gridCellSize, 0f) / 2f;
		MarkGridForDraggedRoom();
	}

	private void HideRoomGhost()
	{
		ClearHighlightTexture();
		roomGhost.SetActive(value: false);
	}

	private GameObject AttachPipeToRooms(RoomBase roomA, WallBase wallA, WallBase wallB, ConnectorLabel labelA, ConnectorLabel labelB, List<Vector3> path)
	{
		GameObject gameObject = Object.Instantiate(standardPipe.prefabObject);
		Pipe component = gameObject.GetComponent<Pipe>();
		component.SetEndingFloorInfo(wallB.GetStructureForLabel(labelB).isFloor);
		component.SetStartingFloorInfo(wallA.GetStructureForLabel(labelA).isFloor);
		component.SetEndingPenTopInfo(wallB.GetStructureForLabel(labelB).isTopOfPen);
		component.SetStartingPenTopInfo(wallA.GetStructureForLabel(labelA).isTopOfPen);
		AttachPipeToRoom(gameObject, roomA, wallA, labelA);
		for (int i = 2; i < path.Count; i++)
		{
			if (path[i].x < path[i - 1].x)
			{
				component.segments.Add(Pipe.PipeSegmentType.Left);
			}
			else if (path[i].x > path[i - 1].x)
			{
				component.segments.Add(Pipe.PipeSegmentType.Right);
			}
			else if (path[i].y < path[i - 1].y)
			{
				component.segments.Add(Pipe.PipeSegmentType.Down);
			}
			else if (path[i].y > path[i - 1].y)
			{
				component.segments.Add(Pipe.PipeSegmentType.Up);
			}
			else if (path[i].z < path[i - 1].z)
			{
				component.segments.Add(Pipe.PipeSegmentType.Forward);
			}
			else if (path[i].z > path[i - 1].z)
			{
				component.segments.Add(Pipe.PipeSegmentType.Backward);
			}
		}
		component.segments.Add(component.segments[component.segments.Count - 1]);
		component.CreatePipeSystem();
		return gameObject;
	}

	private Vector3 GetPipePositionForWall(WallBase wall, ConnectorLabel label)
	{
		Vector3Int startingCoordsForRoom = GetStartingCoordsForRoom(wall.attachedRoom.gameObject);
		startingCoordsForRoom = GetAbsoluteCoordsForGridListCoords(startingCoordsForRoom);
		return GetPosForCoords(startingCoordsForRoom + wall.GetStructureForLabel(label).gridCellOffset);
	}

	private void AttachPipeToRoom(GameObject pipe, RoomBase room, WallBase wall, ConnectorLabel label)
	{
		pipe.SetActive(value: true);
		pipe.transform.position = GetPipePositionForWall(wall, label);
		Pipe component = pipe.GetComponent<Pipe>();
		switch (wall.wallDirection)
		{
		case WallDirection.LEFT:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Left };
			break;
		case WallDirection.RIGHT:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Right };
			break;
		case WallDirection.FRONT:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Forward };
			break;
		case WallDirection.BACK:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Backward };
			break;
		case WallDirection.UP:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Up };
			break;
		case WallDirection.DOWN:
			component.segments = new List<Pipe.PipeSegmentType> { Pipe.PipeSegmentType.Down };
			break;
		}
		component.CreatePipeSystem();
	}

	private void HidePipeGhost()
	{
		pipeGhost.SetActive(value: false);
	}

	private ulong IndexObject(GameObject newBuildObject, BuildableObject buildableObjectRef, ulong? existingUID = null)
	{
		BuildObjectInfo buildObjectInfo = newBuildObject.AddComponent<BuildObjectInfo>();
		buildObjectInfo.SetResourceString(buildableManagerRef.GetPathForObject(buildableObjectRef));
		if (existingUID.HasValue)
		{
			buildObjectInfo.SetUID(existingUID.Value);
			return existingUID.Value;
		}
		buildObjectInfo.SetUID(IDCounter);
		IDCounter++;
		return IDCounter - 1;
	}

	private void OnEnterStandardSubMode()
	{
		CreatePenDecorationButtons();
	}

	private void OnEnterNewRoomSelectionSubMode()
	{
		penFocusRef.BlurBG();
	}

	private void OnEnterRoomBuildingSubMode()
	{
		if (GameControls.actions.Interact.IsPressed)
		{
			needsMouseUp = true;
		}
	}

	private void OnEnterNewPipeSubMode()
	{
		SetPipeMode(PipeMode.STARTING_ROOM);
		ClearPipeModeInfos();
	}

	private void OnExitNewPipeSubMode()
	{
		RemoveHighlightForRoomForSelection();
		HidePipeConnections();
		ClearPipeModeInfos();
		ClearAllIndicators();
		HidePipeGhost();
		forcedNodes.Clear();
		guiRef.SetConstructionInstructionVisibility(val: false);
		if (instantiatedStartingPipeCellIndicator != null)
		{
			Object.Destroy(instantiatedStartingPipeCellIndicator);
			instantiatedStartingPipeCellIndicator = null;
		}
	}

	private void OnEnterDestroySubMode()
	{
	}

	private void OnExitDestroySubMode()
	{
		if (mousedOverRoom != null)
		{
			mousedOverRoom.GetComponent<ConstructionObject>().RestoreMaterials();
		}
		if (mousedOverPipe.HasValue && mousedOverPipe.Value.pipeRef != null)
		{
			mousedOverPipe.Value.pipeRef.GetComponent<ConstructionObject>().RestoreMaterials();
		}
	}

	private void OnEnterStartingRoomPipeMode()
	{
		CreateRoomSelectionForPipeIndicators();
		guiRef.SetConstructionInstructionText(ScriptLocalization.GUI.GUI_BUILD_INST_STARTROOM);
	}

	private void OnExitStartingRoomPipeMode()
	{
		ClearAllIndicators();
		RemoveHighlightForRoomForSelection();
	}

	private void OnEnterStartingWallPipeMode()
	{
		ShowPipeConnectionsForRoom(startingRoom);
		CreateWallSelectionForPipeIndicators(startingRoom, isStartingWall: true);
		guiRef.SetConstructionInstructionText(ScriptLocalization.GUI.GUI_BUILD_INST_STARTWALL);
	}

	private void OnExitStartingWallPipeMode()
	{
		ClearAllIndicators();
		HidePipeConnections();
	}

	private void OnEnterEndingRoomPipeMode()
	{
		CreateRoomSelectionForPipeIndicators();
		guiRef.SetConstructionInstructionText(ScriptLocalization.GUI.GUI_BUILD_INST_ENDROOM);
	}

	private void OnExitEndingRoomPipeMode()
	{
		ClearAllIndicators();
		RemoveHighlightForRoomForSelection();
	}

	private void OnEnterEndingWallPipeMode()
	{
		ShowPipeConnectionsForRoom(endingRoom);
		CreateWallSelectionForPipeIndicators(endingRoom, isStartingWall: false);
		guiRef.SetConstructionInstructionText(ScriptLocalization.GUI.GUI_BUILD_INST_ENDWALL);
	}

	private void OnExitEndingWallPipeMode()
	{
		ClearAllIndicators();
		HidePipeConnections();
	}

	private void OnExitStandardSubMode()
	{
		CancelDragRoom();
		DestroyPenDecorationButtons();
		if (mousedOverRoom != null)
		{
			mousedOverRoom.GetComponent<ConstructionObject>().RestoreMaterials();
		}
	}

	private void OnExitNewRoomSelectionSubMode()
	{
		penFocusRef.UnblurBG();
	}

	private void OnExitRoomBuildingSubMode()
	{
		HideRoomGhost();
		HidePipeGhost();
		needsMouseUp = false;
		buildGUIRef.SetPaneType(BuildGUI.PaneType.BASIC);
	}

	private ConnectorLabel GetLabelForGridListCoords(Vector3Int coords, RoomBase room, WallBase wallRef)
	{
		for (int i = 0; i < wallRef.wallStateStructures.Count; i++)
		{
			Vector3 pipePositionForWall = GetPipePositionForWall(wallRef, wallRef.wallStateStructures[i].label);
			if (GetGridListCoordsForAbsoluteCoords(GetCoordsForPos(pipePositionForWall)) == coords)
			{
				return wallRef.wallStateStructures[i].label;
			}
		}
		return ConnectorLabel.NONE;
	}

	private bool CanPlacePipeNode(RoomBase room, WallDirection dir, ConnectorLabel label, Vector3Int coords, bool storeForcedNodes = false)
	{
		if (!room.CanWallActuallyExpand(dir, label))
		{
			return false;
		}
		if (room.GetWallForDirection(dir) == startingWall && label == startingLabel)
		{
			return false;
		}
		coords = GetGridListCoordsForAbsoluteCoords(coords);
		Vector3Int vector3Int = coords;
		switch (dir)
		{
		case WallDirection.LEFT:
			vector3Int.x--;
			break;
		case WallDirection.RIGHT:
			vector3Int.x++;
			break;
		case WallDirection.UP:
			vector3Int.y++;
			break;
		case WallDirection.DOWN:
			vector3Int.y--;
			break;
		case WallDirection.FRONT:
			vector3Int.z--;
			break;
		case WallDirection.BACK:
			vector3Int.z++;
			break;
		}
		int x = vector3Int.x;
		int y = vector3Int.y;
		int z = vector3Int.z;
		if (x >= grid.Count || x < 0 || y >= grid[x].Count || y < 0 || z >= grid[x][y].Count || z < 0)
		{
			return false;
		}
		if (grid[x][y][z].HasValue || pipeGrid[x][y][z].HasValue)
		{
			ulong uID = room.GetComponent<BuildObjectInfo>().GetUID();
			if (!storeForcedNodes || grid[x][y][z] == uID || !grid[x][y][z].HasValue)
			{
				return false;
			}
			RoomBase component = createdObjects[grid[x][y][z].Value].GetComponent<RoomBase>();
			WallBase wallForDirection = room.GetWallForDirection(dir);
			WallDirection opposingWallDirection = wallForDirection.GetOpposingWallDirection();
			wallForDirection = component.GetWallForDirection(opposingWallDirection);
			ConnectorLabel labelForGridListCoords = GetLabelForGridListCoords(vector3Int, component, wallForDirection);
			if (labelForGridListCoords == ConnectorLabel.NONE)
			{
				return false;
			}
			AttachPipeToRoom(pipeGhost, component, wallForDirection, labelForGridListCoords);
			Vector3Int coordsForPos = GetCoordsForPos(pipeGhost.transform.position);
			coordsForPos = GetGridListCoordsForAbsoluteCoords(coordsForPos);
			HidePipeGhost();
			if (coordsForPos != vector3Int)
			{
				return false;
			}
			if (component.CanWallActuallyExpand(opposingWallDirection, labelForGridListCoords))
			{
				ulong uID2 = component.GetComponent<BuildObjectInfo>().GetUID();
				ForcedNode item = new ForcedNode(coords, vector3Int, uID2, opposingWallDirection, labelForGridListCoords);
				forcedNodes.Add(item);
			}
		}
		return true;
	}

	private void CreateWallSelectionForPipeIndicators(RoomBase room, bool isStartingWall)
	{
		if (GetRequiredRoomID().HasValue && forcedNodes.Count > 0 && !isStartingWall)
		{
			ulong uID = room.GetComponent<BuildObjectInfo>().GetUID();
			Vector3 pipePositionForWall = GetPipePositionForWall(startingWall, startingLabel);
			Vector3Int coordsForPos = GetCoordsForPos(pipePositionForWall);
			coordsForPos = GetGridListCoordsForAbsoluteCoords(coordsForPos);
			for (int i = 0; i < forcedNodes.Count; i++)
			{
				if (forcedNodes[i].requiredRoomID == uID && !(forcedNodes[i].startingCoords != coordsForPos))
				{
					GameObject gameObject = Object.Instantiate(cellValidIndicator, constructionHolder);
					Vector3Int endingCoords = forcedNodes[i].endingCoords;
					endingCoords.z = 0;
					endingCoords = GetAbsoluteCoordsForGridListCoords(endingCoords);
					mouseOverGridCellTargets.Add(endingCoords);
					gridCellsToNodeDict[endingCoords] = room.GetNodeForWallDirection(forcedNodes[i].requiredWallDirection, forcedNodes[i].requiredLabel);
					Vector3 posForCoords = GetPosForCoords(endingCoords);
					posForCoords.z = indicatorZCoords;
					gameObject.transform.position = posForCoords;
					int directionLabelHash = GetDirectionLabelHash(forcedNodes[i].requiredWallDirection, forcedNodes[i].requiredLabel);
					createdIndicatorKeys.Add(directionLabelHash);
					createdIndicators[directionLabelHash] = gameObject.GetComponent<ConstructionIndicator>();
				}
			}
			return;
		}
		foreach (WallDirection value in EnumUtils.GetValues<WallDirection>())
		{
			if (!room.DoesWallHaveExpansionPotential(value))
			{
				continue;
			}
			WallBase wallForDirection = room.GetWallForDirection(value);
			for (int j = 0; j < wallForDirection.wallStateStructures.Count; j++)
			{
				Vector3 pipePositionForWall2 = GetPipePositionForWall(wallForDirection, wallForDirection.wallStateStructures[j].label);
				Vector3Int coordsForPos2 = GetCoordsForPos(pipePositionForWall2);
				GameObject gameObject2;
				if (CanPlacePipeNode(room, value, wallForDirection.wallStateStructures[j].label, coordsForPos2, isStartingWall))
				{
					gameObject2 = Object.Instantiate(cellValidIndicator, constructionHolder);
					coordsForPos2.z = 0;
					mouseOverGridCellTargets.Add(coordsForPos2);
					gridCellsToNodeDict[coordsForPos2] = room.GetNodeForWallDirection(value, wallForDirection.wallStateStructures[j].label);
				}
				else
				{
					gameObject2 = Object.Instantiate(cellInvalidIndicator, constructionHolder);
				}
				coordsForPos2.z = 0;
				Vector3 posForCoords2 = GetPosForCoords(coordsForPos2);
				posForCoords2.z = indicatorZCoords;
				gameObject2.transform.position = posForCoords2;
				int directionLabelHash2 = GetDirectionLabelHash(value, wallForDirection.wallStateStructures[j].label);
				createdIndicatorKeys.Add(directionLabelHash2);
				createdIndicators[directionLabelHash2] = gameObject2.GetComponent<ConstructionIndicator>();
			}
		}
	}

	private int GetDirectionLabelHash(WallDirection dir, ConnectorLabel label)
	{
		return dir.ToString().GetHashCode() + label.ToString().GetHashCode();
	}

	private ulong? GetRequiredRoomID()
	{
		ulong? result = null;
		if (forcedNodes.Count > 0)
		{
			for (int i = 0; i < forcedNodes.Count; i++)
			{
				Vector3Int startingCoords = forcedNodes[i].startingCoords;
				Vector3Int? vector3Int = chosenStartingCoords;
				if (startingCoords == vector3Int)
				{
					result = forcedNodes[i].requiredRoomID;
					break;
				}
			}
		}
		return result;
	}

	private void CreateRoomSelectionForPipeIndicators()
	{
		validRoomUIDs.Clear();
		ulong? requiredRoomID = GetRequiredRoomID();
		for (int i = 0; i < createdRoomIDs.Count; i++)
		{
			GameObject gameObject;
			if (requiredRoomID.HasValue)
			{
				if (requiredRoomID == createdRoomIDs[i])
				{
					validRoomUIDs.Add(createdRoomIDs[i]);
					gameObject = Object.Instantiate(roomValidIndicator, constructionHolder);
				}
				else
				{
					gameObject = Object.Instantiate(roomInvalidIndicator, constructionHolder);
				}
			}
			else if (CanAttachPipeToRoom(createdObjects[createdRoomIDs[i]].GetComponent<RoomBase>()))
			{
				validRoomUIDs.Add(createdRoomIDs[i]);
				gameObject = Object.Instantiate(roomValidIndicator, constructionHolder);
			}
			else
			{
				gameObject = Object.Instantiate(roomInvalidIndicator, constructionHolder);
			}
			Vector3 position = createdObjects[createdRoomIDs[i]].transform.position;
			position.z = indicatorZCoords;
			gameObject.transform.position = position;
			createdIndicatorKeys.Add(createdRoomIDs[i]);
			createdIndicators[createdRoomIDs[i]] = gameObject.GetComponent<ConstructionIndicator>();
		}
	}

	private void ClearAllIndicators()
	{
		for (int i = 0; i < createdIndicatorKeys.Count; i++)
		{
			Object.Destroy(createdIndicators[createdIndicatorKeys[i]].gameObject);
		}
		validRoomUIDs.Clear();
		createdIndicators.Clear();
		gridCellsToNodeDict.Clear();
		createdIndicatorKeys.Clear();
		mouseOverGridCellTargets.Clear();
	}

	private void ClearPipeModeInfos()
	{
		endingRoom = null;
		startingRoom = null;
		endingWall = null;
		startingWall = null;
		chosenStartingCoords = null;
		currentHighlightedRoom = null;
	}

	private void SetPipeMode(PipeMode newPipeMode)
	{
		switch (currentPipeMode)
		{
		case PipeMode.STARTING_ROOM:
			OnExitStartingRoomPipeMode();
			break;
		case PipeMode.STARTING_WALL:
			OnExitStartingWallPipeMode();
			break;
		case PipeMode.ENDING_ROOM:
			OnExitEndingRoomPipeMode();
			break;
		case PipeMode.ENDING_WALL:
			OnExitEndingWallPipeMode();
			break;
		}
		switch (newPipeMode)
		{
		case PipeMode.STARTING_ROOM:
			OnEnterStartingRoomPipeMode();
			break;
		case PipeMode.STARTING_WALL:
			OnEnterStartingWallPipeMode();
			break;
		case PipeMode.ENDING_ROOM:
			OnEnterEndingRoomPipeMode();
			break;
		case PipeMode.ENDING_WALL:
			OnEnterEndingWallPipeMode();
			break;
		}
		currentPipeMode = newPipeMode;
	}

	public List<GameObject> GetAllRoomsWithDogs()
	{
		List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.DOG);
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < roomList.Count; i++)
		{
			for (int j = 0; j < allObjectsForTag.Count; j++)
			{
				if (allObjectsForTag[j].GetComponent<BoundingBoxComponent>().GetRoomUID() == roomList[i].GetComponent<BuildObjectInfo>().GetUID())
				{
					list.Add(roomList[i].gameObject);
					break;
				}
			}
		}
		return list;
	}

	public bool StoreRoomUIDForPosition(Vector3 pos, ref ulong UID)
	{
		for (int i = 0; i < roomList.Count; i++)
		{
			if (roomList[i].GetComponent<BoundingBoxComponent>().IsPointInsideBox(pos))
			{
				UID = roomList[i].GetComponent<BuildObjectInfo>().GetUID();
				return true;
			}
		}
		return false;
	}

	public List<GameObject> GetAllRooms()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < roomList.Count; i++)
		{
			list.Add(roomList[i].gameObject);
		}
		return list;
	}

	public bool IsRoom(GameObject obj)
	{
		if ((bool)obj.transform.root.GetComponent<RoomBase>())
		{
			return true;
		}
		return false;
	}

	public bool ShouldObjectFadeOut(GameObject obj)
	{
		if (!IsRoom(obj))
		{
			return false;
		}
		WallBase component = obj.transform.parent.parent.GetComponent<WallBase>();
		if (component == null || !component.canFade)
		{
			return false;
		}
		return true;
	}

	public void OnWallFaded(GameObject pen, WallBase fadedWall)
	{
		_ = fadedWall == null;
	}

	public void OnWallUnfaded(GameObject pen, WallBase unfadedWall)
	{
		_ = unfadedWall == null;
	}

	public void HidePipeConnections()
	{
		for (int i = 0; i < roomList.Count; i++)
		{
			roomList[i].HidePipeConnections();
		}
	}

	public void ShowPipeConnectionsForRoom(RoomBase room)
	{
		room.ShowPipeConnections(pipeExpansionObject);
	}

	public bool CanAttachPipeToRoom(RoomBase room)
	{
		foreach (WallDirection value in EnumUtils.GetValues<WallDirection>())
		{
			WallBase wallForDirection = room.GetWallForDirection(value);
			for (int i = 0; i < wallForDirection.wallStateStructures.Count; i++)
			{
				Vector3 pipePositionForWall = GetPipePositionForWall(wallForDirection, wallForDirection.wallStateStructures[i].label);
				Vector3Int coordsForPos = GetCoordsForPos(pipePositionForWall);
				if (CanPlacePipeNode(room, value, wallForDirection.wallStateStructures[i].label, coordsForPos))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool CanPlaceRoomGhost()
	{
		Vector3Int startingCoordsForRoom = GetStartingCoordsForRoom(roomGhost, roomGhostBoundingBoxSize);
		if (startingCoordsForRoom.x < 0 || startingCoordsForRoom.y < 0)
		{
			return false;
		}
		for (int i = 0; i < roomGhostDimensions.x; i++)
		{
			for (int j = 0; j < roomGhostDimensions.y; j++)
			{
				for (int k = 0; k < roomGhostDimensions.z; k++)
				{
					int num = startingCoordsForRoom.x + i;
					int num2 = startingCoordsForRoom.y + j;
					int num3 = startingCoordsForRoom.z + k;
					if (num >= grid.Count || num2 >= grid[num].Count)
					{
						return false;
					}
					if (num >= 0 && num2 >= 0 && num3 >= 0 && num < grid.Count && num2 < grid[num].Count && num3 < grid[num][num2].Count && grid[num][num2][num3].HasValue)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public void SetConstructionMode(CurrentMode newMode, ulong? roomUID = null, bool playEntrySound = true, bool playExitSound = true)
	{
		switch (currentMode)
		{
		case CurrentMode.STANDARD:
			OnExitStandardMode();
			break;
		case CurrentMode.CONSTRUCTION:
			OnExitConstructionMode(playExitSound);
			break;
		case CurrentMode.PLACEMENT:
			OnExitPlacementMode();
			break;
		}
		currentMode = newMode;
		switch (newMode)
		{
		case CurrentMode.STANDARD:
			OnEnterStandardMode();
			break;
		case CurrentMode.CONSTRUCTION:
			OnEnterConstructionMode(playEntrySound);
			break;
		case CurrentMode.PLACEMENT:
			OnEnterPlacementMode(roomUID.Value, playSounds: true);
			break;
		}
	}

	private void OnEnterStandardMode()
	{
		guiRef.OnPlayMode();
		musicRef.OnExitPlacementBuildingMode();
	}

	private void OnExitStandardMode()
	{
	}

	private void OnEnterConstructionMode(bool playSounds = true)
	{
		if (playSounds)
		{
			musicRef.OnEnterPlacementBuildingMode();
		}
		if (GameControls.actions.Interact.WasPressed)
		{
			requireMouseUp = true;
		}
		if (subMode == SubMode.NONE && playSounds)
		{
			AudioController.Play(buildModeEnterSound);
		}
		pettingRef.SetPettingMode(val: false);
		guiRef.OnBuildMode();
		grabberRef.DisableGrabber(LockReason.CONSTRUCTION_MANAGER);
		SetPipeLines(newValue: true);
		RemoveHighlightForRoomToFocus();
		constructionPlaneRef.SetActive(value: true);
		penFocusRef.OnEnterConstructionMode(playSounds);
		guiRef.SetConstructionInstructionVisibility(val: false, immediate: true);
		SetSubMode(SubMode.STANDARD);
	}

	private void OnExitConstructionMode(bool playSounds = true)
	{
		if (subMode != SubMode.NONE && playSounds)
		{
			AudioController.Play(playModeEnterSound);
		}
		SetSubMode(SubMode.NONE);
		grabberRef.EnableGrabber(LockReason.CONSTRUCTION_MANAGER);
		SetPipeLines(newValue: false);
		penFocusRef.OnExitConstructionMode(playSounds);
		constructionPlaneRef.SetActive(value: false);
	}

	private void SetPipeLines(bool newValue)
	{
		for (int i = 0; i < createdPipeIDs.Count; i++)
		{
			createdPipes[createdPipeIDs[i]].pipeLineRef.SetActive(newValue);
		}
	}

	private void CreatePenDecorationButtons()
	{
		for (int i = 0; i < createdRoomIDs.Count; i++)
		{
			GameObject gameObject = createdObjects[createdRoomIDs[i]];
			GameObject gameObject2 = Object.Instantiate(penDecorationButtonPrefab, constructionHolderCanvasTransform);
			gameObject2.transform.localScale = penDecorationButtonScale;
			ConstructionDecorationInfo component = gameObject2.GetComponent<ConstructionDecorationInfo>();
			component.constructionRef = this;
			component.associatedRoomID = createdRoomIDs[i];
			instantiatedPenDecorationButtons.Add(gameObject2);
			Vector3Int dimensionsForRoom = GetDimensionsForRoom(gameObject);
			dimensionsForRoom = new Vector3Int(dimensionsForRoom.x / 2, dimensionsForRoom.y / 2, dimensionsForRoom.z);
			Vector3Int coords = GetStartingCoordsForRoom(gameObject) + dimensionsForRoom - new Vector3Int(1, 1, 0);
			coords.z = 0;
			coords = GetAbsoluteCoordsForGridListCoords(coords);
			Vector3 position = GetPosForCoords(coords) + new Vector3(gridCellSize, gridCellSize / 2f, 0f);
			if (gameObject.GetComponent<BoundingBoxComponent>().GetBoxSize().x % 2f != 0f)
			{
				position.x -= gridCellSize / 2f;
			}
			position.z = indicatorZCoords;
			gameObject2.transform.position = position;
		}
	}

	private void DestroyPenDecorationButtons()
	{
		for (int i = 0; i < instantiatedPenDecorationButtons.Count; i++)
		{
			Object.Destroy(instantiatedPenDecorationButtons[i]);
		}
		instantiatedPenDecorationButtons.Clear();
	}

	private void CreateGrid()
	{
		constructionPlaneRef = Object.Instantiate(constructionPlanePrefab, Vector3.zero, Quaternion.identity, constructionHolder);
		constructionPlaneMaterial = constructionPlaneRef.GetComponentInChildren<Renderer>().material;
		constructionPlaneRef.SetActive(value: false);
		for (int i = 0; i < gridSizeX * 2; i++)
		{
			grid.Add(new List<List<ulong?>>());
			pipeGrid.Add(new List<List<ulong?>>());
			for (int j = 0; j < gridSizeY * 2; j++)
			{
				grid[i].Add(new List<ulong?>());
				pipeGrid[i].Add(new List<ulong?>());
				for (int k = 0; k < gridSizeZ; k++)
				{
					grid[i][j].Add(null);
					pipeGrid[i][j].Add(null);
				}
			}
		}
	}

	private void CreateGridCellTextures()
	{
		markedGridCellTexture = new Texture2D(grid.Count, grid[0].Count, TextureFormat.ARGB32, mipChain: false);
		markedGridCellTexture.filterMode = FilterMode.Point;
		markedGridCellTexture.wrapMode = TextureWrapMode.Clamp;
		highlightedGridCellTexture = new Texture2D(grid.Count, grid[0].Count, TextureFormat.ARGB32, mipChain: false);
		highlightedGridCellTexture.filterMode = FilterMode.Point;
		highlightedGridCellTexture.wrapMode = TextureWrapMode.Clamp;
		highlightedGridCellTextureEmpty = new Texture2D(grid.Count, grid[0].Count, TextureFormat.ARGB32, mipChain: false);
		highlightedGridCellTextureEmpty.filterMode = FilterMode.Point;
		highlightedGridCellTextureEmpty.wrapMode = TextureWrapMode.Clamp;
	}

	private Vector3Int GetAbsoluteCoordsForGridListCoords(Vector3Int coords)
	{
		return GetAbsoluteCoordsForGridListCoords(coords.x, coords.y, coords.z);
	}

	private Vector3Int GetAbsoluteCoordsForGridListCoords(int x, int y, int z)
	{
		return new Vector3Int(x - gridSizeX, y - gridSizeY, z);
	}

	private Vector3Int GetGridListCoordsForAbsoluteCoords(Vector3Int coords)
	{
		return GetGridListCoordsForAbsoluteCoords(coords.x, coords.y, coords.z);
	}

	private Vector3Int GetGridListCoordsForAbsoluteCoords(int x, int y, int z)
	{
		return new Vector3Int(x + gridSizeX, y + gridSizeY, z);
	}

	private void CreateRoomGhost(BuildableObject ghostObjectType)
	{
		if (roomGhost != null)
		{
			Object.Destroy(roomGhost);
			roomGhost = null;
			roomGhostDimensions = Vector3Int.zero;
			roomGhostBoundingBoxSize = Vector3.zero;
		}
		if (!(ghostObjectType == null))
		{
			roomGhost = Object.Instantiate(ghostObjectType.prefabObject);
			BoundingBoxComponent boundingBoxComponent = roomGhost.GetComponent<BoundingBoxComponent>();
			if (boundingBoxComponent == null)
			{
				boundingBoxComponent = roomGhost.AddComponent<BoundingBoxComponent>();
			}
			roomGhostBoundingBoxSize = boundingBoxComponent.GetBoxSize();
			roomGhostDimensions = GetDimensionsForRoom(roomGhost, null, checkDisabledColliders: true);
			roomGhost.SetActive(value: false);
			Collider[] componentsInChildren = roomGhost.GetComponentsInChildren<Collider>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Object.Destroy(componentsInChildren[i]);
			}
		}
	}

	private void CreatePipeGhost()
	{
		pipeGhost = Object.Instantiate(standardPipe.prefabObject);
		pipeGhost.SetActive(value: false);
	}

	private GameObject CreateNewRoomAtPos(BuildableObject buildableObject, Vector3 pos, ulong? existingUID = null, bool fromLoad = false)
	{
		if (buildableObject == null)
		{
			return null;
		}
		GameObject gameObject = Object.Instantiate(buildableObject.prefabObject);
		RoomBase component = gameObject.GetComponent<RoomBase>();
		component.associatedBuildableObject = buildableObject;
		roomList.Add(component);
		BoundingBoxComponent boundingBoxComponent = gameObject.GetComponent<BoundingBoxComponent>();
		if (boundingBoxComponent == null)
		{
			boundingBoxComponent = gameObject.AddComponent<BoundingBoxComponent>();
		}
		ulong num = IndexObject(gameObject, buildableObject, existingUID);
		PlaceRoomAtPos(gameObject, pos, newRoom: true, !fromLoad);
		createdRoomIDs.Add(num);
		createdObjects[num] = gameObject;
		createdRoomBBCs[num] = boundingBoxComponent;
		toolsPaneRef.UpdateRoomButton();
		if (!fromLoad && !toolsPaneRef.CanPlaceMoreRooms())
		{
			SetSubMode(SubMode.STANDARD);
		}
		return gameObject;
	}

	private void PlaceRoomAtCoords(GameObject room, Vector3Int coords)
	{
		AttachRoomGhostToCell(coords);
		PlaceRoomAtPos(room, roomGhost.transform.position);
	}

	private void PlaceRoomAtPos(GameObject room, Vector3 pos, bool newRoom = false, bool playSound = true)
	{
		List<Rigidbody> list = new List<Rigidbody>();
		Rigidbody[] componentsInChildren = room.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (!rigidbody.isKinematic || !rigidbody.gameObject.activeSelf)
			{
				rigidbody.isKinematic = true;
				rigidbody.gameObject.SetActive(value: false);
				list.Add(rigidbody);
			}
		}
		room.GetComponent<RoomBase>().MovePosition(pos, newRoom);
		for (int j = 0; j < list.Count; j++)
		{
			list[j].isKinematic = false;
			list[j].gameObject.SetActive(value: true);
		}
		list.Clear();
		MarkGridForRoom(room, room.GetComponent<BuildObjectInfo>().GetUID());
		if (playSound)
		{
			AudioController.Play(placeRoomSound);
		}
		navmeshRef.Rebuild();
	}

	private Vector3 GetPosForCoords(int x, int y, int z)
	{
		Vector3 vector = new Vector3(gridCellSize, gridCellSize, gridCellSize) / 2f;
		return new Vector3(x, y, z) * gridCellSize + vector;
	}

	private Vector3 GetPosForCoords(Vector3Int coords)
	{
		return GetPosForCoords(coords.x, coords.y, coords.z);
	}

	private Vector3Int GetCoordsForPos(Vector3 pos)
	{
		Vector3 vector = new Vector3(gridCellSize, gridCellSize, gridCellSize) / 2f;
		Vector3 vector2 = (pos - vector) / gridCellSize;
		return new Vector3Int(Mathf.FloorToInt(vector2.x), Mathf.FloorToInt(vector2.y), Mathf.FloorToInt(vector2.z));
	}

	private Vector3 GetRealSizeForRoom(GameObject room, Vector3? existingSize = null, bool checkDisabledColliders = false)
	{
		Vector3Int dimensionsForRoom = GetDimensionsForRoom(room, existingSize, checkDisabledColliders);
		dimensionsForRoom = new Vector3Int(dimensionsForRoom.x - 2, dimensionsForRoom.y - 2, dimensionsForRoom.z);
		return new Vector3(dimensionsForRoom.x, dimensionsForRoom.y, dimensionsForRoom.z) * gridCellSize;
	}

	private Vector3 GetInflatedSizeForRoom(GameObject room, Vector3? existingSize = null, bool checkDisabledColliders = false)
	{
		Vector3Int dimensionsForRoom = GetDimensionsForRoom(room, existingSize, checkDisabledColliders);
		dimensionsForRoom = new Vector3Int(dimensionsForRoom.x - 4, dimensionsForRoom.y - 3, dimensionsForRoom.z);
		return new Vector3(dimensionsForRoom.x, dimensionsForRoom.y, dimensionsForRoom.z) * gridCellSize;
	}

	private Vector3Int GetDimensionsForRoom(GameObject room, Vector3? existingSize = null, bool checkDisabledColliders = false)
	{
		BuildableObject associatedBuildableObject = room.GetComponent<RoomBase>().associatedBuildableObject;
		if (associatedBuildableObject.useCustomGridSize)
		{
			return associatedBuildableObject.customGridSize;
		}
		Vector3 vector = ((!existingSize.HasValue) ? room.GetComponent<BoundingBoxComponent>().GetBoxSize(checkDisabledColliders) : existingSize.Value);
		int x = Mathf.CeilToInt(vector.x / gridCellSize * 2f) + 2;
		int y = Mathf.CeilToInt(vector.y / gridCellSize * 2f) + 2;
		int z = Mathf.CeilToInt(vector.z / gridCellSize * 2f);
		return new Vector3Int(x, y, z);
	}

	private Vector3Int GetStartingCoordsForRoom(GameObject room, Vector3? boundingBoxSize = null)
	{
		Vector3 position = room.transform.position;
		Vector3 zero = Vector3.zero;
		zero = ((!boundingBoxSize.HasValue) ? GetInflatedSizeForRoom(room) : boundingBoxSize.Value);
		Vector3Int coordsForPos = GetCoordsForPos(new Vector3(position.x - zero.x, position.y - zero.y, 0f));
		return GetGridListCoordsForAbsoluteCoords(coordsForPos);
	}

	private void MarkGridForRoom(GameObject newRoom, ulong roomID, bool clear = false)
	{
		Vector3Int dimensionsForRoom = GetDimensionsForRoom(newRoom);
		Vector3Int startingCoordsForRoom = GetStartingCoordsForRoom(newRoom, newRoom.GetComponent<BoundingBoxComponent>().GetBoxSize());
		for (int i = 0; i < dimensionsForRoom.x; i++)
		{
			for (int j = 0; j < dimensionsForRoom.y; j++)
			{
				for (int k = 0; k < dimensionsForRoom.z; k++)
				{
					int num = startingCoordsForRoom.x + i;
					int num2 = startingCoordsForRoom.y + j;
					int num3 = startingCoordsForRoom.z + k;
					if (num >= 0 && num2 >= 0 && num3 >= 0 && num < grid.Count && num2 < grid[num].Count && num3 < grid[num][num2].Count)
					{
						MarkGrid(num, num2, num3, roomID, clear);
					}
				}
			}
		}
	}

	private void MarkHighlightedGridTexture(Vector3Int dimensions, Vector3Int startingCoords, bool clear = false)
	{
		Color color = Color.black;
		if (clear)
		{
			color = Color.white;
		}
		for (int i = 0; i < dimensions.x; i++)
		{
			for (int j = 0; j < dimensions.y; j++)
			{
				for (int k = 0; k < dimensions.z; k++)
				{
					int num = startingCoords.x + i;
					int num2 = startingCoords.y + j;
					int num3 = startingCoords.z + k;
					if (num >= 0 && num2 >= 0 && num3 >= 0 && num < grid.Count && num2 < grid[num].Count && num3 < grid[num][num2].Count)
					{
						highlightedGridCellTexture.SetPixel(num, num2, color);
					}
				}
			}
		}
		highlightedGridCellTexture.Apply();
		if (!clear && !CanPlaceRoomGhost())
		{
			constructionPlaneMaterial.SetTexture("_HighlightedGridCellsInvalid", highlightedGridCellTexture);
			constructionPlaneMaterial.SetTexture("_HighlightedGridCellsValid", highlightedGridCellTextureEmpty);
		}
		else
		{
			constructionPlaneMaterial.SetTexture("_HighlightedGridCellsValid", highlightedGridCellTexture);
			constructionPlaneMaterial.SetTexture("_HighlightedGridCellsInvalid", highlightedGridCellTexture);
		}
	}

	private void MarkGridForDraggedRoom()
	{
		MarkHighlightedGridTexture(lastHighlightedDimensions, lastHighlightedStartingCoords, clear: true);
		lastHighlightedDimensions = roomGhostDimensions;
		lastHighlightedStartingCoords = GetStartingCoordsForRoom(roomGhost, roomGhostBoundingBoxSize);
		MarkHighlightedGridTexture(lastHighlightedDimensions, lastHighlightedStartingCoords);
	}

	private void ClearHighlightTexture()
	{
		MarkHighlightedGridTexture(lastHighlightedDimensions, lastHighlightedStartingCoords, clear: true);
	}

	private Vector3Int GetMousedOverCell()
	{
		Vector3 position = new Vector3(InputManager.MouseProvider.GetPosition().x, InputManager.MouseProvider.GetPosition().y, 100f);
		Vector3 vector = cameraRef.ScreenToWorldPoint(position);
		Vector3 vector2 = new Vector3(gridCellSize, gridCellSize, gridCellSize) / 2f;
		vector += vector2;
		Vector3Int coordsForPos = GetCoordsForPos(new Vector3(vector.x, vector.y, 0f));
		coordsForPos.z = 0;
		return coordsForPos;
	}
}
