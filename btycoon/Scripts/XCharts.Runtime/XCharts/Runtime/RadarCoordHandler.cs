using System;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class RadarCoordHandler : MainComponentHandler<RadarCoord>
	{
		private const string INDICATOR_TEXT = "indicator";

		public override void InitComponent()
		{
			InitRadarCoord(base.component);
		}

		public override void Update()
		{
			base.Update();
			if (!base.chart.isPointerInChart)
			{
				base.component.context.isPointerEnter = false;
				return;
			}
			RadarCoord radarCoord = base.component;
			radarCoord.context.isPointerEnter = radarCoord.show && Vector3.Distance(radarCoord.context.center, base.chart.pointerPos) <= radarCoord.context.radius;
		}

		public override void DrawBase(VertexHelper vh)
		{
			DrawRadarCoord(vh, base.component);
		}

		private void InitRadarCoord(RadarCoord radar)
		{
			float txtHig = 20f;
			radar.painter = base.chart.GetPainter(radar.index);
			radar.refreshComponent = delegate
			{
				radar.UpdateRadarCenter(base.chart);
				GameObject gameObject = ChartHelper.AddObject("Radar" + radar.index, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
				radar.gameObject = gameObject;
				radar.gameObject.hideFlags = base.chart.chartHideFlags;
				ChartHelper.HideAllObject(gameObject.transform, "indicator");
				for (int i = 0; i < radar.indicatorList.Count; i++)
				{
					_ = radar.indicatorList[i];
					Vector3 indicatorPosition = radar.GetIndicatorPosition(i);
					ChartLabel chartLabel = ChartHelper.AddChartLabel("indicator_" + i, gameObject.transform, radar.axisName.labelStyle, base.chart.theme.common, radar.GetFormatterIndicatorContent(i), Color.clear);
					chartLabel.SetActive(radar.axisName.show && radar.indicator && radar.axisName.labelStyle.show);
					AxisHelper.AdjustCircleLabelPos(chartLabel, indicatorPosition, radar.context.center, txtHig, radar.axisName.labelStyle.offset);
				}
				base.chart.RefreshBasePainter();
			};
			radar.refreshComponent();
		}

		private void DrawRadarCoord(VertexHelper vh, RadarCoord radar)
		{
			if (radar.show)
			{
				radar.UpdateRadarCenter(base.chart);
				if (radar.shape == RadarCoord.Shape.Circle)
				{
					DrawCricleRadar(vh, radar);
				}
				else
				{
					DrawPolygonRadar(vh, radar);
				}
			}
		}

		private void DrawCricleRadar(VertexHelper vh, RadarCoord radar)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = radar.context.radius / (float)radar.splitNumber;
			int count = radar.indicatorList.Count;
			Vector3 center = radar.context.center;
			float num4 = MathF.PI * 2f / (float)count;
			Color32 color = radar.axisLine.GetColor(base.chart.theme.axis.splitLineColor);
			float width = radar.axisLine.GetWidth(base.chart.theme.axis.lineWidth);
			LineStyle.Type type = radar.axisLine.GetType(base.chart.theme.axis.lineType);
			Color32 color2 = radar.splitLine.GetColor(base.chart.theme.axis.splitLineColor);
			float width2 = radar.splitLine.GetWidth(base.chart.theme.axis.splitLineWidth);
			width2 *= 2f;
			for (int i = 0; i < radar.splitNumber; i++)
			{
				Color32 color3 = radar.splitArea.GetColor(i, base.chart.theme.axis);
				num2 = num + num3;
				if (radar.splitArea.show)
				{
					UGL.DrawDoughnut(vh, center, num, num2, color3, Color.clear, 0f, 360f, base.chart.settings.cicleSmoothness);
				}
				if (radar.splitLine.show)
				{
					UGL.DrawEmptyCricle(vh, center, num2, width2, color2, Color.clear, base.chart.settings.cicleSmoothness);
				}
				num = num2;
			}
			if (radar.axisLine.show)
			{
				for (int j = 0; j <= count; j++)
				{
					float f = (float)j * num4;
					ChartDrawer.DrawLineStyle(endPos: new Vector3(center.x + num2 * Mathf.Sin(f), center.y + num2 * Mathf.Cos(f)), vh: vh, lineType: type, lineWidth: width, startPos: center, color: color);
				}
			}
		}

		private void DrawPolygonRadar(VertexHelper vh, RadarCoord radar)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = radar.context.radius / (float)radar.splitNumber;
			int count = radar.indicatorList.Count;
			Vector3 center = radar.context.center;
			float num4 = radar.startAngle * MathF.PI / 180f;
			float num5 = MathF.PI * 2f / (float)count;
			Color32 color = radar.axisLine.GetColor(base.chart.theme.axis.splitLineColor);
			float width = radar.axisLine.GetWidth(base.chart.theme.axis.lineWidth);
			LineStyle.Type type = radar.axisLine.GetType(base.chart.theme.axis.lineType);
			Color32 color2 = radar.splitLine.GetColor(base.chart.theme.axis.splitLineColor);
			float width2 = radar.splitLine.GetWidth(base.chart.theme.axis.splitLineWidth);
			LineStyle.Type type2 = radar.splitLine.GetType(base.chart.theme.axis.splitLineType);
			for (int i = 0; i < radar.splitNumber; i++)
			{
				Color32 color3 = radar.splitArea.GetColor(i, base.chart.theme.axis);
				num2 = num + num3;
				Vector3 p = new Vector3(center.x + num * Mathf.Sin(num4), center.y + num * Mathf.Cos(num4));
				Vector3 vector = new Vector3(center.x + num2 * Mathf.Sin(num4), center.y + num2 * Mathf.Cos(num4));
				for (int j = 0; j <= count; j++)
				{
					float f = num4 + (float)j * num5;
					Vector3 vector2 = new Vector3(center.x + num2 * Mathf.Sin(f), center.y + num2 * Mathf.Cos(f));
					Vector3 vector3 = new Vector3(center.x + num * Mathf.Sin(f), center.y + num * Mathf.Cos(f));
					if (radar.splitArea.show)
					{
						UGL.DrawQuadrilateral(vh, p, vector, vector2, vector3, color3);
					}
					if (radar.splitLine.NeedShow(i, radar.splitNumber))
					{
						ChartDrawer.DrawLineStyle(vh, type2, width2, vector, vector2, color2);
					}
					p = vector3;
					vector = vector2;
				}
				num = num2;
			}
			if (radar.axisLine.show)
			{
				for (int k = 0; k <= count; k++)
				{
					float f2 = num4 + (float)k * num5;
					ChartDrawer.DrawLineStyle(endPos: new Vector3(center.x + num2 * Mathf.Sin(f2), center.y + num2 * Mathf.Cos(f2)), vh: vh, lineType: type, lineWidth: width, startPos: center, color: color);
				}
			}
		}
	}
}
