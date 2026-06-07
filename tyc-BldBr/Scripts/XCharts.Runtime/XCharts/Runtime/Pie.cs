using System;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieConvert(typeof(Line), typeof(Bar))]
	[SerieHandler(typeof(PieHandler), true)]
	[DefaultAnimation(AnimationType.Clockwise)]
	[SerieComponent(typeof(LabelStyle), typeof(LabelLine), typeof(TitleStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(LabelLine), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField("m_Ignore", "m_Selected", "m_Radius")]
	public class Pie : Serie
	{
		public override SerieColorBy defaultColorBy => SerieColorBy.Data;

		public override bool titleJustForSerie => true;

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Pie pie = chart.AddSerie<Pie>(serieName);
			chart.AddData(pie.index, 70.0, "pie1");
			chart.AddData(pie.index, 20.0, "pie2");
			chart.AddData(pie.index, 10.0, "pie3");
			return pie;
		}

		public static Pie ConvertSerie(Serie serie)
		{
			return SerieHelper.CloneSerie<Pie>(serie);
		}
	}
}
