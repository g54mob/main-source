using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class StageColor : ChildComponent
	{
		[SerializeField]
		private float m_Percent;

		[SerializeField]
		private Color32 m_Color;

		public float percent
		{
			get
			{
				return m_Percent;
			}
			set
			{
				m_Percent = value;
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

		public StageColor(float percent, Color32 color)
		{
			m_Percent = percent;
			m_Color = color;
		}
	}
}
