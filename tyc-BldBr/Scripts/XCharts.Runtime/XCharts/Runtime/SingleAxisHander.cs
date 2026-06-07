using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[Preserve]
	internal sealed class SingleAxisHander : AxisHandler<SingleAxis>
	{
		protected override Orient orient => base.component.orient;

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
			DrawSingleAxisSplit(vh, base.component);
			DrawSingleAxisLine(vh, base.component);
			DrawSingleAxisTick(vh, base.component);
		}

		private void InitXAxis(SingleAxis axis)
		{
			_ = base.chart.theme;
			_ = axis.index;
			axis.painter = base.chart.painter;
			axis.refreshComponent = delegate
			{
				axis.UpdateRuntimeData(base.chart);
				InitAxis(null, axis.orient, axis.context.x, axis.context.y, axis.context.width, axis.context.height);
			};
			axis.refreshComponent();
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
			return AxisHandler<SingleAxis>.GetLabelPosition(i, base.component.orient, base.component, null, base.chart.theme.axis, scaleWid, base.component.context.x, base.component.context.y, base.component.context.width, base.component.context.height);
		}

		private void DrawSingleAxisSplit(VertexHelper vh, SingleAxis axis)
		{
			if (AxisHelper.NeedShowSplit(axis))
			{
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				DrawAxisSplit(vh, base.chart.theme.axis, dataZoomOfAxis, axis.orient, axis.context.x, axis.context.y, axis.context.width, axis.context.height);
			}
		}

		private void DrawSingleAxisTick(VertexHelper vh, SingleAxis axis)
		{
			if (AxisHelper.NeedShowSplit(axis))
			{
				DataZoom dataZoomOfAxis = base.chart.GetDataZoomOfAxis(axis);
				AxisHandler<SingleAxis>.DrawAxisTick(vh, axis, base.chart.theme.axis, dataZoomOfAxis, axis.orient, axis.context.x, axis.context.y, axis.context.width);
			}
		}

		private void DrawSingleAxisLine(VertexHelper vh, SingleAxis axis)
		{
			if (axis.show && axis.axisLine.show)
			{
				AxisHandler<SingleAxis>.DrawAxisLine(vh, axis, base.chart.theme.axis, axis.orient, axis.context.x, GetAxisLineXOrY(), axis.context.width);
			}
		}

		internal override float GetAxisLineXOrY()
		{
			return base.component.context.y + base.component.offset;
		}
	}
}
