using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "furniture_data", menuName = "Database/Decor/Furniture Preset")]
public class FurniturePreset : SoCustomComparison
{
	public enum SubObjectOwnership
	{
		nobody = 0,
		everybody = 1,
		person0 = 2,
		person1 = 3,
		person2 = 4,
		person3 = 5,
		person4 = 6,
		person5 = 7,
		person6 = 8,
		person7 = 9,
		person8 = 10,
		person9 = 11,
		person10 = 12,
		person11 = 13,
		person12 = 14,
		person13 = 15,
		person14 = 16,
		person15 = 17,
		person16 = 18,
		person17 = 19,
		person18 = 20,
		person19 = 21,
		person20 = 22,
		person21 = 23,
		person22 = 24,
		person23 = 25,
		person24 = 26,
		person25 = 27,
		person26 = 28,
		person27 = 29,
		person28 = 30,
		person29 = 31
	}

	[Serializable]
	public class SubObject
	{
		public SubObjectClassPreset preset;

		public string parent;

		public Vector3 localPos;

		public Vector3 localRot;

		public SubObjectOwnership belongsTo;

		public int security;
	}

	[Serializable]
	public class IntegratedInteractable
	{
		public InteractablePreset preset;

		public InteractableController.InteractableID pairToController;

		public SubObjectOwnership belongsTo;
	}

	public enum ShareColours
	{
		none = 0,
		seating = 1,
		wallFrontage = 2,
		cabinets = 3,
		cubicles = 4,
		curtains = 5,
		telephone = 6,
		wood = 7,
		doors = 8,
		shelving = 9,
		bins = 10,
		blinds = 11
	}

	public enum FurnitureGroup
	{
		none = 0,
		seating = 1,
		windowDecor = 2
	}

	public enum ModifierTest
	{
		none = 0,
		testOwner = 1,
		testInhbitants = 2
	}

	public enum DecorClass
	{
		chairs = 0,
		tables = 1,
		units = 2,
		electronics = 3,
		structural = 4,
		decoration = 5,
		misc = 6
	}

	[Header("Rules")]
	[Space(7f)]
	[Tooltip("Classes that this furniture belongs to")]
	public List<FurnitureClass> classes;

	[Header("Visuals")]
	public GameObject prefab;

	[Tooltip("If true this will seach for identical furniture in a room to batch with")]
	public bool allowStaticBatching;

	public ObjectPoolingController.ObjectLoadRange spawnRange;

	[DisableIf("inheritColouringFromDecor")]
	[Tooltip("Allows this furniture to check for weather affected material (only works without custom colour keys or material changes")]
	public bool allowWeatherAffectedMaterials;

	[Header("AI Interaction")]
	[Tooltip("What interatables will be instanced on this? These won't be spawned but created and searched for within the furniture prefab")]
	public List<IntegratedInteractable> integratedInteractables;

	[Header("Decor Settings")]
	[Tooltip("If true use across all design styles")]
	public bool universalDesignStyle;

	public List<DesignStylePreset> designStyles;

	[Space(7f)]
	public bool inheritColouringFromDecor;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room")]
	public ShareColours shareColours;

	[Tooltip("If true this furniture will inherit a grub value from the decor/room")]
	public bool inheritGrubFromDecor;

	public List<MaterialGroupPreset.MaterialVariation> variations;

	[Space(7f)]
	[Tooltip("If this is a part of a group, furntiure of the same group will be chosen in this room.")]
	public FurnitureGroup furnitureGroup;

	public int groupID;

	[Range(0f, 1f)]
	[Header("Material Composition")]
	public float concrete;

	[Range(0f, 1f)]
	public float plaster;

	[Range(0f, 1f)]
	public float wood;

	[Range(0f, 1f)]
	public float carpet;

	[Range(0f, 1f)]
	public float tile;

	[Range(0f, 1f)]
	public float metal;

	[Range(0f, 1f)]
	public float glass;

	[Range(0f, 1f)]
	public float fabric;

	[Tooltip("This is secondary to the same property in the class preset.")]
	[Header("Suitability")]
	public int minimumRoomSize;

	[Tooltip("Is this allowed in open plan rooms?")]
	public FurnitureCluster.AllowedOpenPlan allowedInOpenPlan;

	[Space(7f)]
	[Tooltip("Only allow this in certain inhabitant presets")]
	public bool onlyAllowInFollowing;

	public List<AddressPreset> allowedInAddressesOfType;

	[Tooltip("Ban this in certain inhabitant presets")]
	public bool banInFollowing;

	public List<AddressPreset> bannedInAddressesOfType;

	[Space(7f)]
	[Tooltip("Only allow this in certain buildings")]
	public bool OnlyAllowInBuildings;

	[EnableIf("OnlyAllowInBuildings")]
	public List<BuildingPreset> allowedInBuildings;

	public bool banFromBuildings;

	[EnableIf("banFromBuildings")]
	public List<BuildingPreset> notAllowedInBuildings;

	[Space(7f)]
	[Tooltip("Only allow this in certain districts")]
	public bool OnlyAllowInDistricts;

	[EnableIf("OnlyAllowInDistricts")]
	public List<DistrictPreset> allowedInDistricts;

	public bool banFromDistricts;

	[EnableIf("banFromDistricts")]
	public List<DistrictPreset> notAllowedInDistricts;

	[Space(7f)]
	public bool requiresGenderedInhabitants;

	public List<Human.Gender> enableIfGenderPresent;

	[Space(7f)]
	[Tooltip("The furniture is only allowed in these room types")]
	public List<RoomTypeFilter> allowedRoomFilters;

	[Space(7f)]
	[Range(0f, 1f)]
	public float minimumWealth;

	[Header("Sub Objects")]
	public List<SubObject> subObjects;

	[Tooltip("Use this setting to test for subobject spawn modifiers (see 'SubObjectClassPreset')")]
	public ModifierTest testForModifiers;

	[Tooltip("Objects with illegal actions on this will override the public area allowance set in the interactable setup")]
	public bool forcePublicIllegal;

	[Header("Hiding")]
	public PlayerTransitionPreset hidingEnterTransition;

	public PlayerTransitionPreset hidingExitTransition;

	public PlayerTransitionPreset hidingEnterTransition2;

	public PlayerTransitionPreset hidingExitTransition2;

	[Header("Map")]
	public Texture2D map;

	public bool drawUnderWalls;

	public bool ignoreDirection;

	[Tooltip("Should there be fingerprints here?")]
	[Header("Fingerprints")]
	public bool fingerprintsEnabled;

	[Tooltip("The source of the prints")]
	public RoomConfiguration.PrintsSource printsSource;

	[Tooltip("Fingerprint density")]
	[Range(0f, 5f)]
	public float fingerprintDensity;

	[Header("Environment")]
	[Tooltip("Change area colours")]
	public bool alterAreaLighting;

	[EnableIf("alterAreaLighting")]
	public List<Color> possibleColours;

	[Tooltip("This is used in combination with the following to adjust street area lighting")]
	[EnableIf("alterAreaLighting")]
	public DistrictPreset.AffectStreetAreaLights lightOperation;

	[EnableIf("alterAreaLighting")]
	public float lightAmount;

	[EnableIf("alterAreaLighting")]
	[Tooltip("This is added to brightness")]
	public float brightnessModifier;

	[Header("Decor Edit")]
	public bool purchasable;

	[Tooltip("If true this will not appear in the current room list in the decor menu")]
	public bool disableFromDecorMenu;

	public int cost;

	public DecorClass decorClass;

	[Space(7f)]
	[ShowAssetPreview(64, 64)]
	public Sprite staticImage;

	[ReadOnly]
	public Vector3 imagePos;

	[ReadOnly]
	public Vector3 imageRot;

	[ReadOnly]
	public float imageScale;

	[ReadOnly]
	public GameObject imagePrefabOverride;

	[Header("Special")]
	[Tooltip("Is this a board where jobs can be posted?")]
	public bool isJobBoard;

	[Tooltip("Is this a desk (for work)? If true furniture ownership will be assigned based on jobs.")]
	public bool isWorkPosition;

	[Tooltip("Can spawn a variety of plants")]
	public bool isPlant;

	[Tooltip("Does this require the game to pick a piece of art to fit this?")]
	public bool isArt;

	[Tooltip("Is this a security camera? (Special limitations)")]
	public bool isSecurityCamera;

	[Tooltip("If true, if the player is here, upon load the game will teleport the player to an available adjacent space")]
	public bool onLoadAdjacentPlayerTeleport;

	[EnableIf("isArt")]
	public ArtPreset.ArtOrientation artOrientation;

	[Tooltip("Does this require a special self employed job?")]
	public CompanyPreset createSelfEmployed;

	[Tooltip("If above is true: Which slot contains the work position?")]
	public InteractableController.InteractableID workPositionID;

	[Tooltip("Chance to spawn the below objects; works on a item-by-item basis")]
	public float spawnObjectOnChance;

	[Tooltip("Spawns these objects once placed")]
	public List<InteractablePreset> spawnObjectsOnPlacement;
}
