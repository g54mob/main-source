using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllAugsController : MonoBehaviour
{
	public AugmentController[] augments = new AugmentController[7];

	public Character character;

	public Text totalPowerText;

	public Button advanceEnergyToggle;

	public Image advanceImage;

	public List<float> normalAugSpeedDividers;

	public List<float> evilAugSpeedDividers;

	public List<float> sadisticAugSpeedDividers;

	public List<float> normalUpgradeSpeedDividers;

	public List<float> evilUpgradeSpeedDividers;

	public List<float> sadisticUpgradeSpeedDividers;

	private void Start()
	{
		updateAugStats();
		InvokeRepeating("updateTotalBonus", 0f, 0.5f);
	}

	public void reset()
	{
		for (int i = 0; i < augments.Length; i++)
		{
			augments[i].reset();
		}
	}

	public int augCount()
	{
		return 7;
	}

	public void updateMenu()
	{
		for (int i = 0; i < augments.Length; i++)
		{
			augments[i].refreshMenu();
		}
		updateToggleState();
	}

	private void updateAugStats()
	{
	}

	private void updateTotalBonus()
	{
		if (character.challenges.blindChallenge.inChallenge)
		{
			totalPowerText.text = "";
		}
		else
		{
			totalPowerText.text = "Total Attack/Defense Multiplier: " + NumberOutput.suffixFormat(totalBonus(), character.settings.numberDisplay);
		}
	}

	public float getTotalSpeedFactor()
	{
		float num = character.totalEnergyPower();
		num *= 1f + character.inventoryController.bonuses[specType.Augs];
		num *= character.inventory.macguffinBonuses[12];
		num *= character.hacksController.totalAugSpeedBonus();
		num *= character.cardsController.getBonus(cardBonus.augSpeed);
		num *= 1f + (float)character.allChallenges.noAugsChallenge.evilCompletions() * 0.05f;
		if (character.allChallenges.noAugsChallenge.completions() >= 1)
		{
			num *= 1.1f;
		}
		if (character.allChallenges.noAugsChallenge.evilCompletions() >= character.allChallenges.noAugsChallenge.maxCompletions)
		{
			num *= 1.25f;
		}
		if (num <= 1E-09f)
		{
			num = 0f;
		}
		return num;
	}

	public double totalBonus()
	{
		double num = 1.0;
		for (int i = 0; i < augments.Length; i++)
		{
			num += augments[i].getTotalStatBoost();
		}
		num *= 1.0 + (double)character.allChallenges.noAugsChallenge.completions() * 0.25;
		num *= character.NGUController.augmentBonus();
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num /= sadisticNerfModifier();
		}
		if (num < 1.0)
		{
			num = 1.0;
		}
		return num;
	}

	public double sadisticNerfModifier()
	{
		return 1000000000000.0;
	}

	public void removeAllEnergy()
	{
		for (int i = 0; i < augments.Length; i++)
		{
			augments[i].removeAllEnergy();
		}
	}

	public void toggleAdvance()
	{
		character.augments.advanceEnergy = !character.augments.advanceEnergy;
		updateToggleState();
	}

	public void updateToggleState()
	{
		if (!character.augments.advanceEnergy)
		{
			advanceImage.color = Color.clear;
		}
		else
		{
			advanceImage.color = Color.white;
		}
	}

	public void moveToNextAug(int id)
	{
		int num = id;
		long augEnergy = character.augments.augs[id].augEnergy;
		character.augments.augs[id].augEnergy = 0L;
		character.idleEnergy += augEnergy;
		if (!character.augments.advanceEnergy)
		{
			return;
		}
		for (int i = 0; i < character.augments.augs.Length; i++)
		{
			num++;
			if (num >= character.augments.augs.Length)
			{
				num = 0;
			}
			if (!reachedAugTarget(num) && !character.augmentsController.augments[num].augLocked())
			{
				character.idleEnergy -= augEnergy;
				character.augments.augs[num].augEnergy += augEnergy;
				break;
			}
		}
		updateMenu();
	}

	public void moveToNextUpgrade(int id)
	{
		int num = id;
		long upgradeEnergy = character.augments.augs[id].upgradeEnergy;
		character.augments.augs[id].upgradeEnergy = 0L;
		character.idleEnergy += upgradeEnergy;
		if (!character.augments.advanceEnergy)
		{
			return;
		}
		for (int i = 0; i < character.augments.augs.Length; i++)
		{
			num++;
			if (num >= character.augments.augs.Length)
			{
				num = 0;
			}
			if (!reachedUpgradeTarget(num) && !character.augmentsController.augments[num].upgradeLocked())
			{
				character.idleEnergy -= upgradeEnergy;
				character.augments.augs[num].upgradeEnergy += upgradeEnergy;
				break;
			}
		}
		updateMenu();
	}

	public bool reachedAugTarget(int id)
	{
		if (character.augments.augs[id].augmentTarget == -1)
		{
			return true;
		}
		if (character.augments.augs[id].augmentTarget == 0L)
		{
			return false;
		}
		return character.augments.augs[id].augLevel >= character.augments.augs[id].augmentTarget;
	}

	public bool reachedUpgradeTarget(int id)
	{
		if (character.augments.augs[id].upgradeTarget == -1)
		{
			return true;
		}
		if (character.augments.augs[id].upgradeTarget == 0L)
		{
			return false;
		}
		return character.augments.augs[id].upgradeLevel >= character.augments.augs[id].upgradeTarget;
	}

	public void halfAugs()
	{
		for (int i = 0; i < character.augments.augs.Length; i++)
		{
			character.augments.augs[i].augLevel /= 2L;
			character.augments.augs[i].upgradeLevel /= 2L;
		}
	}
}
