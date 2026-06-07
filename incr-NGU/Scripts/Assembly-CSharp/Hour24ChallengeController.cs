using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hour24ChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Button challengeButton;

	public Text challengeButtonText;

	public Text challengeInfo;

	public AllChallengesController allChallenges;

	public Boss boss;

	private string message;

	public int baseExpReward = 10;

	public int baseAPReward;

	public int maxCompletions = 10;

	private void Start()
	{
	}

	private void Update()
	{
		if (character.menuID == 12)
		{
			if (sadisticCompletions() >= maxCompletions)
			{
				challengeButtonText.text = "24 Hour Challenge";
				challengeButton.image.sprite = allChallenges.redBorder;
			}
			else if (evilCompletions() >= maxCompletions)
			{
				challengeButtonText.text = "24 Hour Challenge";
				challengeButton.image.sprite = allChallenges.orangeBorder;
			}
			else if (completions() >= maxCompletions)
			{
				challengeButtonText.text = "24 Hour Challenge";
				challengeButton.image.sprite = allChallenges.goldBorder;
			}
			else if (unlocked())
			{
				challengeButton.interactable = true;
				challengeButtonText.text = "24 Hour Challenge";
				challengeButton.image.sprite = allChallenges.normalBorder;
			}
			else
			{
				challengeButton.image.sprite = allChallenges.normalBorder;
				challengeButton.interactable = false;
				challengeButtonText.text = "Challenge Locked";
			}
		}
		if (character.challenges.hour24Challenge.inChallenge)
		{
			character.challenges.hour24Challenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.challenges.hour24Challenge.challengeTime.totalseconds >= 86400.0)
			{
				challengeFailed();
			}
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
			challengeButton.GetComponentInChildren<Text>().text = "24 Hour Challenge";
			if (completions() >= maxCompletions)
			{
				challengeButton.interactable = false;
				challengeButton.image.sprite = allChallenges.goldBorder;
			}
			else
			{
				challengeButton.interactable = true;
				challengeButton.image.sprite = allChallenges.normalBorder;
			}
		}
		else
		{
			challengeButton.interactable = false;
			challengeButton.GetComponentInChildren<Text>().text = "Challenge Locked";
		}
	}

	public int completions()
	{
		if (character.challenges.hour24Challenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.hour24Challenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.hour24Challenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.hour24Challenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.hour24Challenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.hour24Challenge.curSadisticCompletions;
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

	public bool unlocked()
	{
		return character.challenges.basicChallenge.bestTime < 86400;
	}

	public int targetBoss()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return Math.Min(299, completions() * 26 + 57);
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return Math.Min(299, evilCompletions() * 26 + 57);
		}
		_ = character.settings.rebirthDifficulty;
		_ = 2;
		return Math.Min(299, sadisticCompletions() * 26 + 57);
	}

	public void complete()
	{
		int timeAsHighscore = character.challenges.hour24Challenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.hour24Challenge.bestTime = timeAsHighscore;
		character.challenges.hour24Challenge.challengeTime.reset();
		character.challenges.hour24Challenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		character.challenges.hour24Challenge.highScore = character.bossID;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.hour24Challenge.curCompletions++;
			if (character.challenges.hour24Challenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * completions());
				num2 = character.addAP(baseAPReward * completions());
			}
			if (completions() == 1)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP! You also gained +1 EXP gained for all boss kills which grant EXP!";
			}
			else if (character.challenges.hour24Challenge.curCompletions <= maxCompletions)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +10% EXP gained for all boss and titan kills!";
			}
			else
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge, but you already exceeded the cap so I can't award you any EXP or AP :c";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.hour24Challenge.curEvilCompletions++;
			if (character.challenges.hour24Challenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * evilCompletions() * 10);
				num2 = character.addAP(baseAPReward * evilCompletions() / 5);
			}
			if (evilCompletions() == 1)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.hour24Challenge.curCompletions <= maxCompletions)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +4% EXP gained for all boss and titan kills!";
			}
			else
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge, but you already exceeded the cap so I can't award you any EXP or AP :c";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.hour24Challenge.curSadisticCompletions++;
			if (character.challenges.hour24Challenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * sadisticCompletions() * 100);
				num2 = character.addAP(baseAPReward * sadisticCompletions() / 5);
			}
			if (sadisticCompletions() == 1)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.hour24Challenge.curCompletions <= maxCompletions)
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge! You've been awarded " + num.ToString("###,##0") + " EXP! and " + num2.ToString("###,##0") + " AP! You also gained +2% EXP gained for all boss and titan kills!";
			}
			else
			{
				message = "You beat the target boss on your 24 Hour Boss Challenge, but you already exceeded the cap so I can't award you any EXP or AP :c";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void challengeFailed()
	{
		character.challenges.hour24Challenge.challengeTime.reset();
		character.challenges.hour24Challenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		message = "Sorry, time's run out and you didn't beat the target boss. Better luck next time!";
		tooltip.showTooltip(message, 3f);
	}

	public void showchallengeInfo()
	{
		message = "<b>24 Hour Challenge</b>\n\n<b>Recommended Stats:</b> The more the better! \n\n<b>Description:</b> Your NUMBER is reset to 1, and you have 24 hours of in-game time to reach the target Boss! Each successful challenge raises the target boss for the next challenge.\n\n<b>Win condition:</b> Defeat Boss " + (targetBoss() + 1) + "\n\n<b>Reward:</b>\n" + expectedExpReward() + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.hour24Challenge.bestTime) + "\n\n<b>Restrictions:</b> Offline Progress will be disabled during this challenge. But, the timer won't run either. Consider it a good thing!\n\n<b>Challenge Unlock Condition:</b> Complete a Basic Challenge in under 24 hours!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "First completion: +1 EXP whenever you defeat boss 24 or higher.\nEvery completion: +10 % EXP whenever you defeat boss 24 or higher(rounded down). This bonus also applies to Titans.\nThis challenge can be FAILED.Failure gives you nothing except shame.";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Every completion: +4 % EXP whenever you defeat boss 24 or higher(rounded down). This bonus also applies to Titans.\nThis challenge can be FAILED.Failure gives you nothing except shame.";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return "Every completion: +2 % EXP whenever you defeat boss 24 or higher(rounded down). This bonus also applies to Titans.\nThis challenge can be FAILED.Failure gives you nothing except shame.";
		}
		return "Additional special rewards may be added over time!";
	}

	public string expectedExpReward()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return character.checkExpAdded(baseExpReward * (completions() + 1)).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return character.checkExpAdded(baseExpReward * (evilCompletions() + 1) * 10).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return character.checkExpAdded(baseExpReward * (sadisticCompletions() + 1) * 100).ToString("###,##0");
		}
		return character.checkExpAdded(baseExpReward * (completions() + 1)).ToString("###,##0");
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
			return character.checkAPAdded(baseAPReward * (completions() + 1)).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return character.checkAPAdded(baseAPReward * (evilCompletions() + 1) / 5).ToString("###,##0");
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return character.checkAPAdded(baseAPReward * (sadisticCompletions() + 1) / 5).ToString("###,##0");
		}
		return character.checkAPAdded(baseAPReward * (completions() + 1)).ToString("###,##0");
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showchallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
