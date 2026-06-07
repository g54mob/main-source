using System.Collections.Generic;
using InventorySystem;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Thief
{
	public class CampLootDisplay : NetworkBehaviour
	{
		private struct VisualLootEntry
		{
			public LootDisplayPoint point;

			public GameObject visualObject;

			public string itemId;
		}

		[Header("References")]
		[Tooltip("The ThiefCampManager this display is associated with.")]
		[SerializeField]
		private ThiefCampManager campManager;

		[Header("Display Points")]
		[Tooltip("Points where stolen items are displayed. Auto-populated from children if empty.")]
		[SerializeField]
		private LootDisplayPoint[] displayPoints;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<int, VisualLootEntry> displayedItems;

		public int DisplayedItemCount => 0;

		public int MaxDisplayPoints => 0;

		public ThiefCampManager CampManager => null;

		public override void OnNetworkSpawn()
		{
		}

		public override void OnNetworkDespawn()
		{
		}

		private void OnItemStolen(StolenItemData data, int index)
		{
		}

		private void OnItemRemoved(int index)
		{
		}

		private void OnAllItemsCleared()
		{
		}

		public void TryDisplayItem(StolenItemData data, int index)
		{
		}

		private void SpawnDisplayItem(Item item, StolenItemData data, int index, LootDisplayPoint point)
		{
		}

		private GameObject CreateVisualOnlyInstance(Item item, StolenItemData data, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		private void StripForVisualDisplay(GameObject obj)
		{
		}

		private void ApplyVisualMetadata(GameObject obj, Item item, StolenItemData data)
		{
		}

		[ClientRpc]
		private void SpawnDisplayItemClientRpc(string itemId, int index, Vector3 position, Quaternion rotation, string crateMetadataJson)
		{
		}

		public void RemoveDisplayedItem(int index)
		{
		}

		[ClientRpc]
		private void RemoveDisplayedItemClientRpc(int index)
		{
		}

		public void ClearAllDisplayedItems()
		{
		}

		[ClientRpc]
		private void ClearAllDisplayedItemsClientRpc()
		{
		}

		public void RefreshFromStolenItems()
		{
		}

		public void TeleportLootItems()
		{
		}

		[ClientRpc]
		private void TeleportDisplayItemClientRpc(int index, Vector3 position, Quaternion rotation)
		{
		}

		private LootDisplayPoint GetNextAvailablePoint()
		{
			return null;
		}

		private int GetNextAvailablePointIndex()
		{
			return 0;
		}

		private LootDisplayPoint GetDisplayPointByIndex(int index)
		{
			return null;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		private static void __rpc_handler_1878944149(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3902581529(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_3589405188(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		private static void __rpc_handler_1541012275(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
