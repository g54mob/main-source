using System;
using System.Collections.Generic;

[Serializable]
public class ToolLevelTable
{
	public List<ToolLevelEntry> levels = new List<ToolLevelEntry>();

	public ToolLevelEntry GetFor(int level)
	{
		if (levels == null || levels.Count == 0)
		{
			return new ToolLevelEntry
			{
				level = 1,
				size = 1.5f,
				speed = 1f,
				damage = 1f
			};
		}
		ToolLevelEntry result = levels[0];
		for (int i = 0; i < levels.Count; i++)
		{
			ToolLevelEntry toolLevelEntry = levels[i];
			if (toolLevelEntry.level == level)
			{
				return toolLevelEntry;
			}
			if (toolLevelEntry.level < level && toolLevelEntry.level >= result.level)
			{
				result = toolLevelEntry;
			}
		}
		return result;
	}
}
