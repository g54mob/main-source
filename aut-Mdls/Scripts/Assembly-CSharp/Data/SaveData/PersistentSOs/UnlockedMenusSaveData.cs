using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class UnlockedMenusSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<bool> UnlockedMenus;

		public UnlockedMenusSaveData(List<bool> unlockedMenus)
			: base(0)
		{
			UnlockedMenus = unlockedMenus;
		}
	}
}
