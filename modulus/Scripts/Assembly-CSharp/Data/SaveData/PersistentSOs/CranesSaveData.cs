using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class CranesSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int MaxReach;

		public int MaxAmountPerBuilding;

		public CranesSaveData(int maxAmountPerBuilding, int maxReach)
			: base(0)
		{
			MaxReach = maxReach;
			MaxAmountPerBuilding = maxAmountPerBuilding;
		}
	}
}
