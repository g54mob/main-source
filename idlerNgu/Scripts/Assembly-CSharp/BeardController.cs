using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeardController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public Slider slider;

	public Image beardImage;

	public Dropdown beardList;

	public Text tempBonus;

	public Text tempValue;

	public Text permBonus;

	public Text permValue;

	public Text levelText;

	public Text activeBeardsText;

	public Button toggle;

	public Image checkmark;

	public Sprite checkSprite;

	public Sprite emptySprite;

	public string[] beardNames;

	public int id;

	public string message;

	public void Start()
	{
		List<string> list = new List<string>();
		beardList.ClearOptions();
		for (int i = 0; i < beardNames.Length; i++)
		{
			list.Add(beardNames[i]);
		}
		beardList.AddOptions(list);
	}

	public void activate()
	{
		character.allBeards.activateBeard(id);
	}

	public void deactivate()
	{
		character.allBeards.deactivateBeard(id);
	}

	public void hideDropdown()
	{
		beardList.Hide();
	}

	public void changeActiveState()
	{
		hideDropdown();
		if (id == 6 && character.allChallenges.trollChallenge.completions() < 7)
		{
			tooltip.showOverrideTooltip("You have to unlock this beard from the Troll Challenge, Completion #7!", 3f);
			return;
		}
		if (character.beards.beards[id].active)
		{
			deactivate();
		}
		else
		{
			activate();
		}
		updateBeardDisplay();
	}

	public void changeID()
	{
		changeID(beardList.value);
	}

	public void changeID(int newid)
	{
		if (id != newid)
		{
			id = newid;
			updateBeardDisplay();
		}
	}

	public void clearBeards()
	{
		character.allBeards.clearActiveBeards();
	}

	public void updateBeardDisplay()
	{
		beardImage.sprite = character.allBeards.beardImages[id];
		updateText();
		updateSlider();
		updateToggleState();
		updateBeardList();
	}

	public void updateToggleState()
	{
		if (!character.beards.beards[id].active)
		{
			checkmark.color = Color.clear;
		}
		else
		{
			checkmark.color = Color.white;
		}
	}

	public void updateSlider()
	{
		if (character.menuID != 39)
		{
			return;
		}
		if (character.settings.antiFlickerBars)
		{
			if (character.allBeards.beardProgressPerTick(id) > 0.1f)
			{
				slider.value = character.allBeards.beardProgressPerTick(id);
			}
			else
			{
				slider.value = character.beards.beards[id].progress;
			}
		}
		else
		{
			slider.value = character.beards.beards[id].progress;
		}
	}

	public void updateBeardList()
	{
		if (character.menuID != 39)
		{
			return;
		}
		for (int i = 0; i < beardList.options.Count; i++)
		{
			string text = beardNames[i];
			text = ((!character.allBeards.usesEnergy[i]) ? ("<color=blue>" + text + "</color>") : ("<color=green>" + text + "</color>"));
			if (character.beards.beards[i].active)
			{
				text = "<b>" + text + "</b>";
				beardList.options[i].image = checkSprite;
			}
			else
			{
				beardList.options[i].image = emptySprite;
			}
			beardList.options[i].text = text;
		}
		if (character.allBeards.usesEnergy[id])
		{
			if (character.beards.beards[id].active)
			{
				beardList.captionText.text = "<color=green><b>" + beardNames[id] + "</b></color>";
			}
			else
			{
				beardList.captionText.text = "<color=green>" + beardNames[id] + "</color>";
			}
		}
		else if (character.beards.beards[id].active)
		{
			beardList.captionText.text = "<color=blue><b>" + beardNames[id] + "</b></color>";
		}
		else
		{
			beardList.captionText.text = "<color=blue>" + beardNames[id] + "</color>";
		}
	}

	public void updateText()
	{
		if (character.menuID != 39)
		{
			return;
		}
		string text = "";
		switch (id)
		{
		case 0:
			tempBonus.text = "<b>Attack/Defense Bonus:</b>";
			text = (character.allBeards.tempStatBonus(overrideFlag: true) * 100.0).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent Attack/Defense Bonus:</b>";
			permValue.text = (character.allBeards.permStatBonus() * 100.0).ToString("###,##0.##") + "%";
			break;
		case 1:
			tempBonus.text = "<b>Drop Chance Bonus:</b>";
			text = (character.allBeards.tempLootBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent Drop Chance Bonus:</b>";
			permValue.text = (character.allBeards.permLootBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		case 2:
			tempBonus.text = "<b>NUMBER Bonus:</b>";
			text = (character.allBeards.tempNumberBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent NUMBER Bonus:</b>";
			permValue.text = (character.allBeards.permNumberBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		case 3:
			tempBonus.text = "<b>NGU Bonus:</b>";
			text = (character.allBeards.tempNGUBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent NGU Bonus:</b>";
			permValue.text = (character.allBeards.permNGUBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		case 4:
			tempBonus.text = "<b>Wandoos Bonus:</b>";
			text = (character.allBeards.tempWandoosBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent Wandoos Bonus:</b>";
			permValue.text = (character.allBeards.permWandoosBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		case 5:
			tempBonus.text = "<b>Adventure Bonus:</b>";
			text = (character.allBeards.tempAdventureBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent Adventure Bonus:</b>";
			permValue.text = (character.allBeards.permAdventureBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		case 6:
			tempBonus.text = "<b>Gold Bonus:</b>";
			text = (character.allBeards.tempGoldBonus(overrideFlag: true) * 100f).ToString("###,##0.##") + "%";
			if (character.beards.beards[id].active)
			{
				text += " (ACTIVE)";
				text = "<b>" + text + "</b>";
			}
			else
			{
				text += " (INACTIVE)";
			}
			tempValue.text = text;
			permBonus.text = "<b>Permanent Gold Bonus:</b>";
			permValue.text = (character.allBeards.permGoldBonus() * 100f).ToString("###,##0.##") + "%";
			break;
		}
		levelText.text = character.display(character.beards.beards[id].beardLevel);
		activeBeardsText.text = "Active:\n" + character.beards.activeBeards.Count + " / " + character.allBeards.capBeards();
	}

	public string timeToLevelup()
	{
		if (character.allBeards.beardProgressPerTick(id) > 0f)
		{
			return NumberOutput.timeOutput((1f - character.beards.beards[id].progress) / character.allBeards.beardProgressPerTick(id) / 50f);
		}
		if (character.beards.beards[id].active && !atCap())
		{
			return "Infinity (cap not reached yet).";
		}
		return "A really long time.";
	}

	public bool atCap()
	{
		if (character.allBeards.usesEnergy[id] && character.curEnergy < character.totalCapEnergy())
		{
			return false;
		}
		if (!character.allBeards.usesEnergy[id] && character.magic.curMagic < character.totalCapMagic())
		{
			return false;
		}
		return true;
	}

	public void displayBeardTooltip()
	{
		InvokeRepeating("showTooltip", 0f, 0.1f);
	}

	public void showTooltip()
	{
		if (character.allBeards.usesEnergy[id])
		{
			message = "<b>This beard's growth is based on your Energy Bars and the sqrt of your Energy Power.</b>";
		}
		else
		{
			message = "<b>This beard's growth is based on your Magic Bars and the sqrt of your Magic Power.</b>";
		}
		message = message + "\n<b>Time until Levelup:</b> " + timeToLevelup();
		message = message + "\n\nIf active upon Rebirth, this beard will gain <b>" + character.display(character.allBeards.addedTrimmings(id)) + "</b> levels to the permanent bonus, increasing from <b>" + permBonusText(0L) + "</b> to <b>" + permBonusText(character.allBeards.addedTrimmings(id)) + "</b>";
		message += "\n\n<b>Math For Nerds</b>";
		message = message + "\nBeard's permanent bonus level is <b>" + character.display(character.beards.beards[id].permLevel) + "</b>";
		switch (id)
		{
		case 0:
			message += "\nBeard's bonus is based on beard level * 5%.\nBeard's Permanent Bonus is based on permanent level * 1%";
			break;
		case 1:
			message += "\nBeard's bonus is beard level * 0.05%, up to level 1000. After level 1000, bonus is (beard level ^ 0.3) * 125.9 * 0.05%.\nPermanent Bonus is based on permanent level * 0.05%, up to level 1000. After level 1000, the bonus is (permanent level ^ 0.33) * 102.4 * 0.05%";
			break;
		case 2:
			message += "\nBeard's bonus is beard level * 1%, up to level 1000. After level 1000, the bonus is (beard level ^ 0.5) * 31.7 * 1%.\nPermanent Bonus is based on permanent level * 0.1%, up to level 1000. After level 1000, bonus is (permanent level ^ 0.5) * 31.7 * 0.1%";
			break;
		case 3:
			message += "\nBeard's bonus is beard level * 0.01%, up to level 1000. After level 1000, bonus is (beard level ^ 0.3) * 125.9 * 0.01%.\nPermanent Bonus is based on permanent level * 0.02%, up to level 1000. After level 1000, bonus is (permanent level ^ 0.3) * 125.9 * 0.02%";
			break;
		case 4:
			message += "\nBeard's bonus is beard level * 0.1%, up to level 1000. After level 1000, bonus is (beard level ^ 0.5) * 31.7* 0.1%.\nPermanent Bonus is based on permanent level * 0.2%, up to level 1000. After level 1000, bonus is (permanent level ^ 0.5) * 31.7 * 0.2%";
			break;
		case 5:
			message += "\nBeard's bonus is beard level * 0.1%, up to level 1000. After level 1000, bonus is (beard level ^ 0.3) * 125.9 * 0.1%.\nPermanent Bonus is based on permanent level * 0.05%, up to level 1000. After level 1000, bonus is (permanent level ^ 0.5) * 31.7 * 0.05%";
			break;
		case 6:
			message += "\nBeard's bonus is beard level * 0.2%, up to level 1000. After level 1000, bonus is (beard level ^ 0.5) * 31.7 * 0.2%.\nPermanent Bonus is based on permanent level * 0.5%, up to level 1000. After level 1000, bonus is (permanent level ^ 0.5) * 31.7 * 0.5%";
			break;
		}
		tooltip.showTooltip(message);
	}

	public string permBonusText(long offset)
	{
		switch (id)
		{
		case 0:
			return (character.allBeards.permStatBonus(offset) * 100.0).ToString("###,##0.##") + "%";
		case 1:
			return (character.allBeards.permLootBonus(offset) * 100f).ToString("###,##0.##") + "%";
		case 2:
			return (character.allBeards.permNumberBonus(offset) * 100f).ToString("###,##0.##") + "%";
		case 3:
			return (character.allBeards.permNGUBonus(offset) * 100f).ToString("###,##0.##") + "%";
		case 4:
			return (character.allBeards.permWandoosBonus(offset) * 100f).ToString("###,##0.##") + "%";
		case 5:
			return (character.allBeards.permAdventureBonus(offset) * 100f).ToString("###,##0.##") + "%";
		case 6:
			return (character.allBeards.permGoldBonus(offset) * 100f).ToString("###,##0.##") + "%";
		default:
			return "";
		}
	}

	public void hideTooltip()
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	public void beardForward()
	{
		int num = id + 1;
		if (num >= character.beards.beards.Count)
		{
			num = 0;
		}
		changeID(num);
		updateBeardDisplay();
	}

	public void beardBack()
	{
		int num = id - 1;
		if (num < 0)
		{
			num = character.beards.beards.Count - 1;
		}
		changeID(num);
		updateBeardDisplay();
	}
}
