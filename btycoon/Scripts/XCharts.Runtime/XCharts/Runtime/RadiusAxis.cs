using System;
using System.Collections.Generic;

namespace XCharts.Runtime
{
	[Serializable]
	[RequireChartComponent(typeof(PolarCoord))]
	[ComponentHandler(typeof(RadiusAxisHandler), true)]
	public class RadiusAxis : Axis
	{
		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Type = AxisType.Value;
			m_Min = 0.0;
			m_Max = 0.0;
			m_SplitNumber = 5;
			m_BoundaryGap = false;
			m_Data = new List<string>(5);
			base.splitLine.show = true;
			base.splitLine.lineStyle.type = LineStyle.Type.Solid;
			base.axisLabel.textLimit.enable = false;
		}
	}
}
