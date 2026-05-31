using System;
using System.Collections.Generic;

[Serializable]
public class ITOPOD
{
	public List<long> perkLevel;

	public long perkPoints;

	public long lifetimePoints;

	public long pointProgress;

	public int enemiesKilled;

	public long poopProgress;

	public long buffedKills;

	public bool filterDiff;

	public bool filterAfford;

	public bool filterMaxxed;

	public orderPerks orderType;

	public long curSize()
	{
		return 232L;
	}

	public ITOPOD()
	{
		perkPoints = 0L;
		lifetimePoints = 0L;
		pointProgress = 0L;
		enemiesKilled = 0;
		poopProgress = 0L;
		buffedKills = 0L;
		updateItopod();
		filterDiff = false;
		filterAfford = false;
		filterMaxxed = false;
		orderType = orderPerks.Default;
	}

	public void updateItopod()
	{
		if (perkLevel == null)
		{
			perkLevel = new List<long>();
		}
		while (perkLevel.Count < curSize())
		{
			perkLevel.Add(0L);
		}
	}
}
