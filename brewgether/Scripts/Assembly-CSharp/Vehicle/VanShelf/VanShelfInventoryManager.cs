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

namespace Vehicle.VanShelf
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(NetworkObject))]
	public class VanShelfInventoryManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct VanSlotData
		{
			public int i;

			public string d;

			public string n;

			public int q;

			public string bm;

			public string rm;

			public string cm;

			public string ci;
		}

		[Serializable]
		private struct VanInventorySnapshot
		{
			public VanSlotData[] s;
		}

		[CompilerGenerated]
		private sealed class _003CPerformTeleportCoroutine_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VanShelfInventoryManager _003C_003E4__this;

			public Vector3 position;

			public Quaternion rotation;

			private Rigidbody _003Crb_003E5__2;

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
			public _003CPerformTeleportCoroutine_003Ed__76(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CRetryInitialSnapshotLoad_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VanShelfInventoryManager _003C_003E4__this;

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
			public _003CRetryInitialSnapshotLoad_003Ed__24(int _003C_003E1__state)
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

		[Header("Van Shelf Settings")]
		[SerializeField]
		private VanShelfConfig config;

		[Header("Persistence")]
		[Tooltip("Unique ID for save/load. Auto-generated if empty. DO NOT change after first save!")]
		[SerializeField]
		private string uniqueVanShelfId;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private InventorySlot[] slots;

		private int totalSlotCount;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		public string VanName => null;

		public int TotalSlotCount => 0;

		public int ShelfCount => 0;

		public VanShelfConfig Config => null;

		public string UniqueVanShelfId => null;

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

		[IteratorStateMachine(typeof(_003CRetryInitialSnapshotLoad_003Ed__24))]
		private IEnumerator RetryInitialSnapshotLoad()
		{
			return null;
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

		public void RequestDepositToSlot(InventoryManager playerInventory, int playerSlotIndex, int targetVanSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestDepositToSlotServerRpc(NetworkObjectReference playerInventoryRef, int playerSlotIndex, int targetVanSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void RequestWithdrawToPlayerSlot(InventoryManager playerInventory, int vanSlotIndex, int targetPlayerSlot)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void RequestWithdrawToPlayerSlotServerRpc(NetworkObjectReference playerInventoryRef, int vanSlotIndex, int targetPlayerSlot, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public InventorySlot[] GetShelfSlots(int shelfIndex)
		{
			return null;
		}

		public int GetShelfIndexForSlot(int globalSlotIndex)
		{
			return 0;
		}

		public (int, int) GetShelfSlotRange(int shelfIndex)
		{
			return default((int, int));
		}

		public SingleShelfConfig GetShelfConfig(int shelfIndex)
		{
			return null;
		}

		public int GetMaxAddable(Item item)
		{
			return 0;
		}

		public void RequestDepositFromPlayer(InventoryManager playerInventory, int playerSlotIndex, int quantity = 0)
		{
		}

		public void RequestWithdrawToPlayer(InventoryManager playerInventory, int vanSlotIndex, int quantity = 0)
		{
		}

		public void RequestInventorySync()
		{
		}

		public bool IsEmpty()
		{
			return false;
		}

		public bool IsShelfEmpty(int shelfIndex)
		{
			return false;
		}

		[ClientRpc]
		private void NotifyInventoryFullClientRpc(string itemName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyVanShelfFullClientRpc(ClientRpcParams rpcParams = default(ClientRpcParams))
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
		private void RequestWithdrawItemServerRpc(NetworkObjectReference playerInventoryRef, int vanSlotIndex, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
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

		[ServerRpc(RequireOwnership = false)]
		public void RequestBottleFromVanBarrelServerRpc(int barrelSlotIndex, ulong playerInventoryId, int requestedBottleCount, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ClientRpc]
		private void SendBottlingResultClientRpc(ulong targetClientId, bool success, int bottlesFilled, int bottlesRemaining, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
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

		private string GetStableVanShelfId()
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

		private void RestoreVehiclePosition(Dictionary<string, object> state)
		{
		}

		[ClientRpc]
		private void TeleportVehicleClientRpc(Vector3 position, Quaternion rotation)
		{
		}

		private void PerformTeleportInternal(Vector3 position, Quaternion rotation)
		{
		}

		[IteratorStateMachine(typeof(_003CPerformTeleportCoroutine_003Ed__76))]
		private IEnumerator PerformTeleportCoroutine(Vector3 position, Quaternion rotation)
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

		private static void __rpc_handler_4126574643(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2855903517(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3739172295(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1449696039(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_156263347(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3496594119(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_638912272(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2153299499(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2703237122(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_790035502(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2527352474(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_966939198(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_774712951(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
