using UnityEngine;
using UnityEngine.Events;

public class AllItemListController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public ItemListDisplayController itemDisplay;

	public ItemListDisplayController itemDisplay2;

	public ItemListController[] itemList = new ItemListController[200];

	public int totalDiscovered;

	public int totalMaxxed;

	private UnityAction yesAction;

	private UnityAction noAction;

	private void Start()
	{
		refreshMenu();
		noAction = cancel;
	}

	public void cancel()
	{
	}

	public void updateList()
	{
		for (int i = 0; i < itemList.Length; i++)
		{
			if (!(itemList[i] == null))
			{
				itemList[i].updateGraphic();
			}
		}
	}

	public void changePage(int pageID)
	{
		int num = pageID * 108;
		for (int i = 0; i < itemList.Length; i++)
		{
			if (!(itemList[i] == null))
			{
				itemList[i].id = num + 1;
				num++;
				itemList[i].setID = itemList[i].getSetID();
				itemList[i].updateGraphic();
			}
		}
	}

	public void debugItemListStats()
	{
		Debug.Log(totalDiscovered + " Seen");
		Debug.Log(totalMaxxed + " Maxxed");
	}

	public void debugItemListStatsSave()
	{
		updateEquipmentBonus();
		Debug.Log(character.inventory.itemList.totalDiscovered + " Seen");
		Debug.Log(character.inventory.itemList.totalMaxxed + " Maxxed");
	}

	public void updateEquipmentBonus()
	{
		totalDiscovered = 0;
		totalMaxxed = 0;
		for (int i = 0; i < character.inventory.itemList.itemDropped.Count; i++)
		{
			if (character.inventory.itemList.itemDropped[i])
			{
				totalDiscovered++;
			}
			if (character.inventory.itemList.itemMaxxed[i])
			{
				totalMaxxed++;
			}
		}
		updateSaveListInfo();
		itemDisplay.updateDisplay();
	}

	public void updateSaveListInfo()
	{
		character.inventory.itemList.totalDiscovered = totalDiscovered;
		character.inventory.itemList.totalMaxxed = totalMaxxed;
	}

	public void updateDisplay()
	{
		itemDisplay.updateDisplay();
	}

	public void refreshMenu()
	{
		updateEquipmentBonus();
		updateList();
	}

	public float boostBonus()
	{
		int num = 0;
		float num2 = 1f;
		for (int i = 0; i <= 39; i++)
		{
			if (character.inventory.itemList.itemMaxxed[i])
			{
				num++;
			}
		}
		num2 += 0.02f * (float)num;
		if (character.inventory.itemList.badlyDrawnComplete)
		{
			num2 *= 1.2f;
		}
		if (character.inventory.itemList.constructionComplete)
		{
			num2 *= 1.2f;
		}
		num2 *= character.adventureController.itopod.totalBoostBonus();
		return num2 * character.beastQuestPerkController.totalBoostBonus();
	}

	public void markItemAsDropped(int id)
	{
		if (id >= 0 && id < character.inventory.itemList.itemDropped.Count && !character.inventory.itemList.itemDropped[id])
		{
			character.inventory.itemList.itemDropped[id] = true;
			updateEquipmentBonus();
		}
	}

	public void markItemAsMaxxed(int id)
	{
		if (!character.inventory.itemList.itemMaxxed[id])
		{
			character.inventory.itemList.itemMaxxed[id] = true;
			character.inventory.itemList.itemDropped[id] = true;
			updateEquipmentBonus();
		}
		checkforBonuses();
	}

	public void checkforBonuses()
	{
		if (!character.inventory.itemList.trainingComplete && character.inventory.itemList.maxxedTraining())
		{
			character.inventory.itemList.trainingComplete = true;
			character.energySpeed += 2f;
			character.addExp(10L);
			tooltip.showTooltip("You've maxxed out every item in the training set, congrats! You've been awarded 2 Energy Speed and 10 EXP! You also unlocked a new player portrait in the Fight Boss Menu!", 5f);
			character.portraits.portraitUnlocked[11] = true;
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.sewersComplete && character.inventory.itemList.maxxedSewers())
		{
			character.inventory.itemList.sewersComplete = true;
			character.adventure.attack += 5f;
			character.adventure.defense += 5f;
			character.adventure.maxHP += 15f;
			character.adventure.regen += 0.2f;
			character.addExp(20L);
			tooltip.showOverrideTooltip("You've maxxed out every item in the sewers set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also been awarded:\n+5 to Power and Toughness\n15 max Health\n0.2 regen\nAnd 20 EXP!", 5f);
			character.portraits.portraitUnlocked[12] = true;
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.forestComplete && character.inventory.itemList.maxxedForest())
		{
			character.inventory.itemList.forestComplete = true;
			character.arbitrary.energyPotion1Count += 2;
			character.arbitrary.energyPotion2Count += 2;
			character.arbitrary.energyBarBar1Count += 2;
			character.energyPower += 5f;
			character.addExp(200L);
			tooltip.showOverrideTooltip("You've maxxed out every item in the forest set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n\n2 Energy Potion α\n2 Energy Potion β\n2 Energy Bar Bar\n5 Energy Power\nAnd 200 EXP!", 5f);
			character.portraits.portraitUnlocked[13] = true;
			character.portraits.portraitUnlocked[14] = true;
			character.portraits.portraitUnlocked[15] = true;
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.caveComplete && character.inventory.itemList.maxxedCave())
		{
			character.inventory.itemList.caveComplete = true;
			character.addExp(300L);
			character.magic.magicPower += 2f;
			character.magic.capMagic += 40000L;
			character.magic.magicPerBar += 2L;
			character.portraits.portraitUnlocked[16] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the cave set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n2 Magic Power\n40,000 Magic Cap\n2 Magic Per Bar\nAnd 300 EXP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.HSBComplete && character.inventory.itemList.maxxedHSB())
		{
			character.inventory.itemList.HSBComplete = true;
			character.addExp(500L);
			character.magic.magicPerBar += 3L;
			character.magic.magicPower += 3f;
			character.magic.capMagic += 30000L;
			character.arbitrary.magicBarBar1Count++;
			character.arbitrary.magicPotion1Count++;
			character.arbitrary.magicPotion2Count++;
			character.portraits.portraitUnlocked[17] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the HSB set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n3 Magic Power\n30000 magic Cap\n3 Magic Bars\n1 Magic Bar Bar\n1 Magic Potion α\n1 Magic Potion β\nAnd 500 EXP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.GRBComplete && character.inventory.itemList.maxxedGRB())
		{
			character.inventory.itemList.GRBComplete = true;
			character.addExp(2000L);
			character.portraits.portraitUnlocked[18] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the GRB set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n2000 EXP!\n Also, the Safe Zone will now provide a 10x HP Regen boost instead of 5x!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.clockComplete && character.inventory.itemList.maxxedClock())
		{
			character.inventory.itemList.clockComplete = true;
			character.addExp(1000L);
			character.portraits.portraitUnlocked[19] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Clockwork set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n1000 EXP!\n Also, enemies will now spawn 5% Faster!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.twoDComplete && character.inventory.itemList.maxxed2D())
		{
			character.inventory.itemList.twoDComplete = true;
			character.addExp(2000L);
			character.portraits.portraitUnlocked[20] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the 2D set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n2000 EXP!\nYour drop chance in Adventure has permanently increased by 7.43%! Why that weird number? Ask room 1 of the NGU Idle chat!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.ghostComplete && character.inventory.itemList.maxxedGhost())
		{
			character.inventory.itemList.ghostComplete = true;
			character.addExp(3000L);
			character.portraits.portraitUnlocked[21] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Ghost set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n3000 EXP!\nAlso, Idle attack now has the damage multiplier of regular Attack!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.jakeComplete && character.inventory.itemList.maxxedJake())
		{
			character.inventory.itemList.jakeComplete = true;
			character.addExp(7000L);
			character.portraits.portraitUnlocked[22] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Jake set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n7000 EXP!\nAlso, you've unlocked wandoos MEH!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.gaudyComplete && character.inventory.itemList.maxxedGaudy())
		{
			character.inventory.itemList.gaudyComplete = true;
			character.addExp(5000L);
			character.arbitrary.lootCharm1Count += 2;
			character.portraits.portraitUnlocked[23] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Gaudy set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n5000 EXP!\n2 Lucky charms!\nAlso, any item that drops at level 1 or higher has a 10% chance of dropping at +1 level!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.megaComplete && character.inventory.itemList.maxxedMega())
		{
			character.inventory.itemList.megaComplete = true;
			character.addExp(6000L);
			character.portraits.portraitUnlocked[24] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Mega set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n6000 EXP!\nAlso, Charge attack now gives a 2.2x bonus to your next move, instead of 2.0!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.beardverseComplete && character.inventory.itemList.maxxedBeardverse())
		{
			character.inventory.itemList.beardverseComplete = true;
			character.addExp(8000L);
			character.portraits.portraitUnlocked[25] = true;
			tooltip.showOverrideTooltip("You completed the Beardverse Set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n8000 EXP!\nAlso, Equipping multiple beards that use Energy or Magic at the same time have a 10% reduced penalty to levelling speed!", 4f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.uugRingComplete && character.inventory.itemList.maxxedRingUUG())
		{
			character.inventory.itemList.uugRingComplete = true;
			long num = character.addExp(20000L);
			long num2 = character.addAP(20000);
			tooltip.showOverrideTooltip("You completed the UUG's Rings Set, congrats! You've been awarded:\n" + num + " EXP!\n" + num2 + " AP!\nAlso, you've unlocked a sixth and ULTRA rare ring drop from UUG! Happy grinding! :D", 4f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.wandoosComplete && character.inventory.itemList.maxxedWandoos())
		{
			character.inventory.itemList.wandoosComplete = true;
			character.addExp(300L);
			tooltip.showOverrideTooltip("You've maxxed out your Wandoos item, congrats! You've been awarded 300 EXP and a special little perk: When wandoos finishes booting up, you will receive a 10% bonus to its leveling speed! And sure, let's add 300 EXP to the pot.", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.tutorialCubeComplete && character.inventory.itemList.maxxedTutorialCube())
		{
			character.inventory.itemList.tutorialCubeComplete = true;
			character.addAP(10000);
			tooltip.showOverrideTooltip("You've merged the Tutorial Cube to level 100, and it cracks open! You look inside and see... :o! 10,000 Arbitrary Points (AP)! These meaningless points can buy cool items in the 4G Sellout shop! You'll earn AP for a lot of things as you continue to play.", 8f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.numberComplete && character.inventory.itemList.maxxedNumber())
		{
			character.inventory.itemList.numberComplete = true;
			tooltip.showOverrideTooltip("For creating a level 100 Number, you've been awarded a 10% speed boost to the NGU feature!", 4f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.flubberComplete && character.inventory.itemList.maxxedFlubber())
		{
			character.inventory.itemList.flubberComplete = true;
			tooltip.showOverrideTooltip("For creating a level 100 Triple Flubber (:o), you've been awarded 30,000 AP!", 4f);
			character.addAP(30000);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.seedComplete && character.inventory.itemList.maxxedSeed())
		{
			character.inventory.itemList.seedComplete = true;
			tooltip.showOverrideTooltip("For creating a level 100 Seed (:o), you've been awarded 10 Premium samples of Icarus Proudbottom's Homeamde Boom Boom Fertilizers! Check out the Sellout shop for more info on what these poops do.", 4f);
			character.arbitrary.poop1Count += 10;
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.uugComplete && character.inventory.itemList.maxxedUUG())
		{
			character.inventory.itemList.uugComplete = true;
			tooltip.showOverrideTooltip("For creating a level 100 piece of Armpit Hair (gross), you've been awarded a 10% boost to your Beard Speed!", 4f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.redLiquidComplete && character.inventory.itemList.maxxedRedLiquid())
		{
			character.inventory.itemList.redLiquidComplete = true;
			character.adventure.setFasterIdleAttack();
			tooltip.showOverrideTooltip("For creating a level 100 Red Liquid, the global cooldown timer is reduced by 20%! Yes, this also means Idle Attack! Yaaaaay!", 4f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.waldoComplete && character.inventory.itemList.maxxedWaldo())
		{
			character.inventory.itemList.waldoComplete = true;
			character.addExp(50000L);
			character.addAP(10000);
			character.portraits.portraitUnlocked[26] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Wanderer's set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n50000 EXP!\n10000 AP!\nA new, ultra-rare accessory can now drop from WALDERP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.antiWaldoComplete && character.inventory.itemList.maxxedAntiWaldo())
		{
			character.inventory.itemList.antiWaldoComplete = true;
			character.addExp(50000L);
			character.addAP(10000);
			character.portraits.portraitUnlocked[27] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the s'rerednaW set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n50000 EXP!\n10000 AP!\nA new, ultra-rare accessory can now drop from WALDERP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.badlyDrawnComplete && character.inventory.itemList.maxxedBadlyDrawn())
		{
			character.inventory.itemList.badlyDrawnComplete = true;
			character.portraits.portraitUnlocked[28] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Badly Drawn set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n" + character.addExp(30000L) + " EXP!\n" + character.addAP(5000) + " AP!\nBoosts now provide 20% more boostification! (Hey, that's not even a word!)", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.stealthComplete && character.inventory.itemList.maxxedStealth())
		{
			character.inventory.itemList.stealthComplete = true;
			character.portraits.portraitUnlocked[29] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Stealth Set set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n" + character.addExp(50000L) + " EXP!\n" + character.addAP(10000) + " AP!\nYou can now also find a SUPER rare chest drop in Boring-Ass Earth!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.beast1complete && character.inventory.itemList.maxxedBeast1())
		{
			character.inventory.itemList.beast1complete = true;
			character.portraits.portraitUnlocked[30] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Beast Set set, congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded:\n" + character.addExp(100000L) + " EXP!\n" + character.addAP(10000) + " AP!\nParry now performs an attack that does 3x the damage!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.brownHeartComplete && character.inventory.itemList.maxxedBrownHeart())
		{
			character.inventory.itemList.brownHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Brown Heart Set, Congrats. Now, once every 10 poops you use on a fruit will not be consumed!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.xlComplete && character.inventory.itemList.maxxedXL())
		{
			character.inventory.itemList.xlComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Wandoos XL Set, Congrats! Wandoos bootup time has now been reduced by 10%!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.greenHeartComplete && character.inventory.itemList.maxxedGreenHeart())
		{
			character.inventory.itemList.greenHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Green Heart Set, Congrats! Progress towards your next Perk Point (PP) in the I.T.O.P.O.D is now 20% faster!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.itopodKeyComplete && character.inventory.itemList.maxxedItopodKey())
		{
			character.inventory.itemList.itopodKeyComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Pissed Off Key Set, Congrats! Progress towards your next Perk Point (PP) in the I.T.O.P.O.D is now 10% faster!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.purpleLiquidComplete && character.inventory.itemList.maxxedPurpleLiquid())
		{
			character.inventory.itemList.purpleLiquidComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Purple Liquid Set, Congrats! Beast Mode will now increase your power by 50% instead of 40%!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.blueHeartComplete && character.inventory.itemList.maxxedBlueHeart())
		{
			character.inventory.itemList.blueHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Blue Heart Set, Congrats! All consumables now grant 10% better effects!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.jakeNoteComplete && character.inventory.itemList.maxxedJakeNote())
		{
			character.inventory.itemList.jakeNoteComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Scrap of Paper Set, Congrats! You earned a new digger slot!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.purpleHeartComplete && character.inventory.itemList.maxxedPurpleHeart())
		{
			character.inventory.itemList.purpleHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Purple Heart Set, Congrats! All MacGuffins will now drop 20% more often!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.edgyComplete && character.inventory.itemList.maxxedEdgy())
		{
			character.inventory.itemList.edgyComplete = true;
			character.addExp(250000L);
			character.portraits.portraitUnlocked[32] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Edgy Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've been awarded " + character.display(character.checkExpAdded(250000L)) + " EXP! You also gained a free MacGuffin slot!", 5f);
			character.inventoryController.updateMacguffinCount();
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.edgyBootsComplete && character.inventory.itemList.maxxedEdgyBoots())
		{
			character.inventory.itemList.edgyBootsComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Boots Set, Congrats! You've unlocked a special drop in The Evilverse!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.chocoComplete && character.inventory.itemList.maxxedChoco())
		{
			character.inventory.itemList.chocoComplete = true;
			character.portraits.portraitUnlocked[31] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Choco Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've unlocked:\n\n2 rare accessory drops in Chocolate World!\nA new MacGuffin drops in Chocolate World!\nMacGuffins require 10% fewer kills per drop outside of the ITOPOD!\n\nChocolate is awesome!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.prettyComplete && character.inventory.itemList.maxxedPretty())
		{
			character.inventory.itemList.prettyComplete = true;
			character.portraits.portraitUnlocked[33] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Pretty Pink Princess Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You'll now earn PP 10% Faster", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.nerdComplete && character.inventory.itemList.maxxedNerd())
		{
			character.inventory.itemList.nerdComplete = true;
			character.portraits.portraitUnlocked[34] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Greasy Nerd Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! Now every MacGuffin will drop 1 level higher!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.metaComplete && character.inventory.itemList.maxxedMeta())
		{
			character.inventory.itemList.metaComplete = true;
			character.portraits.portraitUnlocked[35] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Meta Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've gained +20% NGU Speed!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.partyComplete && character.inventory.itemList.maxxedParty())
		{
			character.inventory.itemList.partyComplete = true;
			character.portraits.portraitUnlocked[36] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Party Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've gained +5% to your Global Digger Bonus!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.godmotherComplete && character.inventory.itemList.maxxedGodmother())
		{
			character.inventory.itemList.godmotherComplete = true;
			character.portraits.portraitUnlocked[37] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Mobster Set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! Quests will now reward 15% more QP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.orangeHeartComplete && character.inventory.itemList.maxxedOrangeHeart())
		{
			character.inventory.itemList.orangeHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Orange Heart Set, Congrats! Quests will now reward 20% more QP!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.sigilComplete && character.inventory.itemList.maxxedHeroicSigil())
		{
			character.inventory.itemList.sigilComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Heroic Sigil Set, congrats! Quest Items will now drop 10% more often.", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.greyHeartComplete && character.inventory.itemList.maxxedGreyHeart())
		{
			character.inventory.itemList.greyHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Grey Heart Set, Congrats! Now your Hacks will be 25% faster", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.evidenceComplete && character.inventory.itemList.maxxedEvidence() && character.res3.res3On)
		{
			character.inventory.itemList.evidenceComplete = true;
			character.res3.res3Power += 2f;
			character.res3.capRes3 += 80000L;
			character.res3.res3PerBar += 2L;
			character.arbitrary.res3Potion1Count++;
			character.arbitrary.res3Potion2Count++;
			character.arbitrary.res3Potion3Count++;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Incriminating Evidence Set, Congrats! You've gained +2 base " + character.res3.res3Name + " Power, 80K base" + character.res3.res3Name + " Cap and +2 base " + character.res3.res3Name + " Bars! you also gained +1 to each Resource 3 Potion", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.typoComplete && character.inventory.itemList.maxxedTypo())
		{
			character.inventory.itemList.typoComplete = true;
			character.portraits.portraitUnlocked[38] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Typo set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also gained +20% Wish Speed!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.fadComplete && character.inventory.itemList.maxxedFad())
		{
			character.inventory.itemList.fadComplete = true;
			character.arbitrary.beastButterCount += 3;
			character.portraits.portraitUnlocked[39] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Fad set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You'll now gain Major Quests 10% faster! You also gained 3 Beast Butter!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.jrpgComplete && character.inventory.itemList.maxxedJRPG())
		{
			character.inventory.itemList.jrpgComplete = true;
			character.portraits.portraitUnlocked[40] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the JRPG set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! Your ultimate attack is even more ultimate-r now!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.exileComplete && character.inventory.itemList.maxxedExile())
		{
			character.inventory.itemList.exileComplete = true;
			character.portraits.portraitUnlocked[41] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Exile set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You gained nothing else though...or have you? Up to you to figure out this mystery!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.pinkHeartComplete && character.inventory.itemList.maxxedPinkHeart())
		{
			character.inventory.itemList.pinkHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Pink Heart set, Congrats! You unlocked an additional Wish Slot!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.severedHeadComplete && character.inventory.itemList.maxxedSeveredHead())
		{
			character.inventory.itemList.severedHeadComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Severed Head set, Congrats! You've gained +13.37% Wish Speed! Wouldn't this joke be better used for Hacks though?", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.radComplete && character.inventory.itemList.maxxedRad())
		{
			character.inventory.itemList.radComplete = true;
			character.portraits.portraitUnlocked[47] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Rad set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! you've also gained +5 Max Deck Size", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.schoolComplete && character.inventory.itemList.maxxedSchool())
		{
			character.inventory.itemList.schoolComplete = true;
			character.portraits.portraitUnlocked[48] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Back To School set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! you also gained +15% NGU Speed", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.westernComplete && character.inventory.itemList.maxxedWestern())
		{
			character.inventory.itemList.westernComplete = true;
			character.portraits.portraitUnlocked[49] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Western set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also unlocked a new drop in The West World", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.spaceComplete && character.inventory.itemList.maxxedSpace())
		{
			character.inventory.itemList.spaceComplete = true;
			character.portraits.portraitUnlocked[50] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Space set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also gained 10% improved cook results!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.rainbowHeartComplete && character.inventory.itemList.maxxedRainbowHeart())
		{
			character.inventory.itemList.rainbowHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Rainbow Heart set, Congrats! You've gained +10% Mayo and Card Generation Speed!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.beatingHeartComplete && character.inventory.itemList.maxxedBeatingHeart())
		{
			character.inventory.itemList.beatingHeartComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Still-Beating Heart set, Congrats! You've gained +1% Tag Effect!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.breadverseComplete && character.inventory.itemList.maxxedBread())
		{
			character.inventory.itemList.breadverseComplete = true;
			character.portraits.portraitUnlocked[52] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Bread set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You can now eat 30 minutes faster!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.that70sComplete && character.inventory.itemList.maxxed70sZone())
		{
			character.inventory.itemList.that70sComplete = true;
			character.portraits.portraitUnlocked[53] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Disco set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You also generate slightly less crappier cards!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.halloweeniesComplete && character.inventory.itemList.maxxedHalloweenies())
		{
			character.inventory.itemList.halloweeniesComplete = true;
			character.portraits.portraitUnlocked[54] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Halloweenies set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also earned +45% PP gain!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.rockLobsterComplete && character.inventory.itemList.maxxedRockLobster())
		{
			character.inventory.itemList.rockLobsterComplete = true;
			character.portraits.portraitUnlocked[55] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Rock Lobster set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You also gained +1 tier to ALL CARDS. Hoo yeah!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.constructionComplete && character.inventory.itemList.maxxedConstruction())
		{
			character.inventory.itemList.constructionComplete = true;
			character.portraits.portraitUnlocked[59] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Construction set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You also gained 20% Boostier Boosts!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.duckComplete && character.inventory.itemList.maxxedDuck())
		{
			character.inventory.itemList.duckComplete = true;
			character.portraits.portraitUnlocked[60] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Duck set, Conquacks! You unclucked a new player portrait in the Fight Goss Menu! You also generate 6% Faster Mayo and Cards! QUACK.", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.netherComplete && character.inventory.itemList.maxxedNether())
		{
			character.inventory.itemList.netherComplete = true;
			character.portraits.portraitUnlocked[61] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Nether set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You've also earned +25% Faster Blood Magic Rituals!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.amalgamateComplete && character.inventory.itemList.maxxedAmalgamate())
		{
			character.inventory.itemList.amalgamateComplete = true;
			character.portraits.portraitUnlocked[62] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Amalgamate set, Congrats! You unlocked a new player portrait in the Fight Boss Menu! You also gain +10 max deck size!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.pirateComplete && character.inventory.itemList.maxxedPirate())
		{
			character.inventory.itemList.pirateComplete = true;
			character.portraits.portraitUnlocked[66] = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Pirate set, Congrats! You unlocked a new player portrait in the Fight Boss Menu!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.normalBonusAccComplete && character.inventory.itemList.maxxedNormalBonusAcc())
		{
			character.inventory.itemList.normalBonusAccComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Bonus Shinies Set (Normal), Congrats! You gained +25% Drop Chance!", 5f);
			character.refreshMenus();
		}
		else if (!character.inventory.itemList.evilBonusAccComplete && character.inventory.itemList.maxxedEvilBonusAcc())
		{
			character.inventory.itemList.evilBonusAccComplete = true;
			tooltip.showOverrideTooltip("You've maxxed out every item in the Bonus Shinies Set (Evil), Congrats! You gained 20% to adventure Stats", 5f);
			character.refreshMenus();
		}
	}

	public void startClearFilter()
	{
		yesAction = clearFilter;
		box.displayBox("Are you sure you want to clear ALL of your filters?", yesAction, noAction);
	}

	public void clearFilter()
	{
		for (int i = 0; i < character.inventory.itemList.itemFiltered.Count; i++)
		{
			character.inventory.itemList.itemFiltered[i] = false;
		}
		updateList();
	}
}
