using System;
using System.Collections.Generic;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class ValueModifiersSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<int> UpdateSpeedFrequencies;

		public List<int> IntVariables;

		public List<bool> BoolVariables;

		public ValueModifiersSaveData(List<int> updateSpeedFrequencies, List<int> intVariables, List<bool> boolVariables)
			: base(0)
		{
			UpdateSpeedFrequencies = updateSpeedFrequencies;
			IntVariables = intVariables;
			BoolVariables = boolVariables;
		}
	}
}
