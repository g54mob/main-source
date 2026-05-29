using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "ValueExchangeBlood", menuName = "BBT/ExchangeData", order = 1)]
	public class ExchangeData : ScriptableObject
	{
		[field: SerializeField]
		public List<ExchangeStruct> ValueExchangeBloodData { get; private set; }

		public int GiveTheValueOfTheQuality(int LevelOfQuality)
		{
			int result = 0;
			foreach (ExchangeStruct valueExchangeBloodDatum in ValueExchangeBloodData)
			{
				if (valueExchangeBloodDatum.QualityLevel == LevelOfQuality)
				{
					result = (int)valueExchangeBloodDatum.ValueQuality;
				}
			}
			return result;
		}
	}
}
