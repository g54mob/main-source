using Data.Variables.Milestones;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Monuments", fileName = "MonumentsPersistentSO")]
	public class MonumentsPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private MonumentBuiltVariableSO _greyMonumentBuilt;

		[SerializeField]
		private MonumentBuiltVariableSO _blueMonumentBuilt;

		[SerializeField]
		private MonumentBuiltVariableSO _yellowMonumentBuilt;

		[SerializeField]
		private GNNGateFinishedVariableSO _gNNGateFinished;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			MonumentsPersistentSaveData monumentsPersistentSaveData = saveData as MonumentsPersistentSaveData;
			_greyMonumentBuilt.SetValue(monumentsPersistentSaveData.greyMonument);
			_blueMonumentBuilt.SetValue(monumentsPersistentSaveData.blueMonument);
			_yellowMonumentBuilt.SetValue(monumentsPersistentSaveData.yellowMonument);
			_gNNGateFinished.SetValue(monumentsPersistentSaveData.gNNGateFinished);
		}

		public override void ResetToDefaults()
		{
			_greyMonumentBuilt.SetValue(_greyMonumentBuilt.DefaultValue);
			_blueMonumentBuilt.SetValue(_blueMonumentBuilt.DefaultValue);
			_yellowMonumentBuilt.SetValue(_yellowMonumentBuilt.DefaultValue);
			_gNNGateFinished.SetValue(_gNNGateFinished.DefaultValue);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new MonumentsPersistentSaveData(_greyMonumentBuilt.Value, _blueMonumentBuilt.Value, _yellowMonumentBuilt.Value, _gNNGateFinished.Value);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<MonumentsPersistentSaveData>(fullPath);
		}
	}
}
