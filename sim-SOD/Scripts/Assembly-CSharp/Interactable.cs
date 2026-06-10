using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class Interactable
{
	[Serializable]
	public class LightConfiguration
	{
		public Color colour;

		public float intensity;

		public float flickerColourMultiplier;

		public float pulseSpeed;

		public float intervalTime;

		public bool flicker;

		public float range;
	}

	[Serializable]
	public class SavedPrint
	{
		public Vector3 worldPos;

		public int interactableID;
	}

	[Serializable]
	public class DynamicFingerprint
	{
		public int id;

		public float created;

		public string seed;

		public PrintLife life;
	}

	public enum PrintLife
	{
		timed = 0,
		manualRemoval = 1
	}

	public class InteractableCurrentAction
	{
		public InteractablePreset.InteractionAction currentAction;

		public bool display;

		public bool enabled;

		public string overrideInteractionName;

		public bool forcePositioning;

		public ControlDisplayController.ControlPositioning forcePosition;

		public bool highlight;
	}

	[Serializable]
	public class UsagePoint
	{
		public InteractablePreset.AIUseSetting useSetting;

		[NonSerialized]
		public Interactable interactable;

		public NewNode node;

		public Dictionary<UsePointSlot, Human> users;

		[NonSerialized]
		public GroupsController.SocialGroup reserved;

		[SerializeField]
		private Vector3 useageWorldPosition;

		public Vector3 worldLookAtPoint;

		public Human debugDefaultSlot;

		public Human debugSlot1;

		public Human debugSlot2;

		public List<string> slotLog;

		public UsagePoint(InteractablePreset.AIUseSetting newPreset, Interactable newInteractable, NewNode newNode)
		{
		}

		public void PositionUpdate()
		{
		}

		public Vector3 GetUsageWorldPosition(Vector3 userPos, Actor actor)
		{
			return default(Vector3);
		}

		private Vector3 GetPositionWithInvertedZ()
		{
			return default(Vector3);
		}

		public bool TrySetUser(UsePointSlot slot, Human newUser, string debug = "")
		{
			return false;
		}

		public void SetReserved(GroupsController.SocialGroup group)
		{
		}

		public bool TryGetUserAtSlot(UsePointSlot slot, out Human user)
		{
			user = null;
			return false;
		}

		public void RemoveUserFromAllSlots(Human user)
		{
		}
	}

	public enum UsePointSlot
	{
		defaultSlot = 0,
		slot1 = 1,
		slot2 = 2
	}

	public enum PassedVarType
	{
		jobID = 0,
		humanID = 1,
		noteID = 2,
		roomID = 3,
		addressID = 4,
		time = 5,
		savedSceneCapID = 6,
		menuIndex = 7,
		vmailThreadID = 8,
		consumableAmount = 9,
		companyID = 10,
		stringInteractablePreset = 11,
		isTrash = 12,
		jobTag = 13,
		groupID = 14,
		ddsOverride = 15,
		metaObjectID = 16,
		murderID = 17,
		decal = 18,
		decalDynamicText = 19,
		ownedByAddress = 20,
		vmailThreadMsgIndex = 21,
		phoneNumber = 22,
		lostItemPreset = 23,
		lostItemBuilding = 24,
		lostItemReward = 25,
		lostItemFloorX = 26,
		lostItemFloorY = 27,
		creationTime = 28,
		stateValue = 29,
		inspected = 30,
		lma = 31,
		spR = 32,
		spP = 33,
		phy = 34,
		drm = 35,
		lhc = 36,
		inStorage = 37
	}

	[Serializable]
	public class Passed
	{
		public PassedVarType varType;

		public float value;

		public string str;

		public Passed(PassedVarType newType, float newVal, string newStr = null)
		{
		}
	}

	public delegate void SwitchChange();

	public delegate void State1Change();

	public delegate void Deleted(Interactable destroyed);

	public delegate void RemovedFromWorld();

	[Header("Serializable")]
	public int id;

	[NonSerialized]
	public static int worldAssignID;

	public Vector3 wPos;

	public Vector3 wEuler;

	public Vector3 lPos;

	public Vector3 lEuler;

	public Vector3 spWPos;

	public Vector3 spWEuler;

	public string p;

	public List<Passed> pv;

	public int fp;

	public int fsoi;

	public int dp;

	public Toolbox.MaterialKey mk;

	public LightConfiguration lcd;

	public string lp;

	public string dds;

	public int w;

	public int r;

	public int b;

	public int inv;

	public float val;

	public float cs;

	public bool wo;

	public string bo;

	public string sd;

	public bool sw0;

	public bool sw1;

	public bool sw2;

	public bool sw3;

	public bool locked;

	public int lzs;

	public bool ml;

	public List<InteractablePreset.SubSpawnSlot> ssp;

	public float mtr;

	public bool cr;

	public bool rem;

	public bool rPl;

	public bool spCh;

	public bool force;

	public List<DynamicFingerprint> df;

	public List<SavedPrint> print;

	public List<SceneRecorder.SceneCapture> cap;

	public List<SceneRecorder.SceneCapture> sCap;

	public int nEvKey;

	public bool ft;

	public GameplayController.Passcode passcode;

	[NonSerialized]
	[Header("Non Serialized")]
	public string name;

	[NonSerialized]
	public Vector3Int spNode;

	[NonSerialized]
	public int pt;

	[NonSerialized]
	public bool mov;

	[NonSerialized]
	public bool phy;

	[NonSerialized]
	public bool audioLoopStarted;

	[NonSerialized]
	public Telephone t;

	[NonSerialized]
	public string seed;

	[NonSerialized]
	public bool save;

	[NonSerialized]
	public bool isTampered;

	[NonSerialized]
	public float distanceFromSpawn;

	[NonSerialized]
	public bool originalPosition;

	[NonSerialized]
	public Vector3 cvp;

	[NonSerialized]
	public Vector3 cve;

	[NonSerialized]
	public Evidence evidence;

	[NonSerialized]
	public SceneRecorder sceneRecorder;

	[NonSerialized]
	public Transform spawnParent;

	[NonSerialized]
	public Transform parentTransform;

	[NonSerialized]
	public Human inInventory;

	[NonSerialized]
	public InteractablePreset preset;

	[NonSerialized]
	public FurnitureLocation furnitureParent;

	[NonSerialized]
	public FurniturePreset.SubObject subObject;

	[NonSerialized]
	public SideJob jobParent;

	[NonSerialized]
	public MurderController.Murder murderParent;

	[NonSerialized]
	public SpeechController speechController;

	[NonSerialized]
	public InteractableController controller;

	[NonSerialized]
	public LightController lightController;

	[NonSerialized]
	public Interactable lockInteractable;

	[NonSerialized]
	public Interactable thisDoor;

	[NonSerialized]
	public object passwordSource;

	[NonSerialized]
	public GameObject spawnedObject;

	[NonSerialized]
	public NewNode node;

	[NonSerialized]
	public NewNode spawnNode;

	[NonSerialized]
	public NewRoom worldObjectRoomParent;

	[NonSerialized]
	public UsagePoint usagePoint;

	[NonSerialized]
	public NewAIAction nextAIInteraction;

	[NonSerialized]
	public LightingPreset isLight;

	[NonSerialized]
	public object objectRef;

	[NonSerialized]
	public Human writer;

	[NonSerialized]
	public Human reciever;

	[NonSerialized]
	public Human belongsTo;

	[NonSerialized]
	public Actor isActor;

	[NonSerialized]
	public BookPreset book;

	[NonSerialized]
	public SyncDiskPreset syncDisk;

	[NonSerialized]
	public GroupsController.SocialGroup group;

	[NonSerialized]
	public float recentCallCheck;

	[NonSerialized]
	private Transform ceilingFan;

	[NonSerialized]
	public NewAddress forSale;

	[NonSerialized]
	public List<Human> proxy;

	[NonSerialized]
	public List<SpatterSimulation.DecalSpawnData> spawnedDecals;

	[NonSerialized]
	public AudioController.LoopingSoundInfo actionLoop;

	[NonSerialized]
	public bool loadedGeometry;

	[NonSerialized]
	public Dictionary<InteractablePreset.InteractionKey, InteractableCurrentAction> currentActions;

	[NonSerialized]
	public List<InteractablePreset.InteractionAction> highlightActions;

	[NonSerialized]
	public List<InteractablePreset.InteractionAction> disabledActions;

	[NonSerialized]
	public Dictionary<AIActionPreset, InteractablePreset.InteractionAction> aiActionReference;

	[NonSerialized]
	public float readingDelay;

	[NonSerialized]
	public Dictionary<AIActionPreset, AudioEvent> actionAudioEventOverrides;

	[NonSerialized]
	public List<AudioController.LoopingSoundInfo> loopingAudio;

	[NonSerialized]
	private bool isSetup;

	[NonSerialized]
	public bool wasLoadedFromSave;

	[NonSerialized]
	public bool mainSetupRun;

	[NonSerialized]
	public bool printDebug;

	public event SwitchChange OnSwitchChange
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

	public event State1Change OnState1Change
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

	public event Deleted OnDelete
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

	public event RemovedFromWorld OnRemovedFromWorld
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

	public Interactable(InteractablePreset newPreset)
	{
	}

	public void MainSetupStart()
	{
	}

	public void UpdatePassedVariables()
	{
	}

	public void OnCreate()
	{
	}

	public void OnLoad()
	{
	}

	public void MainSetupEnd()
	{
	}

	public void OnDecorItemMoveToStorage()
	{
	}

	public void OnDecorItemRePlace()
	{
	}

	private void UpdateSpecialCaseReferences()
	{
	}

	public void RemoveSpecialCaseReferences()
	{
	}

	public void SpawnCheck()
	{
	}

	public void GenerateLightData()
	{
	}

	public void SetMaterialKey(Toolbox.MaterialKey newMatKey)
	{
	}

	public void SetPolymorphicReference(object newRef)
	{
	}

	public void SetValue(float newValue)
	{
	}

	public void SetExtraStateValue(float newValue, bool setSpecialCaseValues = true)
	{
	}

	public float GetExtraStateValue()
	{
		return 0f;
	}

	public void SetDDSOverride(string newTreeID)
	{
	}

	public void AssignIDWorld()
	{
	}

	public void AssignRoomBasedID(NewRoom r)
	{
	}

	public void AssignFurnitureBasedID(FurnitureLocation f)
	{
	}

	public void MoveInteractable(Vector3 newWorldPos, Vector3 newEulerAngle, bool updateSpawnPosition)
	{
	}

	public void SetNewPositionAndParent(Transform newParent, Vector3 newLocalPos, Vector3 newLocalEuler, bool updateSpawnPosition)
	{
	}

	public void SetNewPosition(Vector3 newLocalPos, Vector3 newLocalEuler, bool updateSpawnPosition)
	{
	}

	public Vector3 GetWorldPosition(bool useSpawnedPosition = true)
	{
		return default(Vector3);
	}

	public Vector3 UpdateWorldPositionAndNode(bool updateSpawnPosition, bool forceUpdate = false)
	{
		return default(Vector3);
	}

	public void SetPasswordSource(object newPSource)
	{
	}

	public void SetOwner(Human newOwner, bool updateName = true)
	{
	}

	public void SetWriter(Human newWriter)
	{
	}

	public void SetReciever(Human newReciever)
	{
	}

	public string GetName()
	{
		return null;
	}

	public void UpdateName(bool assignNewNamingEvidenceKey = false, Evidence.DataKey newKey = Evidence.DataKey.name)
	{
	}

	public void SetInInventory(Human newActor)
	{
	}

	public void SetAsNotInventory(NewNode newNode)
	{
	}

	public void UpdateCurrentActions()
	{
	}

	public virtual void SetSwitchState(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false, bool forceInstantLights = false)
	{
	}

	public virtual void SetCustomState1(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false, bool forceInstantLights = false)
	{
	}

	public virtual void SetCustomState2(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false, bool forceInstantLights = false)
	{
	}

	public virtual void SetCustomState3(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false, bool forceInstantLights = false)
	{
	}

	public virtual void SetLockedState(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false)
	{
	}

	public virtual void SetPhysicsPickupState(bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false)
	{
	}

	public void ResetToDefaultSwitchState()
	{
	}

	public void UpdateSwitchStateAudio(InteractablePreset.IfSwitchStateSFX aud, bool swState, List<NewNode> doorNodes, Actor interactor)
	{
	}

	public void MusicPlayerNextTrack(int add)
	{
	}

	public void UpdateMusicPlayer()
	{
	}

	public void UpdateLoopingAudioParams()
	{
	}

	public void OnInteraction(InteractablePreset.InteractionKey input, Actor who)
	{
	}

	public void OnInteraction(InteractablePreset.InteractionAction action, Actor who, bool allowDelays = true, float additionalDelay = 0f)
	{
	}

	public void LoadInteractableToWorld(bool respawn = false, bool forceSpawnImmediate = false)
	{
	}

	public void SetSpawnPositionRelevent(bool val)
	{
	}

	public bool IsSpawnPositionRelevent()
	{
		return false;
	}

	public void SpawnObject(out bool wasPooled)
	{
		wasPooled = default(bool);
	}

	public void UnloadInteractable()
	{
	}

	public void DespawnObject()
	{
	}

	public void OnSpawn()
	{
	}

	public void SpawnLock()
	{
	}

	public void MarkAsTrash(bool val, bool forceTime = false, float forcedTime = 0f)
	{
	}

	public void RemoveFromPlacement()
	{
	}

	public void SafeDelete(bool removeFromInventory = false)
	{
	}

	public void Delete()
	{
	}

	public bool IsSafeToDelete(bool displayDebug = false)
	{
		return false;
	}

	public bool IsSaveStateEligable()
	{
		return false;
	}

	public string GetReasonForSaveStateEligable()
	{
		return null;
	}

	public void SetAsLight(LightingPreset newLightPreset, int newLightZoneSize, bool newIsMainLight, LightConfiguration preconfiguredLight)
	{
	}

	public void SetNextAIInteraction(NewAIAction newAction, NewAIController ai)
	{
	}

	public void OnDoorMovementClosed()
	{
	}

	public void OnDoorMovementOpened()
	{
	}

	public List<int> GetPasswordFromSource(out List<string> notePlacements)
	{
		notePlacements = null;
		return null;
	}

	public GameplayController.Passcode GetPasswordSource()
	{
		return null;
	}

	public void AddPasswordSourceToAcquired()
	{
	}

	public void SetActionHighlight(string newString, bool val)
	{
	}

	public void SetActionDisable(string newString, bool val)
	{
	}

	public void SetOriginalPosition(bool newVal, bool setGameTime = true, bool forceUpdate = false)
	{
	}

	public void SetTampered(bool val)
	{
	}

	public void AddNewDynamicFingerprint(Human from, PrintLife life)
	{
	}

	public void RemoveDynamicPrint(DynamicFingerprint print)
	{
	}

	public void OnHourChange()
	{
	}

	public void OnLockpick()
	{
	}

	public void OnLockpickLookedAway()
	{
	}

	public void OnLockpickProgressChange(float amountChangeThisFrame, float amountToal)
	{
	}

	public void OnCompleteLockpick()
	{
	}

	public void OnReturnFromLockpick()
	{
	}

	public void ForcePhysicsActive(bool forceSpawnLocation, bool applyForce, Vector3 force = default(Vector3), ForceMode forceMode = ForceMode.VelocityChange, bool useThrowingForce = false)
	{
	}

	public void ConvertToFurnitureSpawnedObject(FurnitureLocation newFurniture, FurniturePreset.SubObject newSubObject, bool updatePosition = true, bool updateSpawnPosition = true)
	{
	}

	public void ConvertToWorldObject(bool updatePosition = true)
	{
	}

	public void ResetToFurnitureObject(bool updatePosition = true)
	{
	}

	public bool IsLitter()
	{
		return false;
	}

	public bool PickUpTarget(Human pickerUpper, bool pickUpLitter = false)
	{
		return false;
	}

	public void RemoveManuallyCreatedFingerprints()
	{
	}

	public float GetReachDistance()
	{
		return 0f;
	}

	public float GetSecurityStrength()
	{
		return 0f;
	}

	public bool IsInteractablePhysicsObject()
	{
		return false;
	}

	public bool GetSwitchQuery(InteractablePreset.Switch switchState)
	{
		return false;
	}

	public void SetSwtichByType(InteractablePreset.Switch switchState, bool val, Actor interactor, bool playSFX = true, bool forceUpdate = false)
	{
	}

	public bool TryGetCreationTime(out float creationTime)
	{
		creationTime = default(float);
		return false;
	}

	public void MarkInspected()
	{
	}

	public void MarkLastMovedAt()
	{
	}

	public void ResetLastMovedAt()
	{
	}

	public void SetObjectSpawnPriority(int val)
	{
	}

	public int GetObjectSpawnPriority()
	{
		return 0;
	}

	public void SetDistanceRecognitionMode(bool val)
	{
	}

	public bool GetDistanceRecognitionMode()
	{
		return false;
	}

	public void CopyState(Interactable existing)
	{
	}
}
