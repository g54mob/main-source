using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisSplitLine : BaseLine
	{
		[SerializeField]
		private int m_Interval;

		[SerializeField]
		private float m_Distance;

		[SerializeField]
		private bool m_AutoColor;

		[SerializeField]
		[Since("v3.3.0")]
		private bool m_ShowStartLine = true;

		[SerializeField]
		[Since("v3.3.0")]
		private bool m_ShowEndLine = true;

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

		public int interval
		{
			get
			{
				return m_Interval;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_Interval, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showStartLine
		{
			get
			{
				return m_ShowStartLine;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowStartLine, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showEndLine
		{
			get
			{
				return m_ShowEndLine;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowEndLine, value))
				{
					SetVerticesDirty();
				}
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

		public static AxisSplitLine defaultSplitLine => new AxisSplitLine
		{
			m_Show = false
		};

		public override void ClearVerticesDirty()
		{
			base.ClearVerticesDirty();
			m_LineStyle.ClearVerticesDirty();
		}

		public AxisSplitLine Clone()
		{
			return new AxisSplitLine
			{
				show = base.show,
				interval = interval,
				showStartLine = showStartLine,
				showEndLine = showEndLine,
				lineStyle = base.lineStyle.Clone()
			};
		}

		public void Copy(AxisSplitLine splitLine)
		{
			Copy((BaseLine)splitLine);
			interval = splitLine.interval;
			showStartLine = splitLine.showStartLine;
			showEndLine = splitLine.showEndLine;
		}

		internal bool NeedShow(int index, int total)
		{
			if (!base.show)
			{
				return false;
			}
			if (interval != 0 && index % (interval + 1) != 0)
			{
				return false;
			}
			if (!showStartLine && index == 0)
			{
				return false;
			}
			if (!showEndLine && index == total - 1)
			{
				return false;
			}
			return true;
		}
	}
}
