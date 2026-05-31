using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OffenseTraining : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Text levelText;

	public Text energyText;

	public Slider trainProgress;

	public Character character;

	public InputField energyRequested;

	public HoverTooltip tooltip;

	private string tooltipMessage = "";

	public Text nextAttackName;

	public Button nextAdd;

	public Button nextMinus;

	public Button nextCap;

	public Toggle autoAdvanceToggle;

	public NumberFormat format;

	public AllOffenseTraining allOffense;

	public int id;

	public double levelFactor = 1.0;

	private void Start()
	{
		nextAttackName.transform.SetAsLastSibling();
		checkText();
		updateText();
		checkButtons();
		InvokeRepeating("updateOffenseTraining", 0f, 0.02f);
		InvokeRepeating("checkButtons", 0f, 0.02f);
		InvokeRepeating("checkText", 0f, 0.5f);
	}

	public bool locked()
	{
		if (id == 0)
		{
			return false;
		}
		return character.training.attackTraining[id - 1] <= id * 5000;
	}

	public void checkButtons()
	{
		if (character.training.attackTraining[id] >= (id + 1) * 5000)
		{
			turnOnButtons();
		}
		else
		{
			turnOffButtons();
		}
		if (visible())
		{
			turnOnUI();
		}
		else
		{
			turnOffUI();
		}
	}

	public bool visible()
	{
		if (id <= 1)
		{
			return true;
		}
		if (character.training.attackTraining[id - 2] >= (id - 1) * 5000)
		{
			return true;
		}
		return false;
	}

	public void updateOffenseTraining()
	{
		if (character.training.attackTraining[id] >= (id + 1) * 5000 && character.purchases.hasAutoAdvance && autoAdvanceToggle.isOn && character.training.attackEnergy[id] > character.training.attackCaps[id])
		{
			autoAdvance();
		}
		if (character.training.attackEnergy[id] >= character.training.attackCaps[id])
		{
			character.training.attackBarProgress[id] = 1f;
			trainProgress.value = character.training.attackBarProgress[id];
			levelUp();
			return;
		}
		float num = (float)character.training.attackEnergy[id] / (float)character.training.attackCaps[id];
		character.training.attackBarProgress[id] += num;
		updateSlider(num);
		if (character.training.attackBarProgress[id] >= 1f)
		{
			levelUp();
		}
	}

	private void updateSlider(float toAdd)
	{
		if (character.menuID != 0)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 1)
		{
			trainProgress.value = 0f;
		}
		else if (character.settings.antiFlickerBars && toAdd > 0.1f)
		{
			if (trainProgress.value != toAdd)
			{
				trainProgress.value = toAdd;
			}
		}
		else if (trainProgress.value != character.training.attackBarProgress[id])
		{
			trainProgress.value = character.training.attackBarProgress[id];
		}
	}

	public void levelUp()
	{
		character.training.attackBarProgress[id] = 0f;
		if (character.training.attackTraining[id] >= 9223372036854775805L)
		{
			character.training.attackTraining[id] = long.MaxValue;
			return;
		}
		character.training.attackTraining[id]++;
		character.training.totalAttackLevels++;
		if (character.adventure.itopod.perkLevel[15] >= 1)
		{
			character.training.attackTraining[id]++;
			character.training.totalAttackLevels++;
		}
		if (character.beastQuest.quirkLevel[17] >= 1)
		{
			character.training.attackTraining[id]++;
			character.training.totalAttackLevels++;
		}
		if (character.wishes.wishes[23].level >= 1)
		{
			character.training.attackTraining[id]++;
			character.training.totalAttackLevels++;
		}
		updateText();
		if (character.training.attackTraining[id] == (id + 1) * 5000)
		{
			unlockedText();
			checkButtons();
			if (character.purchases.hasAutoAdvance && autoAdvanceToggle.isOn)
			{
				autoAdvance();
			}
		}
	}

	public void addEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (character.settings.syncTraining && num > character.idleEnergy / 2)
		{
			num = character.idleEnergy / 2;
		}
		if (num >= character.idleEnergy)
		{
			character.training.attackEnergy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		else
		{
			character.training.attackEnergy[id] += num;
			character.idleEnergy -= num;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allDefenseController.trains[id].addEnergy(num);
		}
	}

	public void addEnergy(long amount)
	{
		if (!locked())
		{
			long num = amount;
			if (num < 0)
			{
				num = 0L;
			}
			if (num >= character.idleEnergy)
			{
				character.training.attackEnergy[id] += character.idleEnergy;
				character.idleEnergy = 0L;
			}
			else
			{
				character.training.attackEnergy[id] += num;
				character.idleEnergy -= num;
			}
			updateText();
		}
	}

	public void removeEnergy()
	{
		long num = character.input.energyMagicInput;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.training.attackEnergy[id])
		{
			character.idleEnergy += character.training.attackEnergy[id];
			character.training.attackEnergy[id] = 0L;
		}
		else
		{
			character.idleEnergy += num;
			character.training.attackEnergy[id] = character.training.attackEnergy[id] - num;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allDefenseController.trains[id].removeEnergy(num);
		}
	}

	public void removeEnergy(long amount)
	{
		if (!locked())
		{
			long num = amount;
			if (num < 0)
			{
				num = 0L;
			}
			if (num >= character.training.attackEnergy[id])
			{
				character.idleEnergy += character.training.attackEnergy[id];
				character.training.attackEnergy[id] = 0L;
			}
			else
			{
				character.idleEnergy += num;
				character.training.attackEnergy[id] = character.training.attackEnergy[id] - num;
			}
			updateText();
		}
	}

	public void cap()
	{
		character.idleEnergy += character.training.attackEnergy[id];
		character.training.attackEnergy[id] = 0L;
		if (character.idleEnergy > character.training.attackCaps[id])
		{
			character.idleEnergy -= character.training.attackCaps[id];
			character.training.attackEnergy[id] += character.training.attackCaps[id];
			if (character.settings.syncTraining)
			{
				character.allDefenseController.trains[id].cap(stop: false);
			}
			return;
		}
		long num = Mathf.CeilToInt((float)character.training.attackCaps[id] / (float)Mathf.CeilToInt((float)character.training.attackCaps[id] / (float)character.idleEnergy));
		character.idleEnergy -= num;
		character.training.attackEnergy[id] += num;
		if (character.settings.syncTraining)
		{
			character.allDefenseController.trains[id].cap(stop: false);
		}
		updateText();
	}

	public void cap(bool stop)
	{
		if (!locked())
		{
			character.idleEnergy += character.training.attackEnergy[id];
			character.training.attackEnergy[id] = 0L;
			if (character.idleEnergy > character.training.attackCaps[id])
			{
				character.idleEnergy -= character.training.attackCaps[id];
				character.training.attackEnergy[id] += character.training.attackCaps[id];
				return;
			}
			long num = Mathf.CeilToInt((float)character.training.attackCaps[id] / (float)Mathf.CeilToInt((float)character.training.attackCaps[id] / (float)character.idleEnergy));
			character.idleEnergy -= num;
			character.training.attackEnergy[id] += num;
			updateText();
		}
	}

	public void autoAdvance()
	{
		if (id != 5 && character.training.attackEnergy[id] >= 2)
		{
			long num = Math.Max(character.training.attackEnergy[id] - character.training.attackCaps[id], 0L);
			character.training.attackEnergy[id + 1] += num;
			character.training.attackEnergy[id] -= num;
			allOffense.refresh();
		}
	}

	public void add6()
	{
		if (character.idleEnergy > 6)
		{
			character.idleEnergy -= 6L;
			character.training.attackEnergy[id] += 6L;
		}
		else
		{
			character.training.attackEnergy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		updateText();
	}

	public void addSum()
	{
		long num = 0L;
		for (int i = 0; i < character.training.attackTraining.Length; i++)
		{
			num += character.training.attackCaps[i];
		}
		if (num < 0)
		{
			num = 0L;
		}
		if (character.idleEnergy > num)
		{
			character.idleEnergy -= num;
			character.training.attackEnergy[id] += num;
		}
		else
		{
			character.training.attackEnergy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allDefenseController.trains[id].addEnergy(num);
		}
	}

	public void showTooltip()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		long num = (long)(1f + Mathf.Pow((float)character.training.attackTraining[id] - 500f * (float)id, 1.2f) / 500f * ((float)character.training.attackCaps[id] / 1000f));
		if (num <= 1)
		{
			num = 1L;
		}
		if (character.training.attackTraining[id] == 0L)
		{
			num = 0L;
		}
		long num2 = character.training.attackCaps[id] / 10 + 1;
		if (num > num2)
		{
			num = num2;
		}
		if (character.training.attackCaps[id] - num <= 1)
		{
			num = character.training.attackCaps[id] - 1;
		}
		tooltipMessage = "Levels gained in this Attack skill will decrease the amount of Energy needed to cap leveling speed upon Rebirth.\nCapped speed currently achieved with " + character.training.attackCaps[id].ToString("###,##0") + " Energy.\nOn Rebirth, your new cap will be ";
		if (num == num2 && character.training.attackCaps[id] != 0)
		{
			tooltipMessage = tooltipMessage + "<color=green>" + (character.training.attackCaps[id] - num).ToString("###,##0") + "</color>\n(Maximum cap reduction reached this rebirth!)";
		}
		else
		{
			tooltipMessage += (character.training.attackCaps[id] - num).ToString("###,##0");
		}
		tooltipMessage = tooltipMessage + "\nBase Attack received per level is " + character.display(character.training.trainFactor[id]);
		tooltip.showTooltip(tooltipMessage);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public void updateText()
	{
		if (character.menuID != 0)
		{
			return;
		}
		if (character.challenges.blindChallenge.inChallenge)
		{
			levelText.text = "";
			energyText.text = "";
		}
		else if (!visible())
		{
			if (levelText.text != "")
			{
				levelText.text = "";
			}
			if (energyText.text != "")
			{
				energyText.text = "";
			}
		}
		else
		{
			levelText.text = NumberOutput.suffixFormat(character.training.attackTraining[id], character.settings.numberDisplay);
			energyText.text = NumberOutput.suffixFormat(character.training.attackEnergy[id], character.settings.numberDisplay);
		}
	}

	public void refresh()
	{
		updateText();
	}

	public void reset()
	{
		if (id != 5)
		{
			nextAttackName.text = "Locked";
		}
		levelText.text = "0";
		energyText.text = "0";
		turnOffButtons();
		lockedText();
	}

	private void turnOffButtons()
	{
		if (id != 5)
		{
			nextAdd.gameObject.SetActive(value: false);
			nextMinus.gameObject.SetActive(value: false);
			nextCap.gameObject.SetActive(value: false);
		}
	}

	private void turnOnButtons()
	{
		if (id != 5)
		{
			nextAdd.gameObject.SetActive(value: true);
			nextMinus.gameObject.SetActive(value: true);
			nextCap.gameObject.SetActive(value: true);
		}
	}

	private void turnOnUI()
	{
		trainProgress.gameObject.SetActive(value: true);
	}

	private void turnOffUI()
	{
		trainProgress.gameObject.SetActive(value: false);
	}

	public void checkText()
	{
		if (character.training.attackTraining[id] >= (id + 1) * 5000)
		{
			unlockedText();
		}
		else
		{
			lockedText();
		}
	}

	private void lockedText()
	{
		switch (id)
		{
		case 0:
			nextAttackName.text = "Requires 5K levels in prev. Attack";
			nextAttackName.fontSize = 12;
			break;
		case 1:
			nextAttackName.text = "Requires 10K levels in prev. Attack";
			nextAttackName.fontSize = 12;
			break;
		case 2:
			nextAttackName.text = "Requires 15K levels in prev. Attack";
			nextAttackName.fontSize = 12;
			break;
		case 3:
			nextAttackName.text = "Requires 20K levels in prev. Attack";
			nextAttackName.fontSize = 12;
			break;
		case 4:
			nextAttackName.text = "Requires 25K levels in prev. Attack";
			nextAttackName.fontSize = 12;
			break;
		case 5:
			nextAttackName.text = "Idle Attack";
			nextAttackName.fontSize = 14;
			break;
		}
	}

	private void unlockedText()
	{
		nextAttackName.fontSize = 14;
		switch (id)
		{
		case 0:
			nextAttackName.text = "Regular Attack";
			break;
		case 1:
			nextAttackName.text = "Strong Attack";
			break;
		case 2:
			nextAttackName.text = "Parry";
			break;
		case 3:
			nextAttackName.text = "Piercing Attack";
			break;
		case 4:
			nextAttackName.text = "Ultimate Attack";
			break;
		case 5:
			nextAttackName.text = "Idle Attack";
			break;
		}
	}
}
