using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllGoldDiggerController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public List<double> baseGPSDrain;

	public List<double> baseGoldCost;

	public List<double> gpsGrowthRate;

	public List<bool> consumesGPS;

	public List<string> diggerName;

	public List<string> diggerDesc;

	public List<string> bonusName;

	public List<double> startingBoost;

	public List<double> boostPerLevel;

	public List<GoldDiggerUIController> pods;

	public Text infoText;

	public Text slotsUsed;

	public Text levelBonus;

	public int curPage;

	public long hardCapLevel(int id)
	{
		return (long)Math.Log(double.MaxValue / (baseGoldCost[id] * 2.0), gpsGrowthRate[id]);
	}

	private void Start()
	{
		changePage(0);
	}

	private void Update()
	{
		updateText();
	}

	public void reset()
	{
		clearAllActiveDiggers();
		refreshMenu();
	}

	public double drain(int id)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return 0.0;
		}
		if (character.diggers.diggers[id].curLevel <= 0)
		{
			return 0.0;
		}
		if (!character.diggers.diggers[id].active)
		{
			return 0.0;
		}
		return baseGPSDrain[id] * Math.Pow(gpsGrowthRate[id], character.diggers.diggers[id].curLevel - 1);
	}

	public double drain(int id, int offset)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return 0.0;
		}
		if (!character.diggers.diggers[id].active)
		{
			return 0.0;
		}
		if (character.diggers.diggers[id].curLevel + offset <= 0)
		{
			return 0.0;
		}
		return baseGPSDrain[id] * Math.Pow(gpsGrowthRate[id], character.diggers.diggers[id].curLevel + offset - 1);
	}

	public double drain(int id, bool evenifnotactive)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return 0.0;
		}
		if (character.diggers.diggers[id].curLevel <= 0)
		{
			return 0.0;
		}
		return baseGPSDrain[id] * Math.Pow(gpsGrowthRate[id], character.diggers.diggers[id].curLevel - 1);
	}

	public double drain(int id, int offset, bool evenifnotactive)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return 0.0;
		}
		if (character.diggers.diggers[id].curLevel <= 0)
		{
			return 0.0;
		}
		return baseGPSDrain[id] * Math.Pow(gpsGrowthRate[id], character.diggers.diggers[id].curLevel + offset - 1);
	}

	public double upgradeCost(int id)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return 0.0;
		}
		return baseGoldCost[id] * Math.Pow(gpsGrowthRate[id], character.diggers.diggers[id].maxLevel);
	}

	public void changePage(int newPage)
	{
		int num = newPage * pods.Count;
		for (int i = 0; i < pods.Count; i++)
		{
			pods[i].setID(num);
			num++;
		}
		curPage = newPage;
	}

	public void pageUp(int newPage)
	{
		if (4 + curPage * 4 <= character.diggers.diggers.Count)
		{
			changePage(curPage + 1);
		}
	}

	public void pageDown(int newPage)
	{
		if (curPage != 0)
		{
			changePage(curPage - 1);
		}
	}

	public void refreshMenu()
	{
		if (character.menuID == 44)
		{
			for (int i = 0; i < pods.Count; i++)
			{
				pods[i].updateUI();
			}
			updateText();
		}
	}

	public void setDiggerLoadout()
	{
		tooltip.showTooltip("Diggers saved to list!", 2f);
		character.diggers.loadoutDiggers.Clear();
		for (int i = 0; i < character.diggers.diggers.Count; i++)
		{
			if (character.diggers.diggers[i].active)
			{
				character.diggers.loadoutDiggers.Add(i);
			}
		}
	}

	public void applyDiggerLoadout()
	{
		tooltip.showTooltip("Saved diggers have been capped!", 2f);
		for (int num = character.diggers.loadoutDiggers.Count - 1; num >= 0; num--)
		{
			setLevelMaxAffordable(character.diggers.loadoutDiggers[num]);
		}
		refreshMenu();
	}

	public void updateText()
	{
		if (character.menuID == 44)
		{
			infoText.text = "<b>GROSS GPS: " + character.display(character.grossGoldPerSecond()) + "</b>";
			Text text = infoText;
			text.text = text.text + "\n<b>GPS DRAINED: " + character.display(totalGPSDrain()) + "</b>";
			Text text2 = infoText;
			text2.text = text2.text + "\n<b>NET GPS: " + character.display(character.goldPerSecond()) + "</b>";
			slotsUsed.text = "<b>DIGGER SLOTS USED:\n" + character.diggers.activeDiggers.Count + " / " + maxDiggerSlots() + "</b>";
			levelBonus.text = "<b>Total Digger Levels Bonus:\n\n" + (totalLevelBonus() * 100f).ToString("##0.###") + "%</b>";
		}
	}

	public double totalGPSDrain()
	{
		double num = 0.0;
		for (int i = 0; i < character.diggers.diggers.Count; i++)
		{
			if (character.diggers.diggers[i].active && consumesGPS[i] && character.diggers.diggers[i].curLevel > 0)
			{
				num += drain(i);
			}
		}
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	public void activateDigger(int id)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return;
		}
		int index = character.diggers.activeDiggers.IndexOf(id);
		if (character.diggers.diggers[id].active)
		{
			character.diggers.diggers[id].active = false;
			character.diggers.activeDiggers.RemoveAt(index);
			return;
		}
		if (character.diggers.activeDiggers.Count >= maxDiggerSlots())
		{
			tooltip.showOverrideTooltip("You already have the maximum number of diggers active at once!", 2f);
			return;
		}
		if (character.diggers.diggers[id].curLevel <= 0)
		{
			tooltip.showOverrideTooltip("You must activate this digger at level 1 or higher!", 2f);
			return;
		}
		character.diggers.diggers[id].active = true;
		if (character.totalGPSDrain() > character.grossGoldPerSecond())
		{
			character.diggers.diggers[id].active = false;
			tooltip.showOverrideTooltip("Your GPS is too low to activate this digger!", 2f);
		}
		else
		{
			character.diggers.activeDiggers.Add(id);
		}
	}

	public void upgradeMaxLevel(int id)
	{
		if (character.diggers.diggers[id].maxLevel >= hardCapLevel(id))
		{
			tooltip.showOverrideTooltip("The max level of this digger is as high as it possibly can go! Holy crap, you must be rich or something.", 3f);
			return;
		}
		if (upgradeCost(id) > character.realGold)
		{
			tooltip.showOverrideTooltip("You don't have enough gold to upgrade this digger! Haha, you suck.", 2f);
			return;
		}
		character.realGold -= upgradeCost(id);
		character.diggers.diggers[id].maxLevel++;
		tooltip.showTooltip("You've succesfully raised this digger's max level to <b>" + character.diggers.diggers[id].maxLevel + "!</b>", 2f);
		refreshMenu();
	}

	public void upgradeMaxLevelFully(int id)
	{
		if (id >= 0 && id <= character.diggers.diggers.Count)
		{
			long maxLevel = character.diggers.diggers[id].maxLevel;
			while (character.realGold >= upgradeCost(id) && character.diggers.diggers[id].maxLevel < hardCapLevel(id))
			{
				character.realGold -= upgradeCost(id);
				character.diggers.diggers[id].maxLevel++;
			}
			long maxLevel2 = character.diggers.diggers[id].maxLevel;
			if (maxLevel < maxLevel2)
			{
				tooltip.showTooltip("You've raised the max level of this digger by +" + (maxLevel2 - maxLevel) + "!", 2f);
			}
			else
			{
				tooltip.showOverrideTooltip("You don't have enough gold to upgrade this digger! Haha, you suck.", 2f);
			}
			refreshMenu();
		}
	}

	public void setLevelMaxAffordable(int id)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return;
		}
		long curLevel = character.diggers.diggers[id].curLevel;
		character.diggers.diggers[id].curLevel = 0L;
		if (character.goldPerSecond() < drain(id, 1, evenifnotactive: true))
		{
			character.diggers.diggers[id].curLevel = curLevel;
			return;
		}
		double num = character.goldPerSecond();
		double num2 = baseGPSDrain[id];
		double a = gpsGrowthRate[id];
		long val = (long)(Math.Log(num / num2, Math.E) / Math.Log(a, Math.E));
		val = Math.Min(val, character.diggers.diggers[id].maxLevel);
		if (val < 0)
		{
			val = 0L;
		}
		if (val > character.diggers.diggers[id].maxLevel)
		{
			val = character.diggers.diggers[id].maxLevel;
		}
		character.diggers.diggers[id].curLevel = val;
		if (character.diggers.diggers[id].curLevel == 0L && character.diggers.diggers[id].active)
		{
			for (int i = 0; i < character.diggers.activeDiggers.Count; i++)
			{
			}
			character.diggers.diggers[id].active = false;
			int index = character.diggers.activeDiggers.IndexOf(id);
			character.diggers.activeDiggers.RemoveAt(index);
		}
		if (character.grossGoldPerSecond() < totalGPSDrain())
		{
			character.diggers.diggers[id].curLevel = curLevel;
			tooltip.showOverrideTooltip("Something funky happened with the math here. You'll have to manually set the level, sorry! (PS: Tell 4G about this message!)", 5f);
		}
		else if (!character.diggers.diggers[id].active && character.diggers.diggers[id].curLevel > 0 && character.diggers.activeDiggers.Count < maxDiggerSlots())
		{
			activateDigger(id);
		}
		else
		{
			tooltip.showTooltip("This digger has been set to the highest level your GPS can handle!", 2f);
		}
		refreshMenu();
	}

	public void clearAllActiveDiggers()
	{
		for (int i = 0; i < character.diggers.diggers.Count; i++)
		{
			character.diggers.diggers[i].active = false;
		}
		character.diggers.activeDiggers.Clear();
		refreshMenu();
	}

	public int maxDiggerSlots()
	{
		int num = 1;
		if (character.purchases.hasDiggerSlot1)
		{
			num++;
		}
		num += character.adventureController.itopod.totalDiggerSlots();
		num += character.arbitrary.diggerSlots;
		if (character.inventory.itemList.jakeNoteComplete)
		{
			num++;
		}
		if (character.allChallenges.timeMachineChallenge.completions() >= 5)
		{
			num++;
		}
		if (num > character.diggers.diggers.Count)
		{
			num = character.diggers.diggers.Count;
		}
		return num;
	}

	public float totalDropChanceBonus()
	{
		return totalDropChanceBonus(0, skipCheck: false);
	}

	public float totalDropChanceBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[0].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[0] + (double)(character.diggers.diggers[0].curLevel + offset) * boostPerLevel[0]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalWandoosSpeedBonus()
	{
		return totalWandoosSpeedBonus(0, skipCheck: false);
	}

	public float totalWandoosSpeedBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[1].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[1] + (double)(character.diggers.diggers[1].curLevel + offset) * boostPerLevel[1]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public double totalStatBonus()
	{
		return totalStatBonus(0, skipCheck: false);
	}

	public double totalStatBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[2].active && !skipCheck)
		{
			return 1.0;
		}
		double num = 1.0 + (startingBoost[2] + (Math.Pow(character.diggers.diggers[2].curLevel, 3.0) + (double)offset) * boostPerLevel[2]);
		num *= (double)totalLevelBonus();
		if (num < 1.0)
		{
			return 1.0;
		}
		return num;
	}

	public float totalAdventureBonus()
	{
		return totalAdventureBonus(0, skipCheck: false);
	}

	public float totalAdventureBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[3].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[3] + (double)(character.diggers.diggers[3].curLevel + offset) * boostPerLevel[3]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalEnergyNGUBonus()
	{
		return totalEnergyNGUBonus(0, skipCheck: false);
	}

	public float totalEnergyNGUBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[4].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[4] + (double)(character.diggers.diggers[4].curLevel + offset) * boostPerLevel[4]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalMagicNGUBonus()
	{
		return totalMagicNGUBonus(0, skipCheck: false);
	}

	public float totalMagicNGUBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[5].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[5] + (double)(character.diggers.diggers[5].curLevel + offset) * boostPerLevel[5]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalEnergyBeardBonus()
	{
		return totalEnergyBeardBonus(0, skipCheck: false);
	}

	public float totalEnergyBeardBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[6].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[6] + (double)(character.diggers.diggers[6].curLevel + offset) * boostPerLevel[6]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalMagicBeardBonus()
	{
		return totalMagicBeardBonus(0, skipCheck: false);
	}

	public float totalMagicBeardBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[7].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[7] + (double)(character.diggers.diggers[7].curLevel + offset) * boostPerLevel[7]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalPPBonus()
	{
		return totalPPBonus(0, skipCheck: false);
	}

	public float totalPPBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[8].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[8] + (double)(character.diggers.diggers[8].curLevel + offset) * boostPerLevel[8]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalDaycareBonus()
	{
		float num = totalDaycareBonus(0, skipCheck: false) * (1f + character.inventoryController.bonuses[specType.DaycareSpeed]);
		num *= 1f + (float)character.allChallenges.blindChallenge.evilCompletions() * 0.02f;
		num *= 1f + (float)character.allChallenges.blindChallenge.sadisticCompletions() * 0.01f;
		num *= character.hacksController.totalDaycareSpeedBonus();
		num *= character.wishesController.totalDaycareSpeedBonus();
		num *= character.cardsController.getBonus(cardBonus.dayCareSpeed);
		if (character.adventure.itopod.perkLevel[94] >= 55)
		{
			num *= 1.05f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalDaycareBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[9].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[9] + (double)(character.diggers.diggers[9].curLevel + offset) * boostPerLevel[9]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalBloodBonus()
	{
		return totalBloodBonus(0, skipCheck: false);
	}

	public float totalBloodBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[10].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[10] + (double)(character.diggers.diggers[10].curLevel + offset) * boostPerLevel[10]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float totalEXPBonus()
	{
		return totalEXPBonus(0, skipCheck: false);
	}

	public float totalEXPBonus(int offset, bool skipCheck)
	{
		if (!character.diggers.diggers[11].active && !skipCheck)
		{
			return 1f;
		}
		float num = 1f + (float)(startingBoost[11] + (double)(character.diggers.diggers[11].curLevel + offset) * boostPerLevel[11]);
		num *= totalLevelBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public string bonusString(int id)
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return "Oh boy an error to tell 4G about!";
		}
		switch (id)
		{
		case 0:
			return (totalDropChanceBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 1:
			return (totalWandoosSpeedBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 2:
			return character.display(totalStatBonus(0, skipCheck: true) * 100.0);
		case 3:
			return (totalAdventureBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 4:
			return (totalEnergyNGUBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 5:
			return (totalMagicNGUBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 6:
			return (totalEnergyBeardBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 7:
			return (totalMagicBeardBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 8:
			return (totalPPBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 9:
			return (totalDaycareBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 10:
			return (totalBloodBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		case 11:
			return (totalEXPBonus(0, skipCheck: true) * 100f).ToString("###,##0.##");
		default:
			return "Oh boy an error to tell 4G about!";
		}
	}

	public long sumOfAllLevels()
	{
		long num = 0L;
		for (int i = 0; i < character.diggers.diggers.Count; i++)
		{
			num += character.diggers.diggers[i].maxLevel;
		}
		if (num < 0)
		{
			num = 0L;
		}
		return num;
	}

	public float totalLevelBonus()
	{
		long num = sumOfAllLevels();
		float num2 = 1f;
		num2 = ((num > 500) ? (1.25f + Mathf.Pow(num - 500, 0.7f) * 0.0005f) : (1f + (float)sumOfAllLevels() * 0.0005f));
		if (character.challenges.timeMachineChallenge.curCompletions >= 1)
		{
			num2 += 0.05f;
		}
		if (character.inventory.itemList.partyComplete)
		{
			num2 += 0.05f;
		}
		return num2;
	}

	public void showTooltip(int id)
	{
		string message = "<b>" + diggerName[id] + "\n\n" + diggerDesc[id] + "</b>";
		tooltip.showTooltip(message);
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}
}
