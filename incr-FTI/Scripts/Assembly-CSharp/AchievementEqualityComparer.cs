using System.Collections.Generic;

public class AchievementEqualityComparer : IEqualityComparer<AchievementType>
{
	public bool Equals(AchievementType a, AchievementType b)
	{
		return a == b;
	}

	public int GetHashCode(AchievementType obj)
	{
		return (int)obj;
	}
}
