using System.Collections.Generic;
using Data.FactoryFloor.Drones.Freighter.SaveStateDtos;
using Data.FactoryFloor.Freighter;
using Data.Variables;
using Logic.Freighter;
using Presentation.Locators;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Freighters", fileName = "FreightersPersistentSO")]
	public class FreightersPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private IntVariableSO _maxFreighterAmount;

		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		private FreightersSaveData _freightersSaveData;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
		}

		private void OnFreightersManagerExists(FreightersManager manager)
		{
			manager.ApplySaveData(_freightersSaveData);
		}

		public override void ResetToDefaults()
		{
			_maxFreighterAmount.SetValue(_maxFreighterAmount.DefaultValue);
		}

		public override AbstractSaveData GetSaveData()
		{
			List<FreighterObjectSaveStateDto> list = new List<FreighterObjectSaveStateDto>();
			foreach (FreighterObject freighter in _freightersManagerLocator.Manager.Freighters)
			{
				list.Add(freighter.GetSaveState());
			}
			return new FreightersSaveData(_maxFreighterAmount.Value, list);
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<FreightersSaveData>(fullPath);
		}
	}
}
