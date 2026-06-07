using System;

[Serializable]
public class Challenges
{
	public Challenge basicChallenge;

	public Challenge noAugsChallenge;

	public Challenge hour24Challenge;

	public Challenge levelChallenge10k;

	public Challenge noEquipmentChallenge;

	public Challenge noRebirthChallenge;

	public Challenge trollChallenge;

	public Challenge laserSwordChallenge;

	public Challenge blindChallenge;

	public Challenge nguChallenge;

	public Challenge timeMachineChallenge;

	public bool unlocked;

	public bool inChallenge;

	public challengeType curChallengeType;

	public int curPoints;

	public int maxPoints;

	public int trollCounter;

	public bool trollUnlocked;

	public bool trollDisplay;

	public bool trollMenuSwap;

	public bool trollDivided;

	public bool blindChallengeUnlocked;

	public bool laserSwordChallengeUnlocked;

	public Challenges()
	{
		basicChallenge = new Challenge();
		noAugsChallenge = new Challenge();
		hour24Challenge = new Challenge(highLow: false);
		levelChallenge10k = new Challenge();
		noEquipmentChallenge = new Challenge();
		noRebirthChallenge = new Challenge(highLow: false);
		trollChallenge = new Challenge();
		laserSwordChallenge = new Challenge();
		blindChallenge = new Challenge();
		timeMachineChallenge = new Challenge();
		nguChallenge = new Challenge();
		unlocked = false;
		inChallenge = false;
		curChallengeType = challengeType.None;
		curPoints = 0;
		maxPoints = 0;
		trollCounter = 0;
		trollUnlocked = false;
		trollDisplay = false;
		trollMenuSwap = false;
		trollDivided = false;
		laserSwordChallengeUnlocked = false;
		blindChallengeUnlocked = false;
	}

	public void updateAllChallenges()
	{
		if (basicChallenge == null)
		{
			basicChallenge = new Challenge();
		}
		if (noAugsChallenge == null)
		{
			noAugsChallenge = new Challenge();
		}
		if (hour24Challenge == null)
		{
			hour24Challenge = new Challenge(highLow: false);
		}
		if (levelChallenge10k == null)
		{
			levelChallenge10k = new Challenge();
		}
		if (noEquipmentChallenge == null)
		{
			noEquipmentChallenge = new Challenge();
		}
		if (noRebirthChallenge == null)
		{
			noRebirthChallenge = new Challenge(highLow: false);
		}
		if (trollChallenge == null)
		{
			trollChallenge = new Challenge();
		}
		if (laserSwordChallenge == null)
		{
			laserSwordChallenge = new Challenge();
		}
		if (blindChallenge == null)
		{
			blindChallenge = new Challenge();
		}
		if (nguChallenge == null)
		{
			nguChallenge = new Challenge();
		}
		if (timeMachineChallenge == null)
		{
			timeMachineChallenge = new Challenge();
		}
	}
}
