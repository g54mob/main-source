using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(HeatmapHandler), true)]
	[DefaultAnimation(AnimationType.LeftToRight, false)]
	[DefaultTooltip(Tooltip.Type.None, Tooltip.Trigger.Axis)]
	[RequireChartComponent(typeof(VisualMap))]
	[CoordOptions(typeof(GridCoord), typeof(PolarCoord))]
	[SerieComponent(typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField]
	public class Heatmap : Serie, INeedSerieContainer
	{
		[SerializeField]
		[Since("v3.3.0")]
		private HeatmapType m_HeatmapType;

		public HeatmapType heatmapType
		{
			get
			{
				return m_HeatmapType;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_HeatmapType, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Heatmap heatmap = chart.AddSerie<Heatmap>(serieName);
			heatmap.itemStyle.show = true;
			heatmap.itemStyle.borderWidth = 1f;
			heatmap.itemStyle.borderColor = Color.clear;
			return heatmap;
		}
	}
}
