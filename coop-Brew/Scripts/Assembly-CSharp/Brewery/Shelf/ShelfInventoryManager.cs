using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Items;
using Brewery.Systems;
using InventorySystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Shelf
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class ShelfInventoryManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct ShelfInventorySlotData
		{
			public string id;

			public string name;

			public int quantity;

			public string beverageMetadataJson;

			public string barrelMetadataJson;

			public string crateMetadataJson;
		}

		[Serializable]
		private struct ShelfInventorySnapshot
		{
			public ShelfInventorySlotData[] slots;
		}

		[CompilerGenerated]
		private sealed class _003CRetryInitialSnapshotLoad_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ShelfInventoryManager _003C_003E4__this;

			private float _003CmaxWait_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CRetryInitialSnapshotLoad_003Ed__34(int _003C_003E1__state)
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

		[Header("Shelf Settings")]
		[SerializeField]
		private ShelfConfig config;

		[SerializeField]
		private string shelfName;

		[Header("Persistence")]
		[Tooltip("Unique ID for save/load. Auto-generated if empty. DO NOT change after first save!")]
		[SerializeField]
		private string uniqueShelfId;

		[Header("Initial Items (Pre-placed)")]
		[Tooltip("Items to place on shelf when game starts. Respects stacking rules.")]
		[SerializeField]
		private List<InitialShelfItem> initialItems;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private InventorySlot[] slots;

		private int slotCount;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		private NetworkVariable<bool> isOutputShelf;

		private NetworkVariable<bool> isIgnoredByAI;

		public string UniqueShelfId => null;

		public bool IsOutputShelf => false;

		public bool IsIgnoredByAI => false;

		public string ShelfName => null;

		public int SlotCount => 0;

		public string SaveableId => null;

		public int SavePriority => 0;

		public event Action<bool> OnOutputShelfChanged
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

		public event Action<bool> OnIgnoredByAIChanged
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

		[IteratorStateMachine(typeof(_003CRetryInitialSnapshotLoad_003Ed__34))]
		private IEnumerator RetryInitialSnapshotLoad()
		{
			return null;
		}

		public override void OnNetworkDespawn()
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ToggleOutputShelfServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ToggleIgnoredByAIServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
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

		public int GetItemCount(Item item)
		{
			return 0;
		}

		public int TryRemoveItemByType(Item item, int quantity)
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

		public void RequestWithdrawToPlayer(InventoryManager playerInventory, int shelfSlotIndex, int quantity = 0)
		{
		}

		public void RequestInventorySync()
		{
		}

		public ShelfConfig GetShelfConfig()
		{
			return null;
		}

		public bool IsEmpty()
		{
			return false;
		}

		[ClientRpc]
		private void NotifyInventoryFullClientRpc(string itemName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyShelfFullClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public void RequestDepositToSlot(InventoryManager playerInventory, int playerSlotIndex, int targetShelfSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositToSlotServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int targetShelfSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestWithdrawToPlayerSlot(InventoryManager playerInventory, int shelfSlotIndex, int targetPlayerSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawToPlayerSlotServerRpc(NetworkObjectReference playerInventoryRef, int shelfSlotIndex, int targetPlayerSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositItemServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawItemServerRpc(NetworkObjectReference playerInventoryRef, int shelfSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private void InitializeShelfItems()
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

		public bool HasBarrelsReadyForBottling(BeverageType beverageType, out List<int> barrelSlots)
		{
			barrelSlots = null;
			return false;
		}

		public bool TryGetBarrelMetadataForSlot(int slotIndex, out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return false;
		}

		public bool HasAnyBarrelsReadyForBottling()
		{
			return false;
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestBottleFromShelfBarrelServerRpc(int barrelSlotIndex, ulong playerInventoryId, int requestedBottleCount, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void SendBottlingResultClientRpc(ulong targetClientId, bool success, int bottlesFilled, int bottlesRemaining, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public int GetEmptyBarrelCount()
		{
			return 0;
		}

		public int TryRemoveEmptyBarrel()
		{
			return 0;
		}

		public int GetUnfermentedWineBarrelCount()
		{
			return 0;
		}

		public int TryRemoveUnfermentedWineBarrel(out BarrelMetadata metadata)
		{
			metadata = default(BarrelMetadata);
			return 0;
		}

		public int ServerAddItem(Item item, int quantity)
		{
			return 0;
		}

		public int ServerAddItemWithBeverageMetadata(Item item, int quantity, BeerDataSnapshot beerMetadata)
		{
			return 0;
		}

		public int ServerAddItemWithBarrelMetadata(Item item, int quantity, BarrelMetadata barrelMeta)
		{
			return 0;
		}

		public bool BottleOneZoneWide(int barrelSlotIndex, IReadOnlyList<ShelfInventoryManager> allShelves)
		{
			return false;
		}

		public bool IsBarrelReadyForBottling(int barrelSlotIndex)
		{
			return false;
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

		private string GetStableShelfId()
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

		private void SyncAllCrateMetadataToClients()
		{
		}

		private Dictionary<string, object> SerializeBeerDataSnapshot(BeerDataSnapshot snapshot)
		{
			return null;
		}

		private BeerDataSnapshot DeserializeBeerDataSnapshot(IDictionary<string, object> data)
		{
			return default(BeerDataSnapshot);
		}

		private Dictionary<string, object> SerializeBarrelMetadata(BarrelMetadata barrel)
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

		private void GenerateRuntimeUniqueId()
		{
		}

		private void EnsureUniqueId()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2642818316(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3897009033(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1578105449(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_4123857120(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3079316738(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2191076017(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_757576624(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2668553196(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2585403293(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3863261774(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2795131065(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1975679777(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1971430660(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
