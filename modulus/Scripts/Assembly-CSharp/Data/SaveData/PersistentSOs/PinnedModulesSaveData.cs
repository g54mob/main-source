using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class PinnedModulesSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<(int objectIndex, int shapeIndex)> PinnedModules;

		public PinnedModulesSaveData(List<(int objectIndex, int shapeIndex)> pinnedModules)
			: base(0)
		{
			PinnedModules = pinnedModules;
		}
	}
}
