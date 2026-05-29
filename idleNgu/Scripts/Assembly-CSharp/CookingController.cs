using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingController : MonoBehaviour
{
	public Character character;

	public List<IngredientProperty> ingredientProperties;

	public List<DishProperty> dishProperties;

	public List<IngredientPodUI> pods;

	public Text nextdishTimerText;

	public Text dishInfoText;

	public Image dishSprite;

	public float refreshTimer;

	public void changeIngredientLevel(int newLevel)
	{
	}

	public void Update()
	{
		if (character.cooking.cookTimer < maxBankedtime())
		{
			character.cooking.cookTimer += Time.deltaTime;
		}
		if (character.cooking.cookTimer > maxBankedtime())
		{
			character.cooking.cookTimer = maxBankedtime();
		}
		refreshTimer += Time.deltaTime;
		if (refreshTimer > 1f)
		{
			refreshTimer -= 1f;
			updateDishUI();
		}
	}

	public void updateMenu()
	{
		if (character.menuID == 57)
		{
			updateIngredientPods();
			updateDishUI();
		}
	}

	public void updateIngredientPods()
	{
		foreach (IngredientPodUI pod in pods)
		{
			pod.updatePod();
		}
	}

	public int maxIngredientLevel()
	{
		return 20;
	}

	public void updateDishUI()
	{
		if (character.cooking.cookTimer >= eatRate())
		{
			nextdishTimerText.text = "EAT THIS MEAL AT ANY TIME!\nBanked Time: " + NumberOutput.timeOutput(character.cooking.cookTimer - eatRate());
		}
		else
		{
			nextdishTimerText.text = "You can eat this Meal in: " + NumberOutput.timeOutput(eatRate() - character.cooking.cookTimer);
		}
		float num = getCurPercentofMaxScore() * baseExpBonusPerDish();
		dishSprite.sprite = dishProperties[character.cooking.curDishIndex].sprite;
		dishInfoText.text = "+" + (getCurPercentofMaxScore() * 100f).ToString("#0.##") + "%";
		Text text = dishInfoText;
		text.text = text.text + "\n" + (totalCookingBonuses() * 100f).ToString("##0.##") + "%";
		Text text2 = dishInfoText;
		text2.text = text2.text + "\n+" + (num * 100f).ToString("##0.##") + "%";
		Text text3 = dishInfoText;
		text3.text = text3.text + "\n+" + (character.cooking.expBonus * 100f).ToString("##0.##") + "%";
	}

	public float maxBankedtime()
	{
		return 172800f;
	}

	public float eatRate()
	{
		float num = 84600f;
		if (character.inventory.itemList.breadverseComplete)
		{
			num -= 3600f;
		}
		return num;
	}

	public float invCookCheck()
	{
		float num = 1f;
		if (character.inventory.head.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.head.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.head.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.chest.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.chest.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.chest.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.legs.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.boots.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.boots.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.boots.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.weapon.spec1Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.weapon.spec2Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		if (character.inventory.weapon.spec3Type == specType.Cooking)
		{
			num *= 1.03f;
		}
		for (int i = 0; i < character.inventory.accs.Count; i++)
		{
			if (character.inventory.accs[i] != null)
			{
				if (character.inventory.accs[i].spec1Type == specType.Cooking)
				{
					num *= 1.03f;
				}
				if (character.inventory.accs[i].spec2Type == specType.Cooking)
				{
					num *= 1.03f;
				}
				if (character.inventory.accs[i].spec3Type == specType.Cooking)
				{
					num *= 1.03f;
				}
			}
		}
		if (num > 1.5f)
		{
			num = 1.5f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public float totalCookingBonuses()
	{
		float num = 1f;
		if (character.cooking.ingredients[6].unlocked)
		{
			num *= 1.2f;
		}
		if (character.cooking.ingredients[7].unlocked)
		{
			num *= 1.2f;
		}
		if (character.inventory.itemList.spaceComplete)
		{
			num *= 1.1f;
		}
		return num * invCookCheck();
	}

	public float baseExpBonusPerDish()
	{
		float num = 0.005f;
		float num2 = 1f;
		num2 = ((!(character.cooking.expBonus > 1.8f)) ? (1f - Mathf.Pow(character.cooking.expBonus - 1f, 2f)) : 0.36f);
		num *= totalCookingBonuses();
		float num3 = num * num2;
		if (num3 > num)
		{
			num3 = num;
		}
		if (num3 < num * 0.36f)
		{
			num3 = num * 0.36f;
		}
		return num3;
	}

	public void consumeDish()
	{
		if (character.cooking.cookTimer < eatRate())
		{
			character.tooltip.showOverrideTooltip("You're still full - wait a bit longer to eat again!", 2f);
			return;
		}
		character.cooking.cookTimer -= eatRate();
		float num = getCurPercentofMaxScore() * baseExpBonusPerDish();
		character.cooking.expBonus += num;
		assignNewDish();
		updateMenu();
	}

	public float totalExpBonus()
	{
		float num = 1f;
		num = character.cooking.expBonus;
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 3f)
		{
			num = 3f;
		}
		return num;
	}

	public float minWeight()
	{
		return 4f;
	}

	public float maxWeight()
	{
		return 14f;
	}

	public float minPairedWeight()
	{
		return 8f;
	}

	public float maxPairedWeight()
	{
		return 30f;
	}

	public void assignNewDish()
	{
		int curDishIndex = Random.Range(0, dishProperties.Count);
		character.cooking.curDishIndex = curDishIndex;
		List<int> list = new List<int>();
		list.Clear();
		for (int i = 0; i < ingredientProperties.Count; i++)
		{
			list.Add(i);
		}
		for (int j = 0; j < character.cooking.ingredients.Count; j++)
		{
			int index = Random.Range(0, list.Count);
			character.cooking.ingredients[j].propertyIndex = list[index];
			list.RemoveAt(index);
		}
		List<int> list2 = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
		List<int> list3 = new List<int>();
		int index2 = Random.Range(0, list2.Count);
		list3.Add(list2[index2]);
		list2.RemoveAt(index2);
		index2 = Random.Range(0, list2.Count);
		list3.Add(list2[index2]);
		list2.RemoveAt(index2);
		character.cooking.pair1.Clear();
		character.cooking.pair1.Add(list3[0]);
		character.cooking.pair1.Add(list3[1]);
		List<int> list4 = new List<int>();
		index2 = Random.Range(0, list2.Count);
		list4.Add(list2[index2]);
		list2.RemoveAt(index2);
		index2 = Random.Range(0, list2.Count);
		list4.Add(list2[index2]);
		list2.RemoveAt(index2);
		character.cooking.pair2.Clear();
		character.cooking.pair2.Add(list4[0]);
		character.cooking.pair2.Add(list4[1]);
		List<int> list5 = new List<int>();
		index2 = Random.Range(0, list2.Count);
		list5.Add(list2[index2]);
		list2.RemoveAt(index2);
		index2 = Random.Range(0, list2.Count);
		list5.Add(list2[index2]);
		list2.RemoveAt(index2);
		character.cooking.pair3.Clear();
		character.cooking.pair3.Add(list5[0]);
		character.cooking.pair3.Add(list5[1]);
		List<int> list6 = new List<int>();
		index2 = Random.Range(0, list2.Count);
		list6.Add(list2[index2]);
		list2.RemoveAt(index2);
		index2 = Random.Range(0, list2.Count);
		list6.Add(list2[index2]);
		list2.RemoveAt(index2);
		character.cooking.pair4.Clear();
		character.cooking.pair4.Add(list6[0]);
		character.cooking.pair4.Add(list6[1]);
		character.cooking.ingredients[list3[0]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list3[0]].pairedIngred = list3[1];
		character.cooking.ingredients[list3[0]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list3[0]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.ingredients[list3[1]].pairedIngred = list3[0];
		character.cooking.ingredients[list3[1]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list3[1]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list3[1]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.pair1Target = Random.Range(5, maxIngredientLevel() * 2 - 5);
		character.cooking.ingredients[list4[0]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list4[0]].pairedIngred = list4[1];
		character.cooking.ingredients[list4[0]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list4[0]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.ingredients[list4[1]].pairedIngred = list4[0];
		character.cooking.ingredients[list4[1]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list4[1]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list4[1]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.pair2Target = Random.Range(5, maxIngredientLevel() * 2 - 5);
		character.cooking.ingredients[list5[0]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list5[0]].pairedIngred = list5[1];
		character.cooking.ingredients[list5[0]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list5[0]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.ingredients[list5[1]].pairedIngred = list5[0];
		character.cooking.ingredients[list5[1]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list5[1]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list5[1]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.pair3Target = Random.Range(5, maxIngredientLevel() * 2 - 5);
		character.cooking.ingredients[list6[0]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list6[0]].pairedIngred = list6[1];
		character.cooking.ingredients[list6[0]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list6[0]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.ingredients[list6[1]].pairedIngred = list6[0];
		character.cooking.ingredients[list6[1]].targetLevel = Random.Range(0, maxIngredientLevel() + 1);
		character.cooking.ingredients[list6[1]].weight = Random.Range(minWeight(), maxWeight());
		character.cooking.ingredients[list6[1]].pairedWeight = Random.Range(minPairedWeight(), maxPairedWeight());
		character.cooking.pair4Target = Random.Range(5, maxIngredientLevel() * 2 - 5);
	}

	public bool invalidIngredientIndex(int index)
	{
		if (index < 0 || index >= character.cooking.ingredients.Count)
		{
			return true;
		}
		return false;
	}

	public bool ingredientUnlocked(int ingredientIndex)
	{
		if (invalidIngredientIndex(ingredientIndex))
		{
			return false;
		}
		return character.cooking.ingredients[ingredientIndex].unlocked;
	}

	public float getOptimalScore()
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i <= maxIngredientLevel(); i++)
		{
			for (int j = 0; j <= maxIngredientLevel(); j++)
			{
				num2 = 0f;
				if (ingredientUnlocked(character.cooking.pair1[0]))
				{
					num2 += getLocalScore(character.cooking.pair1[0], i) + getLocalScore(character.cooking.pair1[1], i);
				}
				if (ingredientUnlocked(character.cooking.pair1[1]))
				{
					num2 += getLocalScore(character.cooking.pair1[0], j) + getLocalScore(character.cooking.pair1[1], j);
				}
				if (ingredientUnlocked(character.cooking.pair1[0]) && ingredientUnlocked(character.cooking.pair1[1]))
				{
					num2 += getPairedScore(1, i + j);
				}
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		float num3 = 0f;
		num2 = 0f;
		for (int k = 0; k <= maxIngredientLevel(); k++)
		{
			for (int l = 0; l <= maxIngredientLevel(); l++)
			{
				num2 = 0f;
				if (ingredientUnlocked(character.cooking.pair2[0]))
				{
					num2 += getLocalScore(character.cooking.pair2[0], k) + getLocalScore(character.cooking.pair2[1], k);
				}
				if (ingredientUnlocked(character.cooking.pair2[1]))
				{
					num2 += getLocalScore(character.cooking.pair2[0], l) + getLocalScore(character.cooking.pair2[1], l);
				}
				if (ingredientUnlocked(character.cooking.pair2[0]) && ingredientUnlocked(character.cooking.pair2[1]))
				{
					num2 += getPairedScore(2, k + l);
				}
				if (num2 > num3)
				{
					num3 = num2;
				}
			}
		}
		float num4 = 0f;
		num2 = 0f;
		for (int m = 0; m <= maxIngredientLevel(); m++)
		{
			for (int n = 0; n <= maxIngredientLevel(); n++)
			{
				num2 = 0f;
				if (ingredientUnlocked(character.cooking.pair3[0]))
				{
					num2 += getLocalScore(character.cooking.pair3[0], m) + getLocalScore(character.cooking.pair3[1], m);
				}
				if (ingredientUnlocked(character.cooking.pair3[1]))
				{
					num2 += getLocalScore(character.cooking.pair3[0], n) + getLocalScore(character.cooking.pair3[1], n);
				}
				if (ingredientUnlocked(character.cooking.pair3[0]) && ingredientUnlocked(character.cooking.pair3[1]))
				{
					num2 += getPairedScore(3, m + n);
				}
				if (num2 > num4)
				{
					num4 = num2;
				}
			}
		}
		float num5 = 0f;
		num2 = 0f;
		for (int num6 = 0; num6 <= maxIngredientLevel(); num6++)
		{
			for (int num7 = 0; num7 <= maxIngredientLevel(); num7++)
			{
				num2 = 0f;
				if (ingredientUnlocked(character.cooking.pair4[0]))
				{
					num2 += getLocalScore(character.cooking.pair4[0], num6) + getLocalScore(character.cooking.pair4[1], num6);
				}
				if (ingredientUnlocked(character.cooking.pair4[1]))
				{
					num2 += getLocalScore(character.cooking.pair4[0], num7) + getLocalScore(character.cooking.pair4[1], num7);
				}
				if (ingredientUnlocked(character.cooking.pair4[0]) && ingredientUnlocked(character.cooking.pair4[1]))
				{
					num2 += getPairedScore(4, num6 + num7);
				}
				if (num2 > num5)
				{
					num5 = num2;
				}
			}
		}
		return num + num3 + num4 + num5;
	}

	public float getCurScore()
	{
		float num = 0f;
		if (ingredientUnlocked(character.cooking.pair1[0]))
		{
			num += getLocalScore(character.cooking.pair1[0], character.cooking.ingredients[character.cooking.pair1[0]].curLevel) + getLocalScore(character.cooking.pair1[1], character.cooking.ingredients[character.cooking.pair1[0]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair1[1]))
		{
			num += getLocalScore(character.cooking.pair1[0], character.cooking.ingredients[character.cooking.pair1[1]].curLevel) + getLocalScore(character.cooking.pair1[1], character.cooking.ingredients[character.cooking.pair1[1]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair1[0]) && ingredientUnlocked(character.cooking.pair1[1]))
		{
			num += getPairedScore(1, character.cooking.ingredients[character.cooking.pair1[0]].curLevel + character.cooking.ingredients[character.cooking.pair1[1]].curLevel);
		}
		float num2 = 0f;
		if (ingredientUnlocked(character.cooking.pair2[0]))
		{
			num2 += getLocalScore(character.cooking.pair2[0], character.cooking.ingredients[character.cooking.pair2[0]].curLevel) + getLocalScore(character.cooking.pair2[1], character.cooking.ingredients[character.cooking.pair2[0]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair2[1]))
		{
			num2 += getLocalScore(character.cooking.pair2[0], character.cooking.ingredients[character.cooking.pair2[1]].curLevel) + getLocalScore(character.cooking.pair2[1], character.cooking.ingredients[character.cooking.pair2[1]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair2[0]) && ingredientUnlocked(character.cooking.pair2[1]))
		{
			num2 += getPairedScore(2, character.cooking.ingredients[character.cooking.pair2[0]].curLevel + character.cooking.ingredients[character.cooking.pair2[1]].curLevel);
		}
		float num3 = 0f;
		if (ingredientUnlocked(character.cooking.pair3[0]))
		{
			num3 += getLocalScore(character.cooking.pair3[0], character.cooking.ingredients[character.cooking.pair3[0]].curLevel) + getLocalScore(character.cooking.pair3[1], character.cooking.ingredients[character.cooking.pair3[0]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair3[1]))
		{
			num3 += getLocalScore(character.cooking.pair3[0], character.cooking.ingredients[character.cooking.pair3[1]].curLevel) + getLocalScore(character.cooking.pair3[1], character.cooking.ingredients[character.cooking.pair3[1]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair3[0]) && ingredientUnlocked(character.cooking.pair3[1]))
		{
			num3 += getPairedScore(3, character.cooking.ingredients[character.cooking.pair3[0]].curLevel + character.cooking.ingredients[character.cooking.pair3[1]].curLevel);
		}
		float num4 = 0f;
		if (ingredientUnlocked(character.cooking.pair4[0]))
		{
			num4 += getLocalScore(character.cooking.pair4[0], character.cooking.ingredients[character.cooking.pair4[0]].curLevel) + getLocalScore(character.cooking.pair4[1], character.cooking.ingredients[character.cooking.pair4[0]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair4[1]))
		{
			num4 += getLocalScore(character.cooking.pair4[0], character.cooking.ingredients[character.cooking.pair4[1]].curLevel) + getLocalScore(character.cooking.pair4[1], character.cooking.ingredients[character.cooking.pair4[1]].curLevel);
		}
		if (ingredientUnlocked(character.cooking.pair4[0]) && ingredientUnlocked(character.cooking.pair4[1]))
		{
			num4 += getPairedScore(4, character.cooking.ingredients[character.cooking.pair4[0]].curLevel + character.cooking.ingredients[character.cooking.pair4[1]].curLevel);
		}
		return num + num2 + num3 + num4;
	}

	public float getCurPercentofMaxScore()
	{
		if (getOptimalScore() == 0f)
		{
			return 0.01f;
		}
		float num = getCurScore() / getOptimalScore();
		if (num < 0.01f)
		{
			return 0.01f;
		}
		if (num > 1f)
		{
			return 1f;
		}
		return num;
	}

	public float getPairedScore(int pair, int ingredLevel)
	{
		if (pair < 1 || pair > 4)
		{
			return 0f;
		}
		int num = 0;
		float num2 = 0f;
		switch (pair)
		{
		case 1:
			num = Mathf.Abs(character.cooking.pair1Target - ingredLevel);
			num2 = character.cooking.ingredients[character.cooking.pair1[0]].pairedWeight;
			break;
		case 2:
			num = Mathf.Abs(character.cooking.pair2Target - ingredLevel);
			num2 = character.cooking.ingredients[character.cooking.pair2[0]].pairedWeight;
			break;
		case 3:
			num = Mathf.Abs(character.cooking.pair3Target - ingredLevel);
			num2 = character.cooking.ingredients[character.cooking.pair3[0]].pairedWeight;
			break;
		case 4:
			num = Mathf.Abs(character.cooking.pair4Target - ingredLevel);
			num2 = character.cooking.ingredients[character.cooking.pair4[0]].pairedWeight;
			break;
		default:
			return 0f;
		}
		return Mathf.Pow(1f - 0.02f * (float)num, 40f) * num2;
	}

	public float getLocalScore(int ingredIndex, int ingredLevel)
	{
		int num = Mathf.Abs(character.cooking.ingredients[ingredIndex].targetLevel - ingredLevel);
		return Mathf.Pow(1f - 0.03f * (float)num, 30f) * character.cooking.ingredients[ingredIndex].weight;
	}

	public void tryIngredientUp(int ingredientIndex)
	{
		if (!invalidIngredientIndex(ingredientIndex))
		{
			if (character.cooking.ingredients[ingredientIndex].curLevel >= maxIngredientLevel())
			{
				string ingredientName = ingredientProperties[character.cooking.ingredients[ingredientIndex].propertyIndex].ingredientName;
				character.tooltip.showOverrideTooltip("You can't shove any more " + ingredientName + " in there!", 3f);
			}
			else
			{
				character.cooking.ingredients[ingredientIndex].curLevel++;
				updateMenu();
			}
		}
	}

	public void tryIngredientDown(int ingredientIndex)
	{
		if (!invalidIngredientIndex(ingredientIndex))
		{
			if (character.cooking.ingredients[ingredientIndex].curLevel <= 0)
			{
				character.tooltip.showOverrideTooltip("You can't put less than nothing in the dish, dumbass.", 3f);
				return;
			}
			character.cooking.ingredients[ingredientIndex].curLevel--;
			updateMenu();
		}
	}

	public int getIngredientAmount(int ingredientIndex)
	{
		if (invalidIngredientIndex(ingredientIndex))
		{
			return 1;
		}
		int propertyIndex = character.cooking.ingredients[ingredientIndex].propertyIndex;
		return ingredientProperties[propertyIndex].unitMultiplier * character.cooking.ingredients[ingredientIndex].curLevel;
	}

	public string getIngredientUnitName(int ingredientIndex)
	{
		if (invalidIngredientIndex(ingredientIndex))
		{
			return "Bug";
		}
		int propertyIndex = character.cooking.ingredients[ingredientIndex].propertyIndex;
		return ingredientProperties[propertyIndex].unitName;
	}

	public void showIngredientInfo(int ingredientIndex)
	{
		if (!invalidIngredientIndex(ingredientIndex))
		{
			int propertyIndex = character.cooking.ingredients[ingredientIndex].propertyIndex;
			if (propertyIndex >= 0 && propertyIndex < ingredientProperties.Count)
			{
				string message = ingredientProperties[propertyIndex].ingredientName + "\n\n\"" + ingredientProperties[propertyIndex].ingredientDesc + "\"";
				character.tooltip.showOverrideTooltip(message);
			}
		}
	}

	public void hideIngredientInfo()
	{
		character.tooltip.hideTooltip();
	}

	public void showDishInfo()
	{
		if (character.cooking.curDishIndex >= 0 && character.cooking.curDishIndex < dishProperties.Count)
		{
			int curDishIndex = character.cooking.curDishIndex;
			string message = dishProperties[curDishIndex].dishName + "\n\n\"" + dishProperties[curDishIndex].dishDesc + "\"";
			character.tooltip.showOverrideTooltip(message);
		}
	}

	public void hideDishInfo()
	{
		character.tooltip.hideTooltip();
	}
}
