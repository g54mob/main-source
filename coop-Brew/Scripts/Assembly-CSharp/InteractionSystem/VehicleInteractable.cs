using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AudioSystem;
using BrewGame.SaveSystem.Integration;
using Brewery.Vehicle;
using Ezereal;
using InventorySystem;
using MyStuff.Vehicle;
using Synty.AnimationBaseLocomotion.Samples;
using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(ClientNetworkTransform))]
	public class VehicleInteractable : NetworkBehaviour, IInteractable, ISaveable
	{
		[Serializable]
		public class VehicleSeat
		{
			public Transform seatPosition;

			public bool isDriverSeat;

			public string seatName;

			[Header("Foot IK Targets")]
			[Tooltip("Left foot position for this seat")]
			public Transform leftFootTarget;

			[Tooltip("Right foot position for this seat")]
			public Transform rightFootTarget;

			[Header("Door (optional)")]
			[Tooltip("Door that swings open when entering this seat. When assigned, the player teleport is delayed by 'Door Open Wait Time' so the door has time to open first. Leave empty to use the instant teleport flow.")]
			public VehicleDoor door;

			[Header("Anchor point (optional)")]
			[Tooltip("World anchor where the player stands BEFORE smoothly lerping into the seat. When set, entry teleports the player here first then slides them into the seat over 'Seat Transition Duration', and exit slides them back out to this point before unparenting. Leave null to snap directly to the seat.")]
			public Transform anchorPoint;

			[HideInInspector]
			public ulong occupantId;

			[HideInInspector]
			public GameObject occupantPlayer;

			[HideInInspector]
			public GameObject occupantVisual;

			[HideInInspector]
			public VehicleSeatVisualSync occupantVisualSync;

			[HideInInspector]
			public bool pendingEntry;

			[HideInInspector]
			public float pendingEntryCountdown;

			[HideInInspector]
			public ulong pendingEntryClientId;

			[HideInInspector]
			public Vector3 pendingEntryOriginalPosition;

			[HideInInspector]
			public Quaternion pendingEntryOriginalRotation;

			[HideInInspector]
			public ulong pendingEntryOriginalParentNetId;

			[HideInInspector]
			public ulong pendingEntryVehicleInventoryNetId;

			[HideInInspector]
			public bool pendingExit;

			[HideInInspector]
			public float pendingExitCountdown;

			[HideInInspector]
			public ulong pendingExitClientId;

			[HideInInspector]
			public Vector3 pendingExitOriginalPosition;

			[HideInInspector]
			public Quaternion pendingExitOriginalRotation;

			[HideInInspector]
			public ulong pendingExitOriginalParentNetId;

			[HideInInspector]
			public ulong pendingExitVehicleInventoryNetId;

			[HideInInspector]
			public bool seatLerpActive;

			[HideInInspector]
			public float seatLerpTime;

			[HideInInspector]
			public bool seatLerpIntoSeat;

			[HideInInspector]
			public ulong seatLerpClientId;

			[HideInInspector]
			public bool seatLerpNeedsExitFinalize;

			public bool IsOccupied => false;
		}

		private class StoredRigidbodySettings
		{
			public float mass;

			public float drag;

			public float angularDrag;

			public bool useGravity;

			public bool isKinematic;

			public RigidbodyInterpolation interpolation;

			public CollisionDetectionMode collisionDetectionMode;

			public RigidbodyConstraints constraints;

			public Vector3 centerOfMass;

			public Vector3 inertiaTensor;

			public Quaternion inertiaTensorRotation;

			public float maxAngularVelocity;

			public float maxDepenetrationVelocity;

			public float sleepThreshold;

			public int solverIterations;

			public int solverVelocityIterations;
		}

		private class ServerStoredPlayerState
		{
			public Transform originalParent;

			public Vector3 originalPosition;

			public Quaternion originalRotation;
		}

		private class StoredPlayerState
		{
			public Vector3 originalPosition;

			public Quaternion originalRotation;

			public Transform originalParent;

			public bool[] componentStates;

			public MonoBehaviour[] components;

			public ClientNetworkTransform clientNetworkTransform;

			public bool clientNetworkTransformEnabled;

			public Transform cameraOriginalParent;

			public SampleCameraController cameraController;
		}

		[CompilerGenerated]
		private sealed class _003CDelayedOwnershipRemoval_003Ed__98 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ulong clientId;

			public VehicleInteractable _003C_003E4__this;

			public Vector3 positionBeforeTransfer;

			public Quaternion rotationBeforeTransfer;

			private bool _003CvehicleWasMoving_003E5__2;

			private float _003Ctimeout_003E5__3;

			private float _003Celapsed_003E5__4;

			private Vector3 _003CfinalPosition_003E5__5;

			private Quaternion _003CfinalRotation_003E5__6;

			private Rigidbody _003Crb_003E5__7;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDelayedOwnershipRemoval_003Ed__98(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPassengerExitCoroutine_003Ed__97 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ulong clientId;

			public VehicleInteractable _003C_003E4__this;

			public int seatIndex;

			public Vector3 positionBeforeTransfer;

			public Quaternion rotationBeforeTransfer;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPassengerExitCoroutine_003Ed__97(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPerformTeleportCoroutine_003Ed__156 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleInteractable _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			private Rigidbody _003Crb_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPerformTeleportCoroutine_003Ed__156(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CReenableNetworkTransformAfterDelay_003Ed__154 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public NetworkTransform networkTransform;

			public bool originalEnabledState;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CReenableNetworkTransformAfterDelay_003Ed__154(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CRestorePositionDelayed_003Ed__169 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleInteractable _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			private Rigidbody _003Crb_003E5__2;

			private float _003Cthreshold_003E5__3;

			private int _003CmaxFrames_003E5__4;

			private int _003Cframes_003E5__5;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRestorePositionDelayed_003Ed__169(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSafeExitCoroutine_003Ed__117 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterController characterController;

			public StoredPlayerState storedState;

			public GameObject playerObject;

			public VehicleInteractable _003C_003E4__this;

			public Collider playerCollider;

			public Collider[] vehicleColliders;

			public ulong clientId;

			public ulong vehicleInventoryNetworkObjectId;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSafeExitCoroutine_003Ed__117(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CSyncInitialSeatStates_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VehicleInteractable _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSyncInitialSeatStates_003Ed__71(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CTrackPositionAfterExit_003Ed__153 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform playerTransform;

			private Vector3 _003ClastPos_003E5__2;

			private int _003Ci_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTrackPositionAfterExit_003Ed__153(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static readonly List<VehicleInteractable> allVehicles;

		[Header("Vehicle Settings")]
		[SerializeField]
		private string vehicleName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Persistence")]
		[Tooltip("Unique ID for save/load. Auto-generated if empty. DO NOT change after first save!")]
		[SerializeField]
		private string uniqueVehicleId;

		[Header("Audio")]
		[Tooltip("Delay after door sound before engine start (seconds)")]
		[SerializeField]
		private float engineStartDelay;

		[Header("Flip Recovery")]
		[Tooltip("Angle from upright (in degrees) at which the vehicle is considered flipped")]
		[Range(45f, 120f)]
		[SerializeField]
		private float flipThresholdAngle;

		[Tooltip("Height to lift the vehicle during flip animation")]
		[SerializeField]
		private float flipLiftHeight;

		[Tooltip("Duration of the flip animation in seconds")]
		[SerializeField]
		private float flipAnimationDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Experimental - Physics Optimization")]
		[Tooltip("When enabled, removes Rigidbody from non-driver clients to reduce physics overhead. Only the driver keeps the Rigidbody for physics simulation.")]
		[SerializeField]
		private bool removeRigidbodyForNonDrivers;

		private bool isFlipping;

		private float _preSettleDrag;

		private float _originalDrag;

		private const float PARKED_DRAG = 2f;

		private StoredRigidbodySettings storedRigidbodySettings;

		private bool hasRemovedRigidbody;

		[Header("Seat Configuration")]
		[SerializeField]
		private List<VehicleSeat> seats;

		[Header("References")]
		[SerializeField]
		private EzerealCarController carController;

		[SerializeField]
		private VehicleInventoryManager vehicleInventory;

		[Tooltip("Optional trunk / tailgate VehicleDoor. When assigned, opens with a cartoony animation whenever ANY player has this vehicle's bed inventory open, and closes once the last viewer closes it. State is server-authoritative via a NetworkVariable so every client sees it in sync. Configure openAngle on the VehicleDoor component to match your trunk's hinge (e.g., -90 for a tailgate that rotates from -90 → -180 on Y).")]
		[SerializeField]
		private VehicleDoor trunk;

		[Header("Door Entry")]
		[Tooltip("Seconds to wait after the door starts opening before the player teleports into the seat. Tune to match the door's open tween duration so the player pops in just as the door finishes swinging. Only applied when a seat has a 'door' assigned — otherwise the legacy instant teleport is used.")]
		[SerializeField]
		private float doorOpenWaitTime;

		[Tooltip("Seconds to smoothly slide the player from the anchor point into the seat on ENTRY. Only applied when a seat has an 'Anchor Point' assigned. Tune your animator's Locomotion → CarDriving transition duration to match this value.")]
		[SerializeField]
		private float seatTransitionDuration;

		[Tooltip("Seconds to smoothly slide the player from the seat back to the anchor on EXIT. Defaults shorter than the entry duration so exits feel snappier.")]
		[SerializeField]
		private float exitTransitionDuration;

		[Header("Driver IK Targets")]
		[Tooltip("Left hand position on steering wheel")]
		[SerializeField]
		private Transform leftHandTarget;

		[Tooltip("Right hand position on steering wheel")]
		[SerializeField]
		private Transform rightHandTarget;

		[Tooltip("Right hand position on gear shifter (optional - for gear shift animation)")]
		[SerializeField]
		private Transform gearShifterTarget;

		[Tooltip("Right hand position on radio (optional - for radio reach animation)")]
		[SerializeField]
		private Transform radioTarget;

		[Tooltip("Right hand position on handbrake (optional - for handbrake grab animation)")]
		[SerializeField]
		private Transform handbrakeTarget;

		private VehicleDriverIK driverIK;

		private VehiclePassengerIK passengerIK;

		private VehicleEngineAudio engineAudioForIK;

		private VehicleRadioController radioControllerForIK;

		private NetworkList<ulong> seatOccupants;

		private Dictionary<ulong, int> playerSeatIndex;

		private readonly NetworkVariable<bool> _trunkOpen;

		private readonly HashSet<ulong> _trunkViewers;

		private readonly Dictionary<ulong, float> playerTransitionExpiryTime;

		private readonly Dictionary<ulong, float> _lastInteractionByClient;

		private const float INTERACTION_SPAM_COOLDOWN = 0.5f;

		private Dictionary<ulong, StoredPlayerState> storedPlayerStates;

		private readonly Dictionary<ulong, ClientNetworkTransform> _disabledRemoteCNTs;

		private readonly Dictionary<ulong, ServerStoredPlayerState> serverStoredPlayerStates;

		private bool hasLoggedSeatConfiguration;

		private PlayerInput vehiclePlayerInput;

		private bool isSubscribedToInputReader;

		private readonly Dictionary<ulong, Action> _exitFinalizers;

		public string UniqueVehicleId => null;

		public ulong VehicleInventoryNetworkId => 0uL;

		public string SaveableId => null;

		public int SavePriority => 0;

		public static bool IsPlayerInAnyVehicle(ulong clientId)
		{
			return false;
		}

		public static VehicleInteractable GetVehicleContainingPlayer(ulong clientId)
		{
			return null;
		}

		public void ForcePlayerExitForRecovery(ulong clientId)
		{
		}

		private void RegisterVehicle()
		{
		}

		private void UnregisterVehicle()
		{
		}

		public void SetUniqueId(string id)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void SubscribeToInputReaderForExit()
		{
		}

		private void UnsubscribeFromInputReader()
		{
		}

		private void OnInputReaderInteract()
		{
		}

		private void CheckForExitInput()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnCameraPreCull(Camera cam)
		{
		}

		private void EnforceAllSeatedPlayersPosition()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSyncInitialSeatStates_003Ed__71))]
		private IEnumerator SyncInitialSeatStates()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		private void EmergencyRestoreLocalPlayerState()
		{
		}

		private void OnClientDisconnected(ulong clientId)
		{
		}

		private void ForceExitVehicle(ulong clientId, int seatIndex)
		{
		}

		private void OnSeatOccupancyChanged(NetworkListEvent<ulong> changeEvent)
		{
		}

		private void UpdateCarControllerDriverState()
		{
		}

		public string GetInteractionPrompt()
		{
			return null;
		}

		public bool CanInteract(ulong clientId)
		{
			return false;
		}

		public void Interact(ulong clientId)
		{
		}

		public float GetInteractionDistance()
		{
			return 0f;
		}

		public Transform GetInteractionTransform()
		{
			return null;
		}

		public int GetInteractionPriority()
		{
			return 0;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
		{
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		private int GetClosestAvailableSeat(ulong clientId)
		{
			return 0;
		}

		private void HandleInteractionServer(ulong clientId)
		{
		}

		private bool IsPlayerInTransition(ulong clientId)
		{
			return false;
		}

		private void SetPlayerInTransition(ulong clientId, float duration)
		{
		}

		private bool AcquireInteractionRateLimit(ulong clientId, string pathName)
		{
			return false;
		}

		private void ReconcileAllSeats()
		{
		}

		private void ReconcileClientSeatState(ulong clientId)
		{
		}

		public void RequestVehicleInventoryAccess()
		{
		}

		private void EnterVehicleServer(ulong clientId, int seatIndex)
		{
		}

		private void ExitVehicleServer(ulong clientId, int seatIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CPassengerExitCoroutine_003Ed__97))]
		private IEnumerator PassengerExitCoroutine(ulong clientId, int seatIndex, Vector3 positionBeforeTransfer, Quaternion rotationBeforeTransfer)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedOwnershipRemoval_003Ed__98))]
		private IEnumerator DelayedOwnershipRemoval(ulong clientId, Vector3 positionBeforeTransfer, Quaternion rotationBeforeTransfer)
		{
			return null;
		}

		private void CompleteVehicleExit(ulong clientId, int seatIndex, Vector3 positionBeforeTransfer, Quaternion rotationBeforeTransfer)
		{
		}

		[ClientRpc]
		private void EnterVehicleClientRpc(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId, ulong vehicleInventoryNetworkObjectId)
		{
		}

		private void ProcessPendingEntries()
		{
		}

		private void CancelPendingEntryForClient(ulong clientId)
		{
		}

		private void ProcessPendingExits()
		{
		}

		private void CancelPendingExitForClient(ulong clientId)
		{
		}

		private void ProcessSeatLerps()
		{
		}

		private GameObject ResolvePlayerObject(ulong clientId)
		{
			return null;
		}

		private void DisableRemoteCNT(ulong clientId)
		{
		}

		private void ReenableRemoteCNT(ulong clientId)
		{
		}

		private void StartEntrySeatLerp(int seatIndex, ulong clientId)
		{
		}

		private void StartExitSeatLerp(int seatIndex, ulong clientId)
		{
		}

		private bool IsVehicleEntryStillValid(ulong clientId, int seatIndex)
		{
			return false;
		}

		private void CompleteVehicleEntry(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId, ulong vehicleInventoryNetworkObjectId)
		{
		}

		[ClientRpc]
		private void ExitVehicleClientRpc(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId, ulong vehicleInventoryNetworkObjectId)
		{
		}

		private void CompleteVehicleExitClient(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId, ulong vehicleInventoryNetworkObjectId)
		{
		}

		private void FinalizeVehicleExit(ulong clientId, int seatIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CSafeExitCoroutine_003Ed__117))]
		private IEnumerator SafeExitCoroutine(GameObject playerObject, CharacterController characterController, Collider playerCollider, Collider[] vehicleColliders, StoredPlayerState storedState, ulong clientId, ulong vehicleInventoryNetworkObjectId)
		{
			return null;
		}

		private bool IsClientOccupying(ulong clientId)
		{
			return false;
		}

		private bool IsLocalPlayerParentedToVehicle()
		{
			return false;
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void NotifyTrunkViewedServerRpc(bool viewing, RpcParams rpcParams = default(RpcParams))
		{
		}

		private void UpdateTrunkOpenStateFromViewers()
		{
		}

		private void OnTrunkOpenChanged(bool previous, bool current)
		{
		}

		private void ApplyTrunkStateImmediate(bool isOpen)
		{
		}

		private void NotifyLocalTrunkViewChange(bool viewing)
		{
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void RequestVehicleInventoryAccessRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void OpenVehicleInventoryClientRpc(ulong vehicleInventoryNetworkObjectId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void OnVehicleInputAction(InputAction.CallbackContext context)
		{
		}

		private bool IsLocalPlayerInThisVehicle()
		{
			return false;
		}

		[Rpc(SendTo.Server, RequireOwnership = false)]
		private void RequestExitVehicleRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		private void DisableRigidbodyPhysicsForNonDriver()
		{
		}

		private void RestoreRigidbodyPhysics()
		{
		}

		[ClientRpc]
		private void UpdateRigidbodyStateClientRpc(ulong driverClientId, bool hasDriver)
		{
		}

		private Transform ResolveParentTransform(ulong parentNetworkObjectId)
		{
			return null;
		}

		private void SetPlayerCharacterController(NetworkObject playerNetworkObject, bool enabled)
		{
		}

		private void ApplyCharacterControllerState(NetworkObject playerNetworkObject, bool enabled)
		{
		}

		[ClientRpc]
		private void UpdateCharacterControllerClientRpc(NetworkObjectReference playerRef, bool enabled)
		{
		}

		[ClientRpc]
		private void TogglePlayerRenderersClientRpc(NetworkObjectReference playerRef, bool visible)
		{
		}

		[ClientRpc]
		private void SpawnSeatVisualClientRpc(NetworkObjectReference playerRef, int seatIndex)
		{
		}

		[ClientRpc]
		private void DespawnSeatVisualClientRpc(int seatIndex)
		{
		}

		private void SetDriverState(ulong driverId, bool hasDriver)
		{
		}

		private void CreateSeatVisualLocal(int seatIndex, NetworkObject playerNetworkObject)
		{
		}

		private void DestroySeatVisualLocal(int seatIndex)
		{
		}

		private static Transform FindPlayerVisualRoot(Transform playerRoot)
		{
			return null;
		}

		private static void SetRenderersEnabled(GameObject target, bool visible)
		{
		}

		private static void SetLayerRecursively(GameObject obj, int layer)
		{
		}

		private void TeleportTransform(Transform targetTransform, Vector3 position, Quaternion rotation)
		{
		}

		private Vector3 FindSafeExitPosition()
		{
			return default(Vector3);
		}

		public bool IsFlipped()
		{
			return false;
		}

		private void FlipVehicleServer()
		{
		}

		[ClientRpc]
		private void FlipVehicleClientRpc(Vector3 startPosition, Vector3 liftedPosition, Quaternion targetRotation, float duration)
		{
		}

		public bool ResetToSpawnPoint(Vector3 position, Quaternion rotation)
		{
			return false;
		}

		[ClientRpc]
		private void ResetToSpawnPointClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		[IteratorStateMachine(typeof(_003CTrackPositionAfterExit_003Ed__153))]
		private IEnumerator TrackPositionAfterExit(Transform playerTransform)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CReenableNetworkTransformAfterDelay_003Ed__154))]
		private IEnumerator ReenableNetworkTransformAfterDelay(NetworkTransform networkTransform, float delay, bool originalEnabledState = true)
		{
			return null;
		}

		private void PerformTeleport(Vector3 position, Quaternion rotation)
		{
		}

		[IteratorStateMachine(typeof(_003CPerformTeleportCoroutine_003Ed__156))]
		private IEnumerator PerformTeleportCoroutine(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public bool IsAnyoneInVehicle()
		{
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void DrawIKTargetGizmos()
		{
		}

		private void DrawGizmoAxes(Transform t, float length)
		{
		}

		private string GetStableId()
		{
			return null;
		}

		private string GetHierarchyPath()
		{
			return null;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		[IteratorStateMachine(typeof(_003CRestorePositionDelayed_003Ed__169))]
		private IEnumerator RestorePositionDelayed(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		private void GenerateRuntimeUniqueId()
		{
		}

		private string GenerateDeterministicSceneId()
		{
			return null;
		}

		private void EnsureUniqueId()
		{
		}

		[ClientRpc]
		private void NotifyVehicleEntryClientRpc(ulong clientId, string vehName)
		{
		}

		private void SetupDriverIK(GameObject animatorObject, bool enable)
		{
		}

		private void OnGearShiftForIK()
		{
		}

		private void OnRadioInteractionForIK()
		{
		}

		private void OnHandbrakeStateChangedForIK(bool engaged)
		{
		}

		private void SetupPassengerIK(GameObject animatorObject, int seatIndex, bool enable)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3480621855(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_947643070(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3012946690(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_618069688(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3578838167(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3032878485(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3490472829(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3667980612(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4192368640(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2853711526(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2183987453(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3613193076(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2241603731(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2600827613(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
