using System;
using System.Collections.Generic;

namespace SaveData
{
	[Serializable]
	public class BattlePassiveData
	{
		public eUpgradeKind id;

		public List<string> param;

		public eArchiveCategory sourceCategory;

		public string sourceId;

		public BattlePassiveData(eUpgradeKind id, List<string> param, eArchiveCategory sourceCategory, string sourceId)
		{
		}
	}
}
