using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Shelf
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(ShelfInventoryManager))]
	public class ShelfInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Shelf Settings")]
		[SerializeField]
		private string shelfName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("References")]
		[SerializeField]
		private ShelfInventoryManager shelfInventory;

		private readonly NetworkVariable<ulong> currentUserId;

		public const ulong NO_USER = ulong.MaxValue;

		public ulong ShelfInventoryNetworkId => 0uL;

		public bool IsAvailable => false;

		public bool IsUserClient(ulong clientId)
		{
			return false;
		}

		private void Awake()
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

		private void ClaimShelf(ulong clientId)
		{
		}

		private void ReleaseShelf(ulong clientId)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ReleaseShelfServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestShelfInventoryAccess()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestShelfInventoryAccessServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void OpenShelfInventoryClientRpc(ulong shelfInventoryNetworkObjectId, ClientRpcParams rpcParams = default(ClientRpcParams))
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

		private static void __rpc_handler_3813407938(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2471158249(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1783536581(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
