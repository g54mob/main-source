using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class UnlockedFactoryObjectsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 1;

		public List<int> UnlockedObjectsIds;

		public UnlockedFactoryObjectsSaveData(IEnumerable<int> unlockedObjectsIds)
			: base(1)
		{
			UnlockedObjectsIds = new List<int>(unlockedObjectsIds);
		}
	}
}
