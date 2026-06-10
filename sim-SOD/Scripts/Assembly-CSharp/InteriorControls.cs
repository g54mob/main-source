using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class InteriorControls : MonoBehaviour
{
	[Serializable]
	public class AirDuctOffset
	{
		public string name;

		public List<Vector3> offsets;

		public Vector3 rotation;

		public List<GameObject> prefabs;

		public List<Texture2D> maps;
	}

	[Header("Colours")]
	public List<Color> woods;

	[Space(7f)]
	[Tooltip("Default variation used for things like ceiling lights")]
	public MaterialGroupPreset.MaterialVariation defaultVariation;

	[Header("Presets")]
	public InteractablePreset cctvPreset;

	public InteractablePreset peekUnderDoor;

	public InteractablePreset lightswitch;

	public AddressPreset lobbyAddressPreset;

	public StairwellPreset defaultStairwell;

	public StairwellPreset defaultStairwellInverted;

	public StairwellPreset defaultStairwellLarge;

	public InteractablePreset elevatorUpButton;

	public InteractablePreset elevatorDownButton;

	public InteractablePreset elevatorControls;

	public InteractablePreset doorC;

	public InteractablePreset keypad;

	public InteractablePreset cruncher;

	public InteractablePreset door;

	public InteractablePreset activeCodebreaker;

	public InteractablePreset activeDoorWedge;

	public InteractablePreset activeTracker;

	public InteractablePreset activeFlashbomb;

	public InteractablePreset activeIncapacitator;

	public InteractablePreset flowersAffair;

	public InteractablePreset storageBox;

	public InteractablePreset paperclip;

	public InteractablePreset salesLedger;

	public InteractablePreset telephoneRouter;

	public InteractablePreset telephoneRouterDoor;

	public InteractablePreset saleNote;

	public CruncherAppPreset loginApp;

	public InteractablePreset shotgun;

	[Header("Gadgets")]
	public InteractablePreset codebreaker;

	public InteractablePreset doorWedge;

	public InteractablePreset tracker;

	public InteractablePreset flashbomb;

	public InteractablePreset incapacitator;

	public InteractablePreset printReader;

	public InteractablePreset handcuffs;

	public InteractablePreset policeBadge;

	public InteractablePreset lockpickKit;

	public InteractablePreset detectiveStuff;

	public InteractablePreset briefcaseCustom;

	public InteractablePreset codebreakerUsed;

	public InteractablePreset doorWedgeUsed;

	[Space(7f)]
	public FirstPersonItem FPCodebreaker;

	public FirstPersonItem FPCamera;

	public FirstPersonItem FPHandcuffs;

	public FirstPersonItem FPNewspaper;

	[Space(7f)]
	public MurderWeaponPreset fistsWeapon;

	[Header("Generation")]
	public float roomRankingRandomThreshold;

	[Tooltip("The minimum distance of two light zones (how close ceiling lights can spawn")]
	public float lightZoneMinDistance;

	[Tooltip("Limit to one area light per room (currently causing a weird bug when areas intersect)")]
	public bool oneAreaLightPerRoom;

	[Tooltip("The maximum number of furniture clusters per room (default)")]
	public int maxClustersPerRoom;

	[Tooltip("Multiply the number of nodes by this to get the default number of cluster placement attempts")]
	public float roomSizeClusterAttemptMultiplier;

	public GameObject bug;

	[Header("Clue Items")]
	public InteractablePreset businessCard;

	public InteractablePreset workRota;

	public InteractablePreset employmentContractHome;

	public InteractablePreset employmentContractWork;

	public InteractablePreset workID;

	public InteractablePreset wallet;

	public InteractablePreset diary;

	public InteractablePreset photo;

	public InteractablePreset namePlacard;

	public InteractablePreset employeePhoto;

	public InteractablePreset birthdayCard;

	public InteractablePreset note;

	public InteractablePreset letter;

	public InteractablePreset moneyLots;

	public InteractablePreset travelReceipt;

	public InteractablePreset vmailLetter;

	public InteractablePreset vmailPrintout;

	public InteractablePreset surveillancePrintout;

	public InteractablePreset vmailPrintoutStatic;

	public InteractablePreset key;

	public InteractablePreset keyTabletopOnly;

	public SubObjectClassPreset keyHidingPlace;

	public InteractablePreset noodleBox;

	public SubObjectClassPreset telephone;

	public SubObjectClassPreset payphone;

	public SubObjectClassPreset fridge;

	public InteractablePreset suitcase;

	public InteractablePreset hairpin;

	public InteractablePreset residentsContract;

	public InteractablePreset birthCertificate;

	public InteractablePreset bankStatement;

	public InteractablePreset medicalDetails;

	public InteractablePreset homeFilePreset;

	public EvidencePreset homeFile;

	public List<InteractablePreset> clothesOnFloor;

	public InteractablePreset bookShelf;

	public InteractablePreset bookNonShelf;

	public InteractablePreset bookNonShelfSecret;

	public InteractablePreset receipt;

	public InteractablePreset flyer;

	public InteractablePreset document;

	public InteractablePreset fieldsAd;

	public InteractablePreset policeSupportFlyer;

	public InteractablePreset toothbrush;

	public InteractablePreset painkillers;

	public InteractablePreset bandage;

	public InteractablePreset splint;

	public InteractablePreset binNote;

	public InteractablePreset crumpledPaper;

	public InteractablePreset handgun;

	public InteractablePreset silencer;

	public InteractablePreset ammo1;

	public InteractablePreset coffeeHomemade;

	public InteractablePreset teaHomemade;

	public InteractablePreset stovetopKettle;

	public InteractablePreset streetCrimeScene;

	public InteractablePreset creditCard;

	public InteractablePreset donorCard;

	public SubObjectClassPreset sideJobHiddenItemClass;

	[Header("Misc References")]
	public DoorPreset defaultDoor;

	public RoomConfiguration bedroom;

	public RoomConfiguration lounge;

	public RoomConfiguration kitchen;

	public RoomConfiguration closet;

	public FurnitureClass bed;

	public FurnitureClass bedsideCabinet;

	public FurnitureClass safe;

	public FurnitureClass television;

	public FurnitureClass telephoneTable;

	public InteractablePreset deskLamp;

	public InteractablePreset bedsideLamp;

	public InteractablePreset cityDirectory;

	public GameObject roomAreaLight;

	public Material cameraOffMaterial;

	public Material cameraOnMaterial;

	public Material cameraFocusMaterial;

	public Material cameraAlertMaterial;

	public Material newLightswitchMaterial;

	public Material newLightswithSwitchMaterial;

	public Material pulsingLightswitch;

	public Material pulsingLightswitchSwitch;

	public Color pulseColor;

	public FurnitureCluster bedCluster;

	public FurnitureCluster noticeBoardCluster;

	public FurnitureCluster deskCluster;

	public FurnitureCluster breakerBoxCluster;

	[ReorderableList]
	public List<GameObject> housePlantPool;

	public Color housePlantColour1;

	public Color housePlantColour2;

	[ReorderableList]
	[Tooltip("Use this in various places where we want to set up a robbery")]
	public List<InteractablePreset> valuableItems;

	public SyncDiskPreset chapterRewardSyncDisk;

	public SyncDiskPreset chapterFlophouseSyncDisk;

	public List<InteractablePreset> meetupConsumables;

	[Header("Room Types")]
	public RoomConfiguration nullConfig;

	public RoomTypePreset nullRoomType;

	public RoomTypePreset bedroomType;

	[Header("Air Ducts")]
	public float airDuctYOffset;

	public DoorPairPreset wallVentTop;

	public DoorPairPreset wallVentUpper;

	public DoorPairPreset wallVentLower;

	public DoorPairPreset wallNormal;

	public DoorPairPreset wallVentUpperWithTopSpace;

	public DoorPairPreset wallVentLowerWithTopSpace;

	public Material ductMaterial;

	public GameObject ductStraightModel;

	public GameObject ductStraightWithPeekVent;

	[Header("Misc Controls")]
	public float ceilingFanSpeed;

	[Space(7f)]
	public List<AirDuctOffset> airDuctModels;

	private static InteriorControls _instance;

	public static InteriorControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
