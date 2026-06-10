using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "furniturecluster_data", menuName = "Database/Decor/Furniture Cluster")]
public class FurnitureCluster : SoCustomComparison
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
		wallNoDoor = 1,
		onlyWall = 2,
		doorway = 3,
		door = 4,
		bannister = 5,
		window = 6
	}

	public enum FurnitureFacing
	{
		down = 0,
		up = 1,
		left = 2,
		right = 3
	}

	public enum AllowedOpenPlan
	{
		yes = 0,
		no = 1,
		openPlanOnly = 2
	}

	[Serializable]
	public class FurnitureClusterRule
	{
		[Tooltip("Only consider this if the last object got placed")]
		public bool onlyValidIfPreviousObjectPlaced;

		[Tooltip("If not able to be placed at the above, scan list of alternates at random to find a valid position")]
		public List<Vector2> placements;

		[Tooltip("What should be found at this node?")]
		public FurnitureClass furnitureClass;

		public FurnitureFacing facing;

		[Tooltip("If cannot be place here, this cluster placement is invalid")]
		public bool importantToCluster;

		[DisableIf("importantToCluster")]
		[Range(0f, 1f)]
		[Tooltip("Chance this placement will be attempted: Done on a per-location basis, so often a lower number will result in a much lower placement count...")]
		public float chanceOfPlacementAttempt;

		public int placementScoreBoost;

		[Tooltip("Block objects in this path")]
		public bool useFovBlock;

		[Tooltip("The FOV block will continue in this direction, this is before direction is applied, so 0,1 is infront for example.")]
		public Vector2 blockDirection;

		public int maxFOVBlockDistance;

		[Tooltip("Local scale")]
		public Vector3 localScale;

		[Tooltip("Offset")]
		public Vector3 positionOffset;
	}

	public bool disable;

	[Header("Rules")]
	[Tooltip("List of rules this furniture must follow")]
	public List<FurnitureClusterRule> clusterElements;

	[Range(0f, 1f)]
	[Tooltip("Chance for skipping this cluster altogether")]
	[Header("Suitability")]
	public float placementChance;

	[Range(0f, 11f)]
	[Tooltip("The ranking given to this item when choosing what to place.")]
	public float roomPriority;

	[Tooltip("Modify priority with traits present. The base chance here is x10 and added to the above room priority.")]
	public List<CharacterTrait.TraitPickRule> modifyPriorityTraits;

	[Tooltip("Modify placement chance with traits present. The base chance here is x10 and added to the above placement chance.")]
	public List<CharacterTrait.TraitPickRule> modifyPlacementChanceTraits;

	[Space(7f)]
	[Tooltip("If true this will override priority with 10 unless one already exists")]
	public bool essentialFurniture;

	[Header("PreCalculated Limits/Optimization")]
	[OnValueChanged("UpdatePreCalculatedLimits")]
	public bool updatePreCalculated;

	[ReadOnly]
	public int calculatedMinRoomSize;

	[ReadOnly]
	public int minimumZeroNodeWallCount;

	[ReadOnly]
	public int maximumZeroNodeWallCount;

	[ReadOnly]
	public List<FurnitureClass> zeroNodeClasses;

	[Tooltip("Room must be at least this size")]
	[Header("Custom Limits/Optimization")]
	public int minimumRoomSize;

	public bool useMaximumRoomSize;

	[EnableIf("useMaximumRoomSize")]
	public int maximumRoomSize;

	[Space(7f)]
	public bool useCustomZeroNodeMinWallCount;

	[EnableIf("useCustomZeroNodeMinWallCount")]
	[Range(0f, 4f)]
	public int customZeroNodeMinWallCount;

	public bool useCustomZeroNodeMaxWallCount;

	[Range(0f, 4f)]
	[EnableIf("useCustomZeroNodeMaxWallCount")]
	public int customZeroNodeMaxWallCount;

	public List<FurnitureClass.FurnitureWallRule> zeroNodeWallRules;

	[Space(7f)]
	[Tooltip("Is this allowed in open plan rooms?")]
	public AllowedOpenPlan allowedInOpenPlan;

	[Space(7f)]
	public bool allowInResidential;

	public bool allowInCompanies;

	public bool allowOnStreets;

	[Tooltip("This is only to be placed on coastal streets")]
	public bool coastalOnly;

	[Space(7f)]
	[Tooltip("Only allow this in certain districts")]
	public bool limitToDistricts;

	[EnableIf("limitToDistricts")]
	public List<DistrictPreset> allowedInDistricts;

	public bool banFromDistricts;

	[EnableIf("banFromDistricts")]
	public List<DistrictPreset> notAllowedInDistricts;

	[Space(7f)]
	[Tooltip("Skip placement of this if there are no address owners")]
	public bool skipIfNoAddressInhabitants;

	[EnableIf("skipIfNoAddressInhabitants")]
	[Tooltip("If the above is true, will only be skipped if this is a residence or company")]
	public bool onlySkipNoInhabitantsIfResidenceOrCompany;

	[EnableIf("skipIfNoAddressInhabitants")]
	[Tooltip("If the above is true, don't skip if within addresses of this type")]
	public List<RoomClassPreset> dontSkipNoInhabitantsIfIn;

	[Space(7f)]
	public List<RoomTypeFilter> allowedRoomFilters;

	[Tooltip("Maximum number per room")]
	[Space(7f)]
	public bool limitPerRoom;

	[Range(1f, 20f)]
	[EnableIf("limitPerRoom")]
	public int maximumPerRoom;

	[Tooltip("Maximum number per address")]
	public bool limitPerAddress;

	[EnableIf("limitPerAddress")]
	[Range(1f, 20f)]
	public int maximumPerAddress;

	[Tooltip("Allow only on this floor")]
	public bool limitToFloor;

	[EnableIf("limitToFloor")]
	public int allowedOnFloor;

	[DisableIf("limitToFloor")]
	[Tooltip("Allow only between these floors")]
	public bool limitToFloorRange;

	[EnableIf("limitToFloorRange")]
	public Vector2Int allowedOnFloorRange;

	public bool wealthLimit;

	[EnableIf("wealthLimit")]
	[Range(0f, 1f)]
	public float minimumWealth;

	[EnableIf("wealthLimit")]
	[Range(0f, 1f)]
	public float maximumWealth;

	public bool useRoomGrub;

	[EnableIf("useRoomGrub")]
	[Range(0f, 1f)]
	public float minimumGrub;

	[EnableIf("useRoomGrub")]
	[Range(0f, 1f)]
	public float maximumGrub;

	public bool useBuildingResidences;

	[EnableIf("useBuildingResidences")]
	public int minimumResidences;

	[EnableIf("useBuildingResidences")]
	public int maximumResidences;

	[Tooltip("If this cluster is successfully placed, add the following cluster presets from trying to be placed")]
	[Header("Optimizations")]
	public List<FurnitureCluster> addClustersOnSuccess;

	[Tooltip("If this cluster is successfully placed, remove the following cluster presets from trying to be placed")]
	public List<FurnitureCluster> removeClustersOnSuccess;

	[Tooltip("If this cluster fails to be placed, remove the following cluster presets from trying to be placed")]
	public List<FurnitureCluster> removeClustersOnFail;

	[Header("Misc.")]
	[Tooltip("Is this a security door?")]
	public bool securityDoor;

	[Tooltip("Is this a breaker box?")]
	public bool isBreakerBox;

	[Header("Debugging")]
	public bool enableDebug;

	[Button(null, EButtonEnableMode.Always)]
	public void UpdatePreCalculatedLimits()
	{
	}
}
