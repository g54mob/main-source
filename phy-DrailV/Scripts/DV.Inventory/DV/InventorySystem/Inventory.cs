using System;
using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public abstract class Inventory : SingletonBehaviour<Inventory>, IRecursiveItemStorage
	{
		public delegate void InventoryStatusChangedDelegate(InventorySlotState primarySlotState, InventoryActionType primaryActionType, InventorySlotState secondarySlotState, InventoryActionType secondaryActionType);

		private HashSet<GameObject> droppedItems = new HashSet<GameObject>();

		private HashSet<GameObject> inventoryItemsExcludingDropped = new HashSet<GameObject>();

		private Dictionary<GameObject, int> lockedAndReservedMap = new Dictionary<GameObject, int>();

		private Dictionary<GameObject, Coroutine> removeItemFromWorldCoros = new Dictionary<GameObject, Coroutine>();

		private ItemContainerRegistry itemContainerRegistry;

		private readonly GameObject[] itemsCache = new GameObject[36];

		private GameObject[] equippedItems;

		private InventoryItemData[] inventoryItemData;

		private Dictionary<int, BeltSlotState> beltSlotStates = new Dictionary<int, BeltSlotState>();

		public int Capacity { get; private set; } = 36;

		public int ItemCount => inventoryItemsExcludingDropped.Count;

		public int ItemCountIncludingDropped => ItemCount + droppedItems.Count;

		public double PlayerMoney { get; private set; }

		public BeltSlotState DefaultBeltSlotState => BeltSlotState.HiddenAndEnabled;

		public ItemContainerRegistry ItemContainerRegistry => itemContainerRegistry ?? (itemContainerRegistry = new ItemContainerRegistry());

		private GameObject[] EquippedItems
		{
			get
			{
				if (equippedItems == null)
				{
					equippedItems = new GameObject[HandCapacity];
				}
				return equippedItems;
			}
		}

		private InventoryItemData[] InventoryItems
		{
			get
			{
				if (inventoryItemData == null || inventoryItemData[0] == null)
				{
					inventoryItemData = new InventoryItemData[36];
					for (int i = 0; i < 36; i++)
					{
						inventoryItemData[i] = InventoryItemData.Empty;
					}
				}
				return inventoryItemData;
			}
		}

		public int HandCapacity
		{
			get
			{
				if (!IsVREnabled())
				{
					return 1;
				}
				return 2;
			}
		}

		public event Action<double, double> MoneyChanged;

		public event InventoryStatusChangedDelegate InventoryStatusChanged;

		public GameObject[] GetItemsArray(bool includingDropped = true)
		{
			for (int i = 0; i < 36; i++)
			{
				itemsCache[i] = PeekItemAtSlot(i, includingDropped);
			}
			return itemsCache;
		}

		public bool HasItemAtSlot(int slot, bool includeDropped = true)
		{
			if (!InventoryUtils.IsValidInventoryIndex(slot))
			{
				Debug.LogError(string.Format("[Inventory] Index out of bounds: {0}. {1} returning false.", slot, "HasItemAtSlot"));
				return false;
			}
			if (InventoryItems[slot].item != null)
			{
				if (!includeDropped)
				{
					return !InventoryItems[slot].IsDropped;
				}
				return true;
			}
			return false;
		}

		public GameObject PeekItemAtSlot(int slot, bool includeDropped = true)
		{
			if (!HasItemAtSlot(slot, includeDropped))
			{
				return null;
			}
			return InventoryItems[slot].item;
		}

		private int GetReservedSlotForDroppedItem(GameObject item)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Cannot get reserved slot for null item", this);
				return -1;
			}
			for (int i = 0; i < 36; i++)
			{
				InventoryItemData inventoryItemData = InventoryItems[i];
				if (!(inventoryItemData.item != item))
				{
					if ((inventoryItemData.IsReserved || inventoryItemData.IsLocked) && inventoryItemData.IsDropped)
					{
						return i;
					}
					return -1;
				}
			}
			return -1;
		}

		public bool Contains(GameObject item, bool includeDropped = true)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Cannot check whether inventory contains null item", this);
				return false;
			}
			for (int i = 0; i < 36; i++)
			{
				InventoryItemData inventoryItemData = InventoryItems[i];
				if ((!inventoryItemData.IsDropped || includeDropped) && inventoryItemData.item == item)
				{
					return true;
				}
			}
			return false;
		}

		public GameObject GetItemByName(string prefabName, bool partialNameCheck = true, bool includeDropped = true)
		{
			for (int i = 0; i < 36; i++)
			{
				InventoryItemData inventoryItemData = InventoryItems[i];
				if (inventoryItemData != null && !(inventoryItemData.item == null) && (partialNameCheck ? inventoryItemData.item.name.Contains(prefabName) : (inventoryItemData.item.name == prefabName)) && (!inventoryItemData.IsDropped || includeDropped))
				{
					return inventoryItemData.item;
				}
			}
			return null;
		}

		public int IndexOf(GameObject item)
		{
			if (item == null)
			{
				return -1;
			}
			for (int i = 0; i < 36; i++)
			{
				if (InventoryItems[i].item == item)
				{
					return i;
				}
			}
			return -1;
		}

		public bool HasFreeSlots()
		{
			return ItemCountIncludingDropped < 36;
		}

		public bool IsSlotEmpty(int slot)
		{
			return InventoryItems[slot].item == null;
		}

		public int GetFirstFreeSlot()
		{
			for (int i = 0; i < 36; i++)
			{
				if (InventoryItems[i].item == null)
				{
					return i;
				}
			}
			return -1;
		}

		public int GetLastFreeSlot()
		{
			for (int num = 35; num >= 0; num--)
			{
				if (InventoryItems[num].item == null)
				{
					return num;
				}
			}
			return -1;
		}

		public int GetFirstFreeHotbarSlot()
		{
			for (int i = 0; i < 12; i++)
			{
				if (InventoryItems[i].item == null)
				{
					return i;
				}
			}
			return -1;
		}

		public int GetFirstFreeBackpackSlot()
		{
			for (int i = 12; i < 36; i++)
			{
				if (InventoryItems[i].item == null)
				{
					return i;
				}
			}
			return -1;
		}

		public bool SetMoney(double amount)
		{
			if (amount < 0.0)
			{
				Debug.LogWarning($"[Inventory] Tried to set negative cash amount {amount}, aborting", this);
				return false;
			}
			double playerMoney = PlayerMoney;
			PlayerMoney = amount;
			this.MoneyChanged?.Invoke(playerMoney, PlayerMoney);
			return true;
		}

		public bool AddMoney(double amount)
		{
			if (amount < 0.0)
			{
				Debug.LogWarning($"[Inventory] Tried to add negative cash amount {amount}, aborting", this);
				return false;
			}
			double playerMoney = PlayerMoney;
			PlayerMoney += amount;
			this.MoneyChanged?.Invoke(playerMoney, PlayerMoney);
			return true;
		}

		public bool RemoveMoney(double amount)
		{
			if (amount < 0.0)
			{
				Debug.LogWarning($"[Inventory] Tried to remove negative cash amount {amount}, aborting", this);
				return false;
			}
			if (amount > PlayerMoney)
			{
				Debug.LogWarning("[Inventory] Not enough cash in wallet, aborting", this);
				return false;
			}
			double playerMoney = PlayerMoney;
			PlayerMoney -= amount;
			this.MoneyChanged?.Invoke(playerMoney, PlayerMoney);
			return true;
		}

		public bool IsDestroyedOnAddedToInventory(GameObject item)
		{
			return ((item != null) ? item.GetComponent<IMoney>() : null)?.ShouldDestroyOnUse ?? false;
		}

		private int AddItemToInventory(GameObject item, bool fireEvent, bool addAsDropped)
		{
			int reservedSlotForDroppedItem = GetReservedSlotForDroppedItem(item);
			int num = ((reservedSlotForDroppedItem < 0) ? GetFirstFreeSlot() : reservedSlotForDroppedItem);
			if (num < 0)
			{
				if (!IsDestroyedOnAddedToInventory(item))
				{
					Debug.LogWarning("[Inventory] Inventory full. Can't add more items!");
					return -1;
				}
				num = 0;
			}
			return AddItemToInventory(item, num, fireEvent, addAsDropped);
		}

		public int AddItemToInventory(GameObject item, bool addAsDropped = false)
		{
			int equipSlotForItem = GetEquipSlotForItem(item);
			if (equipSlotForItem < 0)
			{
				return AddItemToInventory(item, fireEvent: true, addAsDropped);
			}
			if (!addAsDropped)
			{
				return UnequipItem(addToInventory: true, equipSlotForItem);
			}
			Debug.LogError("[Inventory] Can't add item '" + item.name + "' as dropped, it's equipped", item);
			return -1;
		}

		private int AddItemToInventory(GameObject item, int slot, bool fireEvent, bool addAsDropped = false)
		{
			if (item == null)
			{
				Debug.LogWarning("[Inventory] Trying to add null item to inventory, aborting");
				return -1;
			}
			if (!InventoryUtils.IsValidInventoryIndex(slot))
			{
				Debug.LogError($"[Inventory] Can't add item '{item}' to inventory slot {slot}, index out range", item);
				return -1;
			}
			if (Contains(item, includeDropped: false))
			{
				Debug.LogWarning($"[Inventory] Can't add item '{item}', it's already in inventory", item);
				return -1;
			}
			InventoryItemData inventoryItemData = InventoryItems[slot];
			if (inventoryItemData.item != null && inventoryItemData.item != item && !IsDestroyedOnAddedToInventory(item))
			{
				Debug.LogWarning($"[Inventory] Cannot add '{item}' to slot {slot}. It is already in use.", item);
				return -1;
			}
			if (IsGrabbed(item))
			{
				ForceEndInteraction(item);
			}
			IMoney component = item.GetComponent<IMoney>();
			if (component != null && component.ShouldDestroyOnUse)
			{
				if (component.Amount > double.Epsilon)
				{
					AddMoney(component.TrySpend(component.Amount));
				}
				InventoryItemData inventoryItemData2 = InventoryItems[slot];
				if (inventoryItemData2.item != null && inventoryItemData2.item == item)
				{
					InventoryItems[slot] = InventoryItemData.Empty;
				}
				InventorySlotState primarySlotState = new InventorySlotState(-1, item, InventoryItemState.Destroyed, isLocked: false, isReserved: false, -1);
				this.InventoryStatusChanged?.Invoke(primarySlotState, InventoryActionType.Add | InventoryActionType.Destroy, InventorySlotState.Empty, InventoryActionType.None);
				droppedItems.Remove(item);
				DestroyItem(item);
				return 0;
			}
			int reservedSlotForDroppedItem = GetReservedSlotForDroppedItem(item);
			if (reservedSlotForDroppedItem >= 0)
			{
				slot = reservedSlotForDroppedItem;
				InventoryItems[slot].ToggleDropped(addAsDropped);
				bool shouldReserve = IsEssential(item);
				InventoryItems[slot].ToggleReserve(shouldReserve);
			}
			else
			{
				InventoryItemData inventoryItemData3 = new InventoryItemData(item, IsEssential(item), addAsDropped);
				InventoryItems[slot] = inventoryItemData3;
			}
			InventoryItemState inventoryItemState = ResolveItemStateOnAdd(slot, addAsDropped, item);
			switch (inventoryItemState)
			{
			case InventoryItemState.Disabled:
				RemoveItemFromWorld(item);
				inventoryItemsExcludingDropped.Add(item);
				droppedItems.Remove(item);
				break;
			case InventoryItemState.Enabled:
				inventoryItemsExcludingDropped.Add(item);
				droppedItems.Remove(item);
				break;
			case InventoryItemState.Dropped:
				inventoryItemsExcludingDropped.Remove(item);
				droppedItems.Add(item);
				break;
			}
			UpdateLockedAndReservedMap(InventoryItems[slot], slot);
			InventoryItemData inventoryItemData4 = InventoryItems[slot];
			InventorySlotState primarySlotState2 = new InventorySlotState(slot, item, inventoryItemState, inventoryItemData4.IsLocked, inventoryItemData4.IsReserved, -1);
			InventoryActionType inventoryActionType = ((!addAsDropped) ? InventoryActionType.Add : InventoryActionType.Reserve);
			if (inventoryItemData4.IsReserved)
			{
				inventoryActionType |= InventoryActionType.Reserve;
			}
			if (fireEvent)
			{
				this.InventoryStatusChanged?.Invoke(primarySlotState2, inventoryActionType, InventorySlotState.Empty, InventoryActionType.None);
			}
			return slot;
		}

		public int AddItemToInventory(GameObject item, int slot, bool addAsDropped = false)
		{
			int equipSlotForItem = GetEquipSlotForItem(item);
			if (equipSlotForItem < 0)
			{
				return AddItemToInventory(item, slot, fireEvent: true, addAsDropped);
			}
			if (!addAsDropped)
			{
				return UnequipItem(addToInventory: true, equipSlotForItem);
			}
			Debug.LogError("[Inventory] Can't add item '" + item.name + "' as dropped, it's equipped", item);
			return -1;
		}

		public GameObject DropItemFromHandsOrInventory(GameObject item)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Trying to drop null item from inventory, aborting.", this);
				return null;
			}
			int equipSlotForItem = GetEquipSlotForItem(item);
			if (equipSlotForItem >= 0)
			{
				UnequipItem(addToInventory: false, equipSlotForItem);
				var (gameObject, equippedSlot) = GetOtherHandItemAndEquipSlot(equipSlotForItem);
				if (gameObject != null && gameObject == item)
				{
					UnequipItem(addToInventory: false, equippedSlot);
				}
				return item;
			}
			int num = IndexOf(item);
			if (!InventoryUtils.IsValidInventoryIndex(num))
			{
				return null;
			}
			return DropItemFromHandsOrInventory(num);
		}

		public GameObject DropItemFromHandsOrInventory(int slot, bool keepInactive = false)
		{
			if (!InventoryUtils.IsValidInventoryIndex(slot))
			{
				Debug.LogError($"[Inventory] Slot index {slot} must be a positive int less than current inventory capacity {36}", this);
				return null;
			}
			InventoryItemData inventoryItemData = InventoryItems[slot];
			GameObject item = inventoryItemData.item;
			int num = ((item != null) ? GetEquipSlotForItem(item) : (-1));
			bool flag = num >= 0;
			if (inventoryItemData.item == null || (inventoryItemData.IsDropped && !flag))
			{
				Debug.Log($"[Inventory] Slot {slot} is empty, can't drop item", this);
				return null;
			}
			if (flag)
			{
				UnequipItem(addToInventory: false, num);
				var (gameObject, equippedSlot) = GetOtherHandItemAndEquipSlot(num);
				if (gameObject != null && gameObject == item)
				{
					UnequipItem(addToInventory: false, equippedSlot);
				}
				return item;
			}
			bool isLocked = inventoryItemData.IsLocked;
			bool isReserved = inventoryItemData.IsReserved;
			bool num2 = isLocked || isReserved;
			if (num2)
			{
				inventoryItemData.ToggleDropped(shouldDrop: true);
				droppedItems.Add(item);
			}
			else
			{
				InventoryItems[slot] = InventoryItemData.Empty;
			}
			UpdateLockedAndReservedMap(InventoryItems[slot], slot);
			if (!item.activeInHierarchy)
			{
				if (!keepInactive)
				{
					ReturnItemToWorld(item);
				}
			}
			else if (keepInactive)
			{
				item.SetActive(value: false);
			}
			inventoryItemsExcludingDropped.Remove(item);
			InventoryItemState itemState = (num2 ? InventoryItemState.Dropped : InventoryItemState.None);
			InventorySlotState primarySlotState = new InventorySlotState(slot, item, itemState, isLocked, isReserved, -1);
			InventoryActionType inventoryActionType = InventoryActionType.Drop;
			if (!num2)
			{
				inventoryActionType |= InventoryActionType.Purge;
			}
			else if (!isReserved)
			{
				inventoryActionType |= InventoryActionType.Reserve;
			}
			this.InventoryStatusChanged?.Invoke(primarySlotState, inventoryActionType, InventorySlotState.Empty, InventoryActionType.None);
			return item;
		}

		private void RemoveItemFromWorld(GameObject item)
		{
			if (IsVREnabled())
			{
				if (removeItemFromWorldCoros.TryGetValue(item, out var value))
				{
					StopCoroutine(value);
				}
				removeItemFromWorldCoros[item] = StartCoroutine(DelayedFinalizeRemoveItemFromWorld(item));
			}
			else
			{
				FinalizeRemoveItemFromWorld(item);
			}
		}

		private IEnumerator DelayedFinalizeRemoveItemFromWorld(GameObject item)
		{
			yield return new WaitForEndOfFrame();
			FinalizeRemoveItemFromWorld(item);
			removeItemFromWorldCoros.Remove(item);
		}

		private void FinalizeRemoveItemFromWorld(GameObject item)
		{
			AssignInventoryLayer(item);
			item.transform.SetParent(null, worldPositionStays: true);
			Rigidbody component = item.GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.collisionDetectionMode = CollisionDetectionMode.Discrete;
				component.isKinematic = true;
			}
			else
			{
				Debug.LogWarning("[Inventory] Couldn't find rigidbody on '" + item.name + "' when trying to restore physics state", item);
			}
			item.SetActive(value: false);
		}

		public void DestroyItem(GameObject item)
		{
			if (IsVREnabled())
			{
				StartCoroutine(DelayedDestroy(item));
			}
			else
			{
				UnityEngine.Object.Destroy(item);
			}
		}

		private IEnumerator DelayedDestroy(GameObject item)
		{
			yield return null;
			UnityEngine.Object.Destroy(item);
		}

		public void ReturnItemToWorld(GameObject item, bool activate = true)
		{
			Rigidbody component = item.GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.isKinematic = false;
			}
			else
			{
				Debug.LogWarning("[Inventory] Couldn't find rigidbody on '" + item.name + "' when returning to world", item);
			}
			AssignWorldItemLayer(item);
			if (activate)
			{
				Transform playerTransform = GetPlayerTransform();
				if ((bool)playerTransform)
				{
					item.transform.position = playerTransform.position;
				}
				item.SetActive(value: true);
			}
			if (removeItemFromWorldCoros.TryGetValue(item, out var value))
			{
				StopCoroutine(value);
				removeItemFromWorldCoros.Remove(item);
			}
		}

		public bool MoveItemFromTo(int originSlot, int targetSlot, bool logOccupationError = true)
		{
			if (originSlot == targetSlot || !InventoryUtils.IsValidInventoryIndex(originSlot) || !InventoryUtils.IsValidInventoryIndex(targetSlot))
			{
				Debug.LogError($"[Inventory] Cannot move item from slot {originSlot} to {targetSlot}. Origin and target indices must be different and valid.", this);
				return false;
			}
			if (!HasItemAtSlot(originSlot) || HasItemAtSlot(targetSlot))
			{
				if (logOccupationError)
				{
					Debug.LogError($"[Inventory] Cannot move item from slot {originSlot} to {targetSlot}. Origin slot must contain an item ({HasItemAtSlot(originSlot)}) while target must not ({!HasItemAtSlot(targetSlot)}).", this);
				}
				return false;
			}
			if (GetSlotLockState(originSlot))
			{
				Debug.LogError($"[Inventory] Cannot move item from slot {originSlot} to {targetSlot}. Origin slot is locked.", this);
				return false;
			}
			InventoryItemData[] inventoryItems = InventoryItems;
			InventoryItemData[] inventoryItems2 = InventoryItems;
			InventoryItemData inventoryItemData = InventoryItems[originSlot];
			InventoryItemData inventoryItemData2 = InventoryItems[targetSlot];
			inventoryItems[targetSlot] = inventoryItemData;
			inventoryItems2[originSlot] = inventoryItemData2;
			UpdateLockedAndReservedMap(InventoryItems[targetSlot], targetSlot);
			GameObject item = InventoryItems[targetSlot].item;
			InventoryItemState itemState = ((!UpdateItemActivityOnMoveOrSwap(item, targetSlot)) ? InventoryItemState.Disabled : InventoryItemState.Enabled);
			bool flag = IsEssential(item);
			InventorySlotState secondarySlotState = new InventorySlotState(targetSlot, item, itemState, isLocked: false, flag, -1);
			InventorySlotState primarySlotState = new InventorySlotState(originSlot, null, InventoryItemState.None, isLocked: false, isReserved: false, -1);
			InventoryActionType inventoryActionType = InventoryActionType.Move;
			if (flag)
			{
				inventoryActionType |= InventoryActionType.Reserve;
			}
			this.InventoryStatusChanged?.Invoke(primarySlotState, InventoryActionType.Purge, secondarySlotState, inventoryActionType);
			return true;
		}

		private bool UpdateItemActivityOnMoveOrSwap(GameObject item, int slot)
		{
			if (item == null)
			{
				return false;
			}
			bool activeInHierarchy = item.activeInHierarchy;
			bool flag = ResolveItemStateOnAdd(slot, isDropped: false, item) == InventoryItemState.Enabled;
			if (activeInHierarchy == flag)
			{
				if (!activeInHierarchy || !removeItemFromWorldCoros.TryGetValue(item, out var value))
				{
					return flag;
				}
				StopCoroutine(value);
				removeItemFromWorldCoros.Remove(item);
				return true;
			}
			if (flag)
			{
				ReturnItemToWorld(item);
			}
			else
			{
				RemoveItemFromWorld(item);
			}
			return flag;
		}

		public bool SwapItems(int originSlot, int targetSlot)
		{
			if (originSlot == targetSlot || !InventoryUtils.IsValidInventoryIndex(originSlot) || !InventoryUtils.IsValidInventoryIndex(targetSlot))
			{
				Debug.LogError($"[Inventory] Cannot swap items from slot {originSlot} to {targetSlot}. Origin and target indices must be different and valid.", this);
				return false;
			}
			if (!HasItemAtSlot(originSlot) || !HasItemAtSlot(targetSlot))
			{
				Debug.LogError($"[Inventory] Cannot swap items from slot {originSlot} to {targetSlot}. Origin and target slots must contain items.", this);
				return false;
			}
			if (GetSlotLockState(originSlot) || GetSlotLockState(targetSlot))
			{
				Debug.LogError($"[Inventory] Cannot swap items from slot {originSlot} to {targetSlot}. Origin and target slots are locked.", this);
				return false;
			}
			InventoryItemData[] inventoryItems = InventoryItems;
			InventoryItemData[] inventoryItems2 = InventoryItems;
			InventoryItemData inventoryItemData = InventoryItems[targetSlot];
			InventoryItemData inventoryItemData2 = InventoryItems[originSlot];
			inventoryItems[originSlot] = inventoryItemData;
			inventoryItems2[targetSlot] = inventoryItemData2;
			GameObject item = InventoryItems[originSlot].item;
			GameObject item2 = InventoryItems[targetSlot].item;
			bool num = UpdateItemActivityOnMoveOrSwap(item, originSlot);
			bool flag = UpdateItemActivityOnMoveOrSwap(item2, targetSlot);
			InventoryItemState itemState = ((!num) ? InventoryItemState.Disabled : InventoryItemState.Enabled);
			InventoryItemState itemState2 = ((!flag) ? InventoryItemState.Disabled : InventoryItemState.Enabled);
			bool flag2 = IsEssential(item);
			bool flag3 = IsEssential(item2);
			InventorySlotState primarySlotState = new InventorySlotState(originSlot, item, itemState, isLocked: false, flag2, -1);
			InventorySlotState secondarySlotState = new InventorySlotState(targetSlot, item2, itemState2, isLocked: false, flag3, -1);
			InventoryActionType inventoryActionType = InventoryActionType.Swap;
			InventoryActionType inventoryActionType2 = InventoryActionType.Swap;
			if (flag2 != flag3)
			{
				inventoryActionType = (InventoryActionType)((int)inventoryActionType | (flag2 ? 512 : 0));
				inventoryActionType2 = (InventoryActionType)((int)inventoryActionType2 | (flag3 ? 512 : 0));
			}
			this.InventoryStatusChanged?.Invoke(primarySlotState, inventoryActionType, secondarySlotState, inventoryActionType2);
			return true;
		}

		public bool ToggleSlotLock(int slot)
		{
			if (!InventoryUtils.IsValidInventoryIndex(slot))
			{
				Debug.LogError($"[Inventory] Cannot toggle slot lock for slot {slot}. Index must be valid.", this);
				return false;
			}
			InventoryItemData inventoryItemData = InventoryItems[slot];
			if (inventoryItemData == null)
			{
				Debug.LogError($"[Inventory] Cannot toggle slot lock for slot {slot}. Slot must contain an item.", this);
				return false;
			}
			InventoryItems[slot].ToggleLock(!inventoryItemData.IsLocked);
			GameObject item = inventoryItemData.item;
			bool flag = false;
			GameObject[] array = EquippedItems;
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject == null) && !(item != gameObject))
				{
					flag = true;
					break;
				}
			}
			bool num = inventoryItemData.IsDropped && !flag && !IsEssential(inventoryItemData.item);
			bool isReserved = inventoryItemData.IsReserved;
			if (num)
			{
				inventoryItemData.ToggleReserve(shouldReserve: false);
				droppedItems.Remove(item);
				InventoryItems[slot] = InventoryItemData.Empty;
			}
			UpdateLockedAndReservedMap(inventoryItemData, slot);
			InventoryItemState itemState = ((!num) ? ((!item.activeInHierarchy) ? InventoryItemState.Disabled : InventoryItemState.Enabled) : InventoryItemState.None);
			InventoryActionType inventoryActionType = (inventoryItemData.IsLocked ? InventoryActionType.Lock : InventoryActionType.Unlock);
			if (num)
			{
				inventoryActionType |= InventoryActionType.Purge;
				if (isReserved)
				{
					inventoryActionType |= InventoryActionType.Unreserve;
				}
			}
			item = inventoryItemData.item;
			InventorySlotState primarySlotState = new InventorySlotState(slot, item, itemState, inventoryItemData.IsLocked, inventoryItemData.IsReserved, -1);
			this.InventoryStatusChanged?.Invoke(primarySlotState, inventoryActionType, InventorySlotState.Empty, InventoryActionType.None);
			return true;
		}

		public int EquipItem(GameObject item, int desiredEquipSlot)
		{
			return EquipItem(item, -1, desiredEquipSlot);
		}

		public int EquipItem(GameObject item, int desiredReservedSlot, int desiredEquipSlot)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Cannot equip null item.", this);
				return -1;
			}
			int equipSlotForItem = GetEquipSlotForItem(item);
			if (equipSlotForItem == desiredEquipSlot)
			{
				return -1;
			}
			InventoryActionType unequipAction = InventoryActionType.None;
			InventorySlotState unequipSlotState = InventorySlotState.Empty;
			bool flag = IsTwoHanded(item);
			if (equipSlotForItem >= 0 && !flag)
			{
				UnequipItem(addToInventory: false, item, fireEvent: false, out unequipAction, out unequipSlotState);
			}
			if (item == GetEquippedItemAtSlot(desiredEquipSlot))
			{
				return -1;
			}
			int num = IndexOf(item);
			bool num2 = InventoryUtils.IsValidInventoryIndex(num);
			bool flag2 = false;
			bool flag3 = false;
			if (num2)
			{
				InventoryItemData inventoryItemData = InventoryItems[num];
				flag2 = inventoryItemData.IsDropped;
				flag3 = inventoryItemData.IsReserved;
				if (!flag2)
				{
					inventoryItemData.ToggleDropped(shouldDrop: true);
					inventoryItemData.ToggleReserve(shouldReserve: true);
					UpdateLockedAndReservedMap(inventoryItemData, num);
					droppedItems.Add(item);
					inventoryItemsExcludingDropped.Remove(item);
					ReturnItemToWorld(item);
				}
			}
			else
			{
				int num3 = ((InventoryUtils.IsValidInventoryIndex(desiredReservedSlot) && InventoryItems[desiredReservedSlot].item == null) ? desiredReservedSlot : GetFirstFreeSlot());
				if (InventoryUtils.IsValidInventoryIndex(num3))
				{
					num = num3;
					InventoryItemData inventoryItemData2 = new InventoryItemData(item, isLocked: false, isReserved: true, isDropped: true);
					this.inventoryItemData[num] = inventoryItemData2;
					UpdateLockedAndReservedMap(inventoryItemData2, num);
					droppedItems.Add(item);
				}
			}
			EquippedItems[desiredEquipSlot] = item;
			InventoryItemState itemState = (num2 ? InventoryItemState.Dropped : InventoryItemState.None);
			bool isLocked = num2 && InventoryItems[num].IsLocked;
			bool flag4 = num2 && InventoryItems[num].IsReserved;
			InventorySlotState primarySlotState = new InventorySlotState(num, item, itemState, isLocked, flag4, desiredEquipSlot);
			InventoryActionType inventoryActionType = InventoryActionType.Equip;
			if (!flag2 && !flag3 && flag4)
			{
				inventoryActionType |= InventoryActionType.Reserve;
			}
			this.InventoryStatusChanged?.Invoke(primarySlotState, inventoryActionType, unequipSlotState, unequipAction);
			return num;
		}

		private int UnequipItem(bool addToInventory, GameObject item, bool fireEvent, out InventoryActionType unequipAction, out InventorySlotState unequipSlotState)
		{
			unequipAction = InventoryActionType.None;
			unequipSlotState = InventorySlotState.Empty;
			int equipSlotForItem = GetEquipSlotForItem(item);
			if (equipSlotForItem < 0)
			{
				return -1;
			}
			return UnequipItem(addToInventory, equipSlotForItem, fireEvent, out unequipAction, out unequipSlotState);
		}

		private int UnequipItem(bool addToInventory, int equippedSlot, bool fireEvent, out InventoryActionType unequipActions, out InventorySlotState unequipSlotState)
		{
			unequipActions = InventoryActionType.None;
			unequipSlotState = InventorySlotState.Empty;
			GameObject gameObject = EquippedItems[equippedSlot];
			if (gameObject == null)
			{
				return -1;
			}
			(GameObject otherItem, int otherEquipSlot) otherHandItemAndEquipSlot = GetOtherHandItemAndEquipSlot(equippedSlot);
			GameObject item = otherHandItemAndEquipSlot.otherItem;
			int item2 = otherHandItemAndEquipSlot.otherEquipSlot;
			bool flag = item == gameObject;
			EquippedItems[equippedSlot] = null;
			int num = FindReservedSlotForDroppedItem(gameObject);
			if (num < 0 && addToInventory)
			{
				num = GetFirstFreeSlot();
			}
			bool num2 = num >= 0;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			if (num2)
			{
				if (addToInventory)
				{
					flag3 = AddItemToInventory(gameObject, fireEvent: false, addAsDropped: false) >= 0;
					if (flag3 && flag)
					{
						EquippedItems[item2] = null;
					}
				}
				else if (!flag)
				{
					bool isLocked = InventoryItems[num].IsLocked;
					bool flag6 = IsEssential(gameObject);
					flag2 = !isLocked && !flag6;
					flag5 = InventoryUtils.IsValidInventoryIndex(num) && !isLocked && !flag6;
					inventoryItemsExcludingDropped.Remove(gameObject);
				}
			}
			else if (addToInventory && IsDestroyedOnAddedToInventory(gameObject))
			{
				AddItemToInventory(gameObject, fireEvent: false, addAsDropped: false);
				flag3 = (flag4 = true);
			}
			if (flag2)
			{
				InventoryItemData inventoryItemData = InventoryItems[num];
				lockedAndReservedMap.Remove(inventoryItemData.item);
				droppedItems.Remove(gameObject);
				this.inventoryItemData[num] = InventoryItemData.Empty;
			}
			InventoryItemState itemState = ((!flag2 && flag3) ? (flag4 ? InventoryItemState.Destroyed : ((!IsValidVRBeltIndex(num) || !IsPlaceableInBelt(gameObject)) ? InventoryItemState.Disabled : InventoryItemState.Enabled)) : InventoryItemState.None);
			bool isLocked2 = num >= 0 && InventoryItems[num].IsLocked;
			bool isReserved = num >= 0 && InventoryItems[num].IsReserved;
			unequipSlotState = new InventorySlotState(num, gameObject, itemState, isLocked2, isReserved, equippedSlot);
			unequipActions = InventoryActionType.Unequip;
			if (flag3)
			{
				unequipActions |= InventoryActionType.Add;
			}
			if (flag4)
			{
				unequipActions |= InventoryActionType.Destroy;
			}
			if (flag5)
			{
				unequipActions |= InventoryActionType.Unreserve;
			}
			if (flag2)
			{
				unequipActions |= InventoryActionType.Purge;
			}
			if (fireEvent)
			{
				this.InventoryStatusChanged?.Invoke(unequipSlotState, unequipActions, InventorySlotState.Empty, InventoryActionType.None);
			}
			return num;
		}

		public int UnequipItem(bool addToInventory, int equippedSlot)
		{
			InventoryActionType unequipActions;
			InventorySlotState unequipSlotState;
			return UnequipItem(addToInventory, equippedSlot, fireEvent: true, out unequipActions, out unequipSlotState);
		}

		public int FindReservedSlotForDroppedItem(GameObject item)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Cannot find reserved slot for dropped item. Item is null.", this);
				return -1;
			}
			if (!lockedAndReservedMap.TryGetValue(item, out var value))
			{
				return -1;
			}
			InventoryItemData inventoryItemData = InventoryItems[value];
			if (inventoryItemData.item != item)
			{
				Debug.LogError($"[Inventory] Item mismatch at slot {value}. Expected {item.name} but got {inventoryItemData.item.name}. This should not happen.", this);
				return -1;
			}
			if (inventoryItemData.IsDropped)
			{
				return value;
			}
			Debug.LogError("[Inventory] Cannot find reserved slot for item - Item is not dropped.", this);
			return -1;
		}

		private void UpdateLockedAndReservedMap(InventoryItemData data, int slot)
		{
			if (!(data.item == null))
			{
				if (data.IsLocked || data.IsReserved)
				{
					lockedAndReservedMap[data.item] = slot;
				}
				else
				{
					lockedAndReservedMap.Remove(data.item);
				}
			}
		}

		public bool GetSlotLockState(int slot)
		{
			if (InventoryUtils.IsValidInventoryIndex(slot))
			{
				return InventoryItems[slot].IsLocked;
			}
			Debug.LogError($"[Inventory] Cannot get slot lock state for slot {slot}. Index must be valid.", this);
			return false;
		}

		public bool GetSlotReservedState(int slot)
		{
			if (InventoryUtils.IsValidInventoryIndex(slot))
			{
				return InventoryItems[slot].IsReserved;
			}
			Debug.LogError($"[Inventory] Cannot get reserved state for slot {slot}. Index must be valid.", this);
			return false;
		}

		public bool GetSlotDroppedState(int slot)
		{
			if (InventoryUtils.IsValidInventoryIndex(slot))
			{
				return InventoryItems[slot].IsDropped;
			}
			Debug.LogError($"[Inventory] Cannot get dropped state for slot {slot}. Index must be valid.", this);
			return false;
		}

		public bool PurgeFromInventory(GameObject item)
		{
			if (item == null)
			{
				Debug.LogError("[Inventory] Cannot purge item from inventory. Item is null.", this);
				return false;
			}
			if (!lockedAndReservedMap.TryGetValue(item, out var value))
			{
				return false;
			}
			if (InventoryItems[value].IsDropped)
			{
				droppedItems.Remove(item);
			}
			else
			{
				inventoryItemsExcludingDropped.Remove(item);
			}
			InventoryItems[value] = InventoryItemData.Empty;
			lockedAndReservedMap.Remove(item);
			InventorySlotState primarySlotState = new InventorySlotState(value, item, InventoryItemState.None, isLocked: false, isReserved: false, -1);
			this.InventoryStatusChanged?.Invoke(primarySlotState, InventoryActionType.Purge, InventorySlotState.Empty, InventoryActionType.None);
			return true;
		}

		public bool CanAddItem(GameObject item)
		{
			if (item != null)
			{
				if (!HasFreeSlots())
				{
					return FindReservedSlotForDroppedItem(item) >= 0;
				}
				return true;
			}
			return false;
		}

		public GameObject GetEquippedItemAtSlot(int slot)
		{
			if (slot.IsInRange(0, EquippedItems.Length - 1))
			{
				return EquippedItems[slot];
			}
			return null;
		}

		public int GetEquipSlotForItem(GameObject item)
		{
			return Array.IndexOf(EquippedItems, item);
		}

		private InventoryItemState ResolveItemStateOnAdd(int slot, bool isDropped, GameObject item)
		{
			if (!IsValidItem(item))
			{
				Debug.LogError("[Inventory] Could not resolve item add approach. Item gameObject is null or isn't a valid item.");
				return InventoryItemState.None;
			}
			if (isDropped)
			{
				return InventoryItemState.Dropped;
			}
			if (!IsValidVRBeltIndex(slot) || !IsPlaceableInBelt(item))
			{
				return InventoryItemState.Disabled;
			}
			return InventoryItemState.Enabled;
		}

		public bool IsValidVRBeltIndex(int index)
		{
			if (IsVREnabled())
			{
				return index.IsInRange(33, 35);
			}
			return false;
		}

		public int BeltIndexFromInventoryIndex(int slot)
		{
			if (!IsValidVRBeltIndex(slot))
			{
				return -1;
			}
			return slot - 33;
		}

		public int InventoryIndexFromBeltIndex(int slot)
		{
			if (!slot.IsInRange(0, 2))
			{
				return -1;
			}
			return slot + 33;
		}

		public (GameObject otherItem, int otherEquipSlot) GetOtherHandItemAndEquipSlot(int currentHand)
		{
			if (HandCapacity == 1)
			{
				return (otherItem: null, otherEquipSlot: -1);
			}
			int num = 1 - currentHand;
			return (otherItem: EquippedItems[num], otherEquipSlot: num);
		}

		public void SetBeltVisibilityState(int slot, BeltSlotState desiredState)
		{
			if (!IsValidVRBeltIndex(slot))
			{
				return;
			}
			if (!beltSlotStates.TryGetValue(slot, out var value))
			{
				value = DefaultBeltSlotState;
			}
			if (value != desiredState)
			{
				beltSlotStates[slot] = desiredState;
				InventoryItemState itemState = ((InventoryItems[slot].item != null) ? (GetSlotDroppedState(slot) ? InventoryItemState.Dropped : ((desiredState != BeltSlotState.VisibleAndEnabled) ? InventoryItemState.Disabled : InventoryItemState.Enabled)) : InventoryItemState.None);
				InventoryActionType primaryActionType;
				switch (desiredState)
				{
				case BeltSlotState.VisibleAndEnabled:
					primaryActionType = InventoryActionType.BeltVisible | InventoryActionType.BeltEnabled;
					break;
				case BeltSlotState.VisibleAndDisabled:
					primaryActionType = InventoryActionType.BeltVisible | InventoryActionType.BeltDisabled;
					break;
				case BeltSlotState.HiddenAndEnabled:
					primaryActionType = InventoryActionType.BeltHidden | InventoryActionType.BeltEnabled;
					break;
				case BeltSlotState.HiddenAndDisabled:
					primaryActionType = InventoryActionType.BeltHidden | InventoryActionType.BeltDisabled;
					break;
				default:
					Debug.LogError($"[Inventory] Could not resolve belt slot state {desiredState}. Returning {InventoryActionType.None}");
					primaryActionType = InventoryActionType.None;
					break;
				}
				InventorySlotState primarySlotState = new InventorySlotState(slot, InventoryItems[slot].item, itemState, GetSlotLockState(slot), GetSlotReservedState(slot), -1);
				this.InventoryStatusChanged?.Invoke(primarySlotState, primaryActionType, default(InventorySlotState), InventoryActionType.None);
			}
		}

		public (int beltSlotIndex, BeltSlotState beltSlotState) GetBeltSlotIndexAndState(int slot)
		{
			int num = BeltIndexFromInventoryIndex(slot);
			if (num < 0)
			{
				return (beltSlotIndex: -1, beltSlotState: BeltSlotState.InvalidSlot);
			}
			if (!beltSlotStates.TryGetValue(slot, out var value))
			{
				value = DefaultBeltSlotState;
			}
			return (beltSlotIndex: num, beltSlotState: value);
		}

		public abstract bool IsVREnabled();

		protected abstract Transform GetPlayerTransform();

		protected abstract bool IsEssential(GameObject item);

		protected abstract bool IsGrabbed(GameObject item);

		protected abstract bool IsPlaceableInBelt(GameObject item);

		protected abstract void ForceEndInteraction(GameObject item);

		protected abstract void AssignInventoryLayer(GameObject item);

		protected abstract void AssignWorldItemLayer(GameObject item);

		protected abstract bool IsValidItem(GameObject item);

		protected abstract bool IsTwoHanded(GameObject item);
	}
}
