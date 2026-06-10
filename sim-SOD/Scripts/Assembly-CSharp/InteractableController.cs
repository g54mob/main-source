using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class InteractableController : Controller
{
	public enum InteractableID
	{
		A = 0,
		B = 1,
		C = 2,
		D = 3,
		E = 4,
		F = 5,
		G = 6,
		H = 7,
		I = 8,
		J = 9,
		hidingPlace = 10,
		none = 11,
		K = 12,
		L = 13,
		M = 14,
		N = 15,
		O = 16,
		P = 17,
		Q = 18,
		R = 19,
		S = 20,
		T = 21,
		U = 22,
		V = 23,
		W = 24,
		X = 25,
		Y = 26,
		Z = 27,
		AA = 28,
		BB = 29,
		CC = 30,
		DD = 31
	}

	[NonSerialized]
	public Interactable interactable;

	[Tooltip("In-editor, set the ID here. This will be used by the preset to identify pairing for interactables.")]
	[Header("Editor Setup")]
	public InteractableID id;

	[Header("Components")]
	public List<MeshRenderer> meshes;

	public LODGroup lod;

	public Rigidbody rb;

	public Collider coll;

	public Collider altColl;

	public List<Collider> additionalPhysicsOnlyColliders;

	public Transform alternativePhysicsParent;

	public WorldFlashController flash;

	public DoorMovementController doorMovement;

	public DoorMovementController secondaryDoorMovement;

	public DoorMovementController thirdDoorMovement;

	public LightController lightController;

	public SteamController steam;

	public ComputerController computer;

	public SecuritySystem securitySystem;

	public FileSystemController fileSystem;

	public DecalProjector decalProjector;

	public List<Transform> pages;

	public ParticleSystem partSystem;

	public EchelonsLaserScreenController echelonsScreen;

	public bool useSmokeMaterial;

	public Transform lockParentOverride;

	public Vector3 lockedInTransformOffset;

	[Tooltip("Automatically sync these on/off depending on switch state.")]
	[Space(5f)]
	public bool enableSwitchSync;

	public List<SwitchSyncBehaviour> switchSyncObjects;

	[Header("State")]
	[Tooltip("True if currently being carried by the player")]
	public bool isVisible;

	public bool fixIfBelowBloodPool;

	public bool isCarriedByPlayer;

	private float carryProgress;

	private float rotProgress;

	private Vector3 pickupPos;

	private Quaternion pickupRot;

	private Vector3 heldEuler;

	private bool setHeldEuler;

	[Tooltip("True if the physics are currently active")]
	public bool physicsOn;

	[Tooltip("For measuring time after physics movement")]
	public float minimumPhysicsTime;

	public bool damageEligable;

	public bool wasTrigger;

	public Actor thrownBy;

	private float objectParticleCreationDelay;

	private Vector3 colliderExtents;

	public bool apartmentPlacementIsValid;

	[Tooltip("Look at when interacting (if null then use centre)")]
	[Header("Interactions")]
	public Transform lookAtTarget;

	[Tooltip("The interaction window for this object")]
	public InfoWindow interactionWindow;

	[Header("Special Cases")]
	[Tooltip("Use this flag for quickly checking if they player is looking at a door")]
	public NewDoor isDoor;

	public Actor isActor;

	public Human belongsTo;

	public bool isPhone;

	public GameObject phoneReciever;

	public float particleSystemDistance;

	public bool willBeSavedWithCity;

	public bool willBeSavedWithState;

	public bool isMainLight;

	private bool broken;

	[Header("Debug")]
	public List<Interactable> debugInteractable;

	[Tooltip("Angle of furniture parent")]
	public int debugAngle;

	public Vector3 debugFurnitureAnchorNodePos;

	[Tooltip("Local position of this, should match the transform")]
	public Vector3 debugLocalPos;

	[Tooltip("Local euler of this, should match the transform")]
	public Vector3 debugLocalEuler;

	public Vector3 debugWorldPos;

	public Vector3 debugInteractablePredictedWorldPos;

	[Tooltip("Interactable node")]
	public Vector3 debugNodeCoord;

	[Tooltip("The usage point")]
	public Interactable.UsagePoint debugUsagePoint;

	public Human debugOwnedBy;

	public Human debugWrittenBy;

	public Human debugReceivedBy;

	public object debugPasswordSource;

	public List<MonoBehaviour> debugFurnitureOwnedBy;

	public bool debugSwitchState;

	public bool debugState1;

	public NewRoom debugRoom;

	public AirDuctGroup.AirVent debugVent;

	private Renderer _raycastHitMeshRenderer;

	private Vector3 _hitMeshBounds;

	private Vector2 _ceilingEdgeMin;

	private Vector2 _ceilingEdgeMax;

	public void Setup(Interactable newInteractable)
	{
	}

	public void SetupDecal(ArtPreset foundArt, Interactable.Passed dynamic, bool doGraffitiChecks = true)
	{
	}

	public void UpdateSwitchSync()
	{
	}

	public void OnPageChange(int newPage)
	{
	}

	private void OnDestroy()
	{
	}

	public void GetScreenBox(out Vector2 uiMin, out Vector2 uiMax)
	{
		uiMin = default(Vector2);
		uiMax = default(Vector2);
	}

	public void OnExitInteractionMode()
	{
	}

	public void MovablePickUpThis()
	{
	}

	public void RotateHeldObject(float val)
	{
	}

	private void Update()
	{
	}

	private Vector3 ConvertBoundsPositionToTransformPosition(Vector3 boundsPosition)
	{
		return default(Vector3);
	}

	public void DropThis(bool throwThis)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}

	public void BreakObject(Vector3 contactPoint, Vector3 normal, float magnitude, Actor breaker)
	{
	}

	public void Spatter(Vector3 target)
	{
	}

	public void ParticleObjectCreation()
	{
	}

	private Vector3 UvTo3D(Vector2 uv, Mesh mesh)
	{
		return default(Vector3);
	}

	private float Area(Vector2 p1, Vector2 p2, Vector2 p3)
	{
		return 0f;
	}

	public void Shatter(Vector3 contact, float force)
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	public void SetPhysics(bool val, Actor setThrownBy = null)
	{
	}

	public void SetVisible(bool val, bool forceUpdate = false)
	{
	}

	private void UpdateLastMovement()
	{
	}

	public void UpdateParticleSystemDistance()
	{
	}

	public void State1Change()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayCCTVVectors()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RefreshCCTVCoveredArea()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayCCTVViewNodes()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateSaveFlags()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetSaveStateEligable()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void WasThisLoadedFromSaveGameData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SetupInteractable()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void IsOnPoolList()
	{
	}

	[Button("Load Furniture's Nodespace Area", EButtonEnableMode.Always)]
	public void LoadWalkable()
	{
	}

	[Button("List Users", EButtonEnableMode.Always)]
	public void ListUsers()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CalculateLocalFurniturePostion()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TogglePrintDebug()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Explode()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void GetLocalizedSnapshot()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdateName()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RevealUsePointPosition()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CalculatePositionWithoutGameObject()
	{
	}

	private bool TrySetRaycastMeshFilter(GameObject targetObject)
	{
		return false;
	}
}
