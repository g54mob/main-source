using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItopodPerkController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public List<ItopodPerkUIController> perkControllers;

	public List<long> maxLevel;

	public List<long> cost;

	public List<string> perkName;

	public List<bool> hasStatEffect;

	public List<float> effectPerLevel;

	public List<string> perkDesc;

	public List<difficulty> perkDifficultyReq;

	public List<Sprite> graphic;

	public List<itopodPerk> perkType;

	public Text displayText;

	public Text displayText2;

	public Text orderTypeText;

	public Image filterDiffCheckmark;

	public Image filterAffordCheckmark;

	public Image filterMaxCheckmark;

	private Dictionary<int, double> dictDouble = new Dictionary<int, double>();

	public List<int> curValidUpgradesList = new List<int>();

	private string message;

	public int page;

	public void Start()
	{
		constructList();
		changePage(0);
	}

	public void constructList()
	{
		dictDouble.Clear();
		constructFullList();
		if (character.adventure.itopod.filterDiff)
		{
			filterDifficulty();
		}
		if (character.adventure.itopod.filterAfford)
		{
			filterAffordable();
		}
		if (character.adventure.itopod.filterMaxxed)
		{
			filterNotMax();
		}
		orderList();
	}

	public void orderList()
	{
		switch (character.adventure.itopod.orderType)
		{
		case orderPerks.SpeedCost:
			orderBaseCost();
			break;
		case orderPerks.totalCost:
			orderTotalCost();
			break;
		case orderPerks.Default:
			break;
		}
	}

	public void constructFullList()
	{
		curValidUpgradesList.Clear();
		for (int i = 0; i < character.adventure.itopod.perkLevel.Count; i++)
		{
			curValidUpgradesList.Add(i);
		}
	}

	public void filterDifficulty()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			if (perkDifficultyReq[curValidUpgradesList[i]] > character.settings.rebirthDifficulty)
			{
				curValidUpgradesList.RemoveAt(i);
				i--;
			}
		}
	}

	public void filterAffordable()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			if (character.adventureController.itopod.cost[curValidUpgradesList[i]] > character.adventure.itopod.perkPoints)
			{
				curValidUpgradesList.RemoveAt(i);
				i--;
			}
		}
	}

	public void filterNotMax()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			if (character.adventure.itopod.perkLevel[curValidUpgradesList[i]] >= character.adventureController.itopod.maxLevel[curValidUpgradesList[i]])
			{
				curValidUpgradesList.RemoveAt(i);
				i--;
			}
		}
	}

	public void orderBaseCost()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			dictDouble.Add(curValidUpgradesList[i], cost[curValidUpgradesList[i]]);
		}
		dictDouble = dictDouble.OrderBy((KeyValuePair<int, double> x) => x.Value).ToDictionary((KeyValuePair<int, double> x) => x.Key, (KeyValuePair<int, double> x) => x.Value);
		curValidUpgradesList.Clear();
		for (int num = 0; num < dictDouble.Count; num++)
		{
			curValidUpgradesList.Add(dictDouble.ElementAt(num).Key);
		}
	}

	public void orderTotalCost()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			dictDouble.Add(curValidUpgradesList[i], totalCost(curValidUpgradesList[i]));
		}
		dictDouble = dictDouble.OrderBy((KeyValuePair<int, double> x) => x.Value).ToDictionary((KeyValuePair<int, double> x) => x.Key, (KeyValuePair<int, double> x) => x.Value);
		curValidUpgradesList.Clear();
		for (int num = 0; num < dictDouble.Count; num++)
		{
			curValidUpgradesList.Add(dictDouble.ElementAt(num).Key);
		}
	}

	public double totalCost(int index)
	{
		double num = 0.0;
		if (character.adventure.itopod.perkLevel[index] >= maxLevel[index])
		{
			return 0.0;
		}
		num = (maxLevel[index] - character.adventure.itopod.perkLevel[index]) * character.adventureController.itopod.cost[index];
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	public long pointThreshold()
	{
		return 1000000L;
	}

	public long poopThreshold()
	{
		return 9000L;
	}

	public long capLevel(int i)
	{
		if (i > maxLevel.Count || i < 0)
		{
			return 0L;
		}
		if (maxLevel[i] == 0L)
		{
			return long.MaxValue;
		}
		return maxLevel[i];
	}

	public void updateMenu()
	{
		if (character.menuID != 41)
		{
			return;
		}
		constructList();
		changePage(page);
		for (int i = 0; i < perkControllers.Count; i++)
		{
			if (perkControllers[i] != null)
			{
				perkControllers[i].updateGraphic();
			}
		}
		updateText();
		updateFilters();
		updateOrderTypeText();
	}

	public void updateText()
	{
		if (character.menuID == 41)
		{
			displayText.text = "You have " + character.display(character.adventure.itopod.perkPoints);
			displayText2.text = "Progress to next PP:\n" + character.adventure.itopod.pointProgress.ToString("###,##0") + " / " + pointThreshold().ToString("###,##0") + " <b>(" + ((float)character.adventure.itopod.pointProgress / (float)pointThreshold() * 100f).ToString("#0.##") + " %)</b>";
		}
	}

	public void updateFilters()
	{
		if (character.menuID == 41)
		{
			if (character.adventure.itopod.filterDiff)
			{
				filterDiffCheckmark.color = Color.white;
			}
			else
			{
				filterDiffCheckmark.color = Color.clear;
			}
			if (character.adventure.itopod.filterMaxxed)
			{
				filterMaxCheckmark.color = Color.white;
			}
			else
			{
				filterMaxCheckmark.color = Color.clear;
			}
			if (character.adventure.itopod.filterAfford)
			{
				filterAffordCheckmark.color = Color.white;
			}
			else
			{
				filterAffordCheckmark.color = Color.clear;
			}
		}
	}

	public void updateOrderTypeText()
	{
		if (character.menuID == 41)
		{
			switch (character.adventure.itopod.orderType)
			{
			case orderPerks.Default:
				orderTypeText.text = "Order By:\n<b>DEFAULT</b>";
				break;
			case orderPerks.SpeedCost:
				orderTypeText.text = "Order By:\n<b>BASE COST</b>";
				break;
			case orderPerks.totalCost:
				orderTypeText.text = "Order By:\n<b>TOTAL COST</b>";
				break;
			default:
				orderTypeText.text = "Order by:\n<b>DEFAULT</b>";
				break;
			}
		}
	}

	public void changePage(int pageID)
	{
		int num = pageID * 108;
		for (int i = 0; i < perkControllers.Count; i++)
		{
			if (num < 0 || num >= curValidUpgradesList.Count)
			{
				perkControllers[i].id = 100000;
			}
			else
			{
				perkControllers[i].id = curValidUpgradesList[num];
			}
			num++;
			perkControllers[i].updateGraphic();
		}
		page = pageID;
	}

	public void onFilterChange()
	{
		constructList();
		changePage(0);
		updateFilters();
	}

	public void onOrderChange()
	{
		constructList();
		changePage(0);
		updateOrderTypeText();
	}

	public void toggleMaxFilter()
	{
		character.adventure.itopod.filterMaxxed = !character.adventure.itopod.filterMaxxed;
		onFilterChange();
	}

	public void toggleAffordFilter()
	{
		character.adventure.itopod.filterAfford = !character.adventure.itopod.filterAfford;
		onFilterChange();
	}

	public void toggleDiffFilter()
	{
		character.adventure.itopod.filterDiff = !character.adventure.itopod.filterDiff;
		onFilterChange();
	}

	public void advanceOrderType()
	{
		character.adventure.itopod.orderType = (orderPerks)((int)(character.adventure.itopod.orderType + 1) % Enum.GetValues(typeof(orderPerks)).Length);
		onOrderChange();
	}

	public long perkCost(int id)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return 1000L;
		}
		return cost[id];
	}

	public void addLevel(int id)
	{
		if (id >= 0 && id <= character.adventure.itopod.perkLevel.Count && id <= cost.Count && character.adventure.itopod.perkPoints >= cost[id])
		{
			character.adventure.itopod.perkPoints -= cost[id];
			character.adventure.itopod.perkLevel[id]++;
			updateText();
		}
	}

	public void awardHighestLevelPP(int level)
	{
		if (level % 10 == 0)
		{
			int num = level / 10;
			int num2 = Mathf.CeilToInt((float)num / 10f);
			if (num % 10 == 0)
			{
				num2 *= 10;
			}
			if (num2 < 0)
			{
				num2 = 10;
			}
			character.adventure.itopod.perkPoints += num2;
			character.adventureController.log.AddEvent("You Reached floor " + level + " of the I.T.O.P.O.D for the first time!");
			character.adventureController.log.AddEvent("You've been awarded a one-time bonus of " + num2 + " Perk points!");
		}
	}

	public long progressGained(long itopodLevel)
	{
		long result = 0L;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			result = (long)((200f + (float)itopodLevel) * totalPPBonus());
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			result = (long)((700f + (float)itopodLevel) * totalPPBonus());
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			result = (long)((2000f + (float)itopodLevel + (float)totalBasePPBonus()) * totalPPBonus());
		}
		return result;
	}

	public long baseProgressGained(long itopodLevel)
	{
		long result = 0L;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			result = (long)(200f + (float)itopodLevel);
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			result = (long)(700f + (float)itopodLevel);
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			result = (long)(2000f + (float)itopodLevel + (float)totalBasePPBonus());
		}
		return result;
	}

	public long totalBasePPBonus()
	{
		return 0 + character.beastQuestPerkController.totalBasePPBonus() + character.wishesController.totalBasePPBonus();
	}

	public float totalPPBonus()
	{
		return totalPPBonus(usePills: true);
	}

	public float totalPPBonus(bool usePills)
	{
		float num = 1f;
		num *= character.NGUController.PPBonus();
		if (character.inventory.itemList.greenHeartComplete)
		{
			num *= 1.2f;
		}
		if (character.inventory.itemList.itopodKeyComplete)
		{
			num *= 1.1f;
		}
		if (character.inventory.itemList.prettyComplete)
		{
			num *= 1.1f;
		}
		if (character.inventory.itemList.halloweeniesComplete)
		{
			num *= 1.45f;
		}
		if (character.adventure.itopod.buffedKills > 0 && character.settings.buffedKillsOn && usePills)
		{
			num *= character.allArbitrary.pillModifier();
		}
		num *= character.allDiggers.totalPPBonus();
		num *= character.hacksController.totalPPGainBonus();
		num *= character.cardsController.getBonus(cardBonus.PP);
		if (character.adventure.itopod.perkLevel[94] >= 13)
		{
			num *= 1.05f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public long addProgress(long amount)
	{
		character.adventure.itopod.pointProgress += amount;
		character.adventureController.log.AddEvent("You gained " + character.display(amount) + " progress to your next Perk Point!");
		long num = character.adventure.itopod.pointProgress / pointThreshold();
		character.adventure.itopod.pointProgress = character.adventure.itopod.pointProgress % pointThreshold();
		if (num == 1)
		{
			character.adventure.itopod.perkPoints += num;
			character.adventure.itopod.lifetimePoints += num;
			character.adventureController.log.AddEvent("You gained " + num + " Perk Point!");
			updateText();
			return num;
		}
		if (num >= 2)
		{
			character.adventure.itopod.perkPoints += num;
			character.adventure.itopod.lifetimePoints += num;
			character.adventureController.log.AddEvent("You gained " + character.display(num) + " Perk Points!");
			updateText();
			return num;
		}
		updateText();
		return 0L;
	}

	public long progressToPP(long progress)
	{
		return progress / pointThreshold();
	}

	public long progressToRemainder(long progress)
	{
		return progress % pointThreshold();
	}

	public long addPoopProgress(long amount)
	{
		character.adventure.itopod.poopProgress += amount;
		long num = character.adventure.itopod.poopProgress / poopThreshold();
		character.adventure.itopod.poopProgress = character.adventure.itopod.poopProgress % poopThreshold();
		if (num >= 1)
		{
			character.arbitrary.poop1Count += (int)num;
			character.adventureController.log.AddEvent("You gained " + num + " Poop!");
			updateText();
			return num;
		}
		updateText();
		return 0L;
	}

	public string getPerkName(int id)
	{
		return perkName[id];
	}

	public void showTooltip(int id)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return;
		}
		message = "<b>(" + id + ") " + getPerkName(id) + "</b>";
		if (perkDifficultyReq[id] == difficulty.evil)
		{
			message += "\n<color=red><b>EVIL DIFFICULTY PERK</b></color>";
		}
		else if (perkDifficultyReq[id] == difficulty.sadistic)
		{
			message += "\n<color=#57007fff><b>SADISTIC DIFFICULTY PERK</b></color>";
		}
		message = message + "\n\n<b>" + perkDesc[id] + "</b>\n\n";
		if (maxLevel[id] <= 0)
		{
			message = message + "<b>Current level: " + character.adventure.itopod.perkLevel[id] + "</b>";
		}
		else if (character.adventure.itopod.perkLevel[id] < maxLevel[id])
		{
			message = message + "<b>Current level: " + character.adventure.itopod.perkLevel[id] + "/" + maxLevel[id] + "</b>";
		}
		else
		{
			message = message + "<b>Current level: " + character.adventure.itopod.perkLevel[id] + " (MAX)</b>";
		}
		if (hasStatEffect[id])
		{
			if (id >= 36 && id <= 50)
			{
				message = message + "\n<b>Current Bonus: " + percentEffectNo100(id, 0) + "%</b>";
			}
			else
			{
				switch (id)
				{
				case 18:
					message = message + "\n<b>Levels Added to Advanced Training: " + levelEffect(id, 0) + "</b>";
					break;
				case 21:
					message = message + "\n<b>Maximum Time Factor for Beards reached at: " + (24 - levelEffect(id, 0)) + " hours</b>";
					break;
				case 22:
					message = message + "\n<b>Bonus Wandoos OS Levels: " + levelEffect(id, 0) + "</b>";
					break;
				case 25:
					message = message + "\n<b>Current Bonus: " + percentEffectNo100(id, 0) + "%</b>";
					break;
				case 51:
					message = message + "\n<b>Current Bonus: " + percentEffectNo100(id, 0) + "% improved first harvest!</b>";
					break;
				case 54:
					message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
					break;
				case 55:
					message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
					break;
				case 84:
					message = message + "\n<b>Current Bonus: " + statEffect(84, 0) + "x</b>";
					if (character.adventure.itopod.perkLevel[id] < capLevel(id))
					{
						message = message + "\n<b>Next Level Bonus: " + statEffect(84, 1) + "x</b>";
					}
					break;
				case 85:
					message = message + "\n<b>Current Bonus: " + statEffect(85, 0) + "x</b>";
					if (character.adventure.itopod.perkLevel[id] < capLevel(id))
					{
						message = message + "\n<b>Next Level Bonus: " + statEffect(85, 1) + "x</b>";
					}
					break;
				case 93:
					message = message + "\n<b>Current Bonus: " + invertedEffectPercent(93, 0) + "%</b>";
					if (character.adventure.itopod.perkLevel[id] < capLevel(id))
					{
						message = message + "\n<b>Next Level Bonus: " + invertedEffectPercent(93, 1) + "%</b>";
					}
					break;
				default:
					if (character.adventure.itopod.perkLevel[id] < capLevel(id))
					{
						message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
						message = message + "\n<b>Next Level Bonus: " + percentEffect(id, 1) + "%</b>";
					}
					else
					{
						message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
					}
					break;
				}
			}
		}
		if (cost[id] == 1)
		{
			message = message + "\n<b>COST: " + cost[id] + " Perk Point</b>";
		}
		else
		{
			message = message + "\n<b>COST: " + character.display(cost[id]) + " Perk Points</b>";
		}
		if (id == 94)
		{
			message += fibPerkUnlocks();
		}
		tooltip.showTooltip(message);
	}

	public string percentEffect(int id, int offset)
	{
		return (statEffect(id, offset) * 100f).ToString("###,##0.##");
	}

	public string percentEffectNo100(int id, int offset)
	{
		return ((statEffect(id, offset) - 1f) * 100f).ToString("###,##0.###");
	}

	public float statEffect(int id, int offset)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return 1f;
		}
		return 1f + (float)(character.adventure.itopod.perkLevel[id] + offset) * effectPerLevel[id];
	}

	public float invertedEffectPercent(int id, int offset)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return 1f;
		}
		return (1f - (float)(character.adventure.itopod.perkLevel[id] + offset) * effectPerLevel[id]) * 100f;
	}

	public long levelEffect(int id, int offset)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return 0L;
		}
		return (long)((float)(character.adventure.itopod.perkLevel[id] + offset) * effectPerLevel[id]);
	}

	public void tryLevelUp(int id)
	{
		if (id >= 0 && id <= character.adventure.itopod.perkLevel.Count)
		{
			if (character.adventure.itopod.perkLevel[id] >= capLevel(id))
			{
				tooltip.showTooltip("Hey this perk is at the MAX level, can't you read? Jeez.", 2f);
			}
			else if (character.settings.rebirthDifficulty < perkDifficultyReq[id])
			{
				tooltip.showOverrideTooltip(string.Concat("You can't buy this Perk until you move to ", perkDifficultyReq[id], " difficulty!"), 2f);
			}
			else if (character.adventure.itopod.perkPoints < perkCost(id))
			{
				tooltip.showTooltip("Hey math genius, you don't have enough PP to level this perk up!", 2f);
			}
			else
			{
				doLevelUp(id);
			}
		}
	}

	public void doLevelUp(int id)
	{
		character.adventure.itopod.perkPoints -= perkCost(id);
		character.adventure.itopod.perkLevel[id]++;
		doEffect(id);
		showTooltip(id);
		updateText();
		changePage(page);
	}

	public void tryLevelAll(int id)
	{
		if (id >= 0 && id <= character.adventure.itopod.perkLevel.Count)
		{
			if (character.adventure.itopod.perkLevel[id] >= capLevel(id))
			{
				tooltip.showTooltip("Hey this perk is at the MAX level, can't you read? Jeez.", 2f);
			}
			else if (character.settings.rebirthDifficulty < perkDifficultyReq[id])
			{
				tooltip.showOverrideTooltip(string.Concat("You can't buy this Perk until you move to ", perkDifficultyReq[id], " difficulty!"), 2f);
			}
			else if (character.adventure.itopod.perkPoints < perkCost(id))
			{
				tooltip.showTooltip("Hey math genius, you don't have enough PP to level this perk up even once!", 2f);
			}
			else
			{
				doLevelAll(id);
			}
		}
	}

	public void doLevelAll(int id)
	{
		while (character.adventure.itopod.perkLevel[id] < character.adventureController.itopod.maxLevel[id] && character.adventure.itopod.perkPoints >= perkCost(id))
		{
			character.adventure.itopod.perkPoints -= perkCost(id);
			character.adventure.itopod.perkLevel[id]++;
			doEffect(id);
		}
		showTooltip(id);
		updateText();
		changePage(page);
	}

	public void doEffect(int id)
	{
		if (id < 0 || id > character.adventure.itopod.perkLevel.Count)
		{
			return;
		}
		switch (id)
		{
		case 0:
			character.energyPower += 3f;
			character.energyBars += 3L;
			break;
		case 1:
			character.magic.magicPower += 1f;
			character.magic.magicPerBar++;
			character.magic.capMagic += 10000L;
			break;
		case 2:
			character.adventure.attack += 100f;
			character.adventure.defense += 100f;
			break;
		case 29:
			character.inventoryController.updateAccCount();
			break;
		case 31:
			character.inventoryController.updateInvCount();
			break;
		case 32:
			character.inventoryController.updateInvCount();
			break;
		case 66:
			character.inventoryController.updateMacguffinCount();
			break;
		case 67:
			character.inventoryController.updateMacguffinCount();
			break;
		case 72:
			character.bloodMagic.macguffin1Time.setTime(character.bloodMagicController.spells.macguffin1Cooldown);
			break;
		case 73:
			character.bloodMagic.macguffin2Time.setTime(character.bloodMagicController.spells.macguffin2Cooldown);
			break;
		case 86:
			character.inventoryController.updateDaycareCount();
			break;
		case 88:
			character.inventoryController.updateMacguffinCount();
			break;
		case 94:
			if (character.adventure.itopod.perkLevel[94] == 1597)
			{
				character.inventoryController.updateKittyArtCount();
			}
			break;
		}
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public float perkEffect(int id)
	{
		if (character.settings.rebirthDifficulty < perkDifficultyReq[id])
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[id] * effectPerLevel[id];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalEnergyPowerBonus()
	{
		float num = energyPower1Bonus() * energyPower2Bonus() * energyPower3Bonus() * energyPower4Bonus() * energyPower5Bonus() * perkEffect(126) * perkEffect(135) * perkEffect(220);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyPower1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[6] * 0.01f;
	}

	public float energyPower2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[57] * effectPerLevel[57];
	}

	public float energyPower3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[74] * effectPerLevel[74];
	}

	public float energyPower4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 1)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float energyPower5Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[116] * effectPerLevel[116];
	}

	public float totalEnergyBarBonus()
	{
		float num = energyBar1Bonus() * energyBar2Bonus() * energyBar3Bonus() * energyBar4Bonus() * energyBar5Bonus() * perkEffect(127) * perkEffect(136) * perkEffect(221);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyBar1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[7] * 0.01f;
	}

	public float energyBar2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[58] * effectPerLevel[58];
	}

	public float energyBar3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[75] * effectPerLevel[75];
	}

	public float energyBar4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 21)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float energyBar5Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[117] * effectPerLevel[117];
	}

	public float totalEnergyCapBonus()
	{
		float num = energyCap1Bonus() * energyCap2Bonus() * energyCap3Bonus() * energyCap4Bonus() * energyCap5Bonus() * perkEffect(128) * perkEffect(137) * perkEffect(222);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyCap1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[8] * 0.01f;
	}

	public float energyCap2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[59] * effectPerLevel[59];
	}

	public float energyCap3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[76] * effectPerLevel[76];
	}

	public float energyCap4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 2)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float energyCap5Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[118] * effectPerLevel[118];
	}

	public float totalMagicPowerBonus()
	{
		float num = magicPower1Bonus() * magicPower2Bonus() * magicPower3Bonus() * magicPower4Bonus() * magicPower5Bonus() * perkEffect(129) * perkEffect(138) * perkEffect(223);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicPower1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[9] * 0.01f;
	}

	public float magicPower2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[60] * effectPerLevel[60];
	}

	public float magicPower3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[77] * effectPerLevel[77];
	}

	public float magicPower4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 1)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float magicPower5Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[119] * effectPerLevel[119];
	}

	public float totalMagicBarBonus()
	{
		float num = magicBar1Bonus() * magicBar2Bonus() * magicBar3Bonus() * magicBar4Bonus() * perkEffect(120) * perkEffect(130) * perkEffect(139) * perkEffect(224);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicBar1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[10] * 0.01f;
	}

	public float magicBar2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[61] * effectPerLevel[61];
	}

	public float magicBar3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[78] * effectPerLevel[78];
	}

	public float magicBar4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 21)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float totalMagicCapBonus()
	{
		float num = magicCap1Bonus() * magicCap2Bonus() * magicCap3Bonus() * magicCap4Bonus() * magicCap5Bonus() * perkEffect(131) * perkEffect(140) * perkEffect(225);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicCap1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[11] * 0.01f;
	}

	public float magicCap2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[62] * effectPerLevel[62];
	}

	public float magicCap3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[79] * effectPerLevel[79];
	}

	public float magicCap4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 3)
		{
			return 1.1f;
		}
		return 1f;
	}

	public float magicCap5Bonus()
	{
		return perkEffect(121);
	}

	public float totalRes3PowerBonus()
	{
		float num = res3Power1Bonus() * res3Power2Bonus() * res3Power3Bonus() * res3Power4Bonus() * perkEffect(132) * perkEffect(141) * perkEffect(226);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3Power1Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[95] * effectPerLevel[95];
	}

	public float res3Power2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[98] * effectPerLevel[98];
	}

	public float res3Power3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[101] * effectPerLevel[101];
	}

	public float res3Power4Bonus()
	{
		return perkEffect(122);
	}

	public float totalRes3BarBonus()
	{
		float num = res3Bar1Bonus() * res3Bar2Bonus() * res3Bar3Bonus() * res3Bar4Bonus() * perkEffect(133) * perkEffect(142) * perkEffect(227);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3Bar1Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[96] * effectPerLevel[96];
	}

	public float res3Bar2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[99] * effectPerLevel[99];
	}

	public float res3Bar3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[102] * effectPerLevel[102];
	}

	public float res3Bar4Bonus()
	{
		return perkEffect(123);
	}

	public float totalRes3CapBonus()
	{
		float num = res3Cap1Bonus() * res3Cap2Bonus() * res3Cap3Bonus() * res3Cap4Bonus() * perkEffect(134) * perkEffect(143) * perkEffect(228);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3Cap1Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[97] * effectPerLevel[97];
	}

	public float res3Cap2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[100] * effectPerLevel[100];
	}

	public float res3Cap3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.adventure.itopod.perkLevel[103] * effectPerLevel[103];
	}

	public float res3Cap4Bonus()
	{
		return perkEffect(124);
	}

	public float totalBoostBonus()
	{
		float num = boost1Bonus() * boost2Bonus() * boost3Bonus() * perkEffect(229) * perkEffect(230);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float boost1Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[12] * effectPerLevel[12];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float boost2Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[33] * effectPerLevel[33];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float boost3Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[107] * effectPerLevel[107];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public double totalStatBonus()
	{
		double num = newbieBonus() * stat1Bonus() * stat2Bonus() * stat3Bonus() * (double)stat4Bonus() * (double)stat5Bonus() * (double)stat6Bonus() * (double)perkEffect(149) * (double)perkEffect(151) * (double)perkEffect(153);
		if (num < 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public double newbieBonus()
	{
		if (character.adventure.itopod.perkLevel[4] >= 1)
		{
			return 2.0;
		}
		return 1.0;
	}

	public double stat1Bonus()
	{
		return 1.0 + (double)((float)character.adventure.itopod.perkLevel[5] * effectPerLevel[5]);
	}

	public double stat2Bonus()
	{
		return 1.0 + (double)((float)character.adventure.itopod.perkLevel[54] * effectPerLevel[54]);
	}

	public double stat3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1.0;
		}
		return 1.0 + (double)((float)character.adventure.itopod.perkLevel[82] * effectPerLevel[82]);
	}

	public float stat4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 377)
		{
			return 3.77f;
		}
		return 1f;
	}

	public float stat5Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[125] >= 1)
		{
			return 3f;
		}
		return 1f;
	}

	public float stat6Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[144] >= 1)
		{
			return 10f;
		}
		return 1f;
	}

	public float totalEnergyNGUBonus()
	{
		float num = energyNGU1Bonus() * energyNGU2Bonus() * energyNGU3Bonus() * energyNGU4Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyNGU1Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[13] * character.adventureController.itopod.effectPerLevel[13];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyNGU2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[63] * character.adventureController.itopod.effectPerLevel[63];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyNGU3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[80] * character.adventureController.itopod.effectPerLevel[80];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyNGU4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 5)
		{
			return 1.05f;
		}
		return 1f;
	}

	public float totalMagicNGUBonus()
	{
		float num = magicNGU1Bonus() * magicNGU2Bonus() * magicNGU3Bonus() * magicNGU4Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicNGU1Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[14] * character.adventureController.itopod.effectPerLevel[14];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicNGU2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[64] * character.adventureController.itopod.effectPerLevel[64];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicNGU3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[81] * character.adventureController.itopod.effectPerLevel[81];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicNGU4Bonus()
	{
		if (character.adventure.itopod.perkLevel[94] >= 8)
		{
			return 1.05f;
		}
		return 1f;
	}

	public float totalSeedBonus()
	{
		float num = seed1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float seed1Bonus()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[24] * character.adventureController.itopod.effectPerLevel[24];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalDropChanceBonus()
	{
		float num = newbieDropChanceBonus() * drop2();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float newbieDropChanceBonus()
	{
		float result = 1f;
		if (character.adventure.itopod.perkLevel[3] >= 1)
		{
			result = 1.1f;
		}
		return result;
	}

	public float drop2()
	{
		float result = 1f;
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[125] >= 1)
		{
			result = 1.5f;
		}
		return result;
	}

	public long totalOSLevelBonus()
	{
		long num = OS1Bonus();
		if (num < 0)
		{
			num = 0L;
		}
		return num;
	}

	public long OS1Bonus()
	{
		return character.adventure.itopod.perkLevel[22] * (long)effectPerLevel[22];
	}

	public float totalGoldDropBonus()
	{
		float num = goldDrop1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float goldDrop1Bonus()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[23] * effectPerLevel[23];
	}

	public long totalInvSpaces()
	{
		long num = invSpace1() + invSpace2();
		if (num < 0)
		{
			num = 0L;
		}
		return num;
	}

	public long invSpace1()
	{
		long num = character.adventure.itopod.perkLevel[31];
		if (num < 0)
		{
			num = 0L;
		}
		if (num > 12)
		{
			num = 12L;
		}
		return num;
	}

	public long invSpace2()
	{
		long num = character.adventure.itopod.perkLevel[32];
		if (num < 0)
		{
			num = 0L;
		}
		if (num > 12)
		{
			num = 12L;
		}
		return num;
	}

	public float totalBossExp()
	{
		float num = bossExp1();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float bossExp1()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[35] * effectPerLevel[35];
	}

	public float totalAdventureBonus()
	{
		float num = adventureStats1() * adventureStats2() * adventureStats3() * adventureStats4() * adventureStats5() * perkEffect(150) * perkEffect(152) * perkEffect(154);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float adventureStats1()
	{
		float num = 1f;
		if (character.adventure.itopod.perkLevel[2] >= 1)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float adventureStats2()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[55] * effectPerLevel[55];
		if (float.IsNaN(num))
		{
			num = 1f;
		}
		return num;
	}

	public float adventureStats3()
	{
		float num = 1f + (float)character.adventure.itopod.perkLevel[83] * effectPerLevel[83];
		if (float.IsNaN(num))
		{
			num = 1f;
		}
		return num;
	}

	public float adventureStats4()
	{
		if (character.adventure.itopod.perkLevel[94] >= 34)
		{
			return 1.13f;
		}
		return 1f;
	}

	public float adventureStats5()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[144] >= 1)
		{
			return 1.15f;
		}
		return 1f;
	}

	public float totalBankedAdvTraining()
	{
		float num = 0f;
		num = (float)character.adventure.itopod.perkLevel[36] * character.adventureController.itopod.effectPerLevel[36] + (float)character.adventure.itopod.perkLevel[37] * character.adventureController.itopod.effectPerLevel[37] + (float)character.adventure.itopod.perkLevel[38] * character.adventureController.itopod.effectPerLevel[38] + (float)character.adventure.itopod.perkLevel[39] * character.adventureController.itopod.effectPerLevel[39] + (float)character.adventure.itopod.perkLevel[40] * character.adventureController.itopod.effectPerLevel[40];
		num += (float)character.beastQuest.quirkLevel[20] * character.beastQuestPerkController.effectPerLevel[20];
		num += (float)character.beastQuest.quirkLevel[21] * character.beastQuestPerkController.effectPerLevel[21];
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num += (float)character.beastQuest.quirkLevel[22] * character.beastQuestPerkController.effectPerLevel[22];
			num += (float)character.beastQuest.quirkLevel[23] * character.beastQuestPerkController.effectPerLevel[23];
			num += (float)character.beastQuest.quirkLevel[24] * character.beastQuestPerkController.effectPerLevel[24];
		}
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.75f)
		{
			num = 0.75f;
		}
		return num;
	}

	public float totalBankedTimeMachine()
	{
		float num = (float)character.adventure.itopod.perkLevel[41] * character.adventureController.itopod.effectPerLevel[41] + (float)character.adventure.itopod.perkLevel[42] * character.adventureController.itopod.effectPerLevel[42] + (float)character.adventure.itopod.perkLevel[43] * character.adventureController.itopod.effectPerLevel[43] + (float)character.adventure.itopod.perkLevel[44] * character.adventureController.itopod.effectPerLevel[44] + (float)character.adventure.itopod.perkLevel[45] * character.adventureController.itopod.effectPerLevel[45];
		num += (float)character.beastQuest.quirkLevel[25] * character.beastQuestPerkController.effectPerLevel[25];
		num += (float)character.beastQuest.quirkLevel[26] * character.beastQuestPerkController.effectPerLevel[26];
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num += (float)character.beastQuest.quirkLevel[27] * character.beastQuestPerkController.effectPerLevel[27];
			num += (float)character.beastQuest.quirkLevel[28] * character.beastQuestPerkController.effectPerLevel[28];
			num += (float)character.beastQuest.quirkLevel[29] * character.beastQuestPerkController.effectPerLevel[29];
		}
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.75f)
		{
			num = 0.75f;
		}
		return num;
	}

	public float totalBankedBeardTemp()
	{
		float num = (float)character.adventure.itopod.perkLevel[46] * character.adventureController.itopod.effectPerLevel[46] + (float)character.adventure.itopod.perkLevel[47] * character.adventureController.itopod.effectPerLevel[47] + (float)character.adventure.itopod.perkLevel[48] * character.adventureController.itopod.effectPerLevel[48] + (float)character.adventure.itopod.perkLevel[49] * character.adventureController.itopod.effectPerLevel[49] + (float)character.adventure.itopod.perkLevel[50] * character.adventureController.itopod.effectPerLevel[50];
		num += (float)character.beastQuest.quirkLevel[30] * character.beastQuestPerkController.effectPerLevel[30];
		num += (float)character.beastQuest.quirkLevel[31] * character.beastQuestPerkController.effectPerLevel[31];
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num += (float)character.beastQuest.quirkLevel[32] * character.beastQuestPerkController.effectPerLevel[32];
			num += (float)character.beastQuest.quirkLevel[33] * character.beastQuestPerkController.effectPerLevel[33];
			num += (float)character.beastQuest.quirkLevel[34] * character.beastQuestPerkController.effectPerLevel[34];
		}
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.75f)
		{
			num = 0.75f;
		}
		return num;
	}

	public float totalHarvestBonus(int id)
	{
		if (character.yggdrasil.fruits[id].harvests > 0)
		{
			return 1f;
		}
		float num = totalHarvestBonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalHarvestBonus()
	{
		float num = harvest1();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float harvest1()
	{
		float num = 1f;
		num = 1f + (float)character.adventure.itopod.perkLevel[51] * character.adventureController.itopod.effectPerLevel[51];
		if (num > 1.5f)
		{
			num = 1.5f;
		}
		return num;
	}

	public int totalDiggerSlots()
	{
		int num = 0;
		if (character.adventure.itopod.perkLevel[52] >= 1)
		{
			num++;
		}
		if (character.adventure.itopod.perkLevel[53] >= 1)
		{
			num++;
		}
		return num;
	}

	public float ironPillBonus()
	{
		float num = 1f;
		num *= 1f + (float)character.adventure.itopod.perkLevel[84] * character.adventureController.itopod.effectPerLevel[84];
		num *= 1f + (float)character.adventure.itopod.perkLevel[85] * character.adventureController.itopod.effectPerLevel[85];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalQPBonus()
	{
		float num = QP1();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float QP1()
	{
		float num = 1f;
		num = 1f + (float)character.adventure.itopod.perkLevel[89] * character.adventureController.itopod.effectPerLevel[89];
		if (num > 1.1f)
		{
			num = 1.1f;
		}
		return num;
	}

	public float totalQuestDropBonus()
	{
		float num = questDrop1();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float questDrop1()
	{
		return 1f + (float)character.adventure.itopod.perkLevel[90] * character.adventureController.itopod.effectPerLevel[90];
	}

	public float totalRespawnBonus()
	{
		return 1f * respawn1Bonus();
	}

	public float respawn1Bonus()
	{
		return 1f - (float)character.adventure.itopod.perkLevel[93] * character.adventureController.itopod.effectPerLevel[93];
	}

	public string fibPerkUnlocks()
	{
		string text = "\n\n<b>Fibonacci Perk Unlocks:</b>";
		text = ((character.adventure.itopod.perkLevel[94] < 1) ? (text + "\n<b>Level 1: </b>??????") : (text + "\n<b>Level 1: </b>+10% Energy and Magic Power"));
		text = ((character.adventure.itopod.perkLevel[94] < 2) ? (text + "\n<b>Level 2: </b>??????") : (text + "\n<b>Level 2: </b>+10% Energy Cap"));
		text = ((character.adventure.itopod.perkLevel[94] < 3) ? (text + "\n<b>Level 3: </b>??????") : (text + "\n<b>Level 3: </b>+10% Magic Cap"));
		text = ((character.adventure.itopod.perkLevel[94] < 5) ? (text + "\n<b>Level 5: </b>??????") : (text + "\n<b>Level 5: </b>+5% Energy NGU Speed"));
		text = ((character.adventure.itopod.perkLevel[94] < 8) ? (text + "\n<b>Level 8: </b>??????") : (text + "\n<b>Level 8: </b>+5% Magic NGU Speed"));
		text = ((character.adventure.itopod.perkLevel[94] < 13) ? (text + "\n<b>Level 13: </b>??????") : (text + "\n<b>Level 13: </b>+5% PP Earnings"));
		text = ((character.adventure.itopod.perkLevel[94] < 21) ? (text + "\n<b>Level 21: </b>??????") : (text + "\n<b>Level 21: </b>+10% Energy and Magic Bars"));
		text = ((character.adventure.itopod.perkLevel[94] < 34) ? (text + "\n<b>Level 34: </b>??????") : (text + "\n<b>Level 34: </b>13% Adventure Stats"));
		text = ((character.adventure.itopod.perkLevel[94] < 55) ? (text + "\n<b>Level 55: </b>??????") : (text + "\n<b>Level 55: </b>+5% Daycare Speed"));
		text = ((character.adventure.itopod.perkLevel[94] < 89) ? (text + "\n<b>Level 89: </b>??????") : (text + "\n<b>Level 89: </b>+2% Bonus to AP Earnings"));
		text = ((character.adventure.itopod.perkLevel[94] < 144) ? (text + "\n<b>Level 144: </b>??????") : (text + "\n<b>Level 144: </b>+5% Chance for +1 level on Loot!"));
		text = ((character.adventure.itopod.perkLevel[94] < 233) ? (text + "\n<b>Level 233: </b>??????") : (text + "\n<b>Level 233: </b>+10% QP Rewards"));
		text = ((character.adventure.itopod.perkLevel[94] < 377) ? (text + "\n<b>Level 377: </b>??????") : (text + "\n<b>Level 377: </b>377% Attack/Def Multiplier"));
		text = ((character.adventure.itopod.perkLevel[94] < 610) ? (text + "\n<b>Level 610: </b>??????") : (text + "\n<b>Level 610: </b>No More Quest Assignment RNG!"));
		text = ((character.adventure.itopod.perkLevel[94] < 987) ? (text + "\n<b>Level 987: </b> ??????") : (text + "\n<b>Level 987: </b>+5% Bonus EXP Gains"));
		if (character.adventure.itopod.perkLevel[94] >= 1597)
		{
			return text + "\n<b>Level 1597: </b>FIBONACCI KITTY ART";
		}
		return text + "\n<b>Level 1597: </b>?????? (COSMETIC)";
	}

	public float totalWishSpeedBonus()
	{
		return 1f * wish1() * perkEffect(155) * perkEffect(156) * perkEffect(159) * perkEffect(160);
	}

	public float wish1()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		float num = 1f + (float)character.adventure.itopod.perkLevel[108] * character.adventureController.itopod.effectPerLevel[108];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalWishMinReduction()
	{
		return 0f + minWish1() + minWish2();
	}

	public float minWish1()
	{
		float num = character.adventure.itopod.perkLevel[109] * 24;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}

	public float minWish2()
	{
		float num = character.adventure.itopod.perkLevel[110] * 24;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}

	public float sadisticBossMultiplierBonus()
	{
		return 0f + (sadBoss1() + sadBoss2());
	}

	public float sadBoss1()
	{
		if (character.settings.rebirthDifficulty < perkDifficultyReq[157])
		{
			return 0f;
		}
		float num = (float)character.adventure.itopod.perkLevel[157] * 0.0005f;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.005f)
		{
			num = 0.005f;
		}
		return num;
	}

	public float sadBoss2()
	{
		if (character.settings.rebirthDifficulty < perkDifficultyReq[158])
		{
			return 0f;
		}
		float num = (float)character.adventure.itopod.perkLevel[158] * 0.0005f;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.005f)
		{
			num = 0.005f;
		}
		return num;
	}

	public float totalBothNGUSpeedBonus()
	{
		return 1f * ngu1();
	}

	public float ngu1()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[144] >= 1)
		{
			return 1.2f;
		}
		return 1f;
	}

	public float totalAugSpeedBonus()
	{
		return 1f * aug1();
	}

	public float aug1()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 1f;
		}
		if (character.adventure.itopod.perkLevel[144] >= 1)
		{
			return 1.2f;
		}
		return 1f;
	}

	public float totalCardSpeed()
	{
		return 1f * (perkEffect(200) * perkEffect(202) * perkEffect(204) * perkEffect(206));
	}

	public float totalMayoSpeed()
	{
		return 1f * (perkEffect(201) * perkEffect(203) * perkEffect(205) * perkEffect(207));
	}

	public int totalDeckSizeBonus()
	{
		int num = 0;
		num += (int)Math.Min(character.adventure.itopod.perkLevel[208], maxLevel[208]);
		num += (int)Math.Min(character.adventure.itopod.perkLevel[209], maxLevel[209]);
		num += (int)Math.Min(character.adventure.itopod.perkLevel[210], maxLevel[210]);
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public float totalCardTagBonus()
	{
		float num = 0f;
		num += (float)character.adventure.itopod.perkLevel[212] * effectPerLevel[212];
		num += (float)character.adventure.itopod.perkLevel[213] * effectPerLevel[213];
		num += (float)character.adventure.itopod.perkLevel[214] * effectPerLevel[214];
		num += (float)character.adventure.itopod.perkLevel[215] * effectPerLevel[215];
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}
