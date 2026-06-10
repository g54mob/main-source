using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "furnitureclass_data", menuName = "Database/Decor/Furniture Class")]
public class FurnitureClass : SoCustomComparison
{
	public enum FurnitureRuleOption
	{
		mustFeature = 0,
		cantFeature = 1,
		canFeature = 2
	}

	public enum WallRule
	{
		nothing = 0,
		wall = 1,
		window = 2,
		windowLarge = 3,
		entrance = 4,
		ventUpper = 5,
		ventLower = 6,
		wallOrUpperVent = 7,
		ventTop = 8,
		entranceDoorOnly = 9,
		entranceToRoomOfType = 10,
		anyWindow = 11,
		entraceDivider = 12,
		securityDoorDivider = 13,
		fence = 14,
		addressEntrance = 15,
		lightswitch = 16
	}

	[Serializable]
	public class FurniureWalkSubLocations
	{
		[Tooltip("This rule is applied at this offset")]
		public Vector2 offset;

		public List<Vector3> sublocations;
	}

	[Serializable]
	public class FurnitureNodeRule
	{
		[Tooltip("This rule is applied at this offset")]
		public Vector2 offset;

		[Tooltip("Type of rule to apply")]
		public FurnitureRuleOption option;

		public bool anyOccupiedTile;

		[HideIf("anyOccupiedTile")]
		[Tooltip("What should be found at this node?")]
		public FurnitureClass furnitureClass;

		[Tooltip("If 'Can Feature' add this to the location score")]
		[Range(-10f, 10f)]
		public int addScore;
	}

	[Serializable]
	public class FurnitureWallRule
	{
		[Tooltip("This rule is applied at this offset")]
		public Vector2 nodeOffset;

		[Tooltip("This rule is applied at this offset")]
		public CityData.BlockingDirection wallDirection;

		[Tooltip("Type of rule to apply")]
		public FurnitureRuleOption option;

		[Tooltip("What should be found at this offset?")]
		public WallRule tag;

		[Tooltip("If the tag is 'room to'")]
		public RoomConfiguration roomType;

		[Tooltip("If 'Can Feature' add this to the location score")]
		[Range(-10f, 10f)]
		public int addScore;
	}

	[Serializable]
	public class BlockedAccess
	{
		public bool disabled;

		public Vector2 nodeOffset;

		[Tooltip("Block diagonals on adjacent tiles")]
		public bool blockExteriorDiagonals;

		public List<CityData.BlockingDirection> blocked;
	}

	[Serializable]
	public class CustomNodeWeighting
	{
		public bool disabled;

		public Vector2 nodeOffset;

		public float nodeWeightModifier;
	}

	[Serializable]
	public class SubObject
	{
		public SubObjectClassPreset preset;

		public string parent;

		public Vector3 localPos;

		public Vector3 localRot;
	}

	public enum OwnershipClass
	{
		none = 0,
		bed = 1,
		desk = 2,
		locker = 3,
		drawers = 4,
		noticeBoard = 5,
		safe = 6,
		mailboxes = 7
	}

	public enum OwnershipSource
	{
		addressInhabitants = 0,
		buildingResidences = 1
	}

	[Header("Rules")]
	[Tooltip("List of rules this furniture must follow")]
	public List<FurnitureWallRule> wallRules;

	[Space(7f)]
	[Tooltip("List of rules this furniture must follow")]
	public List<FurnitureNodeRule> nodeRules;

	[Space(7f)]
	[Tooltip("Which points between nodes are blocked (no walking access)")]
	public List<BlockedAccess> blockedAccess;

	[Space(7f)]
	[Tooltip("Add a custom node weight to these nodes")]
	public List<CustomNodeWeighting> customNodeWeights;

	[OnValueChanged("UpdatePreCalculatedLimits")]
	[Header("PreCalculated Limits")]
	public bool updatePreCalculated;

	[ReadOnly]
	public int minimumZeroNodeWallCount;

	[ReadOnly]
	public int maximumZeroNodeWallCount;

	[Header("Behaviour")]
	[Tooltip("If true, face the furniture diagonally if in corner")]
	public bool canFaceDiagonally;

	[Space(7f)]
	[Tooltip("Maximum number per room")]
	public bool limitPerRoom;

	[EnableIf("limitPerRoom")]
	[Range(1f, 20f)]
	public int maximumNumberPerRoom;

	[Tooltip("Maximum number per address")]
	public bool limitPerAddress;

	[EnableIf("limitPerAddress")]
	[Range(1f, 20f)]
	public int maximumNumberPerAddress;

	[Tooltip("Allow only on this floor")]
	public bool limitToFloor;

	[EnableIf("limitToFloor")]
	public int allowedOnFloor;

	[DisableIf("limitToFloor")]
	[Tooltip("Allow only on this range")]
	public bool limitToFloorRange;

	[EnableIf("limitToFloorRange")]
	public Vector2 allowedOnFloorRange;

	public bool limitPerBuildingResidence;

	[EnableIf("limitPerBuildingResidence")]
	[Tooltip("Limit to 1 per below number of residences in the building")]
	public int perBuildingResidences;

	public bool limitPerJobs;

	[Tooltip("Limit to 1 per below number of residences in the building")]
	[EnableIf("limitPerJobs")]
	public int perJobs;

	[Space(7f)]
	[Tooltip("Must be at least this distance (nodes) from these classes...")]
	public List<FurnitureClass> awayFromClasses;

	[Tooltip("Minimum node distance from these classes. A diagonal is about 1.8")]
	public float minimumNodeDistance;

	[Header("Visuals")]
	public Vector2 objectSize;

	[Tooltip("If true this would cover up items on the wall such as lightswitches or block windows")]
	public bool tall;

	[Tooltip("Use the corresponding wall rules to place wall pieces")]
	public bool wallPiece;

	[Tooltip("If being placed in decor mode, snap to nearby walls")]
	[HideIf("wallPiece")]
	public bool useWallSnappingInDecorMode;

	[Tooltip("Allow one of these per window")]
	public bool windowPiece;

	[Tooltip("Does this block the placement of other furniture (if this flag is true on them also)?")]
	public bool occupiesTile;

	[Tooltip("If this furniture allowed on stairwell tiles?")]
	public bool allowedOnStairwell;

	[ShowIf("allowedOnStairwell")]
	public bool onlyOnStairwell;

	[Tooltip("Determins allowed if no floor")]
	public bool allowIfNoFloor;

	[Tooltip("Is this a ceiling piece?")]
	public bool ceilingPiece;

	[Tooltip("Does this require a ceiling above it?")]
	[DisableIf("ceilingPiece")]
	public bool requiresCeiling;

	[Tooltip("Does this block ceiling pieces from being placed?")]
	public bool blocksCeiling;

	[Tooltip("This is allowed to be placed if there is a lightswitch on this tile")]
	public bool allowLightswitch;

	[EnableIf("allowLightswitch")]
	[Tooltip("If a lightswitch exists here, raise the height slightly")]
	public bool raiseLightswitch;

	[EnableIf("raiseLightswitch")]
	public float lightswitchYOffset;

	[Tooltip("If true this object doesn't need access and won't ever block anything; use on minor objects to optimize placement checks")]
	[Header("AI")]
	public bool noBlocking;

	[Tooltip("If true the AI can access this node, but not pass through it on the way to something else. Can be used for 1 node items such as tables where you can't normally block access. IMPORTANT: Usually true if all but 1-3 directions are blocked.")]
	public bool noPassThrough;

	[Tooltip("If true the AI can't access this node, this node is effectively exluded from access checks. IMPORTANT: Make sure this is enabled if all directions are blocked.")]
	public bool noAccessNeeded;

	[Tooltip("If true then default sublocations will be blocked completely (usually they are added if there are no custom ones on a node). Default sublocations will be used if there are no custom ones, and there is no furniture class with a blocking flag.")]
	public bool blockDefaultSublocations;

	[Tooltip("If true then the physics check will ignore colliders that are not citizens")]
	public bool ignoreGeometryInPhysicsCheck;

	[Tooltip("These will be added to the tile's sublocations")]
	public List<FurniureWalkSubLocations> sublocations;

	[Tooltip("If the AI is robbing a location, use this to compare the likihood of valuable contents...")]
	[Range(0f, 10f)]
	public int aiRobberyPriority;

	public bool isSecurityCamera;

	[Header("Ownership")]
	[Tooltip("Dictates what class of ownership (ie each person living here needs 1 bed)")]
	public OwnershipClass ownershipClass;

	[Tooltip("From where does this derrive the owners pool?")]
	public OwnershipSource ownershipSource;

	[Tooltip("Assign owners to this furniture")]
	public int assignBelongsToOwners;

	[Tooltip("If this is checked the game will assign this object to a couple")]
	public bool preferCouples;

	[Tooltip("If this is true, the object will try to copy ownership from previously placed items in the cluster")]
	public bool copyFromPreviouslyPlacedInCluster;

	[Tooltip("If this is true, this will only pick from the owners of the room (if there are any)")]
	public bool onlyPickFromRoomOwners;

	[Tooltip("Skip placement of this if there are no address owners")]
	public bool skipIfNoAddressInhabitants;

	[Tooltip("Assign homeless owners")]
	public bool assignHomelessOwners;

	[Tooltip("Make sure ownership is only assigned if mailbox not already assigned to an apartment")]
	public bool assignMailbox;

	[Tooltip("Don't allow mission photographs on this furniture")]
	public bool discourageMissionPhotos;

	[Header("Copy")]
	public FurnitureClass copyFrom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyBlockedAccess()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopySublocations()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void BlockSolid()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void BlockAllButFront()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdatePreCalculatedLimits()
	{
	}
}
