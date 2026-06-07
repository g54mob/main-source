using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trash : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Image ghost;

	public Image border;

	public Image image;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	public void OnBeginDrag(PointerEventData eventData)
	{
		character.inventory.item1 = -69;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (character.inventory.trash.id == 0)
		{
			ghost.sprite = Resources.Load<Sprite>("NoItem");
		}
		else
		{
			ghost.sprite = character.itemInfo.graphic[character.inventory.trash.id];
		}
		ghost.transform.position = new Vector3(Input.mousePosition.x - 6f, Input.mousePosition.y + 6f);
	}

	public void OnDrop(PointerEventData eventData)
	{
		character.inventory.item2 = -69;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		ghost.transform.position = new Vector3(-2000f, -2000f);
		if (character.inventory.item2 >= 0)
		{
			recoverItem(character.inventory.item2);
		}
		inventoryController.updateItem(character.inventory.item2);
		inventoryController.updateTrash();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip("Drag items onto this spot to Trash them from your inventory. You can recover the last item you tossed in here, but after that, it's gone!");
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void recoverItem(int id)
	{
		if (id <= character.inventoryController.curSpaces() && character.inventory.trash.id != 0 && character.inventory.inventory[id].id == 0)
		{
			character.inventory.inventory[id] = character.inventory.trash;
			character.inventory.trash = new Equipment();
		}
	}

	public void trashItem(int id)
	{
		if (character.inventory.inventory[id].removable && character.inventory.inventory[id].id != 0)
		{
			character.inventory.trash = character.inventory.inventory[id];
			character.inventory.deleteItem(id);
		}
	}

	public void updateItem()
	{
		if (character.inventory.trash.id == 0)
		{
			border.color = Color.white;
			image.sprite = Resources.Load<Sprite>("Trash");
			return;
		}
		image.sprite = itemInfo.graphic[character.inventory.trash.id];
		border.color = Color.gray;
		if (!character.inventory.trash.removable)
		{
			border.color = Color.red;
		}
	}

	public void updateTrashStats()
	{
		int id = character.inventory.trash.id;
		if (id != 0)
		{
			int rboss = itemInfo.bossRequired[id];
			part ptype = itemInfo.type[id];
			float capatk = itemInfo.capAttack[id];
			float curatk = itemInfo.curAttack[id];
			float capdef = itemInfo.capDefense[id];
			float curdef = itemInfo.curDefense[id];
			specType type = itemInfo.specType1[id];
			float capspec = itemInfo.capSpec1[id];
			float curspec = itemInfo.curSpec1[id];
			specType type2 = itemInfo.specType2[id];
			float capspec2 = itemInfo.capSpec2[id];
			float curspec2 = itemInfo.curSpec2[id];
			specType type3 = itemInfo.specType3[id];
			float capspec3 = itemInfo.capSpec3[id];
			float curspec3 = itemInfo.curSpec3[id];
			string npath = itemInfo.path[id];
			bool punique = itemInfo.unique[id];
			character.inventory.trash.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}
}
