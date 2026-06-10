using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "building_data", menuName = "Database/Building Preset")]
public class BuildingPreset : SoCustomComparison
{
	public enum Density
	{
		low = 0,
		medium = 1,
		high = 2,
		veryHigh = 3
	}

	public enum LandValue
	{
		veryLow = 0,
		low = 1,
		medium = 2,
		high = 3,
		veryHigh = 4
	}

	[Serializable]
	public class InteriorFloorSetting
	{
		[Tooltip("This setting will appear for x floors")]
		public int floorsWithThisSetting;

		[Tooltip("Possible floor presets (choose at random)")]
		public List<TextAsset> blueprints;

		[Tooltip("How far air vents are allowed to extrude from the outer wall of the building (0 if none)")]
		public int airVentMaximumExtrusion;

		[Tooltip("Possible floor variants featuring control rooms (choose at random)")]
		public List<TextAsset> controlRoomVariants;

		[Tooltip("Forces the main building model to be visible on this floor")]
		public bool forceShowModel;

		[Tooltip("When player is on this floor, force these model parents to be hidden")]
		public List<string> forceHideModels;

		[Tooltip("When the player is on this floor, in this specific room type, force this model parents to be hidden (overrides outside rooms)")]
		public List<ForceHideModelsForRoom> forceHideModelsInRooms;

		[Tooltip("When the player is outside on this floor, force this model parents to be hidden")]
		public List<string> forceHideModelsOutside;

		public bool overrideCeilingHeight;

		public int newCeilingHeight;
	}

	[Serializable]
	public class ForceHideModelsForRoom
	{
		public RoomConfiguration roomConfig;

		public List<string> forceHideModels;
	}

	public enum ZoneType
	{
		residential = 0,
		commercial = 1,
		industrial = 2,
		municipal = 3,
		publicProperty = 4,
		privateProperty = 5
	}

	[Serializable]
	public struct CableLinkPoint
	{
		public Vector3 localPos;

		public Vector3 localRot;
	}

	[Serializable]
	public class WindowUVFloor
	{
		public List<WindowUVBlock> front;

		public List<WindowUVBlock> back;

		public List<WindowUVBlock> left;

		public List<WindowUVBlock> right;
	}

	[Serializable]
	public class WindowUVBlock
	{
		public Vector2 originPixel;

		public Vector2 rectSize;

		public Vector2 centrePixel;

		public Vector3 localMeshPositionLeft;

		public Vector3 localMeshPositionRight;

		[Space(7f)]
		public int floor;

		public Vector2 side;

		public int horizonal;
	}

	public bool disable;

	[Tooltip("Reference to the building model prefab")]
	[Header("Models")]
	public GameObject prefab;

	[Tooltip("The emission texture used to light up windows on this model (unlit)")]
	public Texture2D emissionMapUnlit;

	[Tooltip("The emission texture used to light up windows on this model (lit)")]
	public Texture2D emissionMapLit;

	[Tooltip("The height of this building")]
	public float buildingHeight;

	[Tooltip("The local position of the lightning rod")]
	public Vector3 lightningRodLocalPos;

	[Tooltip("The material to use on default walls. Leave blank to use default (brick)")]
	public List<MaterialGroupPreset> defaultExteriorWallMaterial;

	[Tooltip("The material key to use on the exterior of the building")]
	public Toolbox.MaterialKey exteriorKey;

	[Tooltip("Check if this building supports alley blocks")]
	public bool enableAlleywayWalls;

	[Tooltip("Allow this building to feature quoins")]
	public bool enableExteriorQuoins;

	[Space(7f)]
	public bool overrideEvidencePhotoSettings;

	[EnableIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoPos;

	[EnableIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoEuler;

	[Header("Environment")]
	public bool overrideDistrictEnvironment;

	[EnableIf("overrideDistrictEnvironment")]
	public SessionData.SceneProfile sceneProfile;

	[Range(0f, 5f)]
	[Header("Special")]
	[Tooltip("The max amount of lost and found items to spawn at one time")]
	public int maxLostAndFound;

	[Header("Blueprints")]
	[Tooltip("The layouts of above-ground floors, starting with ground floor")]
	public List<InteriorFloorSetting> floorLayouts;

	[Tooltip("The layouts of below-ground floors, starting with basement level 1")]
	public List<InteriorFloorSetting> basementLayouts;

	[Tooltip("How many control rooms should this building feature?")]
	public Vector2 controlRoomRange;

	public List<DesignStylePreset> forceBuildingDesignStyles;

	public StairwellPreset stairwellRegular;

	public StairwellPreset stairwellLarge;

	[Header("Echelons")]
	public bool buildingFeaturesEchelonFloors;

	[EnableIf("buildingFeaturesEchelonFloors")]
	public int echelonFloorStart;

	[Space(7f)]
	public bool overrideGrubiness;

	[EnableIf("overrideGrubiness")]
	public float grubinessOverride;

	[Header("Zoning")]
	public ZoneType displayedZone;

	public bool allowedInAllDistricts;

	[Tooltip("Appears in this district")]
	[DisableIf("allowedInAllDistricts")]
	public List<DistrictPreset> allowedInDistricts;

	[Tooltip("Appears in density range: Not required but choices will be weighted towards this")]
	public Density densityMinimum;

	public Density densityMaximum;

	[Tooltip("Appears in land value range: Not required but choices will be weighted towards this")]
	public LandValue landValueMinimum;

	public LandValue landValueMaximum;

	[Tooltip("Try and make sure the city has at least this many buildings of this type")]
	[Space(7f)]
	public int minimum;

	[Range(0f, 10f)]
	[Tooltip("How important is it that the city features the above minimum amount of buildings?")]
	public int featureImportance;

	[Tooltip("Hard limit on the number of buildings per city")]
	public int hardLimit;

	[Tooltip("Desired ratio on the number of these buildings (1 means the whole city can be these)")]
	[Range(0f, 1f)]
	public float desiredRatio;

	[Range(0f, 10f)]
	[Tooltip("Modernity: Used to choose decor- how modern the building is")]
	public int modernity;

	[Tooltip("Used in choosing decor: The lobby area room type")]
	public AddressPreset lobbyPreset;

	[Tooltip("True if this is supposed to not have floors")]
	public bool nonEnterable;

	[Tooltip("True if this is a boundary piece")]
	public bool boundary;

	[Tooltip("True if this is a boundary corner piece")]
	public bool boundaryCorner;

	[Header("Naming")]
	public bool overrideNaming;

	[EnableIf("overrideNaming")]
	public List<string> possibleNames;

	[Header("Map")]
	public bool customDrawOnMap;

	public Texture2D tex;

	[Header("Window Mapping")]
	[Tooltip("The mesh to use to find the window coordinates, cable coordinates")]
	public Mesh captureMesh;

	[Tooltip("A map with white blocks mapping the window areas: IMPORTANT: Make sure texture image compression is off & read/write is on.")]
	public Texture2D windowMap;

	[Tooltip("A map with red pixels for cable connections and green for external signage: IMPORTANT: Make sure texture image compression is off & read/write is on.")]
	public Texture2D addonMap;

	public List<WindowUVFloor> sortedWindows;

	public int floorCount;

	public float meshHeight;

	[Header("Building Addon Points")]
	public List<CableLinkPoint> cableLinkPoints;

	public AnimationCurve cableSpawnChanceOverHeight;

	public List<CableLinkPoint> sideSignPoints;

	[Header("Signage")]
	public List<GameObject> possibleNeonSigns;

	public Vector2 signsPerBuildingRange;

	[Tooltip("Offset for horizontal lettering signs")]
	public Vector3 horizontalSignOffset;

	[Header("Smokestacks")]
	public bool featuresSmokestack;

	[EnableIf("featuresSmokestack")]
	[Tooltip("Interval in gametime")]
	public Vector2 spawnInterval;

	[EnableIf("featuresSmokestack")]
	public GameObject spritePrefab;

	[EnableIf("featuresSmokestack")]
	public Vector3 spawnOffset;

	private Vector2[] offsetArrayX4;

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateWindowData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GenerateAddonData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CalculateMeshHeight()
	{
	}

	public Vector3 UvTo3D(Vector2 uv)
	{
		return default(Vector3);
	}

	public float Area(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return 0f;
	}

	public InteriorFloorSetting GetFloorSetting(int floor, int index)
	{
		return null;
	}

	public int GetResidenceCount()
	{
		return 0;
	}
}
