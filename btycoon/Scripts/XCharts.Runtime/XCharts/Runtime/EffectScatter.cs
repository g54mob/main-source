using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(EffectScatterHandler), true)]
	[CoordOptions(typeof(GridCoord), typeof(SingleAxisCoord))]
	[DefaultTooltip(Tooltip.Type.None, Tooltip.Trigger.Item)]
	[SerieComponent(typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField("m_Radius")]
	public class EffectScatter : BaseScatter
	{
		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			EffectScatter effectScatter = chart.AddSerie<EffectScatter>(serieName);
			effectScatter.symbol.show = true;
			effectScatter.symbol.type = SymbolType.Circle;
			effectScatter.itemStyle.opacity = 0.8f;
			effectScatter.clip = false;
			for (int i = 0; i < 10; i++)
			{
				chart.AddData(effectScatter.index, UnityEngine.Random.Range(10, 100), UnityEngine.Random.Range(10, 100));
			}
			return effectScatter;
		}
	}
}
