using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BeastQuestPerkController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public List<BeastQuestPerkUIController> quirkControllers;

	public List<long> maxLevel;

	public List<long> cost;

	public List<string> quirkName;

	public List<bool> hasStatEffect;

	public List<float> effectPerLevel;

	public List<string> quirkDesc;

	public List<difficulty> quirkDifficultyReq;

	public List<Sprite> graphic;

	public List<itopodPerk> quirkType;

	public Text qpDisplay;

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
		if (character.beastQuest.filterDiff)
		{
			filterDifficulty();
		}
		if (character.beastQuest.filterAfford)
		{
			filterAffordable();
		}
		if (character.beastQuest.filterMaxxed)
		{
			filterNotMax();
		}
		orderList();
	}

	public void orderList()
	{
		switch (character.beastQuest.orderType)
		{
		case orderQuirks.SpeedCost:
			orderBaseCost();
			break;
		case orderQuirks.totalCost:
			orderTotalCost();
			break;
		case orderQuirks.Default:
			break;
		}
	}

	public void constructFullList()
	{
		curValidUpgradesList.Clear();
		for (int i = 0; i < character.beastQuest.quirkLevel.Count; i++)
		{
			curValidUpgradesList.Add(i);
		}
	}

	public void filterDifficulty()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			if (quirkDifficultyReq[curValidUpgradesList[i]] > character.settings.rebirthDifficulty)
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
			if (character.beastQuestPerkController.cost[curValidUpgradesList[i]] > character.beastQuest.quirkPoints)
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
			if (character.beastQuest.quirkLevel[curValidUpgradesList[i]] >= character.beastQuestPerkController.maxLevel[curValidUpgradesList[i]])
			{
				curValidUpgradesList.RemoveAt(i);
				i--;
			}
		}
	}

	public void onFilterChange()
	{
		constructList();
		changePage(0);
		updateFilters();
	}

	public void onOrderChange()
	{
		Debug.Log(character.beastQuest.orderType);
		constructList();
		changePage(0);
		updateOrderTypeText();
	}

	public void toggleMaxFilter()
	{
		character.beastQuest.filterMaxxed = !character.beastQuest.filterMaxxed;
		onFilterChange();
	}

	public void toggleAffordFilter()
	{
		character.beastQuest.filterAfford = !character.beastQuest.filterAfford;
		onFilterChange();
	}

	public void toggleDiffFilter()
	{
		character.beastQuest.filterDiff = !character.beastQuest.filterDiff;
		onFilterChange();
	}

	public void advanceOrderType()
	{
		character.beastQuest.orderType = (orderQuirks)((int)(character.beastQuest.orderType + 1) % Enum.GetValues(typeof(orderQuirks)).Length);
		onOrderChange();
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
		if (character.beastQuest.quirkLevel[index] >= maxLevel[index])
		{
			return 0.0;
		}
		num = (maxLevel[index] - character.beastQuest.quirkLevel[index]) * cost[index];
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
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

	public void refreshMenu()
	{
		if (character.menuID != 49)
		{
			return;
		}
		constructList();
		changePage(page);
		for (int i = 0; i < quirkControllers.Count; i++)
		{
			if (quirkControllers[i] != null)
			{
				quirkControllers[i].updateGraphic();
			}
		}
		updateText();
		updateFilters();
		updateOrderTypeText();
	}

	public void updateText()
	{
		if (character.menuID == 49)
		{
			qpDisplay.text = "You have " + character.display(character.beastQuest.quirkPoints);
		}
	}

	public void updateFilters()
	{
		if (character.menuID == 49)
		{
			if (character.beastQuest.filterDiff)
			{
				filterDiffCheckmark.color = Color.white;
			}
			else
			{
				filterDiffCheckmark.color = Color.clear;
			}
			if (character.beastQuest.filterMaxxed)
			{
				filterMaxCheckmark.color = Color.white;
			}
			else
			{
				filterMaxCheckmark.color = Color.clear;
			}
			if (character.beastQuest.filterAfford)
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
		if (character.menuID == 49)
		{
			switch (character.beastQuest.orderType)
			{
			case orderQuirks.Default:
				orderTypeText.text = "Order By:\n<b>DEFAULT</b>";
				break;
			case orderQuirks.SpeedCost:
				orderTypeText.text = "Order By:\n<b>BASE COST</b>";
				break;
			case orderQuirks.totalCost:
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
		for (int i = 0; i < quirkControllers.Count; i++)
		{
			if (num < 0 || num >= curValidUpgradesList.Count)
			{
				quirkControllers[i].id = 100000;
			}
			else
			{
				quirkControllers[i].id = curValidUpgradesList[num];
			}
			num++;
			quirkControllers[i].updateGraphic();
		}
	}

	public long quirkCost(int id)
	{
		if (id < 0 || id > character.beastQuest.quirkLevel.Count)
		{
			return 1000L;
		}
		return cost[id];
	}

	public void addLevel(int id)
	{
		if (id >= 0 && id <= character.beastQuest.quirkLevel.Count && id <= cost.Count && character.beastQuest.quirkPoints >= cost[id])
		{
			character.beastQuest.quirkPoints -= cost[id];
			character.beastQuest.quirkLevel[id]++;
			updateText();
		}
	}

	public float totalQPBonus()
	{
		return totalQPBonus(useConsumable: true);
	}

	public float totalQPBonus(bool useConsumable)
	{
		float num = 1f;
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public void showTooltip(int id)
	{
		if (id < 0 || id > character.beastQuest.quirkLevel.Count)
		{
			return;
		}
		message = "<b>(" + id + ") " + quirkName[id] + "</b>";
		if (quirkDifficultyReq[id] == difficulty.evil)
		{
			message += "\n<color=red><b>EVIL DIFFICULTY QUIRK</b></color>";
		}
		else if (quirkDifficultyReq[id] == difficulty.sadistic)
		{
			message += "\n<color=#57007fff><b>SADISTIC DIFFICULTY QUIRK</b></color>";
		}
		message = message + "\n\n<b>" + quirkDesc[id] + "</b>\n\n";
		if (maxLevel[id] <= 0)
		{
			message = message + "<b>Current level: " + character.beastQuest.quirkLevel[id] + "</b>";
		}
		else if (character.beastQuest.quirkLevel[id] < maxLevel[id])
		{
			message = message + "<b>Current level: " + character.beastQuest.quirkLevel[id] + "/" + maxLevel[id] + "</b>";
		}
		else
		{
			message = message + "<b>Current level: " + character.beastQuest.quirkLevel[id] + " (MAX)</b>";
		}
		if (hasStatEffect[id])
		{
			if (id >= 20 && id <= 34)
			{
				message = message + "\n<b>Current Bonus: " + percentEffectNo100(id, 0) + "%</b>";
			}
			else if (character.beastQuest.quirkLevel[id] < capLevel(id))
			{
				message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
				message = message + "\n<b>Next Level Bonus: " + percentEffect(id, 1) + "%</b>";
			}
			else
			{
				message = message + "\n<b>Current Bonus: " + percentEffect(id, 0) + "%</b>";
			}
		}
		if (cost[id] == 1)
		{
			message = message + "\n<b>COST: " + cost[id] + " Quirk Point</b>";
		}
		else
		{
			message = message + "\n<b>COST: " + character.display(cost[id]) + " Quirk Points</b>";
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
		if (id < 0 || id > character.beastQuest.quirkLevel.Count)
		{
			return 1f;
		}
		return 1f + (float)(character.beastQuest.quirkLevel[id] + offset) * effectPerLevel[id];
	}

	public long levelEffect(int id, int offset)
	{
		if (id < 0 || id > character.beastQuest.quirkLevel.Count)
		{
			return 0L;
		}
		return (long)((float)(character.beastQuest.quirkLevel[id] + offset) * effectPerLevel[id]);
	}

	public void tryLevelUp(int id)
	{
		if (id >= 0 && id <= character.beastQuest.quirkLevel.Count)
		{
			if (character.beastQuest.quirkLevel[id] >= capLevel(id))
			{
				tooltip.showTooltip("Hey this Quirk is at the MAX level, can't you read? Jeez.", 2f);
			}
			else if (character.beastQuest.quirkPoints < quirkCost(id))
			{
				tooltip.showTooltip("Hey math genius, you don't have enough QP to level this Quirk up!", 2f);
			}
			else if (character.settings.rebirthDifficulty < quirkDifficultyReq[id])
			{
				tooltip.showOverrideTooltip(string.Concat("You can't buy this Quirk until you move to ", quirkDifficultyReq[id], " difficulty!"), 2f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Res3 && !character.res3.res3On)
			{
				tooltip.showTooltip("Psst. You don't have Resource 3 yet. In fact, Resource 3 is classified information so I have to neuralyze you now. You won't remember this. ", 3f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Cards && !character.cards.cardsOn)
			{
				tooltip.showTooltip("Psst. You don't have Cards yet. In fact, Cards are classified information so I have to neuralyze you now. You won't remember this. ", 3f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Wishes && !character.wishes.wishesOn)
			{
				tooltip.showTooltip("Psst. You don't have Wishes yet. In fact, Wishes is classified information so I have to neuralyze you now. You won't remember this.", 3f);
			}
			else
			{
				doLevelUp(id);
			}
		}
	}

	public void doLevelUp(int id)
	{
		character.beastQuest.quirkPoints -= quirkCost(id);
		character.beastQuest.quirkLevel[id]++;
		doEffect(id);
		showTooltip(id);
		updateText();
	}

	public void tryLevelAll(int id)
	{
		if (id >= 0 && id <= character.beastQuest.quirkLevel.Count)
		{
			if (character.beastQuest.quirkLevel[id] >= capLevel(id))
			{
				tooltip.showTooltip("Hey this quirk is at the MAX level, can't you read? Jeez.", 2f);
			}
			else if (character.beastQuest.quirkPoints < quirkCost(id))
			{
				tooltip.showTooltip("Hey math genius, you don't have enough QP to level this Quirk up even once!", 2f);
			}
			else if (character.settings.rebirthDifficulty < quirkDifficultyReq[id])
			{
				tooltip.showOverrideTooltip(string.Concat("You can't buy this Quirk until you move to ", quirkDifficultyReq[id], " difficulty!"), 2f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Res3 && !character.res3.res3On)
			{
				tooltip.showTooltip("Psst. You don't have Resource 3 yet. In fact, Resource 3 is classified information so I have to neuralyze you now. You won't remember this. ", 3f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Cards && !character.cards.cardsOn)
			{
				tooltip.showTooltip("Psst. You don't have Cards yet. In fact, Cards are classified information so I have to neuralyze you now. You won't remember this. ", 3f);
			}
			else if (character.beastQuestPerkController.quirkType[id] == itopodPerk.Wishes && !character.wishes.wishesOn)
			{
				tooltip.showTooltip("Psst. You don't have Wishes yet. In fact, Wishes is classified information so I have to neuralyze you now. You won't remember this.", 3f);
			}
			else
			{
				doLevelAll(id);
			}
		}
	}

	public void doLevelAll(int id)
	{
		while (character.beastQuest.quirkLevel[id] < maxLevel[id] && character.beastQuest.quirkPoints >= quirkCost(id))
		{
			character.beastQuest.quirkPoints -= quirkCost(id);
			character.beastQuest.quirkLevel[id]++;
			doEffect(id);
		}
		showTooltip(id);
		updateText();
	}

	public void doEffect(int id)
	{
		if (id >= 0 && id <= character.beastQuest.quirkLevel.Count)
		{
			switch (id)
			{
			case 18:
				character.inventoryController.updateAccCount();
				break;
			case 19:
				character.inventoryController.updateMacguffinCount();
				break;
			case 50:
				character.inventoryController.updateMacguffinCount();
				break;
			case 90:
				character.inventoryController.updateInvCount();
				break;
			}
		}
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public float quirkEffect(int id)
	{
		if (character.settings.rebirthDifficulty < quirkDifficultyReq[id])
		{
			return 1f;
		}
		float num = 1f + (float)character.beastQuest.quirkLevel[id] * effectPerLevel[id];
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalEnergyPowerBonus()
	{
		float num = energyPower1Bonus() * energyPower2Bonus() * energyPower3Bonus() * quirkEffect(61) * quirkEffect(80) * quirkEffect(177);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyPower1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[0] * effectPerLevel[0];
	}

	public float energyPower2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[35] * effectPerLevel[35];
	}

	public float energyPower3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[41] * effectPerLevel[41];
	}

	public float totalEnergyCapBonus()
	{
		float num = energyCap1Bonus() * energyCap2Bonus() * energyCap3Bonus() * quirkEffect(62) * quirkEffect(81) * quirkEffect(178);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyCap1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[1] * effectPerLevel[1];
	}

	public float energyCap2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[36] * effectPerLevel[36];
	}

	public float energyCap3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[42] * effectPerLevel[42];
	}

	public float totalEnergyBarBonus()
	{
		float num = energyBar1Bonus() * energyBar2Bonus() * energyBar3Bonus() * quirkEffect(63) * quirkEffect(82) * quirkEffect(179);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyBar1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[2] * effectPerLevel[2];
	}

	public float energyBar2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[37] * effectPerLevel[37];
	}

	public float energyBar3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[43] * effectPerLevel[43];
	}

	public float totalMagicPowerBonus()
	{
		float num = magicPower1Bonus() * magicPower2Bonus() * magicPower3Bonus() * quirkEffect(64) * quirkEffect(83) * quirkEffect(180);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicPower1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[3] * effectPerLevel[3];
	}

	public float magicPower2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[38] * effectPerLevel[38];
	}

	public float magicPower3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[44] * effectPerLevel[44];
	}

	public float totalMagicCapBonus()
	{
		float num = magicCap1Bonus() * magicCap2Bonus() * magicCap3Bonus() * quirkEffect(65) * quirkEffect(84) * quirkEffect(181);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicCap1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[4] * effectPerLevel[4];
	}

	public float magicCap2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[39] * effectPerLevel[39];
	}

	public float magicCap3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[45] * effectPerLevel[45];
	}

	public float totalMagicBarBonus()
	{
		float num = magicBar1Bonus() * magicBar2Bonus() * magicBar3Bonus() * quirkEffect(66) * quirkEffect(85) * quirkEffect(182);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicBar1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[5] * effectPerLevel[5];
	}

	public float magicBar2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[40] * effectPerLevel[40];
	}

	public float magicBar3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[46] * effectPerLevel[46];
	}

	public float totalRes3PowerBonus()
	{
		float num = res3PowerBonus1() * quirkEffect(67) * quirkEffect(86) * quirkEffect(183);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3PowerBonus1()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[47] * effectPerLevel[47];
	}

	public float totalRes3CapBonus()
	{
		float num = res3CapBonus1() * quirkEffect(68) * quirkEffect(87) * quirkEffect(184);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3CapBonus1()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[48] * effectPerLevel[48];
	}

	public float totalRes3BarBonus()
	{
		float num = res3BarBonus1() * quirkEffect(69) * quirkEffect(88) * quirkEffect(185);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float res3BarBonus1()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[49] * effectPerLevel[49];
	}

	public float totalStatBonus()
	{
		float num = statBoost1Bonus() * statBoost2Bonus() * quirkEffect(76) * quirkEffect(78) * quirkEffect(170) * quirkEffect(172);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float statBoost1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[7] * effectPerLevel[7];
	}

	public float statBoost2Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[51] * effectPerLevel[51];
	}

	public float totalAdventureBonus()
	{
		float num = adventure1Bonus() * adventure2Bonus() * adventure3Bonus() * quirkEffect(77) * quirkEffect(79) * quirkEffect(171) * quirkEffect(173);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float adventure1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[6] * effectPerLevel[6];
	}

	public float adventure2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[8] * effectPerLevel[8];
	}

	public float adventure3Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[52] * effectPerLevel[52];
	}

	public float totalGoldBonus()
	{
		float num = gold1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float gold1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[9] * effectPerLevel[9];
	}

	public float totalBeardSpeedBonus()
	{
		float num = beard1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float beard1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[10] * effectPerLevel[10];
	}

	public float totalBoostBonus()
	{
		float num = boost1Bonus() * boost2Bonus() * quirkEffect(72) * quirkEffect(73);
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float boost1Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[11] * effectPerLevel[11];
	}

	public float boost2Bonus()
	{
		return 1f + (float)character.beastQuest.quirkLevel[53] * effectPerLevel[53];
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
		return 1f + (float)character.beastQuest.quirkLevel[12] * effectPerLevel[12];
	}

	public float totalEnergyWandoosBonus()
	{
		float num = energyWandoos1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float energyWandoos1Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[15] * effectPerLevel[15];
	}

	public float totalMagicWandoosBonus()
	{
		float num = magicWandoos1Bonus();
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float magicWandoos1Bonus()
	{
		if (character.settings.rebirthDifficulty < difficulty.evil)
		{
			return 1f;
		}
		return 1f + (float)character.beastQuest.quirkLevel[16] * effectPerLevel[16];
	}

	public float totalWishMinReduction()
	{
		return 0f + minWish1();
	}

	public float minWish1()
	{
		float num = character.beastQuest.quirkLevel[54] * 24;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}

	public long totalBasePPBonus()
	{
		return basePP1();
	}

	public long basePP1()
	{
		if (character.settings.rebirthDifficulty < difficulty.sadistic)
		{
			return 0L;
		}
		return character.beastQuest.quirkLevel[70] * 10;
	}

	public float sadisticBossMultiplierBonus()
	{
		return 0f + (sadBoss1() + sadBoss2());
	}

	public float sadBoss1()
	{
		if (character.settings.rebirthDifficulty < quirkDifficultyReq[74])
		{
			return 0f;
		}
		float num = (float)character.beastQuest.quirkLevel[74] * 0.001f;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.01f)
		{
			num = 0.01f;
		}
		return num;
	}

	public float sadBoss2()
	{
		if (character.settings.rebirthDifficulty < quirkDifficultyReq[75])
		{
			return 0f;
		}
		float num = (float)character.beastQuest.quirkLevel[75] * 0.001f;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 0.01f)
		{
			num = 0.01f;
		}
		return num;
	}

	public int totalInventorySpaces()
	{
		int num = 0;
		num += (int)character.beastQuest.quirkLevel[90];
		if (num > 24)
		{
			num = 24;
		}
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public float totalYggYieldBonus()
	{
		return ygg1();
	}

	public float ygg1()
	{
		return quirkEffect(92);
	}

	public float totalBloodGainBonus()
	{
		return blood1();
	}

	public float blood1()
	{
		return quirkEffect(91);
	}

	public float totalEnergyNGUSpeed()
	{
		return 1f * (quirkEffect(93) * quirkEffect(95) * quirkEffect(97));
	}

	public float totalMagicNGUSpeed()
	{
		return 1f * (quirkEffect(94) * quirkEffect(96) * quirkEffect(98));
	}

	public float totalCardSpeed()
	{
		return 1f * (quirkEffect(138) * quirkEffect(140) * quirkEffect(142) * quirkEffect(144));
	}

	public float totalMayoSpeed()
	{
		return 1f * (quirkEffect(139) * quirkEffect(141) * quirkEffect(143) * quirkEffect(145));
	}

	public int totalDeckSizeBonus()
	{
		int num = 0;
		num += (int)Math.Min(character.beastQuest.quirkLevel[146], maxLevel[146]);
		num += (int)Math.Min(character.beastQuest.quirkLevel[147], maxLevel[147]);
		num += (int)Math.Min(character.beastQuest.quirkLevel[148], maxLevel[148]);
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public float totalCardTagBonus()
	{
		float num = 0f;
		num += character.beastQuestPerkController.effectPerLevel[152] * (float)character.beastQuest.quirkLevel[152];
		num += character.beastQuestPerkController.effectPerLevel[153] * (float)character.beastQuest.quirkLevel[153];
		num += character.beastQuestPerkController.effectPerLevel[154] * (float)character.beastQuest.quirkLevel[154];
		num += character.beastQuestPerkController.effectPerLevel[155] * (float)character.beastQuest.quirkLevel[155];
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}
