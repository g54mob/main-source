using InteractionSystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(NetworkObject))]
	public class BreweryHiringBoard : NetworkBehaviour, IInteractable
	{
		private const string TAG = "BREW_EMP|BOARD";

		[SerializeField]
		private BreweryEmployeeManager employeeManager;

		[SerializeField]
		private string boardName;

		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private Transform interactionPoint;

		[Header("Unlock Configuration")]
		[Tooltip("The locked trade ID that must be purchased to unlock this hiring board. Leave empty for no lock.")]
		[SerializeField]
		private string lockedTradeId;

		[Tooltip("Display name shown when locked (e.g., 'Big Barn'). If empty, tries to get from TradingManager.")]
		[SerializeField]
		private string lockedDisplayName;

		[Header("UI Display")]
		[Tooltip("Optional: Transform for world-space UI positioning. Leave null for default screen-space HUD.")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		public BreweryEmployeeManager EmployeeManager => null;

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
		private void OpenHiringUIClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void ShowLockedMessageClientRpc(ClientRpcParams clientRpcParams = default(ClientRpcParams))
		{
		}

		private bool IsUnlocked()
		{
			return false;
		}

		private string GetLockedDisplayName()
		{
			return null;
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

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2200125985(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_77757083(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
