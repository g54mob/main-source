using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[RequireChartComponent(typeof(ParallelCoord))]
	[ComponentHandler(typeof(ParallelAxisHander), true)]
	public class ParallelAxis : Axis
	{
		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Type = AxisType.Value;
			m_Min = 0.0;
			m_Max = 0.0;
			m_SplitNumber = 0;
			m_BoundaryGap = true;
			m_Position = AxisPosition.Bottom;
			m_Offset = 0f;
			m_Data = new List<string> { "x1", "x2", "x3", "x4", "x5" };
			m_Icons = new List<Sprite>(5);
			base.splitLine.show = false;
			base.splitLine.lineStyle.type = LineStyle.Type.None;
			base.axisLabel.textLimit.enable = true;
			base.axisName.labelStyle.offset = new Vector3(0f, 25f, 0f);
		}
	}
}
