using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class RankSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int CurrentXP;

		public RankSaveData(int currentXP)
			: base(0)
		{
			CurrentXP = currentXP;
		}
	}
}
