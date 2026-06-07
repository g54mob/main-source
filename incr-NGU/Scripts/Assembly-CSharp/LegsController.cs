using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LegsController : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
	public Character character;

	public Image image;

	public Image border;

	public Image ghost;

	public HoverTooltip tooltip;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	private string message;

	private void Start()
	{
		updateItem();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		character.inventory.item1 = -3;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (character.inventory.legs == null)
		{
			ghost.sprite = Resources.Load<Sprite>("NoItem");
		}
		else
		{
			ghost.sprite = Resources.Load<Sprite>(character.inventory.legs.path);
		}
		ghost.transform.position = new Vector3(Input.mousePosition.x - 20f, Input.mousePosition.y + 20f);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		ghost.transform.position = new Vector3(-2000f, -2000f);
		inventoryController.swapLegs();
		inventoryController.updateLegs();
		inventoryController.updateItem(character.inventory.item2);
	}

	public void OnDrop(PointerEventData eventData)
	{
		character.inventory.item2 = -3;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Input.GetKey(KeyCode.A))
		{
			inventoryController.applyAllBoosts(-3);
			tooltip.showTooltip("ZWOOP! All possible boosts have been used on this equipment!,", 2f);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			inventoryController.mergeAll(-3);
			tooltip.showTooltip("FWOOP! All possible merges have been used on this equipment!,", 2f);
		}
	}

	public void updateItem()
	{
		if (character.inventory.legs.id == 0)
		{
			border.color = Color.white;
			image.sprite = Resources.Load<Sprite>("Equipment/EmptyLegs");
		}
		else
		{
			image.sprite = Resources.Load<Sprite>(character.inventory.legs.path);
			border.color = Color.gray;
			if (!character.inventory.legs.removable)
			{
				border.color = Color.red;
			}
		}
		updateTooltipMessage();
	}

	public void updateTooltipMessage()
	{
		message = character.inventoryController.itemTooltipText(-3);
	}

	public void updateLegsStats()
	{
		int id = character.inventory.legs.id;
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
			character.inventory.legs.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}
}
