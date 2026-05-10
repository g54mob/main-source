using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class YAxisHander : AxisHandler<YAxis>
	{
		protected override Orient orient => Orient.Vertical;

		public override void InitComponent()
		{
			InitYAxis(base.component);
		}

		public override void Update()
		{
			UpdateAxisMinMaxValue(base.component.index, base.component);
			UpdatePointerValue(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			UpdatePosition(base.component);
			DrawYAxisSplit(vh, base.component.index, base.component);
			DrawYAxisLine(vh, base.component.index, base.component);
			DrawYAxisTick(vh, base.component.index, base.component);
		}

		private void UpdatePosition(YAxis axis)
		{
			GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (chartComponent != null)
			{
				XAxis chartComponent2 = base.chart.GetChartComponent<XAxis>(axis.gridIndex);
				axis.context.x = AxisHelper.GetYAxisXOrY(chartComponent, axis, chartComponent2);
				axis.context.y = chartComponent.context.y;
				axis.context.zeroX = axis.context.x;
				axis.context.zeroY = axis.context.y + axis.context.offset;
			}
		}

		private void InitYAxis(YAxis yAxis)
		{
			_ = base.chart.theme;
			_ = yAxis.index;
			yAxis.painter = base.chart.painter;
			yAxis.refreshComponent = delegate
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
				if (chartComponent != null)
				{
					YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(yAxis.index);
					InitAxis(chartComponent2, orient, chartComponent.context.x, chartComponent.context.y, chartComponent.context.height, chartComponent.context.width);
				}
			};
			yAxis.refreshComponent();
		}

		internal override void UpdateAxisLabelText(Axis axis)
		{
			base.UpdateAxisLabelText(axis);
			if (!axis.IsTime() && !axis.IsValue())
			{
				return;
			}
			for (int i = 0; i < axis.context.labelObjectList.Count; i++)
			{
				ChartLabel chartLabel = axis.context.labelObjectList[i];
				if (chartLabel != null)
				{
					Vector3 labelPosition = GetLabelPosition(0f, i);
					chartLabel.SetPosition(labelPosition);
					CheckValueLabelActive(axis, i, chartLabel, labelPosition);
				}
			}
		}

		protected override Vector3 GetLabelPosition(float scaleWid, int i)
		{
			GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(base.component.gridIndex);
			if (chartComponent == null)
			{
				return Vector3.zero;
			}
			XAxis chartComponent2 = base.chart.GetChartComponent<XAxis>(base.component.index);
			return AxisHandler<YAxis>.GetLabelPosition(i, Orient.Vertical, base.component, chartComponent2, base.chart.theme.axis, scaleWid, chartComponent.context.x, chartComponent.context.y, chartComponent.context.height, chartComponent.context.width);
		}

		private void DrawYAxisSplit(VertexHelper vh, int yAxisIndex, YAxis yAxis)
		{
			if (AxisHelper.NeedShowSplit(yAxis))
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
				if (chartComponent != null)
				{
					XAxis chartComponent2 = base.chart.GetChartComponent<XAxis>(yAxis.gridIndex);
					DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(yAxis);
					DrawAxisSplit(vh, base.chart.theme.axis, dataZoomOfAxis, Orient.Vertical, chartComponent.context.x, chartComponent.context.y, chartComponent.context.height, chartComponent.context.width, chartComponent2);
				}
			}
		}

		private void DrawYAxisTick(VertexHelper vh, int yAxisIndex, YAxis yAxis)
		{
			if (AxisHelper.NeedShowSplit(yAxis))
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
				if (chartComponent != null)
				{
					DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(yAxis);
					AxisHandler<YAxis>.DrawAxisTick(vh, yAxis, base.chart.theme.axis, dataZoomOfAxis, Orient.Vertical, GetAxisLineXOrY(), chartComponent.context.y, chartComponent.context.height);
				}
			}
		}

		private void DrawYAxisLine(VertexHelper vh, int yAxisIndex, YAxis yAxis)
		{
			if (yAxis.show && yAxis.axisLine.show)
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(yAxis.gridIndex);
				if (chartComponent != null)
				{
					AxisHandler<YAxis>.DrawAxisLine(vh, yAxis, base.chart.theme.axis, Orient.Vertical, GetAxisLineXOrY(), chartComponent.context.y, chartComponent.context.height);
				}
			}
		}

		internal override float GetAxisLineXOrY()
		{
			return base.component.context.x;
		}
	}
}
