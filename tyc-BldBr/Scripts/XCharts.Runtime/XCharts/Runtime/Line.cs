using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(LineHandler), true)]
	[SerieConvert(typeof(Bar), typeof(Pie))]
	[CoordOptions(typeof(GridCoord), typeof(PolarCoord))]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.Line, Tooltip.Trigger.Axis)]
	[SerieDataExtraField("m_State", "m_Ignore")]
	[SerieComponent(typeof(LabelStyle), typeof(EndLabelStyle), typeof(LineArrow), typeof(AreaStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(SerieSymbol), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	public class Line : Serie, INeedSerieContainer
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Line line = chart.AddSerie<Line>(serieName);
			line.symbol.show = true;
			line.animation.interaction.radius.value = 1.5f;
			for (int i = 0; i < 5; i++)
			{
				chart.AddData(line.index, UnityEngine.Random.Range(10, 90));
			}
			return line;
		}

		public static Line ConvertSerie(Serie serie)
		{
			return serie.Clone<Line>();
		}
	}
}
