using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[AddComponentMenu("XCharts/HeatmapChart", 18)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("https://xcharts-team.github.io/docs/configuration")]
	public class HeatmapChart : BaseChart
	{
		protected override void DefaultChart()
		{
			GridCoord gridCoord = EnsureChartComponent<GridCoord>();
			gridCoord.left = 0.12f;
			XAxis xAxis = EnsureChartComponent<XAxis>();
			xAxis.type = Axis.AxisType.Category;
			xAxis.boundaryGap = true;
			xAxis.splitNumber = 10;
			YAxis yAxis = EnsureChartComponent<YAxis>();
			yAxis.type = Axis.AxisType.Category;
			yAxis.boundaryGap = true;
			yAxis.splitNumber = 10;
			RemoveData();
			float num = 10f;
			int num2 = (int)(gridCoord.context.width / num);
			int num3 = (int)(gridCoord.context.height / num);
			Heatmap.AddDefaultSerie(this, GenerateDefaultSerieName());
			VisualMap visualMap = EnsureChartComponent<VisualMap>();
			visualMap.autoMinMax = true;
			visualMap.orient = Orient.Vertical;
			visualMap.calculable = true;
			visualMap.location.align = Location.Align.BottomLeft;
			visualMap.location.bottom = 100f;
			visualMap.location.left = 30f;
			List<string> colors = new List<string>
			{
				"#313695", "#4575b4", "#74add1", "#abd9e9", "#e0f3f8", "#ffffbf", "#fee090", "#fdae61", "#f46d43", "#d73027",
				"#a50026"
			};
			visualMap.AddColors(colors);
			for (int i = 0; i < num2; i++)
			{
				xAxis.data.Add((i + 1).ToString());
			}
			for (int j = 0; j < num3; j++)
			{
				yAxis.data.Add((j + 1).ToString());
			}
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num3; l++)
				{
					int num4 = Random.Range(0, 150);
					List<double> multidimensionalData = new List<double> { k, l, num4 };
					AddData(0, multidimensionalData);
				}
			}
		}
	}
}
