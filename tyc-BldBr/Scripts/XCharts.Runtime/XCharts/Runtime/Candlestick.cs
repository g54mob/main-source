using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(CandlestickHandler), true)]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.Shadow, Tooltip.Trigger.Axis)]
	[SerieComponent]
	[SerieDataComponent(typeof(ItemStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField]
	public class Candlestick : Serie, INeedSerieContainer
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Candlestick candlestick = chart.AddSerie<Candlestick>(serieName);
			int num = 5;
			for (int i = 0; i < num; i++)
			{
				int num2 = UnityEngine.Random.Range(20, 60);
				int num3 = UnityEngine.Random.Range(40, 90);
				int num4 = UnityEngine.Random.Range(0, 50);
				int num5 = UnityEngine.Random.Range(50, 100);
				chart.AddData(candlestick.index, i, num2, num3, num4, num5);
			}
			return candlestick;
		}
	}
}
