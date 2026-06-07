using UnityEngine;
using Utility;

namespace UIScripts.UIReferences.LineagePanel
{
	public struct SpeciesRungData
	{
		public int count;

		public float countShare;

		public float energy;

		public float energyShare;

		public int index;

		public SpeciesRungData(SpeciesDataPoint info, float rungTotalEnergy, int rungTotalCount, int rungIndex)
		{
			count = info.count;
			energy = info.energy;
			countShare = (float)count / Mathf.Max(rungTotalCount, 1f);
			energyShare = energy / Mathf.Max(rungTotalEnergy, 1f);
			index = rungIndex;
		}

		public static SpeciesRungData EmptyRung(int rungIndex)
		{
			return new SpeciesRungData
			{
				count = 0,
				countShare = 0f,
				energy = 0f,
				energyShare = 0f,
				index = rungIndex
			};
		}

		public string Text()
		{
			string text = DataLogger.SerialSpeciesConfig.TimeOfPointInSerialConfig(index).FormattedTimeValue(1, " ", smallUnits: true, spaceBeforeUnits: false, Timescale.Minutes) + " ago";
			return string.Format("{0}\nCount: {1}  ({2:F1}%)\n\rEnergy: {3:F0} E  ({4:F1}%)", (index < 0) ? "now" : text, count, countShare * 100f, energy, energyShare * 100f);
		}
	}
}
