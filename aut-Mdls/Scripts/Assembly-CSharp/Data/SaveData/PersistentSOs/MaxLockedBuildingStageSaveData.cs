using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class MaxLockedBuildingStageSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<int> MaxLockedBuildingStages;

		public MaxLockedBuildingStageSaveData(List<int> maxLockedBuildingStages)
			: base(0)
		{
			MaxLockedBuildingStages = maxLockedBuildingStages;
		}
	}
}
