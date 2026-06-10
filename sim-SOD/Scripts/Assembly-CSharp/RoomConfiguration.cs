using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "roomconfig_data", menuName = "Database/Decor/Room Configuration")]
public class RoomConfiguration : SoCustomComparison
{
	public enum DecorSetting
	{
		ownStyle = 0,
		borrowFromAdjoining = 1,
		borrowFromBuilding = 2
	}

	public enum RoomZoning
	{
		lobby = 0,
		residential = 1,
		commerical = 2,
		industrial = 3,
		municpial = 4,
		park = 5
	}

	public enum Forbidden
	{
		alwaysAllowed = 0,
		alwaysForbidden = 1,
		allowedDuringOpenHours = 2
	}

	public enum SecurityDoorRule
	{
		never = 0,
		allAdjoining = 1,
		onlyToOtherAddress = 2,
		onlyToStairwell = 3
	}

	[Serializable]
	public class AILightingBehaviour
	{
		public enum TimeOfDay
		{
			always = 0,
			daytime = 1,
			evening = 2
		}

		public enum LightingPreference
		{
			mainOn = 0,
			secondaryOn = 1,
			eitherPriorityMain = 2,
			eitherPrioritySecondary = 3,
			allOff = 4,
			mainOff = 5,
			secondaryOff = 6,
			none = 7,
			mainOnSecondaryAny = 8
		}

		public TimeOfDay dayRule;

		public LightingPreference passthroughBehaviour;

		public LightingPreference destinationBehaviour;

		public LightingPreference exitRoomBehaviour;

		public LightingPreference exitGameLocationBehaviour;
	}

	public enum RoomPasswordPreference
	{
		interactableBelongsTo = 0,
		thisRoom = 1,
		thisAddress = 2
	}

	public enum KeyPlacement
	{
		thisAddress = 0,
		belongsToHome = 1,
		belongsToWork = 2
	}

	[Serializable]
	public class WallFrontage
	{
		public string name;

		public DoorPairPreset wallPreset;

		public List<WallFrontageClass> insideFrontage;

		public List<WallFrontageClass> outsideFrontage;

		[Tooltip("This entry is only valid if the wall faces onto the outside")]
		public bool onlyIfBorderingOutside;

		public Vector3 localOffset;

		public bool limitToBuildingTypes;

		public List<BuildingPreset> limitedToBuildings;
	}

	public enum OutsideSetting
	{
		dontChange = 0,
		forceOutside = 1,
		forceInside = 2
	}

	public enum PrintsSource
	{
		owners = 0,
		inhabitants = 1,
		buildingResidents = 2,
		customersAll = 3,
		customersMale = 4,
		customersFemale = 5,
		publicAll = 6,
		inhabitantsAndCustomers = 7,
		writers = 8,
		receivers = 9,
		ownersAndWriters = 10,
		ownersWritersReceivers = 11,
		killer = 12
	}

	[Header("Type")]
	[Tooltip("The room type: Dictates layout parameters")]
	public RoomTypePreset roomType;

	[Tooltip("The room class: Dictates what decor and furniture this has")]
	public RoomClassPreset roomClass;

	[Tooltip("If there's not enough room, section off this room to include its vital elements")]
	[Header("Integration Rules")]
	public bool canBeOpenPlan;

	[EnableIf("canBeOpenPlan")]
	public RoomTypePreset openPlanRoom;

	[Header("Doors")]
	[Tooltip("Allow security doors to spawn on exits for this room?")]
	public SecurityDoorRule securityDoors;

	[Header("Special Rules")]
	[Tooltip("Limit security camera")]
	public bool limitSecurityCameras;

	[EnableIf("limitSecurityCameras")]
	[Range(0f, 5f)]
	public int securityCameraLimit;

	[Header("Lighting")]
	[Tooltip("Use main lights")]
	public bool useMainLights;

	[Tooltip("If set to false then this room will use timer lights")]
	public bool useLightSwitches;

	[Tooltip("At the start of the game, are the main lights on or off?")]
	public bool lightsOnAtStart;

	[Tooltip("If true, boost the amount of light from main lights in this room")]
	public bool wellLit;

	[Tooltip("If true, the game will automatically disable lights on floors that are 2 or more floors away from the player, or out of their vicinity.")]
	public bool autoDisableLightsOutOfVicinity;

	[EnableIf("autoDisableLightsOutOfVicinity")]
	[Tooltip("If true, the game will automatically disable lights on floors that are 2 or more floors away from the player, or out of their vicinity (but not if a stairwell)")]
	public bool onlyAutoDisableInNonStairwell;

	[Tooltip("If true use an area light per zone in addition to normal lights")]
	public bool useAdditionalAreaLights;

	[Tooltip("If true, use district settings as a base for colour and brightness settings")]
	public bool useDistrictSettingsAsBase;

	[EnableIf("useAdditionalAreaLights")]
	public int minimumLightZoneSizeForAreaLights;

	[EnableIf("useAdditionalAreaLights")]
	public Vector3 areaLightOffset;

	[EnableIf("useAdditionalAreaLights")]
	public float areaLightBrightness;

	[EnableIf("useAdditionalAreaLights")]
	public Color areaLightColor;

	[EnableIf("useAdditionalAreaLights")]
	public float areaLightRange;

	[Tooltip("Multiply the area light size by this")]
	[EnableIf("useAdditionalAreaLights")]
	public float areaLightCoverageMultiplier;

	[Tooltip("If true, boost the ceiling emission by this colour when main lights are on")]
	public bool boostCeilingEmission;

	[Tooltip("If true, boost the ceiling emission by this colour when main lights are on")]
	public Color ceilingEmissionBoost;

	[Range(0f, 1f)]
	[Tooltip("Chance of having a ceiling fan on light fittings")]
	public float chanceOfCeilingFans;

	[Tooltip("Give the base lighting a shadow tint?")]
	public bool baseLightingShadowTint;

	[Range(0f, 1f)]
	[Tooltip("Fake caustics by lerping the shadow tint to decor and time of day colours...")]
	public float baseLightingShadowTintIntensity;

	[Tooltip("Give the base lighting a shadow tint?")]
	[EnableIf("useAdditionalAreaLights")]
	public bool areaLightingShadowTint;

	[Tooltip("Fake caustics by lerping the shadow tint to decor and time of day colours...")]
	[Range(0f, 1f)]
	[EnableIf("areaLightingShadowTint")]
	public float areaLightingShadowTintIntensity;

	[EnableIf("areaLightingShadowTint")]
	public bool overrideAreaLightShadowTint;

	[EnableIf("areaLightingShadowTint")]
	public Color areaLightShadowTintOverride;

	[EnableIf("useAdditionalAreaLights")]
	[Range(0f, 1f)]
	public float areaLightShadowDimmer;

	[Header("Lighting AI Behaviour")]
	[InfoBox("These settings can be overriden by AI actions and goals", EInfoBoxType.Normal)]
	public List<AILightingBehaviour> lightingBehaviour;

	[Tooltip("Used when picking a colour scheme for this: How clean/corporate/soulless is this room?")]
	[Header("Colour Scheme")]
	[Range(0f, 10f)]
	public int cleanness;

	[Tooltip("Force a selection of these colour schemes...")]
	public List<ColourSchemePreset> forceColourSchemes;

	[Tooltip("Minimum level of grubiness this room can have....")]
	[Range(0f, 1f)]
	public float minimumGrubiness;

	[Tooltip("Maximum level of grubiness this room can have....")]
	[Range(0f, 1f)]
	public float maximumGrubiness;

	public DecorSetting decorSetting;

	[Tooltip("If true other adjacent rooms with the 'borrow from adjacent' setting won't copy this style.")]
	public bool excludeFromOthersCopyingDecorStyle;

	[Tooltip("Use an override material if this is on the ground floor (picked from this list, saved in building class.)")]
	public float chanceOfOverrideMatIfGroundFloor;

	[Tooltip("Use an override material if this is in the basement (picked from this list, saved in building class.)")]
	public float chanceOfOverrideMatIfBasement;

	[Tooltip("Use an override material if this room contains stairs (picked from this list, saved in building class.)")]
	public float chanceOfOverrideMatIfStairwell;

	[Tooltip("List of override materials")]
	public List<MaterialGroupPreset> floorOverrides;

	public List<MaterialGroupPreset> wallOverrides;

	public List<MaterialGroupPreset> ceilingOverrides;

	[Space(7f)]
	[Tooltip("The priority given to decorating: Higher priority rooms will override size variables of others.")]
	[Range(0f, 10f)]
	public int decorationPriority;

	[Tooltip("Can this room be owned by anyone?")]
	[Header("Ownership")]
	public bool useOwnership;

	[EnableIf("useOwnership")]
	[Tooltip("Assign owners to this furniture")]
	public int assignBelongsToOwners;

	[Tooltip("If this is checked the game will assign this object to a couple")]
	[EnableIf("useOwnership")]
	public bool preferCouples;

	[Tooltip("If this isn't null, the game will use a job to assign ownership to this room")]
	[EnableIf("useOwnership")]
	[ReorderableList]
	public List<OccupationPreset> belongsToJob;

	[Header("Doors")]
	[Tooltip("If this features a door to the outside, use this preset")]
	public DoorPreset exteriorDoor;

	[Tooltip("If this features a door to outside this address, use this preset")]
	public DoorPreset addressDoor;

	[Tooltip("If this features a door to another room in this address, use this preset")]
	public DoorPreset internalDoor;

	[Tooltip("Which room should be the passworded room, ie the place to store the key in?")]
	[Range(0f, 10f)]
	public int passwordPriority;

	[Tooltip("For doors belonging to this room, prefer the password from...")]
	public RoomPasswordPreference preferredPassword;

	[Tooltip("If this spawns a door that requires a key, place it here...")]
	public List<KeyPlacement> placeKey;

	public InteractablePreset.OwnedPlacementRule keyOwnershipPlacement;

	[Tooltip("Use these steps")]
	public GameObject steps;

	[Header("Custom Walls")]
	public DoorPairPreset replaceWindows;

	public DoorPairPreset replaceWalls;

	public DoorPairPreset replaceEntrance;

	[Tooltip("By default, only outside walls are replaced here. Check to replace inside walls...")]
	public bool replaceInsideAlso;

	[Tooltip("Only replace above if the other side is one of these rooms...")]
	public bool replaceOnlyIfOtherIs;

	[EnableIf("replaceOnlyIfOtherIs")]
	public List<RoomTypePreset> onlyReplaceIf;

	[Tooltip("Force inclusion on the street light lighting layer.")]
	public bool forceStreetLightLayer;

	[Tooltip("Draw the current building model when in this room.")]
	public bool drawBuildingModel;

	[Header("Wall Frontage")]
	public List<WallFrontage> wallFrontage;

	[Tooltip("Used for fake roofs for things like rooftop air vents. Only one wall frontage allowed per node")]
	public bool oneFrontagePerNode;

	[Header("Air Vents")]
	public int maximumVents;

	[Range(0f, 10f)]
	public int chanceOfRoofVent;

	[Range(0f, 10f)]
	public int chanceOfWallVentUpper;

	[Range(0f, 10f)]
	public int chanceOfWallVentLower;

	[Tooltip("If true this room allows upper-wall level air ducts (below ceiling height)")]
	public bool allowUpperWallLevelDucts;

	[Tooltip("Only allow upper wall level ducts if floor height is 0")]
	[EnableIf("allowUpperWallLevelDucts")]
	public bool onlyAllowUpperIfFloorLevelIsZero;

	[Tooltip("Limit the number of upper level ducts")]
	public int limitUpperLevelDucts;

	[Tooltip("If true this room allows lower-wall level air ducts (below standing height)")]
	public bool allowLowerWallLevelDucts;

	[Header("Environment")]
	[Tooltip("Use a specific profile for this room")]
	public bool overrideAddressEnvironment;

	[EnableIf("overrideAddressEnvironment")]
	public SessionData.SceneProfile sceneClean;

	[EnableIf("overrideAddressEnvironment")]
	public SessionData.SceneProfile sceneDirty;

	[Range(0f, 1f)]
	[Tooltip("Affects lighting volumetrics; creating a smokey atmosphere with a higher value.")]
	public float baseRoomAtmosphere;

	[Tooltip("Force the nodes in this room to register as outside or inside...")]
	public OutsideSetting forceOutside;

	[Header("Audio")]
	public AmbientZone ambientZone;

	[Header("Fingerprints")]
	[Tooltip("Should there be fingerprints here?")]
	public bool fingerprintsEnabled;

	[Tooltip("Should there be footprints here?")]
	public bool footprintsEnabled;

	[Tooltip("The source of the prints")]
	public PrintsSource printsSource;

	[Tooltip("Fingerprint density on walls")]
	[Range(0f, 2f)]
	public float fingerprintWallDensity;

	[Header("Other")]
	public bool allowCoving;

	[Tooltip("Allow bugs to be spawned in this room")]
	public bool allowBugs;

	[EnableIf("allowBugs")]
	[Tooltip("Number of bugs = number of nodes * grubiness * this")]
	public float bugAmountMultiplier;

	[Tooltip("If true the player will be tresspassing when here")]
	public Forbidden forbidden;

	[Tooltip("The player is allowed here after they have given a correct password (if set on the address preset)")]
	public bool allowedIfGivenCorrectPassword;

	[Tooltip("Allow AI here if the password setting is on in the address preset")]
	public bool AIknowPassword;

	[Tooltip("Severity for being caught when this is forbidden (0 = asked to leave, 2 = combat on sight)")]
	[Range(0f, 2f)]
	public int escalationLevelNormal;

	[Tooltip("Severity for being caught when this is forbidden when after hours (0 = asked to leave, 2 = combat on sight)")]
	[Range(0f, 2f)]
	public int escalationLevelAfterHours;

	[Tooltip("All object placements in this room have this increased security level")]
	[Range(0f, 4f)]
	public int securityLevel;

	[Tooltip("If true, personal affects of citizens can be placed in this room")]
	public bool allowPersonalAffects;

	public bool overrideMaxFurnitureClusters;

	[EnableIf("overrideMaxFurnitureClusters")]
	public int overridenMaxFurniture;

	public bool overrideAttemptsPerNodeMultiplier;

	[EnableIf("overrideAttemptsPerNodeMultiplier")]
	public float overridenAttemptsPerNode;

	[Tooltip("When ranking shadiness for certain jobs/systems the base value")]
	[Range(0f, 10f)]
	public int shadinessValue;

	[Tooltip("AI can mug here")]
	public bool allowMuggings;

	[Tooltip("Player can awaken here after mugging")]
	public bool muggingAwakenRoom;

	[Header("Debug")]
	public RoomConfiguration debugRoom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyWallFrontage()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddWallFrontage()
	{
	}
}
