using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class Actor : Controller
{
	public enum HumanDebug
	{
		movement = 0,
		actions = 1,
		attacks = 2,
		updates = 3,
		misc = 4,
		sight = 5
	}

	public delegate void InteractionChanged();

	public delegate void RoutineChanged();

	[Header("Flags")]
	public bool isMoving;

	public bool isRunning;

	public bool isMachine;

	public bool isPlayer;

	public bool isAsleep;

	public bool isDelayed;

	public bool isStunned;

	public bool isDead;

	public bool unreportable;

	public bool isTrespassing;

	public bool isSkippable;

	public bool isOnStreet;

	public bool seesOthers;

	public bool isSeenByOthers;

	public bool canListen;

	public bool visible;

	public bool isHome;

	public bool isAtWork;

	public bool inAirVent;

	public bool isHiding;

	public bool isInBed;

	public bool isInLowBed;

	public bool inConversation;

	public bool isSpeaking;

	public bool isHomeless;

	public bool isLitterBug;

	public bool isOnDuty;

	public bool isEnforcer;

	public bool ownsUmbrella;

	public bool likesTheRain;

	public bool forceTarget;

	[Header("Illegal State")]
	[ProgressBar("Sees Player", 100f, EColor.Blue)]
	public int debugSeesPlayer;

	[ReadOnly]
	public float debugLastSeesPlayerChange;

	[Space(5f)]
	public Dictionary<Actor, float> seesIllegal;

	public HashSet<Actor> seenIllegalThisCheck;

	public HashSet<Actor> witnessesToIllegalActivity;

	public HashSet<Actor> persuedBy;

	public bool illegalActionActive;

	public bool illegalAreaActive;

	public int trespassingEscalation;

	public bool illegalStatus;

	[Space(7f)]
	[Tooltip("Transform that should be in the centre of this object, when others look at this, they will use this.")]
	public Transform lookAtThisTransform;

	public Transform aimTransform;

	[Header("Common Components")]
	public GameObject modelParent;

	public GameObject distantLOD;

	public List<MeshRenderer> meshes;

	public List<MeshRenderer> meshesLOD1;

	public CitizenAnimationController animationController;

	public SpeechController speechController;

	public Transform neckTransform;

	public InteractablePreset citizenObjectPreset;

	[NonSerialized]
	public Interactable interactable;

	[NonSerialized]
	public Interactable leftHandInteractable;

	[NonSerialized]
	public Interactable rightHandInteractable;

	public InteractableController interactableController;

	public NewAIController ai;

	public Transform footstepSoundTransform;

	public OutlineController outline;

	[Header("Health")]
	[ReadOnly]
	public float currentHealth;

	[ReadOnly]
	public float maximumHealth;

	[ReadOnly]
	public float currentHealthNormalized;

	[ReadOnly]
	public float recoveryRate;

	[Header("Combat")]
	[ReadOnly]
	public float combatSkill;

	[ReadOnly]
	public float combatHeft;

	[ReadOnly]
	public float currentNerve;

	[ReadOnly]
	public Actor lastScaredBy;

	[ReadOnly]
	public NewGameLocation lastScaredAt;

	[ReadOnly]
	public float maxNerve;

	[NonSerialized]
	[Header("Location Data")]
	public CityTile previousCityTile;

	[NonSerialized]
	public CityTile currentCityTile;

	[NonSerialized]
	public NewTile previousTile;

	[NonSerialized]
	public NewTile currentTile;

	[NonSerialized]
	public NewBuilding previousBuilding;

	public NewBuilding currentBuilding;

	[NonSerialized]
	public NewGameLocation previousGameLocation;

	public NewGameLocation currentGameLocation;

	[NonSerialized]
	[Space(4f)]
	public NewRoom previousRoom;

	public NewRoom currentRoom;

	[NonSerialized]
	[Space(4f)]
	public AirDuctGroup currentDuct;

	[NonSerialized]
	public AirDuctGroup previousDuct;

	[Space(4f)]
	public NewNode.NodeSpace currentNodeSpace;

	public HashSet<NewNode.NodeSpace> reservedNodeSpace;

	[Space(4f)]
	public NewNode debugPrevNode2;

	public NewNode debugPrevNode1;

	public NewNode previousNode;

	public NewNode currentNode;

	[NonSerialized]
	public Vector3Int currentNodeCoord;

	[Space(7f)]
	public List<NewDoor> keyring;

	[NonSerialized]
	public EvidenceWitness evidenceEntry;

	[Header("Vision")]
	[ReadOnly]
	public float currentLightLevel;

	[NonSerialized]
	private float lightLevelTransition;

	[ReadOnly]
	public bool stealthMode;

	[ReadOnly]
	public bool isCrouched;

	[ReadOnly]
	public float appliedStealth;

	[ReadOnly]
	private float currentVisibilityPotential;

	[ReadOnly]
	public float overallVisibility;

	[ReadOnly]
	public float stealthDistance;

	[ReadOnly]
	public int escalationLevel;

	public float timeOfLastSightCheck;

	[NonSerialized]
	public float spottedState;

	[NonSerialized]
	public float spottedGraceTime;

	[Space(5f)]
	public float spotFocusSpeedMultiplier;

	public float spotLoseFocusSpeedMultiplier;

	public float hearingMultiplier;

	public HashSet<NewGameLocation> locationsOfAuthority;

	[NonSerialized]
	[Header("Interaction")]
	public Interactable interactingWith;

	[Range(0f, 5f)]
	[Header("BedrollCheck")]
	public float bedCheckRadius;

	[Header("Inventory")]
	public List<Interactable> inventory;

	[Header("Skill Variables")]
	public float stealthSkill;

	[NonSerialized]
	public float sleepDepth;

	[NonSerialized]
	public int awakenPromt;

	[NonSerialized]
	public float awakenRegen;

	public event InteractionChanged OnInteractionChanged
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

	public event RoutineChanged OnRoutineChange
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

	public void SetInteracting(Interactable other)
	{
	}

	public virtual void OnNewInteraction()
	{
	}

	public virtual void Teleport(NewNode teleportLocation, Interactable.UsagePoint usagePoint, bool cancelVent = true, bool teleportYPostionOnly = false, bool goalDeactivation = true)
	{
	}

	public float GetCurrentMaxHealth()
	{
		return 0f;
	}

	public virtual void UpdateGameLocation(float feetOffset = 0f, bool forceNodePositionUpdate = false)
	{
	}

	public virtual void OnCityTileChange()
	{
	}

	public virtual void OnBuildingChange()
	{
	}

	public virtual void OnTileChange()
	{
	}

	public virtual void OnGameLocationChange(bool enableSocialSightings = true, bool forceDisableLocationMemory = false)
	{
	}

	public virtual void OnNodeChange()
	{
	}

	public virtual void OnRoomChange()
	{
	}

	public virtual void SetOnStreet(bool val)
	{
	}

	public virtual void AddToKeyring(NewAddress ad, bool gameMessage = true)
	{
	}

	public virtual void AddToKeyring(NewDoor ac, bool gameMessage = true)
	{
	}

	public virtual void RemoveFromKeyring(NewAddress ad)
	{
	}

	public virtual void RemoveFromKeyring(NewDoor ac)
	{
	}

	public virtual void SetVisible(bool vis, bool force = false)
	{
	}

	public void SetModelParentVisibility(bool val, string debugReason)
	{
	}

	public virtual void GoToSleep()
	{
	}

	public virtual void WakeUp(bool forceImmediate = false)
	{
	}

	public void RoutineChange()
	{
	}

	public void OnRoutineEnd()
	{
	}

	public void SetStealthMode(bool newVal)
	{
	}

	public void SetCrouched(bool newVal, bool instant = false)
	{
	}

	public void StealthModeLoop()
	{
	}

	public virtual void UpdateLightLevel()
	{
	}

	public virtual void OnStealthModeChange()
	{
	}

	public virtual void OnCrouchedChange()
	{
	}

	public void UpdateOverallVisibility()
	{
	}

	public virtual void SetHiding(bool val, Interactable newHidingPlace)
	{
	}

	public virtual void RecieveDamage(float amount, Actor fromWho, Vector3 damagePosition, Vector3 damageDirection, SpatterPatternPreset forwardSpatter, SpatterPatternPreset backSpatter, SpatterSimulation.EraseMode spatterErase = SpatterSimulation.EraseMode.useDespawnTime, bool alertSurrounding = true, bool forceRagdoll = false, float forcedRagdollDuration = 0f, float shockMP = 1f, bool enableKill = false, bool allowRecoil = true, float ragdollForceMP = 1f)
	{
	}

	public virtual void AddHealth(float amount, bool affectedByGameDifficulty = true, bool displayDamageIndicator = false)
	{
	}

	public virtual void SetHealth(float amount)
	{
	}

	public virtual void AddNerve(float amount, Actor scaredBy = null)
	{
	}

	public virtual void SetNerve(float amount)
	{
	}

	public virtual void OnZeroHealthReached()
	{
	}

	public virtual void ResetHealthToMaximum()
	{
	}

	public virtual void ResetNerveToMaximum()
	{
	}

	public virtual void OnZeroNerveReached()
	{
	}

	public virtual void SetMaxHealth(float newMax, bool setToMax = false)
	{
	}

	public virtual void SetMaxNerve(float newMax, bool setToMax = false)
	{
	}

	public virtual void SetRecoveryRate(float newRate)
	{
	}

	public virtual void SetCombatSkill(float newSkill)
	{
	}

	public virtual void SetCombatHeft(float newHeft)
	{
	}

	public void SetInBed(bool newVal, bool isLowBed, bool useRightSide = false)
	{
	}

	public virtual void UpdateCurrentNodeSpace()
	{
	}

	public virtual void AddReservedNodeSpace(NewNode.NodeSpace newSpace)
	{
	}

	public virtual void RemoveReservedNodeSpace()
	{
	}

	public virtual void UpdateTrespassing(bool allowEnforcersEverywhere)
	{
	}

	public virtual void SightingCheck(float fov, bool ignoreLightAndStealth = false)
	{
	}

	public virtual bool CanISee(Interactable interactable)
	{
		return false;
	}

	public bool ActorRaycastCheck(Actor other, float maxRange, out RaycastHit hit, bool drawLine = false, Color lineSuccess = default(Color), Color lineFail = default(Color), Color lineNothing = default(Color), float lineTime = 1f)
	{
		hit = default(RaycastHit);
		return false;
	}

	public virtual void OnInvestigate(Actor newTarget, int escalation)
	{
	}

	public virtual void OnAddTrackedTarget(Actor newTarget)
	{
	}

	public virtual void AddToSeesIllegal(Actor newTarget, float focus)
	{
	}

	public virtual void RemoveFromSeesIllegal(Actor newTarget, float focus)
	{
	}

	public virtual void AddPersuedBy(Actor newTarget)
	{
	}

	public virtual void RemovePersuedBy(Actor newTarget)
	{
	}

	public void HearIllegal(AudioEvent audioEvent, NewNode newInvestigateNode, Vector3 newInvestigatePosition, Actor newTarget, int escLevel)
	{
	}

	public virtual void ClearSeesIllegal()
	{
	}

	public virtual void SetEscalation(int newEsc)
	{
	}

	public void SelectedDebug(string str, HumanDebug debug)
	{
	}

	public void SpottedByPlayer(float graceTimeMultiplier = 1f)
	{
	}

	public void HeardByPlayer()
	{
	}

	public virtual bool IsTrespassing(NewRoom room, out int trespassEscalation, bool enforcersAllowedEverywhere = true)
	{
		trespassEscalation = default(int);
		return false;
	}

	public void AddLocationOfAuthorty(NewGameLocation newLoc)
	{
	}

	public void RemoveLocationOfAuthority(NewGameLocation newLoc)
	{
	}

	public virtual void UpdateIllegalStatus()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListSeesIllegal()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListWitnessToIllegal()
	{
	}

	public bool HasBeenThrowOutOfWindow()
	{
		return false;
	}
}
