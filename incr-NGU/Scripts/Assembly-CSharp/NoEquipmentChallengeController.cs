using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoEquipmentChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public Text challengeInfo;

	public Button challengeButton;

	public Text challengeButtonText;

	public AllChallengesController allChallenges;

	private string message;

	public int baseExpReward;

	public int maxCompletions;

	public int baseAPReward;

	private void Update()
	{
		updateButton();
		if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			character.challenges.noEquipmentChallenge.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "No Equipment Challenge";
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
			challengeButton.GetComponentInChildren<Text>().text = "Challenge Locked";
		}
	}

	public bool unlocked()
	{
		return character.inventory.itemList.receivedGRBSet();
	}

	public int targetBoss()
	{
		return 65;
	}

	public void complete()
	{
		int timeAsHighscore = character.challenges.noEquipmentChallenge.challengeTime.getTimeAsHighscore();
		long num = 0L;
		long num2 = 0L;
		if (timeAsHighscore < character.challenges.noEquipmentChallenge.bestTime)
		{
			character.challenges.noEquipmentChallenge.bestTime = timeAsHighscore;
		}
		character.purchases.hasAutoBoost = true;
		character.challenges.noEquipmentChallenge.challengeTime.reset();
		character.challenges.noEquipmentChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.noEquipmentChallenge.curCompletions++;
			if (character.challenges.noEquipmentChallenge.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (completions() == 1)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also just unlocked AUTO BOOST, and reduced Auto Boost and Merge times by 10%, and gained 8 inventory slots!";
			}
			else if (completions() < maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! Auto Boost and Merge times are also reduced by 10%, and you've been awarded 8 inventory spaces!!";
			}
			else if (character.challenges.noEquipmentChallenge.curCompletions == maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! Auto Boost and Merge times are also reduced by 10%, and you've been awarded 8 inventory slots! Since this is your final challenge completion, you've also been awarded a bonus <b>10</b> inventory spaces! ";
			}
			else
			{
				message = "You completed a No Equipment Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.noEquipmentChallenge.curEvilCompletions++;
			if (character.challenges.noEquipmentChallenge.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (evilCompletions() == 1)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You also gained 3 inventory spaces!";
			}
			else if (evilCompletions() < maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You also gained 3 inventory spaces!";
			}
			else if (character.challenges.noEquipmentChallenge.curEvilCompletions == maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You also gained a MacGuffin Slot, and 12 extra inventory spaces!!";
				character.inventoryController.updateMacguffinCount();
			}
			else
			{
				message = "You completed a No Equipment Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.noEquipmentChallenge.curSadisticCompletions++;
			if (character.challenges.noEquipmentChallenge.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (sadisticCompletions() == 1)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! ";
			}
			else if (sadisticCompletions() < maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! ";
			}
			else if (character.challenges.noEquipmentChallenge.curSadisticCompletions == maxCompletions)
			{
				message = "You completed a No Equipment Challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! ";
			}
			else
			{
				message = "You completed a No Equipment Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 5f);
		showChallengeInfo();
		character.inventoryController.updateInvCount();
	}

	public void failedChallenge()
	{
		character.challenges.noEquipmentChallenge.challengeTime.reset();
		character.challenges.noEquipmentChallenge.inChallenge = false;
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
		message = "<b>No Equipment Challenge</b>\n\n<b>Recommended Stats:</b> Not sure, but if I were you I'd get a lot of Energy Power and Magic Power.\n\n<b>Description:</b> Equipment helps you do everything better, so Let's take that away from you. Also your NUMBER is reverted back to 1, as usual.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + character.checkExpAdded(expectedEXP()).ToString("###,##0") + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Fastest Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.noEquipmentChallenge.bestTime) + "\n\n<b>Restrictions:</b> No Equipment Bonuses for you!\n\n<b>Challenge Unlock Condition:</b> Discover (NOT complete) every piece of the GRB set!";
		challengeInfo.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "First challenge completion will unlock AUTO BOOST. Each completion will reduce auto boost and auto merge times by 10%, and you'll also earn 8 inventory slots. Final completion will earn you a bonus 10 inventory slots!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return " Each completion grants +3 inventory spaces. Final completion grants a bonus MacGuffin Slot, and 12 inventory spaces total!";
		}
		if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			return " Each completion grants 2% stronger idle attacks! Final completion grants +10% Stronger idle attacks! Golly!";
		}
		return "Additional special rewards will be added over time!";
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

	public int completions()
	{
		if (character.challenges.noEquipmentChallenge.curCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noEquipmentChallenge.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.noEquipmentChallenge.curEvilCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noEquipmentChallenge.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.noEquipmentChallenge.curSadisticCompletions >= maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noEquipmentChallenge.curSadisticCompletions;
	}

	public bool maxedOut()
	{
		return character.challenges.noEquipmentChallenge.curCompletions >= maxCompletions;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showChallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
