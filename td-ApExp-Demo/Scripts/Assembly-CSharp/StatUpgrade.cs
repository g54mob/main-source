using System;

[Serializable]
public struct StatUpgrade
{
	public Stat stat;

	public bool isPercent;

	public StatUpgrade(StatTypes statType, float statValue, bool isPercent)
	{
		stat = new Stat(statType, statValue);
		this.isPercent = isPercent;
	}
}
