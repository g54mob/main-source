using UnityEngine;

namespace XCharts.Runtime
{
	[AddComponentMenu("XCharts/PieChart", 15)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("https://xcharts-team.github.io/docs/configuration")]
	public class PieChart : BaseChart
	{
		protected override void DefaultChart()
		{
			EnsureChartComponent<Legend>().show = true;
			RemoveData();
			Pie.AddDefaultSerie(this, GenerateDefaultSerieName());
		}
	}
}
