using System;
using System.Collections.Generic;

[Serializable]
public class DynamiteLevelTable
{
	public List<DynamiteLevelEntry> levels = new List<DynamiteLevelEntry>();

	public DynamiteLevelEntry GetFor(int level)
	{
		if (levels == null || levels.Count == 0)
		{
			return new DynamiteLevelEntry
			{
				level = 1,
				size = 2.5f
			};
		}
		DynamiteLevelEntry result = levels[0];
		for (int i = 0; i < levels.Count; i++)
		{
			DynamiteLevelEntry dynamiteLevelEntry = levels[i];
			if (dynamiteLevelEntry.level == level)
			{
				return dynamiteLevelEntry;
			}
			if (dynamiteLevelEntry.level < level && dynamiteLevelEntry.level >= result.level)
			{
				result = dynamiteLevelEntry;
			}
		}
		return result;
	}
}
