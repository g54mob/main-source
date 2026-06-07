using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	[RequireComponent(typeof(NetworkObject))]
	public class CampStashInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Interaction Settings")]
		[SerializeField]
		private string interactionPrompt;

		[SerializeField]
		private string emptyPrompt;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("References")]
		[SerializeField]
		private ThiefCampManager campManager;

		[SerializeField]
		private CampLootDisplay lootDisplay;

		[Header("Visual Feedback")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		private bool isFocused;

		public ThiefCampManager CampManager => null;

		public bool HasLoot => false;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
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
		private void OpenStashUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void RefreshVisuals()
		{
		}

		private void OnDrawGizmos()
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

		private static void __rpc_handler_2211543495(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
