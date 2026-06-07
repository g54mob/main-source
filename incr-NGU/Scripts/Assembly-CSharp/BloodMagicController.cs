using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BloodMagicController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public InventoryController inventoryController;

	public Slider ritualSlider;

	public int id;

	public Text ritualMagicText;

	public Text ritualLevelText;

	public HoverTooltip tooltip;

	public InputField magicRequested;

	public NumberFormat format;

	private string message;

	public long baseBoost;

	public float baseTime;

	public float baseCost;

	public int bossRequired;

	private void Start()
	{
		InvokeRepeating("updateBloodMagic", 0f, 0.02f);
	}

	public double bloodAdded()
	{
		return (float)baseBoost * character.allDiggers.totalBloodBonus() * character.inventory.macguffinBonuses[18] * character.hacksController.totalBloodGainBonus() * character.beastQuestPerkController.totalBloodGainBonus();
	}

	private void updateBloodMagic()
	{
		updateBloodMagicBar();
		if (character.bossID <= character.bloodMagic.ritual[id].boss || character.bloodMagic.ritual[id].magic == 0L)
		{
			return;
		}
		if (character.bloodMagic.ritual[id].progress <= 0f)
		{
			if (!(character.realGold >= (double)currentCost()))
			{
				return;
			}
			character.realGold -= currentCost();
			character.bloodMagic.ritual[id].progress += progressPerTick();
		}
		else
		{
			character.bloodMagic.ritual[id].progress += progressPerTick();
		}
		if (character.bloodMagic.ritual[id].progress >= 1f)
		{
			character.bloodMagic.ritual[id].progress = 0f;
			if (character.canLevel())
			{
				character.bloodMagic.ritual[id].level++;
				character.bloodMagic.bloodPoints += bloodAdded();
				character.settings.rebirthLevels++;
				updateBloodMagicText();
			}
		}
	}

	public void updateBloodMagicText()
	{
		if (character.menuID == 6)
		{
			if (character.challenges.blindChallenge.inChallenge)
			{
				ritualLevelText.text = "";
				ritualMagicText.text = "";
			}
			else
			{
				ritualLevelText.text = character.display(character.bloodMagic.ritual[id].level);
				ritualMagicText.text = character.display(character.bloodMagic.ritual[id].magic);
			}
		}
	}

	public void updateBloodMagicBar()
	{
		if (character.menuID != 6)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 6)
		{
			ritualSlider.value = 0f;
		}
		else if (character.settings.antiFlickerBars)
		{
			float num = progressPerTick();
			if (num > 0.1f)
			{
				ritualSlider.value = num;
			}
			else
			{
				ritualSlider.value = character.bloodMagic.ritual[id].progress;
			}
		}
		else
		{
			ritualSlider.value = character.bloodMagic.ritual[id].progress;
		}
	}

	public void add()
	{
		long energyMagicInput = character.input.energyMagicInput;
		addMagic(energyMagicInput);
	}

	private void addMagic(long amount)
	{
		if (id >= character.bloodMagicController.ritualsUnlocked())
		{
			tooltip.showOverrideTooltip("You need to unlock this ritual from a challenge!", 2f);
			return;
		}
		long num = amount;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.magic.idleMagic)
		{
			num = character.magic.idleMagic;
			character.bloodMagic.ritual[id].magic += num;
			character.magic.idleMagic = 0L;
		}
		else
		{
			character.bloodMagic.ritual[id].magic += num;
			character.magic.idleMagic -= num;
		}
		updateBloodMagicText();
		updateBloodMagicBar();
	}

	public void removeMagic()
	{
		long num = character.input.energyMagicInput;
		long magic = character.bloodMagic.ritual[id].magic;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= magic)
		{
			num = magic;
			character.magic.idleMagic += num;
			character.bloodMagic.ritual[id].magic -= num;
		}
		else
		{
			character.magic.idleMagic += num;
			character.bloodMagic.ritual[id].magic -= num;
		}
		updateBloodMagicText();
		updateBloodMagicBar();
	}

	public void cap()
	{
		if (id >= character.bloodMagicController.ritualsUnlocked())
		{
			tooltip.showOverrideTooltip("You need to unlock this ritual from a challenge!", 3f);
			return;
		}
		character.magic.idleMagic += character.bloodMagic.ritual[id].magic;
		character.bloodMagic.ritual[id].magic = 0L;
		if (character.magic.idleMagic == 0L)
		{
			return;
		}
		long num = capValue();
		if (character.magic.idleMagic > num)
		{
			character.magic.idleMagic -= num;
			character.bloodMagic.ritual[id].magic += num;
		}
		else
		{
			long num2 = (long)((double)num / Math.Ceiling((double)num / (double)character.magic.idleMagic)) + 1;
			if (num2 > character.magic.idleMagic)
			{
				num2 = character.magic.idleMagic;
			}
			character.magic.idleMagic -= num2;
			character.bloodMagic.ritual[id].magic += num2;
		}
		updateBloodMagicText();
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}

	public void reset()
	{
		character.bloodMagic.ritual[id].reset();
		updateBloodMagicText();
		updateBloodMagicBar();
	}

	public void refresh()
	{
		updateBloodMagicText();
		updateBloodMagicBar();
	}

	public void removeAllMagic()
	{
		long magic = character.bloodMagic.ritual[id].magic;
		character.magic.idleMagic += magic;
		character.bloodMagic.ritual[id].magic -= magic;
		refresh();
	}

	public void showTooltip()
	{
		message = "<b>Blood Gained Per Bar Fill</b>: " + NumberOutput.suffixFormat(character.bloodMagicController.bloodAdded(id), character.settings.numberDisplay) + "\n<b>Total Blood gained from this ritual: " + NumberOutput.suffixFormat(totalBoost(), character.settings.numberDisplay) + "</b>\n\n<b>Time left to Ritual Completion: </b>" + timeLeft() + "\n\n<b>Cost of Ritual: </b> " + format.suffixFormat(baseCost * character.totalDiscount()) + " Gold\n\n<b>Current Speed Cap: </b>" + format.suffixFormat(capValue()) + " Magic\n\n<b>Gold Consumed Per Second: </b>" + character.display(goldConsumedPerSecond()) + "\n\n<b>Blood Gained Per Second: </b>" + character.display(bloodGainedPerSecond());
		tooltip.showTooltip(message);
	}

	public long capValue()
	{
		double num = 1.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = Math.Ceiling(50000.0 * (double)character.bloodMagicController.normalSpeedDividers[id] / ((double)character.totalMagicPower() * (double)totalBloodMagicSpeedBonus())) * 1.000002;
			if (num < 1.0)
			{
				num = 1.0;
			}
			if (num > (double)character.hardCap())
			{
				num = character.hardCap();
			}
			return (long)num;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = Math.Ceiling(50000.0 * (double)character.bloodMagicController.evilSpeedDividers[id] / ((double)character.totalMagicPower() * (double)totalBloodMagicSpeedBonus())) * 1.0000020265579224;
			if (num < 1.0)
			{
				num = 1.0;
			}
			if (num > (double)character.hardCap())
			{
				num = character.hardCap();
			}
			return (long)num;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = Math.Ceiling((double)sadisticDivider() * (double)character.bloodMagicController.sadisticSpeedDividers[id] / ((double)character.totalMagicPower() * (double)totalBloodMagicSpeedBonus())) * 1.0000020265579224;
			if (num < 1.0)
			{
				num = 1.0;
			}
			if (num > (double)character.hardCap())
			{
				num = character.hardCap();
			}
			return (long)num;
		}
		num = (long)(Math.Ceiling(50000.0 * (double)character.bloodMagicController.normalSpeedDividers[id] / ((double)character.totalMagicPower() * (double)totalBloodMagicSpeedBonus())) * 1.0000020265579224);
		if (num < 1.0)
		{
			num = 1.0;
		}
		if (num > (double)character.hardCap())
		{
			num = character.hardCap();
		}
		return (long)num;
	}

	public float barFillsPerSecond()
	{
		if (progressPerTick() < 1E-09f)
		{
			return 0f;
		}
		return 50f / (float)Mathf.CeilToInt(1f / Mathf.Min(progressPerTick(), 1f));
	}

	public double goldConsumedPerSecond()
	{
		return barFillsPerSecond() * baseCost;
	}

	public double bloodGainedPerSecond()
	{
		return (double)barFillsPerSecond() * character.bloodMagicController.bloodAdded(id);
	}

	public float sadisticDivider()
	{
		return 500000000f;
	}

	public float progressPerTick()
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = (float)character.bloodMagic.ritual[id].magic * character.totalMagicPower() / 50000f / character.bloodMagicController.normalSpeedDividers[id];
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = (float)character.bloodMagic.ritual[id].magic * character.totalMagicPower() / 50000f / character.bloodMagicController.evilSpeedDividers[id];
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = (float)character.bloodMagic.ritual[id].magic * character.totalMagicPower() / character.bloodMagicController.sadisticSpeedDividers[id];
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		num *= (double)totalBloodMagicSpeedBonus();
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public float progressPerTick1000()
	{
		double num = 0.0;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			num = (float)character.totalCapMagic() * character.totalMagicPower() / 50000f / character.bloodMagicController.normalSpeedDividers[id];
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			num = (float)character.totalCapMagic() * character.totalMagicPower() / 50000f / character.bloodMagicController.evilSpeedDividers[id];
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			num = (float)character.totalCapMagic() * character.totalMagicPower() / character.bloodMagicController.sadisticSpeedDividers[id];
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num /= (double)sadisticDivider();
		}
		num *= (double)totalBloodMagicSpeedBonus();
		if (num <= -3.4028234663852886E+38)
		{
			num = 0.0;
		}
		if (num >= 3.4028234663852886E+38)
		{
			num = 3.4028234663852886E+38;
		}
		return (float)num;
	}

	public float totalBloodMagicSpeedBonus()
	{
		float num = 1f;
		if (character.inventory.itemList.netherComplete)
		{
			num *= 1.25f;
		}
		return num;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.02f);
	}

	public float totalBoost()
	{
		return (float)bloodAdded() * (float)character.bloodMagic.ritual[id].level;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hideTooltip();
		CancelInvoke("showTooltip");
	}

	public float currentCost()
	{
		return baseCost * character.totalDiscount();
	}

	public string timeLeft()
	{
		if (character.bloodMagic.ritual[id].magic == 0L)
		{
			return NumberOutput.timeOutput((1f - character.bloodMagic.ritual[id].progress) / progressPerTick1000() / 50f);
		}
		return NumberOutput.timeOutput((1f - character.bloodMagic.ritual[id].progress) / progressPerTick() / 50f);
	}
}
