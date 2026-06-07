using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(RadarHandler), true)]
	[RequireChartComponent(typeof(RadarCoord))]
	[SerieComponent(typeof(LabelStyle), typeof(AreaStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(AreaStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField]
	public class Radar : Serie, INeedSerieContainer
	{
		[SerializeField]
		[Since("v3.2.0")]
		private bool m_Smooth;

		public bool smooth
		{
			get
			{
				return m_Smooth;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Smooth, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public override SerieColorBy defaultColorBy
		{
			get
			{
				if (base.radarType != RadarType.Multiple)
				{
					return SerieColorBy.Serie;
				}
				return SerieColorBy.Data;
			}
		}

		public override bool multiDimensionLabel => base.radarType == RadarType.Multiple;

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			chart.EnsureChartComponent<RadarCoord>();
			Radar radar = chart.AddSerie<Radar>(serieName);
			radar.symbol.show = true;
			radar.symbol.type = SymbolType.Circle;
			radar.showDataName = true;
			List<double> list = new List<double>();
			for (int i = 0; i < 5; i++)
			{
				list.Add(UnityEngine.Random.Range(20, 90));
			}
			chart.AddData(radar.index, list, "legendName");
			return radar;
		}
	}
}
