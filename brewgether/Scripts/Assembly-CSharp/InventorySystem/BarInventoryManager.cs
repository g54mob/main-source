using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Data;
using Brewery.Items;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace InventorySystem
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class BarInventoryManager : NetworkBehaviour, ISaveable
	{
		public struct BarSaleResult
		{
			public bool Success;

			public string BeverageName;

			public BaseType BaseType;

			public BrewTag Tags;

			public float FinalPrice;

			public int SlotIndex;
		}

		private struct BeverageSaleCandidate
		{
			public int SlotIndex;

			public string Name;

			public BaseType BaseType;

			public BrewTag Tags;

			public float BaseValue;
		}

		[Serializable]
		private struct BarInventorySlotData
		{
			public int i;

			public string d;

			public int q;

			public string m;
		}

		[Serializable]
		private struct BarInventorySnapshot
		{
			public BarInventorySlotData[] s;
		}

		[Header("Bar Settings")]
		[SerializeField]
		private string barName;

		[SerializeField]
		private bool autoCalculateCapacity;

		[SerializeField]
		private int maxSlots;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Persistence")]
		[Tooltip("Unique ID for save/load. Auto-generated if empty. DO NOT change after first save!")]
		[SerializeField]
		private string uniqueBarId;

		private InventorySlot[] slots;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		private NetworkVariable<float> accumulatedMoney;

		public string BarName => null;

		public int MaxSlots => 0;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<int, InventorySlot> OnSlotChanged
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

		public event Action OnInventoryUpdated
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

		public event Action<int, FactionType, float> OnBeverageSold
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

		public event Action<float> OnMoneyChanged
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

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnAccumulatedMoneyChanged(float oldValue, float newValue)
		{
		}

		public InventorySlot GetSlot(int index)
		{
			return null;
		}

		public InventorySlot[] GetAllSlots()
		{
			return null;
		}

		public int GetTotalBottleCount()
		{
			return 0;
		}

		public int GetMaxAddable(Item item)
		{
			return 0;
		}

		public void RequestDepositFromPlayer(InventoryManager playerInventory, int playerSlotIndex, int quantity = 0)
		{
		}

		public void RequestWithdrawToPlayer(InventoryManager playerInventory, int barSlotIndex, int quantity = 0)
		{
		}

		public void RequestSellToFaction(int slotIndex, FactionType factionType)
		{
		}

		public void RequestInventorySync()
		{
		}

		public float GetAccumulatedMoney()
		{
			return 0f;
		}

		public void RequestCollectMoney()
		{
		}

		public void AddMoneyFromServing(float amount)
		{
		}

		public int ServerAddItems(Item item, int quantity)
		{
			return 0;
		}

		public void TriggerSlotChanged(int slotIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestSwapSlotsServerRpc(int fromSlot, int toSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestDepositToSlot(InventoryManager playerInventory, int playerSlotIndex, int targetBarSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositToSlotServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int targetBarSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestWithdrawToPlayerSlot(InventoryManager playerInventory, int barSlotIndex, int targetPlayerSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawToPlayerSlotServerRpc(NetworkObjectReference playerInventoryRef, int barSlotIndex, int targetPlayerSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private int CalculateShelfCapacity()
		{
			return 0;
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositItemServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawItemServerRpc(NetworkObjectReference playerInventoryRef, int barSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private bool TryGetBeverageCandidate(int slotIndex, out BeverageSaleCandidate candidate)
		{
			candidate = default(BeverageSaleCandidate);
			return false;
		}

		private FactionData LoadFactionData(FactionType factionType)
		{
			return null;
		}

		private void CompleteSale(BeverageSaleCandidate candidate, FactionType factionType, FactionData factionData, float finalPrice, ulong buyerClientId)
		{
		}

		public bool ServerTrySellBestToFaction(FactionData factionData, out BarSaleResult result)
		{
			result = default(BarSaleResult);
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestSellToFactionServerRpc(int slotIndex, FactionType factionType, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void ProcessPayment(ulong playerId, float amount)
		{
		}

		[ClientRpc]
		private void NotifySaleCompletedClientRpc(float amount)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestCollectMoneyServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyMoneyCollectedClientRpc(ulong collectorClientId, float amount)
		{
		}

		[ClientRpc]
		private void NotifyBeverageSoldClientRpc(int slotIndex, int factionTypeInt, float price, string beverageName)
		{
		}

		[ClientRpc]
		private void NotifyFactionRefusalClientRpc(FactionType factionType)
		{
		}

		private int AddItemInternal(Item item, int quantity, BeerDataSnapshot? incomingMetadata = null)
		{
			return 0;
		}

		private void RemoveItemInternal(int slotIndex, int quantity)
		{
		}

		private int CalculatePlayerCapacity(InventoryManager playerInventory, Item item)
		{
			return 0;
		}

		private void BroadcastInventorySnapshot()
		{
		}

		private FixedString4096Bytes SerializeInventory()
		{
			return default(FixedString4096Bytes);
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestInventorySyncServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void OnInventoryStateChanged(FixedString4096Bytes previous, FixedString4096Bytes current)
		{
		}

		private void ApplyInventorySnapshot(string snapshot)
		{
		}

		private void ClearAllSlots()
		{
		}

		[ClientRpc]
		private void SyncInventoryClientRpc(string snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private string FactionTypeToFileName(FactionType factionType)
		{
			return null;
		}

		private string GetStableBarId()
		{
			return null;
		}

		private string GetHierarchyPath(Transform t)
		{
			return null;
		}

		private int GetDeterministicHashCode(string str)
		{
			return 0;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private Dictionary<string, object> SerializeBeerDataSnapshot(BeerDataSnapshot snapshot)
		{
			return null;
		}

		private IDictionary<string, object> ConvertToDictionary(object obj)
		{
			return null;
		}

		private BeerDataSnapshot DeserializeBeerDataSnapshot(IDictionary<string, object> data)
		{
			return default(BeerDataSnapshot);
		}

		private void SyncAllMetadataToClients()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_4101709322(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2483504769(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1085542320(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1064731052(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2208267329(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2042161118(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3034488842(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3222642049(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1932275703(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3401822603(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_209086172(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3271446475(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3577490513(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
