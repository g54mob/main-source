using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using XUGL;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class AngleAxisHandler : AxisHandler<AngleAxis>
	{
		public override void InitComponent()
		{
			InitAngleAxis(base.component);
		}

		public override void Update()
		{
			base.component.context.startAngle = 90f - base.component.startAngle;
			UpdateAxisMinMaxValue(base.component);
			UpdatePointerValue(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			DrawAngleAxis(vh, base.component);
		}

		private void UpdateAxisMinMaxValue(AngleAxis axis, bool updateChart = true)
		{
			if (axis.IsCategory() || !axis.show)
			{
				return;
			}
			double minValue = 0.0;
			double maxValue = 0.0;
			SeriesHelper.GetYMinMaxValue(base.chart, axis.polarIndex, isValueAxis: true, axis.inverse, out minValue, out maxValue, isPolar: true);
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

		internal void UpdateAxisLabelText(AngleAxis axis)
		{
			int num = 360;
			if (axis.context.labelObjectList.Count <= 0)
			{
				InitAngleAxis(axis);
			}
			else
			{
				axis.UpdateLabelText(num, null, forcePercent: false);
			}
		}

		private void InitAngleAxis(AngleAxis axis)
		{
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(axis.polarIndex);
			if (chartComponent == null)
			{
				return;
			}
			PolarHelper.UpdatePolarCenter(chartComponent, base.chart.chartPosition, base.chart.chartWidth, base.chart.chartHeight);
			float outsideRadius = chartComponent.context.outsideRadius;
			axis.context.labelObjectList.Clear();
			axis.context.startAngle = 90f - axis.startAngle;
			string text = base.component.GetType().Name + axis.index;
			GameObject gameObject = ChartHelper.AddObject(text, base.chart.transform, base.chart.chartMinAnchor, base.chart.chartMaxAnchor, base.chart.chartPivot, base.chart.chartSizeDelta);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.SetActive(axis.show);
			gameObject.hideFlags = base.chart.chartHideFlags;
			ChartHelper.HideAllObject(gameObject);
			int splitNumber = AxisHelper.GetSplitNumber(axis, outsideRadius, null);
			float num = axis.context.startAngle;
			int num2 = 360;
			Vector3 center = chartComponent.context.center;
			int num3 = axis.axisLabel.textStyle.GetFontSize(base.chart.theme.axis) + 2;
			float num4 = axis.axisLabel.distance + axis.axisTick.GetLength(base.chart.theme.axis.tickLength);
			bool flag = axis.IsCategory();
			bool forcePercent = SeriesHelper.IsPercentStack<Bar>(base.chart.series);
			for (int i = 0; i < splitNumber; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(axis, num2, i + 1);
				_ = axis.axisLabel.inside;
				string labelName = AxisHelper.GetLabelName(axis, num2, i, axis.context.minValue, axis.context.maxValue, null, forcePercent);
				ChartLabel chartLabel = ChartHelper.AddAxisLabelObject(splitNumber, i, text + i, gameObject.transform, new Vector2(scaleWidth, num3), axis, base.chart.theme.axis, labelName, Color.clear);
				chartLabel.text.SetAlignment(axis.axisLabel.textStyle.GetAlignment(TextAnchor.MiddleCenter));
				Vector3 pos = ChartHelper.GetPos(center, outsideRadius + num4, flag ? (num + scaleWidth / 2f) : num, isDegree: true);
				AxisHelper.AdjustCircleLabelPos(chartLabel, pos, center, num3, Vector3.zero);
				if (i == 0)
				{
					axis.axisLabel.SetRelatedText(chartLabel.text, scaleWidth);
				}
				axis.context.labelObjectList.Add(chartLabel);
				num += scaleWidth;
			}
		}

		private void DrawAngleAxis(VertexHelper vh, AngleAxis angleAxis)
		{
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(angleAxis.polarIndex);
			float outsideRadius = chartComponent.context.outsideRadius;
			Vector3 center = chartComponent.context.center;
			int num = 360;
			int scaleNumber = AxisHelper.GetScaleNumber(angleAxis, num);
			float num2 = angleAxis.context.startAngle;
			float width = angleAxis.axisTick.GetWidth(base.chart.theme.axis.tickWidth);
			float length = angleAxis.axisTick.GetLength(base.chart.theme.axis.tickLength);
			Color32 color = angleAxis.axisTick.GetColor(base.chart.theme.axis.lineColor);
			Color32 color2 = angleAxis.axisLine.GetColor(base.chart.theme.axis.lineColor);
			Color32 color3 = angleAxis.splitLine.GetColor(base.chart.theme.axis.splitLineColor);
			for (int i = 1; i < scaleNumber; i++)
			{
				float scaleWidth = AxisHelper.GetScaleWidth(angleAxis, num, i);
				Vector3 pos = ChartHelper.GetPos(center, chartComponent.context.insideRadius, num2, isDegree: true);
				Vector3 pos2 = ChartHelper.GetPos(center, chartComponent.context.outsideRadius, num2, isDegree: true);
				if (angleAxis.show && angleAxis.splitLine.show && angleAxis.splitLine.NeedShow(i - 1, scaleNumber - 1))
				{
					float width2 = angleAxis.splitLine.GetWidth(base.chart.theme.axis.splitLineWidth);
					UGL.DrawLine(vh, pos, pos2, width2, color3);
				}
				if (angleAxis.show && angleAxis.axisTick.show && ((i == 1 && angleAxis.axisTick.showStartTick) || (i == scaleNumber - 1 && angleAxis.axisTick.showEndTick) || (i > 1 && i < scaleNumber - 1)))
				{
					float radius = outsideRadius + length;
					Vector3 pos3 = ChartHelper.GetPos(center, radius, num2, isDegree: true);
					UGL.DrawLine(vh, pos2, pos3, width, color);
				}
				num2 += scaleWidth;
			}
			if (angleAxis.show && angleAxis.axisLine.show)
			{
				float width3 = angleAxis.axisLine.GetWidth(base.chart.theme.axis.lineWidth);
				float outsideRadius2 = outsideRadius + width3 * 2f;
				UGL.DrawDoughnut(vh, center, outsideRadius, outsideRadius2, color2, ColorUtil.clearColor32);
				if (chartComponent.context.insideRadius > 0f)
				{
					outsideRadius = chartComponent.context.insideRadius;
					outsideRadius2 = outsideRadius + width3 * 2f;
					UGL.DrawDoughnut(vh, center, outsideRadius, outsideRadius2, color2, ColorUtil.clearColor32);
				}
			}
		}

		protected override void UpdatePointerValue(Axis axis)
		{
			PolarCoord chartComponent = base.chart.GetChartComponent<PolarCoord>(axis.polarIndex);
			if (chartComponent != null)
			{
				if (!chartComponent.context.isPointerEnter)
				{
					axis.context.pointerValue = double.PositiveInfinity;
					return;
				}
				Vector2 normalized = (base.chart.pointerPos - new Vector2(chartComponent.context.center.x, chartComponent.context.center.y)).normalized;
				float angle = ChartHelper.GetAngle360(Vector2.up, normalized);
				axis.context.pointerValue = (angle - base.component.context.startAngle + 360f) % 360f;
				axis.context.pointerLabelPosition = chartComponent.context.center + new Vector3(normalized.x, normalized.y) * (chartComponent.context.outsideRadius + chartComponent.indicatorLabelOffset);
			}
		}
	}
}
