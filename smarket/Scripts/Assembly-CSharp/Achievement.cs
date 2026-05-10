using System;

[Serializable]
public class Achievement
{
	public AchievementId Id;

	public int currentVal;

	public int maxVal;

	public bool isAchieved;

	public int index => 0;

	public void Achieve()
	{
	}
}
