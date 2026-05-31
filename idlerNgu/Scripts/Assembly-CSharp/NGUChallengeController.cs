using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NGUChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
		if (character.challenges.nguChallenge.inChallenge)
		{
			character.challenges.nguChallenge.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "No NGU Challenge";
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
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return 57 + sadisticCompletions() * 10;
		}
		return 57 + completions() * 10;
	}

	public int completions()
	{
		if (character.challenges.nguChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.nguChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.nguChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.nguChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.nguChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.nguChallenge.curSadisticCompletions;
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
		int timeAsHighscore = character.challenges.nguChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.nguChallenge.bestTime = timeAsHighscore;
		character.challenges.nguChallenge.challengeTime.reset();
		character.challenges.nguChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		character.NGU.disabled = false;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.nguChallenge.curCompletions++;
			if (character.challenges.nguChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.nguChallenge.curCompletions == 1)
			{
				message = "You completed your first No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus 5% NGU speed!";
			}
			else if (character.challenges.nguChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.nguChallenge.curCompletions == maxCompletions)
			{
				message = "You completed your final No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No NGU Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.nguChallenge.curEvilCompletions++;
			if (character.challenges.nguChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.nguChallenge.curEvilCompletions == 1)
			{
				message = "You completed your first No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +20% Hack Speed!";
			}
			else if (character.challenges.nguChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +20% Hack Speed!";
			}
			else if (character.challenges.nguChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed your final No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +20% Hack Speed!";
			}
			else
			{
				message = "You completed a No NGU Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.nguChallenge.curSadisticCompletions++;
			if (character.challenges.nguChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.nguChallenge.curSadisticCompletions == 1)
			{
				message = "You completed your first No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.nguChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.nguChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed your final No NGU Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No NGU Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void failedChallenge()
	{
		character.challenges.nguChallenge.challengeTime.reset();
		character.challenges.nguChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.NGU.disabled = false;
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
		return character.NGUController.nguChallengeUnlocked();
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
		message = "<b>NGU Challenge</b>\n\n<b>Recommended Stats:</b> Everything that isn't NGU!\n\n<b>Description:</b> Those NGU's sure are powerful! Let's see how well you do without them.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + "). The boss # will increase by 10 for each completion.\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.nguChallenge.bestTime) + "\n\n<b>Restrictions:</b> NGU's provide absolutely no bonuses!\n\n<b>Challenge Unlock Condition:</b> Obtain >10000 levels total through all your NGU's!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "Each completion: 5% faster NGUs!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Each completion: 20% faster Hacks!";
		}
		return "Additional special rewards will be added over time!";
	}
}
