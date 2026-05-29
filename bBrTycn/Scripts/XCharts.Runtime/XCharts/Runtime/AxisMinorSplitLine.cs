using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	[Since("v3.2.0")]
	public class AxisMinorSplitLine : BaseLine
	{
		[SerializeField]
		private float m_Distance;

		[SerializeField]
		private bool m_AutoColor;

		public float distance
		{
			get
			{
				return m_Distance;
			}
			set
			{
				m_Distance = value;
			}
		}

		public bool autoColor
		{
			get
			{
				return m_AutoColor;
			}
			set
			{
				m_AutoColor = value;
			}
		}

		public override bool vertsDirty
		{
			get
			{
				if (!m_VertsDirty)
				{
					return m_LineStyle.anyDirty;
				}
				return true;
			}
		}

		public static AxisMinorSplitLine defaultMinorSplitLine => new AxisMinorSplitLine
		{
			m_Show = false
		};

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			m_LineStyle.ClearVerticesDirty();
		}

		public AxisMinorSplitLine Clone()
		{
			return new AxisMinorSplitLine
			{
				show = base.show,
				distance = distance,
				autoColor = autoColor,
				lineStyle = base.lineStyle.Clone()
			};
		}

		public void Copy(AxisMinorSplitLine splitLine)
		{
			Copy((BaseLine)splitLine);
			distance = splitLine.distance;
			autoColor = splitLine.autoColor;
		}
	}
}
