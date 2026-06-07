using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class CurrencySaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public Dictionary<int, int> ResourceCounts;

		public CurrencySaveData(Dictionary<int, int> resourceCounts)
			: base(0)
		{
			ResourceCounts = resourceCounts;
		}
	}
}
