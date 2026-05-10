using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(RingHandler), true)]
	[SerieComponent(typeof(LabelStyle), typeof(LabelLine), typeof(TitleStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(ItemStyle), typeof(LabelStyle), typeof(LabelLine), typeof(TitleStyle), typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField]
	public class Ring : Serie
	{
		public override SerieColorBy defaultColorBy => SerieColorBy.Data;

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Ring ring = chart.AddSerie<Ring>(serieName);
			ring.roundCap = true;
			ring.gap = 10f;
			ring.radius = new float[2] { 0.3f, 0.35f };
			LabelStyle labelStyle = ring.EnsureComponent<LabelStyle>();
			labelStyle.show = true;
			labelStyle.position = LabelStyle.Position.Center;
			labelStyle.formatter = "{d:f0}%";
			labelStyle.textStyle.autoColor = true;
			labelStyle.textStyle.fontSize = 28;
			TitleStyle obj = ring.EnsureComponent<TitleStyle>();
			obj.show = false;
			obj.offset = new Vector2(0f, 30f);
			int num = UnityEngine.Random.Range(30, 90);
			int num2 = 100;
			chart.AddData(ring.index, num, num2, "data1");
			return ring;
		}

		public override double GetDataTotal(int dimension, SerieData serieData = null)
		{
			if (serieData == null || serieData.data.Count <= 1)
			{
				return base.GetDataTotal(dimension, serieData);
			}
			return serieData.GetData(1);
		}
	}
}
