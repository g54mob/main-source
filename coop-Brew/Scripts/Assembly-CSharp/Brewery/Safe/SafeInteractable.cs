using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Safe
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(SafeInventoryManager))]
	public class SafeInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Safe Settings")]
		[SerializeField]
		private string safeName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("References")]
		[SerializeField]
		private SafeInventoryManager safeInventory;

		[Header("Door Animation")]
		[Tooltip("The door transform to animate (pivot must be on the hinge)")]
		[SerializeField]
		private Transform safeDoor;

		[Tooltip("Local Y rotation when door is fully open")]
		[SerializeField]
		private float doorOpenAngle;

		[SerializeField]
		private float doorOpenDuration;

		[SerializeField]
		private float doorCloseDuration;

		[Tooltip("Seconds to keep door open after player stops interacting")]
		[SerializeField]
		private float doorCloseDelay;

		private readonly NetworkVariable<ulong> currentUserId;

		public const ulong NO_USER = ulong.MaxValue;

		private Vector3 doorClosedRotation;

		private Vector3 doorOpenRotation;

		private bool doorIsOpen;

		private int delayTweenId;

		private int animTweenId;

		public ulong SafeInventoryNetworkId => 0uL;

		public bool IsAvailable => false;

		public bool IsUserClient(ulong clientId)
		{
			return false;
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
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

		private void ClaimSafe(ulong clientId)
		{
		}

		private void ReleaseSafe(ulong clientId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ReleaseSafeServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void OnClientDisconnected(ulong clientId)
		{
		}

		public void RequestSafeAccess()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestSafeAccessServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void OpenSafeClientRpc(ulong safeInventoryNetworkObjectId, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void OnCurrentUserChanged(ulong previousValue, ulong newValue)
		{
		}

		private void AnimateDoorOpen()
		{
		}

		private void AnimateDoorClose()
		{
		}

		private void OpenDoorImmediate()
		{
		}

		private void CancelAllDoorTweens()
		{
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

		private static void __rpc_handler_2137184435(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3838969661(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1952347471(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
