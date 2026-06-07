using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemListController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public AllItemListController allItemsList;

	public Image itemGraphic;

	public Image itemBorder;

	public ItemNameDesc itemInfo;

	public int id;

	public int setID;

	private void Start()
	{
		setID = getSetID();
	}

	public void updateGraphic()
	{
		if (id > character.itemInfo.highestID())
		{
			itemGraphic.sprite = itemInfo.miscSprites[0];
			itemBorder.color = Color.white;
			itemGraphic.color = Color.white;
			return;
		}
		if (character.inventory.itemList.itemMaxxed[id])
		{
			itemGraphic.sprite = itemInfo.graphic[id];
			itemBorder.color = new Color(1f, 0f, 0f);
		}
		else if (character.inventory.itemList.itemDropped[id])
		{
			itemGraphic.sprite = itemInfo.graphic[id];
			itemBorder.color = Color.white;
		}
		else
		{
			itemGraphic.sprite = itemInfo.miscSprites[1];
			itemBorder.color = Color.white;
		}
		if (character.inventory.itemList.itemFiltered[id])
		{
			itemGraphic.color = Color.grey;
		}
		else
		{
			itemGraphic.color = Color.white;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (id > character.itemInfo.highestID())
		{
			return;
		}
		if (character.arbitrary.lootFilter)
		{
			if (character.inventory.itemList.itemDropped[id])
			{
				character.inventory.itemList.itemFiltered[id] = !character.inventory.itemList.itemFiltered[id];
			}
			updateGraphic();
			OnPointerEnter(eventData);
		}
		else
		{
			tooltip.showTooltip("Sorry friendo, you need to buy the improved Loot Filter from the Sellout Shop to filter individual items!", 5f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (id > character.itemInfo.highestID())
		{
			return;
		}
		string text = "";
		if (character.inventory.itemList.itemDropped[id])
		{
			text = ((id == 298) ? ("<b>(" + id + ") " + character.res3.res3Name + " Power MacGuffin Fragment " + itemStatus() + "</b>\n\n" + itemInfo.itemDesc[id]) : ((id == 299) ? ("<b>(" + id + ") " + character.res3.res3Name + " Cap MacGuffin Fragment " + itemStatus() + "</b>\n\n" + itemInfo.itemDesc[id]) : ((id != 300) ? ("<b>(" + id + ") " + itemInfo.itemName[id] + itemStatus() + "</b>\n\n" + itemInfo.itemDesc[id]) : ("<b>(" + id + ") " + character.res3.res3Name + " Bar MacGuffin Fragment " + itemStatus() + " </b>\n\n" + itemInfo.itemDesc[id]))));
			text += setBonusText();
			if (id == 341 && character.adventure.titan9SpecialReward)
			{
				text += "<b> SUPER SECRET EXILE DROP IS UNLOCKED</b>";
			}
		}
		else
		{
			text = itemDropHint();
		}
		tooltip.showTooltip(text);
	}

	public string itemDropHint()
	{
		if (setID >= 0 && setID <= 1000)
		{
			return "HINT: This is part of an equipment set in Adventure!";
		}
		if (id == 76)
		{
			return "HINT: Level up a Forest Pendant!";
		}
		if (id == 92)
		{
			return "HINT: Fight the Grand Corrupted Tree!";
		}
		if (id == 94)
		{
			return "HINT: This will take a lot of Pendants.";
		}
		if (id == 102)
		{
			return "HINT: Fight Gordon Ramsay Bolton!";
		}
		if (id == 120)
		{
			return "HINT: CLASSIFIED";
		}
		if (id == 121)
		{
			return "HINT: CLASSIFIED";
		}
		if (id == 480)
		{
			return "HINT: DO NOT ASCEND.";
		}
		if (id == 481)
		{
			return "HINT: AFTER ALL THIS TIME, YOU'RE STILL THIS IMMATURE?";
		}
		if (id == 482)
		{
			return "HINT: NGU.EXE WILL NOW CLOSE.";
		}
		if (id == 483)
		{
			return "HINT: THE 12TH, FIRST OF ITS FORM";
		}
		if (id == 484)
		{
			return "HINT: THE 12TH, LAST OF ITS FORM";
		}
		if (id == 485)
		{
			return "HINT: DO NOT LOOT.";
		}
		if (id == 486)
		{
			return "HINT: A FATAL EXCEPTION HAS OCCURED.";
		}
		if (id == 487)
		{
			return "HINT: THE 903RD TO FALL.";
		}
		if (id == 488)
		{
			return "HINT: ONE FINAL ACK.";
		}
		if (id == 489)
		{
			return "HINT: THE 12TH, SECOND OF ITS FORM";
		}
		if (id == 490)
		{
			return "HINT: SHUT IT DOWN.";
		}
		if (id == 491)
		{
			return "HINT: NEAR THE END OF THE INFINITE TOWER.";
		}
		if (id == 492)
		{
			return "HINT: A DAUNTING CAST.";
		}
		if (id == 493)
		{
			return "HINT: THE 12TH, THIRD OF ITS FORM";
		}
		if (id == 494)
		{
			return "HINT: LEECHES WILL HELP";
		}
		if (id == 495)
		{
			return "I WILL *DIE* BEFORE I LET YOU TAKE AWAY MY VISION FOR THIS WORLD!!!";
		}
		return "HINT: Beats me how you find this.";
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public string itemStatus()
	{
		string text = "";
		if (character.inventory.itemList.itemMaxxed[id])
		{
			text += "<color=Green> (MAXXED) </color>";
		}
		if (character.inventory.itemList.itemFiltered[id])
		{
			text += "<color=Grey> (FILTERED) </color>";
		}
		return text;
	}

	public int getSetID()
	{
		if (id == 62 || id == 63 || id == 64 || id == 65 || id == 75)
		{
			return 0;
		}
		if (id == 40 || id == 41 || id == 42 || id == 43 || id == 44 || id == 45 || id == 46)
		{
			return 1;
		}
		if (id == 47 || id == 48 || id == 49 || id == 50 || id == 51 || id == 52 || id == 53)
		{
			return 2;
		}
		if (id == 54 || id == 55 || id == 56 || id == 57 || id == 58 || id == 59 || id == 60 || id == 61)
		{
			return 3;
		}
		if (id >= 68 && id <= 74)
		{
			return 4;
		}
		if (id >= 78 && id <= 84)
		{
			return 5;
		}
		if (id >= 85 && id <= 91)
		{
			return 6;
		}
		if (id >= 95 && id <= 101)
		{
			return 7;
		}
		if (id >= 103 && id <= 109)
		{
			return 8;
		}
		if (id >= 111 && id <= 117)
		{
			return 9;
		}
		if (id >= 122 && id <= 126)
		{
			return 10;
		}
		if (id >= 130 && id <= 134)
		{
			return 11;
		}
		if (id >= 143 && id <= 147)
		{
			return 12;
		}
		if (id >= 150 && id <= 153)
		{
			return 13;
		}
		if (id >= 155 && id <= 158)
		{
			return 14;
		}
		if (id >= 164 && id <= 168)
		{
			return 15;
		}
		if (id >= 173 && id <= 177)
		{
			return 16;
		}
		if (id >= 184 && id <= 188)
		{
			return 17;
		}
		if (id == 213 || id == 214 || id == 215 || id == 217 || id == 218)
		{
			return 18;
		}
		if (id == 216 || id == 219)
		{
			return 19;
		}
		if (id >= 221 && id <= 225)
		{
			return 20;
		}
		if (id >= 231 && id <= 236)
		{
			return 21;
		}
		if (id >= 237 && id <= 241)
		{
			return 22;
		}
		if (id >= 251 && id <= 257)
		{
			return 23;
		}
		if (id >= 258 && id <= 264)
		{
			return 24;
		}
		if (id >= 265 && id <= 271)
		{
			return 25;
		}
		if (id >= 301 && id <= 307)
		{
			return 26;
		}
		if (id >= 308 && id <= 314)
		{
			return 27;
		}
		if (id >= 315 && id <= 321)
		{
			return 28;
		}
		if (id >= 322 && id <= 326)
		{
			return 29;
		}
		if (id >= 345 && id <= 351)
		{
			return 30;
		}
		if (id >= 352 && id <= 358)
		{
			return 31;
		}
		if (id >= 359 && id <= 365)
		{
			return 32;
		}
		if (id >= 373 && id <= 379)
		{
			return 33;
		}
		if (id >= 392 && id <= 399)
		{
			return 34;
		}
		if (id >= 400 && id <= 407)
		{
			return 35;
		}
		if (id >= 408 && id <= 415)
		{
			return 36;
		}
		if (id >= 416 && id <= 423)
		{
			return 37;
		}
		if (id >= 453 && id <= 460)
		{
			return 38;
		}
		if (id >= 496 && id <= 503)
		{
			return 39;
		}
		if (id >= 461 && id <= 468)
		{
			return 40;
		}
		if (id >= 469 && id <= 476)
		{
			return 41;
		}
		if (id >= 507 && id <= 514)
		{
			return 42;
		}
		if (id == 66)
		{
			return 1000;
		}
		if (id == 77)
		{
			return 1001;
		}
		if (id == 102)
		{
			return 1002;
		}
		if (id == 121)
		{
			return 1003;
		}
		if (id == 92)
		{
			return 1004;
		}
		if (id == 141)
		{
			return 1005;
		}
		if (id == 119)
		{
			return 1006;
		}
		if (id == 129)
		{
			return 1007;
		}
		if (id >= 136 && id <= 140)
		{
			return 1008;
		}
		if (id >= 1 && id <= 39)
		{
			return 1009;
		}
		if (id == 93)
		{
			return 1010;
		}
		if (id == 162)
		{
			return 1011;
		}
		if (id == 163)
		{
			return 1012;
		}
		if (id == 171)
		{
			return 1013;
		}
		if (id == 172)
		{
			return 1014;
		}
		if (id == 191)
		{
			return 1015;
		}
		if (id == 196)
		{
			return 1016;
		}
		if (id == 197)
		{
			return 1017;
		}
		if (id == 212)
		{
			return 1018;
		}
		if (id >= 278 && id <= 287)
		{
			return 1019;
		}
		if (id == 293)
		{
			return 1020;
		}
		if (id == 292)
		{
			return 1021;
		}
		if (id == 297)
		{
			return 1022;
		}
		if (id == 294)
		{
			return 1023;
		}
		if (id == 344)
		{
			return 1024;
		}
		if (id == 343)
		{
			return 1025;
		}
		if (id == 390)
		{
			return 1026;
		}
		if (id == 391)
		{
			return 1027;
		}
		if (id >= 432 && id <= 444)
		{
			return 1028;
		}
		if (id >= 445 && id <= 452)
		{
			return 1029;
		}
		return -1;
	}

	public string setBonusText()
	{
		string text = "";
		switch (setID)
		{
		case -1:
			text = "";
			break;
		case 0:
			text = "\n\n<b>Training Set:</b>\nItems 62, 63, 64, 65, and 75.\n\n<b>Completion Bonus (All items level 100):</b>\n\n2 Energy Speed\n10 EXP.";
			break;
		case 1:
			text = "\n\n<b>Sewers Set</b>\nItems 40-46.\n\n<b>Completion Bonus (All items level 100):</b>\n+5 Power and Toughness\n+15 max Health\n+0.2 regen\n20 EXP.";
			break;
		case 2:
			text = "\n\n<b>Forest Set:</b>\nItems 47-53.\n\n<b>Completion Bonus (All items level 100):</b>\n2 Energy Potion α\n2 Energy Potion β\n2 Energy Bar Bar\n5 Energy Power\n200 EXP.";
			break;
		case 3:
			text = "\n\n<b>Cave Set:</b>\nItems 54-61.\n\n<b>Completion Bonus (All items level 100):</b>\n2 Magic Power\n40000 Magic Cap\n2 Magic Per Bar\n300 EXP.";
			break;
		case 4:
			text = "\n\n<b>HSB Set:</b>\nItems 68-74.\n\n<b>Completion Bonus (All items level 100):</b>\n3 Magic Power\n30000 Magic Cap\n3 Magic Bars\n1 Magic Potion α\n1 Magic Potion β\n1 Magic Bar Bar\n500 EXP.";
			break;
		case 5:
			text = "\n\n<b>GRB Set:</b>\nItems 78-84.\n\n<b>Completion Bonus (All items level 100):</b>\n2000 EXP\nA small perk: The Safe Zone will now regenerate health 10x faster, instead of 5x!";
			break;
		case 6:
			text = "\n\n<b>Clock Set:</b>\nItems 85-91.\n\n<b>Completion Bonus (All items level 100):</b>\n1000 EXP\nA small perk: Enemies in Adventure will now spawn 5% Faster!";
			break;
		case 7:
			text = "\n\n<b>2D Set:</b>\nItems 95-101.\n\n<b>Completion Bonus (All items level 100):</b>\n2000 EXP\nGain a permanent 7.43% bonus drop chance for loot!";
			break;
		case 8:
			text = "\n\n<b>Spoopy Set:</b>\nItems 103-109.\n\n<b>Completion Bonus (All items level 100):</b>\n3000 EXP\nIdle attack will gain the same damage multiplier as Regular Attack!";
			break;
		case 9:
			text = "\n\n<b>Jake Set:</b>\nItems 111-117.\n\n<b>Completion Bonus (All items level 100):</b>\n7000 EXP\nYou'll also unlock a new Wandoos OS: Wandoos MEH! This is a much stronger OS, provided you have the energy and magic to spare!";
			break;
		case 10:
			text = "\n\n<b>Gaudy Set:</b>\nItems 122-126.\n\n<b>Completion Bonus (All items level 100):</b>\n5000 EXP\n2 Lucky Charms! Items that drop at level 1 or higher have a 10% chance to gain an additional level!";
			break;
		case 11:
			text = "\n\n<b>Mega Set:</b>\nItems 130-134.\n\n<b>Completion Bonus (All items level 100):</b>\n6000 EXP\nCharge will now give a 2.2x boost to the next skill used!";
			break;
		case 12:
			text = "\n\n<b>Beardverse Set:</b>\nItems 143-147.\n\n<b>Completion Bonus (All items level 100):</b>\n8000 EXP\n10% reduced penalty to levelling speed, when equipping multiple beards that use Energy or Magic at the same time!";
			break;
		case 13:
			text = "\n\n<b>Wanderer's Set:</b>\nItems 150-153.\n\n<b>Completion Bonus (All items level 100):</b>\n50000 EXP!\n10000 AP!\nA new, ultra-rare accessory is now dropped by WALDERP!";
			break;
		case 14:
			text = "\n\n<b>s'rerednaW Set:</b>\nItems 155-158.\n\n<b>Completion Bonus (All items level 100):</b>\n50000 EXP!\n10000 AP!\nA new, ultra-rare accessory is now dropped by WALDERP!";
			break;
		case 15:
			text = "\n\n<b>Badly Drawn Set:</b>\nItems 164-168.\n\n<b>Completion Bonus (All items level 100):</b>\n30000 EXP!\n5000 AP!\nBoosts are now 20% more effective!";
			break;
		case 16:
			text = "\n\n<b>Stealth Set:</b>\nItems 173-177.\n\n<b>Completion Bonus (All items level 100):</b>\n50000 EXP!\n10000 AP!\nUnlock an ultra-rare chest drop in Boring-Ass Earth!";
			break;
		case 17:
			text = "\n\n<b>Slimy Set:</b>\nItems 184-188.\n\n<b>Completion Bonus (All items level 100):</b>\n100000 EXP!\n10000 AP!\nParry's reflected attack is now 3x stronger!";
			break;
		case 18:
			text = "\n\n<b>Edgy Set:</b>\nItems 213-215, 217, and 218.\n\n<b>Completion Bonus (All items level 100):</b>\n" + character.display(character.checkExpAdded(250000L)) + " EXP!\nGain a MacGuffin slot!\n";
			break;
		case 19:
			text = "\n\n<b>Edgy Boots Set:</b>\nItems 216 and 219.\n\n<b>Completion Bonus (All items level 100):</b>\nUnlock a special drop in The Evilverse!";
			break;
		case 20:
			text = "\n\n<b>Choco Set:</b>\nItems 221-225.\n\n<b>Completion Bonus (All items level 100):</b>\nUnlock 2 special drops in Chocolate World, plus a new MacGuffin! Also: Reduce the number of kills needed per MacGuffin drop outside of the ITOPOD by 10%! Chocolate is some powerful stuff.";
			break;
		case 21:
			text = "\n\n<b>Pretty Pink Princess Set:</b>\nItems 231-236.\n\n<b>Completion Bonus (All items level 100):</b>\nEarn 10% more PP!";
			break;
		case 22:
			text = "\n\n<b>Greasy Nerd Set:</b>\nItems 237-241.\n\n<b>Completion Bonus (All items level 100):</b>\nAll MacGuffins drop 1 level higher!";
			break;
		case 23:
			text = "\n\n<b>Meta Set:</b>\nItems 251-257.\n\n<b>Completion Bonus (All items level 100):</b> +20% NGU Speed! Gotta get those Numbers Going Up!\n";
			break;
		case 24:
			text = "\n\n<b>Party Set:</b>\nItems 258-264.\n\n<b>Completion Bonus (All items level 100):</b>+5% Global Digger Bonus!\n";
			break;
		case 25:
			text = "\n\n<b>Mobster Set:</b>\nItems 265-271.\n\n<b>Completion Bonus (All items level 100):</b>+15% QP earned while Questing!\n";
			break;
		case 26:
			text = "\n\n<b>Typo Set:</b>\nItems 301-307.\n\n<b>Completion Bonus (All items level 100):</b>+20% Wish Speed!\n";
			break;
		case 27:
			text = "\n\n<b>Fad Set:</b>\nItems 308-314.\n\n<b>Completion Bonus (All items level 100):</b>10% Faster Major Quests!\n";
			break;
		case 28:
			text = "\n\n<b>JRPG Set:</b>\nItems 315-321.\n\n<b>Completion Bonus (All items level 100):</b>A better Ultimate Attack!\n";
			break;
		case 29:
			text = "\n\n<b>Exile Set:</b>\nItems 322-326.\n\n<b>Completion Bonus (All items level 100):</b>Unlocks something secret!\n";
			break;
		case 30:
			text = "\n\n<b>Rad Set:</b>\nItems 345-351.\n\n<b>Completion Bonus (All items level 100):</b>+5 Max Deck Size!\n";
			break;
		case 31:
			text = "\n\n<b>Back To School Set:</b>\nItems 352-358.\n\n<b>Completion Bonus (All items level 100):</b>+15% NGU Speed!\n";
			break;
		case 32:
			text = "\n\n<b>Western Set:</b>\nItems 359-365.\n\n<b>Completion Bonus (All items level 100):</b>An Extra Drop in this zone!\n";
			break;
		case 33:
			text = "\n\n<b>Space Set:</b>\nItems 373-379.\n\n<b>Completion Bonus (All items level 100):</b>+10% Cooking EXP Bonus!\n";
			break;
		case 34:
			text = "\n\n<b>Bread Set:</b>\nItems 392-399.\n\n<b>Completion Bonus (All items level 100):</b>Faster Cooks!!\n";
			break;
		case 35:
			text = "\n\n<b>Disco Set:</b>\nItems 400-407.\n\n<b>Completion Bonus (All items level 100):</b>Less crappy cards!\n";
			break;
		case 36:
			text = "\n\n<b>Halloweenie Set:</b>\nItems 408-415.\n\n<b>Completion Bonus (All items level 100):</b>+45% PP gain!\n";
			break;
		case 37:
			text = "\n\n<b>Rock Set:</b>\nItems 416-423.\n\n<b>Completion Bonus (All items level 100):</b>+1 tier to ALL CARDS!\n";
			break;
		case 38:
			text = "\n\n<b>Construction Set:</b>\nItems 453-460.\n\n<b>Completion Bonus (All items level 100):</b>20% Boostier Boosts!\n";
			break;
		case 39:
			text = "\n\n<b>Duck Set:</b>\nItems 496-503.\n\n<b>Completion Bonus (All items level 100):</b>+6% Mayo and Card Speed!\n";
			break;
		case 40:
			text = "\n\n<b>Dutch Set:</b>\nItems 461-468.\n\n<b>Completion Bonus (All items level 100): Faster Ritual Speed?</b>\n";
			break;
		case 41:
			text = "\n\n<b>Amalgamate Set:</b>\nItems 469-476.\n\n<b>Completion Bonus (All items level 100):</b> +10 Max Deck size!\n";
			break;
		case 42:
			text = "\n\n<b>Pirate Set:</b>\nItems 507-514.\n\n<b>Completion Bonus (All items level 100):</b> Pride and Accomplishment.\n";
			break;
		case 1000:
			text = "\n\n<b>Wandoos Set</b>\nJust this Item. Like, only this. Just level this up to 100, that's it. It's that simple.\n\n<b>Completion Bonus (All items level 100):</b>\n\nWhen Wandoos completes the booting process, gain an additional 10% speed bonus. Also, 300 EXP!";
			break;
		case 1001:
			text = "\n\n<b>Tutorial Cube Set:</b>\nJust this cube, easy peasy.\n\n<b>Completion Bonus (All items level 100):</b>\nSomething special!";
			break;
		case 1002:
			text = "\n\n<b>Number Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+10% NGU Speed!";
			break;
		case 1003:
			text = "\n\n<b>Flubber Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n30,000 AP!";
			break;
		case 1004:
			text = "\n\n<b>Seed Set ;):</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n10 Premium samples of Icarus Proudbottom's Homemade Boom Boom Fertilizers! Check out the Sellout shop for more info on what these poops do.";
			break;
		case 1005:
			text = "\n\n<b>Armpit Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+10% Beard Speed!";
			break;
		case 1006:
			text = "\n\n<b>Red Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nYou will receive the max heart EXP bonus (10%) even when the heart is not equipped!";
			break;
		case 1007:
			text = "\n\n<b>Yellow Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nYou will receive the max heart AP bonus (20%) even when the heart is not equipped!";
			break;
		case 1008:
			text = "\n\n<b>UUG's Rings Set:</b>\nItems 136-140\n\n<b>Completion Bonus (All items level 100):</b>\n20K EXP\n20K AP!\nUnlock a new, super-ultra rare drop from UUG! ";
			break;
		case 1009:
			text = "\n\n<b>Boosts Set:</b>\nItems 1-39\n\n<b>Completion Bonus(For each item maxxed):+2% permanent boosting power to ALL boosts!</b>\n";
			break;
		case 1010:
			text = "\n\n<b>Red Liquid Set:</b>\nJust this thing.\n\n<b>Completion Bonus(All items level 100):</b>\n-20% on the global cooldown timer, AND for idle attack speed! The global cooldown timer is the cooldown between using different moves, if you didn't know!\n";
			break;
		case 1011:
			text = "\n\n<b>Brown Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nEvery 10th poop you use on a fruit will not be consumed!";
			break;
		case 1012:
			text = "\n\n<b>Wandoos XL Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nWandoos now boots up 10% faster!";
			break;
		case 1013:
			text = "\n\n<b>Green Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nGain 20% faster progress towards Perk Points (PP) in the I.T.O.P.O.D!";
			break;
		case 1014:
			text = "\n\n<b>Pissed Off Key Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nGain 10% faster progress towards Perk Points (PP) in the I.T.O.P.O.D!";
			break;
		case 1015:
			text = "\n\n<b>Purple Liquid Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nBEAST MODE now grants +50% to your Power, instead of +40%!";
			break;
		case 1016:
			text = "\n\n<b>Blue Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nAll consumables give 10% better effects!";
			break;
		case 1017:
			text = "\n\n<b>Scrap of Paper Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nGain a Digger Slot!";
			break;
		case 1018:
			text = "\n\n<b>Purple Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nMacGuffins drop 20% more often!";
			break;
		case 1019:
			text = "\n\n<b>Quest Items Set</b>\nItems 278-287\n\n<b>Completion Bonus (For each item maxxed):</b>\n+2% QP rewards in Questing!";
			break;
		case 1020:
			text = "\n\n<b>Orange Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nQuests give 20% more QP!";
			break;
		case 1021:
			text = "\n\n<b>Heroic Sigil Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nQuests Items drop 10% more often!";
			break;
		case 1022:
			text = "\n\n<b>Grey Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n25% Faster Hacks!";
			break;
		case 1023:
			text = "\n\n<b>Incriminating Evidence Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+2 base " + character.res3.res3Name + " Power\n+80K base " + character.res3.res3Name + " Cap\n+2 base " + character.res3.res3Name + " Bars\n+1 of every Resource 3 Potion!";
			break;
		case 1024:
			text = "\n\n<b>Pink Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\nGain an additional Wish slot!";
			break;
		case 1025:
			text = "\n\n<b>Severed Head Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+13.37% Wish Speed!";
			break;
		case 1026:
			text = "\n\n<b>Rainbow Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+10% Mayo and Card Generation Speed!";
			break;
		case 1027:
			text = "\n\n<b>Still-Beating Heart Set:</b>\nJust this thing.\n\n<b>Completion Bonus (All items level 100):</b>\n+1% Tag Effect!";
			break;
		case 1028:
			text = "\n\n<b>Normal Bonus Accs Set:</b>\nItems 432-444.\n\n<b>Completion Bonus (All items level 100):</b>\n+25% Drop Chance";
			break;
		case 1029:
			text = "\n\n<b>Evil Bonus Accs Set:</b>\nItems 445-452.\n\n<b>Completion Bonus (All items level 100):</b>\n+20% Adventure Stats!";
			break;
		default:
			text = "\n\nCongratulations! If you see this, 4G messed something else up in the game too!";
			break;
		}
		if ((setID == 0 && character.inventory.itemList.trainingComplete) || (setID == 1 && character.inventory.itemList.sewersComplete) || (setID == 2 && character.inventory.itemList.forestComplete) || (setID == 3 && character.inventory.itemList.caveComplete) || (setID == 4 && character.inventory.itemList.HSBComplete) || (setID == 5 && character.inventory.itemList.GRBComplete) || (setID == 6 && character.inventory.itemList.clockComplete) || (setID == 7 && character.inventory.itemList.twoDComplete) || (setID == 8 && character.inventory.itemList.ghostComplete) || (setID == 9 && character.inventory.itemList.jakeComplete) || (setID == 10 && character.inventory.itemList.gaudyComplete) || (setID == 11 && character.inventory.itemList.megaComplete) || (setID == 12 && character.inventory.itemList.beardverseComplete) || (setID == 13 && character.inventory.itemList.waldoComplete) || (setID == 14 && character.inventory.itemList.antiWaldoComplete) || (setID == 15 && character.inventory.itemList.badlyDrawnComplete) || (setID == 16 && character.inventory.itemList.stealthComplete) || (setID == 17 && character.inventory.itemList.beast1complete) || (setID == 18 && character.inventory.itemList.edgyComplete) || (setID == 19 && character.inventory.itemList.edgyBootsComplete) || (setID == 20 && character.inventory.itemList.chocoComplete) || (setID == 21 && character.inventory.itemList.prettyComplete) || (setID == 22 && character.inventory.itemList.nerdComplete) || (setID == 23 && character.inventory.itemList.metaComplete) || (setID == 24 && character.inventory.itemList.partyComplete) || (setID == 25 && character.inventory.itemList.godmotherComplete) || (setID == 26 && character.inventory.itemList.typoComplete) || (setID == 27 && character.inventory.itemList.fadComplete) || (setID == 28 && character.inventory.itemList.jrpgComplete) || (setID == 29 && character.inventory.itemList.exileComplete) || (setID == 30 && character.inventory.itemList.radComplete) || (setID == 31 && character.inventory.itemList.schoolComplete) || (setID == 32 && character.inventory.itemList.westernComplete) || (setID == 33 && character.inventory.itemList.spaceComplete) || (setID == 34 && character.inventory.itemList.breadverseComplete) || (setID == 35 && character.inventory.itemList.that70sComplete) || (setID == 36 && character.inventory.itemList.halloweeniesComplete) || (setID == 37 && character.inventory.itemList.rockLobsterComplete) || (setID == 38 && character.inventory.itemList.constructionComplete) || (setID == 39 && character.inventory.itemList.duckComplete) || (setID == 40 && character.inventory.itemList.netherComplete) || (setID == 41 && character.inventory.itemList.amalgamateComplete) || (setID == 1000 && character.inventory.itemList.wandoosComplete) || (setID == 1001 && character.inventory.itemList.tutorialCubeComplete) || (setID == 1002 && character.inventory.itemList.numberComplete) || (setID == 1003 && character.inventory.itemList.flubberComplete) || (setID == 1004 && character.inventory.itemList.seedComplete) || (setID == 1005 && character.inventory.itemList.uugComplete) || (setID == 1006 && character.inventory.itemList.itemMaxxed[119]) || (setID == 1007 && character.inventory.itemList.itemMaxxed[129]) || (setID == 1008 && character.inventory.itemList.uugRingComplete) || (setID == 1009 && character.inventory.itemList.itemMaxxed[id]) || (setID == 1010 && character.inventory.itemList.itemMaxxed[93]) || (setID == 1011 && character.inventory.itemList.itemMaxxed[162]) || (setID == 1012 && character.inventory.itemList.xlComplete) || (setID == 1013 && character.inventory.itemList.greenHeartComplete) || (setID == 1014 && character.inventory.itemList.itopodKeyComplete) || (setID == 1015 && character.inventory.itemList.purpleLiquidComplete) || (setID == 1016 && character.inventory.itemList.blueHeartComplete) || (setID == 1017 && character.inventory.itemList.jakeNoteComplete) || (setID == 1018 && character.inventory.itemList.purpleHeartComplete) || (setID == 1019 && character.inventory.itemList.itemMaxxed[id]) || (setID == 1020 && character.inventory.itemList.orangeHeartComplete) || (setID == 1021 && character.inventory.itemList.sigilComplete) || (setID == 1022 && character.inventory.itemList.greyHeartComplete) || (setID == 1023 && character.inventory.itemList.evidenceComplete) || (setID == 1024 && character.inventory.itemList.pinkHeartComplete) || (setID == 1025 && character.inventory.itemList.severedHeadComplete) || (setID == 1026 && character.inventory.itemList.rainbowHeartComplete) || (setID == 1027 && character.inventory.itemList.beatingHeartComplete) || (setID == 1028 && character.inventory.itemList.normalBonusAccComplete) || (setID == 1029 && character.inventory.itemList.evilBonusAccComplete))
		{
			text += "<color=green><b> COMPLETE</b></color>";
		}
		return text;
	}
}
