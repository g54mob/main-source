using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(SimplifiedLineHandler), true)]
	[SerieConvert(typeof(SimplifiedBar), typeof(Line))]
	[CoordOptions(typeof(GridCoord))]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.Line, Tooltip.Trigger.Axis)]
	[SerieComponent(typeof(AreaStyle))]
	[SerieDataComponent]
	[SerieDataExtraField]
	public class SimplifiedLine : Serie, INeedSerieContainer, ISimplifiedSerie
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			SimplifiedLine simplifiedLine = chart.AddSerie<SimplifiedLine>(serieName);
			simplifiedLine.symbol.show = false;
			double num = 0.0;
			for (int i = 0; i < 50; i++)
			{
				num = ((i >= 20) ? (num + (double)UnityEngine.Random.Range(-3, 5)) : (num + (double)UnityEngine.Random.Range(0, 5)));
				chart.AddData(simplifiedLine.index, num);
			}
			return simplifiedLine;
		}

		public static SimplifiedLine ConvertSerie(Serie serie)
		{
			return serie.Clone<SimplifiedLine>();
		}
	}
}
