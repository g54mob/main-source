using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerClickHandler
{
	public int id;

	public Character character;

	public Boss boss;

	public Image image;

	public Image border;

	public Image ghost;

	public HoverTooltip tooltip;

	private Equipment holder;

	private string message;

	public Trash trash;

	public InventoryController inventoryController;

	public ItemNameDesc itemInfo;

	public bool hovered;

	private void Start()
	{
		updateItem();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.A) && hovered && character.settings.simpleInvShortcuts)
		{
			if (character.inventory.inventory[id].isEquipment() && !inventoryController.midDrag)
			{
				inventoryController.applyAllBoosts(id);
				tooltip.showTooltip("ZWOOP! All possible boosts have been used on this equipment!", 1f);
			}
		}
		else if (Input.GetKeyDown(KeyCode.D) && hovered && character.settings.simpleInvShortcuts && !inventoryController.midDrag)
		{
			inventoryController.mergeAll(id);
			tooltip.showTooltip("FWOOP! This item has merged with all other copies!", 1f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (inventoryController.midDrag)
		{
			character.inventory.item2 = id;
		}
		if (character.inventory.inventory[id].id != 0 || (id >= 0 && id < character.inventoryController.totalInvMergeSlots()))
		{
			if (character.inventory.inventory[id].type == part.MacGuffin)
			{
				updateItem();
			}
			tooltip.showOverrideTooltip(message);
			hovered = true;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
		hovered = false;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right || inventoryController.midDrag || Input.GetMouseButton(1))
		{
			return;
		}
		inventoryController.midDrag = true;
		if (character.inventory.inventory[id].id == 0)
		{
			character.inventory.item1 = id;
			character.inventory.item2 = id;
			inventoryController.midDrag = false;
			return;
		}
		character.inventory.item1 = id;
		character.inventory.item2 = id;
		if (character.inventory.inventory[id] == null)
		{
			ghost.sprite = itemInfo.graphic[0];
		}
		else
		{
			ghost.sprite = itemInfo.graphic[character.inventory.inventory[id].id];
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			return;
		}
		if (character.inventory.item1 == character.inventory.item2)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
			inventoryController.midDrag = false;
			return;
		}
		if (character.inventory.item1 >= 0 && character.inventory.item2 >= 0 && character.inventory.item1 < 10000 && character.inventory.item2 < 10000 && character.inventory.inventory[character.inventory.item1].id == 0)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
			inventoryController.midDrag = false;
			return;
		}
		if (character.inventory.item1 < 0 || character.inventory.item1 >= character.inventory.inventory.Count)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
			inventoryController.midDrag = false;
			return;
		}
		if (character.inventory.inventory[character.inventory.item1].id == 0 && character.inventoryController.daycareID(character.inventory.item2) >= 0)
		{
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			ghost.transform.position = new Vector3(-2000f, -2000f);
			inventoryController.midDrag = false;
			return;
		}
		ghost.transform.position = new Vector3(-2000f, -2000f);
		if (character.inventory.item2 >= 10000 && character.inventory.item2 < 100000)
		{
			int item = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item;
			inventoryController.swapAcc();
			inventoryController.updateAcc(character.inventory.item1 - 10000);
		}
		else if (character.inventory.item2 >= 100000 && character.inventory.item2 < 1000000)
		{
			int item2 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item2;
			inventoryController.swapDaycare();
			inventoryController.updateDaycare(character.inventory.item1 - 100000);
		}
		else if (character.inventory.item2 >= 1000000 && character.inventory.item2 < 2000000)
		{
			int item3 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item3;
			inventoryController.swapMacguffin();
			inventoryController.updateMacguffin(character.inventory.item1 - 1000000);
		}
		else if (character.inventory.item2 >= 0)
		{
			int item4 = character.inventory.item1;
			int item5 = character.inventory.item2;
			inventoryController.swapItems();
			inventoryController.updateItem(item4);
			inventoryController.updateItem(item5);
		}
		else if (character.inventory.item2 == -1)
		{
			int item6 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item6;
			inventoryController.swapHead();
			inventoryController.updateHead();
		}
		else if (character.inventory.item2 == -2)
		{
			int item7 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item7;
			inventoryController.swapChest();
			inventoryController.updateChest();
		}
		else if (character.inventory.item2 == -3)
		{
			int item8 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item8;
			inventoryController.swapLegs();
			inventoryController.updateLegs();
		}
		else if (character.inventory.item2 == -4)
		{
			int item9 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item9;
			inventoryController.swapBoots();
			inventoryController.updateBoots();
		}
		else if (character.inventory.item2 == -5)
		{
			int item10 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item10;
			inventoryController.swapWeapon();
			inventoryController.updateWeapon();
		}
		else if (character.inventory.item2 == -6)
		{
			int item11 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item11;
			inventoryController.swapWeapon2();
			inventoryController.updateWeapon2();
		}
		else if (character.inventory.item2 == -69)
		{
			int item12 = character.inventory.item2;
			character.inventory.item2 = character.inventory.item1;
			character.inventory.item1 = item12;
			trash.trashItem(character.inventory.item2);
			inventoryController.updateTrash();
		}
		else if (character.inventory.item2 == -100 && character.inventory.inventory[character.inventory.item1].removable)
		{
			character.inventoryController.infinityCubeBoost(character.inventory.item1);
			inventoryController.updateInfinityCube();
		}
		updateItem();
		tooltip.hideTooltip();
		inventoryController.midDrag = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			if (id < inventoryController.curSpaces())
			{
				character.inventory.item2 = id;
			}
			if (character.inventory.item1 >= 0 && character.inventory.item1 < character.inventory.inventory.Count && character.inventory.inventory[character.inventory.item1].id != 0)
			{
				ghost.transform.position = new Vector3(Input.mousePosition.x - 6f, Input.mousePosition.y + 6f);
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right && id < inventoryController.curSpaces())
		{
			character.inventory.item2 = id;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (character.inventory.inventory[id].id == 0)
		{
			return;
		}
		if (Input.GetKey("left shift") || Input.GetKey("right shift"))
		{
			if (character.inventory.inventory[id].id == 0)
			{
				return;
			}
			if (character.inventory.inventory[id] != null)
			{
				character.inventory.inventory[id].removable = !character.inventory.inventory[id].removable;
			}
			updateItem();
		}
		if (Input.GetKey("left ctrl") || Input.GetKey("right ctrl"))
		{
			consumeItem();
			return;
		}
		if (eventData.button == PointerEventData.InputButton.Right && !inventoryController.midDrag)
		{
			if (character.inventoryController.daycareUp)
			{
				character.inventoryController.autoDaycare(id);
			}
			else if (character.beastQuestController.isQuestItem(character.inventory.inventory[id].id) && character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == character.inventory.inventory[id].id && character.inventory.inventory[id].removable)
			{
				inventoryController.dumpAllIntoQuest(character.inventory.inventory[id].id);
			}
			else
			{
				autoEquip();
			}
		}
		if (Input.GetKey(KeyCode.Q))
		{
			transformBoostPower();
			return;
		}
		if (Input.GetKey(KeyCode.W))
		{
			transformBoostToughness();
			return;
		}
		if (Input.GetKey(KeyCode.E))
		{
			transformBoostSpecial();
			return;
		}
		if (Input.GetKey(KeyCode.A) && character.inventory.inventory[id].isEquipment() && !inventoryController.midDrag)
		{
			inventoryController.applyAllBoosts(id);
			tooltip.showTooltip("ZWOOP! All possible boosts have been used on this equipment!", 1f);
		}
		if (Input.GetKey(KeyCode.D) && !inventoryController.midDrag)
		{
			inventoryController.mergeAll(id);
			tooltip.showTooltip("FWOOP! This item has merged with all other copies!", 1f);
		}
	}

	private void consumeItem()
	{
		int num = inventoryController.checkItemTransform(character.inventory.inventory[id]);
		if (num > 0 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			itemInfo.makeLoot(num, id);
			updateItem();
			return;
		}
		if (character.inventory.inventory[id].id == 66 && character.inventory.inventory[id].removable)
		{
			if (character.wandoos98.OSlevel >= 100)
			{
				character.inventory.deleteItem(id);
				tooltip.showTooltip("You're at the max wandoos level you can get with this item, so you grind the disk into a coarse powder and snort it. The shards mangle your sinuses causing major blood loss and permanent brain damage. Well done!", 7f);
				updateItem();
				return;
			}
			if (!character.settings.wandoos98On)
			{
				character.settings.wandoos98On = true;
				character.inventory.inventory[id].level--;
				if (character.inventory.inventory[id].level < 0)
				{
					character.inventory.deleteItem(id);
				}
				updateItem();
				return;
			}
			if (character.wandoos98.installTime.totalseconds < 86400.0 && !character.wandoos98.installed)
			{
				return;
			}
			int level = character.inventory.inventory[id].level;
			character.settings.wandoos98On = true;
			int num2 = (int)character.wandoos98.OSlevel + 1;
			if (level == num2)
			{
				if (character.wandoos98.OSlevel < 100)
				{
					character.wandoos98.OSlevel++;
				}
				character.inventory.deleteItem(id);
				tooltip.showTooltip("You've succesfully upgraded your OS level in the Wandoos menu!", 2f);
			}
			else if (level > num2)
			{
				character.wandoos98.OSlevel++;
				if (character.wandoos98.OSlevel > 100)
				{
					character.wandoos98.OSlevel = 100L;
				}
				character.inventory.inventory[id].level -= num2;
				if (character.inventory.inventory[id].level < 0)
				{
					character.inventory.deleteItem(id);
				}
				tooltip.showTooltip("You've successfully upgraded your OS Level in the Wandoos menu!", 2f);
			}
			else
			{
				tooltip.showTooltip("You need to merge this copy of Wandoos 98 to a higher level to upgrade your OS!", 3f);
			}
		}
		else if (character.inventory.inventory[id].id == 92 && character.inventory.inventory[id].removable)
		{
			if (!character.settings.yggdrasilOn)
			{
				character.settings.yggdrasilOn = true;
				character.inventory.deleteItem(id);
				character.yggdrasil.seeds++;
				tooltip.showTooltip("You find a clearing nearby and dig into the ground a bit. You plant the seed and... wihin moments a massive, awe inspiring tree shoots up out of the ground, yielding magnificent fruits! Yggdrasil unlocked!", 12f);
			}
			else
			{
				int num3 = (int)((float)character.inventory.inventory[id].level * (1f + (float)character.inventory.inventory[id].level / 100f));
				if (num3 < 1)
				{
					num3 = 1;
				}
				if (num3 > 200)
				{
					num3 = 200;
				}
				tooltip.showTooltip("You gnaw on this mythical seed, making sure it gets really gross and slimy with your drool. After a couple minutes you realize you can just add this seed to the pile. " + num3 + " Seeds have been added!", 5f);
				character.yggdrasil.seeds += num3;
				character.inventory.deleteItem(id);
			}
			if (character.yggdrasil.goldFruit.maxTier == 0L)
			{
				character.yggdrasil.goldFruit.maxTier = 1L;
			}
		}
		else if (character.inventory.inventory[id].id == 93 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.hasHyperRegen)
			{
				tooltip.showOverrideTooltip("You uncork the liquid and begin chugging... and nearly throw it all back up. You manage to keep it down, and you feel like a barrier in your mind has been lifted! HYPER REGEN move unlocked!", 12f);
				character.settings.hasHyperRegen = true;
			}
			else
			{
				tooltip.showTooltip("I guess you have a 'drinking gross liquids' fetish or something? You already drank this and unlocked HYPER REGEN.", 5f);
			}
		}
		else if (character.inventory.inventory[id].id == 102 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.nguOn)
			{
				tooltip.showOverrideTooltip("You tap on the number to make it go up. It rockets up into the air as the value begins to climb past\n2,147,483,647....\n9,223,372,036,854,775,807....\n3.40282347E+38....\n1.7976931348623157E+308!!!\nAscending into a form of pure energy, it rushes into your body... you have unlocked <b>NGU Skills</b>!", 12f);
				character.settings.nguOn = true;
			}
			else
			{
				tooltip.showTooltip("You tap the number. It deflates like some pathetic balloon. Pretty sure you already unlocked the NGU Skills Menu.", 5f);
			}
		}
		else if (character.inventory.inventory[id].id == 141 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.beardsOn)
			{
				tooltip.showOverrideTooltip("Despite your own disgust, you press UUG's armpit hair onto your chin. The hair suddenly merges onto your face, and instantly gives you a full luxurious beard! (even if you're not a dude. Just go with it.) Power flows through you like you haven't felt in a long, long time. You have unlocked <b>BEARDS OF POWER</b>!", 12f);
				character.settings.beardsOn = true;
			}
			else
			{
				tooltip.showTooltip("You chew on the sweaty armpit hair for a bit. Elsewhere, your parents wonder where it all went wrong.", 5f);
			}
		}
		else if (character.inventory.inventory[id].id == 163 && character.inventory.inventory[id].removable)
		{
			if (!character.settings.wandoos98On)
			{
				return;
			}
			if (character.wandoos98.XLLevels >= 100)
			{
				character.inventory.deleteItem(id);
				updateItem();
				tooltip.showOverrideTooltip("The copy of Wandoos XL explodes when you touch it - You've already gained the maximum number of level from this OS!", 2f);
				return;
			}
			if (character.wandoos98.XLLevels == 0L)
			{
				character.inventory.inventory[id].level--;
				if (character.inventory.inventory[id].level < 0)
				{
					character.inventory.deleteItem(id);
				}
				character.wandoos98.XLLevels++;
				tooltip.showOverrideTooltip("You take out the Wandoos XL installation disc and break it into little pieces, dipping it into an emergency supply of salsa you keep on you at all times and crunching down on the 'chips'.This does absolutely nothing to help you.\n\nIn unrelated news, you just unlocked Wandoos XL! ", 8f);
				updateItem();
				return;
			}
			int level2 = character.inventory.inventory[id].level;
			int num4 = (int)character.wandoos98.XLLevels + 1;
			if (level2 == num4)
			{
				if (character.wandoos98.XLLevels < 100)
				{
					character.wandoos98.XLLevels++;
				}
				character.inventory.deleteItem(id);
				tooltip.showTooltip("You've succesfully upgraded your OS level in the Wandoos menu!", 2f);
				updateItem();
			}
			else if (level2 > num4)
			{
				character.wandoos98.XLLevels++;
				if (character.wandoos98.XLLevels > 100)
				{
					character.wandoos98.XLLevels = 100L;
				}
				character.inventory.inventory[id].level -= num4;
				if (character.inventory.inventory[id].level < 0)
				{
					character.inventory.deleteItem(id);
				}
				tooltip.showTooltip("You've successfully upgraded your OS Level in the Wandoos menu!", 2f);
			}
			else
			{
				tooltip.showTooltip("You need to merge this copy of Wandoos XL to level <b>" + (character.wandoos98.XLLevels + 1) + "</b> to upgrade your OS!", 3f);
			}
			updateItem();
		}
		else if (character.inventory.inventory[id].id == 172 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.itopodOn)
			{
				tooltip.showOverrideTooltip("Despite your common sense screaming at you, you fly up to a nearby infinitely tall tower and jam the Pissed off key into the lock. 'ABOUT GODDAMN TIME!' screams the key as the door swings open. Dare you head to the Adventure menu to enter <b>THE INFINITE TOWER OF PISSED OFF DUDES?</b>?\n\n\n\n(The answer is yes go do that)", 10f);
				character.settings.itopodOn = true;
			}
			else
			{
				tooltip.showTooltip("You flip the key off and toss it from your inventory. You already unlocked the I.T.O.P.O.D anyways.", 5f);
			}
		}
		else if (character.inventory.inventory[id].id == 191 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.beastModeUnlocked)
			{
				tooltip.showOverrideTooltip("Once again, you pop out the cork and begin guzzling a compeltely random liquid from the guts of a horrific caterpillar slug-beast. It slithers down your throat like a thick, hairy milkshake. The taste is reminiscent of a sulfuric acid slurry mixed with pus, topped with some flakes of asbestos. The powers that be have somehow decided that instead of killing you, like they really ought to, you have instead learned the BEAST MODE skill. This will increase your POWER at the cost of taking significantly more damage, ouch! Useful, but dangerous!", 15f);
				character.settings.beastModeUnlocked = true;
			}
			else
			{
				tooltip.showTooltip("Why.", 3f);
			}
		}
		else if (character.inventory.inventory[id].id == 197 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.diggersOn)
			{
				tooltip.showOverrideTooltip("You dial the number on the slip of paper on your new cellphone, which you naturally also stole from Jake. The anticipation of who might answer sends thrills of excitement down your spine. Ring...Ring...Ring... Eventually, a woman answers with a voice that makes Cthulhu sound like a little blonde girl in comparison. A voice that has endured millenia of chain smoking.\n\n 'Why hello there handsome, let's skip the phonecall and you come bring me KFC, and I'll let you store your jackhammer in my tool shed! ;)'\n\nUrrrgghh. You hang up and dispose of the paper the best way you know how - by eating it, and instead advertise online to find folks to help you get stronger for gold. You have unlocked <b>Gold Diggers!</b> ", 25f);
				character.settings.diggersOn = true;
			}
			else
			{
				tooltip.showTooltip("You have an 'eating gross things' problem, you know that right?", 3f);
			}
		}
		else if (character.inventory.inventory[id].id == 292 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.settings.beastOn)
			{
				tooltip.showOverrideTooltip("Clutching the Beast's Sigil in your hand, you find on your next encounter that, instead of being a terrible and cursed Beast, it really is a chill little caterpillar that just wants to EAT EVERYTHING IN EXISTENCE. The Beast says it can offer you Heroic Quests to find it delicious items, and in return make you even stronger! You have unlocked <b>Questing!</b>\n\nAlso, you gained some advanced functionality for NGUs for no particular reason.", 15f);
				character.settings.beastOn = true;
			}
			else
			{
				tooltip.showTooltip("It's well known that Beast Sigils are a good source of Vitamin C and phosphate. Chow down, my iron-gulleted friend.", 3f);
			}
		}
		else if (character.inventory.inventory[id].id == 294 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.res3.res3On || !character.hacks.hacksOn)
			{
				tooltip.showOverrideTooltip("You wave the evidence in front of the Nerd, laughing as he tries to jump and grab it. But gravity is not his friend and he swipes at the air a solid 6 inches below your outstretched hand. You agree to destroy the evidence IF the Nerd helps increase your power. Wiping away a trail of snot and tears he takes your NGU savefile and gets to work. You have unlocked <b>Hacks</b>! You've also unlocked <b>Resource 3!</b> You can head to Page 2 of the Settings menu to name and colour this Resource! You ALSO unlocked a new Special Pack in the Sellout Shop, if you're into that. No pressure!\n\nAfter all this excitement you then destroy the evidence by, of course, eating it. Yum!", 20f);
				character.res3Display.unlockResource3();
				character.hacks.hacksOn = true;
			}
			else
			{
				tooltip.showTooltip("You're addicted to the smooth, smooth texture of the sharp plastic, paper fibres and toxic resins that make up the Incriminating Evidence. Mmm Mm, Good!", 4f);
			}
		}
		else if (character.inventory.inventory[id].id == 495 && character.inventory.inventory.Count >= 40)
		{
			if (character.inventory.inventory[0].id == 480 && character.inventory.inventory[1].id == 481 && character.inventory.inventory[2].id == 482 && character.inventory.inventory[3].id == 483 && character.inventory.inventory[12].id == 484 && character.inventory.inventory[13].id == 485 && character.inventory.inventory[14].id == 486 && character.inventory.inventory[15].id == 487 && character.inventory.inventory[24].id == 488 && character.inventory.inventory[25].id == 489 && character.inventory.inventory[26].id == 490 && character.inventory.inventory[27].id == 491 && character.inventory.inventory[36].id == 492 && character.inventory.inventory[37].id == 493 && character.inventory.inventory[38].id == 494 && character.inventory.inventory[39].id == 495)
			{
				character.showEndSequence(0);
			}
			else
			{
				character.tooltip.showOverrideTooltip("An eerie voice whispers in your ear 'you screwed up the placement somehow, dummy...')", 3f);
			}
		}
		else if (character.inventory.inventory[id].id >= 336 && character.inventory.inventory[id].id <= 341 && character.inventory.inventory[id].removable)
		{
			bool flag = character.inventoryController.exileAssembled();
			if (character.inventoryController.exileSpecialAssembled())
			{
				if (character.adventure.titan9Unlocked)
				{
					tooltip.showOverrideTooltip("The ground beneath you rumbles and shakes violently for a moment, like an earthquake. You're sure something has changed about the Exile, but you can't see it yet.", 8f);
					character.adventure.titan9SpecialReward = true;
				}
			}
			else if (flag)
			{
				if (!character.adventure.titan9Unlocked)
				{
					tooltip.showOverrideTooltip("The pieces vibrate with the mystical voodoo energy that only unlocking something can generate. You can now face THE EXILE in Adventure mode!", 8f);
					character.adventure.titan9Unlocked = true;
				}
				else
				{
					tooltip.showTooltip("You're overcome with a desire to individually lick every piece of the Exile, which of course you succumb to. It takes 30 minutes to give each piece a proper tongue polishing until they sparkle in the noon sun... you gross bastard.", 10f);
				}
			}
		}
		else if (character.inventory.inventory[id].id == 343 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.wishes.wishesOn && character.hacks.hacksOn)
			{
				tooltip.showOverrideTooltip("Despite your better sense of judgement you decide to PLANT the severed unicorn head near Yggdrasil's roots. After a while the tree blooms an odd looking flower. You yank on it and a fully grown unicorn pops out! WTF? You ride the unicorn with great haste back to the Godmother, who is elated to see her pet Snookums back to life! She offers the help of her mafia to grant you any wish you want. You somehow have unlocked <b>WISHES</b>.", 15f);
				character.wishes.wishesOn = true;
			}
			else if (!character.wishes.wishesOn && !character.hacks.hacksOn)
			{
				tooltip.showOverrideTooltip("Despite your better sense of judgement you decide to PLANT the severed unicorn head near Yggdrasil's roots. After a while the tree blooms an odd looking flower. You yank on it and a fully grown unicorn pops out! WTF? However, it immediately starts to disintegrate back to ash, but not before coughing out 'Unlock hacks first, you moron'. Oh.", 15f);
			}
			else
			{
				tooltip.showTooltip("Well, the Godmother already has her pet unicorn back... So you decide to perform unspeakable horrors to this severed unicorn head. You should be ashamed.", 6f);
			}
		}
		else if (character.inventory.inventory[id].id == 391 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.cards.cardsOn)
			{
				tooltip.showOverrideTooltip("Staring at this oozing, still-beating heart, you're filled with an overwhelming urge to devour it.\n\n<b>*CHOMP* *CHOMP* *SMACK*</b>\n\nYour face is smeared with half-congealed blood, but you have a wicked grin on your face - for you now have the heart of the cards on your side! You have unlocked <b>CARDS</b>.", 13f);
				character.cards.cardsOn = true;
				character.cardsController.addCard();
			}
			else
			{
				tooltip.showTooltip("You decide to put a leash around the heart and keep it as a weird pet, to accompany you on your journeys. You now have a pet heart named Edgar.", 6f);
			}
		}
		else if (character.inventory.inventory[id].id == 506 && character.inventory.inventory[id].removable)
		{
			character.inventory.deleteItem(id);
			updateItem();
			if (!character.adventure.move69Unlocked)
			{
				tooltip.showOverrideTooltip("You stare at the liquid.\nIt stares back.\nYour hands shakily reaches out, despite every fibre of your being trying to stop yourself from drinking these gross frickin' liquids.\nYou succumb to the urge, and down the whole vial\nIt's the most foul-tasting thing, and you almost throw up, but... sigh... you have unlocked <b>MOVE 69</b>.", 15f);
				character.adventure.move69Unlocked = true;
			}
			else
			{
				tooltip.showTooltip("You use the mysterious Grey Liquid to follow along with a Rob Boss painting tutorial and produce a horrible, oozing self-portrait. It looks awful. You should feel ashamed.", 6f);
			}
		}
		else
		{
			if (character.beastQuestController.isQuestItem(character.inventory.inventory[id].id) && character.inventory.inventory[id].removable)
			{
				bool flag2 = false;
				if ((character.adventure.itopod.perkLevel[145] <= 0) ? character.beastQuestController.checkItemConsumed(character.inventory.inventory[id].id) : character.beastQuestController.checkItemConsumed(character.inventory.inventory[id].id, character.inventory.inventory[id].level))
				{
					tooltip.showTooltip("You have delivered a Quest item to the Beast, and it is pleased. It devours the item before your eyes.", 2f);
				}
				else if (character.beastQuest.inQuest && character.beastQuest.questID == character.inventory.inventory[id].id && character.beastQuest.curDrops >= character.beastQuest.targetDrops)
				{
					tooltip.showOverrideTooltip("You've already satisfied the Beast's quest - go complete the quest in the Questing menu! The Beast eats your offering anyways.", 2f);
				}
				else if (character.beastQuest.inQuest && character.beastQuest.questID != character.inventory.inventory[id].id)
				{
					tooltip.showOverrideTooltip("This isn't the correct Quest item to deliver to the Beast! It is displeased, but eats your offering anyways.", 2f);
				}
				else if (!character.beastQuest.inQuest)
				{
					tooltip.showOverrideTooltip("you're not currently on a Quest! The Beast is confused at your offering, but eats it anyways.", 2f);
				}
				character.inventory.deleteItem(id);
				updateItem();
				return;
			}
			if (character.inventory.inventory[id].id >= 367 && character.inventory.inventory[id].id <= 371 && character.inventory.inventory[id].removable)
			{
				character.inventoryController.attemptToMakeGlop();
			}
			else if (character.inventory.itemList.tutorialCubeComplete && character.inventory.inventory[id].isBoost() && character.inventory.inventory[id].removable)
			{
				character.inventoryController.infinityCubeBoost(id);
			}
			else if (character.inventory.inventory[id].removable)
			{
				trash.trashItem(id);
			}
		}
		trash.updateItem();
		updateItem();
	}

	public void updateItem()
	{
		if (id >= character.inventory.inventory.Count)
		{
			image.enabled = false;
			border.enabled = false;
			return;
		}
		image.enabled = true;
		border.enabled = true;
		updateTooltipMessage();
		image.sprite = itemInfo.graphic[character.inventory.inventory[id].id];
		if (id < character.inventoryController.totalInvMergeSlots())
		{
			if (character.inventory.inventory[id].removable)
			{
				border.color = Color.blue;
			}
			else
			{
				border.color = new Color(0.5f, 0f, 0.5f);
			}
		}
		else if (!character.inventory.inventory[id].removable)
		{
			border.color = Color.red;
		}
		else if (character.inventory.inventory[id].removable)
		{
			if (character.settings.themeID == 1 || character.settings.themeID == 3)
			{
				border.color = Color.black;
			}
			else
			{
				border.color = Color.white;
			}
		}
	}

	public void updateTooltipMessage()
	{
		message = character.inventoryController.itemTooltipText(id);
	}

	private void trashItem()
	{
		character.inventory.item2 = id;
		trash.trashItem(id);
		inventoryController.updateTrash();
		updateItem();
		tooltip.hideTooltip();
	}

	private void deleteItem()
	{
		character.inventory.deleteItem(id);
	}

	public void updateItemStats()
	{
		if (id < character.inventory.inventory.Count)
		{
			int num = character.inventory.inventory[id].id;
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
				character.inventory.inventory[id].updateItem(rboss, ptype, capatk, curatk, capdef, curdef, type, capspec, curspec, type2, capspec2, curspec2, type3, capspec3, curspec3, npath, punique);
			}
		}
	}

	private void hideAllTooltips()
	{
		tooltip.hideTooltip();
	}

	public void autoEquip()
	{
		character.inventory.item2 = id;
		switch (character.inventory.inventory[id].type)
		{
		case part.Head:
			character.inventory.item1 = -1;
			character.inventoryController.swapHead();
			break;
		case part.Chest:
			character.inventory.item1 = -2;
			character.inventoryController.swapChest();
			break;
		case part.Legs:
			character.inventory.item1 = -3;
			character.inventoryController.swapLegs();
			break;
		case part.Boots:
			character.inventory.item1 = -4;
			character.inventoryController.swapBoots();
			break;
		case part.Weapon:
			character.inventory.item1 = -5;
			character.inventoryController.swapWeapon();
			break;
		case part.Accessory:
			if (Input.GetKey(KeyCode.Q))
			{
				character.inventory.item1 = 10000;
			}
			else if (Input.GetKey(KeyCode.W))
			{
				character.inventory.item1 = 10001;
			}
			else if (Input.GetKey(KeyCode.E))
			{
				character.inventory.item1 = 10002;
			}
			else if (Input.GetKey(KeyCode.Y))
			{
				character.inventory.item1 = 10003;
			}
			else if (Input.GetKey(KeyCode.U))
			{
				character.inventory.item1 = 10004;
			}
			else if (Input.GetKey(KeyCode.I))
			{
				character.inventory.item1 = 10005;
			}
			else if (Input.GetKey(KeyCode.O))
			{
				character.inventory.item1 = 10006;
			}
			else if (Input.GetKey(KeyCode.P))
			{
				character.inventory.item1 = 10007;
			}
			else
			{
				character.inventory.item1 = 10000;
			}
			character.inventoryController.swapAcc();
			break;
		case part.MacGuffin:
		{
			bool flag = false;
			for (int i = 0; i < character.inventory.macguffins.Count; i++)
			{
				if (character.inventory.macguffins[i].id == character.inventory.inventory[id].id)
				{
					character.inventory.item1 = 1000000 + i;
					character.inventoryController.swapMacguffin();
					tooltip.showTooltip("This MacGuffin was merged onto your equipped MacGuffin of the same type!", 2f);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < character.inventory.macguffins.Count; j++)
				{
					if (character.inventory.macguffins[j].id == 0)
					{
						character.inventory.item1 = 1000000 + j;
						character.inventoryController.swapMacguffin();
						tooltip.showTooltip("This MacGuffin has been equipped!", 1.5f);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				tooltip.showTooltip("There's no room to equip this MacGuffin!", 1.5f);
			}
			break;
		}
		default:
			character.inventory.item1 = 0;
			character.inventory.item2 = 0;
			break;
		}
		character.inventoryController.updateInventory();
		if (character.inventory.inventory[id].id != 0)
		{
			tooltip.showTooltip(message);
		}
	}

	public void transformBoostPower()
	{
		if (!character.inventory.inventory[id].isBoost() || !character.inventory.inventory[id].removable)
		{
			return;
		}
		int num = character.inventory.inventory[id].id;
		if (character.allChallenges.level100Challenge.completions() >= character.allChallenges.level100Challenge.maxCompletions)
		{
			num = ((num != 13 && num != 26 && num != 39) ? (num % 13) : 13);
			deleteItem();
			itemInfo.makeLoot(num, id);
			tooltip.showTooltip("Transformed Boost into a Power Boost!", 2f);
		}
		else if (character.allChallenges.level100Challenge.completions() >= 1)
		{
			if (num % 13 != 1)
			{
				num = ((num != 13 && num != 26 && num != 39) ? (num % 13 - 1) : 12);
				deleteItem();
				itemInfo.makeLoot(num, id);
				tooltip.showTooltip("Transformed Boost into a Power Boost! If it was already a Power Boost I bet you feel really silly right about now.", 2f);
			}
		}
		else
		{
			tooltip.showTooltip("You must complete at least one 100-Level Challenge to transform your boosts! ", 2f);
		}
	}

	public void transformBoostToughness()
	{
		if (!character.inventory.inventory[id].isBoost() || !character.inventory.inventory[id].removable)
		{
			return;
		}
		int num = character.inventory.inventory[id].id;
		if (character.allChallenges.level100Challenge.completions() >= character.allChallenges.level100Challenge.maxCompletions)
		{
			num = ((num != 13 && num != 26 && num != 39) ? (num % 13 + 13) : 26);
			deleteItem();
			itemInfo.makeLoot(num, id);
			tooltip.showTooltip("Transformed Boost into a Toughness Boost!", 2f);
		}
		else if (character.allChallenges.level100Challenge.completions() >= 1)
		{
			if (num % 13 != 1)
			{
				num = ((num != 13 && num != 26 && num != 39) ? (num % 13 + 13 - 1) : 25);
				deleteItem();
				itemInfo.makeLoot(num, id);
				tooltip.showTooltip("Transformed Boost into a Toughness Boost! If it was already a Toughness Boost I bet you feel really silly right about now.", 2f);
			}
		}
		else
		{
			tooltip.showTooltip("You must complete at least one 100-Level Challenge to transform your boosts! ", 2f);
		}
	}

	public void transformBoostSpecial()
	{
		if (!character.inventory.inventory[id].isBoost() || !character.inventory.inventory[id].removable)
		{
			return;
		}
		int num = character.inventory.inventory[id].id;
		if (character.allChallenges.level100Challenge.completions() >= character.allChallenges.level100Challenge.maxCompletions)
		{
			num = ((num != 13 && num != 26 && num != 39) ? (num % 13 + 26) : 39);
			deleteItem();
			itemInfo.makeLoot(num, id);
			tooltip.showTooltip("Transformed Boost into a Special Boost! ", 2f);
		}
		else if (character.allChallenges.level100Challenge.completions() >= 1)
		{
			if (num % 13 != 1)
			{
				num = ((num != 13 && num != 26 && num != 39) ? (num % 13 + 26 - 1) : 38);
				deleteItem();
				itemInfo.makeLoot(num, id);
				tooltip.showTooltip("Transformed Boost into a Special Boost! If it was already a Special Boost I bet you feel really silly right about now.", 2f);
			}
		}
		else
		{
			tooltip.showTooltip("You must complete at least one 100-Level Challenge to transform your boosts! ", 2f);
		}
	}
}
