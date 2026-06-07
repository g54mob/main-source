using System.Collections;
using DV.CabControls;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class ItemDisabler
	{
		private static readonly Vector2Int notDisabledCoordsMark = new Vector2Int(-999, -999);

		private ItemBase item;

		private Vector2Int disabledCoords = notDisabledCoordsMark;

		private ItemDisablerGrid itemDisablerGrid;

		private ItemReparentingBase itemReparenting;

		private bool isInCar;

		private bool isInInventory;

		private bool isInLostAndFound;

		private bool isGrabbed;

		private bool inDumpster;

		private bool isOnDisablingStaticParent;

		private Coroutine afterLoadEnablerCoro;

		private bool IsBoundToPlayer
		{
			get
			{
				if (!isGrabbed)
				{
					return isInInventory;
				}
				return true;
			}
		}

		public ItemDisabler(ItemBase item, ItemReparentingBase itemReparenting)
		{
			this.item = item;
			this.itemReparenting = itemReparenting;
			isInCar = TrainCar.Resolve(item.gameObject) != null;
			isGrabbed = item.IsGrabbed();
			isInInventory = SingletonBehaviour<Inventory>.Instance.Contains(item.gameObject, includeDropped: false);
			isInLostAndFound = SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ContainsItem(item);
			if (IsBoundToPlayer || isInCar || isInLostAndFound)
			{
				disabledCoords = notDisabledCoordsMark;
			}
			itemDisablerGrid = SingletonBehaviour<ItemDisablerGrid>.Instance;
			OnItemDisablePositionUpdated();
			SetupListeners(set: true);
		}

		public void Destroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(set: false);
			}
		}

		private void SetupListeners(bool set)
		{
			if (set)
			{
				itemDisablerGrid.PositionUpdated += OnItemDisablePositionUpdated;
				itemReparenting.ItemParented += OnItemReparented;
				item.Grabbed += OnItemGrabbed;
				item.Ungrabbed += OnItemUngrabbed;
				SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ItemAdded += OnItemAddedToLostAndFound;
				SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ItemRemoved += OnItemRemovedFromLostAndFound;
				item.ItemInventoryStateChanged += OnItemInventoryStateChanged;
			}
			else
			{
				itemDisablerGrid.PositionUpdated -= OnItemDisablePositionUpdated;
				itemReparenting.ItemParented -= OnItemReparented;
				item.Grabbed -= OnItemGrabbed;
				item.Ungrabbed -= OnItemUngrabbed;
				SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ItemAdded -= OnItemAddedToLostAndFound;
				SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.ItemRemoved -= OnItemRemovedFromLostAndFound;
				item.ItemInventoryStateChanged -= OnItemInventoryStateChanged;
			}
		}

		private void OnItemInventoryStateChanged(ItemBase itemBase, InventoryActionType actionType, InventoryItemState itemState)
		{
			isInInventory = itemState.IsInInventory();
			if (isInInventory)
			{
				disabledCoords = notDisabledCoordsMark;
			}
		}

		private void OnItemGrabbed(ControlImplBase _)
		{
			isGrabbed = true;
			disabledCoords = notDisabledCoordsMark;
		}

		private void OnItemUngrabbed(ControlImplBase _)
		{
			isGrabbed = item.IsGrabbed();
		}

		private void OnItemAddedToLostAndFound(ItemBase storageItem)
		{
			if (!(item != storageItem))
			{
				isInLostAndFound = true;
				disabledCoords = notDisabledCoordsMark;
			}
		}

		private void OnItemRemovedFromLostAndFound(ItemBase storageItem)
		{
			if (!(item != storageItem))
			{
				isInLostAndFound = false;
			}
		}

		private void OnItemReparented(Transform parentedTo)
		{
			if (TrainCar.Resolve(parentedTo) != null)
			{
				isInCar = true;
				disabledCoords = notDisabledCoordsMark;
			}
			else
			{
				isOnDisablingStaticParent = parentedTo != null && parentedTo.GetComponent<ItemStaticParentPaintStation>() != null;
				isInCar = false;
			}
		}

		public void ToggleInDumpster(bool dumpstered)
		{
			inDumpster = dumpstered;
			if (inDumpster)
			{
				disabledCoords = notDisabledCoordsMark;
			}
		}

		private void OnItemDisablePositionUpdated()
		{
			if (IsBoundToPlayer || isInLostAndFound || isInCar || item.IsSnapped || (!isOnDisablingStaticParent && item.BelongsToPlayer()))
			{
				return;
			}
			if (disabledCoords != notDisabledCoordsMark)
			{
				if (!itemDisablerGrid.IsCoordActive(disabledCoords))
				{
					return;
				}
				if (SingletonBehaviour<WorldStreamingInit>.Instance != null && !SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainRegionLoaded(item.transform.position))
				{
					if (afterLoadEnablerCoro == null)
					{
						afterLoadEnablerCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(EnableItemWhenTerrainsAndScenesAreLoaded());
					}
				}
				else
				{
					item.gameObject.SetActive(value: true);
					disabledCoords = notDisabledCoordsMark;
				}
			}
			else if (item.gameObject.activeInHierarchy)
			{
				Vector2Int gridCoords = itemDisablerGrid.GetGridCoords(item.transform.position);
				if (!itemDisablerGrid.IsCoordActive(gridCoords))
				{
					item.gameObject.SetActive(value: false);
					disabledCoords = gridCoords;
				}
			}
		}

		private IEnumerator EnableItemWhenTerrainsAndScenesAreLoaded()
		{
			do
			{
				yield return WaitFor.Seconds(1f);
				if (!item)
				{
					yield break;
				}
				if (!itemDisablerGrid.IsCoordActive(disabledCoords))
				{
					afterLoadEnablerCoro = null;
					yield break;
				}
			}
			while (!(SingletonBehaviour<WorldStreamingInit>.Instance != null) || !SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainRegionLoaded(item.transform.position));
			item.gameObject.SetActive(value: true);
			disabledCoords = notDisabledCoordsMark;
			afterLoadEnablerCoro = null;
		}
	}
}
