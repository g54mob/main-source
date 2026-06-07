#define ENABLE_DEBUG_LOGS
#define ENABLE_DEBUG_ERRORS
using Data.Variables;
using Data.Variables.Milestones;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/General", fileName = "GeneralPersistentSO", order = 0)]
	public class GeneralPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private BoolVariableSO _startedTutorial;

		[SerializeField]
		private SupportersEditionModalVariableSO _supportersEditionModalVariableSO;

		[SerializeField]
		private GDPRModalVariableSO _gdprModalVariableSo;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			if (!(saveData is GeneralSaveData generalSaveData))
			{
				this.LogError("Could not convert savedata to general-savedata", "ApplyLoadedSaveData", 20);
				return;
			}
			_startedTutorial.SetValue(generalSaveData.StartedTutorial);
			_supportersEditionModalVariableSO.SetValue(generalSaveData.SupportersEditionModal);
			_gdprModalVariableSo.SetValue(generalSaveData.GDPRModal);
		}

		public override void ResetToDefaults()
		{
			this.Log("ResetToDefaults", "ResetToDefaults", 31);
			_startedTutorial.SetValue(_startedTutorial.DefaultValue);
			_supportersEditionModalVariableSO.SetValue(_supportersEditionModalVariableSO.DefaultValue);
			_gdprModalVariableSo.SetValue(_gdprModalVariableSo.DefaultValue);
		}

		public override AbstractSaveData GetSaveData()
		{
			return new GeneralSaveData(_startedTutorial.Value, _supportersEditionModalVariableSO.Value, _gdprModalVariableSo.Value);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<GeneralSaveData>(fullPath);
		}
	}
}
