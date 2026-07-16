using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private Image iconItem;

	[SerializeField]
	private Image slotSelection;

	[SerializeField]
	private TMP_Text labelName;

	[SerializeField]
	private TMP_Text labelAmount;

	public Item assignedItem = Item.Empty();

	public int inventoryId = -1;

	public int slotId = -1;

	public bool leftClickOnly;

	public bool takeOnly;

	public bool onlyValidItem;

	public Item validItem = Item.Empty();

	public UnityEvent OnButtonPress = new UnityEvent();

	[SerializeField]
	private string soundOnClick;

	[SerializeField]
	private string soundOnTakeItem;

	[SerializeField]
	private string soundOnEmpty;

	[SerializeField]
	private string soundOnInValid;

	private void Start()
	{
	}

	public void SetInventory(int id)
	{
		inventoryId = id;
	}

	public void SetSlotId(int id)
	{
		slotId = id;
	}

	public void SetSlotItem(Item item)
	{
		if (item.id == -1)
		{
			ResetSlot();
			return;
		}
		if (onlyValidItem && item.id != validItem.id)
		{
			SoundManager.PlaySoundOnce(soundOnInValid);
			return;
		}
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[item.id];
		assignedItem = item;
		if (labelName != null)
		{
			labelName.text = itemInfo.GetLocalizedName();
		}
		if (labelAmount != null)
		{
			labelAmount.text = item.amount.ToString();
		}
		iconItem.sprite = itemInfo.icon;
		iconItem.enabled = true;
	}

	public void SetValidItem(Item validationItem, bool useValidation = true)
	{
		validItem = validationItem;
		onlyValidItem = useValidation;
	}

	public void UpdateSlotItem()
	{
		if (assignedItem.id == -1)
		{
			ResetSlot();
			return;
		}
		ItemInfo itemInfo = InventorySystem.GetItemLibrary().itemInfos[assignedItem.id];
		if (labelName != null)
		{
			labelName.text = itemInfo.GetLocalizedName();
		}
		if (labelAmount != null)
		{
			labelAmount.text = assignedItem.amount + "x";
		}
		iconItem.sprite = itemInfo.icon;
		iconItem.enabled = true;
	}

	public void UpdateInventorySlot()
	{
		InventorySystem.GetInventory(inventoryId).items[slotId] = assignedItem;
		InventorySystem.GetInventory(inventoryId).OnInventoryItemsChangeEvent.Invoke();
	}

	public void RemoveItem()
	{
		ResetSlot();
	}

	private void ResetSlot()
	{
		if (labelName != null)
		{
			labelName.text = "";
		}
		if (labelAmount != null)
		{
			labelAmount.text = "";
		}
		assignedItem.id = -1;
		assignedItem.amount = 0;
		iconItem.sprite = null;
		iconItem.enabled = false;
	}

	private bool IsSlotEmpty()
	{
		return assignedItem.id == -1;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (takeOnly)
		{
			PressedSelection(assignedItem.amount);
			OnButtonPress.Invoke();
		}
		else if (eventData.button == PointerEventData.InputButton.Left || leftClickOnly)
		{
			PressedSelection(assignedItem.amount);
			OnButtonPress.Invoke();
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			PressedSelection(Mathf.RoundToInt((float)assignedItem.amount * 0.5f), useBehaviour: false, rightClick: true);
			OnButtonPress.Invoke();
		}
	}

	public void PressedSelection(int selectAmount = 100, bool useBehaviour = true, bool rightClick = false)
	{
		if (GameStateManager.GetCurrentCharacterState() == GameStateManager.CharacterState.ShopMode && rightClick)
		{
			_ = assignedItem.id;
			_ = -1;
		}
		if (DragDropPointer.IsDraggingObject())
		{
			if (onlyValidItem && DragDropPointer.DraggedItem().id != validItem.id)
			{
				SoundManager.PlaySoundOnce(soundOnInValid);
				return;
			}
			DragDropPointer.TransferItem(inventoryId, this, (rightClick && !leftClickOnly) ? 1 : (-1));
			SoundManager.PlaySoundOnce(soundOnClick);
		}
		else if (IsSlotEmpty())
		{
			SoundManager.PlaySoundOnce(soundOnEmpty);
		}
		else if (!useBehaviour)
		{
			if (assignedItem.id != -1 && assignedItem.amount > 1)
			{
				DragDropPointer.BeginDragItemWithAmount(assignedItem.id, selectAmount, assignedItem.tag, this, inventoryId);
				SoundManager.PlaySoundOnce(soundOnTakeItem);
			}
		}
		else if (InventorySystemMenu.GetCurrentInventoryMode() != InventorySystemMenu.InventoryMode.OnlyToolbar)
		{
			if (assignedItem.id != -1 && selectAmount != 0)
			{
				DragDropPointer.BeginDragItemWithAmount(assignedItem.id, selectAmount, assignedItem.tag, this, inventoryId);
				SoundManager.PlaySoundOnce(soundOnTakeItem);
			}
		}
		else if (InventorySystem.GetItemLibrary().itemInfos[assignedItem.id].behaviorType != ItemBehaviour.BehaviourType.Placeable || takeOnly)
		{
			if (assignedItem.amount != 0 && selectAmount != 0)
			{
				DragDropPointer.BeginDragItemWithAmount(assignedItem.id, selectAmount, assignedItem.tag, this, inventoryId);
				SoundManager.PlaySoundOnce(soundOnTakeItem);
			}
		}
		else
		{
			SelectItemFromSlot();
		}
	}

	public void OnEnterInfoBox()
	{
	}

	public void OnExitInfoBox()
	{
	}

	public void SelectItemFromSlot()
	{
		InventorySystem.GetInventory(inventoryId).SelectItem(slotId);
		if (assignedItem.id != -1)
		{
			ItemBehaviour.GetBehaviourAsIBehaviour(InventorySystem.GetItemLibrary().itemInfos[assignedItem.id].behaviorType).OnItemSelection(assignedItem);
		}
	}

	public int SelectSlot()
	{
		if (slotSelection != null)
		{
			slotSelection.gameObject.SetActive(value: true);
		}
		return slotId;
	}

	public void DeselectSlot()
	{
		if (slotSelection != null)
		{
			slotSelection.gameObject.SetActive(value: false);
		}
	}
}
