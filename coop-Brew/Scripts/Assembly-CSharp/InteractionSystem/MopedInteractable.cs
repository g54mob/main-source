using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Vehicle;
using Synty.AnimationBaseLocomotion.Samples;
using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(ClientNetworkTransform))]
	public class MopedInteractable : NetworkBehaviour, IInteractable, ISaveable
	{
		[Serializable]
		public class MopedSeat
		{
			public Transform seatPosition;

			public bool isDriverSeat;

			public string seatName;

			[Tooltip("Optional world anchor where the player stands BEFORE smoothly sliding into the seat. When set, entry teleports here first, then lerps into the seat over 'Seat Transition Duration'. Leave null to snap directly to the seat.")]
			public Transform anchorPoint;

			[Header("IK Targets")]
			public Transform leftHandTarget;

			public Transform rightHandTarget;

			public Transform leftFootTarget;

			public Transform rightFootTarget;

			[HideInInspector]
			public ulong occupantId;

			[HideInInspector]
			public GameObject occupantPlayer;

			[HideInInspector]
			public Vector3 cachedLocalPosition;

			[HideInInspector]
			public Quaternion cachedLocalRotation;

			[HideInInspector]
			public bool seatLerpActive;

			[HideInInspector]
			public float seatLerpTime;

			[HideInInspector]
			public ulong seatLerpClientId;

			public bool IsOccupied => false;
		}

		private class StoredPlayerState
		{
			public Vector3 originalPosition;

			public Quaternion originalRotation;

			public Transform originalParent;

			public bool[] componentStates;

			public MonoBehaviour[] components;

			public Animator animator;

			public bool animatorRootMotion;

			public ClientNetworkTransform clientNetworkTransform;

			public bool clientNetworkTransformEnabled;

			public int seatIndex;

			public Transform cameraOriginalParent;

			public SampleCameraController cameraController;
		}

		private class ServerStoredPlayerState
		{
			public Transform originalParent;

			public Vector3 originalPosition;

			public Quaternion originalRotation;

			public int seatIndex;
		}

		[CompilerGenerated]
		private sealed class _003CClearTransitionGuard_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public MopedInteractable _003C_003E4__this;

			public ulong clientId;

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
			public _003CClearTransitionGuard_003Ed__76(int _003C_003E1__state)
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
		private sealed class _003CDelayedMopedOwnershipRemoval_003Ed__80 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ulong clientId;

			public MopedInteractable _003C_003E4__this;

			public int seatIndex;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

			private Vector3 _003CfinalPosition_003E5__4;

			private Quaternion _003CfinalRotation_003E5__5;

			private Rigidbody _003Crb_003E5__6;

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
			public _003CDelayedMopedOwnershipRemoval_003Ed__80(int _003C_003E1__state)
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
		private sealed class _003CExitPassengerSeatCoroutine_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ulong clientId;

			public MopedInteractable _003C_003E4__this;

			public int seatIndex;

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
			public _003CExitPassengerSeatCoroutine_003Ed__82(int _003C_003E1__state)
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
		private sealed class _003CPerformTeleportCoroutine_003Ed__100 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MopedInteractable _003C_003E4__this;

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
			public _003CPerformTeleportCoroutine_003Ed__100(int _003C_003E1__state)
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
		private sealed class _003CReenablePhysicsAfterDelay_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public Rigidbody rb;

			public MopedInteractable _003C_003E4__this;

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
			public _003CReenablePhysicsAfterDelay_003Ed__112(int _003C_003E1__state)
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
		private sealed class _003CSafeSeatExitCoroutine_003Ed__85 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterController characterController;

			public StoredPlayerState state;

			public GameObject playerObject;

			public Collider playerCollider;

			public Collider[] mopedColliders;

			public MopedInteractable _003C_003E4__this;

			public ulong clientId;

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
			public _003CSafeSeatExitCoroutine_003Ed__85(int _003C_003E1__state)
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
		private sealed class _003CSyncSeatStateFromNetworkList_003Ed__57 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MopedInteractable _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CSyncSeatStateFromNetworkList_003Ed__57(int _003C_003E1__state)
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
		private sealed class _003CWaitForPlayerObject_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MopedInteractable _003C_003E4__this;

			public int seatIndex;

			public ulong clientId;

			private float _003Ctimeout_003E5__2;

			private MopedSeat _003Cseat_003E5__3;

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
			public _003CWaitForPlayerObject_003Ed__60(int _003C_003E1__state)
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

		private static readonly List<MopedInteractable> allMopeds;

		[Header("Moped Settings")]
		[SerializeField]
		private string mopedName;

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
		private string uniqueMopedId;

		[Header("Flip Recovery")]
		[Tooltip("Angle from upright (in degrees) at which the moped is considered flipped")]
		[Range(45f, 120f)]
		[SerializeField]
		private float flipThresholdAngle;

		[Tooltip("Height to lift the moped during flip animation")]
		[SerializeField]
		private float flipLiftHeight;

		[Tooltip("Duration of the flip animation in seconds")]
		[SerializeField]
		private float flipAnimationDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Tooltip("For testing: forces entry as passenger instead of driver")]
		[SerializeField]
		private bool forceEnterAsPassenger;

		[Header("Seats")]
		[SerializeField]
		private List<MopedSeat> seats;

		[Tooltip("Seconds to smoothly slide the player from the anchor point into the seat on ENTRY. Only used when a seat has an 'Anchor Point' assigned. Tune the animator locomotion→riding transition duration to match for the best visual blend.")]
		[SerializeField]
		private float seatTransitionDuration;

		[Header("References")]
		[SerializeField]
		private MopedController mopedController;

		private bool isFlipping;

		private float _preSettleDrag;

		private float _originalDrag;

		private const float PARKED_DRAG = 2f;

		private NetworkList<ulong> seatOccupants;

		private Dictionary<ulong, int> playerSeatIndex;

		private HashSet<ulong> playersInTransition;

		private Dictionary<ulong, StoredPlayerState> storedPlayerStates;

		private Dictionary<ulong, ServerStoredPlayerState> serverStoredPlayerStates;

		private Dictionary<ulong, Coroutine> waitForPlayerRoutines;

		private Dictionary<ulong, MopedRiderIK> riderIkCache;

		private Dictionary<ulong, MopedPassengerIK> passengerIkCache;

		public string UniqueMopedId => null;

		private bool hasDriver => false;

		private bool hasPassenger => false;

		private ulong driverClientId => 0uL;

		private ulong passengerClientIdValue => 0uL;

		public string SaveableId => null;

		public int SavePriority => 0;

		public static bool IsPlayerOnAnyMoped(ulong clientId)
		{
			return false;
		}

		public static MopedInteractable GetMopedContainingPlayer(ulong clientId)
		{
			return null;
		}

		public void ForcePlayerExitForRecovery(ulong clientId)
		{
		}

		public void SetUniqueId(string id)
		{
		}

		private void Awake()
		{
		}

		private void InitializeSeats()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void EmergencyRestoreLocalPlayerState()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnCameraPreCull(Camera cam)
		{
		}

		private void EnforceAllSeatTransforms()
		{
		}

		private void ProcessSeatLerps()
		{
		}

		private void StartEntrySeatLerp(int seatIndex, ulong clientId)
		{
		}

		private static Transform FindChildByName(Transform root, string name)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSyncSeatStateFromNetworkList_003Ed__57))]
		private IEnumerator SyncSeatStateFromNetworkList()
		{
			return null;
		}

		private void OnSeatOccupancyChanged(NetworkListEvent<ulong> changeEvent)
		{
		}

		private void CachePlayerObject(ulong clientId, int seatIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForPlayerObject_003Ed__60))]
		private IEnumerator WaitForPlayerObject(ulong clientId, int seatIndex)
		{
			return null;
		}

		private void ConfigureSeatIK(MopedSeat seat, GameObject playerObject, bool enable)
		{
		}

		private void EnsureSeatIKTargets(MopedSeat seat)
		{
		}

		private void OnClientDisconnected(ulong clientId)
		{
		}

		private void ForceExitSeat(ulong clientId, int seatIndex)
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

		private int FindAvailableSeat(bool forcePassenger = false)
		{
			return 0;
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

		private void HandleInteractionServer(ulong clientId)
		{
		}

		[IteratorStateMachine(typeof(_003CClearTransitionGuard_003Ed__76))]
		private IEnumerator ClearTransitionGuard(ulong clientId, float delay)
		{
			return null;
		}

		private void EnterSeatServer(ulong clientId, int seatIndex)
		{
		}

		private void ExitSeatServer(ulong clientId, int seatIndex)
		{
		}

		private void ExitDriverServer(ulong clientId, int seatIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedMopedOwnershipRemoval_003Ed__80))]
		private IEnumerator DelayedMopedOwnershipRemoval(ulong clientId, int seatIndex, Vector3 positionBeforeTransfer, Quaternion rotationBeforeTransfer)
		{
			return null;
		}

		private void ExitPassengerSeatServer(ulong clientId, int seatIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CExitPassengerSeatCoroutine_003Ed__82))]
		private IEnumerator ExitPassengerSeatCoroutine(ulong clientId, int seatIndex)
		{
			return null;
		}

		[ClientRpc]
		private void EnterSeatClientRpc(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId)
		{
		}

		[ClientRpc]
		private void ExitSeatClientRpc(ulong clientId, int seatIndex, Vector3 exitPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId)
		{
		}

		[IteratorStateMachine(typeof(_003CSafeSeatExitCoroutine_003Ed__85))]
		private IEnumerator SafeSeatExitCoroutine(GameObject playerObject, CharacterController characterController, Collider playerCollider, Collider[] mopedColliders, StoredPlayerState state, ulong clientId, bool wasDriver)
		{
			return null;
		}

		[ClientRpc]
		private void TogglePlayerRenderersClientRpc(NetworkObjectReference playerRef, bool visible)
		{
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

		private Transform ResolveParentTransform(ulong parentNetworkObjectId)
		{
			return null;
		}

		private void TeleportTransform(Transform targetTransform, Vector3 position, Quaternion rotation)
		{
		}

		private static void SetRenderersEnabled(GameObject target, bool visible)
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

		private void FlipMopedServer()
		{
		}

		[ClientRpc]
		private void FlipMopedClientRpc(Vector3 startPosition, Vector3 liftedPosition, Quaternion targetRotation, float duration)
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

		private void PerformTeleport(Vector3 position, Quaternion rotation)
		{
		}

		[IteratorStateMachine(typeof(_003CPerformTeleportCoroutine_003Ed__100))]
		private IEnumerator PerformTeleportCoroutine(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}

		private void DrawIKTargetGizmos()
		{
		}

		private void DrawHandGizmoAxes(Transform t, float length)
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

		[IteratorStateMachine(typeof(_003CReenablePhysicsAfterDelay_003Ed__112))]
		private IEnumerator ReenablePhysicsAfterDelay(Rigidbody rb, float delay)
		{
			return null;
		}

		[ClientRpc]
		private void TeleportMopedClientRpc(Vector3 position, Quaternion rotation)
		{
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

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3113506818(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4285782086(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2229081278(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2715542560(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2148736492(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3435193895(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1720748850(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
