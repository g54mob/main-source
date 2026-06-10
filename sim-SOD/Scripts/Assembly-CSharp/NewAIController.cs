using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NaughtyAttributes;
using UnityEngine;

public class NewAIController : MonoBehaviour
{
	[Serializable]
	public class TrackingTarget
	{
		public Actor actor;

		public float lastValidSighting;

		public bool priorityTarget;

		public float attractionRank;

		public float distance;

		public float distanceRank;

		public float fovRank;

		public float itemRank;

		public float lookAtRank;

		public bool active;

		public bool spookedByItem;

		public int spookTimer;
	}

	[Serializable]
	public class ChaseLogic
	{
		public NewAIController ai;

		public Vector3 lastSeenPosition;

		public NewNode lastSeenNode;

		public Vector3 lastSeenDirection;

		public NewNode projectedNode;

		public Vector3 projectedPosition;

		public void UpdateLastSeen()
		{
		}

		public void GenerateProjectedNode()
		{
		}
	}

	public enum InvestigationUrgency
	{
		walk = 0,
		run = 1
	}

	[DataContract]
	public enum ReactionState
	{
		none = 0,
		investigatingSight = 1,
		investigatingSound = 2,
		persuing = 3,
		searching = 4
	}

	[DataContract]
	public enum AITickRate
	{
		veryLow = 0,
		low = 1,
		medium = 2,
		high = 3,
		veryHigh = 4
	}

	public class QueuedAction
	{
		public Interactable interactable;

		public InteractablePreset.InteractionAction actionSetting;

		public float delay;
	}

	[NonSerialized]
	public Human human;

	public CapsuleCollider capCollider;

	[NonSerialized]
	public float delta;

	private float prevDelta;

	[Header("Debug: Status Stats")]
	[ProgressBar("Nourishment", 1f, EColor.Yellow)]
	public float nourishment;

	[ProgressBar("Hydration", 1f, EColor.Yellow)]
	public float hydration;

	[ProgressBar("Alertness", 1f, EColor.Yellow)]
	public float alertness;

	[ProgressBar("Energy", 1f, EColor.Yellow)]
	public float energy;

	[ProgressBar("Excitement", 1f, EColor.Yellow)]
	public float excitement;

	[ProgressBar("Chores", 1f, EColor.Yellow)]
	public float chores;

	[ProgressBar("Hygiene", 1f, EColor.Yellow)]
	public float hygiene;

	[ProgressBar("Bladder", 1f, EColor.Yellow)]
	public float bladder;

	[ProgressBar("Heat", 1f, EColor.Yellow)]
	public float heat;

	[ProgressBar("Drunk", 1f, EColor.Yellow)]
	public float drunk;

	[ProgressBar("Breath", 1f, EColor.Yellow)]
	public float breath;

	[ProgressBar("IdleSound", 1f, EColor.Yellow)]
	public float idleSound;

	[ProgressBar("Blink", 1f, EColor.Yellow)]
	public float blink;

	[Space(5f)]
	[ProgressBar("Sees Player", 100f, EColor.Blue)]
	public int debugSeesPlayer;

	[ReadOnly]
	public float debugLastSeesPlayerChange;

	[ProgressBar("Hears Player", 1f, EColor.Blue)]
	public float hearsIllegal;

	public Actor hearTarget;

	[Tooltip("Goals are a list of things this AI wants to achieve")]
	[Header("Goals")]
	public List<NewAIGoal> goals;

	[NonSerialized]
	[Tooltip("The currently active goal")]
	public NewAIGoal currentGoal;

	[NonSerialized]
	[Tooltip("The currently active action")]
	public NewAIAction currentAction;

	[NonSerialized]
	[Tooltip("Investigation goal")]
	public NewAIGoal investigationGoal;

	[NonSerialized]
	[Tooltip("Patrol goal")]
	public NewAIGoal patrolGoal;

	[NonSerialized]
	[Tooltip("The current ineractable this is using")]
	public FurnitureLocation currentFurnitureUser;

	[NonSerialized]
	public NewNode currentFurnitureNode;

	public Interactable nextAIAction;

	public Human kidnapper;

	public NewGameLocation confineLocation;

	public List<NewGameLocation> avoidLocations;

	[NonSerialized]
	[Header("Movement")]
	public int pathCursor;

	[NonSerialized]
	public NewNode currentDestinationNode;

	[NonSerialized]
	public Vector3 currentDesitnationNodeCoord;

	public Vector3 currentDestinationPositon;

	public float movementAmount;

	public float distanceToNext;

	private Quaternion lastMovementRotation;

	private bool doIMove;

	private float footStepDistanceCounter;

	private bool rightFootNext;

	public bool isTripping;

	public bool doorCheck;

	private NewDoor doorCheckDoor;

	[NonSerialized]
	[Tooltip("If I've just opened a door, this is a reference to it so I can close it later")]
	public NewDoor openedDoor;

	[NonSerialized]
	private int delayFlag;

	private List<NewDoor> doorInteractions;

	[Header("Turning")]
	public bool facingActive;

	[Header("Facing")]
	public Vector3 facingDirection;

	[NonSerialized]
	public Transform faceTransform;

	[NonSerialized]
	public Vector3 faceTransformOffset;

	public Quaternion facingQuat;

	private Quaternion lookingQuatPrevious;

	private Quaternion lookingQuatLastFrame;

	private Quaternion lookingQuatCurrent;

	private float lookAroundTimer;

	private Vector3 lookAroundPosition;

	[Header("Vision")]
	public List<TrackingTarget> trackedTargets;

	[NonSerialized]
	public TrackingTarget currentTrackTarget;

	public Transform lookAtTransform;

	public float lookAtTransformRank;

	[HideInInspector]
	[SerializeField]
	private Quaternion original;

	private Vector3 dirXZ;

	private Vector3 forwardXZ;

	private Vector3 dirYZ;

	private Vector3 forwardYZ;

	[NonSerialized]
	[Header("Expression")]
	public CitizenOutfitController.ExpressionSetup currentExpression;

	public float expressionProgress;

	public bool blinkInProgress;

	private float blinkTimer;

	public float eyesOpen;

	public float bargeTimer;

	[Header("Investigate AI")]
	public Actor persuitTarget;

	public NewNode investigateLocation;

	public Vector3 investigatePosition;

	public Vector3 investigatePositionProjection;

	public Interactable investigateObject;

	public Interactable tamperedObject;

	public InvestigationUrgency investigationUrgency;

	[NonSerialized]
	public NewAIAction audioFocusAction;

	public float lastInvestigate;

	private float persuitUpdateTimer;

	public bool persuit;

	public bool seesOnPersuit;

	public float persuitChaseLogicUses;

	public float minimumInvestigationTimeMultiplier;

	public ChaseLogic chaseLogic;

	public ReactionIndicatorController reactionIndicator;

	public ReactionState reactionState;

	[Header("Patrol AI")]
	public NewGameLocation patrolLocation;

	[Header("Attack")]
	public bool inCombat;

	public bool inFleeState;

	public bool staticFromAnimation;

	public float staticAnimationSafetyTimer;

	public bool attackActive;

	public Actor attackTarget;

	public AttackBarController activeAttackBar;

	public float attackTimeout;

	public float attackProgress;

	private int revolverShots;

	public bool damageColliderCreated;

	private bool ejectBrassCreated;

	public DamageColliderController damageCollider;

	public float attackDelay;

	private float attackActiveLength;

	public bool ko;

	public bool isRagdoll;

	public RigidbodyDragObject dragController;

	public RagdollPositionUpdater ragdollPositionUpdate;

	public float koTime;

	public float koTransitionTimer;

	private float getUpDelayTimer;

	public float deadRagdollTimer;

	public bool restrained;

	public bool outOfBreath;

	public float restrainTime;

	[NonSerialized]
	public Interactable currentWeapon;

	public MurderWeaponPreset currentWeaponPreset;

	public float weaponRangeMax;

	public float weaponRefire;

	public float weaponAccuracy;

	public float weaponDamage;

	[Header("Update")]
	public AITickRate desiredTickRate;

	public AITickRate previousTickRate;

	public AITickRate tickRate;

	public bool dueUpdate;

	public float delayedUntil;

	public float lastUpdated;

	private float lastSnore;

	public float timeSinceLastUpdate;

	public float timeAtCurrentAddress;

	private float drunkTripCheckTimer;

	private int doorCheckProcessTimer;

	public float lastGameLocationUpdate;

	private bool visibleMovementAnimationLerpRequired;

	public bool disableTickRateUpdate;

	public Dictionary<AIGoalPreset, float> delayedGoalsForTime;

	public Dictionary<AIActionPreset, float> delayedActionsForTime;

	public List<QueuedAction> queuedActions;

	private float lastMuggingTimestamp;

	[Header("Held Items")]
	public GameObject spawnedRightItem;

	public GameObject spawnedLeftItem;

	[NonSerialized]
	public NewAIAction customItemSource;

	public bool usingCarryAnimation;

	public int combatMode;

	[NonSerialized]
	public InteractablePreset throwItem;

	public bool throwActive;

	public float throwDelay;

	[Header("Special Cases")]
	public bool dontEverCloseDoors;

	public List<MurderController.Murder> victimsForMurders;

	public List<MurderController.Murder> killerForMurders;

	public bool isConvicted;

	private bool usePointBusyRecursion;

	[NonSerialized]
	public NewGameLocation closeDoorsNormallyAfterLeaving;

	public List<Interactable> putDownItems;

	private float drunkIdleTimer;

	private float restrainedIdleTimer;

	public Dictionary<Human, float> appliedNerveEffect;

	private bool tickActive;

	public float spooked;

	public int spookCounter;

	public float spookForgetCounter;

	private float noPathTimer;

	private int noPathCorrectionAttempts;

	[Header("Debug")]
	public List<string> lastActions;

	public List<string> debugDestinationPosition;

	public string jobDebug;

	public bool debugMovement;

	public AudioEvent debugLastHeardIllegalAudio;

	protected List<AIActionPreset> rem;

	public void Setup(Human newParent)
	{
	}

	public void AITick(bool forceUpdatePriorities = false, bool ignoreRepeatDelays = false)
	{
	}

	public NewAIGoal CreateNewGoal(AIGoalPreset newPreset, float newTrigerTime, float newDuration, NewNode newPassedNode = null, Interactable newPassedInteractable = null, NewGameLocation newPassedGameLocation = null, GroupsController.SocialGroup newPassedGroup = null, MurderController.Murder newMurderRef = null, int newPassedVar = -2)
	{
		return null;
	}

	public NewAIAction CreateNewAction(NewAIGoal newGoal, AIActionPreset newPreset, bool newInsertedAction = false, NewRoom newPassedRoom = null, Interactable newPassedInteractable = null, NewNode newForcedNode = null, GroupsController.SocialGroup newPassedGroup = null, List<InteractablePreset> newPassedAcquireItems = null, bool newForceRun = false, int newInsertedActionPriority = 3, NewAIAction newCreatedFor = null)
	{
		return null;
	}

	public void StatusStatUpdate()
	{
	}

	public void OnCompleteGoal(NewAIGoal completed)
	{
	}

	public void SetDesiredTickRate(AITickRate newRate, bool forceUpdate = false)
	{
	}

	public void UpdateTickRate(bool forceUpdate = false)
	{
	}

	public void FrequentUpdate()
	{
	}

	private void MovementSpeedUpdate()
	{
	}

	private void HearingUpdate()
	{
	}

	private void StatesUpdate()
	{
	}

	public void PersuitUpdate()
	{
	}

	private void MovementUpdate()
	{
	}

	private void SimulateFootprints()
	{
	}

	private float GetRotationalLerpValue(Quaternion originalRotation, Quaternion targetRotation, float multiplier, out float angleBetween)
	{
		angleBetween = default(float);
		return 0f;
	}

	private void FacingUpdate()
	{
	}

	private void AttackUpdate()
	{
	}

	public Human GetCurrentKillTarget()
	{
		return null;
	}

	private void KOUpdate()
	{
	}

	public void SetParentPositionToRagdollLimbPosition()
	{
	}

	public void SetUpdateEnabled(bool val)
	{
	}

	public void ClampNeckRotation(bool setNeckAngles = true)
	{
	}

	public void ReachNewPathNode(bool scanForNextNodeFurniture = true)
	{
	}

	public void DoorCheckProcess()
	{
	}

	public void SetDestinationNode(NewNode newLocation, bool scanForNextNodeFurniture = true)
	{
	}

	private bool DynamicReRoute(NewNode current, NewNode avoidThis, NewNode beyond, out NewNode bestAvoidanceTile)
	{
		bestAvoidanceTile = null;
		return false;
	}

	public void SetFaceTravelDirection()
	{
	}

	public void SetFacingPosition(Vector3 newLookPoint)
	{
	}

	public void SetFacingDirection(Vector3 newLookDirection)
	{
	}

	public void SetFacingTransform(Transform newLookAt, Vector3 offset)
	{
	}

	public void SetLookAtTransform(Transform newTarget, float newRank)
	{
	}

	public void AddTrackedTarget(Actor newTracked)
	{
	}

	private void TrackingSpookCheck(TrackingTarget newTarget, bool seen)
	{
	}

	public void UpdateHumanDrawnWeapon(Human who, bool seen)
	{
	}

	public void UpdateTrackedTargets()
	{
	}

	public void SetTrackTarget(TrackingTarget newTrackingTarget)
	{
	}

	public void OnNewTrackTarget()
	{
	}

	public bool IsMuggingValid(Human target, out string debugReason)
	{
		debugReason = null;
		return false;
	}

	private void RemoveLookAtTargetAt(int index)
	{
	}

	public void OnVisibilityChanged()
	{
	}

	public void SetExpression(CitizenOutfitController.Expression newExpression)
	{
	}

	public void AddDebugAction(string msg)
	{
	}

	[Button("Teleport Player", EButtonEnableMode.Always)]
	public void DebugTeleportPlayerToLocation()
	{
	}

	[Button("Give Sleep!", EButtonEnableMode.Always)]
	public void GiveSleep()
	{
	}

	[Button("Remove Sleep!", EButtonEnableMode.Always)]
	public void RemoveSleep()
	{
	}

	[Button("Give Food!", EButtonEnableMode.Always)]
	public void GiveFood()
	{
	}

	[Button("Remove Food!", EButtonEnableMode.Always)]
	public void RemoveFood()
	{
	}

	[Button("Give Drink!", EButtonEnableMode.Always)]
	public void GiveDrink()
	{
	}

	[Button("Remove Drink!", EButtonEnableMode.Always)]
	public void RemoveDrink()
	{
	}

	[Button("Give Caffeine!", EButtonEnableMode.Always)]
	public void GiveCaffeine()
	{
	}

	[Button("Remove Caffeine!", EButtonEnableMode.Always)]
	public void RemoveCaffeine()
	{
	}

	[Button("Give Fun!", EButtonEnableMode.Always)]
	public void GiveFun()
	{
	}

	[Button("Remove Fun!", EButtonEnableMode.Always)]
	public void RemoveFun()
	{
	}

	[Button("Give Bladder!", EButtonEnableMode.Always)]
	public void GiveBladder()
	{
	}

	[Button("Remove Bladder!", EButtonEnableMode.Always)]
	public void RemoveBladder()
	{
	}

	[Button("Give Hygeine!", EButtonEnableMode.Always)]
	public void GiveHygiene()
	{
	}

	[Button("Remove Hygeine!", EButtonEnableMode.Always)]
	public void RemoveHygiene()
	{
	}

	[Button("Give Drunk!", EButtonEnableMode.Always)]
	public void GiveDrunk()
	{
	}

	[Button("Remove Drunk!", EButtonEnableMode.Always)]
	public void RemoveDrunk()
	{
	}

	[Button("Murder", EButtonEnableMode.Always)]
	public void MurderButton()
	{
	}

	[Button("Debug: Why Aren't I moving?", EButtonEnableMode.Always)]
	public void DebugMovement()
	{
	}

	[Button("Trip", EButtonEnableMode.Always)]
	public void Trip()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateProjectedChasePosition()
	{
	}

	public void HearIllegal(AudioEvent audioEvent, NewNode newInvestigateNode, Vector3 newInvestigatePosition, Actor newTarget, int escLevel)
	{
	}

	public void Investigate(NewNode newInvestigateNode, Vector3 newInvestigatePosition, Actor newTarget, ReactionState newReactionState, float minimumInvestiationTimeMP, int escalation, bool setHighUrgency = false, float focusTimeMultiplier = 1f, Interactable newInvesigationObj = null)
	{
	}

	public void SetInvestigationUrgency(InvestigationUrgency newUrgency)
	{
	}

	public void SetPersue(Actor newTarget, bool publicFauxPas, int escalation, bool setHighUrgency, float responseRange = 10f)
	{
	}

	public void SetPersueTarget(Actor newTarget)
	{
	}

	public void CancelPersue()
	{
	}

	public void SetPersuit(bool val)
	{
	}

	public void SetSeesOnPersuit(bool val)
	{
	}

	public void ResetInvestigate()
	{
	}

	public void Patrol(NewGameLocation newPatLoc)
	{
	}

	public void StartAttack(Actor newAttackTarget)
	{
	}

	public void ThrowObject(Actor newAttackTarget)
	{
	}

	public void OnAttackComplete()
	{
	}

	public void OnAttackBlock(bool perfect = false)
	{
	}

	public void OnAbortAttack()
	{
	}

	private void SetAttackDelay(bool blocked = false, bool blockedPerfect = false)
	{
	}

	public void EndAttack()
	{
	}

	public void TalkTo(InteractionController.ConversationType convoType = InteractionController.ConversationType.normal)
	{
	}

	public void OnReturnFromTalkTo()
	{
	}

	public void SetStunned(bool val)
	{
	}

	public void SetDelayed(float seconds)
	{
	}

	public void AnswerDoor(NewDoor dc, NewGameLocation where, Actor byWho)
	{
	}

	public void AnswerPhone(Telephone where)
	{
	}

	public void AwakenPrompt()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayCurrentRoute()
	{
	}

	public void SetInCombat(bool val, bool forceUpdate = false)
	{
	}

	public void RecalculateWeaponStats()
	{
	}

	public void SetKO(bool val, Vector3 impactPoint = default(Vector3), Vector3 impactDirection = default(Vector3), bool forced = false, float forcedDuration = 0f, bool resetInvesigate = true, float forceMultiplier = 1f)
	{
	}

	public void SetOutOfBreath(bool val)
	{
	}

	public void SetRestrained(bool val, float duration)
	{
	}

	public void SetReactionState(ReactionState newState)
	{
	}

	public void TriggerReactionIndicator()
	{
	}

	public void DebugDestinationPosition(string input)
	{
	}

	public void CancelCombat()
	{
	}

	public void SetAsVictim(MurderController.Murder newMurder)
	{
	}

	public void SetAsMurderer(MurderController.Murder newMurderer)
	{
	}

	public void SetStaticFromAnimation(bool val)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetRotationState()
	{
	}

	public void CloseDoorsNormallyAfterLeavingGamelocation(NewGameLocation afterLeaving)
	{
	}

	public void UpdateCurrentWeapon()
	{
	}

	public void SetCurrentWeapon(Interactable obj)
	{
	}

	public void UpdateHeldItems(AIActionPreset.ActionStateFlag state)
	{
	}

	public void DespawnRightItem()
	{
	}

	public void DespawnLeftItem()
	{
	}

	public void InstantPersuitCheck(Actor target)
	{
	}

	public void EnableAI(bool val)
	{
	}

	public void SetConfineLocation(NewGameLocation newConfine)
	{
	}

	public void AddAvoidLocation(NewGameLocation newAvoid)
	{
	}

	public void RemoveAvoidLocation(NewGameLocation remAvoid)
	{
	}

	public NewGameLocation CheckConfinedLocation(NewGameLocation desired)
	{
		return null;
	}

	public bool CanIgnoreLockedDoors()
	{
		return false;
	}

	public void AddSpooked(float val)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void IsTrespassingAtActionDestination()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CurrentGoalTriggerTime()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ForceNodeReached()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DestinationCheck()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OpenEvidenceFirstName()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OpenEvidenceName()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void OpenEvidencePhoto()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleHumanDebug()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PrintCurrentNodePosition()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ForceUpdateGameLocation()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugNextJobHours()
	{
	}
}
