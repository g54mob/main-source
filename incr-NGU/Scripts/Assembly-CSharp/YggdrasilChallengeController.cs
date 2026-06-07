using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YggdrasilChallengeController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
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
		if (unlocked())
		{
			challengeButton.interactable = true;
			challengeButton.GetComponentInChildren<Text>().text = "Yggrasil Challenge";
		}
		else
		{
			challengeButton.interactable = false;
			challengeButton.GetComponentInChildren<Text>().text = "Challenge Locked";
		}
		if (character.challenges.noAugsChallenge.inChallenge)
		{
			character.challenges.noAugsChallenge.challengeTime.advanceTime(Time.deltaTime);
			if (character.bossID > targetBoss())
			{
				complete();
			}
		}
	}

	public int targetBoss()
	{
		return 57;
	}

	public int completions()
	{
		if (character.challenges.noAugsChallenge.curCompletions > maxCompletions)
		{
			return maxCompletions;
		}
		return character.challenges.noAugsChallenge.curCompletions;
	}

	private void complete()
	{
		int timeAsHighscore = character.challenges.noAugsChallenge.challengeTime.getTimeAsHighscore();
		if (timeAsHighscore < character.challenges.noAugsChallenge.bestTime)
		{
			character.challenges.noAugsChallenge.bestTime = timeAsHighscore;
		}
		character.challenges.noAugsChallenge.challengeTime.reset();
		character.challenges.noAugsChallenge.inChallenge = false;
		character.challenges.inChallenge = false;
		character.challenges.curChallengeType = challengeType.None;
		character.addExp(baseExpReward);
		character.challenges.noAugsChallenge.curCompletions++;
		if (character.challenges.noAugsChallenge.curCompletions <= maxCompletions)
		{
			character.addAP(baseAPReward);
		}
		if (character.challenges.noAugsChallenge.curCompletions == 1)
		{
			message = "You completed your first Yggdrasil Challenge! You've gained " + baseExpReward + " EXP! You also gained +10% leveling speed to Augments!";
		}
		else if (completions() < maxCompletions)
		{
			message = "You completed a Yggdrasil Challenge! You've gained " + baseExpReward + " EXP and +5% to Total Augment Power!";
		}
		else if (completions() == maxCompletions)
		{
			message = "You completed your Ydrassil Challenge! You've gained " + baseExpReward + " EXP and +5% to Total Augment Power! You also reduced costs of all augmentations by 50%!";
		}
		else
		{
			message = "You completed a Yggdrasil Challenge! You've uh... hit your max for this kind of challenge, but pat yourself on the back! I'll still give you the EXP reward.";
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

	public void showChallengeInfo()
	{
		message = "<b>No Augs Challenge</b>\n\n<b>Recommended Stats:</b> A decently high OS level for Wandoos as a backup for having no augments can help!\n\n<b>Description:</b> No augs for you! Revert to your starting NUMBER, and work your way back up as usual. However, the augmentation feature is entirely off-limits for the duration of this challenge!\n\n<b>Win condition:</b> Defeat " + character.bossController.getBossName(targetBoss()) + " (Boss # " + (targetBoss() + 1) + ")\n\n<b>Reward:</b>\n" + baseExpReward + " EXP.\n" + baseAPReward + "AP.\nFirst completion: +10% Augment leveling speed.\nEvery completion: +5% to Total Augment Power. Final completion: Reduces augmentation and upgrade costs by 50%.\n\n<b>Completions:</b> " + completions() + " / " + maxCompletions + "\n\n<b>Fastest Completion Time:</b> " + NumberOutput.timeOutput(character.challenges.noAugsChallenge.bestTime) + "\n\n<b>Restrictions:</b> The augmentations menu will be locked until you complete this challenge! Otherwise, everything else is available.\n\n<b>Challenge Unlock Condition:</b> Defeat boss 75!";
		challengeInfo.text = message;
	}
}
