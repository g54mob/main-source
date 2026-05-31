using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class RadiusAxisHandler : AxisHandler<RadiusAxis>
	{
		public override void InitComponent()
		{
			InitRadiusAxis(base.component);
		}

		public override void Update()
		{
			UpdateAxisMinMaxValue(base.component);
			UpdatePointerValue(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			DrawRadiusAxis(vh, base.component);
		}

		protected override void UpdatePointerValue(Axis axis)
		{
			if (axis == null)
			{
				return;
			}
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(axis.polarIndex);
			if (chartComponent == null)
			{
				return;
			}
			if (!chartComponent.context.isPointerEnter)
			{
				axis.context.pointerValue = double.NaN;
				return;
			}
			AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, chartComponent.index);
			if (angleAxis != null)
			{
				float num = Vector3.Distance(base.chart.pointerPos, chartComponent.context.center);
				axis.context.pointerValue = axis.context.minValue + (double)(num / chartComponent.context.radius) * axis.context.minMaxRange;
				axis.context.pointerLabelPosition = GetLabelPosition(chartComponent, axis, angleAxis.context.startAngle, num);
			}
		}

		private void UpdateAxisMinMaxValue(RadiusAxis axis, bool updateChart = true)
		{
			if (axis == null || axis.IsCategory() || !axis.show)
			{
				return;
			}
			double minValue = 0.0;
			double maxValue = 0.0;
			SeriesHelper.GetXMinMaxValue(base.chart, axis.polarIndex, isValueAxis: true, axis.inverse, out minValue, out maxValue, isPolar: true);
			AxisHelper.AdjustMinMaxValue(axis, ref minValue, ref maxValue, needFormat: true);
			if (minValue != axis.context.minValue || maxValue != axis.context.maxValue)
			{
				axis.UpdateMinMaxValue(minValue, maxValue);
				axis.context.offset = 0f;
				axis.context.lastCheckInverse = axis.inverse;
				UpdateAxisTickValueList(axis);
				if (updateChart)
				{
					UpdateAxisLabelText(axis);
					base.chart.RefreshChart();
				}
			}
		}

		internal void UpdateAxisLabelText(RadiusAxis axis)
		{
			if (axis != null)
			{
				PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(axis.polarIndex);
				if (axis.context.labelObjectList.Count <= 0)
				{
					InitRadiusAxis(axis);
				}
				else
				{
					axis.UpdateLabelText(chartComponent.context.radius, null, forcePercent: false);
				}
			}
		}

		private void InitRadiusAxis(RadiusAxis axis)
		{
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(axis.index);
			if (chartComponent == null)
			{
				return;
			}
			AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, chartComponent.index);
			if (angleAxis == null)
			{
				return;
			}
			PolarHelper.UpdatePolarCenter(chartComponent, base.chart.chartPosition, base.chart.chartWidth, base.chart.chartHeight);
			axis.context.labelObjectList.Clear();
			float coordinateWidth = chartComponent.context.outsideRadius - chartComponent.context.insideRadius;
			string text = base.component.GetType().Name + axis.index;
			GameObject gameObject = ChartHelper.AddObject(text, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.SetActive(axis.show && axis.axisLabel.show);
			gameObject.hideFlags = base.chart.chartHideFlags;
			ChartHelper.HideAllObject(gameObject);
			TextStyle textStyle = axis.axisLabel.textStyle;
			int scaleNumber = AxisHelper.GetScaleNumber(axis, coordinateWidth);
			float num = chartComponent.context.insideRadius;
			int num2 = textStyle.GetFontSize(base.chart.theme.axis) + 2;
			for (int i = 0; i < scaleNumber; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(axis, coordinateWidth, i + 1);
				_ = axis.axisLabel.inside;
				bool forcePercent = SeriesHelper.IsPercentStack<Bar>(base.chart.series);
				string labelName = AxisHelper.GetLabelName(axis, coordinateWidth, i, axis.context.minValue, axis.context.maxValue, null, forcePercent);
				ChartLabel chartLabel = ChartHelper.AddAxisLabelObject(scaleNumber, i, text + i, gameObject.transform, new Vector2(scaleWidth, num2), axis, base.chart.theme.axis, labelName, Color.clear);
				if (i == 0)
				{
					axis.axisLabel.SetRelatedText(chartLabel.text, scaleWidth);
				}
				chartLabel.text.SetAlignment(textStyle.GetAlignment(TextAnchor.MiddleCenter));
				chartLabel.SetText(labelName);
				chartLabel.SetPosition(GetLabelPosition(chartComponent, axis, angleAxis.context.startAngle, num));
				chartLabel.SetActive(flag: true);
				chartLabel.SetTextActive(flag: true);
				axis.context.labelObjectList.Add(chartLabel);
				num += scaleWidth;
			}
		}

		private Vector3 GetLabelPosition(PolarCoord polar, Axis axis, float startAngle, float totalWidth)
		{
			Vector3 center = polar.context.center;
			Vector3 normalized = ChartHelper.GetDire(startAngle, isDegree: true).normalized;
			float length = axis.axisTick.GetLength(base.chart.theme.axis.tickLength);
			Vector3 vector = ChartHelper.GetVertialDire(normalized) * (length + axis.axisLabel.distance);
			if (axis.IsCategory())
			{
				totalWidth += polar.context.radius / (float)axis.data.Count / 2f;
			}
			return ChartHelper.GetPos(center, totalWidth, startAngle, isDegree: true) + vector;
		}

		private void DrawRadiusAxis(VertexHelper vh, RadiusAxis radiusAxis)
		{
			if (radiusAxis == null)
			{
				return;
			}
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(radiusAxis.polarIndex);
			if (chartComponent == null)
			{
				return;
			}
			AngleAxis angleAxis = ComponentHelper.GetAngleAxis(base.chart.components, chartComponent.index);
			if (angleAxis == null)
			{
				return;
			}
			float startAngle = angleAxis.context.startAngle;
			float radius = chartComponent.context.radius;
			Vector3 center = chartComponent.context.center;
			int scaleNumber = AxisHelper.GetScaleNumber(radiusAxis, radius);
			float num = chartComponent.context.insideRadius;
			Vector3 normalized = ChartHelper.GetDire(startAngle, isDegree: true).normalized;
			float width = radiusAxis.axisTick.GetWidth(base.chart.theme.axis.tickWidth);
			float length = radiusAxis.axisTick.GetLength(base.chart.theme.axis.tickLength);
			Vector3 vector = ChartHelper.GetVertialDire(normalized) * length;
			for (int i = 0; i < scaleNumber; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(radiusAxis, radius, i + 1);
				Vector3 pos = ChartHelper.GetPos(center, num + width, startAngle, isDegree: true);
				if (radiusAxis.show && radiusAxis.splitLine.show && CanDrawSplitLine(angleAxis, i, scaleNumber) && radiusAxis.splitLine.NeedShow(i, scaleNumber))
				{
					float outsideRadius = num + radiusAxis.splitLine.GetWidth(base.chart.theme.axis.splitLineWidth) * 2f;
					Color32 color = radiusAxis.splitLine.GetColor(base.chart.theme.axis.splitLineColor);
					UGL.DrawDoughnut(vh, center, num, outsideRadius, color, Color.clear);
				}
				if (radiusAxis.show && radiusAxis.axisTick.show && ((i == 0 && radiusAxis.axisTick.showStartTick) || (i == scaleNumber && radiusAxis.axisTick.showEndTick) || (i > 0 && i < scaleNumber)))
				{
					UGL.DrawLine(vh, pos, pos + vector, width, base.chart.theme.axis.lineColor);
				}
				num += scaleWidth;
			}
			if (radiusAxis.show && radiusAxis.axisLine.show)
			{
				Vector3 startPoint = chartComponent.context.center + normalized * chartComponent.context.insideRadius;
				Vector3 endPoint = chartComponent.context.center + normalized * (chartComponent.context.outsideRadius + 2f * width);
				float width2 = radiusAxis.axisLine.GetWidth(base.chart.theme.axis.lineWidth);
				UGL.DrawLine(vh, startPoint, endPoint, width2, base.chart.theme.axis.lineColor);
			}
		}

		private bool CanDrawSplitLine(AngleAxis angleAxis, int i, int size)
		{
			if (angleAxis.axisLine.show)
			{
				if (i != size - 1)
				{
					return i != 0;
				}
				return false;
			}
			return true;
		}
	}
}
