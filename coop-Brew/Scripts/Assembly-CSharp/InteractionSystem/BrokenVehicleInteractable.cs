using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace InteractionSystem
{
	[RequireComponent(typeof(NetworkObject))]
	public class BrokenVehicleInteractable : NetworkBehaviour, IInteractable
	{
		[Serializable]
		public class VehicleSeat
		{
			public Transform seatPosition;

			public string seatName;

			[HideInInspector]
			public ulong occupantId;

			[HideInInspector]
			public GameObject occupantPlayer;

			public bool IsOccupied => false;
		}

		private class StoredPlayerState
		{
			public Vector3 originalPosition;

			public Quaternion originalRotation;

			public Transform originalParent;

			public bool[] componentStates;

			public MonoBehaviour[] components;
		}

		private class ServerStoredPlayerState
		{
			public Transform originalParent;

			public Vector3 originalPosition;

			public Quaternion originalRotation;
		}

		[CompilerGenerated]
		private sealed class _003CSyncInitialSeatStates_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BrokenVehicleInteractable _003C_003E4__this;

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
			public _003CSyncInitialSeatStates_003Ed__20(int _003C_003E1__state)
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

		[Header("Vehicle Settings")]
		[SerializeField]
		private string vehicleName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Seat Configuration")]
		[SerializeField]
		private List<VehicleSeat> seats;

		[Header("Audio (Optional)")]
		[Tooltip("Play door sounds when entering/exiting")]
		[SerializeField]
		private bool playDoorSounds;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NetworkList<ulong> seatOccupants;

		private Dictionary<ulong, int> playerSeatIndex;

		private Dictionary<ulong, StoredPlayerState> storedPlayerStates;

		private readonly Dictionary<ulong, ServerStoredPlayerState> serverStoredPlayerStates;

		private bool isSubscribedToInputReader;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSyncInitialSeatStates_003Ed__20))]
		private IEnumerator SyncInitialSeatStates()
		{
			return null;
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

		private void EnforceAllSeatedPlayersPosition()
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

		private bool IsLocalPlayerInThisVehicle()
		{
			return false;
		}

		private bool IsLocalPlayerParentedToVehicle()
		{
			return false;
		}

		private bool IsClientOccupying(ulong clientId)
		{
			return false;
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

		private void EnterVehicleServer(ulong clientId, int seatIndex)
		{
		}

		private void ExitVehicleServer(ulong clientId, int seatIndex)
		{
		}

		[ClientRpc]
		private void EnterVehicleClientRpc(ulong clientId, int seatIndex, Vector3 originalPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId)
		{
		}

		[ClientRpc]
		private void ExitVehicleClientRpc(ulong clientId, Vector3 exitPosition, Quaternion originalRotation, ulong originalParentNetworkObjectId)
		{
		}

		[Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
		private void RequestExitVehicleRpc(RpcParams rpcParams = default(RpcParams))
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

		private Vector3 FindSafeExitPosition()
		{
			return default(Vector3);
		}

		public bool IsAnyoneInVehicle()
		{
			return false;
		}

		private void OnDrawGizmosSelected()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2149078203(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3113385796(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_156928343(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_613989837(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
