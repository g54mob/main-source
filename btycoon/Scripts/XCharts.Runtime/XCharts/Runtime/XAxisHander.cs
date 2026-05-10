using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class XAxisHander : AxisHandler<XAxis>
	{
		protected override Orient orient => Orient.Horizonal;

		public override void InitComponent()
		{
			InitXAxis(base.component);
		}

		public override void Update()
		{
			UpdateAxisMinMaxValue(base.component.index, base.component);
			UpdatePointerValue(base.component);
		}

		public override void DrawBase(VertexHelper vh)
		{
			UpdatePosition(base.component);
			DrawXAxisSplit(vh, base.component);
			DrawXAxisLine(vh, base.component);
			DrawXAxisTick(vh, base.component);
		}

		private void UpdatePosition(XAxis axis)
		{
			GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(axis.gridIndex);
			if (chartComponent != null)
			{
				YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(axis.gridIndex);
				axis.context.x = chartComponent.context.x;
				axis.context.y = AxisHelper.GetXAxisXOrY(chartComponent, axis, chartComponent2);
				axis.context.zeroY = chartComponent.context.y;
				axis.context.zeroX = chartComponent.context.x + axis.context.offset;
			}
		}

		private void InitXAxis(XAxis xAxis)
		{
			_ = base.chart.theme;
			_ = xAxis.index;
			xAxis.painter = base.chart.painter;
			xAxis.refreshComponent = delegate
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(xAxis.gridIndex);
				if (chartComponent != null)
				{
					YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(xAxis.index);
					InitAxis(chartComponent2, orient, chartComponent.context.x, chartComponent.context.y, chartComponent.context.width, chartComponent.context.height);
				}
			};
			xAxis.refreshComponent();
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
					CheckValueLabelActive(base.component, i, chartLabel, labelPosition);
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
			YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(base.component.index);
			return AxisHandler<XAxis>.GetLabelPosition(i, Orient.Horizonal, base.component, chartComponent2, base.chart.theme.axis, scaleWid, chartComponent.context.x, chartComponent.context.y, chartComponent.context.width, chartComponent.context.height);
		}

		private void DrawXAxisSplit(VertexHelper vh, XAxis xAxis)
		{
			if (AxisHelper.NeedShowSplit(xAxis))
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(xAxis.gridIndex);
				if (chartComponent != null)
				{
					YAxis chartComponent2 = base.chart.GetChartComponent<YAxis>(xAxis.gridIndex);
					DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(xAxis);
					DrawAxisSplit(vh, base.chart.theme.axis, dataZoomOfAxis, Orient.Horizonal, chartComponent.context.x, chartComponent.context.y, chartComponent.context.width, chartComponent.context.height, chartComponent2);
				}
			}
		}

		private void DrawXAxisTick(VertexHelper vh, XAxis xAxis)
		{
			if (AxisHelper.NeedShowSplit(xAxis))
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(xAxis.gridIndex);
				if (chartComponent != null)
				{
					DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(xAxis);
					AxisHandler<XAxis>.DrawAxisTick(vh, xAxis, base.chart.theme.axis, dataZoomOfAxis, Orient.Horizonal, chartComponent.context.x, GetAxisLineXOrY(), chartComponent.context.width);
				}
			}
		}

		private void DrawXAxisLine(VertexHelper vh, XAxis xAxis)
		{
			if (xAxis.show && xAxis.axisLine.show)
			{
				GridCoord chartComponent = base.chart.GetChartComponent<GridCoord>(xAxis.gridIndex);
				if (chartComponent != null)
				{
					AxisHandler<XAxis>.DrawAxisLine(vh, xAxis, base.chart.theme.axis, Orient.Horizonal, chartComponent.context.x, GetAxisLineXOrY(), chartComponent.context.width);
				}
			}
		}

		internal override float GetAxisLineXOrY()
		{
			return base.component.context.y;
		}
	}
}
