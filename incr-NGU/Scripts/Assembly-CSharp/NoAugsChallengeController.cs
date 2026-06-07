using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoAugsChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
		if (character.challenges.noAugsChallenge.inChallenge)
		{
			character.challenges.noAugsChallenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.bossID > targetBoss())
			{
				complete();
			}
		}
	}

	public void updateButton()
	{
		if (unlocked())
		{
			challengeButton.interactable = true;
			challengeButton.GetComponentInChildren<Text>().text = "No Augs Challenge";
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
		return 58;
	}

	public int completions()
	{
		if (character.challenges.noAugsChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noAugsChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.noAugsChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noAugsChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.noAugsChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noAugsChallenge.curSadisticCompletions;
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

	public void complete()
	{
		int timeAsHighscore = character.challenges.noAugsChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		if (timeAsHighscore < character.challenges.noAugsChallenge.bestTime)
		{
			character.challenges.noAugsChallenge.bestTime = timeAsHighscore;
		}
		character.challenges.noAugsChallenge.challengeTime.reset();
		character.challenges.noAugsChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.noAugsChallenge.curCompletions++;
			if (character.challenges.noAugsChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.noAugsChallenge.curCompletions == 1)
			{
				message = "You completed your first No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained +10% leveling speed to Augments!";
			}
			else if (character.challenges.noAugsChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP, " + num2.ToString("###,##0") + " AP, and +25% to Total Augment Power!";
			}
			else if (character.challenges.noAugsChallenge.curCompletions == maxCompletions)
			{
				message = "You completed your final No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP, " + num2.ToString("###,##0") + " AP, and +5% to Total Augment Power! You also reduced costs of all augmentations by 50%!";
			}
			else
			{
				message = "You completed a No Augmentations Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back! I'll still give you the exp reward.";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.noAugsChallenge.curEvilCompletions++;
			if (character.challenges.noAugsChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.noAugsChallenge.curEvilCompletions == 1)
			{
				message = "You completed your first No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.noAugsChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.noAugsChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed your final No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No Augmentations Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back! I'll still give you the exp reward.";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.noAugsChallenge.curSadisticCompletions++;
			if (character.challenges.noAugsChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.noAugsChallenge.curSadisticCompletions == 1)
			{
				message = "You completed your first No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.noAugsChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP, " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.noAugsChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed your final No Augmentations Challenge! You've gained " + num.ToString("###,##0") + " EXP, " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No Augmentations Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back! I'll still give you the exp reward.";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void failedChallenge()
	{
		character.challenges.noAugsChallenge.challengeTime.reset();
		character.challenges.noAugsChallenge.inChallenge = false;
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
		return character.highestBoss >= 75;
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
		message = "<b>No Augs Challenge</b>\n\n<b>Recommended Stats:</b> A decently high OS level for Wandoos as a backup for having no augments can help!\n\n<b>Description:</b> No augs for you! Revert to a NUMBER of 1, and work your way back up as usual. However, the augmentation feature is entirely off-limits for the duration of this challenge!\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Fastest Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.noAugsChallenge.bestTime) + "\n\n<b>Restrictions:</b> The augmentations menu will be locked until you complete this challenge! Otherwise, everything else is available.\n\n<b>Challenge Unlock Condition:</b> Defeat boss 75!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "First completion: +10 % Augment leveling speed.\nEvery completion: +25 % to Total Augment Power.\nFinal completion: Reduces augmentation and upgrade costs by 50 %.";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Each completion gives +5% Augmentation levelling Speed! Final Completion grants an extra 25% speed! ";
		}
		return "Additional rewards will be added over time!";
	}
}
