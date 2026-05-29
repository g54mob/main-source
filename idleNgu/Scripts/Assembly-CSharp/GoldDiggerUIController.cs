using UnityEngine;
using UnityEngine.UI;

public class GoldDiggerUIController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public int id;

	public InputField diggerLevelInput;

	public Image checkMark;

	public Text diggerInfo;

	public Text diggerName;

	public Text upgradeInfo;

	public Text costInfo;

	public Text maxLevelInfo;

	public Button levelUpButton;

	public Button levelDownButton;

	public Button levelCapButton;

	public GameObject pod;

	public void setID(int newid)
	{
		id = newid;
		updateUI();
	}

	public void updateUI()
	{
		if (character.menuID != 44)
		{
			return;
		}
		if (id < 0 || id >= character.diggers.diggers.Count)
		{
			pod.SetActive(value: false);
			return;
		}
		pod.SetActive(value: true);
		if (character.diggers.diggers[id].active)
		{
			checkMark.color = Color.white;
		}
		else
		{
			checkMark.color = Color.clear;
		}
		if (character.diggers.diggers[id].curLevel <= 0)
		{
			levelDownButton.gameObject.SetActive(value: false);
		}
		else
		{
			levelDownButton.gameObject.SetActive(value: true);
		}
		if (character.diggers.diggers[id].curLevel >= character.diggers.diggers[id].maxLevel)
		{
			levelUpButton.gameObject.SetActive(value: false);
		}
		else
		{
			levelUpButton.gameObject.SetActive(value: true);
		}
		if (character.diggers.diggers[id].maxLevel > 0)
		{
			levelCapButton.gameObject.SetActive(value: true);
		}
		else
		{
			levelCapButton.gameObject.SetActive(value: false);
		}
		diggerLevelInput.text = character.diggers.diggers[id].curLevel.ToString();
		diggerName.text = "<b>" + character.allDiggers.diggerName[id] + "</b>";
		maxLevelInfo.text = "<b>Max Level: " + character.diggers.diggers[id].maxLevel + "</b>";
		costInfo.text = "<b>Cost: " + character.display(character.allDiggers.upgradeCost(id)) + "</b> Gold";
		if (character.diggers.diggers[id].active)
		{
			diggerInfo.text = "<b>Current Effect: " + character.allDiggers.bonusString(id) + "% " + character.allDiggers.bonusName[id] + "</b>";
			Text text = diggerInfo;
			text.text = text.text + "\n<b>GPS Drain: " + character.display(character.allDiggers.drain(id)) + "</b>";
			if (character.diggers.diggers[id].curLevel + 1 < character.allDiggers.hardCapLevel(id))
			{
				Text text2 = diggerInfo;
				text2.text = text2.text + "\n<b>GPS Drain (Next Level): " + character.display(character.allDiggers.drain(id, 1)) + "</b>";
			}
		}
		else
		{
			diggerInfo.text = "\n<b>GPS Drain if Activated: " + character.display(character.allDiggers.drain(id, evenifnotactive: true)) + "</b>";
			Text text3 = diggerInfo;
			text3.text = text3.text + "\n<b>Effect if Activated: " + character.allDiggers.bonusString(id) + "</b>%";
		}
		if (character.diggers.diggers[id].maxLevel == 0L)
		{
			upgradeInfo.text = "UNLOCK DIGGER";
			upgradeInfo.fontSize = 14;
		}
		else
		{
			upgradeInfo.text = "+1 MAX LEVEL";
			upgradeInfo.fontSize = 12;
		}
		character.allDiggers.updateText();
	}

	public void setInputField()
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return;
		}
		long num = long.Parse(diggerLevelInput.text);
		long curLevel = character.diggers.diggers[id].curLevel;
		if (num <= 0)
		{
			num = 0L;
			if (character.diggers.diggers[id].active)
			{
				character.diggers.diggers[id].active = false;
				character.diggers.activeDiggers.Remove(id);
			}
		}
		if (character.diggers.diggers[id].active)
		{
			if (num > character.diggers.diggers[id].maxLevel)
			{
				num = character.diggers.diggers[id].maxLevel;
			}
			character.diggers.diggers[id].curLevel = num;
			if (character.totalGPSDrain() > character.grossGoldPerSecond())
			{
				character.diggers.diggers[id].curLevel = curLevel;
				tooltip.showOverrideTooltip("Your GPS can't support setting the digger to such a high level! Try a lower level instead.", 1.5f);
			}
		}
		else
		{
			if (num > character.diggers.diggers[id].maxLevel)
			{
				num = character.diggers.diggers[id].maxLevel;
			}
			character.diggers.diggers[id].curLevel = num;
		}
		updateUI();
	}

	public void activate()
	{
		character.allDiggers.activateDigger(id);
		updateUI();
	}

	public void levelUp()
	{
		long curLevel = character.diggers.diggers[id].curLevel;
		long num = curLevel + 1;
		if (num < 0)
		{
			num = 0L;
		}
		if (num > character.diggers.diggers[id].maxLevel)
		{
			tooltip.showOverrideTooltip("You need to upgrade this digger's max level first!", 1.5f);
			updateUI();
			return;
		}
		if (character.diggers.diggers[id].active)
		{
			character.diggers.diggers[id].curLevel = num;
			if (character.totalGPSDrain() > character.grossGoldPerSecond())
			{
				character.diggers.diggers[id].curLevel = curLevel;
				tooltip.showOverrideTooltip("Your GPS can't support raising this digger's high level! Try raising your GPS!", 1.5f);
				updateUI();
				return;
			}
		}
		else
		{
			character.diggers.diggers[id].curLevel = num;
		}
		updateUI();
	}

	public void levelDown()
	{
		if (id < 0 || id > character.diggers.diggers.Count)
		{
			return;
		}
		long curLevel = character.diggers.diggers[id].curLevel;
		long num = curLevel - 1;
		if (num <= 0)
		{
			num = 0L;
		}
		if (num == 0L)
		{
			int num2 = character.diggers.activeDiggers.IndexOf(id);
			if (num2 != -1)
			{
				character.diggers.activeDiggers.RemoveAt(num2);
				character.diggers.diggers[id].active = false;
			}
			character.diggers.diggers[id].curLevel = num;
			updateUI();
			return;
		}
		if (num > character.diggers.diggers[id].maxLevel)
		{
			tooltip.showOverrideTooltip("You need to upgrade this digger's max level first!", 1.5f);
			num = character.diggers.diggers[id].maxLevel;
		}
		if (character.diggers.diggers[id].active)
		{
			character.diggers.diggers[id].curLevel = num;
			if (character.totalGPSDrain() > character.grossGoldPerSecond())
			{
				character.diggers.diggers[id].curLevel = curLevel;
				tooltip.showOverrideTooltip("I don't know how you got this tooltip to show, but you better lower this digger's level and tell 4G he probably broke something!", 1.5f);
				updateUI();
				return;
			}
		}
		else
		{
			character.diggers.diggers[id].curLevel = num;
		}
		updateUI();
	}

	public void upgradeMaxLevel()
	{
		character.allDiggers.upgradeMaxLevel(id);
		updateUI();
	}

	public void showTooltip()
	{
		character.allDiggers.showTooltip(id);
	}

	public void exitTooltip()
	{
		character.allDiggers.hideTooltip();
	}

	public void setLevelMaxAffordable()
	{
		character.allDiggers.setLevelMaxAffordable(id);
	}

	public void upgradeMaxLevelFully()
	{
		character.allDiggers.upgradeMaxLevelFully(id);
	}

	public void capTooltip()
	{
		tooltip.showTooltip("This will set the digger's level to the highest you can support with your current Gold Production, or your max level, whatever is lower. Remember to activate the digger too!");
	}
}
