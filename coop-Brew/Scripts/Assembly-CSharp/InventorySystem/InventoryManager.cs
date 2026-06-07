using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Brewery.Core;
using Brewery.Items;
using Brewery.Systems;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
	public class InventoryManager : NetworkBehaviour, ISaveable
	{
		[Serializable]
		private struct InventorySlotData
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
		private struct InventorySnapshotData
		{
			public InventorySlotData[] slots;
		}

		[CompilerGenerated]
		private sealed class _003CHideMessageAfterDelay_003Ed__83 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

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
			public _003CHideMessageAfterDelay_003Ed__83(int _003C_003E1__state)
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

		[Header("Input")]
		[SerializeField]
		private InputReader inputReader;

		[Header("Inventory Settings")]
		[SerializeField]
		private int inventorySize;

		[SerializeField]
		private float dropForce;

		[SerializeField]
		private Transform dropPoint;

		[Header("Drop Safety")]
		[Tooltip("How far in front of the player to attempt dropping")]
		[SerializeField]
		private float dropDistance;

		[Tooltip("Raycast layers that block drops (walls, objects). Exclude Player layer.")]
		[SerializeField]
		private LayerMask dropBlockingLayers;

		[Header("Backpack Settings")]
		[SerializeField]
		private int baseInventorySize;

		[SerializeField]
		private int expandedInventorySize;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private InventorySlot[] inventory;

		private int selectedSlotIndex;

		private NetworkVariable<FixedString4096Bytes> inventoryState;

		private bool isBackpackEquipped;

		private BackpackItem equippedBackpack;

		private int backpackSourceSlotIndex;

		private bool isItemEquipped;

		private bool suppressEquipChanges;

		private bool isItemActivelySelected;

		public bool IsBackpackEquipped => false;

		public BackpackItem EquippedBackpack => null;

		public int BaseInventorySize => 0;

		public int ExpandedInventorySize => 0;

		public bool IsItemEquipped => false;

		public bool IsEquipChangeSuppressed => false;

		public bool IsItemActivelySelected => false;

		public string SaveableId => null;

		public event Action<int, InventorySlot> OnInventorySlotChanged
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

		public event Action<int> OnSelectedSlotChanged
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

		public event Action OnInventoryRestoreComplete
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

		public event Action<bool> OnItemSelectionChanged
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

		public event Action<bool> OnItemEquippedStateChanged
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

		public event Action<bool> OnBackpackStateChanged
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

		public event Action<int> OnInventorySizeChanged
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

		public void NotifyInventoryRestoreComplete()
		{
		}

		public void SetItemActivelySelected(bool selected)
		{
		}

		public void ToggleItemEquipped()
		{
		}

		public void SetItemEquipped(bool equipped, bool force = false)
		{
		}

		public void SetSuppressEquipChanges(bool suppress)
		{
		}

		private void Awake()
		{
		}

		public override void OnNetworkSpawn()
		{
		}

		public bool CanAddItem(Item item, int quantity = 1)
		{
			return false;
		}

		public int CalculateMaxAddable(Item item, int desiredQuantity)
		{
			return 0;
		}

		public int TryAddItemPartial(Item item, int desiredQuantity, bool triggerQuestEvent = true)
		{
			return 0;
		}

		public bool TryAddItem(Item item, int quantity = 1, bool triggerQuestEvent = true)
		{
			return false;
		}

		public void AddItemOrDrop(Item item, int quantity, bool triggerQuestEvent = true)
		{
		}

		public void SpawnItemAtFeet(Item item, int quantity)
		{
		}

		public bool TryAddItemWithMetadata(Item item, int quantity, BeerDataSnapshot snapshot, out int outSlotIndex)
		{
			outSlotIndex = default(int);
			return false;
		}

		public bool TryAddItemWithBarrelMetadata(Item item, int quantity, BarrelMetadata barrelMetadata, out int outSlotIndex)
		{
			outSlotIndex = default(int);
			return false;
		}

		public bool TryAddItemWithCrateMetadata(Item item, int quantity, CrateMetadata crateMetadata, out int outSlotIndex)
		{
			outSlotIndex = default(int);
			return false;
		}

		public bool TryAddItemWithGarbageMetadata(Item item, int quantity, GarbageMetadata garbageMetadata, out int outSlotIndex)
		{
			outSlotIndex = default(int);
			return false;
		}

		public void NotifySlotChanged(int slotIndex)
		{
		}

		public bool SetSlotBarrelMetadata(int slotIndex, BarrelMetadata metadata)
		{
			return false;
		}

		private bool CatalystsMatch(BeerDataSnapshot a, BeerDataSnapshot b)
		{
			return false;
		}

		public bool RemoveItem(int slotIndex, int quantity = 1)
		{
			return false;
		}

		public void UseItem(int slotIndex)
		{
		}

		public void DropItem(int slotIndex)
		{
		}

		private Vector3 CalculateSafeDropPosition(Transform origin)
		{
			return default(Vector3);
		}

		private bool IsDropPositionValid(Vector3 candidate, Vector3 bodyPos, float sphereRadius, float groundCheckDistance, out Vector3 groundPoint)
		{
			groundPoint = default(Vector3);
			return false;
		}

		[IteratorStateMachine(typeof(_003CHideMessageAfterDelay_003Ed__83))]
		private IEnumerator HideMessageAfterDelay(float delay)
		{
			return null;
		}

		[ServerRpc]
		private void RequestDropItemServerRpc(int slotIndex)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestBottleBarrelServerRpc(int barrelSlotIndex, int requestedBottleCount, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestCatalyzeBeverageServerRpc(int beverageSlotIndex, BaseType baseType, FixedString64Bytes catalystId1, FixedString64Bytes catalystId2, FixedString64Bytes catalystId3, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void ClearInventoryServerRpc(ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void AddItemServerRpc(string itemId, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc]
		public void AddBarrelWithMetadataServerRpc(int barrelType = 0, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		public void SwapItems(int fromSlot, int toSlot)
		{
		}

		[ServerRpc]
		public void RequestSwapSlotsServerRpc(int fromSlot, int toSlot)
		{
		}

		private bool ShouldMergeSlots(InventorySlot fromSlot, InventorySlot toSlot)
		{
			return false;
		}

		private void PerformSlotSwap(int fromSlot, int toSlot)
		{
		}

		public static bool CatalystsMatchStatic(BeerDataSnapshot a, BeerDataSnapshot b)
		{
			return false;
		}

		[ClientRpc]
		private void SendBottlingResultClientRpc(bool success, int bottlesFilled, int bottlesRemaining, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void SendCatalyzeResultClientRpc(int slotIndex, BeerDataSnapshot snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyInventoryFullClientRpc(string itemName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ClientRpc]
		private void NotifyCrateFullClientRpc(string crateName, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestAddItemToCrateServerRpc(int crateSlotIndex, int playerSlotIndex, int crateInternalSlot, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		[ServerRpc(RequireOwnership = false)]
		public void RequestRemoveItemFromCrateServerRpc(int crateSlotIndex, int crateInternalSlot, int quantity, ServerRpcParams rpcParams = default(ServerRpcParams))
		{
		}

		private int FindNewSlotIndex(Item item, HashSet<int> previousSlots)
		{
			return 0;
		}

		public InventorySlot GetSlot(int index)
		{
			return null;
		}

		public InventorySlot[] GetAllSlots()
		{
			return null;
		}

		public void SetSlotMetadata(int slotIndex, BeerDataSnapshot metadata)
		{
		}

		public int GetInventorySize()
		{
			return 0;
		}

		public bool HasItem(Item item, int quantity = 1)
		{
			return false;
		}

		public int GetItemCount(Item item)
		{
			return 0;
		}

		public int GetItemCount(string itemId)
		{
			return 0;
		}

		public bool TryRemoveItem(Item item, int quantity)
		{
			return false;
		}

		public int GetItemCountIncludingCrates(Item item)
		{
			return 0;
		}

		public bool TryRemoveItemIncludingCrates(Item item, int quantity)
		{
			return false;
		}

		public void SetSelectedSlot(int slotIndex, bool forceNotify = false)
		{
		}

		public int GetSelectedSlotIndex()
		{
			return 0;
		}

		public InventorySlot GetSelectedSlot()
		{
			return null;
		}

		public void DropSelectedItem()
		{
		}

		private void HandleQuickSlotSelected(int slotIndex)
		{
		}

		private void HandleDropPerformed()
		{
		}

		private void NotifySelectedSlotChanged()
		{
		}

		private void HandleCrateSelection()
		{
		}

		private void HandleBackpackSelection()
		{
		}

		public bool TryEquipBackpack(int slotIndex)
		{
			return false;
		}

		[ServerRpc]
		private void RequestEquipBackpackServerRpc(int slotIndex)
		{
		}

		private void EquipBackpackInternal(int slotIndex, BackpackItem backpack)
		{
		}

		public bool TryUnequipBackpack()
		{
			return false;
		}

		[ServerRpc]
		private void RequestUnequipBackpackServerRpc()
		{
		}

		private void UnequipBackpackInternal()
		{
		}

		public bool CanUnequipBackpack()
		{
			return false;
		}

		[ClientRpc]
		private void SyncBackpackStateClientRpc(bool equipped, string backpackItemId)
		{
		}

		private void OnDrop(InputValue value)
		{
		}

		private void SubscribeToInputReader()
		{
		}

		private void UnsubscribeFromInputReader()
		{
		}

		private void SerializeAndBroadcastInventory()
		{
		}

		public void ForceInventorySync()
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

		private void ParseAndApplyCrateItemMetadata(InventorySlot slot, string crateItemMetadataJson)
		{
		}

		private void ClearAllSlots()
		{
		}

		private void BroadcastSnapshotToOwner(string snapshot)
		{
		}

		[ClientRpc]
		private void SyncInventoryClientRpc(string snapshot, ClientRpcParams rpcParams = default(ClientRpcParams))
		{
		}

		public Dictionary<string, object> CaptureState()
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

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		public override void OnDestroy()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_2851630827(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1220051797(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2187077728(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3144481200(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3486078823(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_30562697(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2404825824(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3551850109(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3094134398(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1425292398(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2111806920(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1969981442(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1619508339(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_407625854(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3750019128(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_376858889(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_2891674903(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
