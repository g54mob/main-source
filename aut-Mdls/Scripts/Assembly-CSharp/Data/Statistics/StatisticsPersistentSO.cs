#define ENABLE_DEBUG_LOGS
using Data.SaveData;
using UnityEngine;
using Utils;

namespace Data.Statistics
{
	[CreateAssetMenu(menuName = "PersistentSOs/Statistics", fileName = "StatisticsPersistentSO", order = 0)]
	public class StatisticsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private StatisticsSO _statisticsSO;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			_statisticsSO.ApplySaveData(saveData as StatisticsSaveData);
			this.Log("Applied Savegame!", "ApplyLoadedSaveData", 19);
		}

		public override void ResetToDefaults()
		{
			_statisticsSO.Reset();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new StatisticsSaveData(_statisticsSO.ProducedStats, _statisticsSO.ProducedShapesStats, _statisticsSO.DeliveredStats, _statisticsSO.DeliveredShapesStats, _statisticsSO.WithdrawnStats, _statisticsSO.PlacedStats, _statisticsSO.BehaviourStats, _statisticsSO.XPEarned);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<StatisticsSaveData>(fullPath);
		}
	}
}
