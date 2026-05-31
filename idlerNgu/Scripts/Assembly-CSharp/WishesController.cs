using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WishesController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public List<WishProperties> properties;

	public List<WishPodUIController> pods;

	public List<Button> pageButtons;

	public Sprite dimBorder;

	public Sprite whiteBorder;

	public Sprite goldBorder;

	public Sprite greenBorder;

	public Sprite wishOnIcon;

	public Sprite wishWarningIcon;

	public Text wishPodTitle;

	public Text wishPodText;

	public Text energyPodText;

	public Text magicPodText;

	public Text res3PodText;

	public Text res3PodTitle;

	public Text wishSlotsUsed;

	public Text filterTypeText;

	public Text orderTypeText;

	public Image filterDiffCheckmark;

	public Image filterAffordCheckmark;

	public Image filterMaxCheckmark;

	private Dictionary<int, double> dictDouble = new Dictionary<int, double>();

	public List<int> curValidUpgradesList = new List<int>();

	public int pageID;

	public int curSelectedWish;

	public void Start()
	{
		constructList();
		InvokeRepeating("updateAllWishes", 0f, 0.02f);
		InvokeRepeating("updateAllBars", 0f, 1f);
		InvokeRepeating("updateWishPodText", 0f, 1f);
		changePage(0);
	}

	public void constructList()
	{
		dictDouble.Clear();
		constructFullList();
		if (character.wishes.filterDiff)
		{
			filterDifficulty();
		}
		if (character.wishes.filterAfford)
		{
			filterAffordable();
		}
		if (character.wishes.filterMaxxed)
		{
			filterNotMax();
		}
		orderList();
	}

	public void orderList()
	{
		switch (character.wishes.orderType)
		{
		case orderWish.SpeedCost:
			orderBaseCost();
			break;
		case orderWish.totalCost:
			orderTotalCost();
			break;
		case orderWish.Default:
			break;
		}
	}

	public void constructFullList()
	{
		curValidUpgradesList.Clear();
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			curValidUpgradesList.Add(i);
		}
	}

	public void filterDifficulty()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
			if (properties[curValidUpgradesList[i]].difficultyRequirement > character.settings.rebirthDifficulty)
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
			if (progressPerTickMax(curValidUpgradesList[i]) <= 0f)
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
			if (character.wishes.wishes[curValidUpgradesList[i]].level >= properties[curValidUpgradesList[i]].maxLevel)
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
			dictDouble.Add(curValidUpgradesList[i], properties[curValidUpgradesList[i]].wishSpeedDivider);
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
		if (character.wishes.wishes[index].level >= properties[index].maxLevel)
		{
			return 0.0;
		}
		double num2 = character.wishes.wishes[index].level;
		double num3 = properties[index].maxLevel;
		double num4 = properties[index].wishSpeedDivider;
		num = 0.5 * num4 * (num3 - num2) * (num3 + num2 + 1.0);
		if (num < 0.0)
		{
			num = 0.0;
		}
		return num;
	}

	public void onFilterChange()
	{
		constructList();
		changePage(0);
		updateFilters();
		updatePageButtons();
	}

	public void onOrderChange()
	{
		constructList();
		changePage(0);
		updateOrderTypeText();
	}

	public void updatePageButtons()
	{
		int num = Mathf.Min(Mathf.CeilToInt((float)curValidUpgradesList.Count / (float)pods.Count), pageButtons.Count);
		int i;
		for (i = 0; i < num; i++)
		{
			pageButtons[i].gameObject.SetActive(value: true);
		}
		for (; i < pageButtons.Count; i++)
		{
			pageButtons[i].gameObject.SetActive(value: false);
		}
	}

	public void toggleMaxFilter()
	{
		character.wishes.filterMaxxed = !character.wishes.filterMaxxed;
		onFilterChange();
	}

	public void toggleAffordFilter()
	{
		character.wishes.filterAfford = !character.wishes.filterAfford;
		onFilterChange();
	}

	public void toggleDiffFilter()
	{
		character.wishes.filterDiff = !character.wishes.filterDiff;
		onFilterChange();
	}

	public void advanceOrderType()
	{
		character.wishes.orderType = (orderWish)((int)(character.wishes.orderType + 1) % Enum.GetValues(typeof(orderWish)).Length);
		onOrderChange();
	}

	public void debugList()
	{
		for (int i = 0; i < curValidUpgradesList.Count; i++)
		{
		}
	}

	public bool invalidID(int id)
	{
		if (id >= 0)
		{
			return id >= character.wishes.wishes.Count;
		}
		return true;
	}

	public void updateAllWishes()
	{
		if (!character.wishes.wishesOn)
		{
			return;
		}
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			if (invalidID(i) || !(progressPerTick(i) > 0f) || character.wishes.wishes[i].level >= maxWishLevel(i))
			{
				continue;
			}
			character.wishes.wishes[i].progress += progressPerTick(i);
			if (character.wishes.wishes[i].progress >= 1f)
			{
				character.wishes.wishes[i].level++;
				character.wishes.wishes[i].progress = 0f;
				doLevelupEffect(i, character.wishes.wishes[i].level);
				if (character.wishes.wishes[i].level >= maxWishLevel(i))
				{
					removeAllResources(i);
				}
				updatebyID(i);
			}
		}
	}

	public void testLevelup(int id)
	{
		if (character.wishes.wishes[id].level < maxWishLevel(id))
		{
			character.wishes.wishes[id].level++;
			doLevelupEffect(id, character.wishes.wishes[id].level);
		}
	}

	public void doLevelupEffect(int id, int level)
	{
		switch (id)
		{
		case 4:
			if (character.wandoos98.pitOSLevels < 100)
			{
				character.wandoos98.pitOSLevels = 100L;
			}
			break;
		case 7:
			character.inventoryController.updateInvCount();
			break;
		case 22:
			character.inventoryController.updateInvCount();
			break;
		case 26:
			if (level >= 1)
			{
				character.portraits.portraitUnlocked[43] = true;
			}
			break;
		case 44:
			if (level >= 1)
			{
				character.inventory.unlockedKittyArt[10] = true;
			}
			break;
		case 57:
			character.inventoryController.updateInvCount();
			break;
		case 75:
			if (level >= 1)
			{
				character.portraits.portraitUnlocked[44] = true;
			}
			break;
		case 109:
			character.inventoryController.updateAccCount();
			break;
		case 202:
			if (level >= 1)
			{
				character.portraits.portraitUnlocked[56] = true;
			}
			break;
		}
	}

	public int curWishSlots()
	{
		int num = 1;
		if (character.challenges.trollChallenge.curEvilCompletions >= 7)
		{
			num++;
		}
		if (character.inventory.itemList.pinkHeartComplete)
		{
			num++;
		}
		if (character.beastQuest.quirkLevel[56] >= 1)
		{
			num++;
		}
		if (num > 4)
		{
			num = 4;
		}
		return num;
	}

	public int numAllocatedWishes()
	{
		int num = 0;
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			if (character.wishes.wishes[i].energy > 0 || character.wishes.wishes[i].magic > 0 || character.wishes.wishes[i].res3 > 0)
			{
				num++;
			}
		}
		return num;
	}

	public void changePage(int newPage)
	{
		int num = newPage * pods.Count;
		for (int i = 0; i < pods.Count; i++)
		{
			if (num < 0 || num >= curValidUpgradesList.Count)
			{
				pods[i].id = 100000;
			}
			else
			{
				pods[i].id = curValidUpgradesList[num];
			}
			num++;
			pods[i].updatePod();
		}
	}

	public void updatebyID(int id)
	{
		for (int i = 0; i < pods.Count; i++)
		{
			if (!pods[i].invalidID() && pods[i].id == id)
			{
				pods[i].updatePod();
			}
		}
	}

	public void updateAllBars()
	{
		if (character.menuID != 53)
		{
			return;
		}
		for (int i = 0; i < pods.Count; i++)
		{
			if (!pods[i].invalidID() && progressPerTick(i) > 0f && character.wishes.wishes[i].level < maxWishLevel(i))
			{
				pods[i].updateBar();
			}
		}
	}

	public void updateMenu()
	{
		if (character.menuID == 53)
		{
			constructList();
			changePage(pageID);
			updatePageButtons();
			updateAllPods();
			updateText();
			updateFilters();
			updateOrderTypeText();
		}
	}

	public void updateAllPods()
	{
		for (int i = 0; i < pods.Count; i++)
		{
			pods[i].updatePod();
		}
	}

	public void updateText()
	{
		if (character.menuID == 53)
		{
			updateWishPodText();
			updateEnergyPodText();
			updateMagicPodText();
			updateRes3PodText();
			updateWishSlotText();
		}
	}

	public void updateWishPodText()
	{
		if (character.menuID == 53)
		{
			wishPodTitle.text = "<b>" + properties[curSelectedWish].wishName + "</b>";
			Text text = wishPodTitle;
			text.text = text.text + "\n\n<b>Level: </b>" + character.wishes.wishes[curSelectedWish].level + "/" + properties[curSelectedWish].maxLevel;
			Text text2 = wishPodTitle;
			text2.text = text2.text + "\n<b>Time to next Level: </b>" + timeToLevel(curSelectedWish);
		}
	}

	public void updateEnergyPodText()
	{
		if (character.menuID == 53 && !invalidID(curSelectedWish))
		{
			energyPodText.text = "<b>" + character.display(character.wishes.wishes[curSelectedWish].energy) + "</b>";
		}
	}

	public void updateMagicPodText()
	{
		if (character.menuID == 53 && !invalidID(curSelectedWish))
		{
			magicPodText.text = "<b>" + character.display(character.wishes.wishes[curSelectedWish].magic) + "</b>";
		}
	}

	public void updateRes3PodText()
	{
		if (character.menuID == 53 && !invalidID(curSelectedWish))
		{
			res3PodTitle.text = "<b>" + character.res3.res3Name + " Allocated</b>";
			res3PodText.text = "<b>" + character.display(character.wishes.wishes[curSelectedWish].res3) + "</b>";
		}
	}

	public void updateWishSlotText()
	{
		if (character.menuID == 53)
		{
			wishSlotsUsed.text = "Wish Slots:\n" + numAllocatedWishes() + "/" + curWishSlots();
		}
	}

	public void updateFilters()
	{
		if (character.menuID == 53)
		{
			if (character.wishes.filterDiff)
			{
				filterDiffCheckmark.color = Color.white;
			}
			else
			{
				filterDiffCheckmark.color = Color.clear;
			}
			if (character.wishes.filterMaxxed)
			{
				filterMaxCheckmark.color = Color.white;
			}
			else
			{
				filterMaxCheckmark.color = Color.clear;
			}
			if (character.wishes.filterAfford)
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
		if (character.menuID == 53)
		{
			switch (character.wishes.orderType)
			{
			case orderWish.Default:
				orderTypeText.text = "Order By:\n<b>DEFAULT</b>";
				break;
			case orderWish.SpeedCost:
				orderTypeText.text = "Order By:\n<b>BASE COST</b>";
				break;
			case orderWish.totalCost:
				orderTypeText.text = "Order By:\n<b>TOTAL COST</b>";
				break;
			default:
				orderTypeText.text = "Order by:\n<b>DEFAULT</b>";
				break;
			}
		}
	}

	public void removeAllResources()
	{
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			removeAllEnergy(i);
			removeAllMagic(i);
			removeAllRes3(i);
		}
	}

	public void removeAllResources(int id)
	{
		removeAllEnergy(id);
		removeAllMagic(id);
		removeAllRes3(id);
	}

	public void removeAllEnergy()
	{
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			removeAllEnergy(i);
		}
	}

	public void removeAllEnergy(int id)
	{
		if (!invalidID(id) && character.wishes.wishes[id].energy > 0)
		{
			long energy = character.wishes.wishes[id].energy;
			character.idleEnergy += energy;
			character.wishes.wishes[id].energy -= energy;
		}
	}

	public void removeAllMagic()
	{
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			removeAllMagic(i);
		}
	}

	public void removeAllMagic(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			if (character.wishes.wishes[id].magic > 0)
			{
				long magic = character.wishes.wishes[id].magic;
				character.magic.idleMagic += magic;
				character.wishes.wishes[id].magic -= magic;
			}
		}
	}

	public void removeAllRes3()
	{
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			removeAllRes3(i);
		}
	}

	public void clearSelectedWish()
	{
		if (!invalidID(curSelectedWish))
		{
			removeAllEnergy(curSelectedWish);
			removeAllMagic(curSelectedWish);
			removeAllRes3(curSelectedWish);
			updateText();
			updatebyID(curSelectedWish);
		}
	}

	public void removeAllRes3(int id)
	{
		if (!invalidID(id) && character.wishes.wishes[id].res3 > 0)
		{
			long res = character.wishes.wishes[id].res3;
			character.res3.idleRes3 += res;
			character.wishes.wishes[id].res3 -= res;
		}
	}

	public void showWishTooltip(int id)
	{
		if (!invalidID(id))
		{
			string text = "";
			text = text + "<b>(" + id + ") " + properties[id].wishName + difficultyString(properties[id].difficultyRequirement) + "\n\n" + properties[id].WishDesc + "</b>";
			if (character.wishes.wishes[id].level < maxWishLevel(id))
			{
				text = text + "\n<b>Current Level: " + character.wishes.wishes[id].level;
				text = text + "</b>\n<b>Max Level: " + maxWishLevel(id) + "</b>";
				text = text + "\n\n<b>Time to next Level: </b>" + timeToLevel(id);
			}
			else
			{
				text = text + "\n<b>Current Level: " + character.wishes.wishes[id].level + "(MAX)</b>";
			}
			tooltip.showTooltip(text);
		}
	}

	public string difficultyString(difficulty diff)
	{
		switch (diff)
		{
		case difficulty.evil:
			return "\n<b><color=red>" + diff.ToString().ToUpper() + " DIFFICULTY WISH</color></b>";
		case difficulty.sadistic:
			return "\n<b><color=#57007fff>" + diff.ToString().ToUpper() + " DIFFICULTY WISH</color></b>";
		default:
			return "\n<b>" + diff.ToString().ToUpper() + " DIFFICULTY WISH</b>";
		}
	}

	public void reset()
	{
		for (int i = 0; i < character.wishes.wishes.Count; i++)
		{
			character.wishes.wishes[i].reset();
		}
	}

	public long maxWishLevel(int id)
	{
		if (invalidID(id))
		{
			return 0L;
		}
		return properties[id].maxLevel;
	}

	public float rawProgressPerTick(int id)
	{
		if (invalidID(id))
		{
			return 0f;
		}
		return energyFactor(id) * magicFactor(id) * res3Factor(id) * totalWishSpeedBonuses() / wishSpeedDivider(id);
	}

	public float rawProgressPerTickMax(int id)
	{
		if (invalidID(id))
		{
			return 0f;
		}
		return energyFactorMax(id) * magicFactorMax(id) * res3FactorMax(id) * totalWishSpeedBonuses() / wishSpeedDivider(id);
	}

	public float totalWishSpeedBonuses()
	{
		float num = 1f;
		num *= 1f + character.inventoryController.bonuses[specType.WishSpeed] + character.inventoryController.cubeWishBonus();
		num *= character.adventureController.itopod.totalWishSpeedBonus();
		num *= character.hacksController.totalWishSpeedBonus();
		num *= character.cardsController.getBonus(cardBonus.wishSpeed);
		if (character.arbitrary.wishSpeedBoster)
		{
			num *= 1.25f;
		}
		if (character.inventory.itemList.typoComplete)
		{
			num *= 1.2f;
		}
		if (character.inventory.itemList.severedHeadComplete)
		{
			num *= 1.1337f;
		}
		return num * totalWishBonus();
	}

	public float minimumWishTime()
	{
		float num = 14400f;
		num -= character.adventureController.itopod.totalWishMinReduction();
		num -= character.beastQuestPerkController.totalWishMinReduction();
		return 1f / (num * 50f);
	}

	public float progressPerTick(int id)
	{
		if (invalidID(id))
		{
			return 0f;
		}
		float num = rawProgressPerTick(id);
		if ((double)num < 1E-08)
		{
			return 0f;
		}
		return Math.Min(minimumWishTime(), num);
	}

	public float progressPerTickMax(int id)
	{
		float num = rawProgressPerTickMax(id);
		if ((double)num < 1E-08)
		{
			return 0f;
		}
		return Math.Min(minimumWishTime(), num);
	}

	public string timeToLevel(int id)
	{
		if (invalidID(id))
		{
			return "Invalid wish detected. 4G screwed up once again!";
		}
		if (character.wishes.wishes[id].level >= maxWishLevel(id))
		{
			return "N/A";
		}
		if (character.wishes.wishes[id].energy == 0L || character.wishes.wishes[id].magic == 0L || character.wishes.wishes[id].res3 == 0L)
		{
			if (progressPerTickMax(id) == 0f)
			{
				return " INFINITY TIME :c";
			}
			return NumberOutput.timeOutput((1f - character.wishes.wishes[id].progress) / progressPerTickMax(id) / 50f) + " (at max resources allocated)";
		}
		if (progressPerTick(id) == 0f)
		{
			return " INFINITY TIME :c";
		}
		return NumberOutput.timeOutput((1f - character.wishes.wishes[id].progress) / progressPerTick(id) / 50f);
	}

	public float wishSpeedDivider(int id)
	{
		return properties[id].wishSpeedDivider * (float)(character.wishes.wishes[id].level + 1);
	}

	public float energyFactor(int id)
	{
		return Mathf.Pow(character.totalEnergyPower() * (float)character.wishes.wishes[id].energy, energyBias(id));
	}

	public float energyFactorMax(int id)
	{
		return Mathf.Pow(character.totalEnergyPower() * (float)character.totalCapEnergy(), energyBias(id));
	}

	public float energyBias(int id)
	{
		return 0.17f;
	}

	public float magicFactor(int id)
	{
		return Mathf.Pow(character.totalMagicPower() * (float)character.wishes.wishes[id].magic, magicBias(id));
	}

	public float magicFactorMax(int id)
	{
		return Mathf.Pow(character.totalMagicPower() * (float)character.totalCapMagic(), magicBias(id));
	}

	public float magicBias(int id)
	{
		return 0.17f;
	}

	public float res3Factor(int id)
	{
		return Mathf.Pow(character.totalRes3Power() * (float)character.wishes.wishes[id].res3, res3Bias(id));
	}

	public float res3FactorMax(int id)
	{
		return Mathf.Pow(character.totalRes3Power() * (float)character.totalCapRes3(), res3Bias(id));
	}

	public float res3Bias(int id)
	{
		return 0.17f;
	}

	public void selectNewWish(int id)
	{
		if (!invalidID(id))
		{
			int id2 = curSelectedWish;
			curSelectedWish = id;
			updatebyID(id2);
			updatebyID(id);
			updateText();
		}
	}

	public void addEnergy()
	{
		addEnergy(curSelectedWish);
	}

	public void removeEnergy()
	{
		removeEnergy(curSelectedWish);
	}

	public void displayLockedMessage(int id)
	{
		switch (id)
		{
		case 28:
			tooltip.showOverrideTooltip("You need to complete Evil Troll Challenge #4 to research this Wish!", 4f);
			break;
		case 45:
			tooltip.showOverrideTooltip("You need to complete Evil Troll Challenge #6 to research this Wish!", 2f);
			break;
		default:
			tooltip.showOverrideTooltip("This wish is currently locked!", 2f);
			break;
		}
	}

	public void addEnergy(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		if (wishLocked(id))
		{
			displayLockedMessage(id);
			return;
		}
		if (properties[id].difficultyRequirement > character.settings.rebirthDifficulty)
		{
			tooltip.showOverrideTooltip(string.Concat("You need to move to at least ", properties[id].difficultyRequirement, " difficulty to research this Wish!"), 2f);
			return;
		}
		if (character.wishes.wishes[id].energy == 0L && character.wishes.wishes[id].magic == 0L && character.wishes.wishes[id].res3 == 0L && numAllocatedWishes() >= curWishSlots())
		{
			tooltip.showOverrideTooltip("You already have resources allocated to your maximum number of wish slots! Go remove resources from a different wish!", 2f);
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.idleEnergy)
		{
			num = character.idleEnergy;
		}
		character.wishes.wishes[id].energy += num;
		character.idleEnergy -= num;
		updatebyID(id);
		updateEnergyPodText();
		updateWishSlotText();
	}

	public bool wishLocked(int id)
	{
		if (invalidID(id))
		{
			return true;
		}
		if (id == 28 && character.challenges.trollChallenge.curEvilCompletions < 4)
		{
			return true;
		}
		if (id == 45 && character.challenges.trollChallenge.curEvilCompletions < 6)
		{
			return true;
		}
		return false;
	}

	public void addMagic()
	{
		addMagic(curSelectedWish);
	}

	public void removeMagic()
	{
		removeMagic(curSelectedWish);
	}

	public void addMagic(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		if (wishLocked(id))
		{
			displayLockedMessage(id);
			return;
		}
		if (properties[id].difficultyRequirement > character.settings.rebirthDifficulty)
		{
			tooltip.showOverrideTooltip(string.Concat("You need to move to at least ", properties[id].difficultyRequirement, " difficulty to research this Wish!"), 2f);
			return;
		}
		if (character.wishes.wishes[id].energy == 0L && character.wishes.wishes[id].magic == 0L && character.wishes.wishes[id].res3 == 0L && numAllocatedWishes() >= curWishSlots())
		{
			tooltip.showOverrideTooltip("You already have resources allocated to your maximum number of wish slots! Go remove resources from a different wish!", 2f);
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.magic.idleMagic)
		{
			num = character.magic.idleMagic;
		}
		character.wishes.wishes[id].magic += num;
		character.magic.idleMagic -= num;
		updatebyID(id);
		updateMagicPodText();
		updateWishSlotText();
	}

	public void addRes3()
	{
		addRes3(curSelectedWish);
	}

	public void removeRes3()
	{
		removeRes3(curSelectedWish);
	}

	public void addRes3(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		if (wishLocked(id))
		{
			displayLockedMessage(id);
			return;
		}
		if (properties[id].difficultyRequirement > character.settings.rebirthDifficulty)
		{
			tooltip.showOverrideTooltip(string.Concat("You need to move to at least ", properties[id].difficultyRequirement, " difficulty to research this Wish!"), 2f);
			return;
		}
		if (character.wishes.wishes[id].energy == 0L && character.wishes.wishes[id].magic == 0L && character.wishes.wishes[id].res3 == 0L && numAllocatedWishes() >= curWishSlots())
		{
			tooltip.showOverrideTooltip("You already have resources allocated to your maximum number of wish slots! Go remove resources from a different wish!", 2f);
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.res3.idleRes3)
		{
			num = character.res3.idleRes3;
		}
		character.wishes.wishes[id].res3 += num;
		character.res3.idleRes3 -= num;
		updatebyID(id);
		updateRes3PodText();
		updateWishSlotText();
	}

	public void removeEnergy(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.wishes.wishes[id].energy)
		{
			num = character.wishes.wishes[id].energy;
		}
		character.wishes.wishes[id].energy -= num;
		character.idleEnergy += num;
		updatebyID(id);
		updateEnergyPodText();
		updateWishSlotText();
	}

	public void removeMagic(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.wishes.wishes[id].magic)
		{
			num = character.wishes.wishes[id].magic;
		}
		character.wishes.wishes[id].magic -= num;
		character.magic.idleMagic += num;
		updatebyID(id);
		updateMagicPodText();
		updateWishSlotText();
	}

	public void removeRes3(int id)
	{
		if (invalidID(id))
		{
			return;
		}
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.wishes.wishes[id].res3)
		{
			num = character.wishes.wishes[id].res3;
		}
		character.wishes.wishes[id].res3 -= num;
		character.res3.idleRes3 += num;
		updatebyID(id);
		updateRes3PodText();
		updateWishSlotText();
	}

	public void manuallyRemoveAll()
	{
		removeAllResources();
		updateAllPods();
		updateText();
	}

	public float wishEffect(int id)
	{
		if (character.settings.rebirthDifficulty < properties[id].difficultyRequirement)
		{
			return 1f;
		}
		float num = 1f + (float)character.wishes.wishes[id].level * properties[id].effectPerLevel;
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalStatBonus()
	{
		return 1f * statBonus1() * wishEffect(5) * wishEffect(30) * wishEffect(105) * wishEffect(106) * wishEffect(189) * wishEffect(191) * wishEffect(192) * wishEffect(219);
	}

	public float statBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 2f;
	}

	public float totalAdventureBonus()
	{
		return 1f * adventureBonus1() * wishEffect(6) * wishEffect(29) * wishEffect(103) * wishEffect(104) * wishEffect(188) * wishEffect(218) * wishEffect(226);
	}

	public float adventureBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.2f;
	}

	public int totalInventorySpaces()
	{
		return 0 + invSpace1() + invSpace2() + invSpace3();
	}

	public int invSpace1()
	{
		return character.wishes.wishes[7].level;
	}

	public int invSpace2()
	{
		return character.wishes.wishes[22].level;
	}

	public int invSpace3()
	{
		return character.wishes.wishes[57].level;
	}

	public float totalEnergyPowerBonus()
	{
		return 1f * energyPowerBonus1() * wishEffect(9) * wishEffect(31) * wishEffect(48) * wishEffect(64) * wishEffect(82) * wishEffect(91) * wishEffect(193);
	}

	public float energyPowerBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalEnergyCapBonus()
	{
		return 1f * energyCapBonus1() * wishEffect(10) * wishEffect(32) * wishEffect(49) * wishEffect(65) * wishEffect(84) * wishEffect(93) * wishEffect(195);
	}

	public float energyCapBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalEnergyBarBonus()
	{
		return 1f * energyBarBonus1() * wishEffect(11) * wishEffect(33) * wishEffect(50) * wishEffect(66) * wishEffect(83) * wishEffect(92) * wishEffect(194);
	}

	public float energyBarBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalMagicPowerBonus()
	{
		return 1f * magicPowerBonus1() * wishEffect(12) * wishEffect(34) * wishEffect(51) * wishEffect(67) * wishEffect(85) * wishEffect(94) * wishEffect(196);
	}

	public float magicPowerBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalMagicCapBonus()
	{
		return 1f * magicCapBonus1() * wishEffect(13) * wishEffect(35) * wishEffect(52) * wishEffect(68) * wishEffect(87) * wishEffect(96) * wishEffect(198);
	}

	public float magicCapBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalMagicBarBonus()
	{
		return 1f * magicBarBonus1() * wishEffect(14) * wishEffect(36) * wishEffect(53) * wishEffect(69) * wishEffect(86) * wishEffect(95) * wishEffect(197);
	}

	public float magicBarBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalRes3PowerBonus()
	{
		return 1f * res3PowerBonus1() * wishEffect(15) * wishEffect(37) * wishEffect(54) * wishEffect(70) * wishEffect(88) * wishEffect(97) * wishEffect(199);
	}

	public float res3PowerBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalRes3CapBonus()
	{
		return 1f * res3CapBonus1() * wishEffect(16) * wishEffect(38) * wishEffect(55) * wishEffect(71) * wishEffect(90) * wishEffect(99) * wishEffect(201);
	}

	public float res3CapBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalRes3BarBonus()
	{
		return 1f * res3BarBonus1() * wishEffect(17) * wishEffect(39) * wishEffect(56) * wishEffect(72) * wishEffect(89) * wishEffect(98) * wishEffect(200);
	}

	public float res3BarBonus1()
	{
		if (character.settings.rebirthDifficulty < properties[0].difficultyRequirement)
		{
			return 1f;
		}
		if (character.wishes.wishes[0].level < 1)
		{
			return 1f;
		}
		return 1.05f;
	}

	public float totalWishBonus()
	{
		return 1f * wishEffect(1) * wishEffect(21) * wishEffect(43);
	}

	public int wishBaseMacGuffinLevels()
	{
		int num = 0;
		num = character.wishes.wishes[2].level;
		if (num > 5)
		{
			num = 5;
		}
		return num;
	}

	public float totalHackSpeedBonus()
	{
		return 1f * wishEffect(18) * wishEffect(42) * wishEffect(63);
	}

	public float totalDaycareSpeedBonus()
	{
		return 1f * wishEffect(27);
	}

	public float totalRespawnBonus()
	{
		return 1f * respawn1();
	}

	public float respawn1()
	{
		float num = 1f - (float)character.wishes.wishes[46].level * properties[46].effectPerLevel;
		if (num < 0.9f)
		{
			num = 0.9f;
		}
		return num;
	}

	public float totalQPBonus()
	{
		return 1f * wishEffect(47);
	}

	public float totalBloodGuffbonus()
	{
		return wishEffect(59);
	}

	public float totalFruitGuffbonus()
	{
		return wishEffect(60);
	}

	public float totalExpBonus()
	{
		return wishEffect(61);
	}

	public long totalBasePPBonus()
	{
		return basePP1();
	}

	public long basePP1()
	{
		if (character.settings.rebirthDifficulty < properties[79].difficultyRequirement)
		{
			return 0L;
		}
		return character.wishes.wishes[79].level * 50;
	}

	public float sadisticBossMultiplierBonus()
	{
		return 0f + (sadBoss1() + sadBoss2());
	}

	public float sadBoss1()
	{
		if (character.settings.rebirthDifficulty < properties[107].difficultyRequirement)
		{
			return 0f;
		}
		float num = (float)character.wishes.wishes[107].level * 0.001f;
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
		if (character.settings.rebirthDifficulty < properties[108].difficultyRequirement)
		{
			return 0f;
		}
		float num = (float)character.wishes.wishes[108].level * 0.001f;
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

	public float totalBoostRatioDivider()
	{
		float num = 1f;
		num *= wishEffect(110);
		if (num > 2f)
		{
			num = 2f;
		}
		return num;
	}

	public float totalEnergyNGUSpeed()
	{
		return 1f * (wishEffect(111) * wishEffect(112));
	}

	public float totalMagicNGUSpeed()
	{
		return 1f * (wishEffect(113) * wishEffect(114));
	}

	public float totalMayoSpeed()
	{
		float num = 1f;
		if (!character.cards.cardsOn)
		{
			return 1f;
		}
		return num * (wishEffect(154) * wishEffect(156) * wishEffect(158) * wishEffect(160) * wishEffect(222) * wishEffect(224));
	}

	public float totalCardSpeed()
	{
		float num = 1f;
		if (!character.cards.cardsOn)
		{
			return 1f;
		}
		return num * (wishEffect(155) * wishEffect(157) * wishEffect(159) * wishEffect(161) * wishEffect(223) * wishEffect(225));
	}

	public int totalDeckSizeBonus()
	{
		int num = 0;
		num += (int)Math.Min(character.wishes.wishes[164].level, properties[164].maxLevel);
		num += (int)Math.Min(character.wishes.wishes[165].level, properties[164].maxLevel);
		num += (int)Math.Min(character.wishes.wishes[166].level, properties[164].maxLevel);
		if (num < 0)
		{
			num = 0;
		}
		return num;
	}

	public float totalCardTagBonus()
	{
		float num = 0f;
		num += properties[169].effectPerLevel * (float)character.wishes.wishes[169].level;
		num += properties[170].effectPerLevel * (float)character.wishes.wishes[170].level;
		num += properties[171].effectPerLevel * (float)character.wishes.wishes[171].level;
		num += properties[172].effectPerLevel * (float)character.wishes.wishes[172].level;
		num += properties[173].effectPerLevel * (float)character.wishes.wishes[173].level;
		if (num < 0f)
		{
			num = 0f;
		}
		return num;
	}
}
