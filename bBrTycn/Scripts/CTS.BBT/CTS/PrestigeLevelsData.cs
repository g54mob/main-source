using System.Collections.Generic;
using System.Linq;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public abstract class PrestigeLevelsData : DataImporter
	{
		[field: SerializeField]
		public List<PrestigeLevelData> PrestigeSteps { get; protected set; } = new List<PrestigeLevelData>();

		public float MaxPrestigeRequired => PrestigeSteps.Last().PrestigeRequired;

		public float GetNextStepFrom(PrestigeLevelData data)
		{
			int num = PrestigeSteps.IndexOf(data);
			if (!num.IsCorrectArrayIndex(PrestigeSteps))
			{
				return data.PrestigeRequired;
			}
			if (num >= PrestigeSteps.Count - 1)
			{
				return data.PrestigeRequired;
			}
			return PrestigeSteps[num + 1].PrestigeRequired;
		}

		public int GetTotalMaxPopulation(bool isVampire)
		{
			if (PrestigeSteps.Count <= 0)
			{
				return 0;
			}
			return PrestigeSteps.Last().MaxCustomerPopulation(isVampire);
		}
	}
}
