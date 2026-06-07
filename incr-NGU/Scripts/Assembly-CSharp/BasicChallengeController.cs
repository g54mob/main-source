using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasicChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public Text challengeInfo;

	public AllChallengesController allChallenges;

	private string message;

	public Button challengeButton;

	public int baseExpReward;

	public int maxCompletions;

	public int baseAPReward;

	private void Update()
	{
		updateButton();
		if (character.challenges.basicChallenge.inChallenge)
		{
			character.challenges.basicChallenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.bossID > targetBoss())
			{
				complete();
			}
		}
	}

	public void updateButton()
	{
		if (character.menuID == 12)
		{
			challengeButton.interactable = true;
			challengeButton.GetComponentInChildren<Text>().text = "Basic Challenge";
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
	}

	public bool unlocked()
	{
		return true;
	}

	public int targetBoss()
	{
		return 57;
	}

	public void complete()
	{
		int timeAsHighscore = character.challenges.basicChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		if (timeAsHighscore < character.challenges.basicChallenge.bestTime)
		{
			character.challenges.basicChallenge.bestTime = timeAsHighscore;
		}
		character.challenges.basicChallenge.challengeTime.reset();
		character.challenges.basicChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		character.challenges.basicChallenge.curCompletions++;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			if (character.challenges.basicChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.basicChallenge.curCompletions == 1)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! For your first completion you've also gained +10% Boost recycling, and 10% to all adventure stats!";
			}
			else if (character.challenges.basicChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! You also gained +10% Boost recycling and +5% to all adventure stats!";
			}
			else if (character.challenges.basicChallenge.curCompletions == maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! You also gained +10% Boost recycling and +5% to all adventure stats! You've also unlocked the <b>PARALYZE</b> skill for your final Basic challenge completed, bravo!";
			}
			else
			{
				message = "You completed a Basic Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.basicChallenge.curEvilCompletions++;
			if (character.challenges.basicChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.basicChallenge.curEvilCompletions == 1)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! You've also gained +10% to your Adventure stats!";
			}
			else if (character.challenges.basicChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! You've also gained +10% to your Adventure stats!";
			}
			else if (character.challenges.basicChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP!";
			}
			else
			{
				message = "You completed a Basic Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.basicChallenge.curSadisticCompletions++;
			if (character.challenges.basicChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.basicChallenge.curSadisticCompletions == 1)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! And here, take this mayo packet I found in my couch (1 Each).";
				character.cardsController.awardSomeMayoIGuess(1, 1, 1, 1, 1, 1);
			}
			else if (character.challenges.basicChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! And here, take this mayo packet I found in my couch (1 Each).";
				character.cardsController.awardSomeMayoIGuess(1, 1, 1, 1, 1, 1);
			}
			else if (character.challenges.basicChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed a Basic Challenge! You've gained " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + "AP! I also emptied some spare mayo I had into your pockets (5 Each!)";
				character.cardsController.awardSomeMayoIGuess(5, 5, 5, 5, 5, 5);
			}
			else
			{
				message = "You completed a Basic Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 5f);
		showChallengeInfo();
	}

	public void failedChallenge()
	{
		character.challenges.basicChallenge.challengeTime.reset();
		character.challenges.basicChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
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
		message = "<b>Basic Challenge</b>\n\n<b>Recommended Stats:</b> None!\n\n<b>Description:</b> A simple, basic challenge. Lose all of your Attack and Defense, and revert your NUMBER back to 1 and work your way from boss 1 back up to boss 58! NOTE: this loss of NUMBER is permanent, but you'll regain NUMBER a lot faster than it took to get here in the first place, I promise.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Fastest Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.basicChallenge.bestTime) + "\n\n<b>Restrictions:</b> None! You can rebirth all you want, and do anything you can do! I'm so merciful.";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "Each completion will raise your boost recycle chance by 10%, and you'll gain + 5% to all adventure stats.First challenge completion will also reward you with +10 % to all adventure stats! Final challenge completion will unlock the <b>PARALYZE</b> skill!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Each completion will increase your adventure stats by 10%!";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return "Each completion will award you with some MAYO! Yay!";
		}
		return "";
	}

	public int completions()
	{
		if (character.challenges.basicChallenge.curCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.basicChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.basicChallenge.curEvilCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.basicChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.basicChallenge.curSadisticCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.basicChallenge.curSadisticCompletions;
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

	public bool maxedOut()
	{
		return character.challenges.basicChallenge.curCompletions >= maxCompletions;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showChallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
