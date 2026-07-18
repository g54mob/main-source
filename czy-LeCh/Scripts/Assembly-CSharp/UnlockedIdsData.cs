using System;
using System.Collections.Generic;

[Serializable]
public class UnlockedIdsData
{
	public List<int> unlockedIds;

	public UnlockedIdsData(List<int> unlockedIds)
	{
		this.unlockedIds = unlockedIds;
	}
}
