using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using InventorySystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Stand
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class StandInventoryManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct StandInventorySlotData
		{
			public int i;

			public string d;

			public int q;
		}

		[Serializable]
		private struct StandInventorySnapshot
		{
			public StandInventorySlotData[] s;
		}

		[Header("Stand Settings")]
		[SerializeField]
		private bool autoCalculateCapacity;

		[SerializeField]
		private int maxSlots;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		[Header("Persistence")]
		[SerializeField]
		private string uniqueStandId;

		private InventorySlot[] slots;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		private NetworkVariable<float> accumulatedMoney;

		public int MaxSlots => 0;

		public float CollectedMoney => 0f;

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

		public bool IsAcceptableItem(Item item)
		{
			return false;
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

		public void AddMoneyFromServing(float amount)
		{
		}

		public float GetAccumulatedMoney()
		{
			return 0f;
		}

		public void DeductMoney(float amount)
		{
		}

		public void RequestInventorySync()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestInventorySyncServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestCollectMoney()
		{
		}

		public void TriggerSlotChanged(int slotIndex)
		{
		}

		public void ServerRemoveFromSlot(int slotIndex, int quantity = 1)
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

		[ServerRpc(RequireOwnership = false)]
		private void RequestCollectMoneyServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void PlayBottleClinkClientRpc(Vector3 position)
		{
		}

		[ClientRpc]
		private void NotifyMoneyCollectedClientRpc(ulong collectorClientId, float amount)
		{
		}

		private int AddItemInternal(Item item, int quantity)
		{
			return 0;
		}

		private void RemoveItemInternal(int slotIndex, int quantity)
		{
		}

		private void BroadcastInventorySnapshot()
		{
		}

		private FixedString4096Bytes SerializeInventory()
		{
			return default(FixedString4096Bytes);
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

		private string GetStableStandId()
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

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2467312074(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3710560293(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_920080103(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1178733642(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3597656099(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1883952637(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2190850166(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
