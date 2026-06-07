using System.Collections.Generic;

public class QuestGroupingEqualityComparer : IEqualityComparer<QuestGroup>
{
	public bool Equals(QuestGroup a, QuestGroup b)
	{
		return a == b;
	}

	public int GetHashCode(QuestGroup obj)
	{
		return (int)obj;
	}
}
