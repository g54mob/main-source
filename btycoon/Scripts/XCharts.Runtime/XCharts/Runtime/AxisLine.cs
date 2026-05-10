using System;
using UnityEngine;

namespace XCharts.Runtime
{
	[Serializable]
	public class AxisLine : BaseLine
	{
		[SerializeField]
		private bool m_OnZero;

		[SerializeField]
		private bool m_ShowArrow;

		[SerializeField]
		private ArrowStyle m_Arrow = new ArrowStyle();

		public bool onZero
		{
			get
			{
				return m_OnZero;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_OnZero, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public bool showArrow
		{
			get
			{
				return m_ShowArrow;
			}
			set
			{
				if (PropertyUtil.SetStruct(ref m_ShowArrow, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public ArrowStyle arrow
		{
			get
			{
				return m_Arrow;
			}
			set
			{
				if (PropertyUtil.SetClass(ref m_Arrow, value))
				{
					SetVerticesDirty();
				}
			}
		}

		public static AxisLine defaultAxisLine => new AxisLine
		{
			m_Show = true,
			m_OnZero = true,
			m_ShowArrow = false,
			m_Arrow = new ArrowStyle(),
			m_LineStyle = new LineStyle(LineStyle.Type.None)
		};

		public AxisLine Clone()
		{
			return new AxisLine
			{
				show = base.show,
				onZero = onZero,
				showArrow = showArrow,
				arrow = arrow.Clone()
			};
		}

		public void Copy(AxisLine axisLine)
		{
			Copy((BaseLine)axisLine);
			onZero = axisLine.onZero;
			showArrow = axisLine.showArrow;
			arrow.Copy(axisLine.arrow);
		}
	}
}
