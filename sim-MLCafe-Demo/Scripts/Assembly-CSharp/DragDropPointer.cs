using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DragDropPointer : MonoBehaviour
{
	[SerializeField]
	private RectTransform dragDropObject;

	[SerializeField]
	private Image iconSelectedItem;

	[SerializeField]
	private TMP_Text labelItemAmount;

	private static DragDropPointer instance;

	private bool isDragging;

	private Item draggedItem;

	private ItemSlot previousSlot;

	private int previousInventory;

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
		dragDropObject.gameObject.SetActive(value: false);
		EndDragItem();
	}

	public static bool IsDraggingObject()
	{
		return instance.isDragging;
	}

	public static Item DraggedItem()
	{
		return instance.draggedItem;
	}

	private void UpdateDragPreview()
	{
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[draggedItem.id];
		instance.iconSelectedItem.sprite = itemInfo.icon;
		instance.labelItemAmount.text = draggedItem.amount.ToString();
	}

	private void SwapDragItemWithSlot(ItemSlot slot)
	{
		Item assignedItem = slot.assignedItem;
		slot.assignedItem = draggedItem;
		slot.UpdateSlotItem();
		slot.UpdateInventorySlot();
		SetDragItem(assignedItem);
	}

	public static bool AddToDragStack(int amount, out int overflow)
	{
		if (instance.draggedItem.amount + amount > instance.draggedItem.maxAmount)
		{
			overflow = instance.draggedItem.amount + amount - instance.draggedItem.maxAmount;
			instance.draggedItem.amount = instance.draggedItem.maxAmount;
			instance.UpdateDragPreview();
			return false;
		}
		instance.draggedItem.amount += amount;
		overflow = 0;
		instance.UpdateDragPreview();
		return true;
	}

	public static void SetDragItem(Item item)
	{
		instance.draggedItem = item;
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[item.id];
		instance.iconSelectedItem.sprite = itemInfo.icon;
		instance.labelItemAmount.text = item.amount.ToString();
		instance.isDragging = true;
		instance.dragDropObject.gameObject.SetActive(value: true);
	}

	public static void BeginDragItem(Item item, ItemSlot slot, int inventory)
	{
		instance.previousSlot = slot;
		instance.previousInventory = inventory;
		instance.draggedItem = item;
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[item.id];
		instance.iconSelectedItem.sprite = itemInfo.icon;
		instance.labelItemAmount.text = item.amount.ToString();
		instance.isDragging = true;
		instance.dragDropObject.gameObject.SetActive(value: true);
		InventorySystem.RemoveItemFromInventorySlot(item.id, inventory, slot.slotId);
	}

	public static void BeginDragItemWithAmount(int itemId, int amount, AnomalyTag tags, ItemSlot slot, int inventory)
	{
		int num = ((inventory != -1) ? InventorySystem.GetInventory(inventory).items[slot.slotId].amount : slot.assignedItem.amount);
		int amount2 = ((num < amount) ? num : amount);
		Item item = Item.Create(itemId, amount2, tags);
		instance.previousSlot = slot;
		instance.previousInventory = inventory;
		instance.draggedItem = item;
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[item.id];
		instance.iconSelectedItem.sprite = itemInfo.icon;
		instance.labelItemAmount.text = item.amount.ToString();
		instance.isDragging = true;
		instance.dragDropObject.gameObject.SetActive(value: true);
		if (inventory != -1)
		{
			InventorySystem.RemoveItemAmountFromInventorySlotWith(itemId, inventory, slot.slotId, amount);
		}
	}

	public static void TransferItem(int toInventory, ItemSlot targetDropItemSlot, int amount = -1)
	{
		if (targetDropItemSlot.assignedItem.id == -1 && amount == -1)
		{
			InventorySystem.TransferToEmptySlot(DraggedItem(), toInventory, targetDropItemSlot);
			EndDragItem();
		}
		else if (targetDropItemSlot.assignedItem.id == -1 && amount == 1)
		{
			Item item = DraggedItem();
			item.amount = amount;
			InventorySystem.TransferToEmptySlot(item, toInventory, targetDropItemSlot);
			instance.draggedItem.amount -= amount;
			instance.UpdateDragPreview();
			if (DraggedItem().amount <= 0)
			{
				EndDragItem();
			}
		}
		else
		{
			if (targetDropItemSlot.assignedItem.id == instance.draggedItem.id && targetDropItemSlot.assignedItem.amount >= targetDropItemSlot.assignedItem.maxAmount)
			{
				return;
			}
			if (targetDropItemSlot.assignedItem.id != -1 && targetDropItemSlot.assignedItem.id != instance.draggedItem.id)
			{
				instance.SwapDragItemWithSlot(targetDropItemSlot);
				instance.UpdateDragPreview();
				return;
			}
			if (targetDropItemSlot.assignedItem.id == instance.draggedItem.id && targetDropItemSlot.assignedItem.amount < targetDropItemSlot.assignedItem.maxAmount && amount == 1)
			{
				InventorySystem.TransferItemAmountToStack(toInventory, targetDropItemSlot, amount);
				instance.draggedItem.amount -= amount;
				instance.UpdateDragPreview();
				if (DraggedItem().amount <= 0)
				{
					EndDragItem();
				}
				return;
			}
			int num = ((amount > 0) ? amount : instance.draggedItem.amount);
			int num2 = targetDropItemSlot.assignedItem.maxAmount - targetDropItemSlot.assignedItem.amount;
			int num3 = ((num > num2) ? (num2 - num) : num);
			int amount2 = 0;
			if (num3 < 0)
			{
				amount2 = num3 * -1;
				num3 = num2;
			}
			Debug.Log("FINAL TRANSFER AMOUNT: " + num3 + " Overflow: " + amount2);
			InventorySystem.TransferItemAmountToStack(toInventory, targetDropItemSlot, num3);
			instance.draggedItem.amount = amount2;
			if (instance.draggedItem.amount <= 0)
			{
				EndDragItem();
			}
			else
			{
				instance.UpdateDragPreview();
			}
		}
	}

	public static void TransferItemToInventory(int toInventory, bool searchForEmptySlot = true)
	{
		if (InventorySystem.HasItem(DraggedItem().id, toInventory))
		{
			int itemIndex = InventorySystem.GetInventory(toInventory).GetItemIndex(DraggedItem().id);
			InventorySystem.TransferToEmptySlot(DraggedItem(), toInventory, itemIndex);
			EndDragItem();
		}
		else if (searchForEmptySlot)
		{
			InventorySystem.TransferToEmptySlot(DraggedItem(), toInventory, InventorySystem.GetInventory(toInventory).GetEmptySlot());
			EndDragItem();
		}
	}

	public static void TransferSingleItem(int toInventory, ItemSlot targetDropItemSlot, AnomalyTag tags)
	{
		InventorySystem.TransferItemToAnotherInventorySlot(instance.draggedItem.id, toInventory, targetDropItemSlot, tags);
		instance.draggedItem.amount--;
		if (instance.draggedItem.amount <= 0)
		{
			EndDragItem();
		}
		else
		{
			instance.UpdateDragPreview();
		}
	}

	public static void CancelDrag()
	{
		EndDragItem();
	}

	public static void EndDragItem()
	{
		instance.previousSlot = null;
		instance.previousInventory = -1;
		instance.draggedItem = Item.Empty();
		instance.iconSelectedItem.sprite = null;
		instance.labelItemAmount.text = "";
		instance.isDragging = false;
		instance.dragDropObject.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (isDragging)
		{
			dragDropObject.position = InputManager.GetPointerPosition();
		}
	}
}
