using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(SimplifiedCandlestickHandler), true)]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.Shadow, Tooltip.Trigger.Axis)]
	[SerieComponent]
	[SerieDataComponent]
	[SerieDataExtraField]
	public class SimplifiedCandlestick : Serie, INeedSerieContainer, ISimplifiedSerie
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			SimplifiedCandlestick simplifiedCandlestick = chart.AddSerie<SimplifiedCandlestick>(serieName);
			double num = 50.0;
			for (int i = 0; i < 50; i++)
			{
				num += (double)UnityEngine.Random.Range(-10, 20);
				double open = num + (double)UnityEngine.Random.Range(-10, 5);
				double close = num + (double)UnityEngine.Random.Range(-5, 10);
				double lowest = num + (double)UnityEngine.Random.Range(-15, -10);
				double heighest = num + (double)UnityEngine.Random.Range(10, 20);
				chart.AddData(simplifiedCandlestick.index, i, open, close, lowest, heighest);
			}
			return simplifiedCandlestick;
		}

		public static SimplifiedCandlestick ConvertSerie(Serie serie)
		{
			return serie.Clone<SimplifiedCandlestick>();
		}
	}
}
