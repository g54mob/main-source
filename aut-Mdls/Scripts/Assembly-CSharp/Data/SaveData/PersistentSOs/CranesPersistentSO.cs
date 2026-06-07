using Data.Variables.Cranes;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Cranes", fileName = "CranesPersistentSO")]
	public class CranesPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private CraneMaxAmountPerBuilding _craneMaxAmountPerBuilding;

		[SerializeField]
		private CraneMaxReach _craneMaxReach;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			CranesSaveData cranesSaveData = saveData as CranesSaveData;
			_craneMaxAmountPerBuilding.SetValue(cranesSaveData.MaxAmountPerBuilding);
			_craneMaxReach.SetValue(cranesSaveData.MaxReach);
		}

		public override void ResetToDefaults()
		{
			_craneMaxAmountPerBuilding.SetValue(_craneMaxAmountPerBuilding.DefaultValue);
			_craneMaxReach.SetValue(_craneMaxReach.DefaultValue);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new CranesSaveData(_craneMaxAmountPerBuilding.Value, _craneMaxReach.Value);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<CranesSaveData>(fullPath);
		}
	}
}
