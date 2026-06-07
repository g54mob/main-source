using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class LockedToolsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<string> _lockedToolsNames;

		public LockedToolsSaveData(List<string> lockedToolsNames)
			: base(0)
		{
			_lockedToolsNames = lockedToolsNames;
		}
	}
}
