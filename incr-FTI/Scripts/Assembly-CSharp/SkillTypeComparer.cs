using System.Collections.Generic;

public class SkillTypeComparer : IEqualityComparer<SkillType>
{
	public bool Equals(SkillType a, SkillType b)
	{
		return a == b;
	}

	public int GetHashCode(SkillType obj)
	{
		return (int)obj;
	}
}
