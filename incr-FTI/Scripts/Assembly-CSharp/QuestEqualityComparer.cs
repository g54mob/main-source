using System.Collections.Generic;

public class QuestEqualityComparer : IEqualityComparer<QuestType>
{
	public bool Equals(QuestType a, QuestType b)
	{
		return a == b;
	}

	public int GetHashCode(QuestType obj)
	{
		return (int)obj;
	}
}
