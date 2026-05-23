using System;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class FactoryUpdaterSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public int Step;

		public int IslandIndex;

		public FactoryUpdaterSaveData(int step, int islandIndex)
			: base(0)
		{
			Step = step;
			IslandIndex = islandIndex;
		}
	}
}
