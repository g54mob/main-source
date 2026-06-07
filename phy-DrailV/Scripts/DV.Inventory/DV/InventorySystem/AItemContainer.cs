using System;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public abstract class AItemContainer : MonoBehaviour, IRecursiveItemStorage
	{
		public delegate void ItemContainerDataChangedDelegate(AItemContainer container, int sourceIndex, int destinationIndex);

		public delegate void ItemContainerAboutToBeDestroyedDelegate(AItemContainer container);

		public delegate void ItemDroppedDelegate(GameObject item);

		public delegate void ItemContainerNestedInChangedDelegate(AItemContainer container, (AItemContainer oldFirstNest, AItemContainer oldLastNest) oldNestedIn);

		protected delegate void RegisterFallbackDelegate();

		public const int NO_CHANGE_INDEX = -1;

		[SerializeField]
		private int capacity;

		protected GameObject[] items;

		protected GameObject[] itemsCache;

		protected ItemContainerRegistry registry;

		private HashSet<AItemContainer> childrenContainers = new HashSet<AItemContainer>();

		private (AItemContainer firstNest, AItemContainer lastNest) nestedIn;

		public string ContainerId { get; private set; }

		public int Capacity => capacity;

		public int ItemCount { get; private set; }

		protected abstract string ContainerName { get; set; }

		public abstract string ContainerNameLocalized { get; protected set; }

		public abstract bool DirectInteractionAllowed { get; }

		public virtual bool QuickDropAllowed { get; protected set; }

		public (AItemContainer firstNest, AItemContainer lastNest) NestedIn
		{
			get
			{
				return nestedIn;
			}
			set
			{
				(AItemContainer, AItemContainer) tuple = nestedIn;
				(AItemContainer, AItemContainer) tuple2 = value;
				if (!(tuple.Item1 == tuple2.Item1) || !(tuple.Item2 == tuple2.Item2))
				{
					(AItemContainer, AItemContainer) oldNestedIn = nestedIn;
					nestedIn = value;
					this.ItemContainerNestedInChanged?.Invoke(this, oldNestedIn);
				}
			}
		}

		public GameObject this[int index]
		{
			get
			{
				if (index.IsInRange(0, Capacity - 1))
				{
					return items[index];
				}
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Returning empty data.", "AItemContainer", index, Capacity));
				return null;
			}
		}

		public event ItemContainerDataChangedDelegate ItemContainerDataChanged;

		public event ItemContainerAboutToBeDestroyedDelegate AboutToBeDestroyed;

		public event ItemDroppedDelegate ItemDropped;

		public event ItemContainerNestedInChangedDelegate ItemContainerNestedInChanged;

		public abstract bool ValidItem(GameObject item);

		protected abstract bool InitializeSpecific();

		public abstract void PlayInteractionEffects(bool open);

		public abstract void ToggleContainerAccess();

		protected virtual void Awake()
		{
			if (Capacity < 1)
			{
				Debug.LogError(string.Format("{0}: Capacity must be greater than 0. Received {1}. Container will not be initialized.", "AItemContainer", capacity));
				return;
			}
			items = new GameObject[Capacity];
			itemsCache = new GameObject[Capacity];
			registry = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry;
			if (InitializeSpecific())
			{
				AssignIdAndRegister(GenerateId());
			}
		}

		protected virtual void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				this.AboutToBeDestroyed?.Invoke(this);
				if (!string.IsNullOrWhiteSpace(ContainerId) && registry.ContainerExists(ContainerId))
				{
					registry.UnregisterItemContainer(ContainerId);
				}
			}
		}

		protected string GenerateId()
		{
			int num = 0;
			string text;
			while (true)
			{
				text = $"{ContainerName}{num}";
				if (!registry.ContainerExists(text))
				{
					break;
				}
				num++;
			}
			return text;
		}

		protected void AssignIdAndRegister(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				Debug.LogError("AItemContainer: Cannot assign null or empty id to container. Ignoring assignment.");
				return;
			}
			ContainerId = id;
			var (text, num) = registry.GetItemContainerIdAndIndex(base.gameObject);
			if (text != null && num >= 0)
			{
				UpdateNesting(this);
			}
			registry.RegisterItemContainer(id, this);
		}

		protected void UpdateNesting(AItemContainer newFirstNest)
		{
			AItemContainer aItemContainer = newFirstNest;
			AItemContainer aItemContainer2 = ((newFirstNest != null) ? newFirstNest.nestedIn.firstNest : null);
			while (aItemContainer2 != null)
			{
				aItemContainer = aItemContainer2;
				aItemContainer2 = aItemContainer2.NestedIn.firstNest;
			}
			AItemContainer item = NestedIn.lastNest;
			NestedIn = (firstNest: newFirstNest, lastNest: aItemContainer);
			if (item == aItemContainer)
			{
				return;
			}
			foreach (AItemContainer childrenContainer in childrenContainers)
			{
				childrenContainer.UpdateNesting(this);
			}
		}

		public virtual bool AddItem(GameObject item, int index)
		{
			if (item == null)
			{
				Debug.LogError("AItemContainer: Cannot add null item to container. Ignoring add operation.");
				return false;
			}
			if (!ValidItem(item))
			{
				return false;
			}
			if (!index.IsInRange(0, Capacity - 1))
			{
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Ignoring add operation.", "AItemContainer", index, Capacity));
				return false;
			}
			if (items[index] == null)
			{
				items[index] = item;
				ItemCount++;
				item.SetActive(value: false);
				AItemContainer component = item.GetComponent<AItemContainer>();
				if (component != null)
				{
					childrenContainers.Add(component);
					component.UpdateNesting(this);
				}
				this.ItemContainerDataChanged?.Invoke(this, index, -1);
				return true;
			}
			Debug.LogError(string.Format("{0}: Cannot add item to index {1} because it is already occupied. Ignoring add operation.", "AItemContainer", index));
			return false;
		}

		public virtual bool RemoveItem(int index, bool activateItem, bool dropItem)
		{
			if (!index.IsInRange(0, Capacity - 1))
			{
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Ignoring remove operation.", "AItemContainer", index, Capacity));
				return false;
			}
			GameObject gameObject = items[index];
			if (gameObject == null)
			{
				Debug.LogError(string.Format("{0}: Cannot remove item from index {1} because it is already empty. Ignoring remove operation.", "AItemContainer", index));
				return false;
			}
			items[index] = null;
			ItemCount--;
			AItemContainer component = gameObject.GetComponent<AItemContainer>();
			if (component != null)
			{
				childrenContainers.Remove(component);
				component.UpdateNesting(null);
			}
			gameObject.SetActive(activateItem);
			this.ItemContainerDataChanged?.Invoke(this, index, -1);
			if (dropItem)
			{
				SingletonBehaviour<Inventory>.Instance.ReturnItemToWorld(gameObject, activateItem);
				this.ItemDropped?.Invoke(gameObject);
			}
			return true;
		}

		public virtual bool RemoveItem(GameObject item, bool activateItem, bool dropItem)
		{
			if (item == null)
			{
				Debug.LogError("AItemContainer: Cannot remove null item from container. Ignoring remove operation.");
				return false;
			}
			int num = Array.IndexOf(items, item);
			if (num != -1)
			{
				return RemoveItem(num, activateItem, dropItem);
			}
			Debug.LogError("AItemContainer: Cannot remove item " + item.name + " because it is not in the container. Ignoring remove operation.");
			return false;
		}

		public virtual bool MoveOrSwapItem(int from, int to)
		{
			if (!from.IsInRange(0, Capacity - 1))
			{
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Ignoring move operation.", "AItemContainer", from, Capacity));
				return false;
			}
			if (!to.IsInRange(0, Capacity - 1))
			{
				Debug.LogError(string.Format("{0}: Index {1} is out of range for container with capacity {2}. Ignoring move operation.", "AItemContainer", to, Capacity));
				return false;
			}
			if (items[from] == null)
			{
				Debug.LogError(string.Format("{0}: Cannot move item from index {1} because it is empty. Ignoring move operation.", "AItemContainer", from));
				return false;
			}
			ref GameObject reference = ref items[from];
			ref GameObject reference2 = ref items[to];
			GameObject gameObject = items[to];
			GameObject gameObject2 = items[from];
			reference = gameObject;
			reference2 = gameObject2;
			this.ItemContainerDataChanged?.Invoke(this, from, to);
			return true;
		}

		public int GetFirstFreeSlot()
		{
			for (int i = 0; i < Capacity; i++)
			{
				if (items[i] == null)
				{
					return i;
				}
			}
			return -1;
		}

		public bool Contains(GameObject item, bool recursive = true)
		{
			for (int i = 0; i < Capacity; i++)
			{
				if (items[i] == null)
				{
					continue;
				}
				if (items[i] == item)
				{
					return true;
				}
				if (recursive)
				{
					AItemContainer component = items[i].GetComponent<AItemContainer>();
					if (component != null && component.Contains(item))
					{
						return true;
					}
				}
			}
			return false;
		}

		public GameObject[] GetItemsArray(bool includingDropped)
		{
			Array.Copy(items, itemsCache, Capacity);
			return itemsCache;
		}

		public int IndexOf(GameObject item)
		{
			return Array.IndexOf(items, item);
		}

		public abstract void Clear();
	}
}
