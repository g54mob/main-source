using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
	public AdventureController ac;

	public Character character;

	public PlayerLog log;

	public ItemNameDesc itemInfo;

	public InventoryController ic;

	public NumberFormat format;

	public List<long> baseKillsPerMacguffin = new List<long>();

	private void Start()
	{
		character.testMode();
	}

	public long macGuffinThreshold(int macGuffintype)
	{
		long num = baseKillsPerMacguffin[macGuffintype];
		if (character.inventory.itemList.purpleHeartComplete)
		{
			num = (long)((double)num * 0.8);
		}
		if (character.inventory.itemList.chocoComplete)
		{
			num = (long)((double)num * 0.9);
		}
		return num;
	}

	public int titanLevelBonus()
	{
		int num = 0;
		if (character.allChallenges.noRebirthChallenge.completions() > 0)
		{
			num++;
		}
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public double goldDrop(float baseGold)
	{
		float num = Random.Range(4f, 5f);
		double num2 = (double)baseGold * (double)num * (double)character.totalGoldbonus();
		if (num2 < 0.0)
		{
			num2 = 0.0;
		}
		character.addGold(num2);
		character.timeMachineController.setbaseGold(num2);
		return num2;
	}

	public void zone0Drop(Enemy enemy)
	{
		if (character.bossID > 58 && Random.Range(58, 301) <= character.bossID)
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(120, 10) + "! WTF, it's real?");
		}
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = 0f;
		float num3 = character.lootFactor();
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(100f)) + " gold! Sweet!");
			if (!character.inventory.itemList.itemDropped[75])
			{
				log.AddEvent(enemy.name + " also dropped a Stick!");
				itemInfo.makeLevelledLoot(75, 10);
			}
			else if (value < (num2 += 0.25f * num3))
			{
				log.AddEvent(enemy.name + " also dropped a Stick!");
				itemInfo.makeLevelledLoot(75, 10);
			}
			if (character.inventory.itemList.itemDropped[62] && character.inventory.itemList.itemDropped[63] && character.inventory.itemList.itemDropped[64] && character.inventory.itemList.itemDropped[65] && character.inventory.itemList.itemDropped[75])
			{
				value = Random.value;
				num2 = 0f;
				if (value < (num2 += 0.15f * num3))
				{
					switch (Random.Range(1, 4))
					{
					case 1:
						log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(1) + itemInfo.endRemark());
						break;
					case 2:
						log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(14) + itemInfo.endRemark());
						break;
					case 3:
						log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(27) + itemInfo.endRemark());
						break;
					}
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(200f)) + " gold! Sweet!");
			if (value < Mathf.Min(num2 += 0.07f * num3, 0.08f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(1L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num2 = 0f;
			if (!character.inventory.itemList.itemDropped[62])
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(62, 10) + itemInfo.endRemark());
			}
			else if (!character.inventory.itemList.itemDropped[65])
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(65, 10) + itemInfo.endRemark());
			}
			else if (!character.inventory.itemList.itemDropped[64])
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(64, 10) + itemInfo.endRemark());
			}
			else if (!character.inventory.itemList.itemDropped[63])
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(63, 10) + itemInfo.endRemark());
			}
			else
			{
				switch (Random.Range(0, 4))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(62, 10) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(63, 10) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(64, 10) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(65, 10) + itemInfo.endRemark());
					break;
				}
			}
		}
		character.lootState = Random.state;
	}

	public void zone1Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		float num = 0f;
		int num2 = Random.Range(0, 7);
		float num3 = character.lootFactor();
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(400f)) + " gold! Sweet!");
			value = Random.value;
			num = 0f;
			if (value < (num += 0.15f * num3))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(14) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(27) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(600f)) + " gold! Sweet!");
			if (value < Mathf.Min(num += 0.085f * num3, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(1L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num = 0f;
			if (value < (num += 0.65f * num3))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(40, 4) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(41, 4) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(42, 4) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(43, 4) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(44, 4) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(45, 4) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(46, 4) + itemInfo.endRemark());
					break;
				}
				if (!character.settings.badge2Part1Complete && character.inventory.itemList.droppedAllSewers() && (character.platform == platform.Kong || character.platform == platform.Kartridge))
				{
					character.settings.badge2Part1Complete = true;
					character.tooltip.showOverrideTooltip("Congrats, you just finished an objective for the Medium Badge! You can click the Info 'N Stuff menu button in the bottom left to see what else you need to do to unlock your shiny badge! :D", 15f);
					character.InfonStuffController.updateBadgeProgressText();
				}
			}
			num = 0f;
			value = Random.value;
			if (value < (num += 0.1f * num3))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(77, 4) + itemInfo.endRemark());
			}
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(0))
		{
			dropMacguffin(enemy.name, 198, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 278 && !character.beastQuest.idleMode)
		{
			num = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(278).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone2Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		float num = character.lootFactor();
		int num2 = Random.Range(0, 7);
		float num3 = 0f;
		character.lootState = Random.state;
		if ((character.bossID >= 100 || character.inventory.itemList.itemDropped[135]) && enemy.name == "Goblin")
		{
			if (value < (num3 += 0.008f * num))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(135, 1) + "! APATHYYYYYYYYYY!");
			}
			else
			{
				log.AddEvent("You spot a ring on Droop's finger, but it crumbles into dust before you can loot it. Better luck next time?");
			}
		}
		value = Random.value;
		num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(900f)) + " gold! Sweet!");
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.12f * num))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(14) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(27) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.08f * num))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(2) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(15) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(28) + itemInfo.endRemark());
					break;
				}
			}
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && enemy.name == "Skeleton")
			{
				if (character.adventure.skeletonWhacked)
				{
					log.AddEvent("Hey genius, <b>Skeleton</b> has already been crossed off the Death Note!");
					log.AddEvent("Now you're just whacking off for fun.");
				}
				else
				{
					character.adventure.skeletonWhacked = true;
					log.AddEvent("You wonder what this skeleton did to piss the mafia so much that they whacked him off, even when  ");
					log.AddEvent("he was already undead. Oh well! <b>Skeleton</b> has been crossed off the Death Note!");
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1500f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.1f * num, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(1L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.5f * num))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(47, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(48, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(49, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(50, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(51, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(52, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(53) + "! What a piece of junk...");
					break;
				}
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.013f * num))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(432, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(2))
		{
			dropMacguffin(enemy.name, 200, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 281 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(281).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone3Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 9);
		float num2 = character.lootFactor();
		float num3 = 0f;
		character.lootState = Random.state;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2200f)) + " gold! Sweet!");
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.13f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(14) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(27) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.12f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(2) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(15) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(28) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.12f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(1L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.75f * num2))
			{
				switch (Random.Range(0, 9))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(54) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(55) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(56) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(57) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(58) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(59) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(60) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(61) + itemInfo.endRemark());
					break;
				case 8:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(53, 1) + " !Wait, this crap again? Ugh!");
					break;
				}
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.0125f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(433, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(1))
		{
			dropMacguffin(enemy.name, 199, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone4Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		float num = character.lootFactor();
		float num2 = 0f;
		int num3 = Random.Range(0, 6);
		character.lootState = Random.state;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(4000f)) + " gold! Sweet!");
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.08f * num))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(3) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(16) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeLoot(29) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.08f * num))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(2) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(15) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(28) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num2 = 0f;
			if (enemy.name == "Icarus Proudbottom" && value < (num2 += Mathf.Min(0.0005f * num, 0.005f)))
			{
				character.arbitrary.poop1Count++;
				log.AddEvent(enemy.name + " also dropped some Boom Booms! +1 Poop for you.");
			}
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && enemy.name == "Icarus Proudbottom")
			{
				if (character.adventure.icarusWhacked)
				{
					log.AddEvent("Hey genius,<b>Icarus Proudbottom</b> has already been crossed off the Death Note!");
					log.AddEvent("Now you're just whacking off for fun.");
				}
				else
				{
					character.adventure.icarusWhacked = true;
					log.AddEvent("Shouldn't have dropped your boombooms on the Godmother's limo, Icarus. Shitty move.");
					log.AddEvent("<b>Icarus Proudbottom</b> has been crossed off the Death Note!");
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(6000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num2 += 0.16f * num, 0.2f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(1L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.003f * num))
			{
				log.AddEvent(enemy.name + " also dropped a busted-up copy of... Wandoos 98? What is this bootlegged piece of crap?");
				itemInfo.makeLoot(66);
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.01f * num))
			{
				log.AddEvent(enemy.name + " also dropped Looty McLootFace! What a cool guy!");
				itemInfo.makeLoot(67);
			}
			if (character.inventory.itemList.itemDropped[172])
			{
				value = Random.value;
				num2 = 0f;
				if (value < (num2 += 0.01f * num))
				{
					log.AddEvent(enemy.name + " also dropped a bright yellow key! It rages incoherently at you as you pick it up.");
					itemInfo.makeLoot(172);
				}
			}
			else
			{
				log.AddEvent(enemy.name + " also dropped a bright yellow key! It rages incoherently at you as you pick it up.");
				itemInfo.makeLoot(172);
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.4f * num))
			{
				log.AddEvent(enemy.name + " also dropped a forest pendant!");
				log.AddEvent("WHY ARE THESE FREAKIN' EVERYWHERE??!!");
				itemInfo.makeLevelledLoot(53, 2);
			}
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.01f * num))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(434, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(3))
		{
			dropMacguffin(enemy.name, 201, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone5Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 8);
		float num2 = character.lootFactor();
		float num3 = 0f;
		character.lootState = Random.state;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(10000f)) + " gold! Sweet!");
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.015f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(3) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(16) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(29) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.06f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(2) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(15) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(28) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(16000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.09f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(2L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.4f * num2))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(68) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(69) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(70) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(71) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(72) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(73) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(74) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(53, 3) + " Dear god no! GO AWAY!!!");
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if ((double)value < (double)num3 * 0.008 * (double)num2)
			{
				log.AddEvent(enemy.name + "also dropped a busted copy of Wandoos!");
				itemInfo.makeLevelledLoot(66, 0);
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.007f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(435, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(4))
		{
			dropMacguffin(enemy.name, 202, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 283 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(283).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone6Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.bigBoss1)
		{
			return;
		}
		Random.state = character.lootState;
		_ = Random.value;
		float num = character.lootFactor();
		int num2 = Random.Range(1, 6);
		float num3 = 0f;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(250000f)) + " gold! Sweet!");
		long num4 = 0L;
		num4 = ((character.adventure.titan1Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp(character.adventureController.boss1Exp()) : character.addExp((float)character.adventureController.boss1Exp() * 1.5f));
		long num5 = character.addAP(character.adventureController.boss1AP());
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num4) + " EXP and " + num5 + " AP!", 3);
		itemInfo.makeTitanLoot(102);
		log.AddEvent("As the giant, pissed-off chef crumples, you see something fall out of his front pocket. It's a number! I wonder if you can make the number go up?");
		switch (num2)
		{
		case 1:
			itemInfo.makeTitanLevelledLoot(78, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a Chef's Hat!");
			break;
		case 2:
			itemInfo.makeTitanLevelledLoot(79, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a Chef's Apron!");
			break;
		case 3:
			itemInfo.makeTitanLevelledLoot(80, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a Chef's... um, chef's don't really have special pants do they? Screw it, you get regular pants.");
			break;
		case 4:
			itemInfo.makeTitanLevelledLoot(81, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped some special non-slip kitchen shoes! Cool I guess?");
			break;
		case 5:
			itemInfo.makeTitanLevelledLoot(82, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a Bloody Cleaver!");
			break;
		}
		num2 = Random.Range(1, 6);
		float value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.5f * num))
		{
			switch (num2)
			{
			case 1:
				itemInfo.makeTitanLevelledLoot(78, Random.Range(0, 3) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Chef's Hat!");
				break;
			case 2:
				itemInfo.makeTitanLevelledLoot(79, Random.Range(0, 3) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Chef's Apron!");
				break;
			case 3:
				itemInfo.makeTitanLevelledLoot(80, Random.Range(0, 3) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Chef's... um, chef's don't really have special pants do they? Screw it, you get regular pants.");
				break;
			case 4:
				itemInfo.makeTitanLevelledLoot(81, Random.Range(0, 3) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped some special non-slip kitchen shoes! Cool I guess?");
				break;
			case 5:
				itemInfo.makeTitanLevelledLoot(82, Random.Range(0, 3) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Bloody Cleaver!");
				break;
			}
		}
		float value2 = Random.value;
		num3 = 0f;
		if (value2 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(78, Random.Range(0, 5) + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value3 = Random.value;
		num3 = 0f;
		if (value3 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(79, Random.Range(0, 5) + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value4 = Random.value;
		num3 = 0f;
		if (value4 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(80, Random.Range(0, 5) + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value5 = Random.value;
		num3 = 0f;
		if (value5 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(81, Random.Range(0, 5) + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value6 = Random.value;
		num3 = 0f;
		if (value6 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(82, Random.Range(0, 5) + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value7 = Random.value;
		num3 = 0f;
		if (value7 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " also dropped a Sausage Necklace! That's really weird.");
			itemInfo.makeTitanLevelledLoot(83, Random.Range(0, 5) + titanLevelBonus());
		}
		float value8 = Random.value;
		num3 = 0f;
		if (value8 < (num3 += 0.15f * num))
		{
			log.AddEvent(enemy.name + " also dropped a Raw Slab of Meat! Sure, that can be used as an accessory I guess.");
			itemInfo.makeTitanLevelledLoot(84, Random.Range(0, 5) + titanLevelBonus());
		}
		float value9 = Random.value;
		num3 = 0f;
		if (value9 < (num3 += 0.1f * num))
		{
			itemInfo.makeTitanLevelledLoot(53, 20);
			log.AddEvent(enemy.name + " dropped a forest pendant! Why god why!");
		}
		float value10 = Random.value;
		num3 = 0f;
		if (value10 < (num3 += 0.2f * num))
		{
			itemInfo.makeTitanLevelledLoot(66, Random.Range(2, 5) + titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a slightly less busted copy of Wandoos 98!");
		}
		else
		{
			itemInfo.makeTitanLevelledLoot(66, 1);
			log.AddEvent(enemy.name + " dropped a busted copy of Wandoos 98!");
		}
		character.lootState = Random.state;
	}

	public void zone7Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 7);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(30000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.15f, num3 += 0.03f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(3) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(16) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(29) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.15f, num3 += 0.03f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(4) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(17) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(30) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(40000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.1f * num2, 0.16f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(2L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.3f * num2))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(85) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(86) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(87) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(88) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(89) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(90) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(91) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if ((double)value < (double)num3 * 0.012 * (double)num2)
			{
				log.AddEvent(enemy.name + "also dropped a busted copy of Wandoos!");
				itemInfo.makeLevelledLoot(66, 0);
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.005f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(436, 1) + itemInfo.endRemark());
		}
		if (character.adventure.titan10questStarted && enemy.name == "SUNDAE (BOSS)")
		{
			num3 = 0f;
			value = Random.value;
			if ((double)value < 0.18)
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(368, 1) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent("You spot the pickle ice cream but it melts in the hot sun before you can grab it! Unlucky.");
			}
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(5))
		{
			dropMacguffin(enemy.name, 203, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone8Drop(Enemy enemy)
	{
		if (enemy.enemyType == enemyType.bigBoss2)
		{
			Random.state = character.lootState;
			_ = Random.value;
			float num = character.lootFactor();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(400000f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan2Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp(character.adventureController.boss2Exp()) : character.addExp((float)character.adventureController.boss2Exp() * 1.5f));
			long num4 = character.addAP(character.adventureController.boss2AP());
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP and " + num4 + " AP!", 3);
			itemInfo.makeTitanLevelledLoot(92, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a giant Seed!");
			itemInfo.makeTitanLevelledLoot(4, titanLevelBonus());
			itemInfo.makeTitanLevelledLoot(17, titanLevelBonus());
			itemInfo.makeTitanLevelledLoot(30, titanLevelBonus());
			log.AddEvent(enemy.name + " dropped a Power, Toughness, and Special Boost 10!");
			float value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.1f * num))
			{
				itemInfo.makeTitanLevelledLoot(4, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped an Power Boost 10!");
			}
			float value2 = Random.value;
			num2 = 0f;
			if (value2 < (num2 += 0.08f * num))
			{
				itemInfo.makeTitanLevelledLoot(5, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped an Power Boost 20!");
			}
			float value3 = Random.value;
			num2 = 0f;
			if (value3 < (num2 += 0.05f * num))
			{
				itemInfo.makeTitanLevelledLoot(6, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped an Power Boost 50! Dayum!");
			}
			float value4 = Random.value;
			num2 = 0f;
			if (value4 < (num2 += 0.05f * num))
			{
				itemInfo.makeTitanLevelledLoot(7, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Power Boost 100! WOAH.");
			}
			float value5 = Random.value;
			num2 = 0f;
			if (value5 < (num2 += 0.1f * num))
			{
				itemInfo.makeTitanLevelledLoot(17, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Toughness Boost 10!");
			}
			float value6 = Random.value;
			num2 = 0f;
			if (value6 < (num2 += 0.08f * num))
			{
				itemInfo.makeTitanLevelledLoot(18, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Toughness Boost 20!");
			}
			float value7 = Random.value;
			num2 = 0f;
			if (value7 < (num2 += 0.05f * num))
			{
				itemInfo.makeTitanLevelledLoot(19, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Toughness Boost 50! Dayum!");
			}
			float value8 = Random.value;
			num2 = 0f;
			if (value8 < (num2 += 0.05f * num))
			{
				itemInfo.makeTitanLevelledLoot(20, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Toughness Boost 100! WOAH.");
			}
			float value9 = Random.value;
			num2 = 0f;
			if (value9 < (num2 += 0.1f * num))
			{
				itemInfo.makeTitanLevelledLoot(30, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Special Boost 10!");
			}
			float value10 = Random.value;
			num2 = 0f;
			if (value10 < (num2 += 0.08f * num))
			{
				itemInfo.makeTitanLevelledLoot(31, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Special Boost 20!");
			}
			float value11 = Random.value;
			num2 = 0f;
			if (value11 < (num2 += 0.08f * num))
			{
				itemInfo.makeTitanLevelledLoot(32, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Special Boost 50! Dayum!");
			}
			float value12 = Random.value;
			num2 = 0f;
			if (value12 < (num2 += 0.05f * num))
			{
				itemInfo.makeTitanLevelledLoot(33, titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a Special Boost 100! WOAH.");
			}
			float value13 = Random.value;
			num2 = 0f;
			if (value13 < (num2 += 0.01f * num))
			{
				itemInfo.makeTitanLevelledLoot(93, 5 + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a mysterious vial of liquid. Looks legit.");
			}
			float value14 = Random.value;
			num2 = 0f;
			if (value14 < (num2 += 0.1f * num))
			{
				itemInfo.makeTitanLevelledLoot(53, 50 + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a forest pendant! NOT THIS AGAIN!!");
			}
			float value15 = Random.value;
			num2 = 0f;
			if (value15 < (num2 += 0.2f * num))
			{
				itemInfo.makeTitanLevelledLoot(66, Random.Range(4, 8) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a... hey, a pretty decent copy of Wandoos 98!");
			}
			else
			{
				itemInfo.makeTitanLevelledLoot(66, Random.Range(3, 8) + titanLevelBonus());
				log.AddEvent(enemy.name + " dropped a busted up copy of Wandoos 98!");
			}
			character.lootState = Random.state;
			checkTreeSecret();
		}
	}

	public void zone9Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 7);
		float num2 = character.lootFactor();
		float num3 = 0f;
		character.lootState = Random.state;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(65000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.15f, num3 += 0.07f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(4) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(17) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(30) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.15f, num3 += 0.07f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(5) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(18) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(31) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(90000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.05f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(3L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.32f * num2))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(95) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(96) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(97) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(98) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(99) + "!");
					log.AddEvent("If you've played Anti-Idle, you know the power a triangle has. Be careful!");
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(100) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(101) + itemInfo.endRemark());
					break;
				}
			}
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && enemy.name == "KING CIRCLE (BOSS)")
			{
				if (character.adventure.kingCircleWhacked)
				{
					log.AddEvent("Hey genius, <b>King Circle</b> has already been crossed off the Death Note!");
					log.AddEvent("Now you're just whacking off for fun.");
				}
				else
				{
					character.adventure.kingCircleWhacked = true;
					log.AddEvent("Usually the mafia stays out of political circles...");
					log.AddEvent("Guess the Square Kingdom paid up enough to make them forget.");
					log.AddEvent("<b>King Circle</b> has been crossed off the Death Note!");
				}
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.005f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(437, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(6))
		{
			dropMacguffin(enemy.name, 204, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 279 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(279).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone10Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 7);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(100000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.2f, num3 += 0.06f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(4) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(17) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(30) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.2f, num3 += 0.06f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(5) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(18) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(31) + itemInfo.endRemark());
					break;
				}
			}
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && enemy.name == "")
			{
				if (character.adventure.emptyNameWhacked)
				{
					log.AddEvent("Hey genius, <b>' '</b> has already been crossed off the Death Note!");
					log.AddEvent("Now you're just whacking off for fun.");
				}
				else
				{
					character.adventure.emptyNameWhacked = true;
					log.AddEvent("You're not sure how to cross out a name like this, but you find a way.");
					log.AddEvent("<b>' '</b> has been crossed off the Death Note!");
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(140000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.03f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(5L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.3f * num2))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(103) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(104) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(105) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(106) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(107) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(108) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(109) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (enemy.name == "MYSTERIOUS FIGURE (BOSS)" && value < (num3 += 0.0015f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(110, 4) + "! Lucky you!");
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.002f * num2))
			{
				log.AddEvent(enemy.name + "also dropped a busted copy of Wandoos!");
				itemInfo.makeLevelledLoot(66, 0);
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.0045f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(438, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(7))
		{
			dropMacguffin(enemy.name, 205, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone11Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.bigBoss3)
		{
			return;
		}
		Random.state = character.lootState;
		_ = Random.value;
		float num = character.lootFactor();
		int num2 = Random.Range(1, 6);
		float num3 = 0f;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(300000f)) + " gold! Sweet!");
		long num4 = 0L;
		num4 = ((character.adventure.titan3Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp(character.adventureController.boss3Exp()) : character.addExp((float)character.adventureController.boss3Exp() * 1.5f));
		long num5 = character.addAP(character.adventureController.boss3AP());
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num4) + " EXP and " + num5 + " AP!", 3);
		switch (num2)
		{
		case 1:
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(111, titanLevelBonus()) + itemInfo.endRemark());
			break;
		case 2:
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(112, titanLevelBonus()) + itemInfo.endRemark());
			break;
		case 3:
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(113, titanLevelBonus()) + itemInfo.endRemark());
			break;
		case 4:
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(114, titanLevelBonus()) + itemInfo.endRemark());
			break;
		case 5:
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(115, titanLevelBonus()) + itemInfo.endRemark());
			break;
		}
		float value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.6f * num))
		{
			switch (Random.Range(1, 6))
			{
			case 1:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(111, 1 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 2:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(112, 1 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 3:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(113, 1 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 4:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(114, 1 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 5:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(115, 1 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			}
		}
		float value2 = Random.value;
		num3 = 0f;
		if (value2 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(111, 2 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value3 = Random.value;
		num3 = 0f;
		if (value3 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(112, 2 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value4 = Random.value;
		num3 = 0f;
		if (value4 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(113, 2 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value5 = Random.value;
		num3 = 0f;
		if (value5 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(114, 2 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value6 = Random.value;
		num3 = 0f;
		if (value6 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(115, 2 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value7 = Random.value;
		num3 = 0f;
		if (value7 < (num3 += 0.25f * num))
		{
			switch (Random.Range(1, 3))
			{
			case 1:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(116, 2 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 2:
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(117, 2 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			}
		}
		float value8 = Random.value;
		num3 = 0f;
		if (value8 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(76, 1 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value9 = Random.value;
		num3 = 0f;
		if (value9 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(33, titanLevelBonus()) + itemInfo.endRemark());
		}
		float value10 = Random.value;
		num3 = 0f;
		if (value10 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(20, titanLevelBonus()) + itemInfo.endRemark());
		}
		float value11 = Random.value;
		num3 = 0f;
		if (value11 < (num3 += 0.1f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(7, titanLevelBonus()) + itemInfo.endRemark());
		}
		float value12 = Random.value;
		num3 = 0f;
		if (value12 < (num3 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(118, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		character.lootState = Random.state;
		log.AddEvent(" You notice a slip of paper in Jake's pocket! You snatch it out of his pocket, it's yours now!");
		itemInfo.makeTitanLevelledLoot(197, titanLevelBonus());
		checkJakeSecret();
	}

	public void zone12Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(180000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.25f, num3 += 0.03f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(5) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(18) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(31) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.25f, num3 += 0.03f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(6) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(19) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(32) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(240000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.1f, num3 += 0.01f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(10L) + " EXP! Holy crap!", 3);
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.2f * num2))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(122) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(123) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(124) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(125) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(126) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.0015f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(127, 4) + "! Lucky you!");
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.0025f * num2))
			{
				log.AddEvent(enemy.name + "also dropped a busted copy of Wandoos!");
				itemInfo.makeLevelledLoot(66, 1);
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.004f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(439, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(8))
		{
			dropMacguffin(enemy.name, 206, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 282 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(282).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone13Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(220000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.15f, num3 += 0.011f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(6) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(19) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(32) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.15f, num3 += 0.011f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(7) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(20) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(33) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(290000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.005f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(15L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < (num3 += 0.08f * num2))
			{
				switch (num)
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(130) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(131) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(132) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(133) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(134) + itemInfo.endRemark());
					break;
				}
				if (character.inventory.itemList.itemDropped[338] && character.inventory.head.id == 130 && character.inventory.chest.id == 131 && character.inventory.legs.id == 132 && character.inventory.boots.id == 133 && character.inventory.weapon.id == 134)
				{
					itemInfo.makeLevelledLoot(339, 100);
					log.AddEvent("As Wahwee's Machine explodes into wobbly energy balls, something metal launches at you! ");
					log.AddEvent("It comes to a stop at your feet, and you pick it up. You have found the Buster of the Exile!");
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.01f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(76) + "! Lucky you!");
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.002f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(440, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(9))
		{
			dropMacguffin(enemy.name, 207, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 287 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(287).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone14Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.bigBoss4)
		{
			return;
		}
		character.challenges.blindChallengeUnlocked = true;
		Random.state = character.lootState;
		float value = Random.value;
		float num = character.lootFactor();
		float num2 = 0f;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(500000f)) + " gold! Sweet!");
		long num3 = 0L;
		num3 = ((character.adventure.titan4Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp(character.adventureController.boss4Exp()) : character.addExp((float)character.adventureController.boss4Exp() * 1.5f));
		long num4 = character.addAP(character.adventureController.boss4AP());
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + "EXP and " + num4 + " AP!", 3);
		log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(141, titanLevelBonus()) + "! Ewwwwwwwwwwwwwww!");
		if (!character.inventory.itemList.itemDropped[136])
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(136, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		if (value < (num2 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(136, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(137, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(138, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(139, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.02f * num))
		{
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(140, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		value = Random.value;
		num2 = 0f;
		if (value < (num2 += 0.02f * num))
		{
			itemInfo.makeTitanLoot(53);
			log.AddEvent(enemy.name + " dropped the best loot drop of all! :D ");
		}
		if (character.inventory.itemList.uugRingComplete)
		{
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.001f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(149, 4 + titanLevelBonus()) + "! Sexy! ;)");
			}
		}
		character.lootState = Random.state;
		checkUUGSecret();
	}

	public void zone15Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(220000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.25f, num3 += 0.0035f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(6) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(19) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(32) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.25f, num3 += 0.0035f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(7) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(20) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(33) + itemInfo.endRemark());
					break;
				}
			}
			if (character.adventure.titan8questStarted && !character.adventure.titan8Unlocked && enemy.name == "Rob Boss")
			{
				if (character.adventure.robBossWhacked)
				{
					log.AddEvent("Hey genius, <b>Rob Boss</b> has already been crossed off the Death Note!");
					log.AddEvent("Now you're just whacking off for fun.");
				}
				else
				{
					character.adventure.robBossWhacked = true;
					log.AddEvent("After you whack Rob Boss, you tamper with the crime scene to make it look like...");
					log.AddEvent("A happy little accident.");
					log.AddEvent("<b>Rob Boss</b> has been crossed off the Death Note!");
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(400000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.002f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(20L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < (num3 += 0.01f * num2))
			{
				switch (num)
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(143, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(144, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(145, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(146, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(147, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.0002f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(148, 5) + "! Lucky you!");
			}
			value = Random.value;
			num3 = 0f;
			if (value < (num3 += 0.006f * num2))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(76, 1) + "! Lucky you!");
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < (num3 += 0.0002f * num2))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(441, 1) + itemInfo.endRemark());
		}
		if (character.adventure.titan10questStarted && enemy.name == "ORANGE TOUPEE WITH FISTS (BOSS)")
		{
			num3 = 0f;
			value = Random.value;
			if ((double)value < 0.36)
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(367, 1) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent("You spot the steak but it gets Thanos-snapped away before you can catch it. Damn!");
			}
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(10))
		{
			dropMacguffin(enemy.name, 208, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 285 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(285).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone16Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.waldo1 && enemy.enemyType != enemyType.waldo2 && enemy.enemyType != enemyType.waldo3 && enemy.enemyType != enemyType.waldo4 && enemy.enemyType != enemyType.bigBoss5)
		{
			return;
		}
		if (enemy.enemyType == enemyType.waldo1)
		{
			character.adventure.waldoDefeats = 1;
			log.AddEvent("As you get the upper hand in the fight, Walderp throws down a smoke bomb and disappears!");
			log.AddEvent("'YOU'LL NEVER FIND ME!!' He screams, dodging in and out of the various menus that make up this game. Sigh.");
			log.AddEvent("Guess you'll have to go hunt down this annoying asshole. But he could be anywhere...");
		}
		else if (enemy.enemyType == enemyType.waldo2)
		{
			character.adventure.waldoDefeats = 2;
			log.AddEvent("Just as you move in for the final blow, Walderp throws down a smoke bomb and disappears! Again!");
			log.AddEvent("YOU'LL NEVER FIND ME!!' he screeches maniacally. 'AND THIS TIME I MEAN IT!");
		}
		else if (enemy.enemyType == enemyType.waldo3)
		{
			character.adventure.waldoDefeats = 3;
			log.AddEvent("Once again, Walderp throws down a smoke bomb and disappears! ");
			log.AddEvent("STOP FOLLOWING ME!!' he shrieks. 'I COULD ONLY AFFORD A 4-PACK OF THESE SMOKE BOMBS!'");
			log.AddEvent("AHA! If you play his stupid game enough times, he won't be able to run away!");
		}
		else if (enemy.enemyType == enemyType.waldo4)
		{
			character.adventure.waldoDefeats = 4;
			log.AddEvent("For the last time Walderp throws down a smoke bomb and disappears! ");
			log.AddEvent("YOU LEAVE ME WITH NO CHOICE! IF YOU COME AGAIN I'll... I'll... run out of ways to stop you :c.'");
		}
		else
		{
			if (enemy.enemyType != enemyType.bigBoss5)
			{
				return;
			}
			character.adventure.waldoDefeats = 4;
			character.adventure.boss5Kills++;
			Random.state = character.lootState;
			float value = Random.value;
			float num = character.lootFactor();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1000000f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan5Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp(character.adventureController.boss5Exp()) : character.addExp((float)character.adventureController.boss5Exp() * 1.5f));
			long num4 = character.addAP(character.adventureController.boss5AP());
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP and " + num4 + " AP!", 3);
			if (value < 0.01f)
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(159, titanLevelBonus()) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(154, 10 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(150, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(151, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(152, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(153, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				value = Random.value;
				num2 = 0f;
				if (value < 0.01f)
				{
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(159, titanLevelBonus()) + itemInfo.endRemark());
				}
				else
				{
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(154, 10 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(163, 20 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(155, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(156, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(157, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(158, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.005f * num))
			{
				log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(76, 50 + titanLevelBonus()) + itemInfo.endRemark());
			}
			if (character.inventory.itemList.waldoComplete)
			{
				value = Random.value;
				num2 = 0f;
				if (value < (num2 += 0.0001f * num))
				{
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(160, 10 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (character.inventory.itemList.antiWaldoComplete)
			{
				value = Random.value;
				num2 = 0f;
				if (value < (num2 += 0.0001f * num))
				{
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(161, 10 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			character.lootState = Random.state;
		}
	}

	public void zone17Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(220000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.2f, num3 += 0.001f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(7) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(20) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(33) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.2f, num3 += 0.001f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(8) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(21) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(34) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 6E-05f * num2, 0.05f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(164, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(165, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(166, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(167, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(168, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(500000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.0005f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(25L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 0.00018f * num2, 0.15f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(164, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(165, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(166, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(167, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(168, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.0005f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(67, 10) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-05f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 5) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.0001f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(94, 1) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 5E-05f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(163, 3) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 1.2E-05f * num2, 0.03f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(442, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(11))
		{
			dropMacguffin(enemy.name, 209, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone18Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactor();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(280000f)) + " gold! Sweet!");
			if (value < Mathf.Min(0.2f, num3 += 0.00012f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(8) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(21) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(34) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(0.2f, num3 += 0.00012f * num2))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(9) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(22) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(35) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.04f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(173, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(174, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(175, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(176, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(177, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(600000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.0003f * num2, 0.1f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 9E-05f * num2, 0.1f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(173, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(174, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(175, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(176, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(177, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 7E-05f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(94, 5) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(163, 8) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 7E-06f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 8) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (character.inventory.itemList.stealthComplete && value < Mathf.Min(num3 += 1E-06f * num2, 0.005f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(178, 5) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 6E-06f * num2, 0.02f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(443, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(12))
		{
			dropMacguffin(enemy.name, 210, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone19Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.guardian && enemy.enemyType != enemyType.bigBoss6V1 && enemy.enemyType != enemyType.bigBoss6V2 && enemy.enemyType != enemyType.bigBoss6V3 && enemy.enemyType != enemyType.bigBoss6V4)
		{
			return;
		}
		if (enemy.enemyType == enemyType.guardian)
		{
			itemInfo.makeLevelledLoot(179, 100);
			log.AddEvent("The Skeleton Guardian lets out a small sigh as it collapses to dust. What on earth was that thing??");
			log.AddEvent("You see a small curled note left behind in the dust and fish it out.");
		}
		else
		{
			if (enemy.enemyType != enemyType.bigBoss6V1 && enemy.enemyType != enemyType.bigBoss6V2 && enemy.enemyType != enemyType.bigBoss6V3 && enemy.enemyType != enemyType.bigBoss6V4)
			{
				return;
			}
			character.adventure.boss6Kills++;
			Random.state = character.lootState;
			_ = Random.value;
			float num = character.lootFactor();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5000000f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan6Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss6Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss6Exp() * 1.5f * higherVFactor(enemy.enemyType)));
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
			if (character.wishes.wishes[73].level > 0)
			{
				long num4 = (long)((float)character.adventureController.boss6QP() * higherVFactor(enemy.enemyType));
				character.beastQuest.quirkPoints += num4;
				log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
			}
			character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss6PP() * higherVFactor(enemy.enemyType)));
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(292, 4 + titanLevelBonus()) + itemInfo.endRemark());
			float value = Random.value;
			num2 = 0f;
			if (value < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(184, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value2 = Random.value;
			num2 = 0f;
			if (value2 < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(185, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value3 = Random.value;
			num2 = 0f;
			if (value3 < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(186, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value4 = Random.value;
			num2 = 0f;
			if (value4 < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(187, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value5 = Random.value;
			num2 = 0f;
			if (value5 < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(188, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value6 = Random.value;
			num2 = 0f;
			if (value6 < (num2 += 0.0005f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(142, 1 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value7 = Random.value;
			num2 = 0f;
			if (value7 < (num2 += 0.0002f * num))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(189, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			if (enemy.enemyType == enemyType.bigBoss6V2 || enemy.enemyType == enemyType.bigBoss6V3 || enemy.enemyType == enemyType.bigBoss6V4)
			{
				float value8 = Random.value;
				num2 = 0f;
				if (value8 < (num2 += 5E-05f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(190, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value9 = Random.value;
				num2 = 0f;
				if (value9 < (num2 += 2E-05f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(191, 1 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss6V3 || enemy.enemyType == enemyType.bigBoss6V4)
			{
				float value10 = Random.value;
				num2 = 0f;
				if (value10 < (num2 += 1E-05f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(192, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value11 = Random.value;
				num2 = 0f;
				if (value11 < (num2 += 5E-06f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(193, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss6V4)
			{
				float value12 = Random.value;
				num2 = 0f;
				if (value12 < (num2 += 2E-06f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(194, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value13 = Random.value;
				num2 = 0f;
				if (value13 < (num2 += 1E-06f * num))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(195, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			character.lootState = Random.state;
		}
	}

	public void zone20Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(600000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.00055f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(8) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(21) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(34) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.00055f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(9) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(22) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(35) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 0.00018f * num2, 0.08f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(221, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(222, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(223, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(224, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(225, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(900000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.0002f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 0.00055f * num2, 0.12f))
			{
				switch (Random.Range(0, 5))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(221, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(222, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(223, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(224, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(225, 1) + itemInfo.endRemark());
					break;
				}
			}
			if (character.inventory.itemList.chocoComplete)
			{
				value = Random.value;
				num3 = 0f;
				if (value < Mathf.Min(num3 += 0.00018f * num2, 0.12f))
				{
					switch (Random.Range(0, 2))
					{
					case 0:
						log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(226, 1) + itemInfo.endRemark());
						break;
					case 1:
						log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(227, 1) + itemInfo.endRemark());
						break;
					}
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.001f + 1E-09f * num2, 0.01f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 0) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 8E-05f * num2, 0.016f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(444, 1) + itemInfo.endRemark());
		}
		if (character.adventure.titan10questStarted && enemy.name == "Screaming Chocolate Fish")
		{
			num3 = 0f;
			value = Random.value;
			if ((double)value < 0.48)
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(369, 1) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent("You spot the surstromming but the smell makes you barf all over it! Yuck!");
				log.AddEvent("This actually improves the smell, so now it can't be used. :c");
			}
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(13) && character.inventory.itemList.chocoComplete)
		{
			dropMacguffin(enemy.name, 228, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 280 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(280).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone21Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(280000000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.00012f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(8) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(21) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(34) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.00012f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(9) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(22) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(35) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 7E-05f * num2, 0.08f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(213, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(214, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(215, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(216, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(217, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(218, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(219, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(600000000f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.0001f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 0.00021f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(213, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(214, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(215, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(216, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(217, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(218, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(219, 1) + itemInfo.endRemark());
					break;
				}
			}
			if (character.inventory.itemList.edgyBootsComplete)
			{
				value = Random.value;
				num3 = 0f;
				if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.12f))
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(220, 1) + itemInfo.endRemark());
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.0015f + 1E-10f * num2, 0.015f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 1) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 2E-05f * num2, 0.011f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(445, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(14))
		{
			dropMacguffin(enemy.name, 211, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 284 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(284).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone22Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+09f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 0.0001f * num2, 0.08f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(9) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(22) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(35) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.0001f * num2, 0.06f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(10) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(23) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(36) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.08f))
			{
				switch (Random.Range(0, 6))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(231, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(232, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(233, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(234, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(235, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(236, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5E+09f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 0.0001f * num2, 0.12f))
			{
				switch (Random.Range(0, 6))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(231, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(232, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(233, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(234, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(235, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(236, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 0.0015f + 2E-11f * num2, 0.02f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 2) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 1.2E-05f * num2, 0.013f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(446, 1) + itemInfo.endRemark());
		}
		if (character.adventure.titan10questStarted && enemy.name == "Barry, the Beer Fairy")
		{
			num3 = 0f;
			value = Random.value;
			if ((double)value < 0.3)
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(370, 1) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent("You grab the Jar of Marmite but trip! The jar smashes against the wall.");
				log.AddEvent("Now the souls of the damned have escaped from within and it's unusable :c");
			}
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(15))
		{
			dropMacguffin(enemy.name, 250, 0);
			ac.globalKillCounter = 0L;
		}
		if (character.settings.beastOn && character.beastQuest.inQuest && character.beastQuest.questID == 286 && !character.beastQuest.idleMode)
		{
			num3 = 0f;
			value = Random.value;
			if (value < character.beastQuestController.questDropChance())
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLoot(286).Substring(40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone23Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.boss7Guardian && enemy.enemyType != enemyType.bigBoss7V1 && enemy.enemyType != enemyType.bigBoss7V2 && enemy.enemyType != enemyType.bigBoss7V3 && enemy.enemyType != enemyType.bigBoss7V4)
		{
			return;
		}
		if (enemy.enemyType == enemyType.boss7Guardian)
		{
			character.adventure.titan7questStarted = true;
			character.tooltip.showOverrideTooltip("With the Greasy Nerd's mom dispatched, you head down to the basement to confront the Titan. But dammit - the door's locked with a 5 letter combination lock! You hear the nerd sneer from the other side of the door: 'Only the biggest NGU fans can find my secret passcode scattered in the beautifully crafted LORE!'", 10f);
		}
		else
		{
			if (enemy.enemyType != enemyType.bigBoss7V1 && enemy.enemyType != enemyType.bigBoss7V2 && enemy.enemyType != enemyType.bigBoss7V3 && enemy.enemyType != enemyType.bigBoss7V4)
			{
				return;
			}
			character.adventure.boss7Kills++;
			Random.state = character.lootState;
			_ = Random.value;
			float num = character.lootFactorRooted();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+10f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan7Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss7Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss7Exp() * 1.5f * higherVFactor(enemy.enemyType)));
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
			character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss7PP() * higherVFactor(enemy.enemyType)));
			if (character.wishes.wishes[74].level > 0)
			{
				long num4 = (long)((float)character.adventureController.boss7QP() * higherVFactor(enemy.enemyType));
				character.beastQuest.quirkPoints += num4;
				log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
			}
			switch (Random.Range(1, 8))
			{
			case 1:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(237, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 2:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(238, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 3:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(239, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 4:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(240, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 5:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(241, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 6:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(242, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			case 7:
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(243, 4 + titanLevelBonus()) + itemInfo.endRemark());
				break;
			}
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(294, 1 + titanLevelBonus()) + itemInfo.endRemark());
			float value = Random.value;
			num2 = 0f;
			if (value < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(237, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value2 = Random.value;
			num2 = 0f;
			if (value2 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(238, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value3 = Random.value;
			num2 = 0f;
			if (value3 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(239, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value4 = Random.value;
			num2 = 0f;
			if (value4 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(240, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value5 = Random.value;
			num2 = 0f;
			if (value5 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(241, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value6 = Random.value;
			num2 = 0f;
			if (value6 < Mathf.Min(num2 += 0.00023f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(242, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value7 = Random.value;
			num2 = 0f;
			if (value7 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(243, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value8 = Random.value;
			num2 = 0f;
			if (value8 < Mathf.Min(num2 += 0.00035f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(170, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			dropRandomMacguffin(enemy.name, titanLevelBonus());
			if (enemy.enemyType == enemyType.bigBoss7V2 || enemy.enemyType == enemyType.bigBoss7V3 || enemy.enemyType == enemyType.bigBoss7V4)
			{
				float value9 = Random.value;
				num2 = 0f;
				if (value9 < Mathf.Min(num2 += 0.00027f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(244, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value10 = Random.value;
				num2 = 0f;
				if (value10 < Mathf.Min(num2 += 0.00027f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(245, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss7V3 || enemy.enemyType == enemyType.bigBoss7V4)
			{
				float value11 = Random.value;
				num2 = 0f;
				if (value11 < Mathf.Min(num2 += 0.00022f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(246, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value12 = Random.value;
				num2 = 0f;
				if (value12 < Mathf.Min(num2 += 0.00022f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(247, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss7V4)
			{
				float value13 = Random.value;
				num2 = 0f;
				if (value13 < Mathf.Min(num2 += 0.00017f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(248, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value14 = Random.value;
				num2 = 0f;
				if (value14 < Mathf.Min(num2 += 0.00017f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(249, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (character.achievements.achievementComplete[145])
			{
				dropMacguffin(enemy.name, 291, 0);
			}
			character.lootState = Random.state;
		}
	}

	public void zone24Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5E+09f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 5E-05f * num2, 0.07f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(10) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(23) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(36) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 5E-05f * num2, 0.07f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.5E-05f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(251, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(252, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(253, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(254, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(255, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(256, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(257, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 5E-05f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(251, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(252, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(253, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(254, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(255, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(256, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(257, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 5E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 5) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.2E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 25) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 6E-06f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(447, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(17))
		{
			dropMacguffin(enemy.name, 289, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone25Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.08f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(10) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(23) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(36) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.08f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.1E-05f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(258, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(259, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(260, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(261, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(262, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(263, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(264, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 3E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(30L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 3.5E-05f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(258, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(259, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(260, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(261, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(262, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(263, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(264, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 3.5E-05f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 10) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-05f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 68) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 1.4E-05f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(448, 1) + itemInfo.endRemark());
		}
		if (character.achievements.achievementComplete[145] && ac.globalKillCounter > macGuffinThreshold(18))
		{
			dropMacguffin(enemy.name, 290, 0);
			ac.globalKillCounter = 0L;
		}
		character.lootState = Random.state;
	}

	public void zone26Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.boss8Guardian && enemy.enemyType != enemyType.bigBoss8V1 && enemy.enemyType != enemyType.bigBoss8V2 && enemy.enemyType != enemyType.bigBoss8V3 && enemy.enemyType != enemyType.bigBoss8V4)
		{
			return;
		}
		if (enemy.enemyType == enemyType.boss8Guardian)
		{
			if (character.adventure.emptyNameWhacked && character.adventure.icarusWhacked && character.adventure.kingCircleWhacked && character.adventure.robBossWhacked && character.adventure.skeletonWhacked)
			{
				character.adventure.titan8Unlocked = true;
				log.AddEvent("You defeated the Consigliere, and this time for good. You pull out the Death Note he gave you.");
				log.AddEvent("You add his name to the bottom of the list and toss it on his body, and enter the doors to see THE GODMOTHER.");
				return;
			}
			character.adventure.titan8questStarted = true;
			itemInfo.makeTitanLevelledLoot(288, 100);
			log.AddEvent("The Consigliere wipes a trickle of blood from his mouth before delivering a massive haymaker!");
			log.AddEvent("You feel the air burst out of your lungs as you slam against the wall on the other side of the room.");
			log.AddEvent("He walks over and hands you a small piece of paper. 'Alright tough guy, you want an audience with the");
			log.AddEvent("Godmother? Go whack off all the guys on this list, then we'll talk.");
		}
		else
		{
			if (enemy.enemyType != enemyType.bigBoss8V1 && enemy.enemyType != enemyType.bigBoss8V2 && enemy.enemyType != enemyType.bigBoss8V3 && enemy.enemyType != enemyType.bigBoss8V4)
			{
				return;
			}
			character.adventure.boss8Kills++;
			Random.state = character.lootState;
			_ = Random.value;
			float num = character.lootFactorRooted();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+11f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan8Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss8Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss8Exp() * 1.5f * higherVFactor(enemy.enemyType)));
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
			character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss8PP() * higherVFactor(enemy.enemyType)));
			if (character.wishes.wishes[40].level > 0)
			{
				long num4 = (long)((float)character.adventureController.boss8QP() * higherVFactor(enemy.enemyType));
				character.beastQuest.quirkPoints += num4;
				log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
			}
			float value = Random.value;
			num2 = 0f;
			if (value < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(265, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value2 = Random.value;
			num2 = 0f;
			if (value2 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(266, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value3 = Random.value;
			num2 = 0f;
			if (value3 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(267, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value4 = Random.value;
			num2 = 0f;
			if (value4 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(268, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value5 = Random.value;
			num2 = 0f;
			if (value5 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(269, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value6 = Random.value;
			num2 = 0f;
			if (value6 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(270, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value7 = Random.value;
			num2 = 0f;
			if (value7 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(271, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value8 = Random.value;
			num2 = 0f;
			if (value8 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(170, 8 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value9 = Random.value;
			num2 = 0f;
			if (value9 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(169, 8) + itemInfo.endRemark());
			}
			dropRandomMacguffin(enemy.name, titanLevelBonus());
			if (character.achievements.achievementComplete[145])
			{
				float value10 = Random.value;
				num2 = 0f;
				if (value10 < Mathf.Min(num2 += 0.0001f * num, 0.25f))
				{
					dropMacguffin(enemy.name, 298, 0);
				}
			}
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(343, 1) + itemInfo.endRemark());
			if (enemy.enemyType == enemyType.bigBoss8V2 || enemy.enemyType == enemyType.bigBoss8V3 || enemy.enemyType == enemyType.bigBoss8V4)
			{
				float value11 = Random.value;
				num2 = 0f;
				if (value11 < Mathf.Min(num2 += 7.5E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(272, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value12 = Random.value;
				num2 = 0f;
				if (value12 < Mathf.Min(num2 += 7.5E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(273, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				if (character.achievements.achievementComplete[145])
				{
					float value13 = Random.value;
					num2 = 0f;
					if (value13 < Mathf.Min(num2 += 7.5E-05f * num, 0.25f))
					{
						dropMacguffin(enemy.name, 299, 0);
					}
				}
			}
			if (enemy.enemyType == enemyType.bigBoss8V3 || enemy.enemyType == enemyType.bigBoss8V4)
			{
				float value14 = Random.value;
				num2 = 0f;
				if (value14 < Mathf.Min(num2 += 6E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(274, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value15 = Random.value;
				num2 = 0f;
				if (value15 < Mathf.Min(num2 += 6E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(275, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				if (character.achievements.achievementComplete[145])
				{
					float value16 = Random.value;
					num2 = 0f;
					if (value16 < Mathf.Min(num2 += 6E-05f * num, 0.25f))
					{
						dropMacguffin(enemy.name, 300, 0);
					}
				}
			}
			if (enemy.enemyType == enemyType.bigBoss8V4)
			{
				float value17 = Random.value;
				num2 = 0f;
				if (value17 < Mathf.Min(num2 += 4.5E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(276, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value18 = Random.value;
				num2 = 0f;
				if (value18 < Mathf.Min(num2 += 4.5E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(277, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			character.lootState = Random.state;
		}
	}

	public void zone27Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 2.2E-05f * num2, 0.09f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(10) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(23) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(36) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.2E-05f * num2, 0.09f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 9E-06f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(301, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(302, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(303, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(304, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(305, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(306, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(307, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 2.2E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(35L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 2.5E-05f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(301, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(302, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(303, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(304, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(305, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(306, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(307, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.5E-05f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 10) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 6E-06f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 68) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 4E-06f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(449, 1) + itemInfo.endRemark());
		}
		character.lootState = Random.state;
	}

	public void zone28Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(6E+10f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 7E-06f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(308, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(309, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(310, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(311, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(312, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(313, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(314, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+11f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.8E-06f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(40L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 2.1E-05f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(308, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(309, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(310, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(311, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(312, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(313, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(314, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.1E-05f * num2, 0.08f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 10) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 7E-06f * num2, 0.08f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 68) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 2.5E-06f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(450, 1) + itemInfo.endRemark());
		}
		character.lootState = Random.state;
	}

	public void zone29Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+11f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.5E-05f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.5E-05f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 5.5E-06f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(315, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(316, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(317, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(318, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(319, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(320, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(321, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.3E+11f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.03f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.addExp(45L) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.12f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(315, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(316, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(317, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(318, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(319, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(320, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(321, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.8E-05f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(142, 10) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 5.5E-06f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(128, 68) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 2E-06f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(451, 1) + itemInfo.endRemark());
		}
		if (character.adventure.titan10questStarted && enemy.name == "The Annoying Fan")
		{
			num3 = 0f;
			value = Random.value;
			if ((double)value < 0.3)
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(371, 1) + itemInfo.endRemark());
			}
			else
			{
				log.AddEvent("As you grab the pineapple pizza, the ghost of the Annoying Fan rises!");
				log.AddEvent("They flip you off and turn the pizza incorporeal! God dammit!!!");
			}
		}
		character.lootState = Random.state;
	}

	public void zone30Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.boss9Guardian && enemy.enemyType != enemyType.bigBoss9V1 && enemy.enemyType != enemyType.bigBoss9V2 && enemy.enemyType != enemyType.bigBoss9V3 && enemy.enemyType != enemyType.bigBoss9V4)
		{
			return;
		}
		if (enemy.enemyType == enemyType.boss9Guardian)
		{
			if (character.inventory.weapon.id == 335)
			{
				itemInfo.makeTitanLevelledLoot(336, 100);
				log.AddEvent("You slap the Priest's bald head with the Dark Seal before he can escape!");
				log.AddEvent("With an unholy wail he crumbles into dust.... which begins to form into something!");
				log.AddEvent("It's a grotesque face! You put on some gloves and gingerly add it to your inventory. ");
			}
			else
			{
				itemInfo.makeTitanLevelledLoot(335, 100);
				log.AddEvent("The Priest disappears in a beam of black light, leaving a dark seal on the ground!");
				log.AddEvent("You grab it before the wind takes it away. There seems to be some writing on the back...");
			}
		}
		else
		{
			if (enemy.enemyType != enemyType.bigBoss9V1 && enemy.enemyType != enemyType.bigBoss9V2 && enemy.enemyType != enemyType.bigBoss9V3 && enemy.enemyType != enemyType.bigBoss9V4)
			{
				return;
			}
			character.adventure.boss9Kills++;
			Random.state = character.lootState;
			_ = Random.value;
			float num = character.lootFactorRooted();
			float num2 = 0f;
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+12f)) + " gold! Sweet!");
			long num3 = 0L;
			num3 = ((character.adventure.titan9Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss9Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss9Exp() * 1.5f * higherVFactor(enemy.enemyType)));
			log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
			character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss9PP() * higherVFactor(enemy.enemyType)));
			if (character.wishes.wishes[41].level > 0)
			{
				long num4 = (long)((float)character.adventureController.boss9QP() * higherVFactor(enemy.enemyType));
				character.beastQuest.quirkPoints += num4;
				log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
			}
			log.AddEvent(enemy.name + " dropped " + itemInfo.makeTitanLevelledLoot(391, 4 + titanLevelBonus()) + itemInfo.endRemark());
			float value = Random.value;
			num2 = 0f;
			if (value < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(322, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value2 = Random.value;
			num2 = 0f;
			if (value2 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(323, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value3 = Random.value;
			num2 = 0f;
			if (value3 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(324, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value4 = Random.value;
			num2 = 0f;
			if (value4 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(325, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value5 = Random.value;
			num2 = 0f;
			if (value5 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(326, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value6 = Random.value;
			num2 = 0f;
			if (value6 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(327, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value7 = Random.value;
			num2 = 0f;
			if (value7 < Mathf.Min(num2 += 2E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(328, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value8 = Random.value;
			num2 = 0f;
			if (value8 < Mathf.Min(num2 += 1.5E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(170, 50 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value9 = Random.value;
			num2 = 0f;
			if (value9 < Mathf.Min(num2 += 1.5E-05f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(169, 50 + titanLevelBonus()) + itemInfo.endRemark());
			}
			dropRandomMacguffin(enemy.name, titanLevelBonus());
			if (enemy.enemyType == enemyType.bigBoss9V2 || enemy.enemyType == enemyType.bigBoss9V3 || enemy.enemyType == enemyType.bigBoss9V4)
			{
				float value10 = Random.value;
				num2 = 0f;
				if (value10 < Mathf.Min(num2 += 1E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(329, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value11 = Random.value;
				num2 = 0f;
				if (value11 < Mathf.Min(num2 += 1E-05f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(330, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss9V3 || enemy.enemyType == enemyType.bigBoss9V4)
			{
				float value12 = Random.value;
				num2 = 0f;
				if (value12 < Mathf.Min(num2 += 6E-06f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(331, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value13 = Random.value;
				num2 = 0f;
				if (value13 < Mathf.Min(num2 += 6E-06f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(332, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (enemy.enemyType == enemyType.bigBoss9V4)
			{
				if (!character.settings.exilev4Defeated)
				{
					character.settings.exilev4Defeated = true;
				}
				float value14 = Random.value;
				num2 = 0f;
				if (value14 < Mathf.Min(num2 += 4E-06f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(333, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
				float value15 = Random.value;
				num2 = 0f;
				if (value15 < Mathf.Min(num2 += 4E-06f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(334, 4 + titanLevelBonus()) + itemInfo.endRemark());
				}
			}
			if (character.inventory.itemList.exileComplete)
			{
				float value16 = Random.value;
				num2 = 0f;
				if (value16 < 0.02f)
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(341, 100) + itemInfo.endRemark());
				}
			}
			if (character.inventory.itemList.exileComplete)
			{
				float value17 = Random.value;
				num2 = 0f;
				if (value17 < 0.25f)
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(336, 100) + itemInfo.endRemark());
				}
			}
			if (character.adventure.titan9SpecialReward)
			{
				float value18 = Random.value;
				num2 = 0f;
				if (value18 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(342, 0) + itemInfo.endRemark());
				}
			}
			character.lootState = Random.state;
		}
	}

	public void zone31Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2E+11f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 6E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(11) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(24) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(37) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 6E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped  " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 2E-07f * num2, 0.05f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(345, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(346, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(347, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(348, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(349, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(350, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(351, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3E+11f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 6E-07f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(450L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 6E-07f * num2, 0.15f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(345, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(346, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(347, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(348, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(349, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(350, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(351, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.2E-06f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(170, 1) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(169, 1) + itemInfo.endRemark());
			}
		}
		value = Random.value;
		num3 = 0f;
		if (value < Mathf.Min(num3 += 8E-08f * num2, 0.017f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(452, 1) + itemInfo.endRemark());
		}
		character.lootState = Random.state;
	}

	public void zone32Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.5E+14f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 4E-07f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-07f * num2, 0.1f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.5E-07f * num2, 0.05f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(352, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(353, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(354, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(355, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(356, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(357, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(358, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.7E+14f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 4.5E-07f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(500L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 4.5E-07f * num2, 0.15f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(352, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(353, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(354, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(355, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(356, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(357, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(358, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4.5E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(229, 1) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.5E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(230, 1) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone33Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3E+14f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 2.5E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.5E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1E-07f * num2, 0.04f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(359, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(360, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(361, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(362, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(363, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(364, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(365, 1) + itemInfo.endRemark());
					break;
				}
			}
			if (character.inventory.itemList.westernComplete)
			{
				value = Random.value;
				num3 = 0f;
				if (value < Mathf.Min(num3 += 2E-08f * num2, 0.12f))
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(366, 1) + itemInfo.endRemark());
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(4E+14f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 3E-07f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(600L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 3E-07f * num2, 0.15f))
			{
				switch (Random.Range(0, 7))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(359, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(360, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(361, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(362, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(363, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(364, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(365, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-06f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(229, 1) + itemInfo.endRemark());
			}
			if (character.inventory.itemList.westernComplete)
			{
				value = Random.value;
				num3 = 0f;
				if (value < Mathf.Min(num3 += 6E-08f * num2, 0.12f))
				{
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(366, 1) + itemInfo.endRemark());
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 3E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(230, 1) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone34Drop(Enemy enemy)
	{
		if ((enemy.enemyType != enemyType.boss10Guardian && enemy.enemyType != enemyType.bigBoss10V1 && enemy.enemyType != enemyType.bigBoss10V2 && enemy.enemyType != enemyType.bigBoss10V3 && enemy.enemyType != enemyType.bigBoss10V4) || enemy.enemyType == enemyType.boss10Guardian || (enemy.enemyType != enemyType.bigBoss10V1 && enemy.enemyType != enemyType.bigBoss10V2 && enemy.enemyType != enemyType.bigBoss10V3 && enemy.enemyType != enemyType.bigBoss10V4))
		{
			return;
		}
		character.adventure.boss10Kills++;
		Random.state = character.lootState;
		_ = Random.value;
		float num = character.lootFactorRooted();
		float num2 = 0f;
		character.cooking.unlocked = true;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2E+15f)) + " gold! Sweet!");
		long num3 = 0L;
		num3 = ((character.adventure.titan10Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss10Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss10Exp() * 1.5f * higherVFactor(enemy.enemyType)));
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
		character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss10PP() * higherVFactor(enemy.enemyType)));
		if (character.wishes.wishes[100].level > 0)
		{
			long num4 = (long)((float)character.adventureController.boss10QP() * higherVFactor(enemy.enemyType));
			character.beastQuest.quirkPoints += num4;
			log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
		}
		float value = Random.value;
		num2 = 0f;
		if (value < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(373, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value2 = Random.value;
		num2 = 0f;
		if (value2 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(374, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value3 = Random.value;
		num2 = 0f;
		if (value3 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(375, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value4 = Random.value;
		num2 = 0f;
		if (value4 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(376, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value5 = Random.value;
		num2 = 0f;
		if (value5 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(377, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value6 = Random.value;
		num2 = 0f;
		if (value6 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(378, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value7 = Random.value;
		num2 = 0f;
		if (value7 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(379, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value8 = Random.value;
		num2 = 0f;
		if (value8 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(380, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value9 = Random.value;
		num2 = 0f;
		if (value9 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(229, 50 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value10 = Random.value;
		num2 = 0f;
		if (value10 < Mathf.Min(num2 += 1E-06f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(230, 50 + titanLevelBonus()) + itemInfo.endRemark());
		}
		dropRandomMacguffin(enemy.name, titanLevelBonus());
		if (enemy.enemyType == enemyType.bigBoss10V2 || enemy.enemyType == enemyType.bigBoss10V3 || enemy.enemyType == enemyType.bigBoss10V4)
		{
			float value11 = Random.value;
			num2 = 0f;
			if (value11 < Mathf.Min(num2 += 6E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(381, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value12 = Random.value;
			num2 = 0f;
			if (value12 < Mathf.Min(num2 += 6E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(382, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		if (enemy.enemyType == enemyType.bigBoss10V3 || enemy.enemyType == enemyType.bigBoss10V4)
		{
			float value13 = Random.value;
			num2 = 0f;
			if (value13 < Mathf.Min(num2 += 4E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(383, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value14 = Random.value;
			num2 = 0f;
			if (value14 < Mathf.Min(num2 += 4E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(384, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		if (enemy.enemyType == enemyType.bigBoss10V4)
		{
			float value15 = Random.value;
			num2 = 0f;
			if (value15 < Mathf.Min(num2 += 3E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(385, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value16 = Random.value;
			num2 = 0f;
			if (value16 < Mathf.Min(num2 += 3E-07f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(386, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone35Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.2E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(12) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(25) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(38) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-07f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.04f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(392, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(393, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(394, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(395, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(396, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(397, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(398, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(399, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.2E-07f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(800L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.2E-07f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(392, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(393, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(394, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(395, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(396, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(397, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(398, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(399, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(229, 5) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.2E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(230, 5) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone36Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2.5E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 6E-08f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 6E-08f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 2.5E-08f * num2, 0.04f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(400, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(401, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(402, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(403, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(404, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(405, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(406, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(407, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(3E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 8E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1000L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 8E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(400, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(401, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(402, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(403, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(404, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(405, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(406, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(407, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.5E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(229, 15) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 8E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(230, 15) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone37Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.15f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.6E-08f * num2, 0.04f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(408, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(409, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(410, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(411, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(412, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(413, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(414, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(415, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(6E+15f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 5E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1200L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 5E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(408, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(409, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(410, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(411, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(412, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(413, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(414, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(415, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.6E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(229, 40) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 6E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(230, 40) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone38Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.bigBoss11V1 && enemy.enemyType != enemyType.bigBoss11V2 && enemy.enemyType != enemyType.bigBoss11V3 && enemy.enemyType != enemyType.bigBoss11V4)
		{
			return;
		}
		character.adventure.boss11Kills++;
		Random.state = character.lootState;
		_ = Random.value;
		float num = character.lootFactorRooted();
		float num2 = 0f;
		character.cooking.ingredients[6].unlocked = true;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2E+16f)) + " gold! Sweet!");
		long num3 = 0L;
		num3 = ((character.adventure.titan11Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss11Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss11Exp() * 1.5f * higherVFactor(enemy.enemyType)));
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
		character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss11PP() * higherVFactor(enemy.enemyType)));
		if (character.wishes.wishes[187].level > 0)
		{
			long num4 = (long)((float)character.adventureController.boss11QP() * higherVFactor(enemy.enemyType));
			character.beastQuest.quirkPoints += num4;
			log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
		}
		float value = Random.value;
		num2 = 0f;
		if (value < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(416, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value2 = Random.value;
		num2 = 0f;
		if (value2 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(417, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value3 = Random.value;
		num2 = 0f;
		if (value3 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(418, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value4 = Random.value;
		num2 = 0f;
		if (value4 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(419, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value5 = Random.value;
		num2 = 0f;
		if (value5 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(420, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value6 = Random.value;
		num2 = 0f;
		if (value6 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(421, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value7 = Random.value;
		num2 = 0f;
		if (value7 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(422, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value8 = Random.value;
		num2 = 0f;
		if (value8 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(423, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value9 = Random.value;
		num2 = 0f;
		if (value9 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(295, 10 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value10 = Random.value;
		num2 = 0f;
		if (value10 < Mathf.Min(num2 += 1E-07f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(296, 10 + titanLevelBonus()) + itemInfo.endRemark());
		}
		dropRandomMacguffin(enemy.name, titanLevelBonus());
		if (enemy.enemyType == enemyType.bigBoss11V2 || enemy.enemyType == enemyType.bigBoss11V3 || enemy.enemyType == enemyType.bigBoss11V4)
		{
			float value11 = Random.value;
			num2 = 0f;
			if (value11 < Mathf.Min(num2 += 6.5E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(424, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value12 = Random.value;
			num2 = 0f;
			if (value12 < Mathf.Min(num2 += 6.5E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(425, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		if (enemy.enemyType == enemyType.bigBoss11V3 || enemy.enemyType == enemyType.bigBoss11V4)
		{
			float value13 = Random.value;
			num2 = 0f;
			if (value13 < Mathf.Min(num2 += 4E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(426, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value14 = Random.value;
			num2 = 0f;
			if (value14 < Mathf.Min(num2 += 4E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(427, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		if (enemy.enemyType == enemyType.bigBoss11V4)
		{
			float value15 = Random.value;
			num2 = 0f;
			if (value15 < Mathf.Min(num2 += 3E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(428, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value16 = Random.value;
			num2 = 0f;
			if (value16 < Mathf.Min(num2 += 3E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(429, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone39Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 2.5E-08f * num2, 0.16f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.5E-08f * num2, 0.16f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1E-08f * num2, 0.04f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(453, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(454, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(455, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(456, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(457, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(458, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(459, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(460, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.2E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1200L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 3E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(453, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(454, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(455, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(456, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(457, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(458, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(459, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(460, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-07f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(295, 2) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(296, 2) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone40Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 2E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 8E-09f * num2, 0.05f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(496, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(497, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(498, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(499, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(500, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(501, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(502, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(503, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(2.4E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 3.3E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1200L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 2.4E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(496, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(497, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(498, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(499, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(500, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(501, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(502, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(503, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 8E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(295, 4) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 3E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(296, 4) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone41Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(4E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.6E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.6E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 6E-09f * num2, 0.05f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(461, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(462, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(463, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(464, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(465, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(466, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(467, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(468, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(5E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.8E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1200L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.8E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(461, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(462, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(463, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(464, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(465, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(466, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(467, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(468, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 6E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(295, 8) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 2.4E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(296, 8) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone42Drop(Enemy enemy)
	{
		if (enemy.enemyType != enemyType.bigBoss12V1 && enemy.enemyType != enemyType.bigBoss12V2 && enemy.enemyType != enemyType.bigBoss12V3 && enemy.enemyType != enemyType.bigBoss12V4)
		{
			return;
		}
		character.adventure.boss12Kills++;
		Random.state = character.lootState;
		_ = Random.value;
		float num = character.lootFactorRooted();
		float num2 = 0f;
		character.cooking.ingredients[7].unlocked = true;
		log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.5E+17f)) + " gold! Sweet!");
		long num3 = 0L;
		num3 = ((character.adventure.titan12Kills >= character.adventure.itopod.perkLevel[34] * 3) ? character.addExp((float)character.adventureController.boss12Exp() * higherVFactor(enemy.enemyType)) : character.addExp((float)character.adventureController.boss12Exp() * 1.5f * higherVFactor(enemy.enemyType)));
		log.AddEvent("Holy crap, you just beat " + enemy.name + "! You gained " + character.display(num3) + " EXP!", 3);
		character.adventureController.itopod.addProgress((long)((float)character.adventureController.boss12PP() * higherVFactor(enemy.enemyType)));
		if (character.wishes.wishes[204].level > 0)
		{
			long num4 = (long)((float)character.adventureController.boss12QP() * higherVFactor(enemy.enemyType));
			character.beastQuest.quirkPoints += num4;
			log.AddEvent("You gained " + num4 + " QP thanks to your wish!");
		}
		float value = Random.value;
		num2 = 0f;
		if (value < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(469, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value2 = Random.value;
		num2 = 0f;
		if (value2 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(470, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value3 = Random.value;
		num2 = 0f;
		if (value3 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(471, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value4 = Random.value;
		num2 = 0f;
		if (value4 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(472, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value5 = Random.value;
		num2 = 0f;
		if (value5 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(473, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value6 = Random.value;
		num2 = 0f;
		if (value6 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(474, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value7 = Random.value;
		num2 = 0f;
		if (value7 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(475, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value8 = Random.value;
		num2 = 0f;
		if (value8 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(476, 4 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value9 = Random.value;
		num2 = 0f;
		if (value9 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(388, 50 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value10 = Random.value;
		num2 = 0f;
		if (value10 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(enemy.name + " also dropped " + itemInfo.makeTitanLevelledLoot(389, 50 + titanLevelBonus()) + itemInfo.endRemark());
		}
		float value11 = Random.value;
		num2 = 0f;
		if (value11 < Mathf.Min(num2 += 1.4E-08f * num, 0.25f))
		{
			log.AddEvent(itemInfo.makeTitanLevelledLoot(483, 100) + " NEARS.");
		}
		dropRandomMacguffin(enemy.name, titanLevelBonus());
		if (enemy.enemyType == enemyType.bigBoss12V2 || enemy.enemyType == enemyType.bigBoss12V3 || enemy.enemyType == enemyType.bigBoss12V4)
		{
			float value12 = Random.value;
			num2 = 0f;
			if (value12 < Mathf.Min(num2 += 1E-08f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(477, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value13 = Random.value;
			num2 = 0f;
			if (value13 < Mathf.Min(num2 += 1E-08f * num, 0.25f))
			{
				log.AddEvent(itemInfo.makeTitanLevelledLoot(489, 100) + " NEARS.");
			}
		}
		if (enemy.enemyType == enemyType.bigBoss12V3 || enemy.enemyType == enemyType.bigBoss12V4)
		{
			float value14 = Random.value;
			num2 = 0f;
			if (value14 < Mathf.Min(num2 += 8E-09f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(478, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value15 = Random.value;
			num2 = 0f;
			if (value15 < Mathf.Min(num2 += 8E-09f * num, 0.25f))
			{
				log.AddEvent(itemInfo.makeTitanLevelledLoot(493, 100) + " NEARS.");
			}
		}
		if (enemy.enemyType == enemyType.bigBoss12V4)
		{
			float value16 = Random.value;
			num2 = 0f;
			if (value16 < Mathf.Min(num2 += 6E-09f * num, 0.25f))
			{
				log.AddEvent(enemy.name + " dropped a " + itemInfo.makeTitanLevelledLoot(479, 4 + titanLevelBonus()) + itemInfo.endRemark());
			}
			float value17 = Random.value;
			num2 = 0f;
			if (value17 < Mathf.Min(num2 += 6E-09f * num, 0.25f))
			{
				log.AddEvent(itemInfo.makeTitanLevelledLoot(484, 100) + " NEARS.");
			}
		}
		character.lootState = Random.state;
	}

	public void zone43Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		float num2 = character.lootFactorRooted();
		float num3 = 0f;
		if (enemy.enemyType == enemyType.normal)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(8E+16f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1E-08f * num2, 0.17f))
			{
				switch (Random.Range(1, 4))
				{
				case 1:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(13) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(26) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " dropped " + itemInfo.makeLoot(39) + itemInfo.endRemark());
					break;
				}
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 4E-09f * num2, 0.05f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(507, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(508, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(509, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(510, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(511, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(512, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(513, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(514, 1) + itemInfo.endRemark());
					break;
				}
			}
		}
		else if (enemy.enemyType == enemyType.boss)
		{
			log.AddEvent(enemy.name + " dropped " + format.suffixFormat(goldDrop(1.6E+17f)) + " gold! Sweet!");
			if (value < Mathf.Min(num3 += 1.2E-08f * num2, 0.15f))
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(1200L)) + " EXP! Holy crap!", 3);
			}
			num3 = 0f;
			value = Random.value;
			if (value < Mathf.Min(num3 += 1.2E-08f * num2, 0.15f))
			{
				switch (Random.Range(0, 8))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(507, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(508, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(509, 1) + itemInfo.endRemark());
					break;
				case 3:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(510, 1) + itemInfo.endRemark());
					break;
				case 4:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(511, 1) + itemInfo.endRemark());
					break;
				case 5:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(512, 1) + itemInfo.endRemark());
					break;
				case 6:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(513, 1) + itemInfo.endRemark());
					break;
				case 7:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(514, 1) + itemInfo.endRemark());
					break;
				}
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 4E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(295, 16) + itemInfo.endRemark());
			}
			value = Random.value;
			num3 = 0f;
			if (value < Mathf.Min(num3 += 1.8E-08f * num2, 0.12f))
			{
				log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(296, 16) + itemInfo.endRemark());
			}
		}
		character.lootState = Random.state;
	}

	public void zone44Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		_ = Random.value;
		Random.Range(0, 5);
		character.lootFactorRooted();
		character.adventure.ratTitanDefeated = true;
		log.AddEvent("What a pathetic, rage filled creature. You wonder if there's a lesson");
		log.AddEvent("to be learned here.........nope. nothing. Kill all the rats you want!");
		character.lootState = Random.state;
	}

	public void zone45Drop(Enemy enemy)
	{
		Random.state = character.lootState;
		_ = Random.value;
		Random.Range(0, 5);
		character.lootFactorRooted();
		if (character.stats.rebirthNumber < 10000)
		{
			character.stats.rebirthNumber = 10000L;
		}
		character.adventure.finalTitanDefeated = true;
		log.AddEvent("With a final wailing curse, the Traitor disintegrates...");
		log.AddEvent("Leaving behind a small trinket. A dreadful sense of finality washes over you...");
		log.AddEvent("as if placing this item with 15 others, and clicking CTRL");
		log.AddEvent("might trigger an ENDING. to a game or something. Very Spooky.");
		itemInfo.makeLevelledLoot(495, 100);
		character.lootState = Random.state;
	}

	public void itopodDrop(Enemy enemy, int itopodLevel)
	{
		Random.state = character.lootState;
		float value = Random.value;
		int num = Random.Range(0, 5);
		int num2 = itopodTier(itopodLevel);
		int num3 = 1;
		if (num2 > 0)
		{
			num3 = Mathf.Min(num2, 24);
		}
		if (num3 < 1)
		{
			num3 = 1;
		}
		if (num3 >= 24)
		{
			num3 = 13;
		}
		else if (num3 >= 18)
		{
			num3 = 12;
		}
		else if (num3 >= 15)
		{
			num3 = 11;
		}
		else if (num3 > 10)
		{
			num3 = 10;
		}
		if (num3 > 13)
		{
			num3 = 10;
		}
		if (enemy.enemyType == enemyType.itopod)
		{
			character.adventure.itopod.enemiesKilled++;
			value = Random.value;
			if (value < 0.14f)
			{
				switch (Random.Range(0, 3))
				{
				case 0:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(num3, 1) + itemInfo.endRemark());
					break;
				case 1:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(13 + num3, 1) + itemInfo.endRemark());
					break;
				case 2:
					log.AddEvent(enemy.name + " also dropped " + itemInfo.makeLevelledLoot(26 + num3, 1) + itemInfo.endRemark());
					break;
				}
			}
			if (character.adventure.itopod.enemiesKilled % killsPerAP(num2) == 0)
			{
				character.arbitrary.curArbitraryPoints++;
				character.arbitrary.curLifetimePoints++;
				log.AddEvent(enemy.name + " also dropped 1 AP!");
			}
			if (character.adventure.itopod.enemiesKilled % killsPerEXP(num2) == 0 && num2 >= 1)
			{
				log.AddEvent(enemy.name + " also dropped " + character.display(character.addExp(itopodEXPAwarded(num2))) + " EXP! OMG!", 3);
			}
			value = Random.value;
			if (character.adventure.itopod.perkLevel[30] >= 1 && value < character.adventureController.itopod.effectPerLevel[30])
			{
				log.AddEvent(enemy.name + " also dropped some poop!");
				character.arbitrary.poop1Count++;
			}
			if (character.achievements.achievementComplete[145] && character.adventure.itopod.perkLevel[68] >= 1 && character.adventure.itopod.enemiesKilled % killsPerMacguffin() == 0)
			{
				dropRandomMacguffin(enemy.name, 0);
			}
		}
		character.lootState = Random.state;
		checkITOPODSecret();
		checkExileDrop();
		checkEndDrop();
	}

	public int killsPerAP(int tier)
	{
		return Mathf.Max(40 - tier, 20);
	}

	public int itopodEXPAwarded(int tier)
	{
		if (tier < 3)
		{
			return tier;
		}
		return (tier - 1) * (tier - 2) + 2;
	}

	public int killsPerEXP(int tier)
	{
		return Mathf.Max(40 - tier, 20);
	}

	public int itopodTier(int level)
	{
		if (level < 0)
		{
			return 0;
		}
		if (level >= 2000)
		{
			return 40;
		}
		return 1 + level / 50;
	}

	public int killsUntilAP(int level)
	{
		return killsPerAP(itopodTier(level)) - character.adventure.itopod.enemiesKilled % killsPerAP(itopodTier(level));
	}

	public int killsPerMacguffin()
	{
		int num = 5000;
		if (character.adventure.itopod.perkLevel[69] >= 1)
		{
			num = (int)((double)num * 0.8);
		}
		if (character.adventure.itopod.perkLevel[70] >= 1)
		{
			num = (int)((double)num * 0.75);
		}
		if (character.adventure.itopod.perkLevel[71] >= 1)
		{
			num = (int)((double)num * 0.75);
		}
		if (character.inventory.itemList.purpleHeartComplete)
		{
			num = (int)((double)num * 0.8);
		}
		return num;
	}

	public int killsUntilMacguffin()
	{
		return killsPerMacguffin() - character.adventure.itopod.enemiesKilled % killsPerMacguffin();
	}

	public void checkUUGSecret()
	{
		if (character.inventoryController.apathyCheck() == 69 && character.inventory.itemList.itemMaxxed[179])
		{
			character.itemInfo.makeLevelledLoot(180, 100);
			character.adventure.clue1Complete = true;
			log.AddEvent("As you deliver your final blow, UUG starts giggling uncontrollably at something...");
			log.AddEvent("He laughs so hard his fat rolls start jiggling - and a piece of paper slips out beneath! You snatch it up.");
		}
	}

	public void checkTreeSecret()
	{
		if (character.adventure.clue1Complete && character.inventory.weapon.id == 75)
		{
			character.itemInfo.makeLevelledLoot(181, 100);
			character.adventure.clue2Complete = true;
			log.AddEvent("Being defeated so embarrasingly, the Grand Corrupted Tree explodes!");
			log.AddEvent("You're showered with wood splinters - but amongst them, another clue appears!");
		}
	}

	public void checkJakeSecret()
	{
		if (!character.adventure.clue1Complete || !character.adventure.clue2Complete || character.inventory.head.id != 0 || character.inventory.chest.id != 0 || character.inventory.legs.id != 0 || character.inventory.boots.id != 0 || character.inventory.weapon.id != 0 || !character.inventoryController.checkforAccEquipped(118))
		{
			return;
		}
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.inventory.accs[i].id != 0 && character.inventory.accs[i].id != 118)
			{
				return;
			}
		}
		character.itemInfo.makeLevelledLoot(182, 100);
		log.AddEvent("Jake lets out a wail of terror as he disintegrates!");
		log.AddEvent("As his final act, his arm reaches out as it crumbles to dust, leaving you his business card - yet another clue!");
		character.adventure.clue3Complete = true;
	}

	public void checkNakedness()
	{
		if (character.inventory.head.id == 0 && character.inventory.chest.id == 0 && character.inventory.legs.id == 0 && character.inventory.boots.id == 0 && character.inventory.weapon.id == 0)
		{
			for (int i = 0; i < character.inventory.accs.Count; i++)
			{
				if (character.inventory.accs[i].id != 0)
				{
					ac.clue4Eligible = false;
					break;
				}
			}
		}
		else
		{
			ac.clue4Eligible = false;
		}
	}

	public void checkITOPODSecret()
	{
		if (character.adventure.clue1Complete && character.adventure.clue2Complete && character.adventure.clue3Complete)
		{
			checkNakedness();
			if (character.adventureController.itopodLevel == 100 && character.adventure.itopodStart == 0 && character.adventureController.itopodKillCount == 1 && ac.clue4Eligible)
			{
				character.itemInfo.makeLevelledLoot(183, 100);
				log.AddEvent("One of the Pissed Off Dudes disappears in a flash of smoke - leaving behind a final clue!");
				character.adventure.clue4Complete = true;
			}
		}
	}

	public void checkExileDrop()
	{
		if (character.inventory.itemList.itemDropped[336] && character.adventureController.itopodLevel >= 950 && character.adventureController.itopodLevel <= 999)
		{
			Random.state = character.lootState;
			float value = Random.value;
			float num = (float)(character.adventureController.itopodLevel - 949) * 0.0001f;
			if (value <= num)
			{
				log.AddEvent("The Pissed Off Dude Shimmers and disappers, leaving... *something* in it's place.");
				log.AddEvent("You found " + character.itemInfo.makeLevelledLoot(337, 100) + "!");
			}
			else if ((double)value < 0.1)
			{
				log.AddEvent("Something seemed different about that Pissed Off Dude...");
			}
			character.lootState = Random.state;
		}
	}

	public void checkEndDrop()
	{
		if (character.adventureController.itopodLevel >= 1450 && character.itemInfo.findIndexWithID(491) < 0)
		{
			Random.state = character.lootState;
			float value = Random.value;
			float num = (float)(character.adventureController.itopodLevel - 1449) * 5E-05f;
			if (value <= num)
			{
				log.AddEvent("The Pissed Off Dude glitches in and out horribly...");
				log.AddEvent("Suddenly it EXPLODES and leaves behind... " + character.itemInfo.makeLevelledLoot(491, 100) + ".");
			}
			else
			{
				log.AddEvent("The Pissed Off Dude glitches in and out horribly as it dies!");
				log.AddEvent("Something *BAD* is happening this high up the Tower!");
			}
			character.lootState = Random.state;
		}
	}

	public void dropMacguffin(string enemyName, int id, int startLevel)
	{
		if (itemInfo.type[id] == part.MacGuffin)
		{
			startLevel += macguffinBaseLevelBonus();
			startLevel = Mathf.FloorToInt((float)startLevel * macguffinDropLevelBonus());
			switch (id)
			{
			case 298:
				itemInfo.makeLevelledLoot(id, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Power Macguffin Fragment" + itemInfo.endRemark());
				break;
			case 299:
				itemInfo.makeLevelledLoot(id, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Cap Macguffin Fragment" + itemInfo.endRemark());
				break;
			case 300:
				itemInfo.makeLevelledLoot(id, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Bar Macguffin Fragment" + itemInfo.endRemark());
				break;
			default:
				log.AddEvent(enemyName + " also dropped " + itemInfo.makeLevelledLoot(id, startLevel) + itemInfo.endRemark());
				break;
			}
		}
	}

	public void dropRandomMacguffin(string enemyName, int startLevel)
	{
		List<int> list = new List<int>
		{
			198, 199, 200, 201, 202, 203, 204, 205, 206, 207,
			208
		};
		if (character.inventory.itemList.itemDropped[209])
		{
			list.Add(209);
		}
		if (character.inventory.itemList.itemDropped[210])
		{
			list.Add(210);
		}
		if (character.inventory.itemList.itemDropped[228])
		{
			list.Add(228);
		}
		if (character.inventory.itemList.itemDropped[211])
		{
			list.Add(211);
		}
		if (character.inventory.itemList.itemDropped[250])
		{
			list.Add(250);
		}
		if (character.inventory.itemList.itemDropped[289])
		{
			list.Add(289);
		}
		if (character.inventory.itemList.itemDropped[290])
		{
			list.Add(290);
		}
		if (character.inventory.itemList.itemDropped[291])
		{
			list.Add(291);
		}
		if (character.inventory.itemList.itemDropped[298])
		{
			list.Add(298);
		}
		if (character.inventory.itemList.itemDropped[299])
		{
			list.Add(299);
		}
		if (character.inventory.itemList.itemDropped[300])
		{
			list.Add(300);
		}
		int num = list[Random.Range(0, list.Count)];
		if (itemInfo.type[num] == part.MacGuffin)
		{
			startLevel += macguffinBaseLevelBonus();
			startLevel = Mathf.FloorToInt((float)startLevel * macguffinDropLevelBonus());
			switch (num)
			{
			case 298:
				itemInfo.makeLevelledLoot(num, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Power Macguffin Fragment" + itemInfo.endRemark());
				break;
			case 299:
				itemInfo.makeLevelledLoot(num, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Cap Macguffin Fragment" + itemInfo.endRemark());
				break;
			case 300:
				itemInfo.makeLevelledLoot(num, startLevel);
				log.AddEvent(enemyName + " also dropped " + character.res3.res3Name + " Bar Macguffin Fragment" + itemInfo.endRemark());
				break;
			default:
				log.AddEvent(enemyName + " also dropped " + itemInfo.makeLevelledLoot(num, startLevel) + itemInfo.endRemark());
				break;
			}
		}
	}

	public void dropRandomMacguffin(int startLevel)
	{
		List<int> list = new List<int>
		{
			198, 199, 200, 201, 202, 203, 204, 205, 206, 207,
			208
		};
		if (character.inventory.itemList.itemDropped[209])
		{
			list.Add(209);
		}
		if (character.inventory.itemList.itemDropped[210])
		{
			list.Add(210);
		}
		if (character.inventory.itemList.itemDropped[228])
		{
			list.Add(228);
		}
		if (character.inventory.itemList.itemDropped[211])
		{
			list.Add(211);
		}
		if (character.inventory.itemList.itemDropped[250])
		{
			list.Add(250);
		}
		if (character.inventory.itemList.itemDropped[289])
		{
			list.Add(289);
		}
		if (character.inventory.itemList.itemDropped[290])
		{
			list.Add(290);
		}
		if (character.inventory.itemList.itemDropped[291])
		{
			list.Add(291);
		}
		if (character.inventory.itemList.itemDropped[298])
		{
			list.Add(298);
		}
		if (character.inventory.itemList.itemDropped[299])
		{
			list.Add(299);
		}
		if (character.inventory.itemList.itemDropped[300])
		{
			list.Add(300);
		}
		int num = list[Random.Range(0, list.Count)];
		if (itemInfo.type[num] == part.MacGuffin)
		{
			startLevel += macguffinBaseLevelBonus();
			startLevel = Mathf.FloorToInt((float)startLevel * macguffinDropLevelBonus());
			itemInfo.makeLevelledLoot(num, startLevel);
		}
	}

	public int macguffinBaseLevelBonus()
	{
		float num = 0f;
		num += (float)character.adventure.itopod.perkLevel[65];
		if (character.inventory.itemList.nerdComplete)
		{
			num += 1f;
		}
		num += (float)character.wishesController.wishBaseMacGuffinLevels();
		return (int)num;
	}

	public float macguffinDropLevelBonus()
	{
		return 1f;
	}

	public float higherVFactor(enemyType type)
	{
		if (character.wishes.wishes[3].level >= 3)
		{
			switch (type)
			{
			case enemyType.bigBoss6V2:
				return 1.1f;
			case enemyType.bigBoss6V3:
				return 1.2f;
			case enemyType.bigBoss6V4:
				return 1.3f;
			case enemyType.bigBoss7V2:
				return 1.1f;
			case enemyType.bigBoss7V3:
				return 1.2f;
			case enemyType.bigBoss7V4:
				return 1.3f;
			case enemyType.bigBoss8V2:
				return 1.1f;
			case enemyType.bigBoss8V3:
				return 1.2f;
			case enemyType.bigBoss8V4:
				return 1.3f;
			case enemyType.bigBoss9V2:
				return 1.1f;
			case enemyType.bigBoss9V3:
				return 1.2f;
			case enemyType.bigBoss9V4:
				return 1.3f;
			case enemyType.bigBoss10V2:
				return 1.1f;
			case enemyType.bigBoss10V3:
				return 1.2f;
			case enemyType.bigBoss10V4:
				return 1.3f;
			case enemyType.bigBoss11V2:
				return 1.1f;
			case enemyType.bigBoss11V3:
				return 1.2f;
			case enemyType.bigBoss11V4:
				return 1.3f;
			case enemyType.bigBoss12V2:
				return 1.1f;
			case enemyType.bigBoss12V3:
				return 1.2f;
			case enemyType.bigBoss12V4:
				return 1.3f;
			default:
				return 1f;
			}
		}
		if (character.wishes.wishes[3].level == 2)
		{
			switch (type)
			{
			case enemyType.bigBoss6V2:
				return 1.1f;
			case enemyType.bigBoss6V3:
				return 1.2f;
			case enemyType.bigBoss6V4:
				return 1.2f;
			case enemyType.bigBoss7V2:
				return 1.1f;
			case enemyType.bigBoss7V3:
				return 1.2f;
			case enemyType.bigBoss7V4:
				return 1.2f;
			case enemyType.bigBoss8V2:
				return 1.1f;
			case enemyType.bigBoss8V3:
				return 1.2f;
			case enemyType.bigBoss8V4:
				return 1.2f;
			case enemyType.bigBoss9V2:
				return 1.1f;
			case enemyType.bigBoss9V3:
				return 1.2f;
			case enemyType.bigBoss9V4:
				return 1.2f;
			case enemyType.bigBoss10V2:
				return 1.1f;
			case enemyType.bigBoss10V3:
				return 1.2f;
			case enemyType.bigBoss10V4:
				return 1.2f;
			case enemyType.bigBoss11V2:
				return 1.1f;
			case enemyType.bigBoss11V3:
				return 1.2f;
			case enemyType.bigBoss11V4:
				return 1.2f;
			case enemyType.bigBoss12V2:
				return 1.1f;
			case enemyType.bigBoss12V3:
				return 1.2f;
			case enemyType.bigBoss12V4:
				return 1.2f;
			default:
				return 1f;
			}
		}
		if (character.wishes.wishes[3].level == 1)
		{
			switch (type)
			{
			case enemyType.bigBoss6V2:
				return 1.1f;
			case enemyType.bigBoss6V3:
				return 1.1f;
			case enemyType.bigBoss6V4:
				return 1.1f;
			case enemyType.bigBoss7V2:
				return 1.1f;
			case enemyType.bigBoss7V3:
				return 1.1f;
			case enemyType.bigBoss7V4:
				return 1.1f;
			case enemyType.bigBoss8V2:
				return 1.1f;
			case enemyType.bigBoss8V3:
				return 1.1f;
			case enemyType.bigBoss8V4:
				return 1.1f;
			case enemyType.bigBoss9V2:
				return 1.1f;
			case enemyType.bigBoss9V3:
				return 1.1f;
			case enemyType.bigBoss9V4:
				return 1.1f;
			case enemyType.bigBoss10V2:
				return 1.1f;
			case enemyType.bigBoss10V3:
				return 1.1f;
			case enemyType.bigBoss10V4:
				return 1.1f;
			case enemyType.bigBoss11V2:
				return 1.1f;
			case enemyType.bigBoss11V3:
				return 1.1f;
			case enemyType.bigBoss11V4:
				return 1.1f;
			case enemyType.bigBoss12V2:
				return 1.1f;
			case enemyType.bigBoss12V3:
				return 1.1f;
			case enemyType.bigBoss12V4:
				return 1.1f;
			default:
				return 1f;
			}
		}
		return 1f;
	}

	public void postDeathDrops(Enemy diedTo)
	{
		if (diedTo != null && (diedTo.enemyType == enemyType.bigBoss10V1 || diedTo.enemyType == enemyType.bigBoss10V2 || diedTo.enemyType == enemyType.bigBoss10V3 || diedTo.enemyType == enemyType.bigBoss10V4))
		{
			if (!character.adventure.titan10questStarted)
			{
				character.adventure.titan10questStarted = true;
			}
			if (character.itemInfo.findItemToDelete(387) == -1)
			{
				character.itemInfo.makeLoot(387);
				log.AddEvent("As you wake up in the Safe Zone, you feel a piece of paper stuck to your head.");
				log.AddEvent("You peel it off - it's a recipe of some sort...");
			}
		}
	}
}
