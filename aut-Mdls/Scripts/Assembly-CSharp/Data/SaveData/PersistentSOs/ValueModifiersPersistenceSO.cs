using System.Collections.Generic;
using System.Linq;
using Data.Variables;
using UnityEngine;
using Utils;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Value Modifiers", fileName = "ValueModifiersPersistenceSO", order = 0)]
	public class ValueModifiersPersistenceSO : AbstractPersistentSO
	{
		[SerializeField]
		private List<IntVariableSO> _updateFrequencyValues;

		[SerializeField]
		private List<IntVariableSO> _intVariables;

		[SerializeField]
		private List<BoolVariableSO> _boolVariables;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			ValueModifiersSaveData valueModifiersSaveData = saveData as ValueModifiersSaveData;
			for (int i = 0; i < _updateFrequencyValues.Count; i++)
			{
				if (valueModifiersSaveData.UpdateSpeedFrequencies.IsNullOrEmpty())
				{
					break;
				}
				if (valueModifiersSaveData.UpdateSpeedFrequencies.Count <= i)
				{
					break;
				}
				_updateFrequencyValues[i].SetValue(valueModifiersSaveData.UpdateSpeedFrequencies[i]);
			}
			for (int j = 0; j < _intVariables.Count; j++)
			{
				if (valueModifiersSaveData.IntVariables.IsNullOrEmpty())
				{
					break;
				}
				if (valueModifiersSaveData.IntVariables.Count <= j)
				{
					break;
				}
				_intVariables[j].SetValue(valueModifiersSaveData.IntVariables[j]);
			}
			for (int k = 0; k < _boolVariables.Count; k++)
			{
				if (valueModifiersSaveData.BoolVariables.IsNullOrEmpty())
				{
					break;
				}
				if (valueModifiersSaveData.BoolVariables.Count <= k)
				{
					break;
				}
				_boolVariables[k].SetValue(valueModifiersSaveData.BoolVariables[k]);
			}
		}

		public override void ResetToDefaults()
		{
			foreach (IntVariableSO updateFrequencyValue in _updateFrequencyValues)
			{
				if (!(updateFrequencyValue == null))
				{
					updateFrequencyValue.SetValue(updateFrequencyValue.DefaultValue);
				}
			}
			foreach (IntVariableSO intVariable in _intVariables)
			{
				if (!(intVariable == null))
				{
					intVariable.SetValue(intVariable.DefaultValue);
				}
			}
			foreach (BoolVariableSO boolVariable in _boolVariables)
			{
				if (!(boolVariable == null))
				{
					boolVariable.SetValue(boolVariable.DefaultValue);
				}
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			return new ValueModifiersSaveData(_updateFrequencyValues.Select((IntVariableSO so) => (so != null) ? so.Value : 0).ToList(), _intVariables.Select((IntVariableSO so) => (so != null) ? so.Value : 0).ToList(), _boolVariables.Select((BoolVariableSO so) => so != null && so.Value).ToList());
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<ValueModifiersSaveData>(fullPath);
		}
	}
}
