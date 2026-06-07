using System.Collections.Generic;
using DV.Common;
using DV.InventorySystem;
using DV.Util;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class ItemContainerProvider : MonoBehaviour
	{
		public delegate void ActiveModelChangedDelegate(ObservableCollectionExt<InventorySlotDisplayData> activeModel, ObservableCollectionExt<InventorySlotDisplayData> previousActiveModel);

		private Dictionary<AItemContainer, ObservableCollectionExt<InventorySlotDisplayData>> containerToInventoryModel = new Dictionary<AItemContainer, ObservableCollectionExt<InventorySlotDisplayData>>();

		private ItemContainerRegistry itemContainerRegistry;

		private bool initialized;

		private ObservableCollectionExt<InventorySlotDisplayData> activeModel;

		public AItemContainer ActiveContainer { get; private set; }

		public ObservableCollectionExt<InventorySlotDisplayData> ActiveModel
		{
			get
			{
				return activeModel;
			}
			protected set
			{
				if (activeModel != value)
				{
					ObservableCollectionExt<InventorySlotDisplayData> previousActiveModel = activeModel;
					activeModel = value;
					this.ActiveModelChanged?.Invoke(activeModel, previousActiveModel);
				}
			}
		}

		public event ActiveModelChangedDelegate ActiveModelChanged;

		public string GetActiveContainerNameLocalized()
		{
			if (!(ActiveContainer != null))
			{
				return string.Empty;
			}
			return ActiveContainer.ContainerNameLocalized;
		}

		public void Initialize(AInventoryProvider inventoryProvider)
		{
			if (initialized)
			{
				return;
			}
			if (inventoryProvider == null)
			{
				Debug.LogError("ItemContainerProvider: Inventory provider is null, cannot initialize.", this);
				return;
			}
			itemContainerRegistry = inventoryProvider.Inventory.ItemContainerRegistry;
			if (itemContainerRegistry == null)
			{
				Debug.LogError("ItemContainerProvider: Item container registry is null, cannot initialize.", this);
				return;
			}
			List<AItemContainer> allItemContainers = itemContainerRegistry.GetAllItemContainers();
			itemContainerRegistry.RegistryUpdated += OnRegistryUpdated;
			itemContainerRegistry.ActiveContainerChanged += OnActiveContainerChanged;
			foreach (AItemContainer item in allItemContainers)
			{
				if (AddContainer(item))
				{
					SetupContainerListeners(item, on: true);
				}
			}
		}

		private void OnDestroy()
		{
			if (UnloadWatcher.isUnloading)
			{
				return;
			}
			if (itemContainerRegistry != null)
			{
				itemContainerRegistry.RegistryUpdated -= OnRegistryUpdated;
				itemContainerRegistry.ActiveContainerChanged -= OnActiveContainerChanged;
			}
			foreach (AItemContainer key in containerToInventoryModel.Keys)
			{
				SetupContainerListeners(key, on: false);
			}
		}

		private void SetupContainerListeners(AItemContainer container, bool on)
		{
			if (!(container == null))
			{
				container.ItemContainerDataChanged -= OnItemContainerDataChanged;
				if (on)
				{
					container.ItemContainerDataChanged += OnItemContainerDataChanged;
				}
			}
		}

		private void OnActiveContainerChanged(AItemContainer activeContainer, AItemContainer _)
		{
			ActiveContainer = activeContainer;
			if (activeContainer != null)
			{
				if (!containerToInventoryModel.TryGetValue(activeContainer, out var value))
				{
					Debug.LogError("ItemContainerProvider: Inventory model for active container " + activeContainer.ContainerId + " not found, cannot update inventory model. This should not happen.", this);
					ActiveModel = null;
				}
				else
				{
					ActiveModel = value;
				}
			}
			else
			{
				ActiveModel = null;
			}
		}

		private void OnItemContainerDataChanged(AItemContainer container, int source, int target)
		{
			if (string.IsNullOrWhiteSpace((container != null) ? container.ContainerId : null))
			{
				Debug.LogError("ItemContainerProvider: Item container id is null or empty, cannot update inventory model. This should not happen.", this);
				return;
			}
			if (!containerToInventoryModel.TryGetValue(container, out var value))
			{
				Debug.LogError("ItemContainerProvider: Inventory model for active container " + container.ContainerId + " not found, cannot update inventory model. This should not happen.", this);
				return;
			}
			bool num = source != -1;
			bool flag = target != -1;
			if (num)
			{
				GameObject gameObject = container[source];
				InventorySlotDisplayData value2 = new InventorySlotDisplayData((gameObject != null) ? gameObject.GetComponent<IInventoryItemSpec>() : null, containerAccessAllowed: true, isHandData: false, isContainerData: true);
				value[source] = value2;
			}
			if (flag)
			{
				GameObject gameObject2 = container[target];
				InventorySlotDisplayData value3 = new InventorySlotDisplayData((gameObject2 != null) ? gameObject2.GetComponent<IInventoryItemSpec>() : null, containerAccessAllowed: true, isHandData: false, isContainerData: true);
				value[target] = value3;
			}
		}

		private void OnRegistryUpdated(AItemContainer itemContainer, bool added)
		{
			if (string.IsNullOrWhiteSpace((itemContainer != null) ? itemContainer.ContainerId : null))
			{
				Debug.LogError("ItemContainerProvider: Item container id is null or empty, cannot update registry. This should not happen.", this);
			}
			else if (added)
			{
				AddContainer(itemContainer);
			}
			else
			{
				RemoveContainer(itemContainer);
			}
		}

		private void RemoveContainer(AItemContainer container)
		{
			string text = ((container != null) ? container.ContainerId : null);
			if (string.IsNullOrWhiteSpace(text))
			{
				Debug.LogError("ItemContainerProvider: Item container id is null or empty, cannot unregister container. This should not happen.", this);
				return;
			}
			if (!containerToInventoryModel.TryGetValue(container, out var value))
			{
				Debug.LogError("ItemContainerProvider: Item container with id " + text + " not found, cannot unregister container. This should not happen.", this);
				return;
			}
			if (ActiveContainer == container)
			{
				ActiveContainer = null;
				ActiveModel = null;
			}
			value.Clear();
			containerToInventoryModel.Remove(container);
			SetupContainerListeners(container, on: false);
		}

		private bool AddContainer(AItemContainer itemContainer)
		{
			if (string.IsNullOrWhiteSpace((itemContainer != null) ? itemContainer.ContainerId : null))
			{
				Debug.LogError("ItemContainerProvider: Item container id is null or empty, cannot add container. This should not happen.", this);
				return false;
			}
			ObservableCollectionExt<InventorySlotDisplayData> observableCollectionExt = new ObservableCollectionExt<InventorySlotDisplayData>();
			for (int i = 0; i < itemContainer.Capacity; i++)
			{
				GameObject gameObject = itemContainer[i];
				InventorySlotDisplayData item = new InventorySlotDisplayData((gameObject != null) ? gameObject.GetComponent<IInventoryItemSpec>() : null, containerAccessAllowed: true, isHandData: false, isContainerData: true);
				observableCollectionExt.Add(item);
			}
			containerToInventoryModel.Add(itemContainer, observableCollectionExt);
			SetupContainerListeners(itemContainer, on: true);
			return true;
		}
	}
}
