using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NGUMagicController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Slider slider;

	public Text nguName;

	public Text levelText;

	public Text energyMagicText;

	public InputField magicRequested;

	public InputField magicTarget;

	public GameObject capButton;

	public int id;

	public float baseTime;

	public float boostFactor;

	public string NGUName;

	private string message;

	private void Start()
	{
		InvokeRepeating("updateNGU", 0f, 0.02f);
		refresh();
	}

	private void updateNGU()
	{
		if (character.NGU.magicSkills[id].magic <= 0)
		{
			return;
		}
		if (character.NGUController.reachedMagicTarget(id))
		{
			character.NGUController.autoAdvanceMagic(id);
		}
		else if (character.settings.nguLevelTrack == difficulty.normal)
		{
			character.NGU.magicSkills[id].progress += progressPerTick();
			updateBar();
			if (character.NGU.magicSkills[id].progress >= 1f)
			{
				character.NGU.magicSkills[id].progress = 0f;
				character.NGU.magicSkills[id].level++;
				if (character.NGU.magicSkills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.magicSkills[id].level = character.NGUController.hardCapNormalLevel();
				}
				updateText();
				updateBar();
			}
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			character.NGU.magicSkills[id].evilProgress += progressPerTick();
			updateText();
			updateBar();
			if (!(character.NGU.magicSkills[id].evilProgress >= 1f))
			{
				return;
			}
			character.NGU.magicSkills[id].evilProgress = 0f;
			character.NGU.magicSkills[id].evilLevel++;
			if (character.NGU.magicSkills[id].evilLevel >= character.NGUController.hardCapNormalLevel())
			{
				character.NGU.magicSkills[id].evilLevel = character.NGUController.hardCapNormalLevel();
			}
			if (character.beastQuest.quirkLevel[14] > 0)
			{
				character.NGU.magicSkills[id].level++;
				if (character.NGU.magicSkills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.magicSkills[id].level = character.NGUController.hardCapNormalLevel();
				}
			}
			updateText();
			updateBar();
		}
		else
		{
			if (character.settings.nguLevelTrack != difficulty.sadistic)
			{
				return;
			}
			character.NGU.magicSkills[id].sadisticProgress += progressPerTick();
			updateBar();
			if (!(character.NGU.magicSkills[id].sadisticProgress >= 1f))
			{
				return;
			}
			character.NGU.magicSkills[id].sadisticProgress = 0f;
			character.NGU.magicSkills[id].sadisticLevel++;
			if (character.NGU.magicSkills[id].sadisticLevel >= character.NGUController.hardCapNormalLevel())
			{
				character.NGU.magicSkills[id].sadisticLevel = character.NGUController.hardCapNormalLevel();
			}
			if (character.beastQuest.quirkLevel[89] > 0)
			{
				character.NGU.magicSkills[id].evilLevel++;
				if (character.NGU.magicSkills[id].evilLevel >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.magicSkills[id].evilLevel = character.NGUController.hardCapNormalLevel();
				}
			}
			if (character.beastQuest.quirkLevel[14] > 0 && character.beastQuest.quirkLevel[89] > 0)
			{
				character.NGU.magicSkills[id].level++;
				if (character.NGU.magicSkills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.magicSkills[id].level = character.NGUController.hardCapNormalLevel();
				}
			}
			updateText();
			updateBar();
		}
	}

	public float bonus(int offset)
	{
		return (float)(character.NGU.magicSkills[id].level + offset) * boostFactor;
	}

	public float sadisticDivider()
	{
		return 10000000f;
	}

	public float progressPerTick()
	{
		double num = character.totalMagicPower() / character.NGUController.magicSpeedDivider(id) * (float)character.NGU.magicSkills[id].magic;
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			if ((float)(character.NGU.magicSkills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].level + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			if ((float)(character.NGU.magicSkills[id].evilLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].evilLevel + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			if ((float)(character.NGU.magicSkills[id].sadisticLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].sadisticLevel + 1);
		}
		num *= (double)character.totalNGUSpeedBonus();
		num *= (double)character.adventureController.itopod.totalMagicNGUBonus();
		num *= (double)character.inventory.macguffinBonuses[5];
		num *= (double)character.NGUController.magicNGUBonus();
		num *= (double)character.allDiggers.totalMagicNGUBonus();
		num *= (double)character.hacksController.totalMagicNGUBonus();
		num *= (double)character.beastQuestPerkController.totalMagicNGUSpeed();
		num *= (double)character.wishesController.totalMagicNGUSpeed();
		num *= (double)character.cardsController.getBonus(cardBonus.magicNGUSpeed);
		if (character.allChallenges.trollChallenge.completions() >= 1)
		{
			num *= 3.0;
		}
		if (character.settings.nguLevelTrack >= difficulty.sadistic)
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
		return (float)num;
	}

	public float progressPerTick1000()
	{
		double num = character.totalMagicPower() / character.NGUController.magicSpeedDivider(id) * (float)character.totalCapMagic();
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			if ((float)(character.NGU.magicSkills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].level + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			if ((float)(character.NGU.magicSkills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].evilLevel + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			if ((float)(character.NGU.magicSkills[id].sadisticLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.magicSkills[id].sadisticLevel + 1);
		}
		num *= (double)character.totalNGUSpeedBonus();
		num *= (double)character.adventureController.itopod.totalMagicNGUBonus();
		num *= (double)character.inventory.macguffinBonuses[5];
		num *= (double)character.NGUController.magicNGUBonus();
		num *= (double)character.allDiggers.totalMagicNGUBonus();
		num *= (double)character.hacksController.totalMagicNGUBonus();
		num *= (double)character.beastQuestPerkController.totalMagicNGUSpeed();
		num *= (double)character.wishesController.totalMagicNGUSpeed();
		num *= (double)character.cardsController.getBonus(cardBonus.magicNGUSpeed);
		if (character.allChallenges.trollChallenge.completions() >= 1)
		{
			num *= 3.0;
		}
		if (character.settings.nguLevelTrack >= difficulty.sadistic)
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
		return (float)num;
	}

	public void add()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.magic.idleMagic)
		{
			num = character.magic.idleMagic;
		}
		character.NGU.magicSkills[id].magic += num;
		character.magic.idleMagic -= num;
		refresh();
	}

	public void cap()
	{
		character.magic.idleMagic += character.NGU.magicSkills[id].magic;
		character.NGU.magicSkills[id].magic = 0L;
		if (character.magic.idleMagic != 0L)
		{
			long num = (long)((float)(character.NGUController.magicNGUCapAmount(id) / (long)Math.Ceiling((double)character.NGUController.magicNGUCapAmount(id) / (double)character.magic.idleMagic)) * 1.000002f);
			if (num + 1 <= long.MaxValue)
			{
				num++;
			}
			if (num > character.magic.idleMagic)
			{
				num = character.magic.idleMagic;
			}
			if (num < 0)
			{
				num = 0L;
			}
			character.NGU.magicSkills[id].magic += num;
			character.magic.idleMagic -= num;
			updateText();
		}
	}

	public void refresh()
	{
		if (character.menuID == 37)
		{
			updateText();
			updateBar();
			updateInput();
			updateCapButton();
		}
	}

	public void updateText()
	{
		if (character.menuID == 37)
		{
			if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 4)
			{
				levelText.text = "";
				energyMagicText.text = "";
			}
			else
			{
				levelText.text = character.display(getLevel());
				energyMagicText.text = character.display(character.NGU.magicSkills[id].magic);
			}
		}
	}

	public void updateBar()
	{
		if (character.menuID != 37)
		{
			return;
		}
		if (character.settings.antiFlickerBars)
		{
			if (progressPerTick() > 0.1f)
			{
				slider.value = progressPerTick();
			}
			else
			{
				slider.value = getProgress();
			}
		}
		else
		{
			slider.value = getProgress();
		}
	}

	public void updateCapButton()
	{
		if (character.settings.beastOn)
		{
			capButton.SetActive(value: true);
		}
		else
		{
			capButton.SetActive(value: false);
		}
	}

	public void remove()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.NGU.magicSkills[id].magic)
		{
			num = character.NGU.magicSkills[id].magic;
		}
		if (num < 0)
		{
			num = 0L;
		}
		character.NGU.magicSkills[id].magic -= num;
		character.magic.idleMagic += num;
		refresh();
	}

	public void removeAll()
	{
		long num = long.MaxValue;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.NGU.magicSkills[id].magic)
		{
			num = character.NGU.magicSkills[id].magic;
		}
		if (num < 0)
		{
			num = 0L;
		}
		character.NGU.magicSkills[id].magic -= num;
		character.magic.idleMagic += num;
		refresh();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("displayTooltip", 0f, 0.1f);
	}

	public float currentBoostFactor()
	{
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return character.NGUController.normalMagicBoostFactor[id];
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGUController.evilMagicBoostFactor[id];
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGUController.sadisticMagicBoostFactor[id];
		}
		return character.NGUController.normalMagicBoostFactor[id];
	}

	private void displayTooltip()
	{
		switch (id)
		{
		case 0:
			message = "<b>NGU YGGDRASIL</b>\n\nMultiplies most fruits' yields by " + currentBoostFactor() * 100f + "% per level. Fruit of Gold and Fruit of Arbitrariness are excluded from this bonus. This NGU has diminishing returns after level 400.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.yggdrasilBonusNormal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.yggdrasilBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.yggdrasilBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.yggdrasilBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 1:
			message = "<b>NGU EXP</b>\n\nMultiplies  all EXP gain by " + currentBoostFactor() * 100f + "% per level. This NGU has sharply diminishing returns after level 2000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.expBonusNormal() * 100f).ToString("###,##0.##") + " %\n<b>Evil Bonus:</b> x" + (character.NGUController.expBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.expBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.expBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 2:
			message = "<b>NGU POWER β</b>\n\nMultiplies (again!) your Attack/Defense stats by " + currentBoostFactor() * 100f + "% per level.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.betaStatBonusNormal() * 100.0) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.betaStatBonusEvil() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.betaStatBonusSadistic() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.betaStatBonus() * 100.0) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 3:
			message = "<b>NGU NUMBER</b>\n\nMultiplies your NUMBER on rebirth by " + currentBoostFactor() * 100f + "% per level. This bonus is scaled by your current rebirth's time factor. This NGU has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.numberBonusNormal() * 100.0) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.numberBonusEvil() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.numberBonusSadistic() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.numberBonus() * 100.0) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 4:
			message = "<b>NGU TIME MACHINE</b>\n\nMultiplies the gold output of the Time Machine by  " + currentBoostFactor() * 100f + "% per level. This NGU has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.timeMachineBonusNormal() * 100.0) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.timeMachineBonusEvil() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.timeMachineBonusSadistic() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.timeMachineBonus() * 100.0) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 5:
			message = "<b>NGU ENERGY NGU</b>\n\nMultiplies the leveling speed of Energy NGU's by " + currentBoostFactor() * 100f + "% per level. This NGU has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.energyNGUBonusNormal() * 100f).ToString("###,##0.##") + " %\n<b>Evil Bonus:</b> x" + (character.NGUController.energyNGUBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.energyNGUBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.energyNGUBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 6:
			message = "<b>NGU ADVENTURE β</b>\n\nMultiplies Adventure stats by " + currentBoostFactor() * 100f + "% per level. This NGU has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.adventureBonus2Normal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.adventureBonus2Evil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.adventureBonus2Sadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.adventureBonus2() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		default:
			message = "Tell 4g he goofed.";
			break;
		}
		tooltip.showTooltip(message);
	}

	public string timeLeft()
	{
		float seconds = 0f;
		if (progressPerTick() == 0f)
		{
			if (character.settings.nguLevelTrack == difficulty.normal)
			{
				seconds = (1f - character.NGU.magicSkills[id].progress) / progressPerTick1000() / 50f;
			}
			if (character.settings.nguLevelTrack == difficulty.evil)
			{
				seconds = (1f - character.NGU.magicSkills[id].evilProgress) / progressPerTick1000() / 50f;
			}
			if (character.settings.nguLevelTrack == difficulty.sadistic)
			{
				seconds = (1f - character.NGU.magicSkills[id].sadisticProgress) / progressPerTick1000() / 50f;
			}
			return NumberOutput.timeOutput(seconds) + " (with " + character.display(character.totalCapMagic()) + " Magic)";
		}
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			seconds = (1f - character.NGU.magicSkills[id].progress) / progressPerTick() / 50f;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			seconds = (1f - character.NGU.magicSkills[id].evilProgress) / progressPerTick() / 50f;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			seconds = (1f - character.NGU.magicSkills[id].sadisticProgress) / progressPerTick() / 50f;
		}
		return NumberOutput.timeOutput(seconds);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
		CancelInvoke("displayTooltip");
	}

	public void reset()
	{
		character.NGU.magicSkills[id].energy = 0L;
		character.NGU.magicSkills[id].magic = 0L;
	}

	public void removeAllMagic()
	{
		long magic = character.NGU.magicSkills[id].magic;
		character.magic.idleMagic += magic;
		character.NGU.magicSkills[id].magic -= magic;
	}

	public float getProgress()
	{
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return character.NGU.magicSkills[id].progress;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGU.magicSkills[id].evilProgress;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGU.magicSkills[id].sadisticProgress;
		}
		return character.NGU.magicSkills[id].progress;
	}

	public long getLevel()
	{
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return character.NGU.magicSkills[id].level;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGU.magicSkills[id].evilLevel;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGU.magicSkills[id].sadisticLevel;
		}
		return character.NGU.magicSkills[id].level;
	}

	public void setTarget()
	{
		long num = 0L;
		try
		{
			num = long.Parse(magicTarget.text);
		}
		catch (Exception)
		{
			num = 0L;
		}
		if (num < -1)
		{
			num = 0L;
		}
		if (num > long.MaxValue)
		{
			num = 0L;
		}
		switch (character.settings.nguLevelTrack)
		{
		case difficulty.normal:
			character.NGU.magicSkills[id].target = num;
			magicTarget.text = num.ToString();
			break;
		case difficulty.evil:
			character.NGU.magicSkills[id].evilTarget = num;
			magicTarget.text = num.ToString();
			break;
		case difficulty.sadistic:
			character.NGU.magicSkills[id].sadisticTarget = num;
			magicTarget.text = num.ToString();
			break;
		default:
			character.NGU.magicSkills[id].target = num;
			magicTarget.text = num.ToString();
			break;
		}
		updateInput();
	}

	public void updateInput()
	{
		switch (character.settings.nguLevelTrack)
		{
		case difficulty.normal:
			magicTarget.text = character.NGU.magicSkills[id].target.ToString();
			break;
		case difficulty.evil:
			magicTarget.text = character.NGU.magicSkills[id].evilTarget.ToString();
			break;
		case difficulty.sadistic:
			magicTarget.text = character.NGU.magicSkills[id].sadisticTarget.ToString();
			break;
		}
	}
}
