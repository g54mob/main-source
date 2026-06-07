using UnityEngine;
using UnityEngine.Events;

public class AllChallengesController : MonoBehaviour
{
	public Character character;

	public Rebirth rebirth;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public BasicChallengeController basicChallenge;

	public NoAugsChallengeController noAugsChallenge;

	public Hour24ChallengeController hour24Challenge;

	public LevelChallenge10KController level100Challenge;

	public NoEquipmentChallengeController noEquipmentChallenge;

	public NoRebirthChallengeController noRebirthChallenge;

	public TrollChallengeController trollChallenge;

	public LaserSwordChallengeController laserSwordChallenge;

	public BlindChallengeController blindChallenge;

	public NGUChallengeController NGUChallenge;

	public TimeMachineChallengeController timeMachineChallenge;

	private UnityAction yesAction;

	private UnityAction noAction;

	public Sprite redBorder;

	public Sprite orangeBorder;

	public Sprite goldBorder;

	public Sprite normalBorder;

	public double checkTimer;

	private void Start()
	{
		character.challenges.updateAllChallenges();
		noAction = cancel;
	}

	public void Update()
	{
		checkTimer += Time.deltaTime;
		if (checkTimer >= 10.0)
		{
			checkTimer = 0.0;
			checkChallengesForPortrait();
		}
	}

	public void cancel()
	{
	}

	public bool hasParalyze()
	{
		return basicChallenge.completions() >= basicChallenge.maxCompletions;
	}

	public float adventureBonus()
	{
		float num = 1f;
		num += (float)basicChallenge.completions() * 0.05f;
		if (basicChallenge.completions() >= 1)
		{
			num += 0.1f;
		}
		return num * (1f + (float)basicChallenge.evilCompletions() * 0.1f);
	}

	public float wandoosBonus()
	{
		return 1f + (float)level100Challenge.completions() * 0.2f;
	}

	public float nguBonus()
	{
		float num = 1f + (float)NGUChallenge.completions() * 0.05f;
		if (num < 1f)
		{
			return 1f;
		}
		return num;
	}

	public float expFactor()
	{
		return 1f + (float)hour24Challenge.completions() * 0.1f + (float)hour24Challenge.evilCompletions() * 0.04f + (float)hour24Challenge.sadisticCompletions() * 0.02f;
	}

	public void startQuitChallenge()
	{
		yesAction = quitChallenge;
		box.displayBox("Are you sure you want to quit your current challenge?", yesAction, noAction);
	}

	private void quitChallenge()
	{
		if (character.challenges.basicChallenge.inChallenge)
		{
			basicChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.noAugsChallenge.inChallenge)
		{
			noAugsChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.hour24Challenge.inChallenge)
		{
			hour24Challenge.challengeFailed();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.levelChallenge10k.inChallenge)
		{
			level100Challenge.challengeFailed();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.noEquipmentChallenge.inChallenge)
		{
			noEquipmentChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.trollChallenge.inChallenge)
		{
			trollChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.noRebirthChallenge.inChallenge)
		{
			noRebirthChallenge.challengeFailed();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.laserSwordChallenge.inChallenge)
		{
			laserSwordChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.nguChallenge.inChallenge)
		{
			NGUChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.timeMachineChallenge.inChallenge)
		{
			timeMachineChallenge.failedChallenge();
			tooltip.showTooltip("It's okay to be a wuss.", 2f);
		}
		else if (character.challenges.blindChallenge.inChallenge)
		{
			CancelInvoke("delayedBlindQuit");
			Invoke("delayedBlindQuit", 180f);
			tooltip.showOverrideTooltip("For anti-cheat purposes, the Blind Challenge will not quit instantly, but instead in about 3 minutes. Take this time to reflect upon your failures in life.", 5f);
		}
		else
		{
			tooltip.showTooltip("You have to BE in a challenge to quit it, you silly person.", 2f);
		}
	}

	public void delayedBlindQuit()
	{
		blindChallenge.failedChallenge();
	}

	public void checkChallengesForPortrait()
	{
		if (!character.portraits.portraitUnlocked[63] && character.challenges.basicChallenge.curCompletions >= character.allChallenges.basicChallenge.maxCompletions && character.challenges.noAugsChallenge.curCompletions >= character.allChallenges.noAugsChallenge.maxCompletions && character.challenges.noEquipmentChallenge.curCompletions >= character.allChallenges.noEquipmentChallenge.maxCompletions && character.challenges.hour24Challenge.curCompletions >= character.allChallenges.hour24Challenge.maxCompletions && character.challenges.levelChallenge10k.curCompletions >= character.allChallenges.level100Challenge.maxCompletions && character.challenges.trollChallenge.curCompletions >= character.allChallenges.trollChallenge.maxCompletions && character.challenges.noRebirthChallenge.curCompletions >= character.allChallenges.noRebirthChallenge.maxCompletions && character.challenges.laserSwordChallenge.curCompletions >= character.allChallenges.laserSwordChallenge.maxCompletions && character.challenges.blindChallenge.curCompletions >= character.allChallenges.blindChallenge.maxCompletions && character.challenges.nguChallenge.curCompletions >= character.allChallenges.NGUChallenge.maxCompletions && character.challenges.timeMachineChallenge.curCompletions >= character.allChallenges.timeMachineChallenge.maxCompletions)
		{
			character.portraits.portraitUnlocked[63] = true;
		}
		if (!character.portraits.portraitUnlocked[64] && character.challenges.basicChallenge.curEvilCompletions >= character.allChallenges.basicChallenge.maxCompletions && character.challenges.noAugsChallenge.curEvilCompletions >= character.allChallenges.noAugsChallenge.maxCompletions && character.challenges.noEquipmentChallenge.curEvilCompletions >= character.allChallenges.noEquipmentChallenge.maxCompletions && character.challenges.hour24Challenge.curEvilCompletions >= character.allChallenges.hour24Challenge.maxCompletions && character.challenges.levelChallenge10k.curEvilCompletions >= character.allChallenges.level100Challenge.maxCompletions && character.challenges.trollChallenge.curEvilCompletions >= character.allChallenges.trollChallenge.maxCompletions && character.challenges.noRebirthChallenge.curEvilCompletions >= character.allChallenges.noRebirthChallenge.maxCompletions && character.challenges.laserSwordChallenge.curEvilCompletions >= character.allChallenges.laserSwordChallenge.maxCompletions && character.challenges.blindChallenge.curEvilCompletions >= character.allChallenges.blindChallenge.maxCompletions && character.challenges.nguChallenge.curEvilCompletions >= character.allChallenges.NGUChallenge.maxCompletions && character.challenges.timeMachineChallenge.curEvilCompletions >= character.allChallenges.timeMachineChallenge.maxCompletions)
		{
			character.portraits.portraitUnlocked[64] = true;
		}
		if (!character.portraits.portraitUnlocked[65] && character.challenges.basicChallenge.curSadisticCompletions >= character.allChallenges.basicChallenge.maxCompletions && character.challenges.noAugsChallenge.curSadisticCompletions >= character.allChallenges.noAugsChallenge.maxCompletions && character.challenges.noEquipmentChallenge.curSadisticCompletions >= character.allChallenges.noEquipmentChallenge.maxCompletions && character.challenges.hour24Challenge.curSadisticCompletions >= character.allChallenges.hour24Challenge.maxCompletions && character.challenges.levelChallenge10k.curSadisticCompletions >= character.allChallenges.level100Challenge.maxCompletions && character.challenges.trollChallenge.curSadisticCompletions >= character.allChallenges.trollChallenge.maxCompletions && character.challenges.noRebirthChallenge.curSadisticCompletions >= character.allChallenges.noRebirthChallenge.maxCompletions && character.challenges.laserSwordChallenge.curSadisticCompletions >= character.allChallenges.laserSwordChallenge.maxCompletions && character.challenges.blindChallenge.curSadisticCompletions >= character.allChallenges.blindChallenge.maxCompletions && character.challenges.nguChallenge.curSadisticCompletions >= character.allChallenges.NGUChallenge.maxCompletions && character.challenges.timeMachineChallenge.curSadisticCompletions >= character.allChallenges.timeMachineChallenge.maxCompletions)
		{
			character.portraits.portraitUnlocked[65] = true;
		}
	}
}
