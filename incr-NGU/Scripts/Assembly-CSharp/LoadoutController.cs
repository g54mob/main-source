using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadoutController : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{
	public Character character;

	public Image image;

	public Image border;

	public Image ghost;

	public HoverTooltip tooltip;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	public int id;

	private string message;

	public bool hovered;

	private void Start()
	{
	}

	public void Update()
	{
		if ((id > -1 || id < -6) && (id < 10000 || id >= 100000) && (id < 1000000 || id >= 2000000))
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.A) && hovered && character.settings.simpleInvShortcuts)
		{
			if (!inventoryController.midDrag && (id < 1000000 || id >= 2000000))
			{
				inventoryController.applyAllBoosts(id);
				tooltip.showTooltip("ZWOOP! All possible boosts have been used on this equipment!", 1f);
			}
		}
		else if (Input.GetKeyDown(KeyCode.D) && hovered && character.settings.simpleInvShortcuts && !inventoryController.midDrag)
		{
			inventoryController.mergeAll(id);
			tooltip.showTooltip("FWOOP! This Equipment has merged with all other copies!", 1f);
		}
	}

	public Equipment equip()
	{
		if (id >= 1000000 && id < 20000000)
		{
			return character.inventory.macguffins[id - 1000000];
		}
		if (id >= 10000 && id < 100000)
		{
			return character.inventory.accs[id - 10000];
		}
		switch (id)
		{
		case -1:
			return character.inventory.head;
		case -2:
			return character.inventory.chest;
		case -3:
			return character.inventory.legs;
		case -4:
			return character.inventory.boots;
		case -5:
			return character.inventory.weapon;
		case -6:
			return character.inventory.weapon2;
		default:
			return character.inventory.head;
		}
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right || inventoryController.midDrag)
		{
			return;
		}
		inventoryController.midDrag = true;
		if (!Input.GetMouseButton(1))
		{
			if (equip().id == 0)
			{
				character.inventory.item1 = id;
				character.inventory.item2 = id;
				inventoryController.midDrag = false;
			}
			else
			{
				character.inventory.item1 = id;
				character.inventory.item2 = id;
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && equip().id != 0 && id != -100)
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
			return;
		}
		if (character.inventory.item1 < 0)
		{
			character.inventoryController.accessoryID(character.inventory.item2);
			_ = -1;
		}
		if (id >= 10000 && id < 100000)
		{
			inventoryController.swapAcc();
			inventoryController.updateAcc(id - 10000);
		}
		else if (id >= 1000000 && id < 2000000)
		{
			inventoryController.swapMacguffin();
			inventoryController.updateMacguffin(id - 1000000);
		}
		switch (id)
		{
		case -1:
			inventoryController.swapHead();
			inventoryController.updateHead();
			break;
		case -2:
			inventoryController.swapChest();
			inventoryController.updateChest();
			break;
		case -3:
			inventoryController.swapLegs();
			inventoryController.updateLegs();
			break;
		case -4:
			inventoryController.swapBoots();
			inventoryController.updateBoots();
			break;
		case -5:
			inventoryController.swapWeapon();
			inventoryController.updateWeapon();
			break;
		case -6:
			inventoryController.swapWeapon2();
			inventoryController.updateWeapon2();
			break;
		}
		inventoryController.updateInventory();
		inventoryController.updateItem(character.inventory.item2);
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
			character.inventory.item2 = id;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if ((id <= -1 && id >= -6) || (id >= 10000 && id < 100000) || (id >= 1000000 && id < 20000000))
		{
			hovered = true;
		}
		if (id == -100)
		{
			infinityCubeTooltip();
			return;
		}
		if (id >= 1000000 && id < 20000000)
		{
			updateItem();
		}
		tooltip.showOverrideTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hovered = false;
		tooltip.hideTooltip();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (id == -100)
		{
			if (eventData.button == PointerEventData.InputButton.Right && !inventoryController.midDrag)
			{
				character.inventoryController.infinityCubeAll();
				character.inventoryController.updateInventory();
				tooltip.showTooltip("QWOOP! All possible boosts have been merged into the Infinity Cube!", 1f);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				character.inventoryController.infinityCubeAll();
				character.inventoryController.updateInventory();
				tooltip.showTooltip("QWOOP! All possible boosts have been merged into the Infinity Cube!", 1f);
			}
			else if (eventData.button == PointerEventData.InputButton.Left)
			{
				advanceCubeGraphic();
			}
		}
		else if (eventData.button == PointerEventData.InputButton.Right && !inventoryController.midDrag)
		{
			for (int i = character.inventoryController.totalInvMergeSlots(); i < character.inventory.inventory.Count; i++)
			{
				if (character.inventory.inventory[i].id == 0)
				{
					character.inventory.item1 = id;
					character.inventory.item2 = i;
					endDragAction();
					break;
				}
			}
		}
		else if (Input.GetKey(KeyCode.A) && toMacGuffinIndex(id) == -1)
		{
			inventoryController.applyAllBoosts(id);
			tooltip.showTooltip("ZWOOP! All possible boosts have been used on this equipment!", 1f);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			inventoryController.mergeAll(id);
			tooltip.showTooltip("FWOOP! All possible merges have been used on this equipment!", 1f);
		}
	}

	public Sprite emptySprite()
	{
		if (id >= 1000000 && id < 20000000)
		{
			return itemInfo.miscSprites[9];
		}
		switch (id)
		{
		case -1:
			return itemInfo.miscSprites[2];
		case -2:
			return itemInfo.miscSprites[3];
		case -3:
			return itemInfo.miscSprites[4];
		case -4:
			return itemInfo.miscSprites[5];
		case -5:
			return itemInfo.miscSprites[6];
		case -6:
			return itemInfo.miscSprites[6];
		default:
			return itemInfo.miscSprites[7];
		}
	}

	public void advanceCubeGraphic()
	{
		character.inventory.selectedGraphic++;
		if (character.inventory.selectedGraphic > character.inventoryController.infinityCubeTier() || character.inventory.selectedGraphic >= itemInfo.cubeSprites.Count)
		{
			character.inventory.selectedGraphic = 0;
		}
		updateItem();
	}

	public void updateItem()
	{
		if (id >= 1000000 && id < 2000000)
		{
			if (toMacGuffinIndex(id) < 0 || toMacGuffinIndex(id) >= character.inventory.macguffins.Count)
			{
				image.enabled = false;
				border.enabled = false;
				return;
			}
			image.enabled = true;
			border.enabled = true;
			updateTooltipMessage();
			if (toMacGuffinIndex(id) == 0 && (character.wishes.wishes[24].level >= 1 || character.wishes.wishes[25].level >= 1))
			{
				if (!equip().removable)
				{
					border.color = new Color(0.5f, 0f, 0.5f);
				}
				else
				{
					border.color = Color.blue;
				}
			}
			else if (equip().id == 0)
			{
				border.color = Color.white;
			}
			else
			{
				border.color = Color.white;
				if (!equip().removable)
				{
					border.color = Color.red;
				}
			}
			if (equip().id == 0)
			{
				image.sprite = emptySprite();
			}
			else
			{
				image.sprite = itemInfo.graphic[equip().id];
			}
			return;
		}
		if (id >= 10000 && id < 100000)
		{
			if (toAccessoryIndex() >= character.inventory.accs.Count)
			{
				image.enabled = false;
				border.enabled = false;
				return;
			}
			image.enabled = true;
			border.enabled = true;
			updateTooltipMessage();
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
			return;
		}
		if (id == -100)
		{
			if (character.inventory.itemList.tutorialCubeComplete)
			{
				image.enabled = true;
				border.enabled = true;
				image.sprite = infinityCubeSprite();
				border.color = Color.black;
			}
			else
			{
				image.enabled = false;
				border.enabled = false;
			}
			return;
		}
		if (id == -6 && !character.inventoryController.weapon2Unlocked())
		{
			image.enabled = false;
			border.enabled = false;
			return;
		}
		image.enabled = true;
		border.enabled = true;
		updateTooltipMessage();
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
		message = character.inventoryController.itemTooltipText(id);
		if (toMacGuffinIndex(id) == 0)
		{
			if (character.wishes.wishes[24].level >= 1 && character.wishes.wishes[25].level >= 1)
			{
				message += "\n\n<b><color=blue>This MacGuffin slot will be targetted by the Blood MacGuffin α Spell and Fruit of MacGuffin α Fruit.</color></b>";
			}
			else if (character.wishes.wishes[24].level >= 1)
			{
				message += "\n\n<b><color=blue>This MacGuffin slot will be targetted by the Blood MacGuffin α Spell.</color></b>";
			}
			else if (character.wishes.wishes[25].level >= 1)
			{
				message += "\n\n<b><color=blue>This MacGuffin slot will be targetted by the Fruit of MacGuffin α Fruit.</color></b>";
			}
		}
	}

	public void updateStats()
	{
		if (id != -100 && (id < 10000 || id - 10000 < character.inventory.accs.Count))
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
	}

	public void updateHeadStats()
	{
		int num = character.inventory.head.id;
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
			character.inventory.head.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void updateChestStats()
	{
		int num = character.inventory.chest.id;
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
			character.inventory.chest.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void updateLegsStats()
	{
		int num = character.inventory.legs.id;
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
			character.inventory.legs.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void updateBootsStats()
	{
		int num = character.inventory.boots.id;
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
			character.inventory.boots.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void updateWeaponStats()
	{
		int num = character.inventory.weapon.id;
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
			character.inventory.weapon.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void updateWeapon2Stats()
	{
		int num = character.inventory.weapon2.id;
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
			character.inventory.weapon2.updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
		}
	}

	public void swapLoadout1()
	{
	}

	public int toAccessoryIndex()
	{
		return id - 10000;
	}

	public int toMacGuffinIndex(int globalID)
	{
		if (globalID - 1000000 < 0 || globalID >= 2000000 || globalID - 1000000 > character.inventory.macguffins.Count)
		{
			return -1;
		}
		return globalID - 1000000;
	}

	public int globalMacguffinID()
	{
		return id + 1000000;
	}

	public Sprite infinityCubeSprite()
	{
		int num = character.inventory.selectedGraphic;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= itemInfo.cubeSprites.Count)
		{
			num = itemInfo.cubeSprites.Count - 1;
		}
		return itemInfo.cubeSprites[num];
	}

	public void infinityCubeTooltip()
	{
		message = "<b>Infinity Cube</b>\n\nDrag any extra boosts onto this cube to receive a small fraction of the boost directly to your Adventure stats! NOTE: You should probably boost your equipment first before boosting the cube, but that's just a suggestion. You do you m8.\n\n";
		message = message + "<b>TIER " + character.inventoryController.infinityCubeTier() + " Infinity Cube Bonuses:</b>\n\n";
		_ = character.inventory.cubePower;
		character.inventoryController.cubePower();
		float num = character.adventure.attack + character.inventoryController.adventureAttackBonus();
		_ = character.adventure.defense;
		character.inventoryController.adventureDefenseBonus();
		if (character.inventoryController.cubePower() < 1000f)
		{
			if (character.inventoryController.cubePower() > num)
			{
				message = message + "<b>Power:</b> " + num.ToString("###,##0.##") + " +" + (character.inventoryController.cubePower() - num).ToString("###,##0.##") + "\n<b>Max Health:</b> " + (character.inventoryController.cubePower() * 3f).ToString("###,##0.##");
			}
			else
			{
				message = message + "<b>Power:</b> " + character.inventoryController.cubePower().ToString("###,##0.##") + "\n<b>Max Health:</b> " + (character.inventoryController.cubePower() * 3f).ToString("###,##0.##");
			}
		}
		else
		{
			message = message + "<b>Power:</b> " + character.inventoryController.cubePower().ToString("###,##0") + "\n<b>Max Health:</b> " + (character.inventoryController.cubePower() * 3f).ToString("###,##0");
		}
		if (character.inventoryController.cubeToughness() < 1000f)
		{
			message = message + "\n<b>Toughness:</b> " + character.inventoryController.cubeToughness().ToString("###,##0.##") + "\n<b>Health Regen:</b> " + (character.inventoryController.cubeToughness() * 0.03f).ToString("###,##0.##");
		}
		else
		{
			message = message + "\n<b>Toughness:</b> " + character.inventoryController.cubeToughness().ToString("###,##0") + "\n<b>Health Regen:</b> " + (character.inventoryController.cubeToughness() * 0.03f).ToString("###,##0");
		}
		if (character.inventoryController.infinityCubeTier() >= 1)
		{
			message = message + "\n<b>Cube Drop Chance Bonus:</b> +" + (character.inventoryController.cubeLootBonus() * 100f).ToString("###,##0") + "%";
		}
		if (character.inventoryController.infinityCubeTier() >= 2)
		{
			message = message + "\n<b>Cube Gold Bonus:</b> +" + (character.inventoryController.cubeGoldBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.inventoryController.infinityCubeTier() >= 8)
		{
			message = message + "\n<b>Cube Hack Speed Bonus:</b> +" + (character.inventoryController.cubeHackBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.inventoryController.infinityCubeTier() >= 9)
		{
			message = message + "\n<b>Cube Wish Speed Bonus:</b> +" + (character.inventoryController.cubeWishBonus() * 100f).ToString("###,##0.##") + "%";
		}
		if (character.inventory.cubePower > character.inventoryController.cubePower())
		{
			message += "\n<b>Cube Power has reached the SOFTCAP.</b>";
		}
		if (character.inventory.cubeToughness > character.inventoryController.cubeToughness())
		{
			message += "\n<b>Cube Toughness has reached the SOFTCAP.</b>";
		}
		if (character.inventory.cubePower > character.inventoryController.cubePower() || character.inventory.cubeToughness > character.inventoryController.cubeToughness())
		{
			message += "\n<b>Improve your gear or base stats to let your cube grow bigger!</b>";
		}
		message += "\n\n<b>Shortcuts</b>\n<b>Right Click or A+Click Cube: Apply all non-protected boosts to the Infinity Cube.</b>";
		tooltip.showTooltip(message);
	}

	public void advanceCubeArt()
	{
	}
}
