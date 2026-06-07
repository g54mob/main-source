using System;
using System.Collections.Generic;

[Serializable]
public class DetectorLevelTable
{
	public List<DetectorLevelEntry> levels = new List<DetectorLevelEntry>();

	public DetectorLevelEntry GetFor(int level)
	{
		if (levels == null || levels.Count == 0)
		{
			return new DetectorLevelEntry
			{
				level = 1,
				scanDistance = 5f,
				scanRadius = 1f
			};
		}
		DetectorLevelEntry result = levels[0];
		for (int i = 0; i < levels.Count; i++)
		{
			DetectorLevelEntry detectorLevelEntry = levels[i];
			if (detectorLevelEntry.level == level)
			{
				return detectorLevelEntry;
			}
			if (detectorLevelEntry.level < level && detectorLevelEntry.level >= result.level)
			{
				result = detectorLevelEntry;
			}
		}
		return result;
	}
}
