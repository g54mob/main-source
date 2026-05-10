using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(ScatterHandler), true)]
	[CoordOptions(typeof(GridCoord), typeof(SingleAxisCoord))]
	[DefaultTooltip(Tooltip.Type.None, Tooltip.Trigger.Item)]
	[SerieComponent(typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField("m_Radius")]
	public class Scatter : BaseScatter
	{
		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Scatter scatter = chart.AddSerie<Scatter>(serieName);
			scatter.symbol.show = true;
			scatter.symbol.type = SymbolType.Circle;
			scatter.itemStyle.opacity = 0.8f;
			scatter.clip = false;
			for (int i = 0; i < 10; i++)
			{
				chart.AddData(scatter.index, UnityEngine.Random.Range(10, 100), UnityEngine.Random.Range(10, 100));
			}
			return scatter;
		}
	}
}
