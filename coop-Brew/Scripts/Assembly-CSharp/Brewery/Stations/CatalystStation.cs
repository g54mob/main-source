using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Core;
using Brewery.Data;
using Brewery.Items;
using InteractionSystem;
using InventorySystem;
using PlacementSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stations
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class CatalystStation : NetworkBehaviour, IInteractable
	{
		private struct PendingCatalyzation
		{
			public ulong clientId;

			public InventoryManager inventory;

			public int beverageSlotIndex;

			public BeverageItem beverageItem;

			public BaseType baseType;

			public List<string> catalystIds;

			public List<Item> catalystItems;

			public List<int> catalystSlots;

			public int quantity;
		}

		[Header("Station Settings")]
		[SerializeField]
		private string stationName;

		[SerializeField]
		private float interactionDistance;

		[Header("Processing")]
		[SerializeField]
		private float processingTimeSeconds;

		[SerializeField]
		private int maxBatchSize;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly NetworkVariable<CatalystStationState> stationState;

		private readonly NetworkVariable<float> processingProgress;

		private readonly NetworkVariable<ulong> currentUserClientId;

		private readonly NetworkVariable<int> batchTotalCount;

		private readonly NetworkVariable<int> batchCompletedCount;

		private readonly NetworkVariable<double> currentItemStartTime;

		private PendingCatalyzation pendingCatalyzation;

		private PlacedObject placedObject;

		public CatalystStationState State => default(CatalystStationState);

		public float Progress => 0f;

		public bool IsInUse => false;

		public ulong CurrentUserClientId => 0uL;

		public float ProcessingTime => 0f;

		public int MaxBatchSize => 0;

		public int BatchTotalCount => 0;

		public int BatchCompletedCount => 0;

		public double CurrentItemStartTime => 0.0;

		public event Action<CatalystStation> OnStationStateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CatalystStation, float> OnProcessingProgressChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<CatalystStation, CatalystBrewRecord, bool> OnCatalyzationComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
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

		private void HandleStateChanged(CatalystStationState previous, CatalystStationState current)
		{
		}

		private void HandleProgressChanged(float previous, float current)
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

		public bool ShouldRemainFocused(ulong clientId)
		{
			return false;
		}

		public Transform GetWorldSpaceUIAnchor()
		{
			return null;
		}

		[Rpc(SendTo.Server)]
		public void RequestCatalyzeRpc(int beverageSlotIndex, BaseType baseType, FixedString32Bytes catalyst1Id, FixedString32Bytes catalyst2Id, FixedString32Bytes catalyst3Id, int quantity, RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Server)]
		public void RequestCloseRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		[Rpc(SendTo.Server)]
		public void RequestCancelProcessingRpc(RpcParams rpcParams = default(RpcParams))
		{
		}

		[ClientRpc]
		private void OpenDashboardClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendProcessingStartedClientRpc(int quantity, float duration, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendCatalyzeResultClientRpc(bool success, FixedString128Bytes message, CatalystBrewRecord record, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendNewDiscoveryClientRpc(CatalystBrewRecord record, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendItemCompletedClientRpc(int completed, int total, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void CompleteOneItem()
		{
		}

		private void CompleteBatchProcessing()
		{
		}

		private string GenerateRecipeId(CatalystBrewRecord record)
		{
			return null;
		}

		private int CountCatalystsInRecord(CatalystBrewRecord record)
		{
			return 0;
		}

		private List<string> ExtractTagNames(BrewTag tags)
		{
			return null;
		}

		private void FinishProcessing(bool success, string message, CatalystBrewRecord record, ulong clientId)
		{
		}

		private int FindItemSlot(InventorySlot[] slots, Item item, int requiredQuantity)
		{
			return 0;
		}

		private ClientRpcParams GetTargetRpcParams(ulong clientId)
		{
			return default(ClientRpcParams);
		}

		private void Log(string message)
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3832587128(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2145433062(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_486775691(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_915611812(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_255264880(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2142949619(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2908437494(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_632544664(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
