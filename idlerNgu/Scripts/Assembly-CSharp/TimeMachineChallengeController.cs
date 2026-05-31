using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeMachineChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
		if (character.challenges.timeMachineChallenge.inChallenge)
		{
			character.challenges.timeMachineChallenge.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "No TM Challenge";
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
			return 57 + completions() * 15;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return 57 + evilCompletions() * 15;
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return 57 + sadisticCompletions() * 15;
		}
		return 57 + completions() * 15;
	}

	public int completions()
	{
		if (character.challenges.timeMachineChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.timeMachineChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.timeMachineChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.timeMachineChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.timeMachineChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.timeMachineChallenge.curSadisticCompletions;
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
		int timeAsHighscore = character.challenges.timeMachineChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.timeMachineChallenge.bestTime = timeAsHighscore;
		character.challenges.timeMachineChallenge.challengeTime.reset();
		character.challenges.timeMachineChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.timeMachineChallenge.curCompletions++;
			if (character.challenges.timeMachineChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.timeMachineChallenge.curCompletions == 1)
			{
				message = "You completed your first No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus +100% GPS, and a bonus +5% to your Total Digger Level Bonus!!";
			}
			else if (character.challenges.timeMachineChallenge.curCompletions == 5)
			{
				message = "You completed your FIFTH No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus +100% GPS, and a free Gold Digger slot!!";
			}
			else if (character.challenges.timeMachineChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.timeMachineChallenge.curCompletions == maxCompletions)
			{
				message = "You completed your final No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No Time Machine Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.timeMachineChallenge.curEvilCompletions++;
			if (character.challenges.timeMachineChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.timeMachineChallenge.curEvilCompletions == 1)
			{
				message = "You completed your first No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained a bonus +100% to your Gold Drops!";
			}
			else if (character.challenges.timeMachineChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +10% to Time Machine Levelling Speed!";
			}
			else if (character.challenges.timeMachineChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed your final No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No Time Machine Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.timeMachineChallenge.curSadisticCompletions++;
			if (character.challenges.timeMachineChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.timeMachineChallenge.curSadisticCompletions == 1)
			{
				message = "You completed your first No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.timeMachineChallenge.curSadisticCompletions == 5)
			{
				message = "You completed your FIFTH No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.timeMachineChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.timeMachineChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed your final No Time Machine Challenge! You've gained " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a No Time Machine Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void failedChallenge()
	{
		character.challenges.timeMachineChallenge.challengeTime.reset();
		character.challenges.timeMachineChallenge.inChallenge = false;
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
		return character.settings.diggersOn;
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
		message = "<b>No Time Machine Challenge</b>\n\n<b>Recommended Stats:</b> High adventure stats, high gold drop bonuses, anything that lets you make gold without the Time Machine!\n\n<b>Description:</b> You're now poor. Good luck!\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + "). The boss # will increase by 15 for each completion.\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.timeMachineChallenge.bestTime) + "\n\n<b>Restrictions:</b> The Time Machine provides no GPS for you!\n\n<b>Challenge Unlock Condition:</b> Unlock Gold Diggers!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return " First Completion: +5% bonuses to all active diggers!\nEach completion: + 100% to your GPS!\n5th Completion: An extra digger slot!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return " First Completion: +100% Gold Drop!\nEach completion: 10% TM Speed Bonus.";
		}
		return "Additional special rewards will be added over time!";
	}

	public double totalGPSbonus()
	{
		return 1.0 + (double)character.allChallenges.timeMachineChallenge.completions() * 1.0;
	}

	public float TMSpeedBonus()
	{
		return 1f + (float)character.allChallenges.timeMachineChallenge.evilCompletions() * 0.1f;
	}
}
