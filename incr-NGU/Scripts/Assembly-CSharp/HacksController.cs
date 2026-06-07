using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HacksController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public List<HackUIController> pods;

	public List<HackProperties> properties;

	public List<Sprite> hackIcons;

	public List<Color> barColors;

	public Image advanceCheckmark;

	public Text advanceText;

	public int curPage;

	private void Start()
	{
		InvokeRepeating("updateAllHacks", 0f, 0.02f);
		InvokeRepeating("checkExilePiece", 60f, 60f);
		initializePage();
	}

	public void refreshMenu()
	{
		if (character.menuID == 52)
		{
			for (int i = 0; i < pods.Count; i++)
			{
				pods[i].refresh();
				pods[i].updateBarColour();
			}
			updateCheckmark();
		}
	}

	public void checkExilePiece()
	{
		if (character.res3.res3On && character.hacks.hacks[13].res3 == character.totalCapRes3() - 1 && character.inventory.itemList.itemDropped[339])
		{
			character.itemInfo.makeLevelledLoot(340, 100);
			tooltip.showOverrideTooltip("The Greasy Nerd's eyes turn a glossy white, and he silently reaches into his fanny pack. He turns, and hands you the Antennae of the Exile! Gross, though...", 6f);
		}
	}

	public void updateCheckmark()
	{
		if (character.hacks.autoAdvance)
		{
			advanceCheckmark.gameObject.SetActive(value: true);
		}
		else
		{
			advanceCheckmark.gameObject.SetActive(value: false);
		}
		advanceText.text = "Advance " + character.res3.res3Name;
	}

	public void toggleAutoAdvance()
	{
		character.hacks.autoAdvance = !character.hacks.autoAdvance;
		updateCheckmark();
	}

	public void checkBarUpdate(int id)
	{
		if (character.menuID != 52)
		{
			return;
		}
		for (int i = 0; i < pods.Count; i++)
		{
			if (pods[i].id == id)
			{
				pods[i].updateBar();
				break;
			}
		}
	}

	public void checkTextUpdate(int id)
	{
		if (character.menuID != 52)
		{
			return;
		}
		for (int i = 0; i < pods.Count; i++)
		{
			if (pods[i].id == id)
			{
				pods[i].updateText();
				break;
			}
		}
	}

	public void reset()
	{
		for (int i = 0; i < character.hacks.hacks.Count; i++)
		{
			character.hacks.hacks[i].res3 = 0L;
		}
	}

	public float progressPerTick(int id)
	{
		if (id < 0 || id >= character.hacks.hacks.Count)
		{
			return 0f;
		}
		double num = (float)character.hacks.hacks[id].res3 * character.totalRes3Power() * totalHackSpeedBonus() / (properties[id].baseDivider * levelDivider(id));
		if (num >= 3.4028234663852886E+38)
		{
			return float.MaxValue;
		}
		if (num <= -3.4028234663852886E+38)
		{
			return 0f;
		}
		return (float)num;
	}

	public float progressPerTickCap(int id)
	{
		if (id < 0 || id >= character.hacks.hacks.Count)
		{
			return 0f;
		}
		double num = (float)character.totalCapRes3() * character.totalRes3Power() * totalHackSpeedBonus() / (properties[id].baseDivider * levelDivider(id));
		if (num >= 3.4028234663852886E+38)
		{
			return float.MaxValue;
		}
		if (num <= -3.4028234663852886E+38)
		{
			return 0f;
		}
		return (float)num;
	}

	public float levelDivider(int id)
	{
		double num = Math.Pow(1.0078, character.hacks.hacks[id].level) * (double)(character.hacks.hacks[id].level + 1);
		if (num > 3.4028234663852886E+38)
		{
			return float.MaxValue;
		}
		return (float)num;
	}

	public void addR3(int id, long amount)
	{
		if (id >= 0 && id < character.hacks.hacks.Count && amount >= 0)
		{
			if (hitTarget(id))
			{
				tooltip.showOverrideTooltip("This Hack has already reached its target, don't stick your " + character.res3.res3Name + " in there!", 2f);
			}
			else if (amount >= character.res3.idleRes3)
			{
				character.hacks.hacks[id].res3 += character.res3.idleRes3;
				character.res3.idleRes3 = 0L;
			}
			else
			{
				character.hacks.hacks[id].res3 += amount;
				character.res3.idleRes3 -= amount;
			}
		}
	}

	public void removeR3(int id, long amount)
	{
		if (id >= 0 && id < character.hacks.hacks.Count && amount >= 0)
		{
			if (amount >= character.hacks.hacks[id].res3)
			{
				character.res3.idleRes3 += character.hacks.hacks[id].res3;
				character.hacks.hacks[id].res3 = 0L;
			}
			else
			{
				character.res3.idleRes3 += amount;
				character.hacks.hacks[id].res3 -= amount;
			}
		}
	}

	public void removeAllR3()
	{
		for (int i = 0; i < character.hacks.hacks.Count; i++)
		{
			if (character.hacks.hacks[i].res3 > 0)
			{
				character.res3.idleRes3 += character.hacks.hacks[i].res3;
				character.hacks.hacks[i].res3 = 0L;
			}
		}
	}

	public bool endHackAvailable()
	{
		for (int i = 0; i < 15; i++)
		{
			if (character.hacks.hacks[i].level < hardCapLevel(i))
			{
				return false;
			}
		}
		return true;
	}

	public float endHackSpeed()
	{
		return 1E-07f;
	}

	public void updateAllHacks()
	{
		if (!character.hacks.hacksOn)
		{
			return;
		}
		for (int i = 0; i < character.hacks.hacks.Count; i++)
		{
			if (i == 15 && endHackAvailable() && character.hacks.hacks[15].level < 1)
			{
				character.hacks.hacks[i].progress += endHackSpeed();
				checkBarUpdate(i);
				if (character.hacks.hacks[i].progress >= 1f)
				{
					character.hacks.hacks[15].level++;
					character.hacks.hacks[i].progress = 0f;
					checkTextUpdate(i);
				}
			}
			else if (i == 15)
			{
				continue;
			}
			if (character.hacks.hacks[i].res3 <= 0)
			{
				continue;
			}
			float num = progressPerTick(i);
			character.hacks.hacks[i].progress += num;
			if (character.hacks.hacks[i].progress >= 1f)
			{
				character.hacks.hacks[i].progress = 0f;
				if (character.hacks.hacks[i].level < hardCapLevel(i))
				{
					character.hacks.hacks[i].level++;
					checkTextUpdate(i);
				}
				if (hitTarget(i))
				{
					autoAdvance(i);
				}
			}
			checkBarUpdate(i);
		}
	}

	public bool hitTarget(int hackID)
	{
		if (hackID < 0 || hackID >= character.hacks.hacks.Count)
		{
			return false;
		}
		if (character.hacks.hacks[hackID].target == -1)
		{
			return true;
		}
		if (character.hacks.hacks[hackID].target == 0L)
		{
			return false;
		}
		return character.hacks.hacks[hackID].level >= character.hacks.hacks[hackID].target;
	}

	public void autoAdvance(int hackID)
	{
		int count = character.hacks.hacks.Count;
		int num = 0;
		if (!character.hacks.autoAdvance)
		{
			long res = character.hacks.hacks[hackID].res3;
			character.res3.idleRes3 += res;
			character.hacks.hacks[hackID].res3 = 0L;
			checkTextUpdate(hackID);
			return;
		}
		while (num < count)
		{
			long res2 = character.hacks.hacks[hackID].res3;
			character.hacks.hacks[hackID].res3 = 0L;
			checkTextUpdate(hackID);
			hackID++;
			num++;
			if (hackID >= 15)
			{
				hackID = 0;
			}
			character.hacks.hacks[hackID].res3 += res2;
			checkTextUpdate(hackID);
			if (!hitTarget(hackID))
			{
				return;
			}
		}
		long res3 = character.hacks.hacks[hackID].res3;
		character.hacks.hacks[hackID].res3 = 0L;
		character.res3.idleRes3 += res3;
		checkTextUpdate(hackID);
	}

	public void changePage(int newPage)
	{
		if (newPage != curPage)
		{
			int num = newPage * pods.Count;
			for (int i = 0; i < pods.Count; i++)
			{
				pods[i].id = num;
				num++;
				pods[i].updateBarColour();
			}
			curPage = newPage;
			refreshMenu();
		}
	}

	public void initializePage()
	{
		int num = 0;
		for (int i = 0; i < pods.Count; i++)
		{
			pods[i].id = num;
			num++;
		}
		curPage = 0;
		refreshMenu();
	}

	public long hardCapLevel(int id)
	{
		long num = (long)(Math.Log(1E+38 / (double)properties[id].baseDivider, 1.0078) + 1.0);
		return (long)Math.Log(1E+38 / (double)properties[id].baseDivider / (double)num, 1.0078);
	}

	public void showTooltip(int id)
	{
		if (id < 0 || id >= character.hacks.hacks.Count)
		{
			return;
		}
		string text = "";
		if (id == 15)
		{
			text = "<b>" + properties[id].hackName + "\n" + properties[id].hackDesc + "</b>";
			if (character.hacks.hacks[id].level < 1)
			{
				text += "\n\nT4#s H$@k h(s n)t y+t r=&ch%d <b>THE END</b>";
				text = text + "\n<b>T*&e U@({l N;^t L:>'l: </b>" + (1f - character.hacks.hacks[id].progress) / endHackSpeed() / 50f + "s";
			}
			else
			{
				text += "\n\nT4#s H$@k h(s r=&ch%d <b>THE END</b>";
			}
			tooltip.showTooltip(text);
		}
		else
		{
			text = "<b>" + properties[id].hackName + "\n" + properties[id].hackDesc + "</b>";
			text = text + "\n\n<b>Current Effect: </b>" + (hackBonus(id) * 100f).ToString("###,##0.##") + "%";
			text = text + "\n<b>Next Level: </b>" + (hackBonus(id, 1) * 100f).ToString("###,##0.##") + "%";
			text = text + "\n<b>Time Until Next Level: </b>" + timeLeft(id);
			text = text + "\n\nThis Hack has reached <b>" + numMilestonesReached(id) + "</b> milestone(s).";
			text = text + "\n\nNext Milestone reached in <b>" + levelsToNextMilestone(id) + "</b> levels.";
			text = text + "\nMilestone Bonus: <b>" + properties[id].milestoneEffect * 100f + "</b>%";
			tooltip.showTooltip(text);
		}
	}

	public string timeLeft(int id)
	{
		if (id < 0 || id >= character.hacks.hacks.Count)
		{
			return "A Buggy Time. You should tell 4G about this!";
		}
		float num = 0f;
		if (progressPerTick(id) == 0f)
		{
			num = (1f - character.hacks.hacks[id].progress) / progressPerTickCap(id) / 50f;
			return NumberOutput.timeOutput(num) + " (with " + character.display(character.totalCapRes3()) + " " + character.res3.res3Name + ")";
		}
		num = (1f - character.hacks.hacks[id].progress) / progressPerTick(id) / 50f;
		return NumberOutput.timeOutput(num);
	}

	public float hackBonus(int id)
	{
		return hackBonus(id, 0);
	}

	public float hackBonus(int id, int offset)
	{
		if (id < 0 || id >= character.hacks.hacks.Count)
		{
			return 1f;
		}
		float num = 1f + (float)(character.hacks.hacks[id].level + offset) * properties[id].baseEffectPerLevel;
		int num2 = Mathf.FloorToInt((character.hacks.hacks[id].level + offset) / milestoneThreshold(id));
		if (num2 < 0)
		{
			num2 = 0;
		}
		return num * Mathf.Pow(properties[id].milestoneEffect, num2);
	}

	public long levelsToNextMilestone(int id)
	{
		if (id < 0 || id > character.hacks.hacks.Count)
		{
			return 0L;
		}
		return milestoneThreshold(id) - character.hacks.hacks[id].level % milestoneThreshold(id);
	}

	public long nextMilestoneTarget(int id)
	{
		if (id < 0 || id > character.hacks.hacks.Count)
		{
			return 0L;
		}
		if (character.hacks.hacks[id].level >= hardCapLevel(id))
		{
			return 0L;
		}
		if (character.hacks.hacks[id].target < character.hacks.hacks[id].level)
		{
			return character.hacks.hacks[id].level + levelsToNextMilestone(id);
		}
		long target = character.hacks.hacks[id].target;
		target = (character.hacks.hacks[id].target / milestoneThreshold(id) + 1) * milestoneThreshold(id);
		if (target > hardCapLevel(id))
		{
			target = 0L;
		}
		return target;
	}

	public long numMilestonesReached(int id)
	{
		if (id < 0 || id > character.hacks.hacks.Count)
		{
			return 0L;
		}
		return Mathf.FloorToInt(character.hacks.hacks[id].level / milestoneThreshold(id));
	}

	public void hideTooltip(int id)
	{
		if (id >= 0 && id < character.hacks.hacks.Count)
		{
			tooltip.hideTooltip();
		}
	}

	public long milestoneThreshold(int id)
	{
		long num = properties[id].milestoneThreshold;
		switch (id)
		{
		case 0:
			num -= character.beastQuest.quirkLevel[57];
			break;
		case 1:
			num -= character.adventure.itopod.perkLevel[113];
			break;
		case 2:
			num -= character.beastQuest.quirkLevel[175];
			break;
		case 3:
			num -= character.adventure.itopod.perkLevel[217];
			break;
		case 4:
			num -= character.adventure.itopod.perkLevel[218];
			break;
		case 5:
			num -= character.beastQuest.quirkLevel[174];
			break;
		case 6:
			num -= character.adventure.itopod.perkLevel[219];
			break;
		case 7:
			num -= character.adventure.itopod.perkLevel[114];
			break;
		case 8:
			num -= character.wishes.wishes[76].level;
			break;
		case 9:
			num -= character.adventure.itopod.perkLevel[115];
			break;
		case 10:
			num -= character.beastQuest.quirkLevel[59];
			break;
		case 11:
			num -= character.wishes.wishes[77].level;
			break;
		case 12:
			num -= character.beastQuest.quirkLevel[58];
			break;
		case 13:
			num -= character.wishes.wishes[78].level;
			break;
		case 14:
			num -= character.beastQuest.quirkLevel[60];
			break;
		}
		return num;
	}

	public long milestoneReduction(int id)
	{
		return 0L;
	}

	public void setToNextMilestone(int id)
	{
		if (id >= 0 && id <= character.hacks.hacks.Count)
		{
			character.hacks.hacks[id].target = nextMilestoneTarget(id);
		}
	}

	public float totalStatBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(0);
	}

	public float totalAdventureBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(1);
	}

	public float totalTMSpeedBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(2);
	}

	public float totalDropChanceBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(3);
	}

	public float totalAugSpeedBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(4);
	}

	public float totalEnergyNGUBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(5);
	}

	public float totalMagicNGUBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(6);
	}

	public float totalBloodGainBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(7);
	}

	public float totalQPGainBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(8);
	}

	public float totalDaycareSpeedBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(9);
	}

	public float totalEXPBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(10);
	}

	public float totalNumberBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(11);
	}

	public float totalPPGainBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(12);
	}

	public float totalHackBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(13);
	}

	public float totalWishSpeedBonus()
	{
		if (character.hacks.disabled)
		{
			return 1f;
		}
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return hackBonus(14);
	}

	public float totalHackSpeedBonus()
	{
		float num = totalHackBonus();
		num *= character.wishesController.totalHackSpeedBonus();
		num *= character.cardsController.getBonus(cardBonus.hackSpeed);
		num *= 1f + character.inventoryController.bonuses[specType.HackSpeed] + character.inventoryController.cubeHackBonus();
		if (character.inventory.itemList.itemMaxxed[297])
		{
			num *= 1.25f;
		}
		num *= 1f + (float)character.allChallenges.NGUChallenge.evilCompletions() * 0.2f;
		if (character.allChallenges.trollChallenge.evilCompletions() >= 5)
		{
			num *= 1.25f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}
}
