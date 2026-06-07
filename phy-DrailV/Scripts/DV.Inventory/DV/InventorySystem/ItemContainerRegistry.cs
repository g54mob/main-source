using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.InventorySystem
{
	public class ItemContainerRegistry
	{
		public delegate void ActiveContainerChangedDelegate(AItemContainer activeContainer, AItemContainer previouslyActiveContainer);

		public delegate void RegistryUpdatedDelegate(AItemContainer itemContainer, bool added);

		[NonSerialized]
		public bool canRegisterContainers = true;

		private AItemContainer activeContainer;

		private Dictionary<string, AItemContainer> itemContainers = new Dictionary<string, AItemContainer>();

		public AItemContainer ActiveContainer
		{
			get
			{
				return activeContainer;
			}
			set
			{
				if (!(activeContainer == value))
				{
					AItemContainer aItemContainer = activeContainer;
					activeContainer = value;
					if ((bool)aItemContainer)
					{
						aItemContainer.PlayInteractionEffects(open: false);
					}
					if ((bool)activeContainer)
					{
						activeContainer.PlayInteractionEffects(open: true);
					}
					SetupContainerListeners(aItemContainer, on: false);
					SetupContainerListeners(activeContainer, on: true);
					this.ActiveContainerChanged?.Invoke(activeContainer, aItemContainer);
				}
			}
		}

		public event ActiveContainerChangedDelegate ActiveContainerChanged;

		public event RegistryUpdatedDelegate RegistryUpdated;

		public event AItemContainer.ItemContainerDataChangedDelegate ActiveContainerDataChanged;

		public event AItemContainer.ItemDroppedDelegate ActiveContainerItemDropped;

		public event AItemContainer.ItemDroppedDelegate MagazineItemDropped;

		public bool ContainerExists(string id)
		{
			return itemContainers.ContainsKey(id);
		}

		public bool RegisterItemContainer(string id, AItemContainer itemContainer)
		{
			if (!canRegisterContainers)
			{
				return false;
			}
			if (ContainerExists(id))
			{
				Debug.LogError("ItemContainerRegistry: ItemContainer with id " + id + " already registered. Cannot register.");
				return false;
			}
			itemContainers.Add(id, itemContainer);
			this.RegistryUpdated?.Invoke(itemContainer, added: true);
			if (!itemContainer.DirectInteractionAllowed)
			{
				itemContainer.ItemDropped += OnMagazineItemDropped;
			}
			return true;
		}

		public void UnregisterItemContainer(string id)
		{
			AItemContainer itemContainer = GetItemContainer(id);
			if (itemContainer == null)
			{
				Debug.LogError("ItemContainerRegistry: ItemContainer with id " + id + " wasn't registered. Cannot unregister.");
				return;
			}
			itemContainers.Remove(id);
			this.RegistryUpdated?.Invoke(itemContainer, added: false);
			if (activeContainer == itemContainer)
			{
				ActiveContainer = null;
			}
			if (!itemContainer.DirectInteractionAllowed)
			{
				itemContainer.ItemDropped -= OnMagazineItemDropped;
			}
		}

		private void SetupContainerListeners(AItemContainer container, bool on)
		{
			if (!(container == null))
			{
				if (on)
				{
					container.ItemContainerDataChanged += OnActiveContainerDataChanged;
					container.ItemDropped += OnActiveContainerItemDropped;
				}
				else
				{
					container.ItemContainerDataChanged -= OnActiveContainerDataChanged;
					container.ItemDropped -= OnActiveContainerItemDropped;
				}
			}
		}

		private void OnActiveContainerItemDropped(GameObject item)
		{
			this.ActiveContainerItemDropped?.Invoke(item);
		}

		private void OnMagazineItemDropped(GameObject item)
		{
			this.MagazineItemDropped?.Invoke(item);
		}

		private void OnActiveContainerDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
		{
			this.ActiveContainerDataChanged?.Invoke(container, sourceIndex, destinationIndex);
		}

		public AItemContainer GetItemContainer(string id, bool nullIsValid = false)
		{
			if (itemContainers.TryGetValue(id, out var value))
			{
				return value;
			}
			if (!nullIsValid)
			{
				Debug.LogWarning("ItemContainerRegistry: ItemContainer with id " + id + " not found.");
			}
			return null;
		}

		public List<AItemContainer> GetAllItemContainers()
		{
			return new List<AItemContainer>(itemContainers.Values);
		}

		public AItemContainer GetContainer(string id)
		{
			if (itemContainers.TryGetValue(id, out var value))
			{
				return value;
			}
			Debug.LogError("ItemContainerRegistry: Container with id " + id + " not found.");
			return null;
		}

		public (string ContainerId, int index) GetItemContainerIdAndIndex(GameObject item)
		{
			var (aItemContainer, item2) = GetItemContainerAndIndex(item);
			if (aItemContainer != null)
			{
				return (ContainerId: aItemContainer.ContainerId, index: item2);
			}
			return (ContainerId: null, index: -1);
		}

		public (AItemContainer Container, int index) GetItemContainerAndIndex(GameObject item)
		{
			foreach (AItemContainer value in itemContainers.Values)
			{
				int num = value.IndexOf(item);
				if (num >= 0)
				{
					return (Container: value, index: num);
				}
			}
			return (Container: null, index: -1);
		}

		public void PurgeItemFromContainer(GameObject item)
		{
			var (id, num) = GetItemContainerIdAndIndex(item);
			if (num >= 0)
			{
				AItemContainer container = GetContainer(id);
				if (!(container == null))
				{
					container.RemoveItem(num, activateItem: true, dropItem: true);
				}
			}
		}
	}
}
