using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BeastQuest
{
	public List<long> quirkLevel;

	public long quirkPoints;

	public long lifetimePoints;

	public bool questsUnlocked;

	public bool inQuest;

	public bool idleMode;

	public int questID;

	public int targetDrops;

	public int curDrops;

	public PlayerTime dailyQuestTimer;

	public int curBankedQuests;

	public int maxBankedQuests;

	public UnityEngine.Random.State questState;

	public bool reducedRewards;

	public bool allActive;

	public bool usedButter;

	public float idleProgress;

	public bool filterDiff;

	public bool filterAfford;

	public bool filterMaxxed;

	public orderQuirks orderType;

	public long curSize()
	{
		return 186L;
	}

	public BeastQuest()
	{
		quirkPoints = 0L;
		lifetimePoints = 0L;
		questsUnlocked = false;
		inQuest = false;
		idleMode = false;
		questID = 0;
		targetDrops = 0;
		curDrops = 0;
		curBankedQuests = 3;
		maxBankedQuests = 10;
		idleProgress = 0f;
		dailyQuestTimer = new PlayerTime();
		updateBeastQuest();
		reducedRewards = false;
		allActive = true;
		usedButter = false;
		filterDiff = false;
		filterAfford = false;
		filterMaxxed = false;
		orderType = orderQuirks.Default;
	}

	public void updateBeastQuest()
	{
		if (quirkLevel == null)
		{
			quirkLevel = new List<long>();
		}
		while (quirkLevel.Count < curSize())
		{
			quirkLevel.Add(0L);
		}
	}
}
