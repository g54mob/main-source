using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[AddComponentMenu("XCharts/ParallelChart", 25)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("https://xcharts-team.github.io/docs/configuration")]
	public class ParallelChart : BaseChart
	{
		protected override void DefaultChart()
		{
			RemoveData();
			AddChartComponent<ParallelCoord>();
			for (int i = 0; i < 3; i++)
			{
				AddChartComponent<ParallelAxis>().type = Axis.AxisType.Value;
			}
			ParallelAxis parallelAxis = AddChartComponent<ParallelAxis>();
			parallelAxis.type = Axis.AxisType.Category;
			parallelAxis.position = Axis.AxisPosition.Right;
			parallelAxis.data = new List<string> { "x1", "x2", "x3", "x4", "x5" };
			Parallel.AddDefaultSerie(this, GenerateDefaultSerieName());
		}
	}
}
