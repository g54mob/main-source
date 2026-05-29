using System;
using System.Collections.Generic;

namespace SaveData
{
	[Serializable]
	public class PlayBattlePassiveData
	{
		public List<BattlePassiveData> passiveDataList;

		public PlayBattlePassiveData(List<BattlePassiveData> passiveDataList)
		{
		}
	}
}
