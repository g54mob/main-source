using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.NPC.TradingSystem;
using InteractionSystem;
using Property;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Environment
{
	public class SlidingFenceGate : NetworkBehaviour, IInteractable, ISaveable, IInteractionIKTarget
	{
		public enum DoorType
		{
			Slide = 0,
			Pivot = 1
		}

		public enum SlideDirection
		{
			Left = 0,
			Right = 1,
			Forward = 2,
			Back = 3
		}

		public enum PivotAxis
		{
			Y = 0,
			X = 1,
			Z = 2
		}

		public enum SoundType
		{
			Gate = 0,
			Door = 1,
			None = 2
		}

		public enum GateMode
		{
			Manual = 0,
			Automatic = 1,
			Both = 2
		}

		[Serializable]
		public class DoorConfig
		{
			[Tooltip("The transform of the door/gate mesh to move")]
			public Transform doorTransform;

			[Tooltip("Type of door movement")]
			public DoorType doorType;

			[Header("Slide Settings")]
			[Tooltip("Direction this door slides when opening (only used for Slide type)")]
			public SlideDirection slideDirection;

			[Header("Pivot Settings")]
			[Tooltip("Axis to rotate around (only used for Pivot type)")]
			public PivotAxis pivotAxis;

			[Tooltip("Angle to rotate when opening in degrees (positive = counter-clockwise, negative = clockwise)")]
			public float openAngle;

			[NonSerialized]
			public Vector3 closedPosition;

			[NonSerialized]
			public Vector3 openPosition;

			[NonSerialized]
			public Quaternion closedRotation;

			[NonSerialized]
			public Quaternion openRotation;

			[NonSerialized]
			public int currentTweenId;

			[NonSerialized]
			public bool isInitialized;
		}

		[CompilerGenerated]
		private sealed class _003CAutoCloseAfterDelay_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SlidingFenceGate _003C_003E4__this;

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
			public _003CAutoCloseAfterDelay_003Ed__81(int _003C_003E1__state)
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
		private sealed class _003CNpcAutoCloseAfterDelay_003Ed__84 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SlidingFenceGate _003C_003E4__this;

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
			public _003CNpcAutoCloseAfterDelay_003Ed__84(int _003C_003E1__state)
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
		private sealed class _003CThiefBreakInCoroutine_003Ed__87 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SlidingFenceGate _003C_003E4__this;

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
			public _003CThiefBreakInCoroutine_003Ed__87(int _003C_003E1__state)
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

		[Header("Doors")]
		[Tooltip("List of doors controlled by this trigger")]
		[SerializeField]
		private List<DoorConfig> doors;

		[Header("Unlock Configuration")]
		[Tooltip("The locked trade ID that must be purchased to unlock these doors")]
		[SerializeField]
		private string lockedTradeId;

		[Tooltip("Display name shown in UI when locked (e.g., 'Small Barn'). If empty, will try to get from TradingManager.")]
		[SerializeField]
		private string lockedDisplayName;

		[Header("Slide Settings")]
		[Tooltip("How far each door slides (in local units)")]
		[SerializeField]
		private float slideDistance;

		[Header("Interaction")]
		[Tooltip("Maximum distance at which the door can be interacted with")]
		[SerializeField]
		private float interactionDistance;

		[Tooltip("Interaction priority (higher = preferred when multiple interactables)")]
		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Animation")]
		[Tooltip("Duration of the open/close animation in seconds")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Easing type for opening (bouncy feels nice)")]
		[SerializeField]
		private LeanTweenType openEaseType;

		[Tooltip("Easing type for closing")]
		[SerializeField]
		private LeanTweenType closeEaseType;

		[Header("Audio")]
		[Tooltip("Type of sound to play (Gate = metallic, Door = wooden)")]
		[SerializeField]
		private SoundType soundType;

		[Header("Automatic Gate Settings")]
		[Tooltip("Gate behavior mode: Manual (E key), Automatic (proximity), or Both")]
		[SerializeField]
		private GateMode gateMode;

		[Tooltip("Layer mask for detecting players (for automatic mode)")]
		[SerializeField]
		private LayerMask playerLayerMask;

		[Tooltip("Cooldown between automatic open/close (prevents rapid toggling)")]
		[SerializeField]
		private float automaticCooldown;

		[Tooltip("Delay before closing after all players leave (automatic mode)")]
		[SerializeField]
		private float autoCloseDelay;

		[Header("Thief Break-In Settings")]
		[Tooltip("Allow thieves to break in through this gate")]
		[SerializeField]
		private bool allowThiefBreakIn;

		[Tooltip("Layer mask for detecting thieves")]
		[SerializeField]
		private LayerMask thiefLayerMask;

		[Tooltip("Time it takes for thief to break in / pick the lock (in seconds)")]
		[SerializeField]
		private float thiefBreakInDuration;

		[Header("NPC Auto-Open Settings")]
		[Tooltip("Enable automatic door opening for NPCs via proximity detection")]
		[SerializeField]
		private bool enableNpcAutoOpen;

		[Tooltip("Layer mask for detecting NPCs (usually 'Npc' layer)")]
		[SerializeField]
		private LayerMask npcDetectionLayerMask;

		[Tooltip("Delay before closing after all NPCs leave")]
		[SerializeField]
		private float npcAutoCloseDelay;

		[Header("IK Reach Animation")]
		[Tooltip("Enable hand IK reach animation when interacting")]
		[SerializeField]
		private bool enableIKReach;

		[Tooltip("Duration of the reach animation in seconds")]
		[SerializeField]
		private float ikReachDuration;

		[Header("Debug")]
		[Tooltip("Force the doors to be unlocked (bypasses trade check)")]
		[SerializeField]
		private bool forceUnlock;

		[SerializeField]
		private bool showDebugLogs;

		private NetworkVariable<bool> isOpen;

		private bool _networkSpawnCalled;

		private bool _localDoorOpen;

		private HashSet<Collider> playersInTrigger;

		private float lastAutomaticToggleTime;

		private Coroutine autoCloseCoroutine;

		private HashSet<Collider> thievesAtGate;

		private Coroutine thiefBreakInCoroutine;

		private bool isDirectBreakInActive;

		private bool _npcNearby;

		private Coroutine npcAutoCloseCoroutine;

		private float _lastNpcCheckTime;

		private const float NpcCheckInterval = 0.25f;

		private const float NpcDetectionRadius = 1f;

		private static readonly Collider[] _npcOverlapBuffer;

		private bool IsServerSafe => false;

		public bool IsDoorsOpen => false;

		public bool IsDoorsUnlocked => false;

		public bool IsGateClosed => false;

		public bool IsBreakInProgress => false;

		public float BreakInDuration => 0f;

		public bool IsBreakInAllowed => false;

		public float IKReachDuration => 0f;

		public bool EnableIKReach => false;

		public string SaveableId => null;

		public int SavePriority => 0;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void CheckNpcProximity()
		{
		}

		private void EnsureTriggerRigidbody()
		{
		}

		private void InitializeDoors()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnOpenStateChanged(bool previousValue, bool newValue)
		{
		}

		private void ToggleDoor()
		{
		}

		private int GetGateIndex(PlotBuildingController controller)
		{
			return 0;
		}

		public void ApplyDoorState(bool open)
		{
		}

		private void AnimateAllDoors(bool opening)
		{
		}

		private void AnimateDoor(DoorConfig door, bool opening)
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

		[ClientRpc]
		private void ShowLockedMessageClientRpc(ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		private bool IsUnlocked()
		{
			return false;
		}

		public void ForceOpen()
		{
		}

		public void ForceClose()
		{
		}

		private void PlaySound(bool opening)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		[IteratorStateMachine(typeof(_003CAutoCloseAfterDelay_003Ed__81))]
		private IEnumerator AutoCloseAfterDelay()
		{
			return null;
		}

		private bool IsPlayerLayer(int layer)
		{
			return false;
		}

		private bool IsThiefLayer(int layer)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CNpcAutoCloseAfterDelay_003Ed__84))]
		private IEnumerator NpcAutoCloseAfterDelay()
		{
			return null;
		}

		private void HandleThiefEnter(Collider thiefCollider)
		{
		}

		private void HandleThiefExit(Collider thiefCollider)
		{
		}

		[IteratorStateMachine(typeof(_003CThiefBreakInCoroutine_003Ed__87))]
		private IEnumerator ThiefBreakInCoroutine()
		{
			return null;
		}

		private void NotifyThievesGateOpened()
		{
		}

		public bool TryThiefBreakIn()
		{
			return false;
		}

		private void ShowLockedMessage()
		{
		}

		private string GetLockedDisplayName()
		{
			return null;
		}

		private IEnumerable<TradingProfile> GetAllProfiles(TradingManager manager)
		{
			return null;
		}

		private string FormatTradeIdAsName(string tradeId)
		{
			return null;
		}

		[ClientRpc]
		private void TriggerInteractionIKClientRpc(ulong interactingClientId, ulong targetNetworkObjectId, float duration)
		{
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3944007922(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1623800838(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
