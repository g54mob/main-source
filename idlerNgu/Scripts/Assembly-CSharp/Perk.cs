using System;

[Serializable]
public class Perk
{
	public int level;

	public int perLevelCost;

	public int levelCap;

	public perkType type;

	public Perk(int cost, int cap)
	{
		level = 0;
		perLevelCost = cost;
		levelCap = cap;
	}

	public Perk()
	{
		level = 0;
		perLevelCost = 1;
		levelCap = 5;
	}

	public void updateBaseStats(int baseCost, int cap)
	{
		perLevelCost = baseCost;
		levelCap = cap;
		if (level > levelCap)
		{
			level = levelCap;
		}
	}

	public void respec()
	{
		level = 0;
	}
}
