using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CityControls : MonoBehaviour
{
	[Serializable]
	public struct WindowColour
	{
		public Color colourOne;

		public Color colourTwo;
	}

	[Serializable]
	public class NeonMaterial
	{
		public Color neonColour;

		public Color altColour2;

		public Color altColour3;

		public Material regularMat;

		public Material flickingMat;

		public AudioEvent flickerAudio;

		[Tooltip("Does this light flicker?")]
		public bool flicker;

		[Tooltip("When flickering, use this multiplier on the flicker colour to determin the actual colour (basically a darker version of flicker colour)")]
		public float flickerColourMultiplier;

		public float pulseSpeed;

		public float flickerState;

		public bool flickerSwitch;

		public bool flickerInterval;

		public float interval;

		public float intervalTime;

		public float brightness;

		[Space(5f)]
		public string colourTag;
	}

	[Serializable]
	public class CitySize
	{
		public Size size;

		public Vector2 v2;
	}

	public enum Size
	{
		small = 0,
		medium = 1,
		large = 2,
		veryLarge = 3
	}

	[Serializable]
	public class PPProfile
	{
		public SessionData.SceneProfile profile;

		public Volume volume;

		public GameObject objectRef;
	}

	[Serializable]
	public class StreetCable
	{
		public GameObject prefab;

		public float maximumWidth;

		public int frequency;

		[Tooltip("The maximum angle deviation for cables. 0 is only straight.")]
		public float maximumCableAngle;

		public float minimumHeight;

		public float maximumHeight;

		[Space(7f)]
		public bool onlyFromZoneType;

		public BuildingPreset.ZoneType zone;

		[Space(7f)]
		public bool disitrctFrequencyModifier;

		public List<DistrictPreset> districts;

		public int frequencyModifier;

		[Space(7f)]
		[Tooltip("Change area colours")]
		public bool alterAreaLighting;

		[EnableIf("alterAreaLighting")]
		public List<Color> possibleColours;

		[EnableIf("alterAreaLighting")]
		[Tooltip("This is used in combination with the following to adjust street area lighting")]
		public DistrictPreset.AffectStreetAreaLights lightOperation;

		[EnableIf("alterAreaLighting")]
		public float lightAmount;

		[Tooltip("This is added to brightness")]
		[EnableIf("alterAreaLighting")]
		public float brightnessModifier;
	}

	[Header("City")]
	public string wardName;

	public string cityCustoms;

	public string cityCustomsAbr;

	public string cityTax;

	public string cityTaxAbr;

	public string cityCurrency;

	[Header("Size")]
	[ReorderableList]
	public List<CitySize> citySizes;

	[Header("Infrastructure")]
	[Tooltip("Exact measurements of groundmap tiles in unity units (metres)")]
	public Vector3 cityTileSize;

	[Tooltip("Tiles are multiplied by this per ground map unit for pathmap grid")]
	public int tileMultiplier;

	[Tooltip("Nodes are multiplied by this per tile")]
	public int nodeMultiplier;

	[Tooltip("Maximum size of a city block")]
	public int maxBlockSize;

	[Tooltip("Chance block will expand into adjacent tile")]
	public float blockExpandChance;

	[Tooltip("?")]
	public float blockExpandCentreMultiplier;

	[Tooltip("?")]
	public float nonFavouredExpandMultiplier;

	[Tooltip("Minimum size of a district")]
	public int districtSizeMin;

	[Tooltip("Maximum size of a district")]
	public int districtSizeMax;

	[Tooltip("Chances of a side alley being formed")]
	public float sideAlleyChance;

	[Tooltip("Chances of a side alley being extended matching a previous side alley")]
	public float sideAlleyExtentionChance;

	[Tooltip("Enable overhead street placement")]
	public bool overheadStreet;

	[Header("Population")]
	[Tooltip("Amount to multiply the travel time distance by for calculating travel time guesses. X and Y planes only, IE Descrepencey between as the crow flies, and actual street route distance.")]
	public float travelTimeCrowFliesMultiplierEstimate;

	[Tooltip("Multiplier for travel time vs distance. Applied for guesses and calculated")]
	public float travelTimeMultiplier;

	[Tooltip("The city size (tile count) * by this will be created")]
	public float homelessMultiplier;

	[Header("Zoning")]
	public float residentialRatio;

	public float commercialRatio;

	public float industrialRatio;

	public float municipalRatio;

	public float parksRatio;

	[Header("Buildings")]
	[Tooltip("The address preset for lobbies/hallways")]
	public AddressPreset lobbyPreset;

	[Tooltip("An internal address/unit of this many tiles is categorised as...")]
	public Vector2 smallUnitRange;

	[Tooltip("An internal address/unit of this many tiles is categorised as...")]
	public Vector2 mediumUnitRange;

	[Tooltip("An internal address/unit of this many tiles is categorised as...")]
	public Vector2 lageUnitRange;

	[Tooltip("The default design style")]
	[Space(5f)]
	public DesignStylePreset defaultStyle;

	[Tooltip("Reference to default walls")]
	public DoorPairPreset defaultWalls;

	public MaterialGroupPreset defaultFloorMaterialGroup;

	public MaterialGroupPreset defaultCeilingMaterialGroup;

	public MaterialGroupPreset defaultWallMaterialGroup;

	[Space(5f)]
	[Tooltip("Setup for interior 'null space'")]
	public RoomConfiguration nullDefaultRoom;

	[Tooltip("Setup for interior hallways")]
	public RoomConfiguration streetRoom;

	public RoomConfiguration alleyRoom;

	public RoomConfiguration backstreetRoom;

	[Header("Layout Configs")]
	public LayoutConfiguration outsideLayoutConfig;

	public LayoutConfiguration lobbyLayoutConfig;

	[Tooltip("Street design styles")]
	public DesignStylePreset street;

	[Space(5f)]
	public int lowestFloor;

	public float lowestFloorLightMultiplier;

	public float lowestFloorIncreaseFlickerChance;

	public float basementWaterLevel;

	[Header("Interior fallback")]
	public DesignStylePreset fallbackStyle;

	public ColourSchemePreset fallbackColourScheme;

	public MaterialGroupPreset fallbackFloorMat;

	public MaterialGroupPreset fallbackWallMat;

	public MaterialGroupPreset fallbackCeilingMat;

	[Header("Lighting")]
	[Tooltip("The directional light representing the sun")]
	public Light sunLight;

	public Transform sunPosition;

	public HDAdditionalLightData hdrpLightSunData;

	public Light exteriorAmbientLight;

	public HDAdditionalLightData exteriorAmbientHDRP;

	public Light interiorAmbientLight;

	public HDAdditionalLightData interiorAmbientHDRP;

	[Header("Materials")]
	public Material seaMaterial;

	public MeshRenderer seaRenderer;

	public Material skylineMaterial;

	public List<MeshRenderer> skylineRenderers;

	public Material smokeMaterial;

	[Space(7f)]
	public DesignStylePreset echelonDesignStyle;

	public Color echelonWood;

	public MaterialGroupPreset echelonFloorMaterial;

	public MaterialGroupPreset.MaterialVariation echelonFloorVariation;

	public MaterialGroupPreset echelonCeilingMaterial;

	public MaterialGroupPreset.MaterialVariation echelonCeilingVariation;

	public MaterialGroupPreset echelonDefaultWallMaterial;

	public MaterialGroupPreset.MaterialVariation echelonWallVariation;

	public ColourSchemePreset echelonColourScheme;

	[Header("PP Profiles")]
	public List<PPProfile> sceneProfileSetup;

	public PPProfile captureSceneNormal;

	public PPProfile captureSceneCCTV;

	[Header("Skybox")]
	public Transform ships1;

	[Tooltip("Angle of North")]
	public float angleOfSun;

	[Tooltip("Interior/Street Lights off")]
	public Vector2 lightsOff;

	[Tooltip("Interior/Street Lights on")]
	public Vector2 lightsOn;

	[Tooltip("Alley blocking wall preset")]
	[Header("Street Furniture")]
	public DoorPairPreset alleyBlockWallPreset;

	[Header("Fog")]
	public FogPreset weatherSettings;

	[Tooltip("How long it takes in gametime for the city to get wet on max rain (1)")]
	[Header("Weather")]
	public float timeForCityToGetWet;

	[Tooltip("How long it takes in gametime for the city to get dry on min rain (0)")]
	public float timeForCityToGetDry;

	[Tooltip("How long it takes in gametime for the city to get snowy on max rain (1)")]
	public float timeForCityToGetSnow;

	[Tooltip("How long it takes in gametime for the city to get not snowy on min rain (0)")]
	public float timeForCityToGetNotSnow;

	[Tooltip("The default neon material")]
	[Header("Signage")]
	public Material neonMaterial;

	[Tooltip("Neon HDR intensity")]
	public float neonIntensity;

	[Tooltip("Neon colours that can appear in signage, along with generated material references")]
	public List<NeonMaterial> neonColours;

	[Header("Street Cables")]
	public List<StreetCable> cables;

	public float maximumCableAngle;

	[Header("Misc. References")]
	public LayoutConfiguration park;

	[Header("Hotels")]
	[Tooltip("Upper and lower ends for hotel rooms in the city")]
	public int hotelCostLower;

	[Tooltip("Upper and lower ends for hotel rooms in the city")]
	public int hotelCostUpper;

	[Tooltip("Time until the player is kicked out of their hotel room for not paying")]
	public float kickoutTime;

	[Header("Basement Water")]
	public Transform basementWaterTransform;

	[Header("Lost & Found")]
	public InteractablePreset lostAndFoundNote;

	[Tooltip("Items that can be lost and posted about")]
	public List<InteractablePreset> lostAndFoundItems;

	public DoorPairPreset dividerCenter;

	public DoorPairPreset dividerLeft;

	public DoorPairPreset dividerRight;

	[Header("Modding Resources")]
	public InteractablePreset jobNote;

	private static CityControls _instance;

	public static CityControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
