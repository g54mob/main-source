using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

namespace DV.InventorySystem
{
	public class InventoryViewNonVR : InventoryViewBase
	{
		public override bool IsVR => false;

		public override bool BigInventoryOpen
		{
			get
			{
				if (inventoryUI != null)
				{
					return inventoryUI.IsOpen;
				}
				return false;
			}
		}

		private void Start()
		{
			SetupListeners(on: true);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				inventoryUI.OpenedOrClosed += InventoryUIOnOpenedOrClosed;
				inventoryUI.SlotPressChanged += OnSlotPressChanged;
			}
			else
			{
				inventoryUI.OpenedOrClosed -= InventoryUIOnOpenedOrClosed;
				inventoryUI.SlotPressChanged -= OnSlotPressChanged;
			}
		}

		private void OnSlotPressChanged(int index, bool pressed, bool isHandSlot, bool isContainerSlot)
		{
			if (pressed)
			{
				if (InputManager.NewPlayer.GetButton(InputManager.Actions.InventoryQuickEquipModifier))
				{
					QuickEquipAction(index, isHandSlot, isContainerSlot);
				}
				else if (InputManager.NewPlayer.GetButton(InputManager.Actions.InventoryQuickMoveModifier))
				{
					QuickMoveAction(index, isHandSlot, isContainerSlot);
				}
			}
		}

		private void QuickEquipAction(int index, bool isHandSlot, bool isContainerSlot)
		{
			AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
			if (isHandSlot)
			{
				GameObject equippedItemAtSlot = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0);
				if (equippedItemAtSlot == null)
				{
					return;
				}
				if (InventoryUtils.IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.IndexOf(equippedItemAtSlot)))
				{
					SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: true, 0);
				}
				else if (activeContainer == null)
				{
					bool addToInventory = InventoryUtils.IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.GetFirstFreeSlot());
					SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory, 0);
				}
				else if (InventoryUtils.IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.GetFirstFreeHotbarSlot()))
				{
					SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: true, 0);
				}
				else if (activeContainer.ValidItem(equippedItemAtSlot))
				{
					int firstFreeSlot = activeContainer.GetFirstFreeSlot();
					if (firstFreeSlot >= 0)
					{
						SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: false, 0);
						activeContainer.AddItem(equippedItemAtSlot, firstFreeSlot);
					}
				}
				return;
			}
			if (isContainerSlot)
			{
				GameObject gameObject = ((activeContainer != null) ? activeContainer[index] : null);
				if (gameObject == null)
				{
					return;
				}
				GameObject equippedItemAtSlot2 = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0);
				if (equippedItemAtSlot2 == null)
				{
					activeContainer.RemoveItem(index, activateItem: true, dropItem: false);
				}
				else
				{
					if (!activeContainer.ValidItem(equippedItemAtSlot2))
					{
						return;
					}
					activeContainer.RemoveItem(index, activateItem: true, dropItem: false);
					SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory: false, 0);
					activeContainer.AddItem(equippedItemAtSlot2, index);
				}
				SingletonBehaviour<Inventory>.Instance.EquipItem(gameObject, 0);
				return;
			}
			GameObject gameObject2 = SingletonBehaviour<Inventory>.Instance.PeekItemAtSlot(index, includeDropped: false);
			if (!(gameObject2 == null))
			{
				GameObject equippedItemAtSlot3 = SingletonBehaviour<Inventory>.Instance.GetEquippedItemAtSlot(0);
				if (equippedItemAtSlot3 != null)
				{
					bool addToInventory2 = InventoryUtils.IsValidInventoryIndex(SingletonBehaviour<Inventory>.Instance.IndexOf(equippedItemAtSlot3));
					SingletonBehaviour<Inventory>.Instance.UnequipItem(addToInventory2, 0);
				}
				SingletonBehaviour<Inventory>.Instance.EquipItem(gameObject2, 0);
			}
		}

		private void QuickMoveAction(int index, bool isHandSlot, bool isContainerSlot)
		{
			if (!ValidQuickMoveSlot(index, isHandSlot, isContainerSlot))
			{
				return;
			}
			AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
			bool flag = !isContainerSlot && InventoryUtils.IsValidHotbarIndex(index);
			if (activeContainer != null)
			{
				if (flag)
				{
					GameObject item = SingletonBehaviour<Inventory>.Instance.PeekItemAtSlot(index, includeDropped: false);
					if (activeContainer.ValidItem(item))
					{
						int firstFreeSlot = activeContainer.GetFirstFreeSlot();
						if (firstFreeSlot >= 0)
						{
							SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(index, keepInactive: true);
							activeContainer.AddItem(item, firstFreeSlot);
						}
					}
				}
				else
				{
					int firstFreeHotbarSlot = SingletonBehaviour<Inventory>.Instance.GetFirstFreeHotbarSlot();
					if (firstFreeHotbarSlot >= 0)
					{
						GameObject item2 = activeContainer[index];
						activeContainer.RemoveItem(index, activateItem: false, dropItem: false);
						SingletonBehaviour<Inventory>.Instance.AddItemToInventory(item2, firstFreeHotbarSlot);
					}
				}
			}
			else
			{
				int num = (flag ? SingletonBehaviour<Inventory>.Instance.GetFirstFreeBackpackSlot() : SingletonBehaviour<Inventory>.Instance.GetFirstFreeHotbarSlot());
				if (InventoryUtils.IsValidInventoryIndex(num))
				{
					SingletonBehaviour<Inventory>.Instance.MoveItemFromTo(index, num);
				}
			}
		}

		private bool ValidQuickMoveSlot(int index, bool isHand, bool isContainer)
		{
			if (isHand)
			{
				return false;
			}
			if (isContainer)
			{
				AItemContainer activeContainer = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer;
				if (activeContainer == null)
				{
					return false;
				}
				return activeContainer[index] != null;
			}
			if (SingletonBehaviour<Inventory>.Instance.IsSlotEmpty(index))
			{
				return false;
			}
			if (SingletonBehaviour<Inventory>.Instance.GetSlotDroppedState(index))
			{
				return false;
			}
			if (SingletonBehaviour<Inventory>.Instance.GetSlotLockState(index))
			{
				return false;
			}
			return true;
		}

		private void InventoryUIOnOpenedOrClosed(bool on)
		{
			bool flag = SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer != null;
			if (!flag)
			{
				inventorySounds.PlayInventoryOpenOrCloseSound(on);
			}
			if (on)
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.RequestOverride(this, on: false, 1);
			}
			else
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
				if (flag)
				{
					SingletonBehaviour<Inventory>.Instance.ItemContainerRegistry.ActiveContainer = null;
				}
			}
			OnBigInventoryOpenChanged_Fire();
		}
	}
}
