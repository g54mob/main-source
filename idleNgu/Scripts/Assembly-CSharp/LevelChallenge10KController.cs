using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelChallenge10KController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	public Boss boss;

	public Text challengeInfoText;

	public Text challengeButtonText;

	public Button challengeButton;

	public AllChallengesController allChallenges;

	public int baseExpReward;

	public int maxCompletions;

	public int baseAPReward;

	private string message;

	private void Update()
	{
		updateButton();
		if (character.challenges.levelChallenge10k.inChallenge)
		{
			character.challenges.levelChallenge10k.challengeTime.advanceTime(Time.deltaTime);
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
			challengeButton.GetComponentInChildren<Text>().text = "100 Level Challenge";
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

	public int completions()
	{
		if (character.challenges.levelChallenge10k.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.levelChallenge10k.curCompletions;
	}

	public int evilCompletions()
	{
		if (character.challenges.levelChallenge10k.curEvilCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.levelChallenge10k.curEvilCompletions;
	}

	public int sadisticCompletions()
	{
		if (character.challenges.levelChallenge10k.curSadisticCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.levelChallenge10k.curSadisticCompletions;
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

	public int targetBoss()
	{
		return 57;
	}

	public bool unlocked()
	{
		return character.NGUController.unlocked100LevelChallenge();
	}

	public void complete()
	{
		if ((int)character.challenges.levelChallenge10k.challengeTime.totalseconds < character.challenges.levelChallenge10k.bestTime)
		{
			character.challenges.levelChallenge10k.bestTime = (int)character.challenges.levelChallenge10k.challengeTime.totalseconds;
		}
		character.challenges.levelChallenge10k.challengeTime.reset();
		character.challenges.levelChallenge10k.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		long num = 0L;
		long num2 = 0L;
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			character.challenges.levelChallenge10k.curCompletions++;
			if (character.challenges.levelChallenge10k.curCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward);
				num2 = character.addAP(baseAPReward);
			}
			if (character.challenges.levelChallenge10k.curCompletions == 1)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You've also earned a permanent +20% wandoos speed! For your first challenge completion you also unlocked Boost Transformation! Using Q/W/E + left click will change any boost to a Power/Toughness/Special boost, at the cost of 1 tier.";
			}
			else if (character.challenges.levelChallenge10k.curCompletions < maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! you also earned +20% permanent wandoos speed.";
			}
			else if (character.challenges.levelChallenge10k.curCompletions == maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! you also earned +20% permanent wandoos speed. For your final completion, the -1 tier penalty for Boost Transformations is removed, and you've unlocked a new option in the settings menu, to automatically transform incoming boosts.";
			}
			else
			{
				message = "You completed a 100 levels Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			character.challenges.levelChallenge10k.curEvilCompletions++;
			if (character.challenges.levelChallenge10k.curEvilCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 10);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.levelChallenge10k.curEvilCompletions == 1)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You also gained +10% Wandoos Bootup Speed!";
			}
			else if (character.challenges.levelChallenge10k.curEvilCompletions < maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP! You also gained +10% Wandoos Bootup Speed!";
			}
			else if (character.challenges.levelChallenge10k.curEvilCompletions == maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a 100 levels Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		else if (character.settings.rebirthDifficulty == difficulty.sadistic)
		{
			character.challenges.levelChallenge10k.curSadisticCompletions++;
			if (character.challenges.levelChallenge10k.curSadisticCompletions <= maxCompletions)
			{
				num = character.addExp(baseExpReward * 100);
				num2 = character.addAP(baseAPReward / 5);
			}
			if (character.challenges.levelChallenge10k.curSadisticCompletions == 1)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.levelChallenge10k.curSadisticCompletions < maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else if (character.challenges.levelChallenge10k.curSadisticCompletions == maxCompletions)
			{
				message = "You completed a 100 levels challenge and gained " + num.ToString("###,##0") + "EXP and " + num2.ToString("###,##0") + " AP!";
			}
			else
			{
				message = "You completed a 100 levels Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back!";
			}
		}
		tooltip.showTooltip(message, 3f);
	}

	public void challengeFailed()
	{
		character.challenges.levelChallenge10k.challengeTime.reset();
		character.challenges.levelChallenge10k.inChallenge = false;
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
		message = "<b>100 Levels Challenge</b>\n\n<b>Recommended Stats:</b> High Energy and Magic caps/power.\n\n<b>Description:</b> Revert back to a NUMBER of 1 and work your way back up! Except, this time you have 100 levels you can gain at most from Augments, Blood Magic, Time Machine, Wandoos and Beards combined during each rebirth.\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + character.display(character.checkExpAdded(expectedEXP())) + " EXP.\n" + expectedAPReward() + " AP.\n" + specialRewards() + "\n\n<b>Completions:</b> " + currentCompletions() + " / " + maxCompletions + "\n\n<b>Fastest Completion Time:</b> " + bestTime() + "\n\n<b>Restrictions:</b> You can use anything you want, but the total number of levels gained from all features (except training and NGU) per rebirth is capped at 100. Offline Progress will be disabled during this challenge.\n\n<b>Challenge Unlock Condition:</b>Gain 10 levels total in NGU!";
		challengeInfoText.text = message;
	}

	public string specialRewards()
	{
		if (character.settings.rebirthDifficulty == difficulty.normal)
		{
			return "First Completion: Unlock Boost Transformation.Change any type of boost to a Power/ Toughness / Special Boost with Q / W / E + left click, at a cost of reducing the boost by one tier.\nEach completion: +20 % permanent Wandoos Speed.\nFinal completion: Removes Boost transformation cost!You also unlock an option in the settings menu to automatically transform dropped boosts!";
		}
		if (character.settings.rebirthDifficulty == difficulty.evil)
		{
			return "Each completion: +10% Wandoos Bootup Speed!";
		}
		return "Additional special rewards will be added over time!";
	}

	public string bestTime()
	{
		if (character.challenges.levelChallenge10k.bestTime != int.MaxValue)
		{
			return NumberOutput.timeOutput(character.challenges.levelChallenge10k.bestTime);
		}
		return "Not Completed Yet.";
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		showChallengeInfo();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
