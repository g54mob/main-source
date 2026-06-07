using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Items;
using Brewery.Systems;
using InteractionSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace InventorySystem
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class VehicleInventoryManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct VehicleInventorySlotData
		{
			public string id;

			public string name;

			public int quantity;

			public string beverageMetadataJson;

			public string barrelMetadataJson;

			public string crateMetadataJson;

			public string crateItemMetadataJson;
		}

		[Serializable]
		private struct VehicleInventorySnapshot
		{
			public VehicleInventorySlotData[] slots;
		}

		[CompilerGenerated]
		private sealed class _003CReenablePhysicsAfterDelay_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public Rigidbody rb;

			public VehicleInventoryManager _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CReenablePhysicsAfterDelay_003Ed__89(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Inventory Settings")]
		[SerializeField]
		private string inventoryName;

		[SerializeField]
		private int rows;

		[SerializeField]
		private int columns;

		[Header("Grid Storage System")]
		[Tooltip("Enable grid-based storage for items with footprints (barrels, crates)")]
		[SerializeField]
		private bool useGridSystem;

		[SerializeField]
		private int gridRows;

		[SerializeField]
		private int gridColumns;

		[SerializeField]
		private Vector3 gridCellSize;

		[SerializeField]
		private Vector3 gridStartOffset;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VehicleInteractable _vehicleInteractable;

		private InventorySlot[] slots;

		private int slotCount;

		private VehicleGridCell[] gridCells;

		private int gridCellCount;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		public string InventoryDisplayName => null;

		public int Rows => 0;

		public int Columns => 0;

		public int SlotCount => 0;

		public bool UseGridSystem => false;

		public int GridRows => 0;

		public int GridColumns => 0;

		public Vector3 GridCellSize => default(Vector3);

		public Vector3 GridStartOffset => default(Vector3);

		public VehicleGridCell[] GridCells => null;

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

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		private void EnsureVehicleHasUniqueId()
		{
		}

		public override void OnNetworkDespawn()
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

		public void TriggerSlotChanged(int slotIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestSwapSlotsServerRpc(int fromSlot, int toSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestWithdrawToPlayerSlot(InventoryManager playerInventory, int vehicleSlotIndex, int targetPlayerSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawToPlayerSlotServerRpc(NetworkObjectReference playerInventoryRef, int vehicleSlotIndex, int targetPlayerSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public int GetMaxAddable(Item item)
		{
			return 0;
		}

		public void RequestDepositFromPlayer(InventoryManager playerInventory, int playerSlotIndex, int quantity = 0)
		{
		}

		public void RequestWithdrawToPlayer(InventoryManager playerInventory, int vehicleSlotIndex, int quantity = 0)
		{
		}

		public void RequestInventorySync()
		{
		}

		[ClientRpc]
		private void NotifyInventoryFullClientRpc(string itemName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyVehicleFullClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyItemNotAllowedClientRpc(string itemName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositItemServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawItemServerRpc(NetworkObjectReference playerInventoryRef, int vehicleSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private int AddItemInternal(Item item, int quantity)
		{
			return 0;
		}

		private int AddItemWithGridValidation(Item item, int quantity)
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

		private void ParseAndApplyCrateItemMetadata(InventorySlot slot, string crateItemMetadataJson)
		{
		}

		private void ClearAllSlots()
		{
		}

		[ClientRpc]
		private void SyncInventoryClientRpc(string snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		private void InitializeGridSystem()
		{
		}

		public int FindGridPlacementPosition(VehicleFootprint footprint)
		{
			return 0;
		}

		public bool CanPlaceItemAtGridPosition(int anchorRow, int anchorCol, VehicleFootprint footprint)
		{
			return false;
		}

		public bool PlaceItemInGrid(int anchorCellIndex, Item item)
		{
			return false;
		}

		public void RemoveItemFromGrid(int anchorCellIndex)
		{
		}

		public Vector3 GetGridCellWorldPosition(int cellIndex)
		{
			return default(Vector3);
		}

		public VehicleGridCell GetGridCell(int row, int col)
		{
			return null;
		}

		private string GetStableVehicleId()
		{
			return null;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		[ClientRpc]
		private void TeleportVehicleClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		[IteratorStateMachine(typeof(_003CReenablePhysicsAfterDelay_003Ed__89))]
		private IEnumerator ReenablePhysicsAfterDelay(Rigidbody rb, float delay)
		{
			return null;
		}

		private IDictionary<string, object> ConvertToDictionary(object obj)
		{
			return null;
		}

		private Dictionary<string, object> SerializeBeerDataSnapshot(BeerDataSnapshot snapshot)
		{
			return null;
		}

		private BeerDataSnapshot DeserializeBeerDataSnapshot(IDictionary<string, object> data)
		{
			return default(BeerDataSnapshot);
		}

		private Dictionary<string, object> SerializeBarrelMetadata(BarrelMetadata meta)
		{
			return null;
		}

		private BarrelMetadata DeserializeBarrelMetadata(IDictionary<string, object> data)
		{
			return default(BarrelMetadata);
		}

		private Dictionary<string, object> SerializeCrateMetadata(CrateMetadata crate)
		{
			return null;
		}

		private CrateMetadata DeserializeCrateMetadata(IDictionary<string, object> data)
		{
			return default(CrateMetadata);
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_3864761720(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_903510590(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1224571915(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_719335681(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3195223407(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2233433919(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1554097641(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2748121425(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2605021318(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_147384430(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
