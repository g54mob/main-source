using System;
using System.Collections.Generic;

[Serializable]
public class ContractCapacityLevelTable
{
	public List<ContractCapacityLevelEntry> levels = new List<ContractCapacityLevelEntry>();

	public ContractCapacityLevelEntry GetFor(int level)
	{
		if (levels == null || levels.Count == 0)
		{
			return new ContractCapacityLevelEntry
			{
				level = 0,
				capacity = 2
			};
		}
		ContractCapacityLevelEntry result = levels[0];
		for (int i = 0; i < levels.Count; i++)
		{
			ContractCapacityLevelEntry contractCapacityLevelEntry = levels[i];
			if (contractCapacityLevelEntry.level == level)
			{
				return contractCapacityLevelEntry;
			}
			if (contractCapacityLevelEntry.level < level && contractCapacityLevelEntry.level >= result.level)
			{
				result = contractCapacityLevelEntry;
			}
		}
		return result;
	}
}
