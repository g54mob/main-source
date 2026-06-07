using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaserSwordChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
		if (!character.challenges.laserSwordChallengeUnlocked && character.augments.augs[6].augLevel >= 1 && character.augments.augs[6].upgradeLevel >= 1)
		{
			character.challenges.laserSwordChallengeUnlocked = true;
		}
		updateButton();
		if (character.challenges.laserSwordChallenge.inChallenge)
		{
			character.challenges.laserSwordChallenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.augments.augs[6].augLevel >= laserSwordTarget() && character.augments.augs[6].upgradeLevel >= laserSwordTarget())
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
			challengeButton.GetComponentInChildren<Text>().text = "Laser Sword Challenge";
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
			challengeButton.interactable = false;
			challengeButton.image.sprite = allChallenges.normalBorder;
			challengeButton.GetComponentInChildren<Text>().text = "Challenge Locked";
		}
	}

	public int laserSwordTarget()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return completions() + 2;
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return evilCompletions() + 2;
		}
		_ = character.settings.rebirthDifficulty;
		_ = 2;
		return sadisticCompletions() + 2;
	}

	public int completions()
	{
		if (character.challenges.laserSwordChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.laserSwordChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.laserSwordChallenge.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.laserSwordChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.laserSwordChallenge.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.laserSwordChallenge.curSadisticCompletions;
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
		int timeAsHighscore = character.challenges.laserSwordChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		character.challenges.laserSwordChallenge.bestTime = timeAsHighscore;
		character.challenges.laserSwordChallenge.challengeTime.reset();
		character.challenges.laserSwordChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.laserSwordChallenge.curCompletions++;
			if (character.challenges.laserSwordChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.laserSwordChallenge.curCompletions == 1)
			{
				message = "You completed your first Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP, and improved the power bonus for augments by 0.05 * augment tier!";
			}
			else if (character.challenges.laserSwordChallenge.curCompletions < maxCompletions)
			{
				message = "You completed a Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP, and improved the power bonus for augments by 0.01 * augment tier!";
			}
			else if (character.challenges.laserSwordChallenge.curCompletions == maxCompletions)
			{
				message = "You completed your final Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP, and improved the power bonus for augments by 0.05 * augment tier!";
			}
			else
			{
				message = "You completed a Laser Sword Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.laserSwordChallenge.curEvilCompletions++;
			if (character.challenges.laserSwordChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.laserSwordChallenge.curEvilCompletions == 1)
			{
				message = "You completed your first Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.laserSwordChallenge.curEvilCompletions < maxCompletions)
			{
				message = "You completed a Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.laserSwordChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed your final Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a Laser Sword Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.laserSwordChallenge.curSadisticCompletions++;
			if (character.challenges.laserSwordChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.laserSwordChallenge.curSadisticCompletions == 1)
			{
				message = "You completed your first Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.laserSwordChallenge.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.laserSwordChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed your final Laser Sword Challenge! You've gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a Laser Sword Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 5f);
	}

	public void failedChallenge()
	{
		character.challenges.laserSwordChallenge.challengeTime.reset();
		character.challenges.laserSwordChallenge.inChallenge = false;
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
		return character.challenges.laserSwordChallengeUnlocked;
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
		message = "<b>Laser Sword Challenge</b>\n\n<b>Recommended Stats:</b> Enough to make the required level Laser Sword. Cmon, it's not that complicated.\n\n<b>Description:</b> The augment guy Jensen wants a " + laserSwordTarget() + "/" + laserSwordTarget() + " Laser Sword Augmentation. Go make him one. Do that and he'll make your augmentations kick more ass. NOTE: YOU DO NOT HAVE ANYTHING RESET IN THIS CHALLENGE! It just performs a normal rebirth!\n\n<b>Win condition:</b> Make a " + laserSwordTarget() + " / " + laserSwordTarget() + " Laser Sword. \n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Last Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.laserSwordChallenge.bestTime) + "\n\n<b>Restrictions:</b> Absolutely nothing!\n\n<b>Challenge Unlock Condition:</b> Make a 1/1 or better laser Sword!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "Each completion: Augment levels for Milk and on will be raised to a higher power! Each completion will raise the bonus by 0.01 for milk, 0.02 for cannon, and so on down to Laser Sword.\nFirst Completion: Same bonus, but increases by 0.05!\nFinal Completion: Same bonus, but increases by 0.05!";
		}
		return "Additional special rewards will be added over time!";
	}
}
