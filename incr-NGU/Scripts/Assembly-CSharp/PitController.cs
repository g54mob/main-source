using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PitController : MonoBehaviour
{
	public Character character;

	public ItemNameDesc itemInfo;

	public InventoryController inventoryController;

	public ConfirmationBox box;

	public HoverTooltip tooltip;

	public Text pitText;

	public Text pitTimeText;

	public Text spinTimeText;

	public Image pitArt;

	public Sprite pitDay;

	public Sprite pitNight;

	private UnityAction yesAction;

	private UnityAction noAction;

	private string message = "";

	private void Start()
	{
		pitText.text = "The Pit is hungry. Click it to feed it all your Gold!";
		noAction = cancel;
		if (character.pit.pitTime == null)
		{
			character.pit.pitTime = new PlayerTime();
		}
		InvokeRepeating("updatePitTime", 0f, 1f);
	}

	private void updatePitTime()
	{
		character.pit.pitTime.advanceTime(1f);
		updateTimeText();
	}

	public float currentPitTime()
	{
		return 3600 * (character.pit.tossCount + 1);
	}

	private void updateTimeText()
	{
		if (character.menuID == 16)
		{
			if (character.pit.pitTime.totalseconds < (double)currentPitTime())
			{
				pitTimeText.text = character.pit.pitTime.inverseDisplayColon(currentPitTime());
			}
			else
			{
				pitTimeText.text = "FEED ME";
			}
			if (character.daily.spinTime.totalseconds >= (double)character.dailyController.targetSpinTime())
			{
				spinTimeText.text = "SPIN AVAILABLE!";
			}
			else
			{
				spinTimeText.text = "TIME TO NEXT SPIN:\n" + NumberOutput.timeOutput((double)character.dailyController.targetSpinTime() - character.daily.spinTime.totalseconds);
			}
		}
	}

	public bool canToss()
	{
		return character.pit.pitTime.totalseconds >= (double)currentPitTime();
	}

	public void tossGold()
	{
		if (character.pit.pitTime.totalseconds < (double)currentPitTime())
		{
			pitText.text = "The pit refuses your gold - you threw away all your gold too recently!";
			return;
		}
		yesAction = engage;
		box.displayBox("Do you want to toss all of your hard earned gold into this pit?", yesAction, noAction);
	}

	private void cancel()
	{
	}

	private void engage()
	{
		character.pit.pitTime.reset();
		character.pit.totalGold += character.realGold;
		oneTossReward(character.realGold);
		totalReward();
		character.realGold = 0.0;
		character.pit.tossCount++;
		if (message != "")
		{
			pitText.text = message;
			message = "";
		}
		else
		{
			message = "You feel a lot poorer... but nothing happened :c. Maybe you need to throw more gold?";
			pitText.text = message;
			message = "";
		}
		character.pit.pitState = UnityEngine.Random.state;
		character.refreshMenus();
		character.buttons.updateButtons();
	}

	public int tossFactor()
	{
		int num = character.pit.tossCount + 1;
		if (num > 10)
		{
			num = 10;
		}
		if (num < 1)
		{
			num = 1;
		}
		return num;
	}

	private void oneTossReward(double gold)
	{
		double num = Math.Log10(gold);
		long amount = (long)num;
		if (num < 1.0)
		{
			num = 1.0;
		}
		character.addAP(amount);
		if (!(num < 5.0))
		{
			if (!character.settings.badge2Part2Complete && (character.platform == platform.Kong || character.platform == platform.Kartridge))
			{
				character.settings.badge2Part2Complete = true;
				character.tooltip.showOverrideTooltip("Congrats, you just finished an objective for the Medium Badge! You can click the Info 'N Stuff menu button in the bottom left to see what else you need to do to unlock your shiny badge! :D", 15f);
				character.InfonStuffController.updateBadgeProgressText();
			}
			if (num < 7.0)
			{
				tier1Reward();
			}
			else if (num < 9.0)
			{
				tier2Reward();
			}
			else if (num < 11.0)
			{
				tier3Reward();
			}
			else if (num < 13.0)
			{
				tier4Reward();
			}
			else if (num < 15.0)
			{
				tier5Reward();
			}
			else if (num < 18.0)
			{
				tier6Reward();
			}
			else if (num < 21.0)
			{
				tier7Reward();
			}
			else if (num < 24.0)
			{
				tier8Reward();
			}
			else if (num < 27.0)
			{
				tier9Reward();
			}
			else if (num < 30.0)
			{
				tier10Reward();
			}
			else if (character.wishes.wishes[4].level < 1)
			{
				tier11Reward();
			}
			else if (num < 50.0)
			{
				tier11Reward();
			}
			else if (num < 55.0)
			{
				tier12Reward();
			}
			else if (num < 60.0)
			{
				tier13Reward();
			}
			else if (num < 65.0)
			{
				tier14Reward();
			}
			else if (num < 70.0)
			{
				tier15Reward();
			}
			else
			{
				tier16Reward();
			}
		}
	}

	private void totalReward()
	{
		float num = Mathf.FloorToInt(Mathf.Log10((float)character.pit.totalGold));
		if (num < 6f)
		{
			return;
		}
		if (num > 7f && !character.pit.tier1TRewarded)
		{
			tier1TotalReward();
			character.pit.tier1TRewarded = true;
		}
		else if (num > 9f && !character.pit.tier2TRewarded)
		{
			tier2TotalReward();
			character.pit.tier2TRewarded = true;
		}
		else if (num > 10f && !character.pit.tier3TRewarded)
		{
			if (!character.settings.filterAccessory && character.inventoryController.freeSpace())
			{
				tier3TotalReward();
				character.pit.tier3TRewarded = true;
			}
		}
		else if (num > 11f && !character.pit.tier4TRewarded)
		{
			tier4TotalReward();
			character.pit.tier4TRewarded = true;
		}
		else if (num > 12f && !character.pit.tier5TRewarded)
		{
			tier5TotalReward();
			character.pit.tier5TRewarded = true;
		}
	}

	public void levelUpTest()
	{
		inventoryController.allLevelUp();
	}

	private void tier1Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 9);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			itemInfo.makeLoot(1);
			message = "The Pit Belches and spits out an " + itemInfo.itemName[1] + "!\n\n";
			break;
		case 2:
			itemInfo.makeLoot(14);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[14] + "!\n\n";
			break;
		case 3:
			itemInfo.makeLoot(27);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[27] + "!\n\n";
			break;
		case 4:
			character.adventure.attack += 1f;
			message = "You feel slightly more powerful. +1 Power to be exact!";
			break;
		case 5:
			character.adventure.defense += 1f;
			message = "You gain +1 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 6:
			character.adventure.maxHP += 10f;
			message = "You have gained +10 Max Health. You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 7:
			character.adventure.regen += 0.1f;
			message = "You gain +0.1 health regen. Everyone is happy except for the adventure mode monsters.";
			break;
		default:
			message = "The Pit Belches and it smells awful. Unlucky!\n\n";
			break;
		}
	}

	private void tier2Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 10);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			itemInfo.makeLoot(2);
			message = "The Pit Belches and spits out an " + itemInfo.itemName[2] + "!\n\n";
			break;
		case 2:
			itemInfo.makeLoot(15);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[15] + "!\n\n";
			break;
		case 3:
			itemInfo.makeLoot(28);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[28] + "!\n\n";
			break;
		case 4:
			message = "The pit sends out a shockwave of energy... you feel like" + inventoryController.randomLevelUp() + "has grown in power!";
			break;
		case 5:
			character.addExp(1L);
			message = "You see a yellow '+1 EXP' float up out of the pit and land on your head before disappearing.";
			break;
		case 6:
			character.adventure.attack += 2f;
			message = "You feel slightly more powerful. +2 Power to be exact!";
			break;
		case 7:
			character.adventure.defense += 2f;
			message = "You gain +2 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 8:
			character.adventure.maxHP += 20f;
			message = "You have gained +20 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 9:
			character.adventure.regen += 0.2f;
			message = "You gain +0.2 health regen. Everyone is happy except for the adventure mode monsters.";
			break;
		default:
			message = "The Pit Belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier3Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 10);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			itemInfo.makeLoot(3);
			message = "The Pit Belches and spits out an " + itemInfo.itemName[3] + "!\n\n";
			break;
		case 2:
			itemInfo.makeLoot(16);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[16] + "!\n\n";
			break;
		case 3:
			itemInfo.makeLoot(29);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[29] + "!\n\n";
			break;
		case 4:
			message = "The pit sends out a shockwave of energy... you feel like" + inventoryController.randomLevelUp() + "has grown in power!";
			break;
		case 5:
			character.addExp(2L);
			message = "You see a yellow '2' float up out of the pit and land on your head before disappearing. Weird. Wonder what that could mean?";
			break;
		case 6:
			character.adventure.attack += 5f;
			message = "You feel slightly more powerful. +5 Power to be exact!";
			break;
		case 7:
			character.adventure.defense += 5f;
			message = "You gain +5 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 8:
			character.adventure.maxHP += 50f;
			message = "You have gained +50 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 9:
			character.adventure.regen += 0.5f;
			message = "You gain +0.5 health regen. Everyone is happy except for the adventure mode monsters.";
			break;
		default:
			message = "The Pit Belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier4Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 10);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			itemInfo.makeLoot(4);
			message = "The Pit Belches and spits out an " + itemInfo.itemName[4] + "!\n\n";
			break;
		case 2:
			itemInfo.makeLoot(17);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[17] + "!\n\n";
			break;
		case 3:
			itemInfo.makeLoot(30);
			message = "The Pit Belches and spits out a " + itemInfo.itemName[30] + "!\n\n";
			break;
		case 4:
			message = "The pit sends out a shockwave of energy... you feel like" + inventoryController.randomLevelUp() + "and" + inventoryController.randomLevelUp() + "have grown in power!";
			break;
		case 5:
			character.addExp(3L);
			message = "You see a yellow '+3 EXP' float up out of the pit and land on your head before disappearing.";
			break;
		case 6:
			character.adventure.attack += 10f;
			message = "You feel slightly more powerful. +10 Power to be exact!";
			break;
		case 7:
			character.adventure.defense += 10f;
			message = "You gain +10 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 8:
			character.adventure.maxHP += 75f;
			message = "You have gained +75 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 9:
			character.adventure.regen += 1f;
			message = "You gain +1 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		default:
			message = "The Pit Belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier5Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 11);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 5f;
			message = "The Pit Blesses your Infinity Cube with 5 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 5f;
			message = "The Pit Blesses your Infinity Cube with 5 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 3f;
			character.inventory.cubeToughness += 3f;
			message = "The Pit Blesses your Infinity Cube with 3 Power and 3 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(10L);
			message = "You see a yellow '+10 EXP' float up out of the pit and land on your head before disappearing.";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 10L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You manage to grab a hold of ten of them!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 20f;
			message = "You feel slightly more powerful. +20 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 20f;
			message = "You gain +20 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 150f;
			message = "You have gained +150 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 1.5f;
			message = "You gain +1.5 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		default:
			message = "The Pit Belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier6Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 12);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 10f;
			message = "The Pit Blesses your Infinity Cube with 10 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 10f;
			message = "The Pit Blesses your Infinity Cube with 10 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 5f;
			character.inventory.cubeToughness += 5f;
			message = "The Pit Blesses your Infinity Cube with 5 Power and 5 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(25L);
			message = "You gained 25 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 25L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You manage to grab a hold of 25 seeds at least!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 50f;
			message = "You feel slightly more powerful. +50 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 50f;
			message = "You gain +50 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 200f;
			message = "You have gained +200 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 2f;
			message = "You gain +2.0 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 20)
			{
				character.wandoos98.pitOSLevels++;
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +1 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier7Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 13);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 20f;
			message = "The Pit Blesses your Infinity Cube with 20 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 20f;
			message = "The Pit Blesses your Infinity Cube with 20 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 10f;
			character.inventory.cubeToughness += 10f;
			message = "The Pit Blesses your Infinity Cube with 10 Power and 10 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(25L);
			message = "You gained 25 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 100L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You manage to grab a hold of 100 seeds at least!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 100f;
			message = "You feel slightly more powerful. +100 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 100f;
			message = "You gain +100 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 300f;
			message = "You have gained +300 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 3f;
			message = "You gain +3 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 50)
			{
				character.wandoos98.pitOSLevels++;
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +1 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		case 12:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier8Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 13);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 50f;
			message = "The Pit Blesses your Infinity Cube with 50 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 50f;
			message = "The Pit Blesses your Infinity Cube with 50 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 25f;
			character.inventory.cubeToughness += 25f;
			message = "The Pit Blesses your Infinity Cube with 25 Power and 25 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(200L);
			message = "You gained 200 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 200L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You manage to grab a hold of 200 seeds! How the heck can you carry so many in your arms?";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 150f;
			message = "You feel slightly more powerful. +150 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 150f;
			message = "You gain +150 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 450f;
			message = "You have gained +450 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 5f;
			message = "You gain +5 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels += 2L;
				if (character.wandoos98.pitOSLevels > 100)
				{
					character.wandoos98.pitOSLevels = 100L;
				}
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +2 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		case 12:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier9Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 13);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 100f;
			message = "The Pit Blesses your Infinity Cube with 100 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 100f;
			message = "The Pit Blesses your Infinity Cube with 100 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 50f;
			character.inventory.cubeToughness += 50f;
			message = "The Pit Blesses your Infinity Cube with 50 Power and 50 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(300L);
			message = "You gained 300 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 300L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You manage to grab a hold of 300 seeds! How the heck can you carry so many in your arms?";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 200f;
			message = "You feel slightly more powerful. +200 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 200f;
			message = "You gain +200 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 700f;
			message = "You have gained +700 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 6f;
			message = "You gain +6 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels += 2L;
				if (character.wandoos98.pitOSLevels > 100)
				{
					character.wandoos98.pitOSLevels = 100L;
				}
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +2 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		case 12:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier10Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 13);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 150f;
			message = "The Pit Blesses your Infinity Cube with 150 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 150f;
			message = "The Pit Blesses your Infinity Cube with 150 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 75f;
			character.inventory.cubeToughness += 75f;
			message = "The Pit Blesses your Infinity Cube with 75 Power and 75 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(400L);
			message = "You gained 400 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 500L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You've rented a moving truck in advance and stuffed 500 seeds into the back!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 250f;
			message = "You feel slightly more powerful. +250 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 250f;
			message = "You gain +250 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 750f;
			message = "You have gained +750 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 7.5f;
			message = "You gain +7.5 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels += 2L;
				if (character.wandoos98.pitOSLevels > 100)
				{
					character.wandoos98.pitOSLevels = 100L;
				}
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +2 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		case 12:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier11Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 13);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
			character.inventory.cubePower += 200f;
			message = "The Pit Blesses your Infinity Cube with 200 Power!";
			break;
		case 2:
			character.inventory.cubeToughness += 200f;
			message = "The Pit Blesses your Infinity Cube with 200 Toughness!";
			break;
		case 3:
			character.inventory.cubePower += 100f;
			character.inventory.cubeToughness += 100f;
			message = "The Pit Blesses your Infinity Cube with 100 Power and 100 Toughness!";
			break;
		case 4:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 5:
			character.addExp(500L);
			message = "You gained 500 EXP! Don't get addicted to this stuff now!";
			break;
		case 6:
			if (character.settings.yggdrasilOn)
			{
				character.yggdrasil.seeds += 700L;
				message = "An explosion of giant green seeds shoot out of the pit. They smack you over the head as they fall back to the ground... ow ow ow!! You've rented a moving truck in advance and stuffed 700 seeds into the back!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 7:
			character.adventure.attack += 300f;
			message = "You feel slightly more powerful. +300 Power to be exact!";
			break;
		case 8:
			character.adventure.defense += 300f;
			message = "You gain +300 Toughness units! Or just Toughness, whatever you prefer.";
			break;
		case 9:
			character.adventure.maxHP += 900f;
			message = "You have gained +900 Max Health! You can have the crap kicked out of you just a little more, rejoice!";
			break;
		case 10:
			character.adventure.regen += 9f;
			message = "You gain +9 health regen! Everyone is happy except for the adventure mode monsters.";
			break;
		case 11:
			if (character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels += 3L;
				if (character.wandoos98.pitOSLevels > 100)
				{
					character.wandoos98.pitOSLevels = 100L;
				}
				message = "The spirit of Wandoos XP floats out of the pit and blesses your crappy OS. +3 Wandoos level!";
			}
			else
			{
				message = "The Pit belches and it smells awful.\n\n";
			}
			break;
		case 12:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier12Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 6);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
		{
			float num3 = character.bloodSpells.givePartialAdventureSpell(0.2f, tossFactor());
			message = "A small iron pill appears in front of you. You eat it and gain " + character.display(num3) + " to your Adventure stats!";
			break;
		}
		case 2:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 3:
			character.addExp(2500 * tossFactor());
			message = "You gained " + character.display(character.checkExpAdded(2500 * tossFactor())) + " EXP! Don't get addicted to this stuff now!";
			break;
		case 4:
			if (character.settings.yggdrasilOn)
			{
				long num2 = character.yggdrasilController.fruits[4].awardPartialPomegranate(0.02f, tossFactor());
				message = "A small pomegranate appears in front of you. You harvest it for " + character.display(num2) + " seeds!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 5:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier13Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 6);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
		{
			float num3 = character.bloodSpells.givePartialAdventureSpell(0.25f, tossFactor());
			message = "A small iron pill appears in front of you. You eat it and gain " + character.display(num3) + " to your Adventure stats!";
			break;
		}
		case 2:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 3:
			character.addExp(3000 * tossFactor());
			message = "You gained " + character.display(character.checkExpAdded(3000 * tossFactor())) + " EXP! Don't get addicted to this stuff now!";
			break;
		case 4:
			if (character.settings.yggdrasilOn)
			{
				long num2 = character.yggdrasilController.fruits[4].awardPartialPomegranate(0.025f, tossFactor());
				message = "A small pomegranate appears in front of you. You harvest it for " + character.display(num2) + " seeds!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 5:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier14Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 6);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
		{
			float num3 = character.bloodSpells.givePartialAdventureSpell(0.3f, tossFactor());
			message = "A small iron pill appears in front of you. You eat it and gain " + character.display(num3) + " to your Adventure stats!";
			break;
		}
		case 2:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 3:
			character.addExp(3500 * tossFactor());
			message = "You gained " + character.display(character.checkExpAdded(3500 * tossFactor())) + " EXP! Don't get addicted to this stuff now!";
			break;
		case 4:
			if (character.settings.yggdrasilOn)
			{
				long num2 = character.yggdrasilController.fruits[4].awardPartialPomegranate(0.03f, tossFactor());
				message = "A small pomegranate appears in front of you. You harvest it for " + character.display(num2) + " seeds!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 5:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier15Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 6);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
		{
			float num3 = character.bloodSpells.givePartialAdventureSpell(0.35f, tossFactor());
			message = "A small iron pill appears in front of you. You eat it and gain " + character.display(num3) + " to your Adventure stats!";
			break;
		}
		case 2:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 3:
			character.addExp(4000 * tossFactor());
			message = "You gained " + character.display(character.checkExpAdded(4000 * tossFactor())) + " EXP! Don't get addicted to this stuff now!";
			break;
		case 4:
			if (character.settings.yggdrasilOn)
			{
				long num2 = character.yggdrasilController.fruits[4].awardPartialPomegranate(0.035f, tossFactor());
				message = "A small pomegranate appears in front of you. You harvest it for " + character.display(num2) + " seeds!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 5:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier16Reward()
	{
		UnityEngine.Random.state = character.pit.pitState;
		int num = UnityEngine.Random.Range(1, 6);
		character.pit.pitState = UnityEngine.Random.state;
		switch (num)
		{
		case 1:
		{
			float num3 = character.bloodSpells.givePartialAdventureSpell(0.4f, tossFactor());
			message = "A small iron pill appears in front of you. You eat it and gain " + character.display(num3) + " to your Adventure stats!";
			break;
		}
		case 2:
			inventoryController.allLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your worn Equipment has grown in power!";
			break;
		case 3:
			character.addExp(5000 * tossFactor());
			message = "You gained " + character.display(character.checkExpAdded(5000 * tossFactor())) + " EXP! Don't get addicted to this stuff now!";
			break;
		case 4:
			if (character.settings.yggdrasilOn)
			{
				long num2 = character.yggdrasilController.fruits[4].awardPartialPomegranate(0.04f, tossFactor());
				message = "A small pomegranate appears in front of you. You harvest it for " + character.display(num2) + " seeds!";
			}
			else
			{
				message = "A giant green seed shoots out of the pit and lands by your feet! Before you can grab it, it hops back into the pit! WTF was that??";
			}
			break;
		case 5:
			inventoryController.daycareLevelUp();
			message = "The pit sends out a shockwave of energy... you feel like all of your daycare items have grown in power!";
			break;
		default:
			message = "The Pit belches and it smells awful.\n\n";
			break;
		}
	}

	private void tier1TotalReward()
	{
		message += "\n\n(BONUS ONE-TIME REWARD UNLOCKED)\n\nThe ground by the pit shakes, and you begin to feel faint. You pass out for an unknown amount of time, but when you come to, you somehow feel better than ever! +10 to Adventure Attack and Defense! +100 Max HP! + 1 HP Regen!";
		character.adventure.attack += 10f;
		character.adventure.defense += 10f;
		character.adventure.maxHP += 100f;
		character.adventure.regen += 1f;
		pitText.text = message;
	}

	private void tier2TotalReward()
	{
		message += "\n\n(BONUS ONE-TIME REWARD UNLOCKED)\n\nThe pit erupts in a golden shower! Not that kind, pervert... Anyways, some falling gold pieces smack your head and make you dizzy, but when you recover, you feel a bit of your old power and magic return to you! +1 to Energy and Magic per Bar!";
		character.energyBars++;
		character.magic.magicPerBar++;
		pitText.text = message;
	}

	private void tier3TotalReward()
	{
		message += "\n\n(BONUS ONE-TIME REWARD UNLOCKED)\n\nThe pit spews out a bunch of noxious gas.... and floating up, and out of the pit? It's Looty mcLootface! :D";
		itemInfo.makeLoot(67);
		pitText.text = message;
	}

	private void tier4TotalReward()
	{
		message += "\n\n(BONUS ONE-TIME REWARD UNLOCKED)\n\nA piercing, high pitched noise screeches from the pit, making you wince with pain! Your brain hurts...but you also feel more knowledgeable? Sure, let's go with that. +100 EXP";
		character.addExp(100L);
		pitText.text = message;
	}

	private void tier5TotalReward()
	{
	}

	public void refreshMenu()
	{
		if (character.menuID == 16)
		{
			updateTimeText();
			updatePitImage();
		}
	}

	public void updatePitImage()
	{
		if (character.menuID == 16)
		{
			if (DateTime.Now.Hour >= 7 && DateTime.Now.Hour <= 19)
			{
				pitArt.sprite = pitDay;
			}
			else
			{
				pitArt.sprite = pitNight;
			}
		}
	}
}
