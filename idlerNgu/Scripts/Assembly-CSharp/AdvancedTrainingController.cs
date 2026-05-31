using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AdvancedTrainingController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public AllAdvancedTraining alladvancedTraining;

	public int id;

	public Text nameText;

	public Text levelText;

	public Text energyText;

	public Slider trainProgress;

	public InputField energyRequested;

	public InputField target;

	public HoverTooltip tooltip;

	public Button addButton;

	public Button minusButton;

	public float baseTime;

	public float levelFactor;

	public string trainingName;

	public string trainingDescription;

	private void Start()
	{
		updateText();
		updateBar();
		nameText.text = trainingName;
		target.text = character.advancedTraining.levelTarget[id].ToString();
		InvokeRepeating("updateAdvancedTraining", 0f, 0.02f);
	}

	public void refresh()
	{
		if (character.menuID == 17)
		{
			if ((id == 3 || id == 4) && !character.settings.wandoos98On)
			{
				trainProgress.gameObject.SetActive(value: false);
				target.gameObject.SetActive(value: false);
				nameText.gameObject.SetActive(value: false);
				levelText.text = "";
				energyText.text = "";
				addButton.gameObject.SetActive(value: false);
				minusButton.gameObject.SetActive(value: false);
			}
			else
			{
				nameText.gameObject.SetActive(value: true);
				trainProgress.gameObject.SetActive(value: true);
				target.gameObject.SetActive(value: true);
				addButton.gameObject.SetActive(value: true);
				minusButton.gameObject.SetActive(value: true);
				updateText();
				updateBar();
			}
		}
	}

	public float progressPerTick()
	{
		double num = 0.0;
		if (getDivisor() == 0f)
		{
			return 0f;
		}
		if (character.wishes.wishes[190].level >= 1)
		{
			return 1f;
		}
		num = (float)character.advancedTraining.energy[id] / 50f * Mathf.Sqrt(character.totalEnergyPower()) * character.totalAdvancedTrainingSpeedBonus() / getDivisor();
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
		if (getDivisor() == 0f)
		{
			return 0f;
		}
		if (character.wishes.wishes[190].level >= 1)
		{
			return 1f;
		}
		num = (float)character.totalCapEnergy() / 50f * Mathf.Sqrt(character.totalEnergyPower()) * character.totalAdvancedTrainingSpeedBonus() / getDivisor();
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

	public float progressPerTick(bool nopot)
	{
		double num = 0.0;
		if (getDivisor() == 0f)
		{
			return 0f;
		}
		if (character.wishes.wishes[190].level >= 1)
		{
			return 1f;
		}
		num = (float)character.advancedTraining.energy[id] / 50f * Mathf.Sqrt(character.totalEnergyPower() / 2f) * character.totalAdvancedTrainingSpeedBonus() / getDivisor();
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

	public float getDivisor()
	{
		return baseTime * ((float)character.advancedTraining.level[id] + 1f);
	}

	private void updateAdvancedTraining()
	{
		if (character.training.attackTraining[4] < 25000 || character.training.defenseTraining[4] < 25000 || getDivisor() == 0f || (character.advancedTraining.energy[id] <= 0 && character.wishes.wishes[190].level <= 0))
		{
			return;
		}
		if (hitTarget())
		{
			character.advancedTrainingController.advanceEnergy(id);
			return;
		}
		character.advancedTraining.barProgress[id] += progressPerTick();
		updateBar();
		if (character.advancedTraining.barProgress[id] >= 1f)
		{
			character.advancedTraining.barProgress[id] = 0f;
			if (character.canLevel())
			{
				character.advancedTraining.level[id]++;
				character.settings.rebirthLevels++;
				updateText();
			}
		}
	}

	public bool hitTarget()
	{
		if (character.advancedTraining.levelTarget[id] == 0L)
		{
			return false;
		}
		if (character.advancedTraining.energy[id] == 0L)
		{
			return false;
		}
		return character.advancedTraining.level[id] >= character.advancedTraining.levelTarget[id];
	}

	public void addEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.idleEnergy)
		{
			character.advancedTraining.energy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		else
		{
			character.advancedTraining.energy[id] += num;
			character.idleEnergy -= num;
		}
		updateText();
	}

	public void removeEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.advancedTraining.energy[id])
		{
			character.idleEnergy += character.advancedTraining.energy[id];
			character.advancedTraining.energy[id] = 0L;
		}
		else
		{
			character.idleEnergy += num;
			character.advancedTraining.energy[id] = character.advancedTraining.energy[id] - num;
		}
		updateText();
	}

	public void levelUp()
	{
		character.advancedTraining.level[id]++;
	}

	public string timeLeft()
	{
		if ((float)character.advancedTraining.energy[id] == 0f)
		{
			return NumberOutput.timeOutput((1f - character.advancedTraining.barProgress[id]) / progressPerTick1000() / 50f) + " (with " + character.display(character.totalCapEnergy()) + " Energy)";
		}
		return NumberOutput.timeOutput((1f - character.advancedTraining.barProgress[id]) / progressPerTick() / 50f);
	}

	public string bonusText()
	{
		string text = "";
		switch (id)
		{
		case 0:
			return "<b>" + trainingName + "</b>\nEach level gained improves your Toughness stat in Adventure!\n\n<b>Current Bonus: </b>" + (alladvancedTraining.adventureToughnessBonus(0) * 100f).ToString("###,##0.##") + "%\n<b>Next: </b>" + (alladvancedTraining.adventureToughnessBonus(1) * 100f).ToString("###,##0.##") + "%";
		case 1:
			return "<b>" + trainingName + "</b>\nEach level gained improves your Power stat in Adventure!\n\n<b>Current Bonus: </b>" + (alladvancedTraining.adventurePowerBonus(0) * 100f).ToString("###,##0.##") + "%\n<b>Next: </b>" + (alladvancedTraining.adventurePowerBonus(1) * 100f).ToString("###,##0.##") + "%";
		case 2:
			return "<b>" + trainingName + "</b>\nEach level gained improves the effectiveness of Block in Adventure!\n\n<b>Current Block Reduction: </b>" + ((1f - blockBonus(0)) * 100f).ToString("##.0#") + "%\n<b>Next: </b>" + ((1f - blockBonus(1)) * 100f).ToString("##.0#") + "%";
		case 3:
			return "<b>" + trainingName + "</b>\nEach level gained increases the levelling speed of Energy Dump in the Wandoos feature!\n\n<b>Current Bonus: </b>" + (100f * trainingBonus(0)).ToString("###,##0") + "%\n<b>Next: </b>" + (100f * trainingBonus(1)).ToString("###,##0") + "%";
		case 4:
			return "<b>" + trainingName + "</b>\nEach level gained increases the levelling speed of Magic Dump in the Wandoos feature!\n\n<b>Current Bonus: </b>" + (100f * trainingBonus(0)).ToString("###,##0") + "%\n<b>Next: </b>" + (100f * trainingBonus(1)).ToString("###,##0") + "%";
		default:
			return "<b>" + trainingName + "</b>\n\n<b>Current Bonus: </b>" + (100f * trainingBonus(0)).ToString("###,##0") + "%\n<b>Next: </b>" + (100f * trainingBonus(1)).ToString("###,##0") + "</b>%";
		}
	}

	public float trainingBonus(int offset)
	{
		if (character.advancedTraining.level[id] + offset <= 0)
		{
			return 0f;
		}
		return levelFactor * (float)(character.advancedTraining.level[id] + offset);
	}

	public float blockBonus(int offset)
	{
		if ((float)(character.advancedTraining.level[id] + offset) <= 0f)
		{
			return 0.5f;
		}
		if (levelFactor * (float)(character.advancedTraining.level[id] + offset) == 0f)
		{
			return 0f;
		}
		float num = 1f + levelFactor * (float)(character.advancedTraining.level[id] + offset);
		return 50f / num / 100f;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	public void showTooltip()
	{
		tooltip.showTooltip(bonusText() + "\n<b>Time to levelup:</b> " + timeLeft());
	}

	public void checkTargetInput()
	{
		long num = long.Parse(target.text);
		if (num < -1)
		{
			num = 0L;
		}
		if (num > 2000000000)
		{
			num = 0L;
		}
		target.text = num.ToString();
		character.advancedTraining.levelTarget[id] = num;
	}

	public void removeAllEnergy()
	{
		long num = character.advancedTraining.energy[id];
		character.idleEnergy += num;
		character.advancedTraining.energy[id] -= num;
		refresh();
	}

	public void updateBar()
	{
		if (character.menuID != 17)
		{
			return;
		}
		if (character.settings.antiFlickerBars)
		{
			if (progressPerTick() > 0.1f)
			{
				trainProgress.value = progressPerTick();
			}
			else
			{
				trainProgress.value = character.advancedTraining.barProgress[id];
			}
		}
		else
		{
			trainProgress.value = character.advancedTraining.barProgress[id];
		}
	}

	public void updateText()
	{
		if (character.menuID == 17)
		{
			target.text = character.advancedTraining.levelTarget[id].ToString();
			levelText.text = character.display(character.advancedTraining.level[id]);
			energyText.text = character.display(character.advancedTraining.energy[id]);
		}
	}

	public void reset()
	{
		updateText();
		updateBar();
	}
}
