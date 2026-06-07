using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NGUController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Slider slider;

	public Text nguName;

	public Text levelText;

	public Text energyMagicText;

	public InputField energyRequested;

	public InputField target;

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
		if (character.NGU.skills[id].energy <= 0)
		{
			return;
		}
		if (character.NGUController.reachedTarget(id))
		{
			character.NGUController.autoAdvanceEnergy(id);
		}
		else if (character.settings.nguLevelTrack == difficulty.normal)
		{
			character.NGU.skills[id].progress += progressPerTick();
			updateBar();
			if (character.NGU.skills[id].progress >= 1f)
			{
				character.NGU.skills[id].progress = 0f;
				character.NGU.skills[id].level++;
				if (character.NGU.skills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.skills[id].level = character.NGUController.hardCapNormalLevel();
				}
				updateText();
				updateBar();
			}
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			character.NGU.skills[id].evilProgress += progressPerTick();
			updateBar();
			if (!(character.NGU.skills[id].evilProgress >= 1f))
			{
				return;
			}
			character.NGU.skills[id].evilProgress = 0f;
			character.NGU.skills[id].evilLevel++;
			if (character.NGU.skills[id].evilLevel >= character.NGUController.hardCapNormalLevel())
			{
				character.NGU.skills[id].evilLevel = character.NGUController.hardCapNormalLevel();
			}
			if (character.beastQuest.quirkLevel[14] > 0)
			{
				character.NGU.skills[id].level++;
				if (character.NGU.skills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.skills[id].level = character.NGUController.hardCapNormalLevel();
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
			character.NGU.skills[id].sadisticProgress += progressPerTick();
			updateBar();
			if (!(character.NGU.skills[id].sadisticProgress >= 1f))
			{
				return;
			}
			character.NGU.skills[id].sadisticProgress = 0f;
			character.NGU.skills[id].sadisticLevel++;
			if (character.NGU.skills[id].sadisticLevel >= character.NGUController.hardCapNormalLevel())
			{
				character.NGU.skills[id].sadisticLevel = character.NGUController.hardCapNormalLevel();
			}
			if (character.beastQuest.quirkLevel[89] > 0)
			{
				character.NGU.skills[id].evilLevel++;
				if (character.NGU.skills[id].evilLevel >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.skills[id].evilLevel = character.NGUController.hardCapNormalLevel();
				}
			}
			if (character.beastQuest.quirkLevel[14] > 0 && character.beastQuest.quirkLevel[89] > 0)
			{
				character.NGU.skills[id].level++;
				if (character.NGU.skills[id].level >= character.NGUController.hardCapNormalLevel())
				{
					character.NGU.skills[id].level = character.NGUController.hardCapNormalLevel();
				}
			}
			updateText();
			updateBar();
		}
	}

	public float bonus(int offset)
	{
		if (id == 2)
		{
			float num = 1f - (float)(character.NGU.skills[id].level + offset) * boostFactor;
			if (num <= 0.8f)
			{
				num = 0.8f;
			}
			return num;
		}
		return (float)(character.NGU.skills[id].level + offset) * boostFactor;
	}

	public float evilBonus(int offset)
	{
		if (id == 2)
		{
			float num = 1f - (float)(character.NGU.skills[id].level + offset) * boostFactor;
			if (num <= 0.8f)
			{
				num = 0.8f;
			}
			return num;
		}
		return (float)(character.NGU.skills[id].level + offset) * boostFactor;
	}

	public float sadisticBonus(int offset)
	{
		if (id == 2)
		{
			float num = 1f - (float)(character.NGU.skills[id].level + offset) * boostFactor;
			if (num <= 0.8f)
			{
				num = 0.8f;
			}
			return num;
		}
		return (float)(character.NGU.skills[id].level + offset) * boostFactor;
	}

	public float sadisticDivider()
	{
		return 10000000f;
	}

	public float progressPerTick()
	{
		double num = character.totalEnergyPower() / character.NGUController.energySpeedDivider(id) * (float)character.NGU.skills[id].energy;
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			if ((float)(character.NGU.skills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].level + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			if ((float)(character.NGU.skills[id].evilLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].evilLevel + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			if ((float)(character.NGU.skills[id].sadisticLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].sadisticLevel + 1);
		}
		num *= (double)character.totalNGUSpeedBonus();
		num *= (double)character.adventureController.itopod.totalEnergyNGUBonus();
		num *= (double)character.inventory.macguffinBonuses[4];
		num *= (double)character.NGUController.energyNGUBonus();
		num *= (double)character.allDiggers.totalEnergyNGUBonus();
		num *= (double)character.hacksController.totalEnergyNGUBonus();
		num *= (double)character.beastQuestPerkController.totalEnergyNGUSpeed();
		num *= (double)character.wishesController.totalEnergyNGUSpeed();
		num *= (double)character.cardsController.getBonus(cardBonus.energyNGUSpeed);
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 1)
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
		double num = 1.0;
		num = character.totalEnergyPower() / character.NGUController.energySpeedDivider(id) * (float)character.totalCapEnergy();
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			if ((float)(character.NGU.skills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].level + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.evil)
		{
			if ((float)(character.NGU.skills[id].level + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].evilLevel + 1);
		}
		else if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			if ((float)(character.NGU.skills[id].sadisticLevel + 1) == 0f)
			{
				return 0f;
			}
			num /= (double)(character.NGU.skills[id].sadisticLevel + 1);
		}
		num *= (double)character.totalNGUSpeedBonus();
		num *= (double)character.adventureController.itopod.totalEnergyNGUBonus();
		num *= (double)character.inventory.macguffinBonuses[4];
		num *= (double)character.NGUController.energyNGUBonus();
		num *= (double)character.allDiggers.totalEnergyNGUBonus();
		num *= (double)character.hacksController.totalEnergyNGUBonus();
		num *= (double)character.beastQuestPerkController.totalEnergyNGUSpeed();
		num *= (double)character.wishesController.totalEnergyNGUSpeed();
		num *= (double)character.cardsController.getBonus(cardBonus.energyNGUSpeed);
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 1)
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
		if (num >= character.idleEnergy)
		{
			num = character.idleEnergy;
		}
		character.NGU.skills[id].energy += num;
		character.idleEnergy -= num;
		refresh();
	}

	public void cap()
	{
		character.idleEnergy += character.NGU.skills[id].energy;
		character.NGU.skills[id].energy = 0L;
		if (character.idleEnergy != 0L)
		{
			long num = (long)((float)(character.NGUController.energyNGUCapAmount(id) / (long)Math.Ceiling((double)character.NGUController.energyNGUCapAmount(id) / (double)character.idleEnergy)) * 1.000002f);
			if (num + 1 <= long.MaxValue)
			{
				num++;
			}
			if (num > character.idleEnergy)
			{
				num = character.idleEnergy;
			}
			if (num < 0)
			{
				num = 0L;
			}
			character.NGU.skills[id].energy += num;
			character.idleEnergy -= num;
			updateText();
		}
	}

	public void refresh()
	{
		if (character.menuID == 8)
		{
			updateText();
			updateBar();
			updateInput();
			updateCapButton();
		}
	}

	public void updateText()
	{
		if (character.menuID == 8)
		{
			if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 4)
			{
				levelText.text = "";
				energyMagicText.text = "";
			}
			else
			{
				levelText.text = character.display(getLevel());
				energyMagicText.text = character.display(character.NGU.skills[id].energy);
			}
		}
	}

	public void updateBar()
	{
		if (character.menuID != 8)
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

	public float getProgress()
	{
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return character.NGU.skills[id].progress;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGU.skills[id].evilProgress;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGU.skills[id].sadisticProgress;
		}
		return character.NGU.skills[id].progress;
	}

	public long getLevel()
	{
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			return character.NGU.skills[id].level;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGU.skills[id].evilLevel;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGU.skills[id].sadisticLevel;
		}
		return character.NGU.skills[id].level;
	}

	public void remove()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
			return;
		}
		if (num > character.NGU.skills[id].energy)
		{
			num = character.NGU.skills[id].energy;
		}
		character.NGU.skills[id].energy -= num;
		character.idleEnergy += num;
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
		if (num > character.NGU.skills[id].energy)
		{
			num = character.NGU.skills[id].energy;
		}
		if (num < 0)
		{
			num = 0L;
		}
		character.NGU.skills[id].energy -= num;
		character.idleEnergy += num;
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
			return character.NGUController.normalEnergyBoostFactor[id];
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			return character.NGUController.evilEnergyBoostFactor[id];
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			return character.NGUController.sadisticEnergyBoostFactor[id];
		}
		return character.NGUController.normalEnergyBoostFactor[id];
	}

	private void displayTooltip()
	{
		switch (id)
		{
		case 0:
			message = "<b>NGU AUGMENTS</b>\n\nMultiplies your total Augment effect by " + currentBoostFactor() * 100f + "% per level.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.augmentBonusNormal() * 100.0) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.augmentBonusEvil() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b>x" + character.display(character.NGUController.augmentBonusSadistic() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.augmentBonus() * 100.0) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 1:
			message = "<b>NGU WANDOOS</b>\n\nMultiplies your total Wandoos speed by " + currentBoostFactor() * 100f + "% per level.";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += " Evil NGU WANDOOS has diminishing returns after level 1000.";
			}
			message += "\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.wandoosBonusNormal() * 100f) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.wandoosBonusEvil() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b>x" + character.display(character.NGUController.wandoosBonusSadistic() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.wandoosBonus() * 100f) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 2:
			message = "<b>NGU RESPAWN</b>\n\nReduces your total respawn time by " + currentBoostFactor() * 100f + "% per level.";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += " Evil NGU RESPAWN has diminishing returns after level 10000.\n\n";
			}
			else
			{
				message += " This has diminishing returns after level 400.\n\n";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.respawnBonusNormal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.respawnBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.respawnBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.respawnBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 3:
			message = "<b>NGU GOLD</b>\n\nMultiplies your gold drops by " + currentBoostFactor() * 100f + "% per level.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.goldBonusNormal() * 100f) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.goldBonusEvil() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.goldBonusSadistic() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.goldBonus() * 100f) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 4:
			message = "<b>NGU ADVENTURE α</b>\n\nMultiplies your Adventure stats by " + currentBoostFactor() * 100f + "% per level.This has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.adventureBonusNormal() * 100f) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.adventureBonusEvil() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.adventureBonusSadistic() * 100f) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + character.display(character.NGUController.adventureBonus() * 100f) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 5:
			message = "<b>NGU POWER α</b>\n\nMultiplies your Attack/Defense stats by " + currentBoostFactor() * 100f + "% per level.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + character.display(character.NGUController.alphaStatBonusNormal() * 100.0) + "%\n<b>Evil Bonus:</b> x" + character.display(character.NGUController.alphaStatBonusEvil() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + character.display(character.NGUController.alphaStatBonusSadistic() * 100.0) + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus</b> " + character.display(character.NGUController.alphaStatBonus() * 100.0) + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 6:
			message = "<b>NGU DROP CHANCE</b>\n\nMultiplies your drop chance by " + currentBoostFactor() * 100f + "% per level. This has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.lootBonusNormal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.lootBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.lootBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.lootBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 7:
			message = "<b>NGU MAGIC NGU</b>\n\nMultiplies your Magic NGU speed by " + currentBoostFactor() * 100f + "% per level. This has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.magicNGUBonusNormal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.magicNGUBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.magicNGUBonusSadistic() * 100f).ToString("###,##0.##") + " %";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.magicNGUBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
			break;
		case 8:
			message = "<b>NGU PP</b>\n\nMultiplies PP progress for ITOPOD kills by " + currentBoostFactor() * 100f + "% per level. This has diminishing returns after level 1000.\n\n";
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message = message + "<b>Normal Bonus:</b> " + (character.NGUController.PPBonusNormal() * 100f).ToString("###,##0.##") + "%\n<b>Evil Bonus:</b> x" + (character.NGUController.PPBonusEvil() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.sadistic)
			{
				message = message + "\n<b>SADISTIC Bonus:</b> x" + (character.NGUController.PPBonusSadistic() * 100f).ToString("###,##0.##") + "%";
			}
			if (character.settings.rebirthDifficulty >= difficulty.evil)
			{
				message += "\n";
			}
			message = message + "\n<b>Total Bonus:</b> " + (character.NGUController.PPBonus() * 100f).ToString("###,##0.##") + "%";
			message = message + "\n<b>Time Remaining: </b>" + timeLeft();
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
				seconds = (1f - character.NGU.skills[id].progress) / progressPerTick1000() / 50f;
			}
			if (character.settings.nguLevelTrack == difficulty.evil)
			{
				seconds = (1f - character.NGU.skills[id].evilProgress) / progressPerTick1000() / 50f;
			}
			if (character.settings.nguLevelTrack == difficulty.sadistic)
			{
				seconds = (1f - character.NGU.skills[id].sadisticProgress) / progressPerTick1000() / 50f;
			}
			return NumberOutput.timeOutput(seconds) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		if (character.settings.nguLevelTrack == difficulty.normal)
		{
			seconds = (1f - character.NGU.skills[id].progress) / progressPerTick() / 50f;
		}
		if (character.settings.nguLevelTrack == difficulty.evil)
		{
			seconds = (1f - character.NGU.skills[id].evilProgress) / progressPerTick() / 50f;
		}
		if (character.settings.nguLevelTrack == difficulty.sadistic)
		{
			seconds = (1f - character.NGU.skills[id].sadisticProgress) / progressPerTick() / 50f;
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
		character.NGU.skills[id].energy = 0L;
		character.NGU.skills[id].magic = 0L;
	}

	public void removeAllEnergy()
	{
		long energy = character.NGU.skills[id].energy;
		character.idleEnergy += energy;
		character.NGU.skills[id].energy -= energy;
	}

	public void setTarget()
	{
		long num = 0L;
		try
		{
			num = long.Parse(target.text);
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
			character.NGU.skills[id].target = num;
			target.text = num.ToString();
			break;
		case difficulty.evil:
			character.NGU.skills[id].evilTarget = num;
			target.text = num.ToString();
			break;
		case difficulty.sadistic:
			character.NGU.skills[id].sadisticTarget = num;
			target.text = num.ToString();
			break;
		default:
			character.NGU.skills[id].target = num;
			target.text = num.ToString();
			break;
		}
		updateInput();
	}

	public void updateInput()
	{
		switch (character.settings.nguLevelTrack)
		{
		case difficulty.normal:
			target.text = character.NGU.skills[id].target.ToString();
			break;
		case difficulty.evil:
			target.text = character.NGU.skills[id].evilTarget.ToString();
			break;
		case difficulty.sadistic:
			target.text = character.NGU.skills[id].sadisticTarget.ToString();
			break;
		}
	}
}
