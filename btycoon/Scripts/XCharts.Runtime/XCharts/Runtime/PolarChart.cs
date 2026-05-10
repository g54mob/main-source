using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[AddComponentMenu("XCharts/PolarChart", 23)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("https://xcharts-team.github.io/docs/configuration")]
	public class PolarChart : BaseChart
	{
		protected override void DefaultChart()
		{
			EnsureChartComponent<PolarCoord>();
			EnsureChartComponent<AngleAxis>();
			EnsureChartComponent<RadiusAxis>();
			Tooltip tooltip = EnsureChartComponent<Tooltip>();
			tooltip.type = Tooltip.Type.Corss;
			tooltip.trigger = Tooltip.Trigger.Axis;
			RemoveData();
			Serie serie = Line.AddDefaultSerie(this, GenerateDefaultSerieName());
			serie.SetCoord<PolarCoord>();
			serie.ClearData();
			for (int i = 0; i <= 360; i++)
			{
				float num = (float)i / 180f * MathF.PI;
				float f = Mathf.Sin(2f * num) * Mathf.Cos(2f * num) * 2f;
				AddData(0, Mathf.Abs(f), i);
			}
		}
	}
}
