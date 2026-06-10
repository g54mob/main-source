using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "address_data", menuName = "Database/Address Preset")]
public class AddressPreset : SoCustomComparison
{
	[Serializable]
	public class AddressRule
	{
		public DistrictPreset districtPreset;

		public int scoreModifier;
	}

	public enum AccessType
	{
		allPublic = 0,
		residents = 1,
		buildingInhabitants = 2,
		employees = 3,
		none = 4
	}

	[Header("Zoning")]
	public bool debug;

	[Range(0f, 225f)]
	[Tooltip("Fits in units of this size (in tiles)")]
	public int fitsUnitSizeMin;

	[Range(0f, 225f)]
	public int fitsUnitSizeMax;

	[Tooltip("If true, units incompatible with size will be completely discounted instead of just ranked lower...")]
	public bool hardSizeLimits;

	[Space(7f)]
	public Vector2 minMaxFloors;

	[Tooltip("If true, the game will place at least one of these if at all possible")]
	[Space(7f)]
	public bool important;

	[Tooltip("Maximum number of instances")]
	public int maxInstances;

	[Space(7f)]
	public int baseScore;

	[Tooltip("Minus to base score with every instance")]
	public int baseScoreFrequencyPenalty;

	[Space(7f)]
	[Range(0f, 1f)]
	public float idealFootfall;

	[Tooltip("How important is the correct footfall?")]
	public float footfallMultiplier;

	public List<AddressRule> addressRules;

	public List<BuildingPreset> limitToBuildings;

	[Tooltip("Always pick this if it is compatible")]
	public bool forcePick;

	[Tooltip("Does the ethnicity of this address factor in the ownership?")]
	[Header("Ownership")]
	public bool ethnicityMatters;

	[Tooltip("Ethnicity of this address")]
	[EnableIf("ethnicityMatters")]
	public Descriptors.EthnicGroup ethnicity;

	[Header("Compatible Layouts")]
	public List<LayoutConfiguration> compatible;

	[Header("Room Config")]
	public List<RoomConfiguration> roomConfig;

	[Header("Access")]
	public AccessType access;

	[Tooltip("If true an AI can pass through this on the way to another place (origins, destinations unaffected)")]
	public bool canPassThrough;

	[Tooltip("Are open hours dictated by a company that ajoins this?")]
	public bool openHoursDicatedByAdjoiningCompany;

	[Tooltip("The player needs a password to enter this location")]
	public bool needsPassword;

	[Tooltip("Sources for a password")]
	public List<string> dictionaryPasswordSources;

	[Tooltip("If a company operates this address, this is the preset")]
	[Header("Purpose")]
	public CompanyPreset company;

	[Tooltip("If a residence is at this address, this is the preset")]
	public ResidencePreset residence;

	[Tooltip("Purpose/icon is known to the player at the start")]
	public bool playerKnowsPurpose;

	[Header("Interface")]
	public Sprite evidenceIconLarge;

	[Header("Signage")]
	[Range(0f, 1f)]
	public float chanceOfNameSignHorizontal;

	[Tooltip("Make a sign using this character set")]
	public Vector3 horizontalSignOffset;

	public List<NeonSignCharacters> signCharacterSet;

	[Range(0f, 1f)]
	public float chanceOfNameSignVertical;

	[Tooltip("Make a sign using one of these")]
	public List<GameObject> possibleSigns;

	[Header("Special Items")]
	public List<InteractablePreset> specialItems;

	[Tooltip("Chance of a spare key being left in an adjoining lobby (will be hidden under mat, or in a plant or radiator)")]
	public float chanceOfExternalSpareKey;

	[Header("Air Vents")]
	public Vector2 airVentRange;

	[Header("Security")]
	[Tooltip("If false, this uses the building's security system")]
	public bool useOwnSecuritySystem;

	[Tooltip("If false, this uses the breaker box contained on the floor")]
	public bool useOwnBreakerBox;

	[EnableIf("useOwnSecuritySystem")]
	[Tooltip("If triggered, does the alarm lock down the building floor?")]
	public bool alarmLocksDownFloor;

	[Header("Environment")]
	public bool overrideBuildingEnvironment;

	[EnableIf("overrideBuildingEnvironment")]
	public SessionData.SceneProfile sceneProfile;

	[Tooltip("Are entrance doors locked by default?")]
	[Header("Misc")]
	public bool entrancesLockedByDefault;

	[Tooltip("AI leaves lights on, even when empty")]
	public bool leaveLightsOn;

	[Tooltip("If enabled, AI leaves doesn't lock doors out of hours or when empty")]
	public bool disableLockingUp;

	[Tooltip("Stop this from appearing in the bottom left when the player enters")]
	public bool disableLocationInformationDisplay;

	[Tooltip("This will be included in the city directory")]
	public bool forceCityDirectoryInclusion;

	[Tooltip("The name of this also contains the building name")]
	public bool nameFeaturesBuildingReference;

	[Tooltip("Number the name of this based on how many of these types there are per floor")]
	public bool nameFeaturesTypeCount;

	[Tooltip("The name of this will become the name of the building")]
	public bool overrideBuildingName;

	[Tooltip("Employees in the same building will have this as a location of authority")]
	public bool sameBuildingEmployeesAuthority;

	[Tooltip("Residents in the same building will have this as a location of authority")]
	public bool sameBuildingResidentsAuthority;

	[Tooltip("This address can feature lost & found notes")]
	public bool canFeatureLostAndFound;

	[Tooltip("The minimum land value for this address type")]
	[Range(0f, 1f)]
	public float minimumLandValue;

	[Range(0f, 1f)]
	[Tooltip("The maximum land value for this address type")]
	public float maximumLandValue;

	[Tooltip("If a sniper type killer is searching for a vantage point, allow this location")]
	public bool allowSniperVantagePoint;

	[Tooltip("Add weight to this being chosen as a sniper vantage point")]
	[EnableIf("allowSniperVantagePoint")]
	public float vantagePointBoost;

	[Tooltip("A sniper victim won't get shot here if true")]
	public bool disableSniperTargetSite;

	[Tooltip("Allow public toilet use")]
	public bool allowPublicToiletUse;

	[Header("Debug")]
	[Tooltip("If true this won't be chosen in-game")]
	public bool disableThis;
}
