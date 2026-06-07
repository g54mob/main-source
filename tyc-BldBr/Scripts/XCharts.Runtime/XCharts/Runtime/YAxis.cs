using System;
using System.Collections.Generic;

namespace XCharts.Runtime
{
	[Serializable]
	[RequireChartComponent(typeof(GridCoord), typeof(XAxis))]
	[ComponentHandler(typeof(YAxisHander), true)]
	public class YAxis : Axis
	{
		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Type = AxisType.Value;
			m_Min = 0.0;
			m_Max = 0.0;
			m_SplitNumber = 0;
			m_BoundaryGap = false;
			m_Position = AxisPosition.Left;
			m_Data = new List<string>(5);
			base.splitLine.show = true;
			base.splitLine.lineStyle.type = LineStyle.Type.None;
			base.axisLabel.textLimit.enable = false;
			base.axisTick.showStartTick = true;
		}
	}
}
