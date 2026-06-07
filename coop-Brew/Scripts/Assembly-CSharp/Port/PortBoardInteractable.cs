using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Port
{
	[RequireComponent(typeof(NetworkObject))]
	public class PortBoardInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Interaction")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI")]
		[Tooltip("Optional: Transform for world-space UI positioning")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private void Awake()
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

		[ClientRpc]
		private void OpenPortBoardUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
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

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		public void OnInteractionFocus()
		{
		}

		public void OnInteractionLoseFocus()
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

		private static void __rpc_handler_2772308487(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
