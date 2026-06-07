using System;
using System.Collections;
using System.Collections.Generic;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI.Inventory
{
	public class InventoryUIController : AInventoryUIController
	{
		[NullCheck]
		public GameObject containerGO;

		[NullCheck]
		public AInventoryProvider provider;

		[NullCheck]
		public TooltipHandler tooltipHandler;

		[NullCheck]
		public ItemContainerProvider itemContainerProvider;

		[NullCheck]
		public InventoryTitleHandler titleHandler;

		public InventorySlotDisplayData draggedData;

		protected List<DataAsIndexAndController> handLinkedParams = new List<DataAsIndexAndController>();

		protected bool disableDragging;

		private bool hasForcedDragData;

		private bool setupFinished;

		public override bool IsOpen => containerGO.activeSelf;

		protected override void Awake()
		{
			base.Awake();
			disableDragging = provider.IsVREnabled;
			base.ItemGetterAllowed = provider.IsEssentialItemsGetterAllowed;
			provider.IsEssentialItemsGetterAllowedChanged += OnIsEssentialItemsGetterAllowedChanged;
			provider.Inventory.ItemContainerRegistry.ActiveContainerChanged += OnActiveContainerChanged;
			for (int i = 0; i < GetHandCapacity(); i++)
			{
				handLinkedParams.Add(null);
			}
		}

		private void OnActiveContainerChanged(AItemContainer activeContainer, AItemContainer _)
		{
			bool flag = activeContainer != null;
			backpackController.transform.parent.gameObject.SetActive(!flag);
			itemContainerController.transform.parent.gameObject.SetActive(flag);
			titleHandler.SetTitle(flag ? activeContainer.ContainerNameLocalized : string.Empty);
		}

		private void OnEnable()
		{
			if (!setupFinished)
			{
				StartCoroutine(InitCoro());
			}
		}

		protected void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private IEnumerator InitCoro()
		{
			while (!provider.IsGameInitialized)
			{
				yield return null;
			}
			itemContainerProvider.Initialize(provider);
			InitializeInventory(backpackController);
			InitializeInventory(hotbarController);
			InitializeInventory(handController);
			InitializeInventory(itemContainerController);
			for (int i = 0; i < GetHandCapacity(); i++)
			{
				IInventoryItemSpec spec = handController.GetData(i).Spec;
				if (spec != null)
				{
					handLinkedParams[i] = GetIndexAndControllerOfSpec(spec);
				}
			}
			titleHandler.Initialize(provider);
			OnActiveContainerChanged(provider.Inventory.ItemContainerRegistry.ActiveContainer, null);
			SetupListeners(on: true);
		}

		private void OnBackpackAccessRequested()
		{
			if (hasForcedDragData)
			{
				BackpackAccessClicked_Fire(isForceDragging: true);
				return;
			}
			AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
			if (!(activeContainer == null))
			{
				AItemContainer item = activeContainer.NestedIn.firstNest;
				provider.Inventory.ItemContainerRegistry.ActiveContainer = item;
				BackpackAccessClicked_Fire(isForceDragging: false);
			}
		}

		private void OnIsEssentialItemsGetterAllowedChanged()
		{
			base.ItemGetterAllowed = provider.IsEssentialItemsGetterAllowed;
		}

		protected void SetupListeners(bool on)
		{
			if (on)
			{
				if ((bool)provider.Inventory)
				{
					provider.Inventory.InventoryStatusChanged += OnInventoryStatusChanged;
				}
				else
				{
					Debug.LogError("Inventory not found. InventoryUIController listeners not set up.", this);
				}
				if (titleHandler != null)
				{
					titleHandler.BackpackAccessRequested += OnBackpackAccessRequested;
				}
				menuButton.Clicked += OnMenuButtonClicked;
				closeButton.Clicked += OnCloseButtonClicked;
			}
			else
			{
				if ((bool)provider.Inventory)
				{
					provider.Inventory.InventoryStatusChanged -= OnInventoryStatusChanged;
				}
				if (titleHandler != null)
				{
					titleHandler.BackpackAccessRequested -= OnBackpackAccessRequested;
				}
				provider.IsEssentialItemsGetterAllowedChanged -= OnIsEssentialItemsGetterAllowedChanged;
				menuButton.Clicked -= OnMenuButtonClicked;
				closeButton.Clicked -= OnCloseButtonClicked;
			}
			setupFinished = on;
		}

		private void OnCloseButtonClicked(IClickable _)
		{
			Toggle(on: false);
		}

		private void OnMenuButtonClicked(IClickable _)
		{
			PauseMenuRequested_Fire();
		}

		private void OnInventoryStatusChanged(InventorySlotState originState, InventoryActionType originActionType, InventorySlotState targetState, InventoryActionType targetActionType)
		{
			if ((targetActionType & InventoryActionType.Move) != InventoryActionType.None)
			{
				HandleItemMove(targetState.item, originState.slotIndex, targetState.slotIndex);
			}
			if ((targetActionType & InventoryActionType.Unequip) != InventoryActionType.None)
			{
				HandleEquipChanged(targetState.item, targetState.slotIndex, equipped: false, targetState.equipSlot);
			}
			if ((originActionType & InventoryActionType.Swap) != InventoryActionType.None)
			{
				HandleItemSwap(originState.item, originState.slotIndex, targetState.item, targetState.slotIndex);
			}
			if ((originActionType & InventoryActionType.Add) != InventoryActionType.None && (originActionType & InventoryActionType.Destroy) == 0)
			{
				HandleItemAdd(originState.item, originState.slotIndex, originState.equipSlot);
			}
			if ((originActionType & InventoryActionType.Equip) != InventoryActionType.None)
			{
				HandleEquipChanged(originState.item, originState.slotIndex, equipped: true, originState.equipSlot);
			}
			if ((originActionType & InventoryActionType.Unequip) != InventoryActionType.None)
			{
				HandleEquipChanged(originState.item, originState.slotIndex, equipped: false, originState.equipSlot);
			}
			if ((originActionType & InventoryActionType.Drop) != InventoryActionType.None)
			{
				HandleItemDrop(originState.item, originState.slotIndex);
			}
			if ((originActionType & (InventoryActionType.Lock | InventoryActionType.Unlock | InventoryActionType.Reserve | InventoryActionType.Unreserve)) != InventoryActionType.None)
			{
				HandleLockAndReserveChange(originState.slotIndex);
			}
			if ((originActionType & InventoryActionType.Purge) != InventoryActionType.None)
			{
				HandleItemPurge(originState.item, originState.slotIndex);
			}
			if (originActionType.HasAnyIntFlag(InventoryActionType.BeltVisible | InventoryActionType.BeltHidden | InventoryActionType.BeltDisabled | InventoryActionType.BeltEnabled))
			{
				HandleBeltStateChanged(originState.slotIndex);
			}
			if ((bool)tooltipHandler)
			{
				tooltipHandler.UpdateTooltipText();
			}
		}

		private void HandleBeltStateChanged(int slotIndex)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(slotIndex);
			int item = relativeSlotIndexAndIsHotbar.slot;
			InventorySectionController obj = (relativeSlotIndexAndIsHotbar.isHotbar ? hotbarController : backpackController);
			InventorySlotDisplayData data = obj.GetData(item);
			UpdateBeltFlags(data, slotIndex);
			obj.Replace(item, data);
		}

		protected void HandleEquipChanged(GameObject item, int index, bool equipped, int equipSlot)
		{
			if (item == null)
			{
				Debug.LogError("HandleEquipChanged needs a valid item reference.", this);
				return;
			}
			if (!index.IsInRange(-1, 35))
			{
				Debug.LogError(string.Format("{0}: index out of bounds {1}.", "HandleEquipChanged", index), this);
				return;
			}
			IInventoryItemSpec component = item.GetComponent<IInventoryItemSpec>();
			InventorySlotDisplayData data;
			if (equipped)
			{
				if (index >= 0)
				{
					(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(index);
					int item2 = relativeSlotIndexAndIsHotbar.slot;
					bool item3 = relativeSlotIndexAndIsHotbar.isHotbar;
					InventorySectionController inventorySectionController = (item3 ? hotbarController : backpackController);
					InventorySlotDisplayData inventorySlotDisplayData = inventorySectionController.GetData(item2);
					if (inventorySlotDisplayData.Spec != null)
					{
						inventorySlotDisplayData.IsGhost = true;
					}
					else
					{
						bool flag = provider.Inventory.IsValidVRBeltIndex(index);
						bool flag2 = flag && provider.IsBeltSnappable(component);
						bool beltVisible = flag2 && inventorySlotDisplayData.BeltVisible;
						inventorySlotDisplayData = new InventorySlotDisplayData(component, base.ItemGetterAllowed, flag, flag2, beltVisible, item3, isLocked: false, isGhost: true, containerAccessAllowed: true, isHandData: false, isContainerData: false);
					}
					inventorySectionController.Replace(item2, inventorySlotDisplayData);
					handLinkedParams[equipSlot] = new DataAsIndexAndController(item2, inventorySectionController);
				}
				data = new InventorySlotDisplayData(component, isLockable: false, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, containerAccessAllowed: true, isHandData: true, isContainerData: false);
			}
			else
			{
				DataAsIndexAndController dataAsIndexAndController = handLinkedParams[equipSlot];
				if (dataAsIndexAndController != null)
				{
					IInventoryItemSpec spec = dataAsIndexAndController.controller.GetData(dataAsIndexAndController.index).Spec;
					if ((spec != null || !provider.Inventory.IsDestroyedOnAddedToInventory(item)) && spec != component)
					{
						Debug.LogError("Unequipping item which is not linked.", this);
					}
				}
				data = GetEmptySlotData(-1, handController);
				handLinkedParams[equipSlot] = null;
			}
			handController.Replace(equipSlot, data);
		}

		private void HandleItemPurge(GameObject _, int slot)
		{
			if (handLinkedParams == null)
			{
				return;
			}
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(slot);
			int item = relativeSlotIndexAndIsHotbar.slot;
			InventorySectionController inventorySectionController = (relativeSlotIndexAndIsHotbar.isHotbar ? hotbarController : backpackController);
			IInventoryItemSpec spec = inventorySectionController.GetData(item).Spec;
			for (int i = 0; i < GetHandCapacity(); i++)
			{
				DataAsIndexAndController dataAsIndexAndController = handLinkedParams[i];
				IInventoryItemSpec inventoryItemSpec = dataAsIndexAndController?.controller.GetData(dataAsIndexAndController.index).Spec;
				if (inventoryItemSpec != null && inventoryItemSpec == spec)
				{
					InventorySlotDisplayData emptySlotData = GetEmptySlotData(-1, handController);
					handController.Replace(i, emptySlotData);
					handLinkedParams[i] = null;
				}
			}
			inventorySectionController.Replace(item, GetEmptySlotData(item, inventorySectionController));
		}

		private void HandleLockAndReserveChange(int slot)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(slot);
			int item = relativeSlotIndexAndIsHotbar.slot;
			bool item2 = relativeSlotIndexAndIsHotbar.isHotbar;
			InventorySectionController inventorySectionController = (item2 ? hotbarController : backpackController);
			GameObject gameObject = provider.Inventory.PeekItemAtSlot(slot);
			IInventoryItemSpec spec = ((gameObject == null) ? null : gameObject.GetComponent<IInventoryItemSpec>());
			DataAsIndexAndController handLinkedParamsFromSpec = GetHandLinkedParamsFromSpec(spec);
			bool isGhost = (handLinkedParamsFromSpec != null && handLinkedParamsFromSpec.controller == inventorySectionController) || provider.Inventory.GetSlotDroppedState(slot);
			bool slotLockState = provider.Inventory.GetSlotLockState(slot);
			InventorySlotDisplayData data = new InventorySlotDisplayData(spec, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, item2, slotLockState, isGhost, containerAccessAllowed: true, isHandData: false, isContainerData: false);
			UpdateBeltFlags(data, slot);
			inventorySectionController.Replace(item, data);
		}

		private void HandleItemAdd(GameObject item, int slot, int equipSlot)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(slot);
			int item2 = relativeSlotIndexAndIsHotbar.slot;
			bool item3 = relativeSlotIndexAndIsHotbar.isHotbar;
			IInventoryItemSpec component = item.GetComponent<IInventoryItemSpec>();
			InventorySlotDisplayData inventorySlotDisplayData = new InventorySlotDisplayData(component, item3, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, containerAccessAllowed: true, isHandData: false, isContainerData: false);
			(bool lockState, bool reserveState) slotStates = GetSlotStates(slot);
			bool item4 = slotStates.lockState;
			bool item5 = slotStates.reserveState;
			inventorySlotDisplayData.IsLocked = item4;
			inventorySlotDisplayData.IsItemGetter = item5;
			AddItem(inventorySlotDisplayData, item2, item3 ? hotbarController : backpackController);
			HandleTwoHandedItemHandClear(equipSlot, component);
		}

		private void HandleTwoHandedItemHandClear(int equipSlot, IInventoryItemSpec spec)
		{
			int num = ((equipSlot >= 0 && GetHandCapacity() == 2) ? (1 - equipSlot) : (-1));
			if (num >= 0)
			{
				DataAsIndexAndController dataAsIndexAndController = handLinkedParams[num];
				IInventoryItemSpec inventoryItemSpec = dataAsIndexAndController?.controller.GetData(dataAsIndexAndController.index).Spec;
				if (inventoryItemSpec != null && inventoryItemSpec == spec)
				{
					handLinkedParams[num] = null;
					handController.Replace(num, GetEmptySlotData(-1, handController));
				}
			}
		}

		private void OnItemRemovedFromInventory(GameObject item, int slot)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(slot);
			int item2 = relativeSlotIndexAndIsHotbar.slot;
			bool item3 = relativeSlotIndexAndIsHotbar.isHotbar;
			InventorySectionController inventorySectionController = (item3 ? hotbarController : backpackController);
			InventorySlotDisplayData data = inventorySectionController.GetData(item2);
			var (flag, flag2) = GetSlotStates(slot);
			if (data.Spec != null)
			{
				if (flag2 || flag)
				{
					data.IsGhost = true;
					data.IsLocked = flag;
					data.IsItemGetter = flag2;
					inventorySectionController.Replace(item2, data);
				}
				else
				{
					RemoveItem(item2, item3 ? hotbarController : backpackController);
				}
			}
		}

		private (bool lockState, bool reserveState) GetSlotStates(int absoluteSlot)
		{
			bool slotLockState = provider.Inventory.GetSlotLockState(absoluteSlot);
			bool slotReservedState = provider.Inventory.GetSlotReservedState(absoluteSlot);
			return (lockState: slotLockState, reserveState: slotReservedState);
		}

		private void HandleItemDrop(GameObject item, int slot)
		{
			var (slot2, flag) = GetRelativeSlotIndexAndIsHotbar(slot);
			var (flag2, flag3) = GetSlotStates(slot);
			DropItem(slot2, flag3 || flag2, flag ? hotbarController : backpackController);
		}

		private void HandleItemMove(GameObject item, int source, int target)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(source);
			int item2 = relativeSlotIndexAndIsHotbar.slot;
			bool item3 = relativeSlotIndexAndIsHotbar.isHotbar;
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar2 = GetRelativeSlotIndexAndIsHotbar(target);
			int item4 = relativeSlotIndexAndIsHotbar2.slot;
			bool item5 = relativeSlotIndexAndIsHotbar2.isHotbar;
			InventorySectionController sourceController = (item3 ? hotbarController : backpackController);
			InventorySectionController targetController = (item5 ? hotbarController : backpackController);
			MoveItem(item2, sourceController, item4, targetController);
		}

		private void HandleItemSwap(GameObject sourceItem, int source, GameObject targetItem, int target)
		{
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar = GetRelativeSlotIndexAndIsHotbar(source);
			int item = relativeSlotIndexAndIsHotbar.slot;
			bool item2 = relativeSlotIndexAndIsHotbar.isHotbar;
			(int slot, bool isHotbar) relativeSlotIndexAndIsHotbar2 = GetRelativeSlotIndexAndIsHotbar(target);
			int item3 = relativeSlotIndexAndIsHotbar2.slot;
			bool item4 = relativeSlotIndexAndIsHotbar2.isHotbar;
			InventorySectionController sourceController = (item2 ? hotbarController : backpackController);
			InventorySectionController targetController = (item4 ? hotbarController : backpackController);
			SwapItem(item, sourceController, item3, targetController);
		}

		private void InitializeInventory(InventorySectionController controller)
		{
			List<InventorySlotDisplayData> list = new List<InventorySlotDisplayData>();
			int num;
			int num2;
			bool isLockable;
			int capacity;
			switch (controller.section)
			{
			case InventorySectionController.InventorySection.Hand:
				num = 0;
				num2 = CapacityFromInventoryControllerType(InventorySectionController.InventorySection.Hand);
				isLockable = false;
				capacity = GetHandCapacity();
				break;
			case InventorySectionController.InventorySection.Hotbar:
				num = 0;
				num2 = 12;
				isLockable = true;
				capacity = GetHotbarCapacity();
				break;
			case InventorySectionController.InventorySection.Backpack:
				num = 12;
				num2 = 36;
				isLockable = false;
				capacity = GetBackpackCapacity();
				break;
			case InventorySectionController.InventorySection.ItemContainer:
				num = 0;
				num2 = (capacity = GetBackpackCapacity());
				isLockable = false;
				break;
			default:
				Debug.LogError($"Could not initialize inventory for {controller.section}. Unknown controller type.");
				return;
			}
			bool flag = controller == handController;
			bool flag2 = controller.section == InventorySectionController.InventorySection.ItemContainer;
			for (int i = num; i < num2; i++)
			{
				IInventoryItemSpec inventoryItemSpec = null;
				if (flag)
				{
					inventoryItemSpec = GetGrabbedItemSpec();
				}
				else if (!flag2)
				{
					GameObject gameObject = provider.Inventory.PeekItemAtSlot(i);
					if (gameObject != null)
					{
						inventoryItemSpec = gameObject.GetComponent<IInventoryItemSpec>();
					}
				}
				if (inventoryItemSpec != null)
				{
					if (flag)
					{
						InventorySlotDisplayData item = new InventorySlotDisplayData(inventoryItemSpec, isLockable: false, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, containerAccessAllowed: true, flag, flag2);
						list.Add(item);
						continue;
					}
					bool slotLockState = provider.Inventory.GetSlotLockState(i);
					bool slotDroppedState = provider.Inventory.GetSlotDroppedState(i);
					InventorySlotDisplayData inventorySlotDisplayData = new InventorySlotDisplayData(inventoryItemSpec, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, isLockable, slotLockState, slotDroppedState, containerAccessAllowed: true, flag, flag2);
					UpdateBeltFlags(inventorySlotDisplayData, i);
					list.Add(inventorySlotDisplayData);
				}
				else
				{
					InventorySlotDisplayData emptySlotData = GetEmptySlotData(i - num, controller);
					list.Add(emptySlotData);
				}
			}
			if (num != num2)
			{
				controller.Initialize(capacity, this, list, disableDragging, itemContainerProvider);
				InventoryUIInteractionObserver observer = controller.GetObserver();
				observer.SlotClicked += OnSlotClicked;
				observer.SlotPressChanged += OnSlotPressChanged;
				observer.GetClicked += OnGetClicked;
				observer.LockClicked += OnLockClicked;
				observer.BeltResetClicked += OnBeltResetClicked;
				observer.BeltToggleClicked += OnBeltToggleClicked;
				observer.ItemContainerAccessClicked += OnItemContainerAccessClicked;
				observer.ItemContainerAccessHoverChanged += OnItemContainerAccessHoverChanged;
				observer.DragStart += OnDragStart;
				observer.DragEnd += OnDragEnd;
				observer.SelectionChanged += OnSelectionChanged;
				observer.HoverChanged += OnHoverChanged;
			}
		}

		private void OnItemContainerAccessHoverChanged(int newIndex, int oldIndex, InventorySectionController controller)
		{
			int childCount = controller.gridView.transform.childCount;
			if (childCount > 0)
			{
				if (oldIndex.IsInRange(0, childCount - 1))
				{
					controller.gridView.transform.GetChild(oldIndex).GetComponent<InventoryGridElement>().ItemContainerAccessHoverUpdate(draggedData, hovered: false);
				}
				if (newIndex.IsInRange(0, childCount - 1))
				{
					controller.gridView.transform.GetChild(newIndex).GetComponent<InventoryGridElement>().ItemContainerAccessHoverUpdate(draggedData, hovered: true);
				}
			}
		}

		private void OnHoverChanged(int newIndex, int oldIndex, InventorySectionController controller)
		{
			if (oldIndex >= 0)
			{
				controller.gridView.transform.GetChild(oldIndex).GetComponent<InventoryGridElement>().HoverUpdate(draggedData, hovered: false);
			}
			if (newIndex >= 0)
			{
				controller.gridView.transform.GetChild(newIndex).GetComponent<InventoryGridElement>().HoverUpdate(draggedData, hovered: true);
			}
		}

		protected virtual IInventoryItemSpec GetGrabbedItemSpec()
		{
			if (provider.IsVREnabled)
			{
				return null;
			}
			GameObject equippedItemAtSlot = SingletonBehaviour<DV.InventorySystem.Inventory>.Instance.GetEquippedItemAtSlot(0);
			if (!(equippedItemAtSlot != null))
			{
				return null;
			}
			return equippedItemAtSlot.GetComponent<IInventoryItemSpec>();
		}

		protected virtual void OnSelectionChanged(int slotIndex, bool selected, InventorySectionController controller)
		{
			if (!provider.IsVREnabled && !(controller != hotbarController) && selected)
			{
				SelectionChanged_Fire(slotIndex, controller);
			}
		}

		public override int GetBackpackCapacity()
		{
			return 24;
		}

		public override int GetHotbarCapacity()
		{
			return 12;
		}

		public override InventorySlotDisplayData GetEmptySlotData(int index, InventorySectionController controller)
		{
			bool flag = controller == handController;
			bool flag2 = !flag && controller == itemContainerController;
			InventorySlotDisplayData inventorySlotDisplayData = new InventorySlotDisplayData(base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, containerAccessAllowed: true, flag, flag2);
			if (flag || flag2)
			{
				return inventorySlotDisplayData;
			}
			int absoluteSlotIndex = GetAbsoluteSlotIndex(index, controller == hotbarController);
			UpdateBeltFlags(inventorySlotDisplayData, absoluteSlotIndex);
			return inventorySlotDisplayData;
		}

		public override int RequestAddItem(InventorySlotDisplayData data, int slotIndex, InventorySectionController controller)
		{
			if (data == null)
			{
				Debug.LogError("RequestAddItem requires a valid InventorySlotDisplayData.", this);
				return -1;
			}
			if (controller == handController)
			{
				Debug.LogError("Cannot directly add item to hand. It is not a proper inventory.", this);
				return -1;
			}
			int num = CapacityFromInventoryControllerType(controller.section);
			if (slotIndex < 0 || slotIndex >= num)
			{
				Debug.LogError("RequestAddItem failed. Slot index is out of bounds.", this);
				return -1;
			}
			if (controller == itemContainerController)
			{
				AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
				if (activeContainer == null)
				{
					Debug.LogError("RequestAddItem failed. No item container selected.", this);
					return -1;
				}
				if (activeContainer[slotIndex] != null)
				{
					return -1;
				}
				if (!activeContainer.AddItem(data.Spec.GetGameObject(), slotIndex))
				{
					return -1;
				}
				return slotIndex;
			}
			if (provider.Inventory.Contains(data.Spec.GetGameObject(), includeDropped: false))
			{
				Debug.LogError("Item already in inventory.", this);
				return -1;
			}
			(bool canReplace, int slot, InventorySectionController controller, InventorySlotDisplayData data) tuple = ExistsAsGhost(data);
			bool item = tuple.canReplace;
			InventorySectionController item2 = tuple.controller;
			InventorySlotDisplayData item3 = tuple.data;
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			if (item)
			{
				int num2 = provider.Inventory.AddItemToInventory(data.Spec.GetGameObject(), absoluteSlotIndex);
				if (num2 >= 0)
				{
					item3.IsGhost = false;
					item2.Replace(num2, item3);
					return num2;
				}
			}
			if (!IsSlotEmpty(slotIndex, controller))
			{
				Debug.LogError("RequestAddItem failed. Slot is not empty.", this);
				return -1;
			}
			return provider.Inventory.AddItemToInventory(data.Spec.GetGameObject(), absoluteSlotIndex);
		}

		private (bool canReplace, int slot, InventorySectionController controller, InventorySlotDisplayData data) ExistsAsGhost(InventorySlotDisplayData data)
		{
			if (data.Spec == null)
			{
				return (canReplace: false, slot: 0, controller: null, data: null);
			}
			for (int i = 0; i < 12; i++)
			{
				InventorySlotDisplayData data2 = hotbarController.GetData(i);
				if (data2.IsGhost && data2.Spec == data.Spec)
				{
					return (canReplace: true, slot: i, controller: hotbarController, data: data2);
				}
			}
			for (int j = 0; j < 24; j++)
			{
				InventorySlotDisplayData data3 = backpackController.GetData(j);
				if (data3.IsGhost && data3.Spec == data.Spec)
				{
					return (canReplace: true, slot: j, controller: backpackController, data: data3);
				}
			}
			return (canReplace: false, slot: 0, controller: null, data: null);
		}

		public override GameObject RequestRemoveItem(int slot, InventorySectionController controller)
		{
			return null;
		}

		public override void RequestDropItem(int slot, InventorySectionController controller, int potentialEquipSlot)
		{
			int num = CapacityFromInventoryControllerType(controller.section);
			if (slot < 0 || slot >= num)
			{
				Debug.LogError("RequestDropItem failed. Slot is out of bounds.", this);
				return;
			}
			if (IsSlotEmpty(slot, controller))
			{
				Debug.LogError("RequestDropItem cannot drop from an empty slot.", this);
				return;
			}
			if (controller == itemContainerController)
			{
				AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
				if (activeContainer == null)
				{
					Debug.LogError("RequestDropItem failed. No item container selected.", this);
				}
				else
				{
					activeContainer.RemoveItem(slot, activateItem: true, dropItem: true);
				}
				return;
			}
			if (controller == handController)
			{
				DataAsIndexAndController handLinkedParamsFromSpec = GetHandLinkedParamsFromSpec(controller.GetData(slot).Spec);
				bool num2 = handLinkedParamsFromSpec != null;
				if (num2)
				{
					controller = handLinkedParamsFromSpec.controller;
					slot = handLinkedParamsFromSpec.index;
				}
				UnequipItem(potentialEquipSlot, addToInventory: false);
				if (!num2)
				{
					return;
				}
			}
			provider.Inventory.DropItemFromHandsOrInventory(GetAbsoluteSlotIndex(slot, controller == hotbarController));
		}

		public override void RequestMoveItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController, int potentialEquipSlot, AItemContainer targetContainer)
		{
			if ((sourceController == targetController && source == target) || IsSlotEmpty(source, sourceController) || !IsSlotEmpty(target, targetController) || IsSlotGhost(target, targetController))
			{
				return;
			}
			if (IsSlotLocked(target, targetController))
			{
				if (targetController != handController)
				{
					return;
				}
				if (sourceController == itemContainerController)
				{
					AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
					if (activeContainer == null)
					{
						Debug.LogError("RequestMoveItem failed. No item container selected.", this);
						return;
					}
					activeContainer.RemoveItem(source, activateItem: true, dropItem: false);
				}
				RequestEquipItem(sourceController.GetData(source).Spec, potentialEquipSlot);
				return;
			}
			if (sourceController == handController)
			{
				GameObject gameObject = handController.GetData(potentialEquipSlot).Spec.GetGameObject();
				bool num = gameObject != null && provider.Inventory.IsDestroyedOnAddedToInventory(gameObject);
				DataAsIndexAndController dataAsIndexAndController = handLinkedParams[source];
				if (num)
				{
					UnequipItem(potentialEquipSlot);
					return;
				}
				if (targetController == itemContainerController)
				{
					AItemContainer activeContainer2 = provider.Inventory.ItemContainerRegistry.ActiveContainer;
					if (activeContainer2 == null)
					{
						Debug.LogError("RequestMoveItem failed. No item container selected.", this);
					}
					else if (activeContainer2.ValidItem(gameObject))
					{
						if (activeContainer2 == null)
						{
							Debug.LogError("RequestMoveItem failed. No item container selected.", this);
							return;
						}
						UnequipItem(potentialEquipSlot, addToInventory: false);
						activeContainer2.AddItem(gameObject, target);
					}
					return;
				}
				if (dataAsIndexAndController == null)
				{
					UnequipItem(potentialEquipSlot);
					return;
				}
				source = dataAsIndexAndController.index;
				sourceController = dataAsIndexAndController.controller;
				UnequipItem(potentialEquipSlot);
				if (IsSlotLocked(source, sourceController))
				{
					return;
				}
			}
			else
			{
				if (targetController == handController)
				{
					InventorySlotDisplayData inventorySlotDisplayData = null;
					if (sourceController == itemContainerController)
					{
						AItemContainer activeContainer3 = provider.Inventory.ItemContainerRegistry.ActiveContainer;
						if (activeContainer3 == null)
						{
							Debug.LogError("RequestMoveItem failed. No item container selected.", this);
							return;
						}
						inventorySlotDisplayData = sourceController.GetData(source);
						activeContainer3.RemoveItem(source, activateItem: true, dropItem: false);
					}
					else
					{
						inventorySlotDisplayData = sourceController.GetData(source);
					}
					if (GetHandLinkedParamsFromSpec(inventorySlotDisplayData.Spec) == null && handController.GetData(0).Spec == null)
					{
						EquipItem(inventorySlotDisplayData.Spec, source, potentialEquipSlot, sourceController);
					}
					return;
				}
				if (IsSlotLocked(source, sourceController))
				{
					if (targetController != itemContainerController)
					{
						return;
					}
					GameObject item = sourceController.GetData(source).Spec.GetGameObject();
					AItemContainer activeContainer4 = provider.Inventory.ItemContainerRegistry.ActiveContainer;
					if (!activeContainer4.ValidItem(item))
					{
						return;
					}
					provider.Inventory.DropItemFromHandsOrInventory(source, keepInactive: true);
					activeContainer4.AddItem(item, target);
				}
			}
			if (!HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer))
			{
				int absoluteSlotIndex = GetAbsoluteSlotIndex(source, sourceController == hotbarController);
				int absoluteSlotIndex2 = GetAbsoluteSlotIndex(target, targetController == hotbarController);
				provider.Inventory.MoveItemFromTo(absoluteSlotIndex, absoluteSlotIndex2);
			}
		}

		private bool HandleItemContainerMoveOrSwap(int source, InventorySectionController sourceController, int target, InventorySectionController targetController, AItemContainer targetContainer)
		{
			bool flag = sourceController == itemContainerController;
			bool flag2 = targetController == itemContainerController;
			bool flag3 = targetContainer != null;
			if (!flag && !flag2 && !flag3)
			{
				return false;
			}
			AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
			if (flag3 && flag && activeContainer == targetContainer)
			{
				return true;
			}
			if (activeContainer == null && !flag3)
			{
				Debug.LogError("HandleItemContainerMoveOrSwap failed. No item container selected.", this);
				return true;
			}
			if (flag && flag2)
			{
				if (targetContainer != null)
				{
					GameObject item = activeContainer[source];
					int num = (targetContainer.ValidItem(item) ? targetContainer.GetFirstFreeSlot() : (-1));
					if (num < 0)
					{
						return true;
					}
					activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
					targetContainer.AddItem(item, num);
				}
				else
				{
					activeContainer.MoveOrSwapItem(source, target);
				}
			}
			else if (flag)
			{
				DV.InventorySystem.Inventory inventory = provider.Inventory;
				GameObject gameObject = activeContainer[source];
				int absoluteSlotIndex = GetAbsoluteSlotIndex(target, targetController == hotbarController);
				GameObject gameObject2 = inventory.PeekItemAtSlot(absoluteSlotIndex);
				if (gameObject2 == null)
				{
					activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
					int num2 = inventory.AddItemToInventory(gameObject, absoluteSlotIndex);
					if (inventory.GetSlotLockState(num2))
					{
						return true;
					}
					if (num2 != absoluteSlotIndex)
					{
						inventory.MoveItemFromTo(num2, absoluteSlotIndex);
					}
				}
				else if (targetContainer != null)
				{
					GameObject item2 = activeContainer[source];
					bool flag4 = targetContainer.ValidItem(item2);
					int num3 = (flag4 ? targetContainer.GetFirstFreeSlot() : (-1));
					if (num3 < 0)
					{
						if (!flag4)
						{
							return true;
						}
						if (targetContainer.DirectInteractionAllowed)
						{
							return true;
						}
						GameObject item3 = targetContainer[0];
						activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
						if (activeContainer.ValidItem(item3))
						{
							targetContainer.RemoveItem(0, activateItem: false, dropItem: false);
							activeContainer.AddItem(item3, source);
						}
						else
						{
							int firstFreeSlot = inventory.GetFirstFreeSlot();
							if (InventoryUtils.IsValidInventoryIndex(firstFreeSlot))
							{
								targetContainer.RemoveItem(0, activateItem: false, dropItem: false);
								inventory.AddItemToInventory(item3, firstFreeSlot);
							}
							else
							{
								targetContainer.RemoveItem(0, activateItem: true, dropItem: true);
							}
						}
						targetContainer.AddItem(item2, 0);
						return true;
					}
					activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
					targetContainer.AddItem(item2, num3);
				}
				else
				{
					if (!activeContainer.ValidItem(gameObject2))
					{
						return true;
					}
					if (inventory.GetSlotDroppedState(absoluteSlotIndex))
					{
						if (!(gameObject2 == gameObject))
						{
							return true;
						}
						activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
						inventory.AddItemToInventory(gameObject);
					}
					else
					{
						int num4 = inventory.FindReservedSlotForDroppedItem(gameObject);
						if (InventoryUtils.IsValidInventoryIndex(num4))
						{
							activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
							bool slotLockState = inventory.GetSlotLockState(num4);
							inventory.AddItemToInventory(gameObject, num4);
							if (!slotLockState && !inventory.GetSlotLockState(absoluteSlotIndex))
							{
								inventory.SwapItems(absoluteSlotIndex, num4);
							}
							inventory.DropItemFromHandsOrInventory(gameObject2);
							activeContainer.AddItem(gameObject2, source);
						}
						else
						{
							int slot = absoluteSlotIndex;
							if (inventory.GetSlotReservedState(slot) || inventory.GetSlotLockState(slot))
							{
								int firstFreeSlot2 = inventory.GetFirstFreeSlot();
								if (!InventoryUtils.IsValidInventoryIndex(firstFreeSlot2))
								{
									return true;
								}
								slot = firstFreeSlot2;
								activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
								inventory.AddItemToInventory(gameObject, slot);
								if (!inventory.GetSlotLockState(absoluteSlotIndex))
								{
									inventory.SwapItems(absoluteSlotIndex, slot);
								}
								inventory.DropItemFromHandsOrInventory(gameObject2);
								activeContainer.AddItem(gameObject2, source);
							}
							else
							{
								activeContainer.RemoveItem(source, activateItem: false, dropItem: false);
								inventory.DropItemFromHandsOrInventory(absoluteSlotIndex, keepInactive: true);
								activeContainer.AddItem(gameObject2, source);
								inventory.AddItemToInventory(gameObject, slot);
							}
						}
					}
				}
			}
			else
			{
				int absoluteSlotIndex2 = GetAbsoluteSlotIndex(source, sourceController == hotbarController);
				GameObject gameObject3 = provider.Inventory.PeekItemAtSlot(absoluteSlotIndex2);
				if (gameObject3 == null)
				{
					Debug.LogError("HandleItemContainerMoveOrSwap failed. No item found in inventory.", this);
					return true;
				}
				if (targetContainer != null)
				{
					bool flag5 = targetContainer.ValidItem(gameObject3);
					int num5 = (flag5 ? targetContainer.GetFirstFreeSlot() : (-1));
					if (num5 < 0)
					{
						if (!flag5)
						{
							return true;
						}
						if (targetContainer.DirectInteractionAllowed)
						{
							return true;
						}
						provider.Inventory.DropItemFromHandsOrInventory(gameObject3);
						int firstFreeSlot3 = provider.Inventory.GetFirstFreeSlot();
						if (InventoryUtils.IsValidInventoryIndex(firstFreeSlot3))
						{
							GameObject item4 = targetContainer[0];
							targetContainer.RemoveItem(0, activateItem: false, dropItem: false);
							provider.Inventory.AddItemToInventory(item4, firstFreeSlot3);
						}
						else
						{
							targetContainer.RemoveItem(0, activateItem: true, dropItem: true);
						}
						targetContainer.AddItem(gameObject3, 0);
						return true;
					}
					provider.Inventory.DropItemFromHandsOrInventory(absoluteSlotIndex2, keepInactive: true);
					targetContainer.AddItem(gameObject3, num5);
					return true;
				}
				if (!activeContainer.ValidItem(gameObject3))
				{
					return true;
				}
				GameObject gameObject4 = activeContainer[target];
				if (gameObject4 == null)
				{
					provider.Inventory.DropItemFromHandsOrInventory(source, keepInactive: true);
				}
				else
				{
					bool flag6 = provider.Inventory.GetSlotReservedState(absoluteSlotIndex2) || provider.Inventory.GetSlotLockState(absoluteSlotIndex2);
					int num6 = provider.Inventory.FindReservedSlotForDroppedItem(gameObject4);
					if (InventoryUtils.IsValidInventoryIndex(num6))
					{
						activeContainer.RemoveItem(target, activateItem: false, dropItem: false);
						provider.Inventory.AddItemToInventory(gameObject4, num6);
						if (!provider.Inventory.GetSlotLockState(num6) && !provider.Inventory.GetSlotLockState(absoluteSlotIndex2))
						{
							provider.Inventory.SwapItems(absoluteSlotIndex2, num6);
						}
						provider.Inventory.DropItemFromHandsOrInventory(gameObject3);
					}
					else if (flag6)
					{
						int firstFreeSlot4 = provider.Inventory.GetFirstFreeSlot();
						if (!InventoryUtils.IsValidInventoryIndex(firstFreeSlot4))
						{
							return true;
						}
						activeContainer.RemoveItem(target, activateItem: false, dropItem: false);
						provider.Inventory.AddItemToInventory(gameObject4, firstFreeSlot4);
						if (!provider.Inventory.GetSlotLockState(absoluteSlotIndex2))
						{
							provider.Inventory.SwapItems(absoluteSlotIndex2, firstFreeSlot4);
						}
						provider.Inventory.DropItemFromHandsOrInventory(gameObject3);
					}
					else
					{
						provider.Inventory.DropItemFromHandsOrInventory(gameObject3);
						provider.Inventory.AddItemToInventory(gameObject4, absoluteSlotIndex2);
					}
				}
				activeContainer.AddItem(gameObject3, target);
			}
			return true;
		}

		public override void RequestSwapItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController, int potentialEquipSlot, AItemContainer targetContainer)
		{
			if (IsSlotEmpty(source, sourceController) || IsSlotEmpty(target, targetController) || (source == target && sourceController == targetController))
			{
				return;
			}
			int num = CapacityFromInventoryControllerType(sourceController.section);
			if (source < 0 || source >= num)
			{
				Debug.LogError("Swap request failed. Source is out of bounds.");
				return;
			}
			int num2 = CapacityFromInventoryControllerType(targetController.section);
			if (target < 0 || target >= num2)
			{
				Debug.LogError("Swap request failed. Target is out of bounds.");
				return;
			}
			InventorySlotDisplayData data = targetController.GetData(target);
			bool isLocked = data.IsLocked;
			bool isGhost = data.IsGhost;
			bool flag = sourceController == handController;
			bool flag2 = targetController == handController;
			bool flag3 = sourceController == itemContainerController;
			bool flag4 = targetController == itemContainerController;
			if (isLocked || isGhost)
			{
				if (isGhost && flag3)
				{
					HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer);
					return;
				}
				if (isLocked && !isGhost)
				{
					if (targetContainer != null)
					{
						HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer);
						return;
					}
					if (flag3 && !flag4)
					{
						HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer);
						return;
					}
				}
				if (!flag)
				{
					return;
				}
				DataAsIndexAndController handLinkedParamsFromSpec = GetHandLinkedParamsFromSpec(sourceController.GetData(source).Spec);
				if (handLinkedParamsFromSpec == null)
				{
					return;
				}
				int index = handLinkedParamsFromSpec.index;
				InventorySectionController controller = handLinkedParamsFromSpec.controller;
				if (index != target || controller != targetController)
				{
					if (!isGhost)
					{
						EquipItem(data.Spec, target, potentialEquipSlot, targetController);
					}
				}
				else
				{
					UnequipItem(potentialEquipSlot);
				}
			}
			else if (sourceController.GetData(source).IsLocked && !flag2)
			{
				if (flag4 || targetContainer != null)
				{
					HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer);
				}
			}
			else if (flag)
			{
				GameObject gameObject = handController.GetData(potentialEquipSlot).Spec.GetGameObject();
				if (gameObject != null && provider.Inventory.IsDestroyedOnAddedToInventory(gameObject))
				{
					UnequipItem(potentialEquipSlot);
					return;
				}
				if (targetContainer != null)
				{
					bool flag5 = targetContainer.ValidItem(gameObject);
					int num3 = (flag5 ? targetContainer.GetFirstFreeSlot() : (-1));
					if (num3 < 0)
					{
						if (flag5 && !targetContainer.DirectInteractionAllowed)
						{
							UnequipItem(potentialEquipSlot, addToInventory: false);
							int firstFreeSlot = provider.Inventory.GetFirstFreeSlot();
							if (InventoryUtils.IsValidInventoryIndex(firstFreeSlot))
							{
								GameObject item = targetContainer[0];
								targetContainer.RemoveItem(0, activateItem: false, dropItem: false);
								provider.Inventory.AddItemToInventory(item, firstFreeSlot);
							}
							else
							{
								targetContainer.RemoveItem(0, activateItem: true, dropItem: true);
							}
							targetContainer.AddItem(gameObject, 0);
						}
					}
					else
					{
						UnequipItem(potentialEquipSlot, addToInventory: false);
						targetContainer.AddItem(gameObject, num3);
					}
					return;
				}
				if (flag4)
				{
					AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
					if (activeContainer == null)
					{
						Debug.LogError("RequestSwapItem failed. No item container selected.", this);
					}
					else if (activeContainer.ValidItem(gameObject))
					{
						UnequipItem(potentialEquipSlot, addToInventory: false);
						IInventoryItemSpec spec = itemContainerController.GetData(target).Spec;
						if (spec != null)
						{
							activeContainer.RemoveItem(target, activateItem: true, dropItem: false);
							EquipItem(spec, provider.Inventory.GetFirstFreeSlot(), potentialEquipSlot, itemContainerController);
						}
						activeContainer.AddItem(gameObject, target);
					}
					return;
				}
				if (handLinkedParams[source] == null)
				{
					if (provider.Inventory.GetFirstFreeSlot() < 0)
					{
						return;
					}
					UnequipItem(potentialEquipSlot);
					EquipItem(data.Spec, target, potentialEquipSlot, targetController);
				}
				EquipItem(data.Spec, target, potentialEquipSlot, targetController);
			}
			else if (flag2)
			{
				if (targetContainer != null)
				{
					HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer);
					return;
				}
				if (flag3)
				{
					AItemContainer activeContainer2 = provider.Inventory.ItemContainerRegistry.ActiveContainer;
					if (activeContainer2 == null)
					{
						Debug.LogError("RequestSwapItem failed. No item container selected.", this);
					}
					else if (activeContainer2.ValidItem(data.Spec.GetGameObject()))
					{
						IInventoryItemSpec spec2 = itemContainerController.GetData(source).Spec;
						activeContainer2.RemoveItem(source, activateItem: true, dropItem: false);
						GameObject equippedItemAtSlot = provider.Inventory.GetEquippedItemAtSlot(potentialEquipSlot);
						if (equippedItemAtSlot != null)
						{
							UnequipItem(potentialEquipSlot, addToInventory: false);
							activeContainer2.AddItem(equippedItemAtSlot, source);
						}
						EquipItem(spec2, provider.Inventory.GetFirstFreeSlot(), potentialEquipSlot, sourceController);
					}
					return;
				}
				if (handLinkedParams[target] == null)
				{
					if (provider.Inventory.GetFirstFreeSlot() < 0)
					{
						return;
					}
					UnequipItem(potentialEquipSlot);
					EquipItem(data.Spec, target, potentialEquipSlot, targetController);
				}
				InventorySlotDisplayData data2 = sourceController.GetData(source);
				EquipItem(data2.Spec, source, potentialEquipSlot, sourceController);
			}
			else if (!HandleItemContainerMoveOrSwap(source, sourceController, target, targetController, targetContainer))
			{
				int absoluteSlotIndex = GetAbsoluteSlotIndex(source, sourceController == hotbarController);
				int absoluteSlotIndex2 = GetAbsoluteSlotIndex(target, targetController == hotbarController);
				provider.Inventory.SwapItems(absoluteSlotIndex, absoluteSlotIndex2);
			}
		}

		public override void RequestEquipItem(IInventoryItemSpec itemSpec, int equipSlot)
		{
			if (!provider.IsVREnabled)
			{
				equipSlot = 0;
			}
			if (itemSpec == null)
			{
				Debug.LogError("Equip request failed. Item is null.");
				return;
			}
			DataAsIndexAndController indexAndControllerOfSpec = GetIndexAndControllerOfSpec(itemSpec);
			InventorySectionController inventorySectionController;
			int num;
			if (indexAndControllerOfSpec != null)
			{
				inventorySectionController = indexAndControllerOfSpec.controller;
				num = indexAndControllerOfSpec.index;
			}
			else
			{
				inventorySectionController = null;
				num = provider.Inventory.GetFirstFreeSlot();
			}
			if (inventorySectionController != null && (num < 0 || num >= CapacityFromInventoryControllerType(inventorySectionController.section)))
			{
				Debug.LogError("Equip request failed. Index is out of bounds.");
			}
			else
			{
				EquipItem(itemSpec, num, equipSlot, inventorySectionController);
			}
		}

		public override void RequestUnequipItem(int equipSlot)
		{
			if (!provider.IsVREnabled)
			{
				equipSlot = 0;
			}
			if (equipSlot >= 0 && handController.GetData(equipSlot).Spec == null)
			{
				return;
			}
			DataAsIndexAndController dataAsIndexAndController = handLinkedParams[equipSlot];
			InventorySectionController inventorySectionController = dataAsIndexAndController?.controller;
			if (dataAsIndexAndController != null && inventorySectionController == null)
			{
				Debug.LogError("Unequip request failed. Hand is not linked to a valid controller.");
				return;
			}
			if (inventorySectionController != null)
			{
				int index = dataAsIndexAndController.index;
				int num = CapacityFromInventoryControllerType(inventorySectionController.section);
				if (!index.IsInRange(0, num - 1))
				{
					Debug.LogError($"Given slot {index} needs to be within 0-{num - 1} range. Aborting unequipping item.", this);
					return;
				}
			}
			UnequipItem(equipSlot);
		}

		public override void RequestClearInventory()
		{
			ClearInventory();
		}

		protected void UpdateBeltFlags(InventorySlotDisplayData data, int absoluteIndex)
		{
			bool flag = provider.Inventory.IsValidVRBeltIndex(absoluteIndex);
			bool flag2 = flag && (data.Spec == null || provider.IsBeltSnappable(data.Spec));
			BeltSlotState item = provider.Inventory.GetBeltSlotIndexAndState(absoluteIndex).beltSlotState;
			bool beltVisible = flag2 && item == BeltSlotState.VisibleAndEnabled;
			data.IsBelt = flag;
			data.BeltAllowed = flag2;
			data.BeltVisible = beltVisible;
		}

		protected override void AddItem(InventorySlotDisplayData data, int slotIndex, InventorySectionController controller)
		{
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			UpdateBeltFlags(data, absoluteSlotIndex);
			controller.Add(data, slotIndex);
		}

		protected override void RemoveItem(int slot, InventorySectionController controller)
		{
			controller.Remove(slot);
		}

		protected override void DropItem(int slot, bool leaveGhost, InventorySectionController controller)
		{
			controller.Drop(slot, leaveGhost);
		}

		protected override void MoveItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController)
		{
			bool flag = targetController == hotbarController;
			InventorySlotDisplayData data = sourceController.GetData(source);
			UpdateBeltFlags(data, GetAbsoluteSlotIndex(target, flag));
			if (sourceController == targetController)
			{
				sourceController.Move(source, target);
				return;
			}
			data.IsLockable = flag;
			sourceController.Remove(source);
			targetController.Add(data, target);
		}

		protected override void SwapItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController)
		{
			bool flag = sourceController == hotbarController;
			bool flag2 = targetController == hotbarController;
			InventorySlotDisplayData data = sourceController.GetData(source);
			InventorySlotDisplayData data2 = targetController.GetData(target);
			int absoluteSlotIndex = GetAbsoluteSlotIndex(target, flag2);
			int absoluteSlotIndex2 = GetAbsoluteSlotIndex(source, flag);
			UpdateBeltFlags(data, absoluteSlotIndex);
			UpdateBeltFlags(data2, absoluteSlotIndex2);
			if (sourceController == targetController)
			{
				sourceController.Swap(source, target);
				return;
			}
			data.IsLockable = flag2;
			data2.IsLockable = flag;
			sourceController.Replace(source, data2);
			targetController.Replace(target, data);
		}

		protected override void ClearInventory()
		{
			for (int i = 0; i < GetHotbarCapacity(); i++)
			{
				hotbarController.Remove(i);
			}
			for (int j = 0; j < GetBackpackCapacity(); j++)
			{
				backpackController.Remove(j);
			}
			for (int k = 0; k < GetHandCapacity(); k++)
			{
				handController.Remove(k);
			}
		}

		protected override bool IsSlotEmpty(int slot, InventorySectionController controller)
		{
			int num = CapacityFromInventoryControllerType(controller.section);
			if (slot >= 0 && slot < num)
			{
				return controller.GetData(slot).Spec == null;
			}
			Debug.LogError(string.Format("{0} failed. Slot '{1}' is out of bounds '0-{2}'.", "IsSlotEmpty", slot, num - 1), this);
			return false;
		}

		protected override DataAsIndexAndController GetIndexAndControllerOfSpec(IInventoryItemSpec spec)
		{
			if (spec == null)
			{
				Debug.LogError("GetIndexAndControllerOfSpec failed. Spec is null.", this);
				return null;
			}
			for (int i = 0; i < 12; i++)
			{
				if (hotbarController.GetData(i).Spec == spec)
				{
					return new DataAsIndexAndController(i, hotbarController);
				}
			}
			for (int j = 0; j < 24; j++)
			{
				if (backpackController.GetData(j).Spec == spec)
				{
					return new DataAsIndexAndController(j, backpackController);
				}
			}
			return null;
		}

		public override void Toggle(bool on)
		{
			if (on != IsOpen)
			{
				if (!on)
				{
					AboutToClose_Fire();
				}
				containerGO.SetActive(on);
				OpenedOrClosed_Fire(on);
			}
		}

		protected override void EquipItem(IInventoryItemSpec itemSpec, int slot, int equipSlot, InventorySectionController sourceController)
		{
			if (!provider.IsVREnabled)
			{
				equipSlot = 0;
			}
			RequestUnequipItem(equipSlot);
			bool num = sourceController != null;
			bool flag = num && sourceController == itemContainerController;
			if (num && !flag)
			{
				InventorySlotDisplayData data = sourceController.GetData(slot);
				data.IsGhost = true;
				sourceController.Replace(slot, data);
			}
			InventorySlotDisplayData data2 = new InventorySlotDisplayData(itemSpec, isLockable: false, base.ItemGetterAllowed, isBelt: false, beltAllowed: false, beltVisible: false, containerAccessAllowed: true, isHandData: true, isContainerData: false);
			handController.Replace(equipSlot, data2);
			int inventorySlot;
			if (flag)
			{
				inventorySlot = -1;
				handLinkedParams[equipSlot] = null;
			}
			else
			{
				inventorySlot = GetAbsoluteSlotIndex(slot, sourceController == hotbarController);
				handLinkedParams[equipSlot] = new DataAsIndexAndController(slot, sourceController);
			}
			if (sourceController == hotbarController && !provider.IsVREnabled)
			{
				hotbarController.SetSelectedSlot(slot);
			}
			provider.RequestEquipItem(equipSlot, inventorySlot, itemSpec);
		}

		public override void OverrideDragAndContainerClickInteraction(int equipSlot, PointerEventData pointerEventData)
		{
			InventorySlotDisplayData inventorySlotDisplayData = (equipSlot.IsInRange(0, GetHandCapacity() - 1) ? handController.GetData(equipSlot) : null);
			draggedData = ((inventorySlotDisplayData?.Spec != null) ? inventorySlotDisplayData : null);
			hasForcedDragData = draggedData != null;
			UpdateContainerAccess(draggedData, hasForcedDragData);
			if (pointerEventData != null)
			{
				GameObject gameObject = pointerEventData.pointerCurrentRaycast.gameObject;
				InventoryGridElement inventoryGridElement = ((gameObject != null) ? gameObject.GetComponentInParentIncludingInactive<InventoryGridElement>() : null);
				if (inventoryGridElement != null)
				{
					inventoryGridElement.HoverUpdate(draggedData, hovered: true);
				}
			}
		}

		protected override void UnequipItem(int equippedSlot, bool addToInventory = true)
		{
			if (!provider.IsVREnabled)
			{
				equippedSlot = 0;
			}
			provider.RequestUnequipItem(addToInventory, equippedSlot);
		}

		protected override bool IsSlotGhost(int slot, InventorySectionController controller)
		{
			if (controller != handController)
			{
				return controller.GetData(slot).IsGhost;
			}
			return false;
		}

		private bool IsSlotLocked(int slot, InventorySectionController controller)
		{
			if (controller != handController)
			{
				return controller.GetData(slot).IsLocked;
			}
			return false;
		}

		protected int GetAbsoluteSlotIndex(int slot, bool isHotbar)
		{
			return slot + ((!isHotbar) ? 12 : 0);
		}

		protected (int slot, bool isHotbar) GetRelativeSlotIndexAndIsHotbar(int absoluteSlot)
		{
			bool flag = absoluteSlot < 12;
			return (slot: absoluteSlot - ((!flag) ? 12 : 0), isHotbar: flag);
		}

		protected virtual void OnSlotClicked(int slotIndex, InventorySectionController controller)
		{
			if (!(controller == handController))
			{
				bool flag = controller == hotbarController;
				SlotClicked_Fire(GetAbsoluteSlotIndex(slotIndex, flag));
				if (flag && !provider.IsVREnabled)
				{
					controller.SetSelectedSlot(slotIndex);
				}
			}
		}

		private void OnSlotPressChanged(int slotIndex, bool pressed, InventorySectionController controller)
		{
			if (controller == handController)
			{
				HandSlotPressChanged_Fire(slotIndex, pressed);
				return;
			}
			bool isHotbar = controller == hotbarController;
			bool flag = controller == itemContainerController;
			int index = (flag ? slotIndex : GetAbsoluteSlotIndex(slotIndex, isHotbar));
			SlotPressChanged_Fire(index, pressed, flag);
		}

		protected void OnGetClicked(int slotIndex, InventorySectionController controller)
		{
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			GameObject gameObject = provider.Inventory.PeekItemAtSlot(absoluteSlotIndex);
			if (gameObject == null)
			{
				Debug.LogError($"Trying to get item to an empty slot {absoluteSlotIndex}. This should not happen...", this);
			}
			else if (!provider.Inventory.GetSlotDroppedState(absoluteSlotIndex))
			{
				Debug.LogError($"Trying to get item that is not dropped to slot {absoluteSlotIndex}. This should not happen...", this);
			}
			else
			{
				provider.Inventory.AddItemToInventory(gameObject, absoluteSlotIndex);
			}
		}

		protected void OnLockClicked(int slotIndex, InventorySectionController controller)
		{
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			provider.Inventory.ToggleSlotLock(absoluteSlotIndex);
		}

		private void OnBeltToggleClicked(int slotIndex, InventorySectionController controller)
		{
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			BeltToggleRequested_Fire(absoluteSlotIndex);
		}

		private void OnBeltResetClicked(int slotIndex, InventorySectionController controller)
		{
			int absoluteSlotIndex = GetAbsoluteSlotIndex(slotIndex, controller == hotbarController);
			BeltResetRequested_Fire(absoluteSlotIndex);
		}

		private void OnItemContainerAccessClicked(int slotIndex, InventorySectionController controller)
		{
			AItemContainer itemContainer = controller.GetData(slotIndex).ItemContainer;
			if (itemContainer == null)
			{
				Debug.LogError($"Missing item container data in slot {slotIndex}. Container access aborted.", this);
				return;
			}
			AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
			if (hasForcedDragData)
			{
				if (draggedData.ItemContainer != itemContainer)
				{
					ContainerAccessClicked_Fire(itemContainer, isForceDragging: true);
					return;
				}
				if (itemContainer.DirectInteractionAllowed)
				{
					ToggleActiveContainerOnClick(itemContainer, activeContainer);
				}
				else
				{
					EjectMagazineOnClick(itemContainer, activeContainer, controller);
				}
				ContainerAccessClicked_Fire(itemContainer, isForceDragging: true);
			}
			else if (!itemContainer.DirectInteractionAllowed)
			{
				EjectMagazineOnClick(itemContainer, activeContainer, controller);
				ContainerAccessClicked_Fire(itemContainer, isForceDragging: false);
			}
			else
			{
				ToggleActiveContainerOnClick(itemContainer, activeContainer);
				ContainerAccessClicked_Fire(itemContainer, isForceDragging: false);
			}
		}

		private void ToggleActiveContainerOnClick(AItemContainer container, AItemContainer activeContainer)
		{
			AItemContainer activeContainer2 = ((activeContainer == container) ? null : container);
			provider.Inventory.ItemContainerRegistry.ActiveContainer = activeContainer2;
		}

		private void EjectMagazineOnClick(AItemContainer container, AItemContainer activeContainer, InventorySectionController controller)
		{
			GameObject gameObject = container[0];
			if (gameObject == null)
			{
				return;
			}
			if (controller == itemContainerController && activeContainer != null)
			{
				int num = (activeContainer.ValidItem(gameObject) ? activeContainer.GetFirstFreeSlot() : (-1));
				if (num >= 0)
				{
					container.RemoveItem(0, activateItem: false, dropItem: false);
					activeContainer.AddItem(gameObject, num);
					return;
				}
			}
			int firstFreeSlot = provider.Inventory.GetFirstFreeSlot();
			if (InventoryUtils.IsValidInventoryIndex(firstFreeSlot))
			{
				container.RemoveItem(0, activateItem: false, dropItem: false);
				provider.Inventory.AddItemToInventory(gameObject, firstFreeSlot);
			}
			else
			{
				container.RemoveItem(0, activateItem: true, dropItem: true);
			}
		}

		protected virtual void OnDragStart(int slotIndex, InventorySectionController controller, PointerEventData pointerEventData, bool _)
		{
			if (hasForcedDragData || IsSlotEmpty(slotIndex, controller))
			{
				return;
			}
			InventorySlotDisplayData data = controller.GetData(slotIndex);
			if (!data.IsGhost)
			{
				draggedData = data;
				UpdateContainerAccess(draggedData, dragStart: true);
				InventoryGridElement component = controller.gridView.transform.GetChild(slotIndex).GetComponent<InventoryGridElement>();
				if (component != null)
				{
					component.DragUpdate(draggedData, dragStart: true);
				}
				titleHandler.UpdateDragState(draggedData);
				controller.ToggleGhost(slotIndex, on: true);
			}
		}

		protected virtual void OnDragEnd(int slotIndex, InventorySectionController controller, PointerEventData pointerEventData, bool forced)
		{
			if (hasForcedDragData)
			{
				return;
			}
			draggedData = null;
			GameObject gameObject = pointerEventData?.pointerEnter;
			InventoryGridElement inventoryGridElement = null;
			InventoryItemDropZone inventoryItemDropZone = null;
			if (gameObject != null)
			{
				inventoryGridElement = gameObject.GetComponentInParent<InventoryGridElement>();
				inventoryItemDropZone = gameObject.GetComponentInParent<InventoryItemDropZone>();
			}
			UpdateContainerAccess(null, dragStart: false);
			titleHandler.UpdateDragState(null);
			controller.ToggleGhost(slotIndex, on: false);
			if (forced)
			{
				return;
			}
			if (gameObject == null)
			{
				RequestDropItem(slotIndex, controller, 0);
				return;
			}
			InventorySectionController inventorySectionController = null;
			if (inventoryGridElement == null)
			{
				if (inventoryItemDropZone == null)
				{
					return;
				}
				AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
				AItemContainer aItemContainer = ((activeContainer != null) ? activeContainer.NestedIn.firstNest : null);
				if (aItemContainer != null)
				{
					HandleItemContainerMoveOrSwap(slotIndex, controller, -1, itemContainerController, aItemContainer);
					return;
				}
				int backpackTargetSlot = inventoryItemDropZone.GetBackpackTargetSlot();
				if (backpackTargetSlot < 0)
				{
					return;
				}
				int item = GetRelativeSlotIndexAndIsHotbar(backpackTargetSlot).slot;
				inventorySectionController = backpackController;
				inventoryGridElement = inventorySectionController.gridView.transform.GetChild(item).GetComponent<InventoryGridElement>();
			}
			if (inventorySectionController == null)
			{
				inventorySectionController = inventoryGridElement.GetComponentInParent<InventorySectionController>();
			}
			if (inventorySectionController == null)
			{
				Debug.LogError($"Could not find controller for {gameObject}.", this);
				return;
			}
			inventoryGridElement.DragUpdate(null, dragStart: false);
			AItemContainer targetContainer = ((inventoryItemDropZone != null && inventoryItemDropZone.ItemContainerDropZone) ? inventoryGridElement.Data.ItemContainer : null);
			int num = inventorySectionController.IndexOfElement(inventoryGridElement.Data);
			if (IsSlotEmpty(num, inventorySectionController))
			{
				RequestMoveItem(slotIndex, controller, num, inventorySectionController, 0, targetContainer);
			}
			else
			{
				RequestSwapItem(slotIndex, controller, num, inventorySectionController, 0, targetContainer);
			}
			if (tooltipHandler != null)
			{
				tooltipHandler.UpdateTooltipText();
			}
		}

		private void UpdateContainerAccess(InventorySlotDisplayData insertionData, bool dragStart)
		{
			foreach (InventoryGridElement allItemContainersWithGridElement in GetAllItemContainersWithGridElements())
			{
				allItemContainersWithGridElement.DragUpdate(insertionData, dragStart);
			}
		}

		private List<InventoryGridElement> GetAllItemContainersWithGridElements()
		{
			List<InventoryGridElement> list = new List<InventoryGridElement>();
			for (int i = 0; i < 12; i++)
			{
				InventorySlotDisplayData data = hotbarController.GetData(i);
				if (data != null && !(data.ItemContainer == null))
				{
					InventoryGridElement component = hotbarController.gridView.transform.GetChild(i).GetComponent<InventoryGridElement>();
					list.Add(component);
				}
			}
			AItemContainer activeContainer = provider.Inventory.ItemContainerRegistry.ActiveContainer;
			if (activeContainer == null)
			{
				for (int j = 0; j < 24; j++)
				{
					InventorySlotDisplayData data2 = backpackController.GetData(j);
					if (data2 != null && !(data2.ItemContainer == null))
					{
						InventoryGridElement component2 = backpackController.gridView.transform.GetChild(j).GetComponent<InventoryGridElement>();
						list.Add(component2);
					}
				}
			}
			else
			{
				for (int k = 0; k < activeContainer.Capacity; k++)
				{
					InventorySlotDisplayData data3 = itemContainerController.GetData(k);
					if (data3 != null && !(data3.ItemContainer == null))
					{
						InventoryGridElement component3 = itemContainerController.gridView.transform.GetChild(k).GetComponent<InventoryGridElement>();
						list.Add(component3);
					}
				}
			}
			for (int l = 0; l < GetHandCapacity(); l++)
			{
				InventorySlotDisplayData data4 = handController.GetData(l);
				if (data4 != null && !(data4.ItemContainer == null))
				{
					InventoryGridElement component4 = handController.gridView.transform.GetChild(l).GetComponent<InventoryGridElement>();
					list.Add(component4);
				}
			}
			return list;
		}

		protected virtual int CapacityFromInventoryControllerType(InventorySectionController.InventorySection section)
		{
			switch (section)
			{
			case InventorySectionController.InventorySection.Backpack:
				return 24;
			case InventorySectionController.InventorySection.Hotbar:
				return 12;
			case InventorySectionController.InventorySection.Hand:
				return GetHandCapacity();
			case InventorySectionController.InventorySection.ItemContainer:
				return provider.Inventory.ItemContainerRegistry.ActiveContainer?.Capacity ?? 1;
			default:
				throw new ArgumentException(string.Format("{0}: Unknown controller type {1}", "CapacityFromInventoryControllerType", section));
			}
		}

		private DataAsIndexAndController GetHandLinkedParamsFromSpec(IInventoryItemSpec spec)
		{
			if (spec == null)
			{
				return null;
			}
			for (int i = 0; i < GetHandCapacity(); i++)
			{
				DataAsIndexAndController dataAsIndexAndController = handLinkedParams[i];
				if (dataAsIndexAndController != null && !(dataAsIndexAndController.controller == null) && dataAsIndexAndController.controller.GetData(dataAsIndexAndController.index).Spec == spec)
				{
					return dataAsIndexAndController;
				}
			}
			return null;
		}

		public override void SetSelectedSlot(int slot)
		{
			if (!provider.IsVREnabled && InventoryUtils.IsValidHotbarIndex(slot))
			{
				hotbarController.SetSelectedSlot(slot);
			}
		}

		public override int GetHandCapacity()
		{
			if (!provider.IsVREnabled)
			{
				return 1;
			}
			return 2;
		}
	}
}
