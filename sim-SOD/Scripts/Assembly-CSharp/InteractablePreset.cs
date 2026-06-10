using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "object_data", menuName = "Database/Interactable Preset")]
public class InteractablePreset : SoCustomComparison
{
	[Serializable]
	public class AIUseSetting
	{
		[Tooltip("Usage point relative to the interactable. Calculated on spawn/move position.")]
		public Vector3 usageOffset;

		[Tooltip("Look at point relative to the interactable. Calculated on spawn/move position.")]
		public Vector3 facingOffset;

		[Tooltip("If true, this will use the parent node's floor Y value for the position")]
		public bool useNodeFloorPosition;

		[Tooltip("If true, flip the Z axis usage offset depending on actor relative position to the door")]
		public bool useDoorBehaviour;

		[Tooltip("If true use the citizen's sitting offset position")]
		public bool useSittingOffset;

		[Tooltip("If true use the citizen's standing offset position")]
		public bool useArmsStandingOffset;
	}

	public enum InteractionKey
	{
		none = 0,
		primary = 1,
		secondary = 2,
		alternative = 3,
		scrollAxisUp = 4,
		scrollAxisDown = 5,
		jump = 6,
		crouch = 7,
		sprint = 8,
		flashlight = 9,
		caseBoard = 10,
		map = 11,
		notebook = 12,
		moveHorizontal = 13,
		moveVertical = 14,
		lookHorizontal = 15,
		lookVertical = 16,
		WeaponSelect = 17,
		nearestInteractable = 18,
		CaseBoardZoomAxis = 19,
		MoveEvidenceAxisX = 20,
		MoveEvidenceAxisY = 21,
		ContentMoveAxisX = 22,
		ContentMoveAxisY = 23,
		SelectLeft = 24,
		SelectRight = 25,
		SelectUp = 26,
		SelectDown = 27,
		CreateString = 28,
		LeanLeft = 29,
		LeanRight = 30,
		Back = 31,
		Select = 32,
		Menu = 33,
		MoveEvidence = 34
	}

	public enum Switch
	{
		switchState = 0,
		custom1 = 1,
		custom2 = 2,
		custom3 = 3,
		lockState = 4,
		lockedIn = 5,
		sprinting = 6,
		enforcersInside = 7,
		ko = 8,
		securityGrid = 9,
		carryPhysicsObject = 10
	}

	[Serializable]
	public class SwitchState
	{
		public Switch switchState;

		public bool boolIs;
	}

	[Serializable]
	public class IfSwitchState
	{
		public Switch switchState;

		public bool boolIs;
	}

	[Serializable]
	public class IfSwitchStateSFX
	{
		public Switch switchState;

		public bool boolIs;

		public AudioEvent triggerAudio;

		public bool isLoop;

		public bool isBroadcast;

		public bool isMusicPlayer;

		public AudioController.StopType stop;

		[Tooltip("Passes an open parameter to FMOD based on switch state")]
		public bool passOpenParam;

		[Tooltip("Passes the consumable state parameter to FMOD based on switch state")]
		public bool passCSParam;

		[Tooltip("Pass door opening or closing direction")]
		public bool passDoorDirParam;

		[Tooltip("Only if player is inside sync bed/chamber")]
		public bool onlyIfInSyncBed;

		[Tooltip("Only if player is not inside sync bed/chamber")]
		public bool onlyIfNotInSyncBed;

		[Tooltip("Only if this door features a neon sign")]
		public bool onlyIfNeonSign;
	}

	[Serializable]
	public class InteractionAction
	{
		public enum SpecialCase
		{
			none = 0,
			takeSwap = 1,
			onlyIfDeadAsleepOrUncon = 2,
			availableInFastForward = 3,
			onlyAvailableInFastForward = 4,
			caseFormsNeeded = 5,
			activeCaseHandInReady = 6,
			search = 7,
			knockOnDoor = 8,
			putBack = 9,
			originalPlace = 10,
			onlyIfRestrained = 11,
			onlyIfNotRestrained = 12,
			ifInventoryItemDrawn = 13,
			onlyIfSick = 14,
			nonCombat = 15,
			onlyIfMultiPageHasPages = 16,
			onlyInNormalTimeAndAwakeNonDialog = 17,
			nonDialog = 18,
			decorPlacementPurchase = 19,
			furniturePlacement = 20,
			decorItemPlacement = 21,
			citizenReturn = 22,
			nonCombatOrRestrained = 23,
			validTransitionZone = 24,
			onlyIfRegularRotation = 25,
			takePrintsFromBody = 26
		}

		[Tooltip("The dictionary reference to this action's name")]
		public string interactionName;

		[Tooltip("The action preset")]
		public AIActionPreset action;

		[Tooltip("Use the default key as found on the action preset...")]
		public bool useDefaultKeySetting;

		[Tooltip("Which key will activate this?")]
		public InteractionKey keyOverride;

		[Tooltip("Alter the interaction name based on special cases")]
		public SpecialCase specialCase;

		[Tooltip("Is this usable by the AI")]
		[Space(7f)]
		public bool usableByAI;

		[Tooltip("When AI is performing this, use a delay (seconds)")]
		[ShowIf("usableByAI")]
		public float aiUsageDelay;

		[Tooltip("This action effects these states")]
		[Space(7f)]
		public List<SwitchState> effectSwitchStates;

		[Tooltip("This action is only enabled if the following is true")]
		[Space(7f)]
		public List<IfSwitchState> onlyActiveIf;

		[Tooltip("Is this action illegal?")]
		[Space(7f)]
		public bool actionIsIllegal;

		[Tooltip("Is this action available while illegal?")]
		public bool availableWhileIllegal;

		[EnableIf("availableWhileIllegal")]
		[Tooltip("If above is true, is this allowed when others have witnessed illegal activity?")]
		public bool availableWhileWitnessesToIllegal;

		[Tooltip("Force availability on restrained while illegal status is active")]
		public bool onlyAvailableToRestrainedWhileIllegal;

		[Tooltip("Is this action available while using a locked in action?")]
		public bool availableWhileLockedIn;

		[Tooltip("Is this action available while jumping?")]
		public bool availableWhileJumping;

		[Tooltip("Cost of performing this action")]
		public int actionCost;

		[Tooltip("If true when this action is unavailable, it will be striked through instead of invisible")]
		[Space(5f)]
		public bool useStrikethrough;

		[Tooltip("Is this a hiding place?")]
		public bool isHidingPlace;

		[Tooltip("Only a hiding place in areas classed as public")]
		[EnableIf("isHidingPlace")]
		public bool onlyHidingPlaceIfPublic;

		[Tooltip("Sound event reference for this action")]
		[Space(7f)]
		public AudioEvent soundEvent;

		[Tooltip("If true this sound event will automatically be played on trigger. If false then this is just a reference for the sound indicator to known the sound level.")]
		public bool playOnTrigger;

		public InteractionKey GetInteractionKey()
		{
			return default(InteractionKey);
		}
	}

	public enum InteractableColourSetting
	{
		none = 0,
		ownersFavColour = 1,
		randomColour = 2,
		randomDecorColour = 3,
		syncDisk = 4
	}

	public enum ItemClass
	{
		consumable = 0,
		medical = 1,
		equipment = 2,
		document = 3,
		misc = 4,
		electronics = 5
	}

	public enum ApartmentPlacementMode
	{
		physics = 0,
		vertical = 1,
		ceiling = 2
	}

	[Serializable]
	public class AIUsePriority
	{
		public List<AIActionPreset> actions;

		[Range(0f, 10f)]
		[Tooltip("AI will rank actions by this if there are multiple copies")]
		public float AIPriority;

		[Tooltip("When chosing between interactables, how much to factor in the closest one?")]
		public float pickDistanceMultiplier;
	}

	[Serializable]
	public class ObjectResetBehaviour
	{
		public Switch ifSwitchState;

		public bool ifSwitchBool;

		public ObjectResetCondition ifCondition;

		public AIGoalPreset ifGoal;

		public ObjectResetScope scope;

		public bool onlyIfObjectBelongsTo;

		public bool onlyIfAuthority;

		public bool onlyIfLastOccupant;

		public bool onlyIfHome;

		public List<AIActionPreset> insertActions;
	}

	public enum ObjectResetCondition
	{
		leavingLocation = 0,
		goalActive = 1,
		goalActivated = 2,
		goalDeactivated = 3
	}

	public enum ObjectResetScope
	{
		ifInSameRoom = 0,
		ifInSameLocation = 1
	}

	public enum ReadingModeSource
	{
		evidenceNote = 0,
		multipageEvidence = 1,
		time = 2,
		bookPreset = 3,
		recordPreset = 4,
		syncDiskPreset = 5,
		mainEvidenceText = 6,
		kaizenSkillDisplay = 7
	}

	public enum AutoPlacement
	{
		always = 0,
		onlyInCompany = 1,
		onlyInHomes = 2,
		onlyOnStreet = 3,
		never = 4
	}

	[Serializable]
	public class TraitPick
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		[Range(0f, 20f)]
		[Tooltip("If the rules match, then apply this frequency")]
		public int appliedFrequencyMin;

		[Tooltip("If the rules match, then apply this frequency")]
		[Range(0f, 20f)]
		public int appliedFrequencyMax;
	}

	public enum OwnedPlacementRule
	{
		nonOwnedOnly = 0,
		ownedOnly = 1,
		prioritiseNonOwned = 2,
		prioritiseOwned = 3,
		both = 4
	}

	public enum RelocationAuthority
	{
		AIAndOwnersCanRelocate = 0,
		ownerCanRelocate = 1,
		anyoneCanRelocate = 2,
		nooneCanRelocate = 3
	}

	public enum FindEvidence
	{
		none = 0,
		residentsContract = 1,
		sideJob = 2,
		companyRoster = 3,
		addressKey = 4,
		businessCard = 5,
		namePlacard = 6,
		photo = 7,
		calendar = 8,
		retailItem = 9,
		workID = 10,
		salesRecords = 11,
		diary = 12,
		menu = 13,
		homeFile = 14,
		birthCertificate = 15,
		bankStatement = 16,
		medicalDetails = 17,
		IDCard = 18,
		addressBook = 19,
		residentRoster = 20,
		telephone = 21,
		callLogs = 22,
		hospitalBed = 23
	}

	public enum SpecialCase
	{
		none = 0,
		sleepPosition = 1,
		workDesk = 2,
		workCounter = 3,
		workKitchen = 4,
		securityDoor = 5,
		alarmSystem = 6,
		sentryGun = 7,
		securityCamera = 8,
		interestBook = 9,
		bookStack = 10,
		thrownItem = 11,
		fingerprint = 12,
		shower = 13,
		syncDisk = 14,
		unused1 = 15,
		unused2 = 16,
		codebreaker = 17,
		doorWedge = 18,
		telephone = 19,
		hospitalBed = 20,
		syncBed = 21,
		padlock = 22,
		salesLedger = 23,
		caseTray = 24,
		footprint = 25,
		breakerSecurity = 26,
		breakerLights = 27,
		breakerDoors = 28,
		fridge = 29,
		stovetopKettle = 30,
		syncDiskUpgrade = 31,
		otherSecuritySystem = 32,
		gasReleaseSystem = 33,
		tracker = 34,
		grenade = 35,
		ballisticArmour = 36,
		forceStanding = 37,
		lightswitch = 38,
		airVent = 39,
		burningBarrel = 40,
		addressBook = 41,
		garbageDisposal = 42,
		glassBulletHole = 43,
		bloodPool = 44,
		briefcase = 45,
		umbrella = 46,
		basBouleCardCommon = 47,
		basBouleCardRare = 48,
		basBouleCardVeryRare = 49,
		cigarettes = 50,
		cigars = 51,
		microcruncher = 52
	}

	[Serializable]
	public class SubSpawnSlot
	{
		public Vector3 localPos;

		public Vector3 localEuler;
	}

	[Header("Spawning")]
	[Tooltip("If true this object can be spawned through the object creator")]
	public bool spawnable;

	[Tooltip("You only need to set this if the item is spawnable.")]
	[ShowIf("spawnable")]
	public GameObject prefab;

	[Tooltip("This value is held as a workaround for not being able to access the prefab in multithreading")]
	[ShowIf("spawnable")]
	[ReadOnly]
	public Vector3 prefabLocalEuler;

	[Tooltip("This value is held as a workaround for not being able to access the prefab in multithreading")]
	[ShowIf("spawnable")]
	[ReadOnly]
	public Vector3 prefabLocalScale;

	[Tooltip("Don't save with state data")]
	public bool dontSaveWithSaveGames;

	[ShowIf("dontSaveWithSaveGames")]
	[Tooltip("Override the above behaviour if this is classed a world object; useful for lightswitches if they have been placed by the player")]
	public bool onlySaveWithSaveGamesIfWorldObject;

	[Tooltip("Object pooling will not be used for this")]
	[ShowIf("spawnable")]
	public bool excludeFromObjectPooling;

	[Tooltip("If true, the mesh renderers on this object won't get turned on and off with range or room visibility.")]
	[ShowIf("excludeFromObjectPooling")]
	public bool excludeFromVisibilityRangeChecks;

	[ShowIf("spawnable")]
	[Tooltip("Load in at this range")]
	[DisableIf("excludeFromVisibilityRangeChecks")]
	public ObjectPoolingController.ObjectLoadRange spawnRange;

	[Tooltip("If true include in any scene capturing. If false the object will be hidden. Toggle for any static or integrated objects.")]
	[Header("Scene Capture")]
	public bool showWorldObjectInSceneCapture;

	[EnableIf("showWorldObjectInSceneCapture")]
	[Tooltip("If true, capture and set the state of this object for captures")]
	public bool captureStateInSceneCapture;

	[DisableIf("showWorldObjectInSceneCapture")]
	public bool createProxy;

	[ShowIf("createProxy")]
	public bool onlyCreateProxyInDetailedCapture;

	[ShowIf("createProxy")]
	public ObjectPoolingController.ObjectLoadRange createProxyAtRange;

	[Header("Colour")]
	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room. Does not apply to integrated interactables which will be coloured by their parent furniture.")]
	public bool inheritColouringFromDecor;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room. Difference from furniture: This cannot 'create' a material key, so furniture with it must already exist in the room.")]
	[ShowIf("inheritColouringFromDecor")]
	public FurniturePreset.ShareColours shareColoursWithFurniture;

	[Tooltip("If this object needs custom colours...")]
	[HideIf("inheritColouringFromDecor")]
	public bool useOwnColourSettings;

	[ShowIf("useOwnColourSettings")]
	public InteractableColourSetting mainColour;

	[ShowIf("useOwnColourSettings")]
	public InteractableColourSetting customColour1;

	[ShowIf("useOwnColourSettings")]
	public InteractableColourSetting customColour2;

	[ShowIf("useOwnColourSettings")]
	public InteractableColourSetting customColour3;

	[ShowIf("useOwnColourSettings")]
	public bool inheritGrubValue;

	[Tooltip("Attempt to name this using evidence entry or preset name, if false you must set this manually.")]
	[Header("Setup")]
	public bool autoName;

	[Tooltip("Include belongs to name in interactable name")]
	public bool includeBelongsTo;

	[Tooltip("Use a shorthand version of the name (Initial + Surname)")]
	[ShowIf("includeBelongsTo")]
	public bool useNameShorthand;

	[ShowIf("includeBelongsTo")]
	public bool useApartmentName;

	[Tooltip("Is this a light?")]
	public LightingPreset isLight;

	public Switch lightswitch;

	[Tooltip("If true, allows an unscrewed override state (cutsom switch 1)")]
	public bool allowUnscrewed;

	public bool isMainLight;

	[Tooltip("If true, this light is added to layer 1; the light layer for street lights")]
	public bool forceIncludeOnStreetLightLayer;

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

	[Tooltip("Weapon selection icon override")]
	[ShowAssetPreview(64, 64)]
	public Sprite iconOverride;

	public ItemClass itemClass;

	public bool allowInApartmentStorage;

	[EnableIf("allowInApartmentStorage")]
	public bool allowInApartmentShop;

	[Tooltip("If enabled, this item cannot be 'moved to storage'. Only needed for spawnable items")]
	[EnableIf("spawnable")]
	public bool disableMoveToStorage;

	[Tooltip("The method of placement used when the player uses the apartment editor to place this")]
	[EnableIf("allowInApartmentStorage")]
	public ApartmentPlacementMode apartmentPlacementMode;

	public List<FurniturePreset> mustTouchFurniture;

	[Space(7f)]
	public bool useMaterialOverride;

	[EnableIf("useMaterialOverride")]
	public AudioController.SoundMaterialOverride materialOverride;

	[Header("Interaction")]
	[Tooltip("Setup of actions able to be performed")]
	public List<InteractableActionsPreset> actionsPreset;

	[Tooltip("Illegal actions are only classed as illegal if the item is in a non-public space")]
	public bool onlyIllegalIfInNonPublic;

	[Tooltip("This modifier will be added to the interactable distance")]
	public float rangeModifier;

	[Header("Physics")]
	public PhysicsProfile physicsProfile;

	public bool overrideMass;

	public bool forcePhysicsAlwaysOn;

	[Tooltip("If true this object will react with doors, damage impacts etc")]
	public bool reactWithExternalStimuli;

	[ShowIf("overrideMass")]
	public float mass;

	public bool breakable;

	[EnableIf("breakable")]
	public ParticleEffect particleProfile;

	[EnableIf("breakable")]
	public bool overrideShatterSettings;

	[EnableIf("overrideShatterSettings")]
	[Tooltip("The size of the shards created")]
	public Vector3 shardSize;

	[EnableIf("overrideShatterSettings")]
	[Tooltip("Create a shard every this amount of pixels on the texture")]
	public int shardEveryXPixels;

	[EnableIf("breakable")]
	public bool overrideSpatterSettings;

	[EnableIf("overrideSpatterSettings")]
	public SpatterPatternPreset spatterSimulation;

	[EnableIf("overrideSpatterSettings")]
	public float spatterCountMultiplier;

	[Header("Hiding Place Override")]
	[Tooltip("Use this to override the hiding place camera settings in the furniture preset")]
	public bool overrideFurnitureSetting;

	[ShowIf("overrideFurnitureSetting")]
	public PlayerTransitionPreset enterTransition;

	[ShowIf("overrideFurnitureSetting")]
	public PlayerTransitionPreset exitTransition;

	[ShowIf("overrideFurnitureSetting")]
	public PlayerTransitionPreset enterTransition2;

	[ShowIf("overrideFurnitureSetting")]
	public PlayerTransitionPreset exitTransition2;

	[Tooltip("Trigger audio on these switch events")]
	[Header("Trigger Sounds")]
	public List<IfSwitchStateSFX> switchSFX;

	[Header("Starting States")]
	[Tooltip("Set the switch state to this on start")]
	public bool startingSwitchState;

	[Tooltip("Set the switch state to this on start")]
	public bool startingCustomState1;

	[Tooltip("Set the switch state to this on start")]
	public bool startingCustomState2;

	[Tooltip("Set the switch state to this on start")]
	public bool startingCustomState3;

	[Tooltip("Set the lock state to this on start")]
	public bool startingLockState;

	[Tooltip("Monetary value of this object. Min/Max.")]
	[MinMaxSlider(0f, 10000f)]
	[Header("Value")]
	public Vector2 value;

	[Header("AI")]
	[Tooltip("AI will rank actions by this if there are multiple copies")]
	[Range(0f, 10f)]
	public int AIPriority;

	[Tooltip("Is this incompatible for social gatherings? Ie if I'm meeting someone here...")]
	public bool disableForSocialGroups;

	[Tooltip("When chosing between interactables, how much to factor in the closest one?")]
	public float pickDistanceMultiplier;

	[Tooltip("Use unique settings per action for each of the following")]
	public List<AIUsePriority> perActionPrioritySettings;

	[Tooltip("Will the AI notice if this is moved?")]
	public bool tamperEnabled;

	[Tooltip("Object reset behaviours based on activity and conditions")]
	[Space(7f)]
	public List<ObjectResetBehaviour> resetBehaviour;

	[Space(7f)]
	[Tooltip("The AI will move to one of these postions to use this")]
	public AIUseSetting useSetting;

	[Header("Reading")]
	[Tooltip("If within reading range then display text contained in this evidence")]
	public bool readingEnabled;

	[ShowIf("readingEnabled")]
	[Tooltip("Reading mode is only active while switch status is true")]
	public bool readyingEnabledOnlyWithSwitchIsTue;

	[Tooltip("Reading mode is only active while switch status is true")]
	[ShowIf("readingEnabled")]
	public bool readingEnabledOnlyWithKaizenSkill;

	[ShowIf("readingEnabled")]
	[Tooltip("Where to pull the text info from")]
	public ReadingModeSource readingSource;

	[ShowIf("readingEnabled")]
	[Tooltip("Discover evidence upon read")]
	public bool discoverOnRead;

	[ShowIf("readingEnabled")]
	[Tooltip("A delay to reading when a page is turned")]
	public float pageTurnReadingDelay;

	[Header("Distance Recognition")]
	[Tooltip("If within a certain range, then display a grey-ed out interaction icon with name text")]
	public bool distanceRecognitionEnabled;

	public bool distanceRecognitionOnly;

	public float recognitionRange;

	[Header("Placement")]
	[Tooltip("Spawn this object using this sub object group")]
	public List<SubObjectClassPreset> subObjectClasses;

	[Tooltip("If the object fails to be placed in the above, use this class as a fall-back placement option. This is irrelevent for auto placement, as objects are spawned by the individual placements upon furniture, these places won't be considered.")]
	public List<SubObjectClassPreset> backupClasses;

	[Space(5f)]
	[Tooltip("Whether this will be automatically placed along with furniture...")]
	public AutoPlacement autoPlacement;

	[Tooltip("If true, these objects will be placed with no owners at every gamelocation (based on other filters in this section).")]
	[Header("...Per Game Location")]
	public bool alwaysPlaceAtGameLocation;

	[Tooltip("The minimum number of objects that will be auto-placed at every gamelocation")]
	[ShowIf("alwaysPlaceAtGameLocation")]
	[Range(0f, 20f)]
	public int frequencyPerGamelocationMin;

	[Tooltip("The minimum number of objects that will be auto-placed at every gamelocation")]
	[ShowIf("alwaysPlaceAtGameLocation")]
	[Range(0f, 20f)]
	public int frequencyPerGameLocationMax;

	[Tooltip("Dictates in what order objects should be placed in...")]
	[ShowIf("alwaysPlaceAtGameLocation")]
	[Range(0f, 10f)]
	public int perGameLocationObjectPriority;

	[Header("...Per Owner")]
	[Tooltip("If true, owners/inhabitants/employees will be scanned for these traits and items will be placed accordingly...")]
	public bool placeIfFiltersPresentInOwner;

	[Tooltip("Place if this is the citizen's home")]
	[ShowIf("placeIfFiltersPresentInOwner")]
	public bool placeAtHome;

	[Tooltip("Place if this is the citizen's place of work")]
	[ShowIf("placeIfFiltersPresentInOwner")]
	public bool placeAtWork;

	public List<TraitPick> traitModifiers;

	[ShowIf("placeIfFiltersPresentInOwner")]
	[Tooltip("The minimum number of objects that will be auto-placed for each owner")]
	[Range(0f, 20f)]
	public int frequencyPerOwnerMin;

	[Tooltip("The minimum number of objects that will be auto-placed for each owner")]
	[ShowIf("placeIfFiltersPresentInOwner")]
	[Range(0f, 20f)]
	public int frequencyPerOwnerMax;

	[Tooltip("If true, the overall frequency range will be multiplied by the inverse of conscientiousness (untidy = more)")]
	[ShowIf("placeIfFiltersPresentInOwner")]
	public bool multiplyByMessiness;

	[Tooltip("Dictates in what order objects should be placed in...")]
	[Range(0f, 10f)]
	[ShowIf("placeIfFiltersPresentInOwner")]
	public int perOwnerObjectPriority;

	[ShowIf("placeIfFiltersPresentInOwner")]
	public EvidencePreset.BelongsToSetting writerIs;

	[ShowIf("placeIfFiltersPresentInOwner")]
	public EvidencePreset.BelongsToSetting receiverIs;

	[ShowIf("placeIfFiltersPresentInOwner")]
	[Tooltip("If the above two options are different, is this allowed to be from the same person to the same person?")]
	public bool canBeFromSelf;

	[Header("Placement Limits")]
	public bool limitPerObject;

	[Tooltip("How many of these objects can be spawned per object?")]
	[ShowIf("limitPerObject")]
	public int perObjectLimit;

	public bool limitPerRoom;

	[ShowIf("limitPerRoom")]
	[Tooltip("How many of these objects can be spawned per room?")]
	public int perRoomLimit;

	public bool limitPerAddress;

	[Tooltip("How many of these objects can be spawned per address?")]
	[ShowIf("limitPerAddress")]
	public int perAddressLimit;

	public bool limitInResidential;

	[Tooltip("How many of these objects can be spawned if residential?")]
	[ShowIf("limitInResidential")]
	public int perResidentialLimit;

	public bool limitInCommercial;

	[Tooltip("How many of these objects can be spawned if residential?")]
	[ShowIf("limitInCommercial")]
	public int perCommercialLimit;

	[Tooltip("Ban this item from being placed in certain room types")]
	[HideIf("limitToCertainRooms")]
	public List<RoomConfiguration> banFromRooms;

	[Tooltip("Only feature this item in certain room types")]
	public bool limitToCertainRooms;

	[ShowIf("limitToCertainRooms")]
	public List<RoomConfiguration> onlyInRooms;

	[Tooltip("Only feature this item in certain building types")]
	public bool limitToCertainBuildings;

	[ShowIf("limitToCertainBuildings")]
	public List<BuildingPreset> onlyInBuildings;

	[Tooltip("If this is not null, it will attempt to place this evidence inside a folder matching this evidence type.")]
	[Space(7f)]
	public EvidencePreset attemptToStoreInFolder;

	[Range(0f, 1f)]
	[Tooltip("If the above is not null, the chance of being placed in the folder.")]
	public float folderPlacementChance;

	[Tooltip("If unable to place in folder, then don't place at all")]
	public bool dontPlaceIfNoFolder;

	[Tooltip("Folder's ownership must match")]
	public bool folderOwnershipMustMatch;

	[Tooltip("If true this will also look to spawn upon on other objects (and prioritize them)")]
	public bool useSubSpawning;

	[Tooltip("This will try to be placed in a place of security matching this, if not higher...")]
	[Range(0f, 3f)]
	public int securityLevel;

	[Tooltip("Rules about being placed in owned vs non-owned locations. 'Prioritise' settings will favour owned locations but sill place in non-owned, while 'only' settings will only place in that location.")]
	public OwnedPlacementRule ownedRule;

	[Tooltip("Override with ownedOnly if at work")]
	public bool overrideWithOnlyOwnedSpawnAtWork;

	[Space(7f)]
	[Tooltip("Can sub spawn objects with this class")]
	public SubObjectClassPreset subSpawnClass;

	[Tooltip("Sub spawning slots within this")]
	public List<SubSpawnSlot> subSpawnPositions;

	[Header("Relocation")]
	[Tooltip("If the object is moved by this person, also set the spawn point so it doesn't get reset.")]
	public RelocationAuthority relocationAuthority;

	[Tooltip("Will not reset if placed in the player's home")]
	public bool relocateIfPlacedInPlayersHome;

	[Tooltip("AI will attempt to put back this if it is out of place")]
	public bool AIWillCorrectPosition;

	[Header("Evidence")]
	[Tooltip("Does this interactable need to reference a piece of evidence? If true will attempt to find the evidence as below (will be overriden by passed variabes in the constructor)")]
	public bool useEvidence;

	[ShowIf("useEvidence")]
	[Tooltip("If not null, will attempt to find the singleton using this preset...")]
	public EvidencePreset useSingleton;

	[ShowIf("useEvidence")]
	[Tooltip("Use a specific evidence from below")]
	public FindEvidence findEvidence;

	[Tooltip("Create an evidence class of below")]
	public EvidencePreset spawnEvidence;

	[ShowIf("useEvidence")]
	[Tooltip("On create evidence: Use the item's location as evidence parent")]
	public bool locationIsParent;

	[Tooltip("Use this DDS message ID for the summary")]
	public string summaryMessageSource;

	[Space(7f)]
	public bool overrideEvidencePhotoSettings;

	[ShowIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoPos;

	[ShowIf("overrideEvidencePhotoSettings")]
	public Vector3 relativeCamPhotoEuler;

	[Header("Locks")]
	public InteractablePreset includeLock;

	public Vector3 lockOffset;

	[Tooltip("Preferred password source")]
	public RoomConfiguration.RoomPasswordPreference passwordSource;

	[Tooltip("Play this when attempted to open while locked")]
	public AudioEvent attemptedOpenSound;

	[Tooltip("The lock is armed when the door movement is closed")]
	public bool armLockOnClose;

	[Tooltip("If this isn't an actual door, this is the lock strength range...")]
	public Vector2 lockStrength;

	[Tooltip("This object itself acts as the lock")]
	public bool isSelfLock;

	[Header("Material Changes")]
	public bool useMaterialChanges;

	[ShowIf("useMaterialChanges")]
	public Material lockOffMaterial;

	[ShowIf("useMaterialChanges")]
	public Material lockOnMaterial;

	[Header("Computer")]
	[Tooltip("Is this a computer (cruncher)?")]
	public bool isComputer;

	[ShowIf("isComputer")]
	[Tooltip("The boot application")]
	public CruncherAppPreset bootApp;

	[ShowIf("isComputer")]
	[Tooltip("The booted app (what this boots to)")]
	public CruncherAppPreset logInApp;

	[ShowIf("isComputer")]
	[Tooltip("The desktop app")]
	public CruncherAppPreset desktopApp;

	[ShowIf("isComputer")]
	[Tooltip("Additional apps")]
	public List<CruncherAppPreset> additionalApps;

	[Tooltip("Should there be fingerprints here?")]
	[Header("Fingerprints")]
	public bool fingerprintsEnabled;

	[ShowIf("fingerprintsEnabled")]
	[Tooltip("The source of the prints")]
	public RoomConfiguration.PrintsSource printsSource;

	[ShowIf("fingerprintsEnabled")]
	[Range(0f, 5f)]
	[Tooltip("Fingerprint density")]
	public float fingerprintDensity;

	[ShowIf("fingerprintsEnabled")]
	[Tooltip("Dynamic fingerprints will be left when an AI uses this")]
	public bool enableDynamicFingerprints;

	[ShowIf("fingerprintsEnabled")]
	public bool disableDynamicFingerprintsFromStaticPrintsSources;

	[ShowIf("fingerprintsEnabled")]
	[Tooltip("Override the default fingerprint maximum")]
	public bool overrideMaxDynamicFingerprints;

	[EnableIf("overrideMaxDynamicFingerprints")]
	[ShowIf("fingerprintsEnabled")]
	public int maxDynamicFingerprints;

	[Tooltip("If this is a first person item, the corresponding item ID")]
	[Header("First Person Setup")]
	public FirstPersonItem fpsItem;

	public bool isInventoryItem;

	[Tooltip("Offset of held item")]
	[ShowIf("isInventoryItem")]
	public Vector3 fpsItemOffset;

	[ShowIf("isInventoryItem")]
	public Vector3 fpsItemRotation;

	[ShowIf("isInventoryItem")]
	[Tooltip("Added to the FPS item scale (default usually 4100 in all dimensions)")]
	public Vector3 fpsItemScaleModifier;

	[Tooltip("The amount of consumable; consumed at 1 per second by the player")]
	public float consumableAmount;

	[ShowIf("isInventoryItem")]
	[Tooltip("Destroy when this is all consumed")]
	public bool destroyWhenAllConsumed;

	[ShowIf("isInventoryItem")]
	[Tooltip("Trash object")]
	public bool useSameModelAsTrash;

	[DisableIf("useSameModelAsTrash")]
	[ShowIf("isInventoryItem")]
	public InteractablePreset trashItem;

	[ShowIf("isInventoryItem")]
	public AudioEvent playerConsumeLoop;

	[ShowIf("isInventoryItem")]
	public AudioEvent takeOneEvent;

	[Space(7f)]
	[ShowIf("isInventoryItem")]
	[DisableIf("destroyWhenAllConsumed")]
	public Human.DisposalType disposal;

	[Range(0f, 1f)]
	[DisableIf("destroyWhenAllConsumed")]
	public float chanceOfDroppedAngle;

	[DisableIf("destroyWhenAllConsumed")]
	public float droppedAngleHeightBoost;

	[ShowIf("isInventoryItem")]
	public MurderWeaponPreset weapon;

	[ShowIf("isInventoryItem")]
	[Tooltip("If in inventory, display object")]
	public bool inventoryCarryItem;

	[Tooltip("This required a carrying animation")]
	[ShowIf("isInventoryItem")]
	public bool requiredCarryAnimation;

	[Tooltip("If an AI can carry this, which carrying animation to play")]
	[ShowIf("isInventoryItem")]
	public int aiCarryAnimation;

	[ShowIf("isInventoryItem")]
	[Tooltip("position object by this when AI is holding")]
	public Vector3 aiHeldObjectPosition;

	[ShowIf("isInventoryItem")]
	[Tooltip("Rotate object by this when AI is holding")]
	public Vector3 aiHeldObjectRotation;

	[ShowIf("isInventoryItem")]
	[Tooltip("The AI will put this down when at home")]
	public bool putDownAtHome;

	[Tooltip("The AI will take this when they leave home")]
	public bool takeWith;

	[ShowIf("isInventoryItem")]
	public List<SubObjectClassPreset> putDownPositions;

	[ShowIf("isInventoryItem")]
	public List<SubObjectClassPreset> backupPutDownPositions;

	[Header("Special cases")]
	public SpecialCase specialCaseFlag;

	[Tooltip("Affect room steam amount with switch state 1")]
	public bool affectRoomSteamLevel;

	[Tooltip("This is a payphone")]
	public bool isPayphone;

	[Tooltip("This is a clock; use hourly chimes")]
	public bool isClock;

	[Tooltip("If true this will be a naming special case.")]
	public bool isMoney;

	[Tooltip("According to AI, only 1 entertainment source should be active in a room")]
	public bool entertainmentSource;

	[Tooltip("Is this a heat source? Only active when switch 0 is on")]
	public bool isHeatSource;

	[Tooltip("Mark this as trash as soon as it is created, for removal as soon as possible")]
	public bool markAsTrashOnCreate;

	[Tooltip("If picked up, the AI will seek to put this in a bin/gets added to their carrying trash")]
	public bool isLitter;

	[Tooltip("Will require an art asset sent to a decal projector")]
	public bool isDecal;

	[Tooltip("Used for detecting work positions/animations mostly")]
	public bool isMovableChair;

	[Tooltip("This is the right side of a double bed")]
	public bool bedRightSide;

	[Tooltip("Resets switch states to starting configuration after x amount of time")]
	public bool resetSwitchStates;

	[EnableIf("resetSwitchStates")]
	public float resetTimer;

	[Tooltip("Don't save switch states")]
	public bool dontSaveSwitchStates;

	[Tooltip("Don't load switch states")]
	public bool dontLoadSwitchStates;

	[Tooltip("If true, the game will record the creation time of this in passed variables")]
	public bool recordCreationTime;

	[Tooltip("If this is a music player: Track list")]
	public List<AudioEvent> musicTracks;

	[Tooltip("Is this a retailItem? If so here's the reference. This is set by having a RetailItem Preset that points to this.")]
	public RetailItemPreset retailItem;

	[Tooltip("If this is associated with a shop interface, override the location's menu with this one (useful for vending machines)")]
	public MenuPreset menuOverride;

	[ShowIf("isClock")]
	public AudioEvent hourlyChime;

	[Tooltip("Do as many chimes as the hour dictates")]
	[ShowIf("isClock")]
	public bool chimeEqualToHour;

	[ShowIf("isClock")]
	[Tooltip("Delay between chimes if above is true")]
	public float chimeDelay;

	[Tooltip("Audio loop played on search")]
	public AudioEvent searchLoop;

	public List<InteractionAction> GetActions(int lockedInPhase = 0)
	{
		return null;
	}

	public PhysicsProfile GetPhysicsProfile()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyFPSHeldPostionFromTransform()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CalculateDroppedAngleHeightBoost()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnIntoInventory()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetToZeroValue()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CreateOwnEvidence()
	{
	}
}
