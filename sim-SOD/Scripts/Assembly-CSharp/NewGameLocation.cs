using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class NewGameLocation : Controller
{
	[Serializable]
	public class TrespassEscalation
	{
		public int actor;

		public bool isPlayer;

		public float lastEscalationCheck;

		public float timeEscalation;
	}

	public class ObjectPlacement
	{
		public FurniturePreset.SubObject location;

		public FurnitureLocation furnParent;

		public Interactable existing;

		public Interactable subSpawn;
	}

	public struct ObjectPlace
	{
		public InteractablePreset interactable;

		public Human belongsTo;

		public Human writer;

		public Human receiver;

		public List<Interactable.Passed> passedVars;

		public int security;

		public InteractablePreset.OwnedPlacementRule ownership;

		public int priority;

		public object passedObject;

		public HashSet<NewRoom> dontPlaceInRooms;
	}

	public class Placement
	{
		public NewRoom room;

		public FurnitureLocation furniture;

		public SubObjectClassPreset placementClass;

		public FurniturePreset.SubObject subObject;

		public Interactable subSpawn;

		public float rank;
	}

	[NonSerialized]
	public NewAddress thisAsAddress;

	[NonSerialized]
	public StreetController thisAsStreet;

	public string seed;

	[Header("Location")]
	public DistrictController district;

	public NewBuilding building;

	public NewFloor floor;

	public int residenceNumber;

	public MapAddressButtonController mapButton;

	[Space(7f)]
	public bool isLobby;

	public bool isOutside;

	public bool isCrimeScene;

	public float loggedAsCrimeScene;

	public AddressPreset.AccessType access;

	[Header("Contents")]
	public NewRoom nullRoom;

	public List<NewRoom> rooms;

	public List<NewNode> nodes;

	public List<Actor> currentOccupants;

	public DesignStylePreset designStyle;

	public List<ArtPreset> artPieces;

	public bool placedKey;

	public List<Interactable> securityCameras;

	public List<Interactable> stacks;

	public List<Telephone> telephones;

	public List<Interactable> resetBehaviourObjects;

	public Dictionary<FurnitureClass.OwnershipClass, Dictionary<FurnitureLocation, List<Human>>> furnitureBelongsTo;

	[Header("AI Navigation")]
	public List<NewNode.NodeAccess> entrances;

	[NonSerialized]
	public NewNode.NodeAccess streetAccess;

	public NewNode anchorNode;

	public Dictionary<AIActionPreset, List<Interactable>> actionReference;

	public Dictionary<AIActionPreset, List<Interactable>> nearestPublicActionReference;

	public Dictionary<Actor, TrespassEscalation> escalation;

	public float playerLoiteringTimer;

	[NonSerialized]
	[Header("Evidence")]
	public EvidenceLocation evidenceEntry;

	public List<ObjectPlace> objectsToPlace;

	public bool objectPoolPlaced;

	public void CommonSetup(bool newIsOutside, DistrictController newDistrict, DesignStylePreset newDefaultStyle)
	{
	}

	public void AddNewNode(NewNode newNode)
	{
	}

	public void RemoveNode(NewNode newNode)
	{
	}

	public void AddNewRoom(NewRoom newRoom)
	{
	}

	public void RemoveRoom(NewRoom newRoom)
	{
	}

	public virtual void AddOccupant(Actor newOcc)
	{
	}

	public virtual void RemoveOccupant(Actor remOcc)
	{
	}

	public NewNode.NodeAccess GetMainEntrance()
	{
		return null;
	}

	public void SetDesignStyle(DesignStylePreset newStyle)
	{
	}

	public void AddEntrance(NewNode fromNode, NewNode toNode, bool forceAccessType = false, NewNode.NodeAccess.AccessType forcedAccessType = NewNode.NodeAccess.AccessType.adjacent, bool forceWalkable = false)
	{
	}

	public void RemoveEntrance(NewNode fromNode, NewNode toNode)
	{
	}

	public Interactable PlaceObject(InteractablePreset interactable, Human belongsTo, Human writer, Human reciever, out FurnitureLocation pickedFurn, bool passVariable = false, Interactable.PassedVarType passedVarType = Interactable.PassedVarType.jobID, int passedValue = -1, bool forceSecuritySettings = false, int forcedSecurity = 0, InteractablePreset.OwnedPlacementRule forcedOwnership = InteractablePreset.OwnedPlacementRule.nonOwnedOnly, int forcedPriority = 0, RetailItemPreset retailItem = null, bool printDebug = false, HashSet<NewRoom> dontPlaceInRooms = null, string loadGUID = null, NewNode placeClosestTo = null, string ddsOverride = "", bool ignoreLimits = false)
	{
		pickedFurn = null;
		return null;
	}

	public Interactable PlaceObject(InteractablePreset interactable, Human belongsTo, Human writer, Human receiver, out FurnitureLocation pickedFurn, List<Interactable.Passed> passedVars = null, bool forceSecuritySettings = false, int forcedSecurity = 0, InteractablePreset.OwnedPlacementRule forcedOwnership = InteractablePreset.OwnedPlacementRule.nonOwnedOnly, int forcedPriority = 0, object passedObject = null, bool printDebug = false, HashSet<NewRoom> dontPlaceInRooms = null, string loadGUID = null, NewNode placeClosestTo = null, string ddsOverride = "", bool ignoreLimits = false)
	{
		pickedFurn = null;
		return null;
	}

	public ObjectPlacement GetBestSpawnLocation(InteractablePreset interactable, bool warmItem, Human belongsTo, Human writer, Human receiver, out FurnitureLocation pickedFurn, List<Interactable.Passed> passedVars = null, bool forceSecuritySettings = false, int forcedSecurity = 0, InteractablePreset.OwnedPlacementRule forcedOwnership = InteractablePreset.OwnedPlacementRule.nonOwnedOnly, int forcedPriority = 0, object passedObject = null, bool printDebug = false, HashSet<NewRoom> dontPlaceInRooms = null, string loadGUID = null, NewNode placeClosestTo = null, string ddsOverride = "", bool ignoreLimits = false, bool usePutDownPosition = false)
	{
		pickedFurn = null;
		return null;
	}

	public ObjectPlacement GetPutDownLocation(InteractablePreset interactable, out FurnitureLocation pickedFurn)
	{
		pickedFurn = null;
		return null;
	}

	public void AddToPlacementPool(InteractablePreset interactable, Human belongsTo, Human writer, Human receiver, List<Interactable.Passed> passedVars = null, int security = 0, InteractablePreset.OwnedPlacementRule ownership = InteractablePreset.OwnedPlacementRule.nonOwnedOnly, int priority = 0, object passedObject = null, HashSet<NewRoom> dontPlaceInRooms = null)
	{
	}

	public void PlaceObjects()
	{
	}

	public bool IsPublicallyOpen(bool forPlayer)
	{
		return false;
	}

	public void AddEscalation(Actor actor)
	{
	}

	public int GetAdditionalEscalation(Actor actor)
	{
		return 0;
	}

	public void RemoveEscalation(Actor actor, bool removeAll = false)
	{
	}

	public void AddSecurityCamera(Interactable newInteractable)
	{
	}

	public void SetAsCrimeScene(bool val)
	{
	}

	public virtual bool IsAlarmSystemTarget(Human human)
	{
		return false;
	}

	public virtual bool IsAlarmActive(out float retAlarmTimer, out NewBuilding.AlarmTargetMode retTargetMode, out List<Human> retTargets)
	{
		retAlarmTimer = default(float);
		retTargetMode = default(NewBuilding.AlarmTargetMode);
		retTargets = null;
		return false;
	}

	public virtual bool IsOutside()
	{
		return false;
	}

	public string GetReplicableSeed()
	{
		return null;
	}

	public void ResetLoiteringTimer()
	{
	}

	public void LoiteringPurchase()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveEverything()
	{
	}

	public void RemoveAllInhabitantFurniture(bool removeSkipAddressInhabitantsFurniture, FurnitureClusterLocation.RemoveInteractablesOption spawnedOnFurnitureRemovalOption)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayAccess()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public int GetSQM(bool print = true)
	{
		return 0;
	}

	[Button(null, EButtonEnableMode.Always)]
	public int GetPrice(bool print = true)
	{
		return 0;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetAIActions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void IsThisOutside()
	{
	}

	public bool AllowEmployeeDoors()
	{
		return false;
	}
}
