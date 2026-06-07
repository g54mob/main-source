using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllYggdrasil : MonoBehaviour
{
	public Character character;

	public Text bonusText;

	public Text bonusValuesText;

	public Text poopText;

	public FruitController[] fruits = new FruitController[7];

	public Color[] tierColours = new Color[24];

	public YggdrasilDisplay display;

	public InputField tierInput;

	public Image checkmark;

	public List<bool> usesEnergy;

	public List<long> baseSeedCost;

	public List<long> baseSeedReward;

	public List<long> activationCost;

	public List<string> fruitName;

	public List<string> fruitDescription;

	public List<GameObject> pods;

	public int curPage;

	public void Start()
	{
		curPage = 0;
		InvokeRepeating("updateFruitTimers", 0f, 1f);
	}

	public void updateFruitTimers()
	{
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			if (!character.yggdrasil.fruits[i].activated && character.yggdrasil.fruits[i].permCostPaid)
			{
				character.yggdrasil.fruits[i].activate();
			}
			if (character.yggdrasil.fruits[i].activated)
			{
				if (character.yggdrasil.fruits[i].seconds / fruits[0].tierThreshold() >= (float)character.yggdrasil.fruits[i].maxTier)
				{
					character.yggdrasil.fruits[i].seconds = (float)character.yggdrasil.fruits[i].maxTier * fruits[0].tierThreshold();
				}
				else
				{
					character.yggdrasil.fruits[i].addTime();
				}
			}
		}
		for (int j = 0; j < fruits.Length; j++)
		{
			fruits[j].updateFruitDisplay();
			fruits[j].updateButton();
		}
		character.yggdrasilController.updateBonusTexts();
	}

	public void reset()
	{
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			character.yggdrasil.fruits[i].reset(character.yggdrasil.resetFactor);
		}
		for (int j = 0; j < fruits.Length; j++)
		{
			fruits[j].updateFruitDisplay();
		}
	}

	public void refreshMenu()
	{
		if (character.menuID == 9)
		{
			for (int i = 0; i < fruits.Length; i++)
			{
				fruits[i].refresh();
			}
			updateBonusTexts();
			updateDisplay();
			if (character.settings.poopOnlyMaxTier)
			{
				checkmark.color = Color.white;
			}
			else
			{
				checkmark.color = Color.clear;
			}
		}
	}

	public void togglePoopOnMaxtier()
	{
		character.settings.poopOnlyMaxTier = !character.settings.poopOnlyMaxTier;
		refreshMenu();
	}

	public void updateDisplay()
	{
		display.updateDisplay();
	}

	public int capTier()
	{
		int result = 10;
		if (character.allChallenges.trollChallenge.completions() >= 3)
		{
			result = 24;
		}
		return result;
	}

	public double totalStatBonus()
	{
		return Math.Pow(character.yggdrasil.fruits[1].totalLevels, 1.5);
	}

	public float luckBonus()
	{
		return 1f + (float)character.yggdrasil.totalLuck * 0.0005f;
	}

	public double permStatBonus()
	{
		if (!character.yggdrasil.permBonusOn)
		{
			return 1.0;
		}
		return 1.0 + (double)(character.yggdrasil.totalPermStatBonus * character.yggdrasil.totalPermStatBonus) * 0.0005;
	}

	public double permStatBonus(bool flag)
	{
		return 1.0 + (double)(character.yggdrasil.totalPermStatBonus * character.yggdrasil.totalPermStatBonus) * 0.0005;
	}

	public double permStatBonus2()
	{
		return 1.0 + Math.Pow(character.yggdrasil.totalPermStatBonus2, 1.3) * 1E-06;
	}

	public double permNumberBonus()
	{
		if (!character.yggdrasil.permNumberBonusOn)
		{
			return 1.0;
		}
		return 1.0 + Math.Pow(character.yggdrasil.totalPermNumberBonus, 1.3) * 0.0005;
	}

	public double permNumberBonus(bool flag)
	{
		return 1.0 + Math.Pow(character.yggdrasil.totalPermNumberBonus, 1.3) * 0.0005;
	}

	public void updateBonusTexts()
	{
		if (character.menuID != 9)
		{
			return;
		}
		bonusText.text = "<b>Drop Chance Bonus:</b>";
		bonusValuesText.text = character.display(luckBonus() * 100f) + "%";
		poopText.text = character.arbitrary.poop1Count.ToString("###,##0");
		if (totalStatBonus() > 0.0)
		{
			bonusText.text += "\n<b>Power Fruit α Bonus:</b>";
			Text text = bonusValuesText;
			text.text = text.text + "\n" + character.display(totalStatBonus() * 100.0) + "%";
		}
		if (permStatBonus(flag: true) > 1.0)
		{
			bonusText.text += "\n<b>Power Fruit β Bonus:</b>";
			Text text2 = bonusValuesText;
			text2.text = text2.text + "\n" + character.display(permStatBonus(flag: true) * 100.0) + "%";
			if (!character.yggdrasil.permBonusOn)
			{
				bonusValuesText.text += " (INACTIVE)";
			}
			else
			{
				bonusValuesText.text += "<b> (ACTIVE)</b>";
			}
		}
		if (permStatBonus2() > 1.0)
		{
			bonusText.text += "\n<b>Power Fruit δ Bonus:</b>";
			if (permStatBonus2() < 10.0)
			{
				Text text3 = bonusValuesText;
				text3.text = text3.text + "\n" + (permStatBonus2() * 100.0).ToString("###,##0.##") + "%";
			}
			else
			{
				Text text4 = bonusValuesText;
				text4.text = text4.text + "\n" + character.display(permStatBonus2() * 100.0) + "%";
			}
		}
		if (permNumberBonus(flag: true) > 1.0)
		{
			bonusText.text += "\n<b>Number Fruit Bonus:</b>";
			Text text5 = bonusValuesText;
			text5.text = text5.text + "\n" + character.display(permNumberBonus(flag: true) * 100.0) + "%";
			if (!character.yggdrasil.permNumberBonusOn)
			{
				bonusValuesText.text += " (INACTIVE)";
			}
			else
			{
				bonusValuesText.text += "<b> (ACTIVE)</b>";
			}
		}
	}

	public bool anyFruitMaxxed()
	{
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			if (fruits[0].fruitMaxxed(i))
			{
				return true;
			}
		}
		return false;
	}

	public void consumeAll()
	{
		_ = curPage;
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			if (fruits[0].harvestTier(i) >= character.yggdrasil.fruits[i].maxTier && fruits[0].harvestTier(i) >= 1)
			{
				if (character.yggdrasil.fruits[i].eatFruit)
				{
					fruits[0].consumeFruit(i);
				}
				else
				{
					fruits[0].harvest(i);
				}
			}
		}
		refreshMenu();
	}

	public void consumeAll(bool overrideFlag)
	{
		for (int i = 0; i < character.yggdrasil.fruits.Count; i++)
		{
			if (fruits[0].harvestTier(i) >= 1)
			{
				if (character.yggdrasil.fruits[i].eatFruit)
				{
					fruits[0].consumeFruit(i);
				}
				else
				{
					fruits[0].harvest(i);
				}
			}
		}
		refreshMenu();
	}

	public void changePage(int pageID)
	{
		if (curPage == pageID)
		{
			return;
		}
		int num = pageID * 9;
		for (int i = 0; i < fruits.Length; i++)
		{
			if (!(fruits[i] == null))
			{
				fruits[i].id = num;
				num++;
				fruits[i].updateFruitDisplay();
				fruits[i].updateButton();
			}
		}
		curPage = pageID;
	}

	public long maxPomSeedReward()
	{
		return character.yggdrasilController.fruits[0].harvestSeedReward(4, character.yggdrasilController.fruits[0].tierFactor((int)character.yggdrasil.fruits[4].maxTier), 1f);
	}
}
