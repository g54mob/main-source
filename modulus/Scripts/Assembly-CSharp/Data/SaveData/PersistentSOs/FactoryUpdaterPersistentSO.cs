using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/FactoryUpdater", fileName = "FactoryUpdaterPersistentSO", order = 0)]
	public class FactoryUpdaterPersistentSO : AbstractPersistentSO
	{
		public int Step = int.MinValue;

		public int IslandIndex;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			FactoryUpdaterSaveData factoryUpdaterSaveData = saveData as FactoryUpdaterSaveData;
			Step = factoryUpdaterSaveData.Step;
		}

		public override void ResetToDefaults()
		{
			Step = int.MinValue;
			IslandIndex = 0;
		}

		public override AbstractSaveData GetSaveData()
		{
			return new FactoryUpdaterSaveData(Step, IslandIndex);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<FactoryUpdaterSaveData>(fullPath);
		}
	}
}
