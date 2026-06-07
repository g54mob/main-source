using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BeastQuestController : MonoBehaviour
{
	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public Slider idleProgress;

	public Button startQuestButton;

	public Button skipButton;

	public Button idleToggle;

	public Text questStats;

	public Text questDescription;

	public Text qpDisplay;

	public Text idleModeDisplay;

	public Text butterCount;

	public Text butterState;

	public Image useMajorQuestsCheckmark;

	public Button goToQuestZoneButton;

	public List<int> possibleQuests;

	private UnityAction yesaction;

	private UnityAction noAction;

	private void Start()
	{
		yesaction = skipQuest;
		noAction = cancel;
		InvokeRepeating("updateIdleQuest", 0f, 0.02f);
		InvokeRepeating("updateText", 0f, 1f);
	}

	public void cancel()
	{
	}

	private void Update()
	{
		if (character.settings.beastOn)
		{
			character.beastQuest.dailyQuestTimer.advanceTime(Time.deltaTime);
			if (character.beastQuest.dailyQuestTimer.totalseconds >= (double)timerThreshold())
			{
				character.beastQuest.dailyQuestTimer.removeTime(timerThreshold());
				addMajorQuests(dailyQuestsAdded());
			}
		}
	}

	public int resolveDailyTimer()
	{
		int curBankedQuests = character.beastQuest.curBankedQuests;
		while (character.beastQuest.dailyQuestTimer.totalseconds >= (double)timerThreshold())
		{
			character.beastQuest.dailyQuestTimer.removeTime(timerThreshold());
			addMajorQuests(dailyQuestsAdded());
		}
		return character.beastQuest.curBankedQuests - curBankedQuests;
	}

	public int maxBankedQuests()
	{
		int num = character.beastQuest.maxBankedQuests;
		if (character.arbitrary.hasExtendedQuestBank)
		{
			num += 40;
		}
		return num;
	}

	public int dailyQuestsAdded()
	{
		return 1;
	}

	public int timerThreshold()
	{
		int num = 28200;
		if (character.arbitrary.hasFasterQuests)
		{
			num = (int)((float)num * 0.8f);
		}
		if (character.inventory.itemList.fadComplete)
		{
			num = (int)((float)num * 0.9f);
		}
		return num;
	}

	public void refreshMenu()
	{
		if (character.menuID == 48)
		{
			updateText();
			updateBar();
			updateButtons();
			updateButtonText();
		}
	}

	public bool readyToHandIn()
	{
		if (character.beastQuest.inQuest && character.beastQuest.questID > 0 && character.beastQuest.curDrops >= character.beastQuest.targetDrops)
		{
			return true;
		}
		return false;
	}

	public void updateText()
	{
		if (character.menuID != 48)
		{
			return;
		}
		if (character.beastQuest.inQuest && isQuestItem(character.beastQuest.questID))
		{
			questDescription.text = "Fetch me " + character.beastQuest.targetDrops + " of the <color=blue><b>[QUEST ITEM]</b></color> " + questItemName().Substring(40) + flavourText();
			Text text = questDescription;
			text.text = text.text + " You can find this item in <b>" + questItemLocation(character.beastQuest.questID) + "</b>.";
			Text text2 = questDescription;
			text2.text = text2.text + "\n\n<b>PROGRESS:</b> " + character.beastQuest.curDrops + "/" + character.beastQuest.targetDrops;
			text2 = questDescription;
			text2.text = text2.text + "\n<b>This Quest is currently worth " + currentQuestQPValue() + " QP.</b>";
			if (character.beastQuest.reducedRewards)
			{
				questDescription.text += "\n\nThis is a <b>Minor Quest.</b>";
			}
			else
			{
				questDescription.text += "\n\nThis is a <b>Major Quest.</b>";
			}
			if (readyToHandIn())
			{
				questDescription.text += "\n\n<b>This Quest can be handed in!</b>";
			}
		}
		else if (!character.beastQuest.inQuest)
		{
			questDescription.text = "Click the 'Start Quest' button and get a Quest!";
		}
		questStats.text = "<b>Major Quests Available: </b>" + character.beastQuest.curBankedQuests + "/" + maxBankedQuests();
		Text text3 = questStats;
		text3.text = text3.text + "\n<b>More Major Quests Available in: </b>" + NumberOutput.timeOutput((double)timerThreshold() - character.beastQuest.dailyQuestTimer.totalseconds);
		if (character.beastQuest.allActive)
		{
			Text text2 = questStats;
			text2.text = text2.text + "<b>\nThis Quest is currently worth " + allActiveModifier() * 100f + "% rewards because you're a hard worker and haven't used Idle Mode!</b>";
		}
		if (character.beastQuest.curBankedQuests == 0)
		{
			Text text2 = questStats;
			text2.text = text2.text + "\n\n<b>You have no more Major Quests remaining. The Beast will now send you on Minor Quests, which are identical to Major Quests but reward only " + (float)minorQuestReward() / (float)majorQuestReward() * 100f + "% QP and AP. You can do as many as you like, though!</b>";
		}
		Text text4 = questStats;
		text4.text = text4.text + "\n\n<b>QP Reward Modifier: </b>" + character.display(questRewardFactor() * 100f) + "%";
		Text text5 = questStats;
		text5.text = text5.text + "\n<b>Quest Item Drop Modifier: </b>" + (questDropBonuses() * 100f).ToString("###,##0.##") + "%";
		qpDisplay.text = "You have " + character.display(character.beastQuest.quirkPoints);
		if (character.beastQuest.idleMode)
		{
			idleModeDisplay.text = "<b>IDLE MODE ON</b>";
		}
		else
		{
			idleModeDisplay.text = "IDLE MODE OFF";
		}
		if (character.beastQuest.usedButter)
		{
			butterState.text = "<b>BEAST BUTTER ACTIVE</b>";
		}
		else
		{
			butterState.text = "BEAST BUTTER INACTIVE";
		}
		butterCount.text = character.display(character.arbitrary.beastButterCount);
	}

	public void updateBar()
	{
		if (character.menuID == 48)
		{
			idleProgress.value = character.beastQuest.idleProgress;
		}
	}

	public void updateButtons()
	{
		if (character.menuID != 48)
		{
			return;
		}
		if (!character.settings.beastOn)
		{
			skipButton.gameObject.SetActive(value: false);
			startQuestButton.gameObject.SetActive(value: false);
			idleToggle.gameObject.SetActive(value: false);
			return;
		}
		skipButton.gameObject.SetActive(value: true);
		startQuestButton.gameObject.SetActive(value: true);
		idleToggle.gameObject.SetActive(value: true);
		if (!character.beastQuest.inQuest)
		{
			skipButton.gameObject.SetActive(value: false);
		}
		if (character.settings.useMajorQuests)
		{
			useMajorQuestsCheckmark.color = Color.white;
		}
		else
		{
			useMajorQuestsCheckmark.color = Color.clear;
		}
		if (character.arbitrary.goToQuestZoneBought)
		{
			goToQuestZoneButton.gameObject.SetActive(value: true);
		}
		else
		{
			goToQuestZoneButton.gameObject.SetActive(value: false);
		}
	}

	public void updateButtonText()
	{
		if (character.beastQuest.idleMode)
		{
			idleToggle.GetComponentInChildren<Text>().text = "OK OK I'LL FETCH THEM MYSELF";
		}
		else
		{
			idleToggle.GetComponentInChildren<Text>().text = "SCREW THE GRIND I'LL SUBCONTRACT IT";
		}
		if (character.beastQuest.inQuest)
		{
			startQuestButton.GetComponentInChildren<Text>().text = "COMPLETE THE " + goodName() + " QUEST";
			skipButton.GetComponentInChildren<Text>().text = "SKIP THE " + badName() + " QUEST";
		}
		else
		{
			startQuestButton.GetComponentInChildren<Text>().text = "START A" + goodNameVowel() + " QUEST";
		}
	}

	public string goodName()
	{
		switch (Random.Range(1, 11))
		{
		case 1:
			return " NOBLE";
		case 2:
			return " HEROIC";
		case 3:
			return " HUMBLE";
		case 4:
			return " AMAZING";
		case 5:
			return " GRAND";
		case 6:
			return " BRAVE";
		case 7:
			return " TASTY";
		case 8:
			return " GUTSY";
		case 9:
			return " DARING";
		case 10:
			return "EPIC";
		default:
			return "NOBLE";
		}
	}

	public string goodNameVowel()
	{
		switch (Random.Range(1, 11))
		{
		case 1:
			return " NOBLE";
		case 2:
			return " HEROIC";
		case 3:
			return " HUMBLE";
		case 4:
			return "N AMAZING";
		case 5:
			return " GRAND";
		case 6:
			return " BRAVE";
		case 7:
			return " TASTY";
		case 8:
			return " GUTSY";
		case 9:
			return " DARING";
		case 10:
			return "N EPIC";
		default:
			return "NOBLE";
		}
	}

	public string badName()
	{
		switch (Random.Range(1, 11))
		{
		case 1:
			return "CRAPPY";
		case 2:
			return "SHODDY";
		case 3:
			return "SHARTY";
		case 4:
			return "STINKY";
		case 5:
			return "AWFUL";
		case 6:
			return "LOUSY";
		case 7:
			return "CHEAP";
		case 8:
			return "HORRID";
		case 9:
			return "ROTTEN";
		case 10:
			return "VILE";
		default:
			return "CRAPPY";
		}
	}

	public string questItemLocation(int itemID)
	{
		switch (itemID)
		{
		case 278:
			return "the Sewers";
		case 279:
			return "2D Universe";
		case 280:
			return "Chocolate World";
		case 281:
			return "the Forest";
		case 282:
			return "A Very Strange Place";
		case 283:
			return "High Security Base";
		case 284:
			return "the Evilverse";
		case 285:
			return "the Beardverse";
		case 286:
			return "Pretty Pink Princess Land";
		case 287:
			return "the Mega Lands";
		default:
			return "'4G made an oopsie, go PM him if you see this'-Land";
		}
	}

	public string questItemName()
	{
		if (character.beastQuest.questID <= 0 || character.beastQuest.questID >= character.itemInfo.highestID())
		{
			return "A buggy item. Tell 4G if you see this!";
		}
		return character.itemInfo.itemName[character.beastQuest.questID];
	}

	public string flavourText()
	{
		if (character.beastQuest.questID <= 0 || character.beastQuest.questID >= character.itemInfo.highestID())
		{
			return "A buggy flavour text. Tell 4G if you see this!";
		}
		switch (character.beastQuest.questID)
		{
		case 278:
			return ", so that I may lure kittens into my lair and DEVOUR THEM!";
		case 279:
			return ", so that I can assemble the most boring version of the U.S. as possible! And then eat it.";
		case 280:
			return ". I get lots of things stuck in my tooth.";
		case 281:
			return ". I've always wanted to catch and eat my own dreams.";
		case 282:
			return ". My Monopoly game is missing some delicious currency and I need a replacement.";
		case 283:
			return ", so that I can make the rarest puzzle of them all!";
		case 284:
			return ". I want to rate NGU " + character.beastQuest.targetDrops + " thumbs up!";
		case 285:
			return ". I have a fetish for disgusting things.";
		case 286:
			return ". I get lonely and hungry sometimes. Mostly hungry. Man, am I ever hungry.";
		case 287:
			return ". No one will miss these anyways!";
		default:
			return ", for reasons.";
		}
	}

	public void constructQuestList()
	{
		possibleQuests.Clear();
		possibleQuests.Add(278);
		if (character.inventory.itemList.twoDComplete)
		{
			possibleQuests.Add(279);
		}
		if (character.inventory.itemList.chocoComplete)
		{
			possibleQuests.Add(280);
		}
		if (character.inventory.itemList.forestComplete)
		{
			possibleQuests.Add(281);
		}
		if (character.inventory.itemList.gaudyComplete)
		{
			possibleQuests.Add(282);
		}
		if (character.inventory.itemList.HSBComplete)
		{
			possibleQuests.Add(283);
		}
		if (character.inventory.itemList.edgyComplete && character.settings.rebirthDifficulty >= difficulty.evil)
		{
			possibleQuests.Add(284);
		}
		if (character.inventory.itemList.beardverseComplete)
		{
			possibleQuests.Add(285);
		}
		if (character.inventory.itemList.prettyComplete && character.settings.rebirthDifficulty >= difficulty.evil)
		{
			possibleQuests.Add(286);
		}
		if (character.inventory.itemList.megaComplete)
		{
			possibleQuests.Add(287);
		}
	}

	public void clearQuest()
	{
		character.beastQuest.inQuest = false;
		character.beastQuest.questID = 0;
		character.beastQuest.idleMode = false;
		character.beastQuest.targetDrops = 0;
		character.beastQuest.curDrops = 0;
		character.beastQuest.reducedRewards = false;
		character.beastQuest.allActive = true;
		character.beastQuest.usedButter = false;
		character.beastQuest.idleProgress = 0f;
	}

	public void startQuest()
	{
		if (character.beastQuest.inQuest)
		{
			return;
		}
		clearQuest();
		if (character.settings.useMajorQuests)
		{
			if (character.beastQuest.curBankedQuests > 0)
			{
				character.beastQuest.curBankedQuests--;
				character.beastQuest.reducedRewards = false;
			}
			else
			{
				character.beastQuest.reducedRewards = true;
			}
		}
		else
		{
			character.beastQuest.reducedRewards = true;
		}
		constructQuestList();
		Random.state = character.beastQuest.questState;
		int index = Random.Range(0, possibleQuests.Count);
		int questID = possibleQuests[index];
		int targetDrops = Random.Range(50, 60);
		if (character.adventure.itopod.perkLevel[94] >= 610)
		{
			targetDrops = 50;
		}
		character.beastQuest.questState = Random.state;
		character.beastQuest.inQuest = true;
		character.beastQuest.targetDrops = targetDrops;
		character.beastQuest.questID = questID;
		character.beastQuest.curDrops = 0;
	}

	public void completeQuest()
	{
		if (character.beastQuest.inQuest && character.beastQuest.questID > 0)
		{
			if (character.beastQuest.curDrops < character.beastQuest.targetDrops)
			{
				tooltip.showOverrideTooltip("You haven't finished this quest, dumbass. Are you trying to piss off the beast?", 2f);
			}
			else
			{
				giveRewardsAndClear();
			}
		}
	}

	public void giveRewardsAndClear()
	{
		giveRewardsAndClear(silent: false);
	}

	public void giveRewardsAndClear(bool silent)
	{
		if (!character.beastQuest.inQuest || character.beastQuest.questID <= 0)
		{
			return;
		}
		long num = 0L;
		long num2 = 0L;
		if (character.beastQuest.reducedRewards)
		{
			num = (long)((float)minorQuestReward() * questRewardFactor());
			num2 = minorQuestAPReward();
			if (character.beastQuest.allActive)
			{
				num2 = (long)((float)num2 * allActiveModifier());
				num = (long)((float)num * allActiveModifier());
			}
			character.beastQuest.quirkPoints += num;
			long num3 = character.addAP(num2);
			if (!silent)
			{
				tooltip.showOverrideTooltip("You have completed this Minor Quest for the Beast and it seems satisfied. It hands you " + character.display(num) + " Quirk Points and " + num3 + " AP in appreciation, devours all of the quest items, and burps with satisfaction.", 5f);
			}
		}
		else
		{
			num = (long)((float)majorQuestReward() * questRewardFactor());
			num2 = majorQuestAPReward();
			if (character.beastQuest.allActive)
			{
				num2 = (long)((float)num2 * allActiveModifier());
				num = (long)((float)num * allActiveModifier());
			}
			character.beastQuest.quirkPoints += num;
			long num4 = character.addAP(num2);
			if (!silent)
			{
				tooltip.showOverrideTooltip("You have completed this Major Quest for the Beast and it seems pleased. It hands you " + character.display(num) + " Quirk Points and " + num4 + " AP in appreciation, devours all of the quest items, and burps with satisfaction.", 5f);
			}
		}
		if (!character.beastQuest.idleMode && character.beastQuest.allActive && character.beastQuest.idleProgress >= 0.9f && character.beastQuest.idleProgress <= 1f && character.inventory.itemList.itemDropped[337])
		{
			character.itemInfo.makeLevelledLoot(338, 100);
			if (!silent)
			{
				tooltip.showOverrideTooltip("The Beast stares at you with its wide, soul-piercing eyes.... 'It's time for my brother to be released, much like myself. I can see the truth inside you... Take this.' You have received the Antlers of the Exile!", 5f);
			}
		}
		clearQuest();
	}

	public void toggleIdleMode()
	{
		character.beastQuest.idleMode = !character.beastQuest.idleMode;
		updateButtonText();
	}

	public long majorQuestReward()
	{
		return 50 + totalBaseQPBonusesMajor();
	}

	public long totalBaseQPBonusesMajor()
	{
		long num = 0L;
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num += character.wishes.wishes[101].level;
			num += character.adventure.itopod.perkLevel[147];
		}
		return num;
	}

	public long minorQuestReward()
	{
		long num = 10L;
		if (character.adventure.itopod.perkLevel[87] > 0)
		{
			num += 2;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num += character.adventure.itopod.perkLevel[148];
			num += character.wishes.wishes[102].level;
		}
		if (num > 16)
		{
			num = 16L;
		}
		return num;
	}

	public long majorQuestAPReward()
	{
		return 50L;
	}

	public long minorQuestAPReward()
	{
		long num = 10L;
		if (character.adventure.itopod.perkLevel[87] > 0)
		{
			num += 2;
		}
		if (num > 13)
		{
			num = 13L;
		}
		return num;
	}

	public float allActiveModifier()
	{
		return 2f * (character.wishesController.wishEffect(19) * character.wishesController.wishEffect(62));
	}

	public float questRewardFactor()
	{
		float num = 1f;
		if (character.inventory.itemList.godmotherComplete)
		{
			num *= 1.15f;
		}
		num *= Mathf.Pow(1.02f, questItemsMaxxed());
		num *= character.adventureController.itopod.totalQPBonus();
		num *= character.hacksController.totalQPGainBonus();
		num *= character.wishesController.totalQPBonus();
		num *= character.cardsController.getBonus(cardBonus.QP);
		if (character.inventory.itemList.orangeHeartComplete)
		{
			num *= 1.2f;
		}
		if (character.beastQuest.usedButter)
		{
			num *= character.allArbitrary.butterModifier();
		}
		if (character.adventure.itopod.perkLevel[94] >= 233)
		{
			num *= 1.1f;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		return num;
	}

	public long currentQuestQPValue()
	{
		if (!character.beastQuest.inQuest)
		{
			return 0L;
		}
		long num = 0L;
		if (character.beastQuest.reducedRewards)
		{
			num = (long)((float)minorQuestReward() * questRewardFactor());
			if (character.beastQuest.allActive)
			{
				num = (long)((float)num * allActiveModifier());
			}
		}
		else
		{
			num = (long)((float)majorQuestReward() * questRewardFactor());
			if (character.beastQuest.allActive)
			{
				num = (long)((float)num * allActiveModifier());
			}
		}
		return num;
	}

	public int questItemsMaxxed()
	{
		int num = 0;
		if (character.inventory.itemList.itemMaxxed[278])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[279])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[280])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[281])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[282])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[283])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[284])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[285])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[286])
		{
			num++;
		}
		if (character.inventory.itemList.itemMaxxed[287])
		{
			num++;
		}
		return num;
	}

	public void advanceQuest()
	{
		if (character.beastQuest.inQuest && character.beastQuest.questID > 0 && character.beastQuest.curDrops < character.beastQuest.targetDrops)
		{
			character.beastQuest.curDrops++;
		}
	}

	public bool checkItemConsumed(int idConsumed)
	{
		if (!character.beastQuest.inQuest)
		{
			return false;
		}
		if (character.beastQuest.questID <= 0)
		{
			return false;
		}
		if (character.beastQuest.curDrops >= character.beastQuest.targetDrops)
		{
			return false;
		}
		if (idConsumed == character.beastQuest.questID)
		{
			character.beastQuest.curDrops++;
			return true;
		}
		return false;
	}

	public bool checkItemConsumed(int idConsumed, int level)
	{
		if (!character.beastQuest.inQuest)
		{
			return false;
		}
		if (character.beastQuest.questID <= 0)
		{
			return false;
		}
		if (character.beastQuest.curDrops >= character.beastQuest.targetDrops)
		{
			return false;
		}
		if (idConsumed == character.beastQuest.questID)
		{
			int num = 0;
			num = 1 + level / questHandinRatio();
			if (num < 1)
			{
				num = 1;
			}
			if (level > 100)
			{
				num = 1;
			}
			character.beastQuest.curDrops += num;
			if (character.beastQuest.curDrops >= character.beastQuest.targetDrops)
			{
				character.beastQuest.curDrops = character.beastQuest.targetDrops;
			}
			return true;
		}
		return false;
	}

	public int questHandinRatio()
	{
		int num = 10;
		if (character.settings.rebirthDifficulty >= difficulty.evil)
		{
			num -= (int)character.adventure.itopod.perkLevel[146];
			num -= (int)character.beastQuest.quirkLevel[71];
			num -= character.wishes.wishes[80].level;
		}
		if (character.settings.rebirthDifficulty >= difficulty.sadistic)
		{
			num -= character.wishes.wishes[81].level;
		}
		if (num < 2)
		{
			num = 2;
		}
		return num;
	}

	public void updateIdleQuest()
	{
		if (!character.settings.beastOn || !character.beastQuest.inQuest || !character.beastQuest.idleMode)
		{
			return;
		}
		character.beastQuest.idleProgress += idleProgressPerTick();
		if (character.beastQuest.idleProgress >= 1f)
		{
			character.beastQuest.idleProgress = 0f;
			character.beastQuest.allActive = false;
			advanceQuest();
			if (character.menuID == 48)
			{
				updateText();
			}
		}
		if (character.beastQuest.curDrops >= character.beastQuest.targetDrops && character.settings.idleQuestAutocycle && character.adventure.itopod.perkLevel[104] >= 1)
		{
			giveRewardsAndClear(silent: true);
			startQuest();
			toggleIdleMode();
			if (character.menuID == 48)
			{
				refreshMenu();
			}
		}
		if (character.menuID == 48)
		{
			updateBar();
		}
	}

	public bool isQuestItem(int itemID)
	{
		if (itemID >= 278 && itemID <= 287)
		{
			return true;
		}
		return false;
	}

	public float idleProgressPerTick()
	{
		if (!character.beastQuest.inQuest || !character.settings.beastOn || character.beastQuest.questID <= 0 || !character.beastQuest.idleMode)
		{
			return 0f;
		}
		float num = expectedTimePerDrop() * idleDropFactor();
		return 1f / num / 50f;
	}

	public float idleDropFactor()
	{
		float num = 8f;
		if (character.adventure.itopod.perkLevel[105] >= 1)
		{
			num -= 2f;
		}
		if (character.adventure.itopod.perkLevel[106] >= 1)
		{
			num -= 1f;
		}
		if (character.adventure.itopod.perkLevel[91] >= 1)
		{
			num -= 1f;
		}
		if (character.adventure.itopod.perkLevel[92] >= 1)
		{
			num -= 1f;
		}
		if (num < 3f)
		{
			num = 3f;
		}
		return num;
	}

	public float questDropChance()
	{
		return 0.05f * questDropBonuses();
	}

	public float questDropBonuses()
	{
		float num = 1f;
		num *= 1f + character.inventoryController.bonuses[specType.QuestDrop];
		if (character.inventory.itemList.sigilComplete)
		{
			num *= 1.1f;
		}
		return num * character.adventureController.itopod.totalQuestDropBonus();
	}

	public float expectedTimePerDrop()
	{
		float num = 1f + character.adventureController.respawnTime();
		if (character.inventory.itemList.redLiquidComplete)
		{
			num = 0.8f + character.adventureController.respawnTime();
		}
		return num / questDropChance();
	}

	public void addMajorQuests(int amount)
	{
		if (character.beastQuest.curBankedQuests + amount > maxBankedQuests())
		{
			character.beastQuest.curBankedQuests = maxBankedQuests();
		}
		else
		{
			character.beastQuest.curBankedQuests += amount;
		}
	}

	public void startOrCompleteQuest()
	{
		if (character.beastQuest.inQuest)
		{
			completeQuest();
			refreshMenu();
			updateButtonText();
		}
		else
		{
			startQuest();
			refreshMenu();
		}
	}

	public void tryUseButter()
	{
		if (character.beastQuest.usedButter)
		{
			tooltip.showOverrideTooltip("You already buttered yourself up! Even the Beast can take only so much saturated fat.", 2.5f);
			return;
		}
		if (character.arbitrary.beastButterCount <= 0)
		{
			tooltip.showOverrideTooltip("You have no Beast Butter! You need to get some from the Sellout Shop!", 2.5f);
			return;
		}
		if (!character.beastQuest.inQuest)
		{
			tooltip.showOverrideTooltip("You need the start a Quest before using the Beast Butter!", 2f);
			return;
		}
		character.arbitrary.beastButterCount--;
		character.beastQuest.usedButter = true;
		tooltip.showTooltip("You butter yourself up and will now receive 2x the QP reward from your next completed Quest!", 2.5f);
		updateText();
	}

	public void trySkipQuest()
	{
		if (character.beastQuest.inQuest)
		{
			box.displayBox("Are you sure you want to skip this Quest? You will not receive any QP rewards.", yesaction, noAction);
		}
	}

	public void skipQuest()
	{
		clearQuest();
		refreshMenu();
		updateButtonText();
	}

	public void startIdleModeTooltip()
	{
		InvokeRepeating("showIdleModeTooltip", 0f, 0.1f);
	}

	public string timeToNextFill()
	{
		if (idleProgressPerTick() == 0f)
		{
			return "N/A";
		}
		return NumberOutput.timeOutput((1f - character.beastQuest.idleProgress) / idleProgressPerTick() / 50f);
	}

	public void showIdleModeTooltip()
	{
		string text = "";
		if (character.beastQuest.idleMode)
		{
			text = "NOTE: When Idle Questing Mode is on, Quest items cannot be looted. Also, keep in mind that a Quest completed *without* using Idle Questing Mode earns double QP and AP!";
			text = text + "\n\nTime until next drop is added to Quest: " + timeToNextFill();
		}
		else
		{
			text = "Turn on Idle Questing Mode to automatically progress the Beast's quest without having to lift a finger. You still have to hand in the quest at the end, however!";
		}
		tooltip.showTooltip(text);
	}

	public void hideTooltip()
	{
		CancelInvoke("showIdleModeTooltip");
		tooltip.hideTooltip();
	}

	public void toggleMajorQuestUse()
	{
		character.settings.useMajorQuests = !character.settings.useMajorQuests;
		updateButtons();
	}

	public int curQuestZone()
	{
		switch (character.beastQuest.questID)
		{
		case 278:
			return 1;
		case 279:
			return 9;
		case 280:
			return 20;
		case 281:
			return 2;
		case 282:
			return 12;
		case 283:
			return 5;
		case 284:
			return 21;
		case 285:
			return 15;
		case 286:
			return 22;
		case 287:
			return 13;
		default:
			return -100;
		}
	}

	public void goToQuestZone()
	{
		int num = -1;
		if (character.beastQuest.questID < 0 || character.beastQuest.questID >= character.itemInfo.highestID())
		{
			tooltip.showOverrideTooltip("Something's buggy, and you can't go to your quest's Adventure zone. Tell 4G about this!", 2f);
			return;
		}
		if (character.beastQuest.questID == 0)
		{
			tooltip.showOverrideTooltip("You're not even on a Quest, you... smurf hugger! This isn't my best day for insults.", 2f);
			return;
		}
		if (character.bossID < 4)
		{
			tooltip.showOverrideTooltip("You haven't unlocked the adventure feature yet this rebirth. Go spank the annoying mouse first!", 2f);
			return;
		}
		num = curQuestZone();
		if (num == -100)
		{
			tooltip.showOverrideTooltip("Something's buggy, and you can't go to your quest's Adventure zone. Tell 4G about this!", 2f);
			return;
		}
		if (num > character.adventureController.zoneDropdown.options.Count - 2)
		{
			tooltip.showOverrideTooltip("You idiot, you don't even have your current Quest's zone unlocked! Go unlock it, butthead.", 2f);
			return;
		}
		character.menuSwapper.swapMenu(3);
		character.adventureController.zoneSelector.changeZone(num);
	}
}
