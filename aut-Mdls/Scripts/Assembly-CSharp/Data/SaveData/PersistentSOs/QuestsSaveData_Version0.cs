using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class QuestsSaveData_Version0 : IPreviousSaveVersion, ISaveVersion
	{
		public int CurrentIndex;

		public int OrderedIndex;

		public List<int> NonOrderedIndices;

		public bool BlockAnyOtherPlacements;

		public bool IsTutorialActiveFlag;

		public bool AllowRotating;

		public bool AllowMirroring;

		public bool DefaultStartupQuestEventsExecuted;

		public ISaveVersion ToNextVersion()
		{
			return new QuestsSaveData(999, showTutorial: false);
		}
	}
}
