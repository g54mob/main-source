using System;

[Serializable]
public class GoldDigger
{
	public long curLevel;

	public long maxLevel;

	public bool active;

	public PlayerTime cooldown;

	public GoldDigger()
	{
		curLevel = 0L;
		maxLevel = 0L;
		active = false;
		cooldown = new PlayerTime();
	}
}
