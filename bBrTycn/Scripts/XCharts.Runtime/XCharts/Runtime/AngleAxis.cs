using System;
using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[RequireChartComponent(typeof(PolarCoord))]
	[ComponentHandler(typeof(AngleAxisHandler), true)]
	public class AngleAxis : Axis
	{
		[SerializeField]
		private float m_StartAngle;

		public float startAngle
		{
			get
			{
				return m_StartAngle;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_StartAngle, value))
				{
					SetAllDirty();
				}
			}
		}

		public float GetValueAngle(float value)
		{
			return (value + context.startAngle + 360f) % 360f;
		}

		public float GetValueAngle(double value)
		{
			return (float)(value + (double)context.startAngle + 360.0) % 360f;
		}

		public override void SetDefaultValue()
		{
			m_Show = true;
			m_Type = AxisType.Value;
			m_SplitNumber = 12;
			m_StartAngle = 0f;
			m_BoundaryGap = false;
			m_Data = new List<string>(12);
			base.splitLine.show = true;
			base.splitLine.lineStyle.type = LineStyle.Type.Solid;
			base.axisLabel.textLimit.enable = false;
			base.minMaxType = AxisMinMaxType.Custom;
			base.min = 0.0;
			base.max = 360.0;
		}
	}
}
