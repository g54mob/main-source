using System;
using System.Collections.Generic;
using System.Linq;
using Restory.ObjectPools;
using Restory.StorageSystem;
using Restory.UI.Presenters.Inventory.StorageSlotElements;
using Restory.UI.Views.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Inventory
{
	public sealed class InventoryPanelItems : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private InventoryItemsView view;

		private StorageSlotElementPool inventoryItemPool;

		private readonly List<IReadOnlyStorageSlot> items = new List<IReadOnlyStorageSlot>();

		private readonly List<StorageSlotElement> uiItems = new List<StorageSlotElement>();

		public IReadOnlyList<IReadOnlyStorageSlot> Items => items;

		public IReadOnlyList<StorageSlotElement> UIItems => uiItems;

		public event Action<InventoryPanelItems, StorageSlotElement> ItemSelected;

		public event Action<InventoryPanelItems, StorageSlotElement> ItemDrag;

		[Inject]
		private void Construct(StorageSlotElementPool inventoryItemPool)
		{
			this.inventoryItemPool = inventoryItemPool;
		}

		private void OnEnable()
		{
			UpdateItemViews();
		}

		private void OnDisable()
		{
			ClearItemViews();
			view.SetEmptyInfoVisibility(isVisible: true);
			items.Clear();
		}

		public void SetItems(IEnumerable<IReadOnlyStorageSlot> items)
		{
			this.items.Clear();
			this.items.AddRange(items);
			UpdateItemViews();
			view.SetEmptyInfoVisibility(items.Count() == 0);
		}

		public void EnableAllItems()
		{
			foreach (StorageSlotElement uiItem in uiItems)
			{
				uiItem.Enable();
			}
		}

		public void DisableNotCompatibleItems(string deviceNameKey)
		{
			foreach (StorageSlotElement uiItem in uiItems)
			{
				if (!(uiItem.Item.Item.DeviceNameLocalizationKey == deviceNameKey))
				{
					uiItem.Disable();
				}
			}
		}

		private void UpdateItemViews()
		{
			ClearItemViews();
			foreach (IReadOnlyStorageSlot item in items)
			{
				StorageSlotElement storageSlotElement = inventoryItemPool.Get<StorageSlotElement>();
				storageSlotElement.SetItem(item);
				storageSlotElement.OnSelectedChanged += OnItemSelected;
				storageSlotElement.OnDrag += OnItemDrag;
				uiItems.Add(storageSlotElement);
			}
			view.SetItems(uiItems.Select((StorageSlotElement p) => p.View));
		}

		private void ClearItemViews()
		{
			view.ClearItems();
			foreach (StorageSlotElement uiItem in uiItems)
			{
				uiItem.OnSelectedChanged -= OnItemSelected;
				uiItem.OnDrag -= OnItemDrag;
				uiItem.SetItem(null);
				inventoryItemPool.Release(uiItem);
			}
			uiItems.Clear();
		}

		private void OnItemSelected(StorageSlotElement p)
		{
			this.ItemSelected?.Invoke(this, p);
		}

		private void OnItemDrag(StorageSlotElement p)
		{
			this.ItemDrag?.Invoke(this, p);
		}

		void ICleanableComponent.Clean()
		{
			ClearItemViews();
			view.SetEmptyInfoVisibility(isVisible: true);
			items.Clear();
		}
	}
}
