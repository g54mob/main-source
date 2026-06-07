using System;
using UnityEngine;

public class AllBeardsController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public float[] speedDivider;

	public bool[] usesEnergy;

	public Sprite[] beardImages;

	public BeardController beard;

	private void Start()
	{
		InvokeRepeating("advanceBeards", 0f, 0.02f);
	}

	private void Update()
	{
	}

	public int beardSize()
	{
		return character.beards.beardSize();
	}

	public int capBeards()
	{
		int num = 1;
		if (character.purchases.hasBeardSlot1)
		{
			num++;
		}
		if (character.allChallenges.trollChallenge.completions() >= 4)
		{
			num++;
		}
		num += character.arbitrary.beardSlots;
		if (num < 1)
		{
			num = 1;
		}
		if (num > beardSize())
		{
			num = beardSize();
		}
		return num;
	}

	public float beardProgressPerTick(int id)
	{
		if (usesEnergy[id])
		{
			float num = 0f;
			if (character.curEnergy < character.totalCapEnergy())
			{
				return 0f;
			}
			num = (float)character.totalEnergyBar() * Mathf.Sqrt(character.totalEnergyPower()) * (1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) / speedDivider[id] / (float)(character.beards.beards[id].beardLevel + 1) / beardCountDivider(energyBeard: true);
			num *= character.allDiggers.totalEnergyBeardBonus();
			num *= character.beastQuestPerkController.totalBeardSpeedBonus();
			if (character.inventory.itemList.uugComplete)
			{
				num *= 1.1f;
			}
			return num;
		}
		float num2 = 0f;
		if (character.magic.curMagic < character.totalCapMagic())
		{
			return 0f;
		}
		num2 = (float)character.totalMagicBar() * Mathf.Sqrt(character.totalMagicPower()) * (1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) / speedDivider[id] / (float)(character.beards.beards[id].beardLevel + 1) / beardCountDivider(energyBeard: false);
		num2 *= character.allDiggers.totalMagicBeardBonus();
		num2 *= character.beastQuestPerkController.totalBeardSpeedBonus();
		if (character.inventory.itemList.uugComplete)
		{
			num2 *= 1.1f;
		}
		return num2;
	}

	public float energyBeardSpeedFactor()
	{
		float num = 0f;
		num = (float)character.totalEnergyBar() * Mathf.Sqrt(character.totalEnergyPower()) * character.inventory.macguffinBonuses[8] * (1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) / beardCountDivider(energyBeard: true);
		num *= character.allDiggers.totalEnergyBeardBonus();
		num *= character.beastQuestPerkController.totalBeardSpeedBonus();
		if (character.inventory.itemList.uugComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public float magicBeardSpeedFactor()
	{
		float num = 0f;
		num = (float)character.totalMagicBar() * Mathf.Sqrt(character.totalMagicPower()) * character.inventory.macguffinBonuses[9] * (1f + character.inventoryController.bonuses[specType.Beards] + character.inventoryController.bonuses[specType.Beards2]) / beardCountDivider(energyBeard: false);
		num *= character.allDiggers.totalMagicBeardBonus();
		num *= character.beastQuestPerkController.totalBeardSpeedBonus();
		if (character.inventory.itemList.uugComplete)
		{
			num *= 1.1f;
		}
		return num;
	}

	public void refreshMenu()
	{
		beard.updateBeardDisplay();
	}

	public void activateBeard(int id)
	{
		if (character.beards.activeBeards.Count >= capBeards())
		{
			if (character.beards.activeBeards.IndexOf(id) == -1)
			{
				tooltip.showOverrideTooltip("You already have the maximum number of beards active!", 2f);
			}
		}
		else if (character.beards.activeBeards.IndexOf(id) == -1)
		{
			character.beards.activeBeards.Add(id);
			character.beards.beards[id].active = true;
			tallyEnergyMagicBeards();
		}
	}

	public float beardCountDivider(bool energyBeard)
	{
		float num = 1f;
		num = ((!energyBeard) ? Math.Max(character.beards.magicBeardCount, 1f) : Math.Max(character.beards.energyBeardCount, 1f));
		if (character.inventory.itemList.beardverseComplete && num >= 1.9f)
		{
			num *= 0.9f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public void deactivateBeard(int id)
	{
		int num = character.beards.activeBeards.IndexOf(id);
		if (num != -1)
		{
			if (id == 6)
			{
				character.allDiggers.clearAllActiveDiggers();
				tooltip.showOverrideTooltip("Your Gold Diggers were turned off because you deactivated the Gold Beard.", 2f);
			}
			character.beards.activeBeards.RemoveAt(num);
			character.beards.beards[id].active = false;
			tallyEnergyMagicBeards();
		}
	}

	public void advanceBeards()
	{
		for (int i = 0; i < character.beards.activeBeards.Count; i++)
		{
			advanceBeard(character.beards.activeBeards[i]);
		}
		beard.updateSlider();
		beard.updateText();
	}

	public void tallyEnergyMagicBeards()
	{
		character.beards.energyBeardCount = 0;
		character.beards.magicBeardCount = 0;
		for (int i = 0; i < character.beards.activeBeards.Count; i++)
		{
			if (usesEnergy[character.beards.activeBeards[i]])
			{
				character.beards.energyBeardCount++;
			}
			else
			{
				character.beards.magicBeardCount++;
			}
		}
	}

	public void advanceBeard(int id)
	{
		character.beards.beards[id].progress += beardProgressPerTick(id);
		if (character.beards.beards[id].progress >= 1f)
		{
			character.beards.beards[id].progress = 0f;
			if (character.canLevel())
			{
				character.beards.beards[id].beardLevel++;
				character.settings.rebirthLevels++;
			}
		}
	}

	public void clearActiveBeards()
	{
		beard.hideDropdown();
		int num = character.beards.activeBeards.IndexOf(6);
		character.beards.activeBeards.Clear();
		for (int i = 0; i < character.beards.beards.Count; i++)
		{
			character.beards.beards[i].active = false;
		}
		if (num != -1)
		{
			character.allDiggers.clearAllActiveDiggers();
			tooltip.showOverrideTooltip("Your Gold Diggers were turned off because you deactivated the Gold Beard.", 2f);
		}
		tallyEnergyMagicBeards();
		beard.updateBeardDisplay();
	}

	public void reset()
	{
		for (int i = 0; i < character.beards.beards.Count; i++)
		{
			long num = (long)(character.adventureController.itopod.totalBankedBeardTemp() * (float)character.beards.beards[i].beardLevel);
			if (num < 0)
			{
				num = 0L;
			}
			if (num > (long)((float)character.beards.beards[i].beardLevel * character.adventureController.itopod.totalBankedBeardTemp()))
			{
				num = (long)((float)character.beards.beards[i].beardLevel * character.adventureController.itopod.totalBankedBeardTemp());
			}
			character.beards.beards[i].progress = 0f;
			character.beards.beards[i].beardLevel = 0L;
			character.beards.beards[i].bankedLevel = num;
			character.beards.transferredBankedLevels = false;
		}
	}

	public void challengeReset()
	{
		for (int i = 0; i < character.beards.beards.Count; i++)
		{
			character.beards.beards[i].bankedLevel = 0L;
		}
		character.beards.transferredBankedLevels = true;
	}

	public void addBankedLevels()
	{
		if (character.beards.transferredBankedLevels)
		{
			return;
		}
		for (int i = 0; i < character.beards.beards.Count; i++)
		{
			if (character.beards.beards[i].bankedLevel > 0)
			{
				character.beards.beards[i].beardLevel = character.beards.beards[i].bankedLevel;
				character.beards.beards[i].bankedLevel = 0L;
			}
		}
		character.beards.transferredBankedLevels = true;
	}

	public double timeFactor()
	{
		if (character.rebirthTime.totalseconds < 3600.0)
		{
			return 0.0;
		}
		double num = character.rebirthTime.totalseconds / 10800.0 * 24.0 / (double)(24 - character.adventure.itopod.perkLevel[21]);
		if (num > 8.0)
		{
			num = 8.0;
		}
		return num;
	}

	public void convertBeardTrimmings()
	{
		for (int i = 0; i < character.beards.activeBeards.Count; i++)
		{
			convertToTrimmings(character.beards.activeBeards[i]);
		}
	}

	public void convertToTrimmings(int id)
	{
		long num = addedTrimmings(id);
		character.beards.beards[id].permLevel += num;
	}

	public long addedTrimmings(int id)
	{
		long num = Convert.ToInt64(Math.Floor(Math.Sqrt(character.beards.beards[id].beardLevel) * timeFactor()));
		if (num > character.beards.beards[id].beardLevel)
		{
			num = character.beards.beards[id].beardLevel;
		}
		return num;
	}

	public double statBonus()
	{
		if (character.beards.disabled)
		{
			return 1.0;
		}
		double num = 1.0 * tempStatBonus() * permStatBonus();
		if (num < 1.0)
		{
			return 1.0;
		}
		return num;
	}

	public double tempStatBonus()
	{
		return tempStatBonus(overrideFlag: false);
	}

	public double tempStatBonus(bool overrideFlag)
	{
		double num = 1.0;
		if (character.beards.beards[0].active || overrideFlag)
		{
			num = 1.0 + (double)character.beards.beards[0].beardLevel * 0.05;
		}
		if (num < 1.0)
		{
			return 1.0;
		}
		return num;
	}

	public double permStatBonus()
	{
		return permStatBonus(0L);
	}

	public double permStatBonus(long offset)
	{
		double num = 1.0 + (double)(character.beards.beards[0].permLevel + offset) * 0.01;
		if (num < 1.0)
		{
			return 1.0;
		}
		return num;
	}

	public float lootBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempLootBonus() * permLootBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempLootBonus()
	{
		return tempLootBonus(overrideFlag: false);
	}

	public float tempLootBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[1].active || overrideFlag)
		{
			num = ((character.beards.beards[1].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[1].beardLevel, 0.3f) * 125.9f * 0.0005f) : (1f + (float)character.beards.beards[1].beardLevel * 0.0005f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permLootBonus()
	{
		return permLootBonus(0L);
	}

	public float permLootBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[1].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.33f) * 102.4f * 0.0005f)) : (num * (1f + (float)num2 * 0.0005f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float numberBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempNumberBonus() * permNumberBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempNumberBonus()
	{
		return tempNumberBonus(overrideFlag: false);
	}

	public float tempNumberBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[2].active || overrideFlag)
		{
			num = ((character.beards.beards[2].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[2].beardLevel, 0.5f) * 31.7f * 0.01f) : (1f + (float)character.beards.beards[2].beardLevel * 0.01f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permNumberBonus()
	{
		return permNumberBonus(0L);
	}

	public float permNumberBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[2].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.5f) * 31.7f * 0.001f)) : (num * (1f + (float)num2 * 0.001f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float nguBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempNGUBonus() * permNGUBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempNGUBonus()
	{
		return tempNGUBonus(overrideFlag: false);
	}

	public float tempNGUBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[3].active || overrideFlag)
		{
			num = ((character.beards.beards[3].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[3].beardLevel, 0.3f) * 125.9f * 0.0001f) : (1f + (float)character.beards.beards[3].beardLevel * 0.0001f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permNGUBonus()
	{
		return permNGUBonus(0L);
	}

	public float permNGUBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[3].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.3f) * 125.9f * 0.0002f)) : (num * (1f + (float)num2 * 0.0002f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float wandoosBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempWandoosBonus() * permWandoosBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempWandoosBonus()
	{
		return tempWandoosBonus(overrideFlag: false);
	}

	public float tempWandoosBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[4].active || overrideFlag)
		{
			num = ((character.beards.beards[4].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[4].beardLevel, 0.5f) * 31.7f * 0.001f) : (1f + (float)character.beards.beards[4].beardLevel * 0.001f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permWandoosBonus()
	{
		return permWandoosBonus(0L);
	}

	public float permWandoosBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[4].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.5f) * 31.7f * 0.002f)) : (num * (1f + (float)num2 * 0.002f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float adventureBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempAdventureBonus() * permAdventureBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempAdventureBonus()
	{
		return tempAdventureBonus(overrideFlag: false);
	}

	public float tempAdventureBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[5].active || overrideFlag)
		{
			num = ((character.beards.beards[5].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[5].beardLevel, 0.3f) * 125.9f * 0.001f) : (1f + (float)character.beards.beards[5].beardLevel * 0.001f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permAdventureBonus()
	{
		return permAdventureBonus(0L);
	}

	public float permAdventureBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[5].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.5f) * 31.7f * 0.0005f)) : (num * (1f + (float)num2 * 0.0005f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float goldBonus()
	{
		if (character.beards.disabled)
		{
			return 1f;
		}
		float num = 1f * tempGoldBonus() * permGoldBonus();
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float tempGoldBonus()
	{
		return tempGoldBonus(overrideFlag: false);
	}

	public float tempGoldBonus(bool overrideFlag)
	{
		float num = 1f;
		if (character.beards.beards[6].active || overrideFlag)
		{
			num = ((character.beards.beards[6].beardLevel > 1000) ? (1f + Mathf.Pow(character.beards.beards[6].beardLevel, 0.5f) * 31.7f * 0.002f) : (1f + (float)character.beards.beards[6].beardLevel * 0.002f));
		}
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float permGoldBonus()
	{
		return permGoldBonus(0L);
	}

	public float permGoldBonus(long offset)
	{
		float num = 1f;
		long num2 = character.beards.beards[6].permLevel + offset;
		num = ((num2 > 1000) ? (num * (1f + Mathf.Pow(num2, 0.5f) * 31.7f * 0.005f)) : (num * (1f + (float)num2 * 0.005f)));
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public void wipeTempBeards()
	{
		for (int i = 0; i < character.beards.beards.Count; i++)
		{
			character.beards.beards[i].beardLevel = 0L;
		}
	}
}
