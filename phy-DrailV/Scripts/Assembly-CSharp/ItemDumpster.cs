using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class ItemDumpster : MonoBehaviour
{
	private struct DumpsteredItemData
	{
		public readonly RespawnOnDrop respawner;

		public readonly bool originalBelongsToPlayer;

		public readonly bool originalRespawnThroughFloor;

		public readonly bool originalIgnoreDistanceFromSpawnPosition;

		public readonly float originalRespawnDistance;

		public DumpsteredItemData(RespawnOnDrop respawner, bool originalBelongsToPlayer)
		{
			this.respawner = respawner;
			this.originalBelongsToPlayer = originalBelongsToPlayer;
			originalRespawnThroughFloor = respawner.respawnOnDropThroughFloor;
			originalRespawnDistance = respawner.maxDistance;
			originalIgnoreDistanceFromSpawnPosition = respawner.ignoreDistanceFromSpawnPosition;
		}
	}

	private const float DUMPED_ITEM_RESPAWN_ON_DROP_DISTANCE = 75f;

	private readonly Dictionary<ItemBase, DumpsteredItemData> dumpsteredItems = new Dictionary<ItemBase, DumpsteredItemData>();

	private readonly Dictionary<GameObject, Coroutine> pendingItems = new Dictionary<GameObject, Coroutine>();

	private void OnDestroy()
	{
		if (UnloadWatcher.isQuitting)
		{
			return;
		}
		foreach (ItemBase item in new List<ItemBase>(dumpsteredItems.Keys))
		{
			UnregisterItem(item);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		RegisterItem(other.gameObject.GetComponentInParent<ItemBase>());
	}

	private bool IsValidDumpsterItem(ItemBase itemBase)
	{
		if (!itemBase)
		{
			return false;
		}
		InventoryItemSpec inventorySpecs = itemBase.InventorySpecs;
		if (!inventorySpecs || inventorySpecs.ImmuneToDumpster)
		{
			return false;
		}
		if (inventorySpecs.TryGetComponent<JobBooklet>(out var _))
		{
			return false;
		}
		if (!dumpsteredItems.ContainsKey(itemBase))
		{
			return !itemBase.IsInBelt();
		}
		return false;
	}

	private void OnTriggerExit(Collider other)
	{
		GameObject gameObject = other.gameObject;
		if (!RemovePending(gameObject) && dumpsteredItems.Count > 0)
		{
			UnregisterItem(gameObject.GetComponentInParent<ItemBase>());
		}
	}

	private void UnregisterItem(ItemBase itemBase)
	{
		if (dumpsteredItems.TryGetValue(itemBase, out var value))
		{
			RespawnOnDrop respawner = value.respawner;
			itemBase.itemDisabler?.ToggleInDumpster(dumpstered: false);
			respawner.maxDistance = value.originalRespawnDistance;
			respawner.respawnOnDropThroughFloor = value.originalRespawnThroughFloor;
			respawner.ignoreDistanceFromSpawnPosition = value.originalIgnoreDistanceFromSpawnPosition;
			itemBase.InventorySpecs.BelongsToPlayer = value.originalBelongsToPlayer;
			dumpsteredItems.Remove(itemBase);
			respawner.Respawned -= OnItemRespawned;
			itemBase.AboutToBeDestroyed -= OnItemAboutToBeDestroyed;
		}
	}

	private void RegisterItem(ItemBase itemBase, bool isRetry = false)
	{
		if (!IsValidDumpsterItem(itemBase))
		{
			return;
		}
		if (itemBase.itemDisabler == null)
		{
			if (isRetry)
			{
				Debug.LogError("Failed to register item " + itemBase.name + " to ItemDumpster!", this);
			}
			else
			{
				pendingItems[itemBase.gameObject] = StartCoroutine(RegisterLater());
			}
			return;
		}
		RemovePending(itemBase.gameObject);
		RespawnOnDrop component = itemBase.GetComponent<RespawnOnDrop>();
		bool belongsToPlayer = itemBase.InventorySpecs.BelongsToPlayer;
		DumpsteredItemData value = new DumpsteredItemData(component, belongsToPlayer);
		component.respawnOnDropThroughFloor = false;
		itemBase.itemDisabler.ToggleInDumpster(dumpstered: true);
		if (SingletonBehaviour<StorageController>.Instance.StorageWorld.ContainsItem(itemBase))
		{
			SingletonBehaviour<StorageController>.Instance.RemoveItemFromWorldStorage(itemBase);
		}
		component.SetMaxDistance(75f);
		component.ignoreDistanceFromSpawnPosition = true;
		itemBase.InventorySpecs.BelongsToPlayer = false;
		dumpsteredItems.Add(itemBase, value);
		component.Respawned += OnItemRespawned;
		itemBase.AboutToBeDestroyed += OnItemAboutToBeDestroyed;
		IEnumerator RegisterLater()
		{
			yield return null;
			yield return WaitFor.EndOfFrame;
			RegisterItem(itemBase, isRetry: true);
		}
	}

	private bool RemovePending(GameObject go)
	{
		if (!pendingItems.TryGetValue(go, out var value))
		{
			return false;
		}
		StopCoroutine(value);
		return pendingItems.Remove(go);
	}

	private void OnItemAboutToBeDestroyed(ItemBase itemBase)
	{
		UnregisterItem(itemBase);
	}

	private void OnItemRespawned(RespawnOnDrop _, ItemBase itemBase)
	{
		UnregisterItem(itemBase);
	}
}
