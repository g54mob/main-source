using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(SimplifiedBarHandler), true)]
	[SerieConvert(typeof(SimplifiedLine), typeof(Bar))]
	[CoordOptions(typeof(GridCoord))]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.Shadow, Tooltip.Trigger.Axis)]
	[SerieComponent]
	[SerieDataComponent]
	[SerieDataExtraField]
	public class SimplifiedBar : Serie, INeedSerieContainer, ISimplifiedSerie
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			SimplifiedBar simplifiedBar = chart.AddSerie<SimplifiedBar>(serieName);
			simplifiedBar.symbol.show = false;
			double num = 0.0;
			for (int i = 0; i < 50; i++)
			{
				num = ((i >= 20) ? (num + (double)UnityEngine.Random.Range(-3, 5)) : (num + (double)UnityEngine.Random.Range(0, 5)));
				chart.AddData(simplifiedBar.index, num);
			}
			return simplifiedBar;
		}

		public static SimplifiedBar ConvertSerie(Serie serie)
		{
			return serie.Clone<SimplifiedBar>();
		}
	}
}
