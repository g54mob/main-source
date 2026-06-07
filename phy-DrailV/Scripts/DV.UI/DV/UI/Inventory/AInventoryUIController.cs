using System;
using DV.Common;
using DV.InventorySystem;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI.Inventory
{
	public abstract class AInventoryUIController : NullCheckingMonoBehaviour
	{
		protected class DataAsIndexAndController
		{
			public readonly int index;

			public readonly InventorySectionController controller;

			public DataAsIndexAndController(int index, InventorySectionController controller)
			{
				this.index = index;
				this.controller = controller;
			}
		}

		public delegate void SlotClickedDelegate(int index);

		public delegate void SlotPressChangedDelegate(int index, bool pressed, bool isHandSlot, bool isContainerSlot);

		public delegate void SelectionChangedDelegate(int index, InventorySectionController controller);

		public delegate void ItemEquippedStateChangedDelegate(bool equipped, int equipSlot, int inventorySlot, IInventoryItemSpec inventoryItemSpec);

		public delegate void BeltButtonInteractionDelegate(int index);

		[NullCheck]
		public ButtonDV menuButton;

		[NullCheck]
		public ButtonDV closeButton;

		[NullCheck]
		public InventorySectionController backpackController;

		[NullCheck]
		public InventorySectionController hotbarController;

		[NullCheck]
		public InventorySectionController handController;

		[NullCheck]
		public InventorySectionController itemContainerController;

		private bool itemGetterAllowed;

		public bool ItemGetterAllowed
		{
			get
			{
				return itemGetterAllowed;
			}
			protected set
			{
				if (itemGetterAllowed != value)
				{
					itemGetterAllowed = value;
					if (backpackController != null)
					{
						backpackController.ToggleItemGetters(value);
					}
					if (hotbarController != null)
					{
						hotbarController.ToggleItemGetters(value);
					}
				}
			}
		}

		public abstract bool IsOpen { get; }

		public event SlotClickedDelegate SlotClicked;

		public event SlotPressChangedDelegate SlotPressChanged;

		public event SelectionChangedDelegate SelectionChanged;

		public event BeltButtonInteractionDelegate BeltToggleRequested;

		public event BeltButtonInteractionDelegate BeltResetRequested;

		public event Action<bool> OpenedOrClosed;

		public event Action PauseMenuRequested;

		public event Action AboutToClose;

		public event Action<AItemContainer, bool> ContainerAccessClicked;

		public event Action<bool> BackpackAccessClicked;

		public abstract void Toggle(bool on);

		public abstract int GetBackpackCapacity();

		public abstract int GetHotbarCapacity();

		public abstract int GetHandCapacity();

		public abstract InventorySlotDisplayData GetEmptySlotData(int index, InventorySectionController controller);

		public abstract int RequestAddItem(InventorySlotDisplayData data, int slotIndex, InventorySectionController controller);

		public abstract GameObject RequestRemoveItem(int slot, InventorySectionController controller);

		public abstract void RequestDropItem(int slot, InventorySectionController controller, int potentialEquipSlot);

		public abstract void RequestMoveItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController, int potentialEquipSlot, AItemContainer targetContainer);

		public abstract void RequestSwapItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController, int potentialEquipSlot, AItemContainer targetContainer);

		public abstract void RequestEquipItem(IInventoryItemSpec inventoryItemSpec, int equipSlot);

		public abstract void RequestUnequipItem(int equipSlot);

		public abstract void RequestClearInventory();

		protected abstract void AddItem(InventorySlotDisplayData data, int slotIndex, InventorySectionController controller);

		protected abstract void RemoveItem(int slot, InventorySectionController controller);

		protected abstract void DropItem(int slot, bool leaveGhost, InventorySectionController controller);

		protected abstract void MoveItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController);

		protected abstract void SwapItem(int source, InventorySectionController sourceController, int target, InventorySectionController targetController);

		protected abstract void EquipItem(IInventoryItemSpec itemSpec, int slot, int equipSlot, InventorySectionController sourceController);

		public abstract void OverrideDragAndContainerClickInteraction(int equipSlot, PointerEventData pointerEventData);

		protected abstract void UnequipItem(int equippedSlot, bool addToInventory = true);

		protected abstract void ClearInventory();

		protected abstract bool IsSlotEmpty(int slot, InventorySectionController controller);

		protected abstract bool IsSlotGhost(int slot, InventorySectionController controller);

		public abstract void SetSelectedSlot(int slot);

		protected abstract DataAsIndexAndController GetIndexAndControllerOfSpec(IInventoryItemSpec spec);

		protected virtual void SlotClicked_Fire(int index)
		{
			this.SlotClicked?.Invoke(index);
		}

		protected virtual void SlotPressChanged_Fire(int index, bool pressed, bool isContainer)
		{
			this.SlotPressChanged?.Invoke(index, pressed, isHandSlot: false, isContainer);
		}

		protected virtual void HandSlotPressChanged_Fire(int index, bool pressed)
		{
			this.SlotPressChanged?.Invoke(index, pressed, isHandSlot: true, isContainerSlot: false);
		}

		protected virtual void SelectionChanged_Fire(int index, InventorySectionController controller)
		{
			this.SelectionChanged?.Invoke(index, controller);
		}

		protected virtual void BeltToggleRequested_Fire(int index)
		{
			this.BeltToggleRequested?.Invoke(index);
		}

		protected virtual void BeltResetRequested_Fire(int index)
		{
			this.BeltResetRequested?.Invoke(index);
		}

		protected virtual void OpenedOrClosed_Fire(bool on)
		{
			this.OpenedOrClosed?.Invoke(on);
		}

		protected virtual void PauseMenuRequested_Fire()
		{
			this.PauseMenuRequested?.Invoke();
		}

		protected virtual void AboutToClose_Fire()
		{
			this.AboutToClose?.Invoke();
		}

		protected virtual void ContainerAccessClicked_Fire(AItemContainer container, bool isForceDragging)
		{
			this.ContainerAccessClicked?.Invoke(container, isForceDragging);
		}

		protected virtual void BackpackAccessClicked_Fire(bool isForceDragging)
		{
			this.BackpackAccessClicked?.Invoke(isForceDragging);
		}
	}
}
