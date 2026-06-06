using InteractionSystem;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar
{
	[RequireComponent(typeof(NetworkObject))]
	[RequireComponent(typeof(BarInventoryManager))]
	public class BarInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Bar Settings")]
		[SerializeField]
		private string barName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("References")]
		[SerializeField]
		private BarInventoryManager barInventory;

		private BarServingManager servingManager;

		public ulong BarInventoryNetworkId => 0uL;

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

		public void RequestBarInventoryAccess()
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

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
