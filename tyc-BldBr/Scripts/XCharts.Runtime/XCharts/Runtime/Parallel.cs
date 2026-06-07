using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[SerieHandler(typeof(ParallelHandler), true)]
	[RequireChartComponent(typeof(ParallelCoord))]
	[SerieComponent(typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataComponent(typeof(EmphasisStyle), typeof(BlurStyle), typeof(SelectStyle))]
	[SerieDataExtraField]
	public class Parallel : Serie, INeedSerieContainer
	{
		public int containerIndex { get; internal set; }

		public int containterInstanceId { get; internal set; }

		public static Serie AddDefaultSerie(BaseChart chart, string serieName)
		{
			Parallel parallel = chart.AddSerie<Parallel>(serieName);
			parallel.lineStyle.width = 0.8f;
			parallel.lineStyle.opacity = 0.6f;
			for (int i = 0; i < 100; i++)
			{
				List<double> valueList = new List<double>
				{
					UnityEngine.Random.Range(0f, 50f),
					UnityEngine.Random.Range(0f, 100f),
					UnityEngine.Random.Range(0f, 1000f),
					UnityEngine.Random.Range(0, 5)
				};
				parallel.AddData(valueList, "data" + i);
			}
			chart.RefreshChart();
			return parallel;
		}
	}
}
