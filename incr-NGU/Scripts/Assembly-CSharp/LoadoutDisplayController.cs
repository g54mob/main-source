using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadoutDisplayController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public Image image;

	public Image border;

	public HoverTooltip tooltip;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	public int id;

	public int loadoutID;

	private string message;

	private void Start()
	{
		updateItem();
	}

	public Sprite findEquipSprite()
	{
		int num = 0;
		switch (id)
		{
		case -1:
			num = character.inventory.loadouts[loadoutID].head;
			break;
		case -2:
			num = character.inventory.loadouts[loadoutID].chest;
			break;
		case -3:
			num = character.inventory.loadouts[loadoutID].legs;
			break;
		case -4:
			num = character.inventory.loadouts[loadoutID].boots;
			break;
		case -5:
			num = character.inventory.loadouts[loadoutID].weapon;
			break;
		case -6:
			num = character.inventory.loadouts[loadoutID].weapon2;
			break;
		}
		if (id >= 10000 && id < 100000)
		{
			num = character.inventory.loadouts[loadoutID].accessories[id - 10000];
		}
		if (num >= 100000)
		{
			return character.itemInfo.graphic[character.inventory.daycare[num - 100000].id];
		}
		if (num == -1000)
		{
			return emptySprite();
		}
		if (num >= 0 && num < character.inventory.inventory.Count)
		{
			return character.itemInfo.graphic[character.inventory.inventory[num].id];
		}
		if (num >= 10000 && num <= 100000)
		{
			return character.itemInfo.graphic[character.inventory.accs[num - 10000].id];
		}
		switch (num)
		{
		case -1:
			return character.itemInfo.graphic[character.inventory.head.id];
		case -2:
			return character.itemInfo.graphic[character.inventory.chest.id];
		case -3:
			return character.itemInfo.graphic[character.inventory.legs.id];
		case -4:
			return character.itemInfo.graphic[character.inventory.boots.id];
		case -5:
			return character.itemInfo.graphic[character.inventory.weapon.id];
		case -6:
			return character.itemInfo.graphic[character.inventory.weapon2.id];
		default:
			return emptySprite();
		}
	}

	public Sprite emptySprite()
	{
		switch (id)
		{
		case -1:
			return character.itemInfo.miscSprites[2];
		case -2:
			return character.itemInfo.miscSprites[3];
		case -3:
			return character.itemInfo.miscSprites[4];
		case -4:
			return character.itemInfo.miscSprites[5];
		case -5:
			return character.itemInfo.miscSprites[6];
		case -6:
			return character.itemInfo.miscSprites[6];
		default:
			return character.itemInfo.miscSprites[7];
		}
	}

	public void updateItem()
	{
		if ((id >= 10000 && id - 10000 >= character.inventory.accs.Count) || (id == -6 && !character.inventoryController.weapon2Unlocked()))
		{
			image.enabled = false;
			border.enabled = false;
			return;
		}
		image.enabled = true;
		border.enabled = true;
		updateTooltipMessage();
		image.sprite = findEquipSprite();
	}

	public void updateTooltipMessage()
	{
		int num = 0;
		switch (id)
		{
		case -1:
			num = character.inventory.loadouts[loadoutID].head;
			break;
		case -2:
			num = character.inventory.loadouts[loadoutID].chest;
			break;
		case -3:
			num = character.inventory.loadouts[loadoutID].legs;
			break;
		case -4:
			num = character.inventory.loadouts[loadoutID].boots;
			break;
		case -5:
			num = character.inventory.loadouts[loadoutID].weapon;
			break;
		case -6:
			num = character.inventory.loadouts[loadoutID].weapon2;
			break;
		}
		if (id >= 10000 && id < 100000)
		{
			num = character.inventory.loadouts[loadoutID].accessories[id - 10000];
		}
		if (num == -1000)
		{
			message = "";
		}
		else
		{
			message = character.inventoryController.itemTooltipText(num);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (character.inventoryController.accessoryID(id) <= character.inventory.accs.Count)
		{
			int num = 0;
			switch (id)
			{
			case -1:
				num = character.inventory.loadouts[loadoutID].head;
				break;
			case -2:
				num = character.inventory.loadouts[loadoutID].chest;
				break;
			case -3:
				num = character.inventory.loadouts[loadoutID].legs;
				break;
			case -4:
				num = character.inventory.loadouts[loadoutID].boots;
				break;
			case -5:
				num = character.inventory.loadouts[loadoutID].weapon;
				break;
			case -6:
				num = character.inventory.loadouts[loadoutID].weapon2;
				break;
			}
			if (id >= 10000 && id < 100000)
			{
				num = character.inventory.loadouts[loadoutID].accessories[id - 10000];
			}
			if (num != -1000)
			{
				tooltip.showOverrideTooltip(message);
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
