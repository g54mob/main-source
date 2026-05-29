using System;
using UnityEngine;
using UnityEngine.UI;

public class AugmentController : MonoBehaviour
{
	public Character character;

	public AllAugsController allAugsController;

	public InventoryController inventoryController;

	public Boss boss;

	public int id;

	public InputField energyRequested;

	public HoverTooltip tooltip;

	public NumberFormat format;

	public Slider augSlider;

	public Slider upgradeSlider;

	public Text augLevelText;

	public Text augEnergyText;

	public Text upgradeLevelText;

	public Text upgradeMagicText;

	public Text augNameText;

	public Text upgradeNameText;

	public InputField augmentTarget;

	public InputField upgradeTarget;

	private Aug aug;

	public float baseAugmentTime;

	public float baseAugmentCost;

	public float baseUpgradeTime;

	public float baseUpgradeCost;

	public long baseBoost;

	public int augBossRequired;

	public int upgradeBossRequired;

	public string augName;

	public string augDesc;

	public string upgradeName;

	public string upgradeDesc;

	private void Start()
	{
		updateAugTexts();
		updateUpgradeTexts();
		updateSliders();
		InvokeRepeating("updateAug", 0f, 0.02f);
	}

	private void updateAug()
	{
		updateSliders();
		if (character.bossID > augBossRequired)
		{
			advanceAug();
			if (character.bossID > upgradeBossRequired)
			{
				advanceUpgrade();
			}
		}
	}

	public void updateSliders()
	{
		if (character.menuID != 5)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 3)
		{
			augSlider.value = 0f;
			upgradeSlider.value = 0f;
		}
		else if (character.settings.antiFlickerBars)
		{
			float augProgressPerTick = getAugProgressPerTick();
			float upgradeProgressPerTick = getUpgradeProgressPerTick();
			if (augProgressPerTick > 0.1f)
			{
				augSlider.value = augProgressPerTick;
			}
			else
			{
				augSlider.value = character.augments.augs[id].augProgress;
			}
			if (upgradeProgressPerTick > 0.1f)
			{
				upgradeSlider.value = upgradeProgressPerTick;
			}
			else
			{
				upgradeSlider.value = character.augments.augs[id].upgradeProgress;
			}
		}
		else
		{
			augSlider.value = character.augments.augs[id].augProgress;
			upgradeSlider.value = character.augments.augs[id].upgradeProgress;
		}
	}

	public void updateAugTexts()
	{
		if (character.menuID == 5)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				augLevelText.text = "";
				augEnergyText.text = "";
			}
			else
			{
				augLevelText.text = format.suffixFormat(character.augments.augs[id].augLevel);
				augEnergyText.text = format.suffixFormat(character.augments.augs[id].augEnergy);
			}
			if (character.bossID <= augBossRequired)
			{
				augNameText.text = "Locked";
			}
			else
			{
				augNameText.text = augName;
			}
		}
	}

	public void updateAugTargetText()
	{
		if (character.menuID == 5)
		{
			augmentTarget.text = character.augments.augs[id].augmentTarget.ToString();
			upgradeTarget.text = character.augments.augs[id].upgradeTarget.ToString();
		}
	}

	public bool augLocked()
	{
		return character.bossID <= augBossRequired;
	}

	public bool upgradeLocked()
	{
		return character.bossID <= upgradeBossRequired;
	}

	public bool hitAugmentTarget()
	{
		if (character.augments.augs[id].augmentTarget == 0L)
		{
			return false;
		}
		return character.augments.augs[id].augLevel >= character.augments.augs[id].augmentTarget;
	}

	public bool hitUpgradeTarget()
	{
		if (character.augments.augs[id].upgradeTarget == 0L)
		{
			return false;
		}
		return character.augments.augs[id].upgradeLevel >= character.augments.augs[id].upgradeTarget;
	}

	public void updateUpgradeTexts()
	{
		if (character.menuID == 5)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				upgradeLevelText.text = "";
				upgradeMagicText.text = "";
			}
			else
			{
				upgradeLevelText.text = format.suffixFormat(character.augments.augs[id].upgradeLevel);
				upgradeMagicText.text = format.suffixFormat(character.augments.augs[id].upgradeEnergy);
			}
			if (character.bossID <= upgradeBossRequired)
			{
				upgradeNameText.text = "Locked";
			}
			else
			{
				upgradeNameText.text = upgradeName;
			}
		}
	}

	public void advanceAug()
	{
		if (character.bossID <= augBossRequired || character.augments.augs[id].augEnergy <= 0)
		{
			return;
		}
		if (hitAugmentTarget())
		{
			allAugsController.moveToNextAug(id);
			allAugsController.updateMenu();
			return;
		}
		if (character.augments.augs[id].augProgress == 0f)
		{
			float augCost = getAugCost();
			if (character.realGold < (double)augCost)
			{
				return;
			}
			character.realGold -= augCost;
			float augProgressPerTick = getAugProgressPerTick();
			character.augments.augs[id].augProgress += augProgressPerTick;
		}
		else
		{
			float augProgressPerTick2 = getAugProgressPerTick();
			character.augments.augs[id].augProgress += augProgressPerTick2;
		}
		if (character.augments.augs[id].augProgress >= 1f)
		{
			character.augments.augs[id].augProgress = 0f;
			if (character.canLevel())
			{
				character.augments.augs[id].augLevel++;
				character.settings.rebirthLevels++;
				updateAugTexts();
			}
		}
	}

	public void advanceUpgrade()
	{
		if (character.bossID <= upgradeBossRequired || character.augments.augs[id].upgradeEnergy <= 0)
		{
			return;
		}
		if (hitUpgradeTarget())
		{
			allAugsController.moveToNextUpgrade(id);
			allAugsController.updateMenu();
			return;
		}
		if (character.augments.augs[id].upgradeProgress == 0f)
		{
			float upgradeCost = getUpgradeCost();
			if (character.realGold < (double)upgradeCost)
			{
				return;
			}
			character.realGold -= upgradeCost;
			float upgradeProgressPerTick = getUpgradeProgressPerTick();
			character.augments.augs[id].upgradeProgress += upgradeProgressPerTick;
		}
		else
		{
			float upgradeProgressPerTick2 = getUpgradeProgressPerTick();
			character.augments.augs[id].upgradeProgress += upgradeProgressPerTick2;
		}
		if (character.augments.augs[id].upgradeProgress >= 1f)
		{
			character.augments.augs[id].upgradeProgress = 0f;
			if (character.canLevel())
			{
				character.augments.augs[id].upgradeLevel++;
				character.settings.rebirthLevels++;
				updateUpgradeTexts();
			}
		}
	}

	public float getAugCost()
	{
		return baseAugmentCost * (float)(character.augments.augs[id].augLevel + 1) * character.augDiscount();
	}

	public float getBaseAugCost()
	{
		return baseAugmentCost;
	}

	public float getUpgradeCost()
	{
		return baseUpgradeCost * Mathf.Pow(character.augments.augs[id].upgradeLevel + 1, 2f) * character.augDiscount();
	}

	public float getBaseUpgradeCost()
	{
		return baseUpgradeCost;
	}

	public float sadisticDivider()
	{
		return 50000000f;
	}

	public float getAugProgressPerTick()
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = character.totalEnergyPower() / character.augmentsController.normalAugSpeedDividers[id] / 50000f * (float)character.augments.augs[id].augEnergy / (float)(character.augments.augs[id].augLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = character.totalEnergyPower() / character.augmentsController.evilAugSpeedDividers[id] / 50000f * (float)character.augments.augs[id].augEnergy / (float)(character.augments.augs[id].augLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = character.totalEnergyPower() / character.augmentsController.sadisticAugSpeedDividers[id] * (float)character.augments.augs[id].augEnergy / (float)(character.augments.augs[id].augLevel + 1);
		}
		num *= (double)(1f + character.inventoryController.bonuses[specType.Augs]);
		num *= (double)character.inventory.macguffinBonuses[12];
		num *= (double)character.hacksController.totalAugSpeedBonus();
		num *= (double)character.adventureController.itopod.totalAugSpeedBonus();
		num *= (double)character.cardsController.getBonus(cardBonus.augSpeed);
		num *= (double)(1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f);
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			num *= 1.100000023841858;
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			num *= 1.25;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		if (num <= 9.999999717180685E-10)
		{
			num = 0.0;
		}
		return (float)num;
	}

	public float getAugProgressPerTick(long amount)
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = (float)amount * character.totalEnergyPower() / 50000f / character.augmentsController.normalAugSpeedDividers[id] / (float)(character.augments.augs[id].augLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = (float)amount * character.totalEnergyPower() / 50000f / character.augmentsController.evilAugSpeedDividers[id] / (float)(character.augments.augs[id].augLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = (float)amount * character.totalEnergyPower() / character.augmentsController.sadisticAugSpeedDividers[id] / (float)(character.augments.augs[id].augLevel + 1);
		}
		num *= (double)(1f + character.inventoryController.bonuses[specType.Augs]);
		num *= (double)character.inventory.macguffinBonuses[12];
		num *= (double)character.hacksController.totalAugSpeedBonus();
		num *= (double)character.adventureController.itopod.totalAugSpeedBonus();
		num *= (double)character.cardsController.getBonus(cardBonus.augSpeed);
		num *= (double)(1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f);
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			num *= 1.100000023841858;
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			num *= 1.25;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		if (num <= 9.999999717180685E-10)
		{
			num = 0.0;
		}
		return (float)num;
	}

	public float getUpgradeProgressPerTick()
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = (float)character.augments.augs[id].upgradeEnergy * character.totalEnergyPower() / 50000f / character.augmentsController.normalUpgradeSpeedDividers[id] / (float)(character.augments.augs[id].upgradeLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = (double)character.augments.augs[id].upgradeEnergy * (double)character.totalEnergyPower() / 50000.0 / (double)character.augmentsController.evilUpgradeSpeedDividers[id] / (double)(character.augments.augs[id].upgradeLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = (double)character.augments.augs[id].upgradeEnergy * (double)character.totalEnergyPower() / (double)character.augmentsController.sadisticUpgradeSpeedDividers[id] / (double)(character.augments.augs[id].upgradeLevel + 1);
		}
		num *= (double)(1f + character.inventoryController.bonuses[specType.Augs]);
		num *= (double)character.inventory.macguffinBonuses[12];
		num *= (double)character.hacksController.totalAugSpeedBonus();
		num *= (double)character.adventureController.itopod.totalAugSpeedBonus();
		num *= (double)character.cardsController.getBonus(cardBonus.augSpeed);
		num *= (double)(1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f);
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			num *= 1.100000023841858;
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			num *= 1.25;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		if (num <= 9.999999717180685E-10)
		{
			num = 0.0;
		}
		return (float)num;
	}

	public float getUpgradeProgressPerTick(long amount)
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = (float)character.totalCapEnergy() * character.totalEnergyPower() / 50000f / character.augmentsController.normalUpgradeSpeedDividers[id] / (float)(character.augments.augs[id].upgradeLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = (float)character.totalCapEnergy() * character.totalEnergyPower() / 50000f / character.augmentsController.evilUpgradeSpeedDividers[id] / (float)(character.augments.augs[id].upgradeLevel + 1);
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = (float)character.totalCapEnergy() * character.totalEnergyPower() / character.augmentsController.sadisticUpgradeSpeedDividers[id] / (float)(character.augments.augs[id].upgradeLevel + 1);
		}
		num *= (double)(1f + character.inventoryController.bonuses[specType.Augs]);
		num *= (double)character.inventory.macguffinBonuses[12];
		num *= (double)character.hacksController.totalAugSpeedBonus();
		num *= (double)character.adventureController.itopod.totalAugSpeedBonus();
		num *= (double)character.cardsController.getBonus(cardBonus.augSpeed);
		num *= (double)(1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f);
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			num *= 1.100000023841858;
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			num *= 1.25;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		if (num <= 9.999999717180685E-10)
		{
			num = 0.0;
		}
		return (float)num;
	}

	public void addEnergyAug()
	{
		if (character.bossID > augBossRequired)
		{
			long num = character.input.energyMagicInput;
			if (num < 0)
			{
				num = 0L;
			}
			if (num >= character.idleEnergy)
			{
				num = character.idleEnergy;
				character.augments.augs[id].addEnergyAug(num);
				character.idleEnergy = 0L;
			}
			else
			{
				character.augments.augs[id].addEnergyAug(num);
				character.idleEnergy -= num;
			}
			updateAugTexts();
		}
	}

	public void addEnergyUpgrade()
	{
		if (character.bossID > upgradeBossRequired)
		{
			long num = character.input.energyMagicInput;
			if (num < 0)
			{
				num = 0L;
			}
			if (num >= character.idleEnergy)
			{
				num = character.idleEnergy;
				character.augments.augs[id].addEnergyUpgrade(num);
				character.idleEnergy = 0L;
			}
			else
			{
				character.augments.augs[id].addEnergyUpgrade(num);
				character.idleEnergy -= num;
			}
			updateUpgradeTexts();
		}
	}

	public void removeEnergyAug()
	{
		if (character.bossID > augBossRequired)
		{
			long energyMagicInput = character.input.energyMagicInput;
			if (energyMagicInput < 0)
			{
				energyMagicInput = 0L;
				return;
			}
			character.idleEnergy += character.augments.augs[id].removeEnergyAug(energyMagicInput);
			updateAugTexts();
		}
	}

	public void removeEnergyUpgrade()
	{
		if (character.bossID > upgradeBossRequired)
		{
			long energyMagicInput = character.input.energyMagicInput;
			if (energyMagicInput < 0)
			{
				energyMagicInput = 0L;
				return;
			}
			character.idleEnergy += character.augments.augs[id].removeEnergyUpgrade(energyMagicInput);
			updateUpgradeTexts();
		}
	}

	public void checkAugTargetInput()
	{
		long num = 0L;
		try
		{
			if (augmentTarget.text == "")
			{
				augmentTarget.text = "0";
			}
			num = long.Parse(augmentTarget.text);
		}
		catch (Exception)
		{
			num = 0L;
		}
		if (num < -1)
		{
			num = 0L;
		}
		if (num >= long.MaxValue)
		{
			num = long.MaxValue;
		}
		augmentTarget.text = num.ToString();
		character.augments.augs[id].augmentTarget = num;
	}

	public void checkUpgradeTargetInput()
	{
		long num = 0L;
		try
		{
			if (upgradeTarget.text == "")
			{
				upgradeTarget.text = "0";
			}
			num = long.Parse(upgradeTarget.text);
		}
		catch (Exception)
		{
			num = 0L;
		}
		if (num < -1)
		{
			num = 0L;
		}
		if (num >= long.MaxValue)
		{
			num = long.MaxValue;
		}
		upgradeTarget.text = num.ToString();
		character.augments.augs[id].upgradeTarget = num;
	}

	public void showAugTooltip()
	{
		if (character.bossID <= augBossRequired)
		{
			tooltip.showTooltip("You must defeat boss " + (augBossRequired + 1) + " to earn this augmentation. Git gud.");
			return;
		}
		string text = "<b>" + augName + "</b>\n<b>" + augDesc + "</b>\n\n<b>Base Stat Multiplier: " + NumberOutput.suffixFormat(baseBoost, character.settings.numberDisplay) + "</b>";
		if (augTierBonus() > 1.0)
		{
			text = text + "\n<b>BONUS: This Augment's level is raised to a power of " + augTierBonus() + "</b>";
		}
		text = text + "\n<b>Total Stat Multiplier: " + NumberOutput.suffixFormat(getTotalStatBoost(), character.settings.numberDisplay) + "</b>\n\nUnlocked by defeating " + character.bossController.getBossName(augBossRequired) + "\n\nNext augment level cost: " + format.suffixFormat(getAugCost()) + " gold.\n\nTime left to complete augment: " + augTimeLeft();
		tooltip.showTooltip(text);
	}

	private string augTimeLeft()
	{
		if (character.totalEnergyPower() == 0f)
		{
			return "N/A";
		}
		if (character.augments.augs[id].augEnergy == 0L)
		{
			return NumberOutput.timeOutput((1f - character.augments.augs[id].augProgress) / getAugProgressPerTick(character.totalCapEnergy()) / 50f) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		return NumberOutput.timeOutput((1f - character.augments.augs[id].augProgress) / getAugProgressPerTick() / 50f);
	}

	private string upgradeTimeLeft()
	{
		if (character.totalEnergyPower() == 0f)
		{
			return "N/A";
		}
		if (character.augments.augs[id].upgradeEnergy == 0L)
		{
			return NumberOutput.timeOutput((1f - character.augments.augs[id].upgradeProgress) / getUpgradeProgressPerTick(character.totalCapEnergy()) / 50f) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		return NumberOutput.timeOutput((1f - character.augments.augs[id].upgradeProgress) / getUpgradeProgressPerTick() / 50f);
	}

	public void showUpgradeTooltip()
	{
		if (character.bossID <= upgradeBossRequired)
		{
			tooltip.showTooltip("You must defeat boss " + (upgradeBossRequired + 1) + " to earn this augmentation upgrade. Git gud.");
			return;
		}
		string message = "<b>" + upgradeName + "</b>\n<b>" + upgradeDesc + "</b>\n\nCurrently multiplies stat multiplier of " + augName + " by " + NumberOutput.suffixFormat(getUpgradeBoost(), character.settings.numberDisplay) + "\nUnlocked by defeating " + character.bossController.getBossName(upgradeBossRequired) + "\n\nNext upgrade cost: " + format.suffixFormat(getUpgradeCost()) + " gold.\n\nTime left to complete upgrade: " + upgradeTimeLeft();
		tooltip.showTooltip(message);
	}

	public float getUpgradeBoost()
	{
		return Mathf.Max(Mathf.Pow(character.augments.augs[id].upgradeLevel, 2f) + 1f, 1f);
	}

	public double getTotalStatBoost()
	{
		return (double)baseBoost * (double)getUpgradeBoost() * Math.Pow(character.augments.augs[id].augLevel, augTierBonus());
	}

	public double augTierBonus()
	{
		double num = 0.0;
		if (character.allChallenges.laserSwordChallenge.completions() >= 1)
		{
			num += 0.05;
		}
		num += 0.01 * (double)character.allChallenges.laserSwordChallenge.completions();
		if (character.allChallenges.laserSwordChallenge.completions() >= character.allChallenges.laserSwordChallenge.maxCompletions)
		{
			num += 0.05;
		}
		num *= (double)id;
		return 1.0 + 0.1 * (double)id + num;
	}

	public void removeAllEnergy()
	{
		long augEnergy = character.augments.augs[id].augEnergy;
		long upgradeEnergy = character.augments.augs[id].upgradeEnergy;
		character.idleEnergy += augEnergy + upgradeEnergy;
		character.augments.augs[id].augEnergy -= augEnergy;
		character.augments.augs[id].upgradeEnergy -= upgradeEnergy;
		refreshMenu();
	}

	public void refreshMenu()
	{
		if (character.menuID == 5)
		{
			updateAugTexts();
			updateUpgradeTexts();
			updateSliders();
			updateAugTargetText();
		}
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void reset()
	{
		character.augments.augs[id].reset();
		resetNameText();
		updateAugTexts();
		updateUpgradeTexts();
		updateSliders();
	}

	public void resetNameText()
	{
		augNameText.text = "Locked";
		upgradeNameText.text = "Locked";
	}

	public void updateBaseStats(float atime, float acost, float utime, float ucost, long atk, long def, int aboss, int uboss, string name, string desc, string udesc)
	{
		character.augments.augs[id].updateBaseStats(atime, acost, utime, ucost, atk, def, aboss, uboss, name, desc, udesc);
	}
}
