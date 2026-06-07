using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class VisualMapRange : ChildComponent
	{
		[SerializeField]
		private double m_Min;

		[SerializeField]
		private double m_Max;

		[SerializeField]
		private string m_Label;

		[SerializeField]
		private Color32 m_Color;

		public double min
		{
			get
			{
				return m_Min;
			}
			set
			{
				m_Min = value;
			}
		}

		public double max
		{
			get
			{
				return m_Max;
			}
			set
			{
				m_Max = value;
			}
		}

		public string label
		{
			get
			{
				return m_Label;
			}
			set
			{
				m_Label = value;
			}
		}

		public Color32 color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public bool Contains(double value, double minMaxRange)
		{
			if (m_Min == 0.0 && m_Max == 0.0)
			{
				return false;
			}
			double num = ((Math.Abs(m_Min) < 1.0) ? (minMaxRange * m_Min) : m_Min);
			double num2 = ((Math.Abs(m_Max) < 1.0) ? (minMaxRange * m_Max) : m_Max);
			if (value >= num)
			{
				return value < num2;
			}
			return false;
		}
	}
}
