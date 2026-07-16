using System;

[Serializable]
public class Stat
{
	public StatTypes statType;

	public float statValue;

	public Stat(StatTypes statType, float statValue)
	{
		this.statType = statType;
		this.statValue = statValue;
	}
}
