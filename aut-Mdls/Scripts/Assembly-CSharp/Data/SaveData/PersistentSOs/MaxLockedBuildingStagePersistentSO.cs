using System.Collections.Generic;
using System.Linq;
using Data.FactoryFloor.Buildings;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Max Locked BuildingStage", fileName = "MaxLockedBuildingStagePersistentSO")]
	public class MaxLockedBuildingStagePersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private List<BuildingMaxLockedStageData> _buildingMaxLockedStageDatas;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			MaxLockedBuildingStageSaveData maxLockedBuildingStageSaveData = saveData as MaxLockedBuildingStageSaveData;
			for (int i = 0; i < _buildingMaxLockedStageDatas.Count; i++)
			{
				_buildingMaxLockedStageDatas[i].Apply(maxLockedBuildingStageSaveData.MaxLockedBuildingStages[i]);
			}
		}

		public override void ResetToDefaults()
		{
			foreach (BuildingMaxLockedStageData buildingMaxLockedStageData in _buildingMaxLockedStageDatas)
			{
				buildingMaxLockedStageData.ResetToDefault();
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			return new MaxLockedBuildingStageSaveData(_buildingMaxLockedStageDatas.Select((BuildingMaxLockedStageData data) => data.MaxLockedBuildingStage).ToList());
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<MaxLockedBuildingStageSaveData>(fullPath);
		}
	}
}
