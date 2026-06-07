using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class FruitController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public NumberFormat format;

	public HoverTooltip tooltip;

	public Slider fruitSlider;

	public YggdrasilDisplay display;

	public Image fill;

	public Image background;

	public Button actionButton;

	public Button unlockButton;

	public Button poopButton;

	public Image poopButtonFill;

	public Text nameText;

	public Button eatOption;

	public Image eatCheckmark;

	public Button harvestOption;

	public Image harvestCheckmark;

	public ThreeChoiceBox box;

	private string message;

	private UnityAction action1;

	private UnityAction action2;

	public int id;

	private void Start()
	{
		updateFruitDisplay();
		action1 = consumeFruit;
		action2 = harvest;
	}

	public void cancel()
	{
	}

	public void consumeFruit()
	{
		consumeFruit(id);
	}

	public void consumeFruit(int fruitID)
	{
		switch (fruitID)
		{
		case 0:
			consumeGoldFruit();
			break;
		case 1:
			consumePowerFruit();
			break;
		case 2:
			consumeAdventureFruit();
			break;
		case 3:
			consumeKnowledgeFruit();
			break;
		case 4:
			consumePomegranate();
			break;
		case 5:
			consumeLuckFruit();
			break;
		case 6:
			consumePermStatFruit();
			break;
		case 7:
			consumeAPFruit();
			break;
		case 8:
			consumePermNumberFruit();
			break;
		case 9:
			consumePPFruit();
			break;
		case 10:
			consumeMacguffinFruit();
			break;
		case 11:
			consumePermStatFruit2();
			break;
		case 12:
			consumeWatermelon();
			break;
		case 13:
			consumeMacguffinFruit2();
			break;
		case 14:
			consumeQPFruit();
			break;
		case 15:
			consumeMayoFruit1();
			break;
		case 16:
			consumeMayoFruit2();
			break;
		case 17:
			consumeMayoFruit3();
			break;
		case 18:
			consumeMayoFruit4();
			break;
		case 19:
			consumeMayoFruit5();
			break;
		case 20:
			consumeMayoFruit6();
			break;
		default:
			cancel();
			break;
		}
	}

	public float tierThreshold()
	{
		return 3600f - Mathf.Min(character.beastQuest.quirkLevel[13] * 60, 180f);
	}

	public int harvestTier(int fruitID)
	{
		if (fruitID < 0 || fruitID >= character.yggdrasil.fruits.Count)
		{
			return 0;
		}
		return Mathf.Min(Mathf.FloorToInt(character.yggdrasil.fruits[fruitID].seconds / tierThreshold()), (int)character.yggdrasil.fruits[fruitID].maxTier);
	}

	public void reset()
	{
		character.yggdrasil.fruits[id].reset(character.yggdrasil.resetFactor);
		updateFruitDisplay();
	}

	public void doAction()
	{
		if (!validID(id))
		{
			return;
		}
		if (character.yggdrasil.fruits[id].growing())
		{
			if (harvestTier(id) > 0)
			{
				if (character.yggdrasil.fruits[id].eatFruit)
				{
					action1();
				}
				else
				{
					action2();
				}
			}
			else
			{
				tooltip.showTooltip("This fruit isn't ready to eat or harvest!", 2f);
			}
		}
		else
		{
			activate(id);
			character.yggdrasilController.updateBonusTexts();
		}
	}

	public void activate(int fruitID)
	{
		if (!validID(fruitID))
		{
			return;
		}
		long num = character.yggdrasilController.activationCost[fruitID];
		if (character.yggdrasil.fruits[fruitID].maxTier == 0L)
		{
			tooltip.showTooltip("This fruit is still locked!", 3f);
			return;
		}
		if (character.yggdrasilController.usesEnergy[fruitID])
		{
			if (character.idleEnergy < num)
			{
				tooltip.showTooltip("You don't have enough idle Energy to start growing this fruit!", 2f);
				return;
			}
			character.idleEnergy -= num;
			character.curEnergy -= num;
			character.yggdrasil.fruits[fruitID].activate();
			tooltip.showTooltip("Fruit Activated!", 1f);
		}
		else
		{
			if (character.magic.idleMagic < num)
			{
				tooltip.showTooltip("You don't have enough idle Magic to start growing this fruit!", 2f);
				return;
			}
			character.magic.idleMagic -= num;
			character.magic.curMagic -= num;
			character.yggdrasil.fruits[fruitID].activate();
			tooltip.showTooltip("Fruit Activated!", 1f);
		}
		updateFruitDisplay();
	}

	public void consume()
	{
	}

	public void upgrade()
	{
		if (!validID(id))
		{
			return;
		}
		long num = character.yggdrasilController.baseSeedCost[id] * Mathf.CeilToInt(Mathf.Pow(character.yggdrasil.fruits[id].maxTier + 1, 2f));
		if (id == 8 && character.yggdrasil.fruits[id].maxTier == 0L)
		{
			tooltip.showOverrideTooltip("This fruit can only be unlocked through the Troll Challenge, completion #5!", 3f);
			return;
		}
		if (id == 9 && !character.settings.itopodOn)
		{
			tooltip.showOverrideTooltip("This fruit can only be unlocked after unlocking the ITOPOD! How the heck do you not have the ITOPOD unlocked by now? Go to the sky, pronto!", 3f);
			return;
		}
		if (id == 10 && !character.achievements.achievementComplete[145])
		{
			tooltip.showOverrideTooltip("This fruit can only be unlocked after defeating a specific Titan!", 3f);
			return;
		}
		if (id == 14 && character.yggdrasil.fruits[id].maxTier == 0L && !character.settings.beastOn)
		{
			tooltip.showOverrideTooltip("This fruit can only be unlocked when you defeat Titan 6!", 3f);
			return;
		}
		if (id >= 15 && id <= 20 && character.yggdrasil.fruits[id].maxTier == 0L && !character.cards.cardsOn)
		{
			tooltip.showOverrideTooltip("This fruit can only be unlocked when you defeat Titan 9!", 3f);
			return;
		}
		if (character.yggdrasil.seeds < num)
		{
			if (character.yggdrasil.fruits[id].maxTier == 0L)
			{
				tooltip.showTooltip("You can't afford to unlock this fruit!", 1f);
			}
			else
			{
				tooltip.showTooltip("You can't afford to upgrade this fruit!", 1f);
			}
		}
		else if (character.yggdrasil.fruits[id].maxTier >= character.yggdrasilController.capTier())
		{
			tooltip.showTooltip("This fruit has the highest Tier possible!", 1f);
		}
		else
		{
			character.yggdrasil.seeds -= num;
			character.yggdrasil.fruits[id].maxTier++;
			if (character.yggdrasil.fruits[id].maxTier == 0L)
			{
				tooltip.showTooltip("You've successfully unlocked this fruit!", 1f);
			}
			else
			{
				tooltip.showTooltip("You've successfully upgraded this fruit!", 1f);
			}
			unlockInfo();
		}
		updateFruitDisplay();
	}

	public void updateFruitSlider()
	{
		if (character.settings.fancyYggBars)
		{
			fancyFruitSlider();
		}
		else
		{
			normalFruitSlider();
		}
	}

	public void normalFruitSlider()
	{
		float value = character.yggdrasil.fruits[id].seconds / tierThreshold() % 1f;
		fill.color = character.yggdrasilController.tierColours[1];
		background.color = character.yggdrasilController.tierColours[0];
		fruitSlider.value = value;
	}

	public void fancyFruitSlider()
	{
		float num = character.yggdrasil.fruits[id].seconds / tierThreshold();
		int num2 = Mathf.FloorToInt(Mathf.Min(num, character.yggdrasil.fruits[id].maxTier));
		float value = num % 1f;
		if (num2 == 24)
		{
			fill.color = character.yggdrasilController.tierColours[24];
			background.color = character.yggdrasilController.tierColours[23];
		}
		else
		{
			fill.color = character.yggdrasilController.tierColours[num2 + 1];
			background.color = character.yggdrasilController.tierColours[num2];
		}
		fruitSlider.value = value;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showTooltip", 0f, 1f);
	}

	public void showTooltip()
	{
		if (!validID(id))
		{
			return;
		}
		message = "<b>" + character.yggdrasilController.fruitName[id] + "</b>\n\n" + character.yggdrasilController.fruitDescription[id];
		message = message + "\n\n<b>Current Fruit Tier:</b> " + harvestTier(id);
		message = message + "\n\n<b>Time to next Tier:</b> " + timeToNextTier();
		message = message + "\n\n<b>Max Tier:</b> " + character.yggdrasil.fruits[id].maxTier;
		if (!character.yggdrasil.fruits[id].activated)
		{
			message = message + "\n\n<b>Activation Cost: </b> " + character.display(character.yggdrasilController.activationCost[id]);
			if (character.yggdrasilController.usesEnergy[id])
			{
				message += " Energy";
			}
			else
			{
				message += " Magic";
			}
		}
		else
		{
			message += "\n\n<b>Fruit activated and growing.</b>";
		}
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke("showTooltip");
		tooltip.hideTooltip();
	}

	private string timeToNextTier()
	{
		if (harvestTier(id) >= character.yggdrasil.fruits[id].maxTier)
		{
			return "DONE";
		}
		int num = (int)(tierThreshold() - character.yggdrasil.fruits[id].seconds % tierThreshold());
		if (character.yggdrasil.fruits[id].seconds / tierThreshold() > (float)character.yggdrasil.fruits[id].maxTier)
		{
			return "DONE";
		}
		return NumberOutput.timeOutput(num);
	}

	public bool validID(int fruitID)
	{
		if (fruitID >= Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			return false;
		}
		if (fruitID < 0)
		{
			return false;
		}
		return true;
	}

	public void updateButton()
	{
		if (!validID(id))
		{
			return;
		}
		if (character.arbitrary.hasYggdrasilReminder && character.yggdrasil.fruits[id].activated)
		{
			if (harvestTier(id) >= character.yggdrasil.fruits[id].maxTier)
			{
				actionButton.image.color = Color.green;
			}
			else
			{
				actionButton.image.color = Color.white;
			}
		}
		else
		{
			actionButton.image.color = Color.white;
		}
	}

	public long seedReward(int fruitID, int tier, float poopBonus)
	{
		return (long)Mathf.Ceil((float)(character.yggdrasilController.baseSeedReward[fruitID] * tier) * poopBonus * character.adventureController.itopod.totalSeedBonus() * character.beastQuestPerkController.totalSeedBonus() * (1f + character.inventoryController.bonuses[specType.Seeds]) * character.NGUController.yggdrasilBonus() * character.adventureController.itopod.totalHarvestBonus(fruitID));
	}

	public long harvestSeedReward(int fruitID, int tier, float poopBonus)
	{
		return (long)Mathf.Ceil((float)(character.yggdrasilController.baseSeedReward[fruitID] * tier * 2) * poopBonus * character.adventureController.itopod.totalSeedBonus() * character.beastQuestPerkController.totalSeedBonus() * (1f + character.inventoryController.bonuses[specType.Seeds]) * character.NGUController.yggdrasilBonus() * character.adventureController.itopod.totalHarvestBonus(fruitID));
	}

	public void harvest()
	{
		harvest(id);
	}

	public void harvest(int fruitID)
	{
		if (fruitID >= 0 && fruitID <= character.yggdrasil.fruits.Count)
		{
			int tier = tierFactor(harvestTier(fruitID));
			float poopBonus = usePoop(fruitID);
			long num = harvestSeedReward(fruitID, tier, poopBonus);
			character.yggdrasil.seeds += num;
			character.yggdrasil.fruits[fruitID].deactivate();
			tooltip.showTooltip("You gained " + num + " Seeds!", 2f);
			character.yggdrasil.fruits[fruitID].harvests++;
			updateFruitDisplay();
		}
	}

	public void consumeGoldFruit()
	{
		int num = tierFactor(harvestTier(0));
		float num2 = usePoop(0);
		double num3 = (double)((float)num * num2 * 1800f) * character.grossGoldPerSecond() * (double)character.adventureController.itopod.totalHarvestBonus(0);
		long num4 = seedReward(0, num, num2);
		character.addGold(num3);
		character.yggdrasil.seeds += num4;
		character.yggdrasil.fruits[0].deactivate();
		tooltip.showOverrideTooltip("You gained " + character.display(num3) + " Gold and " + num4 + " Seeds!", 2f);
		character.yggdrasil.fruits[0].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumePowerFruit()
	{
		int num = tierFactor(harvestTier(1));
		float num2 = usePoop(1);
		long num3 = seedReward(1, num, num2);
		double num4 = character.yggdrasil.totalStatBonus();
		long num5 = (long)Mathf.Ceil((float)num * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(1));
		character.yggdrasil.fruits[1].totalLevels += num5;
		double num6 = character.yggdrasil.totalStatBonus();
		character.yggdrasil.seeds += num3;
		tooltip.showOverrideTooltip("You eat the fruit and icrease your Attack and Defense! Power Fruit α's multiplier increased from <b>" + character.display(num4 * 100.0) + "%</b> to <b>" + character.display(num6 * 100.0) + "%</b>.You've also gained " + num3 + " Seeds!", 4f);
		character.yggdrasil.fruits[1].harvests++;
		character.yggdrasil.fruits[1].deactivate();
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumeAdventureFruit()
	{
		int num = tierFactor(harvestTier(2));
		float num2 = usePoop(2);
		long num3 = seedReward(2, num, num2);
		float num4 = (int)(Mathf.Pow(character.adventure.defense, 0.2f) * (float)num * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(2));
		float num5 = (int)(Mathf.Pow(character.adventure.defense, 0.2f) * (float)num * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(2));
		if (num4 < 0f)
		{
			num4 = 0f;
		}
		if (num5 < 0f)
		{
			num5 = 0f;
		}
		float num6 = num4 * 3f;
		float num7 = num5 * 0.03f;
		character.yggdrasil.seeds += num3;
		character.adventure.attack += num4;
		character.adventure.defense += num5;
		character.adventure.maxHP += num6;
		character.adventure.regen += num7;
		string text = "You gained:\n\n" + character.display(num4) + " Power!\n" + character.display(num5) + " Toughness!\n" + character.display(num6) + " Max Health!\n" + character.display(num7) + " Health Regen!\nAnd " + character.display(num3) + " Seeds!";
		tooltip.showOverrideTooltip(text, 2f);
		character.yggdrasil.fruits[2].deactivate();
		character.yggdrasil.fruits[2].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumeKnowledgeFruit()
	{
		int num = tierFactor(harvestTier(3));
		float num2 = usePoop(3);
		long num3 = seedReward(3, num, num2);
		int num4 = (int)Mathf.Ceil((float)(5 * num) * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(3));
		if (character.adventure.itopod.perkLevel[19] >= 1)
		{
			num4 *= 3;
		}
		if (character.adventure.itopod.perkLevel[20] >= 1)
		{
			num4 *= 3;
		}
		character.yggdrasil.seeds += num3;
		string text = "You gained " + character.display(character.addExp(num4)) + " EXP and " + character.display(num3) + " seeds!";
		tooltip.showOverrideTooltip(text, 3f);
		character.yggdrasil.fruits[3].deactivate();
		character.yggdrasil.fruits[3].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumePomegranate()
	{
		int tier = tierFactor(harvestTier(4));
		float poopBonus = usePoop(4);
		long num = harvestSeedReward(4, tier, poopBonus);
		character.yggdrasil.seeds += num;
		message = "You gained " + character.display(num) + " seeds!";
		tooltip.showOverrideTooltip(message, 3f);
		character.yggdrasil.fruits[4].deactivate();
		character.yggdrasil.fruits[4].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public long awardPartialPomegranate(float percentage, int tossFactor)
	{
		int tier = tierFactor(24);
		long num = (long)((float)harvestSeedReward(4, tier, 1f) * percentage);
		num *= tossFactor;
		character.yggdrasil.seeds += num;
		return num;
	}

	public void consumeLuckFruit()
	{
		if (5 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(5));
			float num2 = usePoop(5);
			long num3 = seedReward(5, num, num2);
			long num4 = (long)Mathf.Ceil((float)character.yggdrasilController.baseSeedReward[5] * 0.7f * (float)num * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(5));
			float num5 = character.yggdrasilController.luckBonus();
			character.yggdrasil.totalLuck += num4;
			float num6 = character.yggdrasilController.luckBonus();
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain:\n+" + ((num6 - num5) * 100f).ToString("###,##0.##") + "% Drop Chance! You also gain + " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[5].deactivate();
			character.yggdrasil.fruits[5].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumePermStatFruit()
	{
		if (6 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(6));
			float num2 = usePoop(6);
			long num3 = seedReward(6, num, num2);
			long num4 = (long)Mathf.Ceil((float)(character.yggdrasilController.baseSeedReward[6] * num) * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(6));
			double num5 = character.yggdrasilController.permStatBonus(flag: true);
			character.yggdrasil.totalPermStatBonus += num4;
			double num6 = character.yggdrasilController.permStatBonus(flag: true);
			character.yggdrasil.seeds += num3;
			character.yggdrasil.permBonusOn = true;
			string text = "You eat the fruit. It tastes fruity. You also gain:\n+" + ((num6 - num5) * 100.0).ToString("###,##0.##") + "% to your Attack and Defense! You also gain + " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[6].deactivate();
			character.yggdrasil.fruits[6].harvests++;
			updateFruitDisplay();
			character.yggdrasilController.updateBonusTexts();
		}
	}

	public void consumeAPFruit()
	{
		int num = tierFactor(harvestTier(7));
		float num2 = usePoop(7);
		long num3 = seedReward(7, num, num2);
		long amount = (long)Mathf.Ceil((float)(15 * num) * num2 * character.adventureController.itopod.totalHarvestBonus(7));
		amount = character.addAP(amount);
		character.yggdrasil.seeds += num3;
		string text = "You eat the fruit. You're filled with the most arbitrary sensations in your stomach. You also gained " + amount + " AP and " + character.display(num3) + " Seeds, which is pretty neat!";
		tooltip.showOverrideTooltip(text, 2f);
		character.yggdrasil.fruits[7].deactivate();
		character.yggdrasil.fruits[7].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumePermNumberFruit()
	{
		int num = tierFactor(harvestTier(8));
		float num2 = usePoop(8);
		long num3 = seedReward(8, num, num2);
		long num4 = (long)Mathf.Ceil((float)(character.yggdrasilController.baseSeedReward[8] * num) * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(8));
		double num5 = character.yggdrasilController.permNumberBonus(flag: true);
		character.yggdrasil.totalPermNumberBonus += num4;
		double num6 = character.yggdrasilController.permNumberBonus(flag: true);
		character.yggdrasil.seeds += num3;
		character.yggdrasil.permNumberBonusOn = true;
		string text = "You eat the fruit. It tastes fruity. You also gain:\n+" + ((num6 - num5) * 100.0).ToString("###,##0.##") + "% to your NUMBER Bonus! You also gain + " + character.display(num3) + " Seeds!";
		tooltip.showOverrideTooltip(text, 3f);
		character.yggdrasil.fruits[8].deactivate();
		character.yggdrasil.fruits[8].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumePPFruit()
	{
		if (9 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(9));
			float num2 = usePoop(9);
			long num3 = seedReward(9, num, num2);
			long num4 = (long)Mathf.Ceil((float)(60000 * num) * num2 * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalPPBonus(usePills: false) * character.adventureController.itopod.totalHarvestBonus(9));
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + character.display(character.adventureController.itopod.progressToPP(num4)) + " Perk Points and " + character.display(character.adventureController.itopod.progressToRemainder(num4)) + " Progress to your next PP! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.adventureController.itopod.addProgress(num4);
			character.yggdrasil.fruits[9].deactivate();
			character.yggdrasil.fruits[9].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMacguffinFruit()
	{
		if (10 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(10));
			float num2 = usePoop(10);
			long num3 = seedReward(10, num, num2);
			long num4 = (long)Mathf.Ceil((float)num * 0.5f * num2 * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(10) * character.wishesController.totalFruitGuffbonus());
			if (num4 >= int.MaxValue)
			{
				num4 = 2147483647L;
			}
			if (num4 < 0)
			{
				num4 = 0L;
			}
			int num5 = 0;
			num5 = ((character.wishes.wishes[25].level <= 0) ? character.inventoryController.levelRandomMacguffinFruit((int)num4) : character.inventoryController.levelFirstMacguffinFruit((int)num4));
			character.yggdrasil.seeds += num3;
			string text = "";
			text = ((num5 != -1) ? ("You eat the fruit and gain " + num4 + " levels to your " + character.itemInfo.itemName[character.inventory.macguffins[num5].id] + "! You also gained " + character.display(num3) + " Seeds!") : " You eat the fruit and feel pissed off because you had absolutely no MacGuffins equipped and it did nothing.");
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[10].deactivate();
			character.yggdrasil.fruits[10].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumePermStatFruit2()
	{
		if (11 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(11));
			float num2 = usePoop(11);
			long num3 = seedReward(11, num, num2);
			long num4 = (long)Mathf.Ceil((float)(character.yggdrasilController.baseSeedReward[11] * num) * num2 * character.NGUController.yggdrasilBonus() * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(11));
			double num5 = character.yggdrasilController.permStatBonus2();
			character.yggdrasil.totalPermStatBonus2 += num4;
			double num6 = character.yggdrasilController.permStatBonus2();
			character.yggdrasil.seeds += num3;
			string text = "You put on an extra strong pair of shades and eat the fruit. The glasses melt onto your face causing unbearable pain, but you gain:\n+" + ((num6 - num5) * 100.0).ToString("###,##0.##") + "% to your Attack and Defense! You also gain + " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[11].deactivate();
			character.yggdrasil.fruits[11].harvests++;
			updateFruitDisplay();
			character.yggdrasilController.updateBonusTexts();
		}
	}

	public void consumeWatermelon()
	{
		int tier = tierFactor(harvestTier(12));
		float poopBonus = usePoop(12);
		long num = harvestSeedReward(12, tier, poopBonus);
		character.yggdrasil.seeds += num;
		message = "You gained " + character.display(num) + " seeds!";
		tooltip.showOverrideTooltip(message, 3f);
		character.yggdrasil.fruits[12].deactivate();
		character.yggdrasil.fruits[12].harvests++;
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void consumeMacguffinFruit2()
	{
		if (13 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = tierFactor(harvestTier(13));
			float num2 = usePoop(13);
			long num3 = seedReward(13, num, num2);
			long num4 = (long)Mathf.Ceil((float)num * 0.1f * num2 * character.yggdrasilYieldBonus() * character.adventureController.itopod.totalHarvestBonus(13));
			if (num4 >= int.MaxValue)
			{
				num4 = 2147483647L;
			}
			if (num4 < 0)
			{
				num4 = 0L;
			}
			character.inventoryController.levelAllMacguffinsFruit((int)num4);
			character.yggdrasil.seeds += num3;
			string text = "";
			text = "You eat the fruit and gain " + num4 + " levels to ALL your equipped MacGuffins! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[13].deactivate();
			character.yggdrasil.fruits[13].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeQPFruit()
	{
		if (14 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			int num = harvestTier(14);
			float num2 = character.beastQuestController.questRewardFactor();
			if (character.beastQuest.usedButter)
			{
				num2 /= character.allArbitrary.butterModifier();
			}
			float num3 = usePoop(14);
			long num4 = seedReward(14, num, num3);
			long num5 = (long)Mathf.Ceil((float)(3 * num) * num3 * character.yggdrasilYieldBonus() * num2 * character.adventureController.itopod.totalHarvestBonus(14));
			character.yggdrasil.seeds += num4;
			string text = "You eat the fruit and gain " + character.display(num5) + " Quirk Points! You also gained " + character.display(num4) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.beastQuest.quirkPoints += num5;
			character.yggdrasil.fruits[14].deactivate();
			character.yggdrasil.fruits[14].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit1()
	{
		if (15 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(15), 1.1f);
			float num2 = usePoop(15);
			long num3 = seedReward(15, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[0].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[0].amount += num6;
			character.cards.manas[0].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Angry Mayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[15].deactivate();
			character.yggdrasil.fruits[15].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit2()
	{
		if (16 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(16), 1.1f);
			float num2 = usePoop(16);
			long num3 = seedReward(16, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[1].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[1].amount += num6;
			character.cards.manas[1].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Sad Mayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[16].deactivate();
			character.yggdrasil.fruits[16].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit3()
	{
		if (17 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(17), 1.1f);
			float num2 = usePoop(17);
			long num3 = seedReward(17, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[2].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[2].amount += num6;
			character.cards.manas[2].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Moldy Mayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[17].deactivate();
			character.yggdrasil.fruits[17].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit4()
	{
		if (18 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(18), 1.1f);
			float num2 = usePoop(18);
			long num3 = seedReward(18, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[3].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[3].amount += num6;
			character.cards.manas[3].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Ayy Lmayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[18].deactivate();
			character.yggdrasil.fruits[18].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit5()
	{
		if (19 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(19), 1.1f);
			float num2 = usePoop(19);
			long num3 = seedReward(19, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[4].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[4].amount += num6;
			character.cards.manas[4].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Cinco De Mayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[19].deactivate();
			character.yggdrasil.fruits[19].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void consumeMayoFruit6()
	{
		if (20 < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			float num = Mathf.Pow(harvestTier(20), 1.1f);
			float num2 = usePoop(20);
			long num3 = seedReward(20, (int)num, num2);
			float num4 = num * 0.025f * character.cardsController.totalMayoSpeed() * num2;
			float num5 = character.cards.manas[5].progress + num4;
			int num6 = Mathf.FloorToInt(num5);
			num5 %= 1f;
			character.cards.manas[5].amount += num6;
			character.cards.manas[5].progress = num5;
			character.yggdrasil.seeds += num3;
			string text = "You eat the fruit and gain " + num4.ToString("##0.##") + " Pretty Mayo! You also gained " + character.display(num3) + " Seeds!";
			tooltip.showOverrideTooltip(text, 2f);
			character.yggdrasil.fruits[20].deactivate();
			character.yggdrasil.fruits[20].harvests++;
			updateFruitDisplay();
			updateFruitSlider();
		}
	}

	public void refresh()
	{
		updateFruitDisplay();
		character.yggdrasilController.updateBonusTexts();
	}

	public void unlockInfo()
	{
		if (id >= Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			return;
		}
		long num = character.yggdrasilController.baseSeedCost[id] * Mathf.CeilToInt(Mathf.Pow(character.yggdrasil.fruits[id].maxTier + 1, 2f));
		if (character.yggdrasil.fruits[id].maxTier == 0L)
		{
			tooltip.showTooltip("<b>Unlock the " + character.yggdrasilController.fruitName[id] + " for " + character.display(num) + " Seeds!</b>");
			return;
		}
		if (character.yggdrasil.fruits[id].maxTier >= character.yggdrasilController.capTier())
		{
			message = "<b>" + character.yggdrasilController.fruitName[id] + "</b>\n\n";
			message = message + "<b>Current Max Fruit Tier:</b> " + character.yggdrasil.fruits[id].maxTier + " (MAX)";
		}
		else
		{
			message = "<b>" + character.yggdrasilController.fruitName[id] + "</b>\n\n";
			message = message + "<b>Current Max Fruit Tier:</b> " + character.yggdrasil.fruits[id].maxTier + "\n\n<b>Upgrade Max Fruit Tier for:</b> " + character.display(num) + " Seeds.";
		}
		tooltip.showTooltip(message);
	}

	public void hideUnlockInfo()
	{
		tooltip.hideTooltip();
	}

	public float usePoop(int fruitID)
	{
		float num = 1f;
		if (!validID(fruitID))
		{
			return 1f;
		}
		if (character.settings.poopOnlyMaxTier && !fruitMaxxed(fruitID))
		{
			return 1f;
		}
		if (character.inventory.itemList.itemMaxxed[162] && character.yggdrasil.fruits[fruitID].usePoop && character.arbitrary.poop1Count > 0)
		{
			if (character.stats.poopUsed % 10 != 0L)
			{
				character.arbitrary.poop1Count--;
			}
			character.stats.poopUsed++;
			return character.allArbitrary.poopModifier();
		}
		if (character.inventory.itemList.itemMaxxed[162] && character.yggdrasil.fruits[fruitID].usePoop && character.stats.poopUsed % 10 == 0L)
		{
			character.stats.poopUsed++;
			return character.allArbitrary.poopModifier();
		}
		if (character.yggdrasil.fruits[fruitID].usePoop && character.arbitrary.poop1Count > 0)
		{
			character.arbitrary.poop1Count--;
			character.stats.poopUsed++;
			num = character.allArbitrary.poopModifier();
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (num > 1.65f)
		{
			num = 1.65f;
		}
		return num;
	}

	public int tierFactor(int tier)
	{
		return Mathf.CeilToInt(Mathf.Pow(tier, 1.5f));
	}

	public bool fruitMaxxed()
	{
		if (id >= Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			return false;
		}
		if (character.yggdrasil.fruits[id].maxTier == 0L)
		{
			return false;
		}
		return harvestTier(id) >= character.yggdrasil.fruits[id].maxTier;
	}

	public bool fruitMaxxed(int fruitID)
	{
		if (fruitID >= Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			return false;
		}
		if (character.yggdrasil.fruits[fruitID].maxTier == 0L)
		{
			return false;
		}
		return harvestTier(fruitID) >= character.yggdrasil.fruits[fruitID].maxTier;
	}

	public void togglePoop()
	{
		if (id < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			character.yggdrasil.fruits[id].usePoop = !character.yggdrasil.fruits[id].usePoop;
			updateFruitDisplay();
		}
	}

	public void toggleEat()
	{
		if (id < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			character.yggdrasil.fruits[id].eatFruit = true;
			updateFruitDisplay();
		}
	}

	public void toggleHarvest()
	{
		if (id < Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			character.yggdrasil.fruits[id].eatFruit = false;
			updateFruitDisplay();
		}
	}

	public void updateFruitDisplay()
	{
		if (character.menuID != 9)
		{
			return;
		}
		if (id >= Math.Min(character.yggdrasil.fruits.Count, character.yggdrasilController.activationCost.Count))
		{
			character.yggdrasilController.pods[id % 9].SetActive(value: false);
			actionButton.GetComponentInChildren<Text>().text = "";
			eatCheckmark.color = Color.clear;
			harvestCheckmark.color = Color.clear;
			poopButtonFill.color = Color.clear;
			actionButton.interactable = false;
			actionButton.GetComponentInChildren<Text>().text = "";
			unlockButton.interactable = false;
			unlockButton.GetComponentInChildren<Text>().text = "";
			fruitSlider.value = 0f;
			nameText.text = "";
			return;
		}
		character.yggdrasilController.pods[id % 9].SetActive(value: true);
		actionButton.interactable = true;
		unlockButton.interactable = true;
		if (character.yggdrasil.fruits[id].eatFruit)
		{
			actionButton.GetComponentInChildren<Text>().text = "Eat";
			eatCheckmark.color = Color.white;
			harvestCheckmark.color = Color.clear;
		}
		else
		{
			actionButton.GetComponentInChildren<Text>().text = "Harvest";
			eatCheckmark.color = Color.clear;
			harvestCheckmark.color = Color.white;
		}
		if (!character.yggdrasil.fruits[id].activated)
		{
			actionButton.GetComponentInChildren<Text>().text = "Activate";
		}
		if (character.yggdrasil.fruits[id].usePoop)
		{
			poopButtonFill.color = Color.white;
		}
		else
		{
			poopButtonFill.color = Color.clear;
		}
		if (character.yggdrasil.fruits[id].maxTier == 0L)
		{
			unlockButton.GetComponentInChildren<Text>().text = "Unlock";
		}
		else
		{
			unlockButton.GetComponentInChildren<Text>().text = "Upgrade";
		}
		nameText.text = character.yggdrasilController.fruitName[id];
		if (character.yggdrasil.fruits[id].maxTier >= 1)
		{
			Text text = nameText;
			text.text = text.text + " (" + harvestTier(id) + "/" + character.yggdrasil.fruits[id].maxTier + ")";
		}
		if (id == 13 || (id >= 15 && id <= 20))
		{
			nameText.fontSize = 12;
		}
		else
		{
			nameText.fontSize = 14;
		}
		updateFruitSlider();
		character.yggdrasilController.updateDisplay();
	}
}
