using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class NewRoom : Controller, IComparable<NewRoom>, IEquatable<NewRoom>
{
	[Serializable]
	public class RoomDivider
	{
		public NewRoom fromRoom;

		public NewRoom toRoom;

		public List<NewWall> dividerWalls;
	}

	[Serializable]
	public class LightZoneData
	{
		public class LightNodeRank
		{
			public NewNode node;

			public float rank;
		}

		public NewRoom room;

		public List<NewNode> nodeList;

		public Vector3 centreWorldPosition;

		public Vector3 lightSpawnPosition;

		public Vector2 worldSize;

		public NewNode centreNode;

		public Light spawnedAreaLight;

		public HDAdditionalLightData aAdditional;

		public bool allowLight;

		public bool bestPosFound;

		public List<string> debug;

		public Color areaLightColour;

		public float areaLightBrightness;

		public LightZoneData(NewRoom newRoom, List<NewNode> newNodeList)
		{
		}

		private void FindBestLightPosition()
		{
		}

		public void CreateMainLight()
		{
		}

		public bool CreateAreaLight()
		{
			return false;
		}

		public void RemoveAreaLight()
		{
		}
	}

	public struct StaticBatchKey
	{
		public MeshFilter filter;

		public Mesh mesh;

		public Material mat;

		public bool Equals(StaticBatchKey other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(StaticBatchKey c1, StaticBatchKey c2)
		{
			return false;
		}

		public static bool operator !=(StaticBatchKey c1, StaticBatchKey c2)
		{
			return false;
		}
	}

	public struct PathKey : IEquatable<PathKey>
	{
		public NewNode origin;

		public NewNode destination;

		private bool hasHash;

		private int hash;

		public PathKey(NewNode locOne, NewNode locTwo)
		{
			origin = null;
			destination = null;
			hasHash = false;
			hash = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		bool IEquatable<PathKey>.Equals(PathKey other)
		{
			return false;
		}
	}

	[Serializable]
	public class CullTreeEntry
	{
		public List<int> requiredOpenDoors;

		public CullTreeEntry(List<int> newRequiredDoors)
		{
		}
	}

	public new string name;

	[Header("Location")]
	public NewBuilding building;

	public NewFloor floor;

	public NewGameLocation gameLocation;

	public NewRoom lowerRoom;

	[Header("Room Contents")]
	public int furnitureAssignID;

	public int interactableAssignID;

	public GameObject contentsParent;

	public HashSet<NewNode> nodes;

	public List<RoomConfiguration> openPlanElements;

	public List<NewNode.NodeAccess> entrances;

	public List<RoomDivider> roomDividers;

	public List<LightZoneData> lightZones;

	public Vector3 middleRoomPosition;

	public List<NewRoom> commonRooms;

	public HashSet<Actor> currentOccupants;

	public GameObject streetObjectContainer;

	public HashSet<Interactable> tamperedInteractables;

	public List<NewNode> noAccessNodes;

	public HashSet<Interactable> worldObjects;

	public List<Human.ConversationInstance> activeConversations;

	public List<NewWall> windows;

	public List<AudioController.LoopingSoundInfo> audibleLoopingSounds;

	public Dictionary<FurniturePreset.FurnitureGroup, int> furnitureGroups;

	public List<Interactable> heatSources;

	public List<PipeConstructor.PipeGroup> pipes;

	public List<StateSaveData.ChangedLightswitch> lightswitchOverrides;

	[Header("Details")]
	public int roomFloorID;

	public static int assignRoomFloorID;

	public int roomID;

	public static int assignRoomID;

	public string seed;

	public int assignWallID;

	public RoomTypePreset roomType;

	public RoomConfiguration preset;

	public Vector3 worldPos;

	public bool calculatedWorldPos;

	public Vector2 boundsSize;

	public bool geometryLoaded;

	public bool reachableFromEntrance;

	public bool isOutsideWindow;

	public bool isNullRoom;

	public bool isBaseNullRoom;

	public bool featuresStairwell;

	public bool uniqueCeilingMaterial;

	public bool containsDead;

	public bool decorEdit;

	public bool isVisible;

	public bool musicPlaying;

	public float musicStartedAt;

	[Header("Decor")]
	public bool allowCoving;

	public MaterialGroupPreset floorMaterial;

	public Toolbox.MaterialKey floorMatKey;

	public Material floorMat;

	public MaterialGroupPreset ceilingMaterial;

	public Toolbox.MaterialKey ceilingMatKey;

	public Material ceilingMat;

	public MaterialGroupPreset defaultWallMaterial;

	public Toolbox.MaterialKey defaultWallKey;

	public Material wallMat;

	public bool hasBeenDecorated;

	public Toolbox.MaterialKey miscKey;

	public ColourSchemePreset colourScheme;

	[Header("Lights")]
	public RoomLightingPreset mainLightPreset;

	public bool mainLightStatus;

	public List<NewWall> lightswitches;

	public List<Interactable> lightswitchInteractables;

	public List<Interactable> mainLights;

	public List<Interactable> secondaryLights;

	public bool enabledLights;

	public List<NewWall> windowsWithUVData;

	public int ceilingFans;

	public List<GenerationController.OverrideData> overrideData;

	private bool actorUpdate;

	[Header("Occlusion")]
	public Dictionary<NewRoom, List<CullTreeEntry>> cullingTree;

	public HashSet<int> doorCheckSet;

	public HashSet<NewRoom> nonAudioOccludedRooms;

	public HashSet<NewDoor> openDoors;

	public HashSet<NewDoor> closedDoors;

	public HashSet<NewRoom> adjacentRooms;

	public HashSet<NewRoom> aboveRooms;

	public HashSet<NewRoom> belowRooms;

	public NewRoom atriumTop;

	public List<NewRoom> atriumRooms;

	public GameObject combinedWalls;

	public MeshRenderer combinedWallRend;

	public Dictionary<NewBuilding, GameObject> additionalWalls;

	public GameObject combinedFloor;

	public MeshRenderer combinedFloorRend;

	public GameObject combinedCeiling;

	public MeshRenderer combinedCeilingRend;

	public int ambientSoundLevel;

	private List<CitySaveData.CullTreeSave> ct;

	private List<int> above;

	private List<int> below;

	private List<int> adj;

	private List<int> occ;

	[Header("Furniture")]
	public List<FurnitureClusterLocation> furniture;

	public List<FurnitureLocation> individualFurniture;

	private Dictionary<StaticBatchKey, List<GameObject>> staticBatchDictionary;

	public List<Mesh> staticBatchedGeneratedMeshes;

	[NonSerialized]
	public Dictionary<FurnitureClass, List<FurniturePreset>> pickFurnitureCache;

	[NonSerialized]
	public Dictionary<Vector3, NewNode> localizedRoomNodeMaps;

	[Header("Footprints")]
	public bool footprintUpdateQueued;

	public List<FootprintController> spawnedFootprints;

	[Header("AI Navigation")]
	public Dictionary<NewNode, List<NewNode>> blockedAccess;

	public Dictionary<AIActionPreset, List<Interactable>> actionReference;

	public Dictionary<InteractablePreset.SpecialCase, List<Interactable>> specialCaseInteractables;

	[Header("Ownership")]
	private List<int> loadBelongsTo;

	public List<Human> belongsTo;

	[Header("Exploration")]
	[Tooltip("Is this room shown on the map?")]
	public int explorationLevel;

	public List<RectTransform> mapDoors;

	[Header("Air Vents")]
	public List<AirDuctGroup.AirVent> airVents;

	public List<AirDuctGroup> ductGroups;

	[Header("Passwords")]
	public GameplayController.Passcode passcode;

	[Header("Crime Scene Elements")]
	public List<SpatterSimulation> spatter;

	[Header("Environment")]
	public List<Interactable> steamControllingInteractables;

	public bool steamOn;

	public float steamLastSwitched;

	public SteamController steamController;

	public List<BugController> spawnedBugs;

	public float gasLevel;

	public float lastRoomGassed;

	[Header("Debug")]
	public GenerationDebugController debugController;

	public Action UpdateEmission;

	public bool completedTreeCull;

	public List<string> debugLightswitches;

	public int cullingDebugLoadReference;

	private List<CullingDebugController> spawnPathDebug;

	public string debugCulling;

	public NewRoom specificRoomCullingDebug;

	public bool loadedCullTreeFromSave;

	public List<InteractableController> mainLightObjects;

	public List<string> debugDecor;

	private List<GameObject> exteriorWindowDebug;

	private List<GameObject> nodeDebug;

	public List<string> debugAddActions;

	public string clustersPlaced;

	public string itemsPlaced;

	public int poolSizeOnPlacement;

	public string palcementKey1;

	public string palcementKey2;

	public string palcementKey3;

	public string palcementKey4;

	public string palcementKey5;

	public string palcementKey51;

	public string palcementKey52;

	public string palcementKey6;

	public string keyAtStart;

	[Space(7f)]
	private GameObject sublocationParent;

	private List<GameObject> sublocationDebugObjects;

	bool IEquatable<NewRoom>.Equals(NewRoom other)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public Color GetShadowTint(Color lightColour, float intensity)
	{
		return default(Color);
	}

	public void SetupLayoutOnly(NewGameLocation newAddress, RoomTypePreset newRoomType, int loadFloorRoomID = -1)
	{
	}

	public void SetupAll(NewGameLocation newAddress, RoomConfiguration newPreset, int loadFloorRoomID = -1)
	{
	}

	public void SetConfiguration(RoomConfiguration newPreset)
	{
	}

	public void SetType(RoomTypePreset newRoomType)
	{
	}

	public void Load(CitySaveData.RoomCitySave data, NewGameLocation newGameLoc)
	{
	}

	public void LoadCullingTree()
	{
	}

	public void UpdateColourSchemeAndMaterials()
	{
	}

	public void AddNewNode(NewNode newNode)
	{
	}

	public string GetName()
	{
		return null;
	}

	public void SetRoomName()
	{
	}

	public void RemoveNode(NewNode newNode)
	{
	}

	public void UpdateWorldPositionAndBoundsSize()
	{
	}

	public void AddOpenPlanElement(RoomConfiguration newElement)
	{
	}

	public void SetFloorMaterial(MaterialGroupPreset newMat, MaterialGroupPreset.MaterialVariation newVar, bool getNewKey = true, bool getMaterial = true)
	{
	}

	public void SetCeilingMaterial(MaterialGroupPreset newMat, MaterialGroupPreset.MaterialVariation newVar, bool getNewKey = true, bool getMaterial = true)
	{
	}

	public void SetWallMaterialDefault(MaterialGroupPreset newMat, MaterialGroupPreset.MaterialVariation newVar, bool getNewKey = true, bool getMaterial = true)
	{
	}

	public void ToggleMainLights(Actor actor = null)
	{
	}

	public void SetMainLights(bool newVal, string debug, Actor actor = null, bool forceInstant = false, bool forceUpdate = false)
	{
	}

	public void SetSecondaryLight(bool newVal, bool forceUpdate = false)
	{
	}

	public void UpdateEmissionEndOfFrame()
	{
	}

	public void UpdateEmissionTex()
	{
	}

	public void AddMainLight(Interactable newLight)
	{
	}

	public void AddSecondaryLight(Interactable newLight)
	{
	}

	public void AddEntrance(NewNode fromNode, NewNode toNode, bool forceAccessType = false, NewNode.NodeAccess.AccessType forcedAccessType = NewNode.NodeAccess.AccessType.adjacent, bool forceWalkable = false)
	{
	}

	public void RemoveEntrance(NewNode fromNode, NewNode toNode)
	{
	}

	public void SetVisible(bool val, bool forceUpdate, bool immediateLoad = false, bool immediatelyLoadStuff = true)
	{
	}

	public void LoadRoomStuff(bool immediateLoad = false)
	{
	}

	public void AddForStaticBatching(FurnitureLocation loc)
	{
	}

	public void AddForStaticBatching(GameObject obj, MeshFilter objectFilter, Mesh objectMesh, Material objectMat)
	{
	}

	public void ExecuteStaticBatching()
	{
	}

	public void QueueFootprintUpdate()
	{
	}

	public void UpdateFootprints(bool forceRemoveAll = false)
	{
	}

	public void EnableLight(bool val)
	{
	}

	public void ConnectNodes()
	{
	}

	public void ApplyBlockedAccess()
	{
	}

	public void GenerateCullingTree(bool debugMode = false)
	{
	}

	private void SpawnDebugCullingObject(Vector3 worldPos, NewRoom room, NewNode.NodeAccess parentEntrance, List<int> depDoors, CullingDebugController.CullDebugType newType, NewRoom atriumTopOf = null, NewNode.NodeAccess otherEntrance = null)
	{
	}

	public void SetLowerRoom(NewRoom newRoom)
	{
	}

	public void AddOccupant(Actor newOcc)
	{
	}

	public void RemoveOccupant(Actor remOcc)
	{
	}

	public void AddFurniture(FurnitureClusterLocation newFurn, bool generateNew, bool addPathBlocking = true, bool immediateSpawn = false, bool ignoreLimitations = false, DesignStylePreset styleOverride = null)
	{
	}

	public FurnitureLocation AddFurnitureCustom(PlayerApartmentController.FurniturePlacement newPlacement)
	{
		return null;
	}

	public FurnitureLocation AddFurnitureCustom(FurnitureLocation newPlacement)
	{
		return null;
	}

	public void AddFurnitureBlockedAccess(FurnitureLocation obj)
	{
	}

	public void AddCustomNodeWeights(FurnitureLocation obj)
	{
	}

	private void AddFOVBlock(FurnitureLocation obj)
	{
	}

	public bool AddRandomAirVent(NewAddress.AirVent ventType)
	{
		return false;
	}

	private void LoadVent(AirDuctGroup.AirVent vent)
	{
	}

	public void AddDuctGroup(AirDuctGroup newGroup)
	{
	}

	public void AddOwner(Human newOwner)
	{
	}

	public void LoadOwners()
	{
	}

	public void PickPassword()
	{
	}

	public void SetupEnvrionment()
	{
	}

	public void SetExplorationLevel(int newLevel)
	{
	}

	public bool TestForDynamicShadowsUpdate()
	{
		return false;
	}

	public int CompareTo(NewRoom otherObject)
	{
		return 0;
	}

	public CitySaveData.RoomCitySave GenerateSaveData()
	{
		return null;
	}

	public NewNode GetRandomNode()
	{
		return null;
	}

	public NewNode GetRandomEntranceNode()
	{
		return null;
	}

	public bool IsAccessAllowed(Human human)
	{
		return false;
	}

	public void RemoveAllInhabitantFurniture(bool removeSkipAddressInhabitantsFurniture, FurnitureClusterLocation.RemoveInteractablesOption spawnedOnFurnitureRemovalOption)
	{
	}

	public void SetSteam(bool val)
	{
	}

	public bool IsOutside()
	{
		return false;
	}

	public List<NewRoom> GetAdjacentRooms()
	{
		return null;
	}

	public List<NewRoom> GetAboveRooms()
	{
		return null;
	}

	public List<NewRoom> GetBelowRooms()
	{
		return null;
	}

	public List<NewRoom> GetAboveAndBelowRooms()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplaySublocations()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveSublocationsDisplay()
	{
	}

	[Button("Teleport Player", EButtonEnableMode.Always)]
	public void DebugTeleportPlayerToLocation()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugCullingDisplay()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetMainLightData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleExteriorWindowDebug()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TestFurniturePlacementBlockingCheck()
	{
	}

	[Button("Test Furniture Placement Blocking Check (Ignore No Passthrough)", EButtonEnableMode.Always)]
	public void TestFurniturePlacementBlockingCheckIgnoreNoPassthrough()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayNodePositions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveNodePositions()
	{
	}

	public int GetWallCount()
	{
		return 0;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetAIActions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetInteractables()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListContainedInteractables()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListActionReferences()
	{
	}

	public SessionData.SceneProfile GetEnvironment()
	{
		return default(SessionData.SceneProfile);
	}

	public void AddGas(float amount)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RebuildCullingTree()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void IsThisOutside()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnModularRoomElements()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListLoadedFurniture()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UnloadRoomGeometry()
	{
	}

	public bool GetSecondaryLightStatus()
	{
		return false;
	}

	public void UnloadRoomGeometry(int spawnedRoomIndex, bool despawnObjects = true)
	{
	}

	public int GetMeshGenerationCachePriority()
	{
		return 0;
	}

	public int GetRoomCullingCachePriority()
	{
		return 0;
	}

	public void ExecuteLightswitchesOverrides()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListCurrentOccupants()
	{
	}
}
