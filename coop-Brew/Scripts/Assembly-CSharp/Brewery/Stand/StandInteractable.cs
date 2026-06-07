using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[RequireComponent(typeof(NetworkObject))]
	public class StandInteractable : NetworkBehaviour, IInteractable
	{
		[Header("Settings")]
		[SerializeField]
		private string standName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("References")]
		[SerializeField]
		private StandInventoryManager inventoryManager;

		private const int IgnoreRaycastLayer = 2;

		public StandInventoryManager InventoryManager => null;

		private void Awake()
		{
		}

		private void SetupColliderLayers()
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

		public void RequestStandInventoryAccess()
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
