using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GameplayControls : MonoBehaviour
{
	[Serializable]
	public class SyncDiskColour
	{
		public SyncDiskPreset.Manufacturer category;

		public Color mainColour;

		public Color colour1;

		public Color colour2;

		public Color colour3;
	}

	[Header("Cut Scenes")]
	public CutScenePreset intro;

	public CutScenePreset outro;

	[Header("Time")]
	public SessionData.TimeSpeed startingTimeSpeed;

	[Tooltip("0 = slomo, 1 = normal, 2 = fast, 3 = ultrafast, 4 = sim")]
	[ReorderableList]
	public List<float> timeMultipliers;

	public int startingDate;

	public int startingMonth;

	public int startingYear;

	[Tooltip("Only time cycles idependent of the actual time data are needed here")]
	public int yearZeroLeapYearCycle;

	public int dayZero;

	public int publicYearZero;

	[Header("Routines")]
	public float routineUpdateFrequency;

	public float gameWorldUpdateFrequency;

	public float doorSequenceUpdateFrequency;

	public float stealthModeLoopUpdateFrequency;

	[Header("First Person")]
	[Tooltip("Player height (normal)")]
	public float playerHeightNormal;

	[Tooltip("Player height (crouched)")]
	public float playerHeightCrouched;

	public AnimationCurve crouchHeightCurve;

	public AnimationCurve leanCurve;

	public AnimationCurve joltCurve;

	[Tooltip("FPS Camera Y as offset of centre of player")]
	public float cameraHeightNormal;

	[Tooltip("FPS Camera Y as offset of centre of player")]
	public float cameraHeightCrouched;

	[Tooltip("Range from which things can be interacted-with by the player")]
	public float interactionRange;

	[Tooltip("Range from which things can be read by the player")]
	public float readingRange;

	[Tooltip("The distance from which things are carried by the player")]
	public float carryDistance;

	[Tooltip("The throw force of the player")]
	public float throwForce;

	[Tooltip("Field of view (Normal)")]
	public float fovNormal;

	[Tooltip("Field of view (interaction)")]
	public float fovInteraction;

	[Tooltip("How much FPS model lag")]
	public float fpsModelLag;

	[Tooltip("Player walk speed")]
	public float playerWalkSpeed;

	[Tooltip("Player run speed")]
	public float playerRunSpeed;

	[Tooltip("Jump height")]
	public float jumpHeight;

	[Tooltip("Player stealth mode walk multiplier")]
	public float playerStealthWalkMuliplier;

	[Tooltip("Player stealth mode run multiplier")]
	public float playerStealthRunMultiplier;

	[Tooltip("Head bob multiplier")]
	public float headBobMultiplier;

	[Tooltip("Player height multiplier in air ducts")]
	public float ductPlayerHeight;

	[Tooltip("Camera height multiplier in air ducts")]
	public float ductCamHeight;

	[Tooltip("Player height boost on enter air duct")]
	public float ductPlayerPosY;

	[Tooltip("Air duct entry point")]
	public Vector3 airDuctEntry;

	[Tooltip("Air duct exit point")]
	public Vector3 airDuctExit;

	[Tooltip("Normal skin width")]
	public float normalSkinWidth;

	[Tooltip("Carrying skin width")]
	public float carryingSkinWidth;

	[Tooltip("Normal skin width")]
	public float ductSkinWidth;

	[Tooltip("Default return transition")]
	public PlayerTransitionPreset defaultReturnTransition;

	public PlayerTransitionPreset enterVentTransition;

	public PlayerTransitionPreset exitVentTransition;

	public PlayerTransitionPreset citizensArrestTranstion;

	public PlayerTransitionPreset citizenTalkToTransition;

	public PlayerTransitionPreset doorPeekEnter;

	public PlayerTransitionPreset doorPeekExit;

	public PlayerTransitionPreset lockpickEnter;

	public PlayerTransitionPreset lockpickExit;

	public PlayerTransitionPreset sabotageEnter;

	public PlayerTransitionPreset sabotageExit;

	public PlayerTransitionPreset bargeDoorEnter;

	public PlayerTransitionPreset bargeDoorFail;

	public PlayerTransitionPreset bargeDoorSuccess;

	public PlayerTransitionPreset punchedReaction;

	public PlayerTransitionPreset playerKO;

	public PlayerTransitionPreset playerUseComputer;

	public PlayerTransitionPreset playerComputerExit;

	public PlayerTransitionPreset playerTakePrint;

	public PlayerTransitionPreset playerTakePrintExit;

	public PlayerTransitionPreset playerSearch;

	public PlayerTransitionPreset playerSearchExit;

	public PlayerTransitionPreset focusOnInteractable;

	public PlayerTransitionPreset waterCoolerEnter;

	[Header("Ragdolls")]
	[Tooltip("Force applied when the player drags a body")]
	public float dragForceAmount;

	[Tooltip("Amount of rotational camera movement allowed per second when dragging a body")]
	public float maxAngleMovementWhenDragging;

	[Tooltip("How far infront the player the ragdoll is held")]
	public float ragdollCarryMaxDistance;

	[Tooltip("Ragdoll preprocessing: Disabling preprocessing helps to stabilize impossible-to-fulfil configurations.")]
	public bool ragdollJointPreprocessing;

	public bool ragdollJointCollision;

	public bool ragdollJointProjection;

	public float ragdollJointContactDistance;

	public bool ragdollRigidbodyCollision;

	public float ragdollJointBounce;

	public float ragdollJointDampen;

	public float ragdollJointSpring;

	[Header("Depth of Field")]
	public float dofNormalNearStart;

	public float dofNormalNearEnd;

	public float dofNormalFarStart;

	public float dofNormalFarEnd;

	[Space(7f)]
	public float dofTalkingNearStart;

	public float dofTalkingNearEnd;

	public float dofTalkingFarStart;

	public float dofTalkingFarEnd;

	[Space(7f)]
	public float dofPausedNearStart;

	public float dofPausedNearEnd;

	public float dofPausedFarStart;

	public float dofPausedFarEnd;

	[Space(7f)]
	public float dofCityEditNearStart;

	public float dofCityEditNearEnd;

	public float dofCityEditFarStart;

	public float dofCityEditFarEnd;

	[Space(7f)]
	public float dofChangeTime;

	[ReorderableList]
	[Tooltip("Start the game with these first person items")]
	public List<FirstPersonItem> startingItems;

	public FirstPersonItem nothingItem;

	public FirstPersonItem watchItem;

	public FirstPersonItem fistsItem;

	public FirstPersonItem coinItem;

	public FirstPersonItem printReader;

	[Tooltip("How long to display the item switch interface when it is activated.")]
	public float itemSwitchCounter;

	[Tooltip("Curve for ambient light levels throughout the day")]
	[Header("Stealth")]
	public AnimationCurve stealthAmbientLightLevel;

	[Tooltip("The above is multiplied by this when inside to give ambient level")]
	public float interiorAmbientLightMultiplier;

	[Tooltip("Transform for the floor light measuring point (the camera is used for the upper)")]
	public Transform floorLightMeasure;

	[Tooltip("Curve for direct sun light levels throughout the day")]
	public AnimationCurve stealthSunLightLevel;

	[Tooltip("How long in gametime a building alarm lasts once triggered: From high to low so we can lerp with skill multiplier")]
	public Vector2 buildingAlarmTime;

	[Tooltip("How fast a camera/turret tracks it's target once alert")]
	public float securityTrackSpeed;

	[Tooltip("Citizen FoV")]
	public float citizenFOV;

	[Tooltip("Security FoV")]
	public float securityFOV;

	[Tooltip("Sabotage land value multiplier")]
	public float sabotageLandValueMP;

	[Tooltip("Citizen max sight range")]
	public float citizenSightRange;

	[Tooltip("Security max sight range")]
	public float securitySightRange;

	[Tooltip("Minimum stealth detection threshold. If target is closer than this, even targets with 0 visibility are spotted")]
	public float minimumStealthDetectionRange;

	[Tooltip("Sentry gun weapon config")]
	public MurderWeaponPreset sentryGunWeapon;

	[Tooltip("Sentry gun rate of fire")]
	public float sentryGunROF;

	[Tooltip("Sentry gun cone of fire")]
	public float sentryGunDamage;

	[Tooltip("Sentry gun cone of fire")]
	public float sentryGunAccuracy;

	[Tooltip("Maximum distance at which the player can officially 'spot' a citizen (used for triggering outlines etc)")]
	public float playerMaxSpotDistance;

	[Tooltip("Perform a player spotting check every x frames")]
	public int playerSpotUpdateEveryXFrame;

	[Tooltip("The time before a spotted actor becomes invisible to the player (seconds)")]
	public float spottedGraceTime;

	[Tooltip("The time it takes for a previously spotted actor to become invisible to the player again (seconds)")]
	public float spottedFadeSpeed;

	[Tooltip("While sighted, the grace time multiplier for spotting a person is x1, how long is it for hearing a player?")]
	public float audioOnlySpotGraceTimeMultiplier;

	[Tooltip("Maximum distance for surveillance capturing the image of the player")]
	public float playerImageCaptureMaxRange;

	[Tooltip("If security catches player, any fines are now active for this long...")]
	public float buildingWantedTime;

	[Tooltip("How long before breakers are reset")]
	public float breakerResetTime;

	[Tooltip("How long before turned off security is reactivated")]
	public float securityResetTime;

	[Tooltip("How long in gametime does it take for a room to fill up with toxic gas")]
	public float gasFillTime;

	[Tooltip("How long in gametime does it take for a room to empty of toxic gas")]
	public float gasEmptyTime;

	[Tooltip("How much time spent at a location trespassing before +1 is added to the escalation level")]
	[Space(7f)]
	public float additionalEscalationTime;

	[Tooltip("Start the game with this amount of money")]
	[Header("Skills")]
	public int startingMoney;

	[Tooltip("Start the game with this presence level")]
	public int startingLockpicks;

	[Tooltip("How much lock strength can be used up by a single lockpick as a range dictated by skill")]
	public Vector2 lockpickEffectivenessRange;

	[Tooltip("Lockpicking speed multiplier")]
	public Vector2 lockpickSpeedRange;

	[Tooltip("How much door strength damage is done when barged")]
	public Vector2 bargeDamageRange;

	[Space(7f)]
	public float baseMaxPlayerHealth;

	[Tooltip("The player recovers this amount of health (normalized) over time (game time 1 hour)")]
	public float playerRecoveryRate;

	[Tooltip("The player's starting combat skill")]
	public float playerCombatSkill;

	[Tooltip("The player's starting combat heft (damage per punch)")]
	public float playerCombatHeft;

	[Tooltip("The default number of inventory slots")]
	public int defaultInventorySlots;

	[Tooltip("Damage multiplier for physics objects hitting the player")]
	public float incomingPlayerPhysicsDamageMultiplier;

	[Space(7f)]
	public float commonSyncDisksPer200Citizens;

	public float mediumSyncDisksPer200Citizens;

	public float rareSyncDisksPer200Citizens;

	public float veryRareSyncDisksPer200Citizens;

	[Space(7f)]
	public int corpSabotageMoney;

	public int corpSabotageManagementBonus;

	public int moneyForAddresses;

	public int moneyForNewLocations;

	public int moneyForAirDucts;

	public int moneyForPasscodes;

	public int moneyForReading;

	public int moneyForStreetCleaning;

	public int passiveIncome;

	public float upgradeHeightModifier;

	public float upgradeRunSpeed;

	public float upgradeReach;

	public float upgradeHealth;

	public float upgradeRegen;

	[Tooltip("Applied to all fines: From high to lower and lerped with the health insurance skill")]
	public Vector2 legalInsuranceMultiplier;

	[Header("Social Credit")]
	public int socialCreditForLostAndFound;

	public int socialCreditForSideJobs;

	public int socialCreditForMurders;

	public AnimationCurve socialCreditLevelCurve;

	[Header("Evidence")]
	[Tooltip("Hot food is warm for this time after purchase")]
	public float foodHotTime;

	public float timeOfDeathAccuracy;

	public EvidencePreset retailItemSoldDiscovery;

	public EvidencePreset retailItemNoSoldDiscovery;

	[Header("First Person Skin Materials")]
	public Material fistMaterial;

	public Material fingerUpperMaterial;

	public Material fingerLowerMaterial;

	public Material fingerTipMaterial;

	public Material thumbJointMaterial;

	[Tooltip("Physics object interpolation: 'By default interpolation is turned off. Commonly rigidbody interpolation is used on the player's character. Physics is running at discrete timesteps, while graphics is renderered at variable frame rates. This can lead to jittery looking objects, because physics and graphics are not completely in sync. The effect is subtle but often visible on the player character, especially if a camera follows the main character. It is recommended to turn on interpolation for the main character but disable it for everything else.'")]
	[Header("Physics")]
	public RigidbodyInterpolation interpolation;

	public float physicsOffTime;

	public PhysicsProfile defaultObjectPhysicsProfile;

	[Header("Trash")]
	[Tooltip("Trash limit per bin")]
	public int binTrashLimit;

	[Header("Calls")]
	[Tooltip("Each building logs this many phone calls")]
	public int buildingCallLogMax;

	[Header("Citizens")]
	[Tooltip("Multiply citizen speed in presimulation by this amount")]
	public float preSimSpeedMultiplier;

	[Tooltip("How much money a wallet contains based on citizien class")]
	public AnimationCurve walletCashAmountBasedOnWealth;

	public CharacterTrait creditCardTrait;

	public CharacterTrait donorCardTrait;

	[Tooltip("How close the block has to land for a successful block (total range = 1.0)")]
	[Header("Combat")]
	public float successfulBlockThreshold;

	[Tooltip("How close the block has to land for a perfect block (total range = 1.0)")]
	public float perfectBlockThreshold;

	[Tooltip("The minimum base attack delay (AI time between attack) in seconds. Modified by combat skill using left from min to max.")]
	public Vector2 baseAttackDelay;

	[Tooltip("Blocking will use this base attack delay instead of the above. Modified by combat skill using left from min to max")]
	public Vector2 blockedAttackDelay;

	[Tooltip("Blocking perfectly use this base attack delay instead of the above. Modified by combat skill using left from min to max")]
	public Vector2 perfectBlockAttackDelay;

	[Tooltip("How much time before an enemy gets up after being KO'd (game time)")]
	public Vector2 koTimeRange;

	[Tooltip("The force applied to an NPC ragdoll on KO")]
	public float playerKOPunchForce;

	[Tooltip("How much time passes when the player is KO'd (in-game hours)")]
	public float koTimePass;

	[Tooltip("How long (game time) will a citizen be restrained by handcuffs?")]
	public float restrainedTimer;

	[Tooltip("When using a takedown, how long a citizen will stay down for")]
	public float takedownTimer;

	[Tooltip("The fuse for a thrown grenade")]
	public float thrownGrenadeFuse;

	[Tooltip("The fuse for a proxy grenade")]
	public float proxyGrenadeFuse;

	[Tooltip("Blood amount multiplier")]
	public float bloodAmountMultiplier;

	[Space(5f)]
	public PlayerTransitionPreset successfulBlockTransition;

	public PlayerTransitionPreset unsuccessfulBlockTransition;

	public PlayerTransitionPreset counterTransition;

	[Header("Tailing")]
	public float maxPlayerLookAtTailingDistance;

	[Tooltip("How fast the AI gains spooked while being looked at")]
	public float playerLookAtSpookRate;

	public float loseSpookedRate;

	public AnimationCurve screenCentreSpookCurve;

	[Header("Mugging")]
	[Tooltip("Chance for player to be mugged if the conditions are right")]
	public float muggingChance;

	[Tooltip("Spatter removal time: Only applys when the spatter simulation is set to use this erase mode. In-game hours.")]
	[Header("Cleanup")]
	public float spatterRemovalTime;

	[Tooltip("Moved objects reset time in-game hours.")]
	public float objectPositionResetTime;

	[Tooltip("Broken windows will become boarded up after this time")]
	public float brokenWindowBoardTime;

	[Tooltip("Broken windows will reset after this time")]
	public float brokenWindowResetTime;

	[Header("Crime/Cases")]
	[Tooltip("Fine amount for breaking windows")]
	public int breakingWindowsFine;

	[Tooltip("Vandalism fine multiplier")]
	public int vandalismFineMultiplier;

	[Tooltip("How long it takes to cancel out address vandalism")]
	public float vandalismTimeout;

	[Tooltip("Minimum amount of time for illegal actions to be present (seconds)")]
	public float illegalActionMinimumTime;

	[Tooltip("How many items can be tampered with before it is considered a crime")]
	public int tamperGrace;

	[Tooltip("How far a physics object can be moved before it is considered a crime")]
	public float physicsTamperDistance;

	public InteractablePreset fignerprintPreset;

	[Tooltip("Time until suspects are detained after a call-in (gametime)")]
	public float detainDelay;

	[Tooltip("Time until results of the case are processed after detaining (gametime)")]
	public float caseResultProcessTime;

	[Tooltip("The number of murder victims needed to get the top rank")]
	public int bestCaseVictimCount;

	[Tooltip("The number of murder victims needed to get the worst rank")]
	public int worstCaseVictimCount;

	[Tooltip("Multiplier for job difficulty")]
	public AnimationCurve sideJobDifficultyRewardMultiplier;

	[Tooltip("Used for side jobs; leave item at this secret location")]
	public List<FurniturePreset> secretLocationFurniture;

	[Tooltip("Chance of triggering combat for stealing items from citizen's inventory")]
	public float stealTriggerChance;

	[Tooltip("The max number of side jobs/custom cases")]
	public int maxCases;

	[Tooltip("The between a crime scene being sweeped, and the cleanup time")]
	public float crimeSceneCleanupDelay;

	[Tooltip("The minimum/maxinum distance a mission photo can be from the object")]
	public Vector2 missionPhotoMinMaxDistance;

	[Tooltip("Scoring curve between min/max distances for a mission photo")]
	public AnimationCurve missionPhotoDistanceScoreCurve;

	[Tooltip("Enable player crime cover up mission opporunities")]
	public bool enableCoverUps;

	[Tooltip("Cover ups will be available during and after case #")]
	[EnableIf("enableCoverUps")]
	public int coverUpAvailableDuringCase;

	[Tooltip("Once cover ups are available, what are the chances that you'll get one?")]
	[EnableIf("enableCoverUps")]
	public float coverUpChance;

	[EnableIf("enableCoverUps")]
	public int coverUpReward;

	[EnableIf("enableCoverUps")]
	public float coverUpDelayTime;

	[Header("Footprints")]
	[Tooltip("The maximum number of footprints per room")]
	public int maximumFootprintsPerRoom;

	[Tooltip("Min/max size of footprints lerped shoe size")]
	public Vector2 footprintScaleRange;

	[Tooltip("Each step removes this level of dirt from the citizen")]
	public float stepDirtRemoval;

	[Tooltip("Each step removes this level of blood from the citizen")]
	public float stepBloodRemoval;

	[Tooltip("Each step outside adds this level of dirt + material specific values")]
	public float outdoorStepDirtAccumulation;

	public InteractablePreset footprintPreset;

	[Tooltip("How long do enforcers search a crime scene?")]
	[Header("Murders")]
	public float crimeSceneSearchLength;

	[Tooltip("How long does a crime scene stay active after enforcers arrive?")]
	public float crimeSceneLength;

	[Tooltip("Time for a dead body smell to extend one additional room (starts with 0)")]
	public float smellTime;

	[Tooltip("Murder turn-in questions")]
	public List<Case.ResolveQuestion> murderResolveQuestions;

	[Tooltip("Retirement turn-in questions")]
	public List<Case.ResolveQuestion> retirementResolveQuestions;

	[Header("Kidnappings")]
	public DialogPreset kidnapperCallTriggerDialog;

	[Header("Computers")]
	[Tooltip("The cursor object to load")]
	public GameObject OScursor;

	[Tooltip("Cursor load sprite")]
	public Sprite loadCursor;

	[Header("Surveillance")]
	[InfoBox("Don't lower this past 85 or it will screw with the introduction set up process", EInfoBoxType.Normal)]
	[Tooltip("Surveillance camera capture FoV")]
	[Range(85f, 180f)]
	public float captureFoV;

	[Tooltip("Surveillance camera capture range (nodes/visuals)")]
	public float captureRange;

	[Tooltip("Surveillance camera capture range (humans)")]
	public float humanCaptureRange;

	[Tooltip("Gap between capturing for cameras (gametime 0.1667 = 10 mins)")]
	public float captureInterval;

	[Tooltip("How many captures a camera can hold before overwriting (288 = 48 hours @ 10 mins)")]
	public int cameraCaptureMemory;

	[Tooltip("How old a camera capture can be before overwriting")]
	public float cameraCaptureMaxTime;

	[Tooltip("Maximum camera captures per gameworld cycle")]
	public int maxCapturesPerFrame;

	[Header("Upgrades")]
	[ReorderableList]
	public List<SyncDiskColour> syncDiskColours;

	public int defaultDiskSlots;

	[Tooltip("Scrolling sensitivity of the mouse wheel when not zooming")]
	[Header("General")]
	public int mouseWheelEvidenceScrollSensitivity;

	[Tooltip("Indoor temperature (-2.5 - 2.5)")]
	public float indoorTemperature;

	[Tooltip("Air duct temperature")]
	public float airDuctTemperature;

	[Tooltip("Heat source temperature")]
	public float heatSourceTemperature;

	[Tooltip("Oscillators")]
	public AnimationCurve oscillatorX;

	public AnimationCurve oscillatorY;

	public Vector2 drunkOscillationSpeed;

	[Tooltip("Shiver fluctuation")]
	public AnimationCurve shiverFluctuation;

	public Vector2 shiverOscillationSpeed;

	[Tooltip("Drunk Lens Distort")]
	public AnimationCurve drunkLensDistortOscillator;

	public Vector2 drunkLensDistortSpeed;

	public PlayerTransitionPreset tripTransition;

	[Tooltip("Headache fluctuation")]
	public AnimationCurve headacheFluctuation;

	public SpatterPatternPreset bleedingSpatter;

	public float fallDamageMultiplier;

	public StatusPreset detainedStatus;

	public StatusPreset wantedInBuildingStatus;

	[Space(7f)]
	public float playerHungerRate;

	public float playerThirstRate;

	public float playerTirednessRate;

	public float playerEnergyRate;

	[Space(7f)]
	public float combatHitChanceOfBruised;

	public float combatHitChanceOfBlackEye;

	public float combatHitChanceOfBrokenLeg;

	public float combatHitChanceOfBleeding;

	[Header("Pricing")]
	public Vector2 propertyValueRange;

	public AnimationCurve propertyValueCurve;

	[Header("Loan Sharks")]
	[Tooltip("How much the player gets now")]
	public int defaultLoanAmount;

	[Tooltip("How much extra the player pays in full")]
	public int defaultLoanExtra;

	[Tooltip("The daily repayment per day")]
	public int defaultLoanRepayment;

	[Header("Loitering")]
	[Tooltip("How long in secords before the AI starts commenting on your loitering behaviour")]
	public float loiteringCommentThreshold;

	[Tooltip("How long in secords before the player is approached by staff")]
	public float loiteringConfrontThreshold;

	[Tooltip("How long in secords before the player is classed as trespassing")]
	public float loiteringTrespassThreshold;

	[Tooltip("The timer resets to this after a purchase")]
	public float loiteringPurchaseResetValue;

	[Header("Scope Bases")]
	public DDSScope humanScope;

	public DDSScope itemScope;

	public DDSScope murderScope;

	public DDSScope locationScope;

	public DDSScope evidenceScope;

	public DDSScope sideJobScope;

	public DDSScope syncDiskScope;

	public DDSScope groupScope;

	private static GameplayControls _instance;

	public static GameplayControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
