using Data.SaveData;
using UnityEngine;

namespace Data.Progression
{
	[CreateAssetMenu(menuName = "PersistentSOs/Progression", fileName = "ProgressionPersistentSO", order = 0)]
	public class ProgressionPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private ProgressionManagerLocator _progressionManagerLocator;

		private ProgressionSaveData _progressionSaveData;

		public bool TryGetSaveData(out ProgressionSaveData progressionSaveData)
		{
			progressionSaveData = _progressionSaveData;
			return _progressionSaveData != null;
		}

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (_progressionManagerLocator.ProgressionMonuments != null)
			{
				_progressionManagerLocator.ProgressionMonuments.ApplySaveData(saveData as ProgressionSaveData);
			}
			if (_progressionManagerLocator.ProgressionModules != null)
			{
				_progressionManagerLocator.ProgressionModules.ApplySaveData(saveData as ProgressionSaveData);
			}
			_progressionSaveData = saveData as ProgressionSaveData;
		}

		public override void ResetToDefaults()
		{
			_progressionSaveData = null;
			_progressionManagerLocator.ProgressionMonuments.Reset();
			_progressionManagerLocator.ProgressionModules.Reset();
		}

		public override AbstractSaveData GetSaveData()
		{
			return new ProgressionSaveData(_progressionManagerLocator.ProgressionMonuments.MonumentInfos, _progressionManagerLocator.ProgressionModules.DiscoveredShapes);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<ProgressionSaveData>(fullPath);
		}
	}
}
