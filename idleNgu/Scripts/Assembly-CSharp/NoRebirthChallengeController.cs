using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoRebirthChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Button challengeButton;

	public Text challengeButtonText;

	public Text challengeInfo;

	public AllChallengesController allChallenges;

	public Boss boss;

	private string message;

	public string challengeName;

	public int baseExpReward = 1000;

	public int baseAPReward;

	public int maxCompletions = 50;

	private void Start()
	{
	}

	private void Update()
	{
		updateButton();
		if (character.challenges.noRebirthChallenge.inChallenge)
		{
			character.challenges.noRebirthChallenge.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "No Rebirth Challenge";
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

	public int completions()
	{
		if (character.challenges.noRebirthChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noRebirthChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.noRebirthChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noRebirthChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.noRebirthChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noRebirthChallenge.curSadisticCompletions;
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
		return character.challenges.noRebirthChallenge.unlocked;
	}

	public int targetBoss()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return completions() * 5 + 39;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return evilCompletions() * 5 + 39;
		}
		_ = character.settings.rebirthDifficulty;
		_ = 2;
		return sadisticCompletions() * 5 + 39;
	}

	public void completeChallenge()
	{
		complete();
	}

	public void complete()
	{
		int timeAsHighscore = character.challenges.noRebirthChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.noRebirthChallenge.bestTime = timeAsHighscore;
		character.challenges.noRebirthChallenge.challengeTime.reset();
		character.challenges.noRebirthChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		character.challenges.noRebirthChallenge.highScore = character.bossID;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.noRebirthChallenge.curCompletions++;
			if (character.challenges.noRebirthChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (completions() == 1)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! For your first completion, also been awarded +1 level on any dropped Titan loot. You've also reduced the respawn timer for Jake and future Titans by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curCompletions < maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Jake and future Titans by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curCompletions == maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Jake and future Titans by 15 minutes.";
			}
			else
			{
				message = "You beat the target boss on your No Rebirth Challenge! You've already completed the maximum allowed for this challenge, so uh... that's about it. Yup.";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.noRebirthChallenge.curEvilCompletions++;
			if (character.challenges.noRebirthChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (evilCompletions() == 1)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Greasy Nerd and future Titans by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Greasy Nerd and future Titans by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Greasy Nerd and future Titans by 15 minutes.";
			}
			else
			{
				message = "You beat the target boss on your No Rebirth Challenge! You've already completed the maximum allowed for this challenge, so uh... that's about it. Yup.";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.noRebirthChallenge.curSadisticCompletions++;
			if (character.challenges.noRebirthChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (sadisticCompletions() == 1)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Titan 10 and beyond by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Titan 10 and beyond by 15 minutes.";
			}
			else if (character.challenges.noRebirthChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You beat the target boss on your No Rebirth Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also reduced the respawn timer for Titan 10 and beyond by 15 minutes.";
			}
			else
			{
				message = "You beat the target boss on your No Rebirth Challenge! You've already completed the maximum allowed for this challenge, so uh... that's about it. Yup.";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void challengeFailed()
	{
		character.challenges.noRebirthChallenge.challengeTime.reset();
		character.challenges.noRebirthChallenge.inChallenge = false;
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

	public void showchallengeInfo()
	{
		message = "<b>" + challengeName + "</b>\n\n<b>Recommended Stats:</b> Anything and everything that helps boosts your Attack and Defense directly.\n\n<b>Description:</b> Man, aren't rebirths fun?\n\nI hate fun.\n\nNO. REBIRTHS. EVER! Your NUMBER is reset to 1 and you must reach the target boss without ever rebirthing. Each successful challenge raises the target boss by 5 for the next challenge.\n\n<b>Win condition:</b> Defeat Boss " + (targetBoss() + 1) + "\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.noRebirthChallenge.bestTime) + "\n\n<b>Restrictions:</b> No Rebirthing!\n\n<b>Challenge Unlock Condition:</b> Defeat Jake From Accounting at least once! Don't know who that is? Guess you're nowhere near ready for this challenge then!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "First completion: +1 level to all dropped Titan loot.\nEvery completion: -15 minutes to Titan spawn time starting with Jake From Accounting and beyond. NOTE: Titan respawns can never be reduced below 60 minutes.";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Every completion: -15 minutes to Titan spawn time starting with Greasy Nerd and beyond.";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return "Every completion: -15 minutes to Titan spawn time starting with IT HUNGERS and beyond.";
		}
		return "More rewards may be added over time!";
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showchallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
