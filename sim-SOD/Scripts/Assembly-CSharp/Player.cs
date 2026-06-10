using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : Human
{
	public delegate void TransitionCompleted(bool restoreTransform);

	public delegate void StartAutoTravel();

	public delegate void AutoTravelEnd();

	public delegate void GameLocationChange();

	public delegate void RoomChange();

	[Header("Player Attributes")]
	public bool fpsMode;

	public FirstPersonController fps;

	public CharacterController charController;

	public CapsuleCollider transitionDamageTrigger;

	public CameraController cam;

	public Transform camHeightParent;

	public Transform playerContainer;

	public AirDuctGroup.AirDuctSection previousDuctSection;

	public AirDuctGroup.AirDuctSection currentDuctSection;

	[Header("Player specific flags")]
	public bool isCrunchingDatabase;

	public SceneRecorder sceneRecorder;

	[Header("Watch Alarm")]
	public bool setAlarmMode;

	public bool editingHours;

	private float setAlarmFlashCounter;

	public float alarm;

	private bool alarmFlash;

	public float setAlarmModeAfterDelay;

	public float spendingTimeDelay;

	public bool spendingTimeMode;

	[Header("Auto Travel")]
	public bool autoTravelActive;

	private float toleranceRecalcTimer;

	private NewDoor autoTravelDoor;

	private NewNode.NodeAccess currentAutoTravelDest;

	private NewNode.NodeSpace currentNodeSpaceDest;

	private float currentNodeSpaceDestTimer;

	public float autoTravelDistanceToNext;

	public Vector3 autoTravelForward;

	[NonSerialized]
	[Header("Telephone")]
	public Telephone answeringPhone;

	[NonSerialized]
	public TelephoneController.PhoneCall activeCall;

	[Header("Audio")]
	public List<CanvasRenderer> footstepSoundObjects;

	[Header("Player State")]
	public float crouchedTransition;

	public bool crouchTransitionActive;

	private int updateNodeSpace;

	private float takeDamageIndicatorTimer;

	private float takeDamageDisplaySpeed;

	private float spawnProtection;

	private bool wasMoving;

	private int nearbyInteractableUpdate;

	public float gasLevel;

	public float hurt;

	private Interactable bed;

	public List<CityTile> cityTilesInVicinity;

	public List<Interactable> playerKeyringInt;

	public bool forceLookAtActive;

	public Interactable forceLookAtInteractable;

	public float forceLookAtTime;

	private float lookAtTime;

	private float lookAtProgress;

	private Quaternion originalLookAtModRotationGlobal;

	public bool transitionActive;

	private float transitionTime;

	public float transitionProgress;

	[NonSerialized]
	public Interactable transitionInteractable;

	public PlayerTransitionPreset currentTransition;

	public PlayerTransitionPreset exitTransition;

	public Vector3 originalPlayerPosition;

	public Vector3 originalModPosition;

	public float originalPlayerHeight;

	public float originalCamHeight;

	public Vector3 startingLookPointWorldPosition;

	public bool transitionRecoilState;

	private List<PlayerTransitionPreset.SFXSetting> soundsPlayed;

	public Quaternion originalModRotationGlobal;

	public Quaternion originalModRotationLocal;

	public Vector3 additionalLookMultiplier;

	public float rollMultiplier;

	public bool transitionForceTime;

	public float transtionForcedTime;

	public Transform transitionLookAt;

	private bool movementOnTransitionComplete;

	private bool restoreHolsterOnTransitionComplete;

	public bool citizensArrestActive;

	public List<string> disabledActions;

	public int forcedLeanState;

	public float extraLeanSpeed;

	public float normalStepOffset;

	public float airVentStepOffset;

	public Vector3 storedTransitionPosition;

	public float desiredWalkSpeed;

	public float desiredRunSpeed;

	private bool playerKOFadeOut;

	private bool paidFines;

	private float KOTime;

	private float KOTimePassed;

	private bool KORecovery;

	private bool dirtyDeath;

	private GameplayController.LoanDebt debtPayment;

	public bool pausedRememberPlayerMovement;

	[NonSerialized]
	public Interactable hideInteractable;

	[NonSerialized]
	public int hideReference;

	[NonSerialized]
	public Interactable phoneInteractable;

	[NonSerialized]
	public Interactable computerInteractable;

	[NonSerialized]
	public Interactable restrainedInteractable;

	[NonSerialized]
	public FirstPersonItemController.InventorySlot restrainedHandcuffsSlot;

	[NonSerialized]
	public Interactable searchInteractable;

	[NonSerialized]
	public Interactable genericActionInteractable;

	[NonSerialized]
	public int nodesTraversedWhileWalking;

	[Header("Damage Block")]
	public float lastDamageAt;

	public Actor lastDmgFrom;

	[NonSerialized]
	[Header("Illegal State")]
	public float illegalActionTimer;

	public float seenProgress;

	public float seenProgressLag;

	public float persuedProgress;

	public float persuedProgressLag;

	[NonSerialized]
	public AudioController.LoopingSoundInfo trespassingSnapshot;

	[NonSerialized]
	public AudioController.LoopingSoundInfo combatSnapshot;

	[NonSerialized]
	public AudioController.LoopingSoundInfo syncMachineSnapshot;

	[NonSerialized]
	public AudioController.LoopingSoundInfo onlyMusicSnapshot;

	[NonSerialized]
	public AudioController.LoopingSoundInfo wristwatchLoop;

	[NonSerialized]
	public float visibilityLag;

	private float stealthLag;

	public float seenIconLag;

	private int spotCheckTimer;

	public bool playerKOInProgress;

	public bool isLockpicking;

	public bool isGrounded;

	private bool wasGrounded;

	public bool inElevator;

	public InteractableController elevatorInteractable;

	public bool claimedAccidentCover;

	public List<int> foodHygeinePhotos;

	public List<int> sanitaryHygeinePhotos;

	public List<int> illegalOpsPhotos;

	public bool firstFrame;

	private bool lateFixedUpdate;

	private bool drinkLoopStarted;

	private AudioController.LoopingSoundInfo drinkLoop;

	[Header("Apartments")]
	public List<NewAddress> apartmentsOwned;

	private bool cullingUpdateRequest;

	private float cullingUpdateTimer;

	private Action updateCullingAction;

	private Action updateStatusAction;

	public List<Actor> spottedByPlayer;

	public List<Actor> spottedWhileHiding;

	[NonSerialized]
	public Interactable hidingInteractable;

	private static Player _instance;

	private List<CityTile> requiredVicinity;

	public static Player Instance => null;

	public event TransitionCompleted OnTransitionCompleted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event StartAutoTravel OnExecuteAutoTravel
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event AutoTravelEnd OnEndAutoTravel
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event GameLocationChange OnNewGameLocation
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event RoomChange OnNewRoom
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void EnablePlayerMovement(bool val, bool updateCulling = true)
	{
	}

	public void EnablePlayerMouseLook(bool val, bool forceHideMouseOnDisable = false)
	{
	}

	private void OnPauseChange(bool openDesktopMode)
	{
	}

	public override void UpdateGameLocation(float feetOffset = 0f, bool forceNodePositionUpdate = false)
	{
	}

	public virtual void OnDuctGroupChange()
	{
	}

	public void OnDuctSectionChange()
	{
	}

	public override void OnCityTileChange()
	{
	}

	public override void OnGameLocationChange(bool enableSocialSightings = true, bool forceDisableLocationMemory = false)
	{
	}

	private void ResetNegativeStatuses(float resetLevel)
	{
	}

	public override void OnBuildingChange()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateCurrentBuildingModelVisibility()
	{
	}

	public override void OnNodeChange()
	{
	}

	public bool DoFallThroughFloorCheck()
	{
		return false;
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void LateUpdate()
	{
	}

	private float GetRotationalLerpValue(Quaternion originalRotation, Quaternion targetRotation, float multiplier, out float angleBetween, float distanceToNext)
	{
		angleBetween = default(float);
		return 0f;
	}

	public void UpdateMovementPhysics(bool forceUpdateBeforeGameStart = false)
	{
	}

	public void ExecuteTransition()
	{
	}

	public void ConvertModifierMovementToPlayerMovement(bool resetCamRoll = true)
	{
	}

	public void ConvertPlayerMovementToModifierMovement()
	{
	}

	public void ForceLookAt(Interactable interactable, float time)
	{
	}

	public void ExecuteForceLookAt()
	{
	}

	public void TransformPlayerController(PlayerTransitionPreset newEnterTransition, PlayerTransitionPreset newExitTransition, Interactable newInteractable, Transform newLookAt, bool newForceMovementOnEnd = false, bool forceTime = false, float forcedTime = 0f, bool useAdditionalLookMultiplier = false, Vector3 newAdditionalLookMultiplier = default(Vector3), float newRollMultiplier = 1f, bool writeReturnPosition = true)
	{
	}

	public void RestorePlayerMovementSpeed()
	{
	}

	public void UpdateSkinWidth()
	{
	}

	public void ReturnFromTransform(bool immediate = false, bool restorePlayerTransform = true)
	{
	}

	public void OnTransitionComplete()
	{
	}

	public void EnableCharacterController(bool val)
	{
	}

	public override void UpdateIllegalStatus()
	{
	}

	public override bool IsTrespassing(NewRoom room, out int trespassEscalation, bool enforcersAllowedEverywhere = true)
	{
		trespassEscalation = default(int);
		return false;
	}

	public override void OnStealthModeChange()
	{
	}

	public override void OnCrouchedChange()
	{
	}

	public void SetLockpickingState(bool val)
	{
	}

	public void SetMaxSpeed(float newWalkSpeed, float newRunSpeed)
	{
	}

	public void SetCameraHeight(float newHeight)
	{
	}

	public void SetPlayerHeight(float newHeight, bool stayOnFloorPlane = true)
	{
	}

	public override void UpdateLightLevel()
	{
	}

	public override void OnRoomChange()
	{
	}

	public override void OnTileChange()
	{
	}

	public void UpdateCullingShortly()
	{
	}

	public void UpdateCullingOnEndOfFrame()
	{
	}

	public void UpdateCulling()
	{
	}

	public override void SetResidence(ResidenceController newHome, bool removePreviousResidence = true)
	{
	}

	public override void AddToKeyring(NewAddress ad, bool gameMessage = true)
	{
	}

	public override void AddToKeyring(NewDoor ac, bool gameMessage = true)
	{
	}

	public void AddToKeyring(Interactable inter, bool gameMessage = true)
	{
	}

	public override void RemoveFromKeyring(NewDoor ac)
	{
	}

	public void RemoveFromKeyring(Interactable inter)
	{
	}

	public void TriggerPlayerKO(Vector3 KODirection, float RollMP, bool forceDirtyDeath = false)
	{
	}

	public void TriggerPlayerRecovery()
	{
	}

	public override void Teleport(NewNode teleportLocation, Interactable.UsagePoint usagePoint, bool cancelVent = true, bool teleportYPostionOnly = false, bool goalDeeactivation = true)
	{
	}

	public void SetPosition(Vector3 newWorldPos, Quaternion newRot)
	{
	}

	public void UpdatePlayerAmbientState()
	{
	}

	public void OnHide(Interactable newHideInteractable, int reference = 0, bool instant = false, bool allowReturnPositionWrite = true)
	{
	}

	public void OnReturnFromHide()
	{
	}

	public void OnAnswerPhone(Interactable newPhone)
	{
	}

	public void OnReturnFromAnswerPhone()
	{
	}

	public void OnCrawlIntoVent(Interactable vent, bool instant = false)
	{
	}

	public void OnCrawlOutOfVent(Interactable vent, bool instant = false)
	{
	}

	public void EnterVent(bool restoreTransform = false)
	{
	}

	public void ExitVent(bool restoreTransform = false)
	{
	}

	public void OnUseComputer(Interactable newComp, bool instant = false)
	{
	}

	public void OnReturnFromUseComputer()
	{
	}

	public void OnTakePrint(Interactable newHand)
	{
	}

	public void OnCompleteTakePrint()
	{
	}

	public void OnReturnFromTakePrint()
	{
	}

	public void OnSearch(Interactable newSearchItem)
	{
	}

	public void OnCompleteSearch()
	{
	}

	public void OnReturnFromSearch()
	{
	}

	public void OnDrink(Interactable newSearchItem)
	{
	}

	public void DrinkProgress(float amountChangeThisFrame, float amountToal)
	{
	}

	public void OnLookAwayFromFountain()
	{
	}

	public void OnCompleteDrink()
	{
	}

	public void OnReturnFromDrink()
	{
	}

	public void OnInteractionActionProgress(float amountThisFrame, float interactionActionAmount)
	{
	}

	public void OnGenericTimedAction(string actionName, float threshold, float increaseRate, Interactable newItem, bool playObjectsSearchLoop = false)
	{
	}

	public void OnReturnFromGenericAction()
	{
	}

	public void OnHandcuff(Interactable newBody)
	{
	}

	public void OnCompleteHandcuff()
	{
	}

	public void OnReturnFromHandcuff()
	{
	}

	public void EnableGhostMovement(bool ghost, bool clipping = false, float stickToGround = 0f)
	{
	}

	public void SetActionDisable(string newString, bool val)
	{
	}

	public void ClearAllDisabledActions()
	{
	}

	public override void SetVehicle(Transform newVehicle)
	{
	}

	public void SetVehicle(Transform newVehicle, bool overrideSessionStarted)
	{
	}

	public void SetSettingAlarmMode(bool val)
	{
	}

	public void AddToAlarmTime(float plusTime)
	{
	}

	public void SetSpendingTimeMode(bool val)
	{
	}

	public override void RecieveDamage(float amount, Actor fromWho, Vector3 damagePosition, Vector3 damageDirection, SpatterPatternPreset forwardSpatter, SpatterPatternPreset backSpatter, SpatterSimulation.EraseMode eraseMode = SpatterSimulation.EraseMode.quickDespawn, bool alertSurrounding = true, bool forceRagdoll = false, float forcedRagdollDuration = 0f, float shockMP = 1f, bool enableKill = false, bool allowRecoil = true, float ragdollForceMP = 1f)
	{
	}

	public override void SetFootwear(ShoeType newType)
	{
	}

	public override void AddHealth(float amount, bool affectedByGameDifficulty = true, bool displayDamageIndicator = false)
	{
	}

	public override void SetHealth(float amount)
	{
	}

	public override void OnZeroHealthReached()
	{
	}

	public override void SightingCheck(float fov, bool ignoreLightAndStealth = false)
	{
	}

	public override void PrepForStart()
	{
	}

	public void GeneratePlayerDetails()
	{
	}

	public void SetupPlayerPhysicalPresence()
	{
	}

	public override void AddNourishment(float addVal)
	{
	}

	public override void AddHydration(float addVal)
	{
	}

	public override void AddEnergy(float addVal)
	{
	}

	public override void AddAlertness(float addVal)
	{
	}

	public override void AddHygiene(float addVal)
	{
	}

	public override void AddHeat(float addVal)
	{
	}

	public override void AddDrunk(float addVal)
	{
	}

	public override void AddSick(float addVal)
	{
	}

	public override void AddHeadache(float addVal)
	{
	}

	public override void AddWet(float addVal)
	{
	}

	public override void AddBrokenLeg(float addVal)
	{
	}

	public override void AddBruised(float addVal)
	{
	}

	public override void AddBlackEye(float addVal)
	{
	}

	public override void AddBlackedOut(float addVal)
	{
	}

	public override void AddNumb(float addVal)
	{
	}

	public override void AddBleeding(float addVal)
	{
	}

	public override void AddStarchAddiction(float addVal)
	{
	}

	public override void AddSyncDiskInstall(float addVal)
	{
	}

	public void StatusCheckEndOfFrame()
	{
	}

	public override void SetOnStreet(bool val)
	{
	}

	public void Trip(float damage, bool forwards = false, bool playSound = true)
	{
	}

	public override void SetHiding(bool val, Interactable newHidingPlace)
	{
	}

	public float GetPlayerHeightNormal()
	{
		return 0f;
	}

	public float GetPlayerHeightCrouched()
	{
		return 0f;
	}

	public void ExecuteAutoTravel(Evidence toLocation, bool fastTravel = false)
	{
	}

	public void ExecuteAutoTravel(NewGameLocation toLocation, bool fastTravel = false)
	{
	}

	public void ExecuteAutoTravel(NewBuilding toBuilding, bool fastTravel = false)
	{
	}

	public void ExecuteAutoTravel(NewNode toNode, bool fastTravel = false)
	{
	}

	public void EndAutoTravel()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void KillPlayer()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetCurrentNodeCoord()
	{
	}

	public void SetPositionFixSolutionsEnabled(bool condition)
	{
	}
}
