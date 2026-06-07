using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlindChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public AllChallengesController allChallenges;

	public Button challengeButton;

	public Text challengeInfo;

	private string message;

	public int baseExpReward;

	public int baseAPReward;

	public int maxCompletions;

	private void Update()
	{
		updateButton();
		if (character.challenges.blindChallenge.inChallenge)
		{
			character.challenges.blindChallenge.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "Blind Challenge";
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
			return 57 + completions() * 10;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return 57 + evilCompletions() * 10;
		}
		_ = character.settings.rebirthDifficulty;
		_ = 2;
		return 57 + sadisticCompletions() * 10;
	}

	public int completions()
	{
		if (character.challenges.blindChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.blindChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.blindChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.blindChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.blindChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.blindChallenge.curSadisticCompletions;
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

	private void complete()
	{
		int timeAsHighscore = character.challenges.blindChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.blindChallenge.bestTime = timeAsHighscore;
		character.challenges.blindChallenge.challengeTime.reset();
		character.challenges.blindChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.blindChallenge.curCompletions++;
			if (character.challenges.blindChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.blindChallenge.curCompletions == 1)
			{
				message = "You completed your first Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! Daycare items will now take 5% less time per levelup!";
			}
			else if (character.challenges.blindChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! Daycare items will now take 1% less time per levelup!";
			}
			else if (character.challenges.blindChallenge.curCompletions == maxCompletions)
			{
				message = "You completed your final Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also unlocked a new daycare slot!";
			}
			else
			{
				message = "You completed a Blind Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.blindChallenge.curEvilCompletions++;
			if (character.challenges.blindChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.blindChallenge.curEvilCompletions == 1)
			{
				message = "You completed your first Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus 2% to Daycare Speed!";
			}
			else if (character.challenges.blindChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus 2% to Daycare Speed!";
			}
			else if (character.challenges.blindChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed your final Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a Blind Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.blindChallenge.curSadisticCompletions++;
			if (character.challenges.blindChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.blindChallenge.curSadisticCompletions == 1)
			{
				message = "You completed your first Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.blindChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus 1% to Daycare Speed!";
			}
			else if (character.challenges.blindChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed your final Blind Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a Blind Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		character.inventoryController.updateDaycareCount();
		tooltip.showTooltip(message, 5f);
	}

	public void failedChallenge()
	{
		character.challenges.blindChallenge.challengeTime.reset();
		character.challenges.blindChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
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
		if (!character.challenges.blindChallengeUnlocked)
		{
			return character.inventory.itemList.itemDropped[141];
		}
		return true;
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
		message = "<b>Blind Challenge</b>\n\n<b>Recommended Stats:</b> A good memory and being able to do some mental math!\n\n<b>Description:</b> You will revert back to a NUMBER of 1, and make the climb back up to the target boss. But, oh no! Most of the of numbers displayed in the game are invisible now! Are you properly training? Did you set up your augs correctly? Are you even rebirthing to a higher or lower NUMBER? Better hope you can remember.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + "). The boss # will increase by 10 for each completion.\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.blindChallenge.bestTime) + "\n\n<b>Restrictions:</b> Nothing is restricted, you're just blind as a bat!\n\n<b>Challenge Unlock Condition:</b> Defeat UUG the Unmentionable!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "Each completion: Items will take 1 % less time to level up in the daycare!\nFirst Completion:Items will take a bonus 5 % less time to level up in the daycare!\nFinal Completion: An extra daycare slot is unlocked!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Each completion: Daycare Speed increases by 2%!\n";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return "Each completion: Daycare Speed increases by 1%!\n";
		}
		return "Additional special rewards will be added over time!";
	}
}
