using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DefenseTraining : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Text levelText;

	public Text energyText;

	public Slider trainProgress;

	public Character character;

	public InputField energyRequested;

	public HoverTooltip tooltip;

	private string tooltipMessage = "";

	public Text nextDefenseName;

	public Button nextAdd;

	public Button nextMinus;

	public Button nextCap;

	public Toggle autoadvanceToggle;

	public AllDefenseTraining allDefense;

	public int id;

	public double levelFactor;

	private void Start()
	{
		nextDefenseName.transform.SetAsLastSibling();
		checkText();
		updateText();
		checkButtons();
		InvokeRepeating("updateDefenseTraining", 0f, 0.02f);
		InvokeRepeating("checkButtons", 0f, 0.02f);
		InvokeRepeating("checkText", 0f, 0.5f);
	}

	public bool locked()
	{
		if (id == 0)
		{
			return false;
		}
		return character.training.defenseTraining[id - 1] <= id * 5000;
	}

	public void checkButtons()
	{
		if (character.training.defenseTraining[id] >= (id + 1) * 5000)
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
		if (character.training.defenseTraining[id - 2] >= (id - 1) * 5000)
		{
			return true;
		}
		return false;
	}

	private void updateDefenseTraining()
	{
		if (character.training.defenseTraining[id] >= (id + 1) * 5000 && character.purchases.hasAutoAdvance && autoadvanceToggle.isOn && character.training.defenseEnergy[id] > character.training.defenseCaps[id])
		{
			autoAdvance();
		}
		float num = (float)character.training.defenseEnergy[id] / (float)character.training.defenseCaps[id];
		character.training.defenseBarProgress[id] += num;
		updateSlider(num);
		if (character.training.defenseBarProgress[id] >= 1f)
		{
			levelUp();
		}
	}

	private void updateSlider(float toAdd)
	{
		if (character.menuID == 0)
		{
			if (character.challenges.blindChallenge.inChallenge && character.allChallenges.blindChallenge.completions() >= 2)
			{
				trainProgress.value = 0f;
			}
			else if (character.settings.antiFlickerBars && toAdd > 0.1f)
			{
				trainProgress.value = toAdd;
			}
			else
			{
				trainProgress.value = character.training.defenseBarProgress[id];
			}
		}
	}

	private void levelUp()
	{
		character.training.defenseBarProgress[id] = 0f;
		if (character.training.defenseTraining[id] >= 9223372036854775805L)
		{
			character.training.defenseTraining[id] = long.MaxValue;
			return;
		}
		character.training.defenseTraining[id]++;
		character.training.totalDefenseLevels++;
		if (character.adventure.itopod.perkLevel[15] >= 1)
		{
			character.training.defenseTraining[id]++;
			character.training.totalDefenseLevels++;
		}
		if (character.beastQuest.quirkLevel[17] >= 1)
		{
			character.training.defenseTraining[id]++;
			character.training.totalDefenseLevels++;
		}
		if (character.wishes.wishes[23].level >= 1)
		{
			character.training.defenseTraining[id]++;
			character.training.totalDefenseLevels++;
		}
		updateText();
		if (character.training.defenseTraining[id] == (id + 1) * 5000 && id != 5)
		{
			unlockedText();
			checkButtons();
			if (character.purchases.hasAutoAdvance && autoadvanceToggle.isOn)
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
			character.training.defenseEnergy[id] = character.training.defenseEnergy[id] + character.idleEnergy;
			character.idleEnergy = 0L;
		}
		else
		{
			character.training.defenseEnergy[id] = character.training.defenseEnergy[id] + num;
			character.idleEnergy -= num;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allOffenseController.trains[id].addEnergy(num);
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
				character.training.defenseEnergy[id] = character.training.defenseEnergy[id] + character.idleEnergy;
				character.idleEnergy = 0L;
			}
			else
			{
				character.training.defenseEnergy[id] = character.training.defenseEnergy[id] + num;
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
		if (num >= character.training.defenseEnergy[id])
		{
			character.idleEnergy += character.training.defenseEnergy[id];
			character.training.defenseEnergy[id] = 0L;
		}
		else
		{
			character.idleEnergy += num;
			character.training.defenseEnergy[id] = character.training.defenseEnergy[id] - num;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allOffenseController.trains[id].removeEnergy(num);
		}
	}

	public void removeEnergy(long amount)
	{
		long num = amount;
		if (num < 0)
		{
			num = 0L;
		}
		if (num >= character.training.defenseEnergy[id])
		{
			character.idleEnergy += character.training.defenseEnergy[id];
			character.training.defenseEnergy[id] = 0L;
		}
		else
		{
			character.idleEnergy += num;
			character.training.defenseEnergy[id] = character.training.defenseEnergy[id] - num;
		}
		updateText();
	}

	public void cap()
	{
		character.idleEnergy += character.training.defenseEnergy[id];
		character.training.defenseEnergy[id] = 0L;
		if (character.idleEnergy > character.training.defenseCaps[id])
		{
			character.idleEnergy -= character.training.defenseCaps[id];
			character.training.defenseEnergy[id] += character.training.defenseCaps[id];
			if (character.settings.syncTraining)
			{
				character.allOffenseController.trains[id].cap(stop: false);
			}
			return;
		}
		long num = Mathf.CeilToInt((float)character.training.defenseCaps[id] / (float)Mathf.CeilToInt((float)character.training.defenseCaps[id] / (float)character.idleEnergy));
		character.idleEnergy -= num;
		character.training.defenseEnergy[id] += num;
		if (character.settings.syncTraining)
		{
			character.allOffenseController.trains[id].cap(stop: false);
		}
		updateText();
	}

	public void cap(bool stop)
	{
		if (!locked())
		{
			character.idleEnergy += character.training.defenseEnergy[id];
			character.training.defenseEnergy[id] = 0L;
			if (character.idleEnergy > character.training.defenseCaps[id])
			{
				character.idleEnergy -= character.training.defenseCaps[id];
				character.training.defenseEnergy[id] += character.training.defenseCaps[id];
				return;
			}
			long num = Mathf.CeilToInt((float)character.training.defenseCaps[id] / (float)Mathf.CeilToInt((float)character.training.defenseCaps[id] / (float)character.idleEnergy));
			character.idleEnergy -= num;
			character.training.defenseEnergy[id] += num;
			updateText();
		}
	}

	public void autoAdvance()
	{
		if (id != 5 && character.training.defenseEnergy[id] >= 2)
		{
			long num = Math.Max(character.training.defenseEnergy[id] - character.training.defenseCaps[id], 0L);
			character.training.defenseEnergy[id + 1] += num;
			character.training.defenseEnergy[id] -= num;
			allDefense.refresh();
		}
	}

	public void add6()
	{
		if (character.idleEnergy > 6)
		{
			character.idleEnergy -= 6L;
			character.training.defenseEnergy[id] += 6L;
		}
		else
		{
			character.training.defenseEnergy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		updateText();
	}

	public void addSum()
	{
		long num = 0L;
		for (int i = 0; i < character.training.defenseTraining.Length; i++)
		{
			num += character.training.defenseCaps[i];
		}
		if (num < 0)
		{
			num = 0L;
		}
		if (character.idleEnergy > num)
		{
			character.idleEnergy -= num;
			character.training.defenseEnergy[id] += num;
		}
		else
		{
			character.training.defenseEnergy[id] += character.idleEnergy;
			character.idleEnergy = 0L;
		}
		updateText();
		if (character.settings.syncTraining)
		{
			character.allOffenseController.trains[id].addEnergy(num);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		long num = (long)(1f + Mathf.Pow((float)character.training.defenseTraining[id] - 500f * (float)id, 1.2f) / 500f * ((float)character.training.defenseCaps[id] / 1000f));
		if (num <= 1)
		{
			num = 1L;
		}
		if (character.training.defenseTraining[id] == 0L)
		{
			num = 0L;
		}
		long num2 = character.training.defenseCaps[id] / 10 + 1;
		if (num > num2)
		{
			num = num2;
		}
		if (character.training.defenseCaps[id] - num <= 1)
		{
			num = character.training.defenseCaps[id] - 1;
		}
		tooltipMessage = "Levels gained in this Defense skill will decrease the amount of Energy needed to cap leveling speed, upon Rebirth.\nCapped speed currently achieved with " + character.training.defenseCaps[id].ToString("###,##0") + " Energy.\nOn Rebirth, your new cap will be ";
		if (num == num2 && character.training.defenseCaps[id] != 0)
		{
			tooltipMessage = tooltipMessage + "<color=green>" + (character.training.defenseCaps[id] - num).ToString("###,##0") + "</color> (Maximum cap reduction reached this rebirth)";
		}
		else
		{
			tooltipMessage += character.training.defenseCaps[id] - num;
		}
		tooltipMessage = tooltipMessage + ".\nBase Defense received per level is " + character.display(character.training.trainFactor[id]) + ".";
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
			levelText.text = NumberOutput.suffixFormat(character.training.defenseTraining[id], character.settings.numberDisplay);
			energyText.text = NumberOutput.suffixFormat(character.training.defenseEnergy[id], character.settings.numberDisplay);
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
			nextDefenseName.text = "Locked";
		}
		levelText.text = "0";
		energyText.text = "0";
		turnOffButtons();
		lockedText();
	}

	public void setNameText()
	{
		if (character.training.defenseTraining[id] == (id + 1) * 5000 && id != 5)
		{
			unlockedText();
		}
		else
		{
			lockedText();
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
		if (character.training.defenseTraining[id] >= (id + 1) * 5000)
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
			nextDefenseName.text = "Requires 5k levels in prev. Defense";
			nextDefenseName.fontSize = 12;
			break;
		case 1:
			nextDefenseName.text = "Requires 10k levels in prev. Defense";
			nextDefenseName.fontSize = 12;
			break;
		case 2:
			nextDefenseName.text = "Requires 15k levels in prev. Defense";
			nextDefenseName.fontSize = 12;
			break;
		case 3:
			nextDefenseName.text = "Requires 20k levels in prev. Defense";
			nextDefenseName.fontSize = 12;
			break;
		case 4:
			nextDefenseName.text = "Requires 25k levels in prev. Defense";
			nextDefenseName.fontSize = 12;
			break;
		case 5:
			nextDefenseName.text = "Block";
			nextDefenseName.fontSize = 14;
			break;
		}
	}

	private void unlockedText()
	{
		nextDefenseName.fontSize = 14;
		switch (id)
		{
		case 0:
			nextDefenseName.text = "Defensive Buff";
			break;
		case 1:
			nextDefenseName.text = "Heal";
			break;
		case 2:
			nextDefenseName.text = "Offensive Buff";
			break;
		case 3:
			nextDefenseName.text = "Charge";
			break;
		case 4:
			nextDefenseName.text = "Ultimate Buff";
			break;
		case 5:
			nextDefenseName.text = "Block";
			break;
		}
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
}
