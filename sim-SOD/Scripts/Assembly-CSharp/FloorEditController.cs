using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorEditController : MonoBehaviour
{
	public enum EditorDisplayMode
	{
		normal = 0,
		displayAddressDesignation = 1,
		displayRoomSelection = 2
	}

	public enum EditorSelectionMode
	{
		tile = 0,
		wall = 1,
		node = 2
	}

	public enum FloorEditTool
	{
		none = 0,
		floorDesignation = 1,
		addressDesignation = 2,
		wallDesignation = 3,
		rotateFloor = 4,
		mainEntrance = 5,
		secondaryEntrance = 6,
		stairwell = 7,
		elevator = 8,
		forceRoom = 9,
		roomDesignation = 10
	}

	[Header("General References")]
	public CityTile cityTile;

	public NewBuilding building;

	public Transform editorFloorParent;

	public GameObject enabledInScrollView;

	public RectTransform toolOptionsWindow;

	public EditorDisplayMode displayMode;

	public EditorSelectionMode selectionModeType;

	public InteractablePreset lightswitchPreset;

	public Transform fakeCitizenHolder;

	public bool heldDown;

	public NewNode heldDownOriginNode;

	public Transform heldDownTransform;

	private int recalculationDelay;

	private string currentRecalculation;

	public bool isSaving;

	public bool loaded;

	[Header("Movement")]
	public bool rightMouse;

	private int selectionLayerMask;

	private int wallsSelectionMask;

	[Header("New Floor")]
	public RectTransform newFloorWindow;

	public TMP_InputField newFloorName;

	public TMP_InputField newFloorSizeX;

	public TMP_InputField newFloorSizeY;

	public TMP_InputField newFloorFloorHeight;

	public TMP_InputField newFloorCeilingHeight;

	[Header("Save As")]
	public RectTransform saveAsFloorWindow;

	public InputField newSaveAsFloorName;

	[Header("Load")]
	public RectTransform loadFloorWindow;

	public TMP_Dropdown loadDropdown;

	private List<string> loadFilePaths;

	[Header("Map")]
	public GameObject mapParent;

	[Header("Current Data")]
	public NewFloor editFloor;

	[Header("Selection")]
	public bool selectionMode;

	public Transform selectionObject;

	public Transform floorSelectCursorObject;

	public Transform wallSelectCursorObject;

	public TextMeshProUGUI statusText;

	public NewTile tileSelection;

	public NewNode nodeSelection;

	public NewWall wallSelection;

	public Vector2 selectionCoord;

	public FloorEditTool tool;

	public List<GameObject> wallTriggers;

	[Header("Tools")]
	public RectTransform floorDesignationOptions;

	public TMP_Dropdown floorDesignationDropdown;

	public NewNode.FloorTileType floorDesignationTypeSelection;

	[Space(5f)]
	public List<Color> editorAddressColours;

	public Material adddressDesignationMaterial;

	public RectTransform addressDesignationOptions;

	public TMP_Dropdown addressDropdown;

	public TMP_Dropdown addressTypeDropdown;

	public NewAddress addressSelection;

	public LayoutConfiguration addressTypeSelection;

	public Image addressDesignationColourImage;

	public Image addressDesignationColourImage2;

	[Space(5f)]
	public RectTransform roomDesignationOptions;

	public TMP_Dropdown roomConfigAddressDropdown;

	public TMP_Dropdown roomConfigsDropdown;

	public TMP_Dropdown roomIDsDropdown;

	public TMP_Dropdown roomLayoutAssignDropdown;

	public NewRoom roomSelection;

	[Space(5f)]
	public RectTransform wallPairsOptions;

	public TMP_Dropdown wallPairsDropdown;

	public DoorPairPreset wallPairPresetSelection;

	[Space(5f)]
	public RectTransform forceRoomOptions;

	public TMP_Dropdown forceRoomDropdown;

	[NonSerialized]
	public RoomConfiguration forceRoomSelection;

	[Space(5f)]
	public Toggle forceBasementToggle;

	[Header("Materials")]
	public Material editorFloorMaterial;

	public Material editorFloorEdgeMaterial;

	public MaterialGroupPreset defaultFloorMaterial;

	public Toolbox.MaterialKey defaultMaterialKey;

	[Header("Scriptable Object Data")]
	public RoomTypePreset nullRoomType;

	private List<RoomTypePreset> allLayoutTypes;

	private List<LayoutConfiguration> allLayouts;

	private List<RoomConfiguration> allRoomConfigs;

	private List<DoorPairPreset> allDoorPairs;

	private List<DoorPairPreset> selectableDoorPairs;

	private List<RoomConfiguration> selectableRooms;

	[Header("Debugging")]
	public Transform debugContainer;

	public GenerationDebugController currentlyDisplayingArea;

	private static FloorEditController _instance;

	public static FloorEditController Instance => null;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void StartGame()
	{
	}

	private void Update()
	{
	}

	private void UpdateStatusText()
	{
	}

	public void SelectNewTile(NewTile newSelect)
	{
	}

	public void SelectNewNode(NewNode newSelect)
	{
	}

	public void SelectNewWall(NewWall newSelect)
	{
	}

	public void SetDisplayMode(EditorDisplayMode newMode)
	{
	}

	public void SetSelectionMode(EditorSelectionMode newMode)
	{
	}

	public void OnPauseChange(bool openDesktopMode)
	{
	}

	public void SetTool(int newTool)
	{
	}

	public void SetTool(FloorEditTool newTool, bool forceRefresh = false)
	{
	}

	public void NewFloorButton()
	{
	}

	public void SaveFloorButton()
	{
	}

	public void SaveAsFloorButton()
	{
	}

	public void EnableSelectionMode(bool val)
	{
	}

	public void LoadFloorButton()
	{
	}

	public void CreateNewFloorTrigger()
	{
	}

	public void CreateNewFloor()
	{
	}

	public void SaveAs()
	{
	}

	public void LoadTrigger()
	{
	}

	public void Load()
	{
	}

	public void RecalculateAllTrigger()
	{
	}

	public void SaveCurrentData(NewFloor data)
	{
	}

	public void OnCompleteSaveData(NewFloor floor, FloorSaveData newSaveData)
	{
	}

	public void LoadData(FloorSaveData savedData)
	{
	}

	public void LoadEditorFloorToWorld()
	{
	}

	public void OnPause()
	{
	}

	public void OnPlay()
	{
	}

	public void OnNewFloorDesignationSetting()
	{
	}

	public void OnNewAddressDesignationSelection()
	{
	}

	public void OnNewAddressDesignationSelection2()
	{
	}

	public void OnNewAddressTypeSelection()
	{
	}

	public void AddNewAddressButton()
	{
	}

	public void RemoveAddress()
	{
	}

	public void OnNewWallDesignationSetting()
	{
	}

	public void OnNewForceRoomSetting()
	{
	}

	public void GenerateAddressLayoutButton()
	{
	}

	public void GenerateAddressDecorButton()
	{
	}

	public void GenerateAddressLayoutAll()
	{
	}

	public void GenerateAddressDecorAll()
	{
	}

	public void RemoveAllForcedRooms()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetAllEntrances()
	{
	}

	public void UpdateAddressDropdowns()
	{
	}

	public void UpdateRoomConfigsDropdown()
	{
	}

	public void OnNewRoomVariationSelection()
	{
	}

	public void UpdateRoomDesignationIDsDropdown()
	{
	}

	public void OnNewRoomSelection()
	{
	}

	public void UpdateRoomLayoutAssignDropdown()
	{
	}

	public void OnAssignNewRoom()
	{
	}

	public void SaveCurrentVariation()
	{
	}

	public void SaveLoadedAddressVariation(NewAddress add)
	{
	}

	public void AddVariationConfiguration()
	{
	}

	public void RemoveVariationConfiguration()
	{
	}

	public void AddRoom()
	{
	}

	public void RemoveRoom()
	{
	}

	public AddressLayoutVariation GetLoadedVariation(NewAddress forAddress)
	{
		return null;
	}
}
