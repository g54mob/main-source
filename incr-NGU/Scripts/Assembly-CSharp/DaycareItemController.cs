using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DaycareItemController : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
	public Character character;

	public Image image;

	public Image border;

	public Image ghost;

	public GameObject sliderBG;

	public HoverTooltip tooltip;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	public int id;

	public Slider daycareSlider;

	public Text daycareText;

	private string message;

	public void Update()
	{
		updateDaycareTimer();
	}

	public void updateDaycareTimer()
	{
		if (id >= character.inventory.daycareTimers.Count)
		{
			return;
		}
		if ((character.inventory.daycare[id].id > 0 && character.inventory.daycare[id].level < 100) || character.inventory.daycare[id].type == part.MacGuffin)
		{
			character.inventory.daycareTimers[id].advanceTime(Time.deltaTime * character.allDiggers.totalDaycareBonus());
		}
		if (character.menuID == 4)
		{
			daycareSlider.value = (float)(character.inventory.daycareTimers[id].totalseconds % (double)daycareRate(equip()) / (double)daycareRate(equip()));
			if (character.inventory.daycare[id].id == 0)
			{
				daycareText.text = "Place an item in the Slot! :D";
			}
			else if (character.inventory.daycare[id].level >= 100 && character.inventory.daycare[id].type != part.MacGuffin)
			{
				daycareText.text = "This item is level 100 already.";
			}
			else
			{
				daycareText.text = "<b>Levels Gained: " + levelsAdded() + "</b>";
			}
		}
	}

	private void Start()
	{
		daycareText.text = "";
	}

	public Equipment equip()
	{
		return character.inventory.daycare[id];
	}

	public int daycareID(int globalID)
	{
		if (globalID - 100000 < 0)
		{
			return -1;
		}
		return globalID - 100000;
	}

	public int globalID()
	{
		return id + 100000;
	}

	public float daycareRate(Equipment equip)
	{
		return character.inventoryController.daycaresController.daycareTime(equip);
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && !inventoryController.midDrag)
		{
			inventoryController.midDrag = true;
			if (!Input.GetMouseButton(1))
			{
				character.inventory.item1 = globalID();
				character.inventory.item2 = globalID();
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && equip().id != 0)
		{
			ghost.sprite = itemInfo.graphic[equip().id];
			ghost.transform.position = new Vector3(Input.mousePosition.x - 6f, Input.mousePosition.y + 6f);
		}
	}

	public void endDragAction()
	{
		if (character.inventory.item1 == character.inventory.item2 || id == -100)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
		}
		else if (daycareID(character.inventory.item2) > 0 && daycareID(character.inventory.item1) > 0)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
		}
		else if (character.inventoryController.accessoryID(character.inventory.item2) > 0 || character.inventoryController.accessoryID(character.inventory.item1) > 0)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
		}
		else if (character.inventory.item2 < 0 || character.inventory.item1 < 0)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
		}
		else if (character.inventory.item2 >= 0 && character.inventory.item2 < character.inventory.inventory.Count && daycareID(character.inventory.item1) >= 0)
		{
			character.inventoryController.swapDaycare();
			inventoryController.updateInventory();
			inventoryController.updateItem(character.inventory.item2);
		}
	}

	public int levelsAdded()
	{
		if (id > character.inventory.daycare.Count)
		{
			return 0;
		}
		if (character.inventory.daycare[id].id == 0)
		{
			return 0;
		}
		int num = (int)Math.Floor(character.inventory.daycareTimers[id].totalseconds / (double)daycareRate(equip()));
		if (character.inventory.daycare[id].level + num > 100 && character.inventory.daycare[id].type != part.MacGuffin)
		{
			num = 100 - character.inventory.daycare[id].level;
		}
		return num;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			if (equip().id == 0)
			{
				character.inventory.item1 = 0;
				character.inventory.item2 = 0;
				ghost.transform.position = new Vector3(-2000f, -2000f);
				inventoryController.midDrag = false;
			}
			else
			{
				ghost.transform.position = new Vector3(-2000f, -2000f);
				endDragAction();
				inventoryController.midDrag = false;
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			character.inventory.item2 = globalID();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id < character.inventory.daycare.Count)
		{
			InvokeRepeating("showTooltip", 0f, 1f);
		}
	}

	public void showTooltip()
	{
		updateTooltipMessage();
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	public Sprite emptySprite()
	{
		return itemInfo.miscSprites[0];
	}

	public void updateItem()
	{
		if (id >= character.inventory.daycare.Count)
		{
			image.enabled = false;
			border.enabled = false;
			daycareSlider.gameObject.SetActive(value: false);
			sliderBG.SetActive(value: false);
			return;
		}
		if (id >= character.inventoryController.daycareSpaces())
		{
			image.enabled = false;
			border.enabled = false;
			daycareSlider.gameObject.SetActive(value: false);
			sliderBG.SetActive(value: false);
			return;
		}
		sliderBG.SetActive(value: true);
		daycareSlider.gameObject.SetActive(value: true);
		image.enabled = true;
		border.enabled = true;
		if (equip().id == 0)
		{
			border.color = Color.white;
			image.sprite = emptySprite();
			return;
		}
		image.sprite = itemInfo.graphic[equip().id];
		border.color = Color.white;
		if (!equip().removable)
		{
			border.color = Color.red;
		}
	}

	public void updateTooltipMessage()
	{
		if (id >= character.inventory.daycareTimers.Count)
		{
			message = "";
			return;
		}
		if (equip().id == 0)
		{
			message = "Place an item here to have some sweet senile grannies take care of it, which will grant FREE levels slowly over time!";
			return;
		}
		message = "Item's original level was <b>" + equip().level + "</b>.\n" + timeLeftMessage();
		Equipment equipment = itemInfo.makeDummy(equip());
		equipment.level += levelsAdded();
		message = message + "\n\n" + character.inventoryController.itemTooltipText(equipment);
	}

	public void updateStats()
	{
		int num = equip().id;
		if (num != 0)
		{
			int rboss = itemInfo.bossRequired[num];
			part ptype = itemInfo.type[num];
			float capatk = itemInfo.capAttack[num];
			float curatk = itemInfo.curAttack[num];
			float capdef = itemInfo.capDefense[num];
			float curdef = itemInfo.curDefense[num];
			specType type = itemInfo.specType1[num];
			float capspec = itemInfo.capSpec1[num];
			float curspec = itemInfo.curSpec1[num];
			specType type2 = itemInfo.specType2[num];
			float capspec2 = itemInfo.capSpec2[num];
			float curspec2 = itemInfo.curSpec2[num];
			specType type3 = itemInfo.specType3[num];
			float capspec3 = itemInfo.capSpec3[num];
			float curspec3 = itemInfo.curSpec3[num];
			string npath = "";
			bool punique = itemInfo.unique[num];
			equip().updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public string timeLeftMessage()
	{
		if (levelsAdded() == 1)
		{
			return "This item will gain<b> " + levelsAdded() + "</b> level if taken out now, reaching level <b>" + (equip().level + 1) + "</b>.\n<b>Time until next level:</b> " + NumberOutput.timeOutput(((double)daycareRate(equip()) - character.inventory.daycareTimers[id].totalseconds % (double)daycareRate(equip())) / (double)character.allDiggers.totalDaycareBonus());
		}
		return "This item will gain<b> " + levelsAdded() + "</b> levels if taken out now, reaching level <b>" + (equip().level + levelsAdded()) + "</b>.\n<b>Time until next level:</b> " + NumberOutput.timeOutput(((double)daycareRate(equip()) - character.inventory.daycareTimers[id].totalseconds % (double)daycareRate(equip())) / (double)character.allDiggers.totalDaycareBonus());
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right || inventoryController.midDrag)
		{
			return;
		}
		for (int i = character.inventoryController.totalInvMergeSlots(); i < character.inventory.inventory.Count; i++)
		{
			if (character.inventory.inventory[i].id == 0)
			{
				character.inventory.item1 = globalID();
				character.inventory.item2 = i;
				endDragAction();
				break;
			}
		}
	}
}
