using System.Collections.Generic;
using DV.UIFramework;
using DV.Util;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class InventorySectionController : AUIController
	{
		public enum InventorySection
		{
			Hotbar = 0,
			Backpack = 1,
			Hand = 2,
			ItemContainer = 3
		}

		public InventorySection section;

		public InventoryGridView gridView;

		public AInventoryUIController controller;

		[SerializeField]
		private InventorySectionTextController textController;

		private InventoryUIInteractionObserver observer;

		private ObservableCollectionExt<InventorySlotDisplayData> inventoryModel = new ObservableCollectionExt<InventorySlotDisplayData>();

		private ItemContainerProvider itemContainerProvider;

		private bool dragDisabled;

		public int IndexOfElement(InventorySlotDisplayData element)
		{
			return inventoryModel.IndexOf(element);
		}

		public void Initialize(int capacity, AInventoryUIController controller, List<InventorySlotDisplayData> initialData, bool dragDisabled, ItemContainerProvider itemContainerProvider)
		{
			this.controller = controller;
			for (int i = 0; i < capacity; i++)
			{
				inventoryModel.Add(initialData[i]);
			}
			gridView.SetModel(inventoryModel);
			this.dragDisabled = dragDisabled;
			if (section == InventorySection.ItemContainer)
			{
				this.itemContainerProvider = itemContainerProvider;
				itemContainerProvider.ActiveModelChanged += OnActiveModelChanged;
			}
			InitializeVisualControllers();
			observer = base.gameObject.AddComponent<InventoryUIInteractionObserver>();
			observer.Initialize(this, gridView, inventoryModel);
		}

		private void InitializeVisualControllers()
		{
			InventoryGridElement[] componentsInChildren = GetComponentsInChildren<InventoryGridElement>();
			foreach (InventoryGridElement inventoryGridElement in componentsInChildren)
			{
				inventoryGridElement.allowSelection = section == InventorySection.Hotbar;
				InventorySlotVisualController component = inventoryGridElement.GetComponent<InventorySlotVisualController>();
				component.dragDisabled = dragDisabled;
				component.isHandSlot = section == InventorySection.Hand;
				component.controllerContainer = ((section == InventorySection.ItemContainer) ? itemContainerProvider.ActiveContainer : null);
				component.AddInventoryReferences(controller);
				component.UpdateVisuals(inventoryGridElement.Data);
			}
		}

		private void OnActiveModelChanged(ObservableCollectionExt<InventorySlotDisplayData> activeModel, ObservableCollectionExt<InventorySlotDisplayData> previousActiveModel)
		{
			inventoryModel = activeModel;
			gridView.SetModel(inventoryModel);
			InitializeVisualControllers();
			observer.Initialize(this, gridView, inventoryModel, reintialize: true);
			if (textController != null)
			{
				textController.UpdateText(itemContainerProvider.GetActiveContainerNameLocalized());
			}
		}

		public void Add(InventorySlotDisplayData data, int index)
		{
			inventoryModel[index] = data;
		}

		public void Remove(int index)
		{
			inventoryModel[index] = controller.GetEmptySlotData(index, this);
		}

		public void Drop(int index, bool leaveGhost)
		{
			InventorySlotDisplayData inventorySlotDisplayData;
			if (leaveGhost)
			{
				inventorySlotDisplayData = inventoryModel[index];
				inventorySlotDisplayData.IsGhost = true;
			}
			else
			{
				inventorySlotDisplayData = controller.GetEmptySlotData(index, this);
			}
			inventoryModel[index] = inventorySlotDisplayData;
		}

		public void Move(int from, int to)
		{
			ObservableCollectionExt<InventorySlotDisplayData> observableCollectionExt = inventoryModel;
			ObservableCollectionExt<InventorySlotDisplayData> observableCollectionExt2 = inventoryModel;
			InventorySlotDisplayData emptySlotData = controller.GetEmptySlotData(from, this);
			InventorySlotDisplayData inventorySlotDisplayData = inventoryModel[from];
			InventorySlotDisplayData inventorySlotDisplayData2 = (observableCollectionExt[from] = emptySlotData);
			inventorySlotDisplayData2 = (observableCollectionExt2[to] = inventorySlotDisplayData);
		}

		public void Swap(int source, int target)
		{
			ObservableCollectionExt<InventorySlotDisplayData> observableCollectionExt = inventoryModel;
			ObservableCollectionExt<InventorySlotDisplayData> observableCollectionExt2 = inventoryModel;
			InventorySlotDisplayData inventorySlotDisplayData = inventoryModel[target];
			InventorySlotDisplayData inventorySlotDisplayData2 = inventoryModel[source];
			InventorySlotDisplayData inventorySlotDisplayData3 = (observableCollectionExt[source] = inventorySlotDisplayData);
			inventorySlotDisplayData3 = (observableCollectionExt2[target] = inventorySlotDisplayData2);
		}

		public void Replace(int target, InventorySlotDisplayData data)
		{
			inventoryModel[target] = data;
		}

		public InventorySlotDisplayData GetData(int index)
		{
			return inventoryModel[index];
		}

		public InventoryUIInteractionObserver GetObserver()
		{
			return observer;
		}

		public void ToggleLock(int index)
		{
			InventorySlotDisplayData inventorySlotDisplayData = inventoryModel[index];
			inventorySlotDisplayData.IsLocked = !inventorySlotDisplayData.IsLocked;
			inventoryModel[index] = inventorySlotDisplayData;
		}

		public void ToggleGhost(int index, bool on)
		{
			InventorySlotDisplayData inventorySlotDisplayData = inventoryModel[index];
			inventorySlotDisplayData.IsGhost = on;
			inventoryModel[index] = inventorySlotDisplayData;
		}

		public void SetSelectedSlot(int slotIndex)
		{
			if (slotIndex >= 0)
			{
				gridView.SetSelected(slotIndex);
			}
			else
			{
				gridView.Deselect();
			}
		}

		public void ToggleItemGetters(bool allowed)
		{
			for (int i = 0; i < inventoryModel.Count; i++)
			{
				InventorySlotDisplayData inventorySlotDisplayData = inventoryModel[i];
				inventorySlotDisplayData.ItemGetterAllowed = allowed;
				inventoryModel[i] = inventorySlotDisplayData;
			}
		}
	}
}
