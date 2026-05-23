using System;
using System.Collections.Generic;

namespace SaveData
{
	[Serializable]
	public class PlayResearchTreeDataGroup
	{
		public List<ResearchTreeDataUnit> researchTreeDataUnits;

		public bool IsAllUnlock => false;

		public bool IsAnyPointUnlock => false;

		public PlayResearchTreeDataGroup(List<ResearchTreeDataUnit> researchTreeDataUnits)
		{
		}
	}
}
