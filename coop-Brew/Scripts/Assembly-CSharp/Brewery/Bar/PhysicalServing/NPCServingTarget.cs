using System.Collections.Generic;
using Brewery.Items;
using Brewery.NPC.Simple;
using Brewery.Stand;
using InteractionSystem;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Bar.PhysicalServing
{
	[RequireComponent(typeof(SimpleNPCController))]
	public class NPCServingTarget : NetworkBehaviour, IInteractable
	{
		[Header("References")]
		[SerializeField]
		private SimpleNPCController npcController;

		[SerializeField]
		private NPCDrinkRequestPanel requestPanel;

		[Header("Configuration")]
		[Tooltip("If true, uses PhysicalServingConfig for all settings. If false, uses local values below.")]
		[SerializeField]
		private bool useGlobalConfig;

		[Header("Local Overrides (only used if useGlobalConfig = false)")]
		[SerializeField]
		private float interactionDistance;

		[SerializeField]
		private int interactionPriority;

		[Header("UI Display")]
		[Tooltip("Transform for world-space UI positioning (head/above NPC)")]
		[SerializeField]
		private Transform worldSpaceUIAnchor;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private ulong npcNetworkId;

		private bool isAtBar;

		private bool isWaitingForDrink;

		private DrinkPoolEntry currentRequest;

		private ulong lastCheckedClientId;

		private bool lastHadCorrectDrink;

		private DrinkPoolEntry lastPlayerDrink;

		private NPCStandServingTarget cachedStandTarget;

		private float InteractionDistanceValue => 0f;

		private int InteractionPriorityValue => 0;

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void Update()
		{
		}

		private void HandleAssignmentsChanged(Dictionary<ulong, DrinkPoolEntry> assignments)
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

		private bool CanShowInteraction()
		{
			return false;
		}

		private void CheckPlayerHasDrink(ulong clientId)
		{
		}

		private InventoryManager GetPlayerInventory(ulong clientId)
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false)]
		private void ServeNPCServerRpc(ulong clientId, int playerSlotIndex, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void CompleteTransaction(ulong clientId, DrinkPoolEntry drink, float price)
		{
		}

		private void HandleWrongDrink(ulong clientId, DrinkPoolEntry offeredDrink, BeverageItem beverage)
		{
		}

		[ClientRpc]
		private void NotifyTransactionCompleteClientRpc(string drinkName, float price, ulong targetClientId)
		{
		}

		[ClientRpc]
		private void NotifyWrongDrinkClientRpc(string offeredDrink, string wantedDrink, ulong targetClientId)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3201071011(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3133617484(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2242117760(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
