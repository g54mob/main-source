using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[CreateAssetMenu(menuName = "XCharts/Export Lang")]
	public class Lang : ScriptableObject
	{
		public string langName = "EN";

		public LangTime time = new LangTime();

		public LangCandlestick candlestick = new LangCandlestick();

		public string GetMonthAbbr(int month)
		{
			if (month < 1 && month > 12)
			{
				return month.ToString();
			}
			return time.monthAbbr[month - 1];
		}

		public string GetDay(int day)
		{
			day--;
			if (day >= 0 && day < time.dayOfMonth.Count - 1)
			{
				return time.dayOfMonth[day];
			}
			return day.ToString();
		}

		public string GetCandlestickDimensionName(int i)
		{
			if (i >= 0 && i < candlestick.dimensionNames.Count)
			{
				return candlestick.dimensionNames[i];
			}
			return string.Empty;
		}
	}
}
