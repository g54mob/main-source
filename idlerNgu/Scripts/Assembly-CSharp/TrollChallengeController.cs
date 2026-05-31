using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class TrollChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public AllChallengesController allChallenges;

	public Button challengeButton;

	public Text challengeInfo;

	public ConfirmationBox box;

	private UnityAction action;

	private UnityAction actionExit;

	private UnityAction trollBox2;

	private UnityAction noAdvance;

	public int switcherooBox;

	public Image kitty;

	private string message;

	public int baseExpReward;

	public int baseAPReward;

	public int maxCompletions;

	public int boxCounter;

	private void Start()
	{
		action = displayBox;
		trollBox2 = trollBox;
		noAdvance = displayBoxNoAdvance;
		actionExit = nothing;
		InvokeRepeating("updateTroll", 0f, 1f);
	}

	public void nothing()
	{
	}

	private void Update()
	{
		if (kitty.transform.localPosition.y < 450f)
		{
			kitty.gameObject.transform.Translate(new Vector3(0f, 0.35f, 0f));
		}
		else
		{
			trollKittyOff();
		}
		updateButton();
		if (character.challenges.trollChallenge.inChallenge)
		{
			character.challenges.trollChallenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.bossID > targetBoss())
			{
				complete();
			}
		}
	}

	public void updateButton()
	{
		if (character.menuID != 12)
		{
			return;
		}
		if (unlocked())
		{
			challengeButton.interactable = true;
			challengeButton.GetComponentInChildren<Text>().text = "The Troll Challenge";
			if (sadisticCompletions() >= maxCompletions)
			{
				challengeButton.image.sprite = allChallenges.redBorder;
			}
			else if (evilCompletions() >= maxCompletions)
			{
				challengeButton.image.sprite = allChallenges.orangeBorder;
			}
			else if (completions() >= maxCompletions)
			{
				challengeButton.image.sprite = allChallenges.goldBorder;
			}
			else
			{
				challengeButton.image.sprite = allChallenges.normalBorder;
			}
		}
		else
		{
			challengeButton.image.sprite = allChallenges.normalBorder;
			challengeButton.interactable = false;
			challengeButton.GetComponentInChildren<Text>().text = "Challenge Locked";
		}
	}

	public int targetBoss()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return 68 + completions() * 15;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return 68 + evilCompletions() * 15;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return 68 + sadisticCompletions() * 15;
		}
		return 68 + completions() * 15;
	}

	public int completions()
	{
		if (character.challenges.trollChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.trollChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.trollChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.trollChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.trollChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.trollChallenge.curSadisticCompletions;
	}

	public int currentCompletions()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return completions();
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return evilCompletions();
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return sadisticCompletions();
		}
		return completions();
	}

	public float totalMagicNGUBonus()
	{
		float result = 1f;
		if (character.allChallenges.trollChallenge.completions() >= 1)
		{
			result = 3f;
		}
		return result;
	}

	public float totalEnergyNGUBonus()
	{
		float result = 1f;
		if (character.allChallenges.trollChallenge.sadisticCompletions() >= 1)
		{
			result = 3f;
		}
		return result;
	}

	private void complete()
	{
		int timeAsHighscore = character.challenges.trollChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.trollChallenge.bestTime = timeAsHighscore;
		character.challenges.trollChallenge.challengeTime.reset();
		character.challenges.trollChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		resetTrolls();
		resetCounter();
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.trollChallenge.curCompletions++;
			if (character.challenges.trollChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			switch (character.challenges.trollChallenge.curCompletions)
			{
			case 1:
				tooltip.showOverrideTooltip("For your 1st Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked a permanent x3 boost to Magic NGU Speed!", 5f);
				break;
			case 2:
				tooltip.showOverrideTooltip("For your 2nd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also have unlocked a new accessory slot!", 5f);
				character.inventoryController.updateAccCount();
				break;
			case 3:
				tooltip.showOverrideTooltip("For your 3rd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked a max fruit tier of 24 for Yggdrasil!", 5f);
				break;
			case 4:
				tooltip.showOverrideTooltip("For your 4th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked a new Beard Slot!", 5f);
				break;
			case 5:
				tooltip.showOverrideTooltip("For your 5th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked a new Fruit: The Fruit of Numbers!", 5f);
				character.yggdrasil.fruits[8].maxTier = 1L;
				break;
			case 6:
				tooltip.showOverrideTooltip("For your 6th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked a new Blood Magic Ritual!", 5f);
				break;
			case 7:
				tooltip.showOverrideTooltip("For your 7th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also unlocked The Golden Beard!.", 5f);
				break;
			default:
				tooltip.showOverrideTooltip("Why the hell did you do another troll challenge after you completed the set? Weirdo.", 5f);
				break;
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.trollChallenge.curEvilCompletions++;
			if (character.challenges.trollChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			switch (character.challenges.trollChallenge.curEvilCompletions)
			{
			case 1:
				tooltip.showOverrideTooltip("For your 1st Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also have unlocked a new accessory slot!", 5f);
				character.inventoryController.updateAccCount();
				break;
			case 2:
				tooltip.showOverrideTooltip("For your 2nd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				character.inventoryController.updateMacguffinCount();
				break;
			case 3:
				tooltip.showOverrideTooltip("For your 3rd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained a new Daycare Slot!", 5f);
				character.inventoryController.updateDaycareCount();
				break;
			case 4:
				tooltip.showOverrideTooltip("For your 4th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			case 5:
				tooltip.showOverrideTooltip("For your 5th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			case 6:
				tooltip.showOverrideTooltip("For your 6th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			case 7:
				tooltip.showOverrideTooltip("For your 7th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			default:
				tooltip.showOverrideTooltip("Why the hell did you do another troll challenge after you completed the set? Weirdo.", 5f);
				break;
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.trollChallenge.curSadisticCompletions++;
			if (character.challenges.trollChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			switch (character.challenges.trollChallenge.curSadisticCompletions)
			{
			case 1:
				tooltip.showOverrideTooltip("For your 1st Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained a x3 speed bonus to your Energy NGU's! Where the hell was this like 2 difficulties ago???", 5f);
				break;
			case 2:
				tooltip.showOverrideTooltip("For your 2nd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! you also unlocked way better Idle MacGuffins!", 5f);
				break;
			case 3:
				tooltip.showOverrideTooltip("For your 3rd Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			case 4:
				tooltip.showOverrideTooltip("For your 4th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!", 5f);
				break;
			case 5:
				tooltip.showOverrideTooltip("For your 5th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained +10% Card Generation speed!", 5f);
				break;
			case 6:
				tooltip.showOverrideTooltip("For your 6th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained +10% Card Generation speed!", 5f);
				break;
			case 7:
				tooltip.showOverrideTooltip("For your 7th Troll Challenge completion, you gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained what is probably your FINAL accessory slot! You have officially beaten me into submission. -4G", 5f);
				character.inventoryController.updateAccCount();
				break;
			default:
				tooltip.showOverrideTooltip("Why the hell did you do another troll challenge after you completed the set? Weirdo.", 5f);
				break;
			}
		}
	}

	public void resetTrolls()
	{
		character.inventory.disabled = false;
		character.NGU.disabled = false;
		character.beards.disabled = false;
		character.wandoos98.disabled = false;
		character.challenges.trollMenuSwap = false;
		character.inventoryController.updateBonuses();
		character.challenges.trollDivided = false;
	}

	public void resetCounter()
	{
		character.challenges.trollCounter = 0;
	}

	public void failedChallenge()
	{
		character.challenges.trollChallenge.challengeTime.reset();
		character.challenges.trollChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		resetTrolls();
		resetCounter();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showChallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public bool unlocked()
	{
		return character.achievements.achievementComplete[129];
	}

	public void lockedMessage()
	{
		message = "This challenge is Locked!";
	}

	public long expectedEXP()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return baseExpReward;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return baseExpReward * 10;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return baseExpReward * 100;
		}
		return baseExpReward;
	}

	public string expectedAPReward()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return character.checkAPAdded(baseAPReward).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return character.checkAPAdded(baseAPReward / 5).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return character.checkAPAdded(baseAPReward / 5).ToString("###,##0");
		}
		return character.checkAPAdded(baseAPReward * (completions() + 1)).ToString("###,##0");
	}

	public void showChallengeInfo()
	{
		message = "<b>Troll Challenge</b>\n\n<b>Recommended Stats:</b> Patience for the BS I'm about to subject you to.\n\n<b>Description:</b> You will fight me, 4G, as you climb up the bosses. Every so often I'm gonna mess with you in some way. Maybe I wipe all your augment progress. Maybe I disable Wandoos. Maybe I spam you with popups. But whatever I do, it'll be bad.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.trollChallenge.bestTime) + "\n\n<b>Restrictions:</b> Any shreds of sanity you have must be left at the door. Also, offline progress is disabled for this challenge.\n\n<b>Challenge Unlock Condition:</b> Defeat Grand Corrupted Tree!\n\n<b>What Top Critics Say About the Troll Challenge:</b>\n\"It feels like you are trying to bail out a sinking ship with a toy pail with land in sight and the sharks are circling\"\n\n\"I F$#%ing hate you\"\n\n\"IF I SEE THAT GODDAMN CAT ONE MORE TIME I'M GONNA SCREAM.\"\n\n\"Hour three of troll challenge and ready to strangle a game dev.\"";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "Completion 1: 3x speed boost to Magic NGU!\nCompletion 2: A new accessory slot! *VERY GOOD THING*\nCompletion 3: Yggdrasil fruits can be upgraded to a max tier of 24!\nCompletion 4: A new beard slot! *ALSO VERY GOOD*\nCompletion 5: A new fruit: The Fruit of Numbers!\nCompletion 6: A new Blood Magic Ritual!\nCompletion 7: The Golden Beard!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Completion 1: An extra Accessory slot!\nCompletion 2: An extra MacGuffin slot!\nCompletion 3: An extra Daycare slot!\nCompletion 4: Unlock the Dual Wielding Wish!\nCompletion 5: +25% Hack Speed!\nCompletion 6: Unlock Improved Dual Wielding!\nCompletion 7: Unlock a Wish Slot!";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return "Completion 1: x3 Energy NGu Speed!\nCompletion 2: More Idle MacGuffins! (oooh)\nCompletion 5:+10% Card Generation Speed\nCompletion 6: +10% Mayo Generation Speed!\nCompletion 7: Unlock an Accessory Slot! Yes, I am a bastard.";
		}
		return "Additional special rewards will be added over time!";
	}

	public void updateTroll()
	{
		if (character.challenges.trollChallenge.inChallenge)
		{
			character.challenges.trollCounter++;
			int trollCounter = character.challenges.trollCounter;
			if (trollCounter % (trollFactor() * 5) == 0)
			{
				doBigTroll();
			}
			else if (trollCounter % trollFactor() == 0)
			{
				doSmallTroll();
			}
		}
	}

	public string timeToNextTroll()
	{
		int num = trollFactor() - character.challenges.trollCounter % trollFactor();
		int num2 = trollFactor() * 5 - character.challenges.trollCounter % (trollFactor() * 5);
		string text = NumberOutput.timeOutput(num);
		if (num == num2)
		{
			text += " (BIG TROLL)";
		}
		return text;
	}

	public int trollFactor()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			switch (completions())
			{
			case 0:
				return 120;
			case 1:
				return 110;
			case 2:
				return 100;
			case 3:
				return 90;
			case 4:
				return 85;
			case 5:
				return 80;
			case 6:
				return 75;
			default:
				return 75;
			}
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			switch (evilCompletions())
			{
			case 0:
				return 120;
			case 1:
				return 110;
			case 2:
				return 100;
			case 3:
				return 90;
			case 4:
				return 85;
			case 5:
				return 80;
			case 6:
				return 75;
			default:
				return 75;
			}
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			switch (sadisticCompletions())
			{
			case 0:
				return 120;
			case 1:
				return 110;
			case 2:
				return 100;
			case 3:
				return 90;
			case 4:
				return 85;
			case 5:
				return 80;
			case 6:
				return 75;
			default:
				return 75;
			}
		}
		switch (completions())
		{
		case 0:
			return 120;
		case 1:
			return 110;
		case 2:
			return 100;
		case 3:
			return 90;
		case 4:
			return 85;
		case 5:
			return 80;
		case 6:
			return 75;
		default:
			return 75;
		}
	}

	public void doBigTroll()
	{
		switch (Random.Range(1, 7))
		{
		case 0:
			disableEquipment();
			break;
		case 1:
			disableNGU();
			break;
		case 2:
			if (character.settings.beardsOn)
			{
				disableBeards();
			}
			else
			{
				doBigTroll();
			}
			break;
		case 3:
			trollMenus();
			break;
		case 4:
			multiTroll();
			break;
		case 5:
			disableWandoos();
			break;
		case 6:
			if (character.challenges.trollDivided)
			{
				doBigTroll();
			}
			else
			{
				divideBossMulti();
			}
			break;
		}
	}

	public void doSmallTroll()
	{
		switch (Random.Range(1, 10))
		{
		case 1:
			if (character.bossID < 17)
			{
				doSmallTroll();
			}
			else
			{
				halfAugs();
			}
			break;
		case 2:
			if (character.bossID < 37)
			{
				doSmallTroll();
			}
			else
			{
				loseBlood();
			}
			break;
		case 3:
			if (character.bossID < 30)
			{
				doSmallTroll();
			}
			else
			{
				wipeTimeMachine();
			}
			break;
		case 4:
			wipeGold();
			break;
		case 5:
			trollBox();
			break;
		case 6:
			wipeEnergy();
			break;
		case 7:
			wipeMagic();
			break;
		case 8:
			if (!character.settings.wandoos98On)
			{
				doSmallTroll();
			}
			else
			{
				wipeWandoos();
			}
			break;
		case 9:
			trollKittyOn();
			break;
		}
	}

	public void halfAugs()
	{
		character.augmentsController.halfAugs();
		box.displayBox("Sorry, I just lost half your augment and upgrade levels!", "HURR", "DURR", actionExit, actionExit);
	}

	public void loseBlood()
	{
		character.bloodMagicController.loseBlood();
		character.bloodMagic.rebirthPower = 1.0;
		box.displayBox("Whoops, I lost all of your blood... AND reduced your blood magic rebirth multi back to 1! Get rekt nerd.", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeTimeMachine()
	{
		character.timeMachineController.wipeTimeMachine();
		character.allDiggers.clearAllActiveDiggers();
		box.displayBox("Crap, there goes your time machine! PS: I also turned off your diggers.", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeBeards()
	{
		character.allBeards.wipeTempBeards();
		character.allDiggers.clearAllActiveDiggers();
		box.displayBox("Welp, there goes your beards! PS: I also turned off your diggers.", "HURR", "DURR", actionExit, actionExit);
	}

	public void disableNGU()
	{
		character.NGU.disabled = true;
		character.allDiggers.clearAllActiveDiggers();
		box.displayBox("I just broke your NGU's you stupid moron! They're giving you no bonuses until you rebirth! PS: I also turned off your diggers.", "HURR", "DURR", actionExit, actionExit);
	}

	public void disableBeards()
	{
		character.beards.disabled = true;
		character.allDiggers.clearAllActiveDiggers();
		box.displayBox("I just broke your Beards you stupid moron! They're giving you no bonuses until you rebirth! PS: I also turned off your diggers.", "HURR", "DURR", actionExit, actionExit);
	}

	public void disableEquipment()
	{
		character.removeAllEnergyAndMagic();
		character.inventory.disabled = true;
		character.inventoryController.updateBonuses();
		box.displayBox("Goodbye equipment! No equipment bonuses until you rebirth! Oh, and I also yanked your energy and magic out of everything, loser.", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeGold()
	{
		character.realGold = 0.0;
		box.displayBox("Hey I just stole your gold thanks bye.", "HURR", "DURR", actionExit, actionExit);
	}

	public void multiTroll()
	{
		wipeGold();
		wipeTimeMachine();
		halfAugs();
		loseBlood();
		wipeEnergyMagic();
		wipeWandoos();
		box.displayBox("I basically ruined everything just now :)", "HURR", "DURR", actionExit, actionExit);
	}

	public void trollMenus()
	{
		character.challenges.trollMenuSwap = true;
		box.displayBox("75% chance you navigate to a random menu now, until you rebirth. You're welcome <3", "HURR", "DURR", actionExit, actionExit);
	}

	public void trollBox()
	{
		boxCounter = 0;
		switcherooBox = Random.Range(1, 49);
		displayBox();
	}

	public void displayBox()
	{
		boxCounter++;
		if (boxCounter == 50)
		{
			boxCounter = 0;
			box.displayBox(((character.platform == platform.Kong) ? "KONGLATURATION" : "CONGLATURATION") + ", YOU'RE WINNER!", "OH BOY!", "YAY!", actionExit, actionExit);
		}
		else if (boxCounter == switcherooBox)
		{
			box.displayBox("HOPE YOU LOVE CLOSING THESE BOXES, YOU'VE GOT " + (50 - boxCounter) + " MORE OF THEM!", "REPEAT", "OK", trollBox2, action);
		}
		else
		{
			box.displayBox("HOPE YOU LOVE CLOSING THESE BOXES, YOU'VE GOT " + (50 - boxCounter) + " MORE OF THEM", "OK", "DURR", action, noAdvance);
		}
	}

	public void displayBoxNoAdvance()
	{
		if (boxCounter == 50)
		{
			boxCounter = 0;
			box.displayBox("CONGLATURATION, YOU'RE WINNER!", "OH BOY!", "YAY!", actionExit, actionExit);
		}
		else if (boxCounter == switcherooBox)
		{
			box.displayBox("HOPE YOU LOVE CLOSING THESE BOXES, YOU'VE GOT " + (50 - boxCounter) + " MORE OF THEM!", "REPEAT", "OK", trollBox2, action);
		}
		else
		{
			box.displayBox("HOPE YOU LOVE CLOSING THESE BOXES, YOU'VE GOT " + (50 - boxCounter) + " MORE OF THEM", "OK", "DURR", action, noAdvance);
		}
	}

	public void divideBossMulti()
	{
		if (character.bossMulti > (double)(float)(completions() + 2))
		{
			character.bossMulti /= (float)(completions() + 2);
		}
		box.displayBox("I just divided your boss multiplier by " + (completions() + 2) + ". you're welcome :3", "HURR", "DURR", actionExit, actionExit);
		character.challenges.trollDivided = true;
	}

	public void wipeEnergy()
	{
		character.removeAllEnergy();
		character.idleEnergy = 0L;
		character.curEnergy = 0L;
		box.displayBox("You didn't need all that Energy right?", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeMagic()
	{
		character.removeAllMagic();
		character.magic.idleMagic = 0L;
		character.magic.curMagic = 0L;
		box.displayBox("You didn't need all that Magic right?", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeEnergyMagic()
	{
		character.removeAllEnergyAndMagic();
		character.idleEnergy = 0L;
		character.curEnergy = 0L;
		character.magic.idleMagic = 0L;
		character.magic.curMagic = 0L;
		box.displayBox("You didn't need all that Energy or Magic right?", "HURR", "DURR", actionExit, actionExit);
	}

	public void wipeWandoos()
	{
		character.wandoos98.energyLevel = 0L;
		character.wandoos98.magicLevel = 0L;
		box.displayBox("Oh no, Wandoos just crashed and lost all levels! who could have seen that coming, the horror, etc...", "HURR", "DURR", actionExit, actionExit);
	}

	public void disableWandoos()
	{
		character.wandoos98.disabled = true;
		box.displayBox("Welp, Wandoos just blue-screened. No more wandoos bonus for you until you rebirth!", "HURR", "DURR", actionExit, actionExit);
	}

	public void trollKittyOn()
	{
		kitty.transform.SetAsLastSibling();
		kitty.color = Color.white;
		kitty.gameObject.transform.localPosition = new Vector3(0f, -550f);
		box.displayBox("I drew a kitty for you, I hope you like it c:", "HURR", "DURR", actionExit, actionExit);
	}

	public void trollKittyOff()
	{
		kitty.transform.SetAsFirstSibling();
		kitty.color = Color.clear;
	}
}
